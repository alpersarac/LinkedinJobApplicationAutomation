
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedinJobApplier.Config
{
    public class Linkedin
    {
        private IWebDriver driver;

        public Linkedin()
        {
            string browser = Config.Browser.ToLower();
            string linkedinEmail = Config.Email;

            if (browser == "firefox")
            {
                if (string.IsNullOrEmpty(linkedinEmail))
                {
                    Console.WriteLine("On Linux you need to define profile path to run the bot with Firefox. Go about:profiles find root directory of your profile paste in line 8 of config file next to firefoxProfileRootDir");
                    //Environment.Exit(0);
                }
                else
                {
                    FirefoxOptions options = new FirefoxOptions();
                    options.Profile = new FirefoxProfile();
                    driver = new FirefoxDriver(OpenQA.Selenium.Firefox.FirefoxDriverService.CreateDefaultService(), options);
                }
            }
            else if (browser == "chrome")
            {
                driver = new ChromeDriver();
            }
            else
            {
                Console.WriteLine("Invalid browser specified in config.");
                Environment.Exit(0);
            }

            driver.Navigate().GoToUrl("https://www.linkedin.com/login?trk=guest_homepage-basic_nav-header-signin");
            Console.WriteLine("Trying to log in to LinkedIn.");

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var usernameField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("username")));
                //var usernameField = driver.FindElement(By.Id("username"));
                usernameField.SendKeys(linkedinEmail);

                var passwordField = driver.FindElement(By.Id("password"));
                passwordField.SendKeys(Config.Password);

                var loginButton = driver.FindElement(By.XPath("//*[@id='organic-div']/form/div[3]/button"));
                loginButton.Click();

                Console.WriteLine("Logged in to LinkedIn.");
                Console.WriteLine("CAPTCHA DELAY");
                //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(Constants.CaptaTime));
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                Console.WriteLine(ex.Message);
                Cleanup();
                Environment.Exit(0);
            }
        }

        private void Cleanup()
        {
            driver.Quit();
            driver.Dispose();
        }

        public IWebDriver getWebDriver()
        {
            return driver;
        }

        public void LinkInfoExtract(CancellationToken cancellationToken, string title)
        {
            string peopleLink = "https://www.linkedin.com/search/results/people/?keywords="+ title + "&origin=SWITCH_SEARCH_VERTICAL";
            driver.Url = peopleLink;
            int totalPages = Utils.GetPageCountForInfoExtract(driver);
            for (int page = 1; page < totalPages; page++)
            {
                
                var currentUrl = peopleLink + "&page=" + page;
                driver.Url = currentUrl;

                ReadOnlyCollection<IWebElement> resultListElements = driver.FindElements(By.CssSelector(".reusable-search__entity-result-list.list-style-none"));

                List<string> links = new List<string>();
                foreach (IWebElement resultListElement in resultListElements)
                {
                    // Find all elements with the class "display-flex" within the current result list element
                    ReadOnlyCollection<IWebElement> displayFlexElements = resultListElement.FindElements(By.CssSelector(".display-flex"));

                    foreach (IWebElement displayFlexElement in displayFlexElements)
                    {
                        // Find anchor elements within each display-flex element
                        ReadOnlyCollection<IWebElement> anchorElements = displayFlexElement.FindElements(By.TagName("a"));

                        foreach (IWebElement anchorElement in anchorElements)
                        {
                            string href = anchorElement.GetAttribute("href");
                            links.Add(href.Split(new string[] { "?miniProfile" }, StringSplitOptions.None)[0]);
                        }
                    } 
                }

                foreach (var profile in links.Distinct())
                {
                    driver.Url = profile + "/overlay/contact-info/";
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    var ww = Utils.FindEmailAndPhoneNumbers(driver);

                }



            }

        }
        public void LinkJobApply(CancellationToken cancellationToken)
        {
            try
            {
                Utils.GenerateUrls();
                int countApplied = 0;
                int countJobs = 0;

                List<string> urlData = Utils.getUrlDataFile();
                var distinctUrls = urlData.Distinct();

                foreach (string url in distinctUrls)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    List<string> urlWords = new List<string>();
                    try
                    {
                        driver.Url = url;
                        Thread.Sleep(TimeSpan.FromSeconds(5));

                        string totalJobs = driver.FindElement(By.XPath("//small")).Text;
                        int totalPages = Utils.GetPageCount(driver);
                        totalPages = Utils.jobsToPages(totalJobs);

                        urlWords = Utils.urlToKeywords(url);
                        string lineToWrite = "\nCategory: " + urlWords[0] + ", Location: " + urlWords[1] + ", Applying to " + totalJobs + " jobs.";

                        for (int page = 0; page < totalPages; page++)
                        {
                            try
                            {
                                int currentPageJobs = Constants.JobsPerPage * page;
                                var currentUrl = url + "&start=" + currentPageJobs;
                                driver.Url = currentUrl;
                                Thread.Sleep(TimeSpan.FromSeconds(5));

                                List<long> offerIds = new List<long>();
                                try
                                {
                                    ReadOnlyCollection<IWebElement> offersPerPage = driver.FindElements(By.XPath("//li[@data-occsludable-job-id]"));
                                    if (offersPerPage.Count == 0)
                                    {
                                        offersPerPage = driver.FindElements(By.XPath("//li[@data-occludable-job-id]"));
                                    }
                                    Console.WriteLine("Number of offers on this page: " + offersPerPage.Count);
                                    Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));

                                    foreach (IWebElement offer in offersPerPage)
                                    {
                                        string offerId = offer.GetAttribute("data-occludable-job-id");
                                        if (!Utils.AppliedBefore(offer))
                                            offerIds.Add(long.Parse(offerId.Split(':').Last()));
                                    }
                                }
                                catch (Exception ex)
                                {
                                    
                                    Console.WriteLine("Exception occurred while fetching offer details from the page!");
                                }

                                if (offerIds.Count == 0)
                                    break;

                                foreach (long jobID in offerIds)
                                {
                                    if (cancellationToken.IsCancellationRequested)
                                        break;

                                    string offerPage = "https://www.linkedin.com/jobs/view/" + jobID;
                                    driver.Url = offerPage;
                                    Thread.Sleep(TimeSpan.FromSeconds(5));

                                    countJobs++;

                                    string jobProperties = Utils.GetJobProperties(countJobs, driver);
                                    Utils.prYellow($"{jobProperties} --> Page {page + 1} of {totalPages}");

                                    IWebElement button = Utils.EasyApplyButton(driver);
                                    IWebElement linkApplyButton = Utils.LinkApplyButton(driver);

                                    if (button != null && linkApplyButton == null)
                                    {
                                        button.Click();
                                        Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));
                                        countApplied++;

                                        try
                                        {
                                            bool isApplied = Utils.SubmitApplication(jobProperties, offerPage, driver);
                                            if (!isApplied)
                                            {
                                                int counter = 0;
                                                string currentValueOfPercent = "";
                                                string previousValueOfPercent = "";

                                                for (int i = 0; i < 15; i++)
                                                {
                                                    Console.WriteLine($"----> Step {i + 1} <----");
                                                    currentValueOfPercent = Utils.ContinueNextStep(driver);
                                                    Utils.EnterCityName(driver);
                                                    Utils.EnterSalaryExpectations(driver);
                                                    Utils.CheckTermsAndConditionsCheckbox(driver);
                                                    Utils.SelectVisaRequirement(driver,"No");
                                                    Utils.SelectCommuteComfort(driver, "Yes");
                                                    Utils.EnterStartDate(driver, "14days");
                                                    if (currentValueOfPercent != previousValueOfPercent)
                                                    {
                                                        previousValueOfPercent = currentValueOfPercent;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }

                                                    if (Utils.ReviewTheApplication(jobProperties, offerPage, ref counter, driver))
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Unable to fill all fields");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Already applied to this job!");
                                    }

                                    if (linkApplyButton != null)
                                    {
                                        lineToWrite = jobProperties + " | " + "* EXTERNAL LINK APPLICATION: " + offerPage;
                                        Utils.DisplayWriteResults(lineToWrite);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception occurred on Page " + page + ": " + url);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception occurred while processing URL: " + url);
                        Console.WriteLine("Error: " + e.ToString());
                    }

                    Console.WriteLine("Category: " + urlWords[0] + ", " + urlWords[1] + " - Applied: " + countApplied +
                        " jobs out of " + countJobs + ".");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Cleanup();
            }

            Utils.prGreen("All tasks completed!");
            System.Windows.Forms.MessageBox.Show("All jobs are completed!");
        }

    }
}







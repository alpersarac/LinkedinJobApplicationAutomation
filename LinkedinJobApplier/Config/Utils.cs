using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LinkedinJobApplier.Config
{
    public static class Utils
    {
        public static FirefoxOptions browserOptions()
        {
            var options = new FirefoxOptions();
            var firefoxProfileRootDir = Config.FirefoxProfileRootDir;
            options.AddArgument("--start-maximized");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu");
            if (Config.Headless)
            {
                options.AddArgument("--headless");
            }

            options.AddArgument("--disable-blink-features");
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument("--incognito");
            options.AddArgument("-profile");
            options.AddArgument(firefoxProfileRootDir);

            return options;
        }

        public static void prRed(string prt)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{prt}");
            Console.ResetColor();
        }

        public static void prGreen(string prt)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{prt}");
            Console.ResetColor();
        }

        public static void prYellow(string prt)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{prt}");
            Console.ResetColor();
        }

        public static List<string> getUrlDataFile()
        {
            var urlData = new List<string>();
            try
            {
                var file = new StreamReader("data/urlData.txt");
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    urlData.Add(line);
                }
                file.Close();
            }
            catch (FileNotFoundException)
            {
                var text = "FileNotFound:urlData.txt file is not found. Please run ./data folder exists and check config.py values of yours. Then run the bot again";
                prRed(text);
            }
            return urlData;
        }

        public static int jobsToPages(string numOfJobs)
        {
            var number_of_pages = 1;

            if (numOfJobs.Contains(" "))
            {
                var spaceIndex = numOfJobs.IndexOf(' ');
                var totalJobs = numOfJobs.Substring(0, spaceIndex);
                var totalJobs_int = int.Parse(totalJobs.Replace(",", ""));
                number_of_pages = (int)Math.Ceiling((double)(totalJobs_int));
                if (number_of_pages > 40)
                {
                    number_of_pages = 40;
                }
            }
            else
            {
                number_of_pages = int.Parse(numOfJobs);
            }

            return number_of_pages;
        }

        public static List<string> urlToKeywords(string url)
        {
            var keywordUrl = url.Substring(url.IndexOf("keywords=") + 9);
            var keyword = keywordUrl.Substring(0, keywordUrl.IndexOf("&"));
            var locationUrl = url.Substring(url.IndexOf("location=") + 9);
            var location = locationUrl.Substring(0, locationUrl.IndexOf("&"));
            return new List<string> { keyword, location };
        }

        public static void writeResults(string text)
        {
            var timeStr = DateTime.Now.ToString("yyyyMMdd");
            var fileName = "Applied Jobs DATA - " + timeStr + ".txt";
            try
            {
                var lines = new List<string>();
                using (var file = new StreamReader("data/" + fileName, System.Text.Encoding.UTF8))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (!line.Contains("----"))
                        {
                            lines.Add(line);
                        }
                    }
                }

                using (var f = new StreamWriter("data/" + fileName, false, System.Text.Encoding.UTF8))
                {
                    f.WriteLine("---- Applied Jobs Data ---- created at: " + timeStr);
                    f.WriteLine("---- Number | Job Title | Company | Location | Work Place | Posted Date | Applications | Result");
                    foreach (var line in lines)
                    {
                        f.WriteLine(line);
                    }
                    f.WriteLine(text);
                }
            }
            catch (FileNotFoundException)
            {
                using (var f = new StreamWriter("data/" + fileName, false, System.Text.Encoding.UTF8))
                {
                    f.WriteLine("---- Applied Jobs Data ---- created at: " + timeStr);
                    f.WriteLine("---- Number | Job Title | Company | Location | Work Place | Posted Date | Applications | Result");
                    f.WriteLine(text);
                }
            }
        }

        public static void printInfoMes(string bot)
        {
            prYellow("ℹ️ " + bot + " is starting soon... ");
        }

        public static void donate()
        {
            //prYellow("If you like the project, please support me so that I can make more such projects, thanks!");
            //try
            //{
            //    driver.Navigate().GoToUrl("https://commerce.coinbase.com/checkout/576ee011-ba40-47d5-9672-ef7ad29b1e6c");
            //}
            //catch (Exception e)
            //{
            //    prRed("Error in donate: " + e.Message);
            //}
        }

        public static string ContinueNextStep(IWebDriver driver)
        {
            string currentValue = "";
            IReadOnlyCollection<IWebElement> progressElements = driver.FindElements(By.CssSelector("progress.artdeco-completeness-meter-linear__progress-element"));

            driver.FindElement(By.CssSelector("button[aria-label='Continue to next step']")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));
            if (progressElements.Count > 0)
            {
                IWebElement progressElement = driver.FindElement(By.CssSelector("progress.artdeco-completeness-meter-linear__progress-element"));
                currentValue = progressElement.GetAttribute("aria-valuenow");
            }
            return currentValue;
        }
        public static bool SubmitApplication(string jobProperties, string offerPage, IWebDriver driver)
        {
            bool isApplied = false;
            Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector("button[aria-label='Submit application']"));
            Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));

            if (elements.Count > 0)
            {
                driver.FindElement(By.CssSelector("button[aria-label='Submit application']")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));

                string lineToWrite = jobProperties + " | " + "* ## SUCCESS ##: " + offerPage;
                DisplayWriteResults(lineToWrite);

                Console.WriteLine(("Successful Job App Count ##-->") + (++Config.successfulJobApplicationCounter) + "<--##");
                isApplied = true;

            }
            return isApplied;
        }
        public static bool ReviewTheApplication(string jobProperties, string offerPage, ref int counter, IWebDriver driver)
        {
            Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));
            ReadOnlyCollection<IWebElement> buttons = driver.FindElements(By.CssSelector("button[aria-label='Review your application']"));
            Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));
            if (buttons.Count > 0)
            {
                counter++;
                Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));
                driver.FindElement(By.CssSelector("button[aria-label='Review your application']")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));
            }
            Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));
            return SubmitApplication(jobProperties, offerPage,driver);
        }

        public static string CheckRadioButtons(IWebDriver driver)
        {
            try
            {
                var radioExistence = driver.FindElement(By.CssSelector("label.t-14"));
                if (radioExistence != null)
                {
                    radioExistence.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));
                }
                if (!Config.FollowCompanies)
                {
                    driver.FindElement(By.CssSelector("label[for='follow-company-checkbox']")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(new Random().NextDouble() * Constants.BotSpeed));
                }

                return "";
            }
            catch (Exception)
            {
                return "%%% xXx -- Exception while selecting Radio Button";
            }




        }

        public static IWebElement EasyApplyButton(IWebDriver driver)
        {
            try
            {
                IWebElement button = driver.FindElement(By.XPath("//button[contains(@class, 'jobs-apply-button')]"));
                return button;
            }
            catch
            {
                return null;
            }
        }
        public static IWebElement LinkApplyButton(IWebDriver driver)
        {
            try
            {
                IWebElement linkApplyButton = driver.FindElement(By.XPath("//span[text()='Apply']"));
                return linkApplyButton;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public static string GetJobProperties(int count, IWebDriver driver)
        {
            string textToWrite = "";
            string jobTitle = "";
            string jobCompany = "";
            string jobLocation = "";
            string jobWorkPlace = "";
            string jobPostedDate = "";
            string jobApplications = "";

            try
            {
                jobTitle = driver.FindElement(By.XPath("//h1[contains(@class, 'job-title')]")).GetAttribute("innerHTML").Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine("Warning in getting jobTitle: " + e.Message.Substring(0, 50));
                jobTitle = "";
            }
            //try
            //{
            //    jobCompany = driver.FindElement(By.XPath("//a[contains(@class, 'ember-view t-black t-normal')]")).GetAttribute("innerHTML").Trim();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Warning in getting jobCompany: " + e.Message.Substring(0, 50));
            //    jobCompany = "";
            //}
            try
            {
                jobLocation = driver.FindElement(By.XPath("//span[contains(@class, 'bullet')]")).GetAttribute("innerHTML").Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine("Warning in getting jobLocation: " + e.Message.Substring(0, 50));
                jobLocation = "";
            }
            //try
            //{
            //    jobWorkPlace = driver.FindElement(By.XPath("//span[contains(@class, 'workplace-type')]")).GetAttribute("innerHTML").Trim();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Warning in getting jobWorkPlace: " + e.Message.Substring(0, 50));
            //    jobWorkPlace = "";
            //}
            //try
            //{
            //    jobPostedDate = driver.FindElement(By.XPath("//span[contains(@class, 'posted-date')]")).GetAttribute("innerHTML").Trim();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Warning in getting jobPostedDate: " + e.Message.Substring(0, 50));
            //    jobPostedDate = "";
            //}
            //try
            //{
            //    jobApplications = driver.FindElement(By.XPath("//span[contains(@class, 'applicant-count')]")).GetAttribute("innerHTML").Trim();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Warning in getting jobApplications: " + e.Message.Substring(0, 50));
            //    jobApplications = "";
            //}

            textToWrite = $"{count} ### Location: {jobLocation} ### Title: {jobTitle}";
            //textToWrite = count + " | " + jobTitle + " | " + jobCompany + " | " + jobLocation + " | " + jobWorkPlace + " | " + jobPostedDate + " | " + jobApplications;

            return textToWrite;
        }
        public static void DisplayWriteResults(string lineToWrite)
        {
            try
            {
                Console.WriteLine(lineToWrite);
                Utils.writeResults(lineToWrite);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in DisplayWriteResults: " + e.Message);
            }
        }
        public static int GetPageCount(IWebDriver driver)
        {
            string lastPageValue = string.Empty;
            int lastPage = 1;
            try
            {
                IWebElement lastPageElement = driver.FindElement(By.CssSelector(".artdeco-pagination__pages--number li:last-child span"));
                lastPageValue = lastPageElement.Text;
                int.TryParse(lastPageValue, out lastPage);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("page count exception");
                // Handle the case where the last page element is not found
                // You can provide an alternative behavior or error handling here
            }
            return lastPage;

        }
        public static void GenerateUrls()
        {
            if (!System.IO.Directory.Exists("data"))
            {
                System.IO.Directory.CreateDirectory("data");
            }

            try
            {
                using (var file = new System.IO.StreamWriter("data/urlData.txt", false, System.Text.Encoding.UTF8))
                {
                    LinkedinUrlGenerate linkedinUrlGenerate = new LinkedinUrlGenerate();
                    var linkedinJobLinks = linkedinUrlGenerate.generateUrlLinks();
                    foreach (var url in linkedinJobLinks)
                    {
                        file.WriteLine(url);
                    }
                }

                Console.WriteLine("URLs are created successfully. Now the bot will visit those URLs.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't generate URL. Make sure you have the 'data' folder and modified 'config.cs' file for your preferences.");
                Console.WriteLine(e.Message);
            }
        }
        public static bool AppliedBefore(IWebElement offer)
        {
            try
            {
                IWebElement appliedElement = offer.FindElement(By.XPath(".//li[contains(@class, 'job-card-container__footer-item') and contains(@class, 'inline-flex') and contains(@class, 'align-items-center')]"));

                string innerText = appliedElement.Text;

                if (innerText.Contains("Applied"))
                {
                    Console.WriteLine("Applied");
                    return true;
                }
                else
                {
                    Console.WriteLine("not Applied");
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Applied Check Exception");
                return false;
            }
        }
        public static void EnterStartDate(IWebDriver driver, string startDate)
        {
            try
            {
                string desiredLabel = "possible start date";
                IWebElement labelElement = driver.FindElement(By.CssSelector("div[id='ember378'] label"));
                string labelInnerText = labelElement.Text.ToLower();

                if (labelInnerText.Contains(desiredLabel))
                {
                    IWebElement inputElement = driver.FindElement(By.CssSelector("div[id='ember378'] input[type='text']"));

                    if (inputElement != null)
                    {
                        inputElement.Clear();
                        inputElement.SendKeys(startDate);
                        inputElement.SendKeys(Keys.Tab);
                    }
                }
            }
            catch (Exception)
            {
                // Handle exception
            }
        }

        public static void SelectCommutePreference(IWebDriver driver, string option)
        {
            try
            {
                string desiredLabel = "Are you comfortable commuting to this job's location?";
                IWebElement mainLabelElement = driver.FindElement(By.CssSelector("span.fb-dash-form-element__label"));

                if (mainLabelElement.Text.Contains(desiredLabel))
                {
                    string optionValue = option.ToLower();
                    IWebElement radioButtonElement = driver.FindElement(By.CssSelector($"input[data-test-text-selectable-option__input='{optionValue}']"));

                    if (radioButtonElement != null)
                    {
                        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                        jsExecutor.ExecuteScript("arguments[0].click();", radioButtonElement);
                    }
                }
            }
            catch (Exception)
            {
                // Handle exception
            }
        }

        public static void SelectVisaRequirement(IWebDriver driver,string option)
        {
            try
            {
                string desiredLabel = "Will you now or in the future require sponsorship for employment visa status?";
                IWebElement mainLabelElement = driver.FindElement(By.CssSelector("span.fb-dash-form-element__label"));

                if (mainLabelElement.Text.Contains(desiredLabel))
                {
                    IWebElement radioButtonElement = driver.FindElement(By.CssSelector("input[data-test-text-selectable-option__input='"+ option + "']"));

                    if (radioButtonElement != null)
                    {
                        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                        jsExecutor.ExecuteScript("arguments[0].click();", radioButtonElement);
                    }
                }
            }
            catch (Exception)
            {
                // Handle exception
            }
        }


        public static void CheckTermsAndConditionsCheckbox(IWebDriver driver)
        {
            try
            {
                string desiredLabel = "agree";
                IReadOnlyCollection<IWebElement> labelElements = driver.FindElements(By.CssSelector("label"));

                foreach (IWebElement labelElement in labelElements)
                {
                    string labelInnerText = labelElement.Text.ToLower();

                    if (labelInnerText.Contains(desiredLabel))
                    {
                        IWebElement checkboxElement = labelElement.FindElement(By.XPath("./preceding-sibling::input[@type='checkbox']"));

                        if (checkboxElement != null)
                        {
                            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                            jsExecutor.ExecuteScript("arguments[0].click();", checkboxElement);
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Handle exception
            }
        }


        public static void EnterSalaryExpectations(IWebDriver driver)
        {
            try
            {
                string desiredLabel = "salary";
                IReadOnlyCollection<IWebElement> labelElements = driver.FindElements(By.CssSelector("label"));
                string salaryExpectations = Config.SalaryExpectation;
                foreach (IWebElement labelElement in labelElements)
                {
                    string labelInnerText = labelElement.Text.ToLower();

                    if (labelInnerText.Contains(desiredLabel))
                    {
                        IWebElement inputElement = labelElement.FindElement(By.XPath("./following-sibling::input[@type='text']"));

                        inputElement.Clear();
                        inputElement.SendKeys(salaryExpectations);
                        inputElement.SendKeys(Keys.Tab);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Salary Exception");

            }

        }

        public static void EnterCityName(IWebDriver driver)
        {
            try
            {
                IWebElement comboboxElement = driver.FindElement(By.CssSelector("input[role='combobox'][id*='city']"));
                string desiredValue = Config.City;

                if (comboboxElement != null)
                {
                    comboboxElement.Clear();
                    comboboxElement.SendKeys(desiredValue);
                    comboboxElement.SendKeys(Keys.Tab);
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("##Error while Entring City");
            }

        }
        public static void ClickAllRadioButtonsAndSelectRandomOptions(IWebDriver driver)
        {
            
            try
            {
                // Find the specific <div> element
                IWebElement modalDiv = driver.FindElement(By.CssSelector("div.artdeco-modal[role='dialog']"));

                // Find the "Additional Questions" section
                IWebElement additionalQuestionsSection = modalDiv.FindElement(By.XPath("//h3[contains(text(), 'Additional')]/ancestor::div[@class='jobs-easy-apply-form-section__grouping']"));

                // Find all radio buttons within the "Additional Questions" section
                IReadOnlyList<IWebElement> radioButtons = additionalQuestionsSection.FindElements(By.CssSelector("input[type='radio']"));

                // Click all radio buttons
                foreach (IWebElement radioButton in radioButtons)
                {
                    radioButton.Click();
                }

                // Find all select elements within the "Additional Questions" section
                IReadOnlyList<IWebElement> selects = additionalQuestionsSection.FindElements(By.CssSelector("select"));

                // Select a random option in each select element
                Random random = new Random();
                foreach (IWebElement select in selects)
                {
                    // Get all the available options
                    IReadOnlyList<IWebElement> options = select.FindElements(By.CssSelector("option"));

                    // Select a random option
                    int randomIndex = random.Next(options.Count);
                    options[randomIndex].Click();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("cb ex");
            }
        }
    }
}

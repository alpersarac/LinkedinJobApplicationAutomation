using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJobApplier.Config
{
    public static class Config
    {
        public static string Browser = "chrome";
        // Optional! run browser in headless mode, no browser screen will be shown it will work in background.
        public static bool Headless = false;
        // Optional! for Firefox enter profile dir to run the bot without logging in your account each time
        //public static string FirefoxProfileRootDir = @"C:\Users\90507\AppData\Roaming\Mozilla\Firefox\Profiles\0cv53qd2.default-release-1687006000021";
        public static string FirefoxProfileRootDir = @"";
        // If you left above field empty enter your Linkedin password and username below
        // Linkedin credits
        public static string Email = "";
        public static string Password = "";

        // These settings are for running Linkedin job apply bot
        public static string LinkedinBotProPasswrod = "";

        //Custom Fields
        public static string City = "";
        public static string SalaryExpectation = "";
        public static string VisaRequirement = "";
        public static string CommutePreference = "";
        public static string NoticePeriod = "";

       
        public static string PhoneAndEmails = "";
        // location you want to search the jobs - ex : new List<string> { "Poland", "Germany", "Netherlands", "Austria", "Switzerland" }
        // continent locations: new List<string> { "Europe", "Asia", "Australia", "NorthAmerica", "SouthAmerica", "Africa", "Australia" }
        public static List<string> Location = new List<string>();
        // keywords related with your job search
        public static List<string> Keywords = new List<string>();
        // keywords = new List<string> { "programming" }
        // job experience Level - ex: new List<string> { "Internship", "Entry level", "Associate", "Mid-Senior level", "Director", "Executive" }
        public static List<string> ExperienceLevels = new List<string> { "Entry level", "Associate", "Mid-Senior level", "Director", "Executive" };
        // job posted date - ex: new List<string> { "Any Time", "Past Month", "Past Week", "Past 24 Hours" } - select only one
        public static List<string> DatePosted = new List<string>();
        // DatePosted = new List<string> { "Past 24 hours" }
        // job type - ex: new List<string> { "Full-time", "Part-time", "Contract", "Temporary", "Volunteer", "Intership", "Other" }
        public static List<string> JobType = new List<string> { "Full-time" };
        // remote - ex: new List<string> { "On-site", "Remote", "Hybrid" }
        public static List<string> Remote = new List<string> { "On-site", "Remote", "Hybrid" };
        // salary - ex: new List<string> { "$40,000+", "$60,000+", "$80,000+", "$100,000+", "$120,000+", "$140,000+", "$160,000+", "$180,000+", "$200,000+" } - select only one
        public static List<string> Salary = new List<string> { "€40,000+" };
        // sort - ex: new List<string> { "Recent" } or new List<string> { "Relevent" } - select only one
        public static List<string> Sort = new List<string> { "Recent" };
        // Blacklist companies you dont want to apply - ex: new List<string> { "Apple", "Google" }
        public static List<string> Blacklist = new List<string> { "Apple", "TeamViewer", "Noir" };
        // Blaclist keywords in title - ex: new List<string> { "manager", ".Net" }
        public static List<string> BlackListTitles = new List<string> { "C++", "C", "Golang", "Spring", "Hibernate", "Maven" };
        // Only Apply these companies - ex: new List<string> { "Apple", "Google" } - leave empty for all companies
        public static List<string> OnlyApply = new List<string> { "" };
        // Only Apply titles having these keywords - ex: new List<string> { "web", "remote" } - leave empty for all companies
        public static List<string> OnlyApplyTitles = new List<string> { "" };
        // Follow companies after successful application True - yes, False - no
        public static bool FollowCompanies = false;
        // your country code for the phone number - ex: "fr"
        public static string CountryCode = "tr";
        // Your phone number without identifier - ex: "123456789"
        public static string PhoneNumber = "";
        // Total successful job application count
        public static int successfulJobApplicationCounter = 0;
        //--------Info extractor

        public static Dictionary<string, int> europeanCountries = new Dictionary<string, int>
        {
            { "Germany", 101282230 },
            { "Serbia", 101855366 },
            { "Slovakia", 103119917 },
            { "Slovenia", 106137034 },
            { "Spain", 105646813 },
            { "Sweden", 105117694 },
            { "Switzerland", 106693272 },
            { "Poland", 105072130 },
            { "Portugal", 100364837 },
            { "Ukraine", 102264497 },
            { "United Kingdom", 101165590 },
            { "Netherlands", 102890719 },
            { "Austria", 103883259 },
            { "Norway", 103819153 },
            { "Romania", 106670623 },
            { "Belgium", 100565514 },
            { "Bosnia and Herzegovina", 102869081 }, 
            { "Bulgaria", 105333783 }, 
            { "Croatia", 104688944 }, 
            { "Cyprus", 106774002 },
            { "Czech Republic", 104508036 }, 
            { "Denmark", 104514075 }, 
            { "Estonia", 102974008 }, 
            { "Finland", 100456013 },
            { "France", 105015875 }, 
            { "Greece", 104677530 }, 
            { "Hungary", 100288700 }, 
            { "Iceland", 105238872 },
            { "Ireland", 104738515 }, 
            { "Italy", 103350119 }, 
            { "Kosovo", 104640522 }, 
            { "Latvia", 104341318 }, 
            { "Liechtenstein", 100878084 },
            { "Lithuania", 101464403 }, 
            { "Luxembourg", 104042105 }, 
            { "Malta", 100961908 }, 
            { "Moldova", 106178099 }, 
            { "Monaco", 101352147 },
            { "Montenegro", 100733275 },
            { "Belarus", 101705918 },
            { "North Macedonia", 103420483 },
            { "San Marino", 105730022 },
            { "Albania", 102845717 },
            { "Andorra", 106296266 },
            { "Vatican City", 107163060 }
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJobApplier.Config
{
    public static class Constants
    {
        public const string LinkJobUrl = "https://www.linkedin.com/jobs/search/";
        public const string AngelCoUrl = "https://angel.co/login";
        public const string GlobalLogicUrl = "https://www.globallogic.com/career-search-page/";
        public const int JobsPerPage = 25;
        public const int CaptaTime = 15;
        public const int Fast = 1;
        public const int Medium = 3;
        public const int Slow = 5;
        public const int BotSpeed = Fast;
        public const int PagePreferenceConstant = (int)PagePreference.FirstTen;
        public enum PagePreference { 
            First=1,
            Second=2,
            Third=3,
            Fourth=4,
            FirstFive =5,
            FirstTen=10,
            FirstTwenty=20,
            FirstThirdty=30,
            FirstForty=40,
            All=0
        };
    }
}

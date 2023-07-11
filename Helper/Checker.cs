using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helper
{
    public static class Checker
    {
        public static bool CheckEmail(string email)
        {
            // Define the regular expression pattern for email validation
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            // Check if the entered email matches the pattern
            bool isValidEmail = Regex.IsMatch(email, pattern);

            if (isValidEmail)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

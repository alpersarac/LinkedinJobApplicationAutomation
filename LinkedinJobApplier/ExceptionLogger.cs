using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedinJobApplier
{
    public static class ExceptionLogger
    {
        private static string _logFilePath;

        public static void LogException(Exception ex)
        {
            try
            {
                string startupPath = Application.StartupPath;
                _logFilePath = Path.Combine(startupPath, "exception.log");
                // Create or append to the log file
                using (StreamWriter writer = File.AppendText(_logFilePath))
                {
                    writer.WriteLine($"[Date/Time: {DateTime.Now}]");
                    writer.WriteLine($"Message: {ex.Message}");
                    writer.WriteLine($"Stack Trace: {ex.StackTrace}");
                    writer.WriteLine(new string('-', 50));
                    writer.WriteLine();
                }
            }
            catch (Exception logEx)
            {
                // Handle any exceptions that occur while logging
                Console.WriteLine($"An error occurred while logging the exception: {logEx.Message}");
            }
        }
    }

}

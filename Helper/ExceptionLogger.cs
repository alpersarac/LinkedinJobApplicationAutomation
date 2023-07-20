using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinkedinJobApplier
{
    public static class ExceptionLogger
    {
        private static readonly string logFilePath;

        static ExceptionLogger()
        {
            string folderName = Path.Combine("C:\\", "ExceptionLogsLinkedinApplier"); // Folder name under C drive
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            string fileName = $"{DateTime.Now:yyyy-MM-dd}.txt"; // Log file name based on the current date
            logFilePath = Path.Combine(folderName, fileName);
        }

        public static void LogException(Exception ex)
        {
            string logMessage = $"[Date/Time: {DateTime.Now}]\n[Exception Type: {ex.GetType()}]\n[Message: {ex.Message}]\n[StackTrace: {ex.StackTrace}]\n\n";

            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.Write(logMessage);
                }
            }
            catch (Exception)
            {
                // Handle any errors that may occur during logging (optional).
                // You might want to log this handling to another log file or event viewer, for example.
            }
        }
    }

}

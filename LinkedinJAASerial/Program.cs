using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedinJAASerial
{
    internal static class Program
    {
        private static readonly string MutexId = "LinkedinApplier_" + Guid.NewGuid().ToString();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isNewInstance;
            using (var mutex = new Mutex(true, MutexId, out isNewInstance))
            {
                if (isNewInstance)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    // Create and run your main form here
                    Application.Run(new frmMain());
                }
                else
                {
                    // Another instance is already running, you may want to notify the user or handle it in some way.
                    MessageBox.Show("The application is already running.", "Multiple Instances Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

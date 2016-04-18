using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace code
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            global::System.Windows.Forms.Application.EnableVisualStyles();
            global::System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Info("Application start");
            global::System.Windows.Forms.Application.Run(new LoginForm());
            
        }
    }
}

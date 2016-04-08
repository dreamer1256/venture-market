using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace code
{
    public partial class MainForm : Form
    {
        private Logger logger;

        public MainForm()
        {
            InitializeComponent();
            try
            {
                logger = LogManager.GetCurrentClassLogger();

                logger.Trace("Version: {0}", Environment.Version.ToString());
                logger.Trace("OS: {0}", Environment.OSVersion.ToString());
                logger.Trace("Command: {0}", Environment.CommandLine.ToString());

                //NLog.Targets.FileTarget tar = (NLog.Targets.FileTarget)LogManager.Configuration.FindTargetByName("run_log");
                //tar.DeleteOldFileOnStartup = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка работы с логом!n" + e.Message);
            }

            //Application.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace code
{
    class LoginHistory
    {
        private static DataClasses1DataContext vmDB = new DataClasses1DataContext();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Метод відображає у профілі користувача історію логувань
        /// (домен і дату чотирьох останніх входів)
        /// </summary>
        /// <param name="userID"> ID користувача, для якого потрібно відобразити історію логуваь</param>
        /// <param name="lbl_LogHist"> Панель у якій відображується історія логувань </param>
        public static void LoadUserLoginHistory(int userID, Label lbl_LogHist)
        {
            var allLogging = vmDB.UserLoginHistories.Where(h => h.UserID == userID)
               .OrderByDescending(h => h.LoggedDate).Take(8);
            int counter = 1;
            foreach (var logDate in allLogging)
            {
                if (counter % 2 == 0)
                    if (logDate.LoggedDate.Day == DateTime.Now.Day)
                        lbl_LogHist.Text += ("Today at  " + logDate.LoggedDate.ToShortTimeString() + "   " + logDate.Domain + "\n");
                    else
                        if ((DateTime.Now.Day - 1) == logDate.LoggedDate.Day)
                            lbl_LogHist.Text += ("Yesterday at  " + logDate.LoggedDate.ToShortTimeString() + "   " + logDate.Domain + "\n");
                        else
                        lbl_LogHist.Text += (logDate.LoggedDate.ToShortDateString() + "   " + logDate.Domain + "\n");
                counter++;
            }
            logger.Info("Loaded login history for user. [UserID: {0}]", userID);
        }
    }
}

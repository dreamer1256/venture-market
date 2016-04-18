using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using System.Net;

namespace code
{
    class UserExit
    {
        public static void SaveUserStoryOnExit(int userID)
        {
            DataClasses1DataContext vmDB = new DataClasses1DataContext();
            Logger logger = LogManager.GetCurrentClassLogger();
            User currUser = vmDB.Users.Single(u => u.ID == userID);
            currUser.LoggedDate = DateTime.Now;

            UserLoginHistory logHist = new UserLoginHistory
            {
                UserID = userID,
                OS = (System.Environment.OSVersion.Platform + " " + System.Environment.OSVersion.Version).ToString(),
                IP = (Dns.Resolve(Dns.GetHostName()).AddressList[0]).ToString(),
                Domain = System.Environment.UserDomainName.ToString(),
                LoggedDate = DateTime.Now
            };
            vmDB.UserLoginHistories.InsertOnSubmit(logHist);
            try
            {
                vmDB.SubmitChanges();
            }
            catch (Exception ex)
            {
                logger.Error("Unable to save user data on exit. " + ex.Message);
            }
        }
    }
}

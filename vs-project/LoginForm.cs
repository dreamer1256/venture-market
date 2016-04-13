using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NLog;

namespace code
{
    public partial class LoginForm : Form
    {
        DataClasses1DataContext vmDB;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = btn_Login;
            logger.Info("Application Start");
        }

        private void btnTop_Signup_Click(object sender, EventArgs e)
        {
            btnTop_Signup.Enabled = false;
            SignInForm sf = new SignInForm();
            sf.Show();
            logger.Info("Show registration form");
            this.Hide();
        }

        private void lbl_FrgtPsswrd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string userName = txt_Username.Text;
            string password = txt_Password.Text;

            if(IsValidUser(userName, password))
            {
                vmDB = new DataClasses1DataContext();
                
                var user = vmDB.Users.Single(u => u.Username.Equals(userName));
                User_Role userRole = vmDB.User_Roles.Single(r => r.UserId == user.ID);
                switch(userRole.RoleID)
                {
                    case (int)URoles.Role.AnglInvestor:
                        UserProfile.AngInvstrMmbrProfile aimp = new UserProfile.AngInvstrMmbrProfile(user);
                        aimp.Show();
                        break;
                    case (int)URoles.Role.InvCompanyMember:
                        UserProfile.InvCompanyMmbrProfile icmp = new UserProfile.InvCompanyMmbrProfile(user);
                        icmp.Show();
                        break;
                    case (int)URoles.Role.StartupCEO:
                        UserProfile.StartupCEOMmbrProfile scmp = new UserProfile.StartupCEOMmbrProfile(user);
                        scmp.Show();
                        break;
                    case (int)URoles.Role.InvestManager:
                        UserProfile.InvManagerMmbrProfile immp = new UserProfile.InvManagerMmbrProfile(user);
                        immp.Show();
                        break;
                    case (int)URoles.Role.StartupMember:
                        UserProfile.StartupMmbrProfile smp = new UserProfile.StartupMmbrProfile(user);
                        smp.Show();
                        break;
                    case (int)URoles.Role.Admin:
                        UserProfile.AdminProfile ap = new UserProfile.AdminProfile(user);
                        ap.Owner = this;
                        ap.Show();
                        break;
                }
                logger.Info("User is logged on");
                this.Hide();
            }
            else
            {
                logger.Info("User has entered the wrong password");
                MessageBox.Show("Please enter a valid username and password!");
            }
        }
    
        public bool IsValidUser(string userName, string passWord)
         {
            vmDB = new DataClasses1DataContext();
            var userResult = vmDB.Users.Where(u => u.Username == userName && u.Password == passWord)
                .Select(u => u);
            return Enumerable.Count(userResult) == 1;
         }
    }
}

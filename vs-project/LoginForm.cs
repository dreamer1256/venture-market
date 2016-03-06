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

namespace code
{
    public partial class LoginForm : Form
    {
        DataClasses1DataContext vmDB;

        //public bool is_SigninWindowExist;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnTop_Signup_Click(object sender, EventArgs e)
        {
            btnTop_Login.Enabled = true;
            btnTop_Signup.Enabled = false;
            SignInForm sf = new SignInForm();
            sf.Show();
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
                
                User user = vmDB.Users.Single(u => u.Username.Equals(userName));
                int userID = user.ID;
                User_Role userRole = vmDB.User_Roles.Single(r => r.UserId == userID);
                int roleID = userRole.RoleID;
                switch(roleID)
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
                        break;
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Please enter a valid username and password!");
            }
        }
    
        private void btnTop_Login_Click(object sender, EventArgs e)
        {   
            btnTop_Signup.Enabled = true;
            btnTop_Login.Enabled = false;
        }

        public bool IsValidUser(string userName, string passWord)
         {
            vmDB = new DataClasses1DataContext();
            var userResults = from u in vmDB.Users
                               where u.Username == userName
                               && u.Password == passWord
                               select u;
            return Enumerable.Count(userResults) == 1;
         }


        /*public User GetUser(string userName)
        {
            vmDB = new DataClasses1DataContext();
            User user = vmDB.Users.Single(u, u.UserName=>userName);
            return user;
        }
        */
    }
}

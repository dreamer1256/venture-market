using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace code.UserProfile
{
    public partial class InvCompanyMmbrProfile : Form
    {
        User user;
        DataClasses1DataContext vmDB = new DataClasses1DataContext();
        public InvCompanyMmbrProfile(User user)
        {
            this.user = user;
            InitializeComponent();
            var combr = vmDB.CompanyMember.Single(u => u.UserID == user.ID);
            if (user.Accaunt_Pic != null)
            {
                picbx_combr.Image = Image.FromFile(user.Accaunt_Pic);
            }
            this.user = user;
            lbl_fl_name.Text = string.Format("{0} {1}", user.FName, user.LName);
            lbl_combr_info.Text = user.Email + "\n"
                      + combr.Phone + "\n"
                      + combr.Skype + "\n"
                      + combr.Twitter;
            lbl_cmbr_company.Text = combr.Investment_Company.Title;

            int logID = vmDB.UserLoginHistories.Where(h => h.UserID == user.ID)
                        .OrderByDescending(h => h.LoggedDate).Select(h => h.ID).First();
            var userLogHist = vmDB.UserLoginHistories.Single(h => h.ID == logID);
            lbl_joined_combr.Text = "Joined on   " + user.RegDate.ToShortDateString();
                lbl_lastlog_combr.Text = "Last seen   " + user.LoggedDate.ToString() +
                "\nIP:  " + userLogHist.IP + "\nOS:  " + userLogHist.OS + "\nDomain:  " + userLogHist.Domain;

            code.LoginHistory.LoadUserLoginHistory(user.ID, lbl_LogHist_combr);   // Завантажити історію логувань користувача
            code.SystemNews.LoadNews(pnl_News_combr); // Завантажити стрічку новин

            InitializeComponent();
        }

        private void btn_logout_combr_Click(object sender, EventArgs e)
        {
            UserExit.SaveUserStoryOnExit(user.ID);
            this.Close();
            LoginForm cmbr = new LoginForm();
            cmbr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ifwasopened = code.user_profile_edit.getstate();
            if (ifwasopened != 1)
            {
                user_profile_edit cmbred = new user_profile_edit(user);
                cmbred.Show();
            }
        }
    }
}

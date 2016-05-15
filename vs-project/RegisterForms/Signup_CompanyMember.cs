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

namespace code.RegisterForms
{
    public partial class Signup_CompanyMember : Form
    {
        private User user;
        private DataClasses1DataContext vmDB = new DataClasses1DataContext();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public Signup_CompanyMember(User user)
        {
            InitializeComponent();
            this.user = user;
            var company = from c in vmDB.Investment_Companies
                          select c.Title;
            foreach (var c in company)
                cmbx_member_add_comp.Items.Add(c);
        }

        private void btn_sighnup_ang_finish_Click(object sender, EventArgs e)
        {
            CompanyMember cm = new CompanyMember();
            User_Role ur = new User_Role();
            ur.RoleID = (int)URoles.Role.InvCompanyMember;
            ur.UserId = user.ID;
            cm.UserID = user.ID;
            Investment_Company company = vmDB.Investment_Companies.Single(c => c.Title == cmbx_member_add_comp.Text);
            cm.CompID = company.ID;
            cm.Phone = txt_member_phone.Text;
            cm.Twitter = txt_member_twitter.Text;
            cm.Skype = txt_member_skype.Text;
            vmDB.CompanyMember.InsertOnSubmit(cm);
            vmDB.User_Roles.InsertOnSubmit(ur);
            try
            {
                vmDB.SubmitChanges();
                this.Hide();
                UserProfile.InvCompanyMmbrProfile icmb = new UserProfile.InvCompanyMmbrProfile(user);
                icmb.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                logger.Error(ex.Message);
            }

        }
    }
}

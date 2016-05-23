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
    public partial class Signup_InvestManager : Form
    {
        private DataClasses1DataContext vmDB;
        private User user;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Signup_InvestManager(User user)
        {
            InitializeComponent();
            this.user = user;
            vmDB = new DataClasses1DataContext();
            var company = from c in vmDB.Investment_Companies
                     select c.Title;
            foreach (var c in company)
                cmbBx_Company.Items.Add(c);
        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            if (cmbBx_Company.Text != "")
            {
                vmDB = new DataClasses1DataContext();
                Investment_Manager im = new Investment_Manager();
                User_Role ur = new User_Role();
                ur.UserId = user.ID;
                ur.RoleID = (int)URoles.Role.InvestManager;
                im.UserID = user.ID;
                Investment_Company company = vmDB.Investment_Companies.Single(c => c.Title == cmbBx_Company.Text);
                im.Investment_CompanyID = company.ID;
                vmDB.Investment_Managers.InsertOnSubmit(im);
                vmDB.User_Roles.InsertOnSubmit(ur);
                try
                {
                    vmDB.SubmitChanges();
                    this.Hide();
                    UserProfile.InvManagerMmbrProfile icmp = new UserProfile.InvManagerMmbrProfile(user);
                    icmp.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    logger.Error(ex.Message);
                }
            }
            else
            {
                label1.ForeColor = Color.Red;
            }
        }

        private void Signup_InvestManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            User deleteuser2 = vmDB.Users.Single(u => u.ID == user.ID);
            vmDB.Users.DeleteOnSubmit(deleteuser2);
            try
            {
                vmDB.SubmitChanges();
                logger.Info("User " + user.Username + " was deleted from system");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Error(ex.Message);
            }
        }
    }
}

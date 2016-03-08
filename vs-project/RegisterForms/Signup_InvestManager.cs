using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace code.RegisterForms
{
    public partial class Signup_InvestManager : Form
    {
        private DataClasses1DataContext vmDB;
        private User user;
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
            vmDB = new DataClasses1DataContext();
            Investment_Manager im = new Investment_Manager();
            User_Role ur = new User_Role();
            ur.UserId = user.ID;
            ur.RoleID = (int)URoles.Role.InvestManager;
            im.UserID = user.ID;
            Investment_Company company = vmDB.Investment_Companies.Single(c => c.Title == cmbBx_Company.Text);
            im.Investment_CompanyID = company.ID;
            im.Geo_Inerests = txt_GeoInterests.Text;
            vmDB.Investment_Managers.InsertOnSubmit(im);
            vmDB.SubmitChanges();
            this.Hide();
            UserProfile.InvCompanyMmbrProfile icmp = new UserProfile.InvCompanyMmbrProfile(user);
            icmp.Show();
        }
    }
}

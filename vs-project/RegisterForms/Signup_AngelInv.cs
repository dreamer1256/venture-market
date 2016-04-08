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
    public partial class Signup_AngelInv : Form
    {
        private User user;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Signup_AngelInv(User user)
        {
            InitializeComponent();
            this.user = user;
            logger.Info("Registration form for Angel investor downloaded\n."
                + "[User ID = {0}]", user.ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext vmDB = new DataClasses1DataContext();
            AngelInvestor ai = new AngelInvestor();
            User_Role ur = new User_Role();
            ur.RoleID = (int)URoles.Role.AnglInvestor;
            ur.UserId = user.ID;
            ai.UserID = user.ID;
            ai.ID = user.ID;
            ai.Phone = txt_Phone.Text;
            ai.Skype = txt_Skype.Text;
            ai.Twitter = txt_Twitter.Text;
            ai.Investment_Experience = rchTxtBx_Expirience.Text;
            ai.Max_amount = Convert.ToDecimal(txt_MaxAmount.Text);
            ai.Min_Amount = Convert.ToDecimal(txt_MinAmount.Text);
            vmDB.AngelInvestors.InsertOnSubmit(ai);
            vmDB.User_Roles.InsertOnSubmit(ur);
            try
            {
                vmDB.SubmitChanges();
                UserProfile.AngInvstrMmbrProfile aimp = new UserProfile.AngInvstrMmbrProfile(user);
                aimp.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                logger.Error(ex.Message);
            }
        }
    }
}

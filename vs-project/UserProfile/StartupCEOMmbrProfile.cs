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
    public partial class StartupCEOMmbrProfile : Form
    {
        User user = null;
        Startup_Member startupCEO = null;
        public StartupCEOMmbrProfile(User user)
        {
            InitializeComponent();
            this.user = user;

            DataClasses1DataContext vmDB = new DataClasses1DataContext();
            
            startupCEO = vmDB.Startup_Members.Single(u => u.UserID == user.ID);
            
            lbl_Name.Text = string.Format("{0} {1}", user.FName, user.LName);
            lbl_Country.Text = string.Format("Country: {0}", startupCEO.Country);
            lbl_City.Text = string.Format("City: {0}", startupCEO.Address);
            lbl_Phone.Text = string.Format("Phone: {0}", startupCEO.Phone);
            lbl_Email.Text = string.Format("Email: {0}", user.Email);
            lbl_Skype.Text = string.Format("Skype: {0}", startupCEO.Skype);
            lbl_Twitter.Text = string.Format("Twitter: {0}", startupCEO.Twitter);
            //lbl_Facebook.Text = string.Format("Facebook:\t{0}", ceo.Facebook);
            //lbl_Website.Text = string.Format("Website:\t{0}", ceo.Website);
            rchTxtBx_About.Text = startupCEO.About;
        }
    }
}

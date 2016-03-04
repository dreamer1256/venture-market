using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace code
{
    public partial class UserProfile : Form
    {
        private String userName;
        public UserProfile(String userName)
        {
            InitializeComponent();
            this.userName = userName;
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }
    }
}

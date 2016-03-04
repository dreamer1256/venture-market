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
        public bool is_SigninWindowExist;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnTop_Signup_Click(object sender, EventArgs e)
        {
            btnTop_Login.Enabled = true;
            btnTop_Signup.Enabled = false;
            if (is_SigninWindowExist)
            {

            }
            else {
                SignInForm sf = new SignInForm();
                sf.Show();
                is_SigninWindowExist = true;
            }
            
            this.Hide();
        }

        private void lbl_FrgtPsswrd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(local)\;" +
                "Initial Catalog=Venture_Market;Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Count(*) FROM Users WHERE Username='" +
                txt_Username.Text + "' and Password='" + txt_Password.Text + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Console.WriteLine(dt.ToString());
                this.Hide();
                UserProfile up = new UserProfile(txt_Username.Text);
                up.Show();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

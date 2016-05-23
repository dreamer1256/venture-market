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

namespace code.UserProfile
{
    public partial class AdminProfile : Form
    {
        /// <summary>
        /// Профіль адміністратора системи
        /// </summary>
        User user;
        DataClasses1DataContext vmDB = new DataClasses1DataContext();
        User selecteduser;
        
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public AdminProfile(User user)
        {
           // pnl_startup.Hide();
           // pnl_User.Hide();
            InitializeComponent();
            this.user = user;
        }

        private void btn_AddIncubator_Click(object sender, EventArgs e)
        {
            AdminPanels.AddIncubator addIncub = new AdminPanels.AddIncubator();
            addIncub.ShowDialog();
        }
        
        private void btn_RemoveIncubator_Click(object sender, EventArgs e)
        {
            AdminPanels.RemoveIncubator removeInc = new AdminPanels.RemoveIncubator();
            removeInc.Show();
        }

        private void btn_AddStartup_Click(object sender, EventArgs e)
        {
            AdminPanels.AddStartup addStartup = new AdminPanels.AddStartup();
            addStartup.Show();
        }

        private void btn_AddInvestCompany_Click(object sender, EventArgs e)
        {
            AdminPanels.AddInvestCompany addInvCompany = new AdminPanels.AddInvestCompany();
            addInvCompany.ShowDialog();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btm_Back_Click(object sender, EventArgs e)
        {
            pnl_startup.Hide();
            pnl_User.Hide();
            pnl_inv_company.Hide();
            pnl_main.Show();
        }

        private void btm_show_startup_Click(object sender, EventArgs e)
        {
            pnl_main.Hide();
            pnl_User.Hide();
            pnl_inv_company.Hide();
            pnl_startup.Show();
            
            listView2.Items.Clear();
            ListViewItem itm;
            string[] arr = new string[9];
            var snm = from s in vmDB.Applications
                      select s;
            foreach (var s in snm)
            {
                arr[0] = s.Startup.Title;
                if (s.ManagerID == null)
                { arr[1] = "No mamager"; }
                else { arr[1] = s.Investment_Manager.User.LName + " " + s.Investment_Manager.User.FName; }
                arr[2] = s.State;

                arr[3] = "Round " + s.Application_Round.ToString();
                arr[4] = s.Startup.Marketing_Strategy;
                arr[5] = Convert.ToString(s.Startup.Competitors);
                arr[6] = Convert.ToString(s.Startup.Business_Model);
                arr[7] = Convert.ToString(s.Startup.Total_Investment);
                arr[8] = Convert.ToString(s.Startup.Foundation_Date);
                itm = new ListViewItem(arr);
                listView2.Items.Add(itm);
            }
        }

        private void btm_show_user_Click(object sender, EventArgs e)
        {
            pnl_main.Hide();
            pnl_startup.Hide();
            pnl_inv_company.Hide();
            pnl_User.Show();
            rb_all.Checked = true;
            ShowUsers("all");
        }

        private void btm_Invest_Company_Click(object sender, EventArgs e)
        {
            pnl_main.Hide();
            pnl_startup.Hide();
            pnl_User.Hide();
            pnl_inv_company.Show();
           // InitializeComponent();

            listView3.Items.Clear();
            ListViewItem itm;
            string[] arr = new string[6];
            var snm = from s in vmDB.Investment_Companies
                      select s;
            foreach (var s in snm)
            {
                arr[0] = s.Title;
                arr[1] = s.Description;
                arr[2] = s.Website;
                arr[3] = Convert.ToString(s.Foundation_Date);
                arr[4] = Convert.ToString(s.Office_Address);
                arr[5] = Convert.ToString(s.CEO);
                itm = new ListViewItem(arr);
                listView3.Items.Add(itm);
            }
        }
        private void ShowUsers(string role)
        {
            btn_delete_user.Enabled = false;
            var snm = from s in vmDB.Users
                      select s;
            if(role == "all")
            {
                listView1.Items.Clear();
                ListViewItem itm;
                string[] arr = new string[5];
                foreach (var s in snm)
                {
                    arr[0] = s.Username;
                    arr[1] = s.Email;
                    arr[2] = s.Password;
                    arr[3] = Convert.ToString(s.RegDate);
                    arr[4] = Convert.ToString(s.LoggedDate);
                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                }
            }
            else
            {
                   var svn = (from userM in vmDB.Users
                   join roleM in vmDB.User_Roles on userM.ID equals roleM.UserId
                   where roleM.Role.Role_Title == role
                   select new
                       {
                           username = userM.Username,
                           email = userM.Email,
                           userpass = userM.Password,
                           userlog = userM.LoggedDate,
                           userred = userM.RegDate,
                           role = roleM.Role.Role_Title
                       });
                listView1.Items.Clear();
                ListViewItem itm;
                string[] arr = new string[5];
                foreach (var s in svn)
                {
                    arr[0] = s.username;
                    arr[1] = s.email;
                    arr[2] = s.userpass;
                    arr[3] = Convert.ToString(s.userred);
                    arr[4] = Convert.ToString(s.userlog);
                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                }
            }
        }

        private void rb_all_CheckedChanged(object sender, EventArgs e)
        {
            ShowUsers("all");
        }

        private void rb_angel_CheckedChanged(object sender, EventArgs e)
        {
            ShowUsers("Angel_Investor");
        }

        private void rb_commbr_CheckedChanged(object sender, EventArgs e)
        {
            ShowUsers("IC_Member"); 
        }

        private void rb_invmngr_CheckedChanged(object sender, EventArgs e)
        {
            ShowUsers("Invest_Manager");
        }

        private void rb_stceo_CheckedChanged(object sender, EventArgs e)
        {
            ShowUsers("StartupCEO");
        }

        private void rb_stmbr_CheckedChanged(object sender, EventArgs e)
        {
            ShowUsers("Startup_Member"); 
        }

        private void btn_delete_user_Click(object sender, EventArgs e)
        {
            var deleteuser = selecteduser;
            DialogResult result = MessageBox.Show("Delete user " + deleteuser.Username + " ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                
                vmDB.Users.DeleteOnSubmit(deleteuser);
                try
                {
                    vmDB.SubmitChanges();
                    logger.Info("User " + deleteuser.Username + " was deleted from system");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
                if (rb_all.Checked)
                {
                    ShowUsers("all");
                }
                else if (rb_angel.Checked)
                {
                    ShowUsers("Angel_Investor");
                }
                else if (rb_commbr.Checked)
                {
                    ShowUsers("IC_Member");
                }
                else if (rb_invmngr.Checked)
                {
                    ShowUsers("Invest_Manager");
                }
                else if (rb_stceo.Checked)
                {
                    ShowUsers("StartupCEO");
                }
                else if (rb_stmbr.Checked)
                {
                    ShowUsers("Startup_Member");
                }
                btn_delete_user.Enabled = false;
                deleteuser = null;
                selecteduser = null;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            if (listView1.SelectedIndices.Count >= 0)
            {
                btn_delete_user.Enabled = true;
                selecteduser = vmDB.Users.Single(u => u.Username == listView1.FocusedItem.SubItems[0].Text);
            }
        }
    }
    }


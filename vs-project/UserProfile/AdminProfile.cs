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
    public partial class AdminProfile : Form
    {
        /// <summary>
        /// Профіль адміністратора системи
        /// </summary>
        User user;
        DataClasses1DataContext vmDB = new DataClasses1DataContext();
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

        private void btn_AddAngelIv_Click(object sender, EventArgs e)
        {
            AdminPanels.AddAngelInvestor addAngelInvestor = new AdminPanels.AddAngelInvestor();
            addAngelInvestor.Show();
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
           // InitializeComponent();
            
            listView1.Items.Clear();
            ListViewItem itm;
            string[] arr = new string[5];
            var snm = from s in vmDB.Users
                      select s;
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
    }
    }


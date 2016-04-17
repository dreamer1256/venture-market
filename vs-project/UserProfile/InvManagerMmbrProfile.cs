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
    public partial class InvManagerMmbrProfile : Form
    {
        //Function to display basic information about Invest manager profile
        User user;
        DataClasses1DataContext vmDB = new DataClasses1DataContext();
        public InvManagerMmbrProfile(User user)
        {
            InitializeComponent();
            this.user = user;

            var maneger = vmDB.Investment_Managers.Single(u => u.UserID == user.ID);
            pnl_aplication.Hide();
            pnl_charts.Hide();
            pnl_startup.Hide();

            lbl_name.Text = string.Format("{0} {1}", user.FName, user.LName);
            lbl_company.Text = string.Format("Company:          {0}", maneger.Investment_Company.Title);
            lbl_email.Text = string.Format("Email:            {0}", user.Email);
            lbl_web.Text = string.Format("Website:          {0}", maneger.Investment_Company.Website);
            lbl_office_adr.Text = string.Format("Office Address:   {0}", maneger.Investment_Company.Office_Address);

        }
        //Button to exit the Profile
        private void btm_logout(object sender, EventArgs e)
        {
            this.Close();
            LoginForm icmp = new LoginForm();
            icmp.Show();
        }
        //Button to refresh data
        private void btm_refresh_Click(object sender, EventArgs e)
        {
            btm_refresh.Click += button2_Click;
            checkBox1.Checked = false;
        }
        //The function to display information about the application, and their parameters
        private void button2_Click(object sender, EventArgs e)
        {
            pnl_startup.Hide();
            pnl_page_view.Hide();
            pnl_contact_inf.Hide();
            pnl_charts.Hide();
            pnl_aplication.Show();
            listView2.Items.Clear();
            ListViewItem itm;
            string[] arr = new string[4];
            var snm = from s in vmDB.Applications
                      select s;
            foreach (var s in snm)
            {
                    if ((s.State.ToString() == "considered") | (s.State.ToString() == "no state"))
                    {
                        arr[0] = s.Startup.Title;
                        if(s.ManagerID == null)
                        { arr[1] = "No mamager"; }
                        else {arr[1] = s.Investment_Manager.User.LName + " " + s.Investment_Manager.User.FName; }
                        arr[2] = s.State;
                        arr[3] = "Round " + s.Application_Round.ToString();
                        itm = new ListViewItem(arr);
                        listView2.Items.Add(itm);
                    }
            }
        }
        //Button to display applications and their settings
        private void button1_Click(object sender, EventArgs e)
        {
            pnl_startup.Hide();
            pnl_aplication.Hide();
            pnl_charts.Hide();
            pnl_page_view.Show();
            pnl_contact_inf.Show();
        }
        //The function to display information about startup and options
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count == 1)
            {
                Startup str = vmDB.Startups.Single(u => u.Title.Equals(listView2.SelectedItems[0].Text));

                lbl_startap_title.Text = string.Format("Startup: {0}", str.Title);
                lbl_startap_strategy.Text = string.Format("Marketing Strategy:  {0}", str.Marketing_Strategy);
                lbl_startap_model.Text = string.Format(   "Business Model:       {0}", str.Business_Model);
                lbl_total_inv.Text = string.Format("Total Investment:       {0} $", str.Total_Investment);
                textBox1.Text = string.Format("{0}", str.Description);
                pnl_page_view.Hide();
                pnl_contact_inf.Hide();
                pnl_aplication.Hide();
                pnl_startup.Show();
            }
        }
        //Button to display charts
        private void button4_Click(object sender, EventArgs e)
        {
            pnl_page_view.Hide();
            pnl_contact_inf.Hide();
            pnl_aplication.Hide();
            pnl_startup.Hide();
            pnl_charts.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        //The function that fills charts
        private void button7_Click(object sender, EventArgs e)
        {
            var snm = from s in vmDB.Applications
                      select s;
            foreach (var s in snm)
            {
                this.chart1.Series["Age"].Points.AddXY("Day", s.ManagerID.ToString());
                this.chart1.Series["Score"].Points.AddXY("Cash", s.Application_Round.ToString());
            }
        }
        //Button that implements the search data
        private void btm_search_Click(object sender, EventArgs e)
        {
            if (txt_box_search.Text != "")
            {
                for (int i = listView2.Items.Count - 1; i >= 0; i--)
                {
                    var item = listView2.Items[i];
                    if (item.Text.ToLower().Contains(txt_box_search.Text.ToLower()))
                    {
                        item.BackColor = Color.LightGreen;
                    }
                    else
                    if (checkBox1.Checked)
                    {
                        listView2.Items.Remove(item);
                    }
                }
                if (listView2.SelectedItems.Count == 1)
                {
                    listView2.Focus();
                }
            }
        }
        private void btm_finance_Click(object sender, EventArgs e)
        {
            if (txt_amount.Text == null) { }
            else
            {
                Startup sp = vmDB.Startups.Single(u => u.Title == listView2.SelectedItems[0].Text);
                Application app = vmDB.Applications.Single(u => u.StartupID == sp.ID);
                app.State = "accepted";

                decimal invamount = Decimal.Parse(txt_amount.Text);
                decimal old_amount = Decimal.Parse(sp.Total_Investment.ToString());
                int old_app_round = app.Application_Round;
                decimal tmp = invamount + old_amount;
                int tmp2 = old_app_round + 1;

                sp.Total_Investment = tmp;
                app.Application_Round = tmp2 + 1;
                vmDB.SubmitChanges();
            }
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InvManagerMmbrProfile_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void pnl_startup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_startap_model_Click(object sender, EventArgs e)
        {

        }

        private void lbl_startap_strategy_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


    } }


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
        User user;
        DataClasses1DataContext vmDB = new DataClasses1DataContext();
        public InvManagerMmbrProfile(User user)
        {
            InitializeComponent();
            this.user = user;
              
            var maneger = user.Investment_Managers.SingleOrDefault(u => u.UserID == user.ID);
            pnl_aplication.Hide();
            pnl_charts.Hide();
            lbl_name.Text = string.Format("{0} {1}", user.FName, user.LName);
            lbl_company.Text = string.Format("Company:          {0}", maneger.Investment_Company.Title);
            lbl_email.Text = string.Format("Email:            {0}", user.Email);
            lbl_web.Text = string.Format("Website:          {0}", maneger.Investment_Company.Website);
            lbl_office_adr.Text = string.Format("Office Address:   {0}", maneger.Investment_Company.Office_Address);

            
            var snm = from s in vmDB.Applications
                      select s;
            foreach (var s in snm)
            {
                this.chart_profile.Series["views"].Points.AddXY("Day", s.ManagerID.ToString());
            }


        }
    

        private void btm_logout(object sender, EventArgs e)
        {
            this.Close();
            LoginForm icmp = new LoginForm();
            icmp.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
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
                arr[0] = s.Investment_Manager.User.LName + " " + s.Investment_Manager.User.FName;
                arr[1] = s.Startup.Title;
                arr[2] = s.State;
                arr[3] = "Raund " + s.Application_Round.ToString();
                itm = new ListViewItem(arr);
                listView2.Items.Add(itm);
                
            }
            listView2.Items[0].Selected = true;
            listView2.Items[1].Selected = true;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_page_view.Show();
            pnl_contact_inf.Show();
            pnl_aplication.Hide();
            pnl_charts.Hide();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnl_charts.Show();
            pnl_page_view.Hide();
            pnl_contact_inf.Hide();
            pnl_aplication.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            var snm = from s in vmDB.Applications
                      select s;
            foreach (var s in snm)
            {
             //   this.chart1.Series["Age"].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
                this.chart1.Series["Age"].Points.AddXY("Day", s.ManagerID.ToString());
                this.chart1.Series["Score"].Points.AddXY("Day", s.ManagerID.ToString());

                this.chart1.Series["Age"].Points.AddXY("Cash", s.Application_Round.ToString());
                this.chart1.Series["Score"].Points.AddXY("Cash", s.Application_Round.ToString());
            }
/*
            this.chart1.Series["Age"].Points.AddXY("Max", 33);
            this.chart1.Series["Score"].Points.AddXY("Max", 90);

            this.chart1.Series["Age"].Points.AddXY("Max11", 13);
            this.chart1.Series["Score"].Points.AddXY("Max11", 50);

            this.chart1.Series["Age"].Points.AddXY("Max22", 43);
            this.chart1.Series["Score"].Points.AddXY("Max22", 60);*/

        }
    }
}


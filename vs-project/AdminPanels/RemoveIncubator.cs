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

namespace code.AdminPanels
{
    public partial class RemoveIncubator : Form
    {
        private static DataClasses1DataContext vmDB = new DataClasses1DataContext();
        private static ListViewItem lvi;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public RemoveIncubator()
        {
            InitializeComponent();
            LoadIncubatorsList();
        }

        /// <summary>
        /// Метод дозволяє визначити кількість стартапів розміщених в інкубаторі
        /// </summary>
        /// <param name="incubID">ID інкубатора</param>
        /// <returns>Кількість стартапів в інкубаторі</returns>
        private int StartupsInIncubCount(int incubID)
        {
            var startups = vmDB.Startups.Where(c => c.Startup1.IncubID == incubID);
            return startups.Count();
        }

        /// <summary>
        /// Метод видаляє вибраний інкубатор
        /// </summary>
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            int incubID = 0;

            if (listView1.SelectedIndices.Count <= 0)
                return;
            if (listView1.SelectedIndices.Count > 0)
            {
                incubID = Int32.Parse(listView1.FocusedItem.SubItems[0].Text);
                var deleteIncubDetails = vmDB.Business_Incubators.Single(i => i.ID == incubID);
                vmDB.Business_Incubators.DeleteOnSubmit(deleteIncubDetails);
                
                try
                {
                        vmDB.SubmitChanges();
                        logger.Info("Business Incubator " + deleteIncubDetails.Title + " removed");
                        LoadIncubatorsList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(ex.Message);
                }
            }

        }

        /// <summary>
        /// Метод робить конпку Remove неактивною, якщо в інкубаторі є стартапи
        /// </summary>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string incubatorTitle = null;

            if (listView1.SelectedIndices.Count <= 0)
                return;
            if (listView1.SelectedIndices.Count > 0)
            {
                incubatorTitle = listView1.FocusedItem.SubItems[1].Text;
                if (Int32.Parse(listView1.FocusedItem.SubItems[4].Text) == 0)
                    btn_Remove.Enabled = true;
                else btn_Remove.Enabled = false;
                btn_Remove.Text = "Remove " + incubatorTitle;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        /// <summary>
        /// Метод виводить у ListView інформацію про інкубатори, що є у системі
        /// </summary>
        private void LoadIncubatorsList()
        {
            listView1.Clear();
            var incubators = vmDB.Business_Incubators.Select(inc => inc);
            listView1.FullRowSelect = true;
            listView1.GridLines = false;

            listView1.Columns.Add("ID", 80);
            listView1.Columns.Add("Title", 160);
            listView1.Columns.Add("Location", 180);
            listView1.Columns.Add("Number of seats", 160);
            listView1.Columns.Add("Number of startups", 160);

            string[] arr = new string[5];
            foreach (var s in incubators)
            {
                arr[0] = s.ID.ToString();
                arr[1] = s.Title;
                arr[2] = s.Address;
                arr[3] = s.Number_Of_Seats.ToString();
                int strtpCount = StartupsInIncubCount(s.ID);
                arr[4] = strtpCount.ToString();

                lvi = new ListViewItem(arr);
                if (strtpCount != 0)
                    lvi.Selected = false;
                else lvi.ForeColor = Color.DarkCyan;

                listView1.Items.Add(lvi);
            }
        }
       
    }
}

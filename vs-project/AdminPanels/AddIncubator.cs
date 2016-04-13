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
    public partial class AddIncubator : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public AddIncubator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод додає новий бізнес інкубатор у систему
        /// </summary>
        private void btn_Accept_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext vmDB = new DataClasses1DataContext();

            // Перевірити чи усі поля заповнено.
            // Якщо так, то створюється новий інкубатор
            if (txt_Title.Text == "" || txt_Location.Text == "" || txt_Website.Text == "" || txt_Seats.Text == "")
                MessageBox.Show("Fields can not be empty!\n",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                {
                    Business_Incubator bi = new Business_Incubator
                    {
                        Title = txt_Title.Text,
                        Address = txt_Location.Text,
                        Website = txt_Website.Text,
                        Number_Of_Seats = Int32.Parse(txt_Seats.Text)
                    };

                    vmDB.Business_Incubators.InsertOnSubmit(bi);
                    try
                    {
                        vmDB.SubmitChanges();
                        logger.Info("Business Incubator " + txt_Title.Text + " added to the system");
                        MessageBox.Show("Business Incubator successfully added to the system!",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error("An error ocured while adding incubator to DB: " + ex.Message);
                    }
                }
        }
    }
}

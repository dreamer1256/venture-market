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
    public partial class AddInvestCompany : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public AddInvestCompany()
        {
            InitializeComponent();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext vmDB = new DataClasses1DataContext();
            bool isunique = true;
            var snm = from us in vmDB.Investment_Companies
                      select us;
            foreach (var us in snm)
            {
                if (us.Title == txt_addinvest_comName.Text)
                {
                    isunique = false;
                }
            }
                if (txt_addinvest_adress.Text == "" || txt_addinvest_comName.Text == "" || txt_addinvest_decription.Text == "" || txt_addinvest_website.Text == "")
                { MessageBox.Show("Some fields are epmty!\n", "Warning", MessageBoxButtons.OK); }
                else if(isunique == false)
                { MessageBox.Show("Such company exist.\n", "Warning", MessageBoxButtons.OK);}
                else
                {
                    Investment_Company addcomp = new Investment_Company
                    {
                        Title = txt_addinvest_comName.Text,
                        Description = txt_addinvest_decription.Text,
                        Website = txt_addinvest_website.Text,
                        Foundation_Date = date_of_foundation_inv_company.Value,
                        Office_Address = txt_addinvest_adress.Text,
                        CEO = txt_comp_ceo.Text
                    };

                    vmDB.Investment_Companies.InsertOnSubmit(addcomp);
                    try
                    {
                        vmDB.SubmitChanges();
                        logger.Info("Company " + txt_addinvest_comName.Text + " added to the system");
                        MessageBox.Show("Company successfully added to the system!",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error("An error ocured while adding Company to DB: " + ex.Message);
                    }
                }
        }

        private void btn_Cancel2_Click(object sender, EventArgs e)
        {

        }
    }
}

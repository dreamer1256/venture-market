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

    public partial class 
        AddStartup : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public AddStartup()
        {
            InitializeComponent();
        }
        
    private void btn_Accept_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext vmDB = new DataClasses1DataContext();
              var st = vmDB.Startups.Select(s => s.Business_Model);
              var str = vmDB.Startups.Select(b => b.Marketing_Strategy);
               foreach (var s in st)
           // string[] a = { "Free in" , "Franchise" };
                cbox_bis_model.Items.Add(s);
               foreach (var b in str)
           // string[] b = { "Product", "Franchise" };
            cbox_mark_strategy.Items.Add(b);

            if (tb_title.Text == "" || tb_description.Text == "" || tb_website.Text == "" || tb_twitter.Text == "" || cbox_bis_model.Text == "" || cbox_mark_strategy.Text == "")
                MessageBox.Show("Fields cannot be empty!\n",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Startup star = new Startup
                {
                    Title = tb_title.Text,
                    Description = tb_description.Text,
                    Business_Model = cbox_bis_model.Text,
                    Marketing_Strategy = cbox_mark_strategy.Text,
                    Website = tb_website.Text,
                    Twitter = tb_twitter.Text,
                    Competitors = null,
                    Total_Investment = 0,
                    Foundation_Date =  dateTimePicker.Value,
                    ceoID = null,
                    IncubID = null,
                    DevStageID = 1
                };

                vmDB.Startups.InsertOnSubmit(star);
                try
                {
                    News news = new News
                    {
                        Information = "A new startup added: " + star.Title,
                        Date = DateTime.Now,
                        Type = "Startup"
                    };
                    vmDB.News.InsertOnSubmit(news);
                    vmDB.SubmitChanges();
                    logger.Info("Startup " + tb_title.Text + " added to the system");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error("An error occured while adding Startup to DB: " + ex.Message);
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

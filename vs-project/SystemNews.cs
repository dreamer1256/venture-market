using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using NLog;

namespace code
{
    class SystemNews
    {
        /// <summary>
        /// Клас реалізовує відображення у новинах користувача
        /// дії, що здійснюють інші користувачі у системі
        /// </summary>
        private static DataClasses1DataContext vmDB = new DataClasses1DataContext();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Метод здійснює вивід новин у панель профілю користувача
        /// </summary>
        /// <param name="pnl_News"> Панель, у яку виводяться новини</param>
        public static void LoadNews(Panel pnl_News)
        {
            int yInfoPicPosition = 35;  // Кординати іконки події
            int xInfoPicPosition = 26;  // у стрічці новин.

            int yInfoLabelPosition = 25;    // Кординати лейблу, у який
            int xInfoLabelPosition = 55;    // виводиться інформація про одну подію.
            int lblWidth = 450;             // Ширина лейблу

            var news = vmDB.News.Select(n => n).OrderByDescending(n => n.Date); // Отримати всі новини системи, 
                                                                                // посортовані за датою
            foreach (var events in news)
            {
                // Інформація про подію
                Label lbl_info = new Label();
                lbl_info.ForeColor = Color.WhiteSmoke;
                lbl_info.Parent = pnl_News;
                lbl_info.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Regular);
                lbl_info.Location = new Point(xInfoLabelPosition, yInfoLabelPosition);
                lbl_info.Width = lblWidth;
                lbl_info.Text = events.Information;
                //lbl_info.BackColor = Color.DarkSeaGreen;

                // Дата події
                Label lbl_EventDate = new Label();
                lbl_EventDate.ForeColor = Color.WhiteSmoke;
                lbl_EventDate.Parent = pnl_News;
                lbl_EventDate.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Italic);
                lbl_EventDate.Location = new Point(xInfoLabelPosition, yInfoLabelPosition + 23);
                lbl_EventDate.Width = lblWidth;
                if((events.Date.Day) == (DateTime.Now.Day))
                    lbl_EventDate.Text = "Today at " + events.Date.ToShortTimeString();
                else
                    if ((DateTime.Now.Day - 1) == events.Date.Day)
                        lbl_EventDate.Text = "Yesterday at " + events.Date.ToShortTimeString();
                else lbl_EventDate.Text = events.Date.ToShortDateString();

                PictureBox pic = new PictureBox();
                pic.Parent = pnl_News;
                pic.Location = new Point(xInfoPicPosition, yInfoPicPosition);

                Label horizontalLine = new Label();
                horizontalLine.Parent = pnl_News;
                horizontalLine.Location = new Point(xInfoLabelPosition, yInfoLabelPosition + 46);
                horizontalLine.Width = lblWidth - 150;
                horizontalLine.Height = 1;
                horizontalLine.BackColor = Color.WhiteSmoke;

                switch (events.Type)    // Вивід іконки події у стрічці новин, залежно від типу події
                {
                    case "Startup":
                        pic.Image = code.Properties.Resources.img_NewsStartup;
                        break;
                    case "Application":
                        pic.Image = code.Properties.Resources.img_NewsApplication;
                        break;
                    case "Incubator":
                        pic.Image = code.Properties.Resources.img_NewsIncubator;
                        break;
                    case "Company":
                        pic.Image = code.Properties.Resources.img_NewsCompany;
                        break;
                }

                yInfoPicPosition += 60;
                yInfoLabelPosition += 60;
            }
            logger.Info("Loaded news for user");
        }
    }
}

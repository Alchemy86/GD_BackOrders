using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AuctionSniperDLL.Business;
using AuctionSniperDLL.Business.Sites;

namespace AuctionSniperDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Email.SendEmail(AppConfig.GetSystemConfig("AlertEmail"),"DAS Service Monitor","Testing Dude");
            GoDaddyAuctions2Cs gd = new GoDaddyAuctions2Cs();
            var moose = gd.Login("nycman789", "Wearefromnyc1");
            gd.CheckBackOrderDomain_IsValid("lunchboxcode.com");
        }
    }
}

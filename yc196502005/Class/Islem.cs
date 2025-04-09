using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yc196502005
{
    class Islem
    {
        public string AnaDizin = "C:\\Users\\yasin_ceyhan\\Desktop\\yasin_ceyhan\\home_codes\\php\\yasin_ceyhan";
        public void FormGetir(Form frm1, Form frm2, Panel pnl)
        {
            pnl.Controls.Clear();
            frm2.MdiParent = frm1;
            frm2.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(frm2);
            frm2.Show();
        }
        public void FormAc(Form frm1)
        {
            frm1.Show();
        }
    }
}

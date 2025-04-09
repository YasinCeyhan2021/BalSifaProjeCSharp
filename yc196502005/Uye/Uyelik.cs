using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yc196502005.Uye
{
    public partial class Uyelik : Form
    {
        Islem islem = new Islem();
        public Uyelik()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void Uye_Load(object sender, EventArgs e)
        {
            Panel Panel;
            Panel = panel2;
            Uyelik Sayfa = new Uyelik();
            UyeGiris Include = new UyeGiris();
            islem.FormGetir(Sayfa, Include, Panel);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Panel Panel;
            Panel = panel2;
            Uyelik Sayfa = new Uyelik();
            UyeGiris Include = new UyeGiris();
            islem.FormGetir(Sayfa, Include, Panel);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel Panel;
            Panel = panel2;
            Uyelik Sayfa = new Uyelik();
            UyeOl Include = new UyeOl();
            islem.FormGetir(Sayfa, Include, Panel);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yc196502005.Admin
{
    public partial class AdminIndex : Form
    {
        Islem islem = new Islem();
        public int kullaniciId;
        int sayi = 0;
        public AdminIndex()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void AdminIndex_Load(object sender, EventArgs e)
        {
            Panel Panel2 = panel2;
            AdminIndex Sayfa = new AdminIndex();
            SliderIndex Include = new SliderIndex();
            islem.FormGetir(Sayfa, Include, Panel2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sayi == 0)
            {
                panel1.Width = 50;
                sayi++;
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
            }
            else
            {
                panel1.Width = 250;
                sayi--;
                button2.Text = "Slider";
                button3.Text = "Sosyal Medya";
                button4.Text = "İletişim";
                button5.Text = "Admin Ayarları";
                button6.Text = "Çıkış Yap";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel Panel2 = panel2;
            AdminIndex Sayfa = new AdminIndex();
            SliderIndex Include = new SliderIndex();
            islem.FormGetir(Sayfa, Include, Panel2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Panel Panel2 = panel2;
            AdminIndex Sayfa = new AdminIndex();
            SosyalIndex Include = new SosyalIndex();
            islem.FormGetir(Sayfa, Include, Panel2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Panel Panel2 = panel2;
            AdminIndex Sayfa = new AdminIndex();
            IletisimIndex Include = new IletisimIndex();
            islem.FormGetir(Sayfa, Include, Panel2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Panel Panel2 = panel2;
            AdminAyar Include = new AdminAyar();
            Include.kullaniciId = this.kullaniciId;
            AdminIndex Sayfa = new AdminIndex();
            islem.FormGetir(Sayfa, Include, Panel2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

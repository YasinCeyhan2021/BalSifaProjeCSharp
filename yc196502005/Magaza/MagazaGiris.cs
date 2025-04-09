using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yc196502005.Magaza
{
    public partial class MagazaGiris : Form
    {
        Islem islem = new Islem();
        public int magazaId;
        int sayi = 0, sayi2 = 0;
        public MagazaGiris()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void MagazaGiris_Load(object sender, EventArgs e)
        {
            Panel Panel2 = panel2;
            MagazaGiris Sayfa = new MagazaGiris();
            MagazaAyar Include = new MagazaAyar();
            Include.magazaId = this.magazaId;
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
                button4.Text = "";
            }
            else
            {
                panel1.Width = 250;
                sayi--;
                button2.Text = "Magaza";
                button3.Text = "Ürün";
                button4.Text = "Sipariş";
                button4.Text = "Çıkış Yap";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel Panel2 = panel2;
            MagazaGiris Sayfa = new MagazaGiris();
            MagazaAyar Include = new MagazaAyar();
            Include.magazaId = this.magazaId;
            islem.FormGetir(Sayfa, Include, Panel2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sayi2 == 0)
            {
                Panel Panel2 = panel2;
                MagazaGiris Sayfa = new MagazaGiris();
                UrunAyar Include = new UrunAyar();
                Include.magazaId = this.magazaId;
                islem.FormGetir(Sayfa, Include, Panel2);
                sayi2++;
            }
            else
            {
                Panel Panel2 = panel2;
                MagazaGiris Sayfa = new MagazaGiris();
                UrunEkle Include = new UrunEkle();
                Include.magazaId = this.magazaId;
                islem.FormGetir(Sayfa, Include, Panel2);
                sayi2--;
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Panel Panel2 = panel2;
            MagazaGiris Sayfa = new MagazaGiris();
            Siparis Include = new Siparis();
            Include.magazaId = this.magazaId;
            islem.FormGetir(Sayfa, Include, Panel2);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

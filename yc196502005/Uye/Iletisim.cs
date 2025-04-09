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
    public partial class Iletisim : Form
    {
        Islem islem = new Islem();
        IletisimClass os = new IletisimClass();
        public int memberId, urunId, magazaId;
        int sayi = 0;
        string ad, soyad, tel, ePosta, mesaj;

        public Iletisim()
        {
            InitializeComponent();
        }

        private void Iletisim_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sifirla();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ad = textBox1.Text;
            soyad = textBox2.Text;
            tel = textBox3.Text;
            ePosta = textBox4.Text;
            mesaj = richTextBox2.Text;
            os.Kaydet(ad, soyad, tel, ePosta, mesaj);
            Sifirla();
        }
        public void Sifirla()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            richTextBox2.Text = "";
        }
    }

}

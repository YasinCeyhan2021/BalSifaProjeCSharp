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
    public partial class AdminAyar : Form
    {
        Islem islem = new Islem();
        AdminClass os = new AdminClass();
        string kAdi, sifre;
        public int kullaniciId;
        public AdminAyar()
        {
            InitializeComponent();
        }


        private void AdminAyar_Load(object sender, EventArgs e)
        {
            TextBox txtb1 = textBox1;
            TextBox txtb2 = textBox2;
            os.Ayar(txtb1, txtb2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sifirla();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Tüm Alanları Eksiksiz Bir Şekilde Doldurun !!!");
            }
            else
            {
                kAdi = textBox1.Text;
                sifre = textBox2.Text;
                AdminIndex ac = new AdminIndex();
                ac.kullaniciId = this.kullaniciId;
                os.Guncelle(kullaniciId, kAdi, sifre);
                islem.FormAc(ac);
            }

        }
        public void Sifirla()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

    }
}

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
    public partial class UyeOl : Form
    {
        public UyeOl()
        {
            InitializeComponent();
        }

        private void UyeOl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sifirla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ad, soyad, numara, il, ilce, adres, ePosta, sifre;
            string Mesaj;
            UyeClass os = new UyeClass();

            ad = textBox1.Text;
            soyad = textBox2.Text;
            numara = textBox3.Text;
            il = textBox4.Text;
            ilce = textBox5.Text;
            adres = richTextBox1.Text;
            ePosta = textBox6.Text;
            sifre = textBox7.Text;


            try
            {
                os.UyeKayit(ad, soyad, numara, il, ilce, adres, ePosta, sifre);
                Sifirla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.ToString(), "Error");
            }
        }
        public void Sifirla()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            richTextBox1.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }
}

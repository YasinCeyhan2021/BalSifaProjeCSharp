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
    public partial class MemberAyar : Form
    {
        Islem islem = new Islem();
        UyeClass os = new UyeClass();
        public int memberId, urunId, magazaId;
        TextBox txtb1, txtb2, txtb3, txtb4, txtb5, txtb6, txtb7;
        RichTextBox rxtb;
        string ad, soyad, tel, il, ilce, adres, ePosta, sifre; 
        public MemberAyar()
        {
            InitializeComponent();
        }

        private void MemberAyar_Load(object sender, EventArgs e)
        {
            txtb1 = textBox1;
            txtb2 = textBox2;
            txtb3 = textBox3;
            txtb4 = textBox4;
            txtb5 = textBox5;
            rxtb = richTextBox1;
            txtb6 = textBox6;
            txtb7 = textBox7;

            os.Member(memberId, txtb1, txtb2, txtb3, txtb4, txtb5, rxtb, txtb6, txtb7);

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
            il = textBox4.Text;
            ilce = textBox5.Text;
            adres = richTextBox1.Text;
            ePosta = textBox6.Text;
            sifre = textBox7.Text;
            os.Güncelle(memberId, ad, soyad, tel, il, ilce, adres, ePosta, sifre);
            MemberAyar ac = new MemberAyar();
            ac.magazaId = this.magazaId;
            ac.memberId = this.memberId;
            ac.urunId = this.urunId;
            islem.FormAc(ac);

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

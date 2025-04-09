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
    public partial class UyeGiris : Form
    {
        public UyeGiris()
        {
            InitializeComponent();
        }
        private void UyeGiris_Load(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Sifirla();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string ePosta, sifre;
            string Mesaj;
            UyeClass os = new UyeClass();

            ePosta = textBox1.Text;
            sifre = textBox2.Text;

            try
            {
                os.UyeGiris(ePosta, sifre);
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
        }


    }
}

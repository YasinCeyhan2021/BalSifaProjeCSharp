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
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sifirla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminClass os = new AdminClass();
            string kAdi, sifre;

            kAdi = textBox1.Text;
            sifre = textBox2.Text;

            try
            {
                os.Giris(kAdi, sifre);
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

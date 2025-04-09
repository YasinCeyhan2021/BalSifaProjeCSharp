using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using yc196502005.Uye;

namespace yc196502005.Magaza
{
    public partial class MagazaOlustur : Form
    {
        Islem islem = new Islem();
        MagazaClass os = new MagazaClass();
        int sayi;
        string profil, profilIsmi, banner, bannerIsmi, dizin, magazaIsmi;
        public int memberId;

        public MagazaOlustur()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            sayi = rastgele.Next();
            profilIsmi = "profil" + sayi + ".png";
            openFileDialog1.Title = "Kopyalanacak Dosyayı Seçiniz...";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                profil = openFileDialog1.FileName.ToString();
                textBox2.Text = profil;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            sayi = rastgele.Next();
            bannerIsmi = "banner" + sayi + ".png";
            openFileDialog1.Title = "Kopyalanacak Dosyayı Seçiniz...";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                banner = openFileDialog1.FileName.ToString();
                textBox3.Text = banner;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Boş Alan Bırakmayınız");
            }
            else
            {
                magazaIsmi = textBox1.Text;
                dizin = islem.AnaDizin + "\\yc196502005\\magaza\\photo\\";
                os.MagazaOlustur(memberId, magazaIsmi, profilIsmi, bannerIsmi);
                File.Copy(profil, dizin + profilIsmi);
                File.Copy(banner, dizin + bannerIsmi);
            }
        }
    }
}

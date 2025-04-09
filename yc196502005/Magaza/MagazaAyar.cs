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

namespace yc196502005.Magaza
{
    public partial class MagazaAyar : Form
    {
        Islem islem = new Islem();
        MagazaClass os = new MagazaClass();
        public int magazaId;
        int sayi;
        string profil, profilIsmi, banner, bannerIsmi, dizin, magazaIsmi;
        public MagazaAyar()
        {
            InitializeComponent();
        }

        private void MagazaAyar_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            PictureBox pctb1 = pictureBox1;
            PictureBox pctb2 = pictureBox2;
            Label label = label2;
            //os.Doldur(magazaId); //Doldur Metodu çağrıldı
            //dataGridView1.DataSource = os.tablo;
            os.Magaza(magazaId, pctb1, pctb2, label);
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
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Resimleri seçmeden güncelleyemezsiniz.");
            }
            else {
                magazaIsmi = textBox1.Text;
                if(magazaIsmi == "")
                {
                    magazaIsmi = label2.Text;
                }
                dizin = islem.AnaDizin + "\\yc196502005\\magaza\\photo\\";
                os.Güncelle(magazaId, magazaIsmi, profilIsmi,bannerIsmi);
                File.Copy(profil, dizin + profilIsmi);
                File.Copy(banner, dizin + bannerIsmi);
                MagazaGiris ac = new MagazaGiris();
                ac.magazaId = this.magazaId;
                islem.FormAc(ac);
               
            }
        }
    }
}

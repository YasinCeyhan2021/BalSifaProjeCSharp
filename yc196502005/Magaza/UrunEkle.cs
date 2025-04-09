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
    public partial class UrunEkle : Form
    {
        Islem islem = new Islem();
        UrunClass os = new UrunClass();
        ComboBox combx;
        public int magazaId;
        int sayi, urunIndex, agirlik, stok, fiyat;
        string photo, photoIsmi, dizin, aciklama;

        public UrunEkle()
        {
            InitializeComponent();
        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            combx = comboBox1;
            os.UrunCesit(combx);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            sayi = rastgele.Next();
            photoIsmi = "urun" + sayi + ".png";
            openFileDialog1.Title = "Kopyalanacak Dosyayı Seçiniz...";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                photo = openFileDialog1.FileName.ToString();
                textBox1.Text = photo;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Sifirla();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedIndex.ToString());
            if (comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Boş Alan Bırakmayın");
            }
            else
            {
                dizin = islem.AnaDizin + "\\yc196502005\\magaza\\include\\photo\\";
                urunIndex = comboBox1.SelectedIndex + 1;
                agirlik = Convert.ToInt32(textBox2.Text);
                stok = Convert.ToInt32(textBox3.Text);
                fiyat = Convert.ToInt32(textBox4.Text);
                aciklama = richTextBox1.Text;
                os.UrunKaydet(magazaId, urunIndex, photoIsmi, aciklama, agirlik, stok, fiyat);
                File.Copy(photo, dizin + photoIsmi);
                MagazaGiris ac = new MagazaGiris();
                ac.magazaId = this.magazaId;
                islem.FormAc(ac);

            }
        }
        public void Sifirla()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            richTextBox1.Text = "";
        }

    }
}

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

namespace yc196502005.Admin
{
    public partial class SosyalIndex : Form
    {
        Islem islem = new Islem();
        SosyalClass os = new SosyalClass();
        string dizin;
        int sayi, bottomId;
        string photoIsmi, photo, url, ad, adresUrl;

        public SosyalIndex()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            url = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            url = url.Replace("/", "\\");
            url =   islem.AnaDizin + url;
            pictureBox1.ImageLocation = url;
        }

        private void SosyalIndex_Load(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            os.Doldur(); //Doldur Metodu çağrıldı
            dataGridView1.DataSource = os.tablo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            sayi = rastgele.Next();
            photoIsmi = "sosyal" + sayi + ".png";
            openFileDialog1.Title = "Kopyalanacak Dosyayı Seçiniz...";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                photo = openFileDialog1.FileName.ToString();
                textBox3.Text = photo;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || photoIsmi == "" || textBox3.Text == "")
            {
                MessageBox.Show("Tüm Alanları Eksiksiz Bir Şekilde Doldurun");
            }
            else
            {
                dizin = islem.AnaDizin + "\\yc196502005\\source\\photo\\";
                if (File.Exists(dizin + photoIsmi))
                {
                    MessageBox.Show("Belirtilen klasörde " + photoIsmi + " isimli dosya zaten mevcut...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ad = textBox1.Text;
                    adresUrl = textBox2.Text;
                    os.Kaydet(ad, adresUrl, photoIsmi);
                    File.Copy(photo, dizin + photoIsmi);
                    MessageBox.Show("Kaydetme İşlemi Başarılı", "Dosya Kopyalandı...");
                    AdminIndex ac = new AdminIndex();
                    islem.FormAc(ac);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Satır Seçiniz");
            }
            else
            {
                bottomId = Convert.ToInt32(textBox4.Text);
                os.Sil(bottomId);
                AdminIndex ac = new AdminIndex();
                islem.FormAc(ac);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Tüm Alanları Eksiksiz Bir Şekilde Doldurun");

            }
            else
            {
                ad = textBox5.Text;
                adresUrl = textBox6.Text;
                bottomId = Convert.ToInt32(textBox4.Text);
                os.Guncelle(bottomId, ad, adresUrl);
                AdminIndex ac = new AdminIndex();
                islem.FormAc(ac);
            }
        }
    }
}

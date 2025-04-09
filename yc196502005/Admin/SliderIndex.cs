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
    public partial class SliderIndex : Form
    {
        Islem islem = new Islem();
        SliderClass os = new SliderClass();
        int sayi, sliderId;
        string sliderIsmi, slider, url, dizin;
        public SliderIndex()
        {
            InitializeComponent();
        }

        private void SliderIndex_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            os.Doldur(); //Doldur Metodu çağrıldı
            dataGridView1.DataSource = os.tablo;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            url = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            url = url.Replace("/", "\\");
            url = islem.AnaDizin + url;
            pictureBox1.ImageLocation = url;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            sayi = rastgele.Next();
            sliderIsmi = "slider" + sayi + ".png";
            openFileDialog1.Title = "Kopyalanacak Dosyayı Seçiniz...";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                slider = openFileDialog1.FileName.ToString();
                textBox1.Text = slider;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fotoğraf Seçin");
            }
            else
            {
                dizin = islem.AnaDizin + "\\yc196502005\\source\\photo\\";
                if (File.Exists(dizin + sliderIsmi))
                {
                    MessageBox.Show("Belirtilen klasörde " + sliderIsmi + " isimli dosya zaten mevcut...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    os.Kaydet(sliderIsmi);
                    File.Copy(slider, dizin + sliderIsmi);
                    MessageBox.Show("Fotoğraf Kaydetme İşlemi Başarılı", "Dosya Kopyalandı...");
                    AdminIndex ac = new AdminIndex();
                    islem.FormAc(ac);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Silmek istediğin sliderı seç.");
            }
            else
            {
                sliderId = Convert.ToInt32(textBox2.Text);
                os.Sil(sliderId);
                AdminIndex ac = new AdminIndex();
                islem.FormAc(ac);
            }
        }
    }
}

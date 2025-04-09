using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yc196502005.Magaza
{
    public partial class UrunAyar : Form
    {
        UrunClass os = new UrunClass();
        Islem islem = new Islem();
        public int magazaId;
        int urunId, urunIndex, agirlik, stok, fiyat;
        ComboBox combx;
        string aciklama;
        public UrunAyar()
        {
            InitializeComponent();
        }

        private void UrunAyar_Load(object sender, EventArgs e)
        {
            os.MagazaUrunDoldur(magazaId); //Doldur Metodu çağrıldı
            dataGridView1.DataSource = os.tablo;
            combx = comboBox1;
            os.UrunCesit(combx);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            urunId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            comboBox1.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value) -1;
            textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            pictureBox1.ImageLocation = islem.AnaDizin + dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sifirla();
        }
        public void Sifirla()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            urunIndex = comboBox1.SelectedIndex + 1;
            agirlik = Convert.ToInt32(textBox1.Text);
            stok = Convert.ToInt32(textBox2.Text);
            fiyat = Convert.ToInt32(textBox3.Text);
            aciklama = richTextBox1.Text;
            os.UrunGuncelle(urunId, urunIndex, agirlik, stok, fiyat, aciklama);
            MagazaGiris ac = new MagazaGiris();
            ac.magazaId = this.magazaId;
            islem.FormAc(ac);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Ürün Seçmeden Silemezsiniz");
            }
            else
            {
                os.UrunSil(urunId);
                MagazaGiris ac = new MagazaGiris();
                ac.magazaId = this.magazaId;
                islem.FormAc(ac);
            }
        }
    }
}

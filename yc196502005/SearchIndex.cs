using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yc196502005.Uye;

namespace yc196502005
{
    public partial class SearchIndex : Form
    {
        Islem islem = new Islem();
        public string search;
        public int memberId;
        string url;
        int urunId, magazaId;
        public SearchIndex()
        {
            InitializeComponent();
        }

        private void SearchIndex_Load(object sender, EventArgs e)
        {
            button1.Text = "";
            button2.Text = "";
            label5.Text = "";
            label7.Text = search;
            SearchClass os = new SearchClass();
            os.Doldur(search); //Doldur Metodu çağrıldı
            dataGridView1.DataSource = os.tablo;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            urunId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            magazaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            button1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            button2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            label5.Text += " Tl";
            url = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            url = url.Replace("/", "\\");
            url = islem.AnaDizin + url;
            pictureBox1.ImageLocation = url;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "")
            {
                MessageBox.Show("Mağaza seçili Değil");
            }
            else
            {
                MagazaIndex ac = new MagazaIndex();
                ac.magazaId = this.magazaId;
                ac.memberId = this.memberId;
                ac.urunId = this.urunId;
                islem.FormAc(ac);

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "")
            {
                MessageBox.Show("Ürün seçili Değil");
            }
            else
            {
                UrunIndex ac = new UrunIndex();
                ac.magazaId = this.magazaId;
                ac.memberId = this.memberId;
                ac.urunId = urunId;
                islem.FormAc(ac);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button2.Text == "")
            {
                MessageBox.Show("İlk Önce Ürün Seçiniz");
            }
            else
            {
                if (memberId == 0)
                {
                    Uyelik ac = new Uyelik();
                    islem.FormAc(ac);
                }
                else
                {
                    SepetClass os = new SepetClass();
                    os.SepeteEkle(memberId, urunId);
                }

            }
        }
    }
}

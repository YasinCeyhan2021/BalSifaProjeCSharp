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
    public partial class UrunIndex : Form
    {
        Islem islem = new Islem();
        UrunClass os = new UrunClass();
        public string ad, soyad;
        public int memberId, urunId, magazaId;
        int dataId, urunYorumId;
        string url, yorum;

        public UrunIndex()
        {
            InitializeComponent();
        }

        private void UrunIndex_Load(object sender, EventArgs e)
        {
            label15.Text = "";
            label16.Text = "";
            PictureBox pctb1 = pictureBox1;
            Label text1 = label6;
            Label text2 = label7;
            Label text3 = label8;
            Label text4 = label9;
            Label text5 = label10;
            os.Urun(urunId, pctb1, text1, text2, text3, text4, text5);
            os.YorumDoldur(urunId); //Doldur Metodu çağrıldı
            dataGridView1.DataSource = os.tablo;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            urunYorumId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            label15.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label16.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richTextBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dataId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            if (memberId == dataId)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(memberId == 0)
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (urunYorumId.ToString() == "")
            {
                MessageBox.Show("Yorum Seçilmedi");
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
                    os.Sil(urunYorumId);
                    UrunIndex ac = new UrunIndex();
                    ac.memberId = this.memberId;
                    ac.magazaId = this.magazaId;
                    ac.urunId = this.urunId;
                    islem.FormAc(ac);
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                MessageBox.Show("Yorum Yazın");
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
                    yorum = richTextBox2.Text;
                    os.YorumKaydet(urunId, memberId, yorum);
                    UrunIndex ac = new UrunIndex();
                    ac.memberId = this.memberId;
                    ac.magazaId = this.magazaId;
                    ac.urunId = this.urunId;
                    islem.FormAc(ac);
                }
            }
        }
    }
}

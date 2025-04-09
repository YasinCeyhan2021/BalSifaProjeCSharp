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
    public partial class UyeIndex : Form
    {
        Islem islem = new Islem();
        public string ad, soyad;
        public int memberId, urunId, magazaId;
        int sayi = 0;
        string url, search;

        public UyeIndex()
        {
            InitializeComponent();
        }



        private void UyeIndex_Load(object sender, EventArgs e)
        {
            button11.Text = "";
            button12.Text = "";
            label5.Text = "";
            panel1.Visible = false;
            button4.Text = ad + " " + soyad;
            UrunClass os = new UrunClass();
            os.Doldur(); //Doldur Metodu çağrıldı
            dataGridView1.DataSource = os.tablo;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            urunId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            magazaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            button11.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            button12.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            label5.Text += " Tl";
            url = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            url = url.Replace("/", "\\");
            url = islem.AnaDizin + url;
            pictureBox1.ImageLocation = url;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sayi == 0)
            {
                panel1.Visible = true;
                sayi++;
            }
            else
            {
                panel1.Visible = false;
                sayi--;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            sayi = 0;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SepetIndex ac = new SepetIndex();
            ac.magazaId = this.magazaId;
            ac.memberId = this.memberId;
            ac.urunId = urunId;
            islem.FormAc(ac);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MagazaClass os = new MagazaClass();
            os.MagazaControl(memberId);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            MemberAyar ac = new MemberAyar();
            ac.magazaId = this.magazaId;
            ac.memberId = this.memberId;
            ac.urunId = urunId;
            islem.FormAc(ac);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Iletisim ac = new Iletisim();
            ac.magazaId = this.magazaId;
            ac.memberId = this.memberId;
            ac.urunId = urunId;
            UyeIndex kapa = new UyeIndex();
            islem.FormAc(ac);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchIndex ac = new SearchIndex();
            search = richTextBox1.Text;
            ac.search = this.search;
            ac.memberId = this.memberId;
            islem.FormAc(ac);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "")
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
        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text == "")
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
        private void button13_Click(object sender, EventArgs e)
        {
            if (button12.Text == "")
            {
                MessageBox.Show("İlk Önce Ürün Seçiniz");
            }
            else
            {
                SepetClass os = new SepetClass();
                os.SepeteEkle(memberId, urunId);
            }
        }

    }
}

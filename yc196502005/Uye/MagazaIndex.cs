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
    public partial class MagazaIndex : Form
    {
        Islem islem = new Islem();
        MagazaClass os = new MagazaClass();
        public int magazaId, memberId, urunId;
        int dataId, magazaYorumId;
        string yorum;

        public MagazaIndex()
        {
            InitializeComponent();
        }

        private void MagazaIndex_Load(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";
            richTextBox2.Text = "";
            button1.Enabled = false;
            PictureBox pctb1 = pictureBox1;
            PictureBox pctb2 = pictureBox2;
            Label label = label1;
            os.Doldur(magazaId); //Doldur Metodu çağrıldı
            dataGridView1.DataSource = os.tablo;
            os.Magaza(magazaId, pctb1, pctb2, label);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            magazaYorumId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            label6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richTextBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dataId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            if (memberId == dataId)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (magazaYorumId.ToString() == "")
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
                    os.Sil(magazaYorumId);
                    MagazaIndex ac = new MagazaIndex();
                    ac.memberId = this.memberId;
                    ac.magazaId = this.magazaId;
                    islem.FormAc(ac);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                    os.YorumKaydet(magazaId, memberId, yorum);
                    MagazaIndex ac = new MagazaIndex();
                    ac.memberId = this.memberId;
                    ac.magazaId = this.magazaId;
                    islem.FormAc(ac);
                }

            }
        }
    }
}

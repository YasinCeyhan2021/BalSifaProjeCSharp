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
    public partial class SepetIndex : Form
    {
        Islem islem = new Islem();
        SepetClass os = new SepetClass();
        public int memberId, urunId, magazaId;
        int sepetId , dataId;
        string url;
        public SepetIndex()
        {
            InitializeComponent();
        }

        private void SepetIndex_Load(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            button1.Enabled = false;
            os.Doldur(memberId); //Doldur Metodu çağrıldı
            dataGridView1.DataSource = os.tablo;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sepetId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            label5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label7.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            label7.Text += " Tl";
            label8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dataId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);

            url = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            url = url.Replace("/", "\\");
            url = islem.AnaDizin + url;
            pictureBox1.ImageLocation = url;
            if(dataId == 1)
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
            if (sepetId.ToString() == "")
            {
                MessageBox.Show("Yorum Seçilmedi");
            }
            else
            {
                os.Sil(sepetId);
                SepetIndex ac = new SepetIndex();
                ac.memberId = this.memberId;
                ac.magazaId = this.magazaId;
                ac.urunId = this.urunId;
                islem.FormAc(ac);
            }
        }
    }
}

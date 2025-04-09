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
    public partial class Siparis : Form
    {
        SiparisClass os = new SiparisClass();
        Islem islem = new Islem();
        ComboBox combx;
        public int magazaId;
        int sepetId, kargoIndex;
        string url;
        public Siparis()
        {
            InitializeComponent();
        }

        private void Siparis_Load(object sender, EventArgs e)
        {
            os.Doldur(magazaId); //Doldur Metodu çağrıldı
            dataGridView1.DataSource = os.tablo;
            combx = comboBox1;
            os.KargoDurumu(combx);
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sepetId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            label7.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label8.Text = dataGridView1.CurrentRow.Cells[3].Value + " " + dataGridView1.CurrentRow.Cells[4].Value;
            label9.Text = dataGridView1.CurrentRow.Cells[5].Value + " " + dataGridView1.CurrentRow.Cells[6].Value + " " + dataGridView1.CurrentRow.Cells[7].Value;
            label10.Text = dataGridView1.CurrentRow.Cells[8].Value + " Tl";
            comboBox1.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value) -1;

            url = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            url = url.Replace("/", "\\");
            url = islem.AnaDizin + url;
            pictureBox1.ImageLocation = url;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label7.Text == "")
            {
                MessageBox.Show("Ürün Seçili Değil");
            }
            else{
                kargoIndex = comboBox1.SelectedIndex + 1;
                os.KargoGuncelle(sepetId, kargoIndex);
                MagazaGiris ac = new MagazaGiris();
                ac.magazaId = this.magazaId;
                islem.FormAc(ac);
            }

        }
    }
}

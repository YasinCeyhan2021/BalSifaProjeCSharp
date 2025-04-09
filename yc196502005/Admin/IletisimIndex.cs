using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yc196502005.Admin
{
    public partial class IletisimIndex : Form
    {
        Islem islem = new Islem();
        IletisimClass os = new IletisimClass();
        int iletisimId;
        public IletisimIndex()
        {
            InitializeComponent();
        }

        private void IletisimIndex_Load(object sender, EventArgs e)
        {
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            os.Doldur(); //Doldur Metodu çağrıldı
            dataGridView1.DataSource = os.tablo;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            label8.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label9.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label10.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            label11.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            label12.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label7.Text == "")
            {
                MessageBox.Show("Mesaj Seçili Değil");
            }
            else
            {
                iletisimId = Convert.ToInt32(label7.Text);
                os.Sil(iletisimId);
                AdminIndex ac = new AdminIndex();
                islem.FormAc(ac);
            }
        }
    }
}

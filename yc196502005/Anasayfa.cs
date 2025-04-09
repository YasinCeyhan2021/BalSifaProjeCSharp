using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using yc196502005.Admin;
using yc196502005.Uye;

namespace yc196502005
{
    public partial class Anasayfa : Form
    {
        Islem islem = new Islem();
        AnasayfaClass os = new AnasayfaClass();
        string[] SliderDizi;
        int SliderIndex = 0;
        string search;
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timerSlide = new System.Timers.Timer(3000);

            timerSlide.Elapsed += SliderTimer;
            timerSlide.AutoReset = true;
            timerSlide.Enabled = true;
            timerSlide.SynchronizingObject = this;
            setSlider();
        }
        public void SliderTimer(object source, ElapsedEventArgs e)
        {
            setSlider();
        }

        public void setSlider()
        {
            SliderDizi = os.Slider();

            pictureBox1.ImageLocation = SliderDizi[SliderIndex];
            //label1.Text += SliderDizi[SliderIndex] + "\n" + SliderIndex + "\n";

            SliderIndex++;

            if (SliderIndex >= SliderDizi.Length)
            {
                SliderIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminGiris ac = new AdminGiris();
            islem.FormAc(ac);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SearchIndex ac = new SearchIndex();
            search = richTextBox1.Text;
            ac.search = this.search;
            islem.FormAc(ac);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Uyelik ac = new Uyelik();
            islem.FormAc(ac);
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Text = "";
        }


    }
}

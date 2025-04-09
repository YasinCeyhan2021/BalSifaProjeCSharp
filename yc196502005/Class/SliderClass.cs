using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace yc196502005
{
    class SliderClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataReader cmd;
        MySqlDataAdapter data;
        public DataTable tablo;
        string dizin = "/yc196502005/source/photo/";
        string url;

        public void Doldur()
        {
            baglanti.Open();
            data = new MySqlDataAdapter("SELECT * FROM slider", baglanti);
            tablo = new DataTable("veriler");
            data.Fill(tablo);
            baglanti.Close();
        }

        public void Kaydet(string Sliderİsmi)
        {
            url = dizin + Sliderİsmi;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO slider (url) VALUES ('" + url + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void Sil(int sliderId)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM slider WHERE sliderId= '" + sliderId + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Slider Silindi");
        }
    }
}

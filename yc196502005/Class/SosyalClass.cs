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
    class SosyalClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataReader cmd;
        MySqlDataAdapter data;

        public DataTable tablo;
        string Mesaj;
        string dizin = "/yc196502005/source/photo/";
        string url;

        public void Doldur()
        {
            baglanti.Open();
            data = new MySqlDataAdapter("SELECT * FROM bottom", baglanti);
            tablo = new DataTable("veriler");
            data.Fill(tablo);
            baglanti.Close();
        }
        public void Kaydet(string ad, string adresUrl, string photoİsmi)
        {
            url = dizin + photoİsmi;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO bottom (ad, url, photoUrl) VALUES ('" + ad + "', '" + adresUrl + "', '" + url + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void Guncelle(int bottomId, string ad, string url)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE bottom SET ad='" + ad + "', url = '" + url + "' WHERE bottomId = '" + bottomId + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi");
        }

        public void Sil(int bottomId)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM bottom WHERE bottomId= '" + bottomId + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silindi");
        }
    }
}




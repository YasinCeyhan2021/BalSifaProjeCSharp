using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using yc196502005.Uye;

namespace yc196502005
{
    class IletisimClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataReader cmd;
        MySqlDataAdapter data;
        public DataTable tablo;

        public void Doldur()
        {
            baglanti.Open();
            data = new MySqlDataAdapter("SELECT * FROM iletisim ORDER BY iletisimId DESC", baglanti);
            tablo = new DataTable("veriler");
            data.Fill(tablo);
            baglanti.Close();
        }

        public void Kaydet(string ad, string soyad, string tel, string ePosta, string mesaj)
        {
            if (ad == "" || soyad == "" || tel == "" || ePosta == "" || mesaj == "")
            {
                MessageBox.Show("Tüm alanları eksiksiz bir şekilde doldurun.");
            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "INSERT INTO iletisim (ad, soyad, tel, ePosta, mesaj) VALUES ('" + ad + "', '" + soyad + "', '" + tel + "', '" + ePosta + "', '" + mesaj + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Mesajınız iletildi.");
            }
        }

        public void Sil(int iletisimId)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM iletisim WHERE iletisimId= '" + iletisimId + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Mesaj Silindi");
        }
    }
}
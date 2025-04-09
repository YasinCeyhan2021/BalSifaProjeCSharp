using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using yc196502005.Admin;

namespace yc196502005
{
    class AdminClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataReader cmd;
        Islem islem = new Islem();
        public void Giris(string kAdi, string sifre)
        {
            if (kAdi == "" || sifre == "")
            {
               MessageBox.Show("Tüm alanları eksiksiz bir şekilde doldurun");
            }
            else
            {

                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM kullanici WHERE kAdi = '" + kAdi + "' AND sifre = '" + sifre + "'";
                cmd = komut.ExecuteReader();
                if (cmd.Read())
                {
                    MessageBox.Show("Giriş Başarılı !!!");
                    AdminGiris adminGiris = new AdminGiris();
                    adminGiris.Sifirla();
                    AdminIndex ac = new AdminIndex();
                    ac.kullaniciId = Convert.ToInt32(cmd["kullaniciId"]);
                    islem.FormAc(ac);
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış.");
                }
                baglanti.Close();
            }
        }
        public void Ayar(TextBox txtb1, TextBox txtb2)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanici";
            cmd = komut.ExecuteReader();
            if (cmd.Read())
            {
                txtb1.Text = cmd["kAdi"].ToString();
                txtb2.Text = cmd["sifre"].ToString();
            }

            baglanti.Close();
        }
        public void Guncelle(int kullaniciId, string kAdi, string sifre)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE kullanici SET kAdi='" + kAdi + "', sifre = '" + sifre + "' WHERE kullaniciId = '" + kullaniciId + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi");
        }
    }
}

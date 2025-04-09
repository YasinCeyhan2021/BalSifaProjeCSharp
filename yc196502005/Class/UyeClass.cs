using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using yc196502005.Uye;

namespace yc196502005
{
    class UyeClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataReader cmd;
        Islem islem = new Islem();

        public void UyeKayit(string ad, string soyad, string numara, string il, string ilce, string adres, string ePosta, string sifre)
        {
            if (ad == "" || soyad == "" || numara == "" || il == "" || ilce == "" || adres == "" || ePosta == "" || sifre == "")
            {
                MessageBox.Show("Tüm alanları eksiksiz bir şekilde doldurun");
            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "INSERT INTO member (ad, soyad, tel, il, ilce, adres, ePosta, sifre) VALUES ('" + ad + "', '" + soyad + "', '" + numara + "', '" + il + "', '" + ilce + "', '" + adres + "', '" + ePosta + "', '" + sifre + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Üye Olundu");
            }

        }
        public void UyeGiris(string ePosta, string sifre)
        {
            if (ePosta == "" || sifre == "")
            {
                MessageBox.Show("STüm alanları eksiksiz bir şekilde doldurun");
            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT * FROM member WHERE ePosta = '" + ePosta + "' AND sifre = '" + sifre + "'";
                cmd = komut.ExecuteReader();
                if (cmd.Read())
                {
                    MessageBox.Show("Giriş Başarılı !!!");
                    UyeIndex ac = new UyeIndex();
                    ac.memberId = Convert.ToInt32(cmd["memberId"]);
                    ac.ad = cmd["ad"].ToString();
                    ac.soyad = cmd["soyad"].ToString();
                    islem.FormAc(ac);
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış.");
                }
                baglanti.Close();
            }
        }
        public void Member(int memberId, TextBox txtb1, TextBox txtb2, TextBox txtb3, TextBox txtb4, TextBox txtb5, RichTextBox rxtb1, TextBox txtb6, TextBox txtb7)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM member WHERE memberId = '" + memberId + "'";
            cmd = komut.ExecuteReader();
            if (cmd.Read())
            {
                txtb1.Text = cmd["ad"].ToString();
                txtb2.Text = cmd["soyad"].ToString();
                txtb3.Text = cmd["tel"].ToString();
                txtb4.Text = cmd["il"].ToString();
                txtb5.Text = cmd["ilce"].ToString();
                rxtb1.Text = cmd["adres"].ToString();
                txtb6.Text = cmd["ePosta"].ToString();
                txtb7.Text = cmd["sifre"].ToString();
            }
            baglanti.Close();
        }
        public void Güncelle(int memberId, string ad, string soyad, string numara, string il, string ilce, string adres, string ePosta, string sifre)
        {
            if (memberId.ToString() == "" || ad == "" || soyad == "" || numara == "" || il == "" || ilce == "" || adres == "" || ePosta == "" || sifre == "")
            {
                MessageBox.Show("Tüm alanları eksiksiz bir şekilde doldurun");
            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "UPDATE member SET ad = '" + ad + "', soyad = '" + soyad + "', tel = '" + numara + "', il = '" + il + "', ilce = '" + ilce + "', adres = '" + adres + "', ePosta = '" + ePosta + "', sifre = '" + sifre + "' WHERE memberId = '" + memberId + "' ";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncellendi");
            }

        }

    }
}

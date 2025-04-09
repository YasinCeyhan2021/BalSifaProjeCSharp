using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using yc196502005.Magaza;


namespace yc196502005
{
    class MagazaClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataReader cmd;
        MySqlDataAdapter data;
        public DataTable tablo;
        Islem islem = new Islem();
        string AnaDizin, profilUrl ,bannerUrl, dizin = "/yc196502005/magaza/photo/";
        public void Doldur(int magazaId)
        {
            baglanti.Open();
            data = new MySqlDataAdapter("SELECT magazayorum.magazayorumId, member.memberId, member.ad, member.soyad, magazayorum.yorum FROM magaza, magazayorum, member WHERE magazayorum.magazaId = '" + magazaId + "' AND magaza.magazaId = magazayorum.magazaId AND member.memberId = magazayorum.memberId ORDER BY magazaYorumId DESC", baglanti);
            tablo = new DataTable("veriler");
            data.Fill(tablo);
            baglanti.Close();
        }
        public void Magaza(int magazaId, PictureBox pctb1, PictureBox pctb2, Label label)
        {
            AnaDizin = islem.AnaDizin;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM magaza WHERE magazaId = '" + magazaId + "'";
            cmd = komut.ExecuteReader();
            if (cmd.Read())
            {
                pctb1.ImageLocation = AnaDizin + cmd["banner"].ToString().Replace("/", "\\");
                pctb2.ImageLocation = AnaDizin + cmd["profil"].ToString().Replace("/", "\\");
                label.Text = cmd["magaza"].ToString();
            }
            baglanti.Close();
        }
        public void YorumKaydet(int magazaId, int memberId, string yorum)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO magazayorum (magazaId, memberId, yorum) VALUES ('" + magazaId + "', '" + memberId + "', '" + yorum + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yorumunuz Kaydedildi");
        }
        public void Sil(int magazaYorumId)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM magazaYorum WHERE magazaYorumId= '" + magazaYorumId + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yorumunuz Silindi");
        }

        public void MagazaControl(int memberId)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM magaza WHERE memberId = '" + memberId + "'";
            cmd = komut.ExecuteReader();
            if (cmd.Read())
            {
                MagazaGiris ac = new MagazaGiris();
                ac.magazaId = Convert.ToInt32(cmd["magazaId"]);
                islem.FormAc(ac);
            }
            else
            {
                MagazaOlustur ac = new MagazaOlustur();
                ac.memberId = memberId;
                islem.FormAc(ac);
            }
            baglanti.Close();
        }
        public void Güncelle(int magazaId, string magazaIsmi, string profilIsmi, string bannerIsmi)
        {
            profilUrl = dizin + profilIsmi;
            bannerUrl = dizin + bannerIsmi;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE magaza SET magaza='" + magazaIsmi + "', profil = '" + profilUrl + "', banner = '" + bannerUrl + "' WHERE magazaId = '" + magazaId + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi");
        }
        public void MagazaOlustur(int memberId, string magazaIsmi, string profilIsmi, string bannerIsmi)
        {
            profilUrl = dizin + profilIsmi;
            bannerUrl = dizin + bannerIsmi;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO magaza (memberId, magaza, profil, banner) VALUES ('" + memberId + "', '" + magazaIsmi + "', '" + profilUrl + "', '" + bannerUrl + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Mağazanız oluştu. Bu formu kapatıp Mağaza Butonuna tekrar tıklyın.");
        }

    }
}

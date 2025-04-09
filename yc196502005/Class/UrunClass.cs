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
    class UrunClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        Islem islem = new Islem();
        MySqlDataReader cmd;
        MySqlDataAdapter data;
        public DataTable tablo;
        string AnaDizin, photoUrl, dizin = "/yc196502005/magaza/include/photo/";
        public void Doldur()
        {
            baglanti.Open();
            data = new MySqlDataAdapter("SELECT urun.urunId, magaza.magazaId, urunCesit.urun, magaza.magaza, urun.photo, urun.fiyat FROM magaza, urunCesit, urun WHERE urun.magazaId = magaza.magazaId AND urun.urunCesitId = urunCesit.urunCesitId ORDER BY urun.urunId DESC", baglanti);
            tablo = new DataTable("veriler");
            data.Fill(tablo);
            baglanti.Close();
        }
        public void MagazaUrunDoldur(int magazaId)
        {
            baglanti.Open();
            data = new MySqlDataAdapter("SELECT urun.urunId, urunCesit.urunCesitId, urun.photo, urun.aciklama, urun.agirlik, urun.stok, urun.fiyat FROM magaza, urunCesit, urun WHERE urun.magazaId = '" + magazaId + "' AND magaza.magazaId = '" + magazaId + "' AND urunCesit.urunCesitId = urun.urunCesitId ORDER BY urun.urunId DESC", baglanti);
            tablo = new DataTable("veriler");
            data.Fill(tablo);
            baglanti.Close();
        }
        public void YorumDoldur(int urunId)
        {
            baglanti.Open();
            data = new MySqlDataAdapter("SELECT urunyorum.urunyorumId, member.memberId, member.ad, member.soyad, urunyorum.yorum FROM urun, urunyorum, member WHERE urunyorum.urunId = '" + urunId + "' AND urun.urunId = urunyorum.urunId AND member.memberId = urunyorum.memberId ORDER BY urunYorumId DESC", baglanti);
            tablo = new DataTable("veriler");
            data.Fill(tablo);
            baglanti.Close();
        }
        public void Urun(int urunId, PictureBox pctb1, Label label1, Label label2, Label label3, Label label4, Label label5)
        {
            AnaDizin = islem.AnaDizin;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM urun, uruncesit WHERE urunId = '" + urunId + "' AND urun.urunCesitId = uruncesit.urunCesitId";
            cmd = komut.ExecuteReader();
            if (cmd.Read())
            {
                label1.Text = cmd["urun"].ToString();
                label2.Text = cmd["agirlik"] + "Kg";
                label3.Text = cmd["stok"] + " Adet";
                label4.Text = cmd["fiyat"] + " Tl";
                label5.Text = cmd["aciklama"].ToString();
                pctb1.ImageLocation = AnaDizin + cmd["photo"].ToString().Replace("/", "\\");
            }
            baglanti.Close();
        }
        public void YorumKaydet(int urunId, int memberId, string yorum)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO urunyorum (urunId, memberId, yorum) VALUES ('" + urunId + "', '" + memberId + "', '" + yorum + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yorumunuz Kaydedildi");
        }
        public void Sil(int urunYorumId)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM urunYorum WHERE urunYorumId= '" + urunYorumId + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yorumunuz Silindi");
        }
        public void UrunCesit(ComboBox combx)
        {
            AnaDizin = islem.AnaDizin;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM uruncesit";
            cmd = komut.ExecuteReader();
            while (cmd.Read())
            {
                
                combx.Items.Add(cmd["urun"].ToString());
            }
            combx.SelectedIndex = 0;
            baglanti.Close();
        }
        public void UrunKaydet(int magazaId, int urunIndex, string photoIsmi, string aciklama, int agirlik, int stok, int fiyat)
        {
            photoUrl = dizin + photoIsmi;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO urun (magazaId, urunCesitId, photo, aciklama, agirlik, stok, fiyat) VALUES ('" + magazaId + "', '" + urunIndex + "', '" + photoUrl + "', '" + aciklama + "', '" + agirlik + "', '" + stok + "', '" + fiyat + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Kaydedildi");
        }
        public void UrunGuncelle(int urunId, int urunIndex, int agirlik, int stok, int fiyat, string aciklama)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE urun SET urunCesitId = '" + urunIndex + "', agirlik = '" + agirlik + "', stok = '" + stok + "', fiyat = '" + fiyat + "', aciklama = '" + aciklama + "' WHERE urunId = '" + urunId + "' ";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Güncellendi");
        }
        public void UrunSil(int urunId)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM urun WHERE urunId= '" + urunId + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Silindi");
        }

    }
}

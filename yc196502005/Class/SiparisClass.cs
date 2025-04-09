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
    class SiparisClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataReader cmd;
        MySqlDataAdapter data;
        public DataTable tablo;
        Islem islem = new Islem();
        public void Doldur(int magazaId)
        {
            baglanti.Open();
            data = new MySqlDataAdapter("SELECT sepet.sepetId, uruncesit.urun, urun.photo, member.ad, member.soyad, member.il, member.ilce, member.adres, urun.fiyat, kargo.kargoId FROM sepet, urun, magaza, uruncesit, kargo, member WHERE magaza.magazaId = '" + magazaId + "' AND sepet.urunId = urun.urunId AND magaza.magazaId = urun.magazaId AND uruncesit.urunCesitId = urun.urunCesitId AND kargo.kargoId = sepet.kargoId AND sepet.memberId = member.memberId ORDER BY sepet.sepetId DESC", baglanti);
            tablo = new DataTable("veriler");
            data.Fill(tablo);
            baglanti.Close();
        }
        public void KargoDurumu(ComboBox combx)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kargo";
            cmd = komut.ExecuteReader();
            while (cmd.Read())
            {

                combx.Items.Add(cmd["kargo"].ToString());
            }
            combx.SelectedIndex = 0;
            baglanti.Close();
        }
        public void KargoGuncelle(int sepetId, int kargoIndex)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE sepet SET kargoId = '" + kargoIndex + "' WHERE sepetId = '" + sepetId + "' ";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sipariş Durumu Güncellendi");
        }
    }
}

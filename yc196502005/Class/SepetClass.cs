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
    class SepetClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataReader cmd;
        MySqlDataAdapter data;
        public DataTable tablo;
        public void SepeteEkle(int memberId, int urunId)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO sepet (memberId, urunId, kargoId) VALUES ('" + memberId + "', '" + urunId + "', '1')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sepete Eklendi");
        }
        public void Doldur(int memberId)
        {
            baglanti.Open();
            data = new MySqlDataAdapter("SELECT sepet.sepetId, magaza.magaza, uruncesit.urun, urun.photo, urun.fiyat, kargo.kargoId, kargo.kargo FROM sepet, urun, magaza, uruncesit, kargo WHERE sepet.memberId = '" + memberId + "' AND sepet.urunId = urun.urunId AND magaza.magazaId = urun.magazaId AND uruncesit.urunCesitId = urun.urunCesitId AND kargo.kargoId = sepet.kargoId ORDER BY sepet.sepetId DESC", baglanti);
            tablo = new DataTable("veriler");
            data.Fill(tablo);
            baglanti.Close();
        }
        public void Sil(int sepetId)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM sepet WHERE sepetId= '" + sepetId + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sepetten Kaldırıldı");
        }
    }
}

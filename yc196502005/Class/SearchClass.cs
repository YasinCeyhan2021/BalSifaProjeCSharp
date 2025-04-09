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
    class SearchClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        Islem islem = new Islem();
        MySqlDataReader cmd;
        MySqlDataAdapter data;
        public DataTable tablo;
        string AnaDizin, photoUrl, dizin = "/yc196502005/magaza/include/photo/";
        public void Doldur(string search)
        {
            baglanti.Open();
            data = new MySqlDataAdapter("SELECT urun.urunId, magaza.magazaId, urunCesit.urun, magaza.magaza, urun.photo, urun.fiyat FROM magaza, urunCesit, urun WHERE urun.magazaId = magaza.magazaId AND urun.urunCesitId = urunCesit.urunCesitId AND (magaza.magaza LIKE '%" + search + "%' OR uruncesit.urun LIKE '%" + search + "%')  ORDER BY urun.urunId DESC", baglanti);
            tablo = new DataTable("veriler");
            data.Fill(tablo);
            baglanti.Close();
        }
    }
}

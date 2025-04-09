using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace yc196502005
{
    class AnasayfaClass
    {
        MySqlConnection baglanti = new MySqlConnection(Baglan.baglan);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataReader cmd;
        public string AnaDizin = "C:\\Users\\yasin_ceyhan\\Desktop\\yasin_ceyhan\\home_codes\\php\\yasin_ceyhan";

        public string[] Slider()
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT count(sliderId) AS kayitSayisi FROM slider";
            cmd = komut.ExecuteReader();
            int uzunluk = 0;
            if (cmd.Read())
            {
                uzunluk = Convert.ToInt32(cmd["kayitSayisi"].ToString());
            }
            string[] SliderDizi = new string[uzunluk];
            cmd.Close();
            komut.CommandText = "SELECT * FROM slider";
            cmd = komut.ExecuteReader();
            int i = 0;
            while (cmd.Read())
            {
                SliderDizi[i] = AnaDizin + cmd["url"].ToString().Replace("/", "\\");
                i++;
            }
            baglanti.Close();
            return SliderDizi;
        }
    }
}

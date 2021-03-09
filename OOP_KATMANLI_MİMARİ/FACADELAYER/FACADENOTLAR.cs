using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ENTITYLAYER;

namespace FACADELAYER
{
    public class FACADENOTLAR
    {
        public static bool GUNCELLE(ENTITYNOTLAR deger)
        {
            SqlCommand komut = new SqlCommand("NOTGUNCELLE", SQLBAGLANTISI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("SINAV1", deger.SINAV1);
            komut.Parameters.AddWithValue("SINAV2", deger.SINAV2);
            komut.Parameters.AddWithValue("SINAV3", deger.SINAV3);
            komut.Parameters.AddWithValue("PROJE", deger.PROJE);
            komut.Parameters.AddWithValue("ORTALAMA", deger.ORTALAMA);
            komut.Parameters.AddWithValue("DURUM", deger.DURUM);
            komut.Parameters.AddWithValue("OGRID", deger.OGRID);
            return komut.ExecuteNonQuery() > 0;
        }

        public static List<ENTITYNOTLAR> NOTLISTESI()
        {
            List<ENTITYNOTLAR> degerler = new List<ENTITYNOTLAR>();
            SqlCommand komut = new SqlCommand("NOTLISTESI", SQLBAGLANTISI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ENTITYNOTLAR ent = new ENTITYNOTLAR();
                ent.OGRID = Convert.ToInt16(dr["OGRID"].ToString());
                ent.AD = dr["AD"].ToString();
                ent.SOYAD = dr["SOYAD"].ToString();
                ent.SINAV1 = Convert.ToInt16(dr["SINAV1"].ToString());
                ent.SINAV2 = Convert.ToInt16(dr["SINAV2"].ToString());
                ent.SINAV3 = Convert.ToInt16(dr["SINAV3"].ToString());
                ent.ORTALAMA = Convert.ToDouble(dr["ORTALAMA"].ToString());
                ent.PROJE = Convert.ToInt16(dr["PROJE"].ToString());
                ent.DURUM = dr["DURUM"].ToString();

                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
    }
}
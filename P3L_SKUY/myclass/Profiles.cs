using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using P3L_SKUY.myclass;
using MySql.Data.MySqlClient;

namespace P3L_SKUY.myclass
{
    class Profiles:connectionClass
    {
        public string nama { set; get; }
        public string alamat { set; get; }
        public string no_telp { set; get; }
        public string id_pegawai { set; get; }

        public bool validate_user()
        {
            bool check = false;
            con.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT nama, alamat, no_telp FROM pegawai WHERE id_pegawai=@id_pegawai";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_pegawai", MySqlDbType.VarChar).Value = idLog.id;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    nama = rd.GetString("nama");
                    alamat = rd.GetString("alamat");
                    no_telp = rd.GetString("no_telp");
                }

                con.Close();
            }

            return check;
        }

        public void Update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE pegawai SET alamat=@alamat, no_telp=@no_telp WHERE id_pegawai=@id_pegawai"; 
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@alamat", MySqlDbType.VarChar).Value = alamat;
                cmd.Parameters.Add("@no_telp", MySqlDbType.VarChar).Value = no_telp;
                cmd.Parameters.Add("@id_pegawai", MySqlDbType.VarChar).Value = idLog.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}

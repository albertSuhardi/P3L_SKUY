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
    static class idLog
    {
        public static string id;
    }

    class LoginLogout : connectionClass
    {
        public string username { set; get; }
        public string password { set; get; }
        public string role { set; get; }
        public string id_pegawai { set; get; }
        public string nama { set; get; }

        public bool validate_user()
        {
            bool check = false;
            con.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM pegawai WHERE username=@username AND password=@password";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    id_pegawai = rd.GetString("id_pegawai");
                    idLog.id = id_pegawai;
                    nama = rd.GetString("nama");
                    role = rd.GetString("role");
                }

                con.Close();
            }

            return check;
        }
        /*private String id_pegawai, nama, alamat, no_telp, role, password, username;
        public LoginLogout(String id_pegawai, String nama, String alamat, String no_telp, String role, String password, String username)
        {
            id_pegawai = id_pegawai;
            nama = nama;
            alamat = alamat;
            no_telp = no_telp;
            role = role;
            password = password;
            username = username;

            *//*string host = "localhost";
            string db = "p3l_gaskuy";
            string port = "3306";
            string user = "root";
            string pass = "";
            string constring = "datasource =" + host + "; database =" + db + "; port =" + port + "; username =" + user + "; password=" + pass + "; SslMode=none";
            con = new MySqlConnection(constring);*//*
        }*/

        public LoginLogout()
        {
            
        }
    }
}


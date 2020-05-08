using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace P3L_SKUY.myclass
{
    class Pegawai
    {
        public MySqlConnection con;
        public Pegawai()
        {
            string host = "localhost";
            string db = "p3l_gaskuy";
            string port = "3306";
            string user = "root";
            string pass = "";
            string constring = "datasource =" + host + "; database =" + db + "; port =" + port + "; username =" + user + "; password=" + pass + "; SslMode=none";
            con = new MySqlConnection(constring);
        }

    }

    class Pegawais:Pegawai
    {
        public List<string> datafill = new List<string>();

        public string search_text { set; get; }
        public string nama { set; get; }
        public string alamat { set; get; }
        public string tgl_lhr { set; get; }
        public string no_telp { set; get; }
        public string role { set; get; }
        public string password { set; get; }
        public string username { set; get; }
        public string id_pegawai { set; get; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        
        
        public void Create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO pegawai(nama, alamat, tgl_lhr, no_telp, role, password, username, created_at, update_at, delete_at, aktor) VALUES(@nama, @alamat, @tgl_lhr, @no_telp, @role, @password, @username, CURRENT_TIMESTAMP(), NULL, NULL, @aktor)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@alamat", MySqlDbType.VarChar).Value = alamat;
                cmd.Parameters.Add("@tgl_lhr", MySqlDbType.DateTime).Value = tgl_lhr;
                cmd.Parameters.Add("@no_telp", MySqlDbType.VarChar).Value = no_telp;
                cmd.Parameters.Add("@role", MySqlDbType.VarChar).Value = role;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;


                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE pegawai SET nama=@nama, alamat=@alamat, tgl_lhr=@tgl_lhr, no_telp=@no_telp, role=@role, password=@password, username=@username, update_at=CURRENT_TIMESTAMP(), delete_at=NULL, aktor=@aktor WHERE id_pegawai=@id_pegawai";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@alamat", MySqlDbType.VarChar).Value = alamat;
                cmd.Parameters.Add("@tgl_lhr", MySqlDbType.Date).Value = tgl_lhr;
                cmd.Parameters.Add("@no_telp", MySqlDbType.VarChar).Value = no_telp;
                cmd.Parameters.Add("@role", MySqlDbType.VarChar).Value = role;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@id_pegawai", MySqlDbType.VarChar).Value = id_pegawai;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE pegawai SET delete_at=CURRENT_TIMESTAMP(), aktor=@aktor WHERE id_pegawai=@id_pegawai";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_pegawai", MySqlDbType.VarChar).Value = id_pegawai;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataSet read_data()
        {
            ds.Clear();
            string query = "SELECT * FROM pegawai where delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "pegawai");
            return ds;   
        }

        public DataSet search_data(String search)
        {
            ds.Clear();
            string query = "SELECT * FROM pegawai WHERE nama like '%" + search + "%' AND delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "pegawai");
            return ds;
        }
    }
}

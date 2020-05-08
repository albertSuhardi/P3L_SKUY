using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace P3L_SKUY.myclass
{
    class Layanan
    {
        public MySqlConnection con;
        public Layanan()
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

    class Layanans : Layanan
    {
        public string nama { set; get; }
        public string harga { set; get;  }
        public string id_layanan { set; get; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();


        public void Create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO layanan(nama, harga, created_at, update_at, delete_at, aktor) VALUES(@nama, @harga, CURRENT_TIMESTAMP(), NULL, NULL, @aktor)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga;
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
                cmd.CommandText = "UPDATE layanan SET nama=@nama, harga=@harga, update_at=CURRENT_TIMESTAMP(), aktor=@aktor, delete_at=NULL WHERE id_layanan=@id_layanan";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@id_layanan", MySqlDbType.VarChar).Value = id_layanan;
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
                cmd.CommandText = "UPDATE layanan SET delete_at=CURRENT_TIMESTAMP(), aktor=@aktor WHERE id_layanan=@id_layanan";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_layanan", MySqlDbType.VarChar).Value = id_layanan;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataSet read_data()
        {
            ds.Clear();
            string query = "SELECT l.id_layanan, l.nama, l.harga, l.created_at, l.update_at, p.nama AS aktor FROM layanan l JOIN pegawai p ON l.aktor = p.id_pegawai WHERE l.delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "layanan");
            return ds;

        }

        public DataSet search_data(String search)
        {
            ds.Clear();
            string query = "SELECT l.nama, l.id_layanan, l.harga, l.created_at, l.update_at, p.nama AS aktor FROM layanan l JOIN pegawai p ON l.aktor = p.id_pegawai WHERE l.nama like '%" + search + "%' AND l.delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "layanan");
            return ds;
        }
    }
}

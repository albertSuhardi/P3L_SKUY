using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace P3L_SKUY.myclass
{
    class JenisHewan
    {
        public MySqlConnection con;
        public JenisHewan()
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

    class Jeniss : JenisHewan
    {

        public string jenis { set; get; }
        public string harga { set; get; }
        public string id_jenis { set; get; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();


        public void Create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO jenis_hewan(jenis, harga, created_at, update_at, delete_at, aktor) VALUES(@jenis, @harga, CURRENT_TIMESTAMP(), NULL, NULL, @aktor)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@jenis", MySqlDbType.VarChar).Value = jenis;
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
                cmd.CommandText = "UPDATE jenis_hewan SET jenis=@jenis, harga=@harga, update_at=CURRENT_TIMESTAMP(), aktor=@aktor, delete_at=NULL WHERE id_jenis=@id_jenis";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_jenis", MySqlDbType.VarChar).Value = id_jenis;
                cmd.Parameters.Add("@jenis", MySqlDbType.VarChar).Value = jenis;
                cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga;
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
                cmd.CommandText = "UPDATE jenis_hewan SET delete_at=CURRENT_TIMESTAMP(), aktor=@aktor WHERE id_jenis=@id_jenis";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_jenis", MySqlDbType.VarChar).Value = id_jenis;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataSet read_data()
        {
            ds.Clear();
            string query = "SELECT j.id_jenis, j.jenis, j.harga, j.created_at, j.delete_at, j.update_at, p.nama AS aktor FROM jenis_hewan j JOIN pegawai p ON j.aktor=p.id_pegawai where j.delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "jenis_hewan");
            return ds;
        }

        public DataSet search_data(String search)
        {
            ds.Clear();
            string query = "SELECT j.id_jenis, j.jenis, j.harga, j.created_at, j.delete_at, j.update_at, p.nama AS aktor FROM jenis_hewan j JOIN pegawai p ON j.aktor=p.id_pegawai WHERE j.jenis like '%" + search + "%' AND j.delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "jenis_hewan");
            return ds;
        }
    }
}

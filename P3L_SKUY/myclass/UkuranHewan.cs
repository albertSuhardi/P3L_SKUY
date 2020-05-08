 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace P3L_SKUY.myclass
{
    class UkuranHewan
    {
        public MySqlConnection con;
        public UkuranHewan()
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

    class Ukurans : UkuranHewan
    {
        public string ukuran { set; get; }

        public string harga { set; get; }

        public string id_ukuran { set; get; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();


        public void Create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO ukuran_hewan(ukuran, harga, created_at, update_at, delete_at, aktor) VALUES(@ukuran, @harga, CURRENT_TIMESTAMP(), NULL, NULL, @aktor)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@ukuran", MySqlDbType.VarChar).Value = ukuran;
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
                cmd.CommandText = "UPDATE ukuran_hewan SET ukuran=@ukuran, harga=@harga, update_at=CURRENT_TIMESTAMP(), aktor=@aktor, delete_at=NULL WHERE id_ukuran=@id_ukuran";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_ukuran", MySqlDbType.VarChar).Value = id_ukuran;
                cmd.Parameters.Add("@ukuran", MySqlDbType.VarChar).Value = ukuran;
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
                cmd.CommandText = "UPDATE ukuran_hewan SET delete_at=CURRENT_TIMESTAMP(), aktor=@aktor WHERE id_ukuran=@id_ukuran";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_ukuran", MySqlDbType.VarChar).Value = id_ukuran;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataSet read_data()
        {
            ds.Clear();
            string query = "SELECT u.id_ukuran ,u.ukuran ,u.harga, u.created_at, u.update_at, u.delete_at, p.nama as aktor from ukuran_hewan u JOIN pegawai p ON(u.aktor = p.id_pegawai) where u.delete_at is null";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "ukuran_hewan");
            return ds;
        }

        public DataSet search_data(String search)
        {
            ds.Clear();
            string query = "SELECT u.id_ukuran ,u.ukuran ,u.harga, u.created_at, u.update_at, u.delete_at, p.nama as aktor FROM ukuran_hewan u JOIN pegawai p ON(u.aktor = p.id_pegawai) WHERE u.ukuran like '%" + search + "%' AND u.delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "ukuran_hewan");
            return ds;
        }
    }
}

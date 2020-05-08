using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace P3L_SKUY.myclass
{
    class Supplier
    {
        public MySqlConnection con;
        public Supplier()
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

    class Suppliers : Supplier
    {

        public string nama { set; get; }
        public string alamat { set; get; }
        public string no_telp { set; get; }
        public string id_supplier { set; get; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();


        public void Create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO supplier(nama, alamat, no_telp, created_at, update_at, delete_at, aktor) VALUES(@nama, @alamat, @no_telp, CURRENT_TIMESTAMP(), NULL, NULL, @aktor)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@alamat", MySqlDbType.VarChar).Value = alamat;
                cmd.Parameters.Add("@no_telp", MySqlDbType.VarChar).Value = no_telp;
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
                cmd.CommandText = "UPDATE supplier SET nama=@nama, alamat=@alamat, no_telp=@no_telp, update_at=CURRENT_TIMESTAMP(), aktor=@aktor WHERE id_supplier=@id_supplier";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@alamat", MySqlDbType.VarChar).Value = alamat;
                cmd.Parameters.Add("@no_telp", MySqlDbType.VarChar).Value = no_telp;
                cmd.Parameters.Add("@id_supplier", MySqlDbType.VarChar).Value = id_supplier;
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
                cmd.CommandText = "UPDATE supplier SET delete_at=CURRENT_TIMESTAMP(), aktor=@aktor, delete_at=NULL WHERE id_supplier=@id_supplier";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_supplier", MySqlDbType.VarChar).Value = id_supplier;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataSet read_data()
        {
            ds.Clear();
            string query = "SELECT s.id_supplier ,s.nama ,s.no_telp, s.alamat, s.created_at, s.update_at, s.delete_at, p.nama as aktor from supplier s JOIN pegawai p ON(s.aktor = p.id_pegawai) where s.delete_at is null";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "supplier");
            return ds;

        }

        public DataSet search_data(String search)
        {
            ds.Clear();
            string query = "SELECT s.id_supplier ,s.nama ,s.no_telp, s.alamat, s.created_at, s.update_at, s.delete_at, p.nama as aktor FROM supplier s JOIN pegawai p ON(s.aktor = p.id_pegawai) WHERE s.nama like '%" + search + "%' AND s.delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "supplier");
            return ds;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace P3L_SKUY.myclass
{ 
    class Member
    {
        public MySqlConnection con;
        public Member()
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

    class Members : Member
    {

        public string nama { set; get; }
        public string alamat { set; get; }
        public string no_telp { set; get; }
        public string tgl_lhr { set; get; }
        public string status { set; get; }
        public string id_member { set; get; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        public void Create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO member(nama, alamat, tgl_lhr, no_telp, status, created_at, update_at, delete_at, aktor) VALUES(@nama, @alamat, @tgl_lhr, @no_telp, @status, CURRENT_TIMESTAMP(), NULL, NULL, @aktor)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@alamat", MySqlDbType.VarChar).Value = alamat;
                cmd.Parameters.Add("@no_telp", MySqlDbType.VarChar).Value = no_telp;
                cmd.Parameters.Add("@tgl_lhr", MySqlDbType.VarChar).Value = tgl_lhr;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
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
                cmd.CommandText = "UPDATE member SET nama=@nama, alamat=@alamat, no_telp=@no_telp, tgl_lhr=@tgl_lhr, status=@status, update_at=CURRENT_TIMESTAMP(), aktor=@aktor, delete_at=NULL WHERE id_member=@id_member";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@alamat", MySqlDbType.VarChar).Value = alamat;
                cmd.Parameters.Add("@no_telp", MySqlDbType.VarChar).Value = no_telp;
                cmd.Parameters.Add("@tgl_lhr", MySqlDbType.VarChar).Value = tgl_lhr;
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@id_member", MySqlDbType.VarChar).Value = id_member;
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
                cmd.CommandText = "UPDATE member SET delete_at=CURRENT_TIMESTAMP(), aktor=@aktor WHERE id_member=@id_member";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_member", MySqlDbType.VarChar).Value = id_member;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataSet read_data()
        {
            ds.Clear();
            string query = "SELECT m.id_member, m.nama, m.alamat, m.tgl_lhr, m.no_telp, m.status, m.created_at, m.update_at, p.nama AS aktor FROM member m JOIN pegawai p ON m.aktor = p.id_pegawai where m.delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "member");
            return ds;
        }

        public DataSet search_data(String search)
        {
            ds.Clear();
            string query = "SELECT m.id_member, m.nama, m.alamat, m.tgl_lhr, m.no_telp, m.status, m.created_at, m.update_at, p.nama AS aktor FROM member m JOIN pegawai p ON m.aktor = p.id_pegawai WHERE m.nama like '%" + search + "%' AND m.delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "member");
            return ds;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace P3L_SKUY.myclass
{

    class DataHewan
    {
        public MySqlConnection con;
        public DataHewan()
        {
            string host = "localhost";
            string db = "p3l_gaskuy";
            string port = "3306";
            string user = "root";
            string password = "";
            string constring = "datasource =" + host + "; database =" + db + "; port =" + port + "; username =" + user + "; password=" + password + "; SslMode=none";
            con = new MySqlConnection(constring);
        }
    }

    class DataHewans : DataHewan
    {
        public int i { set; get; }
        public string id_ukuran { set; get; }
        public string id_jenis { set; get; }
        public string id_hewan { set; get; }
        public string nama { set; get; }
        public string tgl_lhr { set; get; }
        public string id_member { set; get; }
        public string id_pegawai_cs { set; get; }
        public string id_pegawai_kasir { set; get; }
        public string jenis { set; get; }
        public string ukuran { set; get; }
        public string owner { set; get; }

        public List<string> dataJenis = new List<string>();
        public List<string> dataHewan = new List<string>();
        public List<string> dataUkuran = new List<string>();
        public List<string> dataMember = new List<string>();

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        //Dapat tampil jenis hewan, ukuran, member
        /// <summary>
        /// /////////////////////////////
        /// </summary>
        public void jenis_data()
        {
            dataJenis.Clear();
            MySqlDataReader rd;

            using (var cmd = new MySqlCommand()) 
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM jenis_hewan where delete_at IS NULL";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                i = 0;
                rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    dataJenis.Add(rd.GetString("jenis"));
                }
                con.Close();
            }

        }

        public void ukuran_data()
        {
            dataUkuran.Clear();
            MySqlDataReader rd;

            String query = "SELECT * FROM ukuran_hewan";
            using (var cmd = new MySqlCommand())
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM ukuran_hewan where delete_at IS NULL";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dataUkuran.Add(rd[1].ToString());
                }
                con.Close();
            }
        }

        public void owner_data()
        {
            dataMember.Clear();
            MySqlDataReader rd;

            String query = "SELECT * FROM member";
            using (var cmd = new MySqlCommand())
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM member where delete_at IS NULL";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dataMember.Add(rd[3].ToString());
                }
                con.Close();
            }
        }


        public void Create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO data_hewan(id_jenis, id_ukuran, tgl_lhr, nama, created_at, update_at, id_pegawai_cs, id_pegawai_kasir, id_member, aktor, delete_at) VALUES(@id_jenis, @id_ukuran, @tgl_lhr, @nama, CURRENT_TIMESTAMP(), NULL, @id_pegawai_cs, NULL, @id_member, @aktor, NULL)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;


                cmd.Parameters.Add("@id_jenis", MySqlDbType.VarChar).Value = id_jenis;
                cmd.Parameters.Add("@id_ukuran", MySqlDbType.VarChar).Value = id_ukuran;
                cmd.Parameters.Add("@tgl_lhr", MySqlDbType.VarChar).Value = tgl_lhr;
                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@id_member", MySqlDbType.VarChar).Value = id_member;
                cmd.Parameters.Add("@id_pegawai_cs", MySqlDbType.VarChar).Value = id_pegawai_cs;
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
                cmd.CommandText = "UPDATE data_hewan SET id_jenis=@id_jenis, id_ukuran=@id_ukuran, nama=@nama, tgl_lhr=@tgl_lhr, id_member=@id_member, update_at=CURRENT_TIMESTAMP(), aktor=@aktor, delete_at=NULL  WHERE id_hewan=@id_hewan";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@tgl_lhr", MySqlDbType.Date).Value = tgl_lhr;
                cmd.Parameters.Add("@id_jenis", MySqlDbType.VarChar).Value = id_jenis;
                cmd.Parameters.Add("@id_ukuran", MySqlDbType.VarChar).Value = id_ukuran;
                cmd.Parameters.Add("@id_member", MySqlDbType.VarChar).Value = id_member;
                cmd.Parameters.Add("@id_hewan", MySqlDbType.VarChar).Value = id_hewan;
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
                cmd.CommandText = "UPDATE data_hewan SET delete_at=CURRENT_TIMESTAMP(), aktor=@aktor WHERE id_hewan=@id_hewan";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_hewan", MySqlDbType.VarChar).Value = id_hewan;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataSet read_data()
        {
            ds.Clear();
            string query = "SELECT d.id_hewan, j.jenis, u.ukuran, d.nama, d.tgl_lhr, d.created_at, d.update_at, m.nama as member, p.nama as aktor FROM data_hewan d JOIN jenis_hewan j ON d.id_jenis=j.id_jenis JOIN ukuran_hewan u ON d.id_ukuran = u.id_ukuran JOIN member m ON d.id_member=m.id_member JOIN pegawai p ON d.aktor = p.id_pegawai where d.delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "data_hewan");
            return ds;
        }

        public DataSet search_data(String search)
        {
            ds.Clear();
            string query = "SELECT d.id_hewan, j.jenis, u.ukuran, d.nama, d.tgl_lhr, d.created_at, d.update_at, m.nama as member, p.nama as aktor FROM data_hewan d JOIN jenis_hewan j ON d.id_jenis=j.id_jenis JOIN ukuran_hewan u ON d.id_ukuran = u.id_ukuran JOIN member m ON d.id_member=m.id_member JOIN pegawai p ON d.aktor = p.id_pegawai where d.nama like '%" + search + "%'";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "data_hewan");
            return ds;
        }

        /*public DataSet search_jenis(String jenis)
        {
            ds.Clear();
            string query = "SELECT id_jenis from jenis_hewan where jenis='"+ jenis +"'";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "jenis_hewan");
            return ds;
        }

        public DataSet search_ukuran(String ukuran)
        {
            ds.Clear();
            string query = "SELECT id_ukuran from ukuran_hewan where ukuran='" + ukuran + "'";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "ukuran_hewan");
            return ds;
        }

        public DataSet search_member(String member)
        {
            ds.Clear();
            string query = "SELECT id_member from member where nama='" + member + "'";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "member");
            return ds;
        }*/

        // Get id untuk create
        /// <summary>
        /// /////////////////////////////
        /// </summary>
        public bool search_idJenis()
        {
            bool check = false;
            con.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM jenis_hewan WHERE jenis=@jenis";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@jenis", MySqlDbType.VarChar).Value = jenis;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    id_jenis = rd.GetString("id_jenis");
                }

                con.Close();
            }

            return check;
        }

        public bool search_idUkuran()
        {
            bool check = false;
            con.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM ukuran_hewan WHERE ukuran=@ukuran";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@ukuran", MySqlDbType.VarChar).Value = ukuran;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    id_ukuran = rd.GetString("id_ukuran");
                }

                con.Close();
            }

            return check;
        }
        public bool search_idMember()
        {
            bool check = false;
            con.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM member WHERE nama=@nama";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = owner;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    id_member = rd.GetString("id_member");
                }

                con.Close();
            }

            return check;
        }

        /// Get jenis, ukuran, member untuk update
        /// <summary>
        /// /////////////////////////////
        /// </summary>
        public bool search_Jenis()
        {
            bool check = false;
            con.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM jenis_hewan WHERE id_jenis=@id_jenis";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_jenis", MySqlDbType.VarChar).Value = id_jenis;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    jenis = rd.GetString("jenis");
                }

                con.Close();
            }

            return check;
        }

        public bool search_Ukuran()
        {
            bool check = false;
            con.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM ukuran_hewan WHERE id_ukuran=@id_ukuran";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_ukuran", MySqlDbType.VarChar).Value = id_ukuran;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    ukuran = rd.GetString("ukuran");
                }

                con.Close();
            }

            return check;
        }
        public bool search_Member()
        {
            bool check = false;
            con.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM member WHERE id_member=@id_member";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_member", MySqlDbType.VarChar).Value = id_member;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    owner = rd.GetString("nama");
                }

                con.Close();
            }

            return check;
        }

    }
}

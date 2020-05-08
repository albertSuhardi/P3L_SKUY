using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using P3L_SKUY.myclass;
using MySql.Data.MySqlClient;

namespace P3L_SKUY.myclass
{
    class Produks : connectionClass
    {

        public string nama { set; get; }
        public string unit { set; get; }
        public string stok { set; get; }
        public string min_stok { set; get; }
        public string harga { set; get; }
        public string id_produk { set; get; }
        public byte[] fotos { set; get; }

        //FOR ID

        //READ PROPERTIES

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        public void create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO produk(id_produk, nama, unit, stok, min_stok, harga, fotos, created_at, update_at, delete_at, aktor) VALUES (NULL, @nama, @unit, @stok, @min_stok, @harga, @fotos, CURRENT_TIMESTAMP(), NULL, NULL, @aktor)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = unit;
                cmd.Parameters.Add("@stok", MySqlDbType.Int16).Value = stok;
                cmd.Parameters.Add("@min_stok", MySqlDbType.Int16).Value = min_stok;
                cmd.Parameters.Add("@harga", MySqlDbType.Float).Value = harga;
                cmd.Parameters.Add("@fotos", MySqlDbType.Blob).Value = fotos;
                //cmd.Parameters.Add (new MySqlParameter ("@foto", foto));
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;


                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE produk SET nama=@nama, unit=@unit, stok=@stok, min_stok=@min_stok, harga=@harga, fotos=@fotos, update_at=CURRENT_TIMESTAMP(), aktor=@aktor, delete_at=NULL WHERE id_produk=@id_produk";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = unit;
                cmd.Parameters.Add("@stok", MySqlDbType.VarChar).Value = stok;
                cmd.Parameters.Add("@min_stok", MySqlDbType.VarChar).Value = min_stok;
                cmd.Parameters.Add("@harga", MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@fotos", MySqlDbType.LongBlob).Value = fotos;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;
                cmd.Parameters.Add("@id_produk", MySqlDbType.VarChar).Value = id_produk;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE produk SET delete_at=CURRENT_TIMESTAMP(), aktor=@aktor WHERE id_produk = @id_produk";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id_produk", MySqlDbType.Int16).Value = id_produk;
                cmd.Parameters.Add("@aktor", MySqlDbType.VarChar).Value = idLog.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataSet read_data()
        {
            ds.Clear();
            string query = "SELECT pr.id_produk , pr.nama , pr.unit, pr.stok, pr.min_stok, pr.harga, pr.fotos, pr.created_at, pr.update_at, pr.delete_at, p.nama as aktor from produk pr JOIN pegawai p ON pr.aktor = p.id_pegawai where pr.delete_at is null";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "produk");
            return ds;
        }

        public DataSet search_data(String search)
        {
            ds.Clear();
            string query = "SELECT pr.id_produk , pr.nama , pr.unit, pr.stok, pr.min_stok, pr.harga, pr.fotos, pr.created_at, pr.update_at, pr.delete_at, p.nama as aktor FROM produk pr JOIN pegawai p ON pr.aktor = p.id_pegawai WHERE pr.nama like '%" + search + "%' AND pr.delete_at IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "produk");
            return ds;
        }
    }
}

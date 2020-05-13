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
    class TransaksiLayanan : connectionClass
    {
        public string status { set; get; }
        public string pengeluaran { set; get; }
        public string id_pengadaan { set; get; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        public DataSet read_data()
        {
            ds.Clear();
            string query = "SELECT tl.id_transaksi_layanan, tl.id_hewan, tl.total_harga, tl.status_layanan, tl.diskon, tl.sub_total, tl.id_member, tl.created_at, tl.delete_at, tl.id_pegawai_cs, tl.aktor, m.nama as member, p.nama as aktors, h.nama as hewan from transaksi_layanan tl JOIN pegawai p ON(tl.aktor = p.id_pegawai) JOIN member m ON(tl.id_member = m.id_member) JOIN data_hewan h ON(tl.id_hewan = h.id_hewan) where tl.delete_at IS NULL AND tl.id_pegawai_kasir = '0' AND tl.tgl_selesai IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "transaksi_layanan");
            return ds;
        }

        public DataSet search_data(String search)
        {
            ds.Clear();
            string query = "SELECT tl.id_transaksi_layanan, tl.id_hewan, tl.total_harga, tl.status_layanan, tl.diskon, tl.sub_total, tl.id_member, tl.created_at, tl.delete_at, tl.id_pegawai_cs, tl.aktor, m.nama as member, p.nama as aktors, h.nama as hewan from transaksi_layanan tl JOIN pegawai p ON(tl.aktor = p.id_pegawai) JOIN member m ON(tl.id_member = m.id_member) JOIN data_hewan h ON(tl.id_hewan = h.id_hewan) where m.nama like '%" + search + "%' AND tl.delete_at IS NULL AND tl.id_pegawai_kasir = '0' AND tl.tgl_selesai IS NULL";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds, "transaksi_layanan");
            return ds;
        }
    }
}

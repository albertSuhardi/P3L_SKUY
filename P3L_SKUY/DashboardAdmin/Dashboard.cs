using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P3L_SKUY.myclass;
using MySql.Data.MySqlClient;

namespace P3L_SKUY.DashboardAdmin
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void customizeDesign()
        {
            pnlHewan.Visible = false;
        }

        private void hideSubMenu()
        {
            if (pnlHewan.Visible == true)
            {
                pnlHewan.Visible = false;
            }
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private Form activeForm = null;

        private void OpenChildForm(Form childForm)
        {
            if (activeForm!=null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Yakin ingin keluar?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                idLog.id = null;
                new Login().Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Nothing to do
            }
        }

        private void btnPegawai_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new MainBoard());
        }

        private void btnHewan_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlHewan);
        }

        private void btnDataHewan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardAdmin.Hewan.DataHewan());
            hideSubMenu();
        }

        private void btnJenis_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardAdmin.Hewan.JenisHewan());
            hideSubMenu();
        }

        private void btnUkuran_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardAdmin.Hewan.UkuranForm());
            hideSubMenu();
        }

        private void btnMember_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardAdmin.Member.Member());
        }

        private void btnSupplier_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardAdmin.Supplier.Supplier());
        }

        private void btnLayanan_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardAdmin.Layanan.Layanan());
        }

        private void btnProduk_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardAdmin.Produk.Produk());
        }
    }
}

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

namespace P3L_SKUY.DashboardKasir
{
    public partial class DashboardKasir : Form
    {
        public DashboardKasir()
        {
            InitializeComponent();
        }

        private Form activeForm = null;

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
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

        private void gunaPictureBox2_DoubleClick(object sender, EventArgs e)
        {
            OpenChildForm(new Profile.Profile());
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

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pembayaran.KasirLayanan());
        }
    }
}

namespace P3L_SKUY.DashboardAdmin.Pegawai
{
    partial class frmAddEditPegawai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lbltitle = new System.Windows.Forms.Label();
            this.txtNamaP = new System.Windows.Forms.TextBox();
            this.txtAlamatP = new System.Windows.Forms.TextBox();
            this.TglP = new System.Windows.Forms.DateTimePicker();
            this.txtNoP = new System.Windows.Forms.TextBox();
            this.txtUserP = new System.Windows.Forms.TextBox();
            this.txtPassP = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlError = new System.Windows.Forms.Panel();
            this.lblError = new Guna.UI.WinForms.GunaLabel();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrError = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.gunaRadioButton1 = new Guna.UI.WinForms.GunaRadioButton();
            this.gunaRadioButton2 = new Guna.UI.WinForms.GunaRadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlError.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Chocolate;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbltitle);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 54);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(380, -2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "[ x ]";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(3, 8);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(64, 30);
            this.lbltitle.TabIndex = 0;
            this.lbltitle.Text = "{title}";
            // 
            // txtNamaP
            // 
            this.txtNamaP.Location = new System.Drawing.Point(40, 120);
            this.txtNamaP.Name = "txtNamaP";
            this.txtNamaP.Size = new System.Drawing.Size(323, 20);
            this.txtNamaP.TabIndex = 1;
            // 
            // txtAlamatP
            // 
            this.txtAlamatP.Location = new System.Drawing.Point(40, 170);
            this.txtAlamatP.Name = "txtAlamatP";
            this.txtAlamatP.Size = new System.Drawing.Size(323, 20);
            this.txtAlamatP.TabIndex = 2;
            // 
            // TglP
            // 
            this.TglP.CustomFormat = "yyyy-MM-dd";
            this.TglP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TglP.Location = new System.Drawing.Point(7, 158);
            this.TglP.Name = "TglP";
            this.TglP.Size = new System.Drawing.Size(96, 20);
            this.TglP.TabIndex = 3;
            // 
            // txtNoP
            // 
            this.txtNoP.Location = new System.Drawing.Point(40, 277);
            this.txtNoP.Name = "txtNoP";
            this.txtNoP.Size = new System.Drawing.Size(323, 20);
            this.txtNoP.TabIndex = 4;
            // 
            // txtUserP
            // 
            this.txtUserP.Location = new System.Drawing.Point(40, 383);
            this.txtUserP.Name = "txtUserP";
            this.txtUserP.Size = new System.Drawing.Size(323, 20);
            this.txtUserP.TabIndex = 6;
            // 
            // txtPassP
            // 
            this.txtPassP.Location = new System.Drawing.Point(40, 441);
            this.txtPassP.Name = "txtPassP";
            this.txtPassP.Size = new System.Drawing.Size(323, 20);
            this.txtPassP.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gunaRadioButton2);
            this.panel2.Controls.Add(this.gunaRadioButton1);
            this.panel2.Controls.Add(this.pnlError);
            this.panel2.Controls.Add(this.gunaButton1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.TglP);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(33, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 470);
            this.panel2.TabIndex = 8;
            // 
            // pnlError
            // 
            this.pnlError.BackColor = System.Drawing.Color.Red;
            this.pnlError.Controls.Add(this.lblError);
            this.pnlError.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlError.Location = new System.Drawing.Point(0, 0);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(346, 27);
            this.pnlError.TabIndex = 24;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Red;
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.White;
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(346, 27);
            this.lblError.TabIndex = 0;
            this.lblError.Text = "gunaLabel1";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaButton1
            // 
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gunaButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaButton1.ForeColor = System.Drawing.Color.White;
            this.gunaButton1.Image = null;
            this.gunaButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton1.Location = new System.Drawing.Point(91, 421);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Radius = 20;
            this.gunaButton1.Size = new System.Drawing.Size(160, 42);
            this.gunaButton1.TabIndex = 16;
            this.gunaButton1.Text = "Save";
            this.gunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton1.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Role";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nomor Telephone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tgl Lahir Pegawai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Alamat Pegawai";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nama Pegawai";
            // 
            // tmrError
            // 
            this.tmrError.Interval = 1500;
            this.tmrError.Tick += new System.EventHandler(this.tmrError_Tick);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 546);
            this.panel3.TabIndex = 9;
            // 
            // gunaRadioButton1
            // 
            this.gunaRadioButton1.BaseColor = System.Drawing.SystemColors.Control;
            this.gunaRadioButton1.CheckedOffColor = System.Drawing.Color.Gray;
            this.gunaRadioButton1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaRadioButton1.FillColor = System.Drawing.Color.White;
            this.gunaRadioButton1.Location = new System.Drawing.Point(7, 267);
            this.gunaRadioButton1.Name = "gunaRadioButton1";
            this.gunaRadioButton1.Size = new System.Drawing.Size(120, 20);
            this.gunaRadioButton1.TabIndex = 25;
            this.gunaRadioButton1.Text = "Customer Service";
            this.gunaRadioButton1.CheckedChanged += new System.EventHandler(this.gunaRadioButton1_CheckedChanged);
            // 
            // gunaRadioButton2
            // 
            this.gunaRadioButton2.BaseColor = System.Drawing.SystemColors.Control;
            this.gunaRadioButton2.CheckedOffColor = System.Drawing.Color.Gray;
            this.gunaRadioButton2.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaRadioButton2.FillColor = System.Drawing.Color.White;
            this.gunaRadioButton2.Location = new System.Drawing.Point(137, 267);
            this.gunaRadioButton2.Name = "gunaRadioButton2";
            this.gunaRadioButton2.Size = new System.Drawing.Size(56, 20);
            this.gunaRadioButton2.TabIndex = 26;
            this.gunaRadioButton2.Text = "Kasir";
            this.gunaRadioButton2.CheckedChanged += new System.EventHandler(this.gunaRadioButton2_CheckedChanged);
            // 
            // frmAddEditPegawai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 548);
            this.Controls.Add(this.txtPassP);
            this.Controls.Add(this.txtUserP);
            this.Controls.Add(this.txtNoP);
            this.Controls.Add(this.txtAlamatP);
            this.Controls.Add(this.txtNamaP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditPegawai";
            this.Text = "frmAddEditPegawai";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlError.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private System.Windows.Forms.Label lbltitle;
        public System.Windows.Forms.TextBox txtNamaP;
        public System.Windows.Forms.TextBox txtAlamatP;
        public System.Windows.Forms.DateTimePicker TglP;
        public System.Windows.Forms.TextBox txtNoP;
        public System.Windows.Forms.TextBox txtUserP;
        public System.Windows.Forms.TextBox txtPassP;
        private System.Windows.Forms.Panel pnlError;
        private Guna.UI.WinForms.GunaLabel lblError;
        private System.Windows.Forms.Timer tmrError;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        public Guna.UI.WinForms.GunaRadioButton gunaRadioButton2;
        public Guna.UI.WinForms.GunaRadioButton gunaRadioButton1;
    }
}
namespace Bilet
{
    partial class Bilet_Sat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpBoxSorgula = new System.Windows.Forms.GroupBox();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.cmbxVaris = new System.Windows.Forms.ComboBox();
            this.cmbxKalkis = new System.Windows.Forms.ComboBox();
            this.dtTimeTarih = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBoxSeferListele = new System.Windows.Forms.GroupBox();
            this.DGW = new System.Windows.Forms.DataGridView();
            this.grpBoxOtobusPlan = new System.Windows.Forms.GroupBox();
            this.grpBoxSeferDurum = new System.Windows.Forms.GroupBox();
            this.groupBoxGoster = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHesap = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTarihSaat = new System.Windows.Forms.Label();
            this.btnUyelik = new System.Windows.Forms.Button();
            this.grpBoxSorgula.SuspendLayout();
            this.grpBoxSeferListele.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).BeginInit();
            this.grpBoxSeferDurum.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxSorgula
            // 
            this.grpBoxSorgula.Controls.Add(this.btnSorgula);
            this.grpBoxSorgula.Controls.Add(this.cmbxVaris);
            this.grpBoxSorgula.Controls.Add(this.cmbxKalkis);
            this.grpBoxSorgula.Controls.Add(this.dtTimeTarih);
            this.grpBoxSorgula.Controls.Add(this.label3);
            this.grpBoxSorgula.Controls.Add(this.label2);
            this.grpBoxSorgula.Controls.Add(this.label1);
            this.grpBoxSorgula.Location = new System.Drawing.Point(24, 43);
            this.grpBoxSorgula.Name = "grpBoxSorgula";
            this.grpBoxSorgula.Size = new System.Drawing.Size(794, 139);
            this.grpBoxSorgula.TabIndex = 0;
            this.grpBoxSorgula.TabStop = false;
            // 
            // btnSorgula
            // 
            this.btnSorgula.Location = new System.Drawing.Point(225, 95);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(75, 23);
            this.btnSorgula.TabIndex = 6;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = true;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // cmbxVaris
            // 
            this.cmbxVaris.FormattingEnabled = true;
            this.cmbxVaris.Location = new System.Drawing.Point(165, 67);
            this.cmbxVaris.Name = "cmbxVaris";
            this.cmbxVaris.Size = new System.Drawing.Size(200, 21);
            this.cmbxVaris.TabIndex = 5;
            // 
            // cmbxKalkis
            // 
            this.cmbxKalkis.FormattingEnabled = true;
            this.cmbxKalkis.Location = new System.Drawing.Point(165, 37);
            this.cmbxKalkis.Name = "cmbxKalkis";
            this.cmbxKalkis.Size = new System.Drawing.Size(200, 21);
            this.cmbxKalkis.TabIndex = 4;
            this.cmbxKalkis.SelectedIndexChanged += new System.EventHandler(this.cmbxKalkis_SelectedIndexChanged);
            // 
            // dtTimeTarih
            // 
            this.dtTimeTarih.Location = new System.Drawing.Point(165, 11);
            this.dtTimeTarih.Name = "dtTimeTarih";
            this.dtTimeTarih.Size = new System.Drawing.Size(200, 20);
            this.dtTimeTarih.TabIndex = 3;
            this.dtTimeTarih.ValueChanged += new System.EventHandler(this.dtTimeTarih_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Varış";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kalkış";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarih";
            // 
            // grpBoxSeferListele
            // 
            this.grpBoxSeferListele.Controls.Add(this.DGW);
            this.grpBoxSeferListele.Location = new System.Drawing.Point(24, 203);
            this.grpBoxSeferListele.Name = "grpBoxSeferListele";
            this.grpBoxSeferListele.Size = new System.Drawing.Size(794, 658);
            this.grpBoxSeferListele.TabIndex = 1;
            this.grpBoxSeferListele.TabStop = false;
            // 
            // DGW
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.DGW.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW.Location = new System.Drawing.Point(7, 23);
            this.DGW.Name = "DGW";
            this.DGW.Size = new System.Drawing.Size(780, 631);
            this.DGW.TabIndex = 0;
            this.DGW.SelectionChanged += new System.EventHandler(this.DGW_SelectionChanged);
            // 
            // grpBoxOtobusPlan
            // 
            this.grpBoxOtobusPlan.Location = new System.Drawing.Point(824, 43);
            this.grpBoxOtobusPlan.Name = "grpBoxOtobusPlan";
            this.grpBoxOtobusPlan.Size = new System.Drawing.Size(455, 819);
            this.grpBoxOtobusPlan.TabIndex = 2;
            this.grpBoxOtobusPlan.TabStop = false;
            // 
            // grpBoxSeferDurum
            // 
            this.grpBoxSeferDurum.Controls.Add(this.groupBoxGoster);
            this.grpBoxSeferDurum.Location = new System.Drawing.Point(1285, 43);
            this.grpBoxSeferDurum.Name = "grpBoxSeferDurum";
            this.grpBoxSeferDurum.Size = new System.Drawing.Size(186, 818);
            this.grpBoxSeferDurum.TabIndex = 3;
            this.grpBoxSeferDurum.TabStop = false;
            // 
            // groupBoxGoster
            // 
            this.groupBoxGoster.Location = new System.Drawing.Point(0, 73);
            this.groupBoxGoster.Name = "groupBoxGoster";
            this.groupBoxGoster.Size = new System.Drawing.Size(186, 166);
            this.groupBoxGoster.TabIndex = 0;
            this.groupBoxGoster.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHesap);
            this.panel1.Controls.Add(this.btnCikis);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblTarihSaat);
            this.panel1.Controls.Add(this.btnUyelik);
            this.panel1.Location = new System.Drawing.Point(24, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 33);
            this.panel1.TabIndex = 0;
            // 
            // btnHesap
            // 
            this.btnHesap.Location = new System.Drawing.Point(397, 4);
            this.btnHesap.Name = "btnHesap";
            this.btnHesap.Size = new System.Drawing.Size(75, 23);
            this.btnHesap.TabIndex = 10;
            this.btnHesap.Text = "Hesap";
            this.btnHesap.UseVisualStyleBackColor = true;
            this.btnHesap.Click += new System.EventHandler(this.btnHesap_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(1147, 4);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(75, 23);
            this.btnCikis.TabIndex = 4;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "OZCAN TURİZM";
            // 
            // lblTarihSaat
            // 
            this.lblTarihSaat.AutoSize = true;
            this.lblTarihSaat.Location = new System.Drawing.Point(162, 9);
            this.lblTarihSaat.Name = "lblTarihSaat";
            this.lblTarihSaat.Size = new System.Drawing.Size(49, 13);
            this.lblTarihSaat.TabIndex = 7;
            this.lblTarihSaat.Text = "00:00:00";
            // 
            // btnUyelik
            // 
            this.btnUyelik.Location = new System.Drawing.Point(228, 4);
            this.btnUyelik.Name = "btnUyelik";
            this.btnUyelik.Size = new System.Drawing.Size(162, 23);
            this.btnUyelik.TabIndex = 9;
            this.btnUyelik.Text = "Üyelik İşlemleri";
            this.btnUyelik.UseVisualStyleBackColor = true;
            this.btnUyelik.Click += new System.EventHandler(this.btnUyelik_Click);
            // 
            // Bilet_Sat
            // 
            this.AcceptButton = this.btnSorgula;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 865);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpBoxSeferDurum);
            this.Controls.Add(this.grpBoxOtobusPlan);
            this.Controls.Add(this.grpBoxSeferListele);
            this.Controls.Add(this.grpBoxSorgula);
            this.Name = "Bilet_Sat";
            this.Text = "Bilet_Sat";
            this.Load += new System.EventHandler(this.Bilet_Sat_Load);
            this.grpBoxSorgula.ResumeLayout(false);
            this.grpBoxSorgula.PerformLayout();
            this.grpBoxSeferListele.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).EndInit();
            this.grpBoxSeferDurum.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxSorgula;
        private System.Windows.Forms.ComboBox cmbxVaris;
        private System.Windows.Forms.ComboBox cmbxKalkis;
        private System.Windows.Forms.DateTimePicker dtTimeTarih;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.GroupBox grpBoxSeferListele;
        private System.Windows.Forms.GroupBox grpBoxOtobusPlan;
        private System.Windows.Forms.GroupBox grpBoxSeferDurum;
        private System.Windows.Forms.DataGridView DGW;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUyelik;
        private System.Windows.Forms.Label lblTarihSaat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.GroupBox groupBoxGoster;
        private System.Windows.Forms.Button btnHesap;
    }
}
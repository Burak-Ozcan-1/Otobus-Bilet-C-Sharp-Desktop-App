namespace Bilet
{
    partial class SeferEkle
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_Tarih1 = new System.Windows.Forms.Label();
            this.cmbxGuzergah = new System.Windows.Forms.ComboBox();
            this.mskdSure = new System.Windows.Forms.MaskedTextBox();
            this.cmbxOtobusPlaka = new System.Windows.Forms.ComboBox();
            this.cmbxSofor1 = new System.Windows.Forms.ComboBox();
            this.cmbxSofor2 = new System.Windows.Forms.ComboBox();
            this.cmbxMuavin = new System.Windows.Forms.ComboBox();
            this.txtPeronNo = new System.Windows.Forms.TextBox();
            this.btnSeferEkle = new System.Windows.Forms.Button();
            this.dtTimePickerTarih_1 = new System.Windows.Forms.DateTimePicker();
            this.lbl_Tarih2 = new System.Windows.Forms.Label();
            this.dtTimePickerTarih_2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.mskd_Ucret = new System.Windows.Forms.MaskedTextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Güzergah";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Saat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Otobüs Plaka";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Şoför 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Şoför 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Muavin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Peron No";
            // 
            // lbl_Tarih1
            // 
            this.lbl_Tarih1.AutoSize = true;
            this.lbl_Tarih1.Location = new System.Drawing.Point(59, 84);
            this.lbl_Tarih1.Name = "lbl_Tarih1";
            this.lbl_Tarih1.Size = new System.Drawing.Size(40, 13);
            this.lbl_Tarih1.TabIndex = 7;
            this.lbl_Tarih1.Text = "Tarih 1";
            // 
            // cmbxGuzergah
            // 
            this.cmbxGuzergah.FormattingEnabled = true;
            this.cmbxGuzergah.Location = new System.Drawing.Point(136, 37);
            this.cmbxGuzergah.Name = "cmbxGuzergah";
            this.cmbxGuzergah.Size = new System.Drawing.Size(121, 21);
            this.cmbxGuzergah.TabIndex = 8;
            this.cmbxGuzergah.SelectedIndexChanged += new System.EventHandler(this.cmbxGuzergah_SelectedIndexChanged);
            // 
            // mskdSure
            // 
            this.mskdSure.Location = new System.Drawing.Point(136, 148);
            this.mskdSure.Mask = "90:00";
            this.mskdSure.Name = "mskdSure";
            this.mskdSure.Size = new System.Drawing.Size(40, 20);
            this.mskdSure.TabIndex = 10;
            this.mskdSure.ValidatingType = typeof(System.DateTime);
            // 
            // cmbxOtobusPlaka
            // 
            this.cmbxOtobusPlaka.FormattingEnabled = true;
            this.cmbxOtobusPlaka.Location = new System.Drawing.Point(136, 183);
            this.cmbxOtobusPlaka.Name = "cmbxOtobusPlaka";
            this.cmbxOtobusPlaka.Size = new System.Drawing.Size(121, 21);
            this.cmbxOtobusPlaka.TabIndex = 11;
            // 
            // cmbxSofor1
            // 
            this.cmbxSofor1.FormattingEnabled = true;
            this.cmbxSofor1.Location = new System.Drawing.Point(136, 215);
            this.cmbxSofor1.Name = "cmbxSofor1";
            this.cmbxSofor1.Size = new System.Drawing.Size(121, 21);
            this.cmbxSofor1.TabIndex = 12;
            // 
            // cmbxSofor2
            // 
            this.cmbxSofor2.FormattingEnabled = true;
            this.cmbxSofor2.Location = new System.Drawing.Point(136, 254);
            this.cmbxSofor2.Name = "cmbxSofor2";
            this.cmbxSofor2.Size = new System.Drawing.Size(121, 21);
            this.cmbxSofor2.TabIndex = 13;
            // 
            // cmbxMuavin
            // 
            this.cmbxMuavin.FormattingEnabled = true;
            this.cmbxMuavin.Location = new System.Drawing.Point(136, 291);
            this.cmbxMuavin.Name = "cmbxMuavin";
            this.cmbxMuavin.Size = new System.Drawing.Size(121, 21);
            this.cmbxMuavin.TabIndex = 14;
            // 
            // txtPeronNo
            // 
            this.txtPeronNo.Location = new System.Drawing.Point(136, 331);
            this.txtPeronNo.Name = "txtPeronNo";
            this.txtPeronNo.Size = new System.Drawing.Size(121, 20);
            this.txtPeronNo.TabIndex = 15;
            // 
            // btnSeferEkle
            // 
            this.btnSeferEkle.Location = new System.Drawing.Point(146, 400);
            this.btnSeferEkle.Name = "btnSeferEkle";
            this.btnSeferEkle.Size = new System.Drawing.Size(100, 23);
            this.btnSeferEkle.TabIndex = 16;
            this.btnSeferEkle.Text = "Sefer Ekle";
            this.btnSeferEkle.UseVisualStyleBackColor = true;
            this.btnSeferEkle.Click += new System.EventHandler(this.btnSeferEkle_Click);
            // 
            // dtTimePickerTarih_1
            // 
            this.dtTimePickerTarih_1.Location = new System.Drawing.Point(136, 77);
            this.dtTimePickerTarih_1.Name = "dtTimePickerTarih_1";
            this.dtTimePickerTarih_1.Size = new System.Drawing.Size(200, 20);
            this.dtTimePickerTarih_1.TabIndex = 17;
            // 
            // lbl_Tarih2
            // 
            this.lbl_Tarih2.AutoSize = true;
            this.lbl_Tarih2.Location = new System.Drawing.Point(59, 120);
            this.lbl_Tarih2.Name = "lbl_Tarih2";
            this.lbl_Tarih2.Size = new System.Drawing.Size(40, 13);
            this.lbl_Tarih2.TabIndex = 18;
            this.lbl_Tarih2.Text = "Tarih 2";
            // 
            // dtTimePickerTarih_2
            // 
            this.dtTimePickerTarih_2.Location = new System.Drawing.Point(136, 113);
            this.dtTimePickerTarih_2.Name = "dtTimePickerTarih_2";
            this.dtTimePickerTarih_2.Size = new System.Drawing.Size(200, 20);
            this.dtTimePickerTarih_2.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 444);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(846, 148);
            this.dataGridView1.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Ücret";
            // 
            // mskd_Ucret
            // 
            this.mskd_Ucret.Location = new System.Drawing.Point(136, 363);
            this.mskd_Ucret.Mask = "000";
            this.mskd_Ucret.Name = "mskd_Ucret";
            this.mskd_Ucret.Size = new System.Drawing.Size(29, 20);
            this.mskd_Ucret.TabIndex = 24;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(864, 444);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 33);
            this.btnGuncelle.TabIndex = 25;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(864, 560);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 32);
            this.btnSil.TabIndex = 26;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // SeferEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 628);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.mskd_Ucret);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtTimePickerTarih_2);
            this.Controls.Add(this.lbl_Tarih2);
            this.Controls.Add(this.dtTimePickerTarih_1);
            this.Controls.Add(this.btnSeferEkle);
            this.Controls.Add(this.txtPeronNo);
            this.Controls.Add(this.cmbxMuavin);
            this.Controls.Add(this.cmbxSofor2);
            this.Controls.Add(this.cmbxSofor1);
            this.Controls.Add(this.cmbxOtobusPlaka);
            this.Controls.Add(this.mskdSure);
            this.Controls.Add(this.cmbxGuzergah);
            this.Controls.Add(this.lbl_Tarih1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SeferEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sefer";
            this.Load += new System.EventHandler(this.SeferEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_Tarih1;
        private System.Windows.Forms.ComboBox cmbxGuzergah;
        private System.Windows.Forms.MaskedTextBox mskdSure;
        private System.Windows.Forms.ComboBox cmbxOtobusPlaka;
        private System.Windows.Forms.ComboBox cmbxSofor1;
        private System.Windows.Forms.ComboBox cmbxSofor2;
        private System.Windows.Forms.ComboBox cmbxMuavin;
        private System.Windows.Forms.TextBox txtPeronNo;
        private System.Windows.Forms.Button btnSeferEkle;
        private System.Windows.Forms.DateTimePicker dtTimePickerTarih_1;
        private System.Windows.Forms.Label lbl_Tarih2;
        private System.Windows.Forms.DateTimePicker dtTimePickerTarih_2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mskd_Ucret;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
    }
}
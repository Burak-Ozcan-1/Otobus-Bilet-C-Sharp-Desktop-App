namespace Bilet
{
    partial class PersonelEkle
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
            this.cmbxPersonelTuru = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdi = new System.Windows.Forms.TextBox();
            this.txtSoyadi = new System.Windows.Forms.TextBox();
            this.txtTC = new System.Windows.Forms.TextBox();
            this.mskdCepTel = new System.Windows.Forms.MaskedTextBox();
            this.cmbxCinsiyet = new System.Windows.Forms.ComboBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.btnPersonelEkle = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbx_CalistigiYer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Personel Türü ";
            // 
            // cmbxPersonelTuru
            // 
            this.cmbxPersonelTuru.FormattingEnabled = true;
            this.cmbxPersonelTuru.Location = new System.Drawing.Point(141, 41);
            this.cmbxPersonelTuru.Name = "cmbxPersonelTuru";
            this.cmbxPersonelTuru.Size = new System.Drawing.Size(138, 21);
            this.cmbxPersonelTuru.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Soyadı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "TC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cep Tel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cinsiyet";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Adres";
            // 
            // txtAdi
            // 
            this.txtAdi.Location = new System.Drawing.Point(141, 105);
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.Size = new System.Drawing.Size(100, 20);
            this.txtAdi.TabIndex = 8;
            // 
            // txtSoyadi
            // 
            this.txtSoyadi.Location = new System.Drawing.Point(141, 139);
            this.txtSoyadi.Name = "txtSoyadi";
            this.txtSoyadi.Size = new System.Drawing.Size(100, 20);
            this.txtSoyadi.TabIndex = 9;
            // 
            // txtTC
            // 
            this.txtTC.Location = new System.Drawing.Point(141, 182);
            this.txtTC.MaxLength = 11;
            this.txtTC.Name = "txtTC";
            this.txtTC.Size = new System.Drawing.Size(100, 20);
            this.txtTC.TabIndex = 10;
            // 
            // mskdCepTel
            // 
            this.mskdCepTel.Location = new System.Drawing.Point(141, 221);
            this.mskdCepTel.Mask = "(999) 000-0000";
            this.mskdCepTel.Name = "mskdCepTel";
            this.mskdCepTel.Size = new System.Drawing.Size(100, 20);
            this.mskdCepTel.TabIndex = 11;
            // 
            // cmbxCinsiyet
            // 
            this.cmbxCinsiyet.FormattingEnabled = true;
            this.cmbxCinsiyet.Location = new System.Drawing.Point(141, 258);
            this.cmbxCinsiyet.Name = "cmbxCinsiyet";
            this.cmbxCinsiyet.Size = new System.Drawing.Size(100, 21);
            this.cmbxCinsiyet.TabIndex = 12;
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(141, 293);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(225, 70);
            this.txtAdres.TabIndex = 13;
            // 
            // btnPersonelEkle
            // 
            this.btnPersonelEkle.Location = new System.Drawing.Point(141, 392);
            this.btnPersonelEkle.Name = "btnPersonelEkle";
            this.btnPersonelEkle.Size = new System.Drawing.Size(124, 23);
            this.btnPersonelEkle.TabIndex = 14;
            this.btnPersonelEkle.Text = "Personel Ekle";
            this.btnPersonelEkle.UseVisualStyleBackColor = true;
            this.btnPersonelEkle.Click += new System.EventHandler(this.btnPersonelEkle_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Çalıştığı Yer";
            // 
            // cmbx_CalistigiYer
            // 
            this.cmbx_CalistigiYer.FormattingEnabled = true;
            this.cmbx_CalistigiYer.Location = new System.Drawing.Point(141, 74);
            this.cmbx_CalistigiYer.Name = "cmbx_CalistigiYer";
            this.cmbx_CalistigiYer.Size = new System.Drawing.Size(138, 21);
            this.cmbx_CalistigiYer.TabIndex = 16;
            // 
            // PersonelEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 417);
            this.Controls.Add(this.cmbx_CalistigiYer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnPersonelEkle);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.cmbxCinsiyet);
            this.Controls.Add(this.mskdCepTel);
            this.Controls.Add(this.txtTC);
            this.Controls.Add(this.txtSoyadi);
            this.Controls.Add(this.txtAdi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbxPersonelTuru);
            this.Controls.Add(this.label1);
            this.Name = "PersonelEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel";
            this.Load += new System.EventHandler(this.PersonelEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxPersonelTuru;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAdi;
        private System.Windows.Forms.TextBox txtSoyadi;
        private System.Windows.Forms.TextBox txtTC;
        private System.Windows.Forms.MaskedTextBox mskdCepTel;
        private System.Windows.Forms.ComboBox cmbxCinsiyet;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Button btnPersonelEkle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbx_CalistigiYer;
    }
}
namespace Bilet
{
    partial class IndirimEkle
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
            this.DTGW = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIndirimAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskdIndirimOrani = new System.Windows.Forms.MaskedTextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.lblIndirimSimge = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DTGW)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGW
            // 
            this.DTGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGW.Location = new System.Drawing.Point(22, 53);
            this.DTGW.Name = "DTGW";
            this.DTGW.Size = new System.Drawing.Size(345, 150);
            this.DTGW.TabIndex = 0;
            this.DTGW.SelectionChanged += new System.EventHandler(this.DTGW_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "İndirim Adı";
            // 
            // txtIndirimAdi
            // 
            this.txtIndirimAdi.Location = new System.Drawing.Point(83, 16);
            this.txtIndirimAdi.Name = "txtIndirimAdi";
            this.txtIndirimAdi.Size = new System.Drawing.Size(100, 20);
            this.txtIndirimAdi.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "İndirim Oranı";
            // 
            // mskdIndirimOrani
            // 
            this.mskdIndirimOrani.Location = new System.Drawing.Point(274, 16);
            this.mskdIndirimOrani.Mask = "00";
            this.mskdIndirimOrani.Name = "mskdIndirimOrani";
            this.mskdIndirimOrani.Size = new System.Drawing.Size(23, 20);
            this.mskdIndirimOrani.TabIndex = 4;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(373, 82);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 5;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(373, 111);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 6;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(373, 140);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnGuncelle.TabIndex = 7;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // lblIndirimSimge
            // 
            this.lblIndirimSimge.AutoSize = true;
            this.lblIndirimSimge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIndirimSimge.Location = new System.Drawing.Point(297, 18);
            this.lblIndirimSimge.Name = "lblIndirimSimge";
            this.lblIndirimSimge.Size = new System.Drawing.Size(20, 16);
            this.lblIndirimSimge.TabIndex = 8;
            this.lblIndirimSimge.Text = "%";
            // 
            // IndirimEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 226);
            this.Controls.Add(this.lblIndirimSimge);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.mskdIndirimOrani);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIndirimAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTGW);
            this.Name = "IndirimEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indirim";
            this.Load += new System.EventHandler(this.IndirimEkle_Load);
            this.Click += new System.EventHandler(this.IndirimEkle_Click);
            ((System.ComponentModel.ISupportInitialize)(this.DTGW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIndirimAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskdIndirimOrani;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label lblIndirimSimge;
    }
}
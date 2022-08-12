namespace Bilet
{
    partial class Tesisekle
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.txtTesisAdi = new System.Windows.Forms.TextBox();
            this.richTesisAdres = new System.Windows.Forms.RichTextBox();
            this.mskdTel = new System.Windows.Forms.MaskedTextBox();
            this.richAciklama = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DTGW)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGW
            // 
            this.DTGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGW.Location = new System.Drawing.Point(12, 317);
            this.DTGW.Name = "DTGW";
            this.DTGW.Size = new System.Drawing.Size(540, 114);
            this.DTGW.TabIndex = 0;
            this.DTGW.SelectionChanged += new System.EventHandler(this.DTGW_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tesis Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tesis Adresi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tesis Tel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tesis Açıklama";
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(104, 288);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 5;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(186, 288);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnGuncelle.TabIndex = 6;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(268, 288);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // txtTesisAdi
            // 
            this.txtTesisAdi.Location = new System.Drawing.Point(108, 30);
            this.txtTesisAdi.Name = "txtTesisAdi";
            this.txtTesisAdi.Size = new System.Drawing.Size(126, 20);
            this.txtTesisAdi.TabIndex = 8;
            // 
            // richTesisAdres
            // 
            this.richTesisAdres.Location = new System.Drawing.Point(108, 108);
            this.richTesisAdres.Name = "richTesisAdres";
            this.richTesisAdres.Size = new System.Drawing.Size(233, 77);
            this.richTesisAdres.TabIndex = 9;
            this.richTesisAdres.Text = "";
            // 
            // mskdTel
            // 
            this.mskdTel.Location = new System.Drawing.Point(124, 65);
            this.mskdTel.Mask = "(999) 000-0000";
            this.mskdTel.Name = "mskdTel";
            this.mskdTel.Size = new System.Drawing.Size(82, 20);
            this.mskdTel.TabIndex = 10;
            // 
            // richAciklama
            // 
            this.richAciklama.Location = new System.Drawing.Point(108, 205);
            this.richAciklama.Name = "richAciklama";
            this.richAciklama.Size = new System.Drawing.Size(233, 77);
            this.richAciklama.TabIndex = 11;
            this.richAciklama.Text = "";
            // 
            // Tesisekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 444);
            this.Controls.Add(this.richAciklama);
            this.Controls.Add(this.mskdTel);
            this.Controls.Add(this.richTesisAdres);
            this.Controls.Add(this.txtTesisAdi);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTGW);
            this.Name = "Tesisekle";
            this.Text = "Tesisekle";
            this.Load += new System.EventHandler(this.Tesisekle_Load);
            this.Click += new System.EventHandler(this.Tesisekle_Click);
            ((System.ComponentModel.ISupportInitialize)(this.DTGW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TextBox txtTesisAdi;
        private System.Windows.Forms.RichTextBox richTesisAdres;
        private System.Windows.Forms.MaskedTextBox mskdTel;
        private System.Windows.Forms.RichTextBox richAciklama;
    }
}
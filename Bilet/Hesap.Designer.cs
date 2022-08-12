namespace Bilet
{
    partial class Hesap
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
            this.cmbx_SeferTarihi = new System.Windows.Forms.ComboBox();
            this.cmbx_SeferSaati = new System.Windows.Forms.ComboBox();
            this.btnHesap = new System.Windows.Forms.Button();
            this.DGW_Hesap = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Hesap)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sefer Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sefer Saati";
            // 
            // cmbx_SeferTarihi
            // 
            this.cmbx_SeferTarihi.FormattingEnabled = true;
            this.cmbx_SeferTarihi.Location = new System.Drawing.Point(409, 42);
            this.cmbx_SeferTarihi.Name = "cmbx_SeferTarihi";
            this.cmbx_SeferTarihi.Size = new System.Drawing.Size(121, 21);
            this.cmbx_SeferTarihi.TabIndex = 2;
            this.cmbx_SeferTarihi.SelectedIndexChanged += new System.EventHandler(this.cmbx_SeferTarihi_SelectedIndexChanged);
            // 
            // cmbx_SeferSaati
            // 
            this.cmbx_SeferSaati.FormattingEnabled = true;
            this.cmbx_SeferSaati.Location = new System.Drawing.Point(409, 76);
            this.cmbx_SeferSaati.Name = "cmbx_SeferSaati";
            this.cmbx_SeferSaati.Size = new System.Drawing.Size(121, 21);
            this.cmbx_SeferSaati.TabIndex = 3;
            // 
            // btnHesap
            // 
            this.btnHesap.Location = new System.Drawing.Point(435, 118);
            this.btnHesap.Name = "btnHesap";
            this.btnHesap.Size = new System.Drawing.Size(75, 23);
            this.btnHesap.TabIndex = 4;
            this.btnHesap.Text = "Hesap";
            this.btnHesap.UseVisualStyleBackColor = true;
            this.btnHesap.Click += new System.EventHandler(this.btnHesap_Click);
            // 
            // DGW_Hesap
            // 
            this.DGW_Hesap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW_Hesap.Location = new System.Drawing.Point(12, 165);
            this.DGW_Hesap.Name = "DGW_Hesap";
            this.DGW_Hesap.Size = new System.Drawing.Size(952, 150);
            this.DGW_Hesap.TabIndex = 5;
            // 
            // Hesap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 375);
            this.Controls.Add(this.DGW_Hesap);
            this.Controls.Add(this.btnHesap);
            this.Controls.Add(this.cmbx_SeferSaati);
            this.Controls.Add(this.cmbx_SeferTarihi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Hesap";
            this.Text = "Hesap";
            this.Load += new System.EventHandler(this.Hesap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Hesap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbx_SeferTarihi;
        private System.Windows.Forms.ComboBox cmbx_SeferSaati;
        private System.Windows.Forms.Button btnHesap;
        private System.Windows.Forms.DataGridView DGW_Hesap;
    }
}
namespace Bilet
{
    partial class OtobusEkle
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
            this.txtYolcuSayısı = new System.Windows.Forms.TextBox();
            this.cmbxKoltukTip = new System.Windows.Forms.ComboBox();
            this.mskdPlaka = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbxModel = new System.Windows.Forms.ComboBox();
            this.cmbxMarka = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chckdLstOzellik = new System.Windows.Forms.CheckedListBox();
            this.btnOtobusEkle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Koltuk Tipi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Yolcu Sayısı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Plaka";
            // 
            // txtYolcuSayısı
            // 
            this.txtYolcuSayısı.Location = new System.Drawing.Point(96, 147);
            this.txtYolcuSayısı.Name = "txtYolcuSayısı";
            this.txtYolcuSayısı.Size = new System.Drawing.Size(100, 20);
            this.txtYolcuSayısı.TabIndex = 7;
            // 
            // cmbxKoltukTip
            // 
            this.cmbxKoltukTip.FormattingEnabled = true;
            this.cmbxKoltukTip.Items.AddRange(new object[] {
            "2+1",
            "2+2"});
            this.cmbxKoltukTip.Location = new System.Drawing.Point(96, 108);
            this.cmbxKoltukTip.Name = "cmbxKoltukTip";
            this.cmbxKoltukTip.Size = new System.Drawing.Size(121, 21);
            this.cmbxKoltukTip.TabIndex = 8;
            // 
            // mskdPlaka
            // 
            this.mskdPlaka.Location = new System.Drawing.Point(96, 183);
            this.mskdPlaka.Mask = "00-AAA-0000";
            this.mskdPlaka.Name = "mskdPlaka";
            this.mskdPlaka.Size = new System.Drawing.Size(75, 20);
            this.mskdPlaka.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbxModel);
            this.groupBox1.Controls.Add(this.cmbxMarka);
            this.groupBox1.Controls.Add(this.mskdPlaka);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbxKoltukTip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtYolcuSayısı);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(29, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 231);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Otobus";
            // 
            // cmbxModel
            // 
            this.cmbxModel.FormattingEnabled = true;
            this.cmbxModel.Location = new System.Drawing.Point(96, 68);
            this.cmbxModel.Name = "cmbxModel";
            this.cmbxModel.Size = new System.Drawing.Size(121, 21);
            this.cmbxModel.TabIndex = 11;
            // 
            // cmbxMarka
            // 
            this.cmbxMarka.FormattingEnabled = true;
            this.cmbxMarka.Location = new System.Drawing.Point(96, 28);
            this.cmbxMarka.Name = "cmbxMarka";
            this.cmbxMarka.Size = new System.Drawing.Size(121, 21);
            this.cmbxMarka.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chckdLstOzellik);
            this.groupBox2.Location = new System.Drawing.Point(29, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 265);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Özellik";
            // 
            // chckdLstOzellik
            // 
            this.chckdLstOzellik.CheckOnClick = true;
            this.chckdLstOzellik.FormattingEnabled = true;
            this.chckdLstOzellik.Location = new System.Drawing.Point(61, 28);
            this.chckdLstOzellik.Name = "chckdLstOzellik";
            this.chckdLstOzellik.Size = new System.Drawing.Size(120, 214);
            this.chckdLstOzellik.TabIndex = 0;
            // 
            // btnOtobusEkle
            // 
            this.btnOtobusEkle.Location = new System.Drawing.Point(61, 575);
            this.btnOtobusEkle.Name = "btnOtobusEkle";
            this.btnOtobusEkle.Size = new System.Drawing.Size(164, 23);
            this.btnOtobusEkle.TabIndex = 12;
            this.btnOtobusEkle.Text = "Otobüs Ekle";
            this.btnOtobusEkle.UseVisualStyleBackColor = true;
            this.btnOtobusEkle.Click += new System.EventHandler(this.btnOtobusEkle_Click);
            // 
            // OtobusEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 649);
            this.Controls.Add(this.btnOtobusEkle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OtobusEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Otobus";
            this.Load += new System.EventHandler(this.Otobus_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYolcuSayısı;
        private System.Windows.Forms.ComboBox cmbxKoltukTip;
        private System.Windows.Forms.MaskedTextBox mskdPlaka;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox chckdLstOzellik;
        private System.Windows.Forms.Button btnOtobusEkle;
        private System.Windows.Forms.ComboBox cmbxModel;
        private System.Windows.Forms.ComboBox cmbxMarka;
    }
}
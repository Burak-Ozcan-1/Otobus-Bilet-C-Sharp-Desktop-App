namespace Bilet
{
    partial class GuzergahEkle
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
            this.btn_GuzergahEkle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbx_varis = new System.Windows.Forms.ComboBox();
            this.cmbx_kalkis = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chckTesis = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kalkış";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Varış";
            // 
            // btn_GuzergahEkle
            // 
            this.btn_GuzergahEkle.Location = new System.Drawing.Point(111, 497);
            this.btn_GuzergahEkle.Name = "btn_GuzergahEkle";
            this.btn_GuzergahEkle.Size = new System.Drawing.Size(121, 23);
            this.btn_GuzergahEkle.TabIndex = 15;
            this.btn_GuzergahEkle.Text = "Guzergah Ekle";
            this.btn_GuzergahEkle.UseVisualStyleBackColor = true;
            this.btn_GuzergahEkle.Click += new System.EventHandler(this.btn_GuzergahEkle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbx_varis);
            this.groupBox1.Controls.Add(this.cmbx_kalkis);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(30, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 117);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Güzergah";
            // 
            // cmbx_varis
            // 
            this.cmbx_varis.FormattingEnabled = true;
            this.cmbx_varis.Location = new System.Drawing.Point(111, 65);
            this.cmbx_varis.Name = "cmbx_varis";
            this.cmbx_varis.Size = new System.Drawing.Size(141, 21);
            this.cmbx_varis.TabIndex = 9;
            // 
            // cmbx_kalkis
            // 
            this.cmbx_kalkis.FormattingEnabled = true;
            this.cmbx_kalkis.Location = new System.Drawing.Point(111, 32);
            this.cmbx_kalkis.Name = "cmbx_kalkis";
            this.cmbx_kalkis.Size = new System.Drawing.Size(141, 21);
            this.cmbx_kalkis.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chckTesis);
            this.groupBox2.Location = new System.Drawing.Point(70, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 212);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tesis";
            // 
            // chckTesis
            // 
            this.chckTesis.CheckOnClick = true;
            this.chckTesis.FormattingEnabled = true;
            this.chckTesis.Location = new System.Drawing.Point(16, 21);
            this.chckTesis.Name = "chckTesis";
            this.chckTesis.Size = new System.Drawing.Size(184, 169);
            this.chckTesis.TabIndex = 0;
            // 
            // GuzergahEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 552);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_GuzergahEkle);
            this.Name = "GuzergahEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Güzergah";
            this.Load += new System.EventHandler(this.Guzergah_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_GuzergahEkle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox chckTesis;
        private System.Windows.Forms.ComboBox cmbx_varis;
        private System.Windows.Forms.ComboBox cmbx_kalkis;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet
{
    public partial class Uyelik : Form
    {
        public Uyelik()
        {
            InitializeComponent();
        }

        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        EKLE ek = new EKLE();
        string e_posta = "";
        string mesaj = " ";
        MesajVer msj = new MesajVer();
        private void Uyelik_Load(object sender, EventArgs e)
        {
            var cinsiyet = from t in db.Kodlar.Where(p => p.ust_kod_id == 1) select new { t.kod_adi, t.kod_id };

            cmbxCinsiyet.DataSource = cinsiyet.ToList();
            cmbxCinsiyet.DisplayMember = "kod_adi";
            cmbxCinsiyet.ValueMember = "kod_id";

            cmbxCinsiyet.Text = "Cinsiyet Seçiniz.";
        }
        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            if (txtAdiSoyadi.Text.Trim() == "")
                msj.Mesaj("Adı ve Soyadı Boş Geçilemez!");

            if (txtTC.Text.Trim() == "")
                msj.Mesaj("TC Boş Geçilemez!");
            else if (txtTC.TextLength != 11)
                msj.Mesaj("TC Uzunluğu 11 Olmalı!");

            if (mskdTel.Text.Trim() == "")
                msj.Mesaj("Telefon Boş Geçilemez!");

            if (txtE_Posta.Text.Trim() == "")
                e_posta = null;
            else
                e_posta = txtE_Posta.Text;

            if (cmbxCinsiyet.Text == "Cinsiyet Seçiniz.")
                msj.Mesaj("Cinsiyet Boş Geçilemez!");
            
            else{
                mesaj = ek.UyeEkle(true, txtAdiSoyadi.Text, mskdTel.Text, Convert.ToInt64(txtTC.Text), e_posta, Convert.ToInt32(cmbxCinsiyet.SelectedValue));

                if (mesaj != "HATA!")
                    msj.Mesaj(mesaj);
                else
                    msj.Mesaj(mesaj);
            }
        } 
    }
}

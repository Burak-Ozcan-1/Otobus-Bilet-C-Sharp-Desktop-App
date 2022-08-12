using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet
{
    public partial class PersonelEkle : Form
    {
        public PersonelEkle()
        {
            InitializeComponent();
        }

        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        id_bul id = new id_bul();
        EKLE ek = new EKLE();
        MesajVer msj = new MesajVer();
        string mesaj = " ";
        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text != "" || txtSoyadi.Text != "" || txtTC.Text != "") 
            {
                int bulunan_personel_turu = Convert.ToInt32(cmbxPersonelTuru.SelectedValue);
                int bulunan_cinsiyet = Convert.ToInt32(cmbxCinsiyet.SelectedValue);
                int calisilan_yer = Convert.ToInt32(cmbx_CalistigiYer.SelectedValue);
                mesaj = ek.PersonelEkle(txtAdi.Text, txtSoyadi.Text, txtTC.Text, mskdCepTel.Text, txtAdres.Text, bulunan_cinsiyet, bulunan_personel_turu, calisilan_yer);
                if (mesaj != "HATA!")
                {
                    msj.Mesaj(mesaj);
                    this.Close();
                }
                else
                    msj.Mesaj(mesaj);
            }
            else
            {
                msj.Mesaj("HATA!");
            }
        }
        private void PersonelEkle_Load(object sender, EventArgs e)
        {
            Bul();
        }

        private void Bul()
        {
            var personel = from t in db.Kodlar.Where(p => p.ust_kod_id == 4) select new { t.kod_adi, t.kod_id };//db.Personel.Where(p=>p.gorev_kod == 7) select new { name = t., t.tesis_id };

            cmbxPersonelTuru.DataSource = personel.ToList();
            cmbxPersonelTuru.DisplayMember = "kod_adi";
            cmbxPersonelTuru.ValueMember = "kod_id";

            var cinsiyet = from t in db.Kodlar.Where(p => p.ust_kod_id == 1) select new { t.kod_adi, t.kod_id };//db.Personel.Where(p=>p.gorev_kod == 7) select new { name = t., t.tesis_id };

            cmbxCinsiyet.DataSource = cinsiyet.ToList();
            cmbxCinsiyet.DisplayMember = "kod_adi";
            cmbxCinsiyet.ValueMember = "kod_id";

            var calisilan_yer = from t in db.Kodlar.Where(p => p.ust_kod_id == 30) select new { t.kod_adi, t.kod_id };

            cmbx_CalistigiYer.DataSource = calisilan_yer.ToList();
            cmbx_CalistigiYer.DisplayMember = "kod_adi";
            cmbx_CalistigiYer.ValueMember = "kod_id";

            cmbxPersonelTuru.Text = "Personel Seçiniz!";
            cmbx_CalistigiYer.Text = "Çalıştığı Yeri Seçiniz!";
            cmbxCinsiyet.Text = "Cinsiyet Seçiniz!";

        }
    }
}

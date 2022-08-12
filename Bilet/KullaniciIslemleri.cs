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
    public partial class KullaniciIslemleri : Form
    {
        public KullaniciIslemleri()
        {
            InitializeComponent();
        }

        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        EKLE ek = new EKLE();
        SİL sl = new SİL();
        GUNCELLE gnc = new GUNCELLE();
        MesajVer msj = new MesajVer();
        id_bul id = new id_bul();
        string mesaj = " ";
        string secilen_data = " ";
        int bulunan_personel = 0;
        private void KullaniciIslemleri_Load(object sender, EventArgs e)
        {
            var adi_soyadi = from t in db.Personel.Where(t => t.gorev_kod == 7 || t.gorev_kod == 34) select new { name = t.adi + " " + t.soyadi, t.personel_id };
            cmbx_AdiSoyadi.DataSource = adi_soyadi.ToList();
            cmbx_AdiSoyadi.DisplayMember = "name";
            cmbx_AdiSoyadi.ValueMember = "personel_id";
            
            cmbx_AdiSoyadi.Text = "Lütfen Ad Ve Soyad Seçiniz!";
            DTGW_Yenile();
        }

        public void DTGW_Yenile()
        {
            var select = from e in db.Kullanici select new { Kullanıcı_Id = e.kullanici_id, Kullanıcı_Adı = e.kullanici_adi, Kullanıcı_Sifre = e.sifre };
            DGW.DataSource = select.ToList();
            DGW.Refresh();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbx_AdiSoyadi.Text != "Lütfen Ad Ve Soyad Seçiniz!" || txtKullaniciKodu.Text != "" || txtSifre.Text != "")
            {
                bulunan_personel = Convert.ToInt32(cmbx_AdiSoyadi.SelectedValue);
                mesaj = ek.KullaniciEkle(txtKullaniciKodu.Text, txtSifre.Text, bulunan_personel);
                if (mesaj != "HATA!")
                {
                    msj.Mesaj(mesaj);
                    DTGW_Yenile();
                }
                else
                    msj.Mesaj(mesaj);
            }
            else
            {
                msj.Mesaj("HATA!");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            secilen_data = DGW.CurrentRow.Cells[1].Value.ToString();
            Kullanici guncellenecek = db.Kullanici.Where(p => p.kullanici_adi == secilen_data).FirstOrDefault();
            bulunan_personel = Convert.ToInt32(cmbx_AdiSoyadi.SelectedValue);//id.personel_bul(cmbx_AdiSoyadi.SelectedItem.ToString());
            mesaj = gnc.KullaniciGuncelle(bulunan_personel, txtKullaniciKodu.Text, txtSifre.Text, guncellenecek);
            if (mesaj != "HATA!")
            {
                msj.Mesaj(mesaj);
                DTGW_Yenile();
            }
            else
                msj.Mesaj(mesaj);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            secilen_data = DGW.CurrentRow.Cells[1].Value.ToString();
            Kullanici silinecek = db.Kullanici.Where(p => p.kullanici_adi == secilen_data).FirstOrDefault();
            mesaj = sl.KullaniciSil(silinecek);
            if (mesaj != "HATA!")
            {
                msj.Mesaj(mesaj);
                DTGW_Yenile();
            }
            else
                msj.Mesaj(mesaj);
        }

        private void DGW_SelectionChanged(object sender, EventArgs e)
        {
            if (DGW.CurrentRow.Selected == true)
            {
                DTGW_BOSALT();
                secilen_data = DGW.CurrentRow.Cells[1].Value.ToString();
                var t = db.Kullanici.Where(p => p.kullanici_adi == secilen_data).ToList();
                foreach (var item in t)
                {
                    cmbx_AdiSoyadi.Text = item.Personel.adi + " " + item.Personel.soyadi;
                    txtKullaniciKodu.Text = item.kullanici_adi;
                    txtSifre.Text = item.sifre;
                }
            }
            else { }

        }

        private void KullaniciIslemleri_Click(object sender, EventArgs e)
        {
            DTGW_BOSALT();
        }
        public void DTGW_BOSALT()
        {
            cmbx_AdiSoyadi.Text = null;
            txtKullaniciKodu.Text = null;
            txtSifre.Text = null;
        }

        private void cmbx_AdiSoyadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string donen = " ";
                int mevcut = Convert.ToInt32(cmbx_AdiSoyadi.SelectedValue);
                var bulunan = db.Personel.Where(p => p.personel_id == mevcut).ToList();
                foreach (var item in bulunan)
                    donen = item.personel_id + "" + item.yer_kod + item.adi + item.soyadi;//id.IsimKodBul(Convert.ToInt32(item.yer_kod));
                txtKullaniciKodu.Text = donen;
            }   // Form Açılır Açılmaz buraya giriyordu girmesi engellendi.
            catch (Exception)
            {

            }
        }
    }
}
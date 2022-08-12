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
    public partial class Tesisekle : Form
    {
        public Tesisekle()
        {
            InitializeComponent();
        }

        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        EKLE ek = new EKLE();
        SİL sl = new SİL();
        GUNCELLE gnc = new GUNCELLE();
        MesajVer msj = new MesajVer();
        string mesaj = " ";
        int secilen_data = 0;
        private void Tesisekle_Load(object sender, EventArgs e)
        {
            DTGW_Yenile();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtTesisAdi.Text != "" || richAciklama.Text != "" ||richTesisAdres.Text != "")
            {
                mesaj = ek.TesisEkle(txtTesisAdi.Text, mskdTel.Text, richTesisAdres.Text, richAciklama.Text);
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
        private void btnSil_Click(object sender, EventArgs e)
        {
            secilen_data = Convert.ToInt32(DTGW.CurrentRow.Cells[0].Value.ToString());
            Tesis silinecek = db.Tesis.Where(p => p.tesis_id == secilen_data).FirstOrDefault();
            mesaj = sl.Tesis_Sil(silinecek);
            if (mesaj != "HATA!")
            {
                msj.Mesaj(mesaj);
                DTGW_Yenile();
            }
            else
                msj.Mesaj(mesaj);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            secilen_data = Convert.ToInt32(DTGW.CurrentRow.Cells[0].Value.ToString());
            Tesis guncellenecek = db.Tesis.Where(p => p.tesis_id == secilen_data).FirstOrDefault();
            mesaj = gnc.Tesis_Guncelle(txtTesisAdi.Text, richTesisAdres.Text, mskdTel.Text, richAciklama.Text,guncellenecek);
            if (mesaj != "HATA!")
            {
                msj.Mesaj(mesaj);
                DTGW_Yenile();
            }
            else
                msj.Mesaj(mesaj);
        }
        private void DTGW_SelectionChanged(object sender, EventArgs e)
        {
            if (DTGW.CurrentRow.Selected == true)
            {
                DTGW_BOSALT();
                secilen_data = Convert.ToInt32(DTGW.CurrentRow.Cells[0].Value.ToString());
                var t = db.Tesis.Where(p => p.tesis_id == secilen_data).ToList();
                foreach (var item in t)
                {
                    txtTesisAdi.Text = item.adi;
                    mskdTel.Text = item.tel;
                    richTesisAdres.Text = item.adresi;
                    richAciklama.Text = item.aciklama;
                }
            }
        }
        private void Tesisekle_Click(object sender, EventArgs e) // FORM CLİCK
        {
            DTGW_BOSALT();
        }

        public void DTGW_Yenile()
        {
            var sec = from t in db.Tesis select new { ID = t.tesis_id , TESİS_ADI = t.adi, TESİS_ADRESİ = t.adresi, TESİS_TELEFON = t.tel, TESİS_AÇIKLAMA = t.aciklama};
            DTGW.DataSource = sec.ToList();
            DTGW.Refresh();
        }
        public void DTGW_BOSALT()
        {
            txtTesisAdi.Text = null;
            richTesisAdres.Text = null;
            mskdTel.Text = null;
            richAciklama.Text = null;
        }
    }
}
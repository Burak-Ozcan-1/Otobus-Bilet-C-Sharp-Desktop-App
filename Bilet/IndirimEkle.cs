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
    public partial class IndirimEkle : Form
    {
        public IndirimEkle()
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
        private void IndirimEkle_Load(object sender, EventArgs e)
        {
            DTGW_Yenile();

            txtIndirimAdi.Text = "";
            mskdIndirimOrani.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtIndirimAdi.Text != "" || mskdIndirimOrani.Text != "")
            {
                mesaj = ek.IndirimEkle(txtIndirimAdi.Text, Convert.ToInt32(mskdIndirimOrani.Text));
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
            Indirim_Artis silinecek = db.Indirim_Artis.Where(p => p.indirim_artis_id == secilen_data).FirstOrDefault();
            mesaj = sl.Indirim_Sil(silinecek);
            if (mesaj != "HATA!")
            {
                msj.Mesaj(mesaj);
                DTGW_Yenile();
            }
            msj.Mesaj(mesaj);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            secilen_data = Convert.ToInt32(DTGW.CurrentRow.Cells[0].Value.ToString());
            Indirim_Artis guncellenecek = db.Indirim_Artis.Where(p => p.indirim_artis_id == secilen_data).FirstOrDefault();
            mesaj = gnc.Indirim_Guncelle(txtIndirimAdi.Text, Convert.ToDecimal(mskdIndirimOrani.Text),  guncellenecek);
            if (mesaj != "HATA!")
            {
                msj.Mesaj(mesaj);
                DTGW_Yenile();
                DTGW_BOSALT();
            }
            else
                msj.Mesaj(mesaj);
        }

        private void DTGW_SelectionChanged(object sender, EventArgs e)
        {
            int secilen_data = Convert.ToInt32(DTGW.CurrentRow.Cells[0].Value.ToString());
            var t = db.Indirim_Artis.Where(p => p.indirim_artis_id == secilen_data).ToList();
            foreach (var item in t)
            {
                txtIndirimAdi.Text =    item.indirim_artis_adi;
                mskdIndirimOrani.Text = Convert.ToInt32(item.indirim_artis_orani).ToString();
            }
        }

        private void IndirimEkle_Click(object sender, EventArgs e)
        {
            DTGW_BOSALT(); 
        }

        public void DTGW_BOSALT()
        {
            txtIndirimAdi.Text = null;
            mskdIndirimOrani.Text = null;
        }
        public void DTGW_Yenile()
        {
            var select = from e in db.Indirim_Artis select new { İNDİRİM_İD = e.indirim_artis_id, İNDİRİM_ADI = e.indirim_artis_adi, İNDİRİM_ORANI = e.indirim_artis_orani };
            DTGW.DataSource = select.ToList();
            DTGW.Refresh();
        }

    }
}

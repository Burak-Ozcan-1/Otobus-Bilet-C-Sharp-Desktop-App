using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet
{
    public partial class AraYolEkle : Form
    {
        public AraYolEkle()
        {
            InitializeComponent();
        }
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        EKLE ek = new EKLE();
        SİL sl = new SİL();
        GUNCELLE gnc = new GUNCELLE();
        MesajVer msj = new MesajVer();
        string mesaj = " ";
        string secilen_data = " ";
        //int sefer_id = 0;
        Dictionary<string, int> dict = new Dictionary<string, int>();

        List<int> guzergaho = new List<int>();
        private void AraYolEkle_Load(object sender, EventArgs e)
        {
            var gzr = db.Guzergah.Select(a => new { name = a.kalkis_yeri + " " + a.varis_yeri, a.guzergah_id }).ToList();

            cmbx_Guzergah.DataSource = gzr.ToList();
            cmbx_Guzergah.DisplayMember = "name";
            cmbx_Guzergah.ValueMember = "guzergah_id";

            var il = from t in db.iller select new { t.sehir, t.id };

            cmbx_AraYol.DataSource = il.ToList();
            cmbx_AraYol.DisplayMember = "sehir";
            cmbx_AraYol.ValueMember = "id";

            var ilce = from t in db.ilceler select new { t.ilce, t.sehir };

            cmbx_AraYol.DataSource = il.ToList();
            cmbx_AraYol.DisplayMember = "ilce";
            cmbx_AraYol.ValueMember = "sehir";
            cmbx_AraYol.Text = "";
        }

        private void btnAraYolEkle_Click(object sender, EventArgs e)
        {
            if (cmbx_AraYol.Text != "" || txtAraYolUcret.Text != "")
            {
                var ı = cmbx_Guzergah.SelectedValue;
                var u = cmbx_sefer.SelectedValue;
                var y = cmbx_AraYol.SelectedValue;


                mesaj = ek.AraYolEkle(cmbx_AraYol.SelectedValue.ToString(), Convert.ToDecimal(txtAraYolUcret.Text), Convert.ToInt32(txtKontenjan.Text), Convert.ToInt32(cmbx_Guzergah.SelectedValue), Convert.ToInt32(cmbx_sefer.SelectedValue));
                if (mesaj != "HATA!")
                {
                    msj.Mesaj(mesaj);
                    DTGW_Yenile();
                }
                else
                {
                    msj.Mesaj(mesaj);
                    DTGW_Yenile();
                }
            }
            else
            {
                msj.Mesaj("HATA!");
            }
        }

        private void AraYolSil_Click(object sender, EventArgs e)
        {
            secilen_data = DGW.CurrentRow.Cells[0].Value.ToString();
            Guzergah_Arayol silinecek = db.Guzergah_Arayol.Where(p => p.arayol == secilen_data).FirstOrDefault();
            mesaj = sl.AraYolSil(silinecek);
            if (mesaj != "HATA!")
            {
                msj.Mesaj(mesaj);
                DTGW_Yenile();
            }
            else
                msj.Mesaj(mesaj);
        }

        private void btnAraYolGuncelle_Click(object sender, EventArgs e)
        {
            secilen_data = DGW.CurrentRow.Cells[0].Value.ToString();
            Guzergah_Arayol guncellenecek = db.Guzergah_Arayol.Where(p => p.arayol == secilen_data).FirstOrDefault();
            mesaj = gnc.AraYolGuncelle(Convert.ToString(cmbx_AraYol.SelectedItem), Convert.ToDecimal(txtAraYolUcret.Text), Convert.ToInt32(txtKontenjan.Text), guncellenecek);
            if (mesaj != "HATA!")
            {
                msj.Mesaj(mesaj);
                DTGW_Yenile();
            }
            else
                msj.Mesaj(mesaj);
        }

        public void DTGW_Yenile()
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(cmbx_Guzergah.SelectedValue.ToString());
                var sec = from t in db.Sefer_Arayol where (t.Guzergah_Arayol.guzergah_id == id) select new { Guzergah = t.Guzergah_Arayol.Guzergah.kalkis_yeri + " " + t.Guzergah_Arayol.Guzergah.varis_yeri, Sefer = t.Sefer.kalkis_tarihi + " " + t.Sefer.kalkis_saat, Arayol = t.Guzergah_Arayol.arayol, Ücret = t.Guzergah_Arayol.ucret, Kontenjan = t.Guzergah_Arayol.kontenjan };
                DGW.DataSource = sec.ToList();
                DGW.Refresh();
            }
            catch (Exception)
            {
                var sec = from t in db.Sefer_Arayol select new { Guzergah = t.Guzergah_Arayol.Guzergah.kalkis_yeri + " " + t.Guzergah_Arayol.Guzergah.varis_yeri, Sefer = t.Sefer.kalkis_tarihi + " " + t.Sefer.kalkis_saat, Arayol = t.Guzergah_Arayol.arayol, Ücret = t.Guzergah_Arayol.ucret, Kontenjan = t.Guzergah_Arayol.kontenjan };
                DGW.DataSource = sec.ToList();
                DGW.Refresh();
            }
        }


        private void DGW_SelectionChanged(object sender, EventArgs e)
        {
            secilen_data = DGW.CurrentRow.Cells[0].Value.ToString();
            var t = db.Guzergah_Arayol.Where(p => p.arayol == secilen_data).ToList();
            foreach (var item in t)
            {
                cmbx_AraYol.Text = item.arayol;
                txtAraYolUcret.Text = Convert.ToDecimal(item.ucret).ToString();
                txtKontenjan.Text = Convert.ToInt32(item.kontenjan).ToString();
            }

        }

        private void cmbx_Guzergah_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTGW_Yenile();
            try
            {
                int g = Convert.ToInt32(cmbx_Guzergah.SelectedValue);
                var sefer = from t in db.Sefer.Where(p => p.guzergah_id == g) select new { kalkis = t.kalkis_tarihi + " " + t.kalkis_saat, t.sefer_id };

                cmbx_sefer.DataSource = sefer.ToList();
                cmbx_sefer.DisplayMember = "kalkis";
                cmbx_sefer.ValueMember = "sefer_id";
            }
            catch (Exception)
            {
            }
        }
        private void AraYolEkle_Click(object sender, EventArgs e)
        {
            DTGW_BOSALT();
            DTGW_Yenile();
        }

        public void DTGW_BOSALT()
        {
            cmbx_AraYol.Text = null;
            txtAraYolUcret.Text = null;
            txtKontenjan.Text = null;
            cmbx_Guzergah.Text = null;
            cmbx_sefer.Text = null;
        }
    }
}
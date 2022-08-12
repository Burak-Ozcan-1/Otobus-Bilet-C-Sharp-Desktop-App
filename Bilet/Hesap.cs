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
    public partial class Hesap : Form
    {
        public Hesap()
        {
            InitializeComponent();
        }
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        DateTime sefer_tarihi;
        string sefer_saat = " ";
        MesajVer msj = new MesajVer();
        private void Hesap_Load(object sender, EventArgs e)
        {
            var sfr = db.Sefer.ToList();
            foreach (var item in sfr)
                cmbx_SeferTarihi.Items.Add(item.kalkis_tarihi);

        }
        private void cmbx_SeferTarihi_SelectedIndexChanged(object sender, EventArgs e)
        {
            sefer_tarihi = Convert.ToDateTime(cmbx_SeferTarihi.SelectedItem);
            var sfr = db.Sefer.Where(p => p.kalkis_tarihi == sefer_tarihi).ToList();
            foreach (var item in sfr)
                cmbx_SeferSaati.Items.Add(item.kalkis_saat);
            
        }

        private void btnHesap_Click(object sender, EventArgs e)
        {
            if (cmbx_SeferTarihi.SelectedItem == null || cmbx_SeferSaati.SelectedItem == null)
                msj.Mesaj("Sefer Tarihi Ve Sefer Saati Boş Geçilemez!");
            else
                DGW_HesapDoldur();
        }
        private void DGW_HesapDoldur()
        {
            DataGridViewColumn b_normal = new DataGridViewTextBoxColumn();
            b_normal.HeaderText = "Normal Bilet Adet";
            b_normal.Width = 120;

            DataGridViewColumn b_rezerve = new DataGridViewTextBoxColumn();
            b_rezerve.HeaderText = "Rezerve Bilet Adet";
            b_rezerve.Width = 120;

            DataGridViewColumn b_iptal = new DataGridViewTextBoxColumn();
            b_iptal.HeaderText = "İptal Bilet Adet";
            b_iptal.Width = 120;

            DataGridViewColumn b_online = new DataGridViewTextBoxColumn();
            b_online.HeaderText = "Online Bilet Adet";
            b_online.Width = 120;

            DataGridViewColumn b_normal_tutar = new DataGridViewTextBoxColumn();
            b_normal_tutar.HeaderText = "Bilet Normal Tutar";
            b_normal_tutar.Width = 120;

            DataGridViewColumn b_rezerve_tutar = new DataGridViewTextBoxColumn();
            b_rezerve_tutar.HeaderText = "Bilet Rezerve Tutar";
            b_rezerve_tutar.Width = 125;

            DataGridViewColumn b_iptal_tutar = new DataGridViewTextBoxColumn();
            b_iptal_tutar.HeaderText = "Bilet İptal Tutar";
            b_iptal_tutar.Width = 120;

            DataGridViewColumn b_online_tutar = new DataGridViewTextBoxColumn();
            b_online_tutar.HeaderText = "Bilet Online Tutar";
            b_online_tutar.Width = 120;

            DGW_Hesap.Columns.Add(b_normal);
            DGW_Hesap.Columns.Add(b_rezerve);
            DGW_Hesap.Columns.Add(b_iptal);
            DGW_Hesap.Columns.Add(b_online);
            DGW_Hesap.Columns.Add(b_normal_tutar);
            DGW_Hesap.Columns.Add(b_rezerve_tutar);
            DGW_Hesap.Columns.Add(b_iptal_tutar);
            DGW_Hesap.Columns.Add(b_online_tutar);

            sefer_saat = cmbx_SeferSaati.SelectedItem.ToString();

            var hesap_ver_normal = (from sfr in db.Sefer
                                     where sfr.kalkis_tarihi == sefer_tarihi
                                     where sfr.kalkis_saat == sefer_saat
                                     join blt in db.Bilet on sfr.sefer_id equals blt.sefer_id
                                     where blt.iptal == 0
                                     where blt.rezerve == 0
                                     where blt.online == 0
                                     select new
                                     { sfr, blt }).Distinct().ToList();

            var hesap_ver_rezerve = (from sfr in db.Sefer
                                    where sfr.kalkis_tarihi == sefer_tarihi
                                    where sfr.kalkis_saat == sefer_saat
                                    join blt in db.Bilet on sfr.sefer_id equals blt.sefer_id
                                    where blt.iptal == 0
                                    where blt.rezerve == 1
                                    where blt.online == 0
                                    select new
                                    { sfr, blt }).Distinct().ToList();

            var hesap_ver_iptal = (from sfr in db.Sefer
                                    where sfr.kalkis_tarihi == sefer_tarihi
                                    where sfr.kalkis_saat == sefer_saat
                                    join blt in db.Bilet on sfr.sefer_id equals blt.sefer_id
                                    where blt.iptal == 1
                                    where blt.rezerve == 0
                                    where blt.online == 0
                                    select new
                                    { sfr, blt }).Distinct().ToList();

            var hesap_ver_online = (from sfr in db.Sefer
                                     where sfr.kalkis_tarihi == sefer_tarihi
                                     where sfr.kalkis_saat == sefer_saat
                                     join blt in db.Bilet on sfr.sefer_id equals blt.sefer_id
                                     where blt.iptal == 0
                                     where blt.rezerve == 0
                                     where blt.online == 1
                                     select new
                                     { sfr, blt }).Distinct().ToList();


            DataGridViewRow row = (DataGridViewRow)DGW_Hesap.Rows[0].Clone();

            row.Cells[0].Value = hesap_ver_normal.Count();
            row.Cells[1].Value = hesap_ver_rezerve.Count();
            row.Cells[2].Value = hesap_ver_iptal.Count();
            row.Cells[3].Value = hesap_ver_online.Count();

            List<decimal> toplam_normal_ucret = new List<decimal>();
            List<decimal> toplam_rezerve_ucret = new List<decimal>();
            List<decimal> toplam_iptal_ucret = new List<decimal>();
            List<decimal> toplam_online_ucret = new List<decimal>();

            foreach (var item in hesap_ver_normal)
               toplam_normal_ucret.Add(Convert.ToDecimal(item.blt.tutar));

            foreach (var item in hesap_ver_rezerve)
                toplam_rezerve_ucret.Add(Convert.ToDecimal(item.blt.tutar));

            foreach (var item in hesap_ver_iptal)
                toplam_iptal_ucret.Add(Convert.ToDecimal(item.blt.tutar));

            foreach (var item in hesap_ver_online)
                toplam_online_ucret.Add(Convert.ToDecimal(item.blt.tutar));


            row.Cells[4].Value = toplam_normal_ucret.Sum();
            row.Cells[5].Value = toplam_rezerve_ucret.Sum();
            row.Cells[6].Value = toplam_iptal_ucret.Sum();
            row.Cells[7].Value = toplam_online_ucret.Sum();
            
            DGW_Hesap.Rows.Add(row);

        }
        
    }
}

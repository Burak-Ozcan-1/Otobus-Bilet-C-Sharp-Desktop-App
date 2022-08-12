using System;
using System.Collections;
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
    public partial class SeferEkle : Form
    {
        public SeferEkle()
        {
            InitializeComponent();
        }
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        EKLE ek = new EKLE();
        SİL sl = new SİL();
        GUNCELLE gnc = new GUNCELLE();
        id_bul id = new id_bul();
        MesajVer mesaj = new MesajVer();
        string msj = " ";
        private void SeferEkle_Load(object sender, EventArgs e)
        {
            var guzergah = from t in db.Guzergah select new { name = t.kalkis_yeri + " " + t.varis_yeri, t.guzergah_id };

            cmbxGuzergah.DataSource = guzergah.ToList();
            cmbxGuzergah.DisplayMember = "name";
            cmbxGuzergah.ValueMember = "guzergah_id";

            var otobus_plaka_bul = from t in db.Otobus select new { t.plaka, t.otobus_id };

            cmbxOtobusPlaka.DataSource = otobus_plaka_bul.ToList();
            cmbxOtobusPlaka.DisplayMember = "plaka";
            cmbxOtobusPlaka.ValueMember = "otobus_id";

            var sofor = from t in db.Personel.Where(p => p.gorev_kod == 5) select new { name = t.adi + " " + t.soyadi, t.personel_id };
            var muavin = from t in db.Personel.Where(p => p.gorev_kod == 6) select new { name = t.adi + " " + t.soyadi, t.personel_id };

            cmbxSofor1.DataSource = sofor.ToList();
            cmbxSofor1.DisplayMember = "name";
            cmbxSofor1.ValueMember = "personel_id";

            cmbxSofor2.DataSource = sofor.ToList();
            cmbxSofor2.DisplayMember = "name";
            cmbxSofor2.ValueMember = "personel_id";

            cmbxMuavin.DataSource = muavin.ToList();
            cmbxMuavin.DisplayMember = "name";
            cmbxMuavin.ValueMember = "personel_id";

            cmbxGuzergah.Text = "Güzergah Seçiniz";
            cmbxOtobusPlaka.Text = "Otobüs Seçiniz";

            cmbxSofor1.Text = "Şoför 1 Seçiniz";
            cmbxSofor2.Text = "Şoför 2 Seçiniz";
            cmbxMuavin.Text = "Muavin Seçiniz";

            DGW_DOLDUR();
        }

        #region Tek Tarih Ve İki Tarih Arası Gün Bulma
        public List<DateTime> iki_tarih_arasi_gun()
        {
            DateTime d1 = new DateTime(2011, 11, 2);
            DateTime StartDate = Convert.ToDateTime(dtTimePickerTarih_1.Text);
            DateTime EndDate = Convert.ToDateTime(dtTimePickerTarih_2.Text);
            int DayInterval = 1;
            List<DateTime> dateList = new List<DateTime>();
            if (dtTimePickerTarih_1.Text != dtTimePickerTarih_2.Text)
            {
                while (StartDate.AddDays(DayInterval) <= EndDate)
                {
                    StartDate = Convert.ToDateTime(StartDate.AddDays(DayInterval).ToShortDateString());
                    dateList.Add(StartDate);
                }
                return dateList;
            }

            // TEK TARİHLİ SEFER EKLEMEK İÇİN //
            else if (dtTimePickerTarih_1.Text == dtTimePickerTarih_2.Text)
            {
                dateList.Add(StartDate);
                return dateList;
            }
            return dateList;
        }
        #endregion
        private void cmbxGuzergah_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cb != null)
            //{ }
            //    if (Convert.ToInt32(selectedIndex) >= 0)
            //{
            //    DGW_DOLDUR();
            //}
        }
        
        
        public void DTGW_Yenile()
        {
            dataGridView1.Refresh();
        }

        public void DGW_DOLDUR()
        {
            List<Personel> sofor1_bul = new List<Personel>();
            List<Personel> sofor2_bul = new List<Personel>();
            List<Personel> muavin_sorgu = new List<Personel>();
            List<Otobus> otobus_sorgu = new List<Otobus>();
            
            DataGridViewColumn kt = new DataGridViewTextBoxColumn();
            kt.HeaderText = "Kalkış Tarihi";
            DataGridViewTextBoxColumn st = new DataGridViewTextBoxColumn();
            st.HeaderText = "Saat";
            DataGridViewTextBoxColumn ucrt = new DataGridViewTextBoxColumn();
            ucrt.HeaderText = "Ücret";

            DataGridViewComboBoxColumn op = new DataGridViewComboBoxColumn();
            op.HeaderText = "Otobüs Plaka";
            op.DataSource = db.Otobus.ToList();
            op.DisplayMember = "plaka";
            op.ValueMember = "otobus_id";

            DataGridViewComboBoxColumn sfr1 = new DataGridViewComboBoxColumn();
            var b = from t in db.Personel where(t.gorev_kod == 5) select new { adisoyadi = t.adi + " " + t.soyadi, id = t.personel_id };
            sfr1.HeaderText = "Şoför 1";
            sfr1.DataSource = b.ToList();
            sfr1.ValueMember = "id";
            sfr1.DisplayMember = "adisoyadi";

            DataGridViewComboBoxColumn sfr2 = new DataGridViewComboBoxColumn();
            sfr2.HeaderText = "Şoför 2";
            sfr2.DataSource = b.ToList();
            sfr2.ValueMember = "id";
            sfr2.DisplayMember = "adisoyadi";

            DataGridViewComboBoxColumn mnv = new DataGridViewComboBoxColumn();
            var f = from ı in db.Personel where (ı.gorev_kod == 6) select new { adisoyadi = ı.adi + " " + ı.soyadi, id = ı.personel_id };
            mnv.HeaderText = "Muavin";
            mnv.DataSource = f.ToList();
            mnv.ValueMember = "id";
            mnv.DisplayMember = "adisoyadi";
            
            DataGridViewTextBoxColumn pern = new DataGridViewTextBoxColumn();
            pern.HeaderText = "Peron";

            dataGridView1.Columns.Add(kt);
            dataGridView1.Columns.Add(st);
            dataGridView1.Columns.Add(ucrt);
            dataGridView1.Columns.Add(op);
            dataGridView1.Columns.Add(sfr1);
            dataGridView1.Columns.Add(sfr2);
            dataGridView1.Columns.Add(mnv);
            dataGridView1.Columns.Add(pern);

            // SON //

            int sefer = Convert.ToInt32(cmbxGuzergah.SelectedValue);
            var liste = db.Sefer.Where(p => p.guzergah_id == sefer).ToList();
            
            //personel 
            //otobus 
            //sefer

            /*
            var sefer_listele = (from s in db.Sefer
                                 join o in db.Otobus on s.otobus_id equals o.otobus_id
                                 join otbs_detaylar in db.Otobus_Detay on o.otobus_id equals otbs_detaylar.otobus_id
                                 //from per in db.Personel
                                 //where otbs_detaylar.tarih == s.kalkis_tarihi && otbs_detaylar.saat == s.kalkis_saat
                                 select new
                                 { s, o, otbs_detaylar}).Distinct().ToList();
            
            */
            foreach (var ItemSefer in liste)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                // ROWS

                row.Cells[0].Value = Convert.ToDateTime(ItemSefer.kalkis_tarihi).ToShortDateString();
                row.Cells[1].Value = ItemSefer.kalkis_saat.ToString();
                row.Cells[2].Value = ItemSefer.ucret.ToString();
                row.Cells[3].Value = ItemSefer.otobus_id;

                var per = db.Personel.ToList();
                var otbs_detay = db.Otobus_Detay.Where(p => p.otobus_id == ItemSefer.otobus_id).ToList();
                foreach (var item_detay in otbs_detay)
                {
                    foreach (var item_per in per)
                    {
                        if (item_per.personel_id == item_detay.sofor_1_personel_id)
                        {
                            row.Cells[4].Value = item_per.personel_id;
                        }
                        if (item_per.personel_id == item_detay.sofor_2_personel_id)
                        {
                            row.Cells[5].Value = item_per.personel_id;
                        }
                        if (item_per.personel_id == item_detay.muavin_id)
                        {
                            row.Cells[6].Value = item_per.personel_id;
                        }
                    }
                }
                dataGridView1.AllowUserToAddRows = false;
                row.Cells[7].Value = ItemSefer.peron_no;
                dataGridView1.Rows.Add(row);
            }
         
         }

        private void btnSeferEkle_Click(object sender, EventArgs e)
        {
            try
            {
                List<DateTime> tarih = new List<DateTime>();
                int sofor2_id = Convert.ToInt32(cmbxSofor2.SelectedValue);
                if (sofor2_id != 0)
                    sofor2_id = Convert.ToInt32(cmbxSofor2.SelectedValue);
                tarih = iki_tarih_arasi_gun().ToList();

                msj = ek.SeferEkle(tarih, mskdSure.Text, txtPeronNo.Text, Convert.ToDecimal(mskd_Ucret.Text), Convert.ToInt32(cmbxGuzergah.SelectedValue.ToString()), Convert.ToInt32(cmbxOtobusPlaka.SelectedValue.ToString()), 5, Convert.ToInt32(cmbxMuavin.SelectedValue.ToString()), Convert.ToInt32(cmbxSofor1.SelectedValue.ToString()), sofor2_id, 4);
                if (msj != "HATA!")
                {
                    mesaj.Mesaj(msj);
                    DTGW_Yenile();
                }
                else
                {
                    mesaj.Mesaj(msj);
                    DTGW_Yenile();
                }
            }
            catch (Exception)
            {
                mesaj.Mesaj("BOŞ ALANLARI DOLDURUNUZ");
            }
            
        }
        DateTime kalkis_tarihi;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string saat = " ";
            decimal ucret = 0;
            int sofor1 = 0;
            int sofor2 = 0;
            int muavin = 0;
            string peron = " ";
            int otobus = 0;
            
            kalkis_tarihi = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            saat = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ucret = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            otobus = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            sofor1 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            if (dataGridView1.CurrentRow.Cells[5].Value == null)
                sofor2 = 0;
            else
                sofor2 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            muavin = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            peron = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            Sefer guncellenecek = db.Sefer.Where(p => p.kalkis_tarihi == kalkis_tarihi).FirstOrDefault();
            msj = gnc.Sefer_Guncelle(kalkis_tarihi, saat, ucret, sofor1, sofor2, muavin, otobus, peron, guncellenecek);
            if (msj != "HATA!")
            {
                mesaj.Mesaj(msj);
                DTGW_Yenile();
            }
            else
                mesaj.Mesaj(msj);
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            kalkis_tarihi = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Sefer silinecek = db.Sefer.Where(p => p.kalkis_tarihi == kalkis_tarihi).FirstOrDefault();
            Otobus_Detay silinecekDetay = db.Otobus_Detay.Where(p => p.tarih == kalkis_tarihi).FirstOrDefault();
            msj = sl.Sefer_Sil(silinecek, silinecekDetay);
            if (msj != "HATA!")
            {
                mesaj.Mesaj(msj);
                DTGW_Yenile();
            }
            else
                mesaj.Mesaj(msj);
        }

        private void dgv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[4].Value = 0;//give combobox index value here
        }
    }
}
using Bilet.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word; // yeni
using System.Reflection;


namespace Bilet
{
    public partial class Bilet_Sat : Form
    {
        public Bilet_Sat()
        {
            InitializeComponent();

            DGW.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGW.MultiSelect = false;
            DGW.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgw_RowPrePaint);
        }
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();

        public static int KactaneSecili = 0;
        public static string sefer_tarih = " ";
        public static string sefer_saat = " ";
        public static string Kalkis = " ";
        public static string Varis = " ";
        public static string Parametre = " ";
        public static decimal para;
        public static List<string> hangisisecili = new List<string>();
        public string[] yerlerim = new string[60];
        int sefer_id = 0;
        public static string cmbx_kalkis = " ";
        public static string cmbx_varis = " ";
        DateTime secilen_tarih;
        public static string rezervasyon_koltuk = " ";
        public static string nerden = " ";
        id_bul id = new id_bul();
        FormAc frm = new FormAc();
        MesajVer msj = new MesajVer();
        Timer t = new Timer();
        string peron_no = " ";
        int koltukIndex = 0;
        GUNCELLE gnc = new GUNCELLE();
        public static string bilet_duzeltme;
        private void dgw_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus; // DGW tüm Satır Seçilsin Dİye.
        }
        private void Bilet_Sat_Load(object sender, EventArgs e)
        {
            // Digital Saat //
            t.Interval = 100;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
            // SON //
            //string deger=" ";
            var gz = (from g in db.Guzergah join gzara in db.Guzergah_Arayol on g.guzergah_id equals gzara.guzergah_id select new { g, gzara }).ToList();
            foreach (var item in gz.ToList())
            {   
                int index = cmbxKalkis.FindString(item.g.kalkis_yeri);
                int indeXx = cmbxKalkis.FindStringExact(item.gzara.arayol);
                if (index != -1 || indeXx != -1) { } // Var İse Ekleme
                else
                {
                    cmbxKalkis.Items.Add(item.g.kalkis_yeri);
                    cmbxKalkis.Items.Add(item.gzara.arayol);
                }
            }
            grpBoxSefer();
        }

        private void cmbxKalkis_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbxVaris.Items.Clear();
            try
            {
                var gz = db.Guzergah.Where(p => p.kalkis_yeri == cmbxKalkis.SelectedItem.ToString()).ToList();
                var gz_ara = db.Guzergah_Arayol.Where(p => p.arayol == cmbxKalkis.SelectedItem.ToString()).ToList();
                if (gz.Count() != 0)
                {
                    foreach (var item in gz)
                    {
                        cmbxVaris.Items.Add(item.varis_yeri);
                        var bul = db.Guzergah_Arayol.Where(p => p.guzergah_id == item.guzergah_id);
                        foreach (var itemler in bul)
                        {
                            cmbxVaris.Items.Add(itemler.arayol);
                        }
                    }
                }
                else if (gz_ara.Count() != 0)
                {
                    foreach (var item in gz_ara)
                        cmbxVaris.Items.Add(item.Guzergah.varis_yeri);
                }

            }
            catch (Exception)
            {

            }
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (cmbxKalkis.Text == "" && cmbxVaris.Text == "")
                msj.Mesaj(" Kalkış Yeri Ve Varış Yeri Boş Geçilemez! ");
            else
            {
                dgw_doldur();
                grpBoxOtobusPlan.Controls.Clear();
            }
        }
        int secili = 0;
        public void grpBoxSefer()
        {
            //Durum
            //Hesap
            //Servis

            Label lb = new Label(); //Ad Soyad (Ünvanı) Bağlantı Yeri
            lb.Text = login.personel;//"Burak Özcan Ankara"; // Giriş Yapan Kullanıcı Ve Eklenilen Çalışılan Yer.
            lb.Width = 150;
            lb.Font = new Font("Arial", 10, FontStyle.Bold);
            lb.ForeColor = Color.Red;
            lb.Location = new Point(15, 10);
            MenuStrip mn = new MenuStrip();
            mn.Items.Add("Durum", null, new EventHandler(drmclick));
            mn.Items.Add("Hesap", null, new EventHandler(hspclick));
            //mn.Items.Add("Servis",null,new EventHandler(srvclick));
            mn.Dock = DockStyle.None;
            mn.Location = new Point(25, 32);
            grpBoxSeferDurum.Controls.Add(lb);
            grpBoxSeferDurum.Controls.Add(mn);
        }

        public void drmclick(object sender, EventArgs e)
        {
            // Kaçtane Rezervasyon Var Kaç normal bilet satılmış...
            //MessageBox.Show("Durum");

            groupBoxGoster.Controls.Clear();

            int normal = 0;
            int rezerve = 0;
            int online = 0;
            int iptal = 0;

            if (sefer_id == 0)
                msj.Mesaj("Lütfen Önce Sefer Seçiniz!");
            else
            {
                normal = db.Bilet.Where(p => p.sefer_id == sefer_id && p.rezerve == 0 && p.online == 0 && p.iptal == 0).Count(); // Normal Biletler.

                rezerve = db.Bilet.Where(p => p.sefer_id == sefer_id && p.rezerve == 1 && p.iptal == 0).Count(); // Gerçekleştirilmiş Rezervasyon.

                online = db.Bilet.Where(p => p.sefer_id == sefer_id && p.rezerve == 0 && p.online == 1 && p.iptal == 0).Count(); // İnternetten Alınan Biletler.

                iptal = db.Bilet.Where(p => p.sefer_id == sefer_id && p.iptal == 1).Count(); // İptal Edilen Biletler.

                Label lb_rezerve = new Label();
                lb_rezerve.Text = "Rezervasyon Bilet Adet : " + " " + rezerve;
                lb_rezerve.Location = new Point(5, 10);
                lb_rezerve.Width = 180;

                Label lb_normal = new Label();
                lb_normal.Text = "Normal Bilet Adet : " + " " + normal;
                lb_normal.Location = new Point(5, 40);
                lb_normal.Width = 180;

                Label lb_online = new Label();
                lb_online.Text = "Online Bilet Adet : " + " " + online;
                lb_online.Location = new Point(5, 70);
                lb_online.Width = 180;

                Label lb_iptal = new Label();
                lb_iptal.Text = "İptal Edilen Bilet Adet : " + " " + iptal;
                lb_iptal.Location = new Point(5, 100);
                lb_iptal.Width = 180;

                groupBoxGoster.Controls.Add(lb_rezerve);
                groupBoxGoster.Controls.Add(lb_normal);
                groupBoxGoster.Controls.Add(lb_online);
                groupBoxGoster.Controls.Add(lb_iptal);
            }
        }

        public void hspclick(object sender, EventArgs e)
        {
            // Normal = 50 TL Satılmış ... 
            List<decimal> toplam_normal_bilet = new List<decimal>();
            List<decimal> toplam_rezerve_bilet = new List<decimal>();
            List<decimal> toplam_internet_bilet = new List<decimal>();
            List<decimal> toplam_iptal_bilet = new List<decimal>();


            groupBoxGoster.Controls.Clear();

            if (sefer_id == 0)
                msj.Mesaj("Lütfen Önce Sefer Seçiniz!");
            else
            {
                var normal = db.Bilet.Where(p => p.sefer_id == sefer_id && p.rezerve == 0 && p.online == 0 && p.iptal == 0).ToList(); // Normal Biletler.

                var rezerve = db.Bilet.Where(p => p.sefer_id == sefer_id && p.rezerve == 1 && p.iptal == 0).ToList(); // Gerçekleştirilmiş Rezervasyon.

                var online = db.Bilet.Where(p => p.sefer_id == sefer_id && p.online == 1 && p.iptal == 0).ToList(); // İnternetten Alınan Biletler.

                var iptal = db.Bilet.Where(p => p.sefer_id == sefer_id && p.iptal == 1).ToList();

                foreach (var item in normal)
                    toplam_normal_bilet.Add(Convert.ToDecimal(item.tutar));

                foreach (var item in rezerve)
                    toplam_rezerve_bilet.Add(Convert.ToDecimal(item.tutar));

                foreach (var item in online)
                    toplam_internet_bilet.Add(Convert.ToDecimal(item.tutar));

                foreach (var item in iptal)
                    toplam_iptal_bilet.Add(Convert.ToDecimal(item.tutar));

                Label lb_rezerve = new Label();
                lb_rezerve.Text = "Rezervasyon Bilet Ücret : " + " " + toplam_rezerve_bilet.Sum() + " " + "₺";
                lb_rezerve.Location = new Point(5, 10);
                lb_rezerve.Width = 180;

                Label lb_normal = new Label();
                lb_normal.Text = "Normal Bilet Ücret : " + " " + toplam_normal_bilet.Sum() + " " + "₺";
                lb_normal.Location = new Point(5, 40);
                lb_normal.Width = 180;

                Label lb_online = new Label();
                lb_online.Text = "Online Bilet Ücret : " + " " + toplam_internet_bilet.Sum() + " " + "₺";
                lb_online.Location = new Point(5, 70);
                lb_online.Width = 180;

                Label lb_iptal = new Label();
                lb_iptal.Text = "İptal Bilet Ücret : " + " " + toplam_iptal_bilet.Sum() + " " + "₺";
                lb_iptal.Location = new Point(5, 100);
                lb_iptal.Width = 180;

                groupBoxGoster.Controls.Add(lb_rezerve);
                groupBoxGoster.Controls.Add(lb_normal);
                groupBoxGoster.Controls.Add(lb_online);
                groupBoxGoster.Controls.Add(lb_iptal);
            }
        }

        private void BayBayanBiletSat_Method(object sender, EventArgs e)
        {
            MenuItem senderMenuItem = sender as MenuItem;
            Parametre = senderMenuItem.Parent.Name;
            Varis = senderMenuItem.Text;
            ucret(Varis);
            if (secili >= 1)
            { frm.BayBayanBiletSat_Ac(yerlerim); }
            else
            {
                msj.Mesaj("Lütfen Koltuk No Seçiniz");
            }
        }
        private void BayBayanBiletRezerve_Method(object sender, EventArgs e)
        {
            MenuItem senderMenuItem = sender as MenuItem;
            Parametre = senderMenuItem.Parent.Name;
            Varis = senderMenuItem.Text;
            ucret(Varis);
            if (secili >= 1) { frm.BayBayanBiletRezervasyon_Ac(yerlerim); }
            else { msj.Mesaj("Lütfen Koltuk No Seçiniz"); }
        }
        private void BiletIptalEt(object sender, EventArgs e)
        {
            var iptal_at = yerlerim.ToList();
            int secili = sefer_id;
            foreach (var item in iptal_at)
            {
                if (item != null)
                {
                    int silinecek_koltuk = Convert.ToInt32(item);
                    var silinecek = db.Bilet.Where(p => p.sefer_id == secili && p.koltuk_no == silinecek_koltuk).FirstOrDefault();
                    string mesaj = gnc.IptalGuncelle(silinecek);
                    msj.Mesaj(mesaj);
                }
            }

        }

        public void ucret(string varis)
        {
            var sefer = db.Sefer.ToList();
            foreach (var item in sefer)
            {
                if (varis == item.Guzergah.varis_yeri)
                {
                    para = Convert.ToDecimal(item.ucret);
                }
                else
                {
                    var bul = db.Guzergah_Arayol.Where(p => p.arayol == varis);
                    foreach (var item_iki in bul)
                    {
                        para = Convert.ToDecimal(item_iki.ucret);
                    }
                }
            }
        }

        private void dtTimeTarih_ValueChanged(object sender, EventArgs e)
        {
            //sefer tablosundaki kalkış tarihine göre sorgulanacak.
        }

        int iptal = 0;
        public void sag_click()
        {
            int sefer_id = 0;

            ContextMenu cn = new ContextMenu();
            var deger = db.Guzergah.Where(p => p.kalkis_yeri == cmbxKalkis.SelectedItem.ToString() &&
            p.varis_yeri == cmbxVaris.SelectedItem.ToString()).Select(a => a.guzergah_id).ToList();


            var deger_iki = db.Guzergah_Arayol.Where(p => p.arayol == cmbxVaris.SelectedItem.ToString()).ToList();
            List<Guzergah_Arayol> bul = new List<Guzergah_Arayol>();

            MenuItem addBay = new MenuItem("Bay Bilet Sat");
            MenuItem addBayan = new MenuItem("Bayan Bilet Sat");
            MenuItem addBayRezerve = new MenuItem("Bay Rezervasyon");
            MenuItem addBayanRezerve = new MenuItem("Bayan Rezervasyon");
            foreach (var item in deger)
            {
                DateTime kalkis = Convert.ToDateTime(dtTimeTarih.Text);

                var sefer = db.Sefer.Where(p => p.kalkis_tarihi == kalkis && p.guzergah_id == item).ToList();
                foreach (var item_sfr in sefer)
                {
                    sefer_id = item_sfr.sefer_id;
                }

                bul = db.Guzergah_Arayol.Where(p => p.guzergah_id == item).ToList();
                foreach (var item_iki in bul)
                {
                    int sfr_arayol = db.Sefer_Arayol.Where(p => p.sefer_id == sefer_id && p.guzergah_arayol_id == item_iki.guzergah_arayol_id).Count();

                    if (sfr_arayol != 0)
                    {
                        addBay.MenuItems.Add(new MenuItem(item_iki.arayol, new EventHandler(BayBayanBiletSat_Method)));
                        addBay.Name = "Bay Bilet Sat";
                        addBay.MenuItems.Add(new MenuItem(item_iki.Guzergah.varis_yeri, new EventHandler(BayBayanBiletSat_Method)));

                        addBayan.MenuItems.Add(new MenuItem(item_iki.arayol, new EventHandler(BayBayanBiletSat_Method)));
                        addBayan.MenuItems.Add(new MenuItem(item_iki.Guzergah.varis_yeri, new EventHandler(BayBayanBiletSat_Method)));
                        addBayan.Name = "Bayan Bilet Sat";

                        addBayRezerve.MenuItems.Add(new MenuItem(item_iki.arayol, new EventHandler(BayBayanBiletRezerve_Method)));
                        addBayRezerve.MenuItems.Add(new MenuItem(item_iki.Guzergah.varis_yeri, new EventHandler(BayBayanBiletRezerve_Method)));
                        addBayRezerve.Name = "Bay Rezervasyon";

                        addBayanRezerve.MenuItems.Add(new MenuItem(item_iki.arayol, new EventHandler(BayBayanBiletRezerve_Method)));
                        addBayanRezerve.MenuItems.Add(new MenuItem(item_iki.Guzergah.varis_yeri, new EventHandler(BayBayanBiletRezerve_Method)));
                        addBayanRezerve.Name = "Bayan Rezervasyon";
                    }
                    else
                    {
                        addBay.Name = "Bay Bilet Sat";
                        addBay.MenuItems.Add(new MenuItem(item_iki.Guzergah.varis_yeri, new EventHandler(BayBayanBiletSat_Method)));

                        addBayan.Name = "Bayan Bilet Sat";
                        addBayan.MenuItems.Add(new MenuItem(item_iki.Guzergah.varis_yeri, new EventHandler(BayBayanBiletSat_Method)));

                        addBayRezerve.Name = "Bay Rezervasyon";
                        addBayRezerve.MenuItems.Add(new MenuItem(item_iki.Guzergah.varis_yeri, new EventHandler(BayBayanBiletRezerve_Method)));

                        addBayanRezerve.Name = "Bayan Rezervasyon";
                        addBayanRezerve.MenuItems.Add(new MenuItem(item_iki.Guzergah.varis_yeri, new EventHandler(BayBayanBiletRezerve_Method)));
                    }
                }
            }
            foreach (var item_ara in deger_iki)
            {
                if (deger_iki.Count != 0)
                {
                    addBay.MenuItems.Add(new MenuItem(item_ara.arayol, new EventHandler(BayBayanBiletSat_Method)));
                    addBay.Name = "Bay Bilet Sat";

                    addBayan.MenuItems.Add(new MenuItem(item_ara.arayol, new EventHandler(BayBayanBiletSat_Method)));
                    addBayan.Name = "Bayan Bilet Sat";

                    addBayRezerve.MenuItems.Add(new MenuItem(item_ara.arayol, new EventHandler(BayBayanBiletRezerve_Method)));
                    addBayRezerve.Name = "Bay Rezervasyon";

                    addBayanRezerve.MenuItems.Add(new MenuItem(item_ara.arayol, new EventHandler(BayBayanBiletRezerve_Method)));
                    addBayanRezerve.Name = "Bayan Rezervasyon";
                }
            }
            MenuItem addBiletIptal = new MenuItem("Bilet İptal Et", new EventHandler(BiletIptalEt));

            if (iptal == 1)
                cn.MenuItems.Add(addBiletIptal);
            else
            {
                cn.MenuItems.Add(addBay);
                cn.MenuItems.Add(addBayan);
                cn.MenuItems.Add(addBayRezerve);
                cn.MenuItems.Add(addBayanRezerve);
            }
            grpBoxOtobusPlan.ContextMenu = cn;
        }
        private void tikla(object sender, EventArgs e)
        {
            CheckBox clicked = (CheckBox)sender;
            if (clicked.Checked == true)
            {
                if (clicked.Name == "DOLU")
                {
                    msj.Mesaj("DİKKAT KOLTUK DOLU YALNIZCA İPTAL İŞLEMİ YAPABİLİRSİNİZ!");
                    iptal = 1;
                    sag_click();
                    clicked.BackColor = Color.Red;
                    secili++;
                    yerlerim[koltukIndex++] = clicked.Text;
                    hangisisecili.Add(clicked.Text);
                    KactaneSecili++;
                    if (clicked.Checked == false)
                    {
                        clicked.BackColor = default(Color);
                        secili--;
                    }
                }
                else if (clicked.Name == "Rezerve")
                {
                    iptal = 0;
                    sag_click();
                    CheckBox chc = (CheckBox)sender;
                    yerlerim[koltukIndex++] = clicked.Text;
                    hangisisecili.Add(clicked.Text);
                    KactaneSecili = 1;
                    nerden = "Rezerve";
                    var rezerve = db.Rezerve.Where(p => p.Koltuk_No.ToString() == chc.Text).ToList();
                    foreach (var item in rezerve)
                    {
                        ucret(item.varis);
                        Bilet_Sat.Varis = item.varis;
                    }
                    frm.BayBayanBiletRezervasyon_Ac(yerlerim);
                }
                else if (clicked.Name == "Online")
                {
                    iptal = 0;
                    sag_click();
                    CheckBox chc = (CheckBox)sender;
                    yerlerim[koltukIndex++] = clicked.Text;
                    hangisisecili.Add(clicked.Text);
                    KactaneSecili = 1;
                    nerden = "Online";
                    var online = db.Bilet.Where(p => p.koltuk_no.ToString() == chc.Text && p.online == 1).ToList();
                    foreach (var item in online)
                    {
                        ucret(item.varis);
                        Bilet_Sat.Varis = item.varis;
                        Bilet_Sat.para = Convert.ToDecimal(item.tutar);
                    }
                    frm.BayBayanBiletSat_Ac(yerlerim);
                }
                else
                {
                    iptal = 0;
                    sag_click();
                    clicked.BackColor = Color.Red;
                    secili++;
                    yerlerim[koltukIndex++] = clicked.Text;
                    hangisisecili.Add(clicked.Text);
                    KactaneSecili++;
                }
            }
            else
            {
                if (clicked.Name == "DOLU")
                {
                    msj.Mesaj("DİKKAT KOLTUK DOLU YALNIZCA İPTAL İŞLEMİ YAPABİLİRSİNİZ!");
                    iptal = 1;
                    sag_click();
                    clicked.BackColor = Color.Red;
                    secili++;
                    yerlerim[koltukIndex++] = clicked.Text;
                    hangisisecili.Add(clicked.Text);
                    KactaneSecili++;
                    if (clicked.Checked == false)
                    {
                        clicked.BackColor = default(Color);
                        secili--;
                    }
                }
                else
                {
                    iptal = 0;
                    sag_click();
                    clicked.BackColor = default(Color);
                    secili--;
                    for (int k = 0; k < 60; k++)
                    {
                        if (yerlerim[k] == clicked.Text)
                        {
                            yerlerim[k] = "";
                            koltukIndex--;
                            break;
                        }
                    }
                    yerlerim[Convert.ToInt32(clicked.Text)] = "";
                    hangisisecili.Remove(clicked.Text);
                    KactaneSecili--;
                }
            }
        }
        public void dgw_doldur()
        {
            // SÜTUN


            DGW.Columns.Clear();

            DataGridViewColumn kt = new DataGridViewTextBoxColumn();
            kt.HeaderText = "Tarih";
            kt.Width = 60;

            DataGridViewTextBoxColumn st = new DataGridViewTextBoxColumn();
            st.HeaderText = "Saat";
            st.Width = 40;

            DataGridViewTextBoxColumn Kalkis_Yer = new DataGridViewTextBoxColumn();
            Kalkis_Yer.HeaderText = "Kalkış";
            Kalkis_Yer.Width = 60;

            DataGridViewTextBoxColumn Varis_Yer = new DataGridViewTextBoxColumn();
            Varis_Yer.HeaderText = "Varış";
            Varis_Yer.Width = 60;

            DataGridViewTextBoxColumn Otobus_Tip = new DataGridViewTextBoxColumn();
            Otobus_Tip.HeaderText = "O.Tipi";
            Otobus_Tip.Width = 75;

            DataGridViewTextBoxColumn Koltuk_Tip = new DataGridViewTextBoxColumn();
            Koltuk_Tip.HeaderText = "K.Tipi";
            Koltuk_Tip.Width = 40;

            DataGridViewImageColumn Ozellik1 = new DataGridViewImageColumn();
            DataGridViewImageColumn Ozellik2 = new DataGridViewImageColumn();
            DataGridViewImageColumn Ozellik3 = new DataGridViewImageColumn();
            DataGridViewImageColumn Ozellik4 = new DataGridViewImageColumn();


            Ozellik1.HeaderText = "Araç Özellikleri 1";
            Ozellik1.Name = "img1";
            Ozellik2.HeaderText = "Araç Özellikleri 2";
            Ozellik2.Name = "img2";
            Ozellik3.HeaderText = "Araç Özellikleri 3";
            Ozellik3.Name = "img3";
            Ozellik4.HeaderText = "Araç Özellikleri 4";
            Ozellik4.Name = "img4";


            DGW.Columns.Add(kt);
            DGW.Columns.Add(st);
            DGW.Columns.Add(Kalkis_Yer);
            DGW.Columns.Add(Varis_Yer);
            DGW.Columns.Add(Otobus_Tip);
            DGW.Columns.Add(Koltuk_Tip);
            DGW.Columns.Add(Ozellik1);
            DGW.Columns.Add(Ozellik2);
            DGW.Columns.Add(Ozellik3);
            DGW.Columns.Add(Ozellik4);

            List<int> resim = new List<int>();

            cmbx_kalkis = cmbxKalkis.SelectedItem.ToString();
            cmbx_varis = cmbxVaris.SelectedItem.ToString();
            secilen_tarih = Convert.ToDateTime(dtTimeTarih.Text);
            var sefer_listele = (from s in db.Sefer
                                 join g in db.Guzergah on s.guzergah_id equals g.guzergah_id
                                 where g.varis_yeri == cmbx_varis
                                 where g.kalkis_yeri == cmbx_kalkis
                                 where s.kalkis_tarihi == secilen_tarih
                                 join o_detay in db.Otobus on s.otobus_id equals o_detay.otobus_id
                                 select new
                                 { s, g, o_detay }).Distinct().ToList();

            var gzarayol = db.Guzergah_Arayol.Where(p => p.arayol == cmbx_varis).ToList();
            DGW.Rows.Clear();
            List<Sefer> sfr = new List<Sefer>();
            if (sefer_listele.Count() != 0)
            {
                foreach (var ItemSefer in sefer_listele) // ROWS 
                {
                    DataGridViewRow row = (DataGridViewRow)DGW.Rows[0].Clone();
                    row.Cells[0].Value = Convert.ToDateTime(ItemSefer.s.kalkis_tarihi).ToShortDateString();
                    row.Cells[1].Value = ItemSefer.s.kalkis_saat.ToString();
                    row.Cells[2].Value = ItemSefer.g.kalkis_yeri.ToString();
                    row.Cells[3].Value = ItemSefer.g.varis_yeri.ToString();
                    string donen = id.IsimKodBul(Convert.ToInt32(ItemSefer.o_detay.model_kod));
                    row.Cells[4].Value = donen + ItemSefer.o_detay.koltuk_sayisi;

                    sefer_id = ItemSefer.s.sefer_id;

                    row.Cells[5].Value = ItemSefer.o_detay.koltuk_tipi;
                    var item_ozellik = db.Otobus_Ozellik.Where(p => p.otobus_id == ItemSefer.o_detay.otobus_id).ToList();
                    foreach (var t in item_ozellik)
                        resim.Add(Convert.ToInt32(t.ozellik_kod)); // Otobüs Özelliğe Göre Özellik Kodları Eklendi.
                    foreach (var item in resim) // Eklenen Kodlar Otobüste Var İse Gözterildi.
                    {
                        if (item == 26) // "Piriz (220 V)"
                            row.Cells[6].Value = Image.FromFile("C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\priz.png");
                        if (item == 27) //Televizyon (10 İnç)
                            row.Cells[7].Value = Image.FromFile("C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\tv.png");
                        if (item == 28) //USB Giriş
                            row.Cells[8].Value = Image.FromFile("C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\usb_giris.png");
                        if (item == 29) //WC
                            row.Cells[9].Value = Image.FromFile("C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\wc.png");
                    }
                    row.Height = 40;
                    DGW.Rows.Add(row);
                    resim.Clear();
                }
            }
            
            else
            {
                foreach (var ItemSefer in gzarayol) // ROWS 
                {
                    var g = db.Guzergah.Where(p => p.guzergah_id == ItemSefer.guzergah_id).ToList();
                    sfr = db.Sefer.Where(p => p.guzergah_id == ItemSefer.guzergah_id && p.kalkis_tarihi == secilen_tarih).ToList();
                    foreach (var item_sefer in sfr)
                    {
                        DataGridViewRow row = (DataGridViewRow)DGW.Rows[0].Clone();
                        foreach (var item in g)
                        {
                            var otbs_detay = db.Otobus_Detay.Where(p => p.otobus_id == item_sefer.otobus_id).ToList();
                            foreach (var item_detay in otbs_detay)
                            {
                                row.Cells[0].Value = Convert.ToDateTime(item_sefer.kalkis_tarihi).ToShortDateString();
                                row.Cells[1].Value = item_sefer.kalkis_saat.ToString();
                                row.Cells[2].Value = item.kalkis_yeri.ToString();
                                row.Cells[3].Value = ItemSefer.arayol.ToString();
                                string donen = id.IsimKodBul(Convert.ToInt32(item_detay.Otobus.model_kod));
                                row.Cells[4].Value = donen + item_detay.Otobus.koltuk_sayisi;
                                row.Cells[5].Value = item_detay.Otobus.koltuk_tipi;
                                var item_ozellik = db.Otobus_Ozellik.Where(p => p.otobus_id == item_detay.otobus_id).ToList();
                                foreach (var t in item_ozellik)
                                    resim.Add(Convert.ToInt32(t.ozellik_kod)); // Otobüs Özelliğe Göre Özellik Kodları Eklendi.
                                foreach (var item_resim in resim) // Eklenen Kodlar Otobüste Var İse Gözterildi.
                                {
                                    if (item_resim == 26) // "Piriz (220 V)"
                                        row.Cells[6].Value = Image.FromFile("C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\priz.png");
                                    if (item_resim == 27) //Televizyon (10 İnç)
                                        row.Cells[7].Value = Image.FromFile("C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\tv.png");
                                    if (item_resim == 28) //USB Giriş
                                        row.Cells[8].Value = Image.FromFile("C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\usb_giris.png");
                                    if (item_resim == 29) //WC
                                        row.Cells[9].Value = Image.FromFile("C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\wc.png");
                                }
                            }
                        }
                        row.Height = 40;
                        DGW.Rows.Add(row);
                        resim.Clear();
                    }

                }
            }
            if (sefer_listele.Count() == 0 && sfr.Count() == 0)
            {
                msj.Mesaj("Sefer Bulunamadı");
            }


        }
        public string sayi = " ";
        private void DGW_SelectionChanged(object sender, EventArgs e)
        {
            sag_click();
            string koltuk_tipi = " ";
            string koltuk_sayisi = " ";

            if (DGW.CurrentRow.Selected == true)
            {
                if (DGW.CurrentRow.Cells[5].Value != null)
                {
                    sefer_tarih = DGW.CurrentRow.Cells[0].Value.ToString();
                    sefer_saat = DGW.CurrentRow.Cells[1].Value.ToString();
                    Kalkis = DGW.CurrentRow.Cells[2].Value.ToString();
                    #region Otobüs Koltuk Sayısını Bulma
                    koltuk_sayisi = DGW.CurrentRow.Cells[4].Value.ToString();
                    koltuk_sayisi.TrimEnd();
                    koltuk_sayisi.TrimStart();
                    int tam = koltuk_sayisi.Length;
                    tam = tam - 2;
                    sayi = koltuk_sayisi.Substring(tam, 2);

                    var t = Convert.ToDateTime(sefer_tarih);
                    var bul_sefer_id = db.Sefer.Where(p => p.kalkis_saat == sefer_saat && p.kalkis_tarihi == t).ToList();
                    foreach (var item in bul_sefer_id)
                    {
                        sefer_id = item.sefer_id;
                        peron_no = item.peron_no;
                    }

                    #endregion
                    koltuk_tipi = DGW.CurrentRow.Cells[5].Value.ToString();
                    if (koltuk_tipi == "2+1") { iki_arti_bir(); }
                    else if (koltuk_tipi == "2+2") { iki_arti_iki(); }
                    else { msj.Mesaj("Koltuk Tipi Hatalı"); }
                }
            }
        }
        public void button_cinsiyet_diz(CheckBox c)
        {
            //this.Refresh();

            cmbx_kalkis = cmbxKalkis.SelectedItem.ToString();
            cmbx_varis = cmbxVaris.SelectedItem.ToString();
            DateTime tarih = Convert.ToDateTime(sefer_tarih);
            var koltuk_durum_listele = (from b in db.Bilet
                                        where b.sefer_id == sefer_id
                                        where b.iptal == 0
                                        join ylc in db.Yolcu on b.yolcu_id equals ylc.yolcu_id
                                        select new
                                        { b, ylc }).Distinct().ToList();

            foreach (var item_koltuk in koltuk_durum_listele)
            {
                if (c.Text == item_koltuk.b.koltuk_no.ToString())
                {
                    // Satılan Biletler
                    // İnternetten Alınan Biletler
                    // Rezervasyonlar
                    var gz = db.Guzergah.Where(p => p.varis_yeri == item_koltuk.b.varis).Count();//.ToList();
                    var gz_ara = db.Guzergah_Arayol.Where(p => p.arayol == item_koltuk.b.varis).Count();
                    if (gz > 0)
                    {
                        var online = db.Bilet.Where(p => p.koltuk_no.ToString() == c.Text && p.online == 1).ToList();
                        var rezerve = db.Rezerve.Where(p => p.Koltuk_No.ToString() == c.Text).ToList();
                        if (rezerve.Count != 0)
                        {
                            foreach (var item in rezerve)
                            {
                                if (item_koltuk.ylc.cinsiyet_kod.ToString() == "2") // ERKEK REZERVASYON
                                {
                                    string customPath = "C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\";
                                    string filename = "men_rezervasyon.png";
                                    c.Name = "Rezerve";
                                    c.BackgroundImage = Image.FromFile(Path.Combine(customPath, filename));
                                    c.BackgroundImageLayout = ImageLayout.Center;

                                    ToolTip toolTip1 = new ToolTip();
                                    toolTip1.SetToolTip(c, "Adı Soyadı: " + item_koltuk.b.Yolcu.adi_soyadi + "\n" + "Kalkış: " + item.kalkis + "\n" + "Varış: " + item.varis + "\n" + "Ücret: " + "Rezerve" + "\n" + "Rezervasyon Tarihi: " + Convert.ToDateTime(item.rezerve_tarihi).ToShortDateString());
                                }
                                else if (item_koltuk.ylc.cinsiyet_kod.ToString() == "3") // BAYAN REZERVASYON
                                {
                                    string customPath = "C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\";
                                    string filename = "women_rezervasyon.png";
                                    c.Name = "Rezerve";
                                    c.BackgroundImage = Image.FromFile(Path.Combine(customPath, filename));
                                    c.BackgroundImageLayout = ImageLayout.Center;
                                }
                            }
                        }
                        else if (online.Count != 0)
                        {
                            foreach (var item in online)
                            {
                                if (item_koltuk.ylc.cinsiyet_kod.ToString() == "2") // ERKEK İNTERNET
                                {
                                    string customPath = "C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\";
                                    string filename = "men_internet.png";
                                    if (item.cikti_alindi == 1)
                                    {
                                        c.Name = "DOLU";
                                    }
                                    else
                                    {
                                        c.Name = "Online";
                                    }
                                    c.BackgroundImage = Image.FromFile(Path.Combine(customPath, filename));
                                    c.BackgroundImageLayout = ImageLayout.Center;

                                    try
                                    {
                                        ToolTip toolTip1 = new ToolTip();
                                        toolTip1.SetToolTip(c, "Adı Soyadı: " + item_koltuk.b.Yolcu.adi_soyadi + "\n" + "Kalkış: " + item_koltuk.b.kalkis + "\n" + "Varış: " + item_koltuk.b.varis + "\n" + "Ücret: " + item_koltuk.b.tutar + "\n" + "Satan: " + item_koltuk.b.Personel.adi + " " + item_koltuk.b.Personel.soyadi + "\n" + "Satış Tarihi: " + Convert.ToDateTime(item_koltuk.b.satis_tarihi).ToShortDateString());
                                    }
                                    catch (Exception)
                                    {


                                    }
                                }
                                else if (item_koltuk.ylc.cinsiyet_kod.ToString() == "3") // BAYAN İNTERNET
                                {
                                    string customPath = "C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\";
                                    string filename = "women_internet.png";
                                    if (item.cikti_alindi == 1)
                                    {
                                        c.Name = "DOLU";
                                    }
                                    else
                                    {
                                        c.Name = "Online";
                                    }
                                    c.BackgroundImage = Image.FromFile(Path.Combine(customPath, filename));
                                    c.BackgroundImageLayout = ImageLayout.Center;

                                    try
                                    {
                                        ToolTip toolTip1 = new ToolTip();
                                        toolTip1.SetToolTip(c, "Adı Soyadı: " + item_koltuk.b.Yolcu.adi_soyadi + "\n" + "Kalkış: " + item_koltuk.b.kalkis + "\n" + "Varış: " + item_koltuk.b.varis + "\n" + "Ücret: " + item_koltuk.b.tutar + "\n" + "Satan: " + item_koltuk.b.Personel.adi + " " + item_koltuk.b.Personel.soyadi + "\n" + "Satış Tarihi: " + Convert.ToDateTime(item_koltuk.b.satis_tarihi).ToShortDateString());
                                    }
                                    catch (Exception)
                                    {


                                    }
                                }
                            }
                        }
                        else
                        {
                            if (item_koltuk.ylc.cinsiyet_kod.ToString() == "2")
                            {
                                string customPath = "C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\";
                                string filename = "men.png";
                                c.Name = "DOLU";
                                c.BackgroundImage = Image.FromFile(Path.Combine(customPath, filename));
                                c.BackgroundImageLayout = ImageLayout.Center;

                                try
                                {
                                    ToolTip toolTip1 = new ToolTip();
                                    toolTip1.SetToolTip(c, "Adı Soyadı: " + item_koltuk.b.Yolcu.adi_soyadi + "\n" + "Kalkış: " + item_koltuk.b.kalkis + "\n" + "Varış: " + item_koltuk.b.varis + "\n" + "Ücret: " + item_koltuk.b.tutar + "\n" + "Satan: " + item_koltuk.b.Personel.adi + " " + item_koltuk.b.Personel.soyadi + "\n" + "Satış Tarihi: " + Convert.ToDateTime(item_koltuk.b.satis_tarihi).ToShortDateString());
                                }
                                catch (Exception)
                                {


                                }
                            }
                            else if (item_koltuk.ylc.cinsiyet_kod.ToString() == "3")
                            {
                                string customPath = "C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\";
                                string filename = "women.png";
                                c.Name = "DOLU";
                                c.BackgroundImage = Image.FromFile(Path.Combine(customPath, filename));
                                c.BackgroundImageLayout = ImageLayout.Center;
                            }
                        }
                    }
                    else if (cmbx_varis == item_koltuk.b.varis)
                    {
                        var rezerve = db.Rezerve.Where(p => p.Koltuk_No.ToString() == c.Text).ToList();
                        if (rezerve.Count != 0)
                        {
                            foreach (var item in rezerve)
                            {
                                if (item_koltuk.ylc.cinsiyet_kod.ToString() == "2") // ERKEK REZERVASYON
                                {
                                    string customPath = "C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\";
                                    string filename = "men_rezervasyon.png";
                                    c.Name = "Rezerve";
                                    c.BackgroundImage = Image.FromFile(Path.Combine(customPath, filename));
                                    c.BackgroundImageLayout = ImageLayout.Center;

                                    ToolTip toolTip1 = new ToolTip();
                                    toolTip1.SetToolTip(c, "Adı Soyadı: " + item_koltuk.b.Yolcu.adi_soyadi + "\n" + "Kalkış: " + item.kalkis + "\n" + "Varış: " + item.varis + "\n" + "Ücret: " + "Rezerve" + "\n" + "Rezervasyon Tarihi: " + Convert.ToDateTime(item.rezerve_tarihi).ToShortDateString());
                                }
                                else if (item_koltuk.ylc.cinsiyet_kod.ToString() == "3") // BAYAN REZERVASYON
                                {
                                    string customPath = "C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\";
                                    string filename = "women_rezervasyon.png";
                                    c.Name = "Rezerve";
                                    c.BackgroundImage = Image.FromFile(Path.Combine(customPath, filename));
                                    c.BackgroundImageLayout = ImageLayout.Center;
                                }
                            }
                        }

                        if (item_koltuk.ylc.cinsiyet_kod.ToString() == "2") // ERKEK NORMAL
                        {
                            string customPath = "C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\";
                            string filename = "men.png";
                            c.Name = "DOLU";
                            c.BackgroundImage = Image.FromFile(Path.Combine(customPath, filename));
                            c.BackgroundImageLayout = ImageLayout.Center;
                            try
                            {
                                ToolTip toolTip1 = new ToolTip();
                                toolTip1.SetToolTip(c, "Adı Soyadı: " + item_koltuk.b.Yolcu.adi_soyadi + "\n" + "Kalkış: " + item_koltuk.b.kalkis + "\n" + "Varış: " + item_koltuk.b.varis + "\n" + "Ücret: " + item_koltuk.b.tutar + "\n" + "Satan: " + item_koltuk.b.Personel.adi + " " + item_koltuk.b.Personel.soyadi + "\n" + "Satış Tarihi: " + Convert.ToDateTime(item_koltuk.b.satis_tarihi).ToShortDateString());
                            }
                            catch (Exception)
                            {


                            }
                        }
                        else if (item_koltuk.ylc.cinsiyet_kod.ToString() == "3") // BAYAN NORMAL
                        {
                            string customPath = "C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\";
                            string filename = "women.png";
                            c.Name = "DOLU";
                            c.BackgroundImage = Image.FromFile(Path.Combine(customPath, filename));
                            c.BackgroundImageLayout = ImageLayout.Center;
                        }
                    }

                }
            }
        }
        public void iki_arti_bir()
        {
            grpBoxOtobusPlan.Controls.Clear();
            // 2+1 // Koltuk Tipi
            int x1 = 60;
            int y1 = 15;
            int koltuk_b = 0;
            for (int i = 1; i <= Convert.ToInt32(sayi); i++)
            {
                if (i == 26)
                {
                    y1 += 60;
                    x1 = 40;
                }
                if (x1 > 300)
                {
                    x1 = 60;
                    y1 += 60;
                }

                if ((koltuk_b % 3 == 1) && koltuk_b < 26) { x1 += 20; }

                if ((koltuk_b % 3 == 2) && koltuk_b >= 26) { x1 += 20; }

                koltuk_b++;
                CheckBox k = new CheckBox();
                k.Appearance = Appearance.Button;
                k.TextAlign = ContentAlignment.TopRight;
                k.SetBounds(x1, y1, 15, 20);
                x1 += 100;
                k.Text = i.ToString();
                button_cinsiyet_diz(k);
                k.Click += new EventHandler(tikla);
                k.Width = 100;
                k.Height = 40;
                grpBoxOtobusPlan.Controls.Add(k);
            }
            peron_goster(x1 + 150, y1 - 10); //x 470 y 725
        }
        public void iki_arti_iki()
        {
            grpBoxOtobusPlan.Controls.Clear();
            // 2+2 // Koltuk Tipi
            int x = 0;
            int y = 15;
            int koltuk_a = 0;
            for (int i = 1; i <= Convert.ToInt32(sayi); i++)
            {
                if (i == 23)
                {
                    y += 50;
                    x = 0;
                }
                if (x > 350)
                {
                    x = 0;
                    y += 55;
                }
                if (koltuk_a % 2 == 0)
                {
                    x += 20; // Button'ların Sağ'dan Group İçerisinde Hizalanması Sağlar.

                    // orta boşluk // 
                    //if (koltuk != 44)
                    //{ // en arkayi 4lersek bu if oluyor. kaldirirsan arka taraf yan yana 4lu olmaz
                    //    x += 20;
                    //}
                }
                koltuk_a++;
                CheckBox c = new CheckBox();
                c.SetBounds(x, y, 15, 30);
                x += 100;
                c.Text = i.ToString();
                button_cinsiyet_diz(c);
                c.Click += new EventHandler(tikla);
                c.Width = 100;
                c.Height = 40;
                c.TextAlign = ContentAlignment.TopRight;
                c.Appearance = Appearance.Button;
                grpBoxOtobusPlan.Controls.Add(c);
            }

            peron_goster(x, y);
        }

        public void peron_goster(int x, int y)
        {
            Label lb_peron = new Label();
            lb_peron.Text = "PERON:";
            lb_peron.Font = new Font("Arial", 15, FontStyle.Bold);
            lb_peron.SetBounds(x - 300, y + 70, 90, 30);
            grpBoxOtobusPlan.Controls.Add(lb_peron);

            Label lbl_peron_deger = new Label();
            lbl_peron_deger.Text = peron_no;
            lbl_peron_deger.Font = new Font("Arial", 15, FontStyle.Bold);
            lbl_peron_deger.ForeColor = System.Drawing.Color.Red;
            lbl_peron_deger.SetBounds(x - 210, y + 70, 1000, 30);
            grpBoxOtobusPlan.Controls.Add(lbl_peron_deger);
        }

        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;
            string time = " ";

            if (hh < 10) { time += "0" + hh; }
            else { time += hh; }
            time += ":";
            if (mm < 10) { time += "0" + mm; }
            else { time += mm; }
            time += ":";
            if (ss < 10) { time += "0" + ss; }
            else { time += ss; }
            lblTarihSaat.Text = time;
        }

        private void btnUyelik_Click(object sender, EventArgs e)
        {
            frm.Ac("Uyelik");
        }


        private void btnCikis_Click(object sender, EventArgs e)
        {
            var kontrol = MessageBox.Show("                       Güle Güle Yine Bekleriz :)", "Çıkmak İstediğinizden Emin Misiniz?", MessageBoxButtons.YesNo);
            if (kontrol == DialogResult.Yes)
            {
                Bilet_Sat formkapa = new Bilet_Sat();
                formkapa.Close();
                frm.Ac("login");
                this.Hide(); //C:\\Users\\burak\\Desktop\\Bilet\\Bilet\\Resimler\\gule_gule.jpg
            }
        }

        private void btnHesap_Click(object sender, EventArgs e)
        {
            frm.Ac("Hesap");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Windows.Forms.VisualStyles;


namespace Bilet
{
    public partial class BayBayanBiletSat : Form
    {
        public BayBayanBiletSat()
        {
            InitializeComponent();
        }
        decimal fiyat;
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        int kac = Bilet_Sat.KactaneSecili;
        public string[] my_biletlerim = new string[60];
        EKLE ek = new EKLE();
        string[,] biletbilgileri = new string[60, 7];
        MesajVer msj = new MesajVer();
        Bilet_Dokum_Islemleri blt = new Bilet_Dokum_Islemleri();
        int satirx = 0;
        int satiry = 1;
        id_bul id = new id_bul();
        string ad_soyad = " ";
        string tel = " ";
        long tc_iki = 0;
        int yolcu_id = 0;
        DateTime hareket_tarihi;
        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox t = (TextBox)sender;
                long gelen = Convert.ToInt64(t.Text);
                var bulunan = db.Yolcu.Where(p => p.TC == gelen).ToList();
                foreach (var item in bulunan)
                {
                    yolcu_id = Convert.ToInt32(item.yolcu_id);
                    ad_soyad = item.adi_soyadi;
                    tel = item.Tel;
                    tc_iki = Convert.ToInt64(item.TC);
                }
                int a = Convert.ToInt32(t.Tag.ToString());
                a++;
                foreach (Control c in this.Controls)
                {
                    if (c.Tag == null)
                        continue;
                    else if (Convert.ToInt32(c.Tag.ToString()) == a)
                    {
                        c.Text = ad_soyad;
                        c.Refresh();
                    }
                    else if (Convert.ToInt32(c.Tag.ToString()) == a + 1)
                    {
                        c.Text = tel;
                        c.Refresh();
                    }
                    else if (Convert.ToInt32(c.Tag.ToString()) == a + 2)
                    {
                        c.Text = tc_iki.ToString();
                        c.Refresh();
                    }
                }
            }
        }


        private void BayBiletSat_Load(object sender, EventArgs e)
        {
            if (login.giris_yapan_personel_id != 0) // güvenlik amacı ile 
            {

            DateTime tarih = Convert.ToDateTime(Bilet_Sat.sefer_tarih);
            string saat = Bilet_Sat.sefer_saat;
            string cinsiyet = Bilet_Sat.Parametre;
            Button button = new Button(); // KAYDET BUTTON
            Button btn = new Button(); // KREDİ KARTI
            int sayi = 0;
            int x = 130;
            int y = 10;
            int kactane_olustur = 4;
            string[] tepe = { "Seçilen Koltuk No", "T.C No Sorgula", "Adı Soyadı", "Telefon", "T.C. Kimlik", "Fiyat Türü", "Birim Fiyat" };
            for (int i = 0; i < tepe.Count(); i++)
            {
                Label l = new Label();
                l.Text = tepe[i];
                l.SetBounds(x, y, 100, 100);
                x += 130;
                l.Height = 14;
                this.Controls.Add(l);
            }
            y = 40;
            int index = 1;
            for (int i = 0; i < kac; i++)
            {
                x = 0;
                for (int tr = 0; tr < kactane_olustur; tr++)
                {
                    TextBox t = new TextBox();
                    Label lb = new Label();
                    Label lbFiyat = new Label();
                    ComboBox cm = new ComboBox();
                    MaskedTextBox msk = new MaskedTextBox();

                    ////fiyat ayrilda kaldımm....

                    if (tr == 0)
                    {
                        lb.Text = my_biletlerim[i];
                        x += 130;
                        lb.SetBounds(x, y, 100, 30);
                        lb.Name = "Koltuk" + i.ToString();
                        this.Controls.Add(lb);
                        t.MaxLength = 11;
                        t.Tag = index++;
                        t.KeyDown += new KeyEventHandler(tb_KeyDown);
                        t.Leave += new EventHandler(ayril);
                        t.Name = "UYE/TC" + i.ToString();
                    }

                    if (tr == 1)
                    {
                        t.Name = "AdSoyad" + i.ToString();
                        t.Tag = index++;
                        t.Text = ad_soyad;
                        t.Leave += new EventHandler(ayril);
                    }

                    if (tr == 2)
                    {
                        x += 130;
                        msk.Mask = "(000) 000-0000";
                        msk.SetBounds(x, y, 100, 30);
                        msk.Name = "TEL" + i.ToString();
                        msk.Tag = index++;
                        msk.Leave += new EventHandler(ayril);
                        this.Controls.Add(msk);

                        t.MaxLength = 11;
                        t.Tag = index++;
                        t.Name = "TC" + i.ToString();
                        t.Leave += new EventHandler(ayril);
                    }

                    if (tr == 3)
                    {
                        x += 130;
                        var bulunan_fiyat = db.Indirim_Artis.ToList();
                        foreach (var item in bulunan_fiyat)
                        {
                            cm.Items.Add(item.indirim_artis_adi); // indirimler eklendi. Ama Normal Fiyatıda Ekle.
                        }
                        cm.Name = "IndirimTuru";
                        cm.SetBounds(x, y, 100, 50);
                        cm.Tag = index++;
                        cm.SelectedText = "NORMAL";
                        cm.SelectedIndexChanged += new EventHandler(cmb_SelectedValueChanged);
                        cm.Leave += new EventHandler(ayril);
                        this.Controls.Add(cm);

                        lbFiyat.Text = Convert.ToDecimal(Bilet_Sat.para).ToString();//"FİYAT";
                        lbFiyat.Tag = index++;
                        lbFiyat.Name = "Fiyat";
                        fiyat = Convert.ToDecimal(lbFiyat.Text);
                        x += 130;
                        lbFiyat.SetBounds(x, y, 100, 30);
                        this.Controls.Add(lbFiyat);
                    }
                    else
                    {
                        x += 130;
                        t.SetBounds(x, y, 100, 50);
                        this.Controls.Add(t);
                    }
                }

                y += 35;
                x += 130;
                sayi++;

            };
            if (Bilet_Sat.nerden == "Online")
            {
                button.Location = new Point(x - 160, kac * 70);
                button.Text = "Bilet Dök";//"Nakit Ödeme";
                button.Width = 100;
                button.Click += (s, n) =>  /*MessageBox.Show("Nakit");*/
                {
                    string duzenleme_yeri = " "; // ÖRN: AŞTİ
                    string bilet_kesen_kisi = " ";
                    string varis = " ";
                    string peron = " ";
                    string ylc_adi_soyadi = " ";
                    decimal fiyat = 0;
                    string hareket_saati = " ";
                    int secili_koltuk = 0;
                    var secili = Bilet_Sat.hangisisecili.ToList();
                    foreach (var item in secili)
                    {
                        secili_koltuk = Convert.ToInt32(item);
                    }
                   
                    var bilet = db.Bilet.Where(p => p.koltuk_no == secili_koltuk).ToList();
                    foreach (var item_blt in bilet)
                    {
                        bilet_kesen_kisi = item_blt.Personel.adi + item_blt.Personel.soyadi;
                        duzenleme_yeri = id.IsimKodBul(Convert.ToInt32(item_blt.Personel.yer_kod));
                        fiyat = Convert.ToDecimal(item_blt.tutar);
                        ylc_adi_soyadi = item_blt.Yolcu.adi_soyadi;
                        varis = item_blt.varis;
                        var sefer = db.Sefer.Where(p => p.sefer_id == item_blt.sefer_id).ToList();
                        var personel = db.Personel.Where(p => p.personel_id == login.giris_yapan_personel_id).ToList();
                        item_blt.cikti_alindi = 1;
                        db.SaveChanges();

                        foreach (var item_sfr in sefer)
                        {
                            hareket_tarihi = Convert.ToDateTime(item_sfr.kalkis_tarihi);
                            hareket_saati = item_sfr.kalkis_saat.ToString();
                            peron = item_sfr.peron_no;
                        }
                    }
                    blt.biletdok(varis, hareket_tarihi, hareket_saati, Convert.ToString(secili_koltuk), fiyat, ylc_adi_soyadi, peron, bilet_kesen_kisi, duzenleme_yeri,System.DateTime.Now.ToShortDateString());
                };
            }
            else
            {
                button.Location = new Point(x - 160, kac * 70);
                button.Text = "Yazdır / Kaydet";//"Nakit Ödeme";
                button.Width = 100;
                button.Click += (s, n) =>  /*MessageBox.Show("Nakit");*/
                {
                    string peron = " ";
                    string hareket_saati = " ";
                    string personel = " ";
                    string duzenleme_yeri = " ";
                    int sefer_id = 0;
                    string koltukno = " ";
                    string adi = " ";
                    string tel = " ";
                    string tc = " ";
                    string secilen_indirim = " ";
                    decimal bilet_tutar = 0;
                    decimal son_bilet_tutar = 0;
                    int yolcu_id = 0;
                    for (int i = 0; i < 60; i++)
                    {
                        if (biletbilgileri[i, 0] != null)
                        {
                            koltukno = biletbilgileri[i, 0];
                            adi = biletbilgileri[i, 2];
                            tel = biletbilgileri[i, 3];
                            tc = biletbilgileri[i, 4];
                            secilen_indirim = biletbilgileri[i, 5];
                            son_bilet_tutar = fiyat;
                            var indirim = db.Indirim_Artis.Where(p => p.indirim_artis_adi == secilen_indirim.ToString());
                            int indirim_id = 0;
                            bilet_tutar = bilettutarihesapla(tarih, saat);
                            if (indirim.Count() == 0)
                            {
                                indirim_id = 6; // seçilmemiş ise normal dir.
                            }
                            else
                            {
                                foreach (var item in indirim)
                                {
                                    indirim_id = item.indirim_artis_id;
                                }
                            }
                            var bulunan_sefer_id = db.Sefer.Where(p => p.kalkis_tarihi == tarih && p.kalkis_saat == saat).ToList();
                            var donen = cinsiyet.IndexOf("Bayan");
                            int cinsiyet_kod = 0;
                            var uye = db.Yolcu.Where(p => p.TC == tc_iki).ToList();
                            var g = db.Guzergah_Arayol.Where(p => p.arayol == Bilet_Sat.Varis).ToList();
                            if (donen == 0)
                                cinsiyet_kod = 3;
                            else
                                cinsiyet_kod = 2;
                            if (uye.Count != 0)
                            {
                                foreach (var item in uye)
                                    yolcu_id = item.yolcu_id;
                            }
                            else
                                ek.UyeEkle(false, adi, tel, Convert.ToInt64(tc), null, cinsiyet_kod);
                            foreach (var item in bulunan_sefer_id)
                            {
                                sefer_id = item.sefer_id;
                                hareket_tarihi = Convert.ToDateTime(item.kalkis_tarihi);
                                hareket_saati = item.kalkis_saat.ToString();
                                peron = item.peron_no;
                                ek.Bilet_Ekle(Convert.ToInt32(koltukno), yolcu_id, Convert.ToInt32(item.sefer_id), indirim_id,
                                    login.giris_yapan_personel_id, 9, Bilet_Sat.Kalkis, Bilet_Sat.Varis, son_bilet_tutar, 0, 0); //9 Nakit
                            }
                        }
                    }
                    int koltuk_yeni = Convert.ToInt32(koltukno);
                    var ylc = db.Yolcu.Where(p => p.yolcu_id == yolcu_id);
                    var bilet_bul = db.Bilet.Where(p => p.koltuk_no == koltuk_yeni && p.sefer_id == sefer_id).ToList();
                    foreach (var item_ylc in ylc)
                    {
                        adi = item_ylc.adi_soyadi;
                    }
                    foreach (var item in bilet_bul)
                    {
                        personel = item.Personel.adi + item.Personel.soyadi;
                        duzenleme_yeri = id.IsimKodBul(Convert.ToInt32(item.Personel.yer_kod));
                    }
                    blt.biletdok(Bilet_Sat.Varis, hareket_tarihi, hareket_saati, koltukno, son_bilet_tutar, adi, peron, personel, duzenleme_yeri, System.DateTime.Now.ToShortDateString());
                };
            }

            Label kl = new Label();
            kl.Text = "Kalkış";
            kl.Width = 40;
            kl.Location = new Point(10, 42);

            Label kl_deger = new Label();
            kl_deger.Text = Bilet_Sat.Kalkis; // Seçilen Kalkış Gelecek.
            kl_deger.Location = new Point(50, 42);

            Label vr = new Label();
            vr.Text = "Varış";
            vr.Width = 40;
            vr.Location = new Point(10, 75);

            Label vr_deger = new Label();
            vr_deger.Text = Bilet_Sat.Varis; //Seçilen Varış Gelecek.
            vr_deger.Location = new Point(50, 75);

            //button.Click += new EventHandler(button_Click);

            //this.Controls.Add(btn);
            this.Controls.Add(button);
            this.Controls.Add(kl);
            this.Controls.Add(kl_deger);
            this.Controls.Add(vr);
            this.Controls.Add(vr_deger);
            this.Text = cinsiyet + "                  " + "Sefer Tarihi " + Bilet_Sat.sefer_tarih + " " + Bilet_Sat.sefer_saat;//Form Başlık 
            }
        }
        decimal sabit = 0;
        string ne_secili = " ";
        private void cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox txt = (ComboBox)sender;
            var bulunan = db.Indirim_Artis.Where(p => p.indirim_artis_adi == txt.SelectedItem.ToString()).ToList();
            decimal bulunan_indirim = 0;
            // bulunan'daki oran ile 
            foreach (var item in bulunan)
            {
                //(Convert.ToDouble(fiyat.Text) / item.indirim_artis_orani).ToString(); //item.indirim_artis_orani
                bulunan_indirim = Convert.ToDecimal(item.indirim_artis_orani);    
            
            }

            int a = Convert.ToInt32(txt.Tag.ToString());
            a++;

            foreach (Control c in this.Controls)
            {
                if (c.Tag == null)
                    continue;

                else if (Convert.ToInt32(c.Tag.ToString()) == a)
                {
                    if (sabit == 0)
                        sabit = Convert.ToDecimal(c.Text);
                    if (ne_secili == "NORMAL")
                        c.Text = String.Format("{0:0.00}", sabit);
                    else
                    {
                        decimal gecici = sabit;
                        decimal toplam = Convert.ToDecimal(bulunan_indirim) / 100 * gecici;
                        c.Text = String.Format("{0:0.00}", toplam);
                        c.Refresh();
                    }
                }
                else if (Convert.ToInt32(c.Tag.ToString()) == a - 1)
                    ne_secili = c.Text; // neyin seçili olduğunu gösterir.
            }
        }

        public decimal bilettutarihesapla(DateTime tarih, string saat)
        {
            var gzarayol = (from gzrarayol in db.Guzergah_Arayol
                            where gzrarayol.arayol == Bilet_Sat.Varis
                            select new { gzrarayol }).Distinct().ToList();

            var gz = (from sfr in db.Sefer
                      join gzr in db.Guzergah on sfr.guzergah_id equals gzr.guzergah_id
                      where gzr.varis_yeri == Bilet_Sat.Varis &&
                      gzr.kalkis_yeri == Bilet_Sat.Kalkis
                      where sfr.kalkis_tarihi == tarih
                      && sfr.kalkis_saat == saat
                      select new
                      { sfr, gzr }).Distinct().ToList();

            if (gzarayol.Count == 1)
            {
                foreach (var item in gzarayol)
                {
                    return Convert.ToDecimal(item.gzrarayol.ucret);
                }
            }
            else if (gz.Count() == 1)
            {
                foreach (var item in gz)
                {
                    return Convert.ToDecimal(item.sfr.ucret);
                }
            }
            return 0;
        }

        void ayril(object sender, EventArgs e)
        {
            TextBox f = sender as TextBox;
            MaskedTextBox msk = sender as MaskedTextBox;
            ComboBox cmbx = sender as ComboBox;
            Label lb = sender as Label;

            for (int k = 0; k < my_biletlerim.Length; k++)
            {
                if (my_biletlerim[k] == null) continue;
                biletbilgileri[k, 0] = my_biletlerim[k];
            }


            if (f != null)
            {
                satiry = Convert.ToInt32(f.Tag) % 6;
                satirx = Convert.ToInt32(f.Tag) / 6;
                biletbilgileri[satirx, satiry++] = f.Text;
            }
            else if (msk != null)
            {
                satiry = Convert.ToInt32(msk.Tag) % 6;
                satirx = Convert.ToInt32(msk.Tag) / 6;
                biletbilgileri[satirx, satiry] = msk.Text.ToString();
            }
            else if (cmbx != null)
            {
                satiry = Convert.ToInt32(cmbx.Tag) % 6;
                satirx = Convert.ToInt32(cmbx.Tag) / 6;
                biletbilgileri[satirx, satiry++] = cmbx.SelectedItem.ToString();
            }
        }

        private void BayBayanBiletSat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Bilet_Sat hg = new Bilet_Sat();
            hg.Refresh();
        }
    }
}
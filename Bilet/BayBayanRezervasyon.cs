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
    public partial class BayBayanRezervasyon : Form
    {
        public BayBayanRezervasyon()
        {
            InitializeComponent();
        }
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        public string[] my_biletlerim = new string[60];
        public string[,] biletbilgileri = new string[60, 6];
        EKLE ek = new EKLE();
        MesajVer msj = new MesajVer();
        string ad_soyad = " ";
        string tel = " ";
        long tc_iki = 0;
        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox t = (TextBox)sender;
            long gelen = Convert.ToInt64(t.Text);
            var rezerve = db.Rezerve.Where(p => p.Koltuk_No.ToString() == Bilet_Sat.rezervasyon_koltuk).ToList();
            foreach (var item_r in rezerve)
            {
                var bulunan = db.Yolcu.Where(p => p.TC == item_r.Yolcu.TC).ToList();
                foreach (var item in bulunan)
                {
                    ad_soyad = item.adi_soyadi;
                    tel = item.Tel;
                    tc_iki = Convert.ToInt64(item.TC);

                }
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
        private void BayBayanRezervasyon_Load(object sender, EventArgs e)
        {
            DateTime tarih = Convert.ToDateTime(Bilet_Sat.sefer_tarih);
            string saat = Bilet_Sat.sefer_saat;
            List<string> hangi_koltuk_secili = Bilet_Sat.hangisisecili;//List<string> hangi_koltuk_secili = Bilet_Sat.hangisisecili;
            int kac = Bilet_Sat.KactaneSecili;
            string cinsiyet = Bilet_Sat.Parametre;
            string[] st = new string[6];
            Button button = new Button(); // Rezerve Et BUTTON
            Button btn = new Button(); // Rezervasyon İptal
            int sayi = 0;
            int x = 130;
            int y = 10;
            int kactane_olustur = 4;
            string[] tepe = { "Seçilen Koltuk No", "T.C No / ÜyeNo", "Adı Soyadı", "Telefon", "T.C. Kimlik", "Fiyat Türü", "Birim Fiyat" };
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
                        //cm.SelectedIndexChanged += new System.EventHandler(cmb_SelectedValueChanged);
                        cm.Leave += new EventHandler(ayril);
                        this.Controls.Add(cm);

                        lbFiyat.Text = Convert.ToDecimal(Bilet_Sat.para).ToString();//"FİYAT";
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
                if (Bilet_Sat.nerden == "Rezerve")
                {
                    doldur();
                }
            };
            
            string rezerve_btn_durum = " ";
            string hangi = " ";
            foreach (var item in hangi_koltuk_secili)
            {
                hangi = item;
                var rezerve = db.Rezerve.Where(p => p.Koltuk_No.ToString() == hangi).Count();
                if (rezerve > 0)
                {
                    rezerve_btn_durum = "Bilet Dök";

                    btn.Location = new Point(x - 260, kac * 70);
                    btn.Text = "Rezervasyon İptal";
                    btn.Width = 100;
                    btn.Click += (s, n) =>
                    {
                        try
                        {
                            var silinecek = db.Rezerve.Where(p => p.Koltuk_No.ToString() == hangi).FirstOrDefault();
                            var confirmResult = MessageBox.Show("Silmiş Olduğunuz Rezervasyon Geri Alınamaz.", "Silmek İstediğinizden Emin  Misiniz?", MessageBoxButtons.YesNo);

                            if (confirmResult == DialogResult.Yes)
                            {
                                db.Rezerve.Remove(silinecek);
                                db.SaveChanges();
                                 msj.Mesaj("Rezervasyon Silindi");
                            }
                        }
                        catch (Exception)
                        {
                            msj.Mesaj("Hata!");
                        }
                    };
                    this.Controls.Add(btn);
                }
                else
                    rezerve_btn_durum = "Rezervasyon Kaydet";
            }
            button.Location = new Point(x - 160, kac * 70);
            button.Text = rezerve_btn_durum;//"Rezervasyon Kaydet";//"Nakit Ödeme";
            button.Width = 100;
            button.Click += (s, n) =>  /*MessageBox.Show("Nakit");*/
            {
                string secilen_indirim = " ";
                int yolcu_id = 0;
                int kntrl = 0;
                if (button.Text == "Rezervasyon Kaydet")
                {
                    for (int i = 0; i < 60; i++)
                    {
                        if (biletbilgileri[i, 0] == null)
                        {
                            if (kntrl == 1)
                                msj.Mesaj("Lütfen Boş Alanları Doldurunuz!"); // Mesajı 1 Defa Versin Diye :)))

                            kntrl++;
                        }
                        else
                        {
                            string koltukno = biletbilgileri[i, 0];
                            string adi_soyadi = biletbilgileri[i, 2];
                            string tel = biletbilgileri[i, 3];
                            string tc = biletbilgileri[i, 4];
                            secilen_indirim = biletbilgileri[i, 5];
                            var bulunan_sefer_id = db.Sefer.Where(p => p.kalkis_tarihi == tarih && p.kalkis_saat == saat).Select(p => p.sefer_id).ToList();
                            var donen = cinsiyet.IndexOf("Bayan");
                            int cinsiyet_kod = 0;
                            var uye = db.Yolcu.Where(p => p.TC == tc_iki).ToList(); // Üye İse Üye Tablosuna Birdaha Yazmaya Gerek Yok.
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
                                ek.UyeEkle(false, adi_soyadi, tel, Convert.ToInt64(tc), null, cinsiyet_kod);
                            foreach (var item in bulunan_sefer_id)
                            {
                                ek.Rezervasyon_Ekle(yolcu_id, Convert.ToInt32(koltukno), item, login.giris_yapan_personel_id, Bilet_Sat.cmbx_kalkis, Bilet_Sat.cmbx_varis);
                            }
                        }
                    }
                }
                else if (button.Text == "Bilet Dök")
                {
                    for (int i = 0; i < 60; i++)
                    {
                        if (biletbilgileri[i, 0] == null)
                            continue;
                        string koltukno = biletbilgileri[i, 0];
                        string adi_soyadi = biletbilgileri[i, 2];
                        string tel = biletbilgileri[i, 3];
                        string tc = biletbilgileri[i, 4];
                        secilen_indirim = biletbilgileri[i, 5];
                    }

                    decimal bilet_tutar = 0;
                    decimal son_bilet_tutar = 0;
                    bilet_tutar = bilettutarihesapla(tarih, saat);

                    var indirim = db.Indirim_Artis.Where(p => p.indirim_artis_adi == secilen_indirim.ToString());
                    int indirim_id = 0;
                    foreach (var item in indirim)
                    {
                        indirim_id = item.indirim_artis_id;
                        // İndirim / 100 x tutar
                        if (item.indirim_artis_adi == "NORMAL")
                            son_bilet_tutar = bilet_tutar;
                        else
                            son_bilet_tutar = Convert.ToDecimal(item.indirim_artis_orani) / 100 * bilet_tutar;
                    }
                    var bul = db.Rezerve.Where(p => p.Koltuk_No.ToString() == hangi).ToList();
                    foreach (var item in bul)
                    {
                        ek.Bilet_Ekle(Convert.ToInt32(item.Koltuk_No), Convert.ToInt32(item.yolcu_id), Convert.ToInt32(item.sefer_id), 6, 1, 9, item.kalkis, item.varis, son_bilet_tutar, 1, 0);

                        var sil = db.Rezerve.Find(bul);
                        db.Rezerve.Remove(sil);
                        db.SaveChanges();
                    }
                }
            };

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


            this.Controls.Add(button);
            this.Controls.Add(kl);
            this.Controls.Add(kl_deger);
            this.Controls.Add(vr);
            this.Controls.Add(vr_deger);
            this.Text = cinsiyet + "                  " + "Sefer Tarihi " + Bilet_Sat.sefer_tarih + " " + Bilet_Sat.sefer_saat;//Form Başlık 

        }
        int satirx = 0;
        int satiry = 1;
        void ayril(object sender, EventArgs e)
        {
            TextBox f = sender as TextBox;
            MaskedTextBox msk = sender as MaskedTextBox;
            ComboBox cmbx = sender as ComboBox;

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
        public void doldur()
        {
            TextBox t = new TextBox();//(TextBox)sender;
            int gelen = Convert.ToInt32(my_biletlerim[0]);
            var rezerve = db.Rezerve.Where(p => p.Koltuk_No.ToString() == gelen.ToString()).ToList();
            foreach (var item_r in rezerve)
            {
                var bulunan = db.Yolcu.Where(p => p.TC == item_r.Yolcu.TC).ToList();
                foreach (var item in bulunan)
                {
                    ad_soyad = item.adi_soyadi;
                    tel = item.Tel;
                    tc_iki = Convert.ToInt64(item.TC);
                }
            }
            int a = 1;
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
}
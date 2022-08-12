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
    public partial class BayBayanBiletDüzeltme : Form
    {
        public BayBayanBiletDüzeltme()
        {
            InitializeComponent();
        }
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        int kac = Bilet_Sat.KactaneSecili;
        public string[] my_biletlerim = new string[60];
        EKLE ek = new EKLE();
        string[,] biletbilgileri = new string[60, 6];

        int satirx = 0;
        int satiry = 1;
        private void BayBayanBiletDüzeltme_Load(object sender, EventArgs e)
        {
            string cinsiyet = Bilet_Sat.Parametre;
            Button button = new Button(); // KAYDET BUTTON
            Button btn = new Button(); // KREDİ KARTI
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
            //biletlerim = new string[ kac, kactane_olustur];
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
                        // t.s
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
                        cm.SelectedIndexChanged += new System.EventHandler(cmb_SelectedValueChanged);
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

            };
            button.Location = new Point(x - 160, kac * 70);
            button.Text = "Yazdır / Kaydet";//"Nakit Ödeme";
            button.Width = 100;
            button.Click += (s, n) =>  /*MessageBox.Show("Nakit");*/
            {
                for (int i = 0; i < 60; i++)
                {
                    if (biletbilgileri[i, 0] == null)
                        continue;
                    string koltukno = biletbilgileri[i, 0];
                    string adi = biletbilgileri[i, 2];
                    string tel = biletbilgileri[i, 3];
                    string tc = biletbilgileri[i, 4];
                    string secilen_indirim = biletbilgileri[i, 5];
                    var indirim = db.Indirim_Artis.Where(p => p.indirim_artis_adi == secilen_indirim.ToString());
                    int indirim_id = 0;
                    foreach (var item in indirim)
                    {
                        indirim_id = item.indirim_artis_id;
                    }
                    DateTime tarih = Convert.ToDateTime(Bilet_Sat.sefer_tarih);
                    string saat = Bilet_Sat.sefer_saat;
                    var bulunan_sefer_id = db.Sefer.Where(p => p.kalkis_tarihi == tarih || p.kalkis_saat == saat).Select(p => p.sefer_id).ToList();
                    var donen = cinsiyet.IndexOf("Bayan");
                    int cinsiyet_kod = 0;
                    int guzergah_arayol_id = 0;
                    var g = db.Guzergah_Arayol.Where(p => p.arayol == Bilet_Sat.Varis).ToList();
                    if (g.Count != 0)
                    {
                        foreach (var item in g)
                        {
                            guzergah_arayol_id = item.guzergah_arayol_id;
                        }
                    }
                    else
                    {
                        guzergah_arayol_id = 0;
                    }
                    if (donen == 0)
                        cinsiyet_kod = 3;
                    else
                        cinsiyet_kod = 2;
                    ek.UyeEkle(false, adi, tel, Convert.ToInt64(tc), null, cinsiyet_kod);
                    //foreach (var item in bulunan_sefer_id)
                        //ek.Bilet_Ekle(8, Convert.ToInt32(koltukno), 11, Convert.ToInt32(item), indirim_id, 4, 9, guzergah_arayol_id); //9 Nakit
                    //MessageBox.Show("eklendi");
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
            vr_deger.Text = Bilet_Sat.Varis;//Bilet_Sat.Varis; //Seçilen Varış Gelecek.
            vr_deger.Location = new Point(50, 75);

            this.Controls.Add(kl);
            this.Controls.Add(kl_deger);
            this.Controls.Add(vr);
            this.Controls.Add(vr_deger);
        }
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
        private void cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            //Convert.ToDecimal(Bilet_Sat.para).ToString();
            ComboBox txt = (ComboBox)sender;
            var bulunan = db.Indirim_Artis.Where(p => p.indirim_artis_adi == txt.SelectedItem.ToString()).ToList();
            // bulunan'daki oran ile 
            foreach (var item in bulunan)
            {
                //(Convert.ToDouble(fiyat.Text) / item.indirim_artis_orani).ToString(); //item.indirim_artis_orani
            }
        }
        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.)
            //{
            //   

            //    veriler.Add(f.Text);
            //}

            //TextBox f = sender as TextBox;

            //veriler.Add(f.Text);

            if (e.KeyCode == Keys.Enter)
            {
                /*
                TextBox t = (TextBox)sender;
                long gelen = Convert.ToInt64(t.Text);
                var bulunan = db.Yolcu.Where(p => p.TC == gelen).ToList();
                foreach (var item in bulunan)
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c.Tag == null) continue; // 3 TEl // 4 TC
                        if (c.Tag.ToString().Equals("2"))
                        {
                            c.Text = item.adi_soyadi;
                        }
                        if (c.Tag.ToString().Equals("3"))
                        {
                            c.Text = item.Tel;
                        }
                        if (c.Tag.ToString().Equals("4"))
                        {
                            c.Text = Convert.ToInt64(item.TC).ToString();
                        }
                    }
                }
                */
            }
        }
    }
}
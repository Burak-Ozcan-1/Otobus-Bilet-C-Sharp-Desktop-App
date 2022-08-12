using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet
{
    public class EKLE
    {
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        id_bul id = new id_bul();

        public string Otobus_Ekle(int koltuk_sayisi, string koltuk_tipi, int marka_kod, int model_kod,string plaka)
        {
            try
            {
                var otobus_ekle = new Otobus
                {
                    koltuk_sayisi = koltuk_sayisi,
                    koltuk_tipi = koltuk_tipi,
                    marka_kod = marka_kod,
                    model_kod = model_kod,
                    plaka = plaka
                };
                db.Otobus.Add(otobus_ekle);
                db.SaveChanges();
                return "Otobüs Eklendi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }

        public string PersonelEkle(string adi, string soyadi, string tc, string tel, string adres, int cinsiyet_kod, int personel_tur, int calisilan_yer)
        {
            try
            {
                var personel_ekle = new Personel
                {
                    gorev_kod = personel_tur,
                    adi = adi,
                    soyadi = soyadi,
                    TC = tc,
                    tel = tel,
                    cinsiyet_kod = cinsiyet_kod,
                    adresi = adres,
                    yer_kod = calisilan_yer
                };
                db.Personel.Add(personel_ekle);
                db.SaveChanges();
                return "Personel Eklendi.";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }

        public string TesisEkle(string adi, string tel, string adres, string aciklama)
        {
            try
            {
                var tesis_ekle = new Tesis
                {
                    adi = adi,
                    tel = tel,
                    adresi = adres,
                    aciklama = aciklama
                };
                db.Tesis.Add(tesis_ekle);
                db.SaveChanges();
                return "Tesis Eklendi";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }

        public string IndirimEkle(string indirim_adi, int indirim_orani)
        {
            try
            {
                var indirim = new Indirim_Artis
                {
                    indirim_artis_adi = indirim_adi,
                    indirim_artis_orani = Convert.ToDecimal(indirim_orani),
                    indirim_artis_id = 5
                };
                db.Indirim_Artis.Add(indirim);
                db.SaveChanges();
                return "İndirim Eklendi";
            }
            catch (Exception)
            {
                return "HATA!";
            }

        }
        public string Guzergah(string kalkis, string varis, int mevcut_km ,string sure)
        {
            try
            {
                var guzergah_ekle = new Guzergah
                {
                    kalkis_yeri = kalkis,
                    varis_yeri = varis,
                    km = mevcut_km,
                    tahmini_sure = sure
                };
                db.Guzergah.Add(guzergah_ekle);
                db.SaveChanges();
                return "Güzergah Eklendi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }

        }
        public string Guzergah_Tesis(int secilen_ozellik)
        {
            try
            {
                var guzergah_tesis = new Guzergah_Tesis
                {
                    mola_suresi = 30,
                    tesis_id = secilen_ozellik
                };
                db.Guzergah_Tesis.Add(guzergah_tesis);
                db.SaveChanges();
                return "Güzergah Tesis Eklendi";
            }
            catch (Exception)
            {
                return "HATA!";
            }

        }
        public string SeferEkle(List<DateTime> secilen_tarih_kadar, string kalkis_saat, string peron_no, decimal ucret, int guzergah_id, int otobus_id, int sefer_id, int muavin_id, int sofor1_id, int sofor2_id, int otobus_detay_id)
        {
            try
            {
                foreach (var itemSeferEkle in secilen_tarih_kadar)
                {

                    var sefer_ekle = new Sefer
                    {
                        kalkis_tarihi = Convert.ToDateTime(itemSeferEkle.ToShortDateString()),
                        kalkis_saat = kalkis_saat,
                        peron_no = peron_no,
                        ucret = ucret,
                        guzergah_id = guzergah_id,
                        otobus_id = otobus_id,
                    };
                    db.Sefer.Add(sefer_ekle);
                    
                    var otobus_detay = new Otobus_Detay
                    {
                        muavin_id = muavin_id,
                        sofor_1_personel_id = sofor1_id,
                        sofor_2_personel_id = sofor2_id,
                        tarih = Convert.ToDateTime(itemSeferEkle.ToShortDateString()),
                        saat = kalkis_saat,
                        guzergah_id = guzergah_id,
                        otobus_id = otobus_id,
                    };
                    db.Otobus_Detay.Add(otobus_detay);
                    db.SaveChanges();
                }
                return "Sefer Eklendi";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
        public string AraYolEkle(string AraYol, decimal Ucret, int Kontenjan, int Guzergah_id, int sefer_id)
        {
            int guzergah_ara = 0;
            try
            {
                if (sefer_id != 0)
                {
                    var arayol = new Guzergah_Arayol
                    {
                        arayol = AraYol,
                        ucret = Ucret,
                        kontenjan = Kontenjan,
                        guzergah_id = Guzergah_id,
                    };
                    db.Guzergah_Arayol.Add(arayol);
                    db.SaveChanges();

                    var sefer_ara = db.Guzergah_Arayol.Where(p => p.arayol == AraYol && p.guzergah_id == Guzergah_id).ToList();
                    foreach (var item in sefer_ara)
                        guzergah_ara = item.guzergah_arayol_id;

                    var sefer_arayol = new Sefer_Arayol
                    {
                        sefer_id = sefer_id,
                        guzergah_arayol_id = guzergah_ara
                    };
                    db.Sefer_Arayol.Add(sefer_arayol);
                    db.SaveChanges();
                    return "Ara Yol Eklendi";
                }
                return "HATA!";

            }
            catch (Exception)
            {
                return "HATA!";
            }
        }

        public string KullaniciEkle(string kullanici_adi, string sifre, int kullanici_id)
        {
            try
            {
                var kullanici = new Kullanici
                {
                    kullanici_adi = kullanici_adi,
                    sifre = sifre,
                    personel_id = kullanici_id 
                };
                db.Kullanici.Add(kullanici);
                db.SaveChanges();
                return "Kullanıcı Eklendi";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }

        public string UyeEkle(bool uye_durum, string AdiSoyadi, string Tel, long TC_Kimlik, string e_posta, int cinsiyet_kod) {
            try
            {
                var uye = new Yolcu
                {
                    adi_soyadi = AdiSoyadi,
                    Tel = Tel,
                    TC = TC_Kimlik,
                    uyemi = uye_durum,
                    e_posta = e_posta,
                    cinsiyet_kod = cinsiyet_kod
                };
                db.Yolcu.Add(uye);
                db.SaveChanges();
                return "ÜYE EKLENDİ";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
        public string Bilet_Ekle(int koltuk_no, int yolcu_id, int sefer_id, int indirim_id, int bilet_kesen_personel_id, int islem_kod, string kalkis,string varis,decimal bilet_tutar,int rezerve,int online) 
        {
            try
            {
                var bilet = new Bilet
                {
                     koltuk_no = koltuk_no,
                     yolcu_id = yolcu_id,
                     sefer_id = sefer_id,
                     indirim_id = indirim_id,
                     bilet_kesen_personel_id = bilet_kesen_personel_id,
                     islem_kod = islem_kod,
                     kalkis = kalkis.ToString(),
                     varis = varis.ToString(),
                     satis_tarihi = DateTime.Now.ToShortDateString(),
                     tutar = bilet_tutar,
                     rezerve = rezerve,
                     online = online,
                     iptal = 0
                };
                db.Bilet.Add(bilet);
                db.SaveChanges();
                return "Bilet EKLENDİ";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }

        public string Rezervasyon_Ekle(int yolcu_id,int koltuk_no, int sefer_id, int rezerve_eden_kisi, string kalkis, string varis) 
        {
            try
            {
                var rezerve = new Rezerve
                {
                    yolcu_id = yolcu_id,
                    Koltuk_No = koltuk_no,
                    rezerve_tarihi = DateTime.Now,
                    sefer_id = sefer_id,
                    rezerve_eden_kisi_id = rezerve_eden_kisi,
                    kalkis = kalkis,
                    varis = varis
                };
                db.Rezerve.Add(rezerve);
                db.SaveChanges();
                return "Rezerve EKLENDİ";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
    }
}

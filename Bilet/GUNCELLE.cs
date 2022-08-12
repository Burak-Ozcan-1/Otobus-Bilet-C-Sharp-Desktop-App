using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet
{
    public class GUNCELLE
    {
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        public string Tesis_Guncelle(string Tesis_Adi, string Tesis_Adres, string Tesis_Tel, string Tesis_Aciklama, Tesis guncellenecek)
        {
            try
            {
                var bul = db.Tesis.Find(guncellenecek.tesis_id);
                bul.adi = Tesis_Adi;
                bul.adresi = Tesis_Adres;
                bul.tel = Tesis_Tel;
                bul.aciklama = Tesis_Aciklama;
                db.SaveChanges();
                return "Tesis Güncellendi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
        public string Indirim_Guncelle(string Indirim_Adi, decimal Indirim_Orani, Indirim_Artis guncellenecek)
        {
            try
            {
                var bul = db.Indirim_Artis.Find(guncellenecek.indirim_artis_id);
                bul.indirim_artis_adi = Indirim_Adi;
                bul.indirim_artis_orani = Indirim_Orani;
                db.SaveChanges();
                return "İndirim Güncellendi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }

        public string Sefer_Guncelle(DateTime kalkis_tarihi, string saat, decimal ucret, int sofor1, int sofor2, int muavin, int otobus_id, string peron, Sefer bulunacak)
        {
            try
            {
                var bul = db.Sefer.Find(bulunacak.guzergah_id);
                bul.kalkis_tarihi = kalkis_tarihi;
                bul.kalkis_saat = saat;
                bul.ucret = ucret;
                bul.peron_no = peron;
                var bul2 = db.Otobus_Detay.Find(bulunacak.guzergah_id);
                bul2.sofor_1_personel_id = sofor1;
                bul2.sofor_2_personel_id = sofor2;
                bul2.muavin_id = muavin;
                bul2.otobus_id = otobus_id;
                db.SaveChanges();
                return "Sefer Güncellendi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
        public string AraYolGuncelle(string AraYol, decimal Ucret, int Kontenjan, Guzergah_Arayol bulunacak)
        {
            try
            {
                var bul = db.Guzergah_Arayol.Find(bulunacak.guzergah_arayol_id);
                bul.arayol = AraYol;
                bul.ucret = Ucret;
                bul.kontenjan = Kontenjan;
                bul.guzergah_id = bulunacak.guzergah_id;
                db.SaveChanges();
                return "AraYol Güncellendi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
        
        public string KullaniciGuncelle(int bulunan_personel, string kullanici_adi, string sifre, Kullanici guncellenecek)
        {
            try
            {
                var bul = db.Kullanici.Find(guncellenecek.kullanici_id);
                bul.personel_id = bulunan_personel;
                bul.kullanici_adi = kullanici_adi;
                bul.sifre = sifre;
                //bul.
                db.SaveChanges();
                return "Kullanıcı Güncellendi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
        public string IptalGuncelle(Bilet guncellenecek)
        {
            try
            {
                var bul = db.Bilet.Find(guncellenecek.bilet_id);
                bul.iptal = 1;
                db.SaveChanges();
                return "Bilet Silindi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
    }
}
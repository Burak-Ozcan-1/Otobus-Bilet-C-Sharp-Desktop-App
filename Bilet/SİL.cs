using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet
{
    public class SİL
    {
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        public string Tesis_Sil(Tesis silinecek)
        {
            try
            {
                var bul = db.Tesis.Find(silinecek.tesis_id); // silineceği tekrar bulması gerekiyor yoksa silmiyor.
                db.Tesis.Remove(bul); // var üstte tanımlanmıyor.
                db.SaveChanges();
                return "Tesis Silindi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
        public string Indirim_Sil(Indirim_Artis silinecek)
        {
            try
            {
                var bul = db.Indirim_Artis.Find(silinecek.indirim_artis_id);
                db.Indirim_Artis.Remove(bul);
                db.SaveChanges();
                return "İndirim Silindi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }

        public string Sefer_Sil(Sefer silinecek, Otobus_Detay silinecekDetay)
        {
            try
            {
                var bul = db.Sefer.Find(silinecek.sefer_id);
                var bulunan = db.Otobus_Detay.Find(silinecekDetay.otobus_detay_id);
                if (bul != null && bulunan != null) // boş değil ise 
                {
                    db.Sefer.Remove(bul);
                    db.SaveChanges();
                    db.Otobus_Detay.Remove(bulunan);
                    db.SaveChanges();
                    return "Sefer Silindi";
                }
                else
                    return "HATA!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
        public string AraYolSil(Guzergah_Arayol silinecek)
        {
            try
            {
                var bul = db.Guzergah_Arayol.Find(silinecek.guzergah_arayol_id);
                db.Guzergah_Arayol.Remove(bul);
                db.SaveChanges();
                return "Ara Yol Silindi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
       
        public string KullaniciSil(Kullanici silinecek)
        {
            try
            {
                var bul = db.Kullanici.Find(silinecek.kullanici_id);
                db.Kullanici.Remove(bul);
                db.SaveChanges();
                return "Kullanıcı Silindi!";
            }
            catch (Exception)
            {
                return "HATA!";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet
{
    public class id_bul
    {
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        int k;
        string a;
        public int kod_id_bul(string bulunacak_kod_adi)
        {
            var kod_bul = db.Kodlar.Where(p => p.kod_adi == bulunacak_kod_adi).Select(x => new { x.kod_id }).ToList();
            foreach (var item in kod_bul)
                k = item.kod_id;
            return k;
        }
        public int tesis_id_bul(string tesis)
        {
            var kod_bul = db.Tesis.Where(p => p.adi == tesis).Select(x => new { x.tesis_id }).ToList().ToArray();
            foreach (var item in kod_bul)
                k = item.tesis_id;
            return k;
        }
        public string IsimKodBul(int kod)
        {
            var bul = db.Kodlar.Where(p => p.kod_id == kod);
            foreach (var item in bul)
                a = item.kod_adi;
            return a;
        }
    }
}
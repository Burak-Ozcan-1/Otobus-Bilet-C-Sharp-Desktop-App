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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        FormAc frm = new FormAc();
        id_bul bul = new id_bul();
        public static string personel = " ";
        public static int giris_yapan_personel_id = 0;
        MesajVer msj = new MesajVer();
        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            frm.Ac("SifreDegistir");
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            // yetkiye bakacak yazıhane görevlisi ise bilet sat formunu açacak...
            // yönetici ise menu formunu açacak.
            if (txtKullaniciKodu.Text == "" && txtSifre.Text == "")
                msj.Mesaj("Kullanıcı Adı Veya Şifre Boş Geçilemez. Lütfen Kontrol Edin Tekrar Deneyiniz !");
            else
            {
                var sefer_listele = (from kul in db.Kullanici
                                     join per in db.Personel on kul.personel_id equals per.personel_id
                                     where kul.kullanici_adi == txtKullaniciKodu.Text && kul.sifre == txtSifre.Text
                                     select new
                                     { kul, per }).Distinct().ToList();

                if (sefer_listele.Count == 0) // Veri Tabanın da Kullanıcı Kayıtlı Değil İse sefer_listele.Count 0 Gelir.
                    msj.Mesaj("Böyle Bir Kullanıcı Yok !");

                foreach (var item in sefer_listele)
                {
                    giris_yapan_personel_id = item.per.personel_id;

                    string calistigi_yer = " ";
                    calistigi_yer = bul.IsimKodBul(Convert.ToInt32(item.per.yer_kod));
                    personel = item.per.adi + " " + item.per.soyadi + " " + calistigi_yer;



                    if (item.per.gorev_kod == 7)
                    {
                        frm.Ac("Bilet_Sat");
                        this.Hide();
                    }
                    else if (item.per.gorev_kod == 34)
                    {
                        frm.Ac("Menu");
                        this.Hide();
                    }
                }
            }
        }
    }
}

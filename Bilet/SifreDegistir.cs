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
    public partial class SifreDegistir : Form
    {
        public SifreDegistir()
        {
            InitializeComponent();
        }
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        MesajVer msj = new MesajVer();
        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            var bul = db.Kullanici.Where(p => p.kullanici_adi == txtKadi.Text && p.sifre == txtSifre.Text).ToList();
            foreach (var item in bul)
            {
                item.sifre = txtSifreYeni.Text;
                db.SaveChanges();
                msj.Mesaj("Şifre Değiştirildi");
            }
            if (bul.Count == 0)
            {
                msj.Mesaj("Kullanıcı Bulunamadı!");
            }
        }
    }
}

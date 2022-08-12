using System;
using System.Collections;
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
    public partial class OtobusEkle : Form
    {
        public OtobusEkle()
        {
            InitializeComponent();
        }
        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();

        int bulunan_marka_id = 0;
        int bulunan_model_id = 0;
        string mesaj = " ";
        //int mola_suresi = 30;
        int bulunan_ozellik_id = 0;
        id_bul id = new id_bul();
        EKLE ek = new EKLE();
        MesajVer msj = new MesajVer();
        private void Otobus_Load(object sender, EventArgs e)
        {
            Bul();
            cmbxMarka.Text = "Marka Seçiniz";
            cmbxModel.Text = "Model Seçiniz";
            cmbxKoltukTip.Text = "Koltuk Tipi Seçiniz";
        }

        private void btnOtobusEkle_Click(object sender, EventArgs e)
        {
            try
            {
                bulunan_marka_id = Convert.ToInt32(cmbxMarka.SelectedValue);
                bulunan_model_id = Convert.ToInt32(cmbxModel.SelectedValue);

                int bulunan_ozellik_id = 0;
                int otobus_id = 0;

                mesaj = ek.Otobus_Ekle(Convert.ToInt32(txtYolcuSayısı.Text), cmbxKoltukTip.SelectedItem.ToString(), bulunan_marka_id, bulunan_model_id, mskdPlaka.Text);
                msj.Mesaj(mesaj);


                var otobus_id_bul = db.Otobus.Where(p => p.plaka == mskdPlaka.Text).ToList();
                foreach (var item in otobus_id_bul)
                    otobus_id = item.otobus_id;

                foreach (object indexChecked in chckdLstOzellik.CheckedItems)
                {
                    bulunan_ozellik_id = id.kod_id_bul(indexChecked.ToString());
                    var otobus_ozellik_ekle = new Otobus_Ozellik
                    {
                        otobus_id = otobus_id,
                        ozellik_kod = bulunan_ozellik_id
                    };
                    db.Otobus_Ozellik.Add(otobus_ozellik_ekle);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                msj.Mesaj("HATA!");
            }
            
        }
       
        private void Bul()
        {
            var eklenecek_marka = from t_marka in db.Kodlar.Where(p => p.ust_kod_id == 10) select new { t_marka.kod_adi, t_marka.kod_id };
            cmbxMarka.DataSource = eklenecek_marka.ToList();
            cmbxMarka.DisplayMember = "kod_adi";
            cmbxMarka.ValueMember = "kod_id";
            

            var eklenecek_model = from t_model in db.Kodlar.Where(p => p.ust_kod_id == 16) select new { t_model.kod_adi, t_model.kod_id };
            cmbxModel.DataSource = eklenecek_model.ToList();
            cmbxModel.DisplayMember = "kod_adi";
            cmbxModel.ValueMember   = "kod_id";

            bulunan_ozellik_id = id.kod_id_bul("ozellik_kod");

            var eklenecek_ozellik = db.Kodlar.Where(p => p.ust_kod_id == bulunan_ozellik_id).ToArray();
            foreach (var item in eklenecek_ozellik)
                chckdLstOzellik.Items.Add(item.kod_adi);

        }
        public class ListItem
        {
            public int Value;
            public string Text;
            public bool Selected;
            public ListItem(string text, int value, bool selected)
            {
                Value = value;
                Text = text;
                Selected = selected;

            }
            public override string ToString()
            {
                return Text;
            }
        }
        
    }
}

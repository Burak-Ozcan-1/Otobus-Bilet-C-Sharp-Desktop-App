using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet
{
    public partial class GuzergahEkle : Form
    {
        public GuzergahEkle()
        {
            InitializeComponent();
        }

        Otobus_BiletEntities_ db = new Otobus_BiletEntities_();
        EKLE ek = new EKLE();
        MesajVer msj = new MesajVer();
        id_bul id = new id_bul();
        List<string> tesis = new List<string>();
        private void Guzergah_Load(object sender, EventArgs e)
        {
            DTGW_BOSALT();

            var kalkis_varis = from t in db.ILLER_MESAFE select new { name = t.IL_ADI };
            
            cmbx_kalkis.DataSource = kalkis_varis.ToList();
            cmbx_kalkis.DisplayMember = "name";

            cmbx_varis.DataSource = kalkis_varis.ToList();
            cmbx_varis.DisplayMember = "name";

            var tesis = db.Tesis.ToList();
            foreach (var item in tesis)
                chckTesis.Items.Add(item.adi);

            cmbx_kalkis.Text = "Lütfen Kalkış Yeri Seçiniz";
            cmbx_varis.Text = "Lütfen Varış Yeri Seçiniz";

        }
        private void btn_GuzergahEkle_Click(object sender, EventArgs e)
        {
            string connectionString = null;
            SqlConnection cnn = null;
            SqlCommand comm = null;
            int mevcut_km = 0;
            double tahmini_hız = 90;
            double zaman = 0;
            SqlDataReader dataReader = null;
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SeyahatDB"].ConnectionString;
            string sql = " ";
            string mesaj = " ";
            int mola_suresi = 30; // mola süresi standart olarak 30 dakika alınmıştır.

            string k = cmbx_kalkis.Text;
            string v = cmbx_varis.Text;
            string t = " ";

            #region İLLER ARASI KM BUL
            sql = "Select " + k + " from ILLER_MESAFE where IL_ADI='" + v + "'";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                comm = new SqlCommand(sql, cnn);
                dataReader = comm.ExecuteReader();
                while (dataReader.Read())
                {
                    mevcut_km = Convert.ToInt32(dataReader.GetValue(0));
                    zaman = mevcut_km / tahmini_hız;
                    t = Math.Round(zaman, 2).ToString();
                    //MessageBox.Show(mevcut_km + "KM'lik Yolu " + tahmini_hız + " KM/Saat Hızla " + t + " saat'te ulaşırsın…");
                }
                dataReader.Close();
                comm.Dispose();
                cnn.Close();
            }
            catch (Exception)
            {
               // msj.Mesaj("Veri Tabanına Bağlanılamıyor!");
            }
            #endregion

           
            if (cmbx_kalkis.Text != "Lütfen Kalkış Yeri Seçiniz" && cmbx_varis.Text != "Lütfen Varış Yeri Seçiniz")
            {
                int guzergah_id = 0;
                mesaj = ek.Guzergah(k, v, mevcut_km, t);
                if (mesaj != "HATA!")
                {
                    msj.Mesaj(mesaj); // Güzergah Eklendi
                    DTGW_BOSALT();
                }
                int bulunan_ozellik_id = 0;

                var guzergah_idler = db.Guzergah.Where(p => p.kalkis_yeri == k && p.varis_yeri == v).ToList();
                foreach (var item in guzergah_idler)
                    guzergah_id = item.guzergah_id;

                foreach (object indexChecked in chckTesis.CheckedItems) //Güzergah Tesis Ekleme
                {
                    bulunan_ozellik_id = id.tesis_id_bul(indexChecked.ToString());
                    var guzergah_ekle = new Guzergah_Tesis
                    {
                        guzergah_id = guzergah_id,
                        mola_suresi = mola_suresi,
                        tesis_id = bulunan_ozellik_id
                    };
                    db.Guzergah_Tesis.Add(guzergah_ekle);
                    db.SaveChanges();
                }
            }
            else
            {
                msj.Mesaj("HATA! Lütfen Kalkış Ve Varış Yeri Seçiniz!");
            }
        }

        public void DTGW_BOSALT()
        {
            cmbx_kalkis.Text = null;
            cmbx_varis.Text = null;
        }
    }
}
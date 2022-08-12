using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        FormAc frm = new FormAc();
        private void btnOtobus_Click(object sender, EventArgs e)
        {
            frm.Ac("OtobusEkle");
        }


        private void btnPersonel_Click(object sender, EventArgs e)
        {
            frm.Ac("PersonelEkle");
        }

        private void btnTesis_Click(object sender, EventArgs e)
        {
            frm.Ac("Tesisekle");
        }

        private void btnGuzergah_Click(object sender, EventArgs e)
        {
            frm.Ac("GuzergahEkle");
        }

        private void btnSefer_Click(object sender, EventArgs e)
        {
            frm.Ac("SeferEkle");
        }
        private void btnAraYolEkle_Click(object sender, EventArgs e)
        {
            frm.Ac("AraYolEkle");
        }
        private void btnIndirim_Click(object sender, EventArgs e)
        {
            frm.Ac("IndirimEkle");
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frm.Ac("Ayarlar");
        }

        private void btnKullanici_Islemleri_Click(object sender, EventArgs e)
        {
            frm.Ac("KullaniciIslemleri");
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            giris_yapan_kisi.Text = login.personel;
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            var kontrol = MessageBox.Show("                       Güle Güle Yine Bekleriz :)", "Çıkmak İstediğinizden Emin Misiniz?", MessageBoxButtons.YesNo);
            if (kontrol == DialogResult.Yes)
            {
                Menu formkapa = new Menu();
                formkapa.Close();
                frm.Ac("login");
                this.Hide();
            }
        }
    }
}

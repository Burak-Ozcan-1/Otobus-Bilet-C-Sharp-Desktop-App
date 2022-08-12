using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet
{
    public class FormAc
    {
        public void Ac(string acilacak_form)
        {
            Form frm = (Form)Assembly.GetExecutingAssembly().CreateInstance("Bilet." + acilacak_form);
            frm.Show();
            //frm.Hide();
        }
        public void BayBayanBiletSat_Ac(string[] x)
        {
            BayBayanBiletSat frm = new BayBayanBiletSat();
            frm.my_biletlerim = x;
            frm.Show();
        }
        public void BayBayanBiletRezervasyon_Ac(string[] x)
        {
            BayBayanRezervasyon frm = new BayBayanRezervasyon();
            frm.my_biletlerim = x;
            frm.Show();
        }
        //public void BayBayanBiletDuzeltme_Ac(string[] x)
        //{
        //    BayBayanBiletDüzeltme frm = new BayBayanBiletDüzeltme();
        //    frm.my_biletlerim = x;
        //    frm.Show();
        //}
    }
}

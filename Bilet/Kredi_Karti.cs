//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bilet
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kredi_Karti
    {
        public int kredi_karti_id { get; set; }
        public Nullable<int> bilet_id { get; set; }
        public string kart_no { get; set; }
        public string kart_sahibi_adi_soyadi { get; set; }
        public string son_kullanma_tarihi { get; set; }
        public string guvenlik_kodu { get; set; }
        public string islem_tarih { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word; // yeni
using System.Reflection;
namespace Bilet
{
    public class Bilet_Dokum_Islemleri
    {
        public void biletdok(string gidecegi_yer, DateTime hareket_tarihi, string hareket_saati, string koltuk_no, decimal fiyat, string yolcu_adi_soyadi, string peron, string duzenleyen_kisi, string duzenleme_yeri, string duzenleme_tarihi)
        {
            string pWordDoc = @"C:\Users\burak\Desktop\Bilet\Bilet\Cıktı\otobus_bileti.docx"; // Dosya Uzantısı
            string pValue = " "; // Değiştirilecek Değer
            List<string> pMergeField = new List<string>(); // Değerler Listesi
            pMergeField.Add("GidecegiYer");
            pMergeField.Add("HareketTarihi");
            pMergeField.Add("HareketSaati");
            pMergeField.Add("KoltukNo");
            pMergeField.Add("Fiyat₺");
            pMergeField.Add("YolcuAdiSoyadi");
            pMergeField.Add("Peron");
            pMergeField.Add("DuzenleyenKisi");
            pMergeField.Add("DuzenlemeYeri");
            pMergeField.Add("DuzenlemeTarihi");

            Object oMissing = System.Reflection.Missing.Value;
            Object oTrue = true;
            Object oFalse = false;
            Word.Application oWord = new Word.Application();
            Word.Document oWordDoc = new Word.Document();
            oWord.Visible = true;
            Object oTemplatePath = pWordDoc;

            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
            foreach (Word.Field myMergeField in oWordDoc.Fields)
            {
                Word.Range rngFieldCode = myMergeField.Code;
                String fieldText = rngFieldCode.Text;
                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    Int32 endMerge = fieldText.IndexOf("\\");
                    Int32 fieldNameLength = fieldText.Length - endMerge;
                    String fieldName = fieldText.Substring(11, endMerge - 11);
                    fieldName = fieldName.Trim();
                    for (int i = 0; i < pMergeField.Count(); i++)
                    {
                        if (fieldName == pMergeField[i])
                        {
                            if (pMergeField[i] == "GidecegiYer")
                            {
                                pValue = gidecegi_yer;//"Ankara";
                            }
                            else if (pMergeField[i] == "HareketTarihi")
                            {
                                pValue = hareket_tarihi.ToShortDateString();//"09.06.2016";
                            }
                            else if (pMergeField[i] == "HareketSaati")
                            {
                                pValue = hareket_saati;//"09.06.2016";
                            }
                            else if (pMergeField[i] == "KoltukNo")
                            {
                                pValue = koltuk_no;//"15";
                            }
                            else if (pMergeField[i] == "Fiyat₺")
                            {
                                pValue = Convert.ToString(fiyat);//"55";
                            }
                            else if (pMergeField[i] == "YolcuAdiSoyadi")
                            {
                                pValue = yolcu_adi_soyadi;//"Burak Özcan";
                            }
                            else if (pMergeField[i] == "Peron")
                            {
                                pValue = peron;//"55";
                            }
                            else if (pMergeField[i] == "DuzenleyenKisi")
                            {
                                pValue = duzenleyen_kisi;//"Kemal Kızar";
                            }
                            else if (pMergeField[i] == "DuzenlemeYeri")
                            {
                                pValue = duzenleme_yeri;//"Ankara";
                            }
                            else if (pMergeField[i] == "DuzenlemeTarihi")
                            {
                                pValue = duzenleme_tarihi;//"09.06.2016";
                            }
                            myMergeField.Select();
                            oWord.Selection.TypeText(pValue);
                        }
                    }
                }
            }
        }
    }
}

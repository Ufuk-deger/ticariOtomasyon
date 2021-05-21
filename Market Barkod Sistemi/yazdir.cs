﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Market_Barkod_Sistemi
{
    class yazdir
    {
        public int? IslemNo { get; set; }
        public yazdir(int? islemNo)
        {
            IslemNo = islemNo;
        }
        PrintDocument pd = new PrintDocument();
        public void YazdirmayaBasla()
        {
            try
            {
                pd.PrintPage += Pd_PrintPage;
                pd.Print();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
        }
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            marketBarkodSistemiDatabaseEntities2 db = new marketBarkodSistemiDatabaseEntities2();
            var isyeri = db.Sabit.FirstOrDefault();
            var satisListesi = db.Satis.Where(x => x.IslemNo == IslemNo).ToList();
            if (isyeri!=null && satisListesi!= null)
            {
                int kagitUzunluk = 120;
                for (int i = 0; i < satisListesi.Count; i++)
                {
                    kagitUzunluk += 15;
                }
                PaperSize paperSize58 = new PaperSize("58mm Termal", 220, kagitUzunluk + 120);
                pd.DefaultPageSettings.PaperSize = paperSize58;

                Font fontBaslik = new Font("Calibri", 10, FontStyle.Bold);
                Font fontBilgi = new Font("Calibri", 8, FontStyle.Bold);
                Font fontIcerikBaslik = new Font("Calibri", 8, FontStyle.Underline);
                StringFormat ortala = new StringFormat(StringFormatFlags.FitBlackBox);
                ortala.Alignment = StringAlignment.Center;
                RectangleF rcUnvanKonum = new RectangleF(0, 20, 220, 20);
                e.Graphics.DrawString(isyeri.Unvan, fontBaslik, Brushes.Black, rcUnvanKonum, ortala);
                e.Graphics.DrawString("Telefon :" + isyeri.Telefon, fontBilgi, Brushes.Black, new Point(5, 45));
                e.Graphics.DrawString("İşlem No :" + IslemNo.ToString(), fontBilgi, Brushes.Black, new Point(5, 60));
                e.Graphics.DrawString("Tarih :" + DateTime.Now, fontBilgi, Brushes.Black, new Point(5, 75));
                e.Graphics.DrawString("----------------------------------------------------------", fontBilgi, Brushes.Black, new Point(5, 90));

                e.Graphics.DrawString("Ürün Adı", fontIcerikBaslik, Brushes.Black, new Point(5, 105));
                e.Graphics.DrawString("Miktar", fontIcerikBaslik, Brushes.Black, new Point(100, 105));
                e.Graphics.DrawString("Fiyat", fontIcerikBaslik, Brushes.Black, new Point(140, 105));
                e.Graphics.DrawString("Tutar", fontIcerikBaslik, Brushes.Black, new Point(180, 105));

                int yukseklik = 120;
                double genelToplam = 0;
                foreach (var item in satisListesi)
                {
                    e.Graphics.DrawString(item.UrunAd, fontBilgi, Brushes.Black, new Point(5, yukseklik));
                    e.Graphics.DrawString(item.Miktar.ToString(), fontBilgi, Brushes.Black, new Point(100, yukseklik));
                    e.Graphics.DrawString(Convert.ToDouble(item.SatisFiyat).ToString("C2"), fontBilgi, Brushes.Black, new Point(140, yukseklik));
                    e.Graphics.DrawString(Convert.ToDouble(item.Toplam).ToString("C2"), fontBilgi, Brushes.Black, new Point(180, yukseklik));
                    yukseklik += 15;
                    genelToplam += Convert.ToDouble(item.Toplam);
                }
                e.Graphics.DrawString("----------------------------------------------------------", fontBilgi, Brushes.Black, new Point(5, yukseklik));
                e.Graphics.DrawString("TOPLAM :" + genelToplam.ToString("C2"), fontBaslik, Brushes.Black, new Point(5, yukseklik + 20));
                e.Graphics.DrawString("----------------------------------------------------------", fontBilgi, Brushes.Black, new Point(5, yukseklik + 40));
                e.Graphics.DrawString("(Mali Değeri Yoktur)", fontBilgi, Brushes.Black, new Point(5, yukseklik + 60));
               
            }
        }
    }
}

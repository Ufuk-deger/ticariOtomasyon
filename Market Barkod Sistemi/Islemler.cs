using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Market_Barkod_Sistemi
{
    static class Islemler
    {
        public static double doubleYap(string deger)
        {
            double sonuc;
            double.TryParse(deger,NumberStyles.Currency, CultureInfo.CurrentUICulture.NumberFormat, out sonuc);
            return Math.Round(sonuc, 2);
        }

        public static void stokAzalt(string barkod,double miktar)
        {
            if (barkod != "1111111111116")
            {
                using (var db = new marketBarkodSistemiDatabaseEntities2())
                {
                    var urunBilgisi = db.Urun.SingleOrDefault(x => x.Barkod == barkod);
                    urunBilgisi.Miktar -= miktar;
                    db.SaveChanges();
                }
            }            
        }

        public static void stokArtır(string barkod, double miktar)
        {
            if (barkod != "1111111111116")
            {
                using (var db = new marketBarkodSistemiDatabaseEntities2())
                {
                    var urunBilgisi = db.Urun.SingleOrDefault(x => x.Barkod == barkod);
                    urunBilgisi.Miktar += miktar;
                    db.SaveChanges();
                }
            }        
        }

        public static void dataGridDuzenle(DataGridView dgv)
        {
            if (dgv.Columns.Count>0)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    switch (dgv.Columns[i].HeaderText)
                    {
                        case "Id":
                            dgv.Columns[i].HeaderText = "Numara"; break;
                        case "UrunId":
                            dgv.Columns[i].HeaderText = "Ürün Numarası"; break;
                        case "UrunAd":
                            dgv.Columns[i].HeaderText = "Ürün Adı"; break;
                        case "IslemNo":
                            dgv.Columns[i].HeaderText = "İşlem No"; break;
                        case "AlisFiyatToplam":
                            dgv.Columns[i].HeaderText = "Alış Fiyat Toplam";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Aciklama":
                            dgv.Columns[i].HeaderText = "Açıklama"; break;
                        case "UrunGrup":
                            dgv.Columns[i].HeaderText = "Ürün Grubu"; break;
                        case "AlisFiyat":
                            dgv.Columns[i].HeaderText = "Alış Fiyatı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "SatisFiyat":
                            dgv.Columns[i].HeaderText = "Satış Fiyatı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "KdvOrani":
                            dgv.Columns[i].HeaderText = "KDV Oranı"; break;
                        case "KdvTutari":
                            dgv.Columns[i].HeaderText = "KDV Tutarı"; break;
                        case "Kullanici":
                            dgv.Columns[i].HeaderText = "Kullanıcı"; break;
                        case "UrunID":
                            dgv.Columns[i].HeaderText = "Ürün Numarası"; break;
                        case "Iade":
                            dgv.Columns[i].HeaderText = "İade"; break;
                        case "Birim":
                            dgv.Columns[i].HeaderText = "Birim";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Miktar":
                            dgv.Columns[i].HeaderText = "Miktar";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "OdemeSekli":
                            dgv.Columns[i].HeaderText = "Ödeme Şekli";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Nakit":
                            dgv.Columns[i].HeaderText = "Nakit";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "Kart":
                            dgv.Columns[i].HeaderText = "Kart";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                    }
                }
            }
        }

        public static void stokHareket(string barkod,string urunAd,string birim,double miktar,string urunGrup,string kullanici)
        {
            using (var db=new marketBarkodSistemiDatabaseEntities2())
            {
                StokHareket sh = new StokHareket();
                sh.Barkod = barkod;
                sh.UrunAd = urunAd;
                sh.UrunGrup = urunGrup;
                sh.Birim = birim;
                sh.Miktar = miktar;
                sh.Kullanici = kullanici;
                sh.Tarih = DateTime.Now;
                db.StokHareket.Add(sh);
                db.SaveChanges();
            }
        }

        public static int kartKomisyon()
        {
            int sonuc = 0;
            using (var db= new marketBarkodSistemiDatabaseEntities2())
            {
                if (db.Sabit.Any())
                {
                    sonuc = Convert.ToInt16(db.Sabit.First().KartKomisyon);
                }
                else
                {
                    sonuc = 0;
                }
                return sonuc;
            }
        }

        public static void sabitVarsayılan()
        {
            using (var db=new marketBarkodSistemiDatabaseEntities2())
            {
                if (!db.Sabit.Any())
                {
                    Sabit sabitModel = new Sabit();
                    sabitModel.KartKomisyon = 0;
                    sabitModel.Yazici = false;
                    sabitModel.Adres = "admin";
                    sabitModel.Unvan = "admin";
                    sabitModel.AdSoyad = "admin";
                    sabitModel.Telefon = "admin";
                    sabitModel.Eposta = "admin";
                    db.Sabit.Add(sabitModel);
                    db.SaveChanges();
                }
                
            }
        }

        public static void backup()
        {
            SaveFileDialog saveBackup = new SaveFileDialog();
            saveBackup.Filter = "Veritabanı Yedek Dosyası|0.bak";
            saveBackup.FileName = "Barkodlu_Satis_Programi_" + DateTime.Now.ToShortDateString();
            if (saveBackup.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (File.Exists(saveBackup.FileName))
                    {
                        File.Delete(saveBackup.FileName);
                    }
                    var dbHedef = saveBackup.FileName;
                    string dbKaynak = Application.StartupPath + @"\marketBarkodSistemiDatabase.mdf";
                    using (var db=new marketBarkodSistemiDatabaseEntities2())
                    {
                        var cmd = @"BACKUP DATABASE[" + dbKaynak + "] TO DISK='" + dbHedef + "'";
                        db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd);
                    }
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Yedekleme Başarılı");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
            }
        }
    }
}

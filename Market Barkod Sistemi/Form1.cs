using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Market_Barkod_Sistemi
{
    public partial class Form1 : Form
    {
        marketBarkodSistemiDatabaseEntities2 db = new marketBarkodSistemiDatabaseEntities2();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hizliButtonDoldur();
            buttonPara5.Text = 5.ToString("C2");
            buttonPara10.Text = 10.ToString("C2");
            buttonPara20.Text = 20.ToString("C2");
            buttonPara50.Text = 50.ToString("C2");
            buttonPara100.Text = 100.ToString("C2");
            buttonPara200.Text = 200.ToString("C2");
            using (var db=new marketBarkodSistemiDatabaseEntities2())
            {
                var sabit = db.Sabit.FirstOrDefault();
                checkBoxYazdirmaDurmu.Checked = Convert.ToBoolean(sabit.Yazici);
            }
        }

        private void hizliButtonDoldur()
        {
            var hizliUrun = db.hizliUrun.ToList();
            foreach (var item in hizliUrun)
            {
                Button buttonHizli = this.Controls.Find("bH" + item.Id, true).FirstOrDefault() as Button;
                if (buttonHizli != null)
                {
                    double fiyat = Islemler.doubleYap(item.Fiyat.ToString());
                    buttonHizli.Text = item.UrunAd + "\n" + fiyat.ToString("C2");
                }
            }
        }

        private void hizliButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int buttonId = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));

            if (b.Text.ToString().StartsWith("-"))
            {
                formHizliButtonUrunEkle formUrunEkle = new formHizliButtonUrunEkle();
                formUrunEkle.labelButtonId.Text = buttonId.ToString();
                formUrunEkle.ShowDialog();
            }
            else
            {
                var urunBarkod = db.hizliUrun.Where(a => a.Id == buttonId).Select(a => a.Barkod).FirstOrDefault();
                var urun = db.Urun.Where(a => a.Barkod == urunBarkod).FirstOrDefault();
                urunGetirListeye(urun, urunBarkod, Convert.ToDouble(textBoxMiktar.Text));
                genelToplam();
            }

        }

        private void textBoxBarkodGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = textBoxBarkodGiris.Text.Trim();
                if (barkod.Length <= 2)
                {
                    textBoxMiktar.Text = barkod;
                    textBoxBarkodGiris.Focus();
                    textBoxBarkodGiris.Clear();
                }
                else
                {
                    if (db.Urun.Any(a => a.Barkod == barkod))
                    {
                        var urun = db.Urun.Where(a => a.Barkod == barkod).FirstOrDefault();
                        urunGetirListeye(urun, barkod, Convert.ToDouble(textBoxMiktar.Text));
                    }
                    else
                    {
                        int onEk = Convert.ToInt16(barkod.Substring(0, 2));
                        if (db.Terazi.Any(a => a.teraziOnEk == onEk))
                        {
                            string teraziUrunNo = barkod.Substring(2, 5);
                            if (db.Urun.Any(a => a.Barkod == teraziUrunNo))
                            {
                                var urunTerazi = db.Urun.Where(a => a.Barkod == teraziUrunNo).FirstOrDefault();
                                double miktarKg = Convert.ToDouble(barkod.Substring(7, 5)) / 1000;
                                urunGetirListeye(urunTerazi, teraziUrunNo, miktarKg);
                            }
                            else
                            {
                                Console.Beep(1500, 750);
                                MessageBox.Show("KG Ürün Ekleme Sayfası");
                            }


                        }
                        else
                        {
                            Console.Beep(1500, 750);
                            formUrunGiris formUrunGirisAc = new formUrunGiris();
                            formUrunGirisAc.textBoxBarkod.Text = barkod;
                            formUrunGirisAc.ShowDialog();
                        }
                    }
                }
                dataGridViewSatisListesi.ClearSelection();
                genelToplam();
            }
        }

        private void urunGetirListeye(Urun urun, string barkod, double miktar)
        {
            int satirSayisi = dataGridViewSatisListesi.Rows.Count;
            //double miktar = Convert.ToDouble(textBoxMiktar.Text);
            bool eklenmismi = false;
            if (satirSayisi > 0)
            {
                for (int i = 0; i < satirSayisi; i++)
                {
                    if (dataGridViewSatisListesi.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                    {
                        dataGridViewSatisListesi.Rows[i].Cells["miktar"].Value = miktar + Convert.ToDouble(dataGridViewSatisListesi.Rows[i].Cells["miktar"].Value);
                        dataGridViewSatisListesi.Rows[i].Cells["toplam"].Value = Math.Round(Convert.ToDouble(dataGridViewSatisListesi.Rows[i].Cells["miktar"].Value) * Convert.ToDouble(dataGridViewSatisListesi.Rows[i].Cells["fiyat"].Value), 2);
                        double kdvTutar = (double)urun.KdvTutari;
                        dataGridViewSatisListesi.Rows[i].Cells["kdvTutari"].Value = Convert.ToDouble(dataGridViewSatisListesi.Rows[i].Cells["miktar"].Value) * kdvTutar;
                        eklenmismi = true;
                    }
                }

            }
            if (!eklenmismi)
            {
                dataGridViewSatisListesi.Rows.Add();
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["Barkod"].Value = barkod;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["urunAd"].Value = urun.UrunAd;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["urunGrup"].Value = urun.UrunGrup;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["birim"].Value = urun.Birim;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["fiyat"].Value = urun.SatisFiyat;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["alisFiyat"].Value = urun.AlisFiyat;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["kdvTutari"].Value = urun.KdvTutari;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["miktar"].Value = miktar;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["toplam"].Value = Math.Round(miktar * (double)urun.SatisFiyat, 2);
            }
        }

        private void genelToplam()
        {
            double toplam = 0;
            for (int i = 0; i < dataGridViewSatisListesi.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(dataGridViewSatisListesi.Rows[i].Cells["toplam"].Value);
            }
            textBoxGenelToplam.Text = toplam.ToString("C2");
            textBoxMiktar.Text = "1";
            textBoxBarkodGiris.Clear();
            textBoxBarkodGiris.Focus();
        }

        private void dataGridViewSatisListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                dataGridViewSatisListesi.Rows.Remove(dataGridViewSatisListesi.CurrentRow);
                dataGridViewSatisListesi.ClearSelection();
                genelToplam();
                textBoxBarkodGiris.Focus();
            }
        }

        private void buttonHizliMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button buttonSil = (Button)sender;
                if (!buttonSil.Text.StartsWith("-"))
                {
                    int buttonId = Convert.ToInt16(buttonSil.Name.ToString().Substring(2, buttonSil.Name.Length - 2));
                    ContextMenuStrip stripSil = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem();
                    sil.Text = "Temizle - Buton No :" + buttonId.ToString();
                    sil.Click += hizliButtondanVeriSil_Click;
                    stripSil.Items.Add(sil);
                    this.ContextMenuStrip = stripSil;
                }
            }
        }

        private void hizliButtondanVeriSil_Click(object sender, EventArgs e)
        {
            int buttonId = Convert.ToInt16(sender.ToString().Substring(20, sender.ToString().Length - 20));
            var hizliButtonSil = db.hizliUrun.Find(buttonId);
            double fiyat = 0;
            hizliButtonSil.Barkod = "-";
            hizliButtonSil.UrunAd = "-";
            hizliButtonSil.Fiyat = 0;
            db.SaveChanges();
            Button b = this.Controls.Find("bH" + buttonId, true).FirstOrDefault() as Button;
            b.Text = "-" + "\n" + fiyat.ToString("C2");
            MessageBox.Show("Buton Silme İşlemi Tamamlandı.");
        }

        private void buttonNumartator_Click(object sender, EventArgs e)
        {

            Button buttonNumarator = (Button)sender;
            if (buttonNumarator.Text == ",")
            {
                int virgul = textBoxNumarator.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    textBoxNumarator.Text += buttonNumarator.Text;
                }
            }
            else if (buttonNumarator.Text == "<")
            {
                if (textBoxNumarator.Text.Length > 0)
                {
                    textBoxNumarator.Text = textBoxNumarator.Text.Substring(0, textBoxNumarator.Text.Length - 1);
                }
            }
            else
            {
                textBoxNumarator.Text += buttonNumarator.Text;
            }
        }

        private void buttonAdet_Click(object sender, EventArgs e)
        {
            if (textBoxNumarator.Text != "")
            {
                textBoxMiktar.Text = textBoxNumarator.Text;
                textBoxNumarator.Clear();
                textBoxBarkodGiris.Clear();
                textBoxBarkodGiris.Focus();
            }
        }

        private void buttonOdenen_Click(object sender, EventArgs e)
        {
            if (textBoxNumarator.Text != "")
            {
                double paraUstu = Islemler.doubleYap(textBoxNumarator.Text) - Islemler.doubleYap(textBoxGenelToplam.Text);
                textBoxParaUstu.Text = paraUstu.ToString("C2");
                textBoxOdenen.Text = Islemler.doubleYap(textBoxNumarator.Text).ToString("C2");
                textBoxNumarator.Clear();
                textBoxBarkodGiris.Focus();
            }
        }

        private void buttonBarkod_Click(object sender, EventArgs e)
        {
            if (textBoxNumarator.Text != "")
            {
                if (db.Urun.Any(a => a.Barkod == textBoxNumarator.Text))
                {
                    var urunBarkodYazNumaratorden = db.Urun.Where(a => a.Barkod == textBoxNumarator.Text).FirstOrDefault();
                    urunGetirListeye(urunBarkodYazNumaratorden, textBoxNumarator.Text, Convert.ToDouble(textBoxMiktar.Text));
                    textBoxNumarator.Clear();
                    textBoxBarkodGiris.Focus();
                }

            }
        }

        private void paraUstuHesapla_Click(object sender, EventArgs e)
        {
            Button paraButonlari = (Button)sender;
            double paraUstuSonuc = Islemler.doubleYap(paraButonlari.Text) - Islemler.doubleYap(textBoxGenelToplam.Text);
            textBoxOdenen.Text = Islemler.doubleYap(paraButonlari.Text).ToString("C2");
            textBoxParaUstu.Text = paraUstuSonuc.ToString("C2");
        }

        private void buttonDigerUrun_Click(object sender, EventArgs e)
        {
            if (textBoxNumarator.Text != "")
            {
                int satirSayisi = dataGridViewSatisListesi.Rows.Count;
                dataGridViewSatisListesi.Rows.Add();
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["Barkod"].Value = "1111111111116";
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["urunAd"].Value = "Barkodsuz Ürün";
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["urunGrup"].Value = "Barkodsuz Ürün";
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["birim"].Value = "Adet";
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["miktar"].Value = 1;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["alisFiyat"].Value = 0;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["fiyat"].Value = Convert.ToDouble(textBoxNumarator.Text);
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["kdvTutari"].Value = 0;
                dataGridViewSatisListesi.Rows[satirSayisi].Cells["toplam"].Value = Convert.ToDouble(textBoxNumarator.Text);
                textBoxNumarator.Clear();
                genelToplam();
                textBoxBarkodGiris.Focus();
            }
        }

        private void buttonIade_Click(object sender, EventArgs e)
        {
            //if (checkBoxSatisIade.Checked)
            //{
            //    checkBoxSatisIade.Checked = false;
            //    checkBoxSatisIade.Text = "Satış Yapılıyor";
            //}
            //else
            //{
            //    checkBoxSatisIade.Checked = true;
            //    checkBoxSatisIade.Text = "İade İşlemi";
            //}

            formIskontoTutar formIskontoTutarAc = new formIskontoTutar();
            formIskontoTutarAc.ShowDialog();
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            temizlemeIslemi();
        }

        private void temizlemeIslemi()
        {
            textBoxMiktar.Text = "1";
            textBoxBarkodGiris.Clear();
            textBoxOdenen.Clear();
            textBoxParaUstu.Clear();
            textBoxGenelToplam.Text = 0.ToString("C2");
            checkBoxSatisIade.Checked = false;
            textBoxNumarator.Clear();
            dataGridViewSatisListesi.Rows.Clear();
            textBoxBarkodGiris.Focus();
        }

        public void satisYap(string odemeSekli)
        {
            int satirSayisi = dataGridViewSatisListesi.Rows.Count;
            bool satisIade = checkBoxSatisIade.Checked;
            double alisFiyatToplam = 0;
            if (satirSayisi > 0)
            {
                int? islemNo = db.Islem.First().islemNo;
                Satis satisModel = new Satis();

                for (int i = 0; i < satirSayisi; i++)
                {
                    satisModel.IslemNo = islemNo;
                    satisModel.UrunAd = dataGridViewSatisListesi.Rows[i].Cells["urunAd"].Value.ToString();
                    satisModel.UrunGrup = dataGridViewSatisListesi.Rows[i].Cells["urunGrup"].Value.ToString();
                    satisModel.Barkod = dataGridViewSatisListesi.Rows[i].Cells["Barkod"].Value.ToString();
                    satisModel.Birim = dataGridViewSatisListesi.Rows[i].Cells["birim"].Value.ToString();
                    satisModel.AlisFiyat = Islemler.doubleYap(dataGridViewSatisListesi.Rows[i].Cells["alisFiyat"].Value.ToString());
                    satisModel.SatisFiyat = Islemler.doubleYap(dataGridViewSatisListesi.Rows[i].Cells["fiyat"].Value.ToString());
                    satisModel.Miktar = Islemler.doubleYap(dataGridViewSatisListesi.Rows[i].Cells["miktar"].Value.ToString());
                    satisModel.Toplam = Islemler.doubleYap(dataGridViewSatisListesi.Rows[i].Cells["toplam"].Value.ToString());
                    satisModel.KdvTutari = Islemler.doubleYap(dataGridViewSatisListesi.Rows[i].Cells["kdvTutari"].Value.ToString()) * Islemler.doubleYap(dataGridViewSatisListesi.Rows[i].Cells["miktar"].Value.ToString());
                    satisModel.OdemeSekli = odemeSekli;
                    satisModel.Iade = satisIade;
                    satisModel.Tarih = DateTime.Now;
                    satisModel.Kullanici = labelKullanici.Text;
                    db.Satis.Add(satisModel);
                    db.SaveChanges();

                    if (!satisIade)
                    {
                        Islemler.stokAzalt(dataGridViewSatisListesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.doubleYap(dataGridViewSatisListesi.Rows[i].Cells["miktar"].Value.ToString()));

                    }
                    else
                    {
                        Islemler.stokArtır(dataGridViewSatisListesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.doubleYap(dataGridViewSatisListesi.Rows[i].Cells["miktar"].Value.ToString()));
                    }
                    alisFiyatToplam += Islemler.doubleYap(dataGridViewSatisListesi.Rows[i].Cells["alisFiyat"].Value.ToString())* Islemler.doubleYap(dataGridViewSatisListesi.Rows[i].Cells["miktar"].Value.ToString());

                }

                IslemOzet io = new IslemOzet();
                io.IslemNo = islemNo;
                io.Iade = satisIade;
                io.AlisFiyatToplam = alisFiyatToplam;
                io.Gelir = false;
                io.Gider = false;
                if (!satisIade)
                {
                    io.Aciklama = odemeSekli + " Satış";              
                }
                else
                {
                    io.Aciklama = "İade İşlemi (" + odemeSekli + ")";
                }
                io.OdemeSekli = odemeSekli;
                io.Kullanici = labelKullanici.Text;
                io.Tarih = DateTime.Now;
                switch (odemeSekli)
                {
                    case "Nakit":
                        io.Nakit = Islemler.doubleYap(textBoxGenelToplam.Text);
                        io.Kart = 0; break;
                    case "Kart":
                        io.Kart = Islemler.doubleYap(textBoxGenelToplam.Text);
                        io.Nakit = 0; break;
                    case "Kart-Nakit":
                        io.Nakit = Islemler.doubleYap(labelNakit.Text);
                        io.Kart = Islemler.doubleYap(labelKart.Text); break;
                }
                db.IslemOzet.Add(io);
                db.SaveChanges();

                var islemNoArtır = db.Islem.First();
                islemNoArtır.islemNo += 1;
                db.SaveChanges();
                if (checkBoxYazdirmaDurmu.Checked)
                {
                    yazdir yazdirClass = new yazdir(islemNo);
                    yazdirClass.YazdirmayaBasla();
                }
                temizlemeIslemi();
            }
        }

        private void buttonNakit_Click(object sender, EventArgs e)
        {
            satisYap("Nakit");
        }

        private void buttonKrediKartı_Click(object sender, EventArgs e)
        {
            satisYap("Kart");
        }

        private void buttonNakitKart_Click(object sender, EventArgs e)
        {
            formNakitKart formNakitKartAc = new formNakitKart();
            formNakitKartAc.ShowDialog();
        }

        private void textBoxBarkodGiris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void textBoxMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void textBoxNumarator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
  

            if (e.KeyCode == Keys.F1)
                satisYap("Nakit");

            if (e.KeyCode == Keys.F2)
                satisYap("Kart");
          
            if (e.KeyCode == Keys.F3)
            {
                formNakitKart formNakitKartAc = new formNakitKart();
                formNakitKartAc.ShowDialog();
            }
              
        }

        private void buttonIslemBeklet_Click(object sender, EventArgs e)
        {
            if (buttonIslemBeklet.Text=="İşlem Beklet")
            {
                ıslemBeklet();
                buttonIslemBeklet.BackColor = System.Drawing.Color.OrangeRed;
                dataGridViewSatisListesi.Rows.Clear();
                buttonIslemBeklet.Text = "İşlem Bekliyor";
            }
            else
            {
                beklemedenCık();
                buttonIslemBeklet.BackColor = System.Drawing.Color.DimGray;
                dataGridViewIslemBeklet.Rows.Clear();
                buttonIslemBeklet.Text = "İşlem Beklet";
            }
            
        }

        private void ıslemBeklet()
        {
            int satirSayisi = dataGridViewSatisListesi.Rows.Count;
            int sutunSayisi = dataGridViewSatisListesi.Columns.Count;
            if (satirSayisi>0)
            {
                for (int i = 0; i < satirSayisi; i++)
                {
                    dataGridViewIslemBeklet.Rows.Add();
                    for (int j = 0; j < sutunSayisi-1; j++)
                    {
                        dataGridViewIslemBeklet.Rows[i].Cells[j].Value = dataGridViewSatisListesi.Rows[i].Cells[j].Value;
                    }
                }
            }
        }

        private void beklemedenCık()
        {
            int satirSayisi = dataGridViewIslemBeklet.Rows.Count;
            int sutunSayisi = dataGridViewIslemBeklet.Columns.Count;
            if (satirSayisi > 0)
            {
                for (int i = 0; i < satirSayisi; i++)
                {
                    dataGridViewSatisListesi.Rows.Add();
                    for (int j = 0; j < sutunSayisi - 1; j++)
                    {
                        dataGridViewSatisListesi.Rows[i].Cells[j].Value = dataGridViewIslemBeklet.Rows[i].Cells[j].Value;
                    }
                }
            }
        }

        private void checkBoxSatisIade_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSatisIade.Checked)
            {
                checkBoxSatisIade.Text = "İade Yapılıyor";
            }
            else
            {
                checkBoxSatisIade.Text = "Satış Yapılıyor";
            }
        }

        private void textBoxBarkodGiris_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

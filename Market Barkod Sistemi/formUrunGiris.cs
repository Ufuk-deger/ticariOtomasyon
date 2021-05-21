using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_Barkod_Sistemi
{
    public partial class formUrunGiris : Form
    {
        public formUrunGiris()
        {
            InitializeComponent();
        }

        marketBarkodSistemiDatabaseEntities2 db = new marketBarkodSistemiDatabaseEntities2();

        private void formUrunGiris_Load(object sender, EventArgs e)
        {
            textBoxSecilenUrunSayisi.Text = db.Urun.Count().ToString();
            dataGridViewUrunEkleme.DataSource = db.Urun.OrderByDescending(a => a.UrunID).Take(20).ToList();
            Islemler.dataGridDuzenle(dataGridViewUrunEkleme);
            urunGrupDoldur();
        }

        public void urunGrupDoldur()
        {
            comboBoxUrunGrubu.DisplayMember = "UrunGrupAd";
            comboBoxUrunGrubu.ValueMember = "Id";
            comboBoxUrunGrubu.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).ToList();
        }

        private void textBoxBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                string barkod = textBoxBarkod.Text.Trim();
                if (db.Urun.Any(a=> a.Barkod == barkod))
                {
                    var urun = db.Urun.Where(a => a.Barkod == barkod).SingleOrDefault();
                    textBoxUrunAdi.Text = urun.UrunAd;
                    textBoxAciklama.Text = urun.Aciklama;
                    comboBoxUrunGrubu.Text = urun.UrunGrup;
                    textBoxAlisFiyati.Text = urun.AlisFiyat.ToString();
                    textBoxSatisFiyati.Text = urun.SatisFiyat.ToString();
                    textBoxMiktar.Text = urun.Miktar.ToString();
                    textBoxKdvOrani.Text = urun.KdvOrani.ToString();
                    if (urun.Birim=="KG")
                    {
                        checkBoxBarkodGramajGecis.Checked = true;
                    }
                    else
                    {
                        checkBoxBarkodGramajGecis.Checked = false;
                    }
                }
                else
                {

                }
            }
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (textBoxBarkod.Text!=""  && textBoxUrunAdi.Text!="" && comboBoxUrunGrubu.Text!="" && textBoxAlisFiyati.Text!="" && textBoxSatisFiyati.Text!="" && textBoxKdvOrani.Text!="" && textBoxMiktar.Text!="")
            {
                if (db.Urun.Any(a=> a.Barkod==textBoxBarkod.Text))
                {
                    var urunGuncelle = db.Urun.Where(a => a.Barkod == textBoxBarkod.Text).SingleOrDefault();
                    urunGuncelle.UrunAd = textBoxUrunAdi.Text;
                    urunGuncelle.Aciklama = textBoxAciklama.Text;
                    urunGuncelle.UrunGrup = comboBoxUrunGrubu.Text;
                    urunGuncelle.AlisFiyat = Convert.ToDouble(textBoxAlisFiyati.Text);
                    urunGuncelle.SatisFiyat = Convert.ToDouble(textBoxSatisFiyati.Text);
                    urunGuncelle.KdvOrani = Convert.ToInt16(textBoxKdvOrani.Text);
                    urunGuncelle.KdvTutari = Math.Round(Islemler.doubleYap(textBoxSatisFiyati.Text) * Convert.ToInt16(textBoxKdvOrani.Text) / 100, 2);
                    urunGuncelle.Miktar += Convert.ToDouble(textBoxMiktar.Text);
                    if (checkBoxBarkodGramajGecis.Checked)
                    {
                        urunGuncelle.Birim = "KG";
                    }
                    else
                    {
                        urunGuncelle.Birim = "Adet";
                    }                
                    urunGuncelle.Tarih = DateTime.Now;
                    urunGuncelle.Kullanici = labelKullanici.Text;
                    db.SaveChanges();

                    dataGridViewUrunEkleme.DataSource = db.Urun.OrderByDescending(a => a.UrunID).Take(10).ToList();

                }
                else
                {
                    Urun urunModel = new Urun();
                    urunModel.Barkod = textBoxBarkod.Text;
                    urunModel.UrunAd = textBoxUrunAdi.Text;
                    urunModel.Aciklama = textBoxAciklama.Text;
                    urunModel.UrunGrup = comboBoxUrunGrubu.Text;
                    urunModel.AlisFiyat = Convert.ToDouble(textBoxAlisFiyati.Text);
                    urunModel.SatisFiyat = Convert.ToDouble(textBoxSatisFiyati.Text);
                    urunModel.KdvOrani = Convert.ToInt16(textBoxKdvOrani.Text);
                    urunModel.KdvTutari = Math.Round(Islemler.doubleYap(textBoxSatisFiyati.Text) * Convert.ToInt16(textBoxKdvOrani.Text) / 100, 2);
                    urunModel.Miktar = Convert.ToDouble(textBoxMiktar.Text);
                    if (checkBoxBarkodGramajGecis.Checked)
                    {
                        urunModel.Birim = "KG";
                    }
                    else
                    {
                        urunModel.Birim = "Adet";
                    }
                    urunModel.Tarih = DateTime.Now;
                    urunModel.Kullanici = labelKullanici.Text;
                    db.Urun.Add(urunModel);
                    db.SaveChanges();
                    if (textBoxBarkod.Text.Length==8)
                    {
                        var ozelBarkod = db.Barkod.First();
                        ozelBarkod.BarkodNo += 1;
                        db.SaveChanges();
                    }                                 
                    dataGridViewUrunEkleme.DataSource = db.Urun.OrderByDescending(a => a.UrunID).Take(20).ToList();
                    Islemler.dataGridDuzenle(dataGridViewUrunEkleme);
                }
                Islemler.stokHareket(textBoxBarkod.Text, textBoxUrunAdi.Text, "Adet", Convert.ToDouble(textBoxMiktar.Text), comboBoxUrunGrubu.Text, labelKullanici.Text);
                temizle();

            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz");
                textBoxBarkod.Focus();
            }
        }

        private void textBoxUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUrunAra.Text.Length >= 2)
            {
                string urunAd = textBoxUrunAra.Text;
                dataGridViewUrunEkleme.DataSource = db.Urun.Where(a => a.UrunAd.Contains(urunAd)).ToList();
                Islemler.dataGridDuzenle(dataGridViewUrunEkleme);
            }
        }

        private void temizle()
        {
            db.SaveChanges();
            textBoxAciklama.Clear();
            textBoxBarkod.Clear();
            textBoxUrunAdi.Clear();
            textBoxAlisFiyati.Text = "0";
            textBoxMiktar.Text = "0";
            textBoxSatisFiyati.Text = "0";
            textBoxKdvOrani.Text = "8";
            textBoxBarkod.Focus();
            checkBoxBarkodGramajGecis.Checked = false;
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void buttonUrunGrubuEkle_Click(object sender, EventArgs e)
        {
            formUrunGrubuEkleSil formUrunGrupEkleAc = new formUrunGrubuEkleSil();
            formUrunGrupEkleAc.ShowDialog();
        }

        private void buttonBarkodOlustur_Click(object sender, EventArgs e)
        {
            //var barkodNo = db.Barkod.First();
            //int karakter = barkodNo.BarkodNo.ToString().Length;
            //string sifirlar = string.Empty;
            //for (int i = 0; i < 8-karakter; i++)
            //{
            //    sifirlar = sifirlar + "0";
            //}
            //string olusanBarkod = sifirlar + barkodNo.BarkodNo.ToString();
            //textBoxBarkod.Text = olusanBarkod;

            //DateTime anlikZaman = DateTime.UtcNow.Date;
            //string barkodOlustur = anlikZaman.ToString("yyyy/MM/dd hh:mm:ss");

            string barkodOlustur = DateTime.Now.ToString("yyyyMMddhhmmss");
            textBoxBarkod.Text = barkodOlustur;
            textBoxUrunAdi.Focus();
        }

        private void textBoxSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)44 && e.KeyChar != (char)08 && e.KeyChar != (char)45)
            {
                e.Handled = true;
            }
        }

        private void textBoxAlisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)44 && e.KeyChar != (char)08 && e.KeyChar != (char)45)
            {
                e.Handled = true;
            }
        }

        private void textBoxMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)44 && e.KeyChar != (char)08 && e.KeyChar != (char)45)
            {
                e.Handled = true;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewUrunEkleme.Rows.Count>0)
            {
                int urunId = Convert.ToInt16(dataGridViewUrunEkleme.CurrentRow.Cells["UrunId"].Value.ToString());
                string urunAd = dataGridViewUrunEkleme.CurrentRow.Cells["UrunAd"].Value.ToString();
                string barkod = dataGridViewUrunEkleme.CurrentRow.Cells["Barkod"].Value.ToString();
                DialogResult onay = MessageBox.Show(urunAd + " Ürününü Silmek İstiyor musunuz?", "Ürün Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var urun = db.Urun.Find(urunId);
                    db.Urun.Remove(urun);
                    db.SaveChanges();
                    var hizliUrun = db.hizliUrun.Where(x => x.Barkod == barkod).SingleOrDefault();
                    hizliUrun.Barkod = "-";
                    hizliUrun.UrunAd = "-";
                    hizliUrun.Fiyat = 0;
                    db.SaveChanges();
                    MessageBox.Show("Ürün Silindi");
                    textBoxBarkod.Focus();
                    dataGridViewUrunEkleme.DataSource = db.Urun.OrderByDescending(a => a.UrunID).Take(20).ToList();

                }
            }
            
        }

        private void checkBoxBarkodGramajGecis_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBarkodGramajGecis.Checked)
            {
                checkBoxBarkodGramajGecis.Text = "Gramajlı Ürün İşlemi";
                buttonBarkodOlustur.Enabled = false;
            }
            else
            {
                checkBoxBarkodGramajGecis.Text = "Barkodlu Ürün İşlemi";
                buttonBarkodOlustur.Enabled = true;
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewUrunEkleme.Rows.Count>0)
            {
                textBoxBarkod.Text = dataGridViewUrunEkleme.CurrentRow.Cells["Barkod"].Value.ToString();
                textBoxUrunAdi.Text = dataGridViewUrunEkleme.CurrentRow.Cells["UrunAd"].Value.ToString();
                textBoxAciklama.Text = dataGridViewUrunEkleme.CurrentRow.Cells["Aciklama"].Value.ToString();
                comboBoxUrunGrubu.Text = dataGridViewUrunEkleme.CurrentRow.Cells["UrunGrup"].Value.ToString();
                textBoxAlisFiyati.Text = dataGridViewUrunEkleme.CurrentRow.Cells["AlisFiyat"].Value.ToString();
                textBoxSatisFiyati.Text = dataGridViewUrunEkleme.CurrentRow.Cells["SatisFiyat"].Value.ToString();
                textBoxKdvOrani.Text = dataGridViewUrunEkleme.CurrentRow.Cells["KdvOrani"].Value.ToString();
                textBoxMiktar.Text = dataGridViewUrunEkleme.CurrentRow.Cells["Miktar"].Value.ToString();
                string birim = dataGridViewUrunEkleme.CurrentRow.Cells["Birim"].Value.ToString();
                if (birim=="KG")
                {
                    checkBoxBarkodGramajGecis.Checked = true;
                }
                else
                {
                    checkBoxBarkodGramajGecis.Checked = false;
                }
            }

        }

        private void buttonRaporAl_Click(object sender, EventArgs e)
        {

        }
    }
}

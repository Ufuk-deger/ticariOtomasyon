using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_Barkod_Sistemi
{
    public partial class formAyarlar : Form
    {
        public formAyarlar()
        {
            InitializeComponent();
        }

        private void temizle()
        {
            textBoxAdSoyad.Clear();
            textBoxTelefon.Clear();
            textBoxSifre.Clear();
            textBoxEPosta.Clear();
            textBoxSifreTekrar.Clear();
            textBoxKullaniciAdi.Clear();
            checkBoxAyarlar.Checked = false;
            checkBoxFiyatGuncelle.Checked = false;
            checkBoxRaporEkrani.Checked = false;
            checkBoxSatisEkrani.Checked = false;
            checkBoxStok.Checked = false;
            checkBoxUrunGiris.Checked = false;
            checkBoxYedekleme.Checked = false;
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (buttonKaydet.Text == "Kaydet")
            {
                if (textBoxAdSoyad.Text != "" && textBoxTelefon.Text != "" && textBoxKullaniciAdi.Text != "" && textBoxSifre.Text != "" && textBoxSifreTekrar.Text != "")
                {
                    if (textBoxSifre.Text == textBoxSifreTekrar.Text)
                    {
                        try
                        {
                            using (var db = new marketBarkodSistemiDatabaseEntities2())
                            {
                                if (!db.Kullanici.Any(x => x.KullaniciAd == textBoxKullaniciAdi.Text))
                                {
                                    Kullanici kullaniciModel = new Kullanici();
                                    kullaniciModel.AdSoyad = textBoxAdSoyad.Text;
                                    kullaniciModel.Telefon = textBoxTelefon.Text;
                                    kullaniciModel.EPosta = textBoxEPosta.Text;
                                    kullaniciModel.KullaniciAd = textBoxKullaniciAdi.Text;
                                    kullaniciModel.Sifre = textBoxSifre.Text;

                                    kullaniciModel.Satis = checkBoxSatisEkrani.Checked;
                                    kullaniciModel.Rapor = checkBoxRaporEkrani.Checked;
                                    kullaniciModel.Ayarlar = checkBoxAyarlar.Checked;
                                    kullaniciModel.Stok = checkBoxStok.Checked;
                                    kullaniciModel.FiyatGuncelle = checkBoxFiyatGuncelle.Checked;
                                    kullaniciModel.Yedekleme = checkBoxYedekleme.Checked;
                                    kullaniciModel.UrunGiris = checkBoxUrunGiris.Checked;
                                    db.Kullanici.Add(kullaniciModel);
                                    db.SaveChanges();
                                    Doldur();
                                    temizle();

                                }
                                else
                                {
                                    MessageBox.Show("Bu Kullanıcı Zaten Kayıtlı");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata Oluştu" + ex.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz" + "\n*Ad Soyad" + "\n*Telefon" + "\n*Kullanıcı Adı" + "\n*Şifre" + "\n*Şifre Tekrar");
                }
            }
            else if (buttonKaydet.Text == "Düzenle/Kaydet")
            {
                if (textBoxAdSoyad.Text != "" && textBoxTelefon.Text != "" && textBoxKullaniciAdi.Text != "" && textBoxSifre.Text != "" && textBoxSifreTekrar.Text != "")
                {
                    if (textBoxSifre.Text == textBoxSifreTekrar.Text)
                    {
                        int id = Convert.ToInt32(labelId.Text);
                        using (var db = new marketBarkodSistemiDatabaseEntities2())
                        {
                            var guncelle = db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                            guncelle.AdSoyad = textBoxAdSoyad.Text;
                            guncelle.Telefon = textBoxTelefon.Text;
                            guncelle.EPosta = textBoxEPosta.Text;
                            guncelle.KullaniciAd = textBoxKullaniciAdi.Text;
                            guncelle.Sifre = textBoxSifre.Text;

                            guncelle.Satis = checkBoxSatisEkrani.Checked;
                            guncelle.Rapor = checkBoxRaporEkrani.Checked;
                            guncelle.Ayarlar = checkBoxAyarlar.Checked;
                            guncelle.Stok = checkBoxStok.Checked;
                            guncelle.FiyatGuncelle = checkBoxFiyatGuncelle.Checked;
                            guncelle.Yedekleme = checkBoxYedekleme.Checked;
                            guncelle.UrunGiris = checkBoxUrunGiris.Checked;
                            db.SaveChanges();
                            MessageBox.Show("Güncelleme Başarılı");
                            buttonKaydet.Text = "Kaydet";
                            temizle();
                            Doldur();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Uyuşmuyor");
                }
            }

        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewKullanici.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewKullanici.CurrentRow.Cells["Id"].Value.ToString());
                labelId.Text = id.ToString();
                using (var db = new marketBarkodSistemiDatabaseEntities2())
                {
                    var getir = db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                    textBoxAdSoyad.Text = getir.AdSoyad;
                    textBoxEPosta.Text = getir.EPosta;
                    textBoxKullaniciAdi.Text = getir.KullaniciAd;
                    textBoxTelefon.Text = getir.Telefon;
                    textBoxSifre.Text = getir.Sifre;
                    textBoxSifreTekrar.Text = getir.Sifre;
                    checkBoxAyarlar.Checked = (bool)getir.Ayarlar;
                    checkBoxFiyatGuncelle.Checked = (bool)getir.FiyatGuncelle;
                    checkBoxRaporEkrani.Checked = (bool)getir.Rapor;
                    checkBoxSatisEkrani.Checked = (bool)getir.Satis;
                    checkBoxStok.Checked = (bool)getir.Stok;
                    checkBoxUrunGiris.Checked = (bool)getir.UrunGiris;
                    checkBoxYedekleme.Checked = (bool)getir.Yedekleme;
                    buttonKaydet.Text = "Düzenle/Kaydet";
                    Doldur();

                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Seçiniz");
            }
        }

        private void formAyarlar_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Doldur();
            Cursor.Current = Cursors.Default;
        }

        private void Doldur()
        {
            using (var db = new marketBarkodSistemiDatabaseEntities2())
            {
                if (db.Kullanici.Any())
                {
                    dataGridViewKullanici.DataSource = db.Kullanici.Select(x => new { x.Id, x.AdSoyad, x.KullaniciAd, x.Telefon }).ToList();
                   
                }
                Islemler.sabitVarsayılan();
                var yazici = db.Sabit.FirstOrDefault();
                checkBoxYaziciAktif.Checked = (bool)yazici.Yazici;

                var sabitler = db.Sabit.FirstOrDefault();
                textBoxKartKomisyon.Text = sabitler.KartKomisyon.ToString();

                var teraziOnEk = db.Terazi.ToList();
                comboBoxTeraziOnEk.ValueMember="teraziOnEK";
                comboBoxTeraziOnEk.ValueMember = "Id";
                comboBoxTeraziOnEk.DataSource = teraziOnEk;

                textBoxIsyeriAdSoyad.Text = sabitler.AdSoyad;
                textBoxUnvan.Text = sabitler.Unvan;
                textBoxAdres.Text = sabitler.Adres;
                textBoxIsTelefon.Text = sabitler.Telefon;
                textBoxIsEPosta.Text = sabitler.Eposta;
                
               

            }
        }

        private void checkBoxYaziciAktif_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new marketBarkodSistemiDatabaseEntities2())
            {
                if (checkBoxYaziciAktif.Checked)
                {
                    Islemler.sabitVarsayılan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = true;
                    db.SaveChanges();
                    checkBoxYaziciAktif.Text = "Yazma Durumu Aktif";
                }
                else
                {
                    Islemler.sabitVarsayılan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = false;
                    db.SaveChanges();
                    checkBoxYaziciAktif.Text = "Yazma Durumu Pasif";
                }
            }
        }

        private void buttonKomisyonEkle_Click(object sender, EventArgs e)
        {
            if (textBoxKartKomisyon.Text != "")
            {
                using (var db = new marketBarkodSistemiDatabaseEntities2())
                {
                    var sabit = db.Sabit.FirstOrDefault();
                    sabit.KartKomisyon = Convert.ToInt16(textBoxKartKomisyon.Text);
                    db.SaveChanges();
                    MessageBox.Show("Kart Komisyon Ayarlandı");
                }
            }
            else
            {
                MessageBox.Show("Kart Komisyon Bilgisi Giriniz");
            }
        }

        private void buttonTeraziOnEkKaydet_Click(object sender, EventArgs e)
        {
            if (textBoxTeraziOnEk.Text != "")
            {
                int onEk = Convert.ToInt16(textBoxTeraziOnEk.Text);
                using (var db=new marketBarkodSistemiDatabaseEntities2())
                {
                    if (db.Terazi.Any(x=> x.teraziOnEk==onEk))
                    {
                        MessageBox.Show(onEk.ToString() + " Ön Ek Zaten Kayıtlı");
                    }
                    else
                    {
                        Terazi teraziOnEkEkle = new Terazi();
                        teraziOnEkEkle.teraziOnEk = onEk;
                        db.Terazi.Add(teraziOnEkEkle);
                        db.SaveChanges();
                        MessageBox.Show("Ön Ek Kaydedilmiştir");
                        comboBoxTeraziOnEk.DisplayMember = "teraziOnEk";
                        comboBoxTeraziOnEk.ValueMember = "Id";
                        comboBoxTeraziOnEk.DataSource = db.Terazi.ToList();
                        textBoxTeraziOnEk.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Terazi Ön Ek Bilgisi Giriniz");
            }
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void buttonTeraziOnEkSil_Click(object sender, EventArgs e)
        {
            if (comboBoxTeraziOnEk.Text!="")
            {
                int onEkId = Convert.ToInt16(comboBoxTeraziOnEk.SelectedValue);
                DialogResult onay = MessageBox.Show(comboBoxTeraziOnEk.Text + " Ön Ekini Silmek İstiyor musunuz?","Silme Onayı",MessageBoxButtons.YesNo);
                if (onay==DialogResult.Yes)
                {
                    using (var db=new marketBarkodSistemiDatabaseEntities2())
                    {
                        var onEk = db.Terazi.Find(onEkId);
                        db.Terazi.Remove(onEk);
                        db.SaveChanges();
                        comboBoxTeraziOnEk.DisplayMember = "teraziOnEk";
                        comboBoxTeraziOnEk.ValueMember = "Id";
                        comboBoxTeraziOnEk.DataSource = db.Terazi.ToList();
                        MessageBox.Show("Ön Ek Silinmiştir");
                    }
                }

            }
            else
            {
                MessageBox.Show("Ön Ek Seçiniz");
            }
        }

        private void buttonIsyeriKaydet_Click(object sender, EventArgs e)
        {
            if (textBoxIsyeriAdSoyad.Text != "" && textBoxIsEPosta.Text != "" && textBoxIsTelefon.Text != "" && textBoxUnvan.Text != "" && textBoxAdres.Text != "")
            {
                using (var db=new marketBarkodSistemiDatabaseEntities2())
                {
                    var isyeri = db.Sabit.FirstOrDefault();
                    isyeri.AdSoyad = textBoxIsyeriAdSoyad.Text;
                    isyeri.Unvan = textBoxUnvan.Text;
                    isyeri.Adres = textBoxAdres.Text;
                    isyeri.Telefon = textBoxIsTelefon.Text;
                    isyeri.Eposta = textBoxIsEPosta.Text;
                    db.SaveChanges();
                    MessageBox.Show("İşyeri Bilgileri Kaydedilmiştir");
                    var yeni = db.Sabit.FirstOrDefault();
                    textBoxIsyeriAdSoyad.Text = yeni.AdSoyad;
                    textBoxUnvan.Text = yeni.Unvan;
                    textBoxAdres.Text = yeni.Adres;
                    textBoxIsTelefon.Text = yeni.Telefon;
                    textBoxIsEPosta.Text = yeni.Eposta;
                }
            }
        }

        private void buttonYedegiYukle_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\Restore.exe");
            Application.Exit();
        }
    }
}

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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            girisYap();
        }
        private void girisYap()
        {
            if (textBoxKullaniciAdi.Text != "" && textBoxSifre.Text != "")
            {
                try
                {
                    using (var db = new marketBarkodSistemiDatabaseEntities2())
                    {
                        if (db.Kullanici.Any())
                        {
                            var giris = db.Kullanici.Where(x => x.KullaniciAd == textBoxKullaniciAdi.Text && x.Sifre == textBoxSifre.Text).FirstOrDefault();
                            if (giris != null)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                formBaslangic formBaslangicAc = new formBaslangic();
                                formBaslangicAc.buttonSatisIslemi.Enabled = (bool)giris.Satis;
                                formBaslangicAc.buttonStokTakibi.Enabled = (bool)giris.Stok;
                                formBaslangicAc.buttonUrunGiris.Enabled = (bool)giris.UrunGiris;
                                formBaslangicAc.buttonYedekleme.Enabled = (bool)giris.Yedekleme;
                                formBaslangicAc.buttonFiyatGuncelle.Enabled = (bool)giris.FiyatGuncelle;
                                formBaslangicAc.buttonAyarlar.Enabled = (bool)giris.Ayarlar;
                                formBaslangicAc.buttonRaporlar.Enabled = (bool)giris.Rapor;
                                formBaslangicAc.labelKullaniciBaslangic.Text = giris.AdSoyad;
                                var isyeri = db.Sabit.FirstOrDefault();
                                formBaslangicAc.labelIsyeri.Text = isyeri.Unvan;
                                formBaslangicAc.Show();
                                this.Hide();
                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Hatalı Giriş");
                            }


                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void formLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                girisYap();
            }
        }
    }
}

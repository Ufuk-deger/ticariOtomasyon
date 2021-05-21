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
    public partial class formFiyatGuncelle : Form
    {
        public formFiyatGuncelle()
        {
            InitializeComponent();
        }

        private void textBoxBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                using (var db=new marketBarkodSistemiDatabaseEntities2())
                {
                    if (db.Urun.Any(x=> x.Barkod==textBoxBarkod.Text.Trim()))
                    {
                        var getir = db.Urun.Where(x => x.Barkod == textBoxBarkod.Text).SingleOrDefault();
                        labelBarkod.Text = getir.Barkod;
                        labelUrunAdi.Text = getir.UrunAd;
                        double mevcutFiyat = Convert.ToDouble(getir.SatisFiyat);
                        labelFiyat.Text = mevcutFiyat.ToString("C2");
                    }
                    else
                    {
                        MessageBox.Show("Ürün Kayıtlı Değil");
                    }
                }
            }
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (textBoxYeniFiyat.Text!=""&& labelBarkod.Text!="")
            {
                using (var db=new marketBarkodSistemiDatabaseEntities2())
                {
                    var guncellenecek = db.Urun.Where(x => x.Barkod == labelBarkod.Text).SingleOrDefault();
                    guncellenecek.SatisFiyat = Islemler.doubleYap(textBoxYeniFiyat.Text);
                    int kdvOrani = Convert.ToInt16(guncellenecek.KdvOrani);
                    Math.Round(Islemler.doubleYap(textBoxYeniFiyat.Text) * Convert.ToInt16(kdvOrani) / 100, 2);
                    db.SaveChanges();
                    MessageBox.Show("Fiyat Kaydedilmiştir");
                    labelBarkod.Text = "";
                    labelUrunAdi.Text = "";
                    labelFiyat.Text = "";
                    textBoxYeniFiyat.Clear();
                    textBoxBarkod.Clear();
                    textBoxBarkod.Focus();
                }
            }
            else
            {
                MessageBox.Show("Ürün Okutunuz");
            }
        }

        private void formFiyatGuncelle_Load(object sender, EventArgs e)
        {
            labelBarkod.Text = "";
            labelUrunAdi.Text = "";
            labelFiyat.Text = "";
            textBoxBarkod.Focus();
        }
    }
}

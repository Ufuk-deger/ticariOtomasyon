using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_Barkod_Sistemi
{
    public partial class formStok : Form
    {
        public formStok()
        {
            InitializeComponent();
        }
        marketBarkodSistemiDatabaseEntities2 db2 = new marketBarkodSistemiDatabaseEntities2();
        private void buttonAra_Click(object sender, EventArgs e)
        {
            dataGridViewStok.DataSource = null;
            using (var db=new marketBarkodSistemiDatabaseEntities2())
            {
                if (comboBoxIslemTuru.Text!="")
                {
                    string urunGrubuText = comboBoxUrunGrubu.Text;
                    if (comboBoxIslemTuru.SelectedIndex==0)
                    {
                        if (radioButtonTumu.Checked)
                        {
                            db.Urun.OrderBy(x => x.Miktar).Load();
                            dataGridViewStok.DataSource = db.Urun.Local.ToBindingList();
                        }
                        else if (radioButtonUrunGrubunaGore.Checked)
                        {
                            db.Urun.Where(x => x.UrunGrup == urunGrubuText).OrderBy(x => x.Miktar).Load();
                            dataGridViewStok.DataSource = db.Urun.Local.ToBindingList();
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Filtreleme Türünü Seçiniz");
                        }
                    }
                    else if (comboBoxIslemTuru.SelectedIndex==1)
                    {
                        DateTime baslangicTarih = DateTime.Parse(dateTimePickerBaslangic.Value.ToShortDateString());
                        DateTime bitisTarih = DateTime.Parse(dateTimePickerBitis.Value.ToShortDateString());
                        bitisTarih = bitisTarih.AddDays(1);
                        if (radioButtonTumu.Checked)
                        {
                            db.StokHareket.OrderByDescending(x => x.Tarih).Where(x => x.Tarih >= baslangicTarih && x.Tarih <= bitisTarih).Load();
                            dataGridViewStok.DataSource = db.StokHareket.Local.ToBindingList();
                        }
                        else if (radioButtonUrunGrubunaGore.Checked)
                        {
                            db.StokHareket.OrderByDescending(x => x.Tarih).Where(x => x.Tarih >= baslangicTarih && x.Tarih <= bitisTarih && x.UrunGrup.Contains(urunGrubuText)).Load();
                            dataGridViewStok.DataSource = db.StokHareket.Local.ToBindingList();
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Filtreleme Türünü Seçiniz");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Lütfen İşlem Türünü Seçiniz");
                }
            }
            Islemler.dataGridDuzenle(dataGridViewStok);
        }

        private void formStok_Load(object sender, EventArgs e)
        {
            comboBoxUrunGrubu.DisplayMember = "UrunGrupAd";
            comboBoxUrunGrubu.ValueMember = "Id";
            comboBoxUrunGrubu.DataSource = db2.UrunGrup.ToList();
        }

        private void textBoxUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUrunAra.Text.Length>=2)
            {
                string urunAd = textBoxUrunAra.Text;
                using (var db=new marketBarkodSistemiDatabaseEntities2())
                {
                    if (comboBoxIslemTuru.SelectedIndex==0)
                    {
                        db.Urun.Where(x => x.UrunAd.Contains(urunAd)).Load();
                        dataGridViewStok.DataSource = db.Urun.Local.ToBindingList();
                    }
                    else if (comboBoxIslemTuru.SelectedIndex == 1)
                    {
                        db.StokHareket.Where(x => x.UrunAd.Contains(urunAd)).Load();
                        dataGridViewStok.DataSource = db.StokHareket.Local.ToBindingList();
                    }
                }
                Islemler.dataGridDuzenle(dataGridViewStok);
            }
        }

        private void buttonRaporAl_Click(object sender, EventArgs e)
        {
            if (comboBoxIslemTuru.SelectedIndex==0)
            {
                raporlar.Baslik = comboBoxIslemTuru.Text + " Raporu";
                raporlar.TarihBaslangic = dateTimePickerBaslangic.Value.ToShortDateString();
                raporlar.TarihBitis = dateTimePickerBitis.Value.ToShortDateString();
                raporlar.StokSayfasiRaporu(dataGridViewStok);
            }
            else if (comboBoxIslemTuru.SelectedIndex==1)
            {
                raporlar.Baslik = comboBoxIslemTuru.Text + " Raporu";
                raporlar.TarihBaslangic = dateTimePickerBaslangic.Value.ToShortDateString();
                raporlar.TarihBitis = dateTimePickerBitis.Value.ToShortDateString();
                raporlar.StokIzlemeRaporu(dataGridViewStok);
            }
            
        }
    }
}

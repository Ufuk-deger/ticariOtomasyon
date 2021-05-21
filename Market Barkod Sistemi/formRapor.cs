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
    public partial class formRapor : Form
    {
        public formRapor()
        {
            InitializeComponent();
        }

        public void buttonGoster_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime baslangic = DateTime.Parse(dateTimePickerBaslangic.Value.ToShortDateString());
            DateTime bitis = DateTime.Parse(dateTimePickerBitis.Value.ToShortDateString());
            bitis = bitis.AddDays(1);
            using (var db=new marketBarkodSistemiDatabaseEntities2())
            {
                if (listBoxFiltrelemeTuru.SelectedIndex==0)
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).OrderByDescending(x => x.Tarih).Load();
                    var islemOzet = db.IslemOzet.Local.ToBindingList();
                    dataGridViewRapor.DataSource = islemOzet;

                    textBoxSatisNakit.Text = Convert.ToDouble(islemOzet.Where(x => x.Iade == false && x.Gelir == false && x.Gider == false).Sum(x => x.Nakit)).ToString("C2");
                    textBoxSatisKart.Text = Convert.ToDouble(islemOzet.Where(x => x.Iade == false && x.Gelir == false && x.Gider == false).Sum(x => x.Kart)).ToString("C2");

                    textBoxIadeNakit.Text = Convert.ToDouble(islemOzet.Where(x => x.Iade == true).Sum(x => x.Nakit)).ToString("C2");
                    textBoxIadeKart.Text = Convert.ToDouble(islemOzet.Where(x => x.Iade == true).Sum(x => x.Kart)).ToString("C2");

                    textBoxGelirNakit.Text = Convert.ToDouble(islemOzet.Where(x => x.Gelir == true).Sum(s => s.Nakit)).ToString("C2");
                    textBoxGelirKart.Text = Convert.ToDouble(islemOzet.Where(x => x.Gelir == true).Sum(s => s.Kart)).ToString("C2");

                    textBoxGiderNakit.Text = Convert.ToDouble(islemOzet.Where(x => x.Gider == true).Sum(s => s.Nakit)).ToString("C2");
                    textBoxGiderKart.Text = Convert.ToDouble(islemOzet.Where(x => x.Gider == true).Sum(s => s.Kart)).ToString("C2");

                    db.Satis.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).Load();
                    var satisTablosu = db.Satis.Local.ToBindingList();
                    double kdvTutariSatis = Islemler.doubleYap(satisTablosu.Where(x => x.Iade == false).Sum(x => x.KdvTutari).ToString());
                    double kdvTutariIade = Islemler.doubleYap(satisTablosu.Where(x => x.Iade == true).Sum(x => x.KdvTutari).ToString());
                    textBoxKdvToplam.Text = (kdvTutariSatis - kdvTutariIade).ToString("C2");
                }
                else if (listBoxFiltrelemeTuru.SelectedIndex==1)
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Iade == false && x.Gelir == false && x.Gider == false).Load();
                    var islemOzet = db.IslemOzet.Local.ToBindingList();
                    dataGridViewRapor.DataSource = islemOzet;
                }
                else if (listBoxFiltrelemeTuru.SelectedIndex == 2)
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Iade == true).Load();
                    var islemOzet = db.IslemOzet.Local.ToBindingList();
                    dataGridViewRapor.DataSource = islemOzet;
                }
                else if (listBoxFiltrelemeTuru.SelectedIndex == 3)
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Gelir == true).Load();
                    var islemOzet = db.IslemOzet.Local.ToBindingList();
                    dataGridViewRapor.DataSource = islemOzet;
                }
                else if (listBoxFiltrelemeTuru.SelectedIndex == 4)
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Gider == true).Load();
                    var islemOzet = db.IslemOzet.Local.ToBindingList();
                    dataGridViewRapor.DataSource = islemOzet;
                }
            }
            Islemler.dataGridDuzenle(dataGridViewRapor);
            Cursor.Current = Cursors.Default;
        }

      

        private void formRapor_Load(object sender, EventArgs e)
        {
            listBoxFiltrelemeTuru.SelectedIndex = 0;
            textBoxKartKomisyon.Text = Islemler.kartKomisyon().ToString();
            buttonGoster_Click(null, null);
        }

        private void dataGridViewRapor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==2 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                if (e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? "Evet" : "Hayır";
                    e.FormattingApplied = true;
                }
            }

        }

        private void buttonGelirEkle_Click(object sender, EventArgs e)
        {
            formGelirGider formGelirGiderEkle = new formGelirGider();
            formGelirGiderEkle.gelirGider = "Gelir";
            formGelirGiderEkle.kullanici = labelKullanici.Text;
            formGelirGiderEkle.ShowDialog();
        }

        private void buttonGiderEkle_Click(object sender, EventArgs e)
        {
            formGelirGider formGelirGiderEkle = new formGelirGider();
            formGelirGiderEkle.gelirGider = "Gider";
            formGelirGiderEkle.kullanici = labelKullanici.Text;
            formGelirGiderEkle.ShowDialog();
        }

        private void detayGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewRapor.Rows.Count>0)
            {
                int islemNo = Convert.ToInt32(dataGridViewRapor.CurrentRow.Cells["IslemNo"].Value.ToString());
                if (islemNo!=0)
                {
                    formRaporDetayGoster formDetayGosterCagirma = new formRaporDetayGoster();
                    formDetayGosterCagirma.islemNoDetay = islemNo;
                    formDetayGosterCagirma.ShowDialog();
                }
            }

        }

        private void buttonRaporAl_Click(object sender, EventArgs e)
        {
            raporlar.Baslik = "Genel Rapor";
            raporlar.SatisKart = textBoxSatisKart.Text;
            raporlar.SatisNakit = textBoxSatisNakit.Text;
            raporlar.IadeKart = textBoxIadeKart.Text;
            raporlar.IadeNakit = textBoxIadeNakit.Text;
            raporlar.GelirKart = textBoxGelirKart.Text;
            raporlar.GelirNakit = textBoxGelirNakit.Text;
            raporlar.GiderKart = textBoxGiderKart.Text;
            raporlar.GiderNakit = textBoxGiderNakit.Text;
            raporlar.TarihBaslangic = dateTimePickerBaslangic.Value.ToShortDateString();
            raporlar.TarihBitis = dateTimePickerBitis.Value.ToShortDateString();
            raporlar.KdvToplam = textBoxKdvToplam.Text;
            raporlar.KartKomisyon = textBoxKartKomisyon.Text;
            raporlar.RaporSayfasiRaporu(dataGridViewRapor);
        }

       
    }
}

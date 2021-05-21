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
    public partial class formHizliButtonUrunEkle : Form
    {
        public formHizliButtonUrunEkle()
        {
            InitializeComponent();
        }

        marketBarkodSistemiDatabaseEntities2 db = new marketBarkodSistemiDatabaseEntities2();

        private void textBoxUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUrunAra.Text != "")
            {
                string urunAd = textBoxUrunAra.Text;
                var urunler = db.Urun.Where(a => a.UrunAd.Contains(urunAd)).ToList();
                dataGridViewUrunler.DataSource = urunler;
                Islemler.dataGridDuzenle(dataGridViewUrunler);
            }
        }

        private void dataGridViewUrunler_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewUrunler.Rows.Count > 0)
            {
                string barkod = dataGridViewUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                string urunAd = dataGridViewUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                double fiyat = Convert.ToDouble(dataGridViewUrunler.CurrentRow.Cells["SatisFiyat"].Value.ToString());
                int id = Convert.ToInt16(labelButtonId.Text);
                var guncellenecek = db.hizliUrun.Find(id);

                guncellenecek.Barkod = barkod;
                guncellenecek.UrunAd = urunAd;
                guncellenecek.Fiyat = fiyat;

                db.SaveChanges();
                MessageBox.Show("Buton Tanımlanmıştır.");

                Form1 formAna = (Form1)Application.OpenForms["Form1"];
                if (formAna != null)
                {
                    Button b = formAna.Controls.Find("bH" + id, true).FirstOrDefault() as Button;
                    b.Text = urunAd + "\n" + fiyat.ToString("C2");
                }
            }
        }

        private void checkBoxTumunuGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTumunuGoster.Checked)
            {
                dataGridViewUrunler.DataSource = db.Urun.ToList();
                dataGridViewUrunler.Columns["AlisFiyat"].Visible = false;
                dataGridViewUrunler.Columns["SatisFiyat"].Visible = false;
                dataGridViewUrunler.Columns["KdvOrani"].Visible = false;
                dataGridViewUrunler.Columns["KdvTutari"].Visible = false;
                dataGridViewUrunler.Columns["Miktar"].Visible = false;
                Islemler.dataGridDuzenle(dataGridViewUrunler);
            }
            else
            {
                dataGridViewUrunler.DataSource = null;
            }

        }

        private void formHizliButtonUrunEkle_Load(object sender, EventArgs e)
        {

        }
    }
}

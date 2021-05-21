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
    public partial class formGelirGider : Form
    {
        public formGelirGider()
        {
            InitializeComponent();
        }
        public string gelirGider { get; set; }
        public string kullanici { get; set; }
        private void formGelirGider_Load(object sender, EventArgs e)
        {
            labelGelirGider.Text = gelirGider + " İşlemi Yapılıyor";
        }

        private void comboBoxOdemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOdemeTuru.SelectedIndex==0)
            {
                textBoxNakit.Enabled = true;
                textBoxKart.Enabled = false;
            }
            else if (comboBoxOdemeTuru.SelectedIndex == 1)
            {
                textBoxNakit.Enabled = false;
                textBoxKart.Enabled = true;
            }
            else if (comboBoxOdemeTuru.SelectedIndex == 2)
            {
                textBoxNakit.Enabled = true;
                textBoxKart.Enabled = true;
            }
            textBoxKart.Text = "0";
            textBoxNakit.Text = "0";
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            if (comboBoxOdemeTuru.Text!="")
            {
                if (textBoxNakit.Text!="" && textBoxKart.Text!="")
                {
                    using (var db=new marketBarkodSistemiDatabaseEntities2())
                    {
                        IslemOzet io = new IslemOzet();
                        io.IslemNo = 0;
                        io.Iade = false;
                        io.OdemeSekli = comboBoxOdemeTuru.Text;
                        io.Nakit = Islemler.doubleYap(textBoxNakit.Text);
                        io.Kart = Islemler.doubleYap(textBoxKart.Text);
                        if (gelirGider == "Gelir")
                        {
                            io.Gelir = true;
                            io.Gider = false;
                        }
                        else
                        {
                            io.Gelir = false;
                            io.Gider = true;
                        }
                        io.AlisFiyatToplam = 0;
                        io.Aciklama = gelirGider + "- İşlemi " + textBoxAciklama.Text;
                        io.Tarih = dateTimePickerTarih.Value;
                        io.Kullanici = kullanici;
                        db.IslemOzet.Add(io);
                        db.SaveChanges();
                        MessageBox.Show(gelirGider + " İşlemi Kaydedildi");
                        textBoxKart.Text = "0";
                        textBoxNakit.Text = "0";
                        textBoxAciklama.Clear();
                        comboBoxOdemeTuru.Text = "";
                        formRapor f = (formRapor)Application.OpenForms["formRapor"];
                        if (f!=null)
                        {
                            f.buttonGoster_Click(null, null);
                        }
                        this.Hide();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Lütfen Ödeme Türünü Belirleyiniz");
            }
        }
    }
}

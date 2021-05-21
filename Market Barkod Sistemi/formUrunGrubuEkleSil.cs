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
    public partial class formUrunGrubuEkleSil : Form
    {
        public formUrunGrubuEkleSil()
        {
            InitializeComponent();
        }

        marketBarkodSistemiDatabaseEntities2 db = new marketBarkodSistemiDatabaseEntities2();

        private void formUrunGrubuEkleSil_Load(object sender, EventArgs e)
        {
            urunGrupDoldur();
        }

        private void buttonUrunGrupEkle_Click(object sender, EventArgs e)
        {
            if (textBoxUrunGrupAdı.Text!="")
            {
                UrunGrup urunGrupModel = new UrunGrup();
                urunGrupModel.UrunGrupAd = textBoxUrunGrupAdı.Text;
                db.UrunGrup.Add(urunGrupModel);
                db.SaveChanges();
                urunGrupDoldur();
                textBoxUrunGrupAdı.Clear();
                MessageBox.Show("Ürün Grubu Eklenmiştir");
                formUrunGiris urunGiris = (formUrunGiris)Application.OpenForms["formUrunGiris"];         
                if (urunGiris!=null)
                {
                    urunGiris.urunGrupDoldur();
                }

            }
            else
            {
                MessageBox.Show("Grup Bilgisi Ekleyiniz");
            }
        }

        private void urunGrupDoldur()
        {
            listBoxUrunGrup.DisplayMember = "UrunGrupAd";
            listBoxUrunGrup.ValueMember = "Id";
            listBoxUrunGrup.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).ToList();
        }

        private void buttonSecileniSil_Click(object sender, EventArgs e)
        {
            int grupId = Convert.ToInt32(listBoxUrunGrup.SelectedValue.ToString());
            string grupAd = listBoxUrunGrup.Text;
            DialogResult onay = MessageBox.Show(grupAd +" grubunu silmek istiyor musunuz ?","Silme İşlemi",MessageBoxButtons.YesNo);
            if (onay==DialogResult.Yes)
            {
                var urunGrup = db.UrunGrup.FirstOrDefault(x => x.Id == grupId);
                db.UrunGrup.Remove(urunGrup);
                db.SaveChanges();
                urunGrupDoldur();               
                textBoxUrunGrupAdı.Focus();
                MessageBox.Show(grupAd + " Ürün Grubu Silindi");
                formUrunGiris f = (formUrunGiris)Application.OpenForms["formUrunGiris"];
                f.urunGrupDoldur();
            }
        }
    }
}

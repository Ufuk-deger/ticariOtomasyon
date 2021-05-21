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
    public partial class formRaporDetayGoster : Form
    {
        public formRaporDetayGoster()
        {
            InitializeComponent();
        }
        public int islemNoDetay { get; set; }
        private void formRaporDetayGoster_Load(object sender, EventArgs e)
        {
            labelIslemNo.Text = "İşlem No : " + islemNoDetay.ToString();
            using (var db=new marketBarkodSistemiDatabaseEntities2())
            {
                dataGridViewDetay.DataSource = db.Satis.Select(s=> new {s.IslemNo,s.UrunAd,s.UrunGrup,s.Miktar,s.Toplam }).Where(x => x.IslemNo == islemNoDetay).ToList();
                Islemler.dataGridDuzenle(dataGridViewDetay);
            }
        }
    }
}

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
    public partial class formBaslangic : Form
    {
        public formBaslangic()
        {
            InitializeComponent();
        }

        private void buttonSatisIslemi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form1 formSatisGetir = new Form1();
            formSatisGetir.labelKullanici.Text = labelKullaniciBaslangic.Text;
            formSatisGetir.ShowDialog();
            Cursor.Current = Cursors.Default;

        }

        private void buttonRaporlar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            formRapor formRaporGetir = new formRapor();
            formRaporGetir.labelKullanici.Text = labelKullaniciBaslangic.Text;
            formRaporGetir.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void buttonStokTakibi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            formStok formStokAGetir = new formStok();
            formStokAGetir.labelKullanici.Text = labelKullaniciBaslangic.Text;
            formStokAGetir.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void buttonUrunGiris_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            formUrunGiris formUrunGirisGetir = new formUrunGiris();
            formUrunGirisGetir.labelKullanici.Text = labelKullaniciBaslangic.Text;
            formUrunGirisGetir.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void buttonAyarlar_Click(object sender, EventArgs e)
        {
            formAyarlar formAyarlarGetir = new formAyarlar();
            formAyarlarGetir.ShowDialog();
        }      

        private void buttonFiyatGuncelle_Click(object sender, EventArgs e)
        {
            formFiyatGuncelle formFiyatGuncelleGetir = new formFiyatGuncelle();
            formFiyatGuncelleGetir.ShowDialog();
        }
        
        private void buttonCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonKullaniciDegistir_Click(object sender, EventArgs e)
        {
            formLogin formLoginAc = new formLogin();
            formLoginAc.Show();
            this.Hide();
        }

        private void buttonYedekleme_Click(object sender, EventArgs e)
        {
            Islemler.backup();
        }
    }
}

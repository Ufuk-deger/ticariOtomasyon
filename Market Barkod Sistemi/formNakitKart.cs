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
    public partial class formNakitKart : Form
    {
        public formNakitKart()
        {
            InitializeComponent();
        }

        private void buttonNumartator_Click(object sender, EventArgs e)
        {

            Button buttonNumarator = (Button)sender;
            if (buttonNumarator.Text == ",")
            {
                int virgul = textBoxNakitMiktar.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    textBoxNakitMiktar.Text += buttonNumarator.Text;
                }
            }
            else if (buttonNumarator.Text == "<")
            {
                if (textBoxNakitMiktar.Text.Length > 0)
                {
                    textBoxNakitMiktar.Text = textBoxNakitMiktar.Text.Substring(0, textBoxNakitMiktar.Text.Length - 1);
                }
            }
            else
            {
                textBoxNakitMiktar.Text += buttonNumarator.Text;
            }
        }

        private void hesaplama()
        {
            Form1 formSatisaVeriGonder = (Form1)Application.OpenForms["Form1"];
            double nakit = Islemler.doubleYap(textBoxNakitMiktar.Text);
            double genelToplam = Islemler.doubleYap(formSatisaVeriGonder.textBoxGenelToplam.Text);
            double kart = genelToplam - nakit;
            formSatisaVeriGonder.labelNakit.Text = nakit.ToString("C2");
            formSatisaVeriGonder.labelKart.Text = kart.ToString("C2");
            formSatisaVeriGonder.satisYap("Kart-Nakit");
            this.Hide();
        }

        private void textBoxNakitMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxNakitMiktar.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    hesaplama();
                }
            }
        }

        private void buttonNakit_Click(object sender, EventArgs e)
        {
            if (textBoxNakitMiktar.Text!="")
            {
                hesaplama();
            }
        }

        private void textBoxNakitMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void formNakitKart_Load(object sender, EventArgs e)
        {

        }
    }
}

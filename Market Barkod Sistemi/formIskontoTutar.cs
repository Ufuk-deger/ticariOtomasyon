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
    public partial class formIskontoTutar : Form
    {
        public formIskontoTutar()
        {
            InitializeComponent();
        }

        private void buttonNumartator_Click(object sender, EventArgs e)
        {

            Button buttonNumarator = (Button)sender;
            if (buttonNumarator.Text == ",")
            {
                int virgul = textBoxIskontoMiktar.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    textBoxIskontoMiktar.Text += buttonNumarator.Text;
                }
            }
            else if (buttonNumarator.Text == "<")
            {
                if (textBoxIskontoMiktar.Text.Length > 0)
                {
                    textBoxIskontoMiktar.Text = textBoxIskontoMiktar.Text.Substring(0, textBoxIskontoMiktar.Text.Length - 1);
                }
            }
            else
            {
                textBoxIskontoMiktar.Text += buttonNumarator.Text;
            }
        }

        private void checkBoxIskontoYuzdeSecimi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIskontoYuzdeSecimi.Checked)
            {
                checkBoxIskontoYuzdeSecimi.Text = "Yüzde Olarak İskonto Uygula";     
            }
            else
            {
                checkBoxIskontoYuzdeSecimi.Text = "Nakit Olarak İskonto Uygula";
            }
        }

        private void iskontoHesapla()
        {

        }

        private void buttonIskontoUygula_Click(object sender, EventArgs e)
        {
            if (textBoxIskontoMiktar.Text!="")
            {
                iskontoHesapla();
            }
        }

        private void textBoxIskontoMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }
    }
}

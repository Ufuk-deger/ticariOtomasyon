using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_Barkod_Sistemi
{
    class nesneler
    {
    }
    class labelStandart :Label
    {
        public labelStandart()
        {
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.Text = "labelStandart";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "labelStandart";
        }
                  
    }

    class buttonStandart : Button
    {
        public buttonStandart()
        {
            this.BackColor = System.Drawing.Color.Olive;
            this.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Image = global::Market_Barkod_Sistemi.Properties.Resources.kaydet;
            this.Location = new System.Drawing.Point(247, 1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "buttonStandart";
            this.Size = new System.Drawing.Size(121, 133);
            this.TabIndex = 2;
            this.Text = "buttonStandart";
            this.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UseVisualStyleBackColor = false;
        }
    }

    class textBoxStandart:TextBox
    {
        public textBoxStandart()
        {
            this.Size = new System.Drawing.Size(250, 26);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);            
        }
    }

    class textBoxNumericStandart:TextBox
    {
        public textBoxNumericStandart()
        {
            this.Size = new System.Drawing.Size(115, 26);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Name = "textBoxNumericStandart";
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Click += TextBoxNumericStandart_Click;
            this.KeyPress += TextBoxNumericStandart_KeyPress;
        }

        private void TextBoxNumericStandart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)==false && e.KeyChar!=(char)08 && e.KeyChar!=(char)44)
            {
                e.Handled = true;
            }
        }

        private void TextBoxNumericStandart_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }
    }

    class dataGridViewStandart:DataGridView
    {
        public dataGridViewStandart()
        {
            this.AllowUserToAddRows = false;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = this.DefaultCellStyle;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = this.DefaultCellStyle;
            this.EnableHeadersVisualStyles = false;
            this.Location = new System.Drawing.Point(3, 118);
            this.Name = "dataGridViewSatisListesi";
            this.RowHeadersVisible = false;
            this.RowHeadersWidth = 51;
            this.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.RowTemplate.Height = 30;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Size = new System.Drawing.Size(611, 530);
            this.TabIndex = 1;
        }
    }
}

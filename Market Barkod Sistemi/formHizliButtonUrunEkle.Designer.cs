namespace Market_Barkod_Sistemi
{
    partial class formHizliButtonUrunEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.labelButtonId = new System.Windows.Forms.Label();
            this.checkBoxTumunuGoster = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxUrunAra = new System.Windows.Forms.TextBox();
            this.dataGridViewUrunler = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.labelButtonId);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxTumunuGoster);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxUrunAra);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewUrunler);
            this.splitContainer1.Size = new System.Drawing.Size(1555, 740);
            this.splitContainer1.SplitterDistance = 163;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Buton Numarası :";
            // 
            // labelButtonId
            // 
            this.labelButtonId.AutoSize = true;
            this.labelButtonId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelButtonId.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelButtonId.Location = new System.Drawing.Point(183, 9);
            this.labelButtonId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelButtonId.Name = "labelButtonId";
            this.labelButtonId.Size = new System.Drawing.Size(93, 25);
            this.labelButtonId.TabIndex = 7;
            this.labelButtonId.Text = "Buton No";
            // 
            // checkBoxTumunuGoster
            // 
            this.checkBoxTumunuGoster.AutoSize = true;
            this.checkBoxTumunuGoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxTumunuGoster.ForeColor = System.Drawing.Color.DarkCyan;
            this.checkBoxTumunuGoster.Location = new System.Drawing.Point(501, 95);
            this.checkBoxTumunuGoster.Name = "checkBoxTumunuGoster";
            this.checkBoxTumunuGoster.Size = new System.Drawing.Size(170, 29);
            this.checkBoxTumunuGoster.TabIndex = 6;
            this.checkBoxTumunuGoster.Text = "Tümünü Göster";
            this.checkBoxTumunuGoster.UseVisualStyleBackColor = true;
            this.checkBoxTumunuGoster.CheckedChanged += new System.EventHandler(this.checkBoxTumunuGoster_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(13, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ürün Ara";
            // 
            // textBoxUrunAra
            // 
            this.textBoxUrunAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUrunAra.Location = new System.Drawing.Point(18, 95);
            this.textBoxUrunAra.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUrunAra.Name = "textBoxUrunAra";
            this.textBoxUrunAra.Size = new System.Drawing.Size(476, 30);
            this.textBoxUrunAra.TabIndex = 4;
            this.textBoxUrunAra.TextChanged += new System.EventHandler(this.textBoxUrunAra_TextChanged);
            // 
            // dataGridViewUrunler
            // 
            this.dataGridViewUrunler.AllowUserToAddRows = false;
            this.dataGridViewUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUrunler.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewUrunler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUrunler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUrunler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUrunler.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUrunler.EnableHeadersVisualStyles = false;
            this.dataGridViewUrunler.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUrunler.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewUrunler.Name = "dataGridViewUrunler";
            this.dataGridViewUrunler.RowHeadersVisible = false;
            this.dataGridViewUrunler.RowHeadersWidth = 51;
            this.dataGridViewUrunler.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.dataGridViewUrunler.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.dataGridViewUrunler.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewUrunler.RowTemplate.Height = 30;
            this.dataGridViewUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUrunler.Size = new System.Drawing.Size(1555, 573);
            this.dataGridViewUrunler.TabIndex = 2;
            this.dataGridViewUrunler.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUrunler_CellContentDoubleClick);
            // 
            // formHizliButtonUrunEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1555, 740);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formHizliButtonUrunEkle";
            this.Text = "Hızlı Butona Ürün Ekleme";
            this.Load += new System.EventHandler(this.formHizliButtonUrunEkle_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewUrunler;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxUrunAra;
        private System.Windows.Forms.CheckBox checkBoxTumunuGoster;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label labelButtonId;
    }
}
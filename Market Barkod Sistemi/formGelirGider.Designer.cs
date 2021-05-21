namespace Market_Barkod_Sistemi
{
    partial class formGelirGider
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGelirGider));
            this.labelStandart1 = new Market_Barkod_Sistemi.labelStandart();
            this.labelStandart2 = new Market_Barkod_Sistemi.labelStandart();
            this.labelStandart3 = new Market_Barkod_Sistemi.labelStandart();
            this.comboBoxOdemeTuru = new System.Windows.Forms.ComboBox();
            this.textBoxNakit = new Market_Barkod_Sistemi.textBoxNumericStandart();
            this.textBoxKart = new Market_Barkod_Sistemi.textBoxNumericStandart();
            this.labelGelirGider = new Market_Barkod_Sistemi.labelStandart();
            this.textBoxAciklama = new Market_Barkod_Sistemi.textBoxStandart();
            this.labelStandart5 = new Market_Barkod_Sistemi.labelStandart();
            this.dateTimePickerTarih = new System.Windows.Forms.DateTimePicker();
            this.labelStandart6 = new Market_Barkod_Sistemi.labelStandart();
            this.buttonEkle = new Market_Barkod_Sistemi.buttonStandart();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // labelStandart1
            // 
            this.labelStandart1.AutoSize = true;
            this.labelStandart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStandart1.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelStandart1.Location = new System.Drawing.Point(22, 148);
            this.labelStandart1.Name = "labelStandart1";
            this.labelStandart1.Size = new System.Drawing.Size(56, 25);
            this.labelStandart1.TabIndex = 0;
            this.labelStandart1.Text = "Nakit";
            // 
            // labelStandart2
            // 
            this.labelStandart2.AutoSize = true;
            this.labelStandart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStandart2.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelStandart2.Location = new System.Drawing.Point(166, 148);
            this.labelStandart2.Name = "labelStandart2";
            this.labelStandart2.Size = new System.Drawing.Size(48, 25);
            this.labelStandart2.TabIndex = 1;
            this.labelStandart2.Text = "Kart";
            // 
            // labelStandart3
            // 
            this.labelStandart3.AutoSize = true;
            this.labelStandart3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStandart3.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelStandart3.Location = new System.Drawing.Point(22, 71);
            this.labelStandart3.Name = "labelStandart3";
            this.labelStandart3.Size = new System.Drawing.Size(123, 25);
            this.labelStandart3.TabIndex = 2;
            this.labelStandart3.Text = "Ödeme Türü";
            // 
            // comboBoxOdemeTuru
            // 
            this.comboBoxOdemeTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOdemeTuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxOdemeTuru.FormattingEnabled = true;
            this.comboBoxOdemeTuru.Items.AddRange(new object[] {
            "Nakit",
            "Kart",
            "Kart-Nakit"});
            this.comboBoxOdemeTuru.Location = new System.Drawing.Point(27, 99);
            this.comboBoxOdemeTuru.Name = "comboBoxOdemeTuru";
            this.comboBoxOdemeTuru.Size = new System.Drawing.Size(272, 33);
            this.comboBoxOdemeTuru.TabIndex = 3;
            this.comboBoxOdemeTuru.SelectedIndexChanged += new System.EventHandler(this.comboBoxOdemeTuru_SelectedIndexChanged);
            // 
            // textBoxNakit
            // 
            this.textBoxNakit.BackColor = System.Drawing.Color.White;
            this.textBoxNakit.Enabled = false;
            this.textBoxNakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNakit.Location = new System.Drawing.Point(27, 176);
            this.textBoxNakit.Name = "textBoxNakit";
            this.textBoxNakit.Size = new System.Drawing.Size(128, 30);
            this.textBoxNakit.TabIndex = 4;
            this.textBoxNakit.Text = "0";
            this.textBoxNakit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxKart
            // 
            this.textBoxKart.BackColor = System.Drawing.Color.White;
            this.textBoxKart.Enabled = false;
            this.textBoxKart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxKart.Location = new System.Drawing.Point(171, 176);
            this.textBoxKart.Name = "textBoxKart";
            this.textBoxKart.Size = new System.Drawing.Size(128, 30);
            this.textBoxKart.TabIndex = 5;
            this.textBoxKart.Text = "0";
            this.textBoxKart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelGelirGider
            // 
            this.labelGelirGider.AutoSize = true;
            this.labelGelirGider.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelGelirGider.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelGelirGider.Location = new System.Drawing.Point(22, 22);
            this.labelGelirGider.Name = "labelGelirGider";
            this.labelGelirGider.Size = new System.Drawing.Size(138, 25);
            this.labelGelirGider.TabIndex = 6;
            this.labelGelirGider.Text = "labelStandart4";
            // 
            // textBoxAciklama
            // 
            this.textBoxAciklama.BackColor = System.Drawing.Color.White;
            this.textBoxAciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxAciklama.Location = new System.Drawing.Point(27, 254);
            this.textBoxAciklama.Multiline = true;
            this.textBoxAciklama.Name = "textBoxAciklama";
            this.textBoxAciklama.Size = new System.Drawing.Size(272, 104);
            this.textBoxAciklama.TabIndex = 7;
            // 
            // labelStandart5
            // 
            this.labelStandart5.AutoSize = true;
            this.labelStandart5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStandart5.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelStandart5.Location = new System.Drawing.Point(22, 226);
            this.labelStandart5.Name = "labelStandart5";
            this.labelStandart5.Size = new System.Drawing.Size(92, 25);
            this.labelStandart5.TabIndex = 8;
            this.labelStandart5.Text = "Açıklama";
            // 
            // dateTimePickerTarih
            // 
            this.dateTimePickerTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerTarih.Location = new System.Drawing.Point(27, 409);
            this.dateTimePickerTarih.Name = "dateTimePickerTarih";
            this.dateTimePickerTarih.Size = new System.Drawing.Size(272, 30);
            this.dateTimePickerTarih.TabIndex = 9;
            // 
            // labelStandart6
            // 
            this.labelStandart6.AutoSize = true;
            this.labelStandart6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStandart6.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelStandart6.Location = new System.Drawing.Point(22, 381);
            this.labelStandart6.Name = "labelStandart6";
            this.labelStandart6.Size = new System.Drawing.Size(57, 25);
            this.labelStandart6.TabIndex = 10;
            this.labelStandart6.Text = "Tarih";
            // 
            // buttonEkle
            // 
            this.buttonEkle.BackColor = System.Drawing.Color.Olive;
            this.buttonEkle.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.buttonEkle.FlatAppearance.BorderSize = 0;
            this.buttonEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEkle.ForeColor = System.Drawing.Color.White;
            this.buttonEkle.ImageIndex = 0;
            this.buttonEkle.ImageList = this.ımageList1;
            this.buttonEkle.Location = new System.Drawing.Point(27, 457);
            this.buttonEkle.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEkle.Name = "buttonEkle";
            this.buttonEkle.Size = new System.Drawing.Size(272, 89);
            this.buttonEkle.TabIndex = 11;
            this.buttonEkle.Text = "Ekle";
            this.buttonEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonEkle.UseVisualStyleBackColor = false;
            this.buttonEkle.Click += new System.EventHandler(this.buttonEkle_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "icons8-plus-100.png");
            // 
            // formGelirGider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(332, 546);
            this.Controls.Add(this.buttonEkle);
            this.Controls.Add(this.labelStandart6);
            this.Controls.Add(this.dateTimePickerTarih);
            this.Controls.Add(this.labelStandart5);
            this.Controls.Add(this.textBoxAciklama);
            this.Controls.Add(this.labelGelirGider);
            this.Controls.Add(this.textBoxKart);
            this.Controls.Add(this.textBoxNakit);
            this.Controls.Add(this.comboBoxOdemeTuru);
            this.Controls.Add(this.labelStandart3);
            this.Controls.Add(this.labelStandart2);
            this.Controls.Add(this.labelStandart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 593);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 593);
            this.Name = "formGelirGider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gelir-Gider İşlemleri";
            this.Load += new System.EventHandler(this.formGelirGider_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private labelStandart labelStandart1;
        private labelStandart labelStandart2;
        private labelStandart labelStandart3;
        private System.Windows.Forms.ComboBox comboBoxOdemeTuru;
        private textBoxNumericStandart textBoxNakit;
        private textBoxNumericStandart textBoxKart;
        private labelStandart labelGelirGider;
        private textBoxStandart textBoxAciklama;
        private labelStandart labelStandart5;
        private System.Windows.Forms.DateTimePicker dateTimePickerTarih;
        private labelStandart labelStandart6;
        private buttonStandart buttonEkle;
        private System.Windows.Forms.ImageList ımageList1;
    }
}
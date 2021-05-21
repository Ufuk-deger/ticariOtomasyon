namespace Market_Barkod_Sistemi
{
    partial class formRaporDetayGoster
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
            this.labelIslemNo = new Market_Barkod_Sistemi.labelStandart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewDetay = new Market_Barkod_Sistemi.dataGridViewStandart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetay)).BeginInit();
            this.SuspendLayout();
            // 
            // labelIslemNo
            // 
            this.labelIslemNo.AutoSize = true;
            this.labelIslemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelIslemNo.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelIslemNo.Location = new System.Drawing.Point(17, 22);
            this.labelIslemNo.Name = "labelIslemNo";
            this.labelIslemNo.Size = new System.Drawing.Size(138, 25);
            this.labelIslemNo.TabIndex = 0;
            this.labelIslemNo.Text = "labelStandart1";
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
            this.splitContainer1.Panel1.Controls.Add(this.labelIslemNo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewDetay);
            this.splitContainer1.Size = new System.Drawing.Size(676, 566);
            this.splitContainer1.SplitterDistance = 68;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridViewDetay
            // 
            this.dataGridViewDetay.AllowUserToAddRows = false;
            this.dataGridViewDetay.AllowUserToDeleteRows = false;
            this.dataGridViewDetay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDetay.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewDetay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDetay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDetay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetay.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetay.EnableHeadersVisualStyles = false;
            this.dataGridViewDetay.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetay.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewDetay.Name = "dataGridViewDetay";
            this.dataGridViewDetay.ReadOnly = true;
            this.dataGridViewDetay.RowHeadersVisible = false;
            this.dataGridViewDetay.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGridViewDetay.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDetay.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.dataGridViewDetay.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.dataGridViewDetay.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewDetay.RowTemplate.Height = 30;
            this.dataGridViewDetay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDetay.Size = new System.Drawing.Size(676, 494);
            this.dataGridViewDetay.TabIndex = 4;
            this.dataGridViewDetay.TabStop = false;
            // 
            // formRaporDetayGoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(676, 566);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formRaporDetayGoster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detay Göster";
            this.Load += new System.EventHandler(this.formRaporDetayGoster_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private labelStandart labelIslemNo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private dataGridViewStandart dataGridViewDetay;
    }
}
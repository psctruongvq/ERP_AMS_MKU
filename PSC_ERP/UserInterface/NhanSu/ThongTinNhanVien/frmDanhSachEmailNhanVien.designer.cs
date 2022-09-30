namespace PSC_ERP
{
    partial class frmDanhSachEmailNhanVien
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVien_Email", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDiaChiWebsite");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DiaChi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiTiet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Loai");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachEmailNhanVien));
            this.grd_DSEmailNhanVien = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DSEmail_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSEmailNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSEmail_BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_DSEmailNhanVien
            // 
            this.grd_DSEmailNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_DSEmailNhanVien.DataSource = this.DSEmail_BindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.FontData.BoldAsString = "False";
            this.grd_DSEmailNhanVien.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.grd_DSEmailNhanVien.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grd_DSEmailNhanVien.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grd_DSEmailNhanVien.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance2.BackColor = System.Drawing.Color.SteelBlue;
            this.grd_DSEmailNhanVien.DisplayLayout.Override.HeaderAppearance = appearance2;
            this.grd_DSEmailNhanVien.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grd_DSEmailNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grd_DSEmailNhanVien.Location = new System.Drawing.Point(-2, -2);
            this.grd_DSEmailNhanVien.Name = "grd_DSEmailNhanVien";
            this.grd_DSEmailNhanVien.Size = new System.Drawing.Size(391, 204);
            this.grd_DSEmailNhanVien.TabIndex = 46;
            this.grd_DSEmailNhanVien.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grd_DSEmailNhanVien_InitializeLayout);
            // 
            // DSEmail_BindingSource
            // 
            this.DSEmail_BindingSource.AllowNew = true;
            this.DSEmail_BindingSource.DataSource = typeof(ERP_Library.NhanVien_EmailList);
            // 
            // frmDanhSachEmailNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 201);
            this.Controls.Add(this.grd_DSEmailNhanVien);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhSachEmailNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Email  Nhân Viên ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDanhSachEmailNhanVien_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSEmailNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSEmail_BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid grd_DSEmailNhanVien;
        private System.Windows.Forms.BindingSource DSEmail_BindingSource;
    }
}
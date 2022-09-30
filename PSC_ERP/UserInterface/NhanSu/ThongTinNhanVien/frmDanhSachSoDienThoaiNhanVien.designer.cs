namespace PSC_ERP
{
    partial class frmDanhSachSoDienThoaiNhanVien
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVien_DienThoai_Fax", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Active");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDienThoaiFax");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoDTFax");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiTiet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Loai");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachSoDienThoaiNhanVien));
            this.grd_DSSoDienThoaiNhanVien = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DSSoDienThoai_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSSoDienThoaiNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSoDienThoai_bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_DSSoDienThoaiNhanVien
            // 
            this.grd_DSSoDienThoaiNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_DSSoDienThoaiNhanVien.DataSource = this.DSSoDienThoai_bindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.FontData.BoldAsString = "False";
            this.grd_DSSoDienThoaiNhanVien.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            this.grd_DSSoDienThoaiNhanVien.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grd_DSSoDienThoaiNhanVien.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grd_DSSoDienThoaiNhanVien.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance2.BackColor = System.Drawing.Color.SteelBlue;
            this.grd_DSSoDienThoaiNhanVien.DisplayLayout.Override.HeaderAppearance = appearance2;
            this.grd_DSSoDienThoaiNhanVien.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grd_DSSoDienThoaiNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grd_DSSoDienThoaiNhanVien.Location = new System.Drawing.Point(0, -1);
            this.grd_DSSoDienThoaiNhanVien.Name = "grd_DSSoDienThoaiNhanVien";
            this.grd_DSSoDienThoaiNhanVien.Size = new System.Drawing.Size(371, 205);
            this.grd_DSSoDienThoaiNhanVien.TabIndex = 47;
            this.grd_DSSoDienThoaiNhanVien.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grd_DSSoDienThoaiNhanVien_InitializeLayout);
            // 
            // DSSoDienThoai_bindingSource
            // 
            this.DSSoDienThoai_bindingSource.AllowNew = true;
            this.DSSoDienThoai_bindingSource.DataSource = typeof(ERP_Library.NhanVien_DienThoai_FaxList);
            // 
            // frmDanhSachSoDienThoaiNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 203);
            this.Controls.Add(this.grd_DSSoDienThoaiNhanVien);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhSachSoDienThoaiNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Số Điện Thoại Nhân Viên";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDanhSachSoDienThoaiNhanVien_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSSoDienThoaiNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSoDienThoai_bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid grd_DSSoDienThoaiNhanVien;
        private System.Windows.Forms.BindingSource DSSoDienThoai_bindingSource;
    }
}
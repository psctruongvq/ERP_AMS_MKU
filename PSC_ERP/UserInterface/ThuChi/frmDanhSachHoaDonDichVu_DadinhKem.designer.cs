namespace PSC_ERP
{
    partial class frmDanhSachHoaDonDichVu_DadinhKem
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChungTu_HoaDon", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NguoiLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoChungTu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoHoaDon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MachungtuChungtugoc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienDaThanhToan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienSeThanhToan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienConLai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HoanTat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChungTu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaButToan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaHoaDon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhieuNhapXuat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachHoaDonDichVu_DadinhKem));
            this.grb_DSHoaDon = new System.Windows.Forms.GroupBox();
            this.grdu_DSHoaDon = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdCT_HoaDon = new System.Windows.Forms.BindingSource(this.components);
            this.ultraTextEditor9 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.tlsxoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.grb_DSHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_DSHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdCT_HoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor9)).BeginInit();
            this.tlsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_DSHoaDon
            // 
            this.grb_DSHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grb_DSHoaDon.Controls.Add(this.grdu_DSHoaDon);
            this.grb_DSHoaDon.Controls.Add(this.ultraTextEditor9);
            this.grb_DSHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_DSHoaDon.Location = new System.Drawing.Point(1, 28);
            this.grb_DSHoaDon.Name = "grb_DSHoaDon";
            this.grb_DSHoaDon.Size = new System.Drawing.Size(836, 393);
            this.grb_DSHoaDon.TabIndex = 13;
            this.grb_DSHoaDon.TabStop = false;
            this.grb_DSHoaDon.Text = "Danh Sách Hóa Đơn";
            // 
            // grdu_DSHoaDon
            // 
            this.grdu_DSHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdu_DSHoaDon.DataSource = this.bdCT_HoaDon;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.FontData.BoldAsString = "False";
            this.grdu_DSHoaDon.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 14;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 11;
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.VisiblePosition = 13;
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn9.Header.VisiblePosition = 4;
            ultraGridColumn10.Header.VisiblePosition = 7;
            ultraGridColumn11.Header.VisiblePosition = 8;
            ultraGridColumn12.Header.VisiblePosition = 10;
            ultraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn13.Header.VisiblePosition = 9;
            ultraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn14.Header.VisiblePosition = 12;
            ultraGridColumn15.AutoSizeEdit = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn15.DataType = typeof(bool);
            ultraGridColumn15.Header.Caption = "";
            ultraGridColumn15.Header.CheckBoxAlignment = Infragistics.Win.UltraWinGrid.HeaderCheckBoxAlignment.Center;
            ultraGridColumn15.Header.CheckBoxSynchronization = Infragistics.Win.UltraWinGrid.HeaderCheckBoxSynchronization.Band;
            ultraGridColumn15.Header.CheckBoxVisibility = Infragistics.Win.UltraWinGrid.HeaderCheckBoxVisibility.Always;
            ultraGridColumn15.Header.VisiblePosition = 0;
            ultraGridColumn15.Width = 31;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15});
            this.grdu_DSHoaDon.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdu_DSHoaDon.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdu_DSHoaDon.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.grdu_DSHoaDon.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdu_DSHoaDon.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdu_DSHoaDon.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden;
            this.grdu_DSHoaDon.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit;
            this.grdu_DSHoaDon.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.grdu_DSHoaDon.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden;
            this.grdu_DSHoaDon.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance2.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_DSHoaDon.DisplayLayout.Override.HeaderAppearance = appearance2;
            this.grdu_DSHoaDon.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdu_DSHoaDon.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grdu_DSHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdu_DSHoaDon.Location = new System.Drawing.Point(11, 20);
            this.grdu_DSHoaDon.Name = "grdu_DSHoaDon";
            this.grdu_DSHoaDon.Size = new System.Drawing.Size(815, 367);
            this.grdu_DSHoaDon.TabIndex = 29;
            this.grdu_DSHoaDon.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdu_DSHoaDon_InitializeLayout);
            this.grdu_DSHoaDon.DoubleClick += new System.EventHandler(this.grdu_DSHoaDon_DoubleClick);
            // 
            // bdCT_HoaDon
            // 
            this.bdCT_HoaDon.AllowNew = false;
            this.bdCT_HoaDon.DataSource = typeof(ERP_Library.ChungTu_HoaDonList);
            // 
            // ultraTextEditor9
            // 
            this.ultraTextEditor9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraTextEditor9.Location = new System.Drawing.Point(432, -51);
            this.ultraTextEditor9.Name = "ultraTextEditor9";
            this.ultraTextEditor9.Size = new System.Drawing.Size(73, 21);
            this.ultraTextEditor9.TabIndex = 8;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblThoat
            // 
            this.tlslblThoat.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThoat.Image")));
            this.tlslblThoat.Name = "tlslblThoat";
            this.tlslblThoat.Size = new System.Drawing.Size(58, 22);
            this.tlslblThoat.Text = "T&hoát";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlsxoa,
            this.toolStripSeparator3,
            this.tlslblThoat,
            this.toolStripButton1});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(847, 25);
            this.tlsMain.TabIndex = 14;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(47, 22);
            this.tlslblLuu.Text = "&Lưu";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // tlsxoa
            // 
            this.tlsxoa.Image = ((System.Drawing.Image)(resources.GetObject("tlsxoa.Image")));
            this.tlsxoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsxoa.Name = "tlsxoa";
            this.tlsxoa.Size = new System.Drawing.Size(47, 22);
            this.tlsxoa.Text = "&Xóa";
            this.tlsxoa.Click += new System.EventHandler(this.tlsxoa_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(80, 22);
            this.toolStripButton1.Text = "Xuất Excel";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // frmDanhSachHoaDonDichVu_DadinhKem
            // 
            this.ClientSize = new System.Drawing.Size(847, 426);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.grb_DSHoaDon);
            this.Name = "frmDanhSachHoaDonDichVu_DadinhKem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Hóa Đơn-Chứng Từ";
            this.grb_DSHoaDon.ResumeLayout(false);
            this.grb_DSHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_DSHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdCT_HoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor9)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_DSHoaDon;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_DSHoaDon;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor9;
        private System.Windows.Forms.BindingSource bdCT_HoaDon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlsxoa;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
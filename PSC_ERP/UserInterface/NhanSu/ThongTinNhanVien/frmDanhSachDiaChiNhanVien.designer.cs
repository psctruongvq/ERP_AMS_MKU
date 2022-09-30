namespace PSC_ERP
{
    partial class frmDanhSachDiaChiNhanVien
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DiaChi_NhanVien", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenDiaChi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTinhThanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TinhTP");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiTiet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuocGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("QuocGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("QuanHuyen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDiaChi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Active");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanHuyen");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachDiaChiNhanVien));
            this.cmbu_TinhThanh = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.TinhThanh_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbu_QuocGia = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.QuocGia_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbu_QuanHuyen = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.QuanHuyen_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSDiaChi_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grd_DSDiaChiNhanVien = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_TinhThanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TinhThanh_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_QuocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuocGia_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_QuanHuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanHuyen_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDiaChi_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSDiaChiNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbu_TinhThanh
            // 
            this.cmbu_TinhThanh.DataSource = this.TinhThanh_BindingSource;
            this.cmbu_TinhThanh.DisplayMember = "TenTinhThanh";
            this.cmbu_TinhThanh.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_TinhThanh.Location = new System.Drawing.Point(213, 240);
            this.cmbu_TinhThanh.Name = "cmbu_TinhThanh";
            this.cmbu_TinhThanh.Size = new System.Drawing.Size(108, 21);
            this.cmbu_TinhThanh.TabIndex = 46;
            this.cmbu_TinhThanh.ValueMember = "MaTinhThanh";
            // 
            // TinhThanh_BindingSource
            // 
            this.TinhThanh_BindingSource.DataSource = typeof(ERP_Library.TinhThanhList);
            // 
            // cmbu_QuocGia
            // 
            this.cmbu_QuocGia.DataSource = this.QuocGia_BindingSource;
            this.cmbu_QuocGia.DisplayMember = "TenQuocGia";
            this.cmbu_QuocGia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_QuocGia.Location = new System.Drawing.Point(327, 240);
            this.cmbu_QuocGia.Name = "cmbu_QuocGia";
            this.cmbu_QuocGia.Size = new System.Drawing.Size(108, 21);
            this.cmbu_QuocGia.TabIndex = 46;
            this.cmbu_QuocGia.ValueMember = "MaQuocGia";
            // 
            // QuocGia_BindingSource
            // 
            this.QuocGia_BindingSource.DataSource = typeof(ERP_Library.QuocGiaList);
            // 
            // cmbu_QuanHuyen
            // 
            this.cmbu_QuanHuyen.DataSource = this.QuanHuyen_BindingSource;
            this.cmbu_QuanHuyen.DisplayMember = "TenQuanHuyen";
            this.cmbu_QuanHuyen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_QuanHuyen.Location = new System.Drawing.Point(112, 240);
            this.cmbu_QuanHuyen.Name = "cmbu_QuanHuyen";
            this.cmbu_QuanHuyen.Size = new System.Drawing.Size(95, 21);
            this.cmbu_QuanHuyen.TabIndex = 46;
            this.cmbu_QuanHuyen.ValueMember = "MaQuanHuyen";
            this.cmbu_QuanHuyen.ValueChanged += new System.EventHandler(this.cmbu_QuanHuyen_ValueChanged);
            // 
            // QuanHuyen_BindingSource
            // 
            this.QuanHuyen_BindingSource.DataSource = typeof(ERP_Library.QuanHuyenList);
            // 
            // DSDiaChi_bindingSource
            // 
            this.DSDiaChi_bindingSource.AllowNew = true;
            this.DSDiaChi_bindingSource.DataSource = typeof(ERP_Library.DiaChi_NhanVienList);
            // 
            // grd_DSDiaChiNhanVien
            // 
            this.grd_DSDiaChiNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_DSDiaChiNhanVien.DataSource = this.DSDiaChi_bindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.FontData.BoldAsString = "False";
            this.grd_DSDiaChiNhanVien.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.EditorComponent = this.cmbu_TinhThanh;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.EditorComponent = this.cmbu_QuocGia;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn11.EditorComponent = this.cmbu_QuanHuyen;
            ultraGridColumn11.Header.VisiblePosition = 10;
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
            ultraGridColumn11});
            this.grd_DSDiaChiNhanVien.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grd_DSDiaChiNhanVien.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance2.BackColor = System.Drawing.Color.SteelBlue;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderAppearance = appearance2;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grd_DSDiaChiNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grd_DSDiaChiNhanVien.Location = new System.Drawing.Point(-2, -2);
            this.grd_DSDiaChiNhanVien.Name = "grd_DSDiaChiNhanVien";
            this.grd_DSDiaChiNhanVien.Size = new System.Drawing.Size(657, 281);
            this.grd_DSDiaChiNhanVien.TabIndex = 45;
            this.grd_DSDiaChiNhanVien.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grd_DSDiaChiNhanVien_InitializeLayout);
            // 
            // frmDanhSachDiaChiNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 278);
            this.Controls.Add(this.grd_DSDiaChiNhanVien);
            this.Controls.Add(this.cmbu_QuocGia);
            this.Controls.Add(this.cmbu_TinhThanh);
            this.Controls.Add(this.cmbu_QuanHuyen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanhSachDiaChiNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Địa Chỉ Nhân Viên";
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_TinhThanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TinhThanh_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_QuocGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuocGia_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_QuanHuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanHuyen_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDiaChi_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSDiaChiNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource DSDiaChi_bindingSource;
        private Infragistics.Win.UltraWinGrid.UltraGrid grd_DSDiaChiNhanVien;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbu_QuanHuyen;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbu_TinhThanh;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbu_QuocGia;
        private System.Windows.Forms.BindingSource QuanHuyen_BindingSource;
        private System.Windows.Forms.BindingSource TinhThanh_BindingSource;
        private System.Windows.Forms.BindingSource QuocGia_BindingSource;
    }
}
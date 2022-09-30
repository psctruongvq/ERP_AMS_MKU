namespace PSC_ERP
{
    partial class frmNhanVien_ChuyenMon
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVien_ChuyenNganh", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVienChuyenNganh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChuyenNganh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChuyenNganh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChuyenNganhChinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTruongDaoTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenTruongDaoTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaHinhThucDaoTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenHinhThucDaoTao");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.cbTrinhDoChuyenMon = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbTruongDaoTao = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.grd_DSDiaChiNhanVien = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ChuyenMon_NhanVien_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ChuyenNganhDaoTao_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1_TruongDaoTao = new System.Windows.Forms.BindingSource(this.components);
            this.cbHinhThucDaoTao = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.bindingSource1_HinhThucDaoTao = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cbTrinhDoChuyenMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTruongDaoTao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSDiaChiNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChuyenMon_NhanVien_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChuyenNganhDaoTao_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_TruongDaoTao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHinhThucDaoTao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_HinhThucDaoTao)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTrinhDoChuyenMon
            // 
            this.cbTrinhDoChuyenMon.DataSource = this.ChuyenNganhDaoTao_BindingSource;
            this.cbTrinhDoChuyenMon.DisplayMember = "ChuyenNganhDaoTao";
            this.cbTrinhDoChuyenMon.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbTrinhDoChuyenMon.Location = new System.Drawing.Point(50, 208);
            this.cbTrinhDoChuyenMon.Name = "cbTrinhDoChuyenMon";
            this.cbTrinhDoChuyenMon.Size = new System.Drawing.Size(207, 21);
            this.cbTrinhDoChuyenMon.TabIndex = 46;
            this.cbTrinhDoChuyenMon.ValueMember = "MaChuyenNganhDaoTao";
            // 
            // cbTruongDaoTao
            // 
            this.cbTruongDaoTao.DataSource = this.bindingSource1_TruongDaoTao;
            this.cbTruongDaoTao.DisplayMember = "TenTruongDaoTao";
            this.cbTruongDaoTao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbTruongDaoTao.Location = new System.Drawing.Point(50, 208);
            this.cbTruongDaoTao.Name = "cbTruongDaoTao";
            this.cbTruongDaoTao.Size = new System.Drawing.Size(207, 21);
            this.cbTruongDaoTao.TabIndex = 46;
            this.cbTruongDaoTao.ValueMember = "MaTruongDaoTao";
            // 
            // grd_DSDiaChiNhanVien
            // 
            this.grd_DSDiaChiNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_DSDiaChiNhanVien.DataSource = this.ChuyenMon_NhanVien_bindingSource;
            appearance3.BackColor = System.Drawing.Color.White;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.EditorComponent = this.cbTrinhDoChuyenMon;
            ultraGridColumn4.Header.Caption = "Tên Chuyên Ngành";
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.Width = 150;
            ultraGridColumn5.Header.Caption = "Chuyên Ngành Chính";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.EditorComponent = this.cbTruongDaoTao;
            ultraGridColumn6.Header.Caption = "Tên Trường Đào Tạo";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.EditorComponent = this.cbHinhThucDaoTao;
            ultraGridColumn8.Header.Caption = "Hình Thức Đào Tạo";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            this.grd_DSDiaChiNhanVien.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grd_DSDiaChiNhanVien.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.FontData.BoldAsString = "True";
            appearance5.FontData.Name = "Arial";
            appearance5.FontData.SizeInPoints = 10F;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.grd_DSDiaChiNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grd_DSDiaChiNhanVien.Location = new System.Drawing.Point(2, -1);
            this.grd_DSDiaChiNhanVien.Name = "grd_DSDiaChiNhanVien";
            this.grd_DSDiaChiNhanVien.Size = new System.Drawing.Size(553, 404);
            this.grd_DSDiaChiNhanVien.TabIndex = 45;
            this.grd_DSDiaChiNhanVien.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grd_DSDiaChiNhanVien_InitializeLayout);
            this.grd_DSDiaChiNhanVien.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grd_DSDiaChiNhanVien_CellChange);
            // 
            // ChuyenMon_NhanVien_bindingSource
            // 
            this.ChuyenMon_NhanVien_bindingSource.AllowNew = true;
            this.ChuyenMon_NhanVien_bindingSource.DataSource = typeof(ERP_Library.NhanVien_ChuyenNganhList);
            // 
            // ChuyenNganhDaoTao_BindingSource
            // 
            this.ChuyenNganhDaoTao_BindingSource.DataSource = typeof(ERP_Library.ChuyenNganhDaoTaoClassList);
            // 
            // bindingSource1_TruongDaoTao
            // 
            this.bindingSource1_TruongDaoTao.DataSource = typeof(ERP_Library.TruongDaoTaoList);
            // 
            // cbHinhThucDaoTao
            // 
            this.cbHinhThucDaoTao.DataSource = this.bindingSource1_HinhThucDaoTao;
            this.cbHinhThucDaoTao.DisplayMember = "HinhThucDaoTao";
            this.cbHinhThucDaoTao.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbHinhThucDaoTao.Location = new System.Drawing.Point(181, 263);
            this.cbHinhThucDaoTao.Name = "cbHinhThucDaoTao";
            this.cbHinhThucDaoTao.Size = new System.Drawing.Size(207, 21);
            this.cbHinhThucDaoTao.TabIndex = 47;
            this.cbHinhThucDaoTao.ValueMember = "MaHinhThucDaoTao";
            // 
            // bindingSource1_HinhThucDaoTao
            // 
            this.bindingSource1_HinhThucDaoTao.DataSource = typeof(ERP_Library.HinhThucDaoTaoClassList);
            // 
            // frmNhanVien_ChuyenMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 404);
            this.Controls.Add(this.grd_DSDiaChiNhanVien);
            this.Controls.Add(this.cbHinhThucDaoTao);
            this.Controls.Add(this.cbTrinhDoChuyenMon);
            this.Controls.Add(this.cbTruongDaoTao);
            this.Name = "frmNhanVien_ChuyenMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyên Ngành Đào Tạo - Nhân Viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhanVien_ChuyenMon_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.cbTrinhDoChuyenMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTruongDaoTao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSDiaChiNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChuyenMon_NhanVien_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChuyenNganhDaoTao_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_TruongDaoTao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHinhThucDaoTao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_HinhThucDaoTao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource ChuyenMon_NhanVien_bindingSource;
        private Infragistics.Win.UltraWinGrid.UltraGrid grd_DSDiaChiNhanVien;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbTrinhDoChuyenMon;
        private System.Windows.Forms.BindingSource ChuyenNganhDaoTao_BindingSource;
        private System.Windows.Forms.BindingSource bindingSource1_TruongDaoTao;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbTruongDaoTao;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbHinhThucDaoTao;
        private System.Windows.Forms.BindingSource bindingSource1_HinhThucDaoTao;
    }
}
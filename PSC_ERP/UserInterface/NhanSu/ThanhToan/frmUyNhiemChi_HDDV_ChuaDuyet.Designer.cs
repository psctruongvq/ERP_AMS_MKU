namespace PSC_ERP
{
    partial class frmUyNhiemChi_HDDV_ChuaDuyet
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChungTuNganHang_DeNghi", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChungTu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDeNghi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LyDo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTien");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TinhTrang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NganHang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PhaLoai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NguoiLap", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoDeNghi", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenDoiTac");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TKDoiTac");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon", 0);
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("SoTien", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "SoTien", 5, true, "ChungTuNganHang_DeNghi", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SoTien", 5, true);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(2191627);
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUyNhiemChi_HDDV_ChuaDuyet));
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdData = new System.Windows.Forms.BindingSource(this.components);
            this.btnKhong = new Infragistics.Win.Misc.UltraButton();
            this.btnDongY = new Infragistics.Win.Misc.UltraButton();
            this.chkAll = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.DataSource = this.bdData;
            appearance1.BackColor = System.Drawing.Color.White;
            this.grdData.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Width = 216;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.Width = 225;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn3.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            ultraGridColumn3.Header.Caption = "Mã BP";
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Width = 55;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn4.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            ultraGridColumn4.Header.Caption = "Tên bộ phận";
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Width = 126;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn5.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            ultraGridColumn5.Header.Caption = "Diễn giải";
            ultraGridColumn5.Header.VisiblePosition = 9;
            ultraGridColumn5.Width = 293;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            appearance2.TextHAlignAsString = "Right";
            ultraGridColumn6.CellAppearance = appearance2;
            ultraGridColumn6.Format = "#,###";
            ultraGridColumn6.Header.Caption = "Số tiền";
            ultraGridColumn6.Header.VisiblePosition = 10;
            ultraGridColumn6.Width = 110;
            ultraGridColumn7.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            ultraGridColumn7.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            ultraGridColumn7.Header.Caption = "Tình trạng";
            ultraGridColumn7.Header.VisiblePosition = 13;
            ultraGridColumn7.Width = 86;
            ultraGridColumn8.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            ultraGridColumn8.Header.Caption = "Ngân hàng";
            ultraGridColumn8.Header.VisiblePosition = 11;
            ultraGridColumn8.Width = 78;
            ultraGridColumn9.Header.Caption = "Phân loại";
            ultraGridColumn9.Header.VisiblePosition = 14;
            ultraGridColumn10.Header.Caption = "Người lập";
            ultraGridColumn10.Header.VisiblePosition = 12;
            ultraGridColumn10.Width = 107;
            ultraGridColumn11.Header.Caption = "Số đề nghị";
            ultraGridColumn11.Header.VisiblePosition = 5;
            ultraGridColumn12.Header.Caption = "Tên đối tác";
            ultraGridColumn12.Header.VisiblePosition = 7;
            ultraGridColumn12.Width = 121;
            ultraGridColumn15.Format = "dd/MM/yyyy";
            ultraGridColumn15.Header.Caption = "Ngày lập";
            ultraGridColumn15.Header.VisiblePosition = 6;
            ultraGridColumn13.Header.Caption = "Số tài khoản";
            ultraGridColumn13.Header.VisiblePosition = 8;
            ultraGridColumn14.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            ultraGridColumn14.DataType = typeof(bool);
            ultraGridColumn14.DefaultCellValue = false;
            ultraGridColumn14.Header.Caption = "";
            ultraGridColumn14.Header.VisiblePosition = 2;
            ultraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn14.Width = 30;
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
            ultraGridColumn15,
            ultraGridColumn13,
            ultraGridColumn14});
            appearance3.TextHAlignAsString = "Right";
            summarySettings1.Appearance = appearance3;
            summarySettings1.DisplayFormat = "{0:#,###}";
            summarySettings1.GroupBySummaryValueAppearance = appearance4;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1});
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance5;
            this.grdData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdData.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            this.grdData.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.grdData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.FontData.BoldAsString = "True";
            appearance6.FontData.Name = "Arial";
            appearance6.FontData.SizeInPoints = 10F;
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdData.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.grdData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.RowSelectorAppearance = appearance7;
            this.grdData.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.grdData.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdData.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdData.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdData.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            this.grdData.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdData.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            valueList1.Key = "DatabaseNumber";
            this.grdData.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
            this.grdData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(989, 442);
            this.grdData.TabIndex = 0;
            this.grdData.Text = "ultraGrid1";
            this.grdData.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.grdData_BeforeCellActivate);
            this.grdData.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.grdData_ClickCell);
            // 
            // bdData
            // 
            this.bdData.DataSource = typeof(ERP_Library.ChungTuNganHang_DeNghiList);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            appearance9.Image = ((object)(resources.GetObject("appearance9.Image")));
            this.btnKhong.Appearance = appearance9;
            this.btnKhong.CausesValidation = false;
            this.btnKhong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKhong.ImageSize = new System.Drawing.Size(24, 24);
            this.btnKhong.Location = new System.Drawing.Point(505, 10);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(100, 32);
            this.btnKhong.TabIndex = 2;
            this.btnKhong.Text = "Không";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnDongY
            // 
            this.btnDongY.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            appearance10.Image = ((object)(resources.GetObject("appearance10.Image")));
            this.btnDongY.Appearance = appearance10;
            this.btnDongY.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDongY.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDongY.Location = new System.Drawing.Point(383, 10);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(100, 32);
            this.btnDongY.TabIndex = 1;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkAll.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2007CheckBoxGlyphInfo;
            this.chkAll.Location = new System.Drawing.Point(49, 7);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(13, 13);
            this.chkAll.TabIndex = 3;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKhong);
            this.groupBox1.Controls.Add(this.btnDongY);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 442);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(989, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // frmUyNhiemChi_HDDV_ChuaDuyet
            // 
            this.AcceptButton = this.btnDongY;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnKhong;
            this.ClientSize = new System.Drawing.Size(989, 494);
            this.ControlBox = false;
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUyNhiemChi_HDDV_ChuaDuyet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đề nghị chuyển khoản Hóa Đơn - Dịch Vụ chưa duyệt";
            this.Load += new System.EventHandler(this.frmChungTuNganHang_DeNghiChuaDuyet_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bdData;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdData;
        private Infragistics.Win.Misc.UltraButton btnKhong;
        private Infragistics.Win.Misc.UltraButton btnDongY;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAll;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
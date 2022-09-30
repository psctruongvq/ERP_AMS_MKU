namespace PSC_ERP
{
    partial class frmDieuChinhQuyetToanTNCN
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BangLuongQuyetToanThueChild", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Thang");
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "SoTien", 0, true, "BangLuongQuyetToanThueChild", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.Left, null, -1, false);
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(11090047);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DieuChinhQuyetToanThueChild", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Loai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nam");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserID");
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "SoTien", 6, true, "DieuChinhQuyetToanThueChild", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.Left, null, -1, false);
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            this.btnKhong = new Infragistics.Win.Misc.UltraGroupBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.lblTenBoPhan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bl_NhanVien = new System.Windows.Forms.Label();
            this.lb_BoPhan = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.grdBangLuong = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdBangLuong = new System.Windows.Forms.BindingSource(this.components);
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.grdDieuChinh = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdDieuChinh = new System.Windows.Forms.BindingSource(this.components);
            this.btnDongY = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnKhong)).BeginInit();
            this.btnKhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBangLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdBangLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDieuChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdDieuChinh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKhong
            // 
            this.btnKhong.Controls.Add(this.lblLoai);
            this.btnKhong.Controls.Add(this.lblTenNhanVien);
            this.btnKhong.Controls.Add(this.lblTenBoPhan);
            this.btnKhong.Controls.Add(this.label1);
            this.btnKhong.Controls.Add(this.bl_NhanVien);
            this.btnKhong.Controls.Add(this.lb_BoPhan);
            this.btnKhong.Location = new System.Drawing.Point(2, 7);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(591, 66);
            this.btnKhong.TabIndex = 0;
            this.btnKhong.Text = "Thông Tin Chi Tiết";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai.Location = new System.Drawing.Point(112, 45);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(0, 16);
            this.lblLoai.TabIndex = 5;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNhanVien.Location = new System.Drawing.Point(399, 19);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(0, 16);
            this.lblTenNhanVien.TabIndex = 4;
            // 
            // lblTenBoPhan
            // 
            this.lblTenBoPhan.AutoSize = true;
            this.lblTenBoPhan.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBoPhan.Location = new System.Drawing.Point(67, 19);
            this.lblTenBoPhan.Name = "lblTenBoPhan";
            this.lblTenBoPhan.Size = new System.Drawing.Size(0, 16);
            this.lblTenBoPhan.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dữ liệu điều chỉnh:";
            // 
            // bl_NhanVien
            // 
            this.bl_NhanVien.AutoSize = true;
            this.bl_NhanVien.Location = new System.Drawing.Point(333, 19);
            this.bl_NhanVien.Name = "bl_NhanVien";
            this.bl_NhanVien.Size = new System.Drawing.Size(60, 13);
            this.bl_NhanVien.TabIndex = 1;
            this.bl_NhanVien.Text = "Nhân Viên:";
            // 
            // lb_BoPhan
            // 
            this.lb_BoPhan.AutoSize = true;
            this.lb_BoPhan.Location = new System.Drawing.Point(11, 19);
            this.lb_BoPhan.Name = "lb_BoPhan";
            this.lb_BoPhan.Size = new System.Drawing.Size(50, 13);
            this.lb_BoPhan.TabIndex = 0;
            this.lb_BoPhan.Text = "Bộ phận:";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.grdBangLuong);
            this.ultraGroupBox2.Location = new System.Drawing.Point(2, 75);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(591, 209);
            this.ultraGroupBox2.TabIndex = 1;
            this.ultraGroupBox2.Text = "Dữ Liệu Đã Báo Cáo";
            // 
            // grdBangLuong
            // 
            this.grdBangLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBangLuong.DataSource = this.bdBangLuong;
            appearance1.BackColor = System.Drawing.Color.White;
            this.grdBangLuong.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.Caption = "Số Người";
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn2.Header.Caption = "Tháng";
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            summarySettings1.DisplayFormat = "TC={0}";
            summarySettings1.GroupBySummaryValueAppearance = appearance18;
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1});
            this.grdBangLuong.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdBangLuong.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdBangLuong.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdBangLuong.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdBangLuong.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.grdBangLuong.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row;
            this.grdBangLuong.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.grdBangLuong.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.grdBangLuong.DisplayLayout.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Top;
            this.grdBangLuong.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "Arial";
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdBangLuong.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.grdBangLuong.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdBangLuong.DisplayLayout.Override.RowSelectorAppearance = appearance4;
            this.grdBangLuong.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdBangLuong.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.grdBangLuong.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            this.grdBangLuong.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdBangLuong.DisplayLayout.UseFixedHeaders = true;
            valueList1.Key = "Nhom";
            valueListItem1.DataValue = "Phụ cấp";
            valueListItem1.DisplayText = "Phụ cấp";
            valueListItem2.DataValue = "Thưởng";
            valueListItem2.DisplayText = "Thưởng";
            valueList1.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.grdBangLuong.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
            this.grdBangLuong.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdBangLuong.Location = new System.Drawing.Point(6, 18);
            this.grdBangLuong.Name = "grdBangLuong";
            this.grdBangLuong.Size = new System.Drawing.Size(579, 186);
            this.grdBangLuong.TabIndex = 28;
            this.grdBangLuong.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdBangLuong_InitializeLayout);
            // 
            // bdBangLuong
            // 
            this.bdBangLuong.DataSource = typeof(ERP_Library.BangLuongQuyetToanThueList);
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.grdDieuChinh);
            this.ultraGroupBox3.Location = new System.Drawing.Point(6, 317);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(584, 209);
            this.ultraGroupBox3.TabIndex = 2;
            this.ultraGroupBox3.Text = "Dữ Liệu Điều Chỉnh";
            // 
            // grdDieuChinh
            // 
            this.grdDieuChinh.DataSource = this.bdDieuChinh;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdDieuChinh.DisplayLayout.Appearance = appearance6;
            ultraGridColumn3.Header.Caption = "Diễn Giải";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Width = 300;
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Format = "#.###";
            ultraGridColumn9.Header.Caption = "Số Tiền";
            ultraGridColumn9.Header.VisiblePosition = 0;
            ultraGridColumn9.Width = 91;
            ultraGridColumn10.Header.VisiblePosition = 7;
            ultraGridColumn10.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            ultraGridBand2.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            summarySettings2.DisplayFormat = "TC={0}";
            summarySettings2.GroupBySummaryValueAppearance = appearance21;
            summarySettings2.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.Top;
            ultraGridBand2.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings2});
            this.grdDieuChinh.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdDieuChinh.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdDieuChinh.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.BorderColor = System.Drawing.SystemColors.Window;
            this.grdDieuChinh.DisplayLayout.GroupByBox.Appearance = appearance7;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdDieuChinh.DisplayLayout.GroupByBox.BandLabelAppearance = appearance8;
            this.grdDieuChinh.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdDieuChinh.DisplayLayout.GroupByBox.Hidden = true;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance9.BackColor2 = System.Drawing.SystemColors.Control;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdDieuChinh.DisplayLayout.GroupByBox.PromptAppearance = appearance9;
            this.grdDieuChinh.DisplayLayout.MaxColScrollRegions = 1;
            this.grdDieuChinh.DisplayLayout.MaxRowScrollRegions = 1;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdDieuChinh.DisplayLayout.Override.ActiveCellAppearance = appearance10;
            appearance11.BackColor = System.Drawing.SystemColors.Highlight;
            appearance11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdDieuChinh.DisplayLayout.Override.ActiveRowAppearance = appearance11;
            this.grdDieuChinh.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdDieuChinh.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.grdDieuChinh.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdDieuChinh.DisplayLayout.Override.CellAppearance = appearance13;
            this.grdDieuChinh.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdDieuChinh.DisplayLayout.Override.CellPadding = 0;
            appearance14.BackColor = System.Drawing.SystemColors.Control;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.grdDieuChinh.DisplayLayout.Override.GroupByRowAppearance = appearance14;
            appearance15.TextHAlignAsString = "Left";
            this.grdDieuChinh.DisplayLayout.Override.HeaderAppearance = appearance15;
            this.grdDieuChinh.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdDieuChinh.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            this.grdDieuChinh.DisplayLayout.Override.RowAppearance = appearance16;
            this.grdDieuChinh.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdDieuChinh.DisplayLayout.Override.TemplateAddRowAppearance = appearance17;
            this.grdDieuChinh.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdDieuChinh.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdDieuChinh.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdDieuChinh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDieuChinh.Location = new System.Drawing.Point(6, 18);
            this.grdDieuChinh.Name = "grdDieuChinh";
            this.grdDieuChinh.Size = new System.Drawing.Size(575, 186);
            this.grdDieuChinh.TabIndex = 0;
            this.grdDieuChinh.Text = "ultraGrid1";
            this.grdDieuChinh.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdDieuChinh_InitializeLayout);
            this.grdDieuChinh.BeforeRowUpdate += new Infragistics.Win.UltraWinGrid.CancelableRowEventHandler(this.grdDieuChinh_BeforeRowUpdate);
            this.grdDieuChinh.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.grdDieuChinh_BeforeRowsDeleted);
            // 
            // bdDieuChinh
            // 
            this.bdDieuChinh.AllowNew = true;
            this.bdDieuChinh.DataSource = typeof(ERP_Library.DieuChinhQuyetToanThueList);
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(174, 531);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 21);
            this.btnDongY.TabIndex = 3;
            this.btnDongY.Text = "Đồng Ý";
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 531);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 4;
            this.button1.Text = "Không";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bộ phận:";
            // 
            // frmDieuChinhQuyetToanTNCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 555);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.ultraGroupBox3);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.btnKhong);
            this.Name = "frmDieuChinhQuyetToanTNCN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều Chỉnh Quyết Toán Thuế TNCN Năm";
            ((System.ComponentModel.ISupportInitialize)(this.btnKhong)).EndInit();
            this.btnKhong.ResumeLayout(false);
            this.btnKhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBangLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdBangLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDieuChinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdDieuChinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox btnKhong;
        private System.Windows.Forms.Label lb_BoPhan;
        private System.Windows.Forms.Label bl_NhanVien;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdBangLuong;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTenBoPhan;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.BindingSource bdBangLuong;
        private System.Windows.Forms.BindingSource bdDieuChinh;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdDieuChinh;

    }
}
namespace PSC_ERP
{
    partial class frmBaoCaoChuyenKhoanRaSoat
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tổng hợp chuyển khoản ngân hàng  các bộ phận");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Chi tiết số tiền chuyển cho nhân viên của bộ phận");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Chi tiết thu nhập được chuyển khoản của nhân viên");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Tổng hợp thu nhập nhân viên được chuyển khoản");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("DS nhân viên chuyển khoản không hợp lệ");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.ultraCombo_NhanVien = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ultraCombo_NganHang = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.txtDenNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTuNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKyTen = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoPhan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.lblBoPhan = new System.Windows.Forms.Label();
            this.NhanvienListbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boPhanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDieuKien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_NhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_NganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhanvienListbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treeReport
            // 
            this.treeReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeReport.FullRowSelect = true;
            this.treeReport.HideSelection = false;
            this.treeReport.Location = new System.Drawing.Point(0, 0);
            this.treeReport.Name = "treeReport";
            treeNode1.Name = "tonghopbophan";
            treeNode1.Tag = "NganHang";
            treeNode1.Text = "Tổng hợp chuyển khoản ngân hàng  các bộ phận";
            treeNode2.Name = "chitietbophan";
            treeNode2.Tag = "NganHang;BoPhan";
            treeNode2.Text = "Chi tiết số tiền chuyển cho nhân viên của bộ phận";
            treeNode3.Name = "chitietnhanvienbophan";
            treeNode3.Tag = "NganHang;BoPhan;NhanVien";
            treeNode3.Text = "Chi tiết thu nhập được chuyển khoản của nhân viên";
            treeNode4.Name = "tonghopnhanvien";
            treeNode4.Tag = "NganHang;BoPhan;NhanVien";
            treeNode4.Text = "Tổng hợp thu nhập nhân viên được chuyển khoản";
            treeNode5.Name = "DSNhanVienKhongHopLe";
            treeNode5.Text = "DS nhân viên chuyển khoản không hợp lệ";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeReport.Size = new System.Drawing.Size(287, 299);
            this.treeReport.TabIndex = 0;
            this.treeReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeReport_AfterSelect);
            // 
            // pnlDieuKien
            // 
            this.pnlDieuKien.Controls.Add(this.ultraCombo_NhanVien);
            this.pnlDieuKien.Controls.Add(this.ultraCombo_NganHang);
            this.pnlDieuKien.Controls.Add(this.lblNhanVien);
            this.pnlDieuKien.Controls.Add(this.txtDenNgay);
            this.pnlDieuKien.Controls.Add(this.label3);
            this.pnlDieuKien.Controls.Add(this.txtTuNgay);
            this.pnlDieuKien.Controls.Add(this.label2);
            this.pnlDieuKien.Controls.Add(this.cmbKyTen);
            this.pnlDieuKien.Controls.Add(this.label1);
            this.pnlDieuKien.Controls.Add(this.cmbBoPhan);
            this.pnlDieuKien.Controls.Add(this.lblNganHang);
            this.pnlDieuKien.Controls.Add(this.btnClose);
            this.pnlDieuKien.Controls.Add(this.btnReport);
            this.pnlDieuKien.Controls.Add(this.lblBoPhan);
            this.pnlDieuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuKien.Location = new System.Drawing.Point(287, 0);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(341, 299);
            this.pnlDieuKien.TabIndex = 1;
            // 
            // ultraCombo_NhanVien
            // 
            this.ultraCombo_NhanVien.CheckedListSettings.CheckStateMember = "";
            this.ultraCombo_NhanVien.DataSource = this.NhanvienListbindingSource;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraCombo_NhanVien.DisplayLayout.Appearance = appearance14;
            this.ultraCombo_NhanVien.DisplayLayout.InterBandSpacing = 10;
            this.ultraCombo_NhanVien.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraCombo_NhanVien.DisplayLayout.MaxRowScrollRegions = 1;
            appearance15.BackColor = System.Drawing.Color.Transparent;
            this.ultraCombo_NhanVien.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BackColor = System.Drawing.SystemColors.Control;
            appearance16.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.ultraCombo_NhanVien.DisplayLayout.Override.CellAppearance = appearance16;
            this.ultraCombo_NhanVien.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance17.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraCombo_NhanVien.DisplayLayout.Override.HeaderAppearance = appearance17;
            this.ultraCombo_NhanVien.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ultraCombo_NhanVien.DisplayLayout.Override.RowSelectorAppearance = appearance18;
            appearance19.BackColor = System.Drawing.SystemColors.InactiveCaption;
            appearance19.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.ultraCombo_NhanVien.DisplayLayout.Override.SelectedRowAppearance = appearance19;
            this.ultraCombo_NhanVien.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ultraCombo_NhanVien.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.ultraCombo_NhanVien.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraCombo_NhanVien.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraCombo_NhanVien.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraCombo_NhanVien.DisplayMember = "TenDoiTuong";
            this.ultraCombo_NhanVien.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraCombo_NhanVien.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.ultraCombo_NhanVien.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ultraCombo_NhanVien.Location = new System.Drawing.Point(83, 109);
            this.ultraCombo_NhanVien.Name = "ultraCombo_NhanVien";
            this.ultraCombo_NhanVien.Size = new System.Drawing.Size(227, 22);
            this.ultraCombo_NhanVien.TabIndex = 32;
            this.ultraCombo_NhanVien.ValueMember = "MaDoiTuong";
            // 
            // ultraCombo_NganHang
            // 
            this.ultraCombo_NganHang.CheckedListSettings.CheckStateMember = "";
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ultraCombo_NganHang.DisplayLayout.Appearance = appearance1;
            this.ultraCombo_NganHang.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraCombo_NganHang.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraCombo_NganHang.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraCombo_NganHang.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ultraCombo_NganHang.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraCombo_NganHang.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.ultraCombo_NganHang.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraCombo_NganHang.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraCombo_NganHang.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ultraCombo_NganHang.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.ultraCombo_NganHang.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraCombo_NganHang.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.ultraCombo_NganHang.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ultraCombo_NganHang.DisplayLayout.Override.CellAppearance = appearance8;
            this.ultraCombo_NganHang.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ultraCombo_NganHang.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraCombo_NganHang.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.ultraCombo_NganHang.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.ultraCombo_NganHang.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraCombo_NganHang.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.ultraCombo_NganHang.DisplayLayout.Override.RowAppearance = appearance10;
            this.ultraCombo_NganHang.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ultraCombo_NganHang.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.ultraCombo_NganHang.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraCombo_NganHang.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraCombo_NganHang.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraCombo_NganHang.Location = new System.Drawing.Point(82, 50);
            this.ultraCombo_NganHang.Name = "ultraCombo_NganHang";
            this.ultraCombo_NganHang.Size = new System.Drawing.Size(228, 22);
            this.ultraCombo_NganHang.TabIndex = 31;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(6, 117);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(56, 13);
            this.lblNhanVien.TabIndex = 27;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtDenNgay.Location = new System.Drawing.Point(226, 24);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(83, 21);
            this.txtDenNgay.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "đến ngày";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtTuNgay.Location = new System.Drawing.Point(82, 24);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(78, 21);
            this.txtTuNgay.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Từ ngày";
            // 
            // cmbKyTen
            // 
            this.cmbKyTen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyTen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "Không có";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Người lập";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "Người lập, Thủ trưởng";
            valueListItem4.DataValue = 3;
            valueListItem4.DisplayText = "Người lập, BPT, Thủ trưởng";
            this.cmbKyTen.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4});
            this.cmbKyTen.Location = new System.Drawing.Point(83, 137);
            this.cmbKyTen.Name = "cmbKyTen";
            this.cmbKyTen.Size = new System.Drawing.Size(227, 21);
            this.cmbKyTen.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Ký tên";
            // 
            // cmbBoPhan
            // 
            this.cmbBoPhan.CheckedListSettings.CheckStateMember = "";
            this.cmbBoPhan.DataSource = this.boPhanListBindingSource;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cmbBoPhan.DisplayLayout.Appearance = appearance13;
            this.cmbBoPhan.DisplayLayout.InterBandSpacing = 10;
            this.cmbBoPhan.DisplayLayout.MaxColScrollRegions = 1;
            this.cmbBoPhan.DisplayLayout.MaxRowScrollRegions = 1;
            appearance20.BackColor = System.Drawing.Color.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.CardAreaAppearance = appearance20;
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.CellAppearance = appearance21;
            this.cmbBoPhan.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance22.BackColor = System.Drawing.SystemColors.Control;
            appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance22.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.cmbBoPhan.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbBoPhan.DisplayLayout.Override.RowSelectorAppearance = appearance23;
            appearance24.BackColor = System.Drawing.SystemColors.InactiveCaption;
            appearance24.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.SelectedRowAppearance = appearance24;
            this.cmbBoPhan.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbBoPhan.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.cmbBoPhan.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbBoPhan.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbBoPhan.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmbBoPhan.DisplayMember = "TenBoPhan";
            this.cmbBoPhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbBoPhan.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cmbBoPhan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbBoPhan.Location = new System.Drawing.Point(82, 78);
            this.cmbBoPhan.Name = "cmbBoPhan";
            this.cmbBoPhan.Size = new System.Drawing.Size(227, 22);
            this.cmbBoPhan.TabIndex = 11;
            this.cmbBoPhan.ValueMember = "MaBoPhan";
            this.cmbBoPhan.ValueChanged += new System.EventHandler(this.cmbBoPhan_ValueChanged);
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Location = new System.Drawing.Point(6, 60);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(60, 13);
            this.lblNganHang.TabIndex = 12;
            this.lblNganHang.Text = "Ngân hàng";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(154, 255);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 32);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(57, 255);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 32);
            this.btnReport.TabIndex = 15;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblBoPhan
            // 
            this.lblBoPhan.AutoSize = true;
            this.lblBoPhan.Location = new System.Drawing.Point(6, 87);
            this.lblBoPhan.Name = "lblBoPhan";
            this.lblBoPhan.Size = new System.Drawing.Size(47, 13);
            this.lblBoPhan.TabIndex = 10;
            this.lblBoPhan.Text = "Bộ phận";
            // 
            // frmBaoCaoChuyenKhoanRaSoat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 299);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaoCaoChuyenKhoanRaSoat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo chuyển khoản ngân hàng";
            this.Load += new System.EventHandler(this.frmBaoCaoChuyenKhoan_Load);
            this.pnlDieuKien.ResumeLayout(false);
            this.pnlDieuKien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_NhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_NganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhanvienListbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeReport;
        private System.Windows.Forms.Panel pnlDieuKien;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnReport;
        private System.Windows.Forms.BindingSource boPhanListBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyTen;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbBoPhan;
        private System.Windows.Forms.Label lblNganHang;
        private System.Windows.Forms.Label lblBoPhan;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDenNgay;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtTuNgay;
        private System.Windows.Forms.Label lblNhanVien;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraCombo_NganHang;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraCombo_NhanVien;
        private System.Windows.Forms.BindingSource NhanvienListbindingSource;
    }
}
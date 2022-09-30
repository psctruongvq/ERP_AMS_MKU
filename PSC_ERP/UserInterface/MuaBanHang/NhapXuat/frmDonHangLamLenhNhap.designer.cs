namespace PSC_ERP
{
    partial class frmDonHangLamLenhNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonHangLamLenhNhap));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.grdu_DanhSachDonHang = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.cbx_CheckAll = new System.Windows.Forms.CheckBox();
            this.txt_ThongTinTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.donHangBanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donHangMuaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donTraHangMuaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.donNhanHangTraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_DanhSachDonHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donHangBanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donHangMuaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donTraHangMuaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donNhanHangTraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblIn,
            this.toolStripButton1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(611, 25);
            this.tlsMain.TabIndex = 15;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(52, 22);
            this.tlslblLuu.Text = "&Chọn";
            this.tlslblLuu.ToolTipText = "Ctr+C";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblIn
            // 
            this.tlslblIn.Image = ((System.Drawing.Image)(resources.GetObject("tlslblIn.Image")));
            this.tlslblIn.Name = "tlslblIn";
            this.tlslblIn.Size = new System.Drawing.Size(37, 22);
            this.tlslblIn.Text = "&In";
            this.tlslblIn.ToolTipText = "Ctr+I";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(67, 22);
            this.tlslblTroGiup.Text = "Trợ &Giúp";
            this.tlslblTroGiup.ToolTipText = "Ctr+G";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblThoat
            // 
            this.tlslblThoat.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThoat.Image")));
            this.tlslblThoat.Name = "tlslblThoat";
            this.tlslblThoat.Size = new System.Drawing.Size(55, 22);
            this.tlslblThoat.Text = "Th&oát";
            this.tlslblThoat.ToolTipText = "Ctr+O";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // grdu_DanhSachDonHang
            // 
            this.grdu_DanhSachDonHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdu_DanhSachDonHang.DisplayLayout.Appearance = appearance1;
            this.grdu_DanhSachDonHang.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdu_DanhSachDonHang.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdu_DanhSachDonHang.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdu_DanhSachDonHang.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdu_DanhSachDonHang.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdu_DanhSachDonHang.DisplayLayout.GroupByBox.Hidden = true;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdu_DanhSachDonHang.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdu_DanhSachDonHang.DisplayLayout.MaxColScrollRegions = 1;
            this.grdu_DanhSachDonHang.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.RowAppearance = appearance11;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdu_DanhSachDonHang.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdu_DanhSachDonHang.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdu_DanhSachDonHang.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdu_DanhSachDonHang.Location = new System.Drawing.Point(12, 65);
            this.grdu_DanhSachDonHang.Name = "grdu_DanhSachDonHang";
            this.grdu_DanhSachDonHang.Size = new System.Drawing.Size(587, 320);
            this.grdu_DanhSachDonHang.TabIndex = 1;
            this.grdu_DanhSachDonHang.Text = "ultraGrid1";
            this.grdu_DanhSachDonHang.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdu_DanhSachDonHang_AfterCellUpdate);
            // 
            // cbx_CheckAll
            // 
            this.cbx_CheckAll.AutoSize = true;
            this.cbx_CheckAll.Location = new System.Drawing.Point(17, 37);
            this.cbx_CheckAll.Name = "cbx_CheckAll";
            this.cbx_CheckAll.Size = new System.Drawing.Size(86, 17);
            this.cbx_CheckAll.TabIndex = 0;
            this.cbx_CheckAll.Text = "Chọn Tất Cả";
            this.cbx_CheckAll.UseVisualStyleBackColor = true;
            this.cbx_CheckAll.CheckedChanged += new System.EventHandler(this.cbx_CheckAll_CheckedChanged);
            // 
            // txt_ThongTinTimKiem
            // 
            this.txt_ThongTinTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ThongTinTimKiem.Location = new System.Drawing.Point(264, 35);
            this.txt_ThongTinTimKiem.Name = "txt_ThongTinTimKiem";
            this.txt_ThongTinTimKiem.Size = new System.Drawing.Size(238, 20);
            this.txt_ThongTinTimKiem.TabIndex = 0;
            this.txt_ThongTinTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ThongTinTimKiem_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Thông Tin Tìm Kiếm";
            // 
            // donHangBanBindingSource
            // 
            this.donHangBanBindingSource.DataSource = typeof(ERP_Library.DonHangBanList);
            // 
            // donHangMuaBindingSource
            // 
            this.donHangMuaBindingSource.DataSource = typeof(ERP_Library.DonHangMuaList);
            // 
            // donTraHangMuaBindingSource
            // 
            this.donTraHangMuaBindingSource.DataSource = typeof(ERP_Library.DonTraHangMuaList);
            // 
            // donNhanHangTraBindingSource
            // 
            this.donNhanHangTraBindingSource.DataSource = typeof(ERP_Library.DonNhanHangTraList);
            // 
            // frmDonHangLamLenhNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 397);
            this.Controls.Add(this.txt_ThongTinTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_CheckAll);
            this.Controls.Add(this.grdu_DanhSachDonHang);
            this.Controls.Add(this.tlsMain);
            this.Name = "frmDonHangLamLenhNhap";
            this.Text = "Danh Sách Đơn Hàng Lập Lệnh";
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_DanhSachDonHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donHangBanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donHangMuaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donTraHangMuaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donNhanHangTraBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_DanhSachDonHang;
        private System.Windows.Forms.BindingSource donHangBanBindingSource;
        private System.Windows.Forms.BindingSource donHangMuaBindingSource;
        private System.Windows.Forms.BindingSource donTraHangMuaBindingSource;
        private System.Windows.Forms.BindingSource donNhanHangTraBindingSource;
        private System.Windows.Forms.CheckBox cbx_CheckAll;
        private System.Windows.Forms.TextBox txt_ThongTinTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
    }
}
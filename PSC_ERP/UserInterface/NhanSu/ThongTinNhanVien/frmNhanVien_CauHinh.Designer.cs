namespace PSC_ERP
{
    partial class frmNhanVien_CauHinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVien_CauHinh));
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVien_CauHinh", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ten");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoaiDuLieu", -1, 6679547);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCauHinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Stt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLy");
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(6679547);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdData = new System.Windows.Forms.BindingSource(this.components);
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblXoa,
            this.toolStripSeparator3,
            this.tlslblUndo,
            this.toolStripButton1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(492, 25);
            this.tlsMain.TabIndex = 25;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(49, 22);
            this.tlslblLuu.Text = "&Lưu";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblXoa
            // 
            this.tlslblXoa.Image = ((System.Drawing.Image)(resources.GetObject("tlslblXoa.Image")));
            this.tlslblXoa.Name = "tlslblXoa";
            this.tlslblXoa.Size = new System.Drawing.Size(50, 22);
            this.tlslblXoa.Text = "&Xóa";
            this.tlslblXoa.Click += new System.EventHandler(this.tlslblXoa_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(57, 22);
            this.tlslblUndo.Text = "&Undo";
            this.tlslblUndo.Click += new System.EventHandler(this.tlslblUndo_Click);
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
            this.tlslblTroGiup.Size = new System.Drawing.Size(77, 22);
            this.tlslblTroGiup.Text = "Trợ &Giúp";
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
            this.tlslblThoat.Size = new System.Drawing.Size(61, 22);
            this.tlslblThoat.Text = "Th&oát";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // grdData
            // 
            this.grdData.DataSource = this.bdData;
            appearance37.BackColor = System.Drawing.Color.White;
            this.grdData.DisplayLayout.Appearance = appearance37;
            this.grdData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.Header.Caption = "Tên dữ liệu";
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Width = 332;
            ultraGridColumn2.DefaultCellValue = "Ký tự";
            ultraGridColumn2.Header.Caption = "Loại dữ liệu";
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Width = 95;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.Width = 262;
            ultraGridColumn4.Format = "#";
            ultraGridColumn4.Header.Caption = "STT";
            ultraGridColumn4.Header.VisiblePosition = 0;
            ultraGridColumn4.MaskInput = "nnnnnnnnn";
            ultraGridColumn4.Width = 44;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Width = 423;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance38.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance38;
            this.grdData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance39.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance39.FontData.BoldAsString = "True";
            appearance39.FontData.Name = "Arial";
            appearance39.FontData.SizeInPoints = 10F;
            appearance39.ForeColor = System.Drawing.Color.White;
            appearance39.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdData.DisplayLayout.Override.HeaderAppearance = appearance39;
            this.grdData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.ExternalSortMulti;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance40.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.RowSelectorAppearance = appearance40;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance41.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.SelectedRowAppearance = appearance41;
            this.grdData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdData.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell;
            valueList1.Key = "LoaiDuLieu";
            valueListItem1.DataValue = "Số";
            valueListItem2.DataValue = "Ký tự";
            valueListItem3.DataValue = "Ngày";
            valueListItem4.DataValue = "Yes/No";
            valueList1.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4});
            this.grdData.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 25);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(492, 445);
            this.grdData.TabIndex = 26;
            // 
            // bdData
            // 
            this.bdData.DataSource = typeof(ERP_Library.NhanVien_CauHinhList);
            // 
            // frmNhanVien_CauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 470);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.tlsMain);
            this.Name = "frmNhanVien_CauHinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt dữ liệu nhân viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhanVien_CauHinh_FormClosing);
            this.Load += new System.EventHandler(this.frmNhanVien_CauHinh_Load);
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdData;
        private System.Windows.Forms.BindingSource bdData;
    }
}
namespace PSC_ERP
{
    partial class frmChamNgoaiGioChuaDuyet
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
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChamNgoaiGioChuaDuyetChild", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKyTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KyCham");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KyLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKyChamCong");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdData = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.DataSource = this.bdData;
            appearance27.BackColor = System.Drawing.Color.White;
            this.grdData.DisplayLayout.Appearance = appearance27;
            this.grdData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.Header.Caption = "Bộ phận";
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Width = 174;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.Width = 193;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.Width = 176;
            ultraGridColumn4.Header.Caption = "Kỳ chấm";
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Width = 162;
            ultraGridColumn5.Header.Caption = "Tháng lương";
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn5.Width = 149;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.Width = 299;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.GroupByBox.Hidden = true;
            this.grdData.DisplayLayout.MaxColScrollRegions = 1;
            this.grdData.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance28.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance28;
            this.grdData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdData.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance29.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance29.FontData.BoldAsString = "True";
            appearance29.FontData.Name = "Arial";
            appearance29.FontData.SizeInPoints = 10F;
            appearance29.ForeColor = System.Drawing.Color.White;
            appearance29.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdData.DisplayLayout.Override.HeaderAppearance = appearance29;
            this.grdData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance30.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.RowSelectorAppearance = appearance30;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance31.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.SelectedRowAppearance = appearance31;
            this.grdData.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdData.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdData.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdData.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdData.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdData.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(506, 286);
            this.grdData.TabIndex = 0;
            // 
            // bdData
            // 
            this.bdData.DataSource = typeof(ERP_Library.ChamNgoaiGioChuaDuyetList);
            // 
            // frmChamNgoaiGioChuaDuyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 286);
            this.Controls.Add(this.grdData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChamNgoaiGioChuaDuyet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách chấm ngoài giờ chưa duyệt";
            this.Load += new System.EventHandler(this.frmChamNgoaiGioChuaDuyet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid grdData;
        private System.Windows.Forms.BindingSource bdData;
    }
}
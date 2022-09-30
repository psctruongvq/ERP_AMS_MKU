namespace PSC_ERPNew.Main
{
    partial class frmTongHopTrichKhauHao_TichHopFAST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTongHopTrichKhauHao_TichHopFAST));
            this.tableLayout_frm = new System.Windows.Forms.TableLayoutPanel();
            this.gridC_TichHopFast = new DevExpress.XtraGrid.GridControl();
            this.bdSource_TichHopFast = new System.Windows.Forms.BindingSource(this.components);
            this.gridV_TichHopFast = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVoucherDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComments = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostCenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThucHienTichHop_Fast = new DevExpress.XtraBars.BarButtonItem();
            this.btnXuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tableLayout_frm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridC_TichHopFast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSource_TichHopFast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_TichHopFast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayout_frm
            // 
            this.tableLayout_frm.ColumnCount = 1;
            this.tableLayout_frm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout_frm.Controls.Add(this.gridC_TichHopFast, 0, 0);
            this.tableLayout_frm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout_frm.Location = new System.Drawing.Point(0, 44);
            this.tableLayout_frm.Name = "tableLayout_frm";
            this.tableLayout_frm.RowCount = 1;
            this.tableLayout_frm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.64027F));
            this.tableLayout_frm.Size = new System.Drawing.Size(1177, 515);
            this.tableLayout_frm.TabIndex = 0;
            // 
            // gridC_TichHopFast
            // 
            this.gridC_TichHopFast.DataSource = this.bdSource_TichHopFast;
            this.gridC_TichHopFast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridC_TichHopFast.Location = new System.Drawing.Point(3, 3);
            this.gridC_TichHopFast.MainView = this.gridV_TichHopFast;
            this.gridC_TichHopFast.Name = "gridC_TichHopFast";
            this.gridC_TichHopFast.Size = new System.Drawing.Size(1171, 509);
            this.gridC_TichHopFast.TabIndex = 0;
            this.gridC_TichHopFast.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridV_TichHopFast});
            // 
            // bdSource_TichHopFast
            // 
            this.bdSource_TichHopFast.DataSource = typeof(PSC_ERP_Business.Main.Model.spd_TongHopTrichKhauHao_TichHopFAST_Result);
            // 
            // gridV_TichHopFast
            // 
            this.gridV_TichHopFast.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompany,
            this.colVoucherDate,
            this.colDepartmentCode,
            this.colAccDebit,
            this.colAccCredit,
            this.colAmount,
            this.colComments,
            this.colCostCenter});
            this.gridV_TichHopFast.GridControl = this.gridC_TichHopFast;
            this.gridV_TichHopFast.Name = "gridV_TichHopFast";
            this.gridV_TichHopFast.OptionsView.ShowAutoFilterRow = true;
            this.gridV_TichHopFast.OptionsView.ShowFooter = true;
            // 
            // colCompany
            // 
            this.colCompany.FieldName = "Company";
            this.colCompany.Name = "colCompany";
            this.colCompany.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 0;
            // 
            // colVoucherDate
            // 
            this.colVoucherDate.FieldName = "VoucherDate";
            this.colVoucherDate.Name = "colVoucherDate";
            this.colVoucherDate.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVoucherDate.Visible = true;
            this.colVoucherDate.VisibleIndex = 1;
            // 
            // colDepartmentCode
            // 
            this.colDepartmentCode.FieldName = "DepartmentCode";
            this.colDepartmentCode.Name = "colDepartmentCode";
            this.colDepartmentCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepartmentCode.Visible = true;
            this.colDepartmentCode.VisibleIndex = 2;
            // 
            // colAccDebit
            // 
            this.colAccDebit.FieldName = "AccDebit";
            this.colAccDebit.Name = "colAccDebit";
            this.colAccDebit.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAccDebit.Visible = true;
            this.colAccDebit.VisibleIndex = 3;
            // 
            // colAccCredit
            // 
            this.colAccCredit.FieldName = "AccCredit";
            this.colAccCredit.Name = "colAccCredit";
            this.colAccCredit.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAccCredit.Visible = true;
            this.colAccCredit.VisibleIndex = 4;
            // 
            // colAmount
            // 
            this.colAmount.DisplayFormat.FormatString = "n0";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "SUM={0:n0}")});
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 5;
            // 
            // colComments
            // 
            this.colComments.FieldName = "Comments";
            this.colComments.Name = "colComments";
            this.colComments.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colComments.Visible = true;
            this.colComments.VisibleIndex = 6;
            // 
            // colCostCenter
            // 
            this.colCostCenter.FieldName = "CostCenter";
            this.colCostCenter.Name = "colCostCenter";
            this.colCostCenter.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCostCenter.Visible = true;
            this.colCostCenter.VisibleIndex = 7;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThoat,
            this.btnThucHienTichHop_Fast,
            this.btnXuatExcel});
            this.barManager.MaxItemId = 3;
            this.barManager.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(71, 147);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThucHienTichHop_Fast, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXuatExcel, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThucHienTichHop_Fast
            // 
            this.btnThucHienTichHop_Fast.Caption = "Thực Hiện Tích Hợp - Fast";
            this.btnThucHienTichHop_Fast.Id = 1;
            this.btnThucHienTichHop_Fast.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThucHienTichHop_Fast.ImageOptions.Image")));
            this.btnThucHienTichHop_Fast.Name = "btnThucHienTichHop_Fast";
            this.btnThucHienTichHop_Fast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThucHienTichHop_Fast_ItemClick);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Caption = "Xuất Excel";
            this.btnXuatExcel.Id = 2;
            this.btnXuatExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.ImageOptions.Image")));
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXuatExcel_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 0;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1177, 44);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 559);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1177, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 44);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 515);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1177, 44);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 515);
            // 
            // frmTongHopTrichKhauHao_TichHopFAST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 581);
            this.Controls.Add(this.tableLayout_frm);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmTongHopTrichKhauHao_TichHopFAST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng Hợp Trích Khấu Hao - Tích Hợp FAST";
            this.Load += new System.EventHandler(this.frmTongHopTrichKhauHao_TichHopFAST_Load);
            this.tableLayout_frm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridC_TichHopFast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSource_TichHopFast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_TichHopFast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout_frm;
        private DevExpress.XtraGrid.GridControl gridC_TichHopFast;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_TichHopFast;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThucHienTichHop_Fast;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource bdSource_TichHopFast;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colVoucherDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAccDebit;
        private DevExpress.XtraGrid.Columns.GridColumn colAccCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colComments;
        private DevExpress.XtraGrid.Columns.GridColumn colCostCenter;
        private DevExpress.XtraBars.BarButtonItem btnXuatExcel;
    }
}
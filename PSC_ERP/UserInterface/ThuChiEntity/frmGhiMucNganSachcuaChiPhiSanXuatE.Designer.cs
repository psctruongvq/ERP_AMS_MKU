namespace PSC_ERP.ThuChiEntity
{
    partial class frmGhiMucNganSachcuaChiPhiSanXuatE
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
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGhiMucNganSachcuaChiPhiSanXuatE));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnDuaDuLieuVeChungTu = new DevExpress.XtraBars.BarButtonItem();
            this.tbnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.tblButToanMucNganSachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblTieuMucNganSachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdLUChuognTrinh = new DevExpress.XtraEditors.GridLookUpEdit();
            this.tblnsChuongTrinhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSoTien = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblButToanMucNganSachBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTieuMucNganSachBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLUChuognTrinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblnsChuongTrinhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDuaDuLieuVeChungTu,
            this.tbnXoa});
            this.barManager1.MaxItemId = 12;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDuaDuLieuVeChungTu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.tbnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnDuaDuLieuVeChungTu
            // 
            this.btnDuaDuLieuVeChungTu.Caption = "Lưu và Về chứng từ";
            this.btnDuaDuLieuVeChungTu.Id = 8;
            this.btnDuaDuLieuVeChungTu.ImageIndex = 10;
            this.btnDuaDuLieuVeChungTu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B));
            this.btnDuaDuLieuVeChungTu.Name = "btnDuaDuLieuVeChungTu";
            toolTipTitleItem3.Text = "Ctrl+B";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnDuaDuLieuVeChungTu.SuperTip = superToolTip3;
            this.btnDuaDuLieuVeChungTu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDuaDuLieuVeChungTu_ItemClick);
            // 
            // tbnXoa
            // 
            this.tbnXoa.Caption = "Xóa";
            this.tbnXoa.Id = 11;
            this.tbnXoa.ImageIndex = 3;
            this.tbnXoa.Name = "tbnXoa";
            this.tbnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tbnXoa_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1024, 37);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 661);
            this.barDockControlBottom.Size = new System.Drawing.Size(1024, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 37);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 624);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1024, 37);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 624);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add64.png");
            this.imageList1.Images.SetKeyName(1, "undo64.png");
            this.imageList1.Images.SetKeyName(2, "1337595172_file_edit.png");
            this.imageList1.Images.SetKeyName(3, "1343360966_file_delete.png");
            this.imageList1.Images.SetKeyName(4, "save64.png");
            this.imageList1.Images.SetKeyName(5, "1337595258_Gnome-View-Refresh-64.png");
            this.imageList1.Images.SetKeyName(6, "find64.png");
            this.imageList1.Images.SetKeyName(7, "printer64.png");
            this.imageList1.Images.SetKeyName(8, "help64.png");
            this.imageList1.Images.SetKeyName(9, "exit64.png");
            this.imageList1.Images.SetKeyName(10, "1346734888_import.png");
            this.imageList1.Images.SetKeyName(11, "1381303873_131730.ico");
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(184, 407);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 6;
            this.txtBlackHole.TabStop = false;
            // 
            // tblButToanMucNganSachBindingSource
            // 
            this.tblButToanMucNganSachBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblButToan_MucNganSach);
            // 
            // tblTieuMucNganSachBindingSource
            // 
            this.tblTieuMucNganSachBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTieuMucNganSach);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.grdLUChuognTrinh);
            this.groupControl1.Controls.Add(this.txtSoTien);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 37);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1024, 81);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "Thông tin chi phí sản xuất";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(280, 30);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 15);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "Chương trình:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(59, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 15);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Số tiền:";
            // 
            // grdLUChuognTrinh
            // 
            this.grdLUChuognTrinh.Location = new System.Drawing.Point(366, 27);
            this.grdLUChuognTrinh.Name = "grdLUChuognTrinh";
            this.grdLUChuognTrinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLUChuognTrinh.Properties.DataSource = this.tblnsChuongTrinhBindingSource;
            this.grdLUChuognTrinh.Properties.DisplayMember = "TenChuongTrinh";
            this.grdLUChuognTrinh.Properties.NullText = "<<Không chọn>>";
            this.grdLUChuognTrinh.Properties.ReadOnly = true;
            this.grdLUChuognTrinh.Properties.ValueMember = "MaChuongTrinh";
            this.grdLUChuognTrinh.Properties.View = this.gridView3;
            this.grdLUChuognTrinh.Size = new System.Drawing.Size(454, 20);
            this.grdLUChuognTrinh.TabIndex = 1;
            // 
            // tblnsChuongTrinhBindingSource
            // 
            this.tblnsChuongTrinhBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblnsChuongTrinh);
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowAutoFilterRow = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(105, 27);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Properties.DisplayFormat.FormatString = "n0";
            this.txtSoTien.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoTien.Properties.EditFormat.FormatString = "n0";
            this.txtSoTien.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoTien.Properties.Mask.EditMask = "n0";
            this.txtSoTien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoTien.Properties.ReadOnly = true;
            this.txtSoTien.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSoTien.Size = new System.Drawing.Size(160, 20);
            this.txtSoTien.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 118);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1024, 543);
            this.gridControl1.TabIndex = 33;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // frmGhiMucNganSachcuaChiPhiSanXuatE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 661);
            this.ControlBox = false;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmGhiMucNganSachcuaChiPhiSanXuatE";
            this.Text = "Ghi mục ngân sách theo bút toán và chi phí sản xuất";
            this.Load += new System.EventHandler(this.frmDialogDanhSachGhiMucNganSachTheoButToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblButToanMucNganSachBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTieuMucNganSachBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLUChuognTrinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblnsChuongTrinhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtBlackHole;
        private DevExpress.XtraBars.BarButtonItem btnDuaDuLieuVeChungTu;
        private System.Windows.Forms.BindingSource tblButToanMucNganSachBindingSource;
        private System.Windows.Forms.BindingSource tblTieuMucNganSachBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GridLookUpEdit grdLUChuognTrinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.TextEdit txtSoTien;
        private System.Windows.Forms.BindingSource tblnsChuongTrinhBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem tbnXoa;
    }
}
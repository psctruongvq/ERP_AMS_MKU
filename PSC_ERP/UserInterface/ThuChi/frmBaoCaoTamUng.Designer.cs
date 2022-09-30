namespace PSC_ERP
{
    partial class frmBaoCaoTamUng
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
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Báo Cáo Tạm Ứng ");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Báo Cáo Tạm Ứng Chi Tiết");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Báo cáo tạm ứng chi tiết - ĐV Cấp 2");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Giấy xác nhận số dư tạm ứng");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_lydo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbl_NhanVien = new System.Windows.Forms.Label();
            this.cmbu_ChuongTrinh = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource1_ChuongTrinh = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.dateTuNgay1 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dateDenNgay1 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDoiTuong = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource2_DoiTuong = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grdLUED_DoiTuong = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdLUED_ChuongTrinh = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlDieuKien.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_lydo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_ChuongTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChuongTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_DoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLUED_DoiTuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLUED_ChuongTrinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeReport
            // 
            this.treeReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeReport.FullRowSelect = true;
            this.treeReport.HideSelection = false;
            this.treeReport.Location = new System.Drawing.Point(0, 0);
            this.treeReport.Name = "treeReport";
            treeNode13.Name = "Node1";
            treeNode13.Text = "Báo Cáo Tạm Ứng ";
            treeNode14.Name = "Node0";
            treeNode14.Text = "Báo Cáo Tạm Ứng Chi Tiết";
            treeNode15.Name = "Node_TamUngCap2";
            treeNode15.Text = "Báo cáo tạm ứng chi tiết - ĐV Cấp 2";
            treeNode16.Name = "Node_tamung";
            treeNode16.Text = "Giấy xác nhận số dư tạm ứng";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            this.treeReport.Size = new System.Drawing.Size(301, 611);
            this.treeReport.TabIndex = 1;
            // 
            // pnlDieuKien
            // 
            this.pnlDieuKien.Controls.Add(this.groupBox1);
            this.pnlDieuKien.Controls.Add(this.btnClose);
            this.pnlDieuKien.Controls.Add(this.btnReport);
            this.pnlDieuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuKien.Location = new System.Drawing.Point(301, 0);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(380, 611);
            this.pnlDieuKien.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdLUED_ChuongTrinh);
            this.groupBox1.Controls.Add(this.grdLUED_DoiTuong);
            this.groupBox1.Controls.Add(this.txt_lydo);
            this.groupBox1.Controls.Add(this.lbl_NhanVien);
            this.groupBox1.Controls.Add(this.cmbu_ChuongTrinh);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTuNgay1);
            this.groupBox1.Controls.Add(this.dateDenNgay1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbDoiTuong);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 159);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều Kiện";
            // 
            // txt_lydo
            // 
            this.txt_lydo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txt_lydo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lydo.Location = new System.Drawing.Point(96, 126);
            this.txt_lydo.Name = "txt_lydo";
            this.txt_lydo.Size = new System.Drawing.Size(216, 21);
            this.txt_lydo.TabIndex = 78;
            // 
            // lbl_NhanVien
            // 
            this.lbl_NhanVien.AutoSize = true;
            this.lbl_NhanVien.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NhanVien.Location = new System.Drawing.Point(23, 130);
            this.lbl_NhanVien.Name = "lbl_NhanVien";
            this.lbl_NhanVien.Size = new System.Drawing.Size(38, 14);
            this.lbl_NhanVien.TabIndex = 77;
            this.lbl_NhanVien.Text = "Lý Do ";
            // 
            // cmbu_ChuongTrinh
            // 
            this.cmbu_ChuongTrinh.DataSource = this.bindingSource1_ChuongTrinh;
            this.cmbu_ChuongTrinh.DisplayMember = "TenChuongTrinh";
            this.cmbu_ChuongTrinh.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_ChuongTrinh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_ChuongTrinh.Location = new System.Drawing.Point(96, 98);
            this.cmbu_ChuongTrinh.Name = "cmbu_ChuongTrinh";
            this.cmbu_ChuongTrinh.Size = new System.Drawing.Size(216, 22);
            this.cmbu_ChuongTrinh.TabIndex = 1000;
            this.cmbu_ChuongTrinh.ValueMember = "MaChuongTrinh";
            this.cmbu_ChuongTrinh.Visible = false;
            this.cmbu_ChuongTrinh.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_ChuongTrinh_InitializeLayout);
            this.cmbu_ChuongTrinh.ValueChanged += new System.EventHandler(this.cmbu_ChuongTrinh_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 14);
            this.label8.TabIndex = 76;
            this.label8.Text = "Chương Trình";
            // 
            // dateTuNgay1
            // 
            appearance7.BackColor = System.Drawing.SystemColors.Info;
            this.dateTuNgay1.Appearance = appearance7;
            this.dateTuNgay1.BackColor = System.Drawing.SystemColors.Info;
            this.dateTuNgay1.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTuNgay1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dateTuNgay1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTuNgay1.FormatString = "dd/MM/yyyy";
            this.dateTuNgay1.Location = new System.Drawing.Point(96, 16);
            this.dateTuNgay1.MaskInput = "{LOC}dd/mm/yyyy";
            this.dateTuNgay1.Name = "dateTuNgay1";
            this.dateTuNgay1.Size = new System.Drawing.Size(216, 21);
            this.dateTuNgay1.TabIndex = 1;
            this.dateTuNgay1.Value = null;
            // 
            // dateDenNgay1
            // 
            appearance8.BackColor = System.Drawing.SystemColors.Info;
            this.dateDenNgay1.Appearance = appearance8;
            this.dateDenNgay1.BackColor = System.Drawing.SystemColors.Info;
            this.dateDenNgay1.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateDenNgay1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dateDenNgay1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDenNgay1.FormatString = "dd/MM/yyyy";
            this.dateDenNgay1.Location = new System.Drawing.Point(96, 43);
            this.dateDenNgay1.MaskInput = "{LOC}dd/mm/yyyy";
            this.dateDenNgay1.Name = "dateDenNgay1";
            this.dateDenNgay1.Size = new System.Drawing.Size(216, 21);
            this.dateDenNgay1.TabIndex = 2;
            this.dateDenNgay1.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Từ Ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Đến Ngày";
            // 
            // cbDoiTuong
            // 
            this.cbDoiTuong.DataSource = this.bindingSource2_DoiTuong;
            this.cbDoiTuong.DisplayMember = "TenDoiTuong";
            this.cbDoiTuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbDoiTuong.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoiTuong.Location = new System.Drawing.Point(96, 70);
            this.cbDoiTuong.Name = "cbDoiTuong";
            this.cbDoiTuong.Size = new System.Drawing.Size(216, 22);
            this.cbDoiTuong.TabIndex = 1000;
            this.cbDoiTuong.ValueMember = "MaDoiTuong";
            this.cbDoiTuong.Visible = false;
            this.cbDoiTuong.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbNhanVien_InitializeLayout);
            this.cbDoiTuong.ValueChanged += new System.EventHandler(this.cbNhanVien_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 14);
            this.label9.TabIndex = 74;
            this.label9.Text = "Khách Hàng";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(208, 204);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 32);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(103, 204);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 32);
            this.btnReport.TabIndex = 13;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // grdLUED_DoiTuong
            // 
            this.grdLUED_DoiTuong.Location = new System.Drawing.Point(96, 71);
            this.grdLUED_DoiTuong.Name = "grdLUED_DoiTuong";
            this.grdLUED_DoiTuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLUED_DoiTuong.Properties.View = this.gridLookUpEdit1View;
            this.grdLUED_DoiTuong.Size = new System.Drawing.Size(216, 20);
            this.grdLUED_DoiTuong.TabIndex = 4;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // grdLUED_ChuongTrinh
            // 
            this.grdLUED_ChuongTrinh.Location = new System.Drawing.Point(96, 99);
            this.grdLUED_ChuongTrinh.Name = "grdLUED_ChuongTrinh";
            this.grdLUED_ChuongTrinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLUED_ChuongTrinh.Properties.View = this.gridView1;
            this.grdLUED_ChuongTrinh.Size = new System.Drawing.Size(216, 20);
            this.grdLUED_ChuongTrinh.TabIndex = 5;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // frmBaoCaoTamUng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 611);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.Name = "frmBaoCaoTamUng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Tạm Ứng";
            this.Load += new System.EventHandler(this.frmBaoCaoThuLao_Load);
            this.pnlDieuKien.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_lydo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_ChuongTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChuongTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_DoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLUED_DoiTuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLUED_ChuongTrinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeReport;
        private System.Windows.Forms.Panel pnlDieuKien;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbDoiTuong;
        private System.Windows.Forms.BindingSource bindingSource2_DoiTuong;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateDenNgay1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateTuNgay1;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_ChuongTrinh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bindingSource1_ChuongTrinh;
        private System.Windows.Forms.ImageList imageList1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txt_lydo;
        private System.Windows.Forms.Label lbl_NhanVien;
        private DevExpress.XtraEditors.GridLookUpEdit grdLUED_ChuongTrinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GridLookUpEdit grdLUED_DoiTuong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;

    }
}

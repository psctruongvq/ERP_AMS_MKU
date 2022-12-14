namespace PSC_ERP
{
    partial class frmBaoCaoCongDoan
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Danh sách chi tiết nộp công đoàn");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Sổ Thu Chi Ngân Sách Công Đoàn Cơ Sơ");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Sổ Chi Tiết Tài Khoản");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Bảng kê chi tiết", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Tổng hợp nộp công đoàn");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Báo cáo tổng hợp", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.txtQui = new System.Windows.Forms.NumericUpDown();
            this.lblQui = new System.Windows.Forms.Label();
            this.ultraCombo_TaiKhoan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ultraDateTimeEditor_DenNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.ultraDateTimeEditor_TuNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbKyTen = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.boPhanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.heThongTaiKhoan1ListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDieuKien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_TaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor_DenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor_TuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heThongTaiKhoan1ListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treeReport
            // 
            this.treeReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeReport.FullRowSelect = true;
            this.treeReport.HideSelection = false;
            this.treeReport.Location = new System.Drawing.Point(0, 0);
            this.treeReport.Name = "treeReport";
            treeNode1.Name = "nodeCongDoanPhi";
            treeNode1.Tag = "BoPhan,NganHang,LoaiNV,HinhThuc";
            treeNode1.Text = "Danh sách chi tiết nộp công đoàn";
            treeNode2.Name = "Node_ThuChiNganSachCongDoanCoSo";
            treeNode2.Text = "Sổ Thu Chi Ngân Sách Công Đoàn Cơ Sơ";
            treeNode3.Name = "Node_SoChiTietTaiKhoan";
            treeNode3.Text = "Sổ Chi Tiết Tài Khoản";
            treeNode4.Name = "chitietnhanvien";
            treeNode4.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode4.Text = "Bảng kê chi tiết";
            treeNode5.Name = "nodeTongHopCongDoan";
            treeNode5.Tag = "LoaiNV,HinhThuc";
            treeNode5.Text = "Tổng hợp nộp công đoàn";
            treeNode6.Name = "tonghop";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode6.Text = "Báo cáo tổng hợp";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode6});
            this.treeReport.Size = new System.Drawing.Size(350, 231);
            this.treeReport.TabIndex = 0;
            // 
            // pnlDieuKien
            // 
            this.pnlDieuKien.Controls.Add(this.txtNam);
            this.pnlDieuKien.Controls.Add(this.lblNam);
            this.pnlDieuKien.Controls.Add(this.txtQui);
            this.pnlDieuKien.Controls.Add(this.lblQui);
            this.pnlDieuKien.Controls.Add(this.ultraCombo_TaiKhoan);
            this.pnlDieuKien.Controls.Add(this.label6);
            this.pnlDieuKien.Controls.Add(this.label5);
            this.pnlDieuKien.Controls.Add(this.ultraDateTimeEditor_DenNgay);
            this.pnlDieuKien.Controls.Add(this.label4);
            this.pnlDieuKien.Controls.Add(this.ultraDateTimeEditor_TuNgay);
            this.pnlDieuKien.Controls.Add(this.cmbKyTen);
            this.pnlDieuKien.Controls.Add(this.label3);
            this.pnlDieuKien.Controls.Add(this.btnClose);
            this.pnlDieuKien.Controls.Add(this.btnReport);
            this.pnlDieuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuKien.Location = new System.Drawing.Point(350, 0);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(323, 231);
            this.pnlDieuKien.TabIndex = 1;
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(167, 29);
            this.txtNam.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtNam.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(63, 20);
            this.txtNam.TabIndex = 34;
            this.txtNam.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(136, 30);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(29, 13);
            this.lblNam.TabIndex = 33;
            this.lblNam.Text = "Nam";
            // 
            // txtQui
            // 
            this.txtQui.Location = new System.Drawing.Point(83, 29);
            this.txtQui.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.txtQui.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQui.Name = "txtQui";
            this.txtQui.Size = new System.Drawing.Size(37, 20);
            this.txtQui.TabIndex = 32;
            this.txtQui.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQui
            // 
            this.lblQui.AutoSize = true;
            this.lblQui.Location = new System.Drawing.Point(19, 30);
            this.lblQui.Name = "lblQui";
            this.lblQui.Size = new System.Drawing.Size(25, 13);
            this.lblQui.TabIndex = 31;
            this.lblQui.Text = "Quí";
            // 
            // ultraCombo_TaiKhoan
            // 
            this.ultraCombo_TaiKhoan.Location = new System.Drawing.Point(83, 90);
            this.ultraCombo_TaiKhoan.Name = "ultraCombo_TaiKhoan";
            this.ultraCombo_TaiKhoan.Size = new System.Drawing.Size(232, 22);
            this.ultraCombo_TaiKhoan.TabIndex = 30;
            this.ultraCombo_TaiKhoan.Text = "chọn tài khoản";
            this.ultraCombo_TaiKhoan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraCombo_TaiKhoan_InitializeLayout);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Tài Khoản";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Từ Ngày";
            // 
            // ultraDateTimeEditor_DenNgay
            // 
            this.ultraDateTimeEditor_DenNgay.Location = new System.Drawing.Point(232, 58);
            this.ultraDateTimeEditor_DenNgay.Name = "ultraDateTimeEditor_DenNgay";
            this.ultraDateTimeEditor_DenNgay.Size = new System.Drawing.Size(88, 21);
            this.ultraDateTimeEditor_DenNgay.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Từ Ngày";
            // 
            // ultraDateTimeEditor_TuNgay
            // 
            this.ultraDateTimeEditor_TuNgay.Location = new System.Drawing.Point(83, 58);
            this.ultraDateTimeEditor_TuNgay.Name = "ultraDateTimeEditor_TuNgay";
            this.ultraDateTimeEditor_TuNgay.Size = new System.Drawing.Size(82, 21);
            this.ultraDateTimeEditor_TuNgay.TabIndex = 25;
            // 
            // cmbKyTen
            // 
            this.cmbKyTen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyTen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem11.DataValue = 0;
            valueListItem11.DisplayText = "Không có";
            valueListItem12.DataValue = 1;
            valueListItem12.DisplayText = "Người lập";
            valueListItem13.DataValue = 2;
            valueListItem13.DisplayText = "Người lập, Thủ trưởng";
            valueListItem14.DataValue = 3;
            valueListItem14.DisplayText = "Người lập, BPT, Thủ trưởng";
            this.cmbKyTen.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14});
            this.cmbKyTen.Location = new System.Drawing.Point(83, 118);
            this.cmbKyTen.Name = "cmbKyTen";
            this.cmbKyTen.Size = new System.Drawing.Size(232, 21);
            this.cmbKyTen.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Ký tên";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(167, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 32);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(70, 177);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 32);
            this.btnReport.TabIndex = 17;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // boPhanListBindingSource
            // 
            this.boPhanListBindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // frmBaoCaoCongDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 231);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaoCaoCongDoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo phụ cấp";
            this.pnlDieuKien.ResumeLayout(false);
            this.pnlDieuKien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_TaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor_DenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor_TuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heThongTaiKhoan1ListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeReport;

        private System.Windows.Forms.Panel pnlDieuKien;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnReport;
        private System.Windows.Forms.BindingSource boPhanListBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyTen;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraCombo_TaiKhoan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ultraDateTimeEditor_DenNgay;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ultraDateTimeEditor_TuNgay;
        private System.Windows.Forms.BindingSource heThongTaiKhoan1ListBindingSource;
        private System.Windows.Forms.NumericUpDown txtNam;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown txtQui;
        private System.Windows.Forms.Label lblQui;
    }
}
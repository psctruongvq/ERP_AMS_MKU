namespace PSC_ERP
{
    partial class frmBaoCaoChiPhiSanXuat
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tổng Hợp Chi Phí Sản Xuất Chương Trình");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Chi Tiết Chi Phí Sản Xuất Chương Trình");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.cbChungTu = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.cbChiTietGiayXacNhan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label11 = new System.Windows.Forms.Label();
            this.cbNguon = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbu_ChuongTrinh = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTuNgay1 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dateDenNgay1 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.bindingSource1_ChungTu = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1_ChiTietGiayXacNhan = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1_Nguon = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1_ChuongTrinh = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDieuKien.SuspendLayout();
            this.gbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbChungTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChiTietGiayXacNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNguon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_ChuongTrinh)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChungTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChiTietGiayXacNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_Nguon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChuongTrinh)).BeginInit();
            this.SuspendLayout();
            // 
            // treeReport
            // 
            this.treeReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeReport.FullRowSelect = true;
            this.treeReport.HideSelection = false;
            this.treeReport.Location = new System.Drawing.Point(0, 0);
            this.treeReport.Name = "treeReport";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Tổng Hợp Chi Phí Sản Xuất Chương Trình";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Chi Tiết Chi Phí Sản Xuất Chương Trình";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeReport.Size = new System.Drawing.Size(301, 554);
            this.treeReport.TabIndex = 0;
            this.treeReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeReport_AfterSelect);
            // 
            // pnlDieuKien
            // 
            this.pnlDieuKien.Controls.Add(this.gbChiTiet);
            this.pnlDieuKien.Controls.Add(this.groupBox1);
            this.pnlDieuKien.Controls.Add(this.btnClose);
            this.pnlDieuKien.Controls.Add(this.btnReport);
            this.pnlDieuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuKien.Location = new System.Drawing.Point(301, 0);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(380, 554);
            this.pnlDieuKien.TabIndex = 2;
            // 
            // gbChiTiet
            // 
            this.gbChiTiet.Controls.Add(this.cbChungTu);
            this.gbChiTiet.Controls.Add(this.label4);
            this.gbChiTiet.Controls.Add(this.cbChiTietGiayXacNhan);
            this.gbChiTiet.Controls.Add(this.label11);
            this.gbChiTiet.Controls.Add(this.cbNguon);
            this.gbChiTiet.Controls.Add(this.label3);
            this.gbChiTiet.Controls.Add(this.cmbu_ChuongTrinh);
            this.gbChiTiet.Controls.Add(this.label8);
            this.gbChiTiet.Location = new System.Drawing.Point(17, 100);
            this.gbChiTiet.Name = "gbChiTiet";
            this.gbChiTiet.Size = new System.Drawing.Size(326, 153);
            this.gbChiTiet.TabIndex = 77;
            this.gbChiTiet.TabStop = false;
            this.gbChiTiet.Text = "Điều Kiện Chi Tiết";
            // 
            // cbChungTu
            // 
            this.cbChungTu.CheckedListSettings.CheckStateMember = "";
            this.cbChungTu.DataSource = this.bindingSource1_ChungTu;
            this.cbChungTu.DisplayMember = "SoChungTu";
            this.cbChungTu.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbChungTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChungTu.Location = new System.Drawing.Point(90, 106);
            this.cbChungTu.Name = "cbChungTu";
            this.cbChungTu.Size = new System.Drawing.Size(172, 22);
            this.cbChungTu.TabIndex = 3;
            this.cbChungTu.ValueMember = "MaChungTu";
            this.cbChungTu.Visible = false;
            this.cbChungTu.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbChungTu_InitializeLayout_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Chứng Từ";
            this.label4.Visible = false;
            // 
            // cbChiTietGiayXacNhan
            // 
            this.cbChiTietGiayXacNhan.CheckedListSettings.CheckStateMember = "";
            this.cbChiTietGiayXacNhan.DataSource = this.bindingSource1_ChiTietGiayXacNhan;
            this.cbChiTietGiayXacNhan.DisplayMember = "TenGiayXacNhan";
            this.cbChiTietGiayXacNhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbChiTietGiayXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChiTietGiayXacNhan.Location = new System.Drawing.Point(90, 78);
            this.cbChiTietGiayXacNhan.Name = "cbChiTietGiayXacNhan";
            this.cbChiTietGiayXacNhan.Size = new System.Drawing.Size(172, 22);
            this.cbChiTietGiayXacNhan.TabIndex = 2;
            this.cbChiTietGiayXacNhan.ValueMember = "MaChiTietGiayXacNhan";
            this.cbChiTietGiayXacNhan.Visible = false;
            this.cbChiTietGiayXacNhan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbChiTietGiayXacNhan_InitializeLayout);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 81;
            this.label11.Text = "Giấy Xác Nhận";
            this.label11.Visible = false;
            // 
            // cbNguon
            // 
            this.cbNguon.CheckedListSettings.CheckStateMember = "";
            this.cbNguon.DataSource = this.bindingSource1_Nguon;
            this.cbNguon.DisplayMember = "TenNguon";
            this.cbNguon.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbNguon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNguon.Location = new System.Drawing.Point(90, 21);
            this.cbNguon.Name = "cbNguon";
            this.cbNguon.Size = new System.Drawing.Size(172, 22);
            this.cbNguon.TabIndex = 0;
            this.cbNguon.ValueMember = "MaNguon";
            this.cbNguon.ValueChanged += new System.EventHandler(this.cbNguon_ValueChanged);
            this.cbNguon.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbNguon_InitializeLayout);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 76;
            this.label3.Text = "Nguồn";
            // 
            // cmbu_ChuongTrinh
            // 
            this.cmbu_ChuongTrinh.CheckedListSettings.CheckStateMember = "";
            this.cmbu_ChuongTrinh.DataSource = this.bindingSource1_ChuongTrinh;
            this.cmbu_ChuongTrinh.DisplayMember = "TenChuongTrinh";
            this.cmbu_ChuongTrinh.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_ChuongTrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_ChuongTrinh.Location = new System.Drawing.Point(90, 50);
            this.cmbu_ChuongTrinh.Name = "cmbu_ChuongTrinh";
            this.cmbu_ChuongTrinh.Size = new System.Drawing.Size(172, 22);
            this.cmbu_ChuongTrinh.TabIndex = 1;
            this.cmbu_ChuongTrinh.ValueMember = "MaChuongTrinh";
            this.cmbu_ChuongTrinh.ValueChanged += new System.EventHandler(this.cmbu_ChuongTrinh_ValueChanged);
            this.cmbu_ChuongTrinh.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_ChuongTrinh_InitializeLayout);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Chương Trình";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTuNgay1);
            this.groupBox1.Controls.Add(this.dateDenNgay1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 81);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều Kiện";
            // 
            // dateTuNgay1
            // 
            appearance9.BackColor = System.Drawing.SystemColors.Info;
            this.dateTuNgay1.Appearance = appearance9;
            this.dateTuNgay1.BackColor = System.Drawing.SystemColors.Info;
            this.dateTuNgay1.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTuNgay1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dateTuNgay1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTuNgay1.FormatString = "dd/MM/yyyy";
            this.dateTuNgay1.Location = new System.Drawing.Point(87, 18);
            this.dateTuNgay1.MaskInput = "{LOC}dd/mm/yyyy";
            this.dateTuNgay1.Name = "dateTuNgay1";
            this.dateTuNgay1.Size = new System.Drawing.Size(172, 21);
            this.dateTuNgay1.TabIndex = 0;
            this.dateTuNgay1.Value = null;
            // 
            // dateDenNgay1
            // 
            appearance10.BackColor = System.Drawing.SystemColors.Info;
            this.dateDenNgay1.Appearance = appearance10;
            this.dateDenNgay1.BackColor = System.Drawing.SystemColors.Info;
            this.dateDenNgay1.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateDenNgay1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dateDenNgay1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDenNgay1.FormatString = "dd/MM/yyyy";
            this.dateDenNgay1.Location = new System.Drawing.Point(87, 49);
            this.dateDenNgay1.MaskInput = "{LOC}dd/mm/yyyy";
            this.dateDenNgay1.Name = "dateDenNgay1";
            this.dateDenNgay1.Size = new System.Drawing.Size(172, 21);
            this.dateDenNgay1.TabIndex = 1;
            this.dateDenNgay1.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Từ Ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Đến Ngày";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(194, 271);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(89, 271);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 32);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // bindingSource1_Nguon
            // 
            this.bindingSource1_Nguon.AllowNew = true;
            // 
            // frmBaoCaoChiPhiSanXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 554);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.Name = "frmBaoCaoChiPhiSanXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Chi Phí Sản Xuất Chương Trình";
            this.Load += new System.EventHandler(this.frmBaoCaoThuLao_Load);
            this.pnlDieuKien.ResumeLayout(false);
            this.gbChiTiet.ResumeLayout(false);
            this.gbChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbChungTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChiTietGiayXacNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNguon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_ChuongTrinh)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChungTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChiTietGiayXacNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_Nguon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChuongTrinh)).EndInit();
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
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_ChuongTrinh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bindingSource1_ChuongTrinh;
        private System.Windows.Forms.GroupBox gbChiTiet;
        private System.Windows.Forms.BindingSource bindingSource1_Nguon;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbNguon;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateDenNgay1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateTuNgay1;
        private System.Windows.Forms.BindingSource bindingSource1_ChiTietGiayXacNhan;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbChiTietGiayXacNhan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.BindingSource bindingSource1_ChungTu;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbChungTu;
        private System.Windows.Forms.Label label4;

    }
}

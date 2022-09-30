namespace PSC_ERP
{
    partial class frmBaoCaoHoaDon
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Danh Sách Hóa Đơn");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Danh Sách Hóa Đơn-Chứng Từ");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Danh Sách Chứng Từ Không Có Hóa Đơn");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Báo Cáo Theo Dõi Thu-Chi");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("HeThongTaiKhoan1", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTaiKhoan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DungChung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoHieuTK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenTaiKhoan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTaiKhoanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CoDoiTuongTheoDoi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoaiSoDuCo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoaiSoDuNo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoDuNoDauNam");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoDuCoDauNam");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiTaiKhoan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CapTaiKhoan");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.treeReport = new System.Windows.Forms.TreeView();
            this.pnlDieuKien = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_chontk = new Infragistics.Win.Misc.UltraButton();
            this.cbo_sohieutk = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.heThongTaiKhoan1ListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cbTinhTrangThuChi = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.cbLoaiChungTu = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbChungTu = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource1_ChungTu = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTinhTrangHoaDon = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbu_HoaDon = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource1_HoaDon = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.dateTuNgay1 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dateDenNgay1 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDoiTuong = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bindingSource2_DoiTac = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnReport = new Infragistics.Win.Misc.UltraButton();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlDieuKien.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_sohieutk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heThongTaiKhoan1ListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTinhTrangThuChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiChungTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChungTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChungTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTinhTrangHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_HoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_HoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_DoiTac)).BeginInit();
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
            treeNode1.Text = "Danh Sách Hóa Đơn";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Danh Sách Hóa Đơn-Chứng Từ";
            treeNode3.Name = "Node4";
            treeNode3.Text = "Danh Sách Chứng Từ Không Có Hóa Đơn";
            treeNode4.Name = "Node3";
            treeNode4.Text = "Báo Cáo Theo Dõi Thu-Chi";
            this.treeReport.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeReport.Size = new System.Drawing.Size(254, 308);
            this.treeReport.TabIndex = 1;
            this.treeReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeReport_AfterSelect);
            // 
            // pnlDieuKien
            // 
            this.pnlDieuKien.Controls.Add(this.groupBox1);
            this.pnlDieuKien.Controls.Add(this.btnClose);
            this.pnlDieuKien.Controls.Add(this.btnReport);
            this.pnlDieuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuKien.Location = new System.Drawing.Point(254, 0);
            this.pnlDieuKien.Name = "pnlDieuKien";
            this.pnlDieuKien.Size = new System.Drawing.Size(457, 308);
            this.pnlDieuKien.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_chontk);
            this.groupBox1.Controls.Add(this.cbo_sohieutk);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbTinhTrangThuChi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbLoaiChungTu);
            this.groupBox1.Controls.Add(this.cbChungTu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbTinhTrangHoaDon);
            this.groupBox1.Controls.Add(this.cmbu_HoaDon);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTuNgay1);
            this.groupBox1.Controls.Add(this.dateDenNgay1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbDoiTuong);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 254);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều Kiện";
            // 
            // btn_chontk
            // 
            this.btn_chontk.Location = new System.Drawing.Point(312, 211);
            this.btn_chontk.Name = "btn_chontk";
            this.btn_chontk.Size = new System.Drawing.Size(104, 22);
            this.btn_chontk.TabIndex = 87;
            this.btn_chontk.Text = "Chọn nhiều TK ...";
            this.btn_chontk.Click += new System.EventHandler(this.btn_chontk_Click);
            // 
            // cbo_sohieutk
            // 
            this.cbo_sohieutk.CheckedListSettings.CheckStateMember = "";
            this.cbo_sohieutk.DataSource = this.heThongTaiKhoan1ListBindingSource;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14});
            this.cbo_sohieutk.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cbo_sohieutk.DisplayMember = "SoHieuTK";
            this.cbo_sohieutk.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbo_sohieutk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_sohieutk.Location = new System.Drawing.Point(96, 211);
            this.cbo_sohieutk.Name = "cbo_sohieutk";
            this.cbo_sohieutk.Size = new System.Drawing.Size(210, 22);
            this.cbo_sohieutk.TabIndex = 85;
            this.cbo_sohieutk.ValueMember = "MaTaiKhoan";
            this.cbo_sohieutk.ValueChanged += new System.EventHandler(this.cbo_sohieutk_ValueChanged);
            this.cbo_sohieutk.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbo_sohieutk_InitializeLayout);
            // 
            // heThongTaiKhoan1ListBindingSource
            // 
            this.heThongTaiKhoan1ListBindingSource.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 84;
            this.label6.Text = "T.Trạng Thu-Chi";
            // 
            // cbTinhTrangThuChi
            // 
            appearance5.BackColor = System.Drawing.SystemColors.Info;
            this.cbTinhTrangThuChi.Appearance = appearance5;
            this.cbTinhTrangThuChi.BackColor = System.Drawing.SystemColors.Info;
            this.cbTinhTrangThuChi.DisplayMember = "";
            this.cbTinhTrangThuChi.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbTinhTrangThuChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem1.DataValue = -1;
            valueListItem1.DisplayText = "Tất Cả";
            valueListItem2.DataValue = 0;
            valueListItem2.DisplayText = "Chưa T.Toán";
            valueListItem3.DataValue = 1;
            valueListItem3.DisplayText = "Đã T.Toán";
            this.cbTinhTrangThuChi.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cbTinhTrangThuChi.Location = new System.Drawing.Point(96, 156);
            this.cbTinhTrangThuChi.Name = "cbTinhTrangThuChi";
            this.cbTinhTrangThuChi.Size = new System.Drawing.Size(320, 21);
            this.cbTinhTrangThuChi.TabIndex = 83;
            this.cbTinhTrangThuChi.ValueMember = "";
            this.cbTinhTrangThuChi.ValueChanged += new System.EventHandler(this.cbTinhTrangThuChi_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Loại Chứng Từ";
            // 
            // cbLoaiChungTu
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Info;
            this.cbLoaiChungTu.Appearance = appearance1;
            this.cbLoaiChungTu.BackColor = System.Drawing.SystemColors.Info;
            this.cbLoaiChungTu.DisplayMember = "";
            this.cbLoaiChungTu.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbLoaiChungTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem4.DataValue = 0;
            valueListItem4.DisplayText = "Tất Cả";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "Phiếu Thu";
            valueListItem6.DataValue = 3;
            valueListItem6.DisplayText = "Phiếu Chi";
            this.cbLoaiChungTu.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6});
            this.cbLoaiChungTu.Location = new System.Drawing.Point(96, 129);
            this.cbLoaiChungTu.Name = "cbLoaiChungTu";
            this.cbLoaiChungTu.Size = new System.Drawing.Size(320, 21);
            this.cbLoaiChungTu.TabIndex = 81;
            this.cbLoaiChungTu.ValueMember = "";
            this.cbLoaiChungTu.ValueChanged += new System.EventHandler(this.cbLoaiChungTu_ValueChanged);
            // 
            // cbChungTu
            // 
            this.cbChungTu.CheckedListSettings.CheckStateMember = "";
            this.cbChungTu.DataSource = this.bindingSource1_ChungTu;
            this.cbChungTu.DisplayMember = "SoChungTu";
            this.cbChungTu.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbChungTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChungTu.Location = new System.Drawing.Point(96, 183);
            this.cbChungTu.Name = "cbChungTu";
            this.cbChungTu.Size = new System.Drawing.Size(320, 22);
            this.cbChungTu.TabIndex = 79;
            this.cbChungTu.ValueMember = "MaChungTu";
            this.cbChungTu.Visible = false;
            this.cbChungTu.ValueChanged += new System.EventHandler(this.cbChungTu_ValueChanged);
            this.cbChungTu.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbChungTu_InitializeLayout);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 80;
            this.label4.Text = "Chứng Từ";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Tình Trạng HĐ";
            // 
            // cbTinhTrangHoaDon
            // 
            appearance2.BackColor = System.Drawing.SystemColors.Info;
            this.cbTinhTrangHoaDon.Appearance = appearance2;
            this.cbTinhTrangHoaDon.BackColor = System.Drawing.SystemColors.Info;
            this.cbTinhTrangHoaDon.DisplayMember = "";
            this.cbTinhTrangHoaDon.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbTinhTrangHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem7.DataValue = -1;
            valueListItem7.DisplayText = "Tất Cả";
            valueListItem8.DataValue = 0;
            valueListItem8.DisplayText = "Chưa Thanh Toán";
            valueListItem9.DataValue = 1;
            valueListItem9.DisplayText = "Đã Thanh Toán";
            valueListItem10.DataValue = 2;
            valueListItem10.DisplayText = "Thanh Toán Một Phần";
            valueListItem11.DataValue = 3;
            valueListItem11.DisplayText = "Đã Hủy";
            this.cbTinhTrangHoaDon.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9,
            valueListItem10,
            valueListItem11});
            this.cbTinhTrangHoaDon.Location = new System.Drawing.Point(96, 102);
            this.cbTinhTrangHoaDon.Name = "cbTinhTrangHoaDon";
            this.cbTinhTrangHoaDon.Size = new System.Drawing.Size(320, 21);
            this.cbTinhTrangHoaDon.TabIndex = 77;
            this.cbTinhTrangHoaDon.ValueMember = "";
            this.cbTinhTrangHoaDon.ValueChanged += new System.EventHandler(this.cbThanhToan_ValueChanged);
            // 
            // cmbu_HoaDon
            // 
            this.cmbu_HoaDon.CheckedListSettings.CheckStateMember = "";
            this.cmbu_HoaDon.DataSource = this.bindingSource1_HoaDon;
            this.cmbu_HoaDon.DisplayMember = "SoHoaDon";
            this.cmbu_HoaDon.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_HoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_HoaDon.Location = new System.Drawing.Point(96, 74);
            this.cmbu_HoaDon.Name = "cmbu_HoaDon";
            this.cmbu_HoaDon.Size = new System.Drawing.Size(320, 22);
            this.cmbu_HoaDon.TabIndex = 75;
            this.cmbu_HoaDon.ValueMember = "MaHoaDon";
            this.cmbu_HoaDon.ValueChanged += new System.EventHandler(this.cmbu_ChuongTrinh_ValueChanged);
            this.cmbu_HoaDon.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_ChuongTrinh_InitializeLayout);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 76;
            this.label8.Text = "Hóa Đơn";
            // 
            // dateTuNgay1
            // 
            appearance3.BackColor = System.Drawing.SystemColors.Info;
            this.dateTuNgay1.Appearance = appearance3;
            this.dateTuNgay1.BackColor = System.Drawing.SystemColors.Info;
            this.dateTuNgay1.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTuNgay1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dateTuNgay1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTuNgay1.FormatString = "dd/MM/yyyy";
            this.dateTuNgay1.Location = new System.Drawing.Point(96, 19);
            this.dateTuNgay1.MaskInput = "{LOC}dd/mm/yyyy";
            this.dateTuNgay1.Name = "dateTuNgay1";
            this.dateTuNgay1.Size = new System.Drawing.Size(131, 21);
            this.dateTuNgay1.TabIndex = 1;
            this.dateTuNgay1.Value = null;
            // 
            // dateDenNgay1
            // 
            appearance7.BackColor = System.Drawing.SystemColors.Info;
            this.dateDenNgay1.Appearance = appearance7;
            this.dateDenNgay1.BackColor = System.Drawing.SystemColors.Info;
            this.dateDenNgay1.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateDenNgay1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dateDenNgay1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDenNgay1.FormatString = "dd/MM/yyyy";
            this.dateDenNgay1.Location = new System.Drawing.Point(294, 19);
            this.dateDenNgay1.MaskInput = "{LOC}dd/mm/yyyy";
            this.dateDenNgay1.Name = "dateDenNgay1";
            this.dateDenNgay1.Size = new System.Drawing.Size(122, 21);
            this.dateDenNgay1.TabIndex = 2;
            this.dateDenNgay1.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Từ Ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Đến Ngày";
            // 
            // cbDoiTuong
            // 
            this.cbDoiTuong.CheckedListSettings.CheckStateMember = "";
            this.cbDoiTuong.DataSource = this.bindingSource2_DoiTac;
            this.cbDoiTuong.DisplayMember = "TenDoiTac";
            this.cbDoiTuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbDoiTuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoiTuong.Location = new System.Drawing.Point(96, 46);
            this.cbDoiTuong.Name = "cbDoiTuong";
            this.cbDoiTuong.Size = new System.Drawing.Size(320, 22);
            this.cbDoiTuong.TabIndex = 4;
            this.cbDoiTuong.ValueMember = "MaDoiTac";
            this.cbDoiTuong.ValueChanged += new System.EventHandler(this.cbDoiTuong_ValueChanged);
            this.cbDoiTuong.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbNhanVien_InitializeLayout);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 74;
            this.label9.Text = "Khách Hàng";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(355, 272);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 25);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(17, 272);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(91, 25);
            this.btnReport.TabIndex = 13;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Tài Khoản";
            // 
            // frmBaoCaoHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 308);
            this.Controls.Add(this.pnlDieuKien);
            this.Controls.Add(this.treeReport);
            this.Name = "frmBaoCaoHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Chứng Từ - Hóa Đơn";
            this.Load += new System.EventHandler(this.frmBaoCaoThuLao_Load);
            this.pnlDieuKien.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_sohieutk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heThongTaiKhoan1ListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTinhTrangThuChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiChungTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChungTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChungTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTinhTrangHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_HoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_HoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2_DoiTac)).EndInit();
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
        private System.Windows.Forms.BindingSource bindingSource2_DoiTac;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateDenNgay1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dateTuNgay1;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_HoaDon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bindingSource1_HoaDon;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbTinhTrangHoaDon;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbChungTu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bindingSource1_ChungTu;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbTinhTrangThuChi;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbLoaiChungTu;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbo_sohieutk;
        private Infragistics.Win.Misc.UltraButton btn_chontk;
        private System.Windows.Forms.BindingSource heThongTaiKhoan1ListBindingSource;
        private System.Windows.Forms.Label label7;

    }
}

namespace PSC_ERP.ThanhToan
{
    partial class frmChonHoaDon_DichVu
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DoiTuongAll", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTaiKhoan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaSoThue");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DiaChi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Check");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DaCo");
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_CMND = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_DienThoai = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.cmbDoiTac = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.DoiTuongBinding = new System.Windows.Forms.BindingSource(this.components);
            this.txt_MST = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_NganHang = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.NganHangBinding = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dataset)).BeginInit();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CMND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienThoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoiTac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoiTuongBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_NganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NganHangBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.cmb_NganHang);
            this.pnlData.Controls.Add(this.label8);
            this.pnlData.Controls.Add(this.txt_MST);
            this.pnlData.Controls.Add(this.label7);
            this.pnlData.Controls.Add(this.cmbDoiTac);
            this.pnlData.Controls.Add(this.label4);
            this.pnlData.Controls.Add(this.txt_CMND);
            this.pnlData.Controls.Add(this.txt_DienThoai);
            this.pnlData.Controls.Add(this.txtTaiKhoan);
            this.pnlData.Controls.Add(this.label6);
            this.pnlData.Controls.Add(this.label5);
            this.pnlData.Controls.Add(this.label1);
            this.pnlData.Size = new System.Drawing.Size(424, 82);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Size = new System.Drawing.Size(137, 21);
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Size = new System.Drawing.Size(346, 35);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số tài khoản:";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtTaiKhoan.Location = new System.Drawing.Point(91, 58);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(141, 21);
            this.txtTaiKhoan.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Đối tượng";
            // 
            // txt_CMND
            // 
            this.txt_CMND.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txt_CMND.Location = new System.Drawing.Point(287, 81);
            this.txt_CMND.Name = "txt_CMND";
            this.txt_CMND.Size = new System.Drawing.Size(131, 21);
            this.txt_CMND.TabIndex = 4;
            this.txt_CMND.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "CMND:";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số điện thoại:";
            this.label6.Visible = false;
            // 
            // txt_DienThoai
            // 
            this.txt_DienThoai.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txt_DienThoai.Location = new System.Drawing.Point(91, 81);
            this.txt_DienThoai.Name = "txt_DienThoai";
            this.txt_DienThoai.Size = new System.Drawing.Size(141, 21);
            this.txt_DienThoai.TabIndex = 4;
            this.txt_DienThoai.Visible = false;
            // 
            // cmbDoiTac
            // 
            this.cmbDoiTac.DataSource = this.DoiTuongBinding;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            this.cmbDoiTac.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbDoiTac.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.cmbDoiTac.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.cmbDoiTac.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.cmbDoiTac.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.cmbDoiTac.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            this.cmbDoiTac.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmbDoiTac.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.cmbDoiTac.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.cmbDoiTac.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.cmbDoiTac.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbDoiTac.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbDoiTac.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.cmbDoiTac.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cmbDoiTac.DisplayMember = "TenDoiTuong";
            this.cmbDoiTac.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbDoiTac.Location = new System.Drawing.Point(91, 7);
            this.cmbDoiTac.Name = "cmbDoiTac";
            this.cmbDoiTac.Size = new System.Drawing.Size(327, 22);
            this.cmbDoiTac.TabIndex = 6;
            this.cmbDoiTac.ValueMember = "MaDoiTuong";
            this.cmbDoiTac.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbDoiTac_InitializeLayout);
            this.cmbDoiTac.ValueChanged += new System.EventHandler(this.cmbDoiTac_ValueChanged);
            // 
            // DoiTuongBinding
            // 
            this.DoiTuongBinding.DataSource = typeof(ERP_Library.DoiTuongAllList);
            // 
            // txt_MST
            // 
            this.txt_MST.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txt_MST.Location = new System.Drawing.Point(287, 58);
            this.txt_MST.Name = "txt_MST";
            this.txt_MST.Size = new System.Drawing.Size(131, 21);
            this.txt_MST.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "MST:";
            // 
            // cmb_NganHang
            // 
            this.cmb_NganHang.DataSource = this.NganHangBinding;
            this.cmb_NganHang.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.cmb_NganHang.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.cmb_NganHang.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.cmb_NganHang.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.cmb_NganHang.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            this.cmb_NganHang.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmb_NganHang.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.cmb_NganHang.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.cmb_NganHang.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.cmb_NganHang.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmb_NganHang.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmb_NganHang.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.cmb_NganHang.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cmb_NganHang.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmb_NganHang.Location = new System.Drawing.Point(91, 32);
            this.cmb_NganHang.Name = "cmb_NganHang";
            this.cmb_NganHang.Size = new System.Drawing.Size(327, 22);
            this.cmb_NganHang.SyncWithCurrencyManager = true;
            this.cmb_NganHang.TabIndex = 10;
            this.cmb_NganHang.ValueChanged += new System.EventHandler(this.cmb_NganHang_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tài khoản NH:";
            // 
            // frmChonHoaDon_DichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 236);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChonHoaDon_DichVu";
            this.Text = "Chọn hợp đồng - dịch vụ";
            this.SaveXMLData += new System.ComponentModel.CancelEventHandler(this.frmChonKyLuong_SaveXMLData);
            this.CreateXMLData += new System.EventHandler(this.frmChonKyLuong_CreateXMLData);
            this.Load += new System.EventHandler(this.frmChonHoaDon_DichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dataset)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CMND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienThoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDoiTac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoiTuongBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_NganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NganHangBinding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txt_CMND;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTaiKhoan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txt_DienThoai;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbDoiTac;
        private System.Windows.Forms.BindingSource DoiTuongBinding;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txt_MST;
        private System.Windows.Forms.Label label7;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmb_NganHang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource NganHangBinding;
    }
}

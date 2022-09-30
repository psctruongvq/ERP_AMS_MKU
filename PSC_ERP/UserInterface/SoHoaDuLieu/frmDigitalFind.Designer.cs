namespace PSC_ERP
{
    partial class frmDigitalFind
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("BoPhan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhongTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhauHaoHaoMon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            this.radNhanVien = new System.Windows.Forms.RadioButton();
            this.radSoHoSo = new System.Windows.Forms.RadioButton();
            this.txtu_SoHoSo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cmbu_Bophan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.BindS_BoPhan = new System.Windows.Forms.BindingSource(this.components);
            this.NhanVien_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbNhanVien = new PSC_ERP.ComboboxNhanVien();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_SoHoSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhanVien_bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // radNhanVien
            // 
            this.radNhanVien.AutoSize = true;
            this.radNhanVien.Checked = true;
            this.radNhanVien.Location = new System.Drawing.Point(13, 13);
            this.radNhanVien.Name = "radNhanVien";
            this.radNhanVien.Size = new System.Drawing.Size(100, 17);
            this.radNhanVien.TabIndex = 0;
            this.radNhanVien.TabStop = true;
            this.radNhanVien.Text = "Theo nhân viên";
            this.radNhanVien.UseVisualStyleBackColor = true;
            this.radNhanVien.CheckedChanged += new System.EventHandler(this.radNhanVien_CheckedChanged);
            // 
            // radSoHoSo
            // 
            this.radSoHoSo.AutoSize = true;
            this.radSoHoSo.Location = new System.Drawing.Point(12, 73);
            this.radSoHoSo.Name = "radSoHoSo";
            this.radSoHoSo.Size = new System.Drawing.Size(93, 17);
            this.radSoHoSo.TabIndex = 1;
            this.radSoHoSo.Text = "Theo số hồ sơ";
            this.radSoHoSo.UseVisualStyleBackColor = true;
            this.radSoHoSo.CheckedChanged += new System.EventHandler(this.radSoHoSo_CheckedChanged);
            // 
            // txtu_SoHoSo
            // 
            this.txtu_SoHoSo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtu_SoHoSo.Enabled = false;
            this.txtu_SoHoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtu_SoHoSo.Location = new System.Drawing.Point(136, 71);
            this.txtu_SoHoSo.Name = "txtu_SoHoSo";
            this.txtu_SoHoSo.Size = new System.Drawing.Size(287, 21);
            this.txtu_SoHoSo.TabIndex = 3;
            this.txtu_SoHoSo.ValueChanged += new System.EventHandler(this.txtu_SoHoSo_ValueChanged);
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(136, 15);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(62, 13);
            this.lblPhong.TabIndex = 4;
            this.lblPhong.Text = "Phòng ban:";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(136, 46);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(59, 13);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // cmbu_Bophan
            // 
            appearance1.FontData.BoldAsString = "False";
            this.cmbu_Bophan.Appearance = appearance1;
            this.cmbu_Bophan.CheckedListSettings.CheckStateMember = "";
            this.cmbu_Bophan.DataSource = this.BindS_BoPhan;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Caption = "Mã QL";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.Caption = "Tên Bộ Phận";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 250;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.VisiblePosition = 10;
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
            ultraGridColumn11});
            this.cmbu_Bophan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbu_Bophan.DisplayMember = "TenBoPhan";
            this.cmbu_Bophan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_Bophan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_Bophan.Location = new System.Drawing.Point(218, 12);
            this.cmbu_Bophan.Name = "cmbu_Bophan";
            this.cmbu_Bophan.Size = new System.Drawing.Size(205, 22);
            this.cmbu_Bophan.TabIndex = 81;
            this.cmbu_Bophan.ValueMember = "MaBoPhan";
            this.cmbu_Bophan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_Bophan_InitializeLayout);
            this.cmbu_Bophan.ValueChanged += new System.EventHandler(this.cmbu_Bophan_ValueChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(174, 104);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.TabIndex = 83;
            this.btnTimKiem.Text = "T&ìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // BindS_BoPhan
            // 
            this.BindS_BoPhan.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // NhanVien_bindingSource
            // 
            this.NhanVien_bindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.AutoSize = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(218, 41);
            this.cmbNhanVien.Margin = new System.Windows.Forms.Padding(5);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(205, 22);
            this.cmbNhanVien.TabIndex = 84;
            this.cmbNhanVien.Value = null;
            this.cmbNhanVien.ValueChanged += new System.EventHandler(this.cmbNhanVien_ValueChanged);
            // 
            // frmDigitalFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 146);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cmbu_Bophan);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.txtu_SoHoSo);
            this.Controls.Add(this.radSoHoSo);
            this.Controls.Add(this.radNhanVien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDigitalFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm thông tin số hóa";
            this.Load += new System.EventHandler(this.frmDigitalFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtu_SoHoSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhanVien_bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radNhanVien;
        private System.Windows.Forms.RadioButton radSoHoSo;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtu_SoHoSo;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblNhanVien;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_Bophan;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.BindingSource BindS_BoPhan;
        private System.Windows.Forms.BindingSource NhanVien_bindingSource;
        private ComboboxNhanVien cmbNhanVien;
    }
}
namespace PSC_ERP
{
    partial class frmExportThuLapImport
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
            this.checkBox_NghiHuu = new System.Windows.Forms.CheckBox();
            this.lbl_ChiNhanh = new System.Windows.Forms.Label();
            this.cmbu_Bophan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.BoPhanbd = new System.Windows.Forms.BindingSource(this.components);
            this.btn_Xuat = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoPhanbd)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_NghiHuu
            // 
            this.checkBox_NghiHuu.AutoSize = true;
            this.checkBox_NghiHuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_NghiHuu.Location = new System.Drawing.Point(288, 15);
            this.checkBox_NghiHuu.Name = "checkBox_NghiHuu";
            this.checkBox_NghiHuu.Size = new System.Drawing.Size(65, 17);
            this.checkBox_NghiHuu.TabIndex = 63;
            this.checkBox_NghiHuu.Text = "Đã Nghỉ";
            this.checkBox_NghiHuu.UseVisualStyleBackColor = true;
            // 
            // lbl_ChiNhanh
            // 
            this.lbl_ChiNhanh.AutoSize = true;
            this.lbl_ChiNhanh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChiNhanh.Location = new System.Drawing.Point(13, 16);
            this.lbl_ChiNhanh.Name = "lbl_ChiNhanh";
            this.lbl_ChiNhanh.Size = new System.Drawing.Size(47, 14);
            this.lbl_ChiNhanh.TabIndex = 65;
            this.lbl_ChiNhanh.Text = "Bộ phận";
            // 
            // cmbu_Bophan
            // 
            appearance1.FontData.BoldAsString = "False";
            this.cmbu_Bophan.Appearance = appearance1;
            this.cmbu_Bophan.DataSource = this.BoPhanbd;
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
            this.cmbu_Bophan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_Bophan.Location = new System.Drawing.Point(66, 12);
            this.cmbu_Bophan.Name = "cmbu_Bophan";
            this.cmbu_Bophan.Size = new System.Drawing.Size(216, 22);
            this.cmbu_Bophan.TabIndex = 62;
            this.cmbu_Bophan.ValueMember = "MaBoPhan";
            this.cmbu_Bophan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_Bophan_InitializeLayout);
            // 
            // BoPhanbd
            // 
            this.BoPhanbd.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // btn_Xuat
            // 
            this.btn_Xuat.Location = new System.Drawing.Point(76, 47);
            this.btn_Xuat.Name = "btn_Xuat";
            this.btn_Xuat.Size = new System.Drawing.Size(100, 30);
            this.btn_Xuat.TabIndex = 66;
            this.btn_Xuat.Text = "&Xuất";
            this.btn_Xuat.UseVisualStyleBackColor = true;
            this.btn_Xuat.Click += new System.EventHandler(this.btn_Xuat_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(182, 47);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(100, 30);
            this.btn_Thoat.TabIndex = 67;
            this.btn_Thoat.Text = "&Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // frmExportThuLapImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 82);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Xuat);
            this.Controls.Add(this.checkBox_NghiHuu);
            this.Controls.Add(this.lbl_ChiNhanh);
            this.Controls.Add(this.cmbu_Bophan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExportThuLapImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Mẫu Thù Lao";
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoPhanbd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_NghiHuu;
        private System.Windows.Forms.Label lbl_ChiNhanh;
        private System.Windows.Forms.BindingSource BoPhanbd;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_Bophan;
        private System.Windows.Forms.Button btn_Xuat;
        private System.Windows.Forms.Button btn_Thoat;
    }
}
namespace PSC_ERP.UserInterface.NhanSu.TongHopThuLao
{
    partial class frmChonDuLieuImport
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayTao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhongTinhLuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhauHaoHaoMon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("QuocGia", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuocGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuocGiaQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenVietTat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenQuocGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonDuLieuImport));
            this.cmbuBoPhan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.BoPhan_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_ChiNhanh = new System.Windows.Forms.Label();
            this.cmbuQuocGia = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.QuocGia_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cmbuBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoPhan_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbuQuocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuocGia_BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbuBoPhan
            // 
            appearance1.FontData.BoldAsString = "False";
            this.cmbuBoPhan.Appearance = appearance1;
            this.cmbuBoPhan.DataSource = this.BoPhan_BindingSource;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn14.Header.Caption = "Mã QL";
            ultraGridColumn14.Header.VisiblePosition = 2;
            ultraGridColumn15.Header.Caption = "Tên Bộ Phận";
            ultraGridColumn15.Header.VisiblePosition = 3;
            ultraGridColumn15.Width = 250;
            ultraGridColumn16.Header.VisiblePosition = 4;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.VisiblePosition = 5;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.VisiblePosition = 6;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.Header.VisiblePosition = 7;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.Header.VisiblePosition = 8;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.VisiblePosition = 9;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.Header.VisiblePosition = 10;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22});
            this.cmbuBoPhan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbuBoPhan.DisplayMember = "TenBoPhan";
            this.cmbuBoPhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbuBoPhan.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbuBoPhan.Location = new System.Drawing.Point(90, 12);
            this.cmbuBoPhan.Name = "cmbuBoPhan";
            this.cmbuBoPhan.Size = new System.Drawing.Size(252, 26);
            this.cmbuBoPhan.TabIndex = 0;
            this.cmbuBoPhan.ValueMember = "MaBoPhan";
            this.cmbuBoPhan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbuBoPhan_InitializeLayout);
            // 
            // BoPhan_BindingSource
            // 
            this.BoPhan_BindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // lbl_ChiNhanh
            // 
            this.lbl_ChiNhanh.AutoSize = true;
            this.lbl_ChiNhanh.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChiNhanh.Location = new System.Drawing.Point(9, 21);
            this.lbl_ChiNhanh.Name = "lbl_ChiNhanh";
            this.lbl_ChiNhanh.Size = new System.Drawing.Size(59, 17);
            this.lbl_ChiNhanh.TabIndex = 63;
            this.lbl_ChiNhanh.Text = "Bộ Phận";
            // 
            // cmbuQuocGia
            // 
            appearance2.FontData.BoldAsString = "False";
            this.cmbuQuocGia.Appearance = appearance2;
            this.cmbuQuocGia.DataSource = this.QuocGia_BindingSource;
            ultraGridColumn23.Header.VisiblePosition = 0;
            ultraGridColumn24.Header.VisiblePosition = 1;
            ultraGridColumn25.Header.VisiblePosition = 2;
            ultraGridColumn26.Header.VisiblePosition = 3;
            ultraGridColumn27.Header.VisiblePosition = 4;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27});
            this.cmbuQuocGia.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cmbuQuocGia.DisplayMember = "TenQuocGia";
            this.cmbuQuocGia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbuQuocGia.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbuQuocGia.Location = new System.Drawing.Point(90, 44);
            this.cmbuQuocGia.Name = "cmbuQuocGia";
            this.cmbuQuocGia.Size = new System.Drawing.Size(252, 26);
            this.cmbuQuocGia.TabIndex = 1;
            this.cmbuQuocGia.ValueMember = "MaQuocGia";
            this.cmbuQuocGia.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbuQuocGia_InitializeLayout);
            // 
            // QuocGia_BindingSource
            // 
            this.QuocGia_BindingSource.DataSource = typeof(ERP_Library.QuocGiaList);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "Quốc Gia";
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(153, 76);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(95, 36);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // frmChonDuLieuImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 116);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cmbuQuocGia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbuBoPhan);
            this.Controls.Add(this.lbl_ChiNhanh);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmChonDuLieuImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "       Chọn dữ liệu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChonDuLieuImport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.cmbuBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoPhan_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbuQuocGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuocGia_BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraCombo cmbuBoPhan;
        private System.Windows.Forms.Label lbl_ChiNhanh;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbuQuocGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.BindingSource QuocGia_BindingSource;
        private System.Windows.Forms.BindingSource BoPhan_BindingSource;
    }
}
namespace PSC_ERP
{
    partial class frmDSTheoDoiDoiTuong
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("HeThongTaiKhoan1", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTaiKhoan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoHieuTK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenTaiKhoan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTaiKhoanCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CoDoiTuongTheoDoi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoaiSoDuCo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoaiSoDuNo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoDuNoDauNam");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoDuCoDauNam");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiTaiKhoan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CapTaiKhoan");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.HeThongTaiKhoan_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdu_DSTaiKhoan = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.HeThongTaiKhoan_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_DSTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // HeThongTaiKhoan_BindingSource
            // 
            this.HeThongTaiKhoan_BindingSource.AllowNew = true;
            this.HeThongTaiKhoan_BindingSource.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            // 
            // grdu_DSTaiKhoan
            // 
            this.grdu_DSTaiKhoan.DataSource = this.HeThongTaiKhoan_BindingSource;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.FontData.BoldAsString = "False";
            this.grdu_DSTaiKhoan.DisplayLayout.Appearance = appearance3;
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
            this.grdu_DSTaiKhoan.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdu_DSTaiKhoan.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdu_DSTaiKhoan.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.grdu_DSTaiKhoan.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdu_DSTaiKhoan.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.grdu_DSTaiKhoan.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance4.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_DSTaiKhoan.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.grdu_DSTaiKhoan.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdu_DSTaiKhoan.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grdu_DSTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdu_DSTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdu_DSTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.grdu_DSTaiKhoan.Name = "grdu_DSTaiKhoan";
            this.grdu_DSTaiKhoan.Size = new System.Drawing.Size(684, 307);
            this.grdu_DSTaiKhoan.TabIndex = 29;
            this.grdu_DSTaiKhoan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdu_DSTaiKhoan_InitializeLayout);
            this.grdu_DSTaiKhoan.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdu_DSTaiKhoan_DoubleClickRow);
            // 
            // frmDSTheoDoiDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 307);
            this.Controls.Add(this.grdu_DSTaiKhoan);
            this.Name = "frmDSTheoDoiDoiTuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách tài khoản theo dõi đối tượng";
            this.Load += new System.EventHandler(this.frmDSTheoDoiDoiTuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeThongTaiKhoan_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_DSTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource HeThongTaiKhoan_BindingSource;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_DSTaiKhoan;
    }
}
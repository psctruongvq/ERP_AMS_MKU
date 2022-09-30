namespace PSC_ERP
{
    partial class frmNhanVienChungChi
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVien_ChungChi", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ManhanvienChungchi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChungChi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayCap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NoiCap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GhiChu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChungChiChinh");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVienChungChi));
            this.grd_DSDiaChiNhanVien = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ChungChi_NhanVien_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSDiaChiNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChungChi_NhanVien_bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_DSDiaChiNhanVien
            // 
            this.grd_DSDiaChiNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_DSDiaChiNhanVien.DataSource = this.ChungChi_NhanVien_bindingSource;
            appearance3.BackColor = System.Drawing.Color.White;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 4;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Caption = "Tên Chứng Chỉ";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn4.Header.Caption = "Ngày cấp";
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn5.Header.Caption = "Nơi Cấp";
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn6.Header.Caption = "Ghi Chú";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.Caption = "CC.Chính";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            this.grd_DSDiaChiNhanVien.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grd_DSDiaChiNhanVien.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.FontData.BoldAsString = "True";
            appearance5.FontData.Name = "Arial";
            appearance5.FontData.SizeInPoints = 10F;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.grd_DSDiaChiNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grd_DSDiaChiNhanVien.Location = new System.Drawing.Point(1, 2);
            this.grd_DSDiaChiNhanVien.Name = "grd_DSDiaChiNhanVien";
            this.grd_DSDiaChiNhanVien.Size = new System.Drawing.Size(555, 275);
            this.grd_DSDiaChiNhanVien.TabIndex = 45;
            this.grd_DSDiaChiNhanVien.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grd_DSDiaChiNhanVien_InitializeLayout);
            // 
            // ChungChi_NhanVien_bindingSource
            // 
            this.ChungChi_NhanVien_bindingSource.AllowNew = true;
            this.ChungChi_NhanVien_bindingSource.DataSource = typeof(ERP_Library.NhanVien_ChungChiList);
            // 
            // frmNhanVienChungChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 278);
            this.Controls.Add(this.grd_DSDiaChiNhanVien);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhanVienChungChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chứng Chỉ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNhanVienChungChi_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhanVienChungChi_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSDiaChiNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChungChi_NhanVien_bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource ChungChi_NhanVien_bindingSource;
        private Infragistics.Win.UltraWinGrid.UltraGrid grd_DSDiaChiNhanVien;
    }
}
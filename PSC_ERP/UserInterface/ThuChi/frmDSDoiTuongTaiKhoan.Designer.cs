namespace PSC_ERP
{
    partial class frmDSDoiTuongTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSDoiTuongTaiKhoan));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DoiTuongAll", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenDoiTuong");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaSoThue");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DiaChi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Check");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DaCo");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblChonHet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.grdu_DSKhachHang = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DSKhachHang_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_DSKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSKhachHang_BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblChonHet,
            this.toolStripSeparator1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(679, 25);
            this.tlsMain.TabIndex = 46;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(45, 22);
            this.tlslblLuu.Text = "Lưu";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblChonHet
            // 
            this.tlslblChonHet.Image = ((System.Drawing.Image)(resources.GetObject("tlslblChonHet.Image")));
            this.tlslblChonHet.Name = "tlslblChonHet";
            this.tlslblChonHet.Size = new System.Drawing.Size(83, 22);
            this.tlslblChonHet.Text = "Chọn tất cả";
            this.tlslblChonHet.Click += new System.EventHandler(this.tlslblChonHet_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(67, 22);
            this.tlslblTroGiup.Text = "Trợ Giúp";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblThoat
            // 
            this.tlslblThoat.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThoat.Image")));
            this.tlslblThoat.Name = "tlslblThoat";
            this.tlslblThoat.Size = new System.Drawing.Size(55, 22);
            this.tlslblThoat.Text = "Thoát";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // grdu_DSKhachHang
            // 
            this.grdu_DSKhachHang.DataSource = this.DSKhachHang_BindingSource;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.FontData.BoldAsString = "False";
            this.grdu_DSKhachHang.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 3;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 1;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            this.grdu_DSKhachHang.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdu_DSKhachHang.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdu_DSKhachHang.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.grdu_DSKhachHang.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdu_DSKhachHang.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.grdu_DSKhachHang.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance4.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.grdu_DSKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdu_DSKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdu_DSKhachHang.Location = new System.Drawing.Point(0, 25);
            this.grdu_DSKhachHang.Name = "grdu_DSKhachHang";
            this.grdu_DSKhachHang.Size = new System.Drawing.Size(679, 362);
            this.grdu_DSKhachHang.TabIndex = 47;
            this.grdu_DSKhachHang.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdu_DSKhachHang_InitializeLayout);
            this.grdu_DSKhachHang.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdu_DSKhachHang_CellChange);
            // 
            // DSKhachHang_BindingSource
            // 
            this.DSKhachHang_BindingSource.AllowNew = false;
            this.DSKhachHang_BindingSource.DataSource = typeof(ERP_Library.DoiTuongAllList);
            // 
            // frmDSDoiTuongTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 387);
            this.Controls.Add(this.grdu_DSKhachHang);
            this.Controls.Add(this.tlsMain);
            this.Name = "frmDSDoiTuongTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách đối tượng";
            this.Load += new System.EventHandler(this.frmDSDoiTuongTaiKhoan_Load);
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_DSKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSKhachHang_BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_DSKhachHang;
        private System.Windows.Forms.BindingSource DSKhachHang_BindingSource;
        private System.Windows.Forms.ToolStripButton tlslblChonHet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
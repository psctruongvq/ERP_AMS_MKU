namespace PSC_ERP
{
    partial class frmXacNhanCongThucKeToanTongHop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXacNhanCongThucKeToanTongHop));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("CongThucApDungKeToanTongHop", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongThuc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Loai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayApDung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayApDungString");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NoiDung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoaiString");
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.cmbu_CongThucApDungKeToanTongHop = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.CongThucApDungKeToanTongHopbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_ChiNhanh = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_CongThucApDungKeToanTongHop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CongThucApDungKeToanTongHopbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblThem,
            this.toolStripSeparator1,
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblXoa,
            this.toolStripSeparator3,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(633, 25);
            this.tlsMain.TabIndex = 25;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblThem
            // 
            this.tlslblThem.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThem.Image")));
            this.tlslblThem.Name = "tlslblThem";
            this.tlslblThem.Size = new System.Drawing.Size(58, 22);
            this.tlslblThem.Text = "Thêm";
            this.tlslblThem.Visible = false;
            this.tlslblThem.Click += new System.EventHandler(this.tlslblThem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(47, 22);
            this.tlslblLuu.Text = "Lưu";
            this.tlslblLuu.Visible = false;
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblXoa
            // 
            this.tlslblXoa.Image = ((System.Drawing.Image)(resources.GetObject("tlslblXoa.Image")));
            this.tlslblXoa.Name = "tlslblXoa";
            this.tlslblXoa.Size = new System.Drawing.Size(47, 22);
            this.tlslblXoa.Text = "Xóa";
            this.tlslblXoa.Visible = false;
            this.tlslblXoa.Click += new System.EventHandler(this.tlslblXoa_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(73, 22);
            this.tlslblTroGiup.Text = "Trợ Giúp";
            this.tlslblTroGiup.Visible = false;
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
            this.tlslblThoat.Size = new System.Drawing.Size(58, 22);
            this.tlslblThoat.Text = "Thoát";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // cmbu_CongThucApDungKeToanTongHop
            // 
            appearance1.FontData.BoldAsString = "False";
            this.cmbu_CongThucApDungKeToanTongHop.Appearance = appearance1;
            this.cmbu_CongThucApDungKeToanTongHop.DataSource = this.CongThucApDungKeToanTongHopbindingSource;
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn10.Header.VisiblePosition = 3;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.VisiblePosition = 4;
            ultraGridColumn12.Header.VisiblePosition = 5;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12});
            this.cmbu_CongThucApDungKeToanTongHop.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbu_CongThucApDungKeToanTongHop.DisplayMember = "NoiDung";
            this.cmbu_CongThucApDungKeToanTongHop.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_CongThucApDungKeToanTongHop.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_CongThucApDungKeToanTongHop.Location = new System.Drawing.Point(125, 46);
            this.cmbu_CongThucApDungKeToanTongHop.Name = "cmbu_CongThucApDungKeToanTongHop";
            this.cmbu_CongThucApDungKeToanTongHop.Size = new System.Drawing.Size(416, 22);
            this.cmbu_CongThucApDungKeToanTongHop.TabIndex = 66;
            this.cmbu_CongThucApDungKeToanTongHop.ValueMember = "MaCongThuc";
            this.cmbu_CongThucApDungKeToanTongHop.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_CongThucApDungKeToanTongHop_InitializeLayout);
            // 
            // CongThucApDungKeToanTongHopbindingSource
            // 
            this.CongThucApDungKeToanTongHopbindingSource.DataSource = typeof(ERP_Library.CongThucApDungKeToanTongHopRootList);
            // 
            // lbl_ChiNhanh
            // 
            this.lbl_ChiNhanh.AutoSize = true;
            this.lbl_ChiNhanh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChiNhanh.Location = new System.Drawing.Point(59, 46);
            this.lbl_ChiNhanh.Name = "lbl_ChiNhanh";
            this.lbl_ChiNhanh.Size = new System.Drawing.Size(60, 14);
            this.lbl_ChiNhanh.TabIndex = 67;
            this.lbl_ChiNhanh.Text = "Công Thức";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(174, 109);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(277, 23);
            this.btnXem.TabIndex = 68;
            this.btnXem.Text = "Xem Mẫu";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // frmXacNhanCongThucKeToanTongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 178);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbu_CongThucApDungKeToanTongHop);
            this.Controls.Add(this.lbl_ChiNhanh);
            this.Controls.Add(this.tlsMain);
            this.Name = "frmXacNhanCongThucKeToanTongHop";
            this.Text = "Xác Nhận Công Thức Mẫu Báo Cáo";
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_CongThucApDungKeToanTongHop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CongThucApDungKeToanTongHopbindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblThem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.BindingSource CongThucApDungKeToanTongHopbindingSource;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_CongThucApDungKeToanTongHop;
        private System.Windows.Forms.Label lbl_ChiNhanh;
        private System.Windows.Forms.Button btnXem;
    }
}
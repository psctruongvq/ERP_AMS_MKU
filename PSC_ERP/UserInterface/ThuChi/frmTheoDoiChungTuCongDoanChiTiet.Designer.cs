﻿namespace PSC_ERP
{
    partial class frmTheoDoiChungTuCongDoanChiTiet
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
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChungTu_TheoDoiChiTiet", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MactTheodoichitiet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTheoDoi");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienChungTu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienDaThanhToan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienThanhToan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoTienConLai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap");
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTheoDoiChungTuChiTiet));
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bindingSource1_ChiTietTheoDoi = new System.Windows.Forms.BindingSource(this.components);
            this.tbSoTien = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.tbSoChungTu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChiTietTheoDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSoTien)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblXoa,
            this.toolStripSeparator3,
            this.tlslblUndo,
            this.toolStripLabel1,
            this.tlslblIn,
            this.toolStripButton1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(536, 25);
            this.tlsMain.TabIndex = 8;
            this.tlsMain.Text = "toolStrip1";
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
            this.tlslblLuu.Size = new System.Drawing.Size(96, 22);
            this.tlslblLuu.Text = "Lư&u và Thoát";
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
            this.tlslblXoa.Text = "&Xóa";
            this.tlslblXoa.Click += new System.EventHandler(this.tlslblXoa_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(56, 22);
            this.tlslblUndo.Text = "Undo";
            this.tlslblUndo.Click += new System.EventHandler(this.tlslblUndo_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblIn
            // 
            this.tlslblIn.Image = ((System.Drawing.Image)(resources.GetObject("tlslblIn.Image")));
            this.tlslblIn.Name = "tlslblIn";
            this.tlslblIn.Size = new System.Drawing.Size(37, 22);
            this.tlslblIn.Text = "In";
            this.tlslblIn.Click += new System.EventHandler(this.tlslblIn_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(83, 22);
            this.tlslblTroGiup.Text = "Danh Sách";
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
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.DataSource = this.bindingSource1_ChiTietTheoDoi;
            appearance39.BackColor = System.Drawing.Color.White;
            this.grdData.DisplayLayout.Appearance = appearance39;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn8.Format = "dd/MM/yyyy";
            ultraGridColumn8.Header.Caption = "Ngày Lập";
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.FixedAddRowOnTop;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grdData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance40.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance40;
            this.grdData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance41.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance41.FontData.BoldAsString = "True";
            appearance41.FontData.Name = "Arial";
            appearance41.FontData.SizeInPoints = 10F;
            appearance41.ForeColor = System.Drawing.Color.White;
            appearance41.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdData.DisplayLayout.Override.HeaderAppearance = appearance41;
            this.grdData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance42.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.RowSelectorAppearance = appearance42;
            this.grdData.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.grdData.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.grdData.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance43.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.SelectedRowAppearance = appearance43;
            this.grdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 119);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(524, 182);
            this.grdData.TabIndex = 9;
            this.grdData.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grdData.AfterRowInsert += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.grdData_AfterRowInsert);
            this.grdData.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdData_InitializeLayout);
            // 
            // bindingSource1_ChiTietTheoDoi
            // 
            this.bindingSource1_ChiTietTheoDoi.AllowNew = true;
            this.bindingSource1_ChiTietTheoDoi.DataSource = typeof(ERP_Library.CongDoanChungTu_TheoDoiChiTietList);
            // 
            // tbSoTien
            // 
            this.tbSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSoTien.FormatProvider = new System.Globalization.CultureInfo("vi-VN");
            this.tbSoTien.FormatString = "###,###,###,###";
            this.tbSoTien.Location = new System.Drawing.Point(297, 18);
            this.tbSoTien.Name = "tbSoTien";
            this.tbSoTien.ReadOnly = true;
            this.tbSoTien.Size = new System.Drawing.Size(160, 21);
            this.tbSoTien.TabIndex = 10;
            // 
            // tbSoChungTu
            // 
            this.tbSoChungTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSoChungTu.Location = new System.Drawing.Point(90, 19);
            this.tbSoChungTu.Name = "tbSoChungTu";
            this.tbSoChungTu.ReadOnly = true;
            this.tbSoChungTu.Size = new System.Drawing.Size(136, 20);
            this.tbSoChungTu.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbSoChungTu);
            this.groupBox1.Controls.Add(this.tbSoTien);
            this.groupBox1.Location = new System.Drawing.Point(23, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 62);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Số Tiền";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Số Chứng Từ";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(47, 22);
            this.toolStripButton2.Text = "&Lưu";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // frmTheoDoiChungTuChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 301);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.grdData);
            this.KeyPreview = true;
            this.Name = "frmTheoDoiChungTuChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh Toán Chứng Từ";
            this.Load += new System.EventHandler(this.frmTamUng_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTheoDoiChungTuChiTiet_FormClosing);
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_ChiTietTheoDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSoTien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        internal Infragistics.Win.UltraWinGrid.UltraGrid grdData;
        private System.Windows.Forms.BindingSource bindingSource1_ChiTietTheoDoi;
        private Infragistics.Win.UltraWinEditors.UltraCurrencyEditor tbSoTien;
        private System.Windows.Forms.TextBox tbSoChungTu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}
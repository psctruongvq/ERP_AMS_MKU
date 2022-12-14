namespace PSC_ERP.Security
{
    partial class frmGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroups));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("GroupItem", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GroupID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChucNang");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.itNew = new System.Windows.Forms.ToolStripButton();
            this.itEdit = new System.Windows.Forms.ToolStripButton();
            this.itDelete = new System.Windows.Forms.ToolStripButton();
            this.itSave = new System.Windows.Forms.ToolStripButton();
            this.itUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.itDong = new System.Windows.Forms.ToolStripButton();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdData = new System.Windows.Forms.BindingSource(this.components);
            this.toolMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).BeginInit();
            this.SuspendLayout();
            // 
            // toolMain
            // 
            this.toolMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itNew,
            this.itEdit,
            this.itDelete,
            this.itSave,
            this.itUndo,
            this.toolStripSeparator2,
            this.itDong});
            this.toolMain.Location = new System.Drawing.Point(0, 0);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(460, 31);
            this.toolMain.TabIndex = 1;
            this.toolMain.Text = "Cập nhật";
            // 
            // itNew
            // 
            this.itNew.Image = global::PSC_ERP.Properties.Resources._122;
            this.itNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itNew.Name = "itNew";
            this.itNew.Size = new System.Drawing.Size(65, 28);
            this.itNew.Text = "Thêm";
            this.itNew.Click += new System.EventHandler(this.itNew_Click);
            // 
            // itEdit
            // 
            this.itEdit.Image = global::PSC_ERP.Properties.Resources.LapQuyetDinhDaoTao_Tool_Image;
            this.itEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itEdit.Name = "itEdit";
            this.itEdit.Size = new System.Drawing.Size(54, 28);
            this.itEdit.Text = "Sửa";
            this.itEdit.Click += new System.EventHandler(this.itEdit_Click);
            // 
            // itDelete
            // 
            this.itDelete.Image = global::PSC_ERP.Properties.Resources.LoaiQuyetDinhTV_Tool_Image;
            this.itDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itDelete.Name = "itDelete";
            this.itDelete.Size = new System.Drawing.Size(55, 28);
            this.itDelete.Text = "Xóa";
            this.itDelete.Click += new System.EventHandler(this.itDelete_Click);
            // 
            // itSave
            // 
            this.itSave.Image = ((System.Drawing.Image)(resources.GetObject("itSave.Image")));
            this.itSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itSave.Name = "itSave";
            this.itSave.Size = new System.Drawing.Size(55, 28);
            this.itSave.Text = "Lưu";
            this.itSave.Click += new System.EventHandler(this.itSave_Click);
            // 
            // itUndo
            // 
            this.itUndo.Image = ((System.Drawing.Image)(resources.GetObject("itUndo.Image")));
            this.itUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itUndo.Name = "itUndo";
            this.itUndo.Size = new System.Drawing.Size(74, 28);
            this.itUndo.Text = "Refresh";
            this.itUndo.Click += new System.EventHandler(this.itUndo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // itDong
            // 
            this.itDong.Image = ((System.Drawing.Image)(resources.GetObject("itDong.Image")));
            this.itDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itDong.Name = "itDong";
            this.itDong.Size = new System.Drawing.Size(64, 28);
            this.itDong.Text = "Đóng";
            this.itDong.Click += new System.EventHandler(this.itDong_Click);
            // 
            // grdData
            // 
            this.grdData.DataSource = this.bdData;
            appearance1.BackColor = System.Drawing.Color.White;
            this.grdData.DisplayLayout.Appearance = appearance1;
            ultraGridBand1.ColHeadersVisible = false;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Width = 165;
            ultraGridColumn2.DefaultCellValue = "";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Nullable = Infragistics.Win.UltraWinGrid.Nullable.EmptyString;
            ultraGridColumn2.Width = 415;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "Arial";
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdData.DisplayLayout.Override.HeaderAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.RowSelectorAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.grdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(12, 34);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(436, 367);
            this.grdData.TabIndex = 2;
            this.grdData.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDIPlus;
            this.grdData.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            this.grdData.AfterRowsDeleted += new System.EventHandler(this.grdData_AfterRowsDeleted);
            this.grdData.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.grdData_BeforeRowsDeleted);
            // 
            // bdData
            // 
            this.bdData.DataSource = typeof(ERP_Library.Security.GroupList);
            // 
            // frmGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 413);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.toolMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhóm người sử dụng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGroups_FormClosed);
            this.Load += new System.EventHandler(this.frmGroups_Load);
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.ToolStripButton itSave;
        private System.Windows.Forms.ToolStripButton itUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton itDong;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdData;
        private System.Windows.Forms.BindingSource bdData;
        private System.Windows.Forms.ToolStripButton itEdit;
        private System.Windows.Forms.ToolStripButton itNew;
        private System.Windows.Forms.ToolStripButton itDelete;
    }
}
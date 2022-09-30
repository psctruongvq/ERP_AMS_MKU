namespace PSC_ERP
{
    partial class frmXoaCTThuLao
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Ky", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenKy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayBatDau");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKetThuc");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.bindingSource_Ky = new System.Windows.Forms.BindingSource(this.components);
            this.cmbu_KyLuong = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_ChiNhanh = new System.Windows.Forms.Label();
            this.cmbu_Bophan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.BindS_BoPhan = new System.Windows.Forms.BindingSource(this.components);
            this.btnExecute = new Infragistics.Win.Misc.UltraButton();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Ky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_KyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Ky
            // 
            this.bindingSource_Ky.DataSource = typeof(ERP_Library.KyList);
            // 
            // cmbu_KyLuong
            // 
            this.cmbu_KyLuong.DataSource = this.bindingSource_Ky;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn6,
            ultraGridColumn3,
            ultraGridColumn4});
            this.cmbu_KyLuong.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbu_KyLuong.DisplayMember = "TenKy";
            this.cmbu_KyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_KyLuong.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_KyLuong.Location = new System.Drawing.Point(114, 13);
            this.cmbu_KyLuong.Name = "cmbu_KyLuong";
            this.cmbu_KyLuong.Size = new System.Drawing.Size(213, 22);
            this.cmbu_KyLuong.TabIndex = 89;
            this.cmbu_KyLuong.ValueMember = "MaKy";
            this.cmbu_KyLuong.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_KyLuong_InitializeLayout);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 14);
            this.label14.TabIndex = 90;
            this.label14.Text = "Kỳ tính lương:";
            // 
            // lbl_ChiNhanh
            // 
            this.lbl_ChiNhanh.AutoSize = true;
            this.lbl_ChiNhanh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChiNhanh.Location = new System.Drawing.Point(19, 42);
            this.lbl_ChiNhanh.Name = "lbl_ChiNhanh";
            this.lbl_ChiNhanh.Size = new System.Drawing.Size(50, 14);
            this.lbl_ChiNhanh.TabIndex = 92;
            this.lbl_ChiNhanh.Text = "Bộ phận:";
            // 
            // cmbu_Bophan
            // 
            appearance1.FontData.BoldAsString = "False";
            this.cmbu_Bophan.Appearance = appearance1;
            this.cmbu_Bophan.DataSource = this.BindS_BoPhan;
            this.cmbu_Bophan.DisplayMember = "TenBoPhan";
            this.cmbu_Bophan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_Bophan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_Bophan.Location = new System.Drawing.Point(114, 38);
            this.cmbu_Bophan.Name = "cmbu_Bophan";
            this.cmbu_Bophan.Size = new System.Drawing.Size(213, 22);
            this.cmbu_Bophan.TabIndex = 91;
            this.cmbu_Bophan.ValueMember = "MaBoPhan";
            this.cmbu_Bophan.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_Bophan_InitializeLayout);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(67, 66);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(100, 30);
            this.btnExecute.TabIndex = 93;
            this.btnExecute.Text = "Thực hiện";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(173, 66);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 94;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmXoaCTThuLao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 109);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lbl_ChiNhanh);
            this.Controls.Add(this.cmbu_Bophan);
            this.Controls.Add(this.cmbu_KyLuong);
            this.Controls.Add(this.label14);
            this.Name = "frmXoaCTThuLao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xóa dữ liệu chứng từ thù lao";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Ky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_KyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_Bophan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource_Ky;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_KyLuong;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_ChiNhanh;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_Bophan;
        private System.Windows.Forms.BindingSource BindS_BoPhan;
        private Infragistics.Win.Misc.UltraButton btnExecute;
        private Infragistics.Win.Misc.UltraButton btnClose;
    }
}
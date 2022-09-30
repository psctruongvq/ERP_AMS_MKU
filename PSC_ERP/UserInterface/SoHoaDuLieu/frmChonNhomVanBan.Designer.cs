namespace PSC_ERP.UserInterface.SoHoaDuLieu
{
    partial class frmChonNhomVanBan
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
            this.cmb_NhomVanBan = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.bindingSource_NhomVanBan = new System.Windows.Forms.BindingSource(this.components);
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.colMaQuanLy = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTenNhomvanBan = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDienGiai = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaBoPhan = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUserId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_DongY = new DevExpress.XtraEditors.SimpleButton();
            this.btn_HuyBo = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_NhomVanBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_NhomVanBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_NhomVanBan
            // 
            this.cmb_NhomVanBan.Location = new System.Drawing.Point(150, 20);
            this.cmb_NhomVanBan.Name = "cmb_NhomVanBan";
            this.cmb_NhomVanBan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.cmb_NhomVanBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_NhomVanBan.Properties.DataSource = this.bindingSource_NhomVanBan;
            this.cmb_NhomVanBan.Properties.DisplayMember = "TenNhomvanBan";
            this.cmb_NhomVanBan.Properties.NullText = "";
            this.cmb_NhomVanBan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmb_NhomVanBan.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.cmb_NhomVanBan.Properties.ValueMember = "MaNhomVanBan";
            this.cmb_NhomVanBan.Size = new System.Drawing.Size(232, 20);
            this.cmb_NhomVanBan.TabIndex = 3;
            // 
            // bindingSource_NhomVanBan
            // 
            this.bindingSource_NhomVanBan.DataSource = typeof(ERP_Library.NhomVanBan);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colMaQuanLy,
            this.colTenNhomvanBan,
            this.colDienGiai,
            this.colMaBoPhan,
            this.colUserId});
            this.treeListLookUpEdit1TreeList.DataSource = this.bindingSource_NhomVanBan;
            this.treeListLookUpEdit1TreeList.KeyFieldName = "MaNhomVanBan";
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(-13, -58);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.ParentFieldName = "MaNhomCha";
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // colMaQuanLy
            // 
            this.colMaQuanLy.Caption = "Mã Quản Lý";
            this.colMaQuanLy.FieldName = "MaQuanLy";
            this.colMaQuanLy.Name = "colMaQuanLy";
            this.colMaQuanLy.Visible = true;
            this.colMaQuanLy.VisibleIndex = 0;
            this.colMaQuanLy.Width = 55;
            // 
            // colTenNhomvanBan
            // 
            this.colTenNhomvanBan.Caption = "Nhóm Văn Bản";
            this.colTenNhomvanBan.FieldName = "TenNhomvanBan";
            this.colTenNhomvanBan.Name = "colTenNhomvanBan";
            this.colTenNhomvanBan.Visible = true;
            this.colTenNhomvanBan.VisibleIndex = 1;
            this.colTenNhomvanBan.Width = 55;
            // 
            // colDienGiai
            // 
            this.colDienGiai.FieldName = "DienGiai";
            this.colDienGiai.Name = "colDienGiai";
            this.colDienGiai.Width = 55;
            // 
            // colMaBoPhan
            // 
            this.colMaBoPhan.FieldName = "MaBoPhan";
            this.colMaBoPhan.Name = "colMaBoPhan";
            this.colMaBoPhan.Width = 55;
            // 
            // colUserId
            // 
            this.colUserId.FieldName = "UserId";
            this.colUserId.Name = "colUserId";
            this.colUserId.Width = 55;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(11, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(133, 17);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Chọn Nhóm Văn Bản:";
            // 
            // btn_DongY
            // 
            this.btn_DongY.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_DongY.Appearance.Options.UseFont = true;
            this.btn_DongY.Location = new System.Drawing.Point(29, 46);
            this.btn_DongY.Name = "btn_DongY";
            this.btn_DongY.Size = new System.Drawing.Size(139, 33);
            this.btn_DongY.TabIndex = 5;
            this.btn_DongY.Text = "Đồng Ý";
            this.btn_DongY.Click += new System.EventHandler(this.btn_DongY_Click);
            // 
            // btn_HuyBo
            // 
            this.btn_HuyBo.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_HuyBo.Appearance.Options.UseFont = true;
            this.btn_HuyBo.Location = new System.Drawing.Point(220, 46);
            this.btn_HuyBo.Name = "btn_HuyBo";
            this.btn_HuyBo.Size = new System.Drawing.Size(133, 33);
            this.btn_HuyBo.TabIndex = 5;
            this.btn_HuyBo.Text = "Hủy Bỏ";
            this.btn_HuyBo.Click += new System.EventHandler(this.btn_HuyBo_Click);
            // 
            // frmChonNhomVanBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 85);
            this.Controls.Add(this.btn_HuyBo);
            this.Controls.Add(this.btn_DongY);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmb_NhomVanBan);
            this.Name = "frmChonNhomVanBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn Nhóm Văn Bản";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChonNhomVanBan_FormClosed);
            this.Load += new System.EventHandler(this.frmChonNhomVanBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmb_NhomVanBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_NhomVanBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private System.Windows.Forms.BindingSource bindingSource_NhomVanBan;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaQuanLy;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTenNhomvanBan;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDienGiai;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaBoPhan;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUserId;
        public DevExpress.XtraEditors.TreeListLookUpEdit cmb_NhomVanBan;
        private DevExpress.XtraEditors.SimpleButton btn_DongY;
        private DevExpress.XtraEditors.SimpleButton btn_HuyBo;
    }
}
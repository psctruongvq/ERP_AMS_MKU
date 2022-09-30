namespace PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog
{
    partial class frmDialogChonViTri
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
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tblBoPhanERPNewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.cbViTriNew = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridV_ViTri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaBoPhanQL1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenBoPhan1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblBoPhanERPNewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbViTriNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_ViTri)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.labelControl6.Appearance.Options.UseBackColor = true;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.LineVisible = true;
            this.labelControl6.Location = new System.Drawing.Point(30, 52);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 15);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Vị Trí:";
            // 
            // tblBoPhanERPNewBindingSource
            // 
            this.tblBoPhanERPNewBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblBoPhanERPNew);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(111, 82);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbViTriNew
            // 
            this.cbViTriNew.Location = new System.Drawing.Point(68, 47);
            this.cbViTriNew.Name = "cbViTriNew";
            this.cbViTriNew.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbViTriNew.Properties.DataSource = this.tblBoPhanERPNewBindingSource;
            this.cbViTriNew.Properties.DisplayMember = "TenBoPhan";
            this.cbViTriNew.Properties.NullText = "";
            this.cbViTriNew.Properties.PopupSizeable = false;
            this.cbViTriNew.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbViTriNew.Properties.ValueMember = "MaBoPhan";
            this.cbViTriNew.Properties.View = this.gridV_ViTri;
            this.cbViTriNew.Size = new System.Drawing.Size(193, 20);
            this.cbViTriNew.TabIndex = 13;
            // 
            // gridV_ViTri
            // 
            this.gridV_ViTri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaBoPhanQL1,
            this.colTenBoPhan1});
            this.gridV_ViTri.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridV_ViTri.Name = "gridV_ViTri";
            this.gridV_ViTri.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridV_ViTri.OptionsView.ShowAutoFilterRow = true;
            this.gridV_ViTri.OptionsView.ShowGroupPanel = false;
            // 
            // colMaBoPhanQL1
            // 
            this.colMaBoPhanQL1.Caption = "Mã Quản Lý";
            this.colMaBoPhanQL1.FieldName = "MaBoPhanQL";
            this.colMaBoPhanQL1.Name = "colMaBoPhanQL1";
            this.colMaBoPhanQL1.OptionsColumn.ReadOnly = true;
            this.colMaBoPhanQL1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaBoPhanQL1.Visible = true;
            this.colMaBoPhanQL1.VisibleIndex = 0;
            this.colMaBoPhanQL1.Width = 457;
            // 
            // colTenBoPhan1
            // 
            this.colTenBoPhan1.Caption = "Tên Bộ Phận";
            this.colTenBoPhan1.FieldName = "TenBoPhan";
            this.colTenBoPhan1.Name = "colTenBoPhan1";
            this.colTenBoPhan1.OptionsColumn.ReadOnly = true;
            this.colTenBoPhan1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenBoPhan1.Visible = true;
            this.colTenBoPhan1.VisibleIndex = 1;
            this.colTenBoPhan1.Width = 738;
            // 
            // frmDialogChonViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 127);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbViTriNew);
            this.Name = "frmDialogChonViTri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn Vị Trí";
            ((System.ComponentModel.ISupportInitialize)(this.tblBoPhanERPNewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbViTriNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_ViTri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.BindingSource tblBoPhanERPNewBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GridLookUpEdit cbViTriNew;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_ViTri;
        private DevExpress.XtraGrid.Columns.GridColumn colMaBoPhanQL1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenBoPhan1;
    }
}
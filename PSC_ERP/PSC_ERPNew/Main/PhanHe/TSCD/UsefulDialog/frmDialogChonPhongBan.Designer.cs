namespace PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog
{
    partial class frmDialogChonPhongBan
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
            this.cbBoPhan = new DevExpress.XtraEditors.GridLookUpEdit();
            this.tblBoPhanERPNewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenBoPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaBoPhanQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbBoPhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBoPhanERPNewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.labelControl6.LineVisible = true;
            this.labelControl6.Location = new System.Drawing.Point(24, 35);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(61, 15);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Phòng ban:";
            // 
            // cbBoPhan
            // 
            this.cbBoPhan.EditValue = "0";
            this.cbBoPhan.Location = new System.Drawing.Point(106, 33);
            this.cbBoPhan.Name = "cbBoPhan";
            this.cbBoPhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBoPhan.Properties.DataSource = this.tblBoPhanERPNewBindingSource;
            this.cbBoPhan.Properties.DisplayMember = "TenBoPhan";
            this.cbBoPhan.Properties.NullText = "<<Không chọn>>";
            this.cbBoPhan.Properties.ValueMember = "MaBoPhan";
            this.cbBoPhan.Properties.View = this.gridView4;
            this.cbBoPhan.Size = new System.Drawing.Size(193, 20);
            this.cbBoPhan.TabIndex = 7;
            // 
            // tblBoPhanERPNewBindingSource
            // 
            this.tblBoPhanERPNewBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblBoPhanERPNew);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenBoPhan,
            this.colMaBoPhanQL});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // colTenBoPhan
            // 
            this.colTenBoPhan.FieldName = "TenBoPhan";
            this.colTenBoPhan.Name = "colTenBoPhan";
            this.colTenBoPhan.Visible = true;
            this.colTenBoPhan.VisibleIndex = 0;
            // 
            // colMaBoPhanQL
            // 
            this.colMaBoPhanQL.FieldName = "MaBoPhanQL";
            this.colMaBoPhanQL.Name = "colMaBoPhanQL";
            this.colMaBoPhanQL.Visible = true;
            this.colMaBoPhanQL.VisibleIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(165, 86);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmDialogChonPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 141);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.cbBoPhan);
            this.Name = "frmDialogChonPhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn phòng ban";
            this.Load += new System.EventHandler(this.frmDialogChonPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbBoPhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBoPhanERPNewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tblBoPhanERPNewBindingSource;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.GridLookUpEdit cbBoPhan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colTenBoPhan;
        private DevExpress.XtraGrid.Columns.GridColumn colMaBoPhanQL;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}
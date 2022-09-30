namespace PSC_ERP
{
    partial class frmKetChuyenTaiKhoan
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
            this.kyListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bt_NhapSoDu = new System.Windows.Forms.Button();
            this.cb_NamKeToan = new System.Windows.Forms.ComboBox();
            this.lueky = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TenKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kyListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueky.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // kyListBindingSource
            // 
            this.kyListBindingSource.DataSource = typeof(ERP_Library.KyList);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Kỳ kết chuyển";
            // 
            // bt_NhapSoDu
            // 
            this.bt_NhapSoDu.Location = new System.Drawing.Point(334, 24);
            this.bt_NhapSoDu.Name = "bt_NhapSoDu";
            this.bt_NhapSoDu.Size = new System.Drawing.Size(144, 23);
            this.bt_NhapSoDu.TabIndex = 15;
            this.bt_NhapSoDu.Text = "Thực hiện kết chuyển";
            this.bt_NhapSoDu.UseVisualStyleBackColor = true;
            this.bt_NhapSoDu.Click += new System.EventHandler(this.bt_NhapSoDu_Click);
            // 
            // cb_NamKeToan
            // 
            this.cb_NamKeToan.FormattingEnabled = true;
            this.cb_NamKeToan.Location = new System.Drawing.Point(94, 97);
            this.cb_NamKeToan.Name = "cb_NamKeToan";
            this.cb_NamKeToan.Size = new System.Drawing.Size(225, 21);
            this.cb_NamKeToan.TabIndex = 16;
            this.cb_NamKeToan.Visible = false;
            // 
            // lueky
            // 
            this.lueky.EditValue = "";
            this.lueky.Location = new System.Drawing.Point(103, 27);
            this.lueky.Name = "lueky";
            this.lueky.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueky.Properties.DataSource = this.kyListBindingSource;
            this.lueky.Properties.DisplayMember = "TenKy";
            this.lueky.Properties.ValueMember = "MaKy";
            this.lueky.Properties.View = this.gridLookUpEdit1View;
            this.lueky.Size = new System.Drawing.Size(225, 20);
            this.lueky.TabIndex = 17;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TenKy,
            this.NgayBatDau,
            this.NgayKetThuc});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // TenKy
            // 
            this.TenKy.Caption = "Tên kỳ";
            this.TenKy.FieldName = "TenKy";
            this.TenKy.Name = "TenKy";
            this.TenKy.Visible = true;
            this.TenKy.VisibleIndex = 0;
            // 
            // NgayBatDau
            // 
            this.NgayBatDau.Caption = "Ngày bắt đầu";
            this.NgayBatDau.FieldName = "NgayBatDau";
            this.NgayBatDau.Name = "NgayBatDau";
            this.NgayBatDau.Visible = true;
            this.NgayBatDau.VisibleIndex = 1;
            // 
            // NgayKetThuc
            // 
            this.NgayKetThuc.Caption = "Ngày kết thúc";
            this.NgayKetThuc.FieldName = "NgayKetThuc";
            this.NgayKetThuc.Name = "NgayKetThuc";
            this.NgayKetThuc.Visible = true;
            this.NgayKetThuc.VisibleIndex = 2;
            // 
            // frmKetChuyenTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 225);
            this.Controls.Add(this.lueky);
            this.Controls.Add(this.cb_NamKeToan);
            this.Controls.Add(this.bt_NhapSoDu);
            this.Controls.Add(this.label4);
            this.Name = "frmKetChuyenTaiKhoan";
            this.Text = "Kết Chuyển Tài Khoản";
            ((System.ComponentModel.ISupportInitialize)(this.kyListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueky.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource kyListBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_NhapSoDu;
        private System.Windows.Forms.ComboBox cb_NamKeToan;
        private DevExpress.XtraEditors.GridLookUpEdit lueky;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn TenKy;
        private DevExpress.XtraGrid.Columns.GridColumn NgayBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn NgayKetThuc;

    }
}
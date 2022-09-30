namespace PSC_ERP
{
    partial class frmThongTuApDung1
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnXem = new System.Windows.Forms.Button();
            this.lueThongTu = new DevExpress.XtraEditors.GridLookUpEdit();
            this.bs_ThongTuAD = new System.Windows.Forms.BindingSource(this.components);
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayApDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lueThongTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_ThongTuAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Thông tư";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(240, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(74, 31);
            this.btnXem.TabIndex = 3;
            this.btnXem.Text = "Xem Mẫu";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click_1);
            // 
            // lueThongTu
            // 
            this.lueThongTu.Location = new System.Drawing.Point(71, 18);
            this.lueThongTu.Name = "lueThongTu";
            this.lueThongTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueThongTu.Properties.DataSource = this.bs_ThongTuAD;
            this.lueThongTu.Properties.DisplayMember = "NoiDung";
            this.lueThongTu.Properties.ValueMember = "Id";
            this.lueThongTu.Properties.View = this.gridLookUpEdit1View;
            this.lueThongTu.Size = new System.Drawing.Size(163, 20);
            this.lueThongTu.TabIndex = 4;
            // 
            // bs_ThongTuAD
            // 
            this.bs_ThongTuAD.DataSource = typeof(ERP_Library.ThongTuApDung1List);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NoiDung,
            this.NgayApDung});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // NoiDung
            // 
            this.NoiDung.Caption = "Nội dung";
            this.NoiDung.FieldName = "NoiDung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Visible = true;
            this.NoiDung.VisibleIndex = 0;
            // 
            // NgayApDung
            // 
            this.NgayApDung.Caption = "Ngày áp dụng";
            this.NgayApDung.FieldName = "NgayApDung";
            this.NgayApDung.Name = "NgayApDung";
            this.NgayApDung.Visible = true;
            this.NgayApDung.VisibleIndex = 1;
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.Location = new System.Drawing.Point(320, 12);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(100, 31);
            this.btnTaoMoi.TabIndex = 5;
            this.btnTaoMoi.Text = "Tạo mới thông tư";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Xem Mẫu Grid";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(426, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(93, 31);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmThongTuApDung1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 201);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTaoMoi);
            this.Controls.Add(this.lueThongTu);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmThongTuApDung1";
            this.Text = "Xác Nhận Thông Tư Mẫu Báo Cáo";
            ((System.ComponentModel.ISupportInitialize)(this.lueThongTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_ThongTuAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btnXem;
        private DevExpress.XtraEditors.GridLookUpEdit lueThongTu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private System.Windows.Forms.BindingSource bs_ThongTuAD;
        private DevExpress.XtraGrid.Columns.GridColumn NoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn NgayApDung;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnThoat;
    }
}
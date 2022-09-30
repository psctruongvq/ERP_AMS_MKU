namespace PSC_ERPNew.Main.Reports
{
    partial class frmFillReportInfo
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
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhongLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtKey = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDataSourceMethod = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dteCreateDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.numIdx = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtLayoutPath = new DevExpress.XtraEditors.TextEdit();
            this.btnChooseLayout = new DevExpress.XtraEditors.SimpleButton();
            this.txtMaPhanHe = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataSourceMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteCreateDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteCreateDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIdx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLayoutPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhanHe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(131, 201);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnKhongLuu
            // 
            this.btnKhongLuu.Location = new System.Drawing.Point(372, 201);
            this.btnKhongLuu.Name = "btnKhongLuu";
            this.btnKhongLuu.Size = new System.Drawing.Size(75, 23);
            this.btnKhongLuu.TabIndex = 8;
            this.btnKhongLuu.Text = "Không lưu";
            this.btnKhongLuu.Click += new System.EventHandler(this.btnKhongLuu_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(131, 41);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(316, 20);
            this.txtKey.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Key";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(131, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(316, 20);
            this.txtName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Tên";
            // 
            // txtDataSourceMethod
            // 
            this.txtDataSourceMethod.Location = new System.Drawing.Point(131, 93);
            this.txtDataSourceMethod.Name = "txtDataSourceMethod";
            this.txtDataSourceMethod.Size = new System.Drawing.Size(316, 20);
            this.txtDataSourceMethod.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 96);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(114, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Phương thức lấy dữ liệu";
            // 
            // dteCreateDate
            // 
            this.dteCreateDate.EditValue = null;
            this.dteCreateDate.Location = new System.Drawing.Point(131, 120);
            this.dteCreateDate.Name = "dteCreateDate";
            this.dteCreateDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteCreateDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteCreateDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dteCreateDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dteCreateDate.Size = new System.Drawing.Size(100, 20);
            this.dteCreateDate.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 123);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(44, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Ngày tạo";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(329, 127);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(18, 13);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "STT";
            // 
            // numIdx
            // 
            this.numIdx.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numIdx.Location = new System.Drawing.Point(372, 123);
            this.numIdx.Name = "numIdx";
            this.numIdx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.numIdx.Size = new System.Drawing.Size(75, 20);
            this.numIdx.TabIndex = 4;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(13, 178);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(99, 13);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Layout mẫu (nếu có)";
            // 
            // txtLayoutPath
            // 
            this.txtLayoutPath.Location = new System.Drawing.Point(131, 175);
            this.txtLayoutPath.Name = "txtLayoutPath";
            this.txtLayoutPath.Size = new System.Drawing.Size(275, 20);
            this.txtLayoutPath.TabIndex = 6;
            // 
            // btnChooseLayout
            // 
            this.btnChooseLayout.Location = new System.Drawing.Point(412, 173);
            this.btnChooseLayout.Name = "btnChooseLayout";
            this.btnChooseLayout.Size = new System.Drawing.Size(35, 23);
            this.btnChooseLayout.TabIndex = 9;
            this.btnChooseLayout.Text = "...";
            this.btnChooseLayout.Click += new System.EventHandler(this.btnChooseLayout_Click);
            // 
            // txtMaPhanHe
            // 
            this.txtMaPhanHe.Location = new System.Drawing.Point(131, 149);
            this.txtMaPhanHe.Name = "txtMaPhanHe";
            this.txtMaPhanHe.Size = new System.Drawing.Size(100, 20);
            this.txtMaPhanHe.TabIndex = 5;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(13, 152);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 13);
            this.labelControl7.TabIndex = 5;
            this.labelControl7.Text = "Mã phân hệ";
            // 
            // frmFillReportInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 236);
            this.Controls.Add(this.btnChooseLayout);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtLayoutPath);
            this.Controls.Add(this.numIdx);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.dteCreateDate);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtDataSourceMethod);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtMaPhanHe);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnKhongLuu);
            this.Controls.Add(this.btnSave);
            this.Name = "frmFillReportInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin cơ bản của report";
            this.Load += new System.EventHandler(this.frmThemMoiReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataSourceMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteCreateDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteCreateDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIdx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLayoutPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhanHe.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnKhongLuu;
        private DevExpress.XtraEditors.TextEdit txtKey;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDataSourceMethod;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dteCreateDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit numIdx;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtLayoutPath;
        private DevExpress.XtraEditors.SimpleButton btnChooseLayout;
        private DevExpress.XtraEditors.TextEdit txtMaPhanHe;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}
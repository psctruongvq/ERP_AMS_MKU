namespace PSC_ERP
{
    partial class frmBangLuongNhanVien
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.btnDong = new Infragistics.Win.Misc.UltraButton();
            this.btnTinhLuongDot1 = new Infragistics.Win.Misc.UltraButton();
            this.txtDenNgay = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtTuNgay = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNgayThamNien = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.btnTinhLuongDot2 = new Infragistics.Win.Misc.UltraButton();
            this.cmbBoPhan = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.boPhanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtNgayBDTinh = new System.Windows.Forms.DateTimePicker();
            this.dtNgayKTTinh = new System.Windows.Forms.DateTimePicker();
            this.cmbNhanVien = new PSC_ERP.ComboboxNhanVien();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayThamNien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(249, 206);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(93, 29);
            this.btnDong.TabIndex = 14;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTinhLuongDot1
            // 
            this.btnTinhLuongDot1.Location = new System.Drawing.Point(23, 206);
            this.btnTinhLuongDot1.Name = "btnTinhLuongDot1";
            this.btnTinhLuongDot1.Size = new System.Drawing.Size(105, 29);
            this.btnTinhLuongDot1.TabIndex = 12;
            this.btnTinhLuongDot1.Text = "Tính lương đợt 1";
            this.btnTinhLuongDot1.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtDenNgay.Enabled = false;
            this.txtDenNgay.Location = new System.Drawing.Point(249, 50);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(93, 21);
            this.txtDenNgay.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "đến ngày";
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.DisplayMember = "TenKy";
            this.cmbKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyLuong.Location = new System.Drawing.Point(92, 23);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(250, 21);
            this.cmbKyLuong.TabIndex = 1;
            this.cmbKyLuong.ValueMember = "MaKy";
            this.cmbKyLuong.ValueChanged += new System.EventHandler(this.cmbKyLuong_ValueChanged);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtTuNgay.Enabled = false;
            this.txtTuNgay.Location = new System.Drawing.Point(92, 50);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(88, 21);
            this.txtTuNgay.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng lương";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ ngày";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ngày tính thâm niên";
            // 
            // txtNgayThamNien
            // 
            this.txtNgayThamNien.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtNgayThamNien.Location = new System.Drawing.Point(137, 164);
            this.txtNgayThamNien.Name = "txtNgayThamNien";
            this.txtNgayThamNien.Size = new System.Drawing.Size(205, 21);
            this.txtNgayThamNien.TabIndex = 11;
            // 
            // btnTinhLuongDot2
            // 
            this.btnTinhLuongDot2.Location = new System.Drawing.Point(134, 206);
            this.btnTinhLuongDot2.Name = "btnTinhLuongDot2";
            this.btnTinhLuongDot2.Size = new System.Drawing.Size(109, 29);
            this.btnTinhLuongDot2.TabIndex = 13;
            this.btnTinhLuongDot2.Text = "Tính lương đợt 2";
            this.btnTinhLuongDot2.Click += new System.EventHandler(this.btnTinhLuongDot2_Click);
            // 
            // cmbBoPhan
            // 
            this.cmbBoPhan.DataSource = this.boPhanListBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cmbBoPhan.DisplayLayout.Appearance = appearance1;
            this.cmbBoPhan.DisplayLayout.InterBandSpacing = 10;
            this.cmbBoPhan.DisplayLayout.MaxColScrollRegions = 1;
            this.cmbBoPhan.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.CellAppearance = appearance3;
            this.cmbBoPhan.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance4.BackColor = System.Drawing.SystemColors.Control;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.cmbBoPhan.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.cmbBoPhan.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbBoPhan.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            appearance6.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbBoPhan.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.cmbBoPhan.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbBoPhan.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.cmbBoPhan.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbBoPhan.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbBoPhan.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmbBoPhan.DisplayMember = "TenBoPhan";
            this.cmbBoPhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbBoPhan.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cmbBoPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbBoPhan.Location = new System.Drawing.Point(92, 102);
            this.cmbBoPhan.Name = "cmbBoPhan";
            this.cmbBoPhan.Size = new System.Drawing.Size(250, 22);
            this.cmbBoPhan.TabIndex = 7;
            this.cmbBoPhan.ValueMember = "MaBoPhan";
            this.cmbBoPhan.ValueChanged += new System.EventHandler(this.cmbBoPhan_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Bộ phận";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày BĐ tính";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "đến ngày";
            // 
            // dtNgayBDTinh
            // 
            this.dtNgayBDTinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgayBDTinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayBDTinh.Location = new System.Drawing.Point(92, 77);
            this.dtNgayBDTinh.Name = "dtNgayBDTinh";
            this.dtNgayBDTinh.Size = new System.Drawing.Size(88, 20);
            this.dtNgayBDTinh.TabIndex = 15;
            // 
            // dtNgayKTTinh
            // 
            this.dtNgayKTTinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgayKTTinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayKTTinh.Location = new System.Drawing.Point(249, 78);
            this.dtNgayKTTinh.Name = "dtNgayKTTinh";
            this.dtNgayKTTinh.Size = new System.Drawing.Size(93, 20);
            this.dtNgayKTTinh.TabIndex = 15;
            this.dtNgayKTTinh.Value = new System.DateTime(2010, 11, 12, 0, 0, 0, 0);
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.AutoSize = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(92, 131);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(250, 22);
            this.cmbNhanVien.TabIndex = 16;
            this.cmbNhanVien.Value = null;
            // 
            // frmBangLuongNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 242);
            this.ControlBox = false;
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.dtNgayKTTinh);
            this.Controls.Add(this.dtNgayBDTinh);
            this.Controls.Add(this.cmbBoPhan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnTinhLuongDot2);
            this.Controls.Add(this.txtNgayThamNien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTinhLuongDot1);
            this.Controls.Add(this.txtDenNgay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbKyLuong);
            this.Controls.Add(this.txtTuNgay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBangLuongNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng tính lương";
            this.Load += new System.EventHandler(this.frmBangLuongNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayThamNien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnDong;
        private Infragistics.Win.Misc.UltraButton btnTinhLuongDot1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDenNgay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyLuong;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTuNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtNgayThamNien;
        private Infragistics.Win.Misc.UltraButton btnTinhLuongDot2;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbBoPhan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource boPhanListBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtNgayBDTinh;
        private System.Windows.Forms.DateTimePicker dtNgayKTTinh;
        private ComboboxNhanVien cmbNhanVien;

    }
}
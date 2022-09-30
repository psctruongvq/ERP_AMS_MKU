namespace PSC_ERP
{
    partial class frmDate
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            this.dateTimePicker_NgayLap = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPhanLoai = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbKieuNangLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLoaiNV = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbKieuNangLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker_NgayLap
            // 
            this.dateTimePicker_NgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_NgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_NgayLap.Location = new System.Drawing.Point(137, 38);
            this.dateTimePicker_NgayLap.Name = "dateTimePicker_NgayLap";
            this.dateTimePicker_NgayLap.Size = new System.Drawing.Size(145, 20);
            this.dateTimePicker_NgayLap.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Ngày Đến Hạn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 130);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 26);
            this.button1.TabIndex = 82;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPhanLoai
            // 
            this.lblPhanLoai.AutoSize = true;
            this.lblPhanLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanLoai.Location = new System.Drawing.Point(42, 72);
            this.lblPhanLoai.Name = "lblPhanLoai";
            this.lblPhanLoai.Size = new System.Drawing.Size(80, 13);
            this.lblPhanLoai.TabIndex = 84;
            this.lblPhanLoai.Text = "Loại Nhân Viên";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(218, 130);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 26);
            this.button2.TabIndex = 85;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbKieuNangLuong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker_NgayLap);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cmbLoaiNV);
            this.groupBox1.Controls.Add(this.lblPhanLoai);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 261);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            // 
            // cbKieuNangLuong
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Info;
            this.cbKieuNangLuong.Appearance = appearance1;
            this.cbKieuNangLuong.BackColor = System.Drawing.SystemColors.Info;
            this.cbKieuNangLuong.DisplayMember = "";
            this.cbKieuNangLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbKieuNangLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = 1;
            valueListItem1.DisplayText = "Lương && Lương BH";
            valueListItem2.DataValue = 2;
            valueListItem2.DisplayText = "Nâng Lương";
            valueListItem3.DataValue = 3;
            valueListItem3.DisplayText = "Nâng Lương Bảo Hiểm";
            this.cbKieuNangLuong.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cbKieuNangLuong.Location = new System.Drawing.Point(137, 91);
            this.cbKieuNangLuong.Name = "cbKieuNangLuong";
            this.cbKieuNangLuong.Size = new System.Drawing.Size(145, 21);
            this.cbKieuNangLuong.TabIndex = 87;
            this.cbKieuNangLuong.ValueMember = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Kiểu Nâng Lương";
            // 
            // cmbLoaiNV
            // 
            appearance2.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLoaiNV.Appearance = appearance2;
            this.cmbLoaiNV.BackColor = System.Drawing.SystemColors.Info;
            this.cmbLoaiNV.DisplayMember = "";
            this.cmbLoaiNV.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbLoaiNV.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "Biên chế và hợp đồng";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "Hợp đồng vụ việc";
            this.cmbLoaiNV.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5});
            this.cmbLoaiNV.Location = new System.Drawing.Point(137, 64);
            this.cmbLoaiNV.Name = "cmbLoaiNV";
            this.cmbLoaiNV.Size = new System.Drawing.Size(145, 21);
            this.cmbLoaiNV.TabIndex = 85;
            this.cmbLoaiNV.ValueMember = "";
            this.cmbLoaiNV.ValueChanged += new System.EventHandler(this.cmbLoaiNV_ValueChanged);
            // 
            // frmDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 279);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ngày Đến Hạn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbKieuNangLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_NgayLap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPhanLoai;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbLoaiNV;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbKieuNangLuong;
        private System.Windows.Forms.Label label1;
    }
}
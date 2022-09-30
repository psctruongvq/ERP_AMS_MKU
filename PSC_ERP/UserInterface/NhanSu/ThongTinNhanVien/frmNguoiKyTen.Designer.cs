namespace PSC_ERP.UserInterface.NhanSu.ThongTinNhanVien
{
    partial class frmNguoiKyTen
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
            this.grpNguoiLap = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtNguoiLap_Ten = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.bdData = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtNguoiLap_TieuDe = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtBPT_Ten = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBPT_TieuDe = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtThuTruong_Ten = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThuTruong_TieuDe = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDongY = new Infragistics.Win.Misc.UltraButton();
            this.btnKhong = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraTextEditor2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label8 = new System.Windows.Forms.Label();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label7 = new System.Windows.Forms.Label();
            this.ultraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraTextEditor3 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label9 = new System.Windows.Forms.Label();
            this.ultraTextEditor4 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label10 = new System.Windows.Forms.Label();
            this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraTextEditor5 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label11 = new System.Windows.Forms.Label();
            this.ultraTextEditor6 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grpNguoiLap)).BeginInit();
            this.grpNguoiLap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiLap_Ten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiLap_TieuDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBPT_Ten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBPT_TieuDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuTruong_Ten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuTruong_TieuDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
            this.ultraGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
            this.ultraGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor6)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNguoiLap
            // 
            this.grpNguoiLap.Controls.Add(this.txtNguoiLap_Ten);
            this.grpNguoiLap.Controls.Add(this.label2);
            this.grpNguoiLap.Controls.Add(this.txtNguoiLap_TieuDe);
            this.grpNguoiLap.Controls.Add(this.label1);
            this.grpNguoiLap.Location = new System.Drawing.Point(12, 12);
            this.grpNguoiLap.Name = "grpNguoiLap";
            this.grpNguoiLap.Size = new System.Drawing.Size(371, 80);
            this.grpNguoiLap.TabIndex = 0;
            this.grpNguoiLap.Text = "Người lập";
            // 
            // txtNguoiLap_Ten
            // 
            this.txtNguoiLap_Ten.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "NguoiLapTen", true));
            this.txtNguoiLap_Ten.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtNguoiLap_Ten.Location = new System.Drawing.Point(77, 46);
            this.txtNguoiLap_Ten.Name = "txtNguoiLap_Ten";
            this.txtNguoiLap_Ten.Size = new System.Drawing.Size(264, 21);
            this.txtNguoiLap_Ten.TabIndex = 3;
            // 
            // bdData
            // 
            this.bdData.DataSource = typeof(ERP_Library.NguoiKyTen);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Người ký";
            // 
            // txtNguoiLap_TieuDe
            // 
            this.txtNguoiLap_TieuDe.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "NguoiLapTieude", true));
            this.txtNguoiLap_TieuDe.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtNguoiLap_TieuDe.Location = new System.Drawing.Point(77, 19);
            this.txtNguoiLap_TieuDe.Name = "txtNguoiLap_TieuDe";
            this.txtNguoiLap_TieuDe.Size = new System.Drawing.Size(264, 21);
            this.txtNguoiLap_TieuDe.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiêu đề";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtBPT_Ten);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.txtBPT_TieuDe);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Location = new System.Drawing.Point(407, 12);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(371, 80);
            this.ultraGroupBox1.TabIndex = 4;
            this.ultraGroupBox1.Text = "Ban phụ trách";
            // 
            // txtBPT_Ten
            // 
            this.txtBPT_Ten.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "BptTen", true));
            this.txtBPT_Ten.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtBPT_Ten.Location = new System.Drawing.Point(77, 46);
            this.txtBPT_Ten.Name = "txtBPT_Ten";
            this.txtBPT_Ten.Size = new System.Drawing.Size(264, 21);
            this.txtBPT_Ten.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Người ký";
            // 
            // txtBPT_TieuDe
            // 
            this.txtBPT_TieuDe.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "BptTieude", true));
            this.txtBPT_TieuDe.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtBPT_TieuDe.Location = new System.Drawing.Point(77, 19);
            this.txtBPT_TieuDe.Name = "txtBPT_TieuDe";
            this.txtBPT_TieuDe.Size = new System.Drawing.Size(264, 21);
            this.txtBPT_TieuDe.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tiêu đề";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.txtThuTruong_Ten);
            this.ultraGroupBox2.Controls.Add(this.label5);
            this.ultraGroupBox2.Controls.Add(this.txtThuTruong_TieuDe);
            this.ultraGroupBox2.Controls.Add(this.label6);
            this.ultraGroupBox2.Location = new System.Drawing.Point(12, 102);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(371, 80);
            this.ultraGroupBox2.TabIndex = 5;
            this.ultraGroupBox2.Text = "Thủ trưởng / Kế toán trưởng";
            // 
            // txtThuTruong_Ten
            // 
            this.txtThuTruong_Ten.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "ThuTruongTen", true));
            this.txtThuTruong_Ten.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtThuTruong_Ten.Location = new System.Drawing.Point(77, 46);
            this.txtThuTruong_Ten.Name = "txtThuTruong_Ten";
            this.txtThuTruong_Ten.Size = new System.Drawing.Size(264, 21);
            this.txtThuTruong_Ten.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Người ký";
            // 
            // txtThuTruong_TieuDe
            // 
            this.txtThuTruong_TieuDe.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "ThuTruongTieude", true));
            this.txtThuTruong_TieuDe.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtThuTruong_TieuDe.Location = new System.Drawing.Point(77, 19);
            this.txtThuTruong_TieuDe.Name = "txtThuTruong_TieuDe";
            this.txtThuTruong_TieuDe.Size = new System.Drawing.Size(264, 21);
            this.txtThuTruong_TieuDe.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tiêu đề";
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(284, 298);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(94, 31);
            this.btnDongY.TabIndex = 6;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Location = new System.Drawing.Point(384, 298);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(94, 31);
            this.btnKhong.TabIndex = 7;
            this.btnKhong.Text = "Không";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.ultraTextEditor2);
            this.ultraGroupBox3.Controls.Add(this.label8);
            this.ultraGroupBox3.Controls.Add(this.ultraTextEditor1);
            this.ultraGroupBox3.Controls.Add(this.label7);
            this.ultraGroupBox3.Location = new System.Drawing.Point(407, 102);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(371, 80);
            this.ultraGroupBox3.TabIndex = 6;
            this.ultraGroupBox3.Text = "Tổng Giám Đốc /  Giám đốc đơn vị cấp II / Trưởng ban khoán chi";
            // 
            // ultraTextEditor2
            // 
            this.ultraTextEditor2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TenTongGiamDoc", true));
            this.ultraTextEditor2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraTextEditor2.Location = new System.Drawing.Point(77, 46);
            this.ultraTextEditor2.Name = "ultraTextEditor2";
            this.ultraTextEditor2.Size = new System.Drawing.Size(264, 21);
            this.ultraTextEditor2.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Tiêu đề";
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TieuDeTongGiamDoc", true));
            this.ultraTextEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraTextEditor1.Location = new System.Drawing.Point(77, 19);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(264, 21);
            this.ultraTextEditor1.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Người ký";
            // 
            // ultraGroupBox4
            // 
            this.ultraGroupBox4.Controls.Add(this.ultraTextEditor3);
            this.ultraGroupBox4.Controls.Add(this.label9);
            this.ultraGroupBox4.Controls.Add(this.ultraTextEditor4);
            this.ultraGroupBox4.Controls.Add(this.label10);
            this.ultraGroupBox4.Location = new System.Drawing.Point(12, 202);
            this.ultraGroupBox4.Name = "ultraGroupBox4";
            this.ultraGroupBox4.Size = new System.Drawing.Size(371, 80);
            this.ultraGroupBox4.TabIndex = 5;
            this.ultraGroupBox4.Text = "Thủ Quỹ";
            // 
            // ultraTextEditor3
            // 
            this.ultraTextEditor3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdData, "TenThuQuy", true));
            this.ultraTextEditor3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TenThuQuy", true));
            this.ultraTextEditor3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraTextEditor3.Location = new System.Drawing.Point(77, 46);
            this.ultraTextEditor3.Name = "ultraTextEditor3";
            this.ultraTextEditor3.Size = new System.Drawing.Size(264, 21);
            this.ultraTextEditor3.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Người ký";
            // 
            // ultraTextEditor4
            // 
            this.ultraTextEditor4.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TieuDeThuQuy", true));
            this.ultraTextEditor4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraTextEditor4.Location = new System.Drawing.Point(77, 19);
            this.ultraTextEditor4.Name = "ultraTextEditor4";
            this.ultraTextEditor4.Size = new System.Drawing.Size(264, 21);
            this.ultraTextEditor4.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tiêu đề";
            // 
            // ultraGroupBox5
            // 
            this.ultraGroupBox5.Controls.Add(this.ultraTextEditor5);
            this.ultraGroupBox5.Controls.Add(this.label11);
            this.ultraGroupBox5.Controls.Add(this.ultraTextEditor6);
            this.ultraGroupBox5.Controls.Add(this.label12);
            this.ultraGroupBox5.Location = new System.Drawing.Point(407, 202);
            this.ultraGroupBox5.Name = "ultraGroupBox5";
            this.ultraGroupBox5.Size = new System.Drawing.Size(371, 80);
            this.ultraGroupBox5.TabIndex = 6;
            this.ultraGroupBox5.Text = "Chủ Tịch Công Đoàn";
            // 
            // ultraTextEditor5
            // 
            this.ultraTextEditor5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdData, "TenChuTichCD", true));
            this.ultraTextEditor5.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TenChuTichCD", true));
            this.ultraTextEditor5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraTextEditor5.Location = new System.Drawing.Point(77, 46);
            this.ultraTextEditor5.Name = "ultraTextEditor5";
            this.ultraTextEditor5.Size = new System.Drawing.Size(264, 21);
            this.ultraTextEditor5.TabIndex = 5;
            this.ultraTextEditor5.Text = "Trương Bá Hùng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Tiêu đề";
            // 
            // ultraTextEditor6
            // 
            this.ultraTextEditor6.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TieuDeChuTichCD", true));
            this.ultraTextEditor6.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraTextEditor6.Location = new System.Drawing.Point(77, 19);
            this.ultraTextEditor6.Name = "ultraTextEditor6";
            this.ultraTextEditor6.Size = new System.Drawing.Size(264, 21);
            this.ultraTextEditor6.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Người ký";
            // 
            // frmNguoiKyTen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 346);
            this.ControlBox = false;
            this.Controls.Add(this.ultraGroupBox5);
            this.Controls.Add(this.ultraGroupBox3);
            this.Controls.Add(this.btnKhong);
            this.Controls.Add(this.ultraGroupBox4);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.grpNguoiLap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNguoiKyTen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt người ký tên báo cáo";
            this.Load += new System.EventHandler(this.frmNguoiKyTen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpNguoiLap)).EndInit();
            this.grpNguoiLap.ResumeLayout(false);
            this.grpNguoiLap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiLap_Ten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiLap_TieuDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBPT_Ten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBPT_TieuDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuTruong_Ten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuTruong_TieuDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ultraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
            this.ultraGroupBox4.ResumeLayout(false);
            this.ultraGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
            this.ultraGroupBox5.ResumeLayout(false);
            this.ultraGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox grpNguoiLap;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNguoiLap_TieuDe;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNguoiLap_Ten;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBPT_Ten;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBPT_TieuDe;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtThuTruong_Ten;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtThuTruong_TieuDe;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.Misc.UltraButton btnDongY;
        private Infragistics.Win.Misc.UltraButton btnKhong;
        private System.Windows.Forms.BindingSource bdData;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor2;
        private System.Windows.Forms.Label label8;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        private System.Windows.Forms.Label label7;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor3;
        private System.Windows.Forms.Label label9;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor4;
        private System.Windows.Forms.Label label10;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor5;
        private System.Windows.Forms.Label label11;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor6;
        private System.Windows.Forms.Label label12;
        
    }
}
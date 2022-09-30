namespace PSC_ERP
{
    partial class FrmBangPhanBoGTGT
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtmp_NgayLap = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.Binds_PhanboGTGT = new System.Windows.Forms.BindingSource(this.components);
            this.label71 = new System.Windows.Forms.Label();
            this.txt_C30 = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.label52 = new System.Windows.Forms.Label();
            this.txt_C29 = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.label49 = new System.Windows.Forms.Label();
            this.txt_tyle = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.label46 = new System.Windows.Forms.Label();
            this.txt_banchiuthue = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.label43 = new System.Windows.Forms.Label();
            this.txt_tongban = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.label40 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtmp_NgayLap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Binds_PhanboGTGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_C30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_C29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_banchiuthue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tongban)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtmp_NgayLap);
            this.groupBox1.Controls.Add(this.label71);
            this.groupBox1.Controls.Add(this.txt_C30);
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.txt_C29);
            this.groupBox1.Controls.Add(this.label49);
            this.groupBox1.Controls.Add(this.txt_tyle);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.txt_banchiuthue);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.txt_tongban);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 199);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin bàng phân bổ số thuế GTGT";
            // 
            // dtmp_NgayLap
            // 
            this.dtmp_NgayLap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtmp_NgayLap.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Binds_PhanboGTGT, "NgayLap", true));
            this.dtmp_NgayLap.DateTime = new System.DateTime(2009, 7, 23, 0, 0, 0, 0);
            this.dtmp_NgayLap.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dtmp_NgayLap.FormatString = "";
            this.dtmp_NgayLap.Location = new System.Drawing.Point(355, 168);
            this.dtmp_NgayLap.MaskInput = "{LOC}dd/mm/yyyy";
            this.dtmp_NgayLap.Name = "dtmp_NgayLap";
            this.dtmp_NgayLap.Size = new System.Drawing.Size(142, 21);
            this.dtmp_NgayLap.TabIndex = 138;
            this.dtmp_NgayLap.Value = new System.DateTime(2009, 7, 23, 0, 0, 0, 0);
            // 
            // Binds_PhanboGTGT
            // 
            this.Binds_PhanboGTGT.DataSource = typeof(ERP_Library.PhanBoGTGTList);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.Color.Transparent;
            this.label71.Location = new System.Drawing.Point(296, 172);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(53, 13);
            this.label71.TabIndex = 137;
            this.label71.Text = "Ngày Lập";
            // 
            // txt_C30
            // 
            this.txt_C30.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Binds_PhanboGTGT, "C5", true));
            this.txt_C30.Location = new System.Drawing.Point(355, 126);
            this.txt_C30.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn";
            this.txt_C30.Name = "txt_C30";
            this.txt_C30.PromptChar = ' ';
            this.txt_C30.Size = new System.Drawing.Size(142, 21);
            this.txt_C30.TabIndex = 104;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Location = new System.Drawing.Point(15, 130);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(287, 13);
            this.label52.TabIndex = 103;
            this.label52.Text = "5. Thuế GTGT của HHDV mua vào được khấu trừ trong kỳ";
            // 
            // txt_C29
            // 
            this.txt_C29.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Binds_PhanboGTGT, "C4", true));
            this.txt_C29.Location = new System.Drawing.Point(355, 102);
            this.txt_C29.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn";
            this.txt_C29.Name = "txt_C29";
            this.txt_C29.PromptChar = ' ';
            this.txt_C29.Size = new System.Drawing.Size(142, 21);
            this.txt_C29.TabIndex = 102;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Location = new System.Drawing.Point(15, 106);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(217, 13);
            this.label49.TabIndex = 101;
            this.label49.Text = "4. Thuế GTGT của HHDV mua vào trong kỳ";
            // 
            // txt_tyle
            // 
            this.txt_tyle.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Binds_PhanboGTGT, "C3", true));
            this.txt_tyle.Location = new System.Drawing.Point(355, 75);
            this.txt_tyle.MaskInput = "{LOC}nnn.nnnn";
            this.txt_tyle.Name = "txt_tyle";
            this.txt_tyle.PromptChar = ' ';
            this.txt_tyle.Size = new System.Drawing.Size(142, 21);
            this.txt_tyle.TabIndex = 100;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Location = new System.Drawing.Point(15, 72);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(312, 29);
            this.label46.TabIndex = 99;
            this.label46.Text = "3.Tỷ lệ (%) doanh thu HHDV bán ra chịu thuế trên tổng doanh thu của kỳ kê khai (3" +
                ")=(2)/(1)";
            // 
            // txt_banchiuthue
            // 
            this.txt_banchiuthue.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Binds_PhanboGTGT, "C2", true));
            this.txt_banchiuthue.Location = new System.Drawing.Point(355, 48);
            this.txt_banchiuthue.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn";
            this.txt_banchiuthue.Name = "txt_banchiuthue";
            this.txt_banchiuthue.PromptChar = ' ';
            this.txt_banchiuthue.Size = new System.Drawing.Size(142, 21);
            this.txt_banchiuthue.TabIndex = 98;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Location = new System.Drawing.Point(15, 52);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(224, 13);
            this.label43.TabIndex = 97;
            this.label43.Text = "2. Doanh thu HHDV bán ra chịu thuế trong kỳ";
            // 
            // txt_tongban
            // 
            this.txt_tongban.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.Binds_PhanboGTGT, "C1", true));
            this.txt_tongban.Location = new System.Drawing.Point(355, 24);
            this.txt_tongban.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn";
            this.txt_tongban.Name = "txt_tongban";
            this.txt_tongban.PromptChar = ' ';
            this.txt_tongban.Size = new System.Drawing.Size(142, 21);
            this.txt_tongban.TabIndex = 96;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Location = new System.Drawing.Point(15, 28);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(258, 13);
            this.label40.TabIndex = 95;
            this.label40.Text = "1. Tổng doanh thu hàng hóa, dịch vụ bán ra trong kỳ";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(235, 222);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 142;
            this.btnIn.Text = "&In Mẫu";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnthoat.Location = new System.Drawing.Point(354, 222);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(75, 23);
            this.btnthoat.TabIndex = 141;
            this.btnthoat.Text = "&Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(108, 222);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 140;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FrmBangPhanBoGTGT
            // 
            this.AcceptButton = this.btnLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnthoat;
            this.ClientSize = new System.Drawing.Size(544, 258);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmBangPhanBoGTGT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng phân bổ số thuế GTGT";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtmp_NgayLap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Binds_PhanboGTGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_C30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_C29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_banchiuthue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tongban)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinEditors.UltraCurrencyEditor txt_C30;
        private System.Windows.Forms.Label label52;
        private Infragistics.Win.UltraWinEditors.UltraCurrencyEditor txt_C29;
        private System.Windows.Forms.Label label49;
        private Infragistics.Win.UltraWinEditors.UltraCurrencyEditor txt_tyle;
        private System.Windows.Forms.Label label46;
        private Infragistics.Win.UltraWinEditors.UltraCurrencyEditor txt_banchiuthue;
        private System.Windows.Forms.Label label43;
        private Infragistics.Win.UltraWinEditors.UltraCurrencyEditor txt_tongban;
        private System.Windows.Forms.Label label40;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtmp_NgayLap;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.BindingSource Binds_PhanboGTGT;
    }
}
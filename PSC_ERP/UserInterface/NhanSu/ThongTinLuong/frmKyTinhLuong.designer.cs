
namespace PSC_ERP
{
    partial class frmKyTinhLuong
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKyTinhLuong));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KyTinhLuong", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenKy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayBatDau");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKetThuc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Thang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nam");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DungChung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSoKy1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSoKy2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSoKy3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoNgay");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TruThueTNCN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKhoaThuLao");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKyChinh");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_Nam = new System.Windows.Forms.MaskedTextBox();
            this.kyTinhLuongListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbMaKyChinh = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ultraDateTimeEditor1 = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.chkKhoaKy3 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ulbSoNgay = new Infragistics.Win.Misc.UltraLabel();
            this.tbNgay = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.numUp_Thang = new System.Windows.Forms.NumericUpDown();
            this.dtp_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtp_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TenKy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.grdu_KyTinhLuong = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tlslblExportExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kyTinhLuongListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMaKyChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUp_Thang)).BeginInit();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_KyTinhLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kỳ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBox_Nam);
            this.groupBox1.Controls.Add(this.cmbMaKyChinh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ultraDateTimeEditor1);
            this.groupBox1.Controls.Add(this.chkKhoaKy3);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.ulbSoNgay);
            this.groupBox1.Controls.Add(this.tbNgay);
            this.groupBox1.Controls.Add(this.numUp_Thang);
            this.groupBox1.Controls.Add(this.dtp_DenNgay);
            this.groupBox1.Controls.Add(this.dtp_TuNgay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_TenKy);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(928, 117);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin kỳ";
            // 
            // maskedTextBox_Nam
            // 
            this.maskedTextBox_Nam.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.kyTinhLuongListBindingSource, "Nam", true));
            this.maskedTextBox_Nam.Location = new System.Drawing.Point(458, 19);
            this.maskedTextBox_Nam.Mask = "0000";
            this.maskedTextBox_Nam.Name = "maskedTextBox_Nam";
            this.maskedTextBox_Nam.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBox_Nam.TabIndex = 23;
            // 
            // kyTinhLuongListBindingSource
            // 
            this.kyTinhLuongListBindingSource.AllowNew = true;
            this.kyTinhLuongListBindingSource.DataSource = typeof(ERP_Library.KyTinhLuongList);
            // 
            // cmbMaKyChinh
            // 
            this.cmbMaKyChinh.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kyTinhLuongListBindingSource, "MaKyChinh", true));
            this.cmbMaKyChinh.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbMaKyChinh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem1.DataValue = "ValueListItem0";
            this.cmbMaKyChinh.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1});
            this.cmbMaKyChinh.Location = new System.Drawing.Point(225, 86);
            this.cmbMaKyChinh.Name = "cmbMaKyChinh";
            this.cmbMaKyChinh.Size = new System.Drawing.Size(248, 21);
            this.cmbMaKyChinh.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 14);
            this.label7.TabIndex = 21;
            this.label7.Text = "Tháng lương 3 của Tháng lương";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(678, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ngày khóa thù lao";
            // 
            // ultraDateTimeEditor1
            // 
            this.ultraDateTimeEditor1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kyTinhLuongListBindingSource, "NgayKhoaThuLao", true));
            this.ultraDateTimeEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraDateTimeEditor1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraDateTimeEditor1.Location = new System.Drawing.Point(778, 20);
            this.ultraDateTimeEditor1.Name = "ultraDateTimeEditor1";
            this.ultraDateTimeEditor1.Size = new System.Drawing.Size(105, 21);
            this.ultraDateTimeEditor1.TabIndex = 15;
            // 
            // chkKhoaKy3
            // 
            this.chkKhoaKy3.AutoSize = true;
            this.chkKhoaKy3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.kyTinhLuongListBindingSource, "KhoaSoKy3", true));
            this.chkKhoaKy3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKhoaKy3.Location = new System.Drawing.Point(732, 60);
            this.chkKhoaKy3.Name = "chkKhoaKy3";
            this.chkKhoaKy3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkKhoaKy3.Size = new System.Drawing.Size(89, 18);
            this.chkKhoaKy3.TabIndex = 12;
            this.chkKhoaKy3.Text = "Khóa sổ kỳ 3";
            this.chkKhoaKy3.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.kyTinhLuongListBindingSource, "TruThueTNCN", true));
            this.checkBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(608, 60);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox3.Size = new System.Drawing.Size(97, 18);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "Trừ thuế TNCN";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.kyTinhLuongListBindingSource, "KhoaSoKy2", true));
            this.checkBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(513, 59);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox2.Size = new System.Drawing.Size(89, 18);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Khóa sổ kỳ 2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.kyTinhLuongListBindingSource, "KhoaSoKy1", true));
            this.checkBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(417, 59);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(89, 18);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Khóa sổ kỳ 1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ulbSoNgay
            // 
            this.ulbSoNgay.Location = new System.Drawing.Point(532, 24);
            this.ulbSoNgay.Name = "ulbSoNgay";
            this.ulbSoNgay.Size = new System.Drawing.Size(70, 17);
            this.ulbSoNgay.TabIndex = 18;
            this.ulbSoNgay.Text = "Số Ngày LV";
            // 
            // tbNgay
            // 
            this.tbNgay.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kyTinhLuongListBindingSource, "SoNgay", true));
            this.tbNgay.Location = new System.Drawing.Point(608, 19);
            this.tbNgay.MaskInput = "nn";
            this.tbNgay.Name = "tbNgay";
            this.tbNgay.PromptChar = ' ';
            this.tbNgay.Size = new System.Drawing.Size(48, 21);
            this.tbNgay.TabIndex = 17;
            // 
            // numUp_Thang
            // 
            this.numUp_Thang.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kyTinhLuongListBindingSource, "Thang", true));
            this.numUp_Thang.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUp_Thang.Location = new System.Drawing.Point(293, 19);
            this.numUp_Thang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numUp_Thang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUp_Thang.Name = "numUp_Thang";
            this.numUp_Thang.Size = new System.Drawing.Size(106, 20);
            this.numUp_Thang.TabIndex = 3;
            this.numUp_Thang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtp_DenNgay
            // 
            this.dtp_DenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtp_DenNgay.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kyTinhLuongListBindingSource, "NgayKetThuc", true));
            this.dtp_DenNgay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DenNgay.Location = new System.Drawing.Point(293, 56);
            this.dtp_DenNgay.Name = "dtp_DenNgay";
            this.dtp_DenNgay.Size = new System.Drawing.Size(106, 20);
            this.dtp_DenNgay.TabIndex = 9;
            // 
            // dtp_TuNgay
            // 
            this.dtp_TuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtp_TuNgay.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.kyTinhLuongListBindingSource, "NgayBatDau", true));
            this.dtp_TuNgay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TuNgay.Location = new System.Drawing.Point(78, 56);
            this.dtp_TuNgay.Name = "dtp_TuNgay";
            this.dtp_TuNgay.Size = new System.Drawing.Size(126, 20);
            this.dtp_TuNgay.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(222, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Đến Ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Từ Ngày";
            // 
            // txt_TenKy
            // 
            this.txt_TenKy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.kyTinhLuongListBindingSource, "TenKy", true));
            this.txt_TenKy.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenKy.Location = new System.Drawing.Point(78, 19);
            this.txt_TenKy.Name = "txt_TenKy";
            this.txt_TenKy.Size = new System.Drawing.Size(126, 20);
            this.txt_TenKy.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(424, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Năm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(222, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tháng ";
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblThem,
            this.toolStripSeparator1,
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblXoa,
            this.toolStripSeparator3,
            this.tlslblUndo,
            this.toolStripSeparator4,
            this.tlslblExportExcel,
            this.toolStripSeparator6,
            this.tlslblIn,
            this.toolStripButton1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(935, 25);
            this.tlsMain.TabIndex = 0;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblThem
            // 
            this.tlslblThem.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThem.Image")));
            this.tlslblThem.Name = "tlslblThem";
            this.tlslblThem.Size = new System.Drawing.Size(58, 22);
            this.tlslblThem.Text = "Thêm";
            this.tlslblThem.Click += new System.EventHandler(this.thêmToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(47, 22);
            this.tlslblLuu.Text = "Lưu";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblXoa
            // 
            this.tlslblXoa.Image = ((System.Drawing.Image)(resources.GetObject("tlslblXoa.Image")));
            this.tlslblXoa.Name = "tlslblXoa";
            this.tlslblXoa.Size = new System.Drawing.Size(47, 22);
            this.tlslblXoa.Text = "Xóa";
            this.tlslblXoa.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(56, 22);
            this.tlslblUndo.Text = "Undo";
            this.tlslblUndo.Click += new System.EventHandler(this.tlslblUndo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblIn
            // 
            this.tlslblIn.Image = ((System.Drawing.Image)(resources.GetObject("tlslblIn.Image")));
            this.tlslblIn.Name = "tlslblIn";
            this.tlslblIn.Size = new System.Drawing.Size(37, 22);
            this.tlslblIn.Text = "In";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(73, 22);
            this.tlslblTroGiup.Text = "Trợ Giúp";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblThoat
            // 
            this.tlslblThoat.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThoat.Image")));
            this.tlslblThoat.Name = "tlslblThoat";
            this.tlslblThoat.Size = new System.Drawing.Size(58, 22);
            this.tlslblThoat.Text = "Thoát";
            this.tlslblThoat.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(550, 80);
            this.ultraGrid1.TabIndex = 0;
            // 
            // grdu_KyTinhLuong
            // 
            this.grdu_KyTinhLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdu_KyTinhLuong.DataSource = this.kyTinhLuongListBindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            this.grdu_KyTinhLuong.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 5;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Caption = "Tên Kỳ";
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.Width = 148;
            ultraGridColumn3.Header.Caption = "Ngày Bắt Đầu";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Width = 92;
            ultraGridColumn4.Header.Caption = "Ngày kết thúc";
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.Width = 86;
            ultraGridColumn5.Header.Caption = "Tháng";
            ultraGridColumn5.Header.VisiblePosition = 7;
            ultraGridColumn5.Width = 48;
            ultraGridColumn6.Header.Caption = "Khóa Sổ";
            ultraGridColumn6.Header.VisiblePosition = 9;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.Width = 64;
            ultraGridColumn7.Header.Caption = "Năm";
            ultraGridColumn7.Header.VisiblePosition = 8;
            ultraGridColumn7.Width = 45;
            ultraGridColumn8.Header.Caption = "Dùng Từng Bộ Phận";
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.Caption = "Khóa sổ kỳ 1";
            ultraGridColumn9.Header.VisiblePosition = 10;
            ultraGridColumn9.Width = 94;
            ultraGridColumn10.Header.Caption = "Khóa sổ kỳ 2";
            ultraGridColumn10.Header.VisiblePosition = 11;
            ultraGridColumn10.Width = 98;
            ultraGridColumn11.Header.Caption = "Khóa sổ kỳ 3";
            ultraGridColumn11.Header.VisiblePosition = 12;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.Width = 93;
            ultraGridColumn12.Header.Caption = "Số ngày";
            ultraGridColumn12.Header.VisiblePosition = 6;
            ultraGridColumn12.Width = 68;
            ultraGridColumn13.Header.Caption = "Trừ thuế TNCN";
            ultraGridColumn13.Header.VisiblePosition = 13;
            ultraGridColumn13.Width = 109;
            ultraGridColumn14.Header.VisiblePosition = 4;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15});
            this.grdu_KyTinhLuong.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdu_KyTinhLuong.DisplayLayout.GroupByBox.Hidden = true;
            this.grdu_KyTinhLuong.DisplayLayout.MaxColScrollRegions = 1;
            this.grdu_KyTinhLuong.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdu_KyTinhLuong.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.grdu_KyTinhLuong.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "Arial";
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdu_KyTinhLuong.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.grdu_KyTinhLuong.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdu_KyTinhLuong.DisplayLayout.Override.RowSelectorAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdu_KyTinhLuong.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.grdu_KyTinhLuong.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdu_KyTinhLuong.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdu_KyTinhLuong.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdu_KyTinhLuong.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdu_KyTinhLuong.Location = new System.Drawing.Point(4, 150);
            this.grdu_KyTinhLuong.Name = "grdu_KyTinhLuong";
            this.grdu_KyTinhLuong.Size = new System.Drawing.Size(928, 302);
            this.grdu_KyTinhLuong.TabIndex = 2;
            this.grdu_KyTinhLuong.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdu_KyTinhLuong_InitializeLayout);
            this.grdu_KyTinhLuong.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdu_KyTinhLuong_DoubleClickRow);
            // 
            // tlslblExportExcel
            // 
            this.tlslblExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("tlslblExportExcel.Image")));
            this.tlslblExportExcel.Name = "tlslblExportExcel";
            this.tlslblExportExcel.Size = new System.Drawing.Size(80, 22);
            this.tlslblExportExcel.Text = "&Xuất Excel";
            this.tlslblExportExcel.Click += new System.EventHandler(this.tlslblExportExcel_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // frmKyTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 464);
            this.Controls.Add(this.grdu_KyTinhLuong);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKyTinhLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kỳ Tính Lương";
            this.Load += new System.EventHandler(this.frmKyTinhLuong_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kyTinhLuongListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMaKyChinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDateTimeEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUp_Thang)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_KyTinhLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TenKy;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblThem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_KyTinhLuong;
        private System.Windows.Forms.DateTimePicker dtp_DenNgay;
        private System.Windows.Forms.DateTimePicker dtp_TuNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource kyTinhLuongListBindingSource;
        private System.Windows.Forms.NumericUpDown numUp_Thang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
      //  private System.Windows.Forms.Label lbSoNgay;
        //  private System.Windows.Forms.Label lbSoCong;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor tbNgay;
        private Infragistics.Win.Misc.UltraLabel ulbSoNgay;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkKhoaKy3;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ultraDateTimeEditor1;
        private System.Windows.Forms.Label label7;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbMaKyChinh;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Nam;
        private System.Windows.Forms.ToolStripButton tlslblExportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}

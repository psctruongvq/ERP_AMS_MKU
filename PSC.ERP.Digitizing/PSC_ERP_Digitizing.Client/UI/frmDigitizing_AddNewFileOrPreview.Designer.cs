namespace PSC_ERP_Digitizing.Client.UI
{
    partial class frmDigitizing_AddNewFileOrPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDigitizing_AddNewFileOrPreview));
            this.txtDocumentName = new DevExpress.XtraEditors.TextEdit();
            this.digitizingBagBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.lblFilePath = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.chkIndexed = new DevExpress.XtraEditors.CheckEdit();
            this.chkUploaded = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbBoPhan = new DevExpress.XtraEditors.GridLookUpEdit();
            this.tblnsBoPhanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaBoPhanQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenBoPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbChungTu = new DevExpress.XtraEditors.GridLookUpEdit();
            this.chungTuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoChungTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayChungTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbLoaiChungTu = new DevExpress.XtraEditors.GridLookUpEdit();
            this.documentTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupControlChonVaTaiLen = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitizingBagBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIndexed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUploaded.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBoPhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblnsBoPhanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChungTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chungTuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiChungTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlChonVaTaiLen)).BeginInit();
            this.groupControlChonVaTaiLen.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.digitizingBagBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDocumentName.Location = new System.Drawing.Point(126, 24);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.Size = new System.Drawing.Size(672, 20);
            this.txtDocumentName.TabIndex = 0;
            // 
            // digitizingBagBindingSource
            // 
            this.digitizingBagBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.DigitizingBag);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tên tài liệu:";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(124, 24);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(674, 18);
            this.progressBarControl1.TabIndex = 2;
            // 
            // btnUpload
            // 
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.Location = new System.Drawing.Point(362, 56);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(121, 31);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Chọn file && Tải lên";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.Location = new System.Drawing.Point(124, 48);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(79, 13);
            this.lblFilePath.TabIndex = 1;
            this.lblFilePath.Text = "[Đường đẫn file]";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Tiến trình:";
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(12, -28);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 5;
            this.txtBlackHole.TabStop = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.chkIndexed);
            this.groupControl2.Controls.Add(this.chkUploaded);
            this.groupControl2.Controls.Add(this.groupControl1);
            this.groupControl2.Controls.Add(this.txtDocumentName);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(812, 160);
            this.groupControl2.TabIndex = 13;
            this.groupControl2.Text = "Thông tin tài liệu";
            // 
            // chkIndexed
            // 
            this.chkIndexed.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.digitizingBagBindingSource, "FileIndexed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkIndexed.Location = new System.Drawing.Point(229, 45);
            this.chkIndexed.Name = "chkIndexed";
            this.chkIndexed.Properties.Caption = "Đã đánh chỉ mục tìm kiếm";
            this.chkIndexed.Properties.ReadOnly = true;
            this.chkIndexed.Size = new System.Drawing.Size(148, 19);
            this.chkIndexed.TabIndex = 15;
            // 
            // chkUploaded
            // 
            this.chkUploaded.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.digitizingBagBindingSource, "FileUploadCompleted", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkUploaded.Location = new System.Drawing.Point(124, 45);
            this.chkUploaded.Name = "chkUploaded";
            this.chkUploaded.Properties.Caption = "Đã tải lên";
            this.chkUploaded.Properties.ReadOnly = true;
            this.chkUploaded.Size = new System.Drawing.Size(75, 19);
            this.chkUploaded.TabIndex = 15;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cbBoPhan);
            this.groupControl1.Controls.Add(this.cbChungTu);
            this.groupControl1.Controls.Add(this.cbLoaiChungTu);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(2, 65);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(808, 93);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "Gắn vô chứng từ";
            // 
            // cbBoPhan
            // 
            this.cbBoPhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBoPhan.EditValue = 0;
            this.cbBoPhan.Location = new System.Drawing.Point(124, 24);
            this.cbBoPhan.Name = "cbBoPhan";
            this.cbBoPhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBoPhan.Properties.DataSource = this.tblnsBoPhanBindingSource;
            this.cbBoPhan.Properties.DisplayMember = "TenBoPhan";
            this.cbBoPhan.Properties.NullText = "<<Tất cả>>";
            this.cbBoPhan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbBoPhan.Properties.ValueMember = "MaBoPhan";
            this.cbBoPhan.Properties.View = this.gridLookUpEdit1View;
            this.cbBoPhan.Size = new System.Drawing.Size(672, 20);
            this.cbBoPhan.TabIndex = 6;
            // 
            // tblnsBoPhanBindingSource
            // 
            this.tblnsBoPhanBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblnsBoPhan);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaBoPhanQL,
            this.colTenBoPhan});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colMaBoPhanQL
            // 
            this.colMaBoPhanQL.Caption = "Mã";
            this.colMaBoPhanQL.FieldName = "MaBoPhanQL";
            this.colMaBoPhanQL.Name = "colMaBoPhanQL";
            this.colMaBoPhanQL.OptionsColumn.ReadOnly = true;
            this.colMaBoPhanQL.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaBoPhanQL.Visible = true;
            this.colMaBoPhanQL.VisibleIndex = 0;
            // 
            // colTenBoPhan
            // 
            this.colTenBoPhan.Caption = "Tên";
            this.colTenBoPhan.FieldName = "TenBoPhan";
            this.colTenBoPhan.Name = "colTenBoPhan";
            this.colTenBoPhan.OptionsColumn.ReadOnly = true;
            this.colTenBoPhan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenBoPhan.Visible = true;
            this.colTenBoPhan.VisibleIndex = 1;
            // 
            // cbChungTu
            // 
            this.cbChungTu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbChungTu.Location = new System.Drawing.Point(124, 68);
            this.cbChungTu.Name = "cbChungTu";
            this.cbChungTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbChungTu.Properties.DataSource = this.chungTuBindingSource;
            this.cbChungTu.Properties.DisplayMember = "SoChungTu";
            this.cbChungTu.Properties.NullText = "<<Không chọn>>";
            this.cbChungTu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbChungTu.Properties.ValueMember = "Id";
            this.cbChungTu.Properties.View = this.gridView2;
            this.cbChungTu.Size = new System.Drawing.Size(672, 20);
            this.cbChungTu.TabIndex = 10;
            // 
            // chungTuBindingSource
            // 
            this.chungTuBindingSource.DataSource = typeof(PSC_ERP_Digitizing.Client.Model.ChungTu);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoChungTu,
            this.colNgayChungTu});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colSoChungTu
            // 
            this.colSoChungTu.Caption = "Số";
            this.colSoChungTu.FieldName = "SoChungTu";
            this.colSoChungTu.Name = "colSoChungTu";
            this.colSoChungTu.OptionsColumn.ReadOnly = true;
            this.colSoChungTu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoChungTu.Visible = true;
            this.colSoChungTu.VisibleIndex = 0;
            // 
            // colNgayChungTu
            // 
            this.colNgayChungTu.Caption = "Ngày";
            this.colNgayChungTu.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayChungTu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayChungTu.FieldName = "NgayChungTu";
            this.colNgayChungTu.Name = "colNgayChungTu";
            this.colNgayChungTu.OptionsColumn.ReadOnly = true;
            this.colNgayChungTu.Visible = true;
            this.colNgayChungTu.VisibleIndex = 1;
            // 
            // cbLoaiChungTu
            // 
            this.cbLoaiChungTu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLoaiChungTu.EditValue = 0;
            this.cbLoaiChungTu.Location = new System.Drawing.Point(124, 46);
            this.cbLoaiChungTu.Name = "cbLoaiChungTu";
            this.cbLoaiChungTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLoaiChungTu.Properties.DataSource = this.documentTypeBindingSource;
            this.cbLoaiChungTu.Properties.DisplayMember = "Name";
            this.cbLoaiChungTu.Properties.NullText = "<<Tất cả>>";
            this.cbLoaiChungTu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbLoaiChungTu.Properties.ValueMember = "Id";
            this.cbLoaiChungTu.Properties.View = this.gridView1;
            this.cbLoaiChungTu.Size = new System.Drawing.Size(672, 20);
            this.cbLoaiChungTu.TabIndex = 7;
            // 
            // documentTypeBindingSource
            // 
            this.documentTypeBindingSource.DataSource = typeof(PSC_ERP_Digitizing.Client.Predefined.DocumentType);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName1});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colName1
            // 
            this.colName1.Caption = "Tên";
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.OptionsColumn.ReadOnly = true;
            this.colName1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 0;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 75);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(91, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Chứng từ cần gắn:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Lọc bộ phận:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 49);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(86, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Lọc loại chứng từ:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 46);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(53, 13);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "Tình trạng:";
            // 
            // groupControlChonVaTaiLen
            // 
            this.groupControlChonVaTaiLen.Controls.Add(this.progressBarControl1);
            this.groupControlChonVaTaiLen.Controls.Add(this.lblFilePath);
            this.groupControlChonVaTaiLen.Controls.Add(this.labelControl3);
            this.groupControlChonVaTaiLen.Controls.Add(this.btnUpload);
            this.groupControlChonVaTaiLen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlChonVaTaiLen.Location = new System.Drawing.Point(0, 160);
            this.groupControlChonVaTaiLen.Name = "groupControlChonVaTaiLen";
            this.groupControlChonVaTaiLen.Size = new System.Drawing.Size(812, 92);
            this.groupControlChonVaTaiLen.TabIndex = 14;
            this.groupControlChonVaTaiLen.Text = "Chọn file && tải lên";
            // 
            // frmDigitizing_AddNewFileOrPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 252);
            this.Controls.Add(this.groupControlChonVaTaiLen);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.txtBlackHole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDigitizing_AddNewFileOrPreview";
            this.Text = "Thông tin file tải lên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDigitizing_AddNewFileOrPreview_FormClosing);
            this.Load += new System.EventHandler(this.frmDigitizing_AddNewFileOrPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitizingBagBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIndexed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUploaded.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBoPhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblnsBoPhanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChungTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chungTuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiChungTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlChonVaTaiLen)).EndInit();
            this.groupControlChonVaTaiLen.ResumeLayout(false);
            this.groupControlChonVaTaiLen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDocumentName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
        private DevExpress.XtraEditors.LabelControl lblFilePath;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.BindingSource digitizingBagBindingSource;
        private System.Windows.Forms.TextBox txtBlackHole;
        private System.Windows.Forms.BindingSource tblnsBoPhanBindingSource;
        private System.Windows.Forms.BindingSource documentTypeBindingSource;
        private System.Windows.Forms.BindingSource chungTuBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControlChonVaTaiLen;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GridLookUpEdit cbBoPhan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colMaBoPhanQL;
        private DevExpress.XtraGrid.Columns.GridColumn colTenBoPhan;
        private DevExpress.XtraEditors.GridLookUpEdit cbChungTu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colSoChungTu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayChungTu;
        private DevExpress.XtraEditors.GridLookUpEdit cbLoaiChungTu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit chkUploaded;
        private DevExpress.XtraEditors.CheckEdit chkIndexed;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
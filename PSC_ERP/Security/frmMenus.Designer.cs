namespace PSC_ERP.Security
{
    partial class frmMenus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenus));
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn1 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn2 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn3 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn4 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.UltraWinTree.UltraTreeNodeColumn ultraTreeNodeColumn5 = new Infragistics.Win.UltraWinTree.UltraTreeNodeColumn();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.itThem = new System.Windows.Forms.ToolStripButton();
            this.itSua = new System.Windows.Forms.ToolStripButton();
            this.itXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itSave = new System.Windows.Forms.ToolStripButton();
            this.itIDAuto = new System.Windows.Forms.ToolStripButton();
            this.itSort = new System.Windows.Forms.ToolStripButton();
            this.itUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.itDong = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTen = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.bdData = new System.Windows.Forms.BindingSource(this.components);
            this.txtMa = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.cmbParentID = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.treeMenus = new Infragistics.Win.UltraWinTree.UltraTree();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.txtSTT = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAn = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTenForm = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label7 = new System.Windows.Forms.Label();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.toolMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParentID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTenForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolMain
            // 
            this.toolMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itThem,
            this.itSua,
            this.itXoa,
            this.toolStripSeparator1,
            this.itSave,
            this.itIDAuto,
            this.itSort,
            this.itUndo,
            this.toolStripSeparator2,
            this.itDong});
            this.toolMain.Location = new System.Drawing.Point(0, 0);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(772, 31);
            this.toolMain.TabIndex = 0;
            this.toolMain.Text = "Cập nhật";
            // 
            // itThem
            // 
            this.itThem.Image = ((System.Drawing.Image)(resources.GetObject("itThem.Image")));
            this.itThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itThem.Name = "itThem";
            this.itThem.Size = new System.Drawing.Size(61, 28);
            this.itThem.Text = "Thêm";
            this.itThem.Click += new System.EventHandler(this.itThem_Click);
            // 
            // itSua
            // 
            this.itSua.Image = ((System.Drawing.Image)(resources.GetObject("itSua.Image")));
            this.itSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itSua.Name = "itSua";
            this.itSua.Size = new System.Drawing.Size(54, 28);
            this.itSua.Text = "Sửa";
            this.itSua.Click += new System.EventHandler(this.itSua_Click);
            // 
            // itXoa
            // 
            this.itXoa.Image = ((System.Drawing.Image)(resources.GetObject("itXoa.Image")));
            this.itXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itXoa.Name = "itXoa";
            this.itXoa.Size = new System.Drawing.Size(53, 28);
            this.itXoa.Text = "Xóa";
            this.itXoa.Click += new System.EventHandler(this.itXoa_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // itSave
            // 
            this.itSave.Image = ((System.Drawing.Image)(resources.GetObject("itSave.Image")));
            this.itSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itSave.Name = "itSave";
            this.itSave.Size = new System.Drawing.Size(53, 28);
            this.itSave.Text = "Lưu";
            this.itSave.Click += new System.EventHandler(this.itSave_Click);
            // 
            // itIDAuto
            // 
            this.itIDAuto.Image = ((System.Drawing.Image)(resources.GetObject("itIDAuto.Image")));
            this.itIDAuto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itIDAuto.Name = "itIDAuto";
            this.itIDAuto.Size = new System.Drawing.Size(100, 28);
            this.itIDAuto.Text = "Tạo lại Mã CN";
            this.itIDAuto.Click += new System.EventHandler(this.itIDAuto_Click);
            // 
            // itSort
            // 
            this.itSort.Image = ((System.Drawing.Image)(resources.GetObject("itSort.Image")));
            this.itSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itSort.Name = "itSort";
            this.itSort.Size = new System.Drawing.Size(74, 28);
            this.itSort.Text = "Sắp xếp";
            this.itSort.Click += new System.EventHandler(this.itSort_Click);
            // 
            // itUndo
            // 
            this.itUndo.Image = ((System.Drawing.Image)(resources.GetObject("itUndo.Image")));
            this.itUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itUndo.Name = "itUndo";
            this.itUndo.Size = new System.Drawing.Size(60, 28);
            this.itUndo.Text = "Undo";
            this.itUndo.Click += new System.EventHandler(this.itUndo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // itDong
            // 
            this.itDong.Image = ((System.Drawing.Image)(resources.GetObject("itDong.Image")));
            this.itDong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.itDong.Name = "itDong";
            this.itDong.Size = new System.Drawing.Size(61, 28);
            this.itDong.Text = "Đóng";
            this.itDong.Click += new System.EventHandler(this.itDong_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã chức năng";
            // 
            // txtTen
            // 
            this.txtTen.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TenChucNang", true));
            this.txtTen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtTen.Location = new System.Drawing.Point(545, 106);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(215, 21);
            this.txtTen.TabIndex = 7;
            // 
            // bdData
            // 
            this.bdData.DataSource = typeof(ERP_Library.Security.MenuList);
            // 
            // txtMa
            // 
            this.txtMa.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "MaChucNang", true));
            this.txtMa.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtMa.FormatString = "#";
            this.txtMa.Location = new System.Drawing.Point(545, 52);
            this.txtMa.MaskInput = "nnnnnnnnn";
            this.txtMa.Name = "txtMa";
            this.txtMa.PromptChar = ' ';
            this.txtMa.Size = new System.Drawing.Size(95, 21);
            this.txtMa.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên chức năng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Thuộc nhóm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hình ảnh";
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHinhAnh.Location = new System.Drawing.Point(545, 160);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(58, 45);
            this.picHinhAnh.TabIndex = 11;
            this.picHinhAnh.TabStop = false;
            this.picHinhAnh.Click += new System.EventHandler(this.picHinhAnh_Click);
            // 
            // cmbParentID
            // 
            this.cmbParentID.AutoComplete = true;
            this.cmbParentID.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "ParentID", true));
            this.cmbParentID.DisplayMember = "";
            this.cmbParentID.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbParentID.Location = new System.Drawing.Point(545, 133);
            this.cmbParentID.Name = "cmbParentID";
            this.cmbParentID.Size = new System.Drawing.Size(215, 21);
            this.cmbParentID.TabIndex = 9;
            this.cmbParentID.ValueMember = "";
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "All image|*.gif;*.jpg;*.bmp;*.png|All file|*.*";
            // 
            // treeMenus
            // 
            this.treeMenus.ColumnSettings.AllowColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.treeMenus.ColumnSettings.AllowSorting = Infragistics.Win.DefaultableBoolean.False;
            this.treeMenus.ColumnSettings.AutoFitColumns = Infragistics.Win.UltraWinTree.AutoFitColumns.ResizeAllColumns;
            this.treeMenus.ColumnSettings.ColumnAutoSizeMode = Infragistics.Win.UltraWinTree.ColumnAutoSizeMode.VisibleNodes;
            ultraTreeNodeColumn1.DataType = typeof(int);
            ultraTreeNodeColumn1.Key = "MaChucNang";
            ultraTreeNodeColumn1.LayoutInfo.PreferredCellSize = new System.Drawing.Size(74, 16);
            ultraTreeNodeColumn1.LayoutInfo.PreferredLabelSize = new System.Drawing.Size(74, 0);
            ultraTreeNodeColumn1.Text = "Mã CN";
            ultraTreeNodeColumn2.DataType = typeof(string);
            ultraTreeNodeColumn2.Key = "TenChucNang";
            ultraTreeNodeColumn2.LayoutInfo.PreferredCellSize = new System.Drawing.Size(279, 16);
            ultraTreeNodeColumn2.LayoutInfo.PreferredLabelSize = new System.Drawing.Size(279, 0);
            ultraTreeNodeColumn2.Text = "Tên chức năng";
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraTreeNodeColumn3.CellAppearance = appearance3;
            ultraTreeNodeColumn3.DataType = typeof(System.Drawing.Bitmap);
            ultraTreeNodeColumn3.Key = "HinhAnh";
            ultraTreeNodeColumn3.LayoutInfo.PreferredCellSize = new System.Drawing.Size(65, 16);
            ultraTreeNodeColumn3.LayoutInfo.PreferredLabelSize = new System.Drawing.Size(65, 0);
            ultraTreeNodeColumn3.Text = "Hình ảnh";
            ultraTreeNodeColumn4.DataType = typeof(int);
            ultraTreeNodeColumn4.Key = "STT";
            ultraTreeNodeColumn4.SortType = Infragistics.Win.UltraWinTree.SortType.Ascending;
            ultraTreeNodeColumn4.Visible = false;
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraTreeNodeColumn5.CellAppearance = appearance4;
            ultraTreeNodeColumn5.DataType = typeof(bool);
            ultraTreeNodeColumn5.Key = "An";
            ultraTreeNodeColumn5.Text = "Ẩn";
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn1);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn2);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn3);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn4);
            ultraTreeColumnSet1.Columns.Add(ultraTreeNodeColumn5);
            ultraTreeColumnSet1.Key = "menus";
            this.treeMenus.ColumnSettings.ColumnSets.Add(ultraTreeColumnSet1);
            this.treeMenus.HideSelection = false;
            this.treeMenus.ImageList = this.imgList;
            this.treeMenus.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.treeMenus.Location = new System.Drawing.Point(12, 52);
            this.treeMenus.Name = "treeMenus";
            this.treeMenus.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            _override1.ColumnSetIndex = 0;
            _override1.ImageSize = new System.Drawing.Size(24, 24);
            _override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            this.treeMenus.Override = _override1;
            this.treeMenus.Size = new System.Drawing.Size(445, 486);
            this.treeMenus.TabIndex = 1;
            this.treeMenus.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.OutlookExpress;
            this.treeMenus.AfterActivate += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.treeMenus_AfterActivate);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "146.gif");
            // 
            // txtSTT
            // 
            this.txtSTT.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "STT", true));
            this.txtSTT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtSTT.FormatString = "#";
            this.txtSTT.Location = new System.Drawing.Point(545, 79);
            this.txtSTT.MaskInput = "nn";
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.PromptChar = ' ';
            this.txtSTT.Size = new System.Drawing.Size(40, 21);
            this.txtSTT.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số thứ tự";
            // 
            // chkAn
            // 
            this.chkAn.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bdData, "An", true));
            this.chkAn.GlyphStyle = Infragistics.Win.GlyphStyle.Office2007;
            this.chkAn.Location = new System.Drawing.Point(466, 278);
            this.chkAn.Name = "chkAn";
            this.chkAn.Size = new System.Drawing.Size(109, 21);
            this.chkAn.TabIndex = 15;
            this.chkAn.Text = "Không sử dụng";
            // 
            // btnPrev
            // 
            this.btnPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrev.BackgroundImage")));
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrev.Location = new System.Drawing.Point(463, 305);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(26, 40);
            this.btnPrev.TabIndex = 16;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.Location = new System.Drawing.Point(463, 351);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(26, 40);
            this.btnNext.TabIndex = 17;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tên form";
            // 
            // cmbTenForm
            // 
            this.cmbTenForm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbTenForm.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TenForm", true));
            this.cmbTenForm.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.cmbTenForm.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.cmbTenForm.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.cmbTenForm.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.cmbTenForm.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            this.cmbTenForm.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cmbTenForm.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.cmbTenForm.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.cmbTenForm.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.cmbTenForm.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbTenForm.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbTenForm.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.cmbTenForm.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cmbTenForm.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbTenForm.Location = new System.Drawing.Point(545, 211);
            this.cmbTenForm.Name = "cmbTenForm";
            this.cmbTenForm.Size = new System.Drawing.Size(215, 22);
            this.cmbTenForm.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(463, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Phương thức mở";
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdData, "TenFunction", true));
            this.ultraTextEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraTextEditor1.Location = new System.Drawing.Point(554, 239);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(206, 21);
            this.ultraTextEditor1.TabIndex = 14;
            // 
            // frmMenus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 550);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ultraTextEditor1);
            this.Controls.Add(this.cmbTenForm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.chkAn);
            this.Controls.Add(this.txtSTT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.treeMenus);
            this.Controls.Add(this.picHinhAnh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbParentID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolMain);
            this.Name = "frmMenus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách các chức năng";
            this.Load += new System.EventHandler(this.frmMenus_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenus_FormClosing);
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParentID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTenForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.ToolStripButton itThem;
        private System.Windows.Forms.ToolStripButton itSua;
        private System.Windows.Forms.ToolStripButton itXoa;
        private System.Windows.Forms.ToolStripButton itDong;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTen;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.BindingSource bdData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbParentID;
        private System.Windows.Forms.ToolStripButton itSave;
        private System.Windows.Forms.ToolStripButton itUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private Infragistics.Win.UltraWinTree.UltraTree treeMenus;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtSTT;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAn;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ToolStripButton itSort;
        private System.Windows.Forms.ToolStripButton itIDAuto;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbTenForm;
        private System.Windows.Forms.Label label7;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
    }
}
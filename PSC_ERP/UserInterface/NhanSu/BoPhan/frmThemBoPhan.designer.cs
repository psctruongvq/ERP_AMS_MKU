namespace PSC_ERP
{
    partial class frmBoPhan
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
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            this.tbMaQL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tbTenBP = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.cbLoaiBP = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.bindingSource1_LoaiBoPhan = new System.Windows.Forms.BindingSource(this.components);
            this.treeView_PhanXuong = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.theemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mớiLướiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.địnhVịBộPhậnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ultraComboEditor1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbCongTy = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.bindingSource1_BoPhan = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1_CongTy = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTenBP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiBP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LoaiBoPhan)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCongTy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_BoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_CongTy)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMaQL
            // 
            this.tbMaQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaQL.Location = new System.Drawing.Point(124, 26);
            this.tbMaQL.Name = "tbMaQL";
            this.tbMaQL.Size = new System.Drawing.Size(166, 21);
            this.tbMaQL.TabIndex = 1;
            // 
            // tbTenBP
            // 
            this.tbTenBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenBP.Location = new System.Drawing.Point(431, 26);
            this.tbTenBP.Name = "tbTenBP";
            this.tbTenBP.Size = new System.Drawing.Size(156, 21);
            this.tbTenBP.TabIndex = 3;
            // 
            // cbLoaiBP
            // 
            this.cbLoaiBP.DataSource = this.bindingSource1_LoaiBoPhan;
            this.cbLoaiBP.DisplayMember = "TenLoaiBoPhan";
            this.cbLoaiBP.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbLoaiBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiBP.Location = new System.Drawing.Point(124, 58);
            this.cbLoaiBP.Name = "cbLoaiBP";
            this.cbLoaiBP.Size = new System.Drawing.Size(166, 21);
            this.cbLoaiBP.TabIndex = 5;
            this.cbLoaiBP.ValueMember = "MaLoaiBoPhan";
            // 
            // bindingSource1_LoaiBoPhan
            // 
            this.bindingSource1_LoaiBoPhan.DataSource = typeof(ERP_Library.LoaiBoPhanList);
            // 
            // treeView_PhanXuong
            // 
            this.treeView_PhanXuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView_PhanXuong.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView_PhanXuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView_PhanXuong.Location = new System.Drawing.Point(0, 3);
            this.treeView_PhanXuong.Name = "treeView_PhanXuong";
            this.treeView_PhanXuong.ShowNodeToolTips = true;
            this.treeView_PhanXuong.Size = new System.Drawing.Size(357, 599);
            this.treeView_PhanXuong.TabIndex = 1;
            this.treeView_PhanXuong.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_PhanXuong_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theemToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.mớiLướiToolStripMenuItem,
            this.cậpNhậtToolStripMenuItem,
            this.địnhVịBộPhậnToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 114);
            // 
            // theemToolStripMenuItem
            // 
            this.theemToolStripMenuItem.Name = "theemToolStripMenuItem";
            this.theemToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.theemToolStripMenuItem.Text = "Thêm Mới";
            this.theemToolStripMenuItem.Click += new System.EventHandler(this.theemToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // mớiLướiToolStripMenuItem
            // 
            this.mớiLướiToolStripMenuItem.Name = "mớiLướiToolStripMenuItem";
            this.mớiLướiToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.mớiLướiToolStripMenuItem.Text = "Làm Tươi";
            this.mớiLướiToolStripMenuItem.Click += new System.EventHandler(this.mớiLướiToolStripMenuItem_Click);
            // 
            // cậpNhậtToolStripMenuItem
            // 
            this.cậpNhậtToolStripMenuItem.Name = "cậpNhậtToolStripMenuItem";
            this.cậpNhậtToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.cậpNhậtToolStripMenuItem.Text = "Cập Nhật";
            this.cậpNhậtToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtToolStripMenuItem_Click_1);
            // 
            // địnhVịBộPhậnToolStripMenuItem
            // 
            this.địnhVịBộPhậnToolStripMenuItem.Name = "địnhVịBộPhậnToolStripMenuItem";
            this.địnhVịBộPhậnToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.địnhVịBộPhậnToolStripMenuItem.Text = "Sắp Xếp Bộ Phận";
            this.địnhVịBộPhậnToolStripMenuItem.Click += new System.EventHandler(this.địnhVịBộPhậnToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(267, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Tạo Mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ultraComboEditor1);
            this.groupBox1.Controls.Add(this.cbCongTy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cbLoaiBP);
            this.groupBox1.Controls.Add(this.tbMaQL);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tbTenBP);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(363, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 243);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Bộ Phận";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(36, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Phân Cấp";
            // 
            // ultraComboEditor1
            // 
            this.ultraComboEditor1.DisplayMember = "";
            this.ultraComboEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraComboEditor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valueListItem10.DataValue = 1;
            valueListItem10.DisplayText = "Đơn Vị Cấp 1";
            valueListItem11.DataValue = 2;
            valueListItem11.DisplayText = "Đơn Vị Khoán";
            valueListItem12.DataValue = 3;
            valueListItem12.DisplayText = "Đơn Vị Cấp 2";
            this.ultraComboEditor1.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11,
            valueListItem12});
            this.ultraComboEditor1.Location = new System.Drawing.Point(124, 88);
            this.ultraComboEditor1.Name = "ultraComboEditor1";
            this.ultraComboEditor1.Size = new System.Drawing.Size(166, 21);
            this.ultraComboEditor1.TabIndex = 15;
            this.ultraComboEditor1.ValueMember = "";
            this.ultraComboEditor1.ValueChanged += new System.EventHandler(this.ultraComboEditor1_ValueChanged);
            // 
            // cbCongTy
            // 
            this.cbCongTy.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource1_BoPhan, "MaCongTy", true));
            this.cbCongTy.DataSource = this.bindingSource1_CongTy;
            this.cbCongTy.DisplayMember = "TenCongTy";
            this.cbCongTy.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbCongTy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCongTy.Location = new System.Drawing.Point(431, 61);
            this.cbCongTy.Name = "cbCongTy";
            this.cbCongTy.Size = new System.Drawing.Size(156, 21);
            this.cbCongTy.TabIndex = 7;
            this.cbCongTy.ValueMember = "MaCongTy";
            this.cbCongTy.ValueChanged += new System.EventHandler(this.cbCongTy_ValueChanged);
            // 
            // bindingSource1_BoPhan
            // 
            this.bindingSource1_BoPhan.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // bindingSource1_CongTy
            // 
            this.bindingSource1_CongTy.DataSource = typeof(ERP_Library.CongTyList);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(24, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã Bộ Phận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(19, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại Bộ Phận";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(344, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Bộ Phận";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(338, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Đơn Vị Kế Toán:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(280, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cập Nhật";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmBoPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 604);
            this.Controls.Add(this.treeView_PhanXuong);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmBoPhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Định Nghĩa Bộ Phận";
            this.Load += new System.EventHandler(this.BoPhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbMaQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTenBP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiBP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LoaiBoPhan)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCongTy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_BoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_CongTy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor tbMaQL;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor tbTenBP;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbLoaiBP;
        private System.Windows.Forms.BindingSource bindingSource1_LoaiBoPhan;
        private System.Windows.Forms.BindingSource bindingSource1_CongTy;
        private System.Windows.Forms.BindingSource bindingSource1_BoPhan;
        private System.Windows.Forms.TreeView treeView_PhanXuong;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem theemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem mớiLướiToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbCongTy;
        private System.Windows.Forms.ToolStripMenuItem địnhVịBộPhậnToolStripMenuItem;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ultraComboEditor1;
        private System.Windows.Forms.Label label5;

    }
}
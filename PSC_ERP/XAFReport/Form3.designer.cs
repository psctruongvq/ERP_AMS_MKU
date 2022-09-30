namespace PSC_ERP
{
    partial class Form3
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Test Report 1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Test Report 2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Test Report 3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Test Report 4");
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dtp_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_ThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Xem = new DevExpress.XtraEditors.SimpleButton();
            this.TreeView_Test = new System.Windows.Forms.TreeView();
            this.btn_CreateNew = new DevExpress.XtraEditors.SimpleButton();
            this.txt_BoPhanCha = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.boPhanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txt_BoPhanCha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(513, 34);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dtp_DenNgay
            // 
            this.dtp_DenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtp_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DenNgay.Location = new System.Drawing.Point(278, 76);
            this.dtp_DenNgay.Name = "dtp_DenNgay";
            this.dtp_DenNgay.Size = new System.Drawing.Size(128, 20);
            this.dtp_DenNgay.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(240, 8);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker2.TabIndex = 2;
           
            this.simpleButton2.Location = new System.Drawing.Point(344, 34);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(163, 23);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "Chi Tiêt Luong Kỳ 1";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(228, 82);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Ngày tạo";
            // 
            // btn_ThemMoi
            // 
            this.btn_ThemMoi.Location = new System.Drawing.Point(412, 73);
            this.btn_ThemMoi.Name = "btn_ThemMoi";
            this.btn_ThemMoi.Size = new System.Drawing.Size(95, 23);
            this.btn_ThemMoi.TabIndex = 6;
            this.btn_ThemMoi.Text = "Thêm mới có sẵn";
            this.btn_ThemMoi.Click += new System.EventHandler(this.btn_ThemMoi_Click);
            // 
            // btn_Xem
            // 
            this.btn_Xem.Location = new System.Drawing.Point(228, 135);
            this.btn_Xem.Name = "btn_Xem";
            this.btn_Xem.Size = new System.Drawing.Size(95, 23);
            this.btn_Xem.TabIndex = 7;
            this.btn_Xem.Text = "Xem";
            this.btn_Xem.Click += new System.EventHandler(this.btn_Xem_Click);
            // 
            // TreeView_Test
            // 
            this.TreeView_Test.Location = new System.Drawing.Point(44, 76);
            this.TreeView_Test.Name = "TreeView_Test";
            treeNode1.Name = "baocao01";
            treeNode1.Text = "Test Report 1";
            treeNode2.Name = "baocao02";
            treeNode2.Text = "Test Report 2";
            treeNode3.Name = "baocao03";
            treeNode3.Text = "Test Report 3";
            treeNode4.Name = "baocao04";
            treeNode4.Text = "Test Report 4";
            this.TreeView_Test.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.TreeView_Test.Size = new System.Drawing.Size(178, 240);
            this.TreeView_Test.TabIndex = 8;
            // 
            // btn_CreateNew
            // 
            this.btn_CreateNew.Location = new System.Drawing.Point(412, 102);
            this.btn_CreateNew.Name = "btn_CreateNew";
            this.btn_CreateNew.Size = new System.Drawing.Size(95, 23);
            this.btn_CreateNew.TabIndex = 9;
            this.btn_CreateNew.Text = "Thêm mới 2";
            this.btn_CreateNew.Click += new System.EventHandler(this.btn_CreateNew_Click);
            // 
            // txt_BoPhanCha
            // 
            this.txt_BoPhanCha.Location = new System.Drawing.Point(278, 102);
            this.txt_BoPhanCha.Name = "txt_BoPhanCha";
            this.txt_BoPhanCha.Size = new System.Drawing.Size(128, 20);
            this.txt_BoPhanCha.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(228, 105);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Ngày tạo";
            // 
            // boPhanListBindingSource
            // 
            this.boPhanListBindingSource.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 393);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_BoPhanCha);
            this.Controls.Add(this.btn_CreateNew);
            this.Controls.Add(this.TreeView_Test);
            this.Controls.Add(this.btn_Xem);
            this.Controls.Add(this.btn_ThemMoi);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dtp_DenNgay);
            this.Controls.Add(this.simpleButton1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.txt_BoPhanCha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boPhanListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DateTimePicker dtp_DenNgay;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.BindingSource boPhanListBindingSource;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_ThemMoi;
        private DevExpress.XtraEditors.SimpleButton btn_Xem;
        private System.Windows.Forms.TreeView TreeView_Test;
        private DevExpress.XtraEditors.SimpleButton btn_CreateNew;
        private DevExpress.XtraEditors.TextEdit txt_BoPhanCha;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
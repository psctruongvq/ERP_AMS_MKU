namespace PSC_ERPNew.Main
{
    partial class frmNhapSoSerialTaiSan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapSoSerialTaiSan));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtBlack = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelChiTiet = new DevExpress.XtraEditors.PanelControl();
            this.btn_HuyBo = new DevExpress.XtraEditors.SimpleButton();
            this.btn_DongY = new DevExpress.XtraEditors.SimpleButton();
            this.txt_Seria_Moi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Seria_Cu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelChiTiet)).BeginInit();
            this.panelChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Seria_Moi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Seria_Cu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add64.png");
            this.imageList1.Images.SetKeyName(1, "undo64.png");
            this.imageList1.Images.SetKeyName(2, "1337595172_file_edit.png");
            this.imageList1.Images.SetKeyName(3, "1343360966_file_delete.png");
            this.imageList1.Images.SetKeyName(4, "save64.png");
            this.imageList1.Images.SetKeyName(5, "1337595258_Gnome-View-Refresh-64.png");
            this.imageList1.Images.SetKeyName(6, "find64.png");
            this.imageList1.Images.SetKeyName(7, "printer64.png");
            this.imageList1.Images.SetKeyName(8, "help64.png");
            this.imageList1.Images.SetKeyName(9, "exit64.png");
            this.imageList1.Images.SetKeyName(10, "import.png");
            // 
            // txtBlack
            // 
            this.txtBlack.Location = new System.Drawing.Point(352, 41);
            this.txtBlack.Name = "txtBlack";
            this.txtBlack.Size = new System.Drawing.Size(100, 20);
            this.txtBlack.TabIndex = 5;
            this.txtBlack.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.groupControl1.Controls.Add(this.panelChiTiet);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(773, 155);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Thông Tin Tài Sản";
            // 
            // panelChiTiet
            // 
            this.panelChiTiet.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.panelChiTiet.Controls.Add(this.btn_HuyBo);
            this.panelChiTiet.Controls.Add(this.btn_DongY);
            this.panelChiTiet.Controls.Add(this.txt_Seria_Moi);
            this.panelChiTiet.Controls.Add(this.labelControl2);
            this.panelChiTiet.Controls.Add(this.txt_Seria_Cu);
            this.panelChiTiet.Controls.Add(this.labelControl1);
            this.panelChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelChiTiet.Location = new System.Drawing.Point(2, 20);
            this.panelChiTiet.Name = "panelChiTiet";
            this.panelChiTiet.Size = new System.Drawing.Size(769, 134);
            this.panelChiTiet.TabIndex = 0;
            // 
            // btn_HuyBo
            // 
            this.btn_HuyBo.Location = new System.Drawing.Point(370, 76);
            this.btn_HuyBo.Name = "btn_HuyBo";
            this.btn_HuyBo.Size = new System.Drawing.Size(96, 46);
            this.btn_HuyBo.TabIndex = 4;
            this.btn_HuyBo.Text = "Hủy Bỏ";
            this.btn_HuyBo.Click += new System.EventHandler(this.btn_HuyBo_Click);
            // 
            // btn_DongY
            // 
            this.btn_DongY.Location = new System.Drawing.Point(226, 76);
            this.btn_DongY.Name = "btn_DongY";
            this.btn_DongY.Size = new System.Drawing.Size(96, 46);
            this.btn_DongY.TabIndex = 4;
            this.btn_DongY.Text = "Đồng Ý";
            this.btn_DongY.Click += new System.EventHandler(this.btn_DongY_Click);
            // 
            // txt_Seria_Moi
            // 
            this.txt_Seria_Moi.Location = new System.Drawing.Point(164, 46);
            this.txt_Seria_Moi.Name = "txt_Seria_Moi";
            this.txt_Seria_Moi.Size = new System.Drawing.Size(581, 20);
            this.txt_Seria_Moi.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(45, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(106, 15);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Nhập Số Seria Mới :";
            // 
            // txt_Seria_Cu
            // 
            this.txt_Seria_Cu.Location = new System.Drawing.Point(164, 14);
            this.txt_Seria_Cu.Name = "txt_Seria_Cu";
            this.txt_Seria_Cu.Properties.ReadOnly = true;
            this.txt_Seria_Cu.Size = new System.Drawing.Size(581, 20);
            this.txt_Seria_Cu.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(45, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(99, 15);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Nhập Số Seria Cũ :";
            // 
            // frmNhapSoSerialTaiSan
            // 
            this.AcceptButton = this.btn_DongY;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 155);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtBlack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhapSoSerialTaiSan";
            this.Text = "Nhập Số Serial Mới";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhapSoSerialTaiSan_FormClosing);
            this.Load += new System.EventHandler(this.frmNhapSoSerialTaiSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBlack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelChiTiet)).EndInit();
            this.panelChiTiet.ResumeLayout(false);
            this.panelChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Seria_Moi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Seria_Cu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtBlack;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelChiTiet;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.TextEdit txt_Seria_Cu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_HuyBo;
        private DevExpress.XtraEditors.SimpleButton btn_DongY;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txt_Seria_Moi;
    }
}
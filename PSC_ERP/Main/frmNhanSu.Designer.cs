namespace PSC_ERP.Main
{
    partial class frmNhanSu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanSu));
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txt_UserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txt_CanhBao = new System.Windows.Forms.ToolStripStatusLabel();
            this.GioCanhBao = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnMain
            // 
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(647, 24);
            this.mnMain.TabIndex = 0;
            this.mnMain.Text = "Main menu";
            this.mnMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnMain_ItemClicked);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_UserName,
            this.toolStripStatusLabel1,
            this.txt_CanhBao});
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(647, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(77, 17);
            this.txt_UserName.Text = "Người dùng: ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // txt_CanhBao
            // 
            this.txt_CanhBao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CanhBao.IsLink = true;
            this.txt_CanhBao.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.txt_CanhBao.LinkColor = System.Drawing.Color.Red;
            this.txt_CanhBao.Margin = new System.Windows.Forms.Padding(70, 3, 0, 2);
            this.txt_CanhBao.Name = "txt_CanhBao";
            this.txt_CanhBao.Size = new System.Drawing.Size(46, 17);
            this.txt_CanhBao.Text = "Chú ý:";
            this.txt_CanhBao.Click += new System.EventHandler(this.txt_CanhBao_Click);
            // 
            // GioCanhBao
            // 
            this.GioCanhBao.Enabled = true;
            this.GioCanhBao.Interval = 800;
            this.GioCanhBao.Tick += new System.EventHandler(this.GioCanhBao_Tick);
            // 
            // frmNhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(647, 517);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnMain;
            this.Name = "frmNhanSu";
            this.Text = "Quản lý nhân sự";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNhanSu_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txt_UserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel txt_CanhBao;
        private System.Windows.Forms.Timer GioCanhBao;
    }
}
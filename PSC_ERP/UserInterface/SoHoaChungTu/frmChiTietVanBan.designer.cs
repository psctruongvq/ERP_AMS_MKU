namespace PSC_ERP
{
    partial class frmChiTietVanBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietVanBan));
            this.ChungTu_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.axAcroPDF = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.ChungTu_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // ChungTu_BindingSource
            // 
            this.ChungTu_BindingSource.AllowNew = false;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "add64.png");
            this.imageList.Images.SetKeyName(1, "undo64.png");
            this.imageList.Images.SetKeyName(2, "1337595172_file_edit.png");
            this.imageList.Images.SetKeyName(3, "1343360966_file_delete.png");
            this.imageList.Images.SetKeyName(4, "save64.png");
            this.imageList.Images.SetKeyName(5, "1337595258_Gnome-View-Refresh-64.png");
            this.imageList.Images.SetKeyName(6, "find64.png");
            this.imageList.Images.SetKeyName(7, "printer64.png");
            this.imageList.Images.SetKeyName(8, "help64.png");
            this.imageList.Images.SetKeyName(9, "exit64.png");
            this.imageList.Images.SetKeyName(10, "1345614271_text-x-log.png");
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.axAcroPDF);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(848, 684);
            this.ultraGroupBox2.TabIndex = 115;
            // 
            // axAcroPDF
            // 
            this.axAcroPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF.Enabled = true;
            this.axAcroPDF.Location = new System.Drawing.Point(3, 0);
            this.axAcroPDF.Name = "axAcroPDF";
            this.axAcroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF.OcxState")));
            this.axAcroPDF.Size = new System.Drawing.Size(842, 681);
            this.axAcroPDF.TabIndex = 34;
            // 
            // frmChiTietVanBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 684);
            this.Controls.Add(this.ultraGroupBox2);
            this.Name = "frmChiTietVanBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "           Thông Tin Chi Tiết Văn Bản";
            ((System.ComponentModel.ISupportInitialize)(this.ChungTu_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource ChungTu_BindingSource;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private System.Windows.Forms.ImageList imageList;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF;

    }
}
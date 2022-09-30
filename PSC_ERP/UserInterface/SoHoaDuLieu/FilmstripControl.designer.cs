namespace Filmstrip
{
    partial class FilmstripControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilmstripControl));
            this.mainPicture = new System.Windows.Forms.PictureBox();
            this.panelThumbs = new System.Windows.Forms.Panel();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox_ThongTin = new System.Windows.Forms.GroupBox();
            this.txt_DienGiai = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.txtu_SoHoSo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.dtpu_NgayLap = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
            this.panelNavigation.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_ThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienGiai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_SoHoSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpu_NgayLap)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPicture
            // 
            this.mainPicture.BackColor = System.Drawing.Color.White;
            this.mainPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mainPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPicture.Location = new System.Drawing.Point(0, 0);
            this.mainPicture.Name = "mainPicture";
            this.mainPicture.Size = new System.Drawing.Size(543, 410);
            this.mainPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainPicture.TabIndex = 0;
            this.mainPicture.TabStop = false;
            this.mainPicture.DoubleClick += new System.EventHandler(this.pictureMain_DoubleClick);
            // 
            // panelThumbs
            // 
            this.panelThumbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelThumbs.BackColor = System.Drawing.Color.Lavender;
            this.panelThumbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThumbs.Location = new System.Drawing.Point(41, 5);
            this.panelThumbs.Name = "panelThumbs";
            this.panelThumbs.Size = new System.Drawing.Size(461, 78);
            this.panelThumbs.TabIndex = 1;
            this.panelThumbs.TabStop = true;
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonRight.FlatAppearance.BorderSize = 0;
            this.buttonRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonRight.Image")));
            this.buttonRight.Location = new System.Drawing.Point(504, 5);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(36, 78);
            this.buttonRight.TabIndex = 2;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            this.buttonRight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilmstripControl_KeyDown);
            this.buttonRight.MouseLeave += new System.EventHandler(this.buttonNav_MouseLeave);
            this.buttonRight.MouseHover += new System.EventHandler(this.buttonNav_MouseHover);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLeft.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonLeft.Image")));
            this.buttonLeft.Location = new System.Drawing.Point(3, 5);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(36, 78);
            this.buttonLeft.TabIndex = 0;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            this.buttonLeft.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilmstripControl_KeyDown);
            this.buttonLeft.MouseLeave += new System.EventHandler(this.buttonNav_MouseLeave);
            this.buttonLeft.MouseHover += new System.EventHandler(this.buttonNav_MouseHover);
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.White;
            this.panelNavigation.Controls.Add(this.buttonRight);
            this.panelNavigation.Controls.Add(this.buttonLeft);
            this.panelNavigation.Controls.Add(this.panelThumbs);
            this.panelNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNavigation.Location = new System.Drawing.Point(0, 485);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(543, 89);
            this.panelNavigation.TabIndex = 1;
            this.panelNavigation.Paint += new System.Windows.Forms.PaintEventHandler(this.panelNavigation_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox_ThongTin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 75);
            this.panel1.TabIndex = 2;
            // 
            // groupBox_ThongTin
            // 
            this.groupBox_ThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_ThongTin.Controls.Add(this.txt_DienGiai);
            this.groupBox_ThongTin.Controls.Add(this.label3);
            this.groupBox_ThongTin.Controls.Add(this.txtu_SoHoSo);
            this.groupBox_ThongTin.Controls.Add(this.dtpu_NgayLap);
            this.groupBox_ThongTin.Controls.Add(this.label1);
            this.groupBox_ThongTin.Controls.Add(this.label2);
            this.groupBox_ThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ThongTin.Location = new System.Drawing.Point(3, 1);
            this.groupBox_ThongTin.Name = "groupBox_ThongTin";
            this.groupBox_ThongTin.Size = new System.Drawing.Size(537, 70);
            this.groupBox_ThongTin.TabIndex = 31;
            this.groupBox_ThongTin.TabStop = false;
            this.groupBox_ThongTin.Text = "Thông tin hồ sơ";
            // 
            // txt_DienGiai
            // 
            this.txt_DienGiai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DienGiai.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txt_DienGiai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DienGiai.Location = new System.Drawing.Point(277, 14);
            this.txt_DienGiai.Multiline = true;
            this.txt_DienGiai.Name = "txt_DienGiai";
            this.txt_DienGiai.Size = new System.Drawing.Size(254, 47);
            this.txt_DienGiai.TabIndex = 8;
            this.txt_DienGiai.ValueChanged += new System.EventHandler(this.txt_DienGiai_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(219, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số hồ sơ:";
            // 
            // txtu_SoHoSo
            // 
            this.txtu_SoHoSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtu_SoHoSo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtu_SoHoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtu_SoHoSo.Location = new System.Drawing.Point(65, 14);
            this.txtu_SoHoSo.Name = "txtu_SoHoSo";
            this.txtu_SoHoSo.Size = new System.Drawing.Size(141, 21);
            this.txtu_SoHoSo.TabIndex = 2;
            this.txtu_SoHoSo.ValueChanged += new System.EventHandler(this.txtu_SoHoSo_ValueChanged);
            // 
            // dtpu_NgayLap
            // 
            this.dtpu_NgayLap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpu_NgayLap.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.dtpu_NgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpu_NgayLap.FormatString = "dd/MM/yyyy";
            this.dtpu_NgayLap.Location = new System.Drawing.Point(65, 40);
            this.dtpu_NgayLap.MaskInput = "";
            this.dtpu_NgayLap.Name = "dtpu_NgayLap";
            this.dtpu_NgayLap.Size = new System.Drawing.Size(141, 21);
            this.dtpu_NgayLap.TabIndex = 6;
            this.dtpu_NgayLap.ValueChanged += new System.EventHandler(this.dtpu_NgayLap_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số hồ sơ:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày lập:";
            // 
            // FilmstripControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainPicture);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelNavigation);
            this.Name = "FilmstripControl";
            this.Size = new System.Drawing.Size(543, 574);
            this.Load += new System.EventHandler(this.LayoutScreenshotFilmstrip_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilmstripControl_KeyDown);
            this.Resize += new System.EventHandler(this.FilmstripControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).EndInit();
            this.panelNavigation.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox_ThongTin.ResumeLayout(false);
            this.groupBox_ThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DienGiai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtu_SoHoSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpu_NgayLap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPicture;
        private System.Windows.Forms.Panel panelThumbs;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtu_SoHoSo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtpu_NgayLap;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txt_DienGiai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox_ThongTin;
    }
}

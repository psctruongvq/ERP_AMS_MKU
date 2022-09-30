namespace PSC_ERP
{
    partial class frmXemIn
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
            this.rptView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BangChamCongListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BangChamCongListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptView
            // 
            this.rptView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptView.Location = new System.Drawing.Point(0, 0);
            this.rptView.Name = "rptView";
            this.rptView.ShowBackButton = false;
            this.rptView.ShowDocumentMapButton = false;
            this.rptView.ShowRefreshButton = false;
            this.rptView.ShowStopButton = false;
            this.rptView.Size = new System.Drawing.Size(725, 510);
            this.rptView.TabIndex = 0;
            // 
            // BangChamCongListBindingSource
            // 
            this.BangChamCongListBindingSource.DataSource = typeof(ERP_Library.BangChamCongList);
            // 
            // frmXemIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 510);
            this.Controls.Add(this.rptView);
            this.Name = "frmXemIn";
            this.Text = "Báo cáo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXemIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BangChamCongListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Reporting.WinForms.ReportViewer rptView;
        private System.Windows.Forms.BindingSource BangChamCongListBindingSource;


    }
}
namespace PSC_ERP
{
    partial class frmHienThiReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHienThiReport));
            this.crystalReportViewerHienThi = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.frmHienThiReport_Fill_Panel = new System.Windows.Forms.Panel();
            this.frmHienThiReport_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewerHienThi
            // 
            this.crystalReportViewerHienThi.ActiveViewIndex = -1;
            this.crystalReportViewerHienThi.AllowDrop = true;
            this.crystalReportViewerHienThi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewerHienThi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerHienThi.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerHienThi.Location = new System.Drawing.Point(-2, -1);
            this.crystalReportViewerHienThi.Name = "crystalReportViewerHienThi";
            this.crystalReportViewerHienThi.SelectionFormula = "";
            this.crystalReportViewerHienThi.Size = new System.Drawing.Size(686, 388);
            this.crystalReportViewerHienThi.TabIndex = 0;
            this.crystalReportViewerHienThi.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewerHienThi.ViewTimeSelectionFormula = "";
            // 
            // frmHienThiReport_Fill_Panel
            // 
            this.frmHienThiReport_Fill_Panel.Controls.Add(this.crystalReportViewerHienThi);
            this.frmHienThiReport_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmHienThiReport_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmHienThiReport_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.frmHienThiReport_Fill_Panel.Name = "frmHienThiReport_Fill_Panel";
            this.frmHienThiReport_Fill_Panel.Size = new System.Drawing.Size(684, 384);
            this.frmHienThiReport_Fill_Panel.TabIndex = 0;
            // 
            // frmHienThiReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 384);
            this.Controls.Add(this.frmHienThiReport_Fill_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHienThiReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hiển Thị Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.frmHienThiReport_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerHienThi;
        private System.Windows.Forms.Panel frmHienThiReport_Fill_Panel;
    }
}
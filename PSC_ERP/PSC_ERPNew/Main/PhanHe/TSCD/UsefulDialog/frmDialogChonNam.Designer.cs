namespace PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog
{
    partial class frmDialogChonNam
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
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.spinEditNam = new DevExpress.XtraEditors.SpinEdit();
            this.tblBoPhanERPNewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBoPhanERPNewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.labelControl6.LineVisible = true;
            this.labelControl6.Location = new System.Drawing.Point(105, 43);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(27, 15);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Năm:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(152, 86);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // spinEditNam
            // 
            this.spinEditNam.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditNam.Location = new System.Drawing.Point(142, 40);
            this.spinEditNam.Name = "spinEditNam";
            this.spinEditNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditNam.Properties.DisplayFormat.FormatString = "n0";
            this.spinEditNam.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditNam.Properties.Mask.EditMask = "n0";
            this.spinEditNam.Size = new System.Drawing.Size(105, 20);
            this.spinEditNam.TabIndex = 0;
            // 
            // tblBoPhanERPNewBindingSource
            // 
            this.tblBoPhanERPNewBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblBoPhanERPNew);
            // 
            // frmDialogChonNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 141);
            this.ControlBox = false;
            this.Controls.Add(this.spinEditNam);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl6);
            this.Name = "frmDialogChonNam";
            this.Text = "Chọn năm";
            this.Load += new System.EventHandler(this.frmDialogChonNam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBoPhanERPNewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tblBoPhanERPNewBindingSource;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SpinEdit spinEditNam;
    }
}
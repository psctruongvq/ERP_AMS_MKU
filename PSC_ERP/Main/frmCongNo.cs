using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.Main
{
    public partial class frmCongNo : Form
    {
        #region Các cài đặt của form phân hệ
        public frmCongNo()
        {
            InitializeComponent();
        }

        private void frmCongNo_Load(object sender, EventArgs e)
        {
            ERP_Library.Security.CurrentUser.LoadMenu(3000, mnMain, MenuClick);
            ToolStripMenuItem itThoat = new ToolStripMenuItem("Thoát");
            itThoat.Click += new EventHandler(itThoat_Click);
            mnMain.Items.Add(itThoat);
        }

        void itThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem mn = (ToolStripMenuItem)sender;
            ERP_Library.Security.MenuItem item = (ERP_Library.Security.MenuItem)mn.Tag;
            if (item.TenForm != "")
            {
                System.Type t = System.Type.GetType(item.TenForm);
                if (t != null)
                {
                    foreach (Form o in this.MdiChildren)
                    {
                        if (o.GetType() == t)
                        {
                            o.Activate();
                            return;
                        }
                    }
                    
                    object f = Activator.CreateInstance(t);
                    if (f is Form)
                    {
                        Form frm = (Form)f;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.WindowState = FormWindowState.Normal;
                        frm.MdiParent = this;
                        if (item.TenFunction != "")
                            frm.GetType().GetMethod(item.TenFunction).Invoke(frm, null);
                        else
                            frm.Show();
                    }
                }
                else
                    MessageBox.Show("Không tìm thấy form " + item.TenForm, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.Main
{
    public partial class frmTongHop : Form
    {
        public frmTongHop()
        {
            InitializeComponent();
        }

        private void frmTongHop_Load(object sender, EventArgs e)
        {
            //ERP_Library.Security.CurrentUser.LoadMenu(6000, mnMain, MenuClick);
            //ToolStripMenuItem itThoat = new ToolStripMenuItem("Thoát");
            //itThoat.Click += new EventHandler(itThoat_Click);

            //mnMain.Items.Add(itThoat);
        }
        private void LoadForm()
        {
            ERP_Library.Security.CurrentUser.LoadMenu(6000, mnMain, MenuClick);
            ToolStripMenuItem itThoat = new ToolStripMenuItem("Thoát");
            itThoat.Click += new EventHandler(itThoat_Click);

            mnMain.Items.Add(itThoat);
        }

        private void DangNhap()
        {
            frmDangNhap f = new frmDangNhap();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                lblUser.Text = "Người sử dụng : " + ERP_Library.Security.CurrentUser.Info.TenDangNhap;
                //
                LoadForm();
            }
            else
                if (!ERP_Library.Security.CurrentUser.IsLogIn)
                    this.Close();
        }

        void itThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Thoát Khỏi Phần Mềm?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
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
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.WindowState = FormWindowState.Maximized;
                        frm.MdiParent = this;
                        if (item.TenFunction != "")
                            frm.GetType().GetMethod(item.TenFunction).Invoke(frm, null);
                        else
                            frm.Show();
                        //this.Hide();
                    }
                }
                else
                    MessageBox.Show("Không tìm thấy form " + item.TenForm, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmTongHop_Shown(object sender, EventArgs e)
        {
            //thay đổi định dạng
            System.Globalization.CultureInfo cul = new System.Globalization.CultureInfo("vi-VN");

            Application.CurrentCulture = cul;

            if (!ERP_Library.Security.CurrentUser.IsLogIn)
                DangNhap();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

    }
}

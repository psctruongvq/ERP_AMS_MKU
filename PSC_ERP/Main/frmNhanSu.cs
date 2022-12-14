using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.Main
{
    public partial class frmNhanSu : Form
    {
        #region Các cài đặt của form phân hệ
        public frmNhanSu()
        {
            InitializeComponent();

        }

        private void frmNhanSu_Load(object sender, EventArgs e)
        {
            ERP_Library.Security.CurrentUser.LoadMenu(1000, mnMain, MenuClick);
            ToolStripMenuItem itThoat = new ToolStripMenuItem("Thoát");
            itThoat.Click += new EventHandler(itThoat_Click);
            mnMain.Items.Add(itThoat);

            //Thêm tên người dùng
            mfnc_LoadTenNguoiDangNhap();
            
            //Kiểm tra cảnh báo
            mfnc_KiemTraCanhBao();

        }

        private void mfnc_LoadTenNguoiDangNhap()
        {
           txt_UserName.Text = "Người dùng: " + ERP_Library.Security.CurrentUser.Info.TenDangNhap;
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
                    //object f = Activator.CreateInstance(t);
                    //if (f is Form)
                    //{
                    //    Form frm = (Form)f;
                    //    frm.StartPosition = FormStartPosition.CenterScreen;
                    //    frm.MdiParent = this;
                    //    frm.Show();
                    //}

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

        private void mnMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txt_CanhBao_Click(object sender, EventArgs e)
        {
            PSC_ERP.UserInterface.NhanSu.ThongTinLuong.frmCapNhatThongTinQuyetDinh frm = new PSC_ERP.UserInterface.NhanSu.ThongTinLuong.frmCapNhatThongTinQuyetDinh();
            frm.Show();
        }

        private void GioCanhBao_Tick(object sender, EventArgs e)
        {
            if (bAlet)
            {
                txt_CanhBao.Visible = true;
                if (txt_CanhBao.Text != "")
                    txt_CanhBao.Text = "";
                else
                    txt_CanhBao.Text = "Chú ý: Có quyết định đến hạn cần cập nhật thông tin. Vui lòng kiểm tra dữ liệu !";
            }
            else
            {
                txt_CanhBao.Visible = false;
            }
        }

        public static bool bAlet = false;
        public static void mfnc_KiemTraCanhBao()
        {
            ERP_Library.QuyetDinhNangLuongList _quyetdinhcanhbaoList = ERP_Library.QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(true);
            if (_quyetdinhcanhbaoList.Count > 0)
            {
                bAlet = true;
            }
            else
            { 
                bAlet = false; 
            }
        }
    }
}
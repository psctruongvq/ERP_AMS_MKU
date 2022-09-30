using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Diagnostics;
using System.IO;
//09/04/2013
namespace PSC_ERP
{
    public partial class frmKhoaThueUserTheoKy : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        KyList _kyList;
        Ky _ky;
        ERP_Library.Security.UserList _userListChuaKhoaSo;
        KhoaSo_UserList _khoaSo_UserList;
        int _maKy = 0;
        #endregion

        #region Function

        private void KhoiTaoForm()
        {
            bindingSource1_khoaSoUser.DataSource = typeof(ERP_Library.KhoaSo_UserList);
            bindingSource1_Ky.DataSource = typeof(ERP_Library.KyList);
        }

        private void LoadBindingSource()
        {
            _kyList = KyList.GetKyList();
            bindingSource1_Ky.DataSource = _kyList;
            _khoaSo_UserList = KhoaSo_UserList.NewKhoaSo_UserList();
            bindingSource1_khoaSoUser.DataSource = _khoaSo_UserList;
        }
        private void BindingData()
        {
            bindingSource1_khoaSoUser.DataSource = _khoaSo_UserList;
        }

        private void DesignGridView()
        {
            gridControl1.DataSource = bindingSource1_khoaSoUser;
            HamDungChung.InitGridViewDev(grdVDanhSachUserKhoaThue, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(grdVDanhSachUserKhoaThue, new string[] { "TenDangNhap", "NgayBatDau", "NgayKetThuc", "KhoaSoThue" },
                                new string[] { "Tên đăng nhập ", "Ngày bắt đầu", "Ngày kết thúc", "Khóa sổ thuế" },
                                             new int[] { 120, 90, 90, 90 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVDanhSachUserKhoaThue, new string[] { "TenDangNhap", "NgayBatDau", "NgayKetThuc", "KhoaSoThue" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(grdVDanhSachUserKhoaThue, new string[] { "TenDangNhap", "NgayBatDau", "NgayKetThuc" });

            Utils.GridUtils.SetSTTForGridView(grdVDanhSachUserKhoaThue, 50);//M
            //
            //RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            //LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            //LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            //LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            //HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            //HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            //LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            ////
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            //gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private void LoadKhoaSo_UserList(int maKy)
        {
            if (KhoaSo_UserList.KiemTraTonTaiKhoaSoUserListtheoKy(maKy))
            {
                _khoaSo_UserList = KhoaSo_UserList.GetKhoaSo_UserList(maKy);
                BindingData();
            }
            else
            {
                _userListChuaKhoaSo = ERP_Library.Security.UserList.GetUserListChuaPhanQuyenKyKeToan(maKy);
                _khoaSo_UserList = KhoaSo_UserList.NewKhoaSo_UserList();
                foreach (ERP_Library.Security.UserItem user in _userListChuaKhoaSo)
                {
                    _ky = Ky.GetKy(_maKy);
                    KhoaSo_User _khoaSo_User = KhoaSo_User.NewKhoaSo_User();
                    _khoaSo_User.UserID = user.UserID;
                    _khoaSo_User.KhoaSoThue = _ky.KhoaSo;
                    _khoaSo_User.MaKy = _ky.MaKy;
                    _khoaSo_UserList.Add(_khoaSo_User);
                }
                BindingData();

            }
        }

        private void LoadData()
        {
            checkEditAll.Checked = false;
            GetMaKy();
            if (_maKy != 0)
            {
                LoadKhoaSo_UserList(_maKy);
            }
        }

        private void GetMaKy()
        {
            if (Ky_GrLU.EditValue != null)
            {
                int maKy;
                if (int.TryParse(Ky_GrLU.EditValue.ToString(), out maKy))
                {
                    _maKy = maKy;
                }
                else _maKy = 0;
            }
            else _maKy = 0;
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        #endregion

        #region Event

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Ky_GrLU_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangeFocustextEdit.Focus();
            bindingSource1_khoaSoUser.EndEdit();
            try
            {
                _khoaSo_UserList.ApplyEdit();
                _khoaSo_UserList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkEditAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditAll.Checked == true)
            {
                for (int i = 0; i < grdVDanhSachUserKhoaThue.RowCount; i++)
                {
                    KhoaSo_User khoaso_user = grdVDanhSachUserKhoaThue.GetRow(i) as KhoaSo_User;
                    khoaso_user.KhoaSoThue = true;
                }
            }
            else
            {
                for (int i = 0; i < grdVDanhSachUserKhoaThue.RowCount; i++)
                {
                    KhoaSo_User khoaso_user = grdVDanhSachUserKhoaThue.GetRow(i) as KhoaSo_User;
                    khoaso_user.KhoaSoThue = false;
                }
            }
            gridControl1.Refresh();
            grdVDanhSachUserKhoaThue.RefreshData();
        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void btnXuatFileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                grdVDanhSachUserKhoaThue.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }
        #endregion

        public frmKhoaThueUserTheoKy()
        {
            InitializeComponent();
            KhoiTaoForm();
            LoadBindingSource();
            DesignGridView();

        }

        

        


    }
}
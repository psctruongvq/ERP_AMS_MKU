using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmNganHangNew : Form
    {
        NganHang _nganHang;
        NganHangList _nganHangList;
        TinhThanhList _TinhThanhList;
        NhomNganHangList _nhomNganHangList;
        Util util = new Util();

        public frmNganHangNew()
        {
            InitializeComponent();
            NganHang_BindingSource.DataSource = typeof(NganHangList);
            TinhThanh_BindingSource.DataSource = typeof(TinhThanhList);
            NhomNganHang_bindingSource.DataSource = typeof(NhomNganHangList);
            TinhThanh_bindingSource1.DataSource = typeof(TinhThanhList);
            NhomNganHang_bindingSource1.DataSource = typeof(NhomNganHangList);
        }

        private void LoadForm()
        {
            try
            {
                _nganHangList = NganHangList.GetNganHangList();
                NganHang_BindingSource.DataSource = _nganHangList;

                _TinhThanhList = TinhThanhList.GetTinhThanhList();
                TinhThanh tt = TinhThanh.NewTinhThanh(0, "Tất Cả");
                _TinhThanhList.Insert(0, tt);
                TinhThanh_bindingSource1.DataSource = _TinhThanhList;

                _nhomNganHangList = NhomNganHangList.GetNhomNganHangList();
                NhomNganHang _nhomNganHang = NhomNganHang.NewNhomNganHang("Chưa chọn");
                _nhomNganHangList.Insert(0, _nhomNganHang);
                NhomNganHang_bindingSource1.DataSource = _nhomNganHangList;

                TinhThanh_BindingSource.DataSource=TinhThanhList.GetTinhThanhList();
                NhomNganHang_bindingSource.DataSource = NhomNganHangList.GetNhomNganHangList();
            }
            catch (ApplicationException)
            {

            }
        }

        private void FrmNganHang_New_Load(object sender, EventArgs e)
        {
            gridView_NganHang.OptionsBehavior.Editable = false;
            Utils.GridUtils.SetSTTForGridView(gridView_NganHang, 35);
            LoadForm();
        }

        private void KhoiTao()
        {
            _nganHang = NganHang.NewNganHang();
            _nganHangList = NganHangList.NewNganHangList();
            _nganHang.MaQuanLy = NganHang.MaQuanLyNganHang();
            _nganHang.TenVietTat = NganHang.TenVietTatNganHang();

            NganHang_BindingSource.DataSource = _nganHang;
            txt_TenNganHang.Focus();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTao();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
        }

        private bool KiemTraTruocKhiLuu()
        {
            bool kq = true;

            if (_nganHang.TenNganHang == "")
            {
                kq = false;
                MessageBox.Show(this, "Vui Lòng Nhập Tên Ngân Hàng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenNganHang.Focus();
                return kq;
            }
            if (_nganHang.MaQuanLy == "")
            {
                kq = false;
                MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaQuanLy.Focus();
                return kq;
            }
            if (KiemTraMaQuanLy(_nganHang.MaQuanLy, _nganHang.MaNganHang) > 0)
            {
                MessageBox.Show("Mã quản lý bị trùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaQuanLy.Focus();
                return kq = false;
            }

            return kq;
        }

        private int KiemTraMaQuanLy(string MaQuanLy, long MaNganHang)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraMaQuanLyNganHang";
                        if (MaQuanLy.Length > 0)
                            cm.Parameters.AddWithValue("@MaQuanLy", MaQuanLy);
                        else
                            cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);

                        cm.Parameters.AddWithValue("@MaNganHang", MaNganHang);

                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        private void Save()
        {
            try
            {
                txtFocus.Focus();
                NganHang_BindingSource.EndEdit();
                _nganHang = NganHang_BindingSource.Current as NganHang;

                if (KiemTraTruocKhiLuu() == true)
                {
                    if (_nganHang.IsNew)//Thêm mới
                    {
                        _nganHangList.ApplyEdit();
                        _nganHangList.Add(_nganHang);
                        _nganHangList.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _nganHangList = NganHangList.GetNganHangList();
                        NganHang_BindingSource.DataSource = _nganHangList;
                    }
                    else//Đối tượng cũ
                    {
                        _nganHangList.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _nganHangList = NganHangList.GetNganHangList();
                        NganHang_BindingSource.DataSource = _nganHangList;
                    }
                }

            }
            catch (ApplicationException)
            {

            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          //Lưu dữ liệu
            Save();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView_NganHang.SelectedRowsCount == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            gridView_NganHang.DeleteSelectedRows();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
        }
    }
}
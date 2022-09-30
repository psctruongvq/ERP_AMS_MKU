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
//09/04/2013
namespace PSC_ERP
{
    public partial class FrmKetChuyenKhoTheoKy : DevExpress.XtraEditors.XtraForm
    {
        int _maKy = 0;
        int _maKho = 0;
        DateTime _ngayKetThuc;
        string _dienGiai = "";
        bool _kiemTraKhoKC = false;//Ky Nay da Ket chuyen
        int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        private bool KiemTraKhoaSo(DateTime ngayKetThucKy)
        {

            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(ngayKetThucKy);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show(this, "Đã khóa sổ, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;

        }

        private bool KiemTraPhieuNhapThangChuaXuat(int maKho, DateTime ngay)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraPhieuNhapThangChuaXuat_ThucHienKetChuyenVatTu";
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    cm.Parameters.AddWithValue("@NgayNX", ngay);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }
        private bool KiemTraRangBuoc(int maKho, DateTime ngay)
        {
            if (KiemTraPhieuNhapThangChuaXuat(maKho, ngay))
            {
                MessageBox.Show(this, "Còn phiếu nhập thẳng vẫn chưa xuất, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        //Load Form
        private void _loadForm()
        {
            KyListbindingSource.DataSource = KyList.GetKyList();
            // khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();
            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoVatTuList();
        }
        public FrmKetChuyenKhoTheoKy()
        {
            InitializeComponent();
            KyListbindingSource.DataSource = typeof(KyList);
            khoBQVTListBindingSource.DataSource = typeof(KhoBQ_VTList);
        }

        private void FrmKetChuyenKhoTheoKy_Load(object sender, EventArgs e)
        {
            _loadForm();
        }

        private void btn_KetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridLookUpEdit_KyKetchuyen.EditValue == null)
            {
                MessageBox.Show("Nhập vào Kỳ Cần Kết Chuyển!", "Yêu Cầu");
                gridLookUpEdit_KyKetchuyen.Focus();

            }
            else
            {
                if (gridLookUpEdit_KhoKetChuyen.EditValue == null)
                {
                    MessageBox.Show("Nhập vào Kho Cần Kết Chuyển!", "Yêu Cầu");
                    gridLookUpEdit_KhoKetChuyen.Focus();
                }
                else
                {
                    _maKy = (int)gridLookUpEdit_KyKetchuyen.EditValue;
                    _maKho = (int)gridLookUpEdit_KhoKetChuyen.EditValue;
                    if (txt_DienGiai.EditValue != null)
                    {
                        _dienGiai = (string)txt_DienGiai.EditValue;
                    }
                    //
                    try
                    {
                        using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                        {
                            cn.Open();
                            using (SqlCommand cm = cn.CreateCommand())
                            {
                                cm.CommandType = CommandType.StoredProcedure;
                                cm.CommandText = "Spd_KiemTraKetChuyenKhoTheoKy";
                                cm.Parameters.AddWithValue("@maKy", _maKy);
                                cm.Parameters.AddWithValue("@maKho", _maKho);
                                SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 2);
                                prmGiaTriTraVe.Direction = ParameterDirection.Output;
                                cm.Parameters.Add(prmGiaTriTraVe);
                                cm.ExecuteNonQuery();
                                _kiemTraKhoKC = (bool)prmGiaTriTraVe.Value;
                            }
                            if (_kiemTraKhoKC)
                            {
                                if (KiemTraRangBuoc(_maKho, KyKetChuyenTonKho.GetNgayKetThucCuaKy(_maKy).Date))
                                {
                                    //
                                    using (SqlCommand cm1 = cn.CreateCommand())
                                    {
                                        cm1.CommandType = CommandType.StoredProcedure;
                                        cm1.CommandText = "Spd_KetChuyenKhoTheoKy";
                                        cm1.Parameters.AddWithValue("@maKy", _maKy);
                                        cm1.Parameters.AddWithValue("@maKho", _maKho);
                                        cm1.Parameters.AddWithValue("@DienGiai", _dienGiai);
                                        cm1.ExecuteNonQuery();
                                    }
                                    MessageBox.Show("Kết Chuyển Thành Công!", "Thông Báo");
                                    //
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kho đã Kết Chuyển trong kỳ này! Nếu muốn Kết Chuyển lại thì hãy hủy Kết Chuyển cũ", "Thông Báo");
                            }

                        }//us
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //

                }//END Else
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_HuyKetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridLookUpEdit_KyKetchuyen.EditValue == null)
            {
                MessageBox.Show("Nhập vào Kỳ Cần Hủy Kết Chuyển!", "Yêu Cầu");
                gridLookUpEdit_KyKetchuyen.Focus();

            }
            else
            {
                if (gridLookUpEdit_KhoKetChuyen.EditValue == null)
                {
                    MessageBox.Show("Nhập vào Kho Cần Hủy Kết Chuyển!", "Yêu Cầu");
                    gridLookUpEdit_KhoKetChuyen.Focus();
                }
                else
                {
                    _maKy = (int)gridLookUpEdit_KyKetchuyen.EditValue;
                    _maKho = (int)gridLookUpEdit_KhoKetChuyen.EditValue;
                    _ngayKetThuc = KyKetChuyenTonKho.GetNgayKetThucCuaKy(_maKy).Date;
                    if (KiemTraKhoaSo(_ngayKetThuc))
                    {
                        if (KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_ngayKetThuc, _maKho) == false)
                        {
                            //
                            DialogResult kq = MessageBox.Show("Bạn chắc hủy kết chuyển cũ?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (kq == DialogResult.Yes)
                            {


                                try
                                {
                                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                                    {
                                        cn.Open();
                                        using (SqlCommand cm = cn.CreateCommand())
                                        {
                                            cm.CommandType = CommandType.StoredProcedure;
                                            cm.CommandText = "Spd_HuyKetChuyenKhoTheoKy";
                                            cm.Parameters.AddWithValue("@maKy", _maKy);
                                            cm.Parameters.AddWithValue("@maKho", _maKho);
                                            cm.ExecuteNonQuery();

                                        }

                                    }//us
                                    MessageBox.Show("Đã Hủy Kết Chuyển Cũ Thành Công!", "Thông Báo");
                                }
                                catch
                                {
                                    MessageBox.Show("Hủy Kết Chuyển Cũ Không Thành Công!", "Thông Báo");
                                }

                            }
                            //
                        }
                        else
                        {
                            string tenKho = KhoBQ_VT.GetKhoBQ_VT(_maKho, maCongTy).TenKho;
                            MessageBox.Show(string.Format("{0} Đã Kết Chuyển Sang Kỳ Sau. Không Thể Hủy!", tenKho), "Thông Báo");
                        }
                    }//Kiem tra Khoa So
                }
            }
        }

        private void gridLookUpEdit_KyKetchuyen_EditValueChanged(object sender, EventArgs e)
        {
            _maKy = (int)gridLookUpEdit_KyKetchuyen.EditValue;
        }

        private void gridLookUpEdit_KhoKetChuyen_EditValueChanged(object sender, EventArgs e)
        {
            _maKho = (int)gridLookUpEdit_KhoKetChuyen.EditValue;
        }

        private void txt_DienGiai_EditValueChanged(object sender, EventArgs e)
        {
            _dienGiai = (string)txt_DienGiai.EditValue;
        }

    }
}
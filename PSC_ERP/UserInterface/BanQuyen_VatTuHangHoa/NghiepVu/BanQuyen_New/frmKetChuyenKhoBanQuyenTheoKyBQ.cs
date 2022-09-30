using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
//03/04/2014
namespace PSC_ERP
{
    public partial class frmKetChuyenKhoBanQuyenTheoKyBQ : DevExpress.XtraEditors.XtraForm
    {
        KhoBQ_VTList _khoBQ_VTList;
        BoPhanList _boPhanList = null;
        int _maKy = 0;
        int _maKho = 0;
        DateTime _ngayKetThuc;
        //int _maBoPhan = 0;
        string _dienGiai = "";
        bool _kiemTraKhoKC = false;//Ky Nay da Ket chuyen
        bool _kiemTraBoPhanKC = false;
        //Load Form
        private void _loadForm()
        {
            KyListbindingSource.DataSource = KyList.GetKyList();
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(1);
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;
            gridLookUpEdit_KhoKetChuyen.EditValue = (object)_khoBQ_VTList[0].MaKho;
            //boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();
            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            boPhanListBindingSource.DataSource = _boPhanList;

            Utils.GridUtils.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.gridView_BoPhan, this.colChon);
            Utils.GridUtils.SetSTTForGridView(this.gridView_BoPhan, 35);
        }
        public frmKetChuyenKhoBanQuyenTheoKyBQ()
        {
            InitializeComponent();
            KyListbindingSource.DataSource = typeof(KyList);
            khoBQVTListBindingSource.DataSource = typeof(KhoBQ_VTList);
            boPhanListBindingSource.DataSource = typeof(BoPhanList);
        }

        private void frmKetChuyenKhoBanQuyenTheoKy_Load(object sender, EventArgs e)
        {
            _loadForm();
        }

        private void gridLookUpEdit_Ky_EditValueChanged(object sender, EventArgs e)
        {
            _maKy = (int)gridLookUpEdit_Ky.EditValue;
            _ngayKetThuc=KetChuyenTonKhoBanQuyen.GetNgayKetThucCuaKy(_maKy).Date;
        }

        private void gridLookUpEdit_KhoKetChuyen_EditValueChanged(object sender, EventArgs e)
        {
            _maKho = (int)gridLookUpEdit_KhoKetChuyen.EditValue;
        }

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


        #region btn_KetChuyen
        private void btn_KetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (gridLookUpEdit_Ky.EditValue == null)

            if (_maKy == 0)
            {
                MessageBox.Show("Nhập vào Kỳ Cần Kết Chuyển!", "Yêu Cầu");
                gridLookUpEdit_Ky.Focus();

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
                    Boolean coChonBoPhan = false;
                    foreach (BoPhan item in _boPhanList)
                    {
                        if (item.Chon == true)
                        {
                            coChonBoPhan = true;
                            break;
                        }
                    }
                    if (coChonBoPhan == false)
                    {
                        MessageBox.Show("Chọn phòng ban cần kết chuyển!", "Yêu Cầu");
                        this.gridBoPhan.Focus();//gridLookUpEdit_BoPhanKetChuyen.Focus();
                    }
                    else//Khi DS Bo Phan chon k rong
                    {
                        StringBuilder dsBPdaKetChuyen = new StringBuilder("");
                        StringBuilder dsBPchuaKetChuyen = new StringBuilder("");


                        foreach (BoPhan pb in _boPhanList)
                        {
                            if (pb.Chon == true)
                            {
                                int _maBoPhan = pb.MaBoPhan;//(int)gridLookUpEdit_BoPhanKetChuyen.EditValue;
                                //
                                _maKy = (int)gridLookUpEdit_Ky.EditValue; 
                                _ngayKetThuc = KetChuyenTonKhoBanQuyen.GetNgayKetThucCuaKy(_maKy).Date;
                                _maKho = (int)gridLookUpEdit_KhoKetChuyen.EditValue;
                                // _maBoPhan = (int)gridLookUpEdit_BoPhan.EditValue;

                                try
                                {
                                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                                    {
                                        cn.Open();
                                        //Kiem Tra Bo Phan
                                        using (SqlCommand cm = cn.CreateCommand())
                                        {
                                            cm.CommandType = CommandType.StoredProcedure;
                                            cm.CommandText = "Spd_KiemTraBoPhanKetChuyenBanQuyenTheoKy";
                                            cm.Parameters.AddWithValue("@maKy", _maKy);
                                            cm.Parameters.AddWithValue("@maKho", _maKho);
                                            cm.Parameters.AddWithValue("@maBoPhan", _maBoPhan);
                                            cm.Parameters.AddWithValue("@laKetChuyen", 1);
                                            SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 2);
                                            prmGiaTriTraVe.Direction = ParameterDirection.Output;
                                            cm.Parameters.Add(prmGiaTriTraVe);
                                            cm.ExecuteNonQuery();
                                            _kiemTraBoPhanKC = (bool)prmGiaTriTraVe.Value;
                                        }


                                        if (_kiemTraBoPhanKC)
                                        {
                                            //Kiem Tra Kho
                                            using (SqlCommand cm = cn.CreateCommand())
                                            {
                                                cm.CommandType = CommandType.StoredProcedure;
                                                cm.CommandText = "Spd_KiemTraKetChuyenKhoBanQuyenTheoKy";
                                                cm.Parameters.AddWithValue("@maKy", _maKy);
                                                cm.Parameters.AddWithValue("@maKho", _maKho);
                                                cm.Parameters.AddWithValue("@maBoPhan", _maBoPhan);
                                                SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 2);
                                                prmGiaTriTraVe.Direction = ParameterDirection.Output;
                                                cm.Parameters.Add(prmGiaTriTraVe);
                                                cm.ExecuteNonQuery();
                                                _kiemTraKhoKC = (bool)prmGiaTriTraVe.Value;
                                            }

                                            if (_kiemTraKhoKC)
                                            {
                                                using (SqlCommand cm1 = cn.CreateCommand())
                                                {
                                                    cm1.CommandType = CommandType.StoredProcedure;
                                                    cm1.CommandText = "Spd_KetChuyenKhoBanQuyenTheoKy_New";
                                                    cm1.Parameters.AddWithValue("@maKy", _maKy);
                                                    cm1.Parameters.AddWithValue("@maKho", _maKho);
                                                    cm1.Parameters.AddWithValue("@maBoPhan", _maBoPhan);
                                                    cm1.Parameters.AddWithValue("@DienGiai", _dienGiai);
                                                    cm1.ExecuteNonQuery();
                                                }
                                                //MessageBox.Show(string.Format("Kết Chuyển [{0}] Thành Công!", pb.TenBoPhan), "Thông Báo");
                                                dsBPchuaKetChuyen.Append(string.Format("{0},", pb.TenBoPhan));
                                            }
                                            else
                                            {
                                                //MessageBox.Show(string.Format("[{0}] đã Kết Chuyển trong kỳ này! Nếu muốn Kết Chuyển lại thì hãy hủy Kết Chuyển cũ", pb.TenBoPhan), "Thông Báo");
                                                dsBPdaKetChuyen.Append(string.Format("{0},", pb.TenBoPhan));
                                            }
                                        }
                                        //

                                    }//us
                                }
                                catch (SqlException ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                                //
                            }
                        }
                        //Show cau thong bao


                        if (dsBPchuaKetChuyen.Length > 1)
                        {
                            dsBPchuaKetChuyen.Remove(dsBPchuaKetChuyen.Length - 1, 1);
                            MessageBox.Show(string.Format("Kết Chuyển [{0}] Thành Công!", dsBPchuaKetChuyen), "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        if (dsBPdaKetChuyen.Length > 1)
                        {
                            dsBPdaKetChuyen.Remove(dsBPdaKetChuyen.Length - 1, 1);
                            MessageBox.Show(string.Format("[{0}] đã Kết Chuyển trong kỳ này! Nếu muốn Kết Chuyển lại thì hãy hủy Kết Chuyển cũ", dsBPdaKetChuyen), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }//END Else
            }
        }
        #endregion //END btn_KetChuyen
        #region btn_HuyKetChuyen
        private void btn_HuyKetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (gridLookUpEdit_Ky.EditValue == null)
            if (_maKy == 0)
            {
                MessageBox.Show("Nhập vào Kỳ Cần Hủy Kết Chuyển!", "Yêu Cầu");
                gridLookUpEdit_Ky.Focus();
                return;

            }
             
            else
            {
                Ky ky = Ky.GetKy(_maKy);
                if (ky.NgayBatDau.Month == 1 && ky.NgayBatDau.Year == 2014)
                {
                    MessageBox.Show("Không thể hủy kết chuyển kỳ tháng 1/2014");
                    return;
                }
                if (gridLookUpEdit_KhoKetChuyen.EditValue == null)
                {
                    MessageBox.Show("Nhập vào Kho Cần Hủy Kết Chuyển!", "Yêu Cầu");
                    gridLookUpEdit_KhoKetChuyen.Focus();
                    return;
                }

                else
                {
                    Boolean coChonBoPhan = false;
                    foreach (BoPhan item in _boPhanList)
                    {
                        if (item.Chon == true)
                        {
                            coChonBoPhan = true;
                            break;
                        }
                    }
                    if (coChonBoPhan == false)
                    {
                        MessageBox.Show("Chọn Phòng Ban Cần Hủy Kết Chuyển!", "Yêu Cầu");
                        this.gridBoPhan.Focus();
                    }
                    else
                    {
                        if (KiemTraKhoaSo(_ngayKetThuc))
                        {

                            //
                            DialogResult kq = MessageBox.Show("Bạn chắc hủy kết chuyển cũ?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                            if (kq == DialogResult.Yes)
                            {
                                StringBuilder dsBPHuyKetChuyenT = new StringBuilder("");
                                StringBuilder dsBPHuyKetChuyenF = new StringBuilder("");
                                foreach (BoPhan pb in _boPhanList)
                                {
                                    if (pb.Chon == true)
                                    {
                                        int _maBoPhan = pb.MaBoPhan;

                                        _maKy = (int)gridLookUpEdit_Ky.EditValue;
                                        _ngayKetThuc = KetChuyenTonKhoBanQuyen.GetNgayKetThucCuaKy(_maKy).Date;
                                        _maKho = (int)gridLookUpEdit_KhoKetChuyen.EditValue;
                                        try
                                        {
                                            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                                            {
                                                cn.Open();
                                                //Kiem Tra Bo Phan
                                                using (SqlCommand cm = cn.CreateCommand())
                                                {
                                                    cm.CommandType = CommandType.StoredProcedure;
                                                    cm.CommandText = "Spd_KiemTraBoPhanKetChuyenBanQuyenTheoKy";
                                                    cm.Parameters.AddWithValue("@maKy", _maKy);
                                                    cm.Parameters.AddWithValue("@maKho", _maKho);
                                                    cm.Parameters.AddWithValue("@maBoPhan", _maBoPhan);
                                                    cm.Parameters.AddWithValue("@laKetChuyen", 0);
                                                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 2);
                                                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                                                    cm.Parameters.Add(prmGiaTriTraVe);
                                                    cm.ExecuteNonQuery();
                                                    _kiemTraBoPhanKC = (bool)prmGiaTriTraVe.Value;
                                                }

                                                if (_kiemTraBoPhanKC)
                                                {
                                                    if (KetChuyenTonKhoBanQuyenBQ.KiemTraKetChuyenBanQuyen_PhucVuNXvaHuyKetChuyen(_ngayKetThuc, _maKho, _maBoPhan) == false)
                                                    {
                                                        //xuly Huy
                                                        try
                                                        {
                                                            using (SqlCommand cm = cn.CreateCommand())
                                                            {
                                                                cm.CommandType = CommandType.StoredProcedure;
                                                                cm.CommandText = "Spd_HuyKetChuyenKhoBanQuyenTheoKy";
                                                                cm.Parameters.AddWithValue("@maKy", _maKy);
                                                                cm.Parameters.AddWithValue("@maKho", _maKho);
                                                                cm.Parameters.AddWithValue("@maBoPhan", _maBoPhan);
                                                                cm.ExecuteNonQuery();

                                                            }
                                                            //MessageBox.Show(string.Format("[{0}] Đã Hủy Kết Chuyển Cũ Thành Công!", pb.TenBoPhan), "Thông Báo");
                                                            dsBPHuyKetChuyenT.Append(string.Format("{0},", pb.TenBoPhan));
                                                        }
                                                        catch
                                                        {
                                                            //MessageBox.Show(string.Format("[{0}] Hủy Kết Chuyển Cũ Thất Bại!", pb.TenBoPhan), "Thông Báo");
                                                            dsBPHuyKetChuyenF.Append(string.Format("{0},", pb.TenBoPhan));

                                                        }
                                                        //End xuly Huy
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show(string.Format("[{0}] Đã Kết Chuyển Cho Kỳ Sau! Không Thể Hủy", pb.TenBoPhan), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    }
                                                }

                                            }//us

                                        }
                                        catch
                                        {
                                            MessageBox.Show("Cập Nhật Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                if (dsBPHuyKetChuyenT.Length > 1)
                                {
                                    dsBPHuyKetChuyenT.Remove(dsBPHuyKetChuyenT.Length - 1, 1);
                                    MessageBox.Show(string.Format("[{0}] Đã Hủy Kết Chuyển Cũ Thành Công!", dsBPHuyKetChuyenT), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                if (dsBPHuyKetChuyenF.Length > 1)
                                {
                                    dsBPHuyKetChuyenT.Remove(dsBPHuyKetChuyenT.Length - 1, 1);
                                    MessageBox.Show(string.Format("[{0}] Hủy Kết Chuyển Cũ Thất Bại!", dsBPHuyKetChuyenF), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            //
                        }
                    }
                }
            }
        }
        #endregion //END btn_HuyKetChuyen

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void CheckEdit_Chon_EditValueChanged(object sender, EventArgs e)
        {
            BoPhan _bp = (BoPhan)boPhanListBindingSource.Current;
            CheckEdit ch = (CheckEdit)sender;
            _bp.Chon = (bool)ch.EditValue;
        }



    }
}
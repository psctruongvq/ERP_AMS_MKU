using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;

namespace PSC_ERP
{
    public partial class FrmPhatSinhSoHopDong : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        DoiTacList _DoiTacList;
        DoiTac _DoiTac;
        BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();

        HopDongThuChi _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
        //private byte _tinhTrang = 1;//xac dinh bat dau van hanh phan he Hop Dong

        //--


        #endregion

        public FrmPhatSinhSoHopDong()
        {
            InitializeComponent();
            KhoiTao();
            //KhoiTaoHopDong();
        }

        public FrmPhatSinhSoHopDong(HopDongThuChi hopDongThuChi)
        {
            InitializeComponent();
            KhoiTao();
            _HopDongMuaBan = hopDongThuChi;
            BindingData();
        }

        #region
        private void SetGiaTriMacDinhHopDong()
        {
            _HopDongMuaBan.HDTrongNgoaiDai = false;//la Hop Dong Trong Dai
            //_HopDongMuaBan.MaNguoiKy = 14354;//Người đại diện hợp đồng mặc định là "Cao Anh MInh"
            //_HopDongMuaBan.TinhTrang = _tinhTrang;
        }

        private bool SetSoHopDongTrongDai()
        {
            if (_HopDongMuaBan.IsNew)
            {
                //_HopDongMuaBan.SoHopDong = HopDongMuaBan.SetSoHopDongTrongDai(_HopDongMuaBan.NgayLap);
                txt_SoHopDong.Text = HopDongThuChi.SetSoHopDongTrongDai(_HopDongMuaBan.NgayKy.Value.Date);
                _HopDongMuaBan.SoHopDong = txt_SoHopDong.Text;

            }

            return true;
        }

        private bool KiemTraDuLieu()
        {
            bool kq = true;

            if (_HopDongMuaBan.SoHopDong.Trim().Length == 0)
            {
                MessageBox.Show(this, "vui lòng nhập vào Số Hợp Đồng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoHopDong.Focus();
                return false;
            }
            
            return kq;

        }

        private bool KiemTraSoHopDongHopLe()
        {
            string sohopdong = txt_SoHopDong.Text.Trim();
            if (!_HopDongMuaBan.HDTrongNgoaiDai)//Là HĐ trong đài
            {
                int soTTHD;
                if (!int.TryParse(sohopdong.Substring(0, 3), out soTTHD))
                {
                    MessageBox.Show("Số hợp đồng không hợp lệ! 3 ký tự đầu phải là số!");
                    txt_SoHopDong.Focus();
                    return false;
                }

            }
            
            if (HopDongThuChi.KiemTraTrungSoHopDong(_HopDongMuaBan.MaHopDong, sohopdong))
            {
                MessageBox.Show("Trùng số hợp đồng! Vui lòng chỉnh lại!");
                txt_SoHopDong.Focus();
                return false;
            }

            return true;
        }

        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                    if (KiemTraSoHopDongHopLe())
                    {
                        _HopDongMuaBan.ApplyEdit();
                        HopDongMuaBanBindingSource.EndEdit();
                        _HopDongMuaBan.Save();
                    }
                    else
                    {
                        kq = false;
                    }
               
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }

        private bool KiemTraRangBuocTruocKhiXoa()
        {
            HopDongThuChi hdCheck = HopDongThuChi.GetHopDongMuaBanWithoutChild(_HopDongMuaBan.MaHopDong);
            if (hdCheck.MaLoaiHopDong != 0)//hop dong da duoc lap
            {
                MessageBox.Show(this, "Hợp đồng phát sinh này đã được lập, Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BindingData()
        {
            HopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;
        }

        private void KhoiTao()
        {


            //NguoiDaiDienList_bindingSource.DataSource = TenNhanVienList.GetTenNhanVienList_NguoiDaiDienHopDong();
            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();
            _DoiTacList = DoiTacList.GetDoiTacList("", 0);
            doiTacListBindingSource.DataSource = _DoiTacList;


            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;
            //
        }


        private void KhoiTaoHopDong()
        {

            _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
            SetGiaTriMacDinhHopDong();
            SetSoHopDongTrongDai();
            BindingData();

        }
        #endregion

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoHopDong();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            if (KiemTraDuLieu())
            {
                if (MessageBox.Show(this, "Bạn Muốn Lưu Dữ Liệu", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (LuuDuLieu() == true)
                    {
                        MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            //E
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraRangBuocTruocKhiXoa())
            {
                if (MessageBox.Show("Bạn có muốn xóa Hợp đồng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HopDongThuChi.DeleteHopDongThuChi(_HopDongMuaBan.MaHopDong);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
                        {
                            SetGiaTriMacDinhHopDong();
                        }
                        BindingData();
                    }
                    catch
                    {
                        MessageBox.Show(this, "Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }



    }
}
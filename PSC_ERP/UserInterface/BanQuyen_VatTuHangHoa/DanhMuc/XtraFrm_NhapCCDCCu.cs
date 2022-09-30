using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.Data;
using System.IO;
using System.Data.OleDb;
using PSC_ERP_Common;
//08_04_13

namespace PSC_ERP
{
    public partial class XtraFrm_NhapCCDCCu : XtraForm
    {

        #region Properties and Methods
        private int _maCCDC = 0;
        HangHoaBQ_VT _congCuDungcu;
        HangHoaBQ_VTList _CCDCList;
        CCDC _congCuDungCuCaBiet;
        CCDCList _congCuDungCuList = CCDCList.NewCongCuDungCuList();
        bool themMoi = false;
        int maPhongBan = 0;
        #endregion //Properties and Methods
        private void LoadForm()
        {
            _CCDCList = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            bs_DSHangHoaListAll.DataSource = _CCDCList;
        }
        public XtraFrm_NhapCCDCCu()
        {
            InitializeComponent();
            LoadForm();
        }
        public XtraFrm_NhapCCDCCu(HangHoaBQ_VT congCuDungCu)
        {
            InitializeComponent();
            _congCuDungcu = congCuDungCu;
            _congCuDungCuCaBiet = CCDC.NewCongCuDungCu(true);
            themMoi = true;
            LoadForm();
            _congCuDungCuCaBiet.MaQuanLy = LayMaQuanLyMoi();
            _congCuDungCuCaBiet.MaHangHoa = congCuDungCu.MaHangHoa;
            _congCuDungCuCaBiet.LaCCDCCu = true;
        }
        public XtraFrm_NhapCCDCCu(CCDC CCDCCaBiet)
        {
            InitializeComponent();
            _congCuDungCuCaBiet = CCDCCaBiet;
            themMoi = false;
            LoadForm();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            Int32 soLuong = (Int32)numSoLuong.Value;
            if (soLuong < 1)
            {
                DialogUtil.ShowWarning("Số lượng nhỏ nhất là 1!\nVui lòng nhập lại số lượng!");
                return;
            }
            if (lookUpEdit_PhongBan.EditValue == null || lookUpEdit_PhongBan.EditValue == "" || lookUpEdit_PhongBan.EditValue == String.Empty)
            {
                DialogUtil.ShowWarning("Phòng ban hiện tại không được trống!\nVui lòng chọn phòng ban hiện tại!");
                return;
            }
            maPhongBan = (Int32)lookUpEdit_PhongBan.EditValue;
            String maxSoHieu = _congCuDungCuCaBiet.MaQuanLy;
            int thuTuMaQuanLyCCDC = Convert.ToInt32(maxSoHieu.Substring(maxSoHieu.Length - 4));
            string maQuanLyCCDC = _congCuDungcu.MaQuanLy;
            Int32 size = 4;
            if (themMoi)
            {
                using (DialogUtil.Wait("Đang lưu dữ liệu!", "Vui lòng đợi"))
                {
                    for (int i = 0; i < soLuong; i++)
                    {
                        if (i > 0)
                        {
                            CCDC congCuCaBietCopy = CCDC.NewCongCuDungCu(true);
                            congCuCaBietCopy.ViTri = _congCuDungCuCaBiet.ViTri;
                            congCuCaBietCopy.MaHangHoa = _congCuDungCuCaBiet.MaHangHoa;
                            congCuCaBietCopy.NguyenGia = _congCuDungCuCaBiet.NguyenGia;
                            congCuCaBietCopy.NgayNhan = _congCuDungCuCaBiet.NgayNhan;
                            congCuCaBietCopy.LaCCDCCu = _congCuDungCuCaBiet.LaCCDCCu;
                            congCuCaBietCopy.ThoiGianSuDung = _congCuDungCuCaBiet.ThoiGianSuDung;
                            congCuCaBietCopy.ThoiGianDaPhanBo = _congCuDungCuCaBiet.ThoiGianDaPhanBo;
                            congCuCaBietCopy.TaiKhoanChoPhanBo = _congCuDungCuCaBiet.TaiKhoanChoPhanBo;
                            congCuCaBietCopy.TaiKhoanChiPhi = _congCuDungCuCaBiet.TaiKhoanChiPhi;
                            congCuCaBietCopy.MoTaTenCCDC = _congCuDungCuCaBiet.MoTaTenCCDC;
                            congCuCaBietCopy.NgayNhan = _congCuDungCuCaBiet.NgayNhan;
                            congCuCaBietCopy.NgayBDHoatDong = _congCuDungCuCaBiet.NgayBDHoatDong;
                            congCuCaBietCopy.ChiPhiPBLanDau = _congCuDungCuCaBiet.ChiPhiPBLanDau;
                            congCuCaBietCopy.ChiPhiDaPhanBo = _congCuDungCuCaBiet.ChiPhiDaPhanBo;
                            thuTuMaQuanLyCCDC = thuTuMaQuanLyCCDC + 1;
                            String phanTangStr = new String('0', size - thuTuMaQuanLyCCDC.ToString().Length) + thuTuMaQuanLyCCDC.ToString();
                            congCuCaBietCopy.MaQuanLy = maQuanLyCCDC + phanTangStr;                         
                            congCuCaBietCopy.ApplyEdit();                          
                            congCuCaBietCopy.Save();
                        }
                        else
                        {
                            _congCuDungCuCaBiet.CongCuDungCu_PhongBan.MaBoPhan = maPhongBan;                  
                            _congCuDungCuCaBiet.ApplyEdit();
                            _congCuDungCuCaBiet.Save();                          
                        }
                    }
                }
            }
          
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private string LayMaQuanLyMoi()
        {
            String maxSoHieu = "";
            int thuTuMaQuanLyCCDC;
            string maQuanLyCCDC = "";
            string maQuanLy = "";

            CCDC ccdc = CCDC.GetCongCuDungCuByMaHangHoa(_congCuDungcu.MaHangHoa);
            if (ccdc != null)
                maxSoHieu = ccdc.MaQuanLy;
            if (String.IsNullOrWhiteSpace(maxSoHieu) == false)
            {
                thuTuMaQuanLyCCDC = Convert.ToInt32(maxSoHieu.Substring(maxSoHieu.Length - 4)) + 1;//tang len 1 don vi               
            }
            else
            {
                thuTuMaQuanLyCCDC = 1;//cong cu dau tien thuoc hang hoa               
            }
            maQuanLy = _congCuDungcu.MaQuanLy;
            Int32 size = 4;
            String phanTangStr = new String('0', size - thuTuMaQuanLyCCDC.ToString().Length) + thuTuMaQuanLyCCDC.ToString();
            maQuanLyCCDC = maQuanLy + phanTangStr;
            return maQuanLyCCDC;
        }

        private void XtraFrm_NhapCCDCCu_Load(object sender, EventArgs e)
        {
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            bindingSource_CongCuDungCuCaBiet.DataSource = _congCuDungCuCaBiet;
            lbl_SoLuong.Visible = numSoLuong.Visible = themMoi;
            if (themMoi)
                btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            else
                btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void XtraFrm_NhapCCDCCu_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
    }
}
using DevExpress.XtraEditors;
using ERP_Library;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.UserInterface.NhanSu.ThongTinNhanVienE
{
    public partial class frmThongTinNhanVienE : XtraForm
    {

        #region Files
        static ThongTinNhanVienTongHopList _thongTinNhanVienTongHopList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        static tblnsNhanVien _NhanVien;
        NhanVien_Factory nhanVien_Factory = NhanVien_Factory.New();

        List<tblnsTrinhDo> trinhDoNhanVien = new List<tblnsTrinhDo>();
        List<tblnsNhanVien_NgoaiNgu> trinhDoNgoaiNgu = new List<tblnsNhanVien_NgoaiNgu>();
        String trinhDoNgoaiNgu_NhanVien = "";
        #endregion

        #region Contructor
        public frmThongTinNhanVienE()
        {
            InitializeComponent();
        }
        public frmThongTinNhanVienE(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }

        public frmThongTinNhanVienE(ThongTinNhanVienTongHop thongTinNhanVienTongHop, ThongTinNhanVienTongHopList _thongTinNhanVienTongHopList)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
            frmThongTinNhanVienE._thongTinNhanVienTongHopList = _thongTinNhanVienTongHopList;
        }
        #endregion

        private void frmThongTinNhanVienE_Load(object sender, EventArgs e)
        {
            #region phòng ban _ ban
            List<tblnsBoPhan> boPhan_Ban_List = BoPhan_Factory.New().GetAll().ToList();
            bindingSource__BoPhan_Ban.DataSource = boPhan_Ban_List;
            #endregion

            #region loại nhân viên
            List<tblnsNhanVien_Loai> nhanVien_LoaiList = NhanVien_Loai_Factory.New().GetAll().ToList();
            bindingSource_LoaiNhanVien.DataSource = nhanVien_LoaiList;
            #endregion

            #region chức vụ nhân viên
            List<tblnsChucVu> chucVuList = ChucVu_Factory.New().GetAll().ToList();
            chucVuListBindingSource.DataSource = chucVuList;
            #endregion

            #region chức danh nhân viên
            List<tblnsChucDanh> chucDanhList = ChucDanh_Factory.New().GetAll().ToList();
            ChucDanh_BindingSource.DataSource = chucDanhList;
            #endregion

            #region tỉnh thành nơi sinh
            List<tblTinhThanh> tinhThanhNoiSinhList = TinhThanh_Factory.New().GetAll().ToList();
            NoiSinhTinhThanh_bindingSource.DataSource = tinhThanhNoiSinhList;
            #endregion

            #region tỉnh thành quê quán
            List<tblTinhThanh> tinhThanhQueQuanList = TinhThanh_Factory.New().GetAll().ToList();
            TinhThanhQueQuan_bindingSource.DataSource = tinhThanhQueQuanList;
            #endregion

            #region tỉnh thành nơi cấp CMND
            List<tblTinhThanh> tinhThanhQNoiCapCMNDList = TinhThanh_Factory.New().GetAll().ToList();
            bindingSource_TinhThanhNoiCapCMND.DataSource = tinhThanhQNoiCapCMNDList;
            #endregion

            #region tôn giáo
            List<tblnsTonGiao> tonGiaoList = TonGiao_Factory.New().GetAll().ToList();
            //tblnsTonGiao tonGiao_chonTatCa = new tblnsTonGiao() { MaTonGiao = 0, MaQuanLy = "<<Tất cả>>", TenTonGiao = "<<Tất cả>>" };
            //tonGiaoList.Insert(0, tonGiao_chonTatCa);
            tonGiaoListBindingSource.DataSource = tonGiaoList;
            #endregion

            #region dân tộc
            List<tblnsDanToc> danTocList = DanToc_Factory.New().GetAll().ToList();
            danTocListBindingSource.DataSource = danTocList;
            #endregion

            #region ưu tiên bản thân
            List<tblnsUuTienBanThan> uuTienBanThanList = UuTienBanThan_Factory.New().GetAll().ToList();
            bindingSource_UuTienBanThan.DataSource = uuTienBanThanList;
            #endregion

            #region ưu tiên gia đình
            List<tblnsUuTienGiaDinh> uuTienGiaDinhList = UuTienGiaDinh_Factory.New().GetAll().ToList();
            bindingSource_UuTienGiaDinh.DataSource = uuTienGiaDinhList;
            #endregion

            #region thành phần gia đình
            List<tblnsThanhPhanGiaDinh> thanhPhanGiaDinhList = ThanhPhanGiaDinh_Factory.New().GetAll().ToList();
            bindingSource_ThanhPhanGiaDinh.DataSource = thanhPhanGiaDinhList;
            #endregion

            #region quốc tịch
            List<tblQuocGia> quocGiaList = QuocGia_Factory.New().GetAll().ToList();
            quocGiaListBindingSource.DataSource = quocGiaList;
            #endregion

            #region trình độ học vấn
            List<tblnsTrinhDoHocVan> trinhDoHocVanList = TrinhDoHocVan_Factory.New().GetAll().ToList();
            bindingSource_TrinhDoHocVan.DataSource = trinhDoHocVanList;
            #endregion

            #region trình độ tin học
            List<tblnsTrinhDoTinHoc> trinhDoTinHocList = TrinhDoTinHoc_Factory.New().GetAll().ToList();
            bindingSource_TrinhDoTinHoc.DataSource = trinhDoTinHocList;
            #endregion

            #region trình độ ngoại ngữ
            List<tblnsTrinhDoNgoaiNgu> trinhDoNgoaiNguList = TrinhDoNgoaiNgu_Factory.New().GetAll().ToList();
            bindingSource_TrinhDoNgoaiNgu.DataSource = trinhDoNgoaiNguList;
            #endregion

            #region nhóm ngạch lương cơ bản
            List<tblnsNhomNgachLuongCoBan> nhomNgachLuongCoBanList = NhomNgachLuongCoBan_Factory.New().GetAll().ToList();
            bindingSource_NhomNgachLuongCoBan.DataSource = nhomNgachLuongCoBanList;
            #endregion

            #region ngạch lương cơ bản
            List<tblnsNgachLuongCoBan> ngachLuongCoBanList = NgachLuongCoBan_Factory.New().GetAll().ToList();
            bindingSource_NgachLuongCoBan.DataSource = ngachLuongCoBanList;
            #endregion

            #region bậc lương cơ bản
            List<tblnsBacLuongCoBan> bacLuongCoBanList = BacLuong_Factory.New().GetAll().ToList();
            bindingSource_BacLuong.DataSource = bacLuongCoBanList;
            #endregion

            #region nhóm ngạch lương bảo hiểm
            List<tblnsNhomNgachLuongCoBan> nhomNgachLuongBaoHiemList = NhomNgachLuongCoBan_Factory.New().GetAll().ToList();
            bindingSource_NhomNgachLuongBH.DataSource = nhomNgachLuongBaoHiemList;
            #endregion

            #region ngạch lương bảo hiểm
            List<tblnsNgachLuongCoBan> ngachLuongBaoHiemList = NgachLuongCoBan_Factory.New().GetAll().ToList();
            bindingSource_NgachLuongBH.DataSource = ngachLuongBaoHiemList;
            #endregion

            #region bậc lương bảo hiểm
            List<tblnsBacLuongCoBan> bacLuongBaoHiemList = BacLuong_Factory.New().GetAll().ToList();
            bindingSource_BacLuongBH.DataSource = bacLuongBaoHiemList;
            #endregion
        }

        private void TimKiemNhanVien()
        {
            frmTimNhanVien _frmTimNhanVien;

            if (_thongTinNhanVienTongHopList != null)
                _frmTimNhanVien = new frmTimNhanVien(9, _thongTinNhanVienTongHopList);
            else
                _frmTimNhanVien = new frmTimNhanVien(9);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _NhanVien = nhanVien_Factory.Get_NhanVienTheoMaNhanVien(_ThongTinNhanVienTongHop.MaNhanVien);
                    nhanVienBindingSource.DataSource = _NhanVien;

                    //lấy trình độ của nhân viên:
                    trinhDoNhanVien = TrinhDo_Factory.New().GetTrinhDoByMaNhanVien(_NhanVien.MaNhanVien).ToList();
                    bindingSource_TrinhDo.DataSource = trinhDoNhanVien;

                    //lấy trình độ ngoại ngữ của nhân viên
                    trinhDoNgoaiNgu = NhanVien_NgoaiNgu_Factory.New().GetTrinhDoNgoaiNgu_ByNhanVien(_NhanVien.MaNhanVien).ToList();
                    bindingSource_NgoaiNgu_NhanVien.DataSource = trinhDoNgoaiNgu;
                    if (trinhDoNgoaiNgu.Count > 0)
                    {
                        int i=0;
                        foreach (tblnsNhanVien_NgoaiNgu nv_nn in trinhDoNgoaiNgu)
                        {
                            i++;
                            string ngoaiNgu = "";
                            ngoaiNgu = NgoaiNgu_Factory.New().GetById(nv_nn.MaNgoaiNgu.Value).TenNgoaiNgu;
                            string trinhDo = "";
                            trinhDo = TrinhDoNgoaiNgu_Factory.New().GetById(nv_nn.MaTrinhDoNN.Value).TrinhDoNgoaiNgu;
                            txt_TrinhDoNgoaiNgu.Text += i + ") " + ngoaiNgu + " " + trinhDo + (nv_nn.NgoaiNguChinh.Value?" Ngoại ngữ chính \n":"\n");

                        }
                    }
                }
                else
                {
                    DialogUtil.ShowWarning("Chưa lấy được thông tin nhân viên!");
                }
            }

        }

        private void btnTimNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimKiemNhanVien();
        }


    }
}

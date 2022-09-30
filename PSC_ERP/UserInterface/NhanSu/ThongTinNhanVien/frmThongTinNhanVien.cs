
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Threading;
using System.IO;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;


//TT_BX1
namespace PSC_ERP
{
    


    public partial class frmThongTinNhanVien : Form
    {
        #region Properties
      
      
        int _mabp = 1;
        long _maNV = 0;

        string Maqlmoinhat="";
        int maTo = 0; int maPhongBan = 0; int maBan = 0;
        static NhanVien _NhanVien;
        ChungTuGiamTruGiaCanhList _chungTuGiaCanhList;
        ChucVuList _ChucVuList;
        ChucVuList _ChucVu_QuanDoiList;
        ChucVuList _ChucVu_DangList;
        LoaiDangVienList _loaiDangVienList;
        TruongDaoTaoList _truongDaoTaoList;
        ChucVuList _ChucVu_DoanList;
        ChucVuList _ChucVu_CongDoanList;
        ChucDanhList _ChucDanhList;
        BoPhan_CauHinhHeSoList _boPhan_CauHinhList;
      
        UuTienGiaDinhList _UuTienGiaDinhList;
        UuTienBanThanList _UuTienBanThanList;
        DanToc_NVList _DanToc_NVList;
        TonGiaoList _TonGiaoList;
        QuocGiaList _QuocGiaList;
        TinhThanhList _TinhThanh_CMNDList;
        TinhThanhList _TinhThanh_ThT;
        TinhThanhList _TinhThanh_TT;
        TinhThanhList _TinhThanh_NoiSinhList;
        TinhThanhList _TinhThanh_QueQuanList;
        QuanHuyenList _QuanHuyen_NoiSinhList;
        QuanHuyenList _QuanHuyen_ThT;
        QuanHuyenList _QuanHuyen_TT;
        QuanHuyenList _QuanHuyen_QueQuanList;
       
        NhomNgachLuongCoBanList _NhomNgachLuongCoBanList;
        NhomNgachLuongCoBanList _NhomNgachLuongBaoHiemList;
        NgachLuongCoBanList _NgachLuongCoBanList;
        BacLuongCoBanList _BacLuongCoBanList;

        TrinhDoHocVanClassList _TrinhDoHocVanClassList;
        TrinhDoVanHoaList _trinhDoVanHoaList;
        HocHamList _HocHamList;
        TrinhDoChuyenMonList _TrinhDoChuyenMonList;
        LyLuanChinhTriList _LyLuanChinhTriList;
        NgoaiNguList _NgoaiNguList;
        TrinhDoNgoaiNguClassList _TrinhDoNgoaiNguClassList;
        TrinhDoTinHocClassList _TrinhDoTinHocClassList;
        ChuyenMonNghiepVuClassList _ChuyenMonNghiepVuClassList;
        ChuyenNganhDaoTaoClassList _ChuyenNganhDaoTaoClassList;        
        QuaTrinhTGQD _QuaTrinhTGQD;
        QuanHamList _QuanHamList;
        ThanhPhanGiaDinhClassList _ThanhPhanGiaDinhClassList;
        TrinhDo _TrinhDo;
        NganHangList _NganHangList;
        
        HoatDongXaHoi _HoatDongXaHoi;
        NhanVienGiaCanh _NhanVienGiaCanh;
        NhanVienGiaCanhList _NhanVienGiaCanhList;
        ThongTinKhac _ThongTinKhac=ThongTinKhac.NewThongTinKhac();
        NhanVien_TaiKhoanNganHang _NhanVien_TaiKhoanNH;
        NhanVien_TaiKhoanNganHangList _nhanVien_TaiKhoanNHList;
        
        DiaChi_NhanVien _DiaChi_NhanVien;
        public DiaChi_NhanVienList _DiaChi_NhanVienList;
        NhanVien_Email _NhanVien_Email;
      
        NhanVien_DienThoai_Fax _NhanVien_DienThoai_Fax;
       
        TrinhDoList _TrinhDoList;
        ThongTinKhacList _ThongTinKhacList=ThongTinKhacList.NewThongTinKhacList();

       // HoatDongXaHoiList _HoatDongXaHoiList = HoatDongXaHoiList.NewHoatDongXaHoiList();
        public NhanVien_NgoaiNguList _nhanVien_NgoaiNguList;
        public NhanVien_ChuyenNganhList _nhanVien_ChuyenMonList;
        public NhanVien_ChungChiList _nhanVien_ChungChiList;
        public NhanVien_TrinhDoQuanLyList _nhanVien_TrinhDoQuanLyList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        CongViecList _CongViecList;
       

        static string _diaChi;
        static byte[] value;       
        Util util = new Util();
        string _Path;
        OpenFileDialog _OpenFileDialog;
        static ThongTinNhanVienTongHopList _thongTinNhanVienTongHopList;

        private BacLuongCoBanList _BacLuongBaoHiemList;
        private NgachLuongCoBanList _NgachLuongBaoHiemList;
        #endregion

        #region Load
        private void frmThongTinNhanVien_Activated(object sender, EventArgs e)
        {
            this.ResetCombo();
        }

        private void ResetCombo() // Bo dong them moi khi khong chon 
        {
            foreach (Control cbocontrol in tabTongTinCoBan.Controls)
            {
                if (cbocontrol.GetType() == typeof(UltraCombo))
                {
                    if (cbocontrol.Text == "<Thêm Mới...>")
                    {
                        cbocontrol.Text = "<Trống>";
                    }
                }
            }
            foreach (Control cbocontrol in tabThongTinKhac.Controls)
            {
                if (cbocontrol.GetType() == typeof(UltraCombo))
                {
                    if (cbocontrol.Text == "<Thêm Mới...>")
                    {
                        cbocontrol.Text = "<Trống>";
                    }
                }
            }
        }

        private void LayThongTinNhanVien(NhanVien _NhanVien)
        {
            dtmp_NgayTinhThamNien.Value = "";
            QuanHeGiaDinhList _quanHeGiaDinhList = QuanHeGiaDinhList.GetQuanHeGiaDinhList(_NhanVien.MaNhanVien);
            this.bindingSource1_QuanHeGiaDinh.DataSource = _quanHeGiaDinhList;
            if (_NhanVien.GioiTinh == false)//Nữ
            {
                cmbu_GioiTinh.Text = "Nam";
                cmbu_GioiTinh.Value = false;               
            }
            else
            {
                cmbu_GioiTinh.Text = "Nữ";
                cmbu_GioiTinh.Value = true;             
            }
           
            if (DiaChi_NhanVienList.GetDiaChi_NhanVienList(_NhanVien.MaNhanVien).Count != 0)
            {
                _DiaChi_NhanVienList = DiaChi_NhanVienList.GetDiaChi_NhanVienList(_NhanVien.MaNhanVien);
                diaChiNhanVienBindingSource.DataSource = _DiaChi_NhanVienList[0];
            }
            if (_NhanVien.TrinhDoList.Count != 0)
            {
                _TrinhDoList = _NhanVien.TrinhDoList;
                trinhDoBindingSource.DataSource = _TrinhDoList[0];
            }
            if (_NhanVien.HoatDongXHList.Count != 0)
            {
                //_HoatDongXaHoiList = _NhanVien.HoatDongXHList;
                hoatDongXaHoi_BindingSource.DataSource = _NhanVien.HoatDongXHList[0];
            }
            _NhanVien.NhanVienGiaCanhList = NhanVienGiaCanhList.GetNhanVienGiaCanhList(_NhanVien.MaNhanVien);
            nhanVienGiaCanhListBindingSource1.DataSource = _NhanVien.NhanVienGiaCanhList;
            _NhanVien.NhanVienTaiKhoanNganHangList = NhanVien_TaiKhoanNganHangList.GetNhanVien_TaiKhoanNganHangList(_NhanVien.MaNhanVien);
            bindingSource1_NhanVienTaiKhoan.DataSource = _NhanVien.NhanVienTaiKhoanNganHangList;
            if (_NhanVien.ThongTinKhacList.Count != 0)
            {
                _ThongTinKhacList = _NhanVien.ThongTinKhacList;
                ThongTinKhac_BindingSource.DataSource = _ThongTinKhacList[0];
            }         
         
            if (_NhanVien.TrinhDoList.Count != 0)
            {
                _TrinhDoList = _NhanVien.TrinhDoList;
                trinhDoBindingSource.DataSource = _TrinhDoList[0];
            }
            if (_NhanVien.HoatDongXHList.Count != 0)
            {
                //_HoatDongXaHoiList = _NhanVien.HoatDongXHList;
                hoatDongXaHoi_BindingSource.DataSource = _NhanVien.HoatDongXHList[0];
            }
            if (_NhanVien.ThongTinKhacList.Count != 0)
            {
                _ThongTinKhacList = _NhanVien.ThongTinKhacList;
                ThongTinKhac_BindingSource.DataSource = _ThongTinKhacList[0];
            }
            if (_NhanVien.NhanVienNgoaiNguList.Count != 0)
            {
                _nhanVien_NgoaiNguList = _NhanVien.NhanVienNgoaiNguList;
                this.bindingSource1_NhanVienNgoaiNgu.DataSource = _nhanVien_NgoaiNguList[0];
                for (int i = 0; i < _nhanVien_NgoaiNguList.Count; i++)
                    if (_nhanVien_NgoaiNguList[i].NgoaiNguChinh == true)
                    {
                        this.tb_NhanVienNgoaiNgu.Text = _nhanVien_NgoaiNguList[i].TenNgoaiNgu + " trình độ: " + _nhanVien_NgoaiNguList[i].TenTrinhDoNN;
                    }
            }
            if (_NhanVien.NhanVienChuyenNganhList.Count != 0)
            {
                _nhanVien_ChuyenMonList = _NhanVien.NhanVienChuyenNganhList;
                //  this.Chuye.DataSource = _nhanVien_NgoaiNguList[0];
                for (int i = 0; i < _nhanVien_ChuyenMonList.Count; i++)
                    if (_nhanVien_ChuyenMonList[i].ChuyenNganhChinh == true)
                    {
                        this.tbNhanVien_ChuyenMon.Text = "Chuyên Ngành:" + _nhanVien_ChuyenMonList[i].TenChuyenNganh + "; trường tốt nghiệp: " + _nhanVien_ChuyenMonList[i].TenTruongDaoTao;
                    }
            }
            if (_NhanVien.NhanVienChungChiList.Count != 0)
            {
                _nhanVien_ChungChiList = _NhanVien.NhanVienChungChiList;
                //  this.Chuye.DataSource = _nhanVien_NgoaiNguList[0];
                for (int i = 0; i < _nhanVien_ChungChiList.Count; i++)
                    if (_nhanVien_ChungChiList[i].ChungChiChinh == true)
                    {
                        this.tbChungChi.Text = "Chứng Chỉ:" + _nhanVien_ChungChiList[i].TenChungChi + "; nơi cấp: " + _nhanVien_ChungChiList[i].NoiCap;
                    }
            }
            if (_NhanVien.NhanVienTrinhDoQuanLyList.Count != 0)
            {
                _nhanVien_TrinhDoQuanLyList = _NhanVien.NhanVienTrinhDoQuanLyList;
                this.bindingSource1_NhanVien_TrinhDoQuanLy.DataSource = _nhanVien_TrinhDoQuanLyList[0];
                for (int i = 0; i < _nhanVien_TrinhDoQuanLyList.Count; i++)
                    if (_nhanVien_TrinhDoQuanLyList[i].TrinhDoChinh == true)
                    {
                        this.tbTrinhDoQuanLy.Text ="QLKT: "+ _nhanVien_TrinhDoQuanLyList[i].TenTrinhDoQuanLyKinhTe + "; QLNN: " + _nhanVien_TrinhDoQuanLyList[i].TenTrinhDoQuanLyNhaNuoc;
                    }
            }
            else if (_ThongTinKhacList.Count==0)
            {
                _ThongTinKhac = ThongTinKhac.NewThongTinKhac();
                _ThongTinKhacList.Add(_ThongTinKhac);
                txtu_LichSu1.Value = _ThongTinKhacList[0].LichSuBanThan1;
                txtu_LichSu2.Value = _ThongTinKhacList[0].LichSuBanThan2;
                txtu_QuanHeNN.Value = _ThongTinKhacList[0].QuanHeNN;
                txtu_QuanHeGD.Value = _ThongTinKhacList[0].QuanHeGD;
            }
            if (_NhanVien.MaTinhThanhQueQuan != 0)
            {
                cmbu_QueQuan.Value = _NhanVien.MaTinhThanhQueQuan;
            }
         /*
            _BoPhanList = BoPhanList.GetBoPhanList_LoaiBoPhan(2);
            BoPhan_BindingSource.DataSource = _BoPhanList;
            */
            if (_NhanVien.NhanVienNgoaiNguList.Count == 0)
            {
                tb_NhanVienNgoaiNgu.Text = string.Empty;
            }
            if (_NhanVien.NhanVienTrinhDoQuanLyList.Count == 0)
            {
                tbTrinhDoQuanLy.Text = string.Empty;
            }
            if (_NhanVien.NhanVienChuyenNganhList.Count == 0)
            {
                tbNhanVien_ChuyenMon.Text = string.Empty;
            }
            if (_NhanVien.NhanVienChungChiList.Count == 0)
            {
                tbChungChi.Text = string.Empty;
            }
           // BoPhanList _BoPhanList_ban = BoPhanList.GetBoPhanList();
          //  this.bdBoPhan_Ban.DataSource = _BoPhanList_ban;

         
          _mabp = _NhanVien.MaBoPhan;
            //this.Xulymabophankhiloadlen();
          this.XuLyBoPhanKhiLoad(_mabp);

        }

        public void GetList(object value)
        {
            if(value.ToString().Contains("ERP_Library.TonGiaoList"))
            {
                _TonGiaoList= (TonGiaoList)value;
                _TonGiaoList = TonGiaoList.GetTonGiaoList();
                TonGiao _tongiao = TonGiao.NewTonGiao(0, "<Trống>");
                TonGiao _tongiaothem = TonGiao.NewTonGiao(_TonGiaoList.Count + 1, "<Thêm Mới...>");
                _TonGiaoList.Insert(0, _tongiao);
                _TonGiaoList.Insert(1, _tongiaothem);
                tonGiaoListBindingSource.DataSource = _TonGiaoList;
            }
            if (value.ToString().Contains("ERP_Library.ChucVuList"))
            {
                _ChucVuList = ChucVuList.GetChucVuList();
                ChucVu _chucVu = ChucVu.NewChucVu(0, "<Trống>");
                ChucVu _chucVuThem = ChucVu.NewChucVu(_ChucVuList.Count + 1, "<Thêm Mới...>");
                _ChucVuList.Insert(0, _chucVu);
                _ChucVuList.Insert(1, _chucVuThem);
                chucVuListBindingSource.DataSource = _ChucVuList;

                _ChucVu_DangList = ChucVuList.GetChucVuList(1);
                ChucVu _chucVuDang = ChucVu.NewChucVu(0, "<Trống>");
                ChucVu _chucVuDangThem = ChucVu.NewChucVu(_ChucVu_DangList.Count + 1, "<Thêm Mới...>");
                _ChucVu_DangList.Insert(0, _chucVuDang);
                _ChucVu_DangList.Insert(1, _chucVuDangThem);
                ChucVuDang_bindingSource.DataSource = _ChucVu_DangList;

                _loaiDangVienList = LoaiDangVienList.GetLoaiDangVienList();
                LoaiDangVien_bindingSource.DataSource = _loaiDangVienList;

                _truongDaoTaoList = TruongDaoTaoList.GetTruongDaoTaoList();
                this.bindingSource1_TruongDang.DataSource = _truongDaoTaoList;
                _ChucVu_QuanDoiList = ChucVuList.GetChucVuList(2);
                ChucVu _chucVuQD = ChucVu.NewChucVu(0, "<Trống>");
                ChucVu _chucVuQDThem = ChucVu.NewChucVu(_ChucVu_QuanDoiList.Count + 1, "<Thêm Mới...>");
                _ChucVu_QuanDoiList.Insert(0, _chucVuQD);
                _ChucVu_QuanDoiList.Insert(1, _chucVuQDThem);
                ChucVuQuanDoi_bindingSource.DataSource = _ChucVu_QuanDoiList;

                _ChucVu_DoanList = ChucVuList.GetChucVuList(3);
                ChucVu _chucVuDoan = ChucVu.NewChucVu(0, "<Trống>");
                ChucVu _chucVuDoanThem = ChucVu.NewChucVu(_ChucVu_DoanList.Count + 1, "<Thêm Mới...>");
                _ChucVu_DoanList.Insert(0, _chucVuDoan);
                _ChucVu_DoanList.Insert(1, _chucVuDoanThem);
                ChucVuDoan_bindingSource.DataSource = _ChucVu_DoanList;

                _ChucVu_CongDoanList = ChucVuList.GetChucVuList(5);
                ChucVu _chucCD = ChucVu.NewChucVu(0, "<Trống>");
                ChucVu _chucCDThem = ChucVu.NewChucVu(_ChucVu_CongDoanList.Count + 1, "<Thêm Mới...>");
                _ChucVu_CongDoanList.Insert(0, _chucCD);
                _ChucVu_CongDoanList.Insert(1, _chucCDThem);
                ChucVuCongDoan_bindingSource.DataSource = _ChucVu_CongDoanList;
            }
            if (value.ToString().Contains("ERP_Library.NhomNgachLuongCoBanList"))
            {
                _NhomNgachLuongCoBanList = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
                bindingSource1_NhomNgachLuong.DataSource = _NhomNgachLuongCoBanList;
            }
            if (value.ToString().Contains("ERP_Library.NgachLuongCoBanList"))
            {
                _NgachLuongBaoHiemList = NgachLuongCoBanList.GetNgachLuongCoBanList();
                bindingSource1_NgachLuongBH.DataSource = _NgachLuongBaoHiemList;
                _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanList();
                NgachLuongCoBan _Ngachluongcb = NgachLuongCoBan.NewNgachLuongCoBan(0, "<Trống>");
                NgachLuongCoBan _NgachluongcbThem = NgachLuongCoBan.NewNgachLuongCoBan(_NgachLuongCoBanList.Count + 1, "<Thêm Mới...>");
                _NgachLuongCoBanList.Insert(0, _Ngachluongcb);
                _NgachLuongCoBanList.Insert(1, _NgachluongcbThem);
                NgachLuongCoBan_BindingSource.DataSource = _NgachLuongCoBanList;
            }
            if (value.ToString().Contains("ERP_Library.UuTienBanThanList"))
            {
                _UuTienBanThanList = UuTienBanThanList.GetUuTienBanThanList();
                UuTienBanThan _Uutienbanthan = UuTienBanThan.NewUuTienBanThan(0, "<Trống>");
                UuTienBanThan _UutienbanthanThem = UuTienBanThan.NewUuTienBanThan(_UuTienBanThanList.Count + 1, "<Thêm Mới...>");
                _UuTienBanThanList.Insert(0, _Uutienbanthan);
                _UuTienBanThanList.Insert(1, _UutienbanthanThem);
                uuTienBanThanListBindingSource.DataSource = _UuTienBanThanList;
            }
            if (value.ToString().Contains("ERP_Library.UuTienGiaDinhList"))
            {
                _UuTienGiaDinhList = UuTienGiaDinhList.GetUuTienGiaDinhList();
                UuTienGiaDinh _uutiengiadinh = UuTienGiaDinh.NewUuTienGiaDinh(0, "<Trống>");
                UuTienGiaDinh _uutiengiadinhThem = UuTienGiaDinh.NewUuTienGiaDinh(_UuTienGiaDinhList.Count + 1, "<Thêm Mới...>");
                _UuTienGiaDinhList.Insert(0, _uutiengiadinh);
                _UuTienGiaDinhList.Insert(1, _uutiengiadinhThem);
                uuTienGiaDinhListBindingSource.DataSource = _UuTienGiaDinhList;
            }

            if (value.ToString().Contains("ERP_Library.DanToc_NVList"))
            {
                _DanToc_NVList = DanToc_NVList.GetDanToc_NVList();
                DanToc_NV _Dantoc_NV = DanToc_NV.NewDanToc_NV(0, "<Trống>");
                DanToc_NV _Dantoc_NVThem = DanToc_NV.NewDanToc_NV(_DanToc_NVList.Count + 1, "<Thêm Mới...>");
                _DanToc_NVList.Insert(0, _Dantoc_NV);
                _DanToc_NVList.Insert(1, _Dantoc_NVThem);
                danTocNVListBindingSource.DataSource = _DanToc_NVList;
            }
            if (value.ToString().Contains("ERP_Library.TonGiaoList"))
            {
                _TonGiaoList = TonGiaoList.GetTonGiaoList();
                TonGiao _tongiao = TonGiao.NewTonGiao(0, "<Trống>");
                TonGiao _tongiaoThem = TonGiao.NewTonGiao(_TonGiaoList.Count + 1, "<Thêm Mới...>");
                _TonGiaoList.Insert(0, _tongiao);
                _TonGiaoList.Insert(1, _tongiaoThem);
                tonGiaoListBindingSource.DataSource = _TonGiaoList;
            }

            if (value.ToString().Contains("ERP_Library.QuocGiaList"))
            {
                _QuocGiaList = QuocGiaList.GetQuocGiaList();
                QuocGia _Quocgia = QuocGia.NewQuocGia(0, "<Trống>");
                QuocGia _QuocgiaThem = QuocGia.NewQuocGia(_QuocGiaList.Count + 1, "<Thêm Mới...>");
                _QuocGiaList.Insert(0, _Quocgia);
                _QuocGiaList.Insert(1, _QuocgiaThem);
                quocGiaListBindingSource.DataSource = _QuocGiaList;
            }

            if (value.ToString().Contains("ERP_Library.TinhThanhList"))
            {
                _TinhThanh_CMNDList = TinhThanhList.GetTinhThanhList();
                TinhThanh _tinhthanhCMND = TinhThanh.NewTinhThanh(0, "<Trống>");
                TinhThanh _tinhthanhCMNDThem = TinhThanh.NewTinhThanh(_TinhThanh_CMNDList.Count + 1, "<Thêm Mới...>");
                _TinhThanh_CMNDList.Insert(0, _tinhthanhCMND);
                _TinhThanh_CMNDList.Insert(1, _tinhthanhCMNDThem);
                tinhThanhListBindingSource.DataSource = _TinhThanh_CMNDList;
            
                _TinhThanh_NoiSinhList = TinhThanhList.GetTinhThanhList();
                TinhThanh _tinhthanhnoisinh = TinhThanh.NewTinhThanh(0, "<Trống>");
                TinhThanh _tinhthanhnoisinhThem = TinhThanh.NewTinhThanh(_TinhThanh_NoiSinhList.Count + 1, "<Thêm Mới...>");
                _TinhThanh_NoiSinhList.Insert(0, _tinhthanhnoisinh);
                _TinhThanh_NoiSinhList.Insert(1, _tinhthanhnoisinhThem);
                NoiSinhTinhThanh_bindingSource.DataSource = _TinhThanh_NoiSinhList;

                _TinhThanh_ThT = TinhThanhList.GetTinhThanhList();
                TinhThanh _tinhthanhtht = TinhThanh.NewTinhThanh(0, "<Trống>");
                TinhThanh _tinhthanhthtThem = TinhThanh.NewTinhThanh(_TinhThanh_ThT.Count + 1, "<Thêm Mới...>");
                _TinhThanh_ThT.Insert(0, _tinhthanhtht);
                _TinhThanh_ThT.Insert(1, _tinhthanhthtThem);
                BindS_TinhThT.DataSource = _TinhThanh_ThT;

                _TinhThanh_TT = TinhThanhList.GetTinhThanhList();
                TinhThanh _tinhthanhtt = TinhThanh.NewTinhThanh(0, "<Trống>");
                TinhThanh _tinhthanhttThem = TinhThanh.NewTinhThanh(_TinhThanh_TT.Count + 1, "<Thêm Mới...>");
                _TinhThanh_TT.Insert(0, _tinhthanhtt);
                _TinhThanh_TT.Insert(1, _tinhthanhttThem);
                BindS_TinhTT.DataSource = _TinhThanh_TT;

                _TinhThanh_QueQuanList = TinhThanhList.GetTinhThanhList();
                TinhThanh _tinhthanhQQ = TinhThanh.NewTinhThanh(0, "<Trống>");
                TinhThanh _tinhthanhQQThem = TinhThanh.NewTinhThanh(_TinhThanh_QueQuanList.Count + 1, "<Thêm Mới...>");
                _TinhThanh_QueQuanList.Insert(0, _tinhthanhQQ);
                _TinhThanh_QueQuanList.Insert(1, _tinhthanhQQThem);
                TinhThanhQueQuan_bindingSource.DataSource = _TinhThanh_QueQuanList;
            }

            if (value.ToString().Contains("ERP_Library.ChucDanhList"))
            {
                _ChucDanhList = ChucDanhList.GetChucDanhList();
                ChucDanh _chucdanh = ChucDanh.NewChucDanh(0, "<Trống>");
                ChucDanh _chucdanhThem = ChucDanh.NewChucDanh(_ChucDanhList.Count + 1, "<Thêm Mới...>");
                _ChucDanhList.Insert(0, _chucdanh);
                _ChucDanhList.Insert(1, _chucdanhThem);
                ChucDanh_BindingSource.DataSource = _ChucDanhList;
            }

            if (value.ToString().Contains("ERP_Library.NganHangList"))
            {
                _NganHangList = NganHangList.GetNganHangListByCongTy();
                NganHang _NganHang = NganHang.NewNganHang(0, "<Trống>");
                NganHang _NganHangThem = NganHang.NewNganHang(_NganHangList.Count + 1, "<Thêm Mới...>");
                _NganHangList.Insert(0, _NganHang);
                _NganHangList.Insert(1, _NganHangThem);
                nganHangListBindingSource.DataSource = _NganHangList;
            }

            if (value.ToString().Contains("ERP_Library.TrinhDoHocVanClassList"))
            {
                _TrinhDoHocVanClassList = TrinhDoHocVanClassList.GetTrinhDoHocVanClassList();
                TrinhDoHocVanClass _Trinhdohocvan = TrinhDoHocVanClass.NewTrinhDoHocVanClass(0, "<Trống>");
                TrinhDoHocVanClass _TrinhdohocvanThem = TrinhDoHocVanClass.NewTrinhDoHocVanClass(_TrinhDoHocVanClassList.Count + 1, "<Thêm Mới...>");
                _TrinhDoHocVanClassList.Insert(0, _Trinhdohocvan);
                _TrinhDoHocVanClassList.Insert(1, _TrinhdohocvanThem);
                trinhDoHocVanClassListBindingSource.DataSource = _TrinhDoHocVanClassList;
            }


            if (value.ToString().Contains("ERP_Library.NgoaiNguList"))
            {
                _NgoaiNguList = NgoaiNguList.GetNgoaiNguList();
                NgoaiNgu _ngoaingu = NgoaiNgu.NewNgoaiNgu(0, "<Trống>");
                NgoaiNgu _ngoainguThem = NgoaiNgu.NewNgoaiNgu(_NgoaiNguList.Count + 1, "<Thêm Mới...>");
                _NgoaiNguList.Insert(0, _ngoaingu);
                _NgoaiNguList.Insert(1, _ngoainguThem);
                ngoaiNguListBindingSource.DataSource = _NgoaiNguList;
            }

            if (value.ToString().Contains("ERP_Library.TrinhDoNgoaiNguClassList"))
            {
                _TrinhDoNgoaiNguClassList = TrinhDoNgoaiNguClassList.GetTrinhDoNgoaiNguClassList();
                TrinhDoNgoaiNguClass _TrinhdoNN = TrinhDoNgoaiNguClass.NewTrinhDoNgoaiNguClass(0, "<Trống>");
                TrinhDoNgoaiNguClass _TrinhdoNNThem = TrinhDoNgoaiNguClass.NewTrinhDoNgoaiNguClass(_TrinhDoNgoaiNguClassList.Count + 1, "<Thêm Mới...>");
                _TrinhDoNgoaiNguClassList.Insert(0, _TrinhdoNN);
                _TrinhDoNgoaiNguClassList.Insert(1, _TrinhdoNNThem);
                trinhDoNgoaiNguClassListBindingSource.DataSource = _TrinhDoNgoaiNguClassList;
            }

            if (value.ToString().Contains("ERP_Library.TrinhDoTinHocClassList"))
            {
                _TrinhDoTinHocClassList = TrinhDoTinHocClassList.GetTrinhDoTinHocClassList();
                TrinhDoTinHocClass _trinhdoTH = TrinhDoTinHocClass.NewTrinhDoTinHocClass(0, "<Trống>");
                TrinhDoTinHocClass _trinhdoTHThem = TrinhDoTinHocClass.NewTrinhDoTinHocClass(_TrinhDoTinHocClassList.Count + 1, "<Thêm Mới...>");
                _TrinhDoTinHocClassList.Insert(0, _trinhdoTH);
                _TrinhDoTinHocClassList.Insert(1, _trinhdoTHThem);
                trinhDoTinHocClassListBindingSource.DataSource = _TrinhDoTinHocClassList;
            }

            if (value.ToString().Contains("ERP_Library.ChuyenMonNghiepVuClassList"))
            {
                _ChuyenMonNghiepVuClassList = ChuyenMonNghiepVuClassList.GetChuyenMonNghiepVuClassList();
                ChuyenMonNghiepVuClass _ChuyenmonNV = ChuyenMonNghiepVuClass.NewChuyenMonNghiepVuClass(0, "<Trống>");
                ChuyenMonNghiepVuClass _ChuyenmonNVThem = ChuyenMonNghiepVuClass.NewChuyenMonNghiepVuClass(_ChucVu_DangList.Count + 1, "<Thêm Mới...>");
                _ChuyenMonNghiepVuClassList.Insert(0, _ChuyenmonNV);
                _ChuyenMonNghiepVuClassList.Insert(1, _ChuyenmonNVThem);
                chuyenMonNghiepVuClassListBindingSource.DataSource = _ChuyenMonNghiepVuClassList;
            }

            if (value.ToString().Contains("ERP_Library.TrinhDoChuyenMonList"))
            {
                _TrinhDoChuyenMonList = TrinhDoChuyenMonList.GetTrinhDoChuyenMonList();
                TrinhDoChuyenMon _TrinhdoCM = TrinhDoChuyenMon.NewTrinhDoChuyenMon(0, "<Trống>");
                TrinhDoChuyenMon _TrinhdoCMThem = TrinhDoChuyenMon.NewTrinhDoChuyenMon(_TrinhDoChuyenMonList.Count + 1, "<Thêm Mới...>");
                _TrinhDoChuyenMonList.Insert(0, _TrinhdoCM);
                _TrinhDoChuyenMonList.Insert(1, _TrinhdoCMThem);
                trinhDoChuyenMonListBindingSource.DataSource = _TrinhDoChuyenMonList;
            }
            if (value.ToString().Contains("ERP_Library.ThanhPhanGiaDinhClassList"))
            {
                _ThanhPhanGiaDinhClassList = ThanhPhanGiaDinhClassList.GetThanhPhanGiaDinhClassList();
                ThanhPhanGiaDinhClass _ThanhphanGD = ThanhPhanGiaDinhClass.NewThanhPhanGiaDinhClass(0, "<Trống>");
                ThanhPhanGiaDinhClass _ThanhphanGDThem = ThanhPhanGiaDinhClass.NewThanhPhanGiaDinhClass(_ThanhPhanGiaDinhClassList.Count + 1, "<Thêm Mới...>");
                _ThanhPhanGiaDinhClassList.Insert(0, _ThanhphanGD);
                _ThanhPhanGiaDinhClassList.Insert(1, _ThanhphanGDThem);
                thanhPhanGiaDinhClassListBindingSource.DataSource = _ThanhPhanGiaDinhClassList;
            }
            if (value.ToString().Contains("ERP_Library.LyLuanChinhTriList"))
            {
                _LyLuanChinhTriList = LyLuanChinhTriList.GetLyLuanChinhTriList();
                LyLuanChinhTri _lyluanCT = LyLuanChinhTri.NewLyLuanChinhTri(0, "<Trống>");
                LyLuanChinhTri _lyluanCTThem = LyLuanChinhTri.NewLyLuanChinhTri(_LyLuanChinhTriList.Count + 1, "<Thêm Mới...>");
                _LyLuanChinhTriList.Insert(0, _lyluanCT);
                _LyLuanChinhTriList.Insert(1, _lyluanCTThem);
                lyLuanChinhTriListBindingSource.DataSource = _LyLuanChinhTriList;
            }
        }

        private void Load_Combo()
        {
            //BoPhan
        
          this.bdBoPhan_Ban                                                .DataSource =BoPhanList.GetBoPhanList_LoaiBoPhan(2);
          this.bdBoPhan_PhongBan.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(3);
          this.bdBoPhan_To.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(4);
            //Loai Nhan Vien
            LoaiNhanVienList _loaiNVList = LoaiNhanVienList.GetLoaiNhanVienList();
            this.bindingSource1_LoaiNhanVien.DataSource = _loaiNVList;
            //
            //QuanHeGiaDinhList _quanHeGiaDinhList = QuanHeGiaDinhList.GetQuanHeGiaDinhList();
            //this.bindingSource1_QuanHeGiaDinh.DataSource = _quanHeGiaDinhList;
            _chungTuGiaCanhList = ChungTuGiamTruGiaCanhList.GetChungTuGiamTruGiaCanhList();
            this.ChungTuGiaCanh_BindingSource.DataSource = _chungTuGiaCanhList;
            GiamTruGiaCanhList _GiamTruGiaCanhList = GiamTruGiaCanhList.GetGiamTruGiaCanhList();
            this.bindingSource1_GiaCanh.DataSource = _GiamTruGiaCanhList;
            _ChucVuList = ChucVuList.GetChucVuList();
            ChucVu _chucVu = ChucVu.NewChucVu(0, "<Trống>");
            ChucVu _chucVuThem = ChucVu.NewChucVu(_ChucVuList.Count + 1, "<Thêm Mới...>");
            _ChucVuList.Insert(0, _chucVu);
            _ChucVuList.Insert(1, _chucVuThem);
            chucVuListBindingSource.DataSource = _ChucVuList;

            _loaiDangVienList = LoaiDangVienList.GetLoaiDangVienList();
            LoaiDangVien_bindingSource.DataSource = _loaiDangVienList;
            _truongDaoTaoList = TruongDaoTaoList.GetTruongDaoTaoList();
            bindingSource1_TruongDang.DataSource = _truongDaoTaoList;
            _ChucVu_DangList = ChucVuList.GetChucVuList(1);
            ChucVu _chucVuDang = ChucVu.NewChucVu(0, "<Trống>");
            ChucVu _chucVuDangThem = ChucVu.NewChucVu(_ChucVu_DangList.Count + 1, "<Thêm Mới...>");
            _ChucVu_DangList.Insert(0, _chucVuDang);
            _ChucVu_DangList.Insert(1, _chucVuDangThem);
            ChucVuDang_bindingSource.DataSource = _ChucVu_DangList;

            

            _ChucVu_QuanDoiList = ChucVuList.GetChucVuList(2);
            ChucVu _chucVuQD = ChucVu.NewChucVu(0, "<Trống>");
            ChucVu _chucVuQDThem = ChucVu.NewChucVu(_ChucVu_QuanDoiList.Count + 1, "<Thêm Mới...>");
            _ChucVu_QuanDoiList.Insert(0, _chucVuQD);
            _ChucVu_QuanDoiList.Insert(1, _chucVuQDThem);
            ChucVuQuanDoi_bindingSource.DataSource = _ChucVu_QuanDoiList;

            _ChucVu_DoanList = ChucVuList.GetChucVuList(3);
            ChucVu _chucVuDoan = ChucVu.NewChucVu(0, "<Trống>");
            ChucVu _chucVuDoanThem = ChucVu.NewChucVu(_ChucVu_DoanList.Count + 1, "<Thêm Mới...>");
            _ChucVu_DoanList.Insert(0, _chucVuDoan);
            _ChucVu_DoanList.Insert(1, _chucVuDoanThem);
            ChucVuDoan_bindingSource.DataSource = _ChucVu_DoanList;

            _ChucVu_CongDoanList = ChucVuList.GetChucVuList(5);
            ChucVu _chucCD = ChucVu.NewChucVu(0, "<Trống>");
            ChucVu _chucCDThem = ChucVu.NewChucVu(_ChucVu_CongDoanList.Count + 1, "<Thêm Mới...>");
            _ChucVu_CongDoanList.Insert(0, _chucCD);
            _ChucVu_CongDoanList.Insert(1, _chucCDThem);
            ChucVuCongDoan_bindingSource.DataSource = _ChucVu_CongDoanList;


            _NhomNgachLuongCoBanList = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
            bindingSource1_NhomNgachLuong.DataSource = _NhomNgachLuongCoBanList;

            _NhomNgachLuongBaoHiemList = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
            bindingSource1_NhomNgachLuongBH.DataSource = _NhomNgachLuongBaoHiemList;

            _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanList();
            NgachLuongCoBan _Ngachluongcb = NgachLuongCoBan.NewNgachLuongCoBan(0, "<Trống>");
            NgachLuongCoBan _NgachluongcbThem = NgachLuongCoBan.NewNgachLuongCoBan(_NgachLuongCoBanList.Count + 1, "<Thêm Mới...>");
            _NgachLuongCoBanList.Insert(0, _Ngachluongcb);
            _NgachLuongCoBanList.Insert(1, _NgachluongcbThem);
            NgachLuongCoBan_BindingSource.DataSource = _NgachLuongCoBanList;

            _NgachLuongBaoHiemList = NgachLuongCoBanList.GetNgachLuongCoBanList();
            this.bindingSource1_NgachLuongBH.DataSource = _NgachLuongBaoHiemList;
            

            _UuTienBanThanList = UuTienBanThanList.GetUuTienBanThanList();
            UuTienBanThan _Uutienbanthan = UuTienBanThan.NewUuTienBanThan(0, "<Trống>");
            UuTienBanThan _UutienbanthanThem = UuTienBanThan.NewUuTienBanThan(_UuTienBanThanList.Count + 1, "<Thêm Mới...>");
            _UuTienBanThanList.Insert(0, _Uutienbanthan);
            _UuTienBanThanList.Insert(1, _UutienbanthanThem);
            uuTienBanThanListBindingSource.DataSource = _UuTienBanThanList;

            _UuTienGiaDinhList = UuTienGiaDinhList.GetUuTienGiaDinhList();
            UuTienGiaDinh _uutiengiadinh = UuTienGiaDinh.NewUuTienGiaDinh(0, "<Trống>");
            UuTienGiaDinh _uutiengiadinhThem = UuTienGiaDinh.NewUuTienGiaDinh(_UuTienGiaDinhList.Count + 1, "<Thêm Mới...>");
            _UuTienGiaDinhList.Insert(0, _uutiengiadinh);
            _UuTienGiaDinhList.Insert(1, _uutiengiadinhThem);
            uuTienGiaDinhListBindingSource.DataSource = _UuTienGiaDinhList;

            _DanToc_NVList = DanToc_NVList.GetDanToc_NVList();
            DanToc_NV _Dantoc_NV = DanToc_NV.NewDanToc_NV(0, "<Trống>");
            DanToc_NV _Dantoc_NVThem = DanToc_NV.NewDanToc_NV(_DanToc_NVList.Count + 1, "<Thêm Mới...>");
            _DanToc_NVList.Insert(0, _Dantoc_NV);
            _DanToc_NVList.Insert(1, _Dantoc_NVThem);
            danTocNVListBindingSource.DataSource = _DanToc_NVList;

            _TonGiaoList = TonGiaoList.GetTonGiaoList();
            TonGiao _tongiao = TonGiao.NewTonGiao(0, "<Trống>");
            TonGiao _tongiaothem = TonGiao.NewTonGiao(_TonGiaoList.Count + 1, "<Thêm Mới...>");
            _TonGiaoList.Insert(0, _tongiao);
            _TonGiaoList.Insert(1, _tongiaothem);
            tonGiaoListBindingSource.DataSource = _TonGiaoList;

            _QuocGiaList = QuocGiaList.GetQuocGiaList();
            QuocGia _Quocgia = QuocGia.NewQuocGia(0, "<Trống>");
            QuocGia _QuocgiaThem = QuocGia.NewQuocGia(_QuocGiaList.Count + 1, "<Thêm Mới...>");
            _QuocGiaList.Insert(0, _Quocgia);
            _QuocGiaList.Insert(1, _QuocgiaThem);
            quocGiaListBindingSource.DataSource = _QuocGiaList;

            _TinhThanh_CMNDList = TinhThanhList.GetTinhThanhList();
            TinhThanh _tinhthanhCMND = TinhThanh.NewTinhThanh(0, "<Trống>");
            TinhThanh _tinhthanhCMNDThem = TinhThanh.NewTinhThanh(_TinhThanh_CMNDList.Count + 1, "<Thêm Mới...>");
            _TinhThanh_CMNDList.Insert(0, _tinhthanhCMND);
            _TinhThanh_CMNDList.Insert(1, _tinhthanhCMNDThem);
            tinhThanhListBindingSource.DataSource = _TinhThanh_CMNDList;

            _TinhThanh_NoiSinhList = TinhThanhList.GetTinhThanhList();
            TinhThanh _tinhthanhnoisinh = TinhThanh.NewTinhThanh(0, "<Trống>");
            TinhThanh _tinhthanhnoisinhThem = TinhThanh.NewTinhThanh(_TinhThanh_NoiSinhList.Count + 1, "<Thêm Mới...>");
            _TinhThanh_NoiSinhList.Insert(0, _tinhthanhnoisinh);
            _TinhThanh_NoiSinhList.Insert(1, _tinhthanhnoisinhThem);
            NoiSinhTinhThanh_bindingSource.DataSource = _TinhThanh_NoiSinhList;

            _TinhThanh_ThT = TinhThanhList.GetTinhThanhList();
            TinhThanh _tinhthanhtht = TinhThanh.NewTinhThanh(0, "<Trống>");
            TinhThanh _tinhthanhthtThem = TinhThanh.NewTinhThanh(_TinhThanh_ThT.Count + 1, "<Thêm Mới...>");
            _TinhThanh_ThT.Insert(0, _tinhthanhtht);
            _TinhThanh_ThT.Insert(1, _tinhthanhthtThem);
            BindS_TinhThT.DataSource = _TinhThanh_ThT;


          
            _TinhThanh_TT = TinhThanhList.GetTinhThanhList();
            TinhThanh _tinhthanhtt = TinhThanh.NewTinhThanh(0, "<Trống>");
            TinhThanh _tinhthanhttThem = TinhThanh.NewTinhThanh(_TinhThanh_TT.Count + 1, "<Thêm Mới...>");
            _TinhThanh_TT.Insert(0, _tinhthanhtt);
            _TinhThanh_TT.Insert(1, _tinhthanhttThem);
            BindS_TinhTT.DataSource = _TinhThanh_TT;

            _ChucDanhList = ChucDanhList.GetChucDanhList();
            ChucDanh _chucdanh = ChucDanh.NewChucDanh(0, "<Trống>");
            ChucDanh _chucdanhThem = ChucDanh.NewChucDanh(_ChucDanhList.Count + 1, "<Thêm Mới...>");
            _ChucDanhList.Insert(0, _chucdanh);
            _ChucDanhList.Insert(1, _chucdanhThem);
            ChucDanh_BindingSource.DataSource = _ChucDanhList;

            _NganHangList = NganHangList.GetNganHangListByCongTy();
            NganHang _NganHang = NganHang.NewNganHang(0, "<Trống>");
            NganHang _NganHangThem = NganHang.NewNganHang(_NganHangList.Count + 1, "<Thêm Mới...>");
            _NganHangList.Insert(0, _NganHang);
            _NganHangList.Insert(1, _NganHangThem);
            nganHangListBindingSource.DataSource = _NganHangList;

            _TrinhDoHocVanClassList = TrinhDoHocVanClassList.GetTrinhDoHocVanClassList();
            TrinhDoHocVanClass _Trinhdohocvan = TrinhDoHocVanClass.NewTrinhDoHocVanClass(0, "<Trống>");
            TrinhDoHocVanClass _TrinhdohocvanThem = TrinhDoHocVanClass.NewTrinhDoHocVanClass(_TrinhDoHocVanClassList.Count + 1, "<Thêm Mới...>");
            _TrinhDoHocVanClassList.Insert(0, _Trinhdohocvan);
            _TrinhDoHocVanClassList.Insert(1, _TrinhdohocvanThem);
            trinhDoHocVanClassListBindingSource.DataSource = _TrinhDoHocVanClassList;

            _trinhDoVanHoaList = TrinhDoVanHoaList.GetTrinhDoVanHoaList();
            bindingSource1_trinhDoVanHoa.DataSource = _trinhDoVanHoaList;

            _HocHamList = HocHamList.GetHocHamList();
            HocHam _Hocham = HocHam.NewHocHam(0, "<Trống>");            
            _HocHamList.Insert(0, _Hocham);
            hocHamListBindingSource.DataSource = _HocHamList;

            _LyLuanChinhTriList = LyLuanChinhTriList.GetLyLuanChinhTriList();
            LyLuanChinhTri _lyluanCT = LyLuanChinhTri.NewLyLuanChinhTri(0, "<Trống>");
            LyLuanChinhTri _lyluanCTThem = LyLuanChinhTri.NewLyLuanChinhTri(_LyLuanChinhTriList.Count + 1, "<Thêm Mới...>");
            _LyLuanChinhTriList.Insert(0, _lyluanCT);
            _LyLuanChinhTriList.Insert(1, _lyluanCTThem);      
            lyLuanChinhTriListBindingSource.DataSource = _LyLuanChinhTriList;

            _NgoaiNguList = NgoaiNguList.GetNgoaiNguList();
            NgoaiNgu _ngoaingu = NgoaiNgu.NewNgoaiNgu(0, "<Trống>");
            NgoaiNgu _ngoainguThem = NgoaiNgu.NewNgoaiNgu(_NgoaiNguList.Count + 1, "<Thêm Mới...>");
            _NgoaiNguList.Insert(0, _ngoaingu);
            _NgoaiNguList.Insert(1, _ngoainguThem);
            ngoaiNguListBindingSource.DataSource = _NgoaiNguList;

            _TrinhDoNgoaiNguClassList = TrinhDoNgoaiNguClassList.GetTrinhDoNgoaiNguClassList();
            TrinhDoNgoaiNguClass _TrinhdoNN = TrinhDoNgoaiNguClass.NewTrinhDoNgoaiNguClass(0, "<Trống>");
            TrinhDoNgoaiNguClass _TrinhdoNNThem = TrinhDoNgoaiNguClass.NewTrinhDoNgoaiNguClass(_TrinhDoNgoaiNguClassList.Count + 1, "<Thêm Mới...>");
            _TrinhDoNgoaiNguClassList.Insert(0, _TrinhdoNN);
            _TrinhDoNgoaiNguClassList.Insert(1, _TrinhdoNNThem);
            trinhDoNgoaiNguClassListBindingSource.DataSource = _TrinhDoNgoaiNguClassList;

            _TrinhDoTinHocClassList = TrinhDoTinHocClassList.GetTrinhDoTinHocClassList();
            TrinhDoTinHocClass _trinhdoTH = TrinhDoTinHocClass.NewTrinhDoTinHocClass(0, "<Trống>");
            TrinhDoTinHocClass _trinhdoTHThem = TrinhDoTinHocClass.NewTrinhDoTinHocClass(_TrinhDoTinHocClassList.Count + 1, "<Thêm Mới...>");
            _TrinhDoTinHocClassList.Insert(0, _trinhdoTH);
            _TrinhDoTinHocClassList.Insert(1, _trinhdoTHThem);
            trinhDoTinHocClassListBindingSource.DataSource = _TrinhDoTinHocClassList;

            _ChuyenMonNghiepVuClassList = ChuyenMonNghiepVuClassList.GetChuyenMonNghiepVuClassList();
            ChuyenMonNghiepVuClass _ChuyenmonNV = ChuyenMonNghiepVuClass.NewChuyenMonNghiepVuClass(0, "<Trống>");
            ChuyenMonNghiepVuClass _ChuyenmonNVThem = ChuyenMonNghiepVuClass.NewChuyenMonNghiepVuClass(_ChucVu_DangList.Count + 1, "<Thêm Mới...>");
            _ChuyenMonNghiepVuClassList.Insert(0, _ChuyenmonNV);
            _ChuyenMonNghiepVuClassList.Insert(1, _ChuyenmonNVThem);
            chuyenMonNghiepVuClassListBindingSource.DataSource = _ChuyenMonNghiepVuClassList;

            _TrinhDoChuyenMonList = TrinhDoChuyenMonList.GetTrinhDoChuyenMonList();
            TrinhDoChuyenMon _TrinhdoCM = TrinhDoChuyenMon.NewTrinhDoChuyenMon(0, "<Trống>");
            TrinhDoChuyenMon _TrinhdoCMThem = TrinhDoChuyenMon.NewTrinhDoChuyenMon(_TrinhDoChuyenMonList.Count + 1, "<Thêm Mới...>");
            _TrinhDoChuyenMonList.Insert(0, _TrinhdoCM);
            _TrinhDoChuyenMonList.Insert(1, _TrinhdoCMThem);
            trinhDoChuyenMonListBindingSource.DataSource = _TrinhDoChuyenMonList;

            _ChuyenNganhDaoTaoClassList = ChuyenNganhDaoTaoClassList.GetChuyenNganhDaoTaoClassList();
            ChuyenNganhDaoTaoClass _ChuyennganhDT = ChuyenNganhDaoTaoClass.NewChuyenNganhDaoTaoClass(0, "<Trống>");
            ChuyenNganhDaoTaoClass _ChuyennganhDTThem = ChuyenNganhDaoTaoClass.NewChuyenNganhDaoTaoClass(_ChuyenNganhDaoTaoClassList.Count + 1, "<Thêm Mới...>");
            _ChuyenNganhDaoTaoClassList.Insert(0, _ChuyennganhDT);
            chuyenNganhDaoTaoClassListBindingSource.DataSource = _ChuyenNganhDaoTaoClassList;

            _ThanhPhanGiaDinhClassList = ThanhPhanGiaDinhClassList.GetThanhPhanGiaDinhClassList();
            ThanhPhanGiaDinhClass _ThanhphanGD = ThanhPhanGiaDinhClass.NewThanhPhanGiaDinhClass(0, "<Trống>");            
            ThanhPhanGiaDinhClass _ThanhphanGDThem = ThanhPhanGiaDinhClass.NewThanhPhanGiaDinhClass(_ThanhPhanGiaDinhClassList.Count + 1, "<Thêm Mới...>");
            _ThanhPhanGiaDinhClassList.Insert(0, _ThanhphanGD);
            _ThanhPhanGiaDinhClassList.Insert(1, _ThanhphanGDThem);
            thanhPhanGiaDinhClassListBindingSource.DataSource = _ThanhPhanGiaDinhClassList;

            _TinhThanh_QueQuanList = TinhThanhList.GetTinhThanhList();
            TinhThanh _tinhthanhQQ = TinhThanh.NewTinhThanh(0, "<Trống>");
            TinhThanh _tinhthanhQQThem = TinhThanh.NewTinhThanh(_TinhThanh_QueQuanList.Count + 1, "<Thêm Mới...>");
            _TinhThanh_QueQuanList.Insert(0, _tinhthanhQQ);
            _TinhThanh_QueQuanList.Insert(1, _tinhthanhQQThem);
            TinhThanhQueQuan_bindingSource.DataSource = _TinhThanh_QueQuanList;

            _CongViecList = CongViecList.GetCongViecList();
            CongViec _congviec = CongViec.NewCongViec(0, "<Trống>");
            _CongViecList.Insert(0, _congviec);
            CongViecList_BindingSource.DataSource = _CongViecList;

            
        }

        public void KhoiTao(NhanVien nv)
        {
            _NhanVien = nv;
            nhanVienBindingSource.DataSource = _NhanVien;
            this.Load_Combo();
        }

        public void KhoiTaoBanDau()
        {
            this.Load_Combo();
            tlslblXoa.Visible = false;

            #region childList
            //tham gia quan doi
            if (_NhanVien.QuaTrinhTGQDList.Count == 0)
            {
                _QuaTrinhTGQD = QuaTrinhTGQD.NewQuaTrinhTGQD();
                quaTrinhTGQDBindingSource.DataSource = _QuaTrinhTGQD;
                _NhanVien.QuaTrinhTGQDList.Add(_QuaTrinhTGQD);
            }
            else
            {
                _QuaTrinhTGQD = _NhanVien.QuaTrinhTGQDList[0];
                quaTrinhTGQDBindingSource.DataSource = _QuaTrinhTGQD;
                _NhanVien.QuaTrinhTGQDList.Add(_QuaTrinhTGQD);
            }

            _QuanHamList = QuanHamList.GetQuanHamList();
            QuanHam _quanham = QuanHam.NewQuanHam(0, "<Trống>");
            _QuanHamList.Insert(0, _quanham);
            quanHamListBindingSource.DataSource = _QuanHamList;

            //hoat dong xa hoi
            if (_NhanVien.HoatDongXHList.Count == 0)
            {

                _HoatDongXaHoi = HoatDongXaHoi.NewHoatDongXaHoi();
                hoatDongXaHoi_BindingSource.DataSource = _HoatDongXaHoi;
                _NhanVien.HoatDongXHList.Add(_HoatDongXaHoi);
            }
            else
            {
                _HoatDongXaHoi = _NhanVien.HoatDongXHList[0];
                hoatDongXaHoi_BindingSource.DataSource = _HoatDongXaHoi;
                _NhanVien.HoatDongXHList.Add(_HoatDongXaHoi);
            }
            //ThueTNCN
            if (_NhanVien.NhanVienGiaCanhList.Count == 0)
            {

                //_NhanVienGiaCanhList = NhanVienGiaCanhList.NewNhanVienGiaCanhList();
             //   bindingSource1_NhanVienGiaCanhBind.DataSource = _NhanVienGiaCanhList;
                //_NhanVien.NhanVienGiaCanhList.Add(_NhanVienGiaCanh);
             //   _NhanVienGiaCanh = NhanVienGiaCanh.NewNhanVienGiaCanh();
              //  bindingSource1_NhanVienGiaCanhBind.DataSource = _NhanVienGiaCanh;
               // _NhanVien.NhanVienGiaCanhList.Add(_NhanVienGiaCanh);
            }
                
            else
            {
                _NhanVienGiaCanhList = NhanVienGiaCanhList.GetNhanVienGiaCanhList(_maNV);
                bindingSource1_NhanVienGiaCanhBind.DataSource = _NhanVienGiaCanhList;
            }
            //Tai khoan ngan hang
            _nhanVien_TaiKhoanNHList = NhanVien_TaiKhoanNganHangList.GetNhanVien_TaiKhoanNganHangList(_maNV);
            bindingSource1_NhanVienTaiKhoan.DataSource = _nhanVien_TaiKhoanNHList;
            //trinh do
            if (_NhanVien.TrinhDoList.Count == 0)
            {

                _TrinhDo = TrinhDo.NewTrinhDo();
                trinhDoBindingSource.DataSource = _TrinhDo;
                _NhanVien.TrinhDoList.Add(_TrinhDo);
            }
            else
            {
                _TrinhDo = _NhanVien.TrinhDoList[0];
                trinhDoBindingSource.DataSource = _TrinhDo;
                _NhanVien.TrinhDoList.Add(_TrinhDo);
            }
            // Thong Tin khac
            if (_NhanVien.ThongTinKhacList.Count == 0)
            {

                _ThongTinKhac = ThongTinKhac.NewThongTinKhac();
                ThongTinKhac_BindingSource.DataSource = _ThongTinKhac;
                _NhanVien.ThongTinKhacList.Add(_ThongTinKhac);
            }
            else
            {
                _ThongTinKhac = _NhanVien.ThongTinKhacList[0];
                ThongTinKhac_BindingSource.DataSource = _ThongTinKhac;
                _NhanVien.ThongTinKhacList.Add(_ThongTinKhac);
            }
            if (_NhanVien.NhanVien_EmailList.Count == 0)
            {
                _NhanVien_Email = NhanVien_Email.NewNhanVien_Email();
                nhanVienEmailBindingSource.DataSource = _NhanVien_Email;
                _NhanVien.NhanVien_EmailList.Add(_NhanVien_Email);
            }
            else
            {
                _NhanVien_Email = _NhanVien.NhanVien_EmailList[0];
                nhanVienEmailBindingSource.DataSource = _NhanVien_Email;
                _NhanVien.NhanVien_EmailList.Add(_NhanVien_Email);
            }
            //Dien thoai
            if (_NhanVien.NhanVien_DienThoai_FaxList.Count == 0)
            {
                _NhanVien_DienThoai_Fax = NhanVien_DienThoai_Fax.NewNhanVien_DienThoai_Fax();
                nhanVienDienThoaiFaxBindingSource.DataSource = _NhanVien_DienThoai_Fax;
                _NhanVien.NhanVien_DienThoai_FaxList.Add(_NhanVien_DienThoai_Fax);
            }
            else
            {
                _NhanVien_DienThoai_Fax = _NhanVien.NhanVien_DienThoai_FaxList[0];
                nhanVienDienThoaiFaxBindingSource.DataSource = _NhanVien_DienThoai_Fax;
                _NhanVien.NhanVien_DienThoai_FaxList.Add(_NhanVien_DienThoai_Fax);
            }
            //dia chi
            if (_NhanVien.DiaChi_NhanVienList.Count == 0)
            {
                _DiaChi_NhanVien = DiaChi_NhanVien.NewDiaChi_NhanVien();
                diaChiNhanVienBindingSource.DataSource = _DiaChi_NhanVien;
                _NhanVien.DiaChi_NhanVienList.Add(_DiaChi_NhanVien);
            }
            else
            {
                _DiaChi_NhanVien = _NhanVien.DiaChi_NhanVienList[0];
                diaChiNhanVienBindingSource.DataSource = _DiaChi_NhanVien;
                _NhanVien.DiaChi_NhanVienList.Add(_DiaChi_NhanVien);
            }
            #endregion
        }

        public void LayDL(NhanVien nv)
        {
            if (cmbu_ChucVu.SelectedRow != null)
            {
                nv.TenChucVu = ChucVu.GetChucVu((int)cmbu_ChucVu.Value).TenChucVu; ;
            }
            if (ultraCombo_KiemNhiem.SelectedRow != null)
            {
                nv.TenKiemNhiem = ChucVu.GetChucVu((int)ultraCombo_KiemNhiem.Value).TenChucVu;
            }
            if (txt_CardID.Text != null)
            {
                nv.CardID = txt_CardID.Text;
            }
            nv.MaBoPhan = Convert.ToInt32(_mabp); 
        }       

        #endregion

        #region Contructor
        public frmThongTinNhanVien()
        {
            InitializeComponent();
            Them();
            KhoiTaoBanDau();
            toolStripSeparator3.Visible = false;
        }
        
        public frmThongTinNhanVien(NhanVien nv)
        {
            InitializeComponent();
            KhoiTao(nv);
            LayThongTinNhanVien(nv);
        }    

        public frmThongTinNhanVien(string diaChi)
        {
            InitializeComponent();
            _diaChi = diaChi;
        }

        public frmThongTinNhanVien(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }

        public frmThongTinNhanVien(ThongTinNhanVienTongHop thongTinNhanVienTongHop, ThongTinNhanVienTongHopList _thongTinNhanVienTongHopList)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
            frmThongTinNhanVien._thongTinNhanVienTongHopList = _thongTinNhanVienTongHopList;
        }

        #endregion

        #region Events

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            // frmMainNhanSu.LoadHelp(this, "Thong tin nhan vien");
        }

        private void frmThongTinNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control&&e.KeyCode==Keys.F)
            {
                TimKiemNhanVien();
            }
            else if (e.Control && e.KeyCode == Keys.S &&tlslblLuu.Enabled==true)
            {
                if (KiemTra(_NhanVien))
                {
                    Save();
                }
            }
            else if ((e.Control && e.KeyCode == Keys.N)&&tlslblThem.Enabled==true)
            {                
                ThemMoiNhanVien();
            }
            else if (e.Shift&&e.Control && e.KeyCode == Keys.B)
            {
                //tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages["tabThongTinCoBan"];
                tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages[0];
                   
            }
            else if (e.Shift && e.Control && e.KeyCode == Keys.L)
            {
                //tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages["tabThongTinLuong"];
                tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages[1];

            }
            else if (e.Shift && e.Control && e.KeyCode == Keys.S)
            {
                //tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages["tabThongTinTrinhDo"];
                tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages[2];

            }
            else if (e.Shift && e.Control && e.KeyCode == Keys.X)
            {
                //tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages["tabHDXH"];
                tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages[3];

            }
            else if (e.Shift && e.Control && e.KeyCode == Keys.K)
            {
                //tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages["tabThongTinKhac"];
                tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages[4];

            }
            else if (e.Shift && e.Control && e.KeyCode == Keys.G)
            {
                //tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages["tabThueTNCN"];
                tbc_ThongTinNhanVien.SelectedTab = tbc_ThongTinNhanVien.TabPages[5];

            }
        }

        private void cmbu_QueQuan_Leave(object sender, EventArgs e)
        {
            if (cmbu_QueQuan.Text == "<Thêm Mới...>")
            {
                frmTinhThanh frmtt = new frmTinhThanh();
                frmtt.getData = new frmTinhThanh.PassData(GetList);
                frmtt.Show();
            }
          
        }

        private void cmbu_QuanHuyenQueQuan_Leave(object sender, EventArgs e)
        {
         
        }

        public void ChucNangThem()
        {
            //tlslblLuu.Enabled = true;
            tlslblThem.Enabled = false;
            tlslblIn.Enabled = true;

           // numeu_HeSoLuongKD.ReadOnly = false;
           // dtmp_NgayBatDauLuong.ReadOnly = false;
          //  dtmp_NgayKetThucLuong.ReadOnly = false;
            txt_CardID.ReadOnly = false;
            txtu_SoCMND.ReadOnly = false;
            tb_NhanVienNgoaiNgu.Text = string.Empty;
            tbNhanVien_ChuyenMon.Text = string.Empty;
            tbTrinhDoQuanLy.Text = string.Empty;
            tbChungChi.Text = string.Empty;
         

        }

        public void Them()
        {
            _NhanVien = NhanVien.NewNhanVien();
            nhanVienBindingSource.DataSource = _NhanVien;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {

            ThemMoiNhanVien();   
        }
        private void ThemMoiNhanVien()
        {
            ChucNangThem();
            tlslblXoa.Visible = false;
            tlslblLuu.Enabled = true;
            _NhanVien = NhanVien.NewNhanVien();
            nhanVienBindingSource.DataSource = _NhanVien;
            _NhanVien.MaQLNhanVien = Maqlmoinhat;
            SetDefaultValues();
            cmbu_ChucVu.Text = "Công Nhân";
            cmbu_GioiTinh.Text = "Nữ";
            if (_NhanVien.QuaTrinhTGQDList.Count == 0)
            {
                _QuaTrinhTGQD = QuaTrinhTGQD.NewQuaTrinhTGQD();
                quaTrinhTGQDBindingSource.DataSource = _QuaTrinhTGQD;
                _NhanVien.QuaTrinhTGQDList.Add(_QuaTrinhTGQD);
            }
            else
            {
                _QuaTrinhTGQD = _NhanVien.QuaTrinhTGQDList[0];
                quaTrinhTGQDBindingSource.DataSource = _QuaTrinhTGQD;
                _NhanVien.QuaTrinhTGQDList.Add(_QuaTrinhTGQD);
            }
            //hoat dong xa hoi
            if (_NhanVien.HoatDongXHList.Count == 0)
            {

                _HoatDongXaHoi = HoatDongXaHoi.NewHoatDongXaHoi();
                hoatDongXaHoi_BindingSource.DataSource = _HoatDongXaHoi;
                _NhanVien.HoatDongXHList.Add(_HoatDongXaHoi);
            }
            else
            {
                _HoatDongXaHoi = _NhanVien.HoatDongXHList[0];
                hoatDongXaHoi_BindingSource.DataSource = _HoatDongXaHoi;
                _NhanVien.HoatDongXHList.Add(_HoatDongXaHoi);
            }
            //ThueTNCN
            if (_NhanVien.NhanVienGiaCanhList.Count == 0)
            {
                _NhanVien.NhanVienGiaCanhList = NhanVienGiaCanhList.NewNhanVienGiaCanhList();

                //_NhanVienGiaCanh = NhanVienGiaCanh.NewNhanVienGiaCanh();
                nhanVienGiaCanhListBindingSource1.DataSource = _NhanVien.NhanVienGiaCanhList;
                // _NhanVien.NhanVienGiaCanhList.Add(_NhanVienGiaCanh);
            }
            else
            {
                _NhanVienGiaCanh = _NhanVien.NhanVienGiaCanhList[0];
                nhanVienGiaCanhListBindingSource1.DataSource = _NhanVienGiaCanh;
                _NhanVien.NhanVienGiaCanhList.Add(_NhanVienGiaCanh);
            }
            //Tài Khoản NH
            if (_NhanVien.NhanVienTaiKhoanNganHangList.Count == 0)
            {
                _NhanVien.NhanVienTaiKhoanNganHangList = NhanVien_TaiKhoanNganHangList.NewNhanVien_TaiKhoanNganHangList();
                bindingSource1_NhanVienTaiKhoan.DataSource = _NhanVien.NhanVienTaiKhoanNganHangList;
                
            }
            else
            {
               
                _NhanVien_TaiKhoanNH = _NhanVien.NhanVienTaiKhoanNganHangList[0];
                bindingSource1_NhanVienTaiKhoan.DataSource = _NhanVien_TaiKhoanNH;
                _NhanVien.NhanVienTaiKhoanNganHangList.Add(_NhanVien_TaiKhoanNH);

            }
            //trinh do
            if (_NhanVien.TrinhDoList.Count == 0)
            {

                _TrinhDo = TrinhDo.NewTrinhDo();
                trinhDoBindingSource.DataSource = _TrinhDo;
                _NhanVien.TrinhDoList.Add(_TrinhDo);
            }
            else
            {
                _TrinhDo = _NhanVien.TrinhDoList[0];
                trinhDoBindingSource.DataSource = _TrinhDo;
                _NhanVien.TrinhDoList.Add(_TrinhDo);
            }
            // Thong Tin khac
            if (_NhanVien.ThongTinKhacList.Count == 0)
            {

                _ThongTinKhac = ThongTinKhac.NewThongTinKhac();
                ThongTinKhac_BindingSource.DataSource = _ThongTinKhac;
                _NhanVien.ThongTinKhacList.Add(_ThongTinKhac);
            }
            else
            {
                _ThongTinKhac = _NhanVien.ThongTinKhacList[0];
                ThongTinKhac_BindingSource.DataSource = _ThongTinKhac;
                _NhanVien.ThongTinKhacList.Add(_ThongTinKhac);
            }
            if (_NhanVien.NhanVien_EmailList.Count == 0)
            {
                _NhanVien_Email = NhanVien_Email.NewNhanVien_Email();
                nhanVienEmailBindingSource.DataSource = _NhanVien_Email;
                _NhanVien.NhanVien_EmailList.Add(_NhanVien_Email);
            }
            else
            {
                _NhanVien_Email = _NhanVien.NhanVien_EmailList[0];
                nhanVienEmailBindingSource.DataSource = _NhanVien_Email;
                _NhanVien.NhanVien_EmailList.Add(_NhanVien_Email);
            }
            //Dien thoai
            if (_NhanVien.NhanVien_DienThoai_FaxList.Count == 0)
            {
                _NhanVien_DienThoai_Fax = NhanVien_DienThoai_Fax.NewNhanVien_DienThoai_Fax();
                nhanVienDienThoaiFaxBindingSource.DataSource = _NhanVien_DienThoai_Fax;
                _NhanVien.NhanVien_DienThoai_FaxList.Add(_NhanVien_DienThoai_Fax);
            }
            else
            {
                _NhanVien_DienThoai_Fax = _NhanVien.NhanVien_DienThoai_FaxList[0];
                nhanVienDienThoaiFaxBindingSource.DataSource = _NhanVien_DienThoai_Fax;
                _NhanVien.NhanVien_DienThoai_FaxList.Add(_NhanVien_DienThoai_Fax);
            }
            //dia chi
            if (_NhanVien.DiaChi_NhanVienList.Count == 0)
            {
                _DiaChi_NhanVien = DiaChi_NhanVien.NewDiaChi_NhanVien();
                diaChiNhanVienBindingSource.DataSource = _DiaChi_NhanVien;
                _NhanVien.DiaChi_NhanVienList.Add(_DiaChi_NhanVien);
            }
            else
            {
                _DiaChi_NhanVien = _NhanVien.DiaChi_NhanVienList[0];
                diaChiNhanVienBindingSource.DataSource = _DiaChi_NhanVien;
                _NhanVien.DiaChi_NhanVienList.Add(_DiaChi_NhanVien);
            }
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
           if ((!ERP_Library.Security.CurrentUser.Info.CapNhatHoSo) && (_NhanVien.IsDirty == true && (_NhanVien.LoaiNV != 5 && _NhanVien.LoaiNV != 6)))
            {
                
                {
                    MessageBox.Show("Bạn không có quyền chỉnh sửa loại Nhân Viên này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            Xulymatruockhiluu();
            XuLyBoPhanKhiLoad(_mabp);
            if (cmbu_ChucVu.ActiveRow != null)
                _NhanVien.MaChucVu = Convert.ToInt32(cmbu_ChucVu.ActiveRow.Cells["MaChucVu"].Value);         
            nhanVienBindingSource.EndEdit();
            if (KiemTra(_NhanVien))
            {
                Save();
            }

        }
        private void Save()
        {
            try
            {
                if (KiemTraTaiKhoanNganHang() == false)
                    return;
                if (_NhanVien.IsNew == true) // là đối tượng mới
                {
                    LayDL(_NhanVien);
                    _NhanVien.ApplyEdit();
                    _NhanVien.Save();                  
                    tlslblThem.Enabled = true;
                }
                else // là đối tượng cũ 
                {
                    LayDL(_NhanVien);
                    _NhanVien.NhanVienGiaCanhList = (NhanVienGiaCanhList)this.nhanVienGiaCanhListBindingSource1.DataSource;
                    _NhanVien.NhanVienTaiKhoanNganHangList = (NhanVien_TaiKhoanNganHangList)this.bindingSource1_NhanVienTaiKhoan.DataSource;
                    nhanVienBindingSource.EndEdit();
                    _NhanVien.ApplyEdit();
                    _NhanVien.Data_Update();   
                    //Load thông tin nhân viên
                    _NhanVien = NhanVien.GetNhanVien(_NhanVien.MaNhanVien);
                    nhanVienBindingSource.DataSource = _NhanVien;
                    ThongTinKhac_BindingSource.DataSource = _NhanVien.ThongTinKhacList;
                    LayThongTinNhanVien(_NhanVien);
                    _maNV = _NhanVien.MaNhanVien;
                }
                MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

       
     
        public static void InsertChildNhanVIen()
        {
            NhanVienList nvList = NhanVienList.GetNhanVienList();

            //ThongTinKhacList _tempList = ThongTinKhacList.GetThongTinKhacList();
            ThongTinKhacList ttkList = ThongTinKhacList.NewThongTinKhacList();

            //HoatDongXaHoiList _tempLisst = HoatDongXaHoiList.GetHoatDongXaHoiList();
            HoatDongXaHoiList hddxhLisst = HoatDongXaHoiList.NewHoatDongXaHoiList();
            TrinhDoList trinhDoList = TrinhDoList.NewTrinhDoList();
            NhanVien_NgoaiNguList _ngoaiNguList = NhanVien_NgoaiNguList.NewNhanVien_NgoaiNguList();

            NhanVien_TrinhDoQuanLyList _trinhDoQuanLyList = NhanVien_TrinhDoQuanLyList.NewNhanVien_TrinhDoQuanLyList();
            for (int i = 0; i < nvList.Count; i++)
            {
                if (nvList[i].ThongTinKhacList.Count == 0)
                {
                    ThongTinKhac ttk = ThongTinKhac.NewThongTinKhac();
                    ttk.MaNhanVien = nvList[i].MaNhanVien;
                    nvList[i].ThongTinKhacList.AddNew();
                    nvList[i].ThongTinKhacList[0].MaNhanVien = nvList[i].MaNhanVien;
                }
                if (nvList[i].TrinhDoList.Count == 0)
                {
                    TrinhDo td = TrinhDo.NewTrinhDo();
                    td.MaNhanVien = nvList[i].MaNhanVien;
                    nvList[i].TrinhDoList.AddNew();
                    nvList[i].TrinhDoList[0].MaNhanVien = nvList[i].MaNhanVien;
                }
                if (nvList[i].HoatDongXHList.Count == 0)
                {
                    HoatDongXaHoi hdxh = HoatDongXaHoi.NewHoatDongXaHoi();
                    hdxh.MaNhanVien = nvList[i].MaNhanVien;
                    nvList[i].HoatDongXHList.AddNew();
                    nvList[i].HoatDongXHList[0].MaNhanVien = nvList[i].MaNhanVien;
                }
                    
                nvList[i].GhiChu = DateTime.Now.ToLongTimeString();
            }

            nvList.ApplyEdit();
            nvList.Save();
        }
        public static void UpDateChildNhanVIen()
        {
            NhanVienList nvList = NhanVienList.GetNhanVienList();

            for (int i = 0; i < nvList.Count; i++)
            {
                HoatDongXaHoiList h = HoatDongXaHoiList.GetHoatDongXaHoiList(nvList[i].MaNhanVien);
                for (int j = 0; j < h.Count; j++)
                {
                    h[j].NguoiGioiThieu2 = "Chưa Biết";
                }
                TrinhDoList td = TrinhDoList.GetTrinhDoList(nvList[i].MaNhanVien);
                for (int k = 0; k < td.Count; k++)
                {
                    td[k].MaNhanVien = nvList[i].MaNhanVien;
                }
                ThongTinKhacList ttk = ThongTinKhacList.GetThongTinKhacList(nvList[i].MaNhanVien);
                for (int k = 0; k < td.Count; k++)
                {
                    ttk[k].MaNhanVien = nvList[i].MaNhanVien;
                }
                nvList[i].GhiChu = DateTime.Now.Date.ToString();
                nvList[i].HoatDongXHList = h;
                nvList[i].TrinhDoList = td;
                nvList[i].ThongTinKhacList = ttk;
            }

            nvList.ApplyEdit();
            nvList.Save();
        }
         private bool KiemTraNPT(NhanVien nhanVien)
        {
            
            for (int i = 0; i < nhanVien.NhanVienGiaCanhList.Count; i++)
            {
                string cmnd = QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).Cmnd;
                int kiemTra = NhanVienGiaCanh.KiemTraCMND_GiaCanhDuyNhat(cmnd,nhanVien.MaNhanVien);
                if (kiemTra > 0)
                {
                    MessageBox.Show(QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).HoTenNguoiThan.ToString() + " đã được khai báo người phụ thuộc, Xin vui lòng kiểm tra lại CMND.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (NhanVienGiaCanh.KiemTraHoChieu_GiaCanhDuyNhat(QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).HoChieu,nhanVien.MaNhanVien) > 0)
                {
                    MessageBox.Show(QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).HoTenNguoiThan.ToString() + " đã được khai báo người phụ thuộc, Xin vui lòng kiểm tra lại Hộ Chiếu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            
            return true;
        }
        //Hàm mặc định giá trị cho một vài field trong tblnsNhanVien
        private void SetDefaultValues()
        {
            cmbu_LoaiNV.SelectedIndex = 0;//Công nhân
            cmbu_QuocTich.Value = 10;//Việt Nam
        }

        private void btn_FileAnh_Click(object sender, EventArgs e)
        {
            _Path = Application.StartupPath;
            _OpenFileDialog = new OpenFileDialog();
            _OpenFileDialog.Title = "Chọn file cần đính kèm";
            _OpenFileDialog.InitialDirectory = _Path;
            if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {                
                value = ConvertFileToBinary(_OpenFileDialog);               
                _NhanVien.FileAnh = value;
            }            
        }

        private void dtmp_NgayVaoNganh_Leave(object sender, EventArgs e)
        {
            //dtmp_NgayTinhThamNien.Value = dtmp_NgayVaoNganh.Value;
        }

        public void TimNhanVienTheoMa(string maQLNhanVien)
        {           
                    _NhanVien = NhanVien.GetNhanVienByMaQL(maQLNhanVien);
                    nhanVienBindingSource.DataSource = _NhanVien;

                    ////_ChucVuList = ChucVuList.NewChucVuList();
                    ////_ChucVuList = ChucVuList.GetChucVuList(4);
                    ////chucVuListBindingSource.DataSource = _ChucVuList;

                    ////_CongViecList = CongViecList.NewCongViecList();
                    ////_CongViecList = CongViecList.GetCongViecList();
                    //CongViecList_BindingSource.DataSource = _CongViecList;

                    LayThongTinNhanVien(_NhanVien);
           
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiemNhanVien();

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
                    pctbx_HinhNhanVien.Image = null;
                    _NhanVien = NhanVien.GetNhanVien(_ThongTinNhanVienTongHop.MaNhanVien);
                    nhanVienBindingSource.DataSource = _NhanVien;
                    bindingSource1_NhanVienNgoaiNgu.DataSource = _nhanVien_NgoaiNguList;
                    bindingSource1_NhanVien_TrinhDoQuanLy.DataSource = _NhanVien.NhanVienTrinhDoQuanLyList;
                    ThongTinKhac_BindingSource.DataSource = _NhanVien.ThongTinKhacList;
                    //chucVuListBindingSource.DataSource = _NhanVien.MaChucVu;
                    //ChucDanh_BindingSource.DataSource = _NhanVien.MaChucDanh;
                    _ChucVuList = ChucVuList.GetChucVuList();
                    ChucVu _chucVu = ChucVu.NewChucVu(0, "<Trống>");
                    _ChucVuList.Insert(0, _chucVu);
                    chucVuListBindingSource.DataSource = _ChucVuList;

                    _ChucDanhList = ChucDanhList.GetChucDanhList();
                    ChucDanh _chucdanh = ChucDanh.NewChucDanh(0, "<Trống>");
                    _ChucDanhList.Insert(0, _chucdanh);
                    ChucDanh_BindingSource.DataSource = _ChucDanhList;
                    LayThongTinNhanVien(_NhanVien);
                    _maNV = _NhanVien.MaNhanVien;
                    tlslblLuu.Enabled = true;
                    tlslblXoa.Visible = true;
                    hoatDongXaHoi_BindingSource.DataSource = _NhanVien.HoatDongXHList;
                    chuyenNganhDaoTaoClassListBindingSource.DataSource = _NhanVien.NhanVienChuyenNganhList;
                    trinhDoBindingSource.DataSource = _NhanVien.TrinhDoList;
                    _nhanVien_TrinhDoQuanLyList = _NhanVien.NhanVienTrinhDoQuanLyList;

                }
            }
         

        }
      
        private void cmbu_Congdoan_Leave(object sender, EventArgs e)
        {
            //if (cbBoPhan_To.ActiveRow != null)
            //{
            //    this.Xulymatruockhiluu();
            //}
        }

        private void ResetSelectedCombo(UltraCombo cmb) // Bo dong them moi khi khong chon 
        {

            if (cmb.Text == "<Thêm Mới...>")
            {
                cmb.Text = "<Trống>";
            }

        }

        private void cmbu_QuocTich_ValueChanged(object sender, EventArgs e)
        {
           

        }

        private void cmbuNoiSinh_Leave(object sender, EventArgs e)
        {
            if (cmbuNoiSinh.Text == "<Thêm Mới...>")
            {
                frmTinhThanh frmtt = new frmTinhThanh();
                frmtt.getData = new frmTinhThanh.PassData(GetList);
                frmtt.ShowDialog();
            }
           
        }

        private void cmbu_DanToc_Leave(object sender, EventArgs e)
        {
            //ResetSelectedCombo((UltraCombo)sender);
            if (cmbu_DanToc.Text == "<Thêm Mới...>")
            {
                frmDanToc frmdt = new frmDanToc();
                frmdt.getData = new frmDanToc.PassData(GetList);
                frmdt.ShowDialog();
            }
        }

        private void cmbu_TonGiao_Leave(object sender, EventArgs e)
        {
            //ResetSelectedCombo((UltraCombo)sender);
            if (cmbu_TonGiao.Text == "<Thêm Mới...>")
            {
                frmTonGiao frmtg = new frmTonGiao();
                frmtg.getdata = new frmTonGiao.PassData(GetList);
                frmtg.ShowDialog();
            }
        }

 
        private void ucmb_TrinhDoHocVan_Leave(object sender, EventArgs e)
        {
            //ResetSelectedCombo((UltraCombo)sender);
            if (ucmb_TrinhDoHocVan.Text == "<Thêm Mới...>")
            {
                frmTrinhDoHocVan frmtdhv = new frmTrinhDoHocVan();
                frmtdhv.getData = new frmTrinhDoHocVan.PassData(GetList);
                frmtdhv.ShowDialog();
            }
        }

  
        private void cmbu_UuTienGD_Leave(object sender, EventArgs e)
        {
            //ResetSelectedCombo((UltraCombo)sender);
            if (cmbu_UuTienGD.Text == "<Thêm Mới...>")
            {
                frmUuTienGiaDinh frmutgd = new frmUuTienGiaDinh();
                frmutgd.getData = new frmUuTienGiaDinh.PassData(GetList);
                frmutgd.ShowDialog();
            }

        }

        private void cmbu_UuTienBanThan_Leave(object sender, EventArgs e)
        {
            //ResetSelectedCombo((UltraCombo)sender);
            if (cmbu_UuTienBanThan.Text == "<Thêm Mới...>")
            {
                frmUuTienBanThan frmutbt = new frmUuTienBanThan();
                frmutbt.getData = new frmUuTienBanThan.PassData(GetList);
                frmutbt.ShowDialog();
            }
        }

       
        private void cmbu_DCThT_Tinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_DCThT_Tinh.ActiveRow != null)
            {
                _QuanHuyen_ThT = QuanHuyenList.GetQuanHuyenList((int)cmbu_DCThT_Tinh.Value);
                QuanHuyen _Quanhuyentht = QuanHuyen.NewQuanHuyen("<Trống>",0);
                QuanHuyen _QuanhuyenthtThem = QuanHuyen.NewQuanHuyen("<Thêm Mới...>",_QuanHuyen_ThT.Count + 1);
                _QuanHuyen_ThT.Insert(0, _Quanhuyentht);
                _QuanHuyen_ThT.Insert(1, _QuanhuyenthtThem);
                BindS_QuanHuyenThT.DataSource = _QuanHuyen_ThT;
            }
        }

        private void cmbu_DCTT_Tinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_DCTT_Tinh.ActiveRow != null)
            {
                _QuanHuyen_TT = QuanHuyenList.GetQuanHuyenList((int)cmbu_DCTT_Tinh.Value);
                QuanHuyen _Quanhuyentt = QuanHuyen.NewQuanHuyen("<Trống>", 0);             
                BindS_QuanhuyenTT.DataSource = _QuanHuyen_TT;
            }
        }

        #region Email, DiaChi, DienThoai

        #region btn_Email_Click
        private void btn_Email_Click(object sender, EventArgs e)
        {
            //cmustrip_Email.Show(btn_Email, new Point(10, 10));
            frmDanhSachEmailNhanVien f = new frmDanhSachEmailNhanVien(_NhanVien.NhanVien_EmailList);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                _NhanVien.NhanVien_EmailList= f._NhanVien_EmailList;
               
            }
        }
        #endregion

        #region btn_DiaChi_Click
        private void btn_DiaChi_Click(object sender, EventArgs e)
        {
            //cmustrip_DiaChi.Show(btn_DiaChi,new Point(10,10));
            frmDanhSachDiaChiNhanVien f = new frmDanhSachDiaChiNhanVien(_NhanVien.DiaChi_NhanVienList);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                _NhanVien.DiaChi_NhanVienList = f._DiaChi_NhanVienList;
                foreach (DiaChi_NhanVien dc in _NhanVien.DiaChi_NhanVienList)
                {
                    if (dc.Active == true)
                    {
                       // txtu_DiaChi1.Text = dc.TenDiaChi + ", " + dc.QuanHuyen + ", " + dc.TinhTP + ", " + dc.QuocGia;
                    }
                }
            }
        }
        #endregion

        #region btn_DienThoai_Click
        private void btn_DienThoai_Click(object sender, EventArgs e)
        {
            //cmustrip_DienThoai.Show(btn_DienThoai,new Point(10,10));
            frmDanhSachSoDienThoaiNhanVien f = new frmDanhSachSoDienThoaiNhanVien(_NhanVien.NhanVien_DienThoai_FaxList);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                _NhanVien.NhanVien_DienThoai_FaxList = f._NhanVien_DienThoai_FaxList;
                if(_NhanVien.NhanVien_DienThoai_FaxList.Count != 0)
                    txtu_DienThoaiThT.Text = _NhanVien.NhanVien_DienThoai_FaxList[0].SoDTFax;
            }
        }
        #endregion

        #region tstrip_DiaChi1_Click
        private void tstrip_DiaChi1_Click(object sender, EventArgs e)
        {
            frmDiaChi_NhanVien _frmDiaChi_NhanVien = new frmDiaChi_NhanVien();
            if (_frmDiaChi_NhanVien.ShowDialog(this) != DialogResult.OK)
            {
               // txtu_DiaChi1.Text = _frmDiaChi_NhanVien._diaChi;
               // _NhanVien.DiaChi_NhanVienList =_frmDiaChi_NhanVien._DiaChi_NhanVienList;
            }
            //txtu_DiaChi1.Enabled = true;
            //txtu_DiaChi2.Enabled = false;
            //txtu_DiaChi3.Enabled = false;

           // txtu_DiaChi1.Visible = true;
          //  txtu_DiaChi2.Visible = false;
           // txtu_DiaChi3.Visible = false;
        }
        #endregion

        #region tstrip_DiaChi2_Click
        private void tstrip_DiaChi2_Click(object sender, EventArgs e)
        {
            //frmDiaChi_NhanVien _frmDiaChi_NhanVien = new frmDiaChi_NhanVien();
            //if (_frmDiaChi_NhanVien.ShowDialog(this) != DialogResult.OK)
            //{
            //    txtu_DiaChi2.Text = _diaChi;
            //}
            //txtu_DiaChi1.Enabled = false;
            //txtu_DiaChi2.Enabled = true;
            //txtu_DiaChi3.Enabled = false;

            //txtu_DiaChi1.Visible = false;
            //txtu_DiaChi2.Visible = true;
            //txtu_DiaChi3.Visible = false;
        }
        #endregion

        #region tstrip_DiaChi3_Click
        private void tstrip_DiaChi3_Click(object sender, EventArgs e)
        {
            //frmDiaChi_NhanVien _frmDiaChi_NhanVien = new frmDiaChi_NhanVien();
            //if (_frmDiaChi_NhanVien.ShowDialog(this) != DialogResult.OK)
            //{
            //    txtu_DiaChi3.Text = _diaChi;
            //}
            //txtu_DiaChi1.Enabled = false;
            //txtu_DiaChi2.Enabled = false;
            //txtu_DiaChi3.Enabled = true;

            //txtu_DiaChi1.Visible = false;
            //txtu_DiaChi2.Visible = false;
            //txtu_DiaChi3.Visible = true;
        }
        #endregion

        #region tstrip_Email2_Click
        private void strip_Email1_Click(object sender, EventArgs e)
        {
           
          //  txtu_Email2.Visible = false;
          //  txtu_Email3.Visible = false;
        }
        #endregion

     
     

        #region tstrip_DienThoai1_Click
        private void tstrip_DienThoai1_Click(object sender, EventArgs e)
        {
            txtu_DienThoaiThT.Visible = true;
            //txtu_DienThoai2.Visible = false;
            //txtu_DienThoai3.Visible = false;
        }
        #endregion

        #region tstrip_DienThoai2_Click
        private void tstrip_DienThoai2_Click(object sender, EventArgs e)
        {
            txtu_DienThoaiThT.Visible = false;
            //txtu_DienThoai2.Visible = true;
            //txtu_DienThoai3.Visible = false;
        }
        #endregion

        #region tstrip_DienThoai3_Click
        private void tstrip_DienThoai3_Click(object sender, EventArgs e)
        {
            //txtu_DienThoaiThT.Visible = false;
            //txtu_DienThoai2.Visible = false;
            //txtu_DienThoai3.Visible = true;
        }
        #endregion

        #endregion

        #region ValueChanged  


      


        private void cmbu_QueQuan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_QueQuan.ActiveRow != null)
            {
                _QuanHuyen_QueQuanList = QuanHuyenList.GetQuanHuyenList((int)cmbu_QueQuan.Value);
                QuanHuyen _QuanhuyenQQ = QuanHuyen.NewQuanHuyen("<Trống>",0);
                QuanHuyen _QuanhuyenQQThem = QuanHuyen.NewQuanHuyen( "<Thêm Mới...>",_QuanHuyen_QueQuanList.Count+1);
                _QuanHuyen_QueQuanList.Insert(0, _QuanhuyenQQ);
                _QuanHuyen_QueQuanList.Insert(1, _QuanhuyenQQThem);
                QuanHuyenQueQuan_bindingSource.DataSource = _QuanHuyen_QueQuanList;
            }        
        }

        private void cmbu_QuanHuyenQueQuan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_QueQuan.Text == "<Thêm Mới...>")
            {
                frmQuanHuyen frmqh = new frmQuanHuyen();
                frmqh.getData = new frmQuanHuyen.PassData(GetList);
                frmqh.Show();
            }
        }

        private void cmbu_QuanHuyenNoiSinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_QueQuan.Text == "<Thêm Mới...>")
            {
                frmQuanHuyen frmqh = new frmQuanHuyen();
                frmqh.getData = new frmQuanHuyen.PassData(GetList);
                frmqh.Show();
            }
        }

        private void cmbuNoiSinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbuNoiSinh.ActiveRow != null)
            {
                _QuanHuyen_NoiSinhList = QuanHuyenList.GetQuanHuyenList((int)cmbuNoiSinh.Value);
                QuanHuyen _QuanhuyenNoisinh = QuanHuyen.NewQuanHuyen( "<Trống>",0);
                QuanHuyen _QuanhuyenNoisinhThem = QuanHuyen.NewQuanHuyen( "<Thêm Mới...>",_QuanHuyen_NoiSinhList.Count+1);
                _QuanHuyen_NoiSinhList.Insert(0, _QuanhuyenNoisinh);
                _QuanHuyen_NoiSinhList.Insert(1, _QuanhuyenNoisinhThem);
                QuanHuyenNoiSinh_BindingSource.DataSource = _QuanHuyen_NoiSinhList;
            }  
        }

        private void cmbu_NoiCapTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_NoiCapTaiKhoan.Text == "<Thêm Mới...>")
            {
                frmNganHang frmnh = new frmNganHang();
                frmnh.getData = new frmNganHang.PassData(GetList);
                frmnh.Show();
            }
        }

        private void cmbuChucDanhCV_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbuChucDanhCV.Text == "<Thêm Mới...>")
            //{
            //    frmChucDanh ffrmcd = new frmChucDanh();
            //    ffrmcd.getData = new frmChucDanh.PassData(GetList);
            //    ffrmcd.Show();
            //}
        }
   
        private void cmbu_NoiCap_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_NoiCap.Text == "<Thêm Mới...>")
            {
                frmTinhThanh frmtt = new frmTinhThanh();
                frmtt.getData = new frmTinhThanh.PassData(GetList);
                frmtt.Show();
            }
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
       {
        //    if (txtu_MaNhanVien.Text != "")
        //    {
        //        DialogResult = MessageBox.Show(this, "Bạn chỉ có thể cho nhân viên nghỉ việc.Bạn có muốn tiếp tục? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //        if (DialogResult == DialogResult.Yes)
        //        {
        //            frmNghiViecChamDutHD f = new frmNghiViecChamDutHD();
        //            f.ShowDialog(this);
        //            nhanVienBindingSource.DataSource = NhanVien.GetNhanVien(0);
                    
        //            /*
        //            NhanVien.XoaNV(_NhanVien);
        //            MessageBox.Show(this, "Xóa Nhân Viên Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //          */

                    
                   
        //        }
        //        //else if(DialogResult==DialogResult.No)
            //}
           DialogResult = MessageBox.Show(this, "Xóa Nhân Viên sẽ xóa các thông tin kèm theo. Bạn có muốn tiếp tục? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           if (DialogResult == DialogResult.Yes)
           {
              
               NhanVien.XoaNV(_NhanVien);
               MessageBox.Show(this, "Xóa Nhân Viên Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
           



           }
        }

    
        private void cmbu_ChucVu_Leave(object sender, EventArgs e)
        {
      
            //if (cmbu_ChucVu.ActiveRow != null)
            //{
            //    if (cmbu_ChucVu.Text == "<Thêm Mới...>")
            //    {
            //        frmChucVu frmcv = new frmChucVu();
            //        frmcv.passData = new frmChucVu.PassData(GetList);
            //        frmcv.ShowDialog();
            //    }
            //}

        }

        private void cmbu_QuocTich_Leave(object sender, EventArgs e)
        {
            if (cmbu_QuocTich.Text == "<Thêm Mới...>")
            {
                frmQuocGia frmQg = new frmQuocGia();
                frmQg.getData = new frmQuocGia.PassData(GetList);
                frmQg.ShowDialog();
            }
        }

        private void cmbu_ThanhPhanGD_Leave(object sender, EventArgs e)
        {
            if (cmbu_ThanhPhanGD.Text == "<Thêm Mới...>")
            {
                frmThanhPhanGiaDinh frmtpgd = new frmThanhPhanGiaDinh();
                frmtpgd.getData = new frmThanhPhanGiaDinh.PassData(GetList);
                frmtpgd.ShowDialog();
            }
        }      

        private void cmbu_TrinhDoTinHoc_Leave(object sender, EventArgs e)
        {
            if (cmbu_TrinhDoTinHoc.Text == "<Thêm Mới...>")
            {
                frmTrinhDoTinHoc frmtdth = new frmTrinhDoTinHoc();
                frmtdth.getData = new frmTrinhDoTinHoc.PassData(GetList);
                frmtdth.ShowDialog();
            }
        }

        private void cmbu_LyLuanChinhTri_Leave(object sender, EventArgs e)
        {
          //  ResetSelectedCombo((UltraCombo)sender);
            if (cmbu_LyLuanChinhTri.Text == "<Thêm Mới...>")
            {
               
                    frmLyLuanChinhTri frmtt = new frmLyLuanChinhTri();
                    frmtt.getData = new frmLyLuanChinhTri.PassData(GetList);
                    frmtt.ShowDialog();
               
            }
        }

        #endregion

        #endregion

        #region InitializeLayout

        private void cmbu_DCThT_Tinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = true;
            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["MaKhuVuc"].Hidden = true;
            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["MaQuocGia"].Hidden = true;
            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["MaTinhThanhQuanLy"].Hidden = true;

            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên Tỉnh Thành";
            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.VisiblePosition = 0;
            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Width = cmbu_DCThT_Tinh.Width;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            //this.cmbu_DCThT_Tinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.cmbu_DCThT_Tinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        private void cmbu_DCTT_Tinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = true;
            cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns["MaKhuVuc"].Hidden = true;
            cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns["MaQuocGia"].Hidden = true;
            cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns["MaTinhThanhQuanLy"].Hidden = true;

            cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên Tỉnh Thành";
            cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.VisiblePosition = 0;
            cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Width = cmbu_DCTT_Tinh.Width;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            //màu nền
            cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Hidden = false;
            cmbu_DCTT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên Tỉnh Thành";
            //this.cmbu_DCTT_Tinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.cmbu_DCTT_Tinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo ft = new FilterCombo(cmbu_DCTT_Tinh, "TenTinhThanh");
        }      
        private void cmbu_PXBoPhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cbBoPhan_Ban.DisplayLayout.Bands[0],
              new string[2] { "Tenbophan", "MaBophan" },
              new string[2] { "Bộ Phận", "Mã số" },
              new int[2] { cbBoPhan_Ban.Width, 90 },
              new Control[2] { null, null },
              new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
              new bool[2] { false, false });
            cbBoPhan_Ban.DisplayLayout.Bands[0].Columns["Tenbophan"].CellAppearance.TextHAlign = HAlign.Left;
            cbBoPhan_Ban.DisplayLayout.Bands[0].Columns["Mabophan"].Hidden = true;
            FilterCombo f = new FilterCombo(cbBoPhan_Ban, "Tenbophan");
        }
        private void cmbu_Chuyento_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbBoPhan_PhongBan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbBoPhan_PhongBan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbBoPhan_PhongBan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbBoPhan_PhongBan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cbBoPhan_PhongBan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cbBoPhan_PhongBan.Width;
            cbBoPhan_PhongBan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbBoPhan_PhongBan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbBoPhan_PhongBan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
            FilterCombo f = new FilterCombo(cbBoPhan_PhongBan, "Tenbophan");
        }
        private void cmbu_Congdoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbBoPhan_To.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbBoPhan_To.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbBoPhan_To.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbBoPhan_To.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cbBoPhan_To.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cbBoPhan_To.Width;
            cbBoPhan_To.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbBoPhan_To.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbBoPhan_To.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
            FilterCombo f = new FilterCombo(cbBoPhan_To, "Tenbophan");
        }
         private void cmbu_NoiCapTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_NoiCapTaiKhoan.DisplayLayout.Bands[0].Columns["MaNganHang"].Hidden = true;
            cmbu_NoiCapTaiKhoan.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            cmbu_NoiCapTaiKhoan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = true;

            cmbu_NoiCapTaiKhoan.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";

            cmbu_NoiCapTaiKhoan.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 0;
            cmbu_NoiCapTaiKhoan.DisplayLayout.Bands[0].Columns["TenNganHang"].Width = 137;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_NoiCapTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            //this.cmbu_NoiCapTaiKhoan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.cmbu_NoiCapTaiKhoan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        private void ucmb_TrinhDoHocVan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.ucmb_TrinhDoHocVan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            //màu nền
            ucmb_TrinhDoHocVan.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Hidden = false;
            ucmb_TrinhDoHocVan.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Width = ucmb_TrinhDoHocVan.Width;            
            ucmb_TrinhDoHocVan.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Header.Caption = "Trình Độ Học Vấn";
            ucmb_TrinhDoHocVan.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Header.VisiblePosition = 0;
            
            this.ucmb_TrinhDoHocVan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.ucmb_TrinhDoHocVan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        private void cmbu_TrinhDoTinHoc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Hidden = false;
            cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Header.Caption = "Tên Trình Độ Tin Học";
            cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Header.VisiblePosition = 0;
            cmbu_TrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Width = cmbu_TrinhDoTinHoc.Width;
            //màu nền
            this.cmbu_TrinhDoTinHoc.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_TrinhDoTinHoc.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        private void cmbu_LyLuanChinhTri_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_LyLuanChinhTri.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_LyLuanChinhTri.DisplayLayout.Bands[0].Columns["LyLuanCT"].Hidden = false;
            cmbu_LyLuanChinhTri.DisplayLayout.Bands[0].Columns["LyLuanCT"].Header.Caption = "Tên Lý Luận Chính Trị";
            cmbu_LyLuanChinhTri.DisplayLayout.Bands[0].Columns["LyLuanCT"].Header.VisiblePosition = 0;
            cmbu_LyLuanChinhTri.DisplayLayout.Bands[0].Columns["LyLuanCT"].Width = cmbu_LyLuanChinhTri.Width;
            //màu nền
            this.cmbu_LyLuanChinhTri.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_LyLuanChinhTri.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        private void cmbu_ChucVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = cmbu_ChucVu.Width;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            //cmbu_ChucVu.DisplayLayout.Bands[0].Columns["MaNhomChucVu"].Hidden = true;
            //cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Hidden = true;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Hidden = true;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 0;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = 145;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_ChucVu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            cmbu_ChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            
            //màu nền
            this.cmbu_ChucVu.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_ChucVu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo ft = new FilterCombo(cmbu_ChucVu, "TenChucVu");
           
        }
        private void cmbu_KiemNhiem_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        //    cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
        //    //cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["MaNhomChucVu"].Hidden = true;
        //    //cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Hidden = true;

        //    cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Kiêm Nhiệm";
        //    cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Hidden = true;
        //    cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
        //    cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            
        //    cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 0;
        //    cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = 135;
        //    //màu và font chữ
        //    foreach (UltraGridColumn col in this.cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns)
        //    {
        //        col.Hidden = true;
        //        col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
        //        col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //        col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
        //    }
        //    //màu nền
        //    cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
        //    cmbu_KiemNhiem.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Kiêm Nhiệm";
            
        //    this.cmbu_KiemNhiem.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        //    this.cmbu_KiemNhiem.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        //   // FilterCombo ft = new FilterCombo(cmbu_KiemNhiem, "TenChucVu");
        }
        private void cmbuChucDanhCV_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //cmbuChucDanhCV.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            //cmbuChucDanhCV.DisplayLayout.Bands[0].Columns["MaNhomChucDanh"].Hidden = true;
            //cmbuChucDanhCV.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = true;
            //cmbuChucDanhCV.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            //cmbuChucDanhCV.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = true;
            //cmbuChucDanhCV.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            //cmbuChucDanhCV.DisplayLayout.Bands[0].Columns["Machucdanh"].Hidden = true;
            //cmbuChucDanhCV.DisplayLayout.Bands[0].Columns["TenChucDanh"].Header.Caption = "Tên Chức Danh";

            //cmbuChucDanhCV.DisplayLayout.Bands[0].Columns["TenChucDanh"].Header.VisiblePosition = 0;
            //cmbuChucDanhCV.DisplayLayout.Bands[0].Columns["TenChucDanh"].Width = cmbuChucDanhCV.Width;
            
            ////màu và font chữ
            //foreach (UltraGridColumn col in this.cmbuChucDanhCV.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            //}
            ////màu nền
            //this.cmbuChucDanhCV.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.cmbuChucDanhCV.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        private void cmbuNoiSinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbuNoiSinh.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = true;
            cmbuNoiSinh.DisplayLayout.Bands[0].Columns["MaTinhThanhQuanLy"].Hidden = true;
            cmbuNoiSinh.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbuNoiSinh.DisplayLayout.Bands[0].Columns["MaKhuVuc"].Hidden = true;
            cmbuNoiSinh.DisplayLayout.Bands[0].Columns["MaQuocGia"].Hidden = true;
            cmbuNoiSinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên Tỉnh Thành";

            cmbuNoiSinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.VisiblePosition = 0;
            cmbuNoiSinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Width = cmbuNoiSinh.Width;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbuNoiSinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            this.cmbuNoiSinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbuNoiSinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }    
        private void cmbu_NoiCap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(cmbu_NoiCap, "TenTinhThanh");
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_NoiCap.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            //màu nền
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Hidden = false;
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên Tỉnh Thành";
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.VisiblePosition = 0;
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Width = cmbu_NoiCap.Width;
            FilterCombo ft = new FilterCombo(cmbu_NoiCap, "TenTinhThanh");
            
        }
        private void cmbu_QuanHuyenNoiSinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
           
        }
        private void cmbu_QuanHuyenQueQuan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //cmbu_QuanHuyenQueQuan.DisplayLayout.Bands[0].Columns["MaQuanHuyen"].Hidden = true;
            //cmbu_QuanHuyenQueQuan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = true;
            //cmbu_QuanHuyenQueQuan.DisplayLayout.Bands[0].Columns["TenQuanHuyen"].Header.Caption = "Tên Quận Huyện";
            //cmbu_QuanHuyenQueQuan.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = true;

            //cmbu_QuanHuyenQueQuan.DisplayLayout.Bands[0].Columns["TenQuanHuyen"].Header.VisiblePosition = 0;
            //cmbu_QuanHuyenQueQuan.DisplayLayout.Bands[0].Columns["TenQuanHuyen"].Width = 138;
            ////màu và font chữ
            //foreach (UltraGridColumn col in this.cmbu_QuanHuyenQueQuan.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            //}
            //màu nền
           // this.cmbu_QuanHuyenQueQuan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
           // this.cmbu_QuanHuyenQueQuan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        private void cmbu_QueQuan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_QueQuan.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = true;
            cmbu_QueQuan.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_QueQuan.DisplayLayout.Bands[0].Columns["MaKhuVuc"].Hidden = true;
            cmbu_QueQuan.DisplayLayout.Bands[0].Columns["MaQuocGia"].Hidden = true;
            cmbu_QueQuan.DisplayLayout.Bands[0].Columns["MaTinhThanhQuanLy"].Hidden = true;

            cmbu_QueQuan.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên Tỉnh Thành";
            cmbu_QueQuan.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.VisiblePosition = 0;
            cmbu_QueQuan.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Width = cmbu_QueQuan.Width;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_QueQuan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            this.cmbu_QueQuan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_QueQuan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo ft = new FilterCombo(cmbu_QueQuan, "TenTinhThanh");
        }
        private void cmbu_QuocTich_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {        
         
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_QuocTich.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_QuocTich.DisplayLayout.Bands[0].Columns["TenQuocGia"].Hidden = false;
            cmbu_QuocTich.DisplayLayout.Bands[0].Columns["TenQuocGia"].Header.Caption = "Tên Quốc Tịch";
            cmbu_QuocTich.DisplayLayout.Bands[0].Columns["TenQuocGia"].Header.VisiblePosition = 0;
            cmbu_QuocTich.DisplayLayout.Bands[0].Columns["TenQuocGia"].Width = cmbu_QuocTich.Width;
            //màu nền
            this.cmbu_QuocTich.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_QuocTich.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo ft = new FilterCombo(cmbu_QuocTich, "TenQuocGia");
        }

        private void cmbu_DanToc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_DanToc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            //màu nền
            cmbu_DanToc.DisplayLayout.Bands[0].Columns["DanToc"].Hidden = false;
            cmbu_DanToc.DisplayLayout.Bands[0].Columns["DanToc"].Header.Caption = "Dân Tộc";
            cmbu_DanToc.DisplayLayout.Bands[0].Columns["DanToc"].Header.VisiblePosition = 0;
            cmbu_DanToc.DisplayLayout.Bands[0].Columns["DanToc"].Width = cmbu_DanToc.Width;
            FilterCombo ft = new FilterCombo(cmbu_DanToc, "DanToc");
           
        }

        private void cmbu_TonGiao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_TonGiao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            //màu nền
            cmbu_TonGiao.DisplayLayout.Bands[0].Columns["TenTonGiao"].Hidden = false;
            cmbu_TonGiao.DisplayLayout.Bands[0].Columns["TenTonGiao"].Header.Caption = "Tôn Giáo";
            cmbu_TonGiao.DisplayLayout.Bands[0].Columns["TenTonGiao"].Header.VisiblePosition = 0;
            cmbu_TonGiao.DisplayLayout.Bands[0].Columns["TenTonGiao"].Width = 135;
            this.cmbu_TonGiao.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_TonGiao.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo ft = new FilterCombo(cmbu_TonGiao, "TenTonGiao");
        }

        private void cmbu_ThanhPhanGD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {     
          
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns["ThanhPhanGiaDinh"].Hidden = false;
            cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns["ThanhPhanGiaDinh"].Header.Caption = "Thành Phần Gia Đình";

            cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns["ThanhPhanGiaDinh"].Header.VisiblePosition = 0;
            cmbu_ThanhPhanGD.DisplayLayout.Bands[0].Columns["ThanhPhanGiaDinh"].Width = cmbu_ThanhPhanGD.Width;
            //màu nền
            this.cmbu_ThanhPhanGD.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_ThanhPhanGD.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo ft = new FilterCombo(cmbu_ThanhPhanGD, "ThanhPhanGiaDinh");
        }   

        private void cmbu_UuTienGD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
                        //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_UuTienGD.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_UuTienGD.DisplayLayout.Bands[0].Columns["UuTienGD"].Hidden = false;
            cmbu_UuTienGD.DisplayLayout.Bands[0].Columns["UuTienGD"].Header.Caption = "Ưu Tiên Gia Đình";

            cmbu_UuTienGD.DisplayLayout.Bands[0].Columns["UuTienGD"].Header.VisiblePosition = 0;
            cmbu_UuTienGD.DisplayLayout.Bands[0].Columns["UuTienGD"].Width = cmbu_UuTienGD.Width;

            //màu nền
            this.cmbu_UuTienGD.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_UuTienGD.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo ft = new FilterCombo(cmbu_UuTienGD, "UuTienGD");
        }

        private void cmbu_UuTienBanThan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_UuTienBanThan.DisplayLayout.Bands[0].Columns["MaUuTienBanThan"].Hidden = true;
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_UuTienBanThan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_UuTienBanThan.DisplayLayout.Bands[0].Columns["UuTienBT"].Hidden = false;
            cmbu_UuTienBanThan.DisplayLayout.Bands[0].Columns["UuTienBT"].Header.Caption = "Ưu Tiên Bản Thân";

            cmbu_UuTienBanThan.DisplayLayout.Bands[0].Columns["UuTienBT"].Header.VisiblePosition = 0;
            cmbu_UuTienBanThan.DisplayLayout.Bands[0].Columns["UuTienBT"].Width = cmbu_UuTienBanThan.Width;
            //màu nền
            this.cmbu_UuTienBanThan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_UuTienBanThan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo ft = new FilterCombo(cmbu_UuTienBanThan, "UuTienBT");
        }

        private void cmbu_ChucVuCongDoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_ChucVuCongDoan.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            //cmbu_ChucVuCongDoan.DisplayLayout.Bands[0].Columns["MaNhomChucVu"].Hidden = true;
          //  cmbu_ChucVuCongDoan.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Hidden = true;
            cmbu_ChucVuCongDoan.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_ChucVuCongDoan.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            cmbu_ChucVuCongDoan.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Hidden = true;

            cmbu_ChucVuCongDoan.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cmbu_ChucVuCongDoan.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 0;
            cmbu_ChucVuCongDoan.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = 140;
            FilterCombo ft = new FilterCombo(cmbu_ChucVuCongDoan, "TenChucVu");
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_ChucVuCongDoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            this.cmbu_ChucVuCongDoan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_ChucVuCongDoan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

        }

    
        private void cmbu_QuanHam_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {           
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_QuanHam.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_QuanHam.DisplayLayout.Bands[0].Columns["TenQuanHam"].Hidden = false;
            cmbu_QuanHam.DisplayLayout.Bands[0].Columns["TenQuanHam"].Header.Caption = "Tên Quân Hàm";
            cmbu_QuanHam.DisplayLayout.Bands[0].Columns["TenQuanHam"].Header.VisiblePosition = 0;
            cmbu_QuanHam.DisplayLayout.Bands[0].Columns["TenQuanHam"].Width = 147;
            //màu nền
            this.cmbu_QuanHam.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_QuanHam.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo ft = new FilterCombo(cmbu_QuanHam, "TenQuanHam");
        }

       private void cmbu_ChucVuDang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_ChucVuDang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_ChucVuDang.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            cmbu_ChucVuDang.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            cmbu_ChucVuDang.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 0;
            cmbu_ChucVuDang.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = 151;
            //màu nền
            this.cmbu_ChucVuDang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_ChucVuDang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo ft = new FilterCombo(cmbu_ChucVuDang, "TenChucVu");
        }


        private void ultragrdChuyenMonNghiepVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
        }
        private void cbBacLuongCB_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
            foreach (UltraGridColumn col in this.cbBacLuongCB.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cbBacLuongCB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;            
            cbBacLuongCB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            cbBacLuongCB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            cbBacLuongCB.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            cbBacLuongCB.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hế Số Lương";
            cbBacLuongCB.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition =1;
        }
        private void grdu_QuocGia_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
           
           
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaQuanHeGiaDinh"].Hidden = false;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["ChungTu"].EditorComponent = this.ultraTextEditor_MNS;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaQuanHeGiaDinh"].EditorComponent = cbQuanHeGiaDinh;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaQuanHeGiaDinh"].Header.Caption = "Tên Người Phụ Thuộc";
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaQuanHeGiaDinh"].Width = cbQuanHeGiaDinh.Width;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaGiaCanh"].Hidden = false;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaGiaCanh"].Header.Caption = "Tên Gia Cảnh";
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaGiaCanh"].EditorComponent = cbGiaCanh;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaGiaCanh"].Width = cbGiaCanh.Width;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["ChungTu"].Hidden = false;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["ChungTu"].Header.Caption = "Chứng Từ";
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["ChungTu"].Width = 60;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 300;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaQuanHeGiaDinh"].Header.VisiblePosition = 0;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaGiaCanh"].Header.VisiblePosition = 1;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 2;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["ChungTu"].Header.VisiblePosition = 3;
            
            
        }
        private void cmbu_DCThT_Tinh_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Width = cmbu_DCThT_Tinh.Width;
            foreach (UltraGridColumn col in this.cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Hidden = false;
            cmbu_DCThT_Tinh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên Tỉnh Thành";
            FilterCombo ft = new FilterCombo(cmbu_DCThT_Tinh, "TenTinhThanh");

        }

     
        private void cbNgachLuongNB_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //foreach (UltraGridColumn col in this.cbNgachLuongNB.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            //    col.Hidden = true;
            //}
            //cbNgachLuongNB.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            //cbNgachLuongNB.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Tên Ngạch Cơ Bản";
            //cbNgachLuongNB.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Width = cbNhomNgachLuong.Width;

        }

        private void cbBacLuongNB_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

          
        }

        private void cbGiaCanh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cbGiaCanh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbGiaCanh.DisplayLayout.Bands[0].Columns["TenGiaCanh"].Hidden=false;
            cbGiaCanh.DisplayLayout.Bands[0].Columns["TenGiaCanh"].Header.Caption = "Tên Gia Cảnh";
            cbGiaCanh.DisplayLayout.Bands[0].Columns["TenGiaCanh"].Width = cbGiaCanh.Width;
            //màu nền
            this.cbGiaCanh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cbGiaCanh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

        }

        private void cbQuanHeGiaDinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {           
            
            //màu và font chữ
            foreach (UltraGridColumn col in this.cbQuanHeGiaDinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbQuanHeGiaDinh.DisplayLayout.Bands[0].Columns["HoTenNguoiThan"].Hidden = false;
            cbQuanHeGiaDinh.DisplayLayout.Bands[0].Columns["HoTenNguoiThan"].Header.Caption = "Họ Tên";
            cbQuanHeGiaDinh.DisplayLayout.Bands[0].Columns["HoTenNguoiThan"].Width = 250;
            //màu nền
            this.cbQuanHeGiaDinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cbQuanHeGiaDinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        private void cbChucDanh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cbChucDanh.DisplayLayout.Bands[0].Columns["TenChucDanh"].Width = cbChucDanh.Width;
            cbChucDanh.DisplayLayout.Bands[0].Columns["MaChucDanh"].Hidden = true;
            cbChucDanh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = true;
            cbChucDanh.DisplayLayout.Bands[0].Columns["MaNhomChucDanh"].Hidden = true;
            //cbChucDanh.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            cbChucDanh.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            cbChucDanh.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = true;
            foreach (UltraGridColumn col in this.cbChucDanh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChucDanh.DisplayLayout.Bands[0].Columns["TenChucDanh"].Hidden = false;
            cbChucDanh.DisplayLayout.Bands[0].Columns["TenChucDanh"].Header.Caption = "Tên Chức Danh";
            FilterCombo ft = new FilterCombo(cbChucDanh, "TenChucDanh");
        }

        private void cmbu_PXBoPhan_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {           
            foreach (UltraGridColumn col in this.cbBoPhan_Ban.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }            
            cbBoPhan_Ban.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden =false;
            cbBoPhan_Ban.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption ="Tên Bộ Phận";
            cbBoPhan_Ban.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cbBoPhan_Ban.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cbBoPhan_Ban.Width;
            cbBoPhan_Ban.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbBoPhan_Ban.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbBoPhan_Ban.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        #region Bophan /P.Xuong

        #endregion


        #endregion

        #region Process
        private byte[] ConvertFileToBinary(OpenFileDialog openFileDialog)
        {
            value = new byte[0];
            MemoryStream ms=new MemoryStream();
            if (openFileDialog.FileName.Trim() != string.Empty)
            {
                
                Bitmap image1 = new Bitmap(openFileDialog.FileName, true);
                Bitmap image2 = new Bitmap(image1, new Size(100, 120));
                image2.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                value = ms.GetBuffer();
                pctbx_HinhNhanVien.Image = image2;
                ms.Close();
                ms.Dispose();

                /*
                value = new byte[Convert.ToInt32(stream.Length)];
                stream.Read(value, 0, value.Length);

                Size size = new Size(90, 120);
                Bitmap img = new Bitmap(stream);
                img = new Bitmap(img, size);
                pctbx_HinhNhanVien.Image = img;
                
                stream.Close();
                 * */
            }
            return value;

        }

        public Boolean KTCardIDLuu()
        {
            Boolean kq = true;
            if (txt_CardID.Text != "")
            {                
                if (NhanVien.KiemTraCardID(txt_CardID.Text) == 0)
                {
                    kq = true;
                }
                else
                {
                    MessageBox.Show(this, "CardID Bị Trùng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_CardID.Text = "";
                    kq = false;
                    return kq;
                }
            }
            return kq;
        }

        public Boolean KTMaLuu()
        {
            Boolean kq = true;
            if (NhanVien.KiemTraMaNV(txtu_MaNhanVien.Text) == 0)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "Mã Nhân Viên Bị Trùng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtu_MaNhanVien.Text = "";
                txtu_MaNhanVien.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        public Boolean KTCardIDCapNhat()
        {
            Boolean kq = true;
            if (NhanVien.KiemTraCardID(txt_CardID.Text) == 1)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "CardID Đã Tồn Tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_CardID.Text = "";
                txt_CardID.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        public Boolean KTMaCapNhat()
        {
            Boolean kq = true;
            if (NhanVien.KiemTraMaNV(txtu_MaNhanVien.Text) == 1)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "Mã Nhân Viên Đã Tồn Tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtu_MaNhanVien.Text = "";
                txtu_MaNhanVien.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        public bool KiemTra(NhanVien nhanVien)
        {

            if (!NhanVien.KiemTraNguoiPhuThuoc(nhanVien))
            {
                return false;
            }
            if (NhanVien.KiemTraCardIDDuyNhat(txt_CardID.Text,nhanVien.MaNhanVien) > 0)
            {
                MessageBox.Show(this, "CardID đã tồn tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_CardID.Focus();
                return false;
            }
            if (NhanVien.KiemTraCMNDDuyNhat(txtu_SoCMND.Text,nhanVien.MaNhanVien) > 0)
            {
                MessageBox.Show(this, "CMND đã tồn tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtu_SoCMND.Focus();
                return false;
            }
            if (NhanVien.KiemTraMaSoThueDuyNhat(tbMaSoThue.Text,nhanVien.MaNhanVien) > 0)
            {
                MessageBox.Show(this, "Mã Số Thuế đã tồn tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMaSoThue.Focus();
                return false;
            }
            if (nhanVien.LoaiNV==0&&nhanVien.MaQLNhanVien!="")
            {
                //if ((int)cmbu_LoaiNV.Value == 0)
                //{
                    MessageBox.Show(this, "Chọn Loại Nhân Viên", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbu_LoaiNV.Focus();
                    return false;
                //}
            }
            
            //if (_NhanVien.NhanVienNgoaiNguList.Count != 0)
            //{
            //    int count = 0;
            //    foreach (NhanVien_NgoaiNgu nn in _NhanVien.NhanVienNgoaiNguList)
            //    {
            //        if (nn.NgoaiNguChinh == true)
            //        {
            //            count++;
            //        }
            //    }
            //    if (count != 1 && nhanVien.IsNew!=true)
            //    {
            //        MessageBox.Show("Chọn 1 ngoại ngữ làm Ngoại ngữ chính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            //if (_NhanVien.NhanVienTrinhDoQuanLyList.Count != 0)
            //{
            //    int count = 0;
            //    foreach (NhanVien_TrinhDoQuanLy nn in _NhanVien.NhanVienTrinhDoQuanLyList)
            //    {
            //        if (nn.TrinhDoChinh == true)
            //        {
            //            count++;
            //        }
            //    }
            //    if (count != 1 && nhanVien.IsNew != true)
            //    {
            //        MessageBox.Show("Chọn 1 trình độ chính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            return true;
        }

        

        private void Xulymatruockhiluu()
        {
         
            
           
            if(maTo!=0)
                _mabp=maTo;
            else if(maPhongBan!=0)
                _mabp = maPhongBan;
            else if (maTo == 0 && maPhongBan == 0)
                _mabp=maBan;
            return;
           

        }

        private void GetBoPhan(NhanVien _NV)
        {
            BoPhan _boPhan;
            int MaBoPhanCha = 0;
            string TenPX = string.Empty;
            string TenChuyen = string.Empty;
            string TenCongDoan = string.Empty;
            int MaLoaiBoPhan = 0;

            _boPhan = BoPhan.GetBoPhan(_NV.MaBoPhan);
            MaLoaiBoPhan = _boPhan.MaLoaiBoPhan;
            while (MaLoaiBoPhan > 2)//Chỉ xét từ phân xưởng,chuyền_tổ,công đoạn.Không tính Khối
            {
                if (MaLoaiBoPhan == 3) //Phân xưởng, phòng ban
                {
                    TenPX = _boPhan.TenBoPhan;
                }
                else if (MaLoaiBoPhan == 4) //Chuyền Tổ
                {
                    TenChuyen = _boPhan.TenBoPhan;
                }
                else if (MaLoaiBoPhan == 6) //Công Đoạn
                {
                    TenCongDoan = _boPhan.TenBoPhan;
                }
                MaBoPhanCha = _boPhan.MaBoPhanCha;
                _boPhan = BoPhan.GetBoPhan(MaBoPhanCha);

                MaLoaiBoPhan = _boPhan.MaLoaiBoPhan;

            }
           

        }

        private void XuLyBoPhanKhiLoad(int maBoPhan)
        {
            cbBoPhan_Ban.Value = 0;
            cbBoPhan_PhongBan.Value = 0;
            cbBoPhan_To.Value = 0;
            BoPhan boPhan = BoPhan.GetBoPhan(maBoPhan);

            if (boPhan.MaLoaiBoPhan == 2)//Loại Bộ phận=Ban
            {
                this.bdBoPhan_Ban.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(boPhan.MaLoaiBoPhan);
                cbBoPhan_Ban.Value=boPhan.MaBoPhan;
            }
            else if (boPhan.MaLoaiBoPhan == 3)//Loại bộ phận=Phòng Ban
            {
                this.bdBoPhan_PhongBan.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(boPhan.MaLoaiBoPhan);
                cbBoPhan_PhongBan.Value=boPhan.MaBoPhan;

                //Binding Các bộ phận cha.
                BoPhan boPhanCha = BoPhan.GetBoPhan(boPhan.MaBoPhanCha);
                if (boPhanCha.MaBoPhanCha != 0)//Chưa phải là cấp cao nhất
                {
                    this.bdBoPhan_Ban.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(boPhanCha.MaLoaiBoPhan);
                    cbBoPhan_Ban.Value = boPhanCha.MaBoPhan;
                }                
            }

            if (boPhan.MaLoaiBoPhan == 4)//Loại bộ phận=Tổ
            {
                this.bdBoPhan_To.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(boPhan.MaLoaiBoPhan);
                cbBoPhan_To.Value = boPhan.MaBoPhan;

                //Binding cho các bộ phận cha.                
                BoPhan boPhanCha = BoPhan.GetBoPhan(boPhan.MaBoPhanCha);

                
                // HVT
                //    Ban
                //       PhongBan
                //               To
                
                // Và

                //
                // HTV
                //    PhongBan
                //            To  
                if (boPhanCha.MaLoaiBoPhan == 3)//Phong Ban
                {
                    //1. Phong Ban
                    bdBoPhan_PhongBan.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(boPhanCha.MaLoaiBoPhan);
                    cbBoPhan_PhongBan.Value = boPhanCha.MaBoPhan;
                    
                    //Cấp trên của Phòng Ban.
                    BoPhan boPhanChaCha = BoPhan.GetBoPhan(boPhanCha.MaBoPhanCha);
                    if (boPhanChaCha.MaBoPhanCha != 0)//Cấp Ban
                    {
                        bdBoPhan_Ban.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(boPhanChaCha.MaLoaiBoPhan);
                        cbBoPhan_Ban.Value = boPhanChaCha.MaBoPhan;
                    }

                }

                //HTV
                //  Ban
                //      To
                if (boPhanCha.MaLoaiBoPhan == 2)//Ban
                {
                    bdBoPhan_Ban.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(boPhanCha.MaLoaiBoPhan);
                    cbBoPhan_Ban.Value = boPhanCha.MaBoPhan;
                }
                //Và
                //HTV
                //  To
                
                
            }

        }
        
        #endregion

        private void cbNgachLuongCB_ValueChanged(object sender, EventArgs e)
        {
            _BacLuongCoBanList = BacLuongCoBanList.GetBacLuongCoBanList(Convert.ToInt32(cbNgachLuongCB.Value));
            this.BacLuongCB_BindingSource.DataSource = _BacLuongCoBanList;
        }

        private void cbNgachLuongNB_ValueChanged(object sender, EventArgs e)
        {
            _BacLuongBaoHiemList = BacLuongCoBanList.GetBacLuongCoBanList(Convert.ToInt32(cbNgachLuongBaoHiem.Value));
            this.bindingSource1_BacLuongBaoHiem.DataSource = _BacLuongBaoHiemList;
        }

      
        private void lbl_Email_Click(object sender, EventArgs e)
        {

        }

        private void tbc_ThongTinNhanVien_Selected(object sender, TabControlEventArgs e)
        {

        }

      
        private void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            _NhanVien.NhanVienGiaCanhList = NhanVienGiaCanhList.GetNhanVienGiaCanhList(_maNV);
            //this.bindingSource1_NhanVienGiaCanhBind.DataSource = _NhanVien.NhanVienGiaCanhList;
            this.nhanVienGiaCanhListBindingSource1.DataSource = _NhanVien.NhanVienGiaCanhList;
            this.nhanVienGiaCanhListBindingSource.DataSource = _NhanVien.NhanVienGiaCanhList;

            _NhanVien.NhanVienTaiKhoanNganHangList = NhanVien_TaiKhoanNganHangList.GetNhanVien_TaiKhoanNganHangList(_maNV);
            bindingSource1_NhanVienTaiKhoan.DataSource = _NhanVien.NhanVienTaiKhoanNganHangList;
            tlslblLuu.Enabled = false;
        }

    
       
     
        private void cậpNhậtLịchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NhanVien.NhanVienGiaCanhList = NhanVienGiaCanhList.GetNhanVienGiaCanhList(_NhanVien.MaNhanVien);
            nhanVienGiaCanhListBindingSource1.DataSource = _NhanVien.NhanVienGiaCanhList;
         
        }

        private void txt_Ngay_sinh_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void CauHinhHeSoBoPhan(int maBoPhan)
        {
            _boPhan_CauHinhList = BoPhan_CauHinhHeSoList.GetBoPhan_CauHinhHeSoList(maBoPhan);
            if (_boPhan_CauHinhList.Count > 0 && _NhanVien.IsDirty == true && _NhanVien.MaBoPhan != maBoPhan)
            {

                if (MessageBox.Show("Thay đổi Bộ phận có thể sẽ thay đổi HS Bổ Sung, HS Độc hại, PC Hành Chính của nhân viên này. Bạn có muốn thay đổi?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tbHSDocHai.Value = _boPhan_CauHinhList[0].HeSoDocHai;
                    this.tbHSLuongBS.Value = _boPhan_CauHinhList[0].HeSoBoSung;
                    this.ultraCombo2.Value = _boPhan_CauHinhList[0].PhuCapHC;
                }
            }
            else
            {
                this.tbHSDocHai.Value = _NhanVien.HeSoDocHai;
                this.tbHSLuongBS.Value = _NhanVien.HeSoLuongBoSung;
                this.ultraCombo2.Value = _NhanVien.PhuCapHC;
            }

        }
        private void cmbu_PXBoPhan_ValueChanged(object sender, EventArgs e)
        {       if (cbBoPhan_Ban.ActiveRow != null)
                maBan = Convert.ToInt32(cbBoPhan_Ban.Value);
            else
                maBan = 0;
            if (maBan == 0)
            {
                this.bdBoPhan_PhongBan.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(3);
            }
            else
            {
                bdBoPhan_PhongBan.DataSource = BoPhanList.GetBoPhanListCon_LoaiBoPhan(maBan, 3);
            }
            CauHinhHeSoBoPhan(maBan);
        
        }
       
        private void cmbu_Chuyento_ValueChanged(object sender, EventArgs e)
        {
           
            if (cbBoPhan_PhongBan.ActiveRow != null)
                maPhongBan = Convert.ToInt32(cbBoPhan_PhongBan.Value);
            else
                maPhongBan = 0;
            if (maPhongBan == 0)
            {
                this.bdBoPhan_To.DataSource = BoPhanList.GetBoPhanList_LoaiBoPhan(4);
            }
            else
            {
                this.bdBoPhan_To.DataSource = BoPhanList.GetBoPhanListCon_LoaiBoPhan(maPhongBan, 4);
            }
            CauHinhHeSoBoPhan(maPhongBan);
        }

     
        private void BoPhan_BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cmbu_Congdoan_ValueChanged(object sender, EventArgs e)
        {
            if (cbBoPhan_To.ActiveRow != null)
                maTo = Convert.ToInt32(cbBoPhan_To.Value);
            else
                maTo = 0;
            CauHinhHeSoBoPhan(maPhongBan);
            
        }

      
        private void cmbu_DCThT_Tinh_Leave(object sender, EventArgs e)
        {
            if (cmbu_DCThT_Tinh.ActiveRow != null)
            {
                if (cmbu_DCThT_Tinh.Text == "<Thêm Mới...>")
                {
                    frmTinhThanh frmtdcm = new frmTinhThanh();
                    frmtdcm.getData = new frmTinhThanh.PassData(GetList);
                    frmtdcm.ShowDialog();
                }
            }
        }

        private void cmbu_DCTT_Tinh_Leave(object sender, EventArgs e)
        {
           
                if (cmbu_DCTT_Tinh.Text == "<Thêm Mới...>")
                {
                    frmTinhThanh frmtdcm = new frmTinhThanh();
                    frmtdcm.getData = new frmTinhThanh.PassData(GetList);
                    frmtdcm.ShowDialog();
                }
           
        }

        private void cmbu_NoiCap_Leave(object sender, EventArgs e)
        {
            if (cmbu_NoiCap.Text == "<Thêm Mới...>")
            {
                frmTinhThanh frmtdcm = new frmTinhThanh();
                frmtdcm.getData = new frmTinhThanh.PassData(GetList);
                frmtdcm.ShowDialog();
            }
        }

        private void cmbu_ChuyenNganh_Leave(object sender, EventArgs e)
        {
            //if (cmbu_ChuyenNganh.Text == "<Thêm Mới...>")
            //{
            //    frmChuyenNganhDaoTao frmtdcm = new frmChuyenNganhDaoTao();
            //    frmtdcm.getData = new frmChuyenNganhDaoTao.PassData(GetList);
            //    frmtdcm.Show();
            //}
        }
        private void cbChucDanh_Leave(object sender, EventArgs e)
        {
           
                if (cbChucDanh.Text == "<Thêm Mới...>")
                {
                    frmChucVu frmcv = new frmChucVu();
                    frmcv.passData = new frmChucVu.PassData(GetList);
                    frmcv.ShowDialog();
                }
            
        }
        private void cbNhomNgachLuong_Leave(object sender, EventArgs e)
        {
            if (cbNhomNgachLuong.Text == "<Thêm Mới...>")
            {
                frmNhomNgachLuongCoBan frmcv = new frmNhomNgachLuongCoBan();
                frmcv.passData = new frmNhomNgachLuongCoBan.PassData(GetList);
                frmcv.ShowDialog();
            }
        }

        private void cbNgachLuongCB_Leave(object sender, EventArgs e)
        {
            if (cbNgachLuongCB.Text == "<Thêm Mới...>")
            {
                frmNgachLuongCoBan frmcv = new frmNgachLuongCoBan();
                frmcv.passData = new frmNgachLuongCoBan.PassData(GetList);
                frmcv.ShowDialog();
            }
        }

        private void cbBacLuongCB_Leave(object sender, EventArgs e)
        {
            if (cbBacLuongCB.Text == "<Thêm Mới...>")
            {
                frmBacLuongCoBan frmcv = new frmBacLuongCoBan();
                frmcv.getData = new frmBacLuongCoBan.PassData(GetList);
                frmcv.ShowDialog();
            }
        }

        private void cbNhomNgachBaoHiem_Leave(object sender, EventArgs e)
        {
            if (cbNhomNgachBaoHiem.Text == "<Thêm Mới...>")
            {
                frmNhomNgachLuongCoBan frmcv = new frmNhomNgachLuongCoBan();
                frmcv.passData = new frmNhomNgachLuongCoBan.PassData(GetList);
                frmcv.ShowDialog();
            }
        }

        private void cbNgachLuongBaoHiem_Leave(object sender, EventArgs e)
        {
            if (cbNgachLuongBaoHiem.Text == "<Thêm Mới...>")
            {
                frmNgachLuongCoBan frmcv = new frmNgachLuongCoBan();
                frmcv.passData = new frmNgachLuongCoBan.PassData(GetList);
                frmcv.ShowDialog();
            }
        }

        private void ultraCombo3_Leave(object sender, EventArgs e)
        {
            if (ultraCombo3.Text == "<Thêm Mới...>")
            {
                frmBacLuongCoBan frmcv = new frmBacLuongCoBan();
                frmcv.getData = new frmBacLuongCoBan.PassData(GetList);
                frmcv.ShowDialog();
            }
        }
        private void txtu_MaNhanVien_Leave(object sender, EventArgs e)
        {
            //if (!HamDungChung.KiemTraKyTuDacBiet(txtu_MaNhanVien.Text))
            //{
            //    MessageBox.Show("Mã NV không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtu_MaNhanVien.Focus();
            //    return ;
            //}
            //if (txtu_MaNhanVien.Text == string.Empty)
            //{
            //    MessageBox.Show(this, "Nhập Mã Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtu_MaNhanVien.Focus();
            //    return ;
            //}
        }

        private void txt_tenNV_Leave(object sender, EventArgs e)
        {
            if (txt_tenNV.Text == string.Empty)
            {
                MessageBox.Show(this, util.nhaptennhanvien, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txt_tenNV.Focus();
                return ;
            }
            if (!HamDungChung.KiemTraLaKyTu(txt_tenNV.Text))
            {
                MessageBox.Show("Tên không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txt_tenNV.Focus();
                return ;
            }
        }

        private void txt_hoNV_Leave(object sender, EventArgs e)
        {
            if (!HamDungChung.KiemTraLaKyTu(txt_hoNV.Text))
            {
                MessageBox.Show("Họ không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_hoNV.Focus();
                return ;
            }
        }

        private void txtu_SoCMND_Leave(object sender, EventArgs e)
        {
            //if (!HamDungChung.KiemTraLaSo(txtu_SoCMND.Text))
            //{
            //    MessageBox.Show("CMND không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtu_SoCMND.Focus();
            //    return ;
            //}
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {

            HamDungChung hdc = new HamDungChung();
            if (!hdc.KiemTraDiaChiEmail(txtEmail.Text) && (txtEmail.Text != ""))
            {
                MessageBox.Show("Email không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return ;
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new ReportDocument();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_DanhSachNhanVien_TrichNgang";
            command.Parameters.AddWithValue("@MaBoPhan", 0);
            command.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
            //command.Parameters.AddWithValue("@Denngay",Convert.ToDateTime(DateTime.Today));
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_DanhSachNhanVien_TrichNgang;1";
            //// store thu 2
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";
            command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";

            dataset.Tables.Add(table1);
            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();        
        }

        private void cbNhomNgachLuong_ValueChanged(object sender, EventArgs e)
        {
            _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(Convert.ToInt32(cbNhomNgachLuong.Value));
            this.NgachLuongCoBan_BindingSource.DataSource = _NgachLuongCoBanList;
        }

        private void cbNhomNgachBaoHiem_ValueChanged(object sender, EventArgs e)
        {
            _NgachLuongBaoHiemList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(Convert.ToInt32(cbNhomNgachBaoHiem.Value));            
            this.bindingSource1_NgachLuongBH.DataSource = _NgachLuongBaoHiemList;
        }

        private void cbNhomNgachLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbNhomNgachLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbNhomNgachLuong.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Hidden = false;
            cbNhomNgachLuong.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.Caption = "Tên Nhóm Ngạch Cơ Bản";
            cbNhomNgachLuong.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Width = cbNhomNgachLuong.Width;
            FilterCombo ft = new FilterCombo(cbNhomNgachLuong, "TenNhomNgachLuongCoBan");
           
        }

        private void cbNhomNgachBaoHiem_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbNhomNgachBaoHiem.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbNhomNgachBaoHiem.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Hidden = false;
            cbNhomNgachBaoHiem.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.Caption = "Tên Nhóm Ngạch Cơ Bản";
            cbNhomNgachBaoHiem.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Width = cbNhomNgachLuong.Width;
            FilterCombo ft = new FilterCombo(cbNhomNgachBaoHiem, "TenNhomNgachLuongCoBan");
        }

        private void ultraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbNganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbNganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Hidden = false;
            cbNganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";
            cbNganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Width = 300;
            FilterCombo ft = new FilterCombo(cbNganHang, "TenNganHang");
        }

        private void cbNgachLuongCB_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            
            foreach (UltraGridColumn col in this.cbNgachLuongCB.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbNgachLuongCB.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            cbNgachLuongCB.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Tên Ngạch Cơ Bản";
            cbNgachLuongCB.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Width = cbNhomNgachLuong.Width;
            cbNgachLuongCB.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition = 0;

            cbNgachLuongCB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbNgachLuongCB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý ";
            cbNgachLuongCB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            FilterCombo ft = new FilterCombo(cbNgachLuongCB, "MaQuanLy");

        }

        private void cbNgachLuongCB_ValueChanged_1(object sender, EventArgs e)
        {
            _BacLuongCoBanList = BacLuongCoBanList.GetBacLuongCoBanList(Convert.ToInt32(cbNgachLuongCB.Value));
            this.BacLuongCB_BindingSource.DataSource = _BacLuongCoBanList;
        }

       

        private void cbBacLuongBaoHiem_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            //foreach (UltraGridColumn col in this.cbBacLuongBaoHiem.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            //    col.Hidden = true;
            //}
            //cbBacLuongBaoHiem.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            //cbBacLuongBaoHiem.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            //cbBacLuongBaoHiem.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            //cbBacLuongBaoHiem.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            //cbBacLuongBaoHiem.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hế Số Lương";
            //cbBacLuongBaoHiem.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 1;

        }

        private void cbBacLuongBaoHiem_ValueChanged(object sender, EventArgs e)
        {
            /*
            _NgachLuongBaoHiemList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(Convert.ToInt32(cbNhomNgachBaoHiem.Value));
            this.bindingSource1_NgachLuongBH.DataSource = _NgachLuongCoBanList;
            _BacLuongBaoHiemList = BacLuongCoBanList.GetBacLuongCoBanList(Convert.ToInt32(cbNgachLuongNB.Value));
            this.bindingSource1_BacLuongBaoHiem.DataSource = _BacLuongBaoHiemList;
             * */
            
        }

        private void cbNgachLuongBaoHiem_ValueChanged(object sender, EventArgs e)
        {
            _BacLuongBaoHiemList=BacLuongCoBanList.GetBacLuongCoBanListByNgachLuong(Convert.ToInt32(cbNgachLuongBaoHiem.Value));
            this.bindingSource1_BacLuongBaoHiem.DataSource=_BacLuongBaoHiemList;
        }

        private void cbNgachLuongBaoHiem_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            foreach (UltraGridColumn col in this.cbNgachLuongBaoHiem.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbNgachLuongBaoHiem.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            cbNgachLuongBaoHiem.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Tên Ngạch Bảo Hiểm";
            cbNgachLuongBaoHiem.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Width = cbNhomNgachLuong.Width;
            cbNgachLuongBaoHiem.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition=0;
            cbNgachLuongBaoHiem.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbNgachLuongBaoHiem.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý ";
            cbNgachLuongBaoHiem.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            FilterCombo ft = new FilterCombo(cbNgachLuongBaoHiem, "MaQuanLy");

        }

        private void ultraCombo3_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo3.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            ultraCombo3.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultraCombo3.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultraCombo3.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultraCombo3.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            ultraCombo3.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hế Số Lương";
            ultraCombo3.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 1;
            FilterCombo ft = new FilterCombo(cbNgachLuongBaoHiem, "MaQuanLy");
 
        }

        private void btn_DiaChi_Click_1(object sender, EventArgs e)
        {
            //cmustrip_DiaChi.Show(btn_DiaChi,new Point(10,10));
            frmNhanVien_NgoaiNgu f = new frmNhanVien_NgoaiNgu(_NhanVien.NhanVienNgoaiNguList);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                int count = 0;
                _NhanVien.NhanVienNgoaiNguList = f._NhanVien_NgoaiNguList;
                if (_NhanVien.NhanVienNgoaiNguList.Count != 0)
                {
                    foreach (NhanVien_NgoaiNgu nn in _NhanVien.NhanVienNgoaiNguList)
                    {
                        if (nn.NgoaiNguChinh == true)
                        {
                            tb_NhanVienNgoaiNgu.Text = nn.TenNgoaiNgu + " trình độ: " + nn.TenTrinhDoNN;
                            count++;
                        }                       
                       
                    }
                    if (count > 1)
                        MessageBox.Show("Chọn 1 ngoại ngữ làm Ngoại ngữ chính","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cmustrip_DiaChi.Show(btn_DiaChi,new Point(10,10));
            frmNhanVien_TrinhDoQuanLy f = new frmNhanVien_TrinhDoQuanLy(_NhanVien.NhanVienTrinhDoQuanLyList);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                int count = 0;
                _NhanVien.NhanVienTrinhDoQuanLyList = f._NhanVien_TrinhDoQuanLyList;
                if (_NhanVien.NhanVienTrinhDoQuanLyList.Count != 0)
                {
                    foreach (NhanVien_TrinhDoQuanLy nn in _NhanVien.NhanVienTrinhDoQuanLyList)
                    {
                        if (nn.TrinhDoChinh == true)
                        {
                            tbTrinhDoQuanLy.Text ="QLKT: "+ nn.TenTrinhDoQuanLyKinhTe + "; QLNN: " + nn.TenTrinhDoQuanLyNhaNuoc;
                            count++;
                        }

                    }
                    if (count > 1)
                        MessageBox.Show("Chọn 1 trình độ quản lý chính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cmustrip_DiaChi.Show(btn_DiaChi,new Point(10,10));
            frmNhanVien_ChuyenMon f = new frmNhanVien_ChuyenMon(_NhanVien.NhanVienChuyenNganhList);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                int count = 0;
                _NhanVien.NhanVienChuyenNganhList = f._NhanVien_ChuyenMonList;
                if (_NhanVien.NhanVienChuyenNganhList.Count != 0)
                {
                    foreach (NhanVien_ChuyenNganh nn in _NhanVien.NhanVienChuyenNganhList)
                    {
                        if (nn.ChuyenNganhChinh == true)
                        {
                            tbNhanVien_ChuyenMon.Text = "Chuyên Ngành: "+nn.TenChuyenNganh +"; Tốt nghiệp: "+nn.TenTruongDaoTao;
                            count++;
                        }

                    }
                    if (count > 1||count==0)
                        MessageBox.Show("Chọn 1 Chuyên môn làm chuyên môn chính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNhanVien_ChuyenMon.Focus();
                }

            }
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Hidden = false;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.Caption = "Ngân Hàng";
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.VisiblePosition = 0;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].EditorComponent =cbNganHang;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Width = cbNganHang.Width;

            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số Tài Khoản";
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 1;           
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Width = 120;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["LuongV1"].Hidden = false;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["LuongV1"].Header.Caption = "Lương V1";
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["LuongV1"].Header.VisiblePosition = 2;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["LuongV1"].Width = 80;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["LuongV2"].Hidden = false;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["LuongV2"].Header.Caption = "Lương V2";
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["LuongV2"].Header.VisiblePosition = 3;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["LuongV2"].Width = 80;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["ThuLao"].Hidden = false;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["ThuLao"].Header.Caption = "Thù Lao";
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["ThuLao"].Header.VisiblePosition = 4;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["ThuLao"].Width = 80;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["PhuCap"].Hidden = false;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["PhuCap"].Header.Caption = "Phụ Cấp";
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["PhuCap"].Header.VisiblePosition = 5;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["PhuCap"].Width = 80;

            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["KhenThuong"].Hidden = false;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["KhenThuong"].Header.Caption = "Khen Thưởng";
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["KhenThuong"].Header.VisiblePosition = 6;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["KhenThuong"].Width = 80;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 7;
            gridTaiKhoanNganHang.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 150;

 
        }

        private void ultraGrid1_CellChange(object sender, CellEventArgs e)
        {
           
        }
        private bool KiemTraTaiKhoanNganHang()
        {
            gridTaiKhoanNganHang.UpdateData();

            int _luongV1 = 0; int _luongV2 = 0; int _thuLao = 0; int _phuCap = 0; int _khenThuong = 0;
            if (_NhanVien.NhanVienTaiKhoanNganHangList.Count != 0)
            {
                for (int i = 0; i < _NhanVien.NhanVienTaiKhoanNganHangList.Count; i++)
                {
                    if (_NhanVien.NhanVienTaiKhoanNganHangList[i].LuongV1 == true)
                    {
                        _luongV1++;
                        if (_luongV1 > 1)
                        {
                            MessageBox.Show(" Lương V1 không thể chuyển nhiều hơn 1 tài khoản ngân hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (_NhanVien.NhanVienTaiKhoanNganHangList[i].LuongV2 == true)
                    {
                        _luongV2++;
                        if (_luongV2 > 1)
                        {
                            MessageBox.Show(" Lương V2 không thể chuyển nhiều hơn 1 tài khoản ngân hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return false;
                        }
                    }
                    if (_NhanVien.NhanVienTaiKhoanNganHangList[i].ThuLao == true)
                    {
                        _thuLao++;
                        if (_thuLao > 1)
                        {
                            MessageBox.Show(" Thù Lao không thể chuyển nhiều hơn 1 tài khoản ngân hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (_NhanVien.NhanVienTaiKhoanNganHangList[i].PhuCap == true)
                    {
                        _phuCap++;
                        if (_phuCap > 1)
                        {
                            MessageBox.Show("Phụ Cấp không thể chuyển nhiều hơn 1 tài khoản ngân hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (_NhanVien.NhanVienTaiKhoanNganHangList[i].KhenThuong == true)
                    {
                        _khenThuong++;
                        if (_khenThuong > 1)
                        {
                            MessageBox.Show("Khen Thưởng không thể chuyển nhiều hơn 1 tài khoản ngân hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                }
                if (_khenThuong ==0||_luongV1==0||_luongV2==0||_thuLao==0||_phuCap==0)
                {
                    MessageBox.Show("Dữ liệu tài khoản ngân hàng chưa hợp lệ. Các khoản thu nhập phải được chuyển qua tài khoản ngân hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
               
            }
            return true;
        }

        private void cbTraLuongQuaTK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTraLuongQuaTK.Checked == true)
                gridTaiKhoanNganHang.Enabled = true;
            else
                gridTaiKhoanNganHang.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            frmNhanVienChungChi f = new frmNhanVienChungChi(_NhanVien.NhanVienChungChiList);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                int count = 0;
                _NhanVien.NhanVienChungChiList = f._NhanVien_ChungChiList;
                if (_NhanVien.NhanVienChungChiList.Count != 0)
                {
                    foreach (NhanVien_ChungChi nn in _NhanVien.NhanVienChungChiList)
                    {
                        if (nn.ChungChiChinh == true)
                        {
                            tbChungChi.Text = "Chứng chỉ: " + nn.TenChungChi + "; Tốt nghiệp: " + nn.NoiCap;
                            count++;
                        }

                    }
                    if (count > 1 || count == 0)
                        MessageBox.Show("Chọn 1 Chứng chỉ làm chứng chỉ chính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNhanVien_ChuyenMon.Focus();
                }

            }
        }

        private void ultraTextEditor_MNS_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            int maNhanVien_GiaCanh = 0;
            if (grdu_NhanVien_GiaCanh.ActiveRow != null)
            {
                maNhanVien_GiaCanh = (int)grdu_NhanVien_GiaCanh.ActiveRow.Cells["NhanvienGiacanh"].Value;
            }
            frmNhanVienGiaCanh_ChungTu _frmChietNhanVien = new frmNhanVienGiaCanh_ChungTu((NhanVienGiaCanh)nhanVienGiaCanhListBindingSource1.Current, maNhanVien_GiaCanh);
            _frmChietNhanVien.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pctbx_HinhNhanVien.Image = null;
        }

        private void cmbu_ChucVu_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChucVu.ActiveRow != null)
            {
                if (cmbu_ChucVu.Text == "<Thêm Mới...>")
                {
                    frmChucVu frmcv = new frmChucVu();
                    frmcv.passData = new frmChucVu.PassData(GetList);
                    frmcv.ShowDialog();
                }
            }
        }

        private void ultraCombo_KiemNhiem_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //màu và font chữ
            foreach (UltraGridColumn col in this.ultraCombo_KiemNhiem.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            ultraCombo_KiemNhiem.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            ultraCombo_KiemNhiem.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Kiêm Nhiệm";

            this.ultraCombo_KiemNhiem.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.ultraCombo_KiemNhiem.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo ft = new FilterCombo(ultraCombo_KiemNhiem, "TenChucVu");
        }

        private void ultraCombo_KiemNhiem_Leave(object sender, EventArgs e)
        {
            if (ultraCombo_KiemNhiem.ActiveRow != null)
            {
                if (ultraCombo_KiemNhiem.Text == "<Thêm Mới...>")
                {
                    frmChucVu frmtdcm = new frmChucVu();
                    frmtdcm.passData = new frmChucVu.PassData(GetList);
                    frmtdcm.ShowDialog();
                }
            }
         
        }

       

       

     

    }
}



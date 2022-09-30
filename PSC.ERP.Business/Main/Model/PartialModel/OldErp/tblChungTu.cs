using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Util;
using PSC_ERP_Common;
using System.Windows.Forms;
using PSC_ERP_Core;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Predefined;
//Cường


namespace PSC_ERP_Business.Main.Model
{

    public partial class tblChungTu
    {
        public Boolean Chon { get; set; }

        public Object CurrentForm_AddedObj = null;

        public String TaiKhoanDoiUngGhiTangTaiSan_RefObj
        {
            get
            {
                var taiSanDauTien = this.tblTaiSanCoDinhCaBiets.FirstOrDefault();
                if (taiSanDauTien != null)
                {
                    return taiSanDauTien.TaiKhoanDoiUng;
                }
                return String.Empty;
            }

        }
        public String SoHopDongGhiTangTaiSan_RefObj
        {
            get
            {
                //var taiSanDauTien = this.tblTaiSanCoDinhCaBiets.FirstOrDefault();
                if (this.tblTaiSanCoDinhCaBiets.Count > 0)
                {
                    var taiSanDauTien = this.tblTaiSanCoDinhCaBiets.FirstOrDefault();
                    String StrChuoiSoHopDong = String.Empty;
                    foreach (var taiSan in this.tblTaiSanCoDinhCaBiets)
                    {
                        if (!StrChuoiSoHopDong.Contains(taiSan.SoHopDong))
                        {
                            StrChuoiSoHopDong += taiSan.SoHopDong + ", ";
                        }
                    }
                    return StrChuoiSoHopDong.Substring(0, StrChuoiSoHopDong.Length - 2);
                }
                return String.Empty;
            }
        }
        public String SoHoaDonGhiTangTaiSan_RefObj
        {
            get
            {
               // var taiSanDauTien = this.tblTaiSanCoDinhCaBiets.FirstOrDefault();
                if (this.tblTaiSanCoDinhCaBiets.Count > 0)
                {
                    var taiSanDauTien = this.tblTaiSanCoDinhCaBiets.FirstOrDefault();
                    String StrChuoiSoHoaDon = String.Empty;
                    foreach (var taiSan in this.tblTaiSanCoDinhCaBiets)
                    {
                        if (!StrChuoiSoHoaDon.Contains(taiSan.SoHoaDon))
                        {
                            StrChuoiSoHoaDon += taiSan.SoHoaDon + ", ";
                        }
                    }
                    return StrChuoiSoHoaDon.Substring(0, StrChuoiSoHoaDon.Length - 2);
                }
                return String.Empty;
            }
        }
        public String NguonMuaTaiSan_AddedObject
        {
            get
            {
                var taiSanDauTien = this.tblTaiSanCoDinhCaBiets.FirstOrDefault();
                if (taiSanDauTien != null)
                {
                    if ((taiSanDauTien.NguonMua ?? false) == false)
                    {
                        return "Lẻ";
                    }
                    else
                    {
                        return "Dự án";
                    }
                }
                return String.Empty;
            }
        }

        //partial void On_SoChungTu_Changed(string oldValue, string currentValue)
        //{
        //}

        partial void On_MaChungTuQL_Changed(string oldValue, string currentValue)
        {
            if (oldValue != null && oldValue != currentValue)
            {
                foreach (var item in this.tblTaiSanCoDinhCaBiets)
                {
                    item.SoChungTu = currentValue;
                }
            }
        }

        partial void On_NgayLap_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue)
        {
            if ((oldValue ?? DateTime.MinValue) != DateTime.MinValue)
            {
                foreach (var item in this.tblChiTietNguyenGiaTSCDs)
                {
                    //cập nhật lại ngày thực hiện cho chi tiết nguyên giá (chi tiết nguyên giá phát sinh từ ghi tăng và điều chỉnh giá trị)
                    item.NgayThucHien = this.NgayLap;
                    //cập nhật lũy kế khấu hao
                    item.LuyKeKhauHao =
                        TaiSanCoDinhCaBiet_Factory.New()
                            .LuyKeKhauHaoCuaTaiSanCaBietDenNgay(item.MaTSCDCaBiet.Value, this.NgayLap.Value);
                    //cập nhật lũy kế hao mòn
                    item.LuyKeHaoMon =
                        TaiSanCoDinhCaBiet_Factory.New()
                            .LuyKeHaoMonCuaTaiSanCaBietDenNgay(item.MaTSCDCaBiet.Value, this.NgayLap.Value);
                }
                //xu ly ngay cho sua chua lon
                var nvscl = this.tblNghiepVuSuaChuaLons.FirstOrDefault();
                if (nvscl != null)
                    foreach (var ctnvscl in nvscl.tblCT_NghiepVuSuaChuaLon)
                    {
                        foreach (var dcpt in ctnvscl.tblBoSungDungCuPhuTungs)
                        {
                            dcpt.NgayChungTuSCL = this.NgayLap;
                        }

                        foreach (var cttscb in ctnvscl.tblChiTietTaiSanCaBiets)
                        {
                            cttscb.NgayChungTuSCL = this.NgayLap;
                        }
                    }
            }
        }
        public bool KiemTraDinhKhoan(bool kiemTraSoTienChungTuBangSoTienButToan = true)
        {
            //kiểm tra định khoản
            //if (this.tblDinhKhoan.tblButToans.Count() == 0)
            //{
            //    //DialogUtil.ShowError("Chưa nhập định khoản");
            //    if (DialogResult.No == DialogUtil.ShowYesNo("Bạn muốn lưu chứng từ với định khoản rỗng?"))
            //        return false;
            //}
            //else
            if (this.tblDinhKhoan.tblButToans.Count() > 0)
            {
                Decimal tongTienButToan = 0;
                Decimal tongTienChiPhiSanXuat = 0;
                foreach (var buttoan in this.tblDinhKhoan.tblButToans)
                {
                    if (buttoan.SoHoaDonThamChieu != null)
                    {
                        if (this.tblChungTu_HoaDonTaiSan.Count == 0 && buttoan.SoHoaDonThamChieu.Trim().Length > 0)
                        {
                            DialogUtil.ShowError("Số hóa đơn không hợp lệ!\nVui lòng gán hóa đơn rồi mới nhập số hóa đơn");
                            return false;
                        }
                        else if (this.tblChungTu_HoaDonTaiSan.Count > 0 && buttoan.SoHoaDonThamChieu.Trim().Length > 0)
                        {
                            Boolean cohieu = false;
                            foreach (var chungtu_hoadonTS in this.tblChungTu_HoaDonTaiSan)
                            {
                                if (chungtu_hoadonTS.tblHoaDon.SoHoaDon == buttoan.SoHoaDonThamChieu)
                                {
                                    cohieu = true;
                                    break;
                                }
                            }
                            if (!cohieu)
                            {
                                DialogUtil.ShowError("Số hóa đơn không hợp lệ!\nSố hóa đơn không được gán vô chứng từ!\nVui lòng kiếm tra lại!");
                                return false;
                            }
                        }
                    }
                    //cong don so tien but toan
                    tongTienButToan += buttoan.SoTien;
                    //kiểm tra tổng tiền chi phi san xuat từng bút toán
                    {
                        Decimal tongTienChiPhiSanXuatTheoButToanHienTai = 0;
                        foreach (var chiPhi in buttoan.tblCT_ChiPhiSanXuat)
                        {
                            tongTienChiPhiSanXuatTheoButToanHienTai += chiPhi.SoTien ?? 0;
                            tongTienChiPhiSanXuat += chiPhi.SoTien ?? 0;

                            //kiểm tra mục ngân sách
                            {
                                Decimal tongTienGhiMucNganSachTheoChiPhiHienTai = 0;

                                foreach (var buttoanMucNganSach in chiPhi.tblButToan_MucNganSach)
                                {
                                    tongTienGhiMucNganSachTheoChiPhiHienTai += buttoanMucNganSach.SoTien;
                                }
                                if (tongTienGhiMucNganSachTheoChiPhiHienTai != chiPhi.SoTien && chiPhi.tblButToan_MucNganSach.Any())//.Count > 0)
                                {
                                    DialogUtil.ShowError(String.Format("Số tiền ghi mục ngân sách không bằng số tiền công việc/chương trình [{0}]", chiPhi.tblnsChuongTrinh.TenChuongTrinh));
                                    return false;
                                }
                            }
                        }
                        if (tongTienChiPhiSanXuatTheoButToanHienTai != buttoan.SoTien && buttoan.tblCT_ChiPhiSanXuat.Any())//.Count > 0)
                        {
                            DialogUtil.ShowError("Số tiền chi phí theo bút toán không bằng số tiền bút toán");
                            return false;
                        }
                    }

                    //kiểm tra nợ có tài khoản của bút toán định khoản
                    if ((buttoan.NoTaiKhoan ?? 0) == 0 || (buttoan.CoTaiKhoan ?? 0) == 0)
                    {
                        DialogUtil.ShowError("Chưa chọn đầy đủ tài khoản của bút toán");
                        return false;
                    }  
                    
                    //kiem tra doi tuong no co
                    {
                        tblTaiKhoan coTaiKhoan = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.CoTaiKhoan ?? 0);
                        tblTaiKhoan noTaiKhoan = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.NoTaiKhoan ?? 0);
                        List<tblTaiKhoan> dsTaiKhoanCha =   TaiKhoan_Factory.New().Get_DanhSachTaiKhoanCha().ToList<tblTaiKhoan>();
                        foreach (tblTaiKhoan tk in dsTaiKhoanCha)
                        {
                            if (tk.MaTaiKhoan == coTaiKhoan.MaTaiKhoan || noTaiKhoan.MaTaiKhoan == tk.MaTaiKhoan)
                            {
                                DialogUtil.ShowError("Vui lòng chọn tài khoản con!");
                                return false;
                            }
                        }
                        //kiểm tra nhập chi phi
                        {
                            if (noTaiKhoan.SoHieuTK.StartsWith("1551") || coTaiKhoan.SoHieuTK.StartsWith("1551")
                                || noTaiKhoan.SoHieuTK.StartsWith("1552") || coTaiKhoan.SoHieuTK.StartsWith("1552")
                                || noTaiKhoan.SoHieuTK.StartsWith("631") //|| coTaiKhoan.SoHieuTK.StartsWith("631")
                                || noTaiKhoan.SoHieuTK.StartsWith("4314") //|| coTaiKhoan.SoHieuTK.StartsWith("4314")
                                )
                            {
                                if (buttoan.tblCT_ChiPhiSanXuat.Any() == false)
                                {
                                    DialogUtil.ShowError("Bạn phải nhập công việc/chương trình cho các bút toán chi phí");
                                    return false;
                                }
                                else
                                {
                                    foreach (tblCT_ChiPhiSanXuat chiPhi in buttoan.tblCT_ChiPhiSanXuat)
                                    {
                                        if (chiPhi.tblButToan_MucNganSach.Any() == false && (noTaiKhoan.SoHieuTK.StartsWith("631") || noTaiKhoan.SoHieuTK.StartsWith("4314")))
                                        {
                                            DialogUtil.ShowError(String.Format("Vui lòng nhập mục ngân sách cho công việc chương trình [{0}] trong bút toán [{1}]", chiPhi.tblnsChuongTrinh.TenChuongTrinh, noTaiKhoan.SoHieuTK));
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                        //
                        if (noTaiKhoan != null && noTaiKhoan.CoDoiTuongTheoDoi == true)
                        {
                            if ((buttoan.MaDoiTuongNo ?? 0) == 0)
                            {
                                DialogUtil.ShowWarning("Vui lòng chọn đối tượng nợ");
                                return false;
                            }
                        }
                        if (coTaiKhoan != null && coTaiKhoan.CoDoiTuongTheoDoi == true)
                        {
                            if ((buttoan.MaDoiTuongCo ?? 0) == 0)
                            {
                                DialogUtil.ShowWarning("Vui lòng chọn đối tượng có ");
                                return false;
                            }
                        }
                    }
                }
                //kiem tra tong tien but toan
                if (kiemTraSoTienChungTuBangSoTienButToan)
                    if (tongTienButToan != this.tblTienTe.ThanhTien)
                    {
                        DialogUtil.ShowError("Tổng tiền bút toán không bằng số tiền chứng từ");
                        return false;
                    }
                //kiểm tra tông tiền ghi mục ngân sách
                //if (tongTienGhiMucNganSach != tongTienButToan)
                //{
                //    DialogUtil.ShowError("Tổng tiền ghi mục ngân sách không bằng tổng tiền bút toán");
                //    return false;
                //}
            }//end else
            return true;
        }

        public bool KiemTraHoaDon()
        {
            if (this.tblChungTu_HoaDon.Count == 0)
            {
                //DialogUtil.ShowError("Chưa nhập hóa đơn");
                //return false;
            }
            else
            {
                //TaiKhoan_Factory taiKhoan_factory = TaiKhoan_Factory.New();
                foreach (var butToan in this.tblDinhKhoan.tblButToans)
                {
                    //lấy tổng tiền bút toán thuế
                    decimal tongTienButToanThue = 0;

                    tblTaiKhoan coTaiKhoan = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.CoTaiKhoan ?? 0);
                    tblTaiKhoan noTaiKhoan = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.NoTaiKhoan ?? 0);
                    //kiểm tra đối tượng nợ
                    if (noTaiKhoan.SoHieuTK.StartsWith("3113") || noTaiKhoan.SoHieuTK.StartsWith("3337") || coTaiKhoan.SoHieuTK.StartsWith("3113") || coTaiKhoan.SoHieuTK.StartsWith("3337"))
                        tongTienButToanThue += butToan.SoTien;
                    //////////////

                    if (noTaiKhoan.SoHieuTK.StartsWith("3113") || noTaiKhoan.SoHieuTK.StartsWith("3337") || coTaiKhoan.SoHieuTK.StartsWith("3113") || coTaiKhoan.SoHieuTK.StartsWith("3337"))
                    {
                        if (!butToan.tblChungTu_HoaDon.Any())
                        {
                            DialogUtil.ShowWarning("Có bút toán thuế chưa chọn hóa đơn");
                            return false;
                        }
                    }
                    else
                    {
                        if (butToan.tblChungTu_HoaDon.Any())
                        {
                            DialogUtil.ShowWarning("Hóa đơn không được phép đặt trong bút toán không phải bút toán thuế 3113...");
                            return false;
                        }
                    }

                    //lấy tổng tiền hóa đơn và tổng tiền thuế VAT trong hóa đơn
                    Decimal tongTienHoaDon = 0;
                    decimal tongTienThueVATTrongHoaDon = 0;
                    foreach (var chungTuHoaDon in this.tblChungTu_HoaDon)
                    {
                        tongTienThueVATTrongHoaDon += chungTuHoaDon.tblHoaDon.ThueVAT;
                        tongTienHoaDon += chungTuHoaDon.tblHoaDon.TongTien;
                    }

                    //kiểm tra tổng tiền phần thuế VAT trong hóa đơn phải bằng tổng tiền bút toán thuế nếu bút toán thuế có khai báo
                    if (tongTienButToanThue > 0 && tongTienThueVATTrongHoaDon != tongTienButToanThue)
                    {
                        DialogUtil.ShowWarning("Giá trị hạch toán tài khoản thuế không bằng tổng giá trị các hóa đơn");
                        return false;
                    }
                }

                //kiểm tra tổng tiền hóa đơn phải bằng tổng tiền chứng từ
                //if (tongTienHoaDon != this.tblTienTe.ThanhTien.Value)
                //{
                //    DialogUtil.ShowWarning("Tổng tiền hóa đơn phải bằng tổng tiền chứng từ");
                //    return false;
                //}
            }
            return true;
        }
        public bool KiemTraMaChungTuQuanLy()
        {
            if (String.IsNullOrWhiteSpace(this.MaChungTuQL))
            {
                DialogUtil.ShowError("Chưa nhập mã chứng từ quản lý");
                return false;
            }

            return true;
        }
        public void RefreshHoaDon(System.Data.Objects.RefreshMode refreshMode)
        {
            BaseObjectContext context = this.GetContext();
            if (context != null)
                foreach (var item in this.tblChungTu_HoaDon)
                {
                    context.Refresh(refreshMode, item.tblHoaDon);
                }
        }
    }
}
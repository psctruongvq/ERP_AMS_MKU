using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Core;
using System.Reflection;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Objects;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main;
using PSC_ERP_Util.DateTimeExtension;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using System.Data.SqlClient;
using ERP_Library.Security;

namespace PSC_ERP_Business.Main.Factory
{
    public class ChungTuThuChi_DerivedFactory : ChungTu_Factory
    {
         UserInfo _user = ERP_Library.Security.CurrentUser.Info;

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChungTuThuChi_DerivedFactory.New().CreateAloneObject();
        }
        public static ChungTuThuChi_DerivedFactory New()
        {
            return new ChungTuThuChi_DerivedFactory();
        }
        public ChungTuThuChi_DerivedFactory()
            : base()
        {

        }

        #region Custom
        public tblChungTu NewChungTuThuChi(int maLoaiChungTu, int nam)
        {
            //khởi tạo mới chứng từ được quản lý bởi factory
            tblChungTu chungTu = this.CreateManagedObject();

            DateTime ngayHeThong = app_users_Factory.New().SystemDate;
            //xác định ngày chứng từ
            chungTu.NgayLap = ngayHeThong;


            chungTu.MaLoaiChungTu = maLoaiChungTu;

            if (maLoaiChungTu == 2 || maLoaiChungTu == 3)
            {
                chungTu.MaPhuongThucThanhToan = 1;
            }
            else if (maLoaiChungTu == 6 || maLoaiChungTu == 7 || maLoaiChungTu == 8 || maLoaiChungTu == 16)
            {
                chungTu.MaPhuongThucThanhToan = 2;
            }
            //chungTu.tblLoaiChungTu = LoaiChungTu_Factory.New().Get_LoaiChungTu_ByMaLoaiChungTu(maLoaiChungTu);


            //tạo mới tiền tệ cho chứng từ
            chungTu.tblTienTe = TienTe_Factory.New().CreateAloneObject();
            chungTu.tblTienTe.MaLoaiTien = 1;
            chungTu.tblTienTe.SoTien = chungTu.tblTienTe.ThanhTien.Value;

            //tạo mới định khoản
            chungTu.tblDinhKhoan = DinhKhoan_Factory.New().CreateAloneObject();

            ////tạo chứng từ - địa chỉ
            //chungTu.tblChungTu_DiaChi = ChungTu_DiaChi_Factory.New().CreateAloneObject();

            //Phát sinh số chứng từ mới
            chungTu.SoChungTu = Get_NextSoChungThuChi_ByYear(maLoaiChungTu, nam);

            //gán user lập
            chungTu.MaNguoiLap = PSC_ERP_Global.Main.UserID;
            return chungTu;
        }



        private string FillFormat(String format, string stringSoMoi, int year)
        {
         //   app_users user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
            tblnsBoPhan boPhan = BoPhan_Factory.New().Get_ByID((_user.MaBoPhan));
            String maBoPhanQL = "";
            if (boPhan != null)
                maBoPhanQL = boPhan.MaBoPhanQL ?? String.Empty;
            String soChungTuMoi = String.Format(format, stringSoMoi, (_user.MaQLUser ?? String.Empty), maBoPhanQL, year);
            return soChungTuMoi;
        }
        private String Get_MaxSoChungTuThuChi_ByYear(int maLoaiChungTu, int year)
        {
           // app_users user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
            int maBoPhanUser = _user.MaBoPhan;

            Int32 sizeOfNumber = PSC_ERP_Global.ThuChi.SizeOf_SoChungTuThuChi_IncreasePart;
            string soChungTu = "";

            if (BoPhan_Factory.New().Get_ByID(maBoPhanUser).MaBoPhanQL == "DV02")
            {
                soChungTu = (from o in this.ObjectSet
                             where
                             o.MaLoaiChungTu == maLoaiChungTu
                             && o.MaBoPhanDangNhap.Value == 37
                             && o.SoChungTu.Contains("DV02")
                             && o.NgayLap.Value.Year == year
                             && o.NgayLap.Value >= new DateTime(2010, 8, 1)
                             orderby o.SoChungTu.Substring(0, sizeOfNumber) descending
                             select o.SoChungTu.Substring(0, sizeOfNumber)).FirstOrDefault();

            }
            else
            {
                if (maLoaiChungTu == 2 || maLoaiChungTu == 3)
                {
                    soChungTu = (from o in this.ObjectSet
                                 where
                                 o.MaLoaiChungTu == maLoaiChungTu
                                 && o.MaBoPhanDangNhap.Value == maBoPhanUser
                                 && o.NgayLap.Value.Year == year
                                && o.NgayLap.Value >= new DateTime(2010, 3, 1)
                                 orderby o.SoChungTu.Substring(0, sizeOfNumber) descending
                                 select o.SoChungTu.Substring(0, sizeOfNumber)).FirstOrDefault();
                }
                else
                {
                    soChungTu = (from o in this.ObjectSet
                                 where
                                 o.MaLoaiChungTu == maLoaiChungTu
                                 && o.MaNguoiLap.Value == _user.UserID
                                 && o.NgayLap.Value.Year == year
                                && o.NgayLap.Value >= new DateTime(2010, 3, 1)
                                 orderby o.SoChungTu.Substring(0, sizeOfNumber) descending
                                 select o.SoChungTu.Substring(0, sizeOfNumber)).FirstOrDefault();
                }

            }

            return soChungTu;
        }
        public String Get_NextSoChungThuChi_ByYear(int maLoaiChungTu, int year)
        {
            Int32 size = PSC_ERP_Global.ThuChi.SizeOf_SoChungTuThuChi_IncreasePart;
            String result = "";

            string kytuLoaiCtu = "";
            if (maLoaiChungTu == 2)
                kytuLoaiCtu = "T/";
            else if (maLoaiChungTu == 3)
                kytuLoaiCtu = "C/";
            else if (maLoaiChungTu == 15)
                kytuLoaiCtu = "D/";
            else if (maLoaiChungTu == 16)
                kytuLoaiCtu = "K/";

            String maxSoChungTu = Get_MaxSoChungTuThuChi_ByYear(maLoaiChungTu, year);


            if (!String.IsNullOrWhiteSpace(maxSoChungTu))
            {
                int max = int.Parse(maxSoChungTu.Substring(0, size));
                int soMoi = max + 1;
                string stringSoMoi = new String('0', size - soMoi.ToString().Length) + soMoi.ToString();
                stringSoMoi = stringSoMoi + kytuLoaiCtu;
                result = FillFormat("{0}{1}/{2}/{3}", stringSoMoi, year);
            }
            else
            {
                result = FillFormat("{0}{1}/{2}/{3}", new String('0', size - 1) + "1" + kytuLoaiCtu, year);
            }

            return result;
        }



        public override tblChungTu Get_ChungTu_ByMaChungTu(long maChungTu)
        {
            tblChungTu obj = (from o in this.ObjectSet
                              where o.MaChungTu == maChungTu
                              select o).SingleOrDefault();
            return obj;
        }

        public void XoaChungTuThuChi(tblChungTu chungTu)
        {
            //clear tài sản cá biệt
            //ChungTuThuChi_Factory.FullDeleteChungTuThuChi(context: this.Context, deleteList: chungTu.tblTaiSanCoDinhCaBiets.ToList<Object>());


            //xóa tiền tệ
            if (chungTu.tblTienTe != null)
                this.Context.tblTienTes.DeleteObject(chungTu.tblTienTe);

            //xóa chứng từ hợp đồng
            ChungTu_HopDong_Factory.FullDelete(this.Context, chungTu.tblChungTu_HopDong.ToList<Object>());

            //xóa hóa đơn
            ChungTu_HoaDon_Factory.FullDelete(this.Context, chungTu.tblChungTu_HoaDon.ToList<Object>());
            //Xóa tạm ứng
            TamUng_Factory.FullDelete(this.Context, chungTu.tblTamUngs.ToList<Object>());
            //Xóa Chứng từ - Theo Dõi
            ChungTu_TheoDoi_Factory.FullDelete(this.Context, chungTu.tblChungTu_TheoDoi.ToList<Object>());
            //Xóa chứng từ - địa chỉ
            if (chungTu.tblChungTu_DiaChi != null)
                ChungTu_DiaChi_Factory.FullDelete(this.Context, chungTu.tblChungTu_DiaChi);

            tblDinhKhoan dinhKhoan = chungTu.tblDinhKhoan;
            //Xóa tblChungTu_DeNghiChuyenKhoan
            tblChungTu_DeNghiChuyenKhoan_Factory.FullDelete(this.Context, chungTu.tblChungTu_DeNghiChuyenKhoan.ToList<Object>());
            //Xóa tblChungTu_GiayBaoCo
            tblChungTu_GiayBaoCo_Factory.FullDelete(this.Context, chungTu.tblChungTu_GiayBaoCo.ToList<Object>());
            //Xóa tblChungTu_LenhChuyenTien
            tblChungTu_LenhChuyenTien_Factory.FullDelete(this.Context, chungTu.tblChungTu_LenhChuyenTien.ToList<Object>());
            //Xóa tblChungTu_GiayBanNT
            tblChungTu_GiayBanNT_Factory.FullDelete(this.Context, chungTu.tblChungTu_GiayBanNT.ToList<Object>());
            //Xóa tblChungTu_UyNhiemChi
            tblChungTu_UyNhiemChi_Factory.FullDelete(this.Context, chungTu.tblChungTu_UyNhiemChi.ToList<Object>());
            //Xóa tblChungTu_GiayRutTien
            tblChungTu_GiayRutTien_Factory.FullDelete(this.Context, chungTu.tblChungTu_GiayRutTien.ToList<Object>());
            //Xoa tblPhieuThuTuPhieuThu
            PhieuThuTuPhieuChi_Factory.FullDelete(this.Context, chungTu.tblPhieuThutuPhieuChis.ToList<Object>());
            //CapNhat ButToan cac ChungTu da Ket Chuyen Chi Phi
            ButToan_Factory.New().CapNhatButToanCacChungTuDaKCCP(chungTu.MaChungTu, PSC_ERP_Global.Main.UserID, true);
            //xóa định khoản, bút toán
            {

                if (dinhKhoan != null)
                {
                    DinhKhoan_Factory.FullDeleteDinhKhoanThuChi(this.Context, dinhKhoan);
                }
            }
            //xóa chứng từ
            this.DeleteObject(chungTu);
        }


        public IQueryable<tblChungTu> TimKiemChungTuThuChibyMaLoaiChungTu_NgayLap(int maLoaiChungTu, DateTime tuNgay, DateTime denNgay, int userID)
        {
            
            IQueryable<tblChungTu> query = null;
            IQueryable<app_UserChild> listUser = this.Context.app_UserChild.AsQueryable();

            var varUser = (from us in listUser
                           where us.UserID == userID || userID == 0
                           select us);

            query = from o in this.ObjectSet
                    where //o.MaChungTu==120967
                    o.MaNguoiLap == (from us in varUser where us.UserChild == o.MaNguoiLap select us.UserChild).FirstOrDefault()
                    && o.MaLoaiChungTu == maLoaiChungTu
                       && o.NgayLap >= tuNgay.Date
                       && o.NgayLap <= denNgay.Date
                    orderby o.NgayLap, o.SoChungTu ascending
                    select o;

            //query = from o in this.ObjectSet
            //        join us in varUser on o.MaNguoiLap equals us.UserChild
            //        where o.MaLoaiChungTu == maLoaiChungTu
            //           && o.NgayLap >= tuNgay.Date
            //           && o.NgayLap <= denNgay.Date
            //        orderby o.NgayLap, o.SoChungTu ascending
            //        select o;


            return query;
        }

        public IQueryable<tblChungTu> TimKiemChungTuThuChibySearch(int maLoaiChungTu, string soChungTu, decimal sotienTu, decimal soTienDen, DateTime tuNgay, DateTime denNgay, int matkNo, int matkCo, string dienGiai, string doiTuong, int userID)
        {
            IQueryable<tblChungTu> query = null;
            IQueryable<app_UserChild> listUser = this.Context.app_UserChild.AsQueryable();
            IQueryable<tblTienTe> tiente = this.Context.tblTienTes.AsQueryable();
            var varUser = (from us in listUser
                           where us.UserID == userID || userID == 0
                           select us);
            IQueryable<tblTaiKhoan> listTaiKhoan = this.Context.tblTaiKhoans.AsQueryable();
            IQueryable<tblButToan> listButtoan = this.Context.tblButToans.AsQueryable();
            var varDinhKhoan = (
                                    from bt in listButtoan
                                    where (matkNo == 0 || bt.NoTaiKhoan == matkNo)
                                    && (matkCo == 0 || bt.CoTaiKhoan == matkCo)
                                    select new
                                    {
                                        MaDinhKhoan = bt.MaDinhKhoan
                                    }

                                ).Distinct();

            query = from o in this.ObjectSet
                    join tt in tiente on o.MaChungTu equals tt.MaTienTe
                    join dk in varDinhKhoan on o.MaDinhKhoan equals dk.MaDinhKhoan
                    where
                    o.MaNguoiLap == (from us in varUser where us.UserChild == o.MaNguoiLap select us.UserChild).FirstOrDefault()
                    && o.MaLoaiChungTu == maLoaiChungTu
                       && o.NgayLap >= tuNgay.Date
                       && o.NgayLap <= denNgay.Date
                       && o.SoChungTu.Contains(soChungTu)
                       && tt.ThanhTien>=sotienTu
                       && (soTienDen==0 || tt.ThanhTien <= soTienDen )
                       && o.DienGiai.Contains(dienGiai)
                    orderby o.NgayLap, o.SoChungTu ascending
                    select o;


            return query;
        }



        public IQueryable<tblChungTu> TimKiemChungTuThuChibyBoPhan_NgayLap(DateTime tuNgay, DateTime denNgay, int maBoPhan)
        {
            IQueryable<tblChungTu> query = null;
            IQueryable<tblTaiKhoan> listTaiKhoan = this.Context.tblTaiKhoans.AsQueryable();
            IQueryable<tblButToan> listButtoan = this.Context.tblButToans.AsQueryable();
            var varDinhKhoan = (from tk in listTaiKhoan
                                join bt in listButtoan on tk.MaTaiKhoan equals bt.NoTaiKhoan
                                where tk.SoHieuTK.Contains("3113")
                                select new
                                {
                                    MaDinhKhoan = bt.MaDinhKhoan
                                }
                               ).Distinct();

            query = from o in this.ObjectSet
                    join dk in varDinhKhoan on o.MaDinhKhoan equals dk.MaDinhKhoan
                    where o.MaBoPhanDangNhap == maBoPhan
                       && o.NgayLap >= tuNgay.Date
                       && o.NgayLap <= denNgay.Date
                    orderby o.NgayLap, o.SoChungTu ascending
                    select o;

            return query;
        }

        public IQueryable<tblChungTu> TimKiem(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, Decimal soTien, Decimal soTienDen, DateTime ngayChungTu, DateTime ngayChungTuDen, Int64 maDoiTac)
        {
            IQueryable<tblChungTu> query = null;


            switch (loaiTim)
            {
                case LoaiTimChungTuEnum.TatCa:
                    query = this.GetAll();
                    break;
                case LoaiTimChungTuEnum.SoChungTu://tìm theo số chứng từ
                    {

                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in this.ObjectSet
                                    where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                     && o.SoChungTu == soChungTu
                                    orderby o.NgayLap descending
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soChungTuLower = soChungTu.ToLower();
                            query = from o in this.ObjectSet
                                    where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                     && o.SoChungTu.ToLower().Contains(soChungTuLower)
                                    orderby o.NgayLap descending
                                    select o;
                        }

                    }
                    break;
                case LoaiTimChungTuEnum.NgayLap://tìm theo ngày chứng từ
                    {
                        switch (compareType)
                        {
                            case CompareTypeEnum.Equal:
                                query = from o in this.ObjectSet
                                        where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                         && o.NgayLap == ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in this.ObjectSet
                                        where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                         && o.NgayLap < ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in this.ObjectSet
                                        where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                         && o.NgayLap <= ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in this.ObjectSet
                                        where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                         && o.NgayLap >= ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in this.ObjectSet
                                        where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                         && o.NgayLap > ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in this.ObjectSet
                                        where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                         && o.NgayLap >= ngayChungTu.Date
                                         && o.NgayLap <= ngayChungTuDen.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case LoaiTimChungTuEnum.SoTien://tìm theo số tiền
                    switch (compareType)
                    {
                        case CompareTypeEnum.Equal:
                            query = from o in this.ObjectSet
                                    where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                     && o.tblTienTe.ThanhTien == soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThan:
                            query = from o in this.ObjectSet
                                    where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                     && o.tblTienTe.ThanhTien < soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThanOrEqual:
                            query = from o in this.ObjectSet
                                    where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                     && o.tblTienTe.ThanhTien <= soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThanOrEqual:
                            query = from o in this.ObjectSet
                                    where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                     && o.tblTienTe.ThanhTien >= soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThan:
                            query = from o in this.ObjectSet
                                    where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                     && o.tblTienTe.ThanhTien > soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.Between:
                            query = from o in this.ObjectSet
                                    where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                     && o.tblTienTe.ThanhTien >= soTien
                                     && o.tblTienTe.ThanhTien <= soTienDen
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        default:
                            break;
                    }
                    break;
                case LoaiTimChungTuEnum.DoiTac://tìm theo mã đối tác
                    query = from o in this.ObjectSet
                            where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                             && o.MaDoiTuong == maDoiTac
                            orderby o.NgayLap descending
                            select o;
                    break;
                default:
                    break;
            }

            return query;
        }

        public decimal KiemTraSoQuy(long maChungTu)
        {
            decimal kiemtra = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.NormalConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        try
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "sp_KiemTraSoQuyE";
                            cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                            SqlParameter parResult = new SqlParameter("@Result", SqlDbType.Decimal, 18);
                            parResult.Direction = ParameterDirection.Output;
                            cm.Parameters.Add(@parResult);
                            cm.ExecuteNonQuery();
                            kiemtra =(decimal) parResult.Value;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kiemtra;
        }

        #endregion
    }//end class
}

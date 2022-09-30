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
using System.Data.Objects.DataClasses;
//Cường


namespace PSC_ERP_Business.Main.Model
{

    public partial class tblChungTu
    {

        public decimal SoTien
        {
            get
            {
                return this.tblTienTe.SoTien;
            }

        }

        public Nullable<decimal> ThanhTien
        {
            get
            {
                return this.tblTienTe.ThanhTien ?? 0;
            }

        }


        public bool KiemTraDinhKhoanBangKe()
        {
            app_users user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
            int maBoPhanUser = user.MaBoPhan ?? 0;
            int maCongTyuSer = user.MaCongTy ?? 0;

            //kiểm tra định khoản
            if (this.tblDinhKhoan.tblButToans.Count() == 0)
            {
                DialogUtil.ShowError("Chưa nhập định khoản");
                return false;
                //if (DialogResult.No == DialogUtil.ShowYesNo("Bạn muốn lưu chứng từ với định khoản rỗng?"))
                //    return false;
            }
            else
            {
                //kiểm tra số tiền bút toán - công việc chương trình
                {
                    Decimal tongTienButToan = 0;
                    Decimal tongTienChiPhiSanXuat = 0;
                    foreach (var butToan in this.tblDinhKhoan.tblButToans)
                    {

                        tongTienButToan += butToan.SoTien;

                        if (maCongTyuSer == 3)//Hang Phim TFS
                        {
                            if (butToan.tblCT_ChiPhiSanXuat.Count == 0)
                            {
                                MessageBox.Show("Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            //kiểm tra tổng tiền chi phi san xuat từng bút toán
                            {
                                Decimal tongTienChiPhiSanXuatTheoButToanHienTai = 0;
                                foreach (var chiPhi in butToan.tblCT_ChiPhiSanXuat)
                                {
                                    tongTienChiPhiSanXuatTheoButToanHienTai += chiPhi.SoTien ?? 0;
                                    tongTienChiPhiSanXuat += chiPhi.SoTien ?? 0;
                                }

                                if (tongTienChiPhiSanXuatTheoButToanHienTai != butToan.SoTien && butToan.tblCT_ChiPhiSanXuat.Any())//.Count > 0)
                                {
                                    DialogUtil.ShowError("Số tiền chi phí theo bút toán không bằng số tiền bút toán");
                                    return false;
                                }
                            }
                        }
                        //
                        //tai khoan
                        if ((butToan.NoTaiKhoan ?? 0) == 0 || (butToan.CoTaiKhoan ?? 0) == 0)
                        {
                            DialogUtil.ShowError("Chưa chọn đầy đủ tài khoản của bút toán");
                            return false;
                        }

                        else if (butToan.NoTaiKhoan == butToan.CoTaiKhoan)
                        {
                            DialogUtil.ShowError("Tài khoản Nợ và Có giống nhau. Không hợp lệ!");
                            return false;
                        }
                        //doi tuong
                        else
                        {
                            tblTaiKhoan httkno = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.NoTaiKhoan.Value);
                            tblTaiKhoan httkco = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.CoTaiKhoan.Value);
                            string noTK = httkno.SoHieuTK;
                            string CoTK = httkco.SoHieuTK;

                            if (httkno.CoDoiTuongTheoDoi == true)
                            {
                                if (butToan.MaDoiTuongNo == 0)
                                {
                                    MessageBox.Show("Vui lòng chọn đối tượng nợ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            if (httkco.CoDoiTuongTheoDoi == true)
                            {
                                if (butToan.MaDoiTuongCo == 0)
                                {
                                    MessageBox.Show("Vui lòng chọn đối tượng Có ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            //Công việc - chương trinh
                            if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.Contains("631") || noTK.Contains("4314"))
                            {
                                if (butToan.tblCT_ChiPhiSanXuat.Count == 0)
                                {
                                    MessageBox.Show("Bạn phải chọn công việc/chương trình cho Bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                                else
                                {
                                    foreach (tblCT_ChiPhiSanXuat cp in butToan.tblCT_ChiPhiSanXuat)
                                    {
                                        if (cp.tblButToan_MucNganSach.Count == 0 && (noTK.Contains("631") || noTK.Contains("4314")))
                                        {
                                            MessageBox.Show("Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return false;
                                        }
                                    }
                                }
                            }
                            //Tạm ứng
                            if (noTK == "312" || noTK == "312.5" || noTK == "312.9" || noTK == "312.9" || noTK == "312.93" || CoTK == "312" || CoTK == "312.5" || CoTK == "312.9" || CoTK == "312.9" || CoTK == "312.93")
                            //if (noTK.Contains("312") )
                            {
                                if (this.tblTamUngs.Count == 0)
                                {
                                    MessageBox.Show("Vui lòng chọn nhập tạm ứng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                            }
                        }
                        //
                    }

                    if (tongTienButToan != this.tblTienTe.ThanhTien)
                    {
                        DialogUtil.ShowError("Tổng tiền bút toán không bằng số tiền chứng từ");
                        return false;
                    }

                }

            }//end else
            return true;
        }

        public bool KiemTraDinhKhoanPhieuThu()
        {
            app_users user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
            int maBoPhanUser = user.MaBoPhan ?? 0;
            int maCongTyuSer = user.MaCongTy ?? 0;

            //kiểm tra định khoản
            if (this.tblDinhKhoan.tblButToans.Count() == 0)
            {
                DialogUtil.ShowError("Chưa nhập định khoản");
                return false;
                //if (DialogResult.No == DialogUtil.ShowYesNo("Bạn muốn lưu chứng từ với định khoản rỗng?"))
                //    return false;
            }
            else
            {
                //kiểm tra số tiền bút toán - công việc chương trình
                {
                    Decimal tongTienButToan = 0;
                    Decimal tongTienChiPhiSanXuat = 0;
                    foreach (var butToan in this.tblDinhKhoan.tblButToans)
                    {
                        tongTienButToan += butToan.SoTien;
                        //kiểm tra tổng tiền chi phi san xuat từng bút toán
                        {
                            Decimal tongTienChiPhiSanXuatTheoButToanHienTai = 0;
                            foreach (var chiPhi in butToan.tblCT_ChiPhiSanXuat)
                            {
                                Decimal tongTienButToan_MNS = 0;
                                foreach (tblButToan_MucNganSach bt_mns in chiPhi.tblButToan_MucNganSach)
                                {
                                    tongTienButToan_MNS += bt_mns.SoTien;
                                }
                                if (tongTienButToan_MNS != (chiPhi.SoTien ?? 0))
                                {
                                    DialogUtil.ShowError("Số tiền bút toán - mục ngân sách không bằng số tiền chi phí");
                                    return false;
                                }
                                tongTienChiPhiSanXuatTheoButToanHienTai += chiPhi.SoTien ?? 0;
                                tongTienChiPhiSanXuat = chiPhi.SoTien ?? 0;
                            }

                            if (tongTienChiPhiSanXuatTheoButToanHienTai != butToan.SoTien && butToan.tblCT_ChiPhiSanXuat.Any())//.Count > 0)
                            {
                                DialogUtil.ShowError("Số tiền chi phí theo bút toán không bằng số tiền bút toán");
                                return false;
                            }
                        }
                        //tai khoan
                        if ((butToan.NoTaiKhoan ?? 0) == 0 || (butToan.CoTaiKhoan ?? 0) == 0)
                        {
                            DialogUtil.ShowError("Chưa chọn đầy đủ tài khoản của bút toán");
                            return false;
                        }
                        //doi tuong
                        else
                        {
                            tblTaiKhoan httkno = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.NoTaiKhoan.Value);
                            tblTaiKhoan httkco = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.CoTaiKhoan.Value);
                            string noTK = httkno.SoHieuTK;
                            string CoTK = httkco.SoHieuTK;

                            if (httkno.CoDoiTuongTheoDoi == true)
                            {
                                if (butToan.MaDoiTuongNo == 0)
                                {
                                    MessageBox.Show("Vui lòng chọn đối tượng nợ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            if (httkco.CoDoiTuongTheoDoi == true)
                            {
                                if (butToan.MaDoiTuongCo == 0)
                                {
                                    MessageBox.Show("Vui lòng chọn đối tượng Có ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }

                            //Tạm ứng
                            if (noTK == "312" || noTK == "312.5" || noTK == "312.9" || noTK == "312.9" || noTK == "312.93" || CoTK == "312" || CoTK == "312.5" || CoTK == "312.9" || CoTK == "312.9" || CoTK == "312.93")
                            //if (noTK.Contains("312") )
                            {
                                if (this.tblTamUngs.Count == 0)
                                {
                                    MessageBox.Show("Vui lòng chọn nhập tạm ứng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                            }
                        }
                        //
                    }

                    if (tongTienButToan != this.tblTienTe.ThanhTien)
                    {
                        DialogUtil.ShowError("Tổng tiền bút toán không bằng số tiền chứng từ");
                        return false;
                    }

                }

            }//end else
            return true;
        }

        public bool KiemTraDinhKhoanPhieuChi()
        {
            app_users user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
            int maBoPhanUser = user.MaBoPhan ?? 0;
            int maCongTyuSer = user.MaCongTy ?? 0;

            //kiểm tra định khoản
            if (this.tblDinhKhoan.tblButToans.Count() == 0)
            {
                DialogUtil.ShowError("Chưa nhập định khoản");
                return false;
                //if (DialogResult.No == DialogUtil.ShowYesNo("Bạn muốn lưu chứng từ với định khoản rỗng?"))
                //    return false;
            }
            else
            {
                //kiểm tra số tiền bút toán - công việc chương trình
                {
                    Decimal tongTienButToan = 0;
                    Decimal tongTienChiPhiSanXuat = 0;
                    foreach (var butToan in this.tblDinhKhoan.tblButToans)
                    {
                        if (maCongTyuSer == 3)//Hang Phim TFS
                        {
                            if (butToan.tblCT_ChiPhiSanXuat.Count == 0)
                            {
                                MessageBox.Show("Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }

                        if (butToan.NoTaiKhoan.ToString().StartsWith("431"))//Hang Phim TFS
                        {
                            if (butToan.tblCT_ChiPhiSanXuat.Count == 0)
                            {
                                MessageBox.Show("Vui lòng nhập thù lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            tongTienButToan += butToan.SoTien;
                            //kiểm tra tổng tiền chi phi san xuat từng bút toán
                            {
                                Decimal tongTienChiPhiSanXuatTheoButToanHienTai = 0;
                                foreach (var chiPhi in butToan.tblCT_ChiPhiSanXuat)
                                {
                                    tongTienChiPhiSanXuatTheoButToanHienTai += chiPhi.SoTien ?? 0;
                                    tongTienChiPhiSanXuat += chiPhi.SoTien ?? 0;
                                }

                                if (tongTienChiPhiSanXuatTheoButToanHienTai != butToan.SoTien && butToan.tblCT_ChiPhiSanXuat.Any())//.Count > 0)
                                {
                                    DialogUtil.ShowError("Số tiền chi phí theo bút toán không bằng số tiền bút toán");
                                    return false;
                                }
                            }
                        }
                        //
                        //tai khoan
                        if ((butToan.NoTaiKhoan ?? 0) == 0 || (butToan.CoTaiKhoan ?? 0) == 0)
                        {
                            DialogUtil.ShowError("Chưa chọn đầy đủ tài khoản của bút toán");
                            return false;
                        }
                        //doi tuong
                        else
                        {
                            tblTaiKhoan httkno = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.NoTaiKhoan.Value);
                            tblTaiKhoan httkco = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(butToan.CoTaiKhoan.Value);
                            string noTK = httkno.SoHieuTK;
                            string CoTK = httkco.SoHieuTK;

                            if (httkno.CoDoiTuongTheoDoi == true)
                            {
                                if (butToan.MaDoiTuongNo == 0)
                                {
                                    MessageBox.Show("Vui lòng chọn đối tượng nợ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            if (httkco.CoDoiTuongTheoDoi == true)
                            {
                                if (butToan.MaDoiTuongCo == 0)
                                {
                                    MessageBox.Show("Vui lòng chọn đối tượng Có ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            //Công việc - chương trinh
                            if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.Contains("631") || noTK.Contains("4314"))
                            {
                                if (butToan.tblCT_ChiPhiSanXuat.Count == 0)
                                {
                                    MessageBox.Show("Bạn phải chọn công việc/chương trình cho Bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                                else
                                {
                                    foreach (tblCT_ChiPhiSanXuat cp in butToan.tblCT_ChiPhiSanXuat)
                                    {
                                        if (cp.tblButToan_MucNganSach.Count == 0 && (noTK.Contains("631") || noTK.Contains("4314")))
                                        {
                                            MessageBox.Show("Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return false;
                                        }
                                    }
                                }
                            }
                            //Tạm ứng
                            if (noTK == "312" || noTK == "312.5" || noTK == "312.9" || noTK == "312.9" || noTK == "312.93" || CoTK == "312" || CoTK == "312.5" || CoTK == "312.9" || CoTK == "312.9" || CoTK == "312.93")
                            //if (noTK.Contains("312") )
                            {
                                if (this.tblTamUngs.Count == 0)
                                {
                                    MessageBox.Show("Vui lòng chọn nhập tạm ứng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                            }
                        }
                        //
                    }

                    if (tongTienButToan != this.tblTienTe.ThanhTien)
                    {
                        DialogUtil.ShowError("Tổng tiền bút toán không bằng số tiền chứng từ");
                        return false;
                    }

                }

            }//end else
            return true;
        }

        public bool KiemTraHoaDonThuChi()
        {
            if (this.tblChungTu_HoaDon.Count == 0)
            {
                //DialogUtil.ShowError("Chưa nhập hóa đơn");
                //return false;
            }
            else
            {
                //lấy tổng tiền hóa đơn và tổng tiền thuế VAT trong hóa đơn
                Decimal tongTienHoaDon = 0;
                decimal tongTienThueVATTrongHoaDon = 0;
                foreach (var chungTuHoaDon in this.tblChungTu_HoaDon)
                {
                    tongTienThueVATTrongHoaDon += chungTuHoaDon.tblHoaDon.ThueVAT;
                    tongTienHoaDon += chungTuHoaDon.tblHoaDon.TongTien;
                }

                //lấy tổng tiền bút toán thuế
                decimal tongTienButToanThue = 0;
                TaiKhoan_Factory taiKhoan_factory = TaiKhoan_Factory.New();
                foreach (var butToan in this.tblDinhKhoan.tblButToans)
                {
                    //kiểm tra đối tượng nợ
                    tblTaiKhoan noTK = taiKhoan_factory.Get_TaiKhoan_ByMaTaiKhoan(butToan.NoTaiKhoan.Value);
                    if (noTK.SoHieuTK.StartsWith("31131"))
                        tongTienButToanThue += butToan.SoTien;
                }


                //kiểm tra tổng tiền hóa đơn phải bằng tổng tiền chứng từ
                //if (tongTienHoaDon != this.tblTienTe.ThanhTien.Value)
                //{
                //    DialogUtil.ShowWarning("Tổng tiền hóa đơn phải bằng tổng tiền chứng từ");
                //    return false;
                //}

                //kiểm tra tổng tiền phần thuế VAT trong hóa đơn phải bằng tổng tiền bút toán thuế nếu bút toán thuế có khai báo
                if (tongTienButToanThue > 0 && tongTienThueVATTrongHoaDon != tongTienButToanThue)
                {
                    DialogUtil.ShowWarning("Tổng tiền bút toán thuế 31131... phải bằng tổng tiền thuế VAT trong hóa đơn");
                    return false;
                }
            }

            return true;
        }


    }
}
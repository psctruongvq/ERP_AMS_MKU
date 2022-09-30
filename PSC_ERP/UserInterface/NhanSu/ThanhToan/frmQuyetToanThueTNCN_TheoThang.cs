using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmQuyetToanThueTNCN_TheoThang : Form
    {
        #region Properties
        int Thang = 0;
        int Nam = 0;
        QuyetToanThueTNCN_TheoThangList _data;
        #endregion

        #region Load
        public frmQuyetToanThueTNCN_TheoThang()
        {
            InitializeComponent();
            Load_Form();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdData.DisplayLayout.Bands[0],
                new string[21] { "MaNhanVien", "TenNhanVien", "MST", "CMND", "TuQuyetToan", "TongThuNhapChiuThue", "SoNguoiPhuThuoc", "BHBatBuoc", "DaNop", "TongTienThue", "BHXH", "BHYT", "BHTN", "TenBoPhan", "TongThuNhap", "TongGiamTru", "ConPhaiNop_SuDung", "ThueNLDNopThem", "ThueNLDTraLai", "TinhTrang", "SoThang" },
                new string[21] { "MaNhanVien", "Tên nhân viên", "MST", "CMND", "Tự QT", "Tổng thu nhập chịu thuế", "Số NPT", "BH Bắt buộc", "Đã nộp", "Tiền thuế", "BHXH", "BHYT", "BHTN", "Bộ phận", "Tổng thu nhập", "Tổng tiền giảm trừ", "Còn phải nộp", "Thuế Nộp Thêm", "Thuế Trả Lại", "Tình trạng", "Số Tháng" },
                new int[21] { 150, 150, 130, 130, 130, 130, 80, 130, 130, 130, 130, 80, 130, 130, 130, 130, 130, 130, 130, 130, 130 },
                new Control[21] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                new KieuDuLieu[21] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[21] { false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, true, false, true, true, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;//x =  //= System.Drawing.w;//RoyalBlue
            }

        }
        #endregion

        #region Process
        private void Load_Form()
        {
            cmbKyTinhLuong.DataSource = KyTinhLuongList.GetKyTinhLuongList();
            _data = QuyetToanThueTNCN_TheoThangList.GetQuyetToanThueTNCN_TheoThangList(Thang, Nam, checkBox_Thue.Checked);
            bdDanhSach.DataSource = _data;
            if (_data !=null && _data.Count>0 && _data[0].Thang == 12)
            {
                dtmp_NgayChotBienLai.Value = DateTime.Now.Date;
            }
        }
        #endregion

        #region Events
        private void cmbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int MaKy = Convert.ToInt32(cmbKyTinhLuong.Value);
                DateTime ngay = KyTinhLuong.GetKyTinhLuong(MaKy).NgayBatDau;
                Thang = ngay.Month;
                Nam = ngay.Year;

                if (MaKy != 0)
                {
                    _data = QuyetToanThueTNCN_TheoThangList.GetQuyetToanThueTNCN_TheoThangList(Thang, Nam, checkBox_Thue.Checked);
                    bdDanhSach.DataSource = _data;
                }
                QTCuoiNamcheckBox.Checked = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlUndo_Click(object sender, EventArgs e)
        {
            Load_Form();
        }
        #endregion

        private void btn_QuyetToan_Click(object sender, EventArgs e)
        {
            try
            {
                bool duocQuyetToan = true;
                ERP_Library.KyTinhLuong i = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyTinhLuong.Value);
                if (i.KhoaSoKy2)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên không thể tính lại bảng lương", "Tính lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Thang == 0)
                {
                    MessageBox.Show(this, "Vui lòng chọn kỳ tính lương cần quyết toán !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (QuyetToanThueTNCN_TheoThang.KiemTraQuyetToanThueTNCN(Thang, Nam) == 1)
                {
                    MessageBox.Show(this, "Đã tồn tại chứng từ ở tháng tiếp theo. Vui lòng xóa các chứng từ này trước !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (QuyetToanThueTNCN_TheoThang.KiemTraQuyetToanThueTNCN(Thang, Nam) == 2)
                {
                    if (MessageBox.Show(this, "Kỳ tính lương đã được quyết toán. Thao tác này sẽ làm thay đổi dữ liệu hiện tại, đã chắc chắn thay đổi ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        //QuyetToanThueTNCN_TheoThang.XoaQuyetToanThueTNCN(Thang, Nam);
                        //QuyetToanThueTNCN_TheoThang.XuLyQuyetToanThueTNCN(Thang, Nam);
                        duocQuyetToan = true;
                    }
                    else
                    {
                        return;
                    }
                }
                if (duocQuyetToan)
                {
                    QuyetToanThueTNCN_TheoThang.XuLyQuyetToanThueTNCN(Thang, Nam,QTCuoiNamcheckBox.Checked);
                }
                if (ERP_Library.Security.CurrentUser.IsAdminNhanSu)
                {
                    i.KhoaSoKy2 = true;
                    i.Save();
                }

                MessageBox.Show(this, "Hoàn tất việc xử lý quyết toán thuế !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_Form();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                HamDungChung.ExportToExcel(grdData);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnBoSungThue_Click(object sender, EventArgs e)
        {
            try
            {
                //foreach (QuyetToanThueTNCN_TheoThang item in _data)
                //{
                //    if (item.TNCNDongBoSung > item.ConPhaiNop_SuDung && item.TinhTrang)
                //    {
                //        MessageBox.Show(this, "Tiền thuế nộp bổ sung không được phép lớn hơn tiền thuế còn phải nộp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}

            

                _data.ApplyEdit();
                _data.Save();
                MessageBox.Show(this, "Đã cập nhật thành công bổ sung thuế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bdDanhSach.DataSource = _data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void checkBox_Thue_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int MaKy = Convert.ToInt32(cmbKyTinhLuong.Value);
                DateTime ngay = KyTinhLuong.GetKyTinhLuong(MaKy).NgayBatDau;
                Thang = ngay.Month;
                Nam = ngay.Year;

                if (MaKy != 0)
                {
                    _data = QuyetToanThueTNCN_TheoThangList.GetQuyetToanThueTNCN_TheoThangList(Thang, Nam, checkBox_Thue.Checked);
                    bdDanhSach.DataSource = _data;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tổngHợpQuyếtToánThuếTNCNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(6);
        }
        KyTinhLuong _ky;
        private void OpenReport(int Loai)
        {


            int num;
            //long num2;

            //try
            //{
            //    num = _bophan;//(int)this.cmbBoPhan.Value;
            //}
            //catch
            //{
            //    num = 0;
            //}
            //try
            //{
            //    num2 = _nhanvien;//(long)this.ComboboxNhanVien.Value;
            //}
            //catch
            //{
            //    num2 = 0L;
            //}
            frmXemIn @in = new frmXemIn();
            if (cmbKyTinhLuong.Value != null)
            {
                _ky = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cmbKyTinhLuong.Value));
            }
            else
            {
                MessageBox.Show(this, "Vui Lòng Chọn Đến Tháng Quyết Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (Loai)
            {
                case 1:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCNNam.rdlc";
                    break;
                case 20:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCNNamCuaHTVNew.rdlc";
                    break;

                case 2:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCNNamNhanVien.rdlc";
                    break;

                case 3:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptDanhSachThuTienThueTNCN.rdlc";
                    break;

                case 4:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptDanhSachTraTienThueTNCN.rdlc";
                    break;

                //case 5:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCNNam.rdlc";
                //    BangKeThueTNCNList _bangKeThueTNCNList = BangKeThueTNCNList.GetBangKeThueTNCNListByNghiViec(Convert.ToInt32(this.txtNam.Value), num, num2, this.checkBox_InQuyetToan.Checked);
                //    @in.SetDatabase("ERP_Library_BangKeThueTNCNList", _bangKeThueTNCNList);
                //    break;

                case 6:
                    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeTongHopThueTNCNNamNew.rdlc";
                    @in.SetDatabase("ERP_Library_Report_TongHopQuyetToanThueList", TongHopQuyetToanThueList.GetTongHopQuyetToanThueList(Nam, this.checkBox_Thue.Checked));
                    break;


                //case 7:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeTongHopThueTNCNNamNhanVien.rdlc";
                //    @in.SetDatabase("ERP_Library_Report_TongHopQuyetToanThueList", TongHopQuyetToanThueList.GetTongHopQuyetToanThueList(Convert.ToInt32(this.txtNam.Value), this.checkBox_InQuyetToan.Checked));
                //    break;

                //case 21:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeTongHopThueTNCNNamNhanVienHTV.rdlc";
                //    @in.SetDatabase("ERP_Library_TongHopQuyetToanThueList", TongHopQuyetToanThueList.GetTongHopQuyetToanThueList(Convert.ToInt32(this.txtNam.Value), this.checkBox_InQuyetToan.Checked));
                //    break;

                //case 8:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCN_09A.rdlc";
                //    BangKeThueTNCNList bangKeThueTNCNListGetBangKeThueTNCNList = BangKeThueTNCNList.GetBangKeThueTNCNList(Convert.ToInt32(this.txtNam.Value), num, num2, this.checkBox_InQuyetToan.Checked);
                //    @in.SetDatabase("ERP_Library_BangKeThueTNCNList", bangKeThueTNCNListGetBangKeThueTNCNList);
                //    break;

                //case 9:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCN_09ANhanVien.rdlc";
                //    //@in.SetDatabase("ERP_Library_BangKeThueTNCNList", BangKeThueTNCNList.GetBangKeThueTNCNList(Convert.ToInt32(this.txtNam.Value), num, num2, this.chkTuQuyetToan.Checked));
                //    break;

                //case 10:

                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptInChiTietQuyetToan.rdlc";
                //    this._dataChiTiet = InChiTietThueTNCN_NhanVienList.GetInChiTietThueTNCN_NhanVienList(num2, num, Convert.ToInt32(this.txtNam.Value), true, checkBox_InQuyetToan.Checked, _ky.Thang);
                //    @in.Report.SubreportProcessing += new SubreportProcessingEventHandler(this.ReportChiTiet_SubreportProcessing);
                //    @in.SetDatabase("ERP_Library_Report_InChiTietThueTNCN_NhanVienList", this._dataChiTiet);
                //    @in.SetParameter(new string[] { "ChuKy", this.GetChuKy() });

                //    break;


                //case 11:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptInChiTietQuyetToan.rdlc";
                //    //this._dataChiTiet = InChiTietThueTNCN_NhanVienList.GetInChiTietThueTNCN_NhanVienList(num2, num, Convert.ToInt32(this.txtNam.Value), false, checkBox_InQuyetToan.Checked);
                //    @in.Report.SubreportProcessing += new SubreportProcessingEventHandler(this.ReportChiTiet_SubreportProcessing);
                //    @in.SetDatabase("ERP_Library_Report_InChiTietThueTNCN_NhanVienList", this._dataChiTiet);
                //    @in.SetParameter(new string[] { "ChuKy", this.GetChuKy() });
                //    break;

                //case 12:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptInChiTietQuyetToan2.rdlc";
                //    this._dataChiTiet2 = InChiTietThueTNCN2_TongHopList.GetInChiTietThueTNCN2_TongHopList(Convert.ToInt32(this.txtNam.Value), num, num2, true);
                //    @in.SetDatabase("ERP_Library_Report_InChiTietThueTNCN2_TongHopList", this._dataChiTiet2);
                //    @in.SetParameter(new string[] { "ChuKy", this.GetChuKy() });
                //    break;

                //case 13:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptInChiTietQuyetToan2.rdlc";
                //    this._dataChiTiet2 = InChiTietThueTNCN2_TongHopList.GetInChiTietThueTNCN2_TongHopList(Convert.ToInt32(this.txtNam.Value), num, num2, false);
                //    @in.SetDatabase("ERP_Library_Report_InChiTietThueTNCN2_TongHopList", this._dataChiTiet2);
                //    @in.SetParameter(new string[] { "ChuKy", this.GetChuKy() });
                //    break;

                //case 14:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptDanhSachThuThueTNCNNVTuQuyetToan.rdlc";
                //    @in.SetDatabase("ERP_Library_Report_DanhSachThuThueNVTuQuyetToanList", DanhSachThuThueNVTuQuyetToanList.GetDanhSachThuThueNVTuQuyetToanList((int)this.txtNam.Value));
                //    break;

                //case 15:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBangKeThueTNCNKy3QuyetToanNam.rdlc";
                //    @in.SetDatabase("ERP_Library_Report_ChiTietThueTNCNKy3QuyetToanNamList", ChiTietThueTNCNKy3QuyetToanNamList.GetChiTietThueTNCNKy3QuyetToanNamList(Convert.ToInt32(this.txtNam.Value), this.checkBox_InQuyetToan.Checked));
                //    break;

                //case 0x10:
                //    @in.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptTongHopThueTNCNKy3QuyetToanNam.rdlc";
                //    @in.SetDatabase("ERP_Library_Report_ChiTietThueTNCNKy3QuyetToanNamList", ChiTietThueTNCNKy3QuyetToanNamList.GetTongHopThueTNCNKy3QuyetToanNamList(Convert.ToInt32(this.txtNam.Value), this.checkBox_InQuyetToan.Checked));
                //    break;
            }
            if (@in.Report.DataSources.Count == 0)
            {

                BangKeThueTNCNList _bangKeThueTNCNList = BangKeThueTNCNList.GetBangKeThueTNCNList2013(Nam, ERP_Library.Security.CurrentUser.Info.UserID, checkBox_Thue.Checked);
                @in.SetDatabase("ERP_Library_BangKeThueTNCNList", _bangKeThueTNCNList);

                //_BangKeThueTNCN_NVList = ERP_Library.Report.BangKeThueTNCN_NVList.GetBangKeThueTNCN_NVList(maKyTinhLuong, (int)cmbBoPhan.Value, namTinh);
                //bindingSource_ToKhaiTNCNLias.DataSource = _BangKeThueTNCN_NVList;
            }
            @in.SetParameter(new string[] { "TenBoPhan", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan });
            @in.SetParameter(new string[] { "Nam", "Năm : " +Nam });
            if ((((Loai != 10) && (Loai != 11)) && (Loai != 12)) && (Loai != 13))
            {
                @in.SetNguoiKy(Convert.ToInt32(3));
            }
            @in.ShowDialog();
        }

        private void tổngHợpQuyếtToánThuếTNCNVớiNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenReport(20);
        }

        private void toolStripBtnInBienLai_Click(object sender, EventArgs e)
        {
            if (_data[0].Thang != 12)
            {
                MessageBox.Show("Chỉ quyết toán cuối năm mới thực hiện chức năng này!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (InBienLaiNhanVienTuQuyetToan.KiemTraMaKyQuyetToanDaInBienLai(_data[0].MaKyQuyetToan)==0)
            {
                MessageBox.Show("Kỳ Quyêt Toán Này đã In Biên Lai!", "Thôgn Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmInBienLaiNhanVienTuQuyetToan frm = new frmInBienLaiNhanVienTuQuyetToan(_data[0].MaKyQuyetToan);
                frm.ShowDialog();
            }
            else
            {
                QuyetToanThueTNCN_TheoThangList dStuQuyetToan = QuyetToanThueTNCN_TheoThangList.NewQuyetToanThueTNCN_TheoThangList();
                foreach (QuyetToanThueTNCN_TheoThang itemQT in _data)
                {
                    if (itemQT.TuQuyetToan && itemQT.TongTienThue>0)
                    {
                        dStuQuyetToan.Add(itemQT);
                    }
                }
                if (dStuQuyetToan.Count > 0)
                {
                    frmInBienLaiNhanVienTuQuyetToan frm = new frmInBienLaiNhanVienTuQuyetToan(dStuQuyetToan);
                    frm.ShowDialog();
                }
            }
        }

        private void btnChotBienLai_Click(object sender, EventArgs e)
        {
            if (_data[0].Thang != 12)
            {
                MessageBox.Show("Chỉ quyết toán cuối năm mới thực hiện chức năng này!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int CheckKyChotBienLai=InBienLaiNhanVienTuQuyetToan.KiemTraMaKyQuyetToanDaInBienLai(_data[0].MaKyQuyetToan);
            if (CheckKyChotBienLai == 1)
            {
                if (MessageBox.Show("Kỳ Quyết Toán Này đã Chốt Biên Lai, bạn có muốn chốt lại!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            else if (CheckKyChotBienLai == 2)
            {
                MessageBox.Show("Kỳ Quyết Toán Này đã In Biên Lai, không thể chốt lại!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            //Xu Ly Phia Duoi
            DateTime ngaychotOut=DateTime.MinValue;
            if (dtmp_NgayChotBienLai.Value == null || DateTime.TryParse(dtmp_NgayChotBienLai.Value.ToString(), out ngaychotOut) == false)
            {
                MessageBox.Show("Chọn ngày chốt Biên Lai Nhân viên tự quyết toán!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuyetToanThueTNCN_TheoThangList dStuQuyetToan = QuyetToanThueTNCN_TheoThangList.NewQuyetToanThueTNCN_TheoThangList();
            foreach (QuyetToanThueTNCN_TheoThang itemQT in _data)
            {
                if (itemQT.TuQuyetToan==false 
                    //&& itemQT.TongTienThue > 0 
                    && itemQT.DaNop>0)
                {
                    dStuQuyetToan.Add(itemQT);
                }
            }
            if (dStuQuyetToan.Count > 0)
            {
                InBienLaiNhanVienTuQuyetToanRootList _bienLaiNhanVientuQTList = InBienLaiNhanVienTuQuyetToanRootList.NewInBienLaiNhanVienTuQuyetToanRootList();
                foreach (QuyetToanThueTNCN_TheoThang qt in dStuQuyetToan)
                {
                    InBienLaiNhanVienTuQuyetToan bl = InBienLaiNhanVienTuQuyetToan.NewInBienLaiNhanVienTuQuyetToanChild();

                    bl.MaNhanVien = qt.MaNhanVien;
                    bl.MaKyQuyetToan = qt.MaKyQuyetToan;
                    bl.Nam = qt.Nam;
                    bl.Thang = qt.Thang;
                    bl.MaBoPhan = 0;
                    bl.TenNhanVien = qt.TenNhanVien;
                    bl.Mst = qt.MST;
                    bl.Cmnd = qt.CMND;
                    bl.SoTien = qt.TongThuNhapChiuThue;
                    bl.TienThue = qt.DaNop;
                    bl.SoTienConLai = qt.TongThuNhapChiuThue - qt.DaNop;
                    bl.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                    bl.Quyen = string.Empty;
                    bl.KyHieu = string.Empty;
                    bl.So = string.Empty;
                    bl.Stt = 0;
                    bl.TinhTrangIn = false;

                    bl.TenBoPhan = qt.TenBoPhan;
                    bl.NgayLap = ngaychotOut;
                    _bienLaiNhanVientuQTList.Add(bl);
                }
                try
                {
                    _bienLaiNhanVientuQTList.ApplyEdit();
                    _bienLaiNhanVientuQTList.Save();
                    MessageBox.Show("Chốt biên lai thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Chốt biên lai không thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}

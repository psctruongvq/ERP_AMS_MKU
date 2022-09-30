using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmChonHoaDonBaoCao_ThueGTGTMuaVao : Form
    {
        #region Properties
        private int _maKy = 0;
        private DSHoaDonDichVu_BaoCaoList _listThue;
        #endregion

        #region Loads
        public frmChonHoaDonBaoCao_ThueGTGTMuaVao()
        {
            InitializeComponent();
            Load_Form();
        }

        public frmChonHoaDonBaoCao_ThueGTGTMuaVao(int MaKy)
        {
            InitializeComponent();
            _maKy = MaKy;
            Load_Form();
        }
        #endregion


        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Process
        private void Load_Form()
        {
            Utils.GridUtils.SetSTTForGridView(gridViewHoaDon, 50);

            kyListBindingSource.DataSource = KyList.GetKyList();
            HamDungChung.InitGridLookUpDev2(cboKy, kyListBindingSource, "TenKy", "MaKy", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(cboKy, new string[] { "TenKy", "NgayBatDau", "NgayKetThuc" }, new string[] { "Kỳ", "Ngày bắt đầu", "Ngày kết thúc" }, new int[] { 100, 100, 100 }, false);

            HamDungChung.InitGridLookUpDev2(cboTuKy, kyListBindingSource, "TenKy", "MaKy", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(cboTuKy, new string[] { "TenKy", "NgayBatDau", "NgayKetThuc" }, new string[] { "Kỳ", "Ngày bắt đầu", "Ngày kết thúc" }, new int[] { 100, 100, 100 }, false);

            HamDungChung.InitGridLookUpDev2(cboDenKy, kyListBindingSource, "TenKy", "MaKy", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(cboDenKy, new string[] { "TenKy", "NgayBatDau", "NgayKetThuc" }, new string[] { "Kỳ", "Ngày bắt đầu", "Ngày kết thúc" }, new int[] { 100, 100, 100 }, false);
        }

        #endregion

        private void tlslblXuatExcel_Click(object sender, EventArgs e)
        {
            //HamDungChung.ExportToExcel(grdu_DSThueGTGTMua);

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridHoaDon.ExportToXls(dlg.FileName);
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        private void btnXemDuLieu_Click(object sender, EventArgs e)
        {
            if (radXemTheoKy.Checked == true)
            {
                XemTheoKy();
            }
            else
            {
                XemTheoTuKyDenKy();
            }
        }

        private void XemTheoKy()
        {
            if (cboKy.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ báo cáo!");
                return;
            }
            _maKy = (int)cboKy.EditValue;
            _listThue = DSHoaDonDichVu_BaoCaoList.GetList_ChonBaoCao_HoaDonMuaVao(_maKy);
            Thue01_2GTGT_bindingSource.DataSource = _listThue;

            KhoaSo_User obj = KhoaSo_User.GetKhoaSo_User_ByMaKyUserID(_maKy, ERP_Library.Security.CurrentUser.Info.UserID);
            if (obj != null)
            {
                if (obj.KhoaSoThue == true)
                {
                    btnLuu.Enabled = false;
                    gridViewHoaDon.OptionsBehavior.ReadOnly = true;
                }
                else
                {
                    btnLuu.Enabled = true;
                    gridViewHoaDon.OptionsBehavior.ReadOnly = false;
                }
            }
            else
            {
                btnLuu.Enabled = true;
                gridViewHoaDon.OptionsBehavior.ReadOnly = false;
            }
        }

        private void XemTheoTuKyDenKy()
        {
            if (cboTuKy.EditValue == null || cboDenKy.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ báo cáo!");
                return;
            }
            int tuKy = (int)cboTuKy.EditValue;
            int denKy = (int)cboDenKy.EditValue;
            
            _listThue = DSHoaDonDichVu_BaoCaoList.GetList_ChonBaoCao_HoaDonMuaVao_TuKy_DenKy(tuKy,denKy);
            Thue01_2GTGT_bindingSource.DataSource = _listThue;
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                btnXemDuLieu.Focus();
                tlsMain.Focus();
                //xoa du lieu va luu lai
                if (cboKy.EditValue == null)
                {
                    MessageBox.Show("Vui lòng chọn kỳ báo cáo!");
                    return;
                }
                if (_listThue == null || _listThue.Count == 0)
                    return;

                _maKy = (int)cboKy.EditValue;
                DSHoaDonDichVu_BaoCaoList.Delete_Insert_tblDSHoaDonDichVu(_maKy, 1, _listThue);

                MessageBox.Show("Cập nhật dữ liệu thành công!");
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void gridViewHoaDon_DoubleClick(object sender, EventArgs e)
        {
            if (gridViewHoaDon.GetFocusedRow() != null)
            {
                //DataRowView drv = (DataRowView)gridViewHoaDon.GetFocusedRow();
                DSHoaDonDichVu_BaoCao obj = (DSHoaDonDichVu_BaoCao)Thue01_2GTGT_bindingSource.Current;

                HoaDon objHoaDon = HoaDon.GetHoaDon(obj.mahoadon);

                frmHoaDonDichVuMuaVao _frmHoaDonDichVu = new frmHoaDonDichVuMuaVao(objHoaDon);
                _frmHoaDonDichVu.WindowState = FormWindowState.Maximized;
                _frmHoaDonDichVu.Show();
            }
            
        }

        
        private void gridViewHoaDon_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //show form chung tu khi click vao so chung tu
            if (gridViewHoaDon.GetFocusedRow() != null)
            {
                if (e.Column.Name == colGhichu.Name)
                {
                    DSHoaDonDichVu_BaoCao obj = (DSHoaDonDichVu_BaoCao)Thue01_2GTGT_bindingSource.Current;
                    int maLoaiChungTu = obj.MaLoaiChungTu;
                    long maChungTu = obj.MaChungTu;
                    HoaDon objHoaDon = HoaDon.GetHoaDon(obj.mahoadon);

                    switch (maLoaiChungTu)
                    {
                        case 2:
                            //PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu,isShowFromReport);
                            PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu);
                            //frm.maChungTuOfReport = maChungTu;
                            //frm.isShowFromReport = isShowFromReport;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.strStatus = "KHOA";
                            frm.ShowDialog();
                            break;

                        case 3:
                            PSC_ERP.FrmChungTuChiTienMat frm3 = new PSC_ERP.FrmChungTuChiTienMat(maChungTu);
                            frm3.WindowState = FormWindowState.Maximized;
                            frm3.strStatus = "KHOA";
                            frm3.ShowDialog();
                            break;

                        case 4:
                            PSC_ERP.frmPhieuNhapVatTuHangHoa_New frm4 = new PSC_ERP.frmPhieuNhapVatTuHangHoa_New(maChungTu);
                            frm4.WindowState = FormWindowState.Maximized;
                            //frm4.strStatus = "KHOA";
                            frm4.ShowDialog();
                            break;

                        case 5:
                            PSC_ERP.FrmPhieuXuatVatTuHangHoa_New frm5 = new PSC_ERP.FrmPhieuXuatVatTuHangHoa_New(maChungTu, 1);
                            frm5.WindowState = FormWindowState.Maximized;
                            frm5.ShowDialog();
                            break;

                        case 6:
                            PSC_ERP.FrmChungTuThuTienGui frm6 = new PSC_ERP.FrmChungTuThuTienGui(maChungTu);
                            frm6.WindowState = FormWindowState.Maximized;
                            frm6.strStatus = "KHOA";
                            frm6.ShowDialog();
                            break;

                        case 7:
                            PSC_ERP.FrmChungTuChiTienGui frm7 = new PSC_ERP.FrmChungTuChiTienGui(maChungTu);
                            frm7.WindowState = FormWindowState.Maximized;
                            frm7.strStatus = "KHOA";
                            frm7.ShowDialog();
                            break;

                        case 8:
                            PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD frm8 = new PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD(maChungTu);
                            frm8.WindowState = FormWindowState.Maximized;
                            frm8.strStatus = "KHOA";
                            frm8.ShowDialog();
                            break;

                        case 9:
                            PSC_ERP.FrmChungTuMuaChuaThanhToan frm9 = new PSC_ERP.FrmChungTuMuaChuaThanhToan(maChungTu);
                            frm9.WindowState = FormWindowState.Maximized;
                            frm9.strStatus = "KHOA";
                            frm9.ShowDialog();
                            break;

                        case 10:
                            PSC_ERP.FrmChungTuGiayNhanNo frm10 = new PSC_ERP.FrmChungTuGiayNhanNo(maChungTu);
                            frm10.WindowState = FormWindowState.Maximized;
                            frm10.strStatus = "KHOA";
                            frm10.ShowDialog();
                            break;

                        case 14:
                            PSC_ERP.FrmChungTuChuyenTienNoiBo frm14 = new PSC_ERP.FrmChungTuChuyenTienNoiBo(maChungTu);
                            frm14.WindowState = FormWindowState.Maximized;
                            frm14.strStatus = "KHOA";
                            frm14.ShowDialog();
                            break;

                        case 16:
                            PSC_ERP.FrmChungTuKeToanCustomize frm16 = new PSC_ERP.FrmChungTuKeToanCustomize(maChungTu);
                            frm16.WindowState = FormWindowState.Maximized;
                            frm16.strStatus = "KHOA";
                            frm16.ShowDialog();
                            break;

                        case 22:
                            PSC_ERP.FrmChungTuPhiNganHang frm22 = new PSC_ERP.FrmChungTuPhiNganHang(maChungTu);
                            frm22.WindowState = FormWindowState.Maximized;
                            frm22.strStatus = "KHOA";
                            frm22.ShowDialog();
                            break;

                        case 23:
                            PSC_ERP.FrmChungTuMuaNgoaiTe frm23 = new PSC_ERP.FrmChungTuMuaNgoaiTe(maChungTu);
                            frm23.WindowState = FormWindowState.Maximized;
                            frm23.strStatus = "KHOA";
                            frm23.ShowDialog();
                            break;

                        case 24:
                            PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai frm24 = new PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai(maChungTu);
                            frm24.WindowState = FormWindowState.Maximized;
                            frm24.strStatus = "KHOA";
                            frm24.ShowDialog();
                            break;

                        case 25:
                            PSC_ERP.FrmChungTuGiayRutTienMat frm25 = new PSC_ERP.FrmChungTuGiayRutTienMat(maChungTu);
                            frm25.WindowState = FormWindowState.Maximized;
                            frm25.strStatus = "KHOA";
                            frm25.ShowDialog();
                            break;


                        default:
                            MessageBox.Show("Không tìm thấy form chứng từ ");
                            break;
                    }
 	
                }

            }
        }

        private void gridHoaDon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void radXemTheoKy_CheckedChanged(object sender, EventArgs e)
        {
            if (radXemTheoKy.Checked == true)
            {
                btnLuu.Enabled = true;
            }
            else
            {
                btnLuu.Enabled = false;
            }
        }

        private void gridHoaDon_DoubleClick(object sender, EventArgs e)
        {
            if (gridViewHoaDon.GetFocusedRow() != null)
            {
                if ("" == colGhichu.Name)
                {
                    DSHoaDonDichVu_BaoCao obj = (DSHoaDonDichVu_BaoCao)Thue01_2GTGT_bindingSource.Current;
                    int maLoaiChungTu = obj.MaLoaiChungTu;
                    long maChungTu = obj.MaChungTu;
                    HoaDon objHoaDon = HoaDon.GetHoaDon(obj.mahoadon);

                    switch (maLoaiChungTu)
                    {
                        case 2:
                            //PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu,isShowFromReport);
                            PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu);
                            //frm.maChungTuOfReport = maChungTu;
                            //frm.isShowFromReport = isShowFromReport;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.strStatus = "KHOA";
                            frm.ShowDialog();
                            break;

                        case 3:
                            PSC_ERP.FrmChungTuChiTienMat frm3 = new PSC_ERP.FrmChungTuChiTienMat(maChungTu);
                            frm3.WindowState = FormWindowState.Maximized;
                            frm3.strStatus = "KHOA";
                            frm3.ShowDialog();
                            break;

                        case 4:
                            PSC_ERP.frmPhieuNhapVatTuHangHoa_New frm4 = new PSC_ERP.frmPhieuNhapVatTuHangHoa_New(maChungTu);
                            frm4.WindowState = FormWindowState.Maximized;
                            //frm4.strStatus = "KHOA";
                            frm4.ShowDialog();
                            break;

                        case 5:
                            PSC_ERP.FrmPhieuXuatVatTuHangHoa_New frm5 = new PSC_ERP.FrmPhieuXuatVatTuHangHoa_New(maChungTu, 1);
                            frm5.WindowState = FormWindowState.Maximized;
                            frm5.ShowDialog();
                            break;

                        case 6:
                            PSC_ERP.FrmChungTuThuTienGui frm6 = new PSC_ERP.FrmChungTuThuTienGui(maChungTu);
                            frm6.WindowState = FormWindowState.Maximized;
                            frm6.strStatus = "KHOA";
                            frm6.ShowDialog();
                            break;

                        case 7:
                            PSC_ERP.FrmChungTuChiTienGui frm7 = new PSC_ERP.FrmChungTuChiTienGui(maChungTu);
                            frm7.WindowState = FormWindowState.Maximized;
                            frm7.strStatus = "KHOA";
                            frm7.ShowDialog();
                            break;

                        case 8:
                            PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD frm8 = new PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD(maChungTu);
                            frm8.WindowState = FormWindowState.Maximized;
                            frm8.strStatus = "KHOA";
                            frm8.ShowDialog();
                            break;

                        case 9:
                            PSC_ERP.FrmChungTuMuaChuaThanhToan frm9 = new PSC_ERP.FrmChungTuMuaChuaThanhToan(maChungTu);
                            frm9.WindowState = FormWindowState.Maximized;
                            frm9.strStatus = "KHOA";
                            frm9.ShowDialog();
                            break;

                        case 10:
                            PSC_ERP.FrmChungTuGiayNhanNo frm10 = new PSC_ERP.FrmChungTuGiayNhanNo(maChungTu);
                            frm10.WindowState = FormWindowState.Maximized;
                            frm10.strStatus = "KHOA";
                            frm10.ShowDialog();
                            break;

                        case 14:
                            PSC_ERP.FrmChungTuChuyenTienNoiBo frm14 = new PSC_ERP.FrmChungTuChuyenTienNoiBo(maChungTu);
                            frm14.WindowState = FormWindowState.Maximized;
                            frm14.strStatus = "KHOA";
                            frm14.ShowDialog();
                            break;

                        case 16:
                            PSC_ERP.FrmChungTuKeToanCustomize frm16 = new PSC_ERP.FrmChungTuKeToanCustomize(maChungTu);
                            frm16.WindowState = FormWindowState.Maximized;
                            frm16.strStatus = "KHOA";
                            frm16.ShowDialog();
                            break;

                        case 22:
                            PSC_ERP.FrmChungTuPhiNganHang frm22 = new PSC_ERP.FrmChungTuPhiNganHang(maChungTu);
                            frm22.WindowState = FormWindowState.Maximized;
                            frm22.strStatus = "KHOA";
                            frm22.ShowDialog();
                            break;

                        case 23:
                            PSC_ERP.FrmChungTuMuaNgoaiTe frm23 = new PSC_ERP.FrmChungTuMuaNgoaiTe(maChungTu);
                            frm23.WindowState = FormWindowState.Maximized;
                            frm23.strStatus = "KHOA";
                            frm23.ShowDialog();
                            break;

                        case 24:
                            PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai frm24 = new PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai(maChungTu);
                            frm24.WindowState = FormWindowState.Maximized;
                            frm24.strStatus = "KHOA";
                            frm24.ShowDialog();
                            break;

                        case 25:
                            PSC_ERP.FrmChungTuGiayRutTienMat frm25 = new PSC_ERP.FrmChungTuGiayRutTienMat(maChungTu);
                            frm25.WindowState = FormWindowState.Maximized;
                            frm25.strStatus = "KHOA";
                            frm25.ShowDialog();
                            break;

	

                        default:
                            MessageBox.Show("Không tìm thấy form chứng từ ");
                            break;
                    }

                }

            }
        }

        private void itemGhiChu_DoubleClick(object sender, EventArgs e)
        {
            DSHoaDonDichVu_BaoCao obj = (DSHoaDonDichVu_BaoCao)Thue01_2GTGT_bindingSource.Current;
            int maLoaiChungTu = obj.MaLoaiChungTu;
            long maChungTu = obj.MaChungTu;
            int loaiNhapXuat = obj.LoaiNhapXuat;
            HoaDon objHoaDon = HoaDon.GetHoaDon(obj.mahoadon);

            switch (maLoaiChungTu)
            {
                case 2:
                    //PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu,isShowFromReport);
                    PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu);
                    //frm.maChungTuOfReport = maChungTu;
                    //frm.isShowFromReport = isShowFromReport;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                    break;

                case 3:
                    PSC_ERP.FrmChungTuChiTienMat frm3 = new PSC_ERP.FrmChungTuChiTienMat(maChungTu);
                    frm3.WindowState = FormWindowState.Maximized;
                    frm3.ShowDialog();
                    break;

                case 4:
                    if (loaiNhapXuat == 2)
                    {
                        PSC_ERP.frmPhieuNhapVatTuHangHoa_New frm4 = new PSC_ERP.frmPhieuNhapVatTuHangHoa_New(maChungTu);
                        frm4.WindowState = FormWindowState.Maximized;
                        frm4.ShowDialog();
                    }
                    else if (loaiNhapXuat == 3)
                    {
                        PSC_ERP.frmPhieuNhapCongCuDungCu_Update frm4 = new PSC_ERP.frmPhieuNhapCongCuDungCu_Update(maChungTu);
                        frm4.WindowState = FormWindowState.Maximized;
                        frm4.ShowDialog();
                    }
                    break;

                case 5:
                    if (loaiNhapXuat == 2)
                    {
                        PSC_ERP.FrmPhieuXuatVatTuHangHoa_New frm5 = new PSC_ERP.FrmPhieuXuatVatTuHangHoa_New(maChungTu, 1);
                        frm5.WindowState = FormWindowState.Maximized;
                        frm5.ShowDialog();
                    }
                    else if (loaiNhapXuat == 3)
                    {
                        PSC_ERP.frmPhieuXuatPhanBoCCDC_Update frm5 = new PSC_ERP.frmPhieuXuatPhanBoCCDC_Update(maChungTu);
                        frm5.WindowState = FormWindowState.Maximized;
                        frm5.ShowDialog();
                    }
                    break;

                case 6:
                    PSC_ERP.FrmChungTuThuTienGui frm6 = new PSC_ERP.FrmChungTuThuTienGui(maChungTu);
                    frm6.WindowState = FormWindowState.Maximized;
                    frm6.ShowDialog();
                    break;

                case 7:
                    PSC_ERP.FrmChungTuChiTienGui frm7 = new PSC_ERP.FrmChungTuChiTienGui(maChungTu);
                    frm7.WindowState = FormWindowState.Maximized;
                    frm7.ShowDialog();
                    break;

                case 8:
                    PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD frm8 = new PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD(maChungTu);
                    frm8.WindowState = FormWindowState.Maximized;
                    frm8.ShowDialog();
                    break;

                case 9:
                    PSC_ERP.FrmChungTuMuaChuaThanhToan frm9 = new PSC_ERP.FrmChungTuMuaChuaThanhToan(maChungTu);
                    frm9.WindowState = FormWindowState.Maximized;
                    frm9.ShowDialog();
                    break;

                case 10:
                    PSC_ERP.FrmChungTuGiayNhanNo frm10 = new PSC_ERP.FrmChungTuGiayNhanNo(maChungTu);
                    frm10.WindowState = FormWindowState.Maximized;
                    frm10.ShowDialog();
                    break;

                case 14:
                    PSC_ERP.FrmChungTuChuyenTienNoiBo frm14 = new PSC_ERP.FrmChungTuChuyenTienNoiBo(maChungTu);
                    frm14.WindowState = FormWindowState.Maximized;
                    frm14.ShowDialog();
                    break;

                case 16:
                    PSC_ERP.FrmChungTuKeToanCustomize frm16 = new PSC_ERP.FrmChungTuKeToanCustomize(maChungTu);
                    frm16.WindowState = FormWindowState.Maximized;
                    frm16.ShowDialog();
                    break;

                case 17:	//ghi tang tscd
                    PSC_ERPNew.Main.frmGhiTangTSCDCaBiet frm17 = new PSC_ERPNew.Main.frmGhiTangTSCDCaBiet(maChungTu);
                    frm17.WindowState = FormWindowState.Maximized;
                    frm17.ShowDialog();
                    break;

                case 22:
                    PSC_ERP.FrmChungTuPhiNganHang frm22 = new PSC_ERP.FrmChungTuPhiNganHang(maChungTu);
                    frm22.WindowState = FormWindowState.Maximized;
                    frm22.ShowDialog();
                    break;

                case 23:
                    PSC_ERP.FrmChungTuMuaNgoaiTe frm23 = new PSC_ERP.FrmChungTuMuaNgoaiTe(maChungTu);
                    frm23.WindowState = FormWindowState.Maximized;
                    frm23.ShowDialog();
                    break;

                case 24:
                    PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai frm24 = new PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai(maChungTu);
                    frm24.WindowState = FormWindowState.Maximized;
                    frm24.ShowDialog();
                    break;

                case 25:
                    PSC_ERP.FrmChungTuGiayRutTienMat frm25 = new PSC_ERP.FrmChungTuGiayRutTienMat(maChungTu);
                    frm25.WindowState = FormWindowState.Maximized;
                    frm25.ShowDialog();
                    break;


                default:
                    MessageBox.Show("Không tìm thấy Form chứng từ");
                    break;
            }
        }
      
        #region Events
        #endregion


    }
}

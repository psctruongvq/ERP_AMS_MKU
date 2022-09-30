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
    public partial class frmQuyetToanThueTNCNCuoiNam : Form
    {
        #region Properties
        int Thang = 0;
        int Nam = 0;
        QuyetToanThueTNCN_TheoThangList _data;
        #endregion

        #region Load
        public frmQuyetToanThueTNCNCuoiNam()
        {
            InitializeComponent();
            Load_Form();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdData.DisplayLayout.Bands[0],
                new string[17] { "TenNhanVien", "CMND", "MST", "BHXH", "BHYT", "BHTN", "BHBatBuoc", "TenBoPhan", "TongThuNhap", "TongThuNhapChiuThue", "TongGiamTru", "TongTienThue", "DaNop", "ConPhaiNop_SuDung", "TNCNDongBoSung", "DaNopBoSung", "TinhTrang" },
                new string[17] { "Tên nhân viên", "CMND", "MST", "BHXH", "BHYT", "BHTN", "BH Bắt buộc", "Bộ phận", "Tổng thu nhập", "Tổng thu nhập chịu thuế", "Tổng tiền giảm trừ", "Tiền thuế", "Đã nộp", "Còn phải nộp", "Bổ sung", "Đã nộp bổ sung", "Tình trạng" },
                new int[17] { 150, 150, 130, 130, 130, 130, 130, 130, 130, 80, 130, 130, 130, 130, 130, 130, 130 },
                new Control[17] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                new KieuDuLieu[17] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Tien, KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[17] { false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, false, false });
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
            _data = QuyetToanThueTNCN_TheoThangList.GetQuyetToanThueTNCNCuoiNamList(Thang, Nam);
            bdDanhSach.DataSource = _data;
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
                    _data = QuyetToanThueTNCN_TheoThangList.GetQuyetToanThueTNCNCuoiNamList(Thang, Nam);
                    bdDanhSach.DataSource = _data;
                }
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
                QuyetToanThueTNCN_TheoThang.XuLyQuyetToanThueTNCNCuoiNam(Thang, Nam);
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

                foreach (QuyetToanThueTNCN_TheoThang item in _data)
                {
                    if (!item.DaNopBoSung & item.TNCNDongBoSung != 0)
                    {
                        item.DaNop += item.TNCNDongBoSung;
                        item.DaNopBoSung = true;
                        //item.ConPhaiNop_SuDung = item.TongTienThue - item.DaNop;
                    }
                }

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
    }
}

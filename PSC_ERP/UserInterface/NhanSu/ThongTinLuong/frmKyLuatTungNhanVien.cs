using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;


namespace PSC_ERP
{    
    public partial class frmKyLuatTungNhanVien : Form
    {
        #region Khai Báo Biến
        ThongTinNhanVienTongHopList _nhanVienList;
        KyLuatTheoNhanVienList _KyLuatTheoNhanVienList;
        KyLuatTheoNhanVien _KyLuatTheoNhanVien;
        HinhThucKyLuatList _HinhThucKyLuatList;
        CapQuyetDinhList _CapQuyetDinhList;
        Util util = new Util();
        ChucVuList _ChucVuList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        long maNhanVien = 0;
        #endregion

        #region Events
        public frmKyLuatTungNhanVien()
        {
            InitializeComponent();
            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblXoa.Enabled = false;
            tlslblIn.Enabled = false;
            tlslblUndo.Enabled = false;
            this.CapQuyetDinh_bindingSource.DataSource = CapQuyetDinhList.GetCapQuyetDinhList();
        }

        public frmKyLuatTungNhanVien(ThongTinNhanVienTongHop obj)
        {
            _ThongTinNhanVienTongHop = obj;

            InitializeComponent();
        }

        public frmKyLuatTungNhanVien(long MaNhanVien)
        {
            InitializeComponent();
            Load_Form(MaNhanVien);
        }
        
        private void Load_Form(long MaNhanVien)
        {
            _KyLuatTheoNhanVienList = KyLuatTheoNhanVienList.GetKyLuatTheoNhanVienList(MaNhanVien);
            DanhSachKyLuat_bindingSource.DataSource = _KyLuatTheoNhanVienList;

            _ChucVuList = ChucVuList.GetChucVuList();
            chucVuListBindingSource.DataSource = _ChucVuList;

            txtu_MaNhanVienQL.Text = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien).MaQLNhanVien;
            txtu_TenNhanVien.Text = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien).TenNhanVien;
            txtu_MaNhanVien.Text = MaNhanVien.ToString();

            tlslblThem.Enabled = true;
            tlslblLuu.Enabled = true;
            tlslblXoa.Enabled = true;
            tlslblIn.Enabled = true;
            tlslblUndo.Enabled = true;
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 0; i < grdu_ThongTinKyLuat.Rows.Count; i++)
            {
                if (grdu_ThongTinKyLuat.Rows[i].Cells["SoQuyetDinh"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Nhập Số Quyết Định", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_ThongTinKyLuat.ActiveRow = grdu_ThongTinKyLuat.Rows[i];
                    return kq;
                }
               
                if (grdu_ThongTinKyLuat.Rows[i].Cells["MaHinhThucKyLuat"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Hình Thức Kỷ Luật", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_ThongTinKyLuat.ActiveRow = grdu_ThongTinKyLuat.Rows[i];
                    return kq;
                }
                if (grdu_ThongTinKyLuat.Rows[i].Cells["NguoiKy"].Text == "0")
                {
                    kq = false;
                    MessageBox.Show(this, "Nhập Người Ký Quyết Định", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_ThongTinKyLuat.ActiveRow = grdu_ThongTinKyLuat.Rows[i];
                    return kq;
                }
            }
            return kq;
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _KyLuatTheoNhanVienList.Count; i++)
            {
                for (int j = 0; j < _KyLuatTheoNhanVienList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_KyLuatTheoNhanVienList[i].SoQuyetDinh.Trim() == _KyLuatTheoNhanVienList[j].SoQuyetDinh.Trim())
                        {
                            KyLuatTheoNhanVien qg = KyLuatTheoNhanVien.GetKyLuatTheoNhanVien(_KyLuatTheoNhanVienList[i].MaHinhThucKyLuat,_KyLuatTheoNhanVienList[i].SoQuyetDinh);
                            MessageBox.Show(this, "Số Quyết Định " + qg.SoQuyetDinh.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_ThongTinKyLuat.ActiveRow = grdu_ThongTinKyLuat.Rows[i + 1];
                            grdu_ThongTinKyLuat.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _KyLuatTheoNhanVien = KyLuatTheoNhanVien.NewKyLuatTheoNhanVien(maNhanVien);
            _KyLuatTheoNhanVienList.Add(_KyLuatTheoNhanVien);
            DanhSachKyLuat_bindingSource.DataSource = _KyLuatTheoNhanVienList;
            grdu_ThongTinKyLuat.ActiveRow = grdu_ThongTinKyLuat.Rows[_KyLuatTheoNhanVienList.Count - 1];
        }

        private void grdu_ThongTinKyLuat_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            _HinhThucKyLuatList = HinhThucKyLuatList.GetHinhThucKyLuatList();
            HinhThucKyLuat_bindingSource.DataSource = _HinhThucKyLuatList;

           

            #region Header Lưới
            grdu_ThongTinKyLuat.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["MaHinhThucKyLuat"].Hidden = true;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["MaKyLuat"].Hidden = true;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["NgayLapQuyetDinh"].Hidden = true;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["MaCapQuyetDinh"].Hidden = true;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = true;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TenCapQuyetDinh"].Hidden = true;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TenHinhThucKyLuat"].Header.Caption = "Hình Thức Khen Thưởng";
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TenCapQuyetDinh"].Header.Caption = "Cấp Quyết Định";
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Header.Caption = "Ngày Cấp";
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TGBDKyLuat"].Header.Caption = "TG Bắt Đầu KL";
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TGKTKyLuat"].Header.Caption = "TG Kết Thúc KL";
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["NguoiKy"].Header.Caption = "Người Ký QĐ";
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["GiamLuongDenHan"].Header.Caption = "Giảm Lương (Tháng)";
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 150;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;

            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TenHinhThucKyLuat"].Header.VisiblePosition = 1;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TenCapQuyetDinh"].Header.VisiblePosition = 2;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 3;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Header.VisiblePosition = 4;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TGBDKyLuat"].Header.VisiblePosition = 5;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["TGKTKyLuat"].Header.VisiblePosition = 6;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["NguoiKy"].Header.VisiblePosition = 7;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["GiamLuongDenHan"].Header.VisiblePosition = 8;
            grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 9;
            foreach (UltraGridColumn col in grdu_ThongTinKyLuat.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
            this.grdu_ThongTinKyLuat.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_ThongTinKyLuat.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            #endregion
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Form(maNhanVien);
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_ThongTinKyLuat.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdu_ThongTinKyLuat.DeleteSelectedRows();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmTimNhanVien newForm = new frmTimNhanVien(11);
            if (newForm.ShowDialog(this) != DialogResult.OK)
            {
                maNhanVien = frmTimNhanVien.MaNhanVien;
                
                    this.Load_Form(maNhanVien);
                
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (KiemTra_Luoi() == true)
                {
                    if (KiemTraMaQuanLy() == true)
                    {
                        _KyLuatTheoNhanVienList.ApplyEdit();
                        _KyLuatTheoNhanVienList.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
        }

        private void txtu_SoQuyetDinh_Leave(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in grdu_ThongTinKyLuat.Rows)
            {
                if (row.Cells["SoQuyetDinh"].Value.ToString().ToUpper() == txtu_SoQuyetDinh.Text.ToUpper())
                {
                    MessageBox.Show("Quyết Định Này Không Hợp Lệ !", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtu_SoQuyetDinh.Focus();
                    return;                    
                }
            }
        }
        #endregion

        private void cmbu_NguoiKy_ValueChanged(object sender, EventArgs e)
        {
            
        }

    
    }
}
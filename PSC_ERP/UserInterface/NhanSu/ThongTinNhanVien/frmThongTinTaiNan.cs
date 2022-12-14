using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmThongTinTaiNan : Form
    {
        Util util = new Util();
        ThongTinTaiNan _ThongTinTaiNan=ThongTinTaiNan.NewThongTinTaiNan();
        ThongTinNguoiBiTaiNanList _ThongTinNguoiBiTaiNanList=ThongTinNguoiBiTaiNanList.NewThongTinNguoiBiTaiNanList();
        ThongTinNhanVienTongHopList _NhanVien = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
        LoaiTaiNanList _LoaiTaiNanList;
        NguyenNhanTaiNanList _NguyenNhanTaiNanList;
        BoPhanList _BoPhanList = BoPhanList.NewBoPhanList();
        int matainan=0;
        public frmThongTinTaiNan()
        {                        
            InitializeComponent();
            this.Load_Source();
        }      
        #region Load 

        private void Load_Source()
        {
            _LoaiTaiNanList = LoaiTaiNanList.GetLoaiTaiNanList();
            BindS_LoaiTaiNan.DataSource = _LoaiTaiNanList;

            _NguyenNhanTaiNanList = NguyenNhanTaiNanList.GetNguyenNhanTaiNanList();
            BindS_NguyenNhan.DataSource = _NguyenNhanTaiNanList;

            _BoPhanList = BoPhanList.GetBoPhanList();
            BindS_BoPhan.DataSource = _BoPhanList;
            if (matainan.Equals(0))
            {
                _ThongTinTaiNan = ThongTinTaiNan.NewThongTinTaiNan();
                BindS_TTTaiNan.DataSource=_ThongTinTaiNan;                
            }
            else
            {
                _ThongTinTaiNan = ThongTinTaiNan.GetThongTinTaiNan(matainan);
                BindS_TTTaiNan.DataSource=_ThongTinTaiNan;                  
            }
            lblTSo.Text = "Tổng Số : " + _ThongTinTaiNan.ThongTinNguoiBiTainanList.Count;
        }

        private void cmbu_BoPhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_BoPhan.DisplayLayout.Bands[0],
            new string[2] { "Tenbophan", "mabophan" },
            new string[2] { "Bộ Phận", "Mã bộ phận" },
            new int[2] { cmbu_BoPhan.Width, 90 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["Tenbophan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_BoPhan.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;
        }

        private void grdu_NguoiBiTainan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_MaNhanVien.Visible = false;
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["MaThongTinNguoiBiTaiNan"].Hidden = true;
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["MaTaiNan"].Hidden = true;
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["maQLNhanVien"].Hidden = true;

            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["maNhanVien"].Header.Caption = "Mã Số";
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["maNhanVien"].EditorComponent = cmbu_MaNhanVien;

            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Họ và Tên";
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["MucDo"].Header.Caption = "Mức Độ";
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["SoNgayNghi"].Header.Caption = "Số Ngày Nghỉ";
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["ChiPhi"].Header.Caption = "Chi Phí";
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["TinhTrangThuongTat"].Header.Caption = "Tình Trạng Thương Tật";
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["NoiVaPPDieuTri"].Header.Caption = "Nơi Và PP Điều Trị";
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["SoNgayNghi"].MaskInput = "{LOC}nnn";
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["ChiPhi"].MaskInput = "{LOC}nnn,nnn,nnn,nnn";

            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["Manhanvien"].Header.VisiblePosition = 0;
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["MucDo"].Header.VisiblePosition = 2;
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["SoNgayNghi"].Header.VisiblePosition = 3;
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["ChiPhi"].Header.VisiblePosition = 4;
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["TinhTrangThuongTat"].Header.VisiblePosition = 5;
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["NoiVaPPDieuTri"].Header.VisiblePosition = 6;
            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 7;

            grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellActivation = Activation.NoEdit;

            grdu_NguoiBiTainan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;

            grdu_NguoiBiTainan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_NguoiBiTainan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_NguoiBiTainan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn";
                }

                if (col.DataType.ToString() == "System.Datetime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
        }

        private void cmbu_MaNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_MaNhanVien.DisplayLayout.Bands[0],
            new string[3] { "MaQLNHanvien", "Tennhanvien", "manhanvien" },
            new string[3] { "Mã Số", "Họ Tên", "maso" },
            new int[3] { 100, 170,0 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { false, false, false });
            cmbu_MaNhanVien.DisplayLayout.Bands[0].Columns["MaQLNHanvien"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_MaNhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_MaNhanVien.DisplayLayout.Bands[0].Columns["manhanvien"].Hidden = true;

        }
        #endregion
        
        #region Event
        private void cmbu_MaNhanVien_AfterCloseUp(object sender, EventArgs e)
        {
            if (grdu_NguoiBiTainan.ActiveRow != null)
            {
                if (cmbu_MaNhanVien.ActiveRow != null)
                {
                      grdu_NguoiBiTainan.ActiveRow.Cells["Tennhanvien"].Value = cmbu_MaNhanVien.ActiveRow.Cells["TenNhanVien"].Value;
                }
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            frmThongTinTaiNan_Tim frmtim = new frmThongTinTaiNan_Tim();
            if(frmtim.ShowDialog() !=DialogResult.OK)
            {
                matainan=frmtim._maTaiNan;
                this.Load_Source();
            }            
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _ThongTinTaiNan=ThongTinTaiNan.NewThongTinTaiNan();
            BindS_TTTaiNan.DataSource=_ThongTinTaiNan;
        }   

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (cmbu_LoaiTaiNan.Value.ToString() == "0" || cmbu_NguyenNhan.Value.ToString() == "0")
            {
                return;
            }
            _ThongTinTaiNan.ApplyEdit();
            _ThongTinTaiNan.Save();
            MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
        } 

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_NguoiBiTainan.Selected.Rows.Count > 0)
            {
                grdu_NguoiBiTainan.DeleteSelectedRows();
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
          this.Load_Source();
        }

        private void cmbu_BoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_BoPhan.Value != null)
            {
                _NhanVien = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_Bophan((int)cmbu_BoPhan.Value,0);
                BindS_NhanVien.DataSource = _NhanVien;
            }
        }

        private void grdu_NguoiBiTainan_AfterCellUpdate(object sender, CellEventArgs e)
        {
            int count = 0;
            if (grdu_NguoiBiTainan.ActiveCell == grdu_NguoiBiTainan.ActiveRow.Cells["TennhanVien"])
            {
                foreach (UltraGridRow row in grdu_NguoiBiTainan.Rows)
                {
                    if ((long)row.Cells["MaNhanVien"].Value == (long)cmbu_MaNhanVien.ActiveRow.Cells["MaNhanVien"].Value)
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    MessageBox.Show("Nhân Viên Bị Trùng!", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        #endregion

        #region Process

        #endregion     
    }
}
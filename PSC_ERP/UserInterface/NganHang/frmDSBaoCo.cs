using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using ERP_Library;
using ERP_Library.Security;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmDSBaoCo : Form
    {
        #region Properties
        private GiayBaoCoList _giayBaoCoList;
        private NganHangList _nganHangList;
        private UserList _userList;
        int maChungTu = 0;
        DoiTacList doitacList;
        #endregion

        #region Loads
        public frmDSBaoCo()
        {
            InitializeComponent();
            txtTuNgay.Value = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            LoadData();
        }

        private void cmb_NguoiLap_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_NguoiLap.DisplayLayout.Bands[0],
            new string[3] { "TenNhanVien", "TenDangNhap", "TenBoPhan" },
            new string[3] { "Nhân Viên", "Tên Đăng Nhập", "Bộ Phận" },
            new int[3] { 150, 250, 250 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { false, false, false });

            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_NganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                //col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
        }
        #endregion

        #region Process
        private void LoadData()
        {
            _giayBaoCoList = GiayBaoCoList.GetGiayBaoCoList(txtTuNgay.DateTime, txtDenNgay.DateTime, 0); // Nếu là phí ngân hàng thì truyền là 1 giấy báo có là 0 
            bdGiayBaoCo.DataSource = _giayBaoCoList;

            _userList = UserList.GetUserList_GBC();
            UserItem _userItem = UserItem.NewUserItem("Chưa chọn");
            _userList.Insert(0, _userItem);
            NguoiLapListBindingSouce.DataSource = _userList;

            //doitacList = DoiTacList.GetDoiTacList(" ", false);
            doitacList = DoiTacList.GetDoiTacList(" ", 0);
            DoiTac _doiTac = DoiTac.NewDoiTac(0, "Chưa chọn");
            doitacList.Insert(0, _doiTac);
            DoiTac_bindingSource.DataSource = doitacList;
        }

        private void SaveData()
        {
            try
            {
                _giayBaoCoList.Save();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _giayBaoCoList);
            }
        }

        private void frmDSBaoCo_Load(object sender, EventArgs e)
        {
            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList())
                grd_DSGiayBaoCo.DisplayLayout.ValueLists["NganHang"].ValueListItems.Add(item.MaChiTiet, item.SoTaiKhoan);
            foreach (ERP_Library.DoiTac item in doitacList)
                grd_DSGiayBaoCo.DisplayLayout.ValueLists["DoiTac"].ValueListItems.Add(item.MaDoiTac, item.TenDoiTac);
            foreach (LoaiTien item in LoaiTienList.GetLoaiTienList())
                grd_DSGiayBaoCo.DisplayLayout.ValueLists["LoaiTien"].ValueListItems.Add(item.MaLoaiTien, item.MaLoaiQuanLy);
        }
        #endregion

        #region Event
        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlXoa_Click(object sender, EventArgs e)
        {
            if (grd_DSGiayBaoCo.Selected.Rows.Count <= 0)
            {
                MessageBox.Show(this, "Vui lòng chọn giấy báo có cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grd_DSGiayBaoCo.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {

        }

        private void grdData_AfterRowsDeleted(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            GiayBaoCo item = _giayBaoCoList.AddNew();
            frmGiayBaoCo_Edit f = new frmGiayBaoCo_Edit(false, false);
            item.LoaiGiayBaoCo = 0;
            //item.So = item.SoPhieuMoi();
            if (f.ShowEdit(item))
            {
                SaveData();
            }
            else
            {
                _giayBaoCoList.Remove(item);
            }
        }

        private void tlSua_Click(object sender, EventArgs e)
        {
            if (grd_DSGiayBaoCo.ActiveRow != null && grd_DSGiayBaoCo.ActiveRow.IsDataRow)
            {
                GiayBaoCo item = (GiayBaoCo)grd_DSGiayBaoCo.ActiveRow.ListObject;
                frmGiayBaoCo_Edit f = new frmGiayBaoCo_Edit(false, true);
                item.BeginEdit();
                if (f.ShowEdit(item))
                {
                    item.ApplyEdit();
                    SaveData();
                }
                else
                    item.CancelEdit();
            }
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row.IsDataRow)
                tlSua.PerformClick();
        }

        private void Ngay_Changed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grd_DSGiayBaoCo);
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grd_DSGiayBaoCo.UpdateData();
                bdGiayBaoCo.EndEdit();
                _giayBaoCoList.ApplyEdit();
                _giayBaoCoList.Save();

                MessageBox.Show(this, "Cập nhật thông tin thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void grd_DSGiayBaoCo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (e.Row.IsDataRow)
                tlSua.PerformClick();
        }
        #endregion
    }
}
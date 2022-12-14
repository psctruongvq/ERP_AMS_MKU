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
    public partial class frmGiayBaoCo_CacQuy : Form
    {
        #region Properties
        private GiayBaoCo_CacQuyList _giayBaoCo_CacQuyList;
        private NganHangList _nganHangList;
        private UserList _userList;
        int maChungTu = 0;
        DoiTacList doitacList;
        int _loaiGBC = 0;
        int _loaiDeNghi = 0;
        #endregion

        #region Loads
        private void Create_TieuDe()
        {
            if (_loaiGBC == 0)
                this.Text = "Danh Sách Giấy Báo Có";
            else
                this.Text = "Danh Sách Phí Ngân Hàng";

            if (_loaiDeNghi == 1)
                this.Text += " Các Quỹ";
            else
                this.Text += " Công Đoàn";
        }

        public void ShowGiayBaoCo_CacQuy()
        {
            _loaiGBC = 0; //Giấy báo có
            _loaiDeNghi = 1; // Các Quỹ
            Create_TieuDe();
            
            this.Show();
        }

        public void ShowPhiNganHang_CacQuy()
        {
            _loaiGBC = 1; //Phí ngân hàng
            _loaiDeNghi = 1; // Các Quỹ
            Create_TieuDe();
            
            this.Show();
        }

        public void ShowGiayBaoCo_CongDoan()
        {
            _loaiGBC = 0; //Giấy báo có
            _loaiDeNghi = 2; // Các Quỹ
            Create_TieuDe();
            
            this.Show();
        }

        public void ShowPhiNganHang_CongDoan()
        {
            _loaiGBC = 1; //Phí ngân hàng
            _loaiDeNghi = 2; // Các Quỹ
            Create_TieuDe();
            
            this.Show();
        }

        public frmGiayBaoCo_CacQuy()
        {
            InitializeComponent();
            txtTuNgay.Value = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
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
            DateTime TuNgay = txtTuNgay.DateTime;
            DateTime DenNgay = txtDenNgay.DateTime;

            _giayBaoCo_CacQuyList = GiayBaoCo_CacQuyList.GetGiayBaoCo_CacQuyList(txtTuNgay.DateTime, txtDenNgay.DateTime, _loaiGBC, _loaiDeNghi); // Nếu là phí ngân hàng thì truyền là 1 giấy báo có là 0 
            bdGiayBaoCo.DataSource = _giayBaoCo_CacQuyList;

            _userList = UserList.GetUserList_GBC();
            UserItem _userItem = UserItem.NewUserItem("Chưa chọn");
            _userList.Insert(0, _userItem);
            NguoiLapListBindingSouce.DataSource = _userList;

            doitacList = DoiTacList.GetDoiTacList("", 0);
            DoiTac _doiTac = DoiTac.NewDoiTac(0, "Chưa chọn");
            doitacList.Insert(0, _doiTac);
            DoiTac_bindingSource.DataSource = doitacList;
        }

        private void SaveData()
        {
            try
            {
                _giayBaoCo_CacQuyList.Save();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _giayBaoCo_CacQuyList);
            }
        }

        private void frmDSBaoCo_Load(object sender, EventArgs e)
        {
            //foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList())
            //    grd_DSGiayBaoCo.DisplayLayout.ValueLists["NganHang"].ValueListItems.Add(item.MaChiTiet, item.SoTaiKhoan);
            //foreach (ERP_Library.DoiTac item in doitacList)
            //    grd_DSGiayBaoCo.DisplayLayout.ValueLists["DoiTac"].ValueListItems.Add(item.MaDoiTac, item.TenDoiTac);
            foreach (LoaiTien item in LoaiTienList.GetLoaiTienList())
                grd_DSGiayBaoCo.DisplayLayout.ValueLists["LoaiTien"].ValueListItems.Add(item.MaLoaiTien, item.MaLoaiQuanLy);
            LoadData();
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
            GiayBaoCo_CacQuy item = _giayBaoCo_CacQuyList.AddNew();
            frmGiayBaoCo_CacQuy_Edit f = new frmGiayBaoCo_CacQuy_Edit(_loaiGBC, _loaiDeNghi, false);

            //Set Loại Giấy Báo Có, Phí Ngân Hàng và Công Đoàn - Các Quỹ
            item.LoaiGBC = _loaiGBC;
            item.LoaiDeNghi = _loaiDeNghi;
          
            if (f.ShowEdit(item))
            {
                SaveData();
            }
            else
            {
                _giayBaoCo_CacQuyList.Remove(item);
            }
        }

        private void tlSua_Click(object sender, EventArgs e)
        {
            if (grd_DSGiayBaoCo.ActiveRow != null && grd_DSGiayBaoCo.ActiveRow.IsDataRow)
            {
                GiayBaoCo_CacQuy item = (GiayBaoCo_CacQuy)grd_DSGiayBaoCo.ActiveRow.ListObject;
                frmGiayBaoCo_CacQuy_Edit f = new frmGiayBaoCo_CacQuy_Edit(_loaiGBC, _loaiDeNghi, true);
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
                _giayBaoCo_CacQuyList.ApplyEdit();
                _giayBaoCo_CacQuyList.Save();

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
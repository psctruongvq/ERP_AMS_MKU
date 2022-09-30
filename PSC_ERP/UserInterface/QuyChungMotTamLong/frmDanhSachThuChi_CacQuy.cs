using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmDanhSachThuChi_CacQuy : Form
    {
        #region Properties
        private ChungTu_CacLoaiQuy _chungTu_CacLoaiQuy;
        private ChungTu_CacLoaiQuyList _chungTu_CacLoaiQuyList;
        ERP_Library.Security.UserList _userList;
        #endregion

        #region Loads
        public frmDanhSachThuChi_CacQuy()
        {
            InitializeComponent();
        }

        private void grdu_DSChungTu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdu_DSChungTu.DisplayLayout.Bands[0],
                new string[8] { "IsThuChi", "SoChungTu", "NgayLap", "SoTien", "MaLoaiChungTu", "DienGiai", "NgayThuChi", "NguoiThuChi" },
                new string[8] { "Thu/Chi", "Số chứng từ", "Ngày lập", "Số tiền", "Chương trình", "Diễn giải", "Ngày Thu chi", "Người thu chi" },
                new int[8] { 70, 120, 100, 130, 200, 150, 100, 120 },
                new Control[8] { null, null, null, null, cmb_LoaiChungTu, null, null, null },
                new KieuDuLieu[8] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.TienLe, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[8] { true, false, false, false, false, false, true, false });

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DSChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            this.grdu_DSChungTu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DSChungTu.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;

            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
        }
        #endregion

        #region Process
        private void LoadForm()
        {
            DateTime dtTuNgay = Convert.ToDateTime(dtu_NgayBatDau.Value);
            DateTime dtDenNgay = Convert.ToDateTime(dtu_NgayKetThuc.Value);
            int iLoaiThuChi = Convert.ToInt32(cmb_LoaiChungTu.Value);

            _chungTu_CacLoaiQuyList = ChungTu_CacLoaiQuyList.GetChungTu_CacLoaiQuyList_ThuChi(dtTuNgay, dtDenNgay, iLoaiThuChi);
            bdDanhSachChungTu.DataSource = _chungTu_CacLoaiQuyList;
        }

        private void Save()
        {
            try
            {
                grdu_DSChungTu.UpdateData();
                _chungTu_CacLoaiQuyList.ApplyEdit();
                _chungTu_CacLoaiQuyList.Update();

                MessageBox.Show(this, "Đã cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Events
        private void bt_Tim_Click(object sender, EventArgs e)
        {
            if (cmb_LoaiChungTu.Value == null)
            {
                MessageBox.Show(this, "Vui lòng chọn loại thu chi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadForm();
        }

        private void tlslbl_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslbl_Undo_Click(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void tbllbl_Luu_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion
    }
}

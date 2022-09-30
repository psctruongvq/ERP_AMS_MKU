using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmNhomVanBan : Form
    {
        #region Propeties
        Util util = new Util();
        NhomVanBanList _nhomVanBanList;

        NhomVanBanList _nhomVanBanListCha;

        public delegate void PassData(NhomVanBanList value);
        public PassData getData;
        #endregion

        #region Load
        public frmNhomVanBan()
        {
            InitializeComponent();
            this.NhomVanBan_BindingSource.DataSource = typeof(ERP_Library.NhomVanBanList);
            Load_Form();
        }

        private void grdu_NhomVanBan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //Thêm dòng thêm mới dữ liệu
            HamDungChung.EditThemDongMoi(grdu_NhomVanBan);

            //Thêm phần đếm số thứ tự
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

            HamDungChung.EditBand(grdu_NhomVanBan.DisplayLayout.Bands[0],
            new string[4] { "MaQuanLy", "TenNhomvanBan", "MaNhomCha", "DienGiai" },
            new string[4] { "Mã nhóm", "Tên nhóm", "Nhóm cha", "Diễn giải" },
            new int[4] { 100, 200, 200, 200 },
            new Control[4] { null, null, cmbu_NhomVB, null },
            new KieuDuLieu[4] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[4] { true, true, true, true });

            grdu_NhomVanBan.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
        }

        private void cmbu_NhomVB_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_NhomVB.DisplayLayout.Bands[0],
            new string[3] { "MaQuanLy", "TenNhomvanBan", "DienGiai" },
            new string[3] { "Mã nhóm", "Tên nhóm", "Diễn giải" },
            new int[3] { 100, 200, 200 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { false, false, false });

            cmbu_NhomVB.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
        }
        #endregion

        #region Process
        private void Load_Form()
        {
            try
            {
                _nhomVanBanList = NhomVanBanList.GetNhomVanBanList();
                NhomVanBan_BindingSource.DataSource = _nhomVanBanList;

                _nhomVanBanListCha = NhomVanBanList.GetNhomVanBanList();
                _nhomVanBanListCha.Insert(0, NhomVanBan.NewNhomVanBan(0, "Không có"));
                NhomCha_BindingSource.DataSource = _nhomVanBanListCha;
            }
            catch (ApplicationException)
            { }
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _nhomVanBanList.Count; i++)
            {
                for (int j = 0; j < _nhomVanBanList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_nhomVanBanList[i].MaQuanLy.Trim().ToUpper() == _nhomVanBanList[j].MaQuanLy.Trim().ToUpper())
                        {
                            MessageBox.Show(this, "Mã nhóm văn bản " + _nhomVanBanList[i].MaQuanLy.ToString() + " bị trùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_NhomVanBan.ActiveRow = grdu_NhomVanBan.Rows.GetRowWithListIndex(i);
                            grdu_NhomVanBan.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void Save()
        {
            //Kiểm tra dữ liệu
            try
            {
                NhomVanBan _nhomvb;
                for (int i = 0; i < _nhomVanBanList.Count; i++)
                {
                    _nhomvb = _nhomVanBanList[i];
                    if (_nhomvb.MaQuanLy == string.Empty)
                    {
                        MessageBox.Show(this, "Xin vui lòng nhập Mã nhóm văn bản quản lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_NhomVanBan.ActiveRow = grdu_NhomVanBan.Rows.GetRowWithListIndex(i);
                        grdu_NhomVanBan.Focus();
                        return;
                    }
                    if (_nhomvb.TenNhomvanBan == string.Empty)
                    {
                        MessageBox.Show(this, "Xin vui lòng nhập Tên nhóm văn bản quản lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_NhomVanBan.ActiveRow = grdu_NhomVanBan.Rows.GetRowWithListIndex(i);
                        grdu_NhomVanBan.Focus();
                        return;
                    }
                }
                if (KiemTraMaQuanLy())
                {
                    grdu_NhomVanBan.UpdateData();
                    _nhomVanBanList.ApplyEdit();
                    NhomVanBan_BindingSource.EndEdit();
                    _nhomVanBanList.Save();
                    if (getData != null)
                    {
                        getData(_nhomVanBanList);
                    }
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {

            }
        }
        #endregion

        #region Event
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            //Chưa viết code
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            //Chưa viết code
        }

        private void tlslblExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_NhomVanBan);
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Form();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_NhomVanBan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdu_NhomVanBan.DeleteSelectedRows();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }

        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Shared;

namespace PSC_ERP
{
    public partial class frmDonViTinh : Form
    {
        #region Properties
        HamDungChung _hamdungchung = new HamDungChung();
        Util _util = new Util();
        DonViTinhList _dVTList = DonViTinhList.NewDonViTinhList();
        public delegate void GetData(DonViTinhList value);
        public GetData getData;
        #endregion

        #region Constructor
        public frmDonViTinh()
        {
            InitializeComponent();
            _hamdungchung.EventForm(this);
            _hamdungchung.EventGrid(ultraGridDonViTinh);
            Khoitao();
        }
        #endregion

        #region Khoi tao
        public void Khoitao()
        {
            _dVTList = DonViTinhList.GetDonViTinhList();
            donViTinhList_bindingSource.DataSource = _dVTList;
        }
        #endregion

        #region ultraGridDonViTinh_InitializeLayout
        private void ultraGridDonViTinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            _hamdungchung.ultragrdEmail_InitializeLayout(sender, e);
            HamDungChung.EditBand(ultraGridDonViTinh.DisplayLayout.Bands[0],
            new string[3] { "MaQuanLy", "TenDonViTinh", "DienGiai" },
            new string[3] { "Mã ĐVT", "Tên ĐVT", "Diễn Giải" },
            new int[3] { 100, 200, 250 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.ultraGridDonViTinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
            //màu nền
            this.ultraGridDonViTinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.ultraGridDonViTinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region Các thao tác chức năng
        private void tlslbl_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                ultraGridDonViTinh.UpdateData();
                if (KiemTraTenĐVTBiTrung() && KiemTraMaQLĐVTBiTrung())
                {
                    _dVTList.ApplyEdit();
                    donViTinhList_bindingSource.EndEdit();
                    _dVTList.Save();
                    MessageBox.Show(this, _util.luuthanhcong, _util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    donViTinhList_bindingSource.Clear();
                    Khoitao();
                    if (getData != null)
                        getData(_dVTList);
                }
                else
                    return;
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(this, _util.luuthatbai, _util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                //throw ex;
            }
        }

        private void tlslbl_Xoa_Click(object sender, EventArgs e)
        {
            if (ultraGridDonViTinh.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, _util.chodongcanxoa, _util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultraGridDonViTinh.DeleteSelectedRows();
        }

        private void tlslbl_TroLai_Click(object sender, EventArgs e)
        {
            Khoitao();
        }

        private void tlslbl_In_Click(object sender, EventArgs e)
        {

        }

        private void tlslbl_TroGiup_Click(object sender, EventArgs e)
        {

        }

        private void tlslbl_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, _util.thaoTac, _util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        private void ultraGridDonViTinh_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (ultraGridDonViTinh.ActiveCell == ultraGridDonViTinh.ActiveRow.Cells["TenDonViTinh"])
            {
                if (KiemTraTenĐVTBiTrung() == false)
                    return;
            }
            if (ultraGridDonViTinh.ActiveCell == ultraGridDonViTinh.ActiveRow.Cells["MaQuanLy"])
            {
                if (KiemTraMaQLĐVTBiTrung() == false)
                    return;
            }
        }

        #region Kiểm Tra Tên ĐVT Bị Trùng
        private Boolean KiemTraTenĐVTBiTrung()
        {
            for (int i = 0; i < _dVTList.Count; i++)
            {
                for (int j = 0; j < _dVTList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_dVTList[i].TenDonViTinh.ToUpper() == _dVTList[j].TenDonViTinh.ToUpper())
                        {
                            DonViTinh dvt = DonViTinh.GetDonViTinh(_dVTList[i].MaDonViTinh);
                            MessageBox.Show(this, "Đơn vị tính '" + dvt.TenDonViTinh.Trim() + "' bị trùng. Vui lòng nhập tên khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultraGridDonViTinh.ActiveRow = ultraGridDonViTinh.Rows[i];
                            ultraGridDonViTinh.ActiveCell = ultraGridDonViTinh.ActiveRow.Cells["TenDonViTinh"];
                            ultraGridDonViTinh.ActiveCell.SelectAll();
                            //ultraGridDonViTinh.Focus();
                            return false;

                        }
                    }
                }
            }
            return true;
        }
        private Boolean KiemTraMaQLĐVTBiTrung()
        {
            for (int i = 0; i < _dVTList.Count; i++)
            {
                for (int j = 0; j < _dVTList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_dVTList[i].MaQuanLy.ToUpper() == _dVTList[j].MaQuanLy.ToUpper())
                        {
                            DonViTinh dvt = DonViTinh.GetDonViTinh(_dVTList[i].MaDonViTinh);
                            MessageBox.Show(this, "Mã Quản Lý đơn vị tính '" + dvt.MaQuanLy.Trim() + "' bị trùng. Vui lòng nhập tên khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultraGridDonViTinh.ActiveRow = ultraGridDonViTinh.Rows[i];
                            ultraGridDonViTinh.ActiveCell = ultraGridDonViTinh.ActiveRow.Cells["MaQuanLy"];
                            ultraGridDonViTinh.ActiveCell.SelectAll();
                            //ultraGridDonViTinh.Focus();
                            return false;

                        }
                    }
                }
            }
            return true;
        }
        #endregion
    }
}
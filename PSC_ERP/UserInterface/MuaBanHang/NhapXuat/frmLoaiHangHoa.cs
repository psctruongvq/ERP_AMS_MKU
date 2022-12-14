using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmLoaiHangHoa : Form
    {
        #region Properties

        HamDungChung hamDungChung = new HamDungChung();
        Util util = new Util();
        LoaiHangHoaList _loaiHHList = LoaiHangHoaList.NewLoaiHangHoaList();
        NhomHangHoaList _nhomHHList;
        public delegate void GetData(LoaiHangHoaList value);
        public GetData getData;
        #endregion

        #region Constructor
        public frmLoaiHangHoa()
        {
            InitializeComponent();
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_LoaiHangHoa);
            Khoitao();
        }
        #endregion

        #region Hàm Khởi Tạo

        public void Khoitao()
        {
            _loaiHHList = LoaiHangHoaList.GetLoaiHangHoaList(0);
            loaiHangHoaListBindingSource.DataSource = _loaiHHList;
            _nhomHHList = NhomHangHoaList.GetNhomHangHoaList(0);
            //nhomHHListbindingSource.DataSource = _nhomHHList;
        }
        #endregion

        #region grdu_LoaiHangHoa_InitializeLayout(sender,obj)
        private void grdu_LoaiHangHoa_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e); // Định dạng lưới có dòng mới
            //HamDungChung.EditBand(grdu_LoaiHangHoa.DisplayLayout.Bands[0],
            //    new string[4] { "MaQuanLy", "TenLoaiHangHoa", "DienGiai", "MaNhomHangHoa" },
            //    new string[4] { "Mã Loại Hàng Hóa", "Tên Loại Hàng Hóa", "Diễn Giải", "Mã Nhóm Hàng Hóa" },
            //    new int[4] { 110, 150, 150, 150 },
            //    new Control[4] { null, null, null, null },
            //    new KieuDuLieu[4] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            //    new bool[4] { true, true, true, true });
            //grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaNhomHangHoa"].EditorControl = cmbu_NhomHangHoa;
            //grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaNhomHangHoa"].Header.Caption = "Nhóm Hàng Hóa";
            //grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaNhomHangHoa"].Header.Appearance.TextHAlign = HAlign.Center;
            //grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaNhomHangHoa"].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
            
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Loại Hàng Hóa";
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Appearance.TextHAlign = HAlign.Center;
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Appearance.FontData.Bold = DefaultableBoolean.True;

            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Tên Loại Hàng Hóa";
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Appearance.TextHAlign = HAlign.Center;
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Appearance.FontData.Bold = DefaultableBoolean.True;

            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Appearance.TextHAlign = HAlign.Center;
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
            
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaTinhTrang"].Hidden = true;
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaLoaiHangHoa"].Hidden = true;
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaNhomHangHoa"].Hidden = true;
            
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 120;
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Width = 250;
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 280;

            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaNhomHangHoa"].Header.VisiblePosition = 0;
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 2;
            grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            //grdu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaNhomHangHoa"].EditorControl = cmbu_NhomHangHoa;
           // cmbu_NhomHangHoa.DropDownStyle = UltraComboStyle.DropDownList;

        }
        #endregion

        #region cmbu_NhomHangHoa_InitializeLayout(sender,obj)
        private void cmbu_NhomHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //cmbu_NhomHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //cmbu_NhomHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            //cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Nhóm Hàng Hóa";
            ////cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Appearance.TextHAlign = HAlign.Center;
            ////cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
            //cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            //cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["TenNhomHangHoa"].Header.Caption = "Tên Nhóm Hàng Hóa";
            ////cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["TenNhomHangHoa"].Header.Appearance.TextHAlign = HAlign.Center;
            ////cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["TenNhomHangHoa"].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
            //cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["TenNhomHangHoa"].Header.VisiblePosition = 1;

            //cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ////cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Appearance.TextHAlign = HAlign.Center;
            ////cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
            //cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;
            //cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["MaNhomHangHoa"].Hidden = true;
            //cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["ManhomhhC1"].Hidden = true;
            //cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns["MaTinhTrang"].Hidden = true;
            //foreach (UltraGridColumn col in this.cmbu_NhomHangHoa.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.CellAppearance.TextHAlign = HAlign.Left;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            //    col.CellAppearance.ForeColor = System.Drawing.Color.RoyalBlue;
            //}
        }
        #endregion

        #region tlslblLuu_Click()
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdu_LoaiHangHoa.UpdateData();

                //#region Kiemtra Luới
                //for (int i = 0; i < grdu_LoaiHangHoa.Rows.Count; i++)
                //{
                //    if (grdu_LoaiHangHoa.Rows[i].Cells["MaNhomHangHoa"].Text == "0")
                //    {
                //        MessageBox.Show(this, "Chưa Chọn Nhóm Hàng Hóa!", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        grdu_LoaiHangHoa.ActiveRow = grdu_LoaiHangHoa.Rows[i];
                //        return;
                //    }
                //}
                //#endregion      

                _loaiHHList.ApplyEdit();
                loaiHangHoaListBindingSource.EndEdit();
                _loaiHHList.Save();
                MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (getData != null)
                    getData(this._loaiHHList);
            }
            catch (ApplicationException ex)
            {
                //MessageBox.Show(this, util.luuthatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //string tem = ex.Message;
                return;
            }
        }
        #endregion

        #region tlslblXoa_Click()
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_LoaiHangHoa.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_LoaiHangHoa.DeleteSelectedRows();
            //tlslblLuu_Click(sender, e);
        }
        #endregion

        #region tlslblUndo_Click()
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            //Khoitao();
            _loaiHHList = LoaiHangHoaList.GetLoaiHangHoaList(0);
            loaiHangHoaListBindingSource.DataSource = _loaiHHList;
        }
        #endregion

        #region tlslblTroGiup_Click()
        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region tlslblThoat_Click()
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion
    }
}
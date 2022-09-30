using System;
using System.Collections.Generic;
using System.Collections;	
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace PSC_ERP
{
    public partial class frmQuaTrinhNghi_Loat : Form
    {
        QuaTrinhNghiList _DsNghi = QuaTrinhNghiList.NewQuaTrinhNghiList();
        HinhThucNghiList _HinhThucNghiList=HinhThucNghiList.NewHinhThucNghiList();
        BoPhanList _BophanList = BoPhanList.NewBoPhanList();
        ThongTinNhanVienTongHopList _DSNhanvien = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
        Util util = new Util();
       // private ListViewColumnSorter lvwColumnSorter;
        public frmQuaTrinhNghi_Loat()
        {
            InitializeComponent();
          //  lvwColumnSorter = new ListViewColumnSorter();
          //  this.lstvDsnguon.ListViewItemSorter = lvwColumnSorter;
            this.Load_Source();
        }

        #region Load
        private void Load_Source()
        {
            try
            {
                _BophanList = BoPhanList.GetBoPhanList();
                BindS_BoPhan.DataSource = _BophanList;
                _HinhThucNghiList = HinhThucNghiList.GetHinhThucNghiList();
                BindS_HinhThucNghi.DataSource = _HinhThucNghiList;
                dtmp_TuNgay.Value = DateTime.Now;
                dtpu_DenNgay.Value = DateTime.Now;
                dtp_DenngayTraCuu.Value = DateTime.Now;
                dtp_ngaylap.Value = DateTime.Now;
                dtp_TungayTracuu.Value = Convert.ToDateTime(dtp_DenngayTraCuu.Value).AddDays(-7);
                cmbu_TruChuyenCan.Text = "Có";
            }
            catch (ApplicationException)
            {

            }
        }

        private void cmbu_Bophan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_Bophan.DisplayLayout.Bands[0],
            new string[2] { "Tenbophan", "mabophan" },
            new string[2] { "Bộ Phận", "Mã bộ phận" },
            new int[2] { cmbu_Bophan.Width, 90 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["Tenbophan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;

        }

        private void grdu_QuaTrinhTrichNghi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["MaQuaTrinhNghi"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["MaHinhThucNghi"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["NgayNghi"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SoTienHuong"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SuDung"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["LuongTinh"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["Giahan"].Hidden = true;
            
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["maqlnhanvien"].Header.Caption = "Mã Số";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["maqlnhanvien"].CellActivation = Activation.NoEdit;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["maqlnhanvien"].Header.VisiblePosition = 1;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["maqlnhanvien"].Width = 80;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.Caption = "Họ Tên";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellActivation = Activation.NoEdit;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.VisiblePosition = 2;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["Tennhanvien"].Width = 150;


            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TuNgay"].Header.Caption = "Từ Ngày";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TuNgay"].CellActivation = Activation.NoEdit;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TuNgay"].Header.VisiblePosition = 3;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TuNgay"].Width = 80;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["DenNgay"].Header.Caption = "Đến Ngày";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["DenNgay"].CellActivation = Activation.NoEdit;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["DenNgay"].Header.VisiblePosition = 4;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["DenNgay"].Width = 80;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SoGioNghi"].Header.Caption = "Số Giờ Nghỉ";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SoGioNghi"].CellActivation = Activation.NoEdit;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SoGioNghi"].Header.VisiblePosition = 5;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["SoGioNghi"].Width = 80;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TenHinhThucNghi"].Header.Caption = "Hình Thức Nghỉ";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TenHinhThucNghi"].CellActivation = Activation.NoEdit;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TenHinhThucNghi"].Header.VisiblePosition = 6;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TenHinhThucNghi"].Width = 120;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TruChuyenCan"].Header.Caption = "Trừ Chuyên Cần";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TruChuyenCan"].CellActivation = Activation.NoEdit;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TruChuyenCan"].Header.VisiblePosition = 7;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["TruChuyenCan"].Width = 100;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["LyDo"].Header.Caption = "Lý Do";
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["LyDo"].Header.VisiblePosition = 8;
            grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns["LyDo"].Width = 233;

            grdu_QuaTrinhTrichNghi.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_QuaTrinhTrichNghi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_QuaTrinhTrichNghi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
        }

        private void Load_Nguon()
        {
            if (cmbu_Bophan.Value != null)
            {
                if (txt_NhanVien.Text.Trim()=="")
                {
                    _DSNhanvien = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanKhongCotrongQTNghi((int)cmbu_Bophan.Value, Convert.ToDateTime(dtp_TungayTracuu.Value),Convert.ToDateTime(dtp_DenngayTraCuu.Value));
                }
                else
                {
                    _DSNhanvien = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanAndNVKhongCotrongQTNghi((int)cmbu_Bophan.Value, Convert.ToDateTime(dtp_TungayTracuu.Value),Convert.ToDateTime(dtp_DenngayTraCuu.Value),txt_NhanVien.Text.ToString());
                }

                lstvDsnguon.Items.Clear();
                for (int i = 0; i < _DSNhanvien.Count; i++)
                {
                    ListViewItem lstnguonitem;
                    lstnguonitem = lstvDsnguon.Items.Add(_DSNhanvien[i].MaNhanVien.ToString());
                    lstnguonitem.SubItems.Add(_DSNhanvien[i].MaQLNhanVien.ToString());
                    lstnguonitem.SubItems.Add(_DSNhanvien[i].TenNhanVien.ToString());
                    lstnguonitem.SubItems.Add(_DSNhanvien[i].TenChucVu.ToString());
                   // lstnguonitem.SubItems.Add(DateTime.Parse(_DSNhanvien[i].NgayVaoLam.ToString()).ToString("dd/MM/yyyy"));
                }
            }
            lblTSoNV.Text = "Tổng Số : " + _DSNhanvien.Count;
        }

        private void Load_Dich()
        {
            try
            {
                if (cmbu_BoPhanTraCuu.ActiveRow != null)
                {
                    _DsNghi = QuaTrinhNghiList.GetQuaTrinhNghiListBoPhan((int)cmbu_BoPhanTraCuu.Value, Convert.ToDateTime(dtp_TungayTracuu.Value), Convert.ToDateTime(dtp_DenngayTraCuu.Value));
                    BindS_QuaTrinhNghi.DataSource = _DsNghi;
                }
                else
                {
                    _DsNghi = QuaTrinhNghiList.GetQuaTrinhNghiListNgay( Convert.ToDateTime(dtp_TungayTracuu.Value), Convert.ToDateTime(dtp_DenngayTraCuu.Value));
                    BindS_QuaTrinhNghi.DataSource = _DsNghi;
                }
            }
            catch (ApplicationException)
            {

            }
            lblTSoNghi.Text = "Tổng Số : " + _DsNghi.Count;
        }

        private void cmbu_BoPhanTraCuu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_BoPhanTraCuu.DisplayLayout.Bands[0],
            new string[2] { "Tenbophan", "mabophan" },
            new string[2] { "Bộ Phận", "Mã bộ phận" },
            new int[2] { cmbu_BoPhanTraCuu.Width, 90 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });
            cmbu_BoPhanTraCuu.DisplayLayout.Bands[0].Columns["Tenbophan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_BoPhanTraCuu.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;

        }
        #endregion

        #region Event
        private void cmbu_HinhThucNghi_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_HinhThucNghi.Value != null)
            {
                if ((int)cmbu_HinhThucNghi.Value == 3)
                {
                    numeu_SoGioNghi.Value = 4;
                    numeu_SoGioNghi.ReadOnly = false;
                }
                else
                {
                    numeu_SoGioNghi.Value = 8;
                    numeu_SoGioNghi.ReadOnly = true;
                }
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Nguon();
            this.Load_Dich();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_QuaTrinhTrichNghi.ActiveRow != null)
            {
                grdu_QuaTrinhTrichNghi.DeleteSelectedRows();
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _DsNghi.ApplyEdit();
                _DsNghi.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (ApplicationException)
            {

            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpu_DenNgay.Value) < Convert.ToDateTime(dtmp_TuNgay.Value))
            {
                MessageBox.Show(this, "Ngày Không Hợp Lệ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
           if (cmbu_HinhThucNghi.Text != "")
            {
                DialogResult = MessageBox.Show(this, "Nghỉ Việc Từ Ngày : " + DateTime.Parse((dtmp_TuNgay.Value).ToString()).ToString("dd/MM/yyyy") + " Đến Ngày : " + DateTime.Parse((dtpu_DenNgay.Value).ToString()).ToString("dd/MM/yyyy") + "  Cho Nhân Viên Được Chọn (Yes/No) ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult == DialogResult.Yes)
                {
                    int _hinhthucnghi = (int)cmbu_HinhThucNghi.Value;
                    short _Truchuyencan = (short)cmbu_TruChuyenCan.Value;
                    DateTime _NgayLap = Convert.ToDateTime(dtp_ngaylap.Value);
                    long _manguoilap=(long)ERP_Library.Security.CurrentUser.Info.UserID;
                    DateTime _tungay=Convert.ToDateTime(dtmp_TuNgay.Value);
                    DateTime _denngay= Convert.ToDateTime(dtpu_DenNgay.Value);
                    decimal _Gionghi = Convert.ToDecimal(numeu_SoGioNghi.Value);
                    for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                    {
                        if (lstvDsnguon.Items[i].Checked == true)
                        {
                            QuaTrinhNghi.ThemQTNghi(Convert.ToInt64(lstvDsnguon.Items[i].Text),_hinhthucnghi,_Gionghi,_Truchuyencan, txtu_LyDo.Text, _NgayLap, _manguoilap, _tungay,_denngay);
                        }
                    }
                    this.Load_Nguon();
                    this.Load_Dich();
                }
            }
        }

        private void chkTatca_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTatca.Checked == true)
            {
                for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                {
                    lstvDsnguon.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                {
                    lstvDsnguon.Items[i].Checked = false;
                }
            }
        }    

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            this.Load_Nguon();
        }

        private void txt_NhanVien_TextChanged(object sender, EventArgs e)
        {
            this.Load_Nguon();
        }

        private void lstvDsnguon_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //if (e.Column == lvwColumnSorter.SortColumn)
            //{
            //    if (lvwColumnSorter.Order == SortOrder.Ascending)
            //    {
            //        lvwColumnSorter.Order = SortOrder.Descending;
            //    }
            //    else
            //    {
            //        lvwColumnSorter.Order = SortOrder.Ascending;
            //    }
            //}
            //else
            //{
            //    lvwColumnSorter.SortColumn = e.Column;
            //    lvwColumnSorter.Order = SortOrder.Ascending;
            //}
            //this.lstvDsnguon.Sort();
        }

        private void grdu_QuaTrinhTrichNghi_KeyDown(object sender, KeyEventArgs e)
        {
            grdu_QuaTrinhTrichNghi.UpdateData();
        }

        private void grdu_QuaTrinhTrichNghi_Leave(object sender, EventArgs e)
        {
            grdu_QuaTrinhTrichNghi.UpdateData();
        }
        #endregion        

        #region Process
        /*private class ListViewColumnSorter : IComparer
        {
            private int ColumnToSort;
	        private SortOrder OrderOfSort;
	        private CaseInsensitiveComparer ObjectCompare;
	        public ListViewColumnSorter()
	        {
		        // Initialize the column to '0'
		        ColumnToSort = 0;

		        // Initialize the sort order to 'none'
		        OrderOfSort = SortOrder.None;

		        // Initialize the CaseInsensitiveComparer object
		        ObjectCompare = new CaseInsensitiveComparer();
	        }	   
	        public int Compare(object x, object y)
	        {
		        int compareResult;
		        ListViewItem listviewX, listviewY;		 
		        listviewX = (ListViewItem)x;
		        listviewY = (ListViewItem)y;		   
		        compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text,listviewY.SubItems[ColumnToSort].Text);
        			
		        if (OrderOfSort == SortOrder.Ascending)
		        {			 
			        return compareResult;
		        }
		        else if (OrderOfSort == SortOrder.Descending)
		        {
			        return (-compareResult);
		        }
		        else
		        {			 
			        return 0;
		        }
	        }        
	        public int SortColumn
	        {
		        set
		        {
			        ColumnToSort = value;
		        }
		        get
		        {
			        return ColumnToSort;
		        }
	        }	 
	        public SortOrder Order
	        {
		        set
		        {
			        OrderOfSort = value;
		        }
		        get
		        {
			        return OrderOfSort;
		        }
	        }  
        }*/
        #endregion


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using ERP_Library;
using ERP_Library.ThanhToan;
//ok
namespace PSC_ERP
{
    public partial class frmChonLenhChuyenTien : Form
    {
        #region Properties
        private ERP_Library.LenhChuyenTienNuocNgoaiList _data;
        internal GiayBanNgoaiTe _GiayBan;

        SqlCommand command;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table; 

        long iMaPhieu = 0;
        #endregion

        #region Loads
        public frmChonLenhChuyenTien(GiayBanNgoaiTe data)
        {
            InitializeComponent();
            _GiayBan = data;
        }

        public frmChonLenhChuyenTien()
        {
            InitializeComponent();
        }

        private void frmChonLenhChuyenTien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }
        #endregion

        #region Process
        private void LoadData()
        {
            _data = ERP_Library.LenhChuyenTienNuocNgoaiList.GetLenhChuyenTienNuocNgoaiList_ChuaCT();
            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList())
                grdData.DisplayLayout.ValueLists["NganHang"].ValueListItems.Add(item.MaChiTiet, item.TenNganHang);
            foreach (LoaiTien item in LoaiTienList.GetLoaiTienList())
                grdData.DisplayLayout.ValueLists["LoaiTien"].ValueListItems.Add(item.MaLoaiTien, item.MaLoaiQuanLy);
            //foreach (DoiTac item in DoiTacList.GetDoiTacList(" ",false))
            foreach (DoiTac item in DoiTacList.GetDoiTacList(" ", 0))
                grdData.DisplayLayout.ValueLists["DoiTac"].ValueListItems.Add(item.MaDoiTac, item.TenDoiTac);
            
            grdData.DisplayLayout.Bands[0].ColumnFilters["So"].ClearFilterConditions();

            //foreach (ChuyenTien_BanNgoaiTe item in _GiayBan.ChuyenTien_NgoaiTeList)
            //{
            //    if (item.IsNew)
            //    {
            //        grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
            //    }
            //}

            bdChungTu.DataSource = _data;
        }

        private void SaveData()
        {
            try
            {
                _data.Save();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
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
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.Cancel = true;
        }

        private void grdData_AfterRowsDeleted(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            LenhChuyenTienNuocNgoai item = _data.AddNew();
            frmLenhChuyenTienNuocNgoai_Edit f = new frmLenhChuyenTienNuocNgoai_Edit();
            if (f.ShowEdit(item, true))
            {
                SaveData();
            }
            else
            {
                _data.Remove(item);
            }
        }

        private void tlSua_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                ERP_Library.LenhChuyenTienNuocNgoai item = (ERP_Library.LenhChuyenTienNuocNgoai)grdData.ActiveRow.ListObject;
                frmLenhChuyenTienNuocNgoai_Edit f = new frmLenhChuyenTienNuocNgoai_Edit();
                item.BeginEdit();
                //Sửa
                if (f.ShowEdit(item, false))
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

        }

        private void Ngay_Changed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
           
        }
        #endregion

        private void tlslblDNBanNgoaiTe_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null)
            {
                ERP_Library.LenhChuyenTienNuocNgoai item = (ERP_Library.LenhChuyenTienNuocNgoai)grdData.ActiveRow.ListObject;
                iMaPhieu = item.MaLenhCT;

                Report = new Report.NganHang.rpt_LenhChuyenTienRaNuocNgoai();
                command = new SqlCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_tblLenhChuyenTienNuocNgoai";

                command.Parameters.AddWithValue("@MaLenhCT", iMaPhieu);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_tblLenhChuyenTienNuocNgoai;1";
                Report.SetDataSource(table);

                Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
        }

        private void tlslblChon_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();

            foreach(LenhChuyenTienNuocNgoai lc in _data)
            {
                if (lc.Chon)
                {
                    //foreach(ChiTietDeNghi_LenhChuyenTien ctdn in lc.ChiTietDeNghi_LenhChuyenTienList)
                    //{
                        ChuyenTien_BanNgoaiTe ct = ChuyenTien_BanNgoaiTe.NewChuyenTien_BanNgoaiTe(lc.MaLenhCT, lc.So, lc.SoTien, lc.LoaiTien, lc.TyGia);
                       //_GiayBan.ChuyenTien_NgoaiTeList.Add(ct);
                   // }
                }
            }
            this.Close();
        }

        private void grdData_ClickCell(object sender, ClickCellEventArgs e)
        {
            grdData.UpdateData();
        }
    }
}

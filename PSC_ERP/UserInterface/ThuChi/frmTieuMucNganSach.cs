using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using PSC_ERP;


namespace PSC_ERP
{
    public partial class frmTieuMucNganSach : Form
    {
        #region Properties
        TieuMucNganSachList _TieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        TieuMucNganSach _TieuMucNganSach;
        MucNganSachList _MucNganSachList = MucNganSachList.NewMucNganSachList();
        MucNganSach _MucNganSach = MucNganSach.NewMucNganSach();
        decimal TongTien = 0;
        decimal TongTienMuc = 0, TongTienTieuMuc = 0;
        Util _Util = new Util();
        PSC_ERP.HamDungChung t = new PSC_ERP.HamDungChung();
        public string maTieuMuc = string.Empty;
        public string maTieuMucQL = string.Empty;
        #endregion


        #region Events
        public frmTieuMucNganSach()
        {
            InitializeComponent();
            tlsMain.Enabled = true;
            KhoiTaoMoi();
            LayDuLieu();
        }

        public frmTieuMucNganSach(int MaMucNganSach)
        {
            InitializeComponent();
            tlsMain.Enabled = false;
            KhoiTaoSua();
            LayDuLieuSua(MaMucNganSach);
        }

        private void LayDuLieu()
        {
            _TieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach_BindingSource.DataSource = _TieuMucNganSachList;

            _MucNganSachList = MucNganSachList.GetMucNganSachList();
            MucNganSach_BindingSource.DataSource = _MucNganSachList;
        }

        private void LayDuLieuSua(int MaMucNganSach)
        {
            _TieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList(MaMucNganSach);
            TieuMucNganSach_BindingSource.DataSource = _TieuMucNganSachList;

            _MucNganSachList = MucNganSachList.GetMucNganSachList();
            MucNganSach_BindingSource.DataSource = _MucNganSachList;
        }


        private void frmTieuMucNganSach_Load(object sender, EventArgs e)
        {
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                TieuMucNganSach_BindingSource.EndEdit();
                grdu_TieuMucNganSach.UpdateData();
                _TieuMucNganSachList.ApplyEdit();
                _TieuMucNganSachList.Save();
                
                MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_TieuMucNganSach.Selected.Rows.Count == 0)
            {
                MessageBox.Show(_Util.chodongcanxoa, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            grdu_TieuMucNganSach.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_TieuMucNganSach);
            //ReportDocument Report = new PSC_ERP.Report.CongNo.TieuMucNganSach();
            //DataSet dataset = new DataSet();

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "spd_Report_TieuMucNganSach";
            //command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable table = new DataTable();
            //adapter.Fill(table);
            //table.TableName = "spd_Report_TieuMucNganSach;1";

            ////// store thu 2
            //SqlCommand command1 = new SqlCommand();
            //command1.CommandType = CommandType.StoredProcedure;
            //command1.CommandText = "spd_REPORT_ReportHeader";

            //command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            //SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            //DataTable table1 = new DataTable();
            //adapter1.Fill(table1);
            //table1.TableName = "spd_REPORT_ReportHeader;1";

            //dataset.Tables.Add(table1);
            //dataset.Tables.Add(table);

            //Report.SetDataSource(dataset);

            //frmHienThiReport dlg = new frmHienThiReport();
            //dlg.crytalView_HienThiReport.ReportSource = Report;
            //dlg.Show();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdu_TieuMucNganSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdu_TieuMucNganSach.UpdateData();
            }
        }

        private void grdu_TieuMucNganSach_Leave(object sender, EventArgs e)
        {
            grdu_TieuMucNganSach.UpdateData();
        }
        #endregion

        #region InitializeLayout

        private void grdu_TieuMucNganSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
          // KhoiTaoLanDau(grdu_TieuMucNganSach);
        }
        public void KhoiTaoMoi()
        {
            //t.ultragrdEmail_InitializeLayout(sender, e);

            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Override.AllowAddNew = AllowAddNew.FixedAddRowOnTop;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Override.TemplateAddRowPrompt = "Thêm Dòng Mới...";

            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Hidden = true;

            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSach"].Header.Caption = "Mục Ngân Sách";
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSach"].Header.VisiblePosition = 0;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSach"].Width = 200;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSach"].EditorComponent = cmbu_MucNganSach;

            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Tiểu MNS";
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;

            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.Caption = "Tên Tiểu Mục Ngân Sách";
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.VisiblePosition = 2;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Width = 305;

            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.Caption = "Số Tiền";
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.VisiblePosition = 3;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Width = 100;

            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 4;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 218;

            foreach (UltraGridColumn col in this.grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                    col.CellAppearance.TextHAlign = HAlign.Center;
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
                    col.Format = "###,###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }

        }

        public void KhoiTaoSua()
        {

            foreach (UltraGridColumn col in this.grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                    col.CellAppearance.TextHAlign = HAlign.Center;
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
                    col.Format = "###,###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                col.Hidden = true;
            }
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Tiểu MNS";
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 70;

            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Hidden = false;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.Caption = "Tên Tiểu Mục Ngân Sách";
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.VisiblePosition = 2;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Width = 300;

            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdu_TieuMucNganSach.DisplayLayout.Bands[0].Columns["Chon"].Width = 30;

        
        }
        #endregion

        private void grdu_TieuMucNganSach_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            decimal TienNewValue = 0;
            _TieuMucNganSach = (TieuMucNganSach)TieuMucNganSach_BindingSource.Current;
            if (e.Cell.Column.Key == "SoTienTieuMuc")
            {
                TienNewValue = (decimal)e.NewValue;
                TongTien = 0;
                if(_TieuMucNganSach.MaMucNganSach!=0)
                    _MucNganSach = MucNganSach.GetMucNganSach(_TieuMucNganSach.MaMucNganSach);
                if(_TieuMucNganSachList.Count !=0)
                {
                    foreach (TieuMucNganSach tm in _TieuMucNganSachList)
                    {
                        if(tm.MaMucNganSach == _MucNganSach.MaMucNganSach)
                            TongTien = TongTien + TienNewValue;
                    }
                }
                if (TongTien > _MucNganSach.SoTien)
                {
                    MessageBox.Show(this, "Tổng tiền Tiểu Mục NS không được lớn hơn tiền của Mục NS", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void CongChuoi()
        {
            maTieuMuc = string.Empty;
            maTieuMucQL = string.Empty;
            foreach (TieuMucNganSach mns in _TieuMucNganSachList)
            {
                if (mns.Chon == true)
                {
                    //mns.Chon = true;
                    maTieuMuc += mns.MaTieuMuc + ",";
                    maTieuMucQL += mns.MaQuanLy + ",";
                }
            }
            if (maTieuMuc != "")
            {
                maTieuMuc = maTieuMuc.Substring(0, maTieuMuc.Length - 1);
                maTieuMucQL = maTieuMucQL.Substring(0, maTieuMucQL.Length - 1);
            }
        }

        private void grdu_TieuMucNganSach_CellChange(object sender, CellEventArgs e)
        {
            if (grdu_TieuMucNganSach.ActiveRow.IsFilterRow != true)
            {
                Color mau = grdu_TieuMucNganSach.ActiveRow.Appearance.BackColor;
                if (grdu_TieuMucNganSach.ActiveCell == grdu_TieuMucNganSach.ActiveRow.Cells["Chon"])
                {
                    TieuMucNganSach dt;// = DoiTuongAll.NewDoiTuongAll();
                    dt = (TieuMucNganSach)(TieuMucNganSach_BindingSource.Current);
                    if (dt.Chon == false)
                    {
                        dt.Chon = true;
                    }
                    else
                        dt.Chon = false;
                    if (dt.Chon == true)
                        grdu_TieuMucNganSach.ActiveRow.Appearance.BackColor = Color.LightBlue;
                    else
                        grdu_TieuMucNganSach.ActiveRow.Appearance.BackColor = Color.White;
                }
            }
        }

        private void frmTieuMucNganSach_FormClosed(object sender, FormClosedEventArgs e)
        {
            CongChuoi();
        }
    }
}
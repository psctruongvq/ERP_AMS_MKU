using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace PSC_ERP
{
    public partial class frmBiaHoso : Form
    {
        BiaHoSoList _BiaHosoList = BiaHoSoList.NewBiaHoSoList();
        Util util = new Util();

        public frmBiaHoso()
        {
            InitializeComponent();
            Load_Source();
        }

        #region "Load"
        private void Load_Source()
        {
            try
            {
                _BiaHosoList = BiaHoSoList.GetBiaHoSoList();
                BindS_Biahoso.DataSource = _BiaHosoList;
            }
            catch (ApplicationException)
            {

            }
        }

        private void grdu_Biahoso_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["mabiahoso"].Hidden = true;
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["mabiahosoquanly"].Header.Caption = "Mã số";
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["mabiahosoquanly"].Width = 85;
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["mabiahosoquanly"].Header.VisiblePosition = 0;

            grdu_Biahoso.DisplayLayout.Bands[0].Columns["Tenbiahoso"].Header.Caption = "Tên bìa hồ sơ";
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["Tenbiahoso"].Width = 160;
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["Tenbiahoso"].Header.VisiblePosition = 1;

            grdu_Biahoso.DisplayLayout.Bands[0].Columns["Soluongchua"].Header.Caption = "Số lượng chứa";
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["Soluongchua"].Header.VisiblePosition = 2;
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["Soluongchua"].CellClickAction = CellClickAction.CellSelect;


            grdu_Biahoso.DisplayLayout.Bands[0].Columns["soluongtoida"].Header.Caption = "Số lượng tối đa";
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["soluongtoida"].Header.VisiblePosition = 3;
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["ngaytao"].Header.Caption = "Ngày tạo";
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["ngaytao"].Header.VisiblePosition = 4;
            grdu_Biahoso.DisplayLayout.Bands[0].Columns["Nguoitao"].Hidden = true;

            grdu_Biahoso.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_Biahoso.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_Biahoso.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        #region "Event"


        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new ReportDocument();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_tblnsBiaHoSoAll";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_tblnsBiaHoSoAll;1";

            //// store thu 2
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";

            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";

            dataset.Tables.Add(table1);
            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
                for (int i = 0; i < grdu_Biahoso.Rows.Count; i++)
                {
                    if (grdu_Biahoso.Rows[i].Cells["mabiahosoquanly"].Text == "")
                    {
                        MessageBox.Show(this, util.chonNhomChucVu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_Biahoso.ActiveRow = grdu_Biahoso.Rows[i];
                        return;
                    }
                    if (grdu_Biahoso.Rows[i].Cells["Soluongtoida"].Text == "0" || (int)grdu_Biahoso.Rows[i].Cells["Soluongtoida"].Value >100)
                    {
                        MessageBox.Show(this, "Nhập Số Lượng Tối Đa Cho Bìa Hồ Sơ. Hoặc Số Lượng Chứa Quá Lớn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_Biahoso.ActiveRow = grdu_Biahoso.Rows[i];
                        return;
                    }
                }
                for (int i = 0; i < _BiaHosoList.Count; i++)
                {                    
                    if (_BiaHosoList[i].SoLuongChua > _BiaHosoList[i].SoLuongToiDa)
                    {
                        MessageBox.Show(this, "Số lượng chứa tối đa phải lớn hơn số lượng đang chứa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_Biahoso.ActiveRow = grdu_Biahoso.Rows[i];
                        return;
                    }
                }
                if (KiemTraMaQuanLy() == true)
                {
                    try
                    {
                        _BiaHosoList.ApplyEdit();
                        _BiaHosoList.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Load_Source();
                    }
                    catch (ApplicationException)
                    {
                        
                    }
                }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Source();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_Biahoso.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_Biahoso.DeleteSelectedRows();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            BiaHoSo Biahoso;
            for (int i = 0; i < _BiaHosoList.Count; i++)
            {
                Biahoso = _BiaHosoList[i];
                if (Biahoso.MaBiaHoSoQuanLy == "")
                {
                    return;
                }
            }
            Biahoso = BiaHoSo.NewBiaHoSo();
            _BiaHosoList.Add(Biahoso);
            grdu_Biahoso.ActiveRow = grdu_Biahoso.Rows[_BiaHosoList.Count - 1];
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblSapxepHS_Click(object sender, EventArgs e)
        {
            BiaHoSoList _biaHSList;
            DanhsachNVTheoBiaHoSoList _dsNVTheoBiaHSList;
            _dsNVTheoBiaHSList = DanhsachNVTheoBiaHoSoList.GetNhanvienBiaHoSoAll();
            int indexList = 0;
            _biaHSList = BiaHoSoList.GetBiaHoSoList();
            for (int i = 0; i < _biaHSList.Count; i++)
            {
                DialogResult result = MessageBox.Show("Bạn Có Muốn Dồn Hồ Sơ Vào Bìa : " + _biaHSList[i].TenBiaHoSo, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int k = 0; k < _biaHSList[i].SoLuongToiDa; k++)
                    {
                        if (indexList < _dsNVTheoBiaHSList.Count)
                        {
                            _dsNVTheoBiaHSList[indexList].MaBiaHoSo = _biaHSList[i].MaBiaHoSo;
                            indexList++;
                        }
                    }
                }
            }
            _dsNVTheoBiaHSList.ApplyEdit();
            _dsNVTheoBiaHSList.Save();
        }

        #endregion

        #region "Process"
        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _BiaHosoList.Count; i++)
            {
                for (int j = 0; j < _BiaHosoList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_BiaHosoList[i].MaBiaHoSoQuanLy.Trim() == _BiaHosoList[j].MaBiaHoSoQuanLy.Trim())
                        {
                            BiaHoSo Biahoso = BiaHoSo.GetBiaHoSo(_BiaHosoList[i].MaBiaHoSo);
                            MessageBox.Show(this, "Bìa hồ sơ " + Biahoso.TenBiaHoSo.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_Biahoso.ActiveRow = grdu_Biahoso.Rows[i];
                            grdu_Biahoso.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        #endregion  

        private void grdu_Biahoso_Leave(object sender, EventArgs e)
        {
            grdu_Biahoso.UpdateData();
        }

        private void grdu_Biahoso_KeyDown(object sender, KeyEventArgs e)
        {
            grdu_Biahoso.UpdateData();
        }


       
    }
}
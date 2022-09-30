using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;


namespace PSC_ERP
{
    public partial class frmTonGiao : Form
    {
        public delegate void PassData(TonGiaoList value);
        public PassData getdata;
        Util util=new Util();
        TonGiao _TonGiao;
        TonGiaoList _TonGiaoList;
        //DonViTinhList _DonViTinhList;

        public frmTonGiao()
        {
            InitializeComponent();
        }

        private void LayDuLieuLenLuoi()
        {
            try
            {
                _TonGiaoList = TonGiaoList.GetTonGiaoList();
                TonGiaoListBindingSource.DataSource = _TonGiaoList;
            }
            catch (ApplicationException)
            {

            }
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _TonGiaoList.Count; i++)
            {
                for (int j = 0; j < _TonGiaoList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_TonGiaoList[i].MaQuanLy.Trim() == _TonGiaoList[j].MaQuanLy.Trim())
                        {
                            TonGiao tg = TonGiao.GetTonGiao(_TonGiaoList[i].MaTonGiao);
                            MessageBox.Show(this, "Dân tộc " + tg.TenTonGiao.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdTonGiao.ActiveRow = ultragrdTonGiao.Rows[i];
                            ultragrdTonGiao.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void frmTonGiao_Load(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                TonGiao tonGiao;
                for (int i = 0; i < _TonGiaoList.Count; i++)
                {
                    tonGiao = _TonGiaoList[i];
                    if (tonGiao.MaQuanLy == string.Empty)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Tôn Giáo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdTonGiao.ActiveRow = ultragrdTonGiao.Rows[i + 1];
                        ultragrdTonGiao.Focus();
                        return;
                    }
                    else if (tonGiao.TenTonGiao == string.Empty)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Tôn Giáo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdTonGiao.ActiveRow = ultragrdTonGiao.Rows[i + 1];
                        ultragrdTonGiao.Focus();
                        return;
                    }
                }
                if (KiemTraMaQuanLy() == true)
                {
                    try
                    {
                        ultragrdTonGiao.UpdateData();
                        _TonGiaoList.ApplyEdit();
                        _TonGiaoList.Save();                        
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LayDuLieuLenLuoi();
                        if (getdata != null)
                        {
                            getdata(_TonGiaoList);
                        }
                    }
                    catch (ApplicationException)
                    {

                    }
                }
            }
            catch (ApplicationException)
            {

            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _TonGiao = TonGiao.NewTonGiao();
            _TonGiaoList.Add(_TonGiao);
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdTonGiao.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdTonGiao.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }

        private void ultragrdTonGiao_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdTonGiao.DisplayLayout.Bands[0].Columns["MaTonGiao"].Hidden = true;
            ultragrdTonGiao.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdTonGiao.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 80;
            ultragrdTonGiao.DisplayLayout.Bands[0].Columns["TenTonGiao"].Header.Caption = "Tên Tôn Giáo";
            ultragrdTonGiao.DisplayLayout.Bands[0].Columns["TenTonGiao"].Width = 200;


            ultragrdTonGiao.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.ultragrdTonGiao.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.ultragrdTonGiao.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_TonGiaosAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptTonGiao(), new frmHienThiReport(), false);           
        }

        private void ultragrdTonGiao_KeyDown(object sender, KeyEventArgs e)
        {
            ultragrdTonGiao.UpdateData();
        }

        private void ultragrdTonGiao_Leave(object sender, EventArgs e)
        {
            ultragrdTonGiao.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdTonGiao);
        }
    }
}
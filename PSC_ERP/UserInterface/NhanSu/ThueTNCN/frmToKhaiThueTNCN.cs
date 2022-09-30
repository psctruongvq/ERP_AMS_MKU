using System;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using ERP_Library.Security;
//using CrystalDecisions.CrystalReports.Engine;

namespace PSC_ERP
{
    public partial class frmKhaiBaoThueTNCN : Form
    {
        int maKyTinhLuong = -1;
        int namTinh = -1;
        bool theoNam = false;
        string tenKy = string.Empty;
        int userID = CurrentUser.Info.UserID;
        public frmKhaiBaoThueTNCN()
        {
            InitializeComponent();
        }

        private void frmKyTinhLuong_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListAll(userID);
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbBoPhan.Value = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnToKhai_Click(object sender, EventArgs e)
        {
            CheckYearChanged();
           
            if ( cmbBoPhan.Value == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ lương và bộ phận để báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmXemIn frm = new frmXemIn();
            if (KyTinhLuong.GetKyTinhLuong(maKyTinhLuong).Nam <= 2013)
            {
                frm.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptToKhaiThueTNCN.rdlc";
            }
            else
            { 
                 frm.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptToKhaiThueTNCNNew.rdlc";
            }
            ERP_Library.Report.ToKhaiThueTNCNList _toKhaiThueTNCNList = ERP_Library.Report.ToKhaiThueTNCNList.GetToKhaiThueTNCNList(maKyTinhLuong, (int)cmbBoPhan.Value, namTinh);
            bindingSource_ToKhaiTNCNLias.DataSource = _toKhaiThueTNCNList;
            frm.SetDatabase("ERP_Library_Report_ToKhaiThueTNCNList", _toKhaiThueTNCNList);
            frm.SetParameter("KyLuong", tenKy);
            frm.ShowDialog();
        }

        ERP_Library.Report.BangKeThueTNCN_CTVList _BangKeThueTNCN_CTVList;
        private void btnKBCTV_Click(object sender, EventArgs e)
        {
            CheckYearChanged();
             _BangKeThueTNCN_CTVList =ERP_Library.Report.BangKeThueTNCN_CTVList.GetBangKeThueTNCN_CTV_KhongThueList(maKyTinhLuong, (int)cmbBoPhan.Value,namTinh,0);
             //bindingSource_ToKhaiTNCNLias.Clear();
            bindingSource_ToKhaiTNCNLias.DataSource = _BangKeThueTNCN_CTVList;
            ultraGrid_Export.DataSource = _BangKeThueTNCN_CTVList;            
            if ( cmbBoPhan.Value == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ lương và bộ phận để báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmXemIn frm = new frmXemIn();
            //frm.Report.ReportPath = @"F:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptBangKeThueTNCN_CTV.rdlc";
            frm.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptBangKeThueTNCN_CTV.rdlc";
            //frm.SetDatabase("ERP_Library_Report_BangKeThueTNCN_CTVList", ERP_Library.Report.BangKeThueTNCN_CTVList.GetBangKeThueTNCN_CTV_KhongThueList(maKyTinhLuong, (int)cmbBoPhan.Value,namTinh));
            frm.SetDatabase("ERP_Library_Report_BangKeThueTNCN_CTVList", _BangKeThueTNCN_CTVList);
            frm.SetNguoiKy(2);
            ERP_Library.BoPhan bp = ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            ERP_Library.CongTy cty = ERP_Library.CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            frm.SetParameter("TenBoPhan", bp.TenBoPhan, "KyTinhThue", tenKy, "TenCongTy", cty.TenCongTy, "MaSoThue", cty.MaSoThue);
            frm.ShowDialog();
        }

        ERP_Library.Report.BangKeThueTNCN_NVList _BangKeThueTNCN_NVList;
        private void btnBKNV_Click(object sender, EventArgs e)
        {
            CheckYearChanged();
            _BangKeThueTNCN_NVList= ERP_Library.Report.BangKeThueTNCN_NVList.GetBangKeThueTNCN_NVList(maKyTinhLuong, (int)cmbBoPhan.Value, namTinh);
            bindingSource_ToKhaiTNCNLias.DataSource = _BangKeThueTNCN_NVList;
            ultraGrid_Export.DataSource = _BangKeThueTNCN_NVList; 
            if (cmbBoPhan.Value == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ lương và bộ phận để báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmXemIn frm = new frmXemIn();
            //frm.Report.ReportPath = @"F:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptBangKeThueTNCN_NV.rdlc";
            frm.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptBangKeThueTNCN_NV.rdlc";
            //frm.SetDatabase("ERP_Library_Report_BangKeThueTNCN_NVList", ERP_Library.Report.BangKeThueTNCN_NVList.GetBangKeThueTNCN_NVList(maKyTinhLuong, (int)cmbBoPhan.Value,namTinh));
            frm.SetDatabase("ERP_Library_Report_BangKeThueTNCN_NVList", _BangKeThueTNCN_NVList);
            frm.SetNguoiKy(2);
            ERP_Library.BoPhan bp = ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            ERP_Library.CongTy cty = ERP_Library.CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            frm.SetParameter("TenBoPhan", bp.TenBoPhan, "KyTinhThue", tenKy, "TenCongTy", cty.TenCongTy, "MaSoThue", cty.MaSoThue);
            frm.ShowDialog();
        }

        
        private void btnCTVCoThue_Click(object sender, EventArgs e)
        {
            CheckYearChanged();
            _BangKeThueTNCN_CTVList=ERP_Library.Report.BangKeThueTNCN_CTVList.GetBangKeThueTNCN_CTV_TinhThueList(maKyTinhLuong, (int)cmbBoPhan.Value,namTinh,0);
            bindingSource_ToKhaiTNCNLias.DataSource = _BangKeThueTNCN_CTVList;
            ultraGrid_Export.DataSource = _BangKeThueTNCN_CTVList; 
            if (cmbBoPhan.Value == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ lương và bộ phận để báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmXemIn frm = new frmXemIn();
            //frm.Report.ReportPath = @"F:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptBangKeThueTNCN_CTV.rdlc";
            frm.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptBangKeThueTNCN_CTV.rdlc";
            frm.SetDatabase("ERP_Library_Report_BangKeThueTNCN_CTVList", _BangKeThueTNCN_CTVList);
            frm.SetNguoiKy(2);
            ERP_Library.BoPhan bp = ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            ERP_Library.CongTy cty = ERP_Library.CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            frm.SetParameter("TenBoPhan", bp.TenBoPhan, "KyTinhThue", tenKy, "TenCongTy", cty.TenCongTy, "MaSoThue", cty.MaSoThue);
            frm.ShowDialog();
        }

        private void chkNam_CheckedChanged(object sender, EventArgs e)
        {
            CheckYearChanged();
        }
        private void CheckYearChanged()
        {

            if (chkNam.Checked)
            {
                maKyTinhLuong = -1;
                namTinh = Convert.ToInt32(txtNam.Value);
                tenKy = "Năm tính: "+txtNam.Value.ToString();
            }
            else
            {
                namTinh = -1;
                maKyTinhLuong = Convert.ToInt32(cmbKyLuong.Value);
                tenKy = cmbKyLuong.Text;
            }
        }

        private void ultraButton_CTVKThue_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraGrid_Export);
        }

        private void ultraGrid_Export_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraGrid_Export.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                //col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    //col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "#,###";                   
                }
            }
        }

        private void ultraButton_ChiTietThue_Click(object sender, EventArgs e)
        {
            CheckYearChanged();
            _BangKeThueTNCN_CTVList = ERP_Library.Report.BangKeThueTNCN_CTVList.GetBangKeThueTNCN_CTVChiTiet(maKyTinhLuong, (int)cmbBoPhan.Value, namTinh, 0);
            bindingSource_ToKhaiTNCNLias.DataSource = _BangKeThueTNCN_CTVList;
            ultraGrid_Export.DataSource = _BangKeThueTNCN_CTVList;
            if (cmbBoPhan.Value == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ lương và bộ phận để báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmXemIn frm = new frmXemIn();
            //frm.Report.ReportPath = @"F:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptBangKeThueTNCN_CTV.rdlc";
            frm.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptBangKeThueTNCN_CTVChiTiet.rdlc";
            frm.SetDatabase("ERP_Library_Report_BangKeThueTNCN_CTVList", _BangKeThueTNCN_CTVList);
            frm.SetNguoiKy(2);
            ERP_Library.BoPhan bp = ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            ERP_Library.CongTy cty = ERP_Library.CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            frm.SetParameter("TenBoPhan", bp.TenBoPhan, "KyTinhThue", tenKy);
            frm.ShowDialog();
        }

        private void btn03KK_Click(object sender, EventArgs e)
        {
            CheckYearChanged();
            ERP_Library.Report.ToKhaiThueTNCNList _toKhaiThueTNCNList = ERP_Library.Report.ToKhaiThueTNCNList.GetToKhaiThueTNCNListByThuong(maKyTinhLuong, (int)cmbBoPhan.Value, namTinh);
            bindingSource_ToKhaiTNCNLias.DataSource = _toKhaiThueTNCNList;

            if (cmbBoPhan.Value == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ lương và bộ phận để báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmXemIn frm = new frmXemIn();
            //frm.Report.ReportPath = @"F:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptToKhaiThueTNCN.rdlc";
            frm.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptToKhaiThueTNCNTrungThuong.rdlc";
            //frm.SetDatabase("ERP_Library_Report_ToKhaiThueTNCNList", ERP_Library.Report.ToKhaiThueTNCNList.GetToKhaiThueTNCNList(maKyTinhLuong, (int)cmbBoPhan.Value,namTinh));
            frm.SetDatabase("ERP_Library_Report_ToKhaiThueTNCNList", _toKhaiThueTNCNList);
            frm.SetParameter("KyLuong", tenKy);
            frm.ShowDialog();
        }

        private void btn03KKChiTiet_Click(object sender, EventArgs e)
        {
            CheckYearChanged();
            _BangKeThueTNCN_CTVList = ERP_Library.Report.BangKeThueTNCN_CTVList.GetBangKeThueTNCN_CTVChiTietByThuong(maKyTinhLuong, (int)cmbBoPhan.Value, namTinh, 0);
            bindingSource_ToKhaiTNCNLias.DataSource = _BangKeThueTNCN_CTVList;
            ultraGrid_Export.DataSource = _BangKeThueTNCN_CTVList;
            if (cmbBoPhan.Value == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ lương và bộ phận để báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmXemIn frm = new frmXemIn();
            //frm.Report.ReportPath = @"F:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptBangKeThueTNCN_CTV.rdlc";
            frm.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptBangKeThueTNCN_CTV.rdlc";
            frm.SetDatabase("ERP_Library_Report_BangKeThueTNCN_CTVList", _BangKeThueTNCN_CTVList);
            frm.SetNguoiKy(2);
            ERP_Library.BoPhan bp = ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            ERP_Library.CongTy cty = ERP_Library.CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            frm.SetParameter("TenBoPhan", bp.TenBoPhan, "KyTinhThue", tenKy, "TenCongTy", cty.TenCongTy, "MaSoThue", cty.MaSoThue);
            frm.ShowDialog();
        }

        private void btn03KKChiTietExport_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraGrid_Export);
        }
    }
}
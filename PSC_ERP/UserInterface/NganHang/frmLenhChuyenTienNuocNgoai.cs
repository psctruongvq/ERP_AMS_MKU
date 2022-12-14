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

namespace PSC_ERP
{
    public partial class frmLenhChuyenTienNuocNgoai : Form
    {
        #region Properties
        private ERP_Library.LenhChuyenTienNuocNgoaiList _data;

        SqlCommand command;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table; 

        long iMaPhieu = 0;
        #endregion

        #region Loads
        public frmLenhChuyenTienNuocNgoai()
        {
            InitializeComponent();
        }

        private void frmLenhChuyenTienNuocNgoai_Load(object sender, EventArgs e)
        {
            txtTuNgay.Value = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            LoadData();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }
        #endregion

        #region Process
        private void LoadData()
        {
            _data = ERP_Library.LenhChuyenTienNuocNgoaiList.GetLenhChuyenTienNuocNgoaiList(txtTuNgay.DateTime, txtDenNgay.DateTime);
            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList())
                grdData.DisplayLayout.ValueLists["NganHang"].ValueListItems.Add(item.MaChiTiet, item.TenNganHang);
            foreach (LoaiTien item in LoaiTienList.GetLoaiTienList())
                grdData.DisplayLayout.ValueLists["LoaiTien"].ValueListItems.Add(item.MaLoaiTien, item.MaLoaiQuanLy);
            //foreach (DoiTac item in DoiTacList.GetDoiTacList(" ",false))
                foreach (DoiTac item in DoiTacList.GetDoiTacList(" ", 0))
                grdData.DisplayLayout.ValueLists["DoiTac"].ValueListItems.Add(item.MaDoiTac, item.TenDoiTac);
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
            e.Cancel = MessageBox.Show("Bạn có muốn xóa chứng từ này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            e.DisplayPromptMsg = false;
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
                int iSoChungTu = 0;
                item.So = item.GetSoChungTu(ref iSoChungTu).ToString() + '-' + item.GetMaLenhChuyenTien();

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
            if (e.Row.IsDataRow)
                tlSua.PerformClick();
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
            try
            {
                grdData.UpdateData();
                bdChungTu.EndEdit();
                _data.ApplyEdit();
                _data.Save();
                LoadData();

                MessageBox.Show(this, "Cập nhật thông tin thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void tlslblDNBanNgoaiTe_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null)
            {
                ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

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

                //Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                //Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                //Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                Report.SetParameterValue("_tenBoPhan", nguoiky.ThuTruongTen);
                Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_tenThuTruong", nguoiky.TenTongGiamDoc);

                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
        }
        LenhChuyenTienNuocNgoai _lenhChuyenTienNuocNgoaiNew = LenhChuyenTienNuocNgoai.NewLenhChuyenTienNuocNgoai();
        private void toolStripButton_coppy_Click(object sender, EventArgs e)
        {
            LenhChuyenTienNuocNgoai _lenhChuyenTienNuocNgoaiOld = LenhChuyenTienNuocNgoai.NewLenhChuyenTienNuocNgoai();
         
            if (grdData.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Chọn dòng cần coppy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _lenhChuyenTienNuocNgoaiNew = LenhChuyenTienNuocNgoai.NewLenhChuyenTienNuocNgoai();
                _lenhChuyenTienNuocNgoaiOld = (LenhChuyenTienNuocNgoai)bdChungTu.Current;
                int iSoChungTu = 0;
                _lenhChuyenTienNuocNgoaiNew.DienGiai = _lenhChuyenTienNuocNgoaiOld.DienGiai;
                _lenhChuyenTienNuocNgoaiNew.GhiChu = _lenhChuyenTienNuocNgoaiOld.GhiChu;
                _lenhChuyenTienNuocNgoaiNew.HinhThucChuyen = _lenhChuyenTienNuocNgoaiOld.HinhThucChuyen;
                _lenhChuyenTienNuocNgoaiNew.LoaiPhiDichVu = _lenhChuyenTienNuocNgoaiOld.LoaiPhiDichVu;
                _lenhChuyenTienNuocNgoaiNew.LoaiTien = _lenhChuyenTienNuocNgoaiOld.LoaiTien;
                _lenhChuyenTienNuocNgoaiNew.MaDoiTac = _lenhChuyenTienNuocNgoaiOld.MaDoiTac;
                _lenhChuyenTienNuocNgoaiNew.NganHangChuyen = _lenhChuyenTienNuocNgoaiOld.NganHangChuyen;
                _lenhChuyenTienNuocNgoaiNew.NganHangNhan = _lenhChuyenTienNuocNgoaiOld.NganHangNhan;
                _lenhChuyenTienNuocNgoaiNew.NgayLap = _lenhChuyenTienNuocNgoaiOld.NgayLap;
                //_lenhChuyenTienNuocNgoaiNew.NgayXacNhan = _lenhChuyenTienNuocNgoaiOld.NgayXacNhan;
                _lenhChuyenTienNuocNgoaiNew.NoiDungThanhToan = _lenhChuyenTienNuocNgoaiOld.NoiDungThanhToan;
                _lenhChuyenTienNuocNgoaiNew.So = _lenhChuyenTienNuocNgoaiNew.GetSoChungTu(ref iSoChungTu).ToString() + '-' + _lenhChuyenTienNuocNgoaiNew.GetMaLenhChuyenTien(); ;
                _lenhChuyenTienNuocNgoaiNew.SoChungTu = _lenhChuyenTienNuocNgoaiOld.SoChungTu;
                _lenhChuyenTienNuocNgoaiNew.SoDeNghi = _lenhChuyenTienNuocNgoaiOld.SoDeNghi;
                _lenhChuyenTienNuocNgoaiNew.SoTien = _lenhChuyenTienNuocNgoaiOld.SoTien;
                _lenhChuyenTienNuocNgoaiNew.SoTienBangChu = _lenhChuyenTienNuocNgoaiOld.SoTienBangChu;
                _lenhChuyenTienNuocNgoaiNew.TyGia = _lenhChuyenTienNuocNgoaiOld.TyGia;
                _lenhChuyenTienNuocNgoaiNew.UserId = _lenhChuyenTienNuocNgoaiOld.UserId;
         
            }
        }

        private void toolStripButton_Paste_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Chọn dòng cần coppy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                _data.Insert(0, _lenhChuyenTienNuocNgoaiNew);
            }
        }
    }
}
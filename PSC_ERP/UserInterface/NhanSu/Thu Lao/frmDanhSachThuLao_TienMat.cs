using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
//
namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmDanhSachThuLao_TienMat : Form
    {

        ThuLaoChuongTrinhList _ThuLaoChuongTrinhList, _thuLaoChuongTrinhListUpdateDangPhi;
        public frmDanhSachThuLao_TienMat()
        {
            InitializeComponent();
            ThuLaoLilst_bindingSource.DataSource = typeof(ThuLaoChuongTrinhList);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_DenNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ThuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhListByNgayLap(Convert.ToDateTime(dateTimePicker_TuNgay.Value),Convert.ToDateTime( dateTimePicker_DenNgay.Value),false,true);
            ThuLaoLilst_bindingSource.DataSource = _ThuLaoChuongTrinhList;
        }

        private void grdu_QuocGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
           
            foreach (UltraGridColumn col in this.grdu_QuocGia.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

            }
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 180;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Chứng Từ";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 120;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 1;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TinhDangPhi"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TinhDangPhi"].Header.Caption = "Tính Đảng Phí";            
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TinhDangPhi"].Header.VisiblePosition = 4;
        }

        private void grdu_QuocGia_Error(object sender, Infragistics.Win.UltraWinGrid.ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.MultiCellOperation)
            {
                // Cancel the default error message
                e.Cancel = true;

                // e.MultiCellOperationErrorInfo returns the error information.
                // Build a custom error message for the user.
                System.Text.StringBuilder SB = new System.Text.StringBuilder();

                SB.AppendFormat("An error has occurred during the {0} operation", e.MultiCellOperationErrorInfo.Operation.ToString());
                SB.Append(Environment.NewLine);
                SB.Append("The error was as follows:");
                SB.Append(Environment.NewLine);
                SB.Append(Environment.NewLine);
                SB.AppendFormat("\"{0}\"", e.ErrorText);

                // Get the cell on which the error occurred
                UltraGridCell errorCell = e.MultiCellOperationErrorInfo.ErrorCell;

                // The ErrorCell will be null if the error was an error in the whole
                // operation as oppossed to an error no a single cell.
                if (errorCell != null)
                {
                    int rowIndex = errorCell.Row.Index;
                    string columnCaption = errorCell.Column.Header.Caption;

                    SB.Append(Environment.NewLine);
                    SB.AppendFormat("The error occurred on Row {0} in Column {1}", rowIndex, columnCaption);
                }

                MessageBox.Show(this, SB.ToString());
            }
        }

        private void grdu_QuocGia_DoubleClick(object sender, EventArgs e)
        {
            if (grdu_QuocGia.ActiveRow != null)
            {
                int maKyTinhLuong = (int)grdu_QuocGia.ActiveRow.Cells["MaKyTinhLuong"].Value;
                int maChuongTrinh = (int)grdu_QuocGia.ActiveRow.Cells["MaChuongTrinh"].Value;
                int maChiTietGiayXacNhan = (int)grdu_QuocGia.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value;
                bool tinhDangPhi = (bool)grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"].Value;
                string maPhieuChi = (string)grdu_QuocGia.ActiveRow.Cells["MaPhieuChi"].Value;
                DateTime ngayLap = (DateTime)grdu_QuocGia.ActiveRow.Cells["NgayLap"].Value;
                bool thanhToan = (bool)grdu_QuocGia.ActiveRow.Cells["ThanhToan"].Value;
                long maChiThuLao = (long)grdu_QuocGia.ActiveRow.Cells["MaChiThuLao"].Value;
                
                KyTinhLuong _kyTinhLuong = KyTinhLuong.NewKyTinhLuong();
                _kyTinhLuong = KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);

                frmThuLaoChuongTrinh_TienMatNew _frmThuLaoChuongTrinh = new frmThuLaoChuongTrinh_TienMatNew(maKyTinhLuong, maChuongTrinh, maPhieuChi, ngayLap, tinhDangPhi, maChiThuLao,maChiTietGiayXacNhan);
                _frmThuLaoChuongTrinh.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ThuLaoChuongTrinhList.Save();
        }

        private void grdu_QuocGia_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void copyThùLaoChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (grdu_QuocGia.Selected.Rows.Count != 1)
            {
                MessageBox.Show("Chọn 1 dòng để copy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                int maKyTinhLuong = (int)grdu_QuocGia.ActiveRow.Cells["MaKyTinhLuong"].Value;
                int maChuongTrinh = (int)grdu_QuocGia.ActiveRow.Cells["MaChuongTrinh"].Value;
                int maChiTietGiayXacNhan = (int)grdu_QuocGia.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value;
                bool tinhDangPhi = (bool)grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"].Value;
                string maPhieuChi = (string)grdu_QuocGia.ActiveRow.Cells["MaPhieuChi"].Value;
                DateTime ngayLap = (DateTime)grdu_QuocGia.ActiveRow.Cells["NgayLap"].Value;
                bool thanhToan = (bool)grdu_QuocGia.ActiveRow.Cells["ThanhToan"].Value;
                long maChiThuLao = (long)grdu_QuocGia.ActiveRow.Cells["MaChiThuLao"].Value;
                frmCopyThuLao copy = new frmCopyThuLao();
                DialogResult result = MessageBox.Show("Bạn có muốn copy dữ liệu?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    copy.ShowDialog(this);
                    if (KyTinhLuong.GetKyTinhLuong(copy.maKyTinhluong).KhoaSoKy2 == false && copy.IsOK == true)
                    {

                       ThuLaoChuongTrinhList _thuLaoListCopy = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhListByCopyTienMat(0, maChuongTrinh, maKyTinhLuong, maPhieuChi, tinhDangPhi, maChiThuLao, maChiTietGiayXacNhan, ngayLap);
                       //ThuLaoChuongTrinhList _thuLaoListCopy = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhListByCopy(maChuongTrinh, maKyTinhLuong, maChiTietGiayXacNhan, ERP_Library.Security.CurrentUser.Info.UserID, tinhDangPhi, ngayLap, maChiThuLao);
                        foreach (ThuLaoChuongTrinh thuLao in _thuLaoListCopy)
                        {
                            thuLao.ThanhToan = false;
                            thuLao.MaPhieuChi = copy.tenChungTu;
                            thuLao.SoChungTu = copy.tenChungTu;
                            thuLao.MaKyTinhLuong = copy.maKyTinhluong;
                            thuLao.TinhDangPhi = copy.tinhDangPhi;
                            thuLao.NgayLap = copy.ngayLap;
                            thuLao.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                            thuLao.DuocNhapHo = copy.nhapHo;
                            thuLao.MaChiThuLao = copy.maChiThuLao;
                            thuLao.MaChiTietGiayXacNhan = copy.maChiTietGiayXacNhan;
                            thuLao.MaGiayXacNhan = copy.maGiayXacNhan;
                            thuLao.TenGiayXacNhan = copy.tenGiayXacNhan;
                            thuLao.ThucNhan = copy.thucNhan;
                            thuLao.MaChuongTrinh = copy.maChuongTrinh;
                            thuLao.TenChuongTrinh = copy.tenChuongTrinh;
                            thuLao.MaNguonChuongTrinh = copy.maNguonChuongTrinh;
                            thuLao.TenNguonChuongTrinh = copy.tenNguonChuongTrinh;
                        }
                        _thuLaoListCopy.ApplyEdit();
                        _thuLaoListCopy.Save();
                        MessageBox.Show("Copy dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _ThuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhListByNgayLap(Convert.ToDateTime(dateTimePicker_TuNgay.Value), Convert.ToDateTime(dateTimePicker_DenNgay.Value), false, true);
                        ThuLaoLilst_bindingSource.DataSource = _ThuLaoChuongTrinhList;
                    }
                    else
                    {
                        MessageBox.Show("Kỳ Này Đã Khóa Sổ Rổi !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

    
        private void button2_Click_1(object sender, EventArgs e)
        {/*
            ReportDocument Report = new Report.rptThuLaoChuongTrinh();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_DanhSachThuLao_Report";
            command.Parameters.AddWithValue("@TuNgay", dateTimePicker_TuNgay.Value.Date);
            command.Parameters.AddWithValue("@DenNgay", dateTimePicker_DenNgay.Value.Date);
            command.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_DanhSachThuLao_Report;1";
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
          * */
            frmBaoCaoThuLaoChiTiet f = new frmBaoCaoThuLaoChiTiet();
            f.Show();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void báoCáoDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.rptThuLaoChuongTrinh();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_DanhSachThuLao_Report";
            command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
            command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
            command.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_DanhSachThuLao_Report;1";
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

        private void báoCáoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuNgayDenNgay f = new frmTuNgayDenNgay();
            f.ShowDialog(this);
            ReportDocument Report = new Report.rptDanhSachThuLaoChiTiet();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_ThuLaoChuongTrinhByNhanVien";
            command.Parameters.AddWithValue("@MaBoPhan", 0);
            command.Parameters.AddWithValue("@MaNhanVien",0);
            command.Parameters.AddWithValue("@TuNgay", frmTuNgayDenNgay.TuNgay.Date);
            command.Parameters.AddWithValue("@DenNgay", frmTuNgayDenNgay.DenNgay.Date);
            command.Parameters.AddWithValue("@MaNguoiDangNhap", ERP_Library.Security.CurrentUser.Info.UserID);
            //command.Parameters.AddWithValue("@Denngay",Convert.ToDateTime(DateTime.Today));
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_ThuLaoChuongTrinhByNhanVien;1";

            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();   
        }

        private void báoCáoĐảngPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChonKyTinhLuong f = new frmChonKyTinhLuong();
            f.ShowDialog(this);
            ReportDocument Report = new Report.ThuLaoChuongTrinh_DangPhi();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi";
            command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            command.Parameters.AddWithValue("@TuKy", frmChonKyTinhLuong.maKyTinhLuongTuKy);
            command.Parameters.AddWithValue("@DenKy", frmChonKyTinhLuong.maKyTinhLuongDenKy);
            //command.Parameters.AddWithValue("@Denngay",Convert.ToDateTime(DateTime.Today));
            command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi;1";

            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();   
        }
        
        private void grdu_QuocGia_AfterCellUpdate(object sender, CellEventArgs e)
        {
            //if (grdu_QuocGia.ActiveRow != null)
            //{
            //    if (grdu_QuocGia.ActiveCell == grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"])
            //    {
            //        int maKyTinhLuong = (int)grdu_QuocGia.ActiveRow.Cells["MaKyTinhLuong"].Value;
            //        int maChuongTrinh = (int)grdu_QuocGia.ActiveRow.Cells["MaChuongTrinh"].Value;
            //        string maPhieuChi = (string)grdu_QuocGia.ActiveRow.Cells["MaPhieuChi"].Value;
            //        bool tinhDangPhi = (bool)grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"].Value;
            //        _thuLaoChuongTrinhListUpdateDangPhi = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(0, maChuongTrinh, maKyTinhLuong, maPhieuChi);

            //        foreach (ThuLaoChuongTrinh thulao in _thuLaoChuongTrinhListUpdateDangPhi)
            //        {
            //            thulao.TinhDangPhi = true;
            //        }
            //    }
            //}
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            try
            {
               _thuLaoChuongTrinhListUpdateDangPhi.Save();
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, "Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void ThuLaoLilst_bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //int maKyTinhLuong = (int)grdu_QuocGia.ActiveRow.Cells["MaKyTinhLuong"].Value;
            //int maChuongTrinh = (int)grdu_QuocGia.ActiveRow.Cells["MaChuongTrinh"].Value;
            //string maPhieuChi = (string)grdu_QuocGia.ActiveRow.Cells["MaPhieuChi"].Value;
            //bool tinhDangPhi = (bool)grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"].Value;
            //_thuLaoChuongTrinhListUpdateDangPhi = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(0, maChuongTrinh, maKyTinhLuong, maPhieuChi);

            //foreach (ThuLaoChuongTrinh thulao in _thuLaoChuongTrinhListUpdateDangPhi)
            //{
            //    thulao.TinhDangPhi = true;
            //}
        }


        private void grdu_QuocGia_CellChange(object sender, CellEventArgs e)
        {
            try
            {
                
                if (grdu_QuocGia.ActiveRow.IsFilterRow != true)
                {
                    if (grdu_QuocGia.ActiveRow.IsFilterRow != true)
                    {
                        if (grdu_QuocGia.ActiveRow != null)
                        {
                            grdu_QuocGia.UpdateData();
                            
                            if (grdu_QuocGia.ActiveCell == grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"])
                            {
                                int maKyTinhLuong = (int)grdu_QuocGia.ActiveRow.Cells["MaKyTinhLuong"].Value;
                                int maChuongTrinh = (int)grdu_QuocGia.ActiveRow.Cells["MaChuongTrinh"].Value;
                                int maChiTietGiayXacNhan = (int)grdu_QuocGia.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value;
                                bool tinhDangPhi = (bool)grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"].Value;
                                string maPhieuChi = (string)grdu_QuocGia.ActiveRow.Cells["MaPhieuChi"].Value;
                                DateTime ngayLap = (DateTime)grdu_QuocGia.ActiveRow.Cells["NgayLap"].Value;
                                bool _tinhDP = false;
                                if (tinhDangPhi == true)
                                    _tinhDP = false;
                                else
                                    _tinhDP = true;
                                _thuLaoChuongTrinhListUpdateDangPhi = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(0, maChuongTrinh, maKyTinhLuong, maChiTietGiayXacNhan, maPhieuChi, ngayLap,_tinhDP,false);
                                
                                //maKyTinhLuong, maChuongTrinh, maChiTietGiayXacNhan, maPhieuChi, ngayLap
                                foreach (ThuLaoChuongTrinh thulao in _thuLaoChuongTrinhListUpdateDangPhi)
                                {
                                    thulao.TinhDangPhi = tinhDangPhi;
                                }
                                //KyTinhLuong ktl=KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);
                                //if (ktl.KhoaSoKy2 == true || ktl.KhoaSo == true)
                                //{
                                //    MessageBox.Show("Tháng lương Đã Khóa Sổ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    return;
                                //}

                                for (int i = 0; i < _thuLaoChuongTrinhListUpdateDangPhi.Count; i++)
                                {
                                    ThuLaoChuongTrinh.UpdateDangPhi(_thuLaoChuongTrinhListUpdateDangPhi[i].MaThuLao, tinhDangPhi);
                                }

                            }
                         }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_QuocGia);
        }
    }
}

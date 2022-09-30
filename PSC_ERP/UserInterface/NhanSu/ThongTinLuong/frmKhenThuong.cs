using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmKhenThuong : Form
    {
        Util util = new Util();
        KhenThuongList _khenThuongList;
        ChucVuList _chucVuList ;
        CongViecList _congViecList;
        KyTinhLuongList _KyTLList;
        MucDoHTCongViecList _mucDoHTCongViecList ;
        public frmKhenThuong()
        {
            InitializeComponent();
            Load_Form();
        }

        #region "Load"
        private void Load_Form()
        {
            _khenThuongList = KhenThuongList.GetKhenThuongList();
            KhenThuongBindingSource.DataSource = _khenThuongList;
            _mucDoHTCongViecList = MucDoHTCongViecList.GetMucDoHTCongViecList();
            MucDoBindingSource.DataSource = _mucDoHTCongViecList;
            _KyTLList = KyTinhLuongList.GetKyTinhLuongList();
            BindS_kyluong.DataSource = _KyTLList;
            _chucVuList = ChucVuList.GetChucVuListAll();
            ChucVuBindingSource.DataSource = _chucVuList;
            _congViecList = CongViecList.GetCongViecList();
            CongViecBindingSource.DataSource = _congViecList;
        }
        private void grdKhenThuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["MaKhenThuong"].Hidden = true;
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["MaCongViec"].Hidden = true;
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = true;
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["MaMucDo"].Hidden = true;
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;

            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 1;

            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.Caption = "Tên Công Việc";
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.VisiblePosition=2;
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["TenMucDo"].Header.Caption = "Mức Độ";
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["TenMucDo"].Header.VisiblePosition = 3;
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 4;
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Kỳ";
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 5;
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["SoTienThuong"].Header.Caption = "Số Tiền Thưởng";
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["SoTienThuong"].Header.VisiblePosition = 6;
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_KhenThuong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition=7;
            

            //grdu_KhenThuong.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //this.grdu_KhenThuong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_KhenThuong.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                    col.Format = "dd/MM/yyyy";
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }

            }
        }
        #endregion

        #region "Event"
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            KhenThuong _khenthuong;
            for (int i = 0; i < _khenThuongList.Count; i++)
            {
                if (_khenThuongList[i].MaChucVu == 0)
                {
                    return;
                }
                if (_khenThuongList[i].MaCongViec == 0)
                {
                    return;
                }
                if (_khenThuongList[i].MaKy == 0)
                {
                    return;
                }
                if (_khenThuongList[i].MaMucDo == 0)
                {
                    return;
                }
            }
            _khenthuong = KhenThuong.NewKhenThuong();
            _khenThuongList.Add(_khenthuong);
            grdu_KhenThuong.ActiveRow = grdu_KhenThuong.Rows[_khenThuongList.Count - 1];
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _khenThuongList.Count; i++)
                {
                    if (_khenThuongList[i].MaChucVu == 0)
                    {
                        MessageBox.Show(this, "Không để trống mã chức vụ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_KhenThuong.ActiveRow = grdu_KhenThuong.Rows[i];
                        return;
                    }
                    if (_khenThuongList[i].MaCongViec == 0)
                    {
                        MessageBox.Show(this, "Không để trống mã công việc", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_KhenThuong.ActiveRow = grdu_KhenThuong.Rows[i];
                        return;
                    }
                    if (_khenThuongList[i].MaKy == 0)
                    {
                        MessageBox.Show(this, "Không để trống mã Tháng lương", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_KhenThuong.ActiveRow = grdu_KhenThuong.Rows[i];
                        return;
                    }
                    if (_khenThuongList[i].MaMucDo == 0)
                    {
                        MessageBox.Show(this, "Không để trống mã mức độ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_KhenThuong.ActiveRow = grdu_KhenThuong.Rows[i];
                        return;
                    }
                }
                if (KiemTraMaQuanLy() == true)
                {
                    _khenThuongList.ApplyEdit();
                    _khenThuongList.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Form();

                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_KhenThuong.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn  Dòng Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_KhenThuong.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Form();
        }
            
        private void tlslblIn_Click(object sender, EventArgs e)
        {
                ReportDocument Report = new Report.rptKhenThuong();
                DataSet dataset = new DataSet();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_report_KhenThuongsAll";
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_report_KhenThuongsAll;1";

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
                #endregion

        #region "Process"    
        private bool KiemTraMaQuanLy()
        {          
            for (int i = 0; i < _khenThuongList.Count; i++)
            {
                for (int j = 0; j < _khenThuongList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_khenThuongList[i].MaChucVu == _khenThuongList[j].MaChucVu & _khenThuongList[i].MaCongViec == _khenThuongList[j].MaCongViec & _khenThuongList[i].MaMucDo == _khenThuongList[j].MaMucDo & _khenThuongList[i].MaKy == _khenThuongList[j].MaKy)
                        {
                            KhenThuong kt = KhenThuong.GetKhenThuong(_khenThuongList[i].MaChucVu, _khenThuongList[i].MaCongViec, _khenThuongList[i].MaMucDo, _khenThuongList[i].MaKy);
                            MessageBox.Show(this, "Khen thưởng bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_KhenThuong.ActiveRow = grdu_KhenThuong.Rows[i + 1];
                            grdu_KhenThuong.Focus();
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Shared;
using Csla;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;

namespace PSC_ERP
{
    public partial class frmQuyetDinhBoNhiem_TimQD : Form
    {
        QuyetDinhBoNhiem _QuyetDinhBoNhiem = QuyetDinhBoNhiem.NewQuyetDinhBoNhiem();
      
        public frmQuyetDinhBoNhiem_TimQD()
        {
            InitializeComponent();
            this.Load_Form();

            tlslblUndo.Visible = false;
            toolStripSeparator4.Visible = false;
        }
        
        #region Properties
        Util util = new Util();
        public int _maQuyetDinh = 0;
        QuyetDinhBoNhiem _QDBoNhiem;
        QuyetDinhBoNhiemList _QDBoNhiemList;
        #endregion

        #region Events
        private void Load_Form()
        {
            _QDBoNhiemList = QuyetDinhBoNhiemList.GetQuyetDinhBoNhiemAll();
            BindS_QuyetDinhBN.DataSource = _QDBoNhiemList;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _QDBoNhiemList.ApplyEdit();
                _QDBoNhiemList.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void grdu_QuyetDinhBoNhiem_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            _maQuyetDinh = ((QuyetDinhBoNhiem)BindS_QuyetDinhBN.Current).MaQuyetDinh;

            this.Close();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_QuyetDinhBoNhiem.UpdateData();
            if (grdu_QuyetDinhBoNhiem.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdu_QuyetDinhBoNhiem.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Form();
        }
        #endregion         

        #region Load
        private void grdu_QuyetDinhBoNhiem_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Hidden = true;

            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["MaQuyetDinh"].Hidden = true;

            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Maloaiquyetdinh"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["manguoicapquyetdinh"].Hidden = true;

            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Tennguoicap"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["TenLoaiQD"].Hidden = true;


            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["SoQuyetdinh"].Header.Caption = "Số Quyết Định";
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Ngayky"].Header.Caption = "Ngày Ký";
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Ngayhieuluc"].Header.Caption = "Ngày Hiệu Lực";
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Ghichu"].Header.Caption = "Ghi Chú";
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";


            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["SoQuyetdinh"].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Ngayky"].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Ngayhieuluc"].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Ghichu"].Header.Caption = "Ghi Chú";
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["NgayLap"].CellActivation = Activation.NoEdit;


            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["SoQuyetdinh"].Header.VisiblePosition = 0;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Ngayky"].Header.VisiblePosition = 1;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Ngayhieuluc"].Header.VisiblePosition = 2;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["Ghichu"].Header.VisiblePosition = 3;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 4;

            grdu_QuyetDinhBoNhiem.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_QuyetDinhBoNhiem.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;



            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["maquyetdinh"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["Machitiet"].Hidden = true;

            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["MaQLNhanVien"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["machucvucu"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["TenChuCdanhCu"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["MaPhongBancu"].Hidden = true;

            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["machucdanhcu"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["machucdanhmoi"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["madonvicu"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["madonvimoi"].Hidden = true;

            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["machuyenmonnghiepvucu"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["machuyenmonnghiepvumoi"].Hidden = true;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["TenChuyenmonNghiepVuCu"].Hidden = true;


            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["maNhanVien"].Header.Caption = "Mã Số";

            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["tennhanvien"].Header.Caption = "Họ Tên";
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["Tenbophancu"].Header.Caption = "Bộ Phận Cũ";
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["TenChucvucu"].Header.Caption = "Chức Vụ Cũ";
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["maphongbanmoi"].Header.Caption = "Bộ Phận Mới";
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["maChucvumoi"].Header.Caption = "Chức Vụ Mới";

            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["maNhanVien"].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["tennhanvien"].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["Tenbophancu"].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["TenChucvucu"].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["maphongbanmoi"].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["maChucvumoi"].CellActivation = Activation.NoEdit;

            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["ManhanVien"].Header.VisiblePosition = 0;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["tennhanvien"].Header.VisiblePosition = 1;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["Tenbophancu"].Header.VisiblePosition = 2;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["TenChucvucu"].Header.VisiblePosition = 3;


            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["maphongbanmoi"].Header.VisiblePosition = 6;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["MaChucvumoi"].Header.VisiblePosition = 7;

            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["Manhanvien"].Width = 100;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["tennhanvien"].Width = 200;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["Tenbophancu"].Width = 130;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["TenChucvucu"].Width = 150;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["maphongbanmoi"].Width = 150;
            grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[1].Columns["MaChucvumoi"].Width = 170;


            foreach (UltraGridColumn col in this.grdu_QuyetDinhBoNhiem.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###";
                }
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
        }
        #endregion

        private void tblblIn_Click(object sender, EventArgs e)
        {
            if (BindS_QuyetDinhBN.Count != 0)
            {
                string soQD = ((QuyetDinhBoNhiem)BindS_QuyetDinhBN.Current).SoQuyetDinh.ToString();
                ReportDocument Report = new ReportDocument();
                DataSet dataset = new DataSet();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_report_QuyetDinhBoNhiem";
                command.Parameters.AddWithValue("@SoQD", soQD);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_report_QuyetDinhBoNhiem;1";

                dataset.Tables.Add(table);
                Report.SetDataSource(dataset);
                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
        }

    }
}
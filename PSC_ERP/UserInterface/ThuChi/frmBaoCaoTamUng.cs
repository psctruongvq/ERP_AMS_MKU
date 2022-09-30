using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
   using ERP_Library.ThanhToan;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmBaoCaoTamUng : Form
    {
        DoiTuongAllList _list;
        int maChuongTrinh = 0;
        ChuongTrinhList _chuongTrinhList;
        long maDoiTuong = 0;
        public frmBaoCaoTamUng()
        {
            InitializeComponent();
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ERP_Library.ChuongTrinhList);
            this.bindingSource2_DoiTuong.DataSource = typeof(ERP_Library.DoiTuongAllList);
        }

        private void frmBaoCaoThuLao_Load(object sender, EventArgs e)
        {
            _list = DoiTuongAllList.GetDoiTuongAllList();
            DoiTuongAll item = DoiTuongAll.NewDoiTuongAll("Tất Cả");
            _list.Insert(0, item);
            this.bindingSource2_DoiTuong.DataSource = _list;
            //chuong trinh
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            DesignGridLUED_DoiTuong();
            DesignGrdLUED_ChuongTrinh();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            DataSet dataset;
            ReportDocument Report;
            frmHienThiReport dlg;
            SqlDataAdapter adapter;
            DataTable table;
            SqlCommand command1;
            SqlDataAdapter adapter1; 
            DataTable table1;
            DateTime ngayDauNam = new DateTime(DateTime.Today.Date.Year, 1, 1);
            switch (treeReport.SelectedNode.Name)
            {
                case "Node0":
                    Report = new Report.CongNo.BangKeTamUng();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_TamUngChiTietLong";
                    command.CommandTimeout = 0;

                    command.Parameters.AddWithValue("@TuNgay",Convert.ToDateTime(dateTuNgay1.Value));
                    command.Parameters.AddWithValue("@DenNgay",Convert.ToDateTime( dateDenNgay1.Value));
                    command.Parameters.AddWithValue("@MaDoiTuong",maDoiTuong);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);  
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_TamUngChiTietLong;1";
                    dataset.Tables.Add(table);

                    command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    adapter1 = new SqlDataAdapter(command1);
                    table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    dataset.Tables.Add(table1);

                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tuNgay",Convert.ToDateTime(dateTuNgay1.Value));
                    Report.SetParameterValue("_denNgay",Convert.ToDateTime(dateDenNgay1.Value));
                    //Report.SetParameterValue("_tenChuongTrinh", cmbu_ChuongTrinh.Text);
                    Report.SetParameterValue("_tenChuongTrinh", grdLUED_ChuongTrinh.Text);
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node1":
                    Report = new Report.CongNo.BangKeTamUngTongHop();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_TongHopTamUngLong";
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay1.Value)); 
                    command.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_TongHopTamUngLong;1";
                    dataset.Tables.Add(table);

                    command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    adapter1 = new SqlDataAdapter(command1);
                    table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    dataset.Tables.Add(table1);

                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay1.Value));
                    //if (cmbu_ChuongTrinh.Text == "")
                    if (grdLUED_ChuongTrinh.Text == "")
                    {
                        Report.SetParameterValue("_tenChuongTrinh", "Tất Cả");
                    }
                    else
                    {
                        //Report.SetParameterValue("_tenChuongTrinh", cmbu_ChuongTrinh.Text);
                        Report.SetParameterValue("_tenChuongTrinh", grdLUED_ChuongTrinh.Text);
                    }
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node_tamung":
                    Report = new Report.CongNo.rptGiayXacNhanTamUng();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_TongHopTamUngLong";
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay1.Value));
                    command.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_TongHopTamUngLong;1";
                    dataset.Tables.Add(table);

                    command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    adapter1 = new SqlDataAdapter(command1);
                    table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    dataset.Tables.Add(table1);

                    Report.SetDataSource(dataset);

                    if (maDoiTuong != 0)
                    {                    
                        if (dataset.Tables[0].Rows.Count != 0)
                        {
                            decimal _duno=0;
                            DataRow row = dataset.Tables[0].Rows[0];
                            _duno = (decimal)row["DuNo"];
                            Report.SetParameterValue("_BangChu",HamDungChung.DocTien(_duno) );
                        }
                        else
                            Report.SetParameterValue("_BangChu", "");
                    }
                    else
                        Report.SetParameterValue("_BangChu", "");
                    Report.SetParameterValue("p_lydotamung", txt_lydo.Text);
                    Report.SetParameterValue("p_denNgay", Convert.ToDateTime(dateDenNgay1.Value));

                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    //Report.SetParameterValue("_thuTruong", CaiDatKyTen.GetCaiDatKyTen(0).NhanThuTruong);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();            
                    break;
                case "Node_TamUngCap2":
                    Report = new Report.CongNo.BangKeTamUng_DonViCap2();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportTamUng_DVCap2";
                    command.CommandTimeout = 0;

                    command.Parameters.AddWithValue("@TuNgay",Convert.ToDateTime(dateTuNgay1.Value));
                    command.Parameters.AddWithValue("@DenNgay",Convert.ToDateTime(dateDenNgay1.Value));
                    command.Parameters.AddWithValue("@MaDoiTuong",maDoiTuong);
                    command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);  
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportTamUng_DVCap2;1";
                    dataset.Tables.Add(table);

                    command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_LayNguoiKyTenCongNo";
                    command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    adapter1 = new SqlDataAdapter(command1);
                    table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_LayNguoiKyTenCongNo;1";
                    dataset.Tables.Add(table1);

                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tuNgay",Convert.ToDateTime(dateTuNgay1.Value));
                    Report.SetParameterValue("_denNgay",Convert.ToDateTime(dateDenNgay1.Value));
                    //Report.SetParameterValue("_tenChuongTrinh", cmbu_ChuongTrinh.Text);
                    Report.SetParameterValue("_tenChuongTrinh", grdLUED_ChuongTrinh.Text);
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;

            }
        }
        private void ingiayxntamung()
        {           
                 
             

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            //if (cbDoiTuong.ActiveRow != null)
            //{
            //    maDoiTuong = Convert.ToInt64(cbDoiTuong.ActiveRow.Cells["MaDoiTuong"].Value);
            //}            
        }

        private void cmbNguoiLap_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbNguoiLap.Value != null && (int)cmbNguoiLap.Value != 0)
            //{
            //    _tenNguoiLap = "Tên Người Lập\r\n(Ký, họ tên)";
            //    tenNguoiLap = cmbNguoiLap.Text;
            //}
            //else if ((int)cmbNguoiLap.Value == 0)
            //{
            //    _tenNguoiLap = string.Empty;
            //    tenNguoiLap = string.Empty;
            //}
        }

        private void cmbPTDonVi_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbPTDonVi.Value != null && (int)cmbPTDonVi.Value != 0)
            //{
            //    _tenBanPhuTrach = "Ban Phụ Trách\r\n(Ký, họ tên)";
            //    tenBanPhuTrach = cmbPTDonVi.Text;
            //}
            //else if ((int)cmbPTDonVi.Value == 0)
            //{
            //    _tenBanPhuTrach = string.Empty;
            //    tenBanPhuTrach = string.Empty;
            //}
        }

        private void cmbPTTaiChinh_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbPTTaiChinh.Value != null && (int)cmbPTTaiChinh.Value != 0)
            //{
            //    _tenThuTruong = "Thủ Trưởng đơn vị\r\n(Ký, họ tên)";
            //    tenThuTruong = cmbPTTaiChinh.Text;
            //}
            //else if ((int)cmbPTTaiChinh.Value == 0)
            //{
            //    _tenThuTruong = string.Empty;
            //    tenThuTruong = string.Empty;
            //}
        }

    
        private void cbNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //HamDungChung.Combobox_InitializeLayout(sender, e);
            //FilterCombo f = new FilterCombo(cbDoiTuong, "TenDoiTuong");
            //foreach (UltraGridColumn col in this.cbDoiTuong.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            //    col.Hidden = true;
            //}
            //cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            //cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Khách Hàng";
            //cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 0;
            //cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 250;

            //cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            //cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            //cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 2;
            //cbDoiTuong.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 250;

            //cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Hidden = false;
            //cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.Caption = "Mã Quản Lý";
            //cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.VisiblePosition = 1;
            //cbDoiTuong.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Width = 250;
        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //HamDungChung.Combobox_InitializeLayout(sender, e);
            //FilterCombo f = new FilterCombo(cmbu_ChuongTrinh,  "TenChuongTrinh");
            //foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Hidden = true;
            //}
            //cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            //cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            //cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            //cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            //cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            //cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";
            //cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            //cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            //cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            //cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
        }

        private void cmbu_ChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbu_ChuongTrinh.ActiveRow!= null)
            //{
            //    maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.ActiveRow.Cells["MaChuongTrinh"].Value);
            //}
        }

        #region Devexpres

        private void DesignGridLUED_DoiTuong()
        {
            grdLUED_DoiTuong.Properties.DataSource = bindingSource2_DoiTuong;
            grdLUED_DoiTuong.Properties.ValueMember = "MaDoiTuong";
            grdLUED_DoiTuong.Properties.DisplayMember = "TenDoiTuong";
            HamDungChung.InitGridLookUpDev(grdLUED_DoiTuong, true, DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor);
            HamDungChung.ShowFieldGridLookUpDev2(grdLUED_DoiTuong, new string[] { "TenDoiTuong", "MaQLDoiTuong", "DiaChi" }, new string[] { "Tên khách hàng", "Mã quản lý", "Địa chỉ" }, new int[] { 200, 90, 200 },true);
            grdLUED_DoiTuong.EditValue = 0;
            this.grdLUED_DoiTuong.EditValueChanged += new System.EventHandler(this.grdLUED_DoiTuong_EditValueChanged);


        }
        private void DesignGrdLUED_ChuongTrinh()
        {
            grdLUED_ChuongTrinh.Properties.DataSource = bindingSource1_ChuongTrinh;
            grdLUED_ChuongTrinh.Properties.ValueMember = "MaChuongTrinh";
            grdLUED_ChuongTrinh.Properties.DisplayMember = "TenChuongTrinh";
            HamDungChung.InitGridLookUpDev(grdLUED_ChuongTrinh, true, DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor);
            HamDungChung.ShowFieldGridLookUpDev2(grdLUED_ChuongTrinh, new string[] { "TenChuongTrinh", "MaQL", "TenNguon" }, new string[] { "Tên khách hàng", "Mã quản lý", "Địa chỉ" }, new int[] { 200, 90, 150 },true);
            grdLUED_ChuongTrinh.EditValue = 0;
            this.grdLUED_ChuongTrinh.EditValueChanged += new System.EventHandler(this.grdLUED_ChuongTrinh_EditValueChanged);
        }

        private  void grdLUED_DoiTuong_EditValueChanged(object sender, EventArgs e)
        {
            if (grdLUED_DoiTuong.EditValue != null)
            {
                long madoituongTP = 0;
                if (long.TryParse(grdLUED_DoiTuong.EditValue.ToString(), out madoituongTP))
                {
                    maDoiTuong = madoituongTP;
                }
            }
        }

        private void grdLUED_ChuongTrinh_EditValueChanged(object sender, EventArgs e)
        {
            if (grdLUED_ChuongTrinh.EditValue != null)
            {
                int machuongtrinhTP = 0;
                if (int.TryParse(grdLUED_ChuongTrinh.EditValue.ToString(), out machuongtrinhTP))
                {
                    maChuongTrinh = machuongtrinhTP;
                }
            }
        }

        #endregion//Devexpress


    }
}
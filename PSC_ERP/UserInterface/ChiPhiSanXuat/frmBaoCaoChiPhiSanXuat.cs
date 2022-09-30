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
    public partial class frmBaoCaoChiPhiSanXuat : Form
    {
        BoPhanList _BoPhanList;
     
        int maChuongTrinh = 0; int userID = 0;
       int maNguon = 0;       
        long maChungTu = 0;
        int maChiTietGiayXacNhan = 0;
        
      
        
        NguonList _nguonList;
        ChuongTrinhList _chuongTrinhList;
        ChungTuRutGonList _chungTuList;
        ChiTietGiayXacNhanList _gxnList;
        

        public frmBaoCaoChiPhiSanXuat()
        {
            InitializeComponent();
            bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.bindingSource1_Nguon.DataSource =typeof(NguonList);           
            this.bindingSource1_ChuongTrinh.DataSource =typeof(ChuongTrinhList);            
            this.bindingSource1_ChungTu.DataSource =typeof(ChungTuRutGonList);            
          
        }

        private void frmBaoCaoThuLao_Load(object sender, EventArgs e)
        {
            

            _nguonList = NguonList.GetNguonList();
            Nguon itemAdd = Nguon.NewNguon("Tất Cả");         
            _nguonList.Insert(0, itemAdd);
            this.bindingSource1_Nguon.DataSource = _nguonList;
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList();
            ChuongTrinh itemCT = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemCT);
            bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;
            //_chungTuList = ChungTuRutGonList.GetChungTuRutGonList();
            //ChungTuRutGon itemChT = ChungTuRutGon.NewChungTuRutGon("Tất Cả");
            //_chungTuList.Insert(0, itemChT);
            //bindingSource1_ChungTu.DataSource = _chungTuList;
            //_gxnList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanList();
        
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            DataSet dataset;
            ReportDocument Report;
            frmHienThiReport dlg;
            SqlDataAdapter adapter;
            DataTable table;           
            switch (treeReport.SelectedNode.Name)
            {
                case "Node1":
                    Report = new Report.ChiPhiSanXuat.BaoCaoChiPhiSanXuat();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReportTongHopChiPhiChuongTrinh";       
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaNguon", maNguon);
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay1.Value));
                    command.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "ReportTongHopChiPhiChuongTrinh;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay1.Value).Date);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay1.Value).Date);
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                    Report.SetParameterValue("_tenChuongTrinh", cmbu_ChuongTrinh.Text);
                 
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node2":
                    Report = new Report.ChiPhiSanXuat.BaoCaoChiPhiSanXuatChiTiet();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReportTongHopChiPhiChuongTrinhChiTiet";
                    command.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    command.Parameters.AddWithValue("@MaNguon", maNguon);
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay1.Value));
                    command.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "ReportTongHopChiPhiChuongTrinhChiTiet;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay1.Value).Date);
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay1.Value).Date);
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                    Report.SetParameterValue("_tenChuongTrinh", cmbu_ChuongTrinh.Text);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
             

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        private void cmbu_ChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.ActiveRow != null)
            {
                maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.Value);
            }
        }

       

        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (treeReport.SelectedNode.Name)
            {
                //case "Node1":
                //    gbChiTiet.Enabled = false;
                //    lbGhiChu.Text = "Báo Cáo thù lao chi tiết cho từng nhân viên điều kiện: Từ ngày->Đến ngày";
                //    break;
                //case "Node2":
                //    gbChiTiet.Enabled = false;
                //    lbGhiChu.Text = "Báo Cáo thù lao chi tiết cho từng nhân viên theo phiếu chi điều kiện: Từ ngày->Đến ngày";
                //    break;
                //case "Node3":
                //    gbChiTiet.Enabled = true;
                //    lbGhiChu.Text = "Báo Cáo thù lao theo bộ phận được phân quyền điều kiện: Điều kiện chi tiết";
                //    break;
                //case "Node4":
                //    gbChiTiet.Enabled = true;
                //    lbGhiChu.Text = "Báo Cáo thù lao chuyển đi ngân hàng của nhân viên từng bộ phận được phân phân quyền điều kiện: Điều kiện chi tiết";
                //    break;
                //default:
                //    lbGhiChu.Text = "";
                //    break;
                    
            }
        }

        private void cbNguon_ValueChanged(object sender, EventArgs e)
        {
            if (cbNguon.ActiveRow != null)
            {
                maNguon = Convert.ToInt32(cbNguon.Value);
            }
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhListByNguon(maNguon);
            ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("Tất Cả");
            _chuongTrinhList.Insert(0, itemChuongTrinh);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;
        }

     

  

        private void cbNguon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbNguon, "TenNguon");
            foreach (UltraGridColumn col in this.cbNguon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 0;
            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Width = 350;
            
        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_ChuongTrinh, "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width =270;           
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
        }

     /*
        private void cbChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChungTu, "So");
            foreach (UltraGridColumn col in this.ultraCombo1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Olive;//x =  //= System.Drawing.w;//Navy
              //  col.Hidden = true;
            }
            ultraCombo1.DisplayLayout.Bands[0].Columns["So"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["So"].Header.Caption = "Số Chứng Từ";
            ultraCombo1.DisplayLayout.Bands[0].Columns["So"].Header.VisiblePosition = 0;

            ultraCombo1.DisplayLayout.Bands[0].Columns["Ngay"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["Ngay"].Header.Caption = "Ngày";
            ultraCombo1.DisplayLayout.Bands[0].Columns["Ngay"].Header.VisiblePosition = 1;
            ultraCombo1.DisplayLayout.Bands[0].Columns["Ngay"].Width = 90;

            ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            ultraCombo1.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 2;

            //ultraCombo1.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 250;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;

            //ultraCombo1.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 4;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 250;
        }
        */
        private void cbChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (cbChungTu.Value != null)
            {
                maChungTu = Convert.ToInt32(cbChungTu.Value);
            }
        }

      

        private void cbChungTu_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChungTu, "SoChungTu");
            foreach (UltraGridColumn col in this.cbChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                if (col.DataType == typeof(decimal))
                {
                    col.Format = "###,###,###,####,###";
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;

            //cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            //cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            //cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
        }

        private void cbChiTietGiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChiTietGiayXacNhan, "TenGiayXacNhan");
        }
    }
}
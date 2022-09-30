using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace PSC_ERP
{
    public partial class frmHopDongLaoDongGiaHan : Form
    {
        BoPhanList _BophanList = BoPhanList.NewBoPhanList();
        HinhThucHopDongList _HinhThucHopDongList;
        ThongTinNhanVienTongHopList _ThongTinNVTHList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
        HDLaoDongList _DSNhanvienChuaGiaHan = HDLaoDongList.NewHDLaoDongList();
        GiaHanHopDongList _GiaHanList;
        int ThoiHanHD = 0;
       // private ListViewColumnSorter lvwColumnSorter;
        public frmHopDongLaoDongGiaHan()
        {
            InitializeComponent();

            //lvwColumnSorter = new ListViewColumnSorter();
           // this.lstvDsnguon.ListViewItemSorter = lvwColumnSorter;

            this.Load_Source();
        }

        #region Load
        private void Load_Source()
        {
            try
            {
                _BophanList = BoPhanList.GetBoPhanList();
                BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Tất Cả");
                _BophanList.Insert(0, _BoPhan);
                BindS_Bophan.DataSource = _BophanList;
                _HinhThucHopDongList = HinhThucHopDongList.GetHinhThucHopDongList();
                BindS_HinhthucHD.DataSource = _HinhThucHopDongList;
                BindS_HinhthucHDCD.DataSource = _HinhThucHopDongList;
                dtpu_tungay.Value = DateTime.Now;
                dtp_Ngayky.Value = DateTime.Now;
                dtpu_Denngay.Value = DateTime.Now;
                dtmp_NgayLap.Value = DateTime.Now;
                txt_NguoiLap.Text = ERP_Library.Security.CurrentUser.Info.UserID.ToString();
            }
            catch (ApplicationException)
            {

            }
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_Bophan.DisplayLayout.Bands[0],
              new string[2] { "Tenbophan", "mabophan" },
              new string[2] { "Bộ Phận", "Mã bộ phận" },
              new int[2] { cmbu_Bophan.Width, 90 },
              new Control[2] { null, null },
              new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
              new bool[2] { false, false });
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["Tenbophan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;
        }

        private void cmbu_HinhThucHopDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_HinhThucHopDong.DisplayLayout.Bands[0],
              new string[2] { "Tenhinhthuchopdong", "Mahinhthuchopdong" },
              new string[2] { "Hình Thức Hợp Đồng", "Mã hình thức" },
              new int[2] { cmbu_HinhThucHopDong.Width , 90 },
              new Control[2] { null, null },
              new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
              new bool[2] { false, false });
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["Tenhinhthuchopdong"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["mahinhthuchopdong"].Hidden = true;
        }

        private void grdu_DsDaChuyenDoiHD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Magiahanghopdong"].Hidden = true; 
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["MaHopDongLaoDong"].Hidden = true; 
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["MaHinhThucHopDong"].Hidden = true;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["PhantramBHXH"].Hidden = true;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["PhantramBHYT"].Hidden = true;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["SoTienCongDoan"].Hidden = true;

            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.Caption = "Họ Tên";
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Tennhanvien"].Width = 120;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellActivation = Activation.NoEdit;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["SoHDLD"].Header.Caption = "Số Hợp Đồng";
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["SoHDLD"].Width = 100;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["SoHDLD"].CellActivation = Activation.NoEdit;

            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["TenHinhthucHopdong"].Header.Caption = "Loại Hợp Đồng";
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["TenHinhthucHopdong"].Width = 120;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Ngayky"].Header.Caption = "Ngày Ký";
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Ngayky"].Width = 90;

            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Tungay"].Header.Caption = "Từ Ngày";
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Tungay"].Width = 90;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Tungay"].CellActivation = Activation.NoEdit;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Denngay"].Header.Caption = "Đến Ngày";
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Denngay"].Width = 90;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Denngay"].CellActivation = Activation.NoEdit;

            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["NgheNghiep"].Header.Caption = "Nghề Nghiệp";
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["NgheNghiep"].Width = 100;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["CongviecphaiLam"].Header.Caption = "Công Việc Phải Làm";
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["CongviecphaiLam"].Width = 150;


            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["TenHinhthucHopdong"].Header.VisiblePosition = 0;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.VisiblePosition = 1;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["SoHDLD"].Header.VisiblePosition = 2;  
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Ngayky"].Header.VisiblePosition = 3;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Tungay"].Header.VisiblePosition =4;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["Denngay"].Header.VisiblePosition = 5;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["NgheNghiep"].Header.VisiblePosition = 6;
            grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns["CongviecphaiLam"].Header.VisiblePosition = 7;         

            foreach (UltraGridColumn col in this.grdu_DsDaChuyenDoiHD.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
            this.grdu_DsDaChuyenDoiHD.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_DsDaChuyenDoiHD.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

      
        private void Load_Nguon()
        {
            try
            {
                if (cmbu_Bophan.Value != null)
                {
                    if (cmbu_HinhThucHopDong.Value == null)
                    {
                        _DSNhanvienChuaGiaHan = HDLaoDongList.GetHDLaoDong_denhanchuyendoiHD((int)cmbu_Bophan.Value, Convert.ToDateTime(dtpu_HanHD.Value));
                    }
                    else
                    {
                        _DSNhanvienChuaGiaHan = HDLaoDongList.GetHDLaoDong_denhanchuyendoiHDByLoaiHD((int)cmbu_Bophan.Value, Convert.ToDateTime(dtpu_HanHD.Value), (int)cmbu_HinhThucHopDong.Value);
                    }
                    lstvDsnguon.Items.Clear();
                    for (int i = 0; i < _DSNhanvienChuaGiaHan.Count; i++)
                    {
                        ListViewItem lstnguonitem;
                        lstnguonitem = lstvDsnguon.Items.Add(_DSNhanvienChuaGiaHan[i].MaHopDongLaoDong.ToString());
                        lstnguonitem.SubItems.Add(_DSNhanvienChuaGiaHan[i].SoHopDong.ToString());
                        lstnguonitem.SubItems.Add(_DSNhanvienChuaGiaHan[i].TenNhanVien.ToString());
                        lstnguonitem.SubItems.Add(_DSNhanvienChuaGiaHan[i].TenHinhThucHD.ToString());
                        lstnguonitem.SubItems.Add(DateTime.Parse(_DSNhanvienChuaGiaHan[i].NgayKy.ToString()).ToString("dd/MM/yyyy"));
                        lstnguonitem.SubItems.Add(DateTime.Parse(_DSNhanvienChuaGiaHan[i].TuNgay.ToString()).ToString("dd/MM/yyyy"));
                        lstnguonitem.SubItems.Add(DateTime.Parse(_DSNhanvienChuaGiaHan[i].DenNgay.ToString()).ToString("dd/MM/yyyy"));

                    }
                }
                lblTChuagiahan.Text = "Tổng Số : " + _DSNhanvienChuaGiaHan.Count;        
            }
            catch (ApplicationException)
            {

            }             
        }

        private void Load_Dich()
        {
            try
            {
               
                    if (cmbu_Bophan.Value != null)
                    {
                        _GiaHanList = GiaHanHopDongList.GetGiaHanHopDongByBoPhan((int)cmbu_Bophan.Value);
                        BindS_DSDaChuyenDoi.DataSource = _GiaHanList;
                    }
               
            }
            catch (ApplicationException)
            {

            }
            ultraLabel1.Text = "Tổng Số : " + _GiaHanList.Count;
        }

        private void cmbu_HinhThucHopDongCD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_HinhThucHopDongCD.DisplayLayout.Bands[0],
              new string[2] { "Tenhinhthuchopdong", "Mahinhthuchopdong" },
              new string[2] { "Hình Thức Hợp Đồng", "Mã hình thức" },
              new int[2] { cmbu_HinhThucHopDongCD.Width, 90 },
              new Control[2] { null, null },
              new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
              new bool[2] { false, false });
            cmbu_HinhThucHopDongCD.DisplayLayout.Bands[0].Columns["Tenhinhthuchopdong"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_HinhThucHopDongCD.DisplayLayout.Bands[0].Columns["mahinhthuchopdong"].Hidden = true;

        }
        #endregion 
 
        #region Event
        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbu_Bophan.Value != null)
                {
                    _ThongTinNVTHList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_Bophan((int)cmbu_Bophan.Value,0);
                    BindS_NhanvienCanCD.DataSource = _ThongTinNVTHList;
                }
            }
            catch (ApplicationException)
            {

            }
            this.Load_Nguon();
            this.Load_Dich();
        }

        private void cmbu_HinhThucHopDong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_HinhThucHopDong.Value != null)
            {
                this.Load_Nguon();
            }
        }

        private void cmbu_HinhThucHopDongCD_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_HinhThucHopDongCD.Value != null)
            {
                this.XulythoihanHD((int)cmbu_HinhThucHopDongCD.Value);
            }
        }

        private void tsllblSetting_Click(object sender, EventArgs e)
        {
            frmHDLD_Default frmDefault = new frmHDLD_Default(2);
            frmDefault.ShowDialog();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Util util = new Util();
            try
            {               
                _GiaHanList.ApplyEdit();
                _GiaHanList.Save();
                MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, util.luuthatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DsDaChuyenDoiHD.ActiveRow != null)
            {
                grdu_DsDaChuyenDoiHD.DeleteSelectedRows();
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Source();
            this.Load_Nguon();
            this.Load_Dich();
            cmbu_HinhThucHopDong.Value = null;
        }        

        private void tlslblKymoi_Click(object sender, EventArgs e)
        {
            long ManguoiLap = 0;
            if (txt_NguoiLap.Text != "")
            {
                ManguoiLap = Convert.ToInt64(txt_NguoiLap.Text.Trim());
            }
            if (cmbu_HinhThucHopDongCD.Value == null)
            {
                MessageBox.Show(this, "Chọn Loại Hợp Đồng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (Convert.ToDateTime(dtpu_Denngay.Value) <= Convert.ToDateTime(dtpu_tungay.Value) && ThoiHanHD!=0)// Chi kiem tra ngay khi khong la Loai Hop dong vo thoi han
            {
                MessageBox.Show(this, "Ngày Không Hợp Lệ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            DialogResult = MessageBox.Show(this, "Ký Mới Hợp Đồng lao Động Cho Các Nhân Viên Được Chọn (Yes/No) ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                {
                    if (lstvDsnguon.Items[i].Checked)
                    {
                        GiaHanHopDong.ThemvaoHopDong(Convert.ToInt64(lstvDsnguon.Items[i].Text),(int)cmbu_HinhThucHopDongCD.Value, Convert.ToDateTime(dtp_Ngayky.Value), Convert.ToDateTime(dtpu_tungay.Value), Convert.ToDateTime(dtpu_Denngay.Value),txtu_NgheNghiep.Text, txt_Congviecphailam.Text);
                    }
                }
                this.Load_Nguon();
                this.Load_Dich();
            }
        }

        private void chkNguon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNguon.Checked == true)
            {
                for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                {
                    lstvDsnguon.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                {
                    lstvDsnguon.Items[i].Checked = false;
                }
            }
        }

        private void cmbu_Nhanvien_ValueChanged(object sender, EventArgs e)
        {
            this.Load_Dich();
        }

        private void tslInLoat_Click(object sender, EventArgs e)
        {
            frmInLoatHDLD frmInLoat = new frmInLoatHDLD(1);
            frmInLoat.Show();
        }

        private void mẫuNhàMáyIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.InHDLD("NMI");
        }

        private void mẫuSpacificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.InHDLD("SPACIFIC");
        }

        #endregion

        #region Process
        private void XulythoihanHD(int MahinhthucHD)
        {
            if (MahinhthucHD != 0)
            {
                HinhThucHopDong _HinhthucHD = HinhThucHopDong.GetHinhThucHopDong(MahinhthucHD);
                if (_HinhthucHD.DonViKyHan == "Tháng")
                {
                    dtpu_Denngay.Value = Convert.ToDateTime(dtpu_tungay.Value).AddMonths(Convert.ToInt32(_HinhthucHD.ThoiHanHopDong));
                    ThoiHanHD = Convert.ToInt32(_HinhthucHD.ThoiHanHopDong);
                }
                else
                {
                    dtpu_Denngay.Value = Convert.ToDateTime(dtpu_tungay.Value).AddYears(Convert.ToInt32(_HinhthucHD.ThoiHanHopDong));
                    ThoiHanHD = Convert.ToInt32(_HinhthucHD.ThoiHanHopDong);
                }
                if (_HinhthucHD.ThoiHanHopDong == 0)
                {
                    dtpu_Denngay.Nullable = true;
                    dtpu_Denngay.Value = null;
                    dtpu_Denngay.NullText = "<Trống>";
                }

            }
        }
        private void InHDLD(string Mau)
        {
            ReportDocument Report;
            if (Mau=="NMI")
            {
                Report = new ReportDocument();
            }
            else
            {
                Report = new ReportDocument();
            }
            long manhanvien = 0;
            if (grdu_DsDaChuyenDoiHD.Selected.Rows.Count !=1)
            {
                MessageBox.Show(this, "Chọn Một Để In !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                manhanvien = HDLaoDong.GetHDLaoDong(GiaHanHopDong.GetGiaHanHopDong((long)grdu_DsDaChuyenDoiHD.Selected.Rows[0].Cells["MaGiaHangHopDong"].Value).MaHopDongLaoDong).MaNhanVien;
                 
                int Loai = 2;
                DataSet dataset = new DataSet();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "spd_report_TblnsHopdonglaodongGiahan";
                command.Parameters.AddWithValue("@manhanvien", manhanvien);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_report_TblnsHopdonglaodongGiahan;1";

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "hdld_CongTy";
                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "hdld_CongTy;1";

                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.StoredProcedure;
                command2.CommandText = "spd_Report_tblnsHopdonglaodong_DieuKhoan";
                command2.Parameters.AddWithValue("@Loai", Loai);
                command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                table2.TableName = "spd_Report_tblnsHopdonglaodong_DieuKhoan;1";

                dataset.Tables.Add(table);
                dataset.Tables.Add(table1);
                dataset.Tables.Add(table2);

                Report.SetDataSource(dataset);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
        }      
        #endregion                  


    }
}
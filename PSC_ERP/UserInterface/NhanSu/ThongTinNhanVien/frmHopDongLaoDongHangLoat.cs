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
    public partial class frmHopDongLaoDongHangLoat : Form
    {
        BoPhanList _BophanList = BoPhanList.NewBoPhanList();
        HinhThucHopDongList _HinhThucHopDongList;
        ThongTinNhanVienTongHopList _ThongTinNVTHList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
        DanhsachNVTheoHDList _DSNhanvien = DanhsachNVTheoHDList.NewDanhsachNVTheoHDList();
        HDLaoDongList _HDLaoDongList;
        int ThoihanHD=0;
        //private ListViewColumnSorter lvwColumnSorter;
        public frmHopDongLaoDongHangLoat()
        {
            InitializeComponent();
           // lvwColumnSorter = new ListViewColumnSorter();
           // this.lstvDsnguon.ListViewItemSorter = lvwColumnSorter;
            this.Load_Source();

        }

        #region Load
        private void Load_Source()
        {
            try
            {
                _BophanList = BoPhanList.GetBoPhanList();
                BindS_Bophan.DataSource = _BophanList;
                _HinhThucHopDongList = HinhThucHopDongList.GetHinhThucHopDongList();
                BindS_HinhthucHD.DataSource = _HinhThucHopDongList;                
                dtpu_tungay.Value = DateTime.Now;
                dtp_Ngayky.Value = DateTime.Now;
                dtpu_Denngay.Value = DateTime.Now;
                dtmp_NgayLap.Value = DateTime.Now;
                txt_NguoiLap.Text = ERP_Library.Security.CurrentUser.Info.UserID.ToString();
                txtu_NgheNghiep.Text = "Công Nhân May";
            }
            catch (ApplicationException)
            {

            }
        }

        private void cmbu_TracuuHTHD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_TracuuHTHD.DisplayLayout.Bands[0],
            new string[2] { "Tenhinhthuchopdong", "Mahinhthuchopdong" },
            new string[2] { "Hình Thức Hợp Đồng", "Mã hình thức" },
            new int[2] { cmbu_TracuuHTHD.Width, 90 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });
            cmbu_TracuuHTHD.DisplayLayout.Bands[0].Columns["Tenhinhthuchopdong"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_TracuuHTHD.DisplayLayout.Bands[0].Columns["mahinhthuchopdong"].Hidden = true;

        }

        private void cmbu_Bophan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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
        
        private void cmbu_HinhThucHopDong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_HinhThucHopDong.DisplayLayout.Bands[0],
            new string[2] { "Tenhinhthuchopdong", "Mahinhthuchopdong" },
            new string[2] { "Hình Thức Hợp Đồng", "Mã hình thức" },
            new int[2] { cmbu_HinhThucHopDong.Width, 90 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["Tenhinhthuchopdong"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["mahinhthuchopdong"].Hidden = true;
        }

        private void grdu_Dshopdong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["MaHopDongLaoDong"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["MaNguoiKy"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["MaChucDanh"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["DieuKhoanKhac"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["ThoiGianLamViec"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["DungCuLamViec"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["PhuongTienDiLamViec"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["CheDoDaoTao"].Hidden = true;            
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Mucluong"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Hinhthuctraluong"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["MaHinhThucHopDong"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["HeSoBHXH"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["HeSoBHYT"].Hidden = true;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["SoTienCongDoan"].Hidden = true;
            


            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["TenHinhThucHD"].Header.Caption = "Loại Hợp Đồng";
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["TenHinhThucHD"].CellActivation = Activation.NoEdit;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["TenHinhThucHD"].Width = 120;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.Caption = "Họ Tên";
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Tennhanvien"].Width = 120;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellActivation = Activation.NoEdit;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Tungay"].Header.Caption = "Từ Ngày";
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Tungay"].Width = 95;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Tungay"].CellActivation = Activation.NoEdit;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Denngay"].Header.Caption = "Đến Ngày";
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Denngay"].Width = 95;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Denngay"].CellActivation = Activation.NoEdit;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.Caption = "Số Hợp Đồng";
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["SoHopDong"].Width = 95;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["SoHopDong"].CellActivation = Activation.NoEdit;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["NgayKy"].Header.Caption = "Ngày Ký";
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["NgayKy"].Width = 95;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["NgayKy"].CellActivation = Activation.NoEdit;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 200;         
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["NgheNghiep"].Header.Caption = "Nghề Nghiệp";
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["NgheNghiep"].Width = 100;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["CongviecphaiLam"].Header.Caption = "Công Việc Phải Làm";
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["CongviecphaiLam"].Width = 150;

            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["TenHinhThucHD"].Header.VisiblePosition = 0;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.VisiblePosition = 1;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Tungay"].Header.VisiblePosition = 2;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["Denngay"].Header.VisiblePosition = 3;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.VisiblePosition = 4;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["NgayKy"].Header.VisiblePosition = 5;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 6;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["NgheNghiep"].Header.VisiblePosition = 7;
            grdu_Dshopdong.DisplayLayout.Bands[0].Columns["CongviecphaiLam"].Header.VisiblePosition = 8; 

            foreach (UltraGridColumn col in this.grdu_Dshopdong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }          
            this.grdu_Dshopdong.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_Dshopdong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }

        private void Load_Nguon()
        {
            
                try
                {
                    if (cmbu_Bophan.Value != null)
                    {
                        _DSNhanvien = DanhsachNVTheoHDList.GetNhanvien_ChuakyHD((int)cmbu_Bophan.Value, Convert.ToDateTime(dtp_VaoTungay.Value), Convert.ToDateTime(dtp_VaoDenngay.Value));
                    }
                    else
                    {
                        _DSNhanvien = DanhsachNVTheoHDList.GetNhanvien_ChuakyHDByNgay(Convert.ToDateTime(dtp_VaoTungay.Value),Convert.ToDateTime(dtp_VaoDenngay.Value));
                    }                    
                    lstvDsnguon.Items.Clear();
                    for (int i = 0; i < _DSNhanvien.Count; i++)
                    {
                        ListViewItem lstnguonitem;
                        lstnguonitem = lstvDsnguon.Items.Add(_DSNhanvien[i].MaNhanVien.ToString());
                        lstnguonitem.SubItems.Add(_DSNhanvien[i].MaQLNhanVien.ToString());
                        lstnguonitem.SubItems.Add(_DSNhanvien[i].TenNhanVien.ToString());
                        lstnguonitem.SubItems.Add(_DSNhanvien[i].TenChucVu.ToString());
                        lstnguonitem.SubItems.Add(DateTime.Parse(_DSNhanvien[i].NgayVaoLam.ToString()).ToString("dd/MM/yyyy"));
                    }
                }
                catch (ApplicationException)
                {

                }
                lblTChuaky.Text = "Tổng Số : " + _DSNhanvien.Count;
        }

        private void Load_Dich()
        {
            try
            {
                if (cmbu_Nhanvien.Value == null)
                {
                    if (cmbu_Bophan.Value != null && cmbu_TracuuHTHD.Value == null)
                    {
                        _HDLaoDongList = HDLaoDongList.GetHDLaoDongListByBoPhan((int)cmbu_Bophan.Value);
                        BindS_DSkyHD.DataSource = _HDLaoDongList;
                    }
                    else if (cmbu_Bophan.Value != null && cmbu_TracuuHTHD.Value != null)
                    {
                        _HDLaoDongList = HDLaoDongList.GetHDLaoDongListByBoPhanVaLoaiHD((int)cmbu_Bophan.Value, (int)cmbu_TracuuHTHD.Value);
                        BindS_DSkyHD.DataSource = _HDLaoDongList;
                    }
                    else if (cmbu_Bophan.Value == null && cmbu_TracuuHTHD.Value != null)
                    {
                        _HDLaoDongList = HDLaoDongList.GetHDLaoDongListByLoaiHD((int)cmbu_TracuuHTHD.Value);
                        BindS_DSkyHD.DataSource = _HDLaoDongList;
                    }
                }
                else
                {
                    _HDLaoDongList = HDLaoDongList.GetHDLaoDongList((long)cmbu_Nhanvien.Value);
                    BindS_DSkyHD.DataSource = _HDLaoDongList;
                }
            }
            catch (ApplicationException)
            {

            }
            lblTdaky.Text = "Tổng Số : " + _HDLaoDongList.Count;
        }
     
        private void cmbu_Nhanvien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_Nhanvien.DisplayLayout.Bands[0],
             new string[2] { "MaQLNHanvien", "Tennhanvien" },
             new string[2] { "Mã Số", "Họ Tên" },
             new int[2] { 100, cmbu_Nhanvien.Width - 100 },
             new Control[2] { null, null },
             new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
             new bool[2] { false, false });
            cmbu_Nhanvien.DisplayLayout.Bands[0].Columns["MaQLNHanvien"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_Nhanvien.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellAppearance.TextHAlign = HAlign.Left;
        }
        #endregion

        #region Event
        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                _ThongTinNVTHList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_Bophan((int)cmbu_Bophan.Value,0);
                BindS_Nhanvien.DataSource = _ThongTinNVTHList;
            }
            this.Load_Nguon();
            this.Load_Dich();
        }

        private void cmbu_HinhThucHopDong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_HinhThucHopDong.Value != null)
            {
                this.XulythoihanHD((int)cmbu_HinhThucHopDong.Value);
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {          
            this.Load_Nguon();
            this.Load_Dich();
            cmbu_HinhThucHopDong.Value = null;

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_Dshopdong.ActiveRow != null)
            {
                grdu_Dshopdong.DeleteSelectedRows();
            }        
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Util util = new Util();
            try
            {
                _HDLaoDongList.ApplyEdit();
                _HDLaoDongList.Save();
                MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ApplicationException)
            {

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

        private void cmbu_TracuuHTHD_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_TracuuHTHD.Value != null)
            {
                this.Load_Dich();
            }
        }

        private void tlslblKymoi_Click(object sender, EventArgs e)
        {
            long ManguoiLap = 0;
            if (txt_NguoiLap.Text != "")
            {
                ManguoiLap = Convert.ToInt64(txt_NguoiLap.Text.Trim());
            }
            if (cmbu_HinhThucHopDong.Value == null)
            {
                MessageBox.Show(this, "Chọn Loại Hợp Đồng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (Convert.ToDateTime(dtpu_Denngay.Value) < Convert.ToDateTime(dtpu_tungay.Value) && ThoihanHD !=0) // Chi kiem tra ngay khi khong la Loai Hop dong vo thoi han
            {
                MessageBox.Show(this, "Ngày Không Hợp Lệ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            DialogResult = MessageBox.Show(this, "Ký Mới Hợp Đồng Lao Động Cho Các Nhân Viên Được Chọn (Yes/No) ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                {
                    if (lstvDsnguon.Items[i].Checked == true)
                    {
                        HDLaoDong.ThemvaoHopDong(Convert.ToInt64(lstvDsnguon.Items[i].Text), lstvDsnguon.Items[i].SubItems[1].Text, (int)cmbu_HinhThucHopDong.Value, Convert.ToDateTime(dtp_Ngayky.Value), Convert.ToDateTime(dtpu_tungay.Value), Convert.ToDateTime(dtpu_Denngay.Value), ManguoiLap, Convert.ToDateTime(dtmp_NgayLap.Value), txt_ghichu.Text, txtu_NgheNghiep.Text, txtu_CongViecPhaiLam.Text);
                    }
                }
                this.Load_Nguon();
                this.Load_Dich();
            }
        }

        private void tlslblInloat_Click(object sender, EventArgs e)
        {
            frmInLoatHDLD frmInLoat = new frmInLoatHDLD(0);
            frmInLoat.Show();
        }

        private void hĐLĐToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.InHDLD();
        }

        private void hĐThửViệcHọcViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.InHDThuViecHocViec();
        }

        private void điềuKhoảnHĐLĐToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHDLD_Default frmDefault = new frmHDLD_Default(1);
            frmDefault.ShowDialog();
        }

        private void điềuKhoảnThửViệcHọcViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHDLD_Default frmDefault = new frmHDLD_Default(3);
            frmDefault.ShowDialog();
        }

        private void lstvDsnguon_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //if (e.Column == lvwColumnSorter.SortColumn)
            //{
            //    if (lvwColumnSorter.Order == SortOrder.Ascending)
            //    {
            //        lvwColumnSorter.Order = SortOrder.Descending;
            //    }
            //    else
            //    {
            //        lvwColumnSorter.Order = SortOrder.Ascending;
            //    }
            //}
            //else
            //{
            //    lvwColumnSorter.SortColumn = e.Column;
            //    lvwColumnSorter.Order = SortOrder.Ascending;
            //}
            //this.lstvDsnguon.Sort();
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
                    ThoihanHD = Convert.ToInt32(_HinhthucHD.ThoiHanHopDong);
                }
                else
                {
                    dtpu_Denngay.Value = Convert.ToDateTime(dtpu_tungay.Value).AddYears(Convert.ToInt32(_HinhthucHD.ThoiHanHopDong));
                    ThoihanHD = Convert.ToInt32(_HinhthucHD.ThoiHanHopDong);
                }
                if (_HinhthucHD.ThoiHanHopDong == 0)
                {
                    dtpu_Denngay.Nullable = true;
                    dtpu_Denngay.Value = null;
                    dtpu_Denngay.NullText = "<Trống>";
                }

            }
        }

        private void InHDLD()
        {
            ReportDocument Report = new ReportDocument();
            if (cmbu_Nhanvien.Value != null)
            {
                DataSet dataset = new DataSet();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "spd_report_tblnsHopdonglaodong";
                command.Parameters.AddWithValue("@MaNhanVien", (long)cmbu_Nhanvien.Value);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_report_tblnsHopdonglaodong;1";

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
                command2.Parameters.AddWithValue("@Loai", 1);
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

        private void InHDThuViecHocViec()
        {
            ReportDocument Report = new ReportDocument();
            if (cmbu_Nhanvien.Value != null)
            {
                DataSet dataset = new DataSet();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "spd_report_tblnsHopdonglaodong_ThuViecHocViec";
                command.Parameters.AddWithValue("@MaNhanVien", (long)cmbu_Nhanvien.Value);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_report_tblnsHopdonglaodong_ThuViecHocViec;1";

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
                command2.Parameters.AddWithValue("@Loai", 3);
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

        private void frmHopDongLaoDongHangLoat_Load(object sender, EventArgs e)
        {
            dtpu_Denngay.Value = DateTime.Now;
            dtpu_tungay.Value = DateTime.Now;
            dtp_VaoDenngay.Value = DateTime.Now;
            dtp_VaoTungay.Value = Convert.ToDateTime(dtp_VaoDenngay.Value).AddDays(-7);
        }

        /*private class ListViewColumnSorter : IComparer
        {
            private int ColumnToSort;
            private SortOrder OrderOfSort;
            private CaseInsensitiveComparer ObjectCompare;
            public ListViewColumnSorter()
            {
                // Initialize the column to '0'
                ColumnToSort = 0;

                // Initialize the sort order to 'none'
                OrderOfSort = SortOrder.None;

                // Initialize the CaseInsensitiveComparer object
                ObjectCompare = new CaseInsensitiveComparer();
            }
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX, listviewY;
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

                if (OrderOfSort == SortOrder.Ascending)
                {
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    return (-compareResult);
                }
                else
                {
                    return 0;
                }
            }
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }
        }*/


        #endregion

    

    }
}
using System;
using System.Collections.Generic;
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
    public partial class frmThuViecHocViec : Form
    {
        BoPhanList _BophanList = BoPhanList.NewBoPhanList();
        BoPhanList _BophanHCTVList = BoPhanList.NewBoPhanList();
        ThongTinNhanVienTongHopList _ThongTinNVTHList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();        
        DanhsachNVTheoHDList _DSNhanvien = DanhsachNVTheoHDList.NewDanhsachNVTheoHDList();
        ThuViecHocViecList _DSTVHV = ThuViecHocViecList.NewThuViecHocViecList();
        public frmThuViecHocViec()
        {
            InitializeComponent();
            this.Load_Source();
        }     

        #region Load
        private void Load_Source()
        {
            try
            {
                _BophanList = BoPhanList.GetBoPhanList();
                BindS_Bophan.DataSource = _BophanList;
                _BophanHCTVList = BoPhanList.GetBoPhanList();
                BindS_BophanHCTV.DataSource = _BophanHCTVList;
                dtpu_Denngay.Value = Convert.ToDateTime(dtpu_tungay.Value).AddDays(7);
            }
            catch (ApplicationException)
            { 

            }
        }

        private void grdu_Dsthuviec_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["manhanvien"].Hidden = true;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Chucvu"].Hidden = true;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["makytinhluong"].Hidden = true;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Mathuviechocviec"].Hidden = true;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Ngayvaolam"].Hidden = true;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Ngaysinh"].Hidden = true;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Loai"].Hidden = true;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["kytinhluong"].Hidden = true;

            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["MaQlNhanvien"].Header.Caption = "Mã Số";
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["MaQlNhanvien"].Header.VisiblePosition = 1;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["MaQlNhanvien"].Width = 120;

            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.Caption = "Tên Nhân Viên";
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.VisiblePosition = 2;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Tennhanvien"].Width = 200;

            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Ngay"].Header.Caption = "Ngày";
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Ngay"].Header.VisiblePosition = 3;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Ngay"].Width = 100;

            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Ghichu"].Header.Caption = "Ghi Chú";
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Ghichu"].Header.VisiblePosition = 4;
            grdu_Dsthuviec.DisplayLayout.Bands[0].Columns["Ghichu"].Width = 250;

            grdu_Dsthuviec.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_Dsthuviec.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_Dsthuviec.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
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

        private void Load_Nguon()
        {
            int Loai = 0;
            Loai=radtv.Checked ? 0 : 1;
            if (cmbu_Bophan.Value != null)
            {
                _DSNhanvien = DanhsachNVTheoHDList.GetDSchuaphanbothuviecByBophan((int)cmbu_Bophan.Value,Convert.ToDateTime(dtpu_tungay.Value),Convert.ToDateTime(dtpu_Denngay.Value),Loai);
            }
            else
            {
                _DSNhanvien = DanhsachNVTheoHDList.GetDSchuaphanbothuviecByNgay(Convert.ToDateTime(dtpu_tungay.Value), Convert.ToDateTime(dtpu_Denngay.Value),Loai);
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
                lblTSo.Text = "Tổng cộng : " + _DSNhanvien.Count;            
        }

        private void Load_Dich()
        {
            int Loai=0;
            if (radtv.Checked)
            {
                Loai = 0;
            }
            else
            {
                Loai = 1;
            }
            if (chkLaytatca.Checked) // Lay tat ca ke ca trong HDLD
            {
                if (cmbu_Nhanvien.Value == null)
                {
                    if (cmbu_Bophan.Value != null)
                    {
                        _DSTVHV = ThuViecHocViecList.GetThuViecHocViecListByBoPhanAll((int)cmbu_Bophan.Value, Loai);
                        BindS_TVHV.DataSource = _DSTVHV;
                    }
                }
                else
                {
                    _DSTVHV = ThuViecHocViecList.GetThuViecHocViecListByNhanVien((long)cmbu_Nhanvien.Value, Loai);
                    BindS_TVHV.DataSource = _DSTVHV;
                }
            }
            else
            {
                if (cmbu_Nhanvien.Value == null)
                {
                    if (cmbu_Bophan.Value != null)
                    {
                        _DSTVHV = ThuViecHocViecList.GetThuViecHocViecListByBoPhan((int)cmbu_Bophan.Value, Loai);
                        BindS_TVHV.DataSource = _DSTVHV;
                    }
                }
                else
                {
                    _DSTVHV = ThuViecHocViecList.GetThuViecHocViecListByNhanVien((long)cmbu_Nhanvien.Value, Loai);
                    BindS_TVHV.DataSource = _DSTVHV;
                }
            }
        }

        #endregion 

        #region Event
        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
              //  _ThongTinNVTHList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_Bophan((int)cmbu_Bophan.Value);
              //  BindS_NhanVien.DataSource = _ThongTinNVTHList;
            }
            this.Load_Nguon();
            this.Load_Dich();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            // Insert vao thu viec
            int Loai=0;
            int _Ngay=(int)txtu_Sluong.Value;
            if (txtu_Sluong.Value.ToString()=="0")
            {
                MessageBox.Show(this, "Ngày không hơp lệ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }        
            if (radtv.Checked == true)
            {
                Loai = 0;
            }
            else
            {
                Loai = 1;
            }
                for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                {
                    if (lstvDsnguon.Items[i].Checked == true)
                    {
                        ThuViecHocViec.Themvaothuviec(Convert.ToInt64(lstvDsnguon.Items[i].Text.Trim()), _Ngay, Loai, txt_ghichu.Text.Trim());
                    }
                }
            try
            {
                _DSTVHV.ApplyEdit();
                _DSTVHV.Save();
                this.Load_Nguon();
                this.Load_Dich();
            }
            catch (ApplicationException)
            {

            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
                if (grdu_Dsthuviec.ActiveRow != null)
                {
                    grdu_Dsthuviec.DeleteSelectedRows();                  
                }        
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void radtv_Click(object sender, EventArgs e)
        {
            if (cmbu_Bophan.ActiveRow != null)
            {
                this.Load_Dich();
            }
        }

        private void radhv_Click(object sender, EventArgs e)
        {
            if (cmbu_Bophan.ActiveRow != null)
            {
                this.Load_Dich();
            }
        }

        private void chkLaytatca_CheckedChanged(object sender, EventArgs e)
        {
            // Load danh sach 
            this.Load_Dich();
            // Load lai nhan vien

        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Nguon();
        }

        private void frmThuViecHocViec_Load(object sender, EventArgs e)
        {
            dtpu_Denngay.Value = DateTime.Now;
            dtpu_tungay.Value = Convert.ToDateTime(dtpu_Denngay.Value).AddDays(-7);
            txtu_Sluong.Value = 7;
        }

        private void tblblXulynghi_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show(this, "Chương Trình Sẽ Căn Cứ Vào Thông Tin Nghỉ Của Nhân Viên Và Xử Lý Lại Các Ngày Thử Việc. Thực Hiện (Yes/No)?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    int Thang = 0;
                    int Nam = 0;
                    Thang = Convert.ToDateTime(dtpu_tungay.Value).Month;
                    Nam = Convert.ToDateTime(dtpu_tungay.Value).Year;
                    ThuViecHocViec.XulyNghi(Thang, Nam);
                    MessageBox.Show(this, "Đã Xử Lý Ngày Hoàn Tất Cho Các Nhân Viên Thử Việc !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Load_Dich();
                    Load_Nguon();
                }
                catch (ApplicationException)
                {

                }
            }
        }
        #endregion         

        #region Process
        private void XulyNghi()        
        {

        }
        #endregion


 
    }
}
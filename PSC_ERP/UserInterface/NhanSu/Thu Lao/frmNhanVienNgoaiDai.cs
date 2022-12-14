using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmNhanVienNgoaiDai : Form
    {
        private ERP_Library.NhanVienNgoaiDaiList _data;

        private ERP_Library.NhanVienNgoaiDaiList _datacompo;

        private FilterCombo fBoPhan;
        private FilterCombo fNganHang;
        NganHangList _nganHangList=NganHangList.NewNganHangList();
        BoPhanList boPhanList;
        public frmNhanVienNgoaiDai()
        {
            InitializeComponent();            
            this.bdBoPhan.DataSource = typeof(BoPhanList);            
            this.bindingSource1_NganHang.DataSource = typeof(NganHangList);            
            bdData.DataSource = typeof(NhanVienNgoaiDaiList);
            bindingSource_NhanVien.DataSource = typeof(NhanVienNgoaiDaiList);
            //grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
          //  grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            //grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            boPhanList = BoPhanList.GetBoPhanListBy_All();
            this.bdBoPhan.DataSource = boPhanList;
            _nganHangList = NganHangList.GetNganHangList();
            this.bindingSource1_NganHang.DataSource = _nganHangList;

            _data = ERP_Library.NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiListBySuDung(false);
            bdData.DataSource = _data;

            //_datacompo = ERP_Library.NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiListBySuDung();            
            //NhanVienNgoaiDai nv = NhanVienNgoaiDai.NewNhanVienNgoaiDai("Không có");
            //_datacompo.Insert(0, nv);
            //bindingSource_NhanVien.DataSource = _datacompo;
        }


        private void SaveData()
        {
            try
            {
                grdData.UpdateData();
                this.bdData.EndEdit();
               
                //foreach (NhanVienNgoaiDai nv in _data)
                //{
                //    if (nv.NguoiLap == ERP_Library.Security.CurrentUser.Info.UserID && nv.IsDirty == true && (nv.Cmnd == string.Empty || nv.SoTaiKhoan == string.Empty || nv.MaNganHang == 0 || nv.MaBoPhan == 0))
                //    {
                //        MessageBox.Show("Dữ liệu chưa hợp lệ, cần điền thông tin: CMND, MST, STK, Ngân Hàng, Bộ Phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //    if (nv.IsDirty == true && ((NhanVienNgoaiDai.KiemTraTrungSoCMND(nv.MaNhanVien, nv.Cmnd) == true)))
                //    {
                //        MessageBox.Show("CMND của nhân viên " + nv.TenNhanVien + " đã tồn tại, vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //    //if (nv.IsDirty == true)
                //    //{
                //    //    nv.MaBoPhan in 
                //    //}
                //}
                _data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _data = ERP_Library.NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList();
                bdData.DataSource = _data;
            }
            catch (Exception ex)
            {

                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void frmNhanVienNgoaiDai_Load(object sender, EventArgs e)
        {
            bdBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListByAll();
            fBoPhan = new FilterCombo(grdData, "MaBoPhan", "TenBoPhan");
            fNganHang = new FilterCombo(grdData, "MaNganHang", "TenNganHang");
            FilterCombo f = new FilterCombo(grdData, "MaNhanVien", "TenNhanVien");
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            LoadData();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void frmNhanVienNgoaiDai_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_data != null && _data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                
                col.Hidden = true;                
                if (col.DataType == typeof(DateTime))
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType == typeof(decimal))
                {
                    col.Format = "###,###,###,###,###";
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;

            grdData.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            grdData.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 1;

            grdData.DisplayLayout.Bands[0].Columns["MST"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MST"].Header.Caption = "Mã Số Thuế";
            grdData.DisplayLayout.Bands[0].Columns["MST"].Header.VisiblePosition = 2;

            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cmbBoPhan;
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.Caption = "Bộ Phận";
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Width = 150;

            grdData.DisplayLayout.Bands[0].Columns["MaNganHang"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.Caption = "Ngân Hàng";
            grdData.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.VisiblePosition = 4;
            grdData.DisplayLayout.Bands[0].Columns["MaNganHang"].EditorComponent = cbNganHang;

            grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;            
            grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số Tài Khoản";
            grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 5;
            grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Width = 80;
            

            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 6;

            grdData.DisplayLayout.Bands[0].Columns["DienThoai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            grdData.DisplayLayout.Bands[0].Columns["DienThoai"].Header.VisiblePosition = 7;

            grdData.DisplayLayout.Bands[0].Columns["SuDung"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SuDung"].Header.Caption = "Sử Dụng";
            grdData.DisplayLayout.Bands[0].Columns["SuDung"].Header.VisiblePosition = 7;
            //grdData.DisplayLayout.Bands[0].Columns["MaNhanVienChuyenTien"].Header.Caption = "NV Chuyển Tiền";
            //grdData.DisplayLayout.Bands[0].Columns["MaNhanVienChuyenTien"].Header.VisiblePosition = 8;
            //grdData.DisplayLayout.Bands[0].Columns["MaNhanVienChuyenTien"].EditorComponent = ultraCombo_NhanVien;
        
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void ultraCombo_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 0;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Width = 70;

            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;            

            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MST"].Hidden = false;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MST"].Header.Caption = "Mã Số Thuế";
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MST"].Width = 70;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MST"].Header.VisiblePosition = 2;
        }

        private void cbNganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void checkBox_SuDung_CheckedChanged(object sender, EventArgs e)
        {
            _data = ERP_Library.NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiListBySuDung(checkBox_SuDung.Checked);
            bdData.DataSource = _data;
        }

      
       

    }
}
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
    public partial class frmGopNhanVienNgoaiDai : Form
    {
        private ERP_Library.NhanVienNgoaiDaiList _data;
        private FilterCombo fBoPhan;
        NganHangList _nganHangList=NganHangList.NewNganHangList();
        BoPhanList boPhanList;
        public frmGopNhanVienNgoaiDai()
        {
            InitializeComponent();            
            this.bdBoPhan.DataSource = typeof(BoPhanList);            
            this.bindingSource1_NganHang.DataSource = typeof(NganHangList);            
            bdData.DataSource = typeof(NhanVienNgoaiDaiList);
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
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
            _data = ERP_Library.NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList();
            bdData.DataSource = _data;
        }


        private void SaveData()
        {
            //try
            //{
            //    this.bdData.EndEdit();
            //    _data.Save();
            //    MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //_data = ERP_Library.NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList();
            //    //bdData.DataSource = _data;
            //}
            //catch (Exception ex)
            //{
            //    frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            //}
            int d_SuDungChinh = 0;
            long _makhchinh = 0;
            string _makhbo = string.Empty;
            bool _hoantat = false;
            int Type_err = 0; // 0 ko loi , 1 click nhieu dung chinh, 2 vua co SuDungChinh vua co loai bo
            try
            {

                bdData.EndEdit();
                grdData.DataBind();
                // kiem tra moi lan cap nhat chi lam cho mot khach hang
                //grdData.UpdateData();
                //for (int i = 0; i < grdData.Rows.Count; i++)
                //{
                //    if ((bool)grdData.Rows[i].Cells["SuDungChinh"].Value)
                //    {
                //        d_SuDungChinh++;
                //        if (d_SuDungChinh > 1)
                //            break;
                //    }
                //    if ((bool)grdData.Rows[i].Cells["SuDungChinh"].Value == true && (bool)grdData.Rows[i].Cells["SuDung"].Value == true)
                //    {
                //        Type_err = 2;
                //        break;
                //    }

                //}
                //if (d_SuDungChinh > 1)
                //    Type_err = 1;
                //if (Type_err == 1)
                //{
                //    MessageBox.Show(this, "Mỗi lần chỉ cập nhật dữ liệu 01 khách hàng dùng chính.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                foreach (NhanVienNgoaiDai nvnd in _data)
                {
                    //if (nvnd.SuDungChinh == false)
                    //{
                    //    MessageBox.Show(this, "Bạn Phải Chọn Nhân Viên Sử Dụng Chính.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //       return;
                    //}
                    //if (nvnd.SuDung == false)
                    //{
                    //    MessageBox.Show(this, "Bạn Phải Chọn Nhân Viên Bỏ Khỏi hệ Thống","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    if (nvnd.SuDung == true)
                    {
                        _makhbo += nvnd.MaNhanVien.ToString() + ",";                       
                    }
                    if (nvnd.SuDungChinh == true)
                    {
                        _makhchinh = nvnd.MaNhanVien;
                    }
                }
                if (_makhbo != "")
                {
                    _makhbo = _makhbo.Substring(0, _makhbo.Length - 1);
                    if (NhanVienNgoaiDai.GopNhanVienNgoaiDai(_makhchinh, _makhbo))
                        _hoantat = true;
                }
                _data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _data = ERP_Library.NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList();
                bdData.DataSource = _data;
                MessageBox.Show(this, "Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmNhanVienNgoaiDai_Load(object sender, EventArgs e)
        {
            bdBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListByAll();
            fBoPhan = new FilterCombo(grdData, "MaBoPhan", "TenBoPhan");
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
            grdData.DisplayLayout.Bands[0].Columns["SuDung"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SuDung"].Header.Caption = "Chọn NV Bỏ";
            grdData.DisplayLayout.Bands[0].Columns["SuDung"].Header.VisiblePosition = 0;

            grdData.DisplayLayout.Bands[0].Columns["SuDungChinh"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SuDungChinh"].Header.Caption = "Chọn NV Chính";
            grdData.DisplayLayout.Bands[0].Columns["SuDungChinh"].Header.VisiblePosition = 1;

            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;

            grdData.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            grdData.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 3;

            grdData.DisplayLayout.Bands[0].Columns["MST"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MST"].Header.Caption = "Mã Số Thuế";
            grdData.DisplayLayout.Bands[0].Columns["MST"].Header.VisiblePosition = 4;

            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cmbBoPhan;
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.Caption = "Bộ Phận";
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.VisiblePosition = 5;
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cmbBoPhan;

            grdData.DisplayLayout.Bands[0].Columns["MaNganHang"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.Caption = "Ngân Hàng";
            grdData.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.VisiblePosition = 6;
            grdData.DisplayLayout.Bands[0].Columns["MaNganHang"].EditorComponent = cbNganHang;

            grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;            
            grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số Tài Khoản";
            grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 7;
            

            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 8;

            grdData.DisplayLayout.Bands[0].Columns["DienThoai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            grdData.DisplayLayout.Bands[0].Columns["DienThoai"].Header.VisiblePosition = 9;

            grdData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.Caption = "MaNVHgt";
            grdData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.VisiblePosition = 10;
            
        
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

    }
}
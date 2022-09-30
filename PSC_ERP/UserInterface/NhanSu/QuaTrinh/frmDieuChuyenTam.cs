using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmDieuChuyenTam : Form
    {
        static int maBoPhan = 0;
        static int maKyTinhLuong = 0;
        static long maNhanVien = 0;
        BoPhanList _boPhanList,_boPhanList1;
        CongViecList _congViecList;        
        KyTinhLuongList _kyTinhLuongList,_kyTinhLuongListSearch;
        DieuChuyenTamList _dieuChuyenTamList;
        public frmDieuChuyenTam()
        {
            InitializeComponent();
        }

        private void frmDieuChuyenTam_Load(object sender, EventArgs e)
        {
            _boPhanList = BoPhanList.GetBoPhanList();
            _boPhanList1 = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            this.bindingSource1_BoPhan2.DataSource = _boPhanList1;
            _congViecList = CongViecList.GetCongViecList();
            this.bindingSource1_CongViec.DataSource = _congViecList;
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();            
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
            _kyTinhLuongListSearch = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuongSearch.DataSource = _kyTinhLuongListSearch;
            _dieuChuyenTamList = DieuChuyenTamList.GetDieuChuyenTamListByNhanVien(0);
            this.bindingSource1_DieuChuyenTam.DataSource = _dieuChuyenTamList;
        }

        private void ultragrdDanToc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdDanToc.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdDanToc.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].EditorComponent = cbMaKyTinhLuong;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaNhanVien"].EditorComponent = cbNhanVien;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cbBoPhan2;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaCongViec"].EditorComponent = cbCongViec;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["Ngay"].EditorComponent = ultralDate;
            foreach (UltraGridColumn col in ultragrdDanToc.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiem();
            //frmTimNhanVien fTim = new frmTimNhanVien();
            //fTim.Show();
            //fTim.FormClosed += new FormClosedEventHandler(fTim_FormClosed);
        }
        void fTim_FormClosed(object sender, FormClosedEventArgs e)
        {
            maNhanVien = frmTimNhanVien.MaNhanVien;
            _dieuChuyenTamList = DieuChuyenTamList.GetDieuChuyenTamListByNhanVien(maNhanVien);
            
            this.bindingSource1_DieuChuyenTam.DataSource = _dieuChuyenTamList;
            TTNhanVienRutGon tt = TTNhanVienRutGon.GetTTNhanVienRutGon(maNhanVien);
            this.bindingSource_NhanVien.DataSource = tt;
            if (_dieuChuyenTamList.Count == 0)
            {
                MessageBox.Show("Chưa có điều chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0;i<_dieuChuyenTamList.Count; i++)
                {
                    if (_dieuChuyenTamList[i].MaBoPhan == 0)
                    {
                        MessageBox.Show("Chưa chọn bộ phận điều chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_dieuChuyenTamList[i].MaCongViec == 0)
                    {
                        MessageBox.Show("Chưa chọn công việc sau điều chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_dieuChuyenTamList[i].MaDieuChuyenQL == "")
                    {
                        MessageBox.Show("Chưa nhập mã điều chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_dieuChuyenTamList[i].MaKyTinhLuong== 0)
                    {
                        MessageBox.Show("Chưa chọn kỳ tính lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_dieuChuyenTamList[i].MaNhanVien == 0)
                    {
                        MessageBox.Show("Chưa chọn nhân viên điều chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                _dieuChuyenTamList.ApplyEdit();
                _dieuChuyenTamList.Save();
                MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
           // GridLoad();
        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GridLoad()
        {
            _dieuChuyenTamList = DieuChuyenTamList.GetDieuChuyenTamListByNhanVien(maNhanVien);
            this.bindingSource1_DieuChuyenTam.DataSource = _dieuChuyenTamList;
        }
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            GridLoad();
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdDanToc.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Chọn Dòng Để Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdDanToc.DeleteSelectedRows();  
        }
        private void ultragrdDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ultragrdDanToc.UpdateData();
            }
        }
        private void TimKiem()
        {
            maKyTinhLuong = Convert.ToInt32(cbKyTinhLuongSearch.Value);
            maBoPhan = Convert.ToInt32(ultraCombo1.Value);
            TTNhanVienRutGonList _nvList = TTNhanVienRutGonList.GetNhanVienListBoPhan(maBoPhan);
            this.bindingSource_NhanVien.DataSource = _nvList;
            _dieuChuyenTamList = DieuChuyenTamList.GetDieuChuyenTamListByKyTinhLuong(maKyTinhLuong, maBoPhan);
            this.bindingSource1_DieuChuyenTam.DataSource = _dieuChuyenTamList;
            if (_dieuChuyenTamList.Count == 0)
            {
                MessageBox.Show("Chưa có điều chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TimKiem();   
     
         }
    }
}
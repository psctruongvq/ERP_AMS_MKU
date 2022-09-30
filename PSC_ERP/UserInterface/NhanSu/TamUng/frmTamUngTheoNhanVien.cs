using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmTamUngTheoNhanVien : Form
    {
        BoPhanList _boPhanList;
        static int maLoaiBoPhan = 0;
        static int maBoPhan = 0;
        LoaiBoPhanList _loaiBoPhanList;
        private static long maNhanVien = 0;
        private static long maNhanVien1 = 0;
        private static int maKyTinhLuong = 0;
        private static int maChucVu = 0;
        ChucVuList _chucVuList;
        private TTNhanVienRutGonList _nhanVienList;
        private TamUngTheoNhanVien _tamUngNV;
        private TamUngTheoNhanVienList _tamUngNVList;
        KyTinhLuongList _kyTinhLuongList,_kyTinhLuongSearch;
        
        public frmTamUngTheoNhanVien()
        {
            InitializeComponent();
        }

        private void frmTamUngTheoNhanVien_Load(object sender, EventArgs e)
        {
            _loaiBoPhanList = LoaiBoPhanList.GetLoaiBoPhanList();
            this.bindingSource1_LoaiBoPhan.DataSource = _loaiBoPhanList;
            _boPhanList = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            //this.tlsMain.Enabled = false;            
           // tlslblTim_Click(sender, e);
            //maNhanVien = frmTimNhanVien.MaNhanVien;
            maNhanVien = frmTimNhanVien.MaNhanVien;
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
            _chucVuList = ChucVuList.GetChucVuListAll();
            this.bindingSource2_ChucVu.DataSource = _chucVuList;
            _kyTinhLuongSearch = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuongSearch.DataSource = _kyTinhLuongSearch;
        }             

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            if (maKyTinhLuong == 0)
            {
                MessageBox.Show("Chưa có kỳ tính lương","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            frmTimNhanVien fTim = new frmTimNhanVien();
            fTim.Show();
            fTim.FormClosed += new FormClosedEventHandler(fTim_FormClosed);
            
        }

        void fTim_FormClosed(object sender, FormClosedEventArgs e)
        {
            maNhanVien = frmTimNhanVien.MaNhanVien;
            maNhanVien1 = maNhanVien;
            _tamUngNVList = TamUngTheoNhanVienList.GetTamUngTheoNhanVienListByMaKy(maNhanVien, maKyTinhLuong);
            this.bindingSource1_TamUngTheoNhanVien.DataSource = _tamUngNVList;
            TTNhanVienRutGon tt = TTNhanVienRutGon.GetTTNhanVienRutGon(maNhanVien);
            this.bindingSource_NhanVien.DataSource = tt;

        }

   

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _tamUngNVList.Count; i++)
                {
                    if (_tamUngNVList[i].SoTien < 0)
                    {
                        MessageBox.Show("Số Tiền Chưa Chính Xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_tamUngNVList[i].MaNhanVien== 0)
                    {
                        _tamUngNVList[i].MaNhanVien = maNhanVien1;
                        
                    }
                }
                _tamUngNVList.ApplyEdit();
                _tamUngNVList.Save();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ultragrdDanToc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            //h.ultragrdEmail_InitializeLayout(sender, e);
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].EditorComponent = cbMaKyTinhLuong;
            ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaNhanVien"].EditorComponent = cbNhanVien;
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
                ultragrdDanToc.UpdateData();
            }
        }

        private void ultragrdDanToc_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            for (int i = 0; i < _tamUngNVList.Count; i++)
            {
                if (_tamUngNVList[i].MaNhanVien == 0&& maNhanVien!=0)
                {
                    _tamUngNVList[i].MaNhanVien = maNhanVien;
                    //_tamUngNVList[i].MaChucVu= NhanVien.GetNhanVien(maNhanVien).MaChucVu;
                   // _tamUngNVList[i].MaChucVu = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(maNhanVien).MaChucVu;
                    
                }
                cbNhanVien.Value = maNhanVien1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maBoPhan=Convert.ToInt32(cbBoPhan.Value);
            //_nhanVienListTemp = TTNhanVienRutGonList.GetNhanVienListByMaChucVuBoPhan(maChucVu, maBoPhan);
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByMaChucVuBoPhan(maChucVu, maBoPhan);
            this.bindingSource_NhanVien.DataSource = _nhanVienList;
            _tamUngNVList = TamUngTheoNhanVienList.GetTamUngTheoNhanVienListMaChucVuMaKyTinhLuong(maChucVu, maKyTinhLuong,maBoPhan);

            for (int i = 0; i < _nhanVienList.Count; i++)
            {
                for (int j = 0; j < _tamUngNVList.Count; j++)
                {
                    if (_nhanVienList.Count > i)
                    {
                        if (_nhanVienList[i].MaNhanVien == _tamUngNVList[j].MaNhanVien)
                        {
                            _nhanVienList.RemoveAt(i);
                        }
                    }
                }
            }

                for (int i = 0; i < _nhanVienList.Count; i++)
                {
                    TamUngTheoNhanVien _tamUngNV = TamUngTheoNhanVien.NewTamUngTheoNhanVien();
                    _tamUngNV.MaNhanVien = _nhanVienList[i].MaNhanVien;
                    
                    _tamUngNV.SoCongThucTe = TamUngTheoNhanVien.GetSoCongThucTe(_nhanVienList[i].MaNhanVien, maKyTinhLuong, DateTime.Today);
                    _tamUngNV.MaKyTinhLuong = maKyTinhLuong;
                    //_tamUngNV.GhiChu = "Dữ Liệu Mới";
                    //ultragrdDanToc.Rows[i].Cells["GhiChu"].Value = "Dữ Liệu Mới";
                    _tamUngNVList.Add(_tamUngNV);


                }

            this.bindingSource1_TamUngTheoNhanVien.DataSource = _tamUngNVList;
            if (_tamUngNVList.Count == 0)
            {
                MessageBox.Show("Không Có Tạm Ứng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cbChucVu_ValueChanged(object sender, EventArgs e)
        {
            maChucVu = Convert.ToInt32(cbChucVu.Value);
           
        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            //maNhanVien = Convert.ToInt32(cbNhanVien.Value);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLoaiBoPhan_ValueChanged(object sender, EventArgs e)
        {
            maLoaiBoPhan = Convert.ToInt32(cbLoaiBoPhan.Value);
            _boPhanList = BoPhanList.GetBoPhanList_LoaiBoPhan(maLoaiBoPhan);
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
        }

        private void cbKyTinhLuongSearch_ValueChanged(object sender, EventArgs e)
        {
            maKyTinhLuong = Convert.ToInt32(cbKyTinhLuongSearch.Value);
        }

        private void tbSoTien_ValueChanged(object sender, EventArgs e)
        {
           
               
        }

        private void ultragrdDanToc_FilterRow(object sender, Infragistics.Win.UltraWinGrid.FilterRowEventArgs e)
        {
            ultragrdDanToc.UpdateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ultragrdDanToc.Rows.
            //for (int i = 0; i < ultragrdDanToc.Rows.FilteredInRowCount; i++)
            //for (int i = 0; i < ultragrdDanToc.Rows.FilteredInRowCount; i++)
            //{
                Infragistics.Win.UltraWinGrid.UltraGridRow []celColl =ultragrdDanToc.Rows.GetFilteredInNonGroupByRows();
                for (int i = 0; i < celColl.Length; i++)
                {
                    celColl[i].Cells["SoTien"].Value = Convert.ToDecimal(tbSoTien.Value);
                }
                   

                //ultragrdDanToc.Rows[i].Cells["SoTien"].Value = Convert.ToDecimal(tbSoTien.Value);
                //ultragrdDanToc.Rows.FilterRow.Cells["SoTien"].Value = 999;
                    //ultragrdDanToc.Rows[i].Cells["SoTien"].Value = Convert.ToDecimal(tbSoTien.Value);
            //}
        }
    }
}
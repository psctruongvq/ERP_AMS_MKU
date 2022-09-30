using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using System.Threading;
namespace PSC_ERP
{
    public partial class frmTamUngTheoChucVu : Form
    {
        //NhanVienList _nhanVienList;
        TTNhanVienRutGonList _nhanVienList;
        Util util = new Util();
        ChucVuList _chucVuList;
        KyTinhLuongList _kyTinhLuongList;
        TamUngTheoChucVuList _tamUngTheoChucVuList;
        TamUngTheoChucVu _tamUngCV;
        TamUngTheoNhanVienList _tamUngNVList,_tamUngNVListForDelete;
        TamUngTheoNhanVien _tamUngNV;
        private static int maKyTinhLuong = 0;
        private static int maChucVu = 0;
        private static int maKyTinhLuongTemp = 0;
        private static int maChucVuTemp = 0;
        private static int maKyTinhLuongRowSelect = 0;
        private static int maChucVuRowSelect = 0;
        private static string ghiChu = "";
        private static decimal soTien = 0;
        private static DateTime ngayLap;
        public frmTamUngTheoChucVu()
        {
            InitializeComponent();
        }

        private void frmTamUngTheoChucVu_Load(object sender, EventArgs e)
        {
            //this.tlslblThem.Enabled = false;

            maKyTinhLuong = Convert.ToInt32(cbMaKyTinhLuong.Value);
            maChucVu = Convert.ToInt32(cbChucVu.Value);
            
            _tamUngNVList = TamUngTheoNhanVienList.GetTamUngTheoNhanVienListMaChucVuMaKyTinhLuong(maChucVu, maKyTinhLuong,0);


            _chucVuList = ChucVuList.GetChucVuListAll();
            this.bindingSource2_ChucVu.DataSource = _chucVuList;
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;

            maKyTinhLuong = Convert.ToInt32(cbMaKyTinhLuong.Value);
            _tamUngTheoChucVuList = TamUngTheoChucVuList.GetTamUngTheoChucVuListByMaKyTinhLuong(maKyTinhLuong);            
            this.bindingSource1_TamUngTheoChucVu.DataSource = _tamUngTheoChucVuList;            
        }
        private void ultragrdDanToc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //HamDungChung t = new HamDungChung();
            //t.ultragrdEmail_InitializeLayout(sender, e);
            //ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaChucVu"].EditorComponent = cbChucVu;
            //ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].EditorComponent = cbMaKyTinhLuong;
            ultragrdDanToc.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdDanToc.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            foreach (UltraGridColumn col in ultragrdDanToc.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        private void GridLoad()
        {
            _tamUngTheoChucVuList = TamUngTheoChucVuList.GetTamUngTheoChucVuListByMaChucVuMaKyTinhLuong(maChucVu, maKyTinhLuong);
            this.bindingSource1_TamUngTheoChucVu.DataSource = _tamUngTheoChucVuList;
        }
        private void btKyTinhLuong_Click(object sender, EventArgs e)
        {
            GridLoad();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ghiChu = tbGhiChu.Text;
                soTien = Convert.ToDecimal(tbSoTien.Value);
                ngayLap = Convert.ToDateTime(dateNgayTao.Value);
                for (int i = 0; i < _tamUngTheoChucVuList.Count; i++)
                {                    
                    if (_tamUngTheoChucVuList[i].SoTien < 0)
                    {
                        MessageBox.Show("Số Tiền Chưa Chính Xác", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_tamUngTheoChucVuList[i].MaKyTinhLuong <= 0)
                    {
                        
                        MessageBox.Show("Kỳ Tính Lương Chưa Chính Xác", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if ((_tamUngTheoChucVuList[i].IsDirty == true) )
                    {
                        TamUngTheoNhanVienList _tamUngNVListTemp = TamUngTheoNhanVienList.GetTamUngTheoNhanVienListMaChucVuMaKyTinhLuong(_tamUngTheoChucVuList[i].MaChucVu, _tamUngTheoChucVuList[i].MaKyTinhLuong,0);
                        decimal _soTien = Convert.ToDecimal(ultragrdDanToc.Rows[i].Cells["SoTien"].Value);
                        string _ghiChu= Convert.ToString(ultragrdDanToc.Rows[i].Cells["GhiChu"].Value);
                        for (int j = 0; j < _tamUngNVListTemp.Count; j++)
                        {
                            
                                _tamUngNVListTemp[j].SoTien = _soTien;
                                _tamUngNVListTemp[j].GhiChu = _ghiChu;
                            
                            
                        }
                        _tamUngNVListTemp.ApplyEdit();
                        _tamUngNVListTemp.Save();
                    }
                }                
                _tamUngTheoChucVuList.ApplyEdit();
                _tamUngTheoChucVuList.Save();


                //Xóa Tạm Ứng cho NV
                if (_tamUngNVListForDelete != null)
                {
                    _tamUngNVListForDelete.Clear();
                    _tamUngNVListForDelete.Save();
                }
               //Thông tin tạm ứng cho DS nhân viên
                for (int i = 0; i < _tamUngNVList.Count; i++)
                {
                    if (_tamUngNVList[i].MaChucVu == 0 || _tamUngNVList[i].MaKyTinhLuong == 0)
                    {
                        _tamUngNVList[i].MaChucVu = maChucVuTemp;
                        _tamUngNVList[i].MaKyTinhLuong = maKyTinhLuongTemp;
                        _tamUngNVList[i].GhiChu = ghiChu;                  
                        _tamUngNVList[i].NgayLap = ngayLap;
                        _tamUngNVList[i].SoTien = soTien;
                    }
             
                }
                _tamUngNVList.ApplyEdit();
               _tamUngNVList.Save();              
              
               
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util.thatbai,util.thongbao,MessageBoxButtons.OK,MessageBoxIcon.Error);
                GridLoad();
            }
        }

        private void ultragrdDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultragrdDanToc.UpdateData();
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {   
            if (ultragrdDanToc.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ultragrdDanToc.Selected.Rows.Count > 1)
            {
                MessageBox.Show(this, "Chọn một dòng cho một lần xóa", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdDanToc.DeleteSelectedRows();            
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            GridLoad();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            GridLoad();
            if (_tamUngTheoChucVuList.Count == 0)
            {
                MessageBox.Show("Chưa có tạm ứng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(cbChucVu.Value) == 0) || (Convert.ToInt32(cbMaKyTinhLuong.Value)) == 0)
            {
                MessageBox.Show("Chọn Chức Vụ và Kỳ Tính Lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < _tamUngTheoChucVuList.Count; i++)
            {
                _tamUngCV = _tamUngTheoChucVuList[i];
                if (_tamUngCV.MaTamUngTheoCV == 0)
                {
                    return;
                }
            }
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByMaChucVu(maChucVu);
            _tamUngNVList = TamUngTheoNhanVienList.GetTamUngTheoNhanVienListMaChucVuMaKyTinhLuong(0, 0,0);            
            foreach (TTNhanVienRutGon nv in _nhanVienList)
            {
                if (TamUngTheoNhanVien.KiemTraNVTonTai(nv.MaNhanVien, maKyTinhLuong, maChucVu) == 0)
                {
                    _tamUngNV = TamUngTheoNhanVien.NewTamUngTheoNhanVien();
                    maKyTinhLuongTemp = maKyTinhLuong;
                    _tamUngNV.MaNhanVien = nv.MaNhanVien;
                    maChucVuTemp = maChucVu;                   
                    _tamUngNVList.Add(_tamUngNV);
                }
            }            
            _tamUngCV = TamUngTheoChucVu.NewTamUngTheoChucVu(0);
            _tamUngCV.MaKyTinhLuong = maKyTinhLuong;
            _tamUngCV.MaChucVu = maChucVu;            
            _tamUngTheoChucVuList.Add(_tamUngCV);           
            this.bindingSource1_TamUngTheoChucVu.DataSource = _tamUngTheoChucVuList;
            ultragrdDanToc.ActiveRow = ultragrdDanToc.Rows[_tamUngTheoChucVuList.Count - 1];
          
        }

        private void cbMaKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
           maKyTinhLuong = Convert.ToInt32(cbMaKyTinhLuong.Value);
            if (maKyTinhLuong != 0 && maChucVu != 0)
                this.tlslblThem.Enabled = true;
                
        }

        private void cbChucVu_ValueChanged(object sender, EventArgs e)
        {
            maChucVu = Convert.ToInt32(cbChucVu.Value);
            if (maKyTinhLuong != 0 && maChucVu != 0)
                this.tlslblThem.Enabled = true;
        }

        private void ultragrdDanToc_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            maChucVuRowSelect = Convert.ToInt32(ultragrdDanToc.ActiveRow.Cells["MaChucVu"].Value);
            maKyTinhLuongRowSelect = Convert.ToInt32(ultragrdDanToc.ActiveRow.Cells["MaKyTinhLuong"].Value);
            
        }

        private void ultragrdDanToc_AfterRowsDeleted(object sender, EventArgs e)
        {
            _tamUngNVListForDelete = TamUngTheoNhanVienList.GetTamUngTheoNhanVienListMaChucVuMaKyTinhLuong(maChucVuRowSelect, maKyTinhLuongRowSelect,0);
        }

        private void tbSoTien_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                soTien = Convert.ToDecimal(tbSoTien.Text);
            }
            catch (Exception ex)
            {
                tbSoTien.Text = "0";
                return;
            }
        }

        private void tbGhiChu_ValueChanged(object sender, EventArgs e)
        {
            ghiChu = tbGhiChu.Text;
        }

        private void dateNgayTao_ValueChanged(object sender, EventArgs e)
        {
           ngayLap =Convert.ToDateTime(dateNgayTao.Value);
        }
    }
}
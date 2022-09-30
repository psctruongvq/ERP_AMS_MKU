using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmBacLuongCoBan : Form
    {
        BacLuongCoBanList _BacLuongCoBanList;
        NgachLuongCoBanList _NgachLuongCoBanList;
        NhomNgachLuongCoBanList _nhomNgachLuongList;
        ChucVuList _ChucVuList;
      
        public delegate void PassData(BacLuongCoBanList value);
        public PassData getData;
        Util _Util = new Util();

        #region Load
        public frmBacLuongCoBan()
        {
            InitializeComponent();
            
        }

       

        private void Load_Source()
        {
            _BacLuongCoBanList = BacLuongCoBanList.NewBacLuongCoBanList();
            this.BindS_BacluongCB.DataSource = _BacLuongCoBanList; 
            _ChucVuList = ChucVuList.GetChucVuListAll();
            BindS_ChucVu.DataSource = _ChucVuList;
        }
        private void grdu_BacLuongCoBan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["MaBacLuongCoBan"].Hidden = true;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã QL";
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 70;

            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["TenBacLuongCoBan"].Header.Caption = "Tên Bậc Lương";
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["TenBacLuongCoBan"].Header.VisiblePosition = 1;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["TenBacLuongCoBan"].Width = 150;


            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hệ Số Lương";
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 2;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["HeSoLuong"].Width = 100;

            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["MaNgachLuongCB"].Hidden=true;
            


            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["ThoiGianNangbac"].Header.Caption = "TG Nâng Bậc(tháng)";
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["ThoiGianNangbac"].Header.VisiblePosition = 3;
            
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["ThoiGianNangbac"].Width = 170;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["DonViThoiGian"].Hidden = true;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["DonViThoiGian"].Header.Caption = "Đơn Vị Thời Gian";
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["DonViThoiGian"].Header.VisiblePosition = 4;
            //grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["DonViThoiGian"].EditorComponent = cmbu_DVThoiGain;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["DonViThoiGian"].Width = 100;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["SoThuTu"].Hidden = true;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["SoThuTu"].Header.Caption = "Số Thứ Tự";
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["SoThuTu"].Header.VisiblePosition = 5;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["SoThuTu"].Width = 100;

            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi Chú";
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 6;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 280;

            //grdu_BacLuongCoBan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //this.grdu_BacLuongCoBan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        #endregion 

        #region Events
        private void Save() 
        {
           
                for (int i = 0; i < _BacLuongCoBanList.Count; i++)
                {
                    _BacLuongCoBanList[i].MaNgachLuongCB = Convert.ToInt32(cbNgachLuong.Value);
                   
                    if (_BacLuongCoBanList[i].MaQuanLy == "")
                    {
                        MessageBox.Show(this, _Util.vuilongnhapbacluong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (_BacLuongCoBanList[i].HeSoLuong <= 0 || _BacLuongCoBanList[i].HeSoLuong > 99)
                    {
                        MessageBox.Show(this, "Hệ Số Lương chưa đúng", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (_BacLuongCoBanList[i].MaNgachLuongCB == 0)
                    {
                        MessageBox.Show(this, _Util.vuilongchonngachluong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
              
                    grdu_BacLuongCoBan.UpdateData();
                    _BacLuongCoBanList.ApplyEdit();
                    _BacLuongCoBanList.Save();
                    MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (getData != null)
                    {
                        getData(_BacLuongCoBanList);
                    }
                
        
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Undo()
        {
            _BacLuongCoBanList = BacLuongCoBanList.GetBacLuongCoBanList(Convert.ToInt32(cbNgachLuong.Value));
            this.BindS_BacluongCB.DataSource = _BacLuongCoBanList;
        }
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_BacLuongCoBan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(_Util.chodongcanxoa,_Util.thongbao,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            grdu_BacLuongCoBan.DeleteSelectedRows();
        }

        private void grdu_BacLuongCoBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //grdu_BacLuongCoBan.UpdateData();
            }
        }

        private void grdu_BacLuongCoBan_Leave(object sender, EventArgs e)
        {
            grdu_BacLuongCoBan.UpdateData();
        }

        private void cmbu_ChucVu_ValueChanged(object sender, EventArgs e)
        {
            //int machucvu = 0;
            //if (cmbu_ChucVu.Value != null)
            //{
            //    machucvu = (int)cmbu_ChucVu.Value;
            //    _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanListByChucVu(machucvu);
            //    BindS_NgachLuongCB.DataSource = _NgachLuongCoBanList;
            //}
            //else
            //{
            //    _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanList();
            //    BindS_NgachLuongCB.DataSource = _NgachLuongCoBanList;
            //}
        }

        private void cmbu_NgachLuong_ValueChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Process

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 0; i < grdu_BacLuongCoBan.Rows.Count; i++)//coi lai vong for i=1 
            {
                if (grdu_BacLuongCoBan.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Nhập Mã Bậc Lương Cơ Bản", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_BacLuongCoBan.ActiveRow = grdu_BacLuongCoBan.Rows[i];
                    return kq;
                }
                if (grdu_BacLuongCoBan.Rows[i].Cells["MaNgachLuongCB"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Chọn Ngạch Lương Cơ Bản", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_BacLuongCoBan.ActiveRow = grdu_BacLuongCoBan.Rows[i];
                    return kq;
                }
                if (grdu_BacLuongCoBan.Rows[i].Cells["HeSoLuong"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Nhập Hệ Số Lương", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_BacLuongCoBan.ActiveRow = grdu_BacLuongCoBan.Rows[i];
                    return kq;
                }
            }
            return kq;
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _BacLuongCoBanList.Count; i++)
            {
                for (int j = 0; j < _BacLuongCoBanList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_BacLuongCoBanList[i].MaQuanLy.Trim() == _BacLuongCoBanList[j].MaQuanLy.Trim())
                        {
                            BacLuongCoBan qg = BacLuongCoBan.GetBacLuongCoBan(_BacLuongCoBanList[i].MaBacLuongCoBan);
                            MessageBox.Show(this, "Bậc Lương " + qg.MaQuanLy.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_BacLuongCoBan.ActiveRow = grdu_BacLuongCoBan.Rows[i + 1];
                            grdu_BacLuongCoBan.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        private void frmBacLuongCoBan_Load(object sender, EventArgs e)
        {
            _nhomNgachLuongList = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
            bindingSource1_NhomNgachLuong.DataSource = _nhomNgachLuongList;
            _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanList();
            this.BindS_NgachLuongCB.DataSource = _NgachLuongCoBanList;
            _BacLuongCoBanList = BacLuongCoBanList.NewBacLuongCoBanList();
            this.BindS_BacluongCB.DataSource = _BacLuongCoBanList; 
        }

        private void cbNgachLuong_ValueChanged(object sender, EventArgs e)
        {
            _BacLuongCoBanList = BacLuongCoBanList.GetBacLuongCoBanList(Convert.ToInt32(cbNgachLuong.Value));
            this.BindS_BacluongCB.DataSource = _BacLuongCoBanList;
        }

        private void cbNhomNgachLuong_ValueChanged(object sender, EventArgs e)
        {
            _NgachLuongCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(Convert.ToInt32(cbNhomNgachLuong.Value));
            this.BindS_NgachLuongCB.DataSource = _NgachLuongCoBanList;
        }

        private void frmBacLuongCoBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                Undo();
            }
         
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_BacLuongCoBan);
        }
    }
}
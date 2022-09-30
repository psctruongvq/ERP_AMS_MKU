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
using Infragistics.Shared;

namespace PSC_ERP
{
    public partial class frmPhanTramHoaHong : Form
    {
        PhanTramHoaHongList _phanTramHoaHongList;
        HamDungChung hamDungChung = new HamDungChung();

        #region Contructors
        public frmPhanTramHoaHong()
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao();
        }
        #endregion 

        #region Khai Báo Sự Kiện
        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_PhanTramHoaHong);
        }
        #endregion 

        #region KhoiTao
        private void KhoiTao()
        {
            loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);
            loaiHangHoabindingSource1.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);
            _phanTramHoaHongList = PhanTramHoaHongList.GetPhanTramHoaHongList();
            phanTramHoaHongListBindingSource.DataSource = _phanTramHoaHongList;
        }
        #endregion

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (cb_LoaiHangHoa.Text  == null)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Loại Hàng Hóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_LoaiHangHoa.Focus();
                kq = false;
                return kq;
            }
            else if (numeu_PhanTramHoaHong.Value == null)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Phần Trăm Hoa Hồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numeu_PhanTramHoaHong.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(PhanTramHoaHong phanTramHoaHong)
        {
            Boolean kq = true;
            if (phanTramHoaHong.MaLoaiHangHoa == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Loại Hàng Hóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_LoaiHangHoa.Focus();
                kq = false;
                return kq;
            }
            else if (phanTramHoaHong.PhanTram == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Phần Trăm Hoa Hồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numeu_PhanTramHoaHong.Focus();
                kq = false;
                return kq;
            }
            
            return kq;
        }
        #endregion

        #region grdu_PhanTramHoaHong_InitializeLayout
        private void grdu_PhanTramHoaHong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_PhanTramHoaHong.DisplayLayout.Bands[0].Columns["MaHoaHong"].Hidden = true;
            grdu_PhanTramHoaHong.DisplayLayout.Bands[0].Columns["MaLoaiHangHoa"].Header.Caption = "Loại Hàng Hóa";
            grdu_PhanTramHoaHong.DisplayLayout.Bands[0].Columns["MaLoaiHangHoa"].Header.VisiblePosition = 1;
            grdu_PhanTramHoaHong.DisplayLayout.Bands[0].Columns["MaLoaiHangHoa"].EditorComponent =cbu_LoaiHangHoa;
            grdu_PhanTramHoaHong.DisplayLayout.Bands[0].Columns["PhanTram"].Header.Caption = "Phần Trăm Hoa Hồng";
            grdu_PhanTramHoaHong.DisplayLayout.Bands[0].Columns["PhanTram"].Header.VisiblePosition = 2;
          
            this.grdu_PhanTramHoaHong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_PhanTramHoaHong.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_PhanTramHoaHong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion

        #region thêmToolStripMenuItem_Click
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_phanTramHoaHongList.Count == 0)
            {
                PhanTramHoaHong phanTramHoaHong = PhanTramHoaHong.NewPhanTramHoaHongChild();
                _phanTramHoaHongList.Add(phanTramHoaHong);
                grdu_PhanTramHoaHong.ActiveRow = grdu_PhanTramHoaHong.Rows[_phanTramHoaHongList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    PhanTramHoaHong phanTramHoaHong = PhanTramHoaHong.NewPhanTramHoaHongChild();
                    _phanTramHoaHongList.Add(phanTramHoaHong);
                    grdu_PhanTramHoaHong.ActiveRow = grdu_PhanTramHoaHong.Rows[_phanTramHoaHongList.Count - 1];
                }
            }

        }
        #endregion

        #region luuToolStripMenuItem_Click
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhanTramHoaHong phanTramHoaHong;
            for (int i = 0; i < _phanTramHoaHongList.Count; i++)
            {

                phanTramHoaHong = _phanTramHoaHongList[i];
                if (phanTramHoaHong.MaLoaiHangHoa == 0)
                {
                    MessageBox.Show(this, "Vui Lòng Chọn Loại Hàng Hóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbu_LoaiHangHoa.Focus();
                    grdu_PhanTramHoaHong.Rows[i].Activate();
                    
                    return ;
                }
                else if (phanTramHoaHong.PhanTram == 0)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Phần Trăm Hoa Hồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numeu_PhanTramHoaHong.Focus();
                    grdu_PhanTramHoaHong.Rows[i].Activate();
                 
                    return ;
                }
            }
            if (MessageBox.Show(this, "Bạn Có Muốn Lưu Dữ Liệu Hiện Tại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    _phanTramHoaHongList.ApplyEdit();
                    _phanTramHoaHongList.Save();
                    KhoiTao();
                }
                catch (ApplicationException ex)
                { 
                    
                }
            }
        }
        #endregion

        #region thoatToolStripMenuItem_Click
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdu_PhanTramHoaHong.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_PhanTramHoaHong.DeleteSelectedRows();
        }
        #endregion

        #region cbu_LoaiHangHoa_InitializeLayout
        private void cbu_LoaiHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //cbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaLoaiHangHoa"].Hidden = true;
            //cbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            //cbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaTinhTrang"].Hidden = true;
            //cbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaNhomHangHoa"].Hidden = true;
            //cbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            //cbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            //cbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Tên Loại Hàng Hóa";
            //cbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 2;


            //this.cbu_LoaiHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            //this.cbu_LoaiHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //foreach (UltraGridColumn col in this.cbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            //}
        }
        #endregion        

        private void loaiHangHoaListBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
           if(loaiHangHoaListBindingSource.Current!=null)
            txt_TenLoaiHangHoa.Text=((LoaiHangHoa)loaiHangHoaListBindingSource.Current).TenLoaiHangHoa;
        }

        private void frmPhanTramHoaHong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Phan Tram Hoa Hong", "Help_BanHang.chm");
            }
        }

    }
}
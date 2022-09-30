using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
namespace PSC_ERP
{
    public partial class frmNhanVien_GiamTruGiaCanh : Form
    {
        #region Properties
        
        QuanHeGiaDinhList _quanHeGiaDinhList;
        GiamTruGiaCanhList _giamTruGiaCanhList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        NhanVienGiaCanhList _nhanVienGiaCanhList;
        long maNhanVien = 0;
        NhanVien _nhanVien;
        #endregion

        #region Events
        public frmNhanVien_GiamTruGiaCanh()
        {
            InitializeComponent();
            txtu_MaNhanVien.Focus();
            _quanHeGiaDinhList = QuanHeGiaDinhList.GetQuanHeGiaDinhList(maNhanVien);
            this.QuanHeGiaDinh_bindingSource1.DataSource = _quanHeGiaDinhList;
            _giamTruGiaCanhList = GiamTruGiaCanhList.GetGiamTruGiaCanhList();
            this.GiamTruGiaCanh_bindingSource.DataSource = _giamTruGiaCanhList;
            _nhanVienGiaCanhList = NhanVien.GetNhanVien(maNhanVien).NhanVienGiaCanhList;
            this.NhanVienGiaCanh_bindingSource.DataSource = _nhanVienGiaCanhList;
            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblXoa.Enabled = false;
            tlslblUndo.Enabled = false;
            tlslblIn.Visible = false;
            toolStripButton1.Visible = false;
            //this.Load_Form();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }

       

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
           
                this.Close();
           
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
        //{
        //    if (txtu_MaNhanVien.Text != "")
        //    {
        //        txt_TenVBCC.Focus();

        //        _QuaTrinhDaoTaoMoi = QuaTrinhDaoTao.NewQuaTrinhDaoTaoMoi(_ThongTinNhanVienTongHop.MaNhanVien);
        //        _QuaTrinhDaoTaoMoiList.Add(_QuaTrinhDaoTaoMoi);
        //        NhanVienGiaCanh_bindingSource.DataSource = _QuaTrinhDaoTaoMoiList;
        //        grdu_QuaTrinhDaoTao.ActiveRow = grdu_QuaTrinhDaoTao.Rows[_QuaTrinhDaoTaoMoiList.Count - 1];
        //    }
        }
        
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_NhanVien_GiaCanh.DeleteSelectedRows();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
        private void TimKiem()
        {
            frmTimNhanVien form_TimNV = new frmTimNhanVien();
            if (form_TimNV.ShowDialog(this) != DialogResult.OK)
            {
                if (frmTimNhanVien.MaNhanVien != 0)
                {
                    maNhanVien = frmTimNhanVien.MaNhanVien;
                    _nhanVien = NhanVien.GetNhanVien(maNhanVien);
                    _quanHeGiaDinhList = QuanHeGiaDinhList.GetQuanHeGiaDinhList(maNhanVien);
                    this.QuanHeGiaDinh_bindingSource1.DataSource = _quanHeGiaDinhList;
                    _nhanVienGiaCanhList = NhanVienGiaCanhList.GetNhanVienGiaCanhList(maNhanVien);
                    NhanVienGiaCanh_bindingSource.DataSource = _nhanVienGiaCanhList;
                    txtu_MaNhanVien.Text = _nhanVien.MaQLNhanVien.ToString();
                    txtu_TenNhanVien.Text = _nhanVien.TenNhanVien.ToString();
                }
            }
            tlslblThem.Enabled = true;
            tlslblLuu.Enabled = true;
            tlslblXoa.Enabled = true;
            tlslblUndo.Enabled = true;
        }
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _nhanVienGiaCanhList = NhanVienGiaCanhList.GetNhanVienGiaCanhList(maNhanVien);
            NhanVienGiaCanh_bindingSource.DataSource = _nhanVienGiaCanhList;
        }
        #endregion

      
        private void Save()
        {
            // _nhanVienGiaCanhList.ApplyEdit();
            if (!NhanVien.KiemTraNguoiPhuThuoc(_nhanVien))
                return;
            _nhanVien.NhanVienGiaCanhList = _nhanVienGiaCanhList;
            _nhanVien.ApplyEdit();
            _nhanVien.Save(true);
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _nhanVienGiaCanhList = NhanVienGiaCanhList.GetNhanVienGiaCanhList(maNhanVien);
            NhanVienGiaCanh_bindingSource.DataSource = _nhanVienGiaCanhList;
        }

        private void frmQuaTrinhDaoTaoMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                TimKiem();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            } 
        }

        private void frmQuaTrinhDaoTaoMoi_Load(object sender, EventArgs e)
        {
            _nhanVienGiaCanhList = NhanVien.GetNhanVien(maNhanVien).NhanVienGiaCanhList;
            this.NhanVienGiaCanh_bindingSource.DataSource = _nhanVienGiaCanhList;
        }

        private void grdu_NhanVien_GiaCanh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);


            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaQuanHeGiaDinh"].Hidden = false;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["ChungTu"].EditorComponent = this.ultraTextEditor_MNS;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaQuanHeGiaDinh"].EditorComponent = cbQuanHeGiaDinh;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaQuanHeGiaDinh"].Header.Caption = "Tên Người Phụ Thuộc";
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaQuanHeGiaDinh"].Width = cbQuanHeGiaDinh.Width;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaGiaCanh"].Hidden = false;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaGiaCanh"].Header.Caption = "Tên Gia Cảnh";
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaGiaCanh"].EditorComponent = cbGiaCanh;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaGiaCanh"].Width = cbGiaCanh.Width;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["ChungTu"].Hidden = false;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["ChungTu"].Header.Caption = "Chứng Từ";
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["ChungTu"].Width = 60;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 300;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaQuanHeGiaDinh"].Header.VisiblePosition = 0;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["MaGiaCanh"].Header.VisiblePosition = 1;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 2;
            grdu_NhanVien_GiaCanh.DisplayLayout.Bands[0].Columns["ChungTu"].Header.VisiblePosition = 3;
        }

        private void cbQuanHeGiaDinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //màu và font chữ
            foreach (UltraGridColumn col in this.cbQuanHeGiaDinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbQuanHeGiaDinh.DisplayLayout.Bands[0].Columns["HoTenNguoiThan"].Hidden = false;
            cbQuanHeGiaDinh.DisplayLayout.Bands[0].Columns["HoTenNguoiThan"].Header.Caption = "Họ Tên";
            cbQuanHeGiaDinh.DisplayLayout.Bands[0].Columns["HoTenNguoiThan"].Width = 250;
            //màu nền
            this.cbQuanHeGiaDinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cbQuanHeGiaDinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

        }

        private void cbGiaCanh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            //màu và font chữ
            foreach (UltraGridColumn col in this.cbGiaCanh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbGiaCanh.DisplayLayout.Bands[0].Columns["TenGiaCanh"].Hidden = false;
            cbGiaCanh.DisplayLayout.Bands[0].Columns["TenGiaCanh"].Header.Caption = "Tên Gia Cảnh";
            cbGiaCanh.DisplayLayout.Bands[0].Columns["TenGiaCanh"].Width = cbGiaCanh.Width;
            //màu nền
            this.cbGiaCanh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cbGiaCanh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

        }
        private bool KiemTraNPT(NhanVien nhanVien)
        {

            for (int i = 0; i < nhanVien.NhanVienGiaCanhList.Count; i++)
            {
                string cmnd = QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).Cmnd;
                int kiemTra = NhanVienGiaCanh.KiemTraCMND_GiaCanhDuyNhat(cmnd, nhanVien.MaNhanVien);
                if (kiemTra > 0)
                {
                    MessageBox.Show(QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).HoTenNguoiThan.ToString() + " đã được khai báo người phụ thuộc, Xin vui lòng kiểm tra lại CMND.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (NhanVienGiaCanh.KiemTraHoChieu_GiaCanhDuyNhat(QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).HoChieu, nhanVien.MaNhanVien) > 0)
                {
                    MessageBox.Show(QuanHeGiaDinh.GetQuanHeGiaDinh(nhanVien.NhanVienGiaCanhList[i].MaQuanHeGiaDinh).HoTenNguoiThan.ToString() + " đã được khai báo người phụ thuộc, Xin vui lòng kiểm tra lại Hộ Chiếu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void ultraTextEditor_MNS_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            int maNhanVien_GiaCanh = 0;
            if (grdu_NhanVien_GiaCanh.ActiveRow != null)
            {
                maNhanVien_GiaCanh = (int)grdu_NhanVien_GiaCanh.ActiveRow.Cells["NhanvienGiacanh"].Value;
            }
            frmNhanVienGiaCanh_ChungTu _frmChietNhanVien = new frmNhanVienGiaCanh_ChungTu((NhanVienGiaCanh)NhanVienGiaCanh_bindingSource.Current, maNhanVien_GiaCanh);
            _frmChietNhanVien.Show();
            
        }
    }
}
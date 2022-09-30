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



namespace PSC_ERP
{
    public partial class frmDanhSachDonNhanHangTra : Form
    {
        Util util = new Util();
        private DonNhanHangTraList _DonNhanHangTraList;
        private byte _Loai;
        HamDungChung hamDungChung = new HamDungChung();

        public frmDanhSachDonNhanHangTra(byte loai)
        {
            InitializeComponent();
            KhaiBaoSuKienForm();
            KhoiTao(loai);
            Invisible();
        }       
       
        #region Khai Báo Sự Kiện Form
        private void KhaiBaoSuKienForm()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(ultragrdDSDonHang);
        }
        #endregion 

        private void KhoiTao(byte loai)
        {
            _Loai = loai;
            _DonNhanHangTraList = DonNhanHangTraList.GetDonNhanHangTraList(DateTime.Today, DateTime.Today, _Loai);
            donNhanHangTraListBindingSource.DataSource = _DonNhanHangTraList;
        }

        #region Lưu Dữ Liệu
        private Boolean LuuDuLieu()
        {
            Boolean kq = true;
            try
            {
                _DonNhanHangTraList.ApplyEdit();
                _DonNhanHangTraList.Save();
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }
        #endregion 

        #region Invisible Button
        private void Invisible()
        {
            tlslblXoa.Available = false;
            tlslblUndo.Available = false;
           
            tlslblTroGiup.Available = false;
        }
        #endregion 

        #region ultragrdDSDonHang_DoubleClick
        private void ultragrdDSDonHang_DoubleClick(object sender, EventArgs e)
        {
            DonNhanHangTra _donNhanHangTra;
            _donNhanHangTra = DonNhanHangTra.GetDonNhanHangTra((long)(ultragrdDSDonHang.ActiveRow.Cells["MaDonHang"].Value));
            frmDonNhanHangTra dgl = new frmDonNhanHangTra(_donNhanHangTra);
            if (dgl.ShowDialog() != DialogResult.OK)
            {
                _DonNhanHangTraList = DonNhanHangTraList.GetDonNhanHangTraList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),_Loai);
                donNhanHangTraListBindingSource.DataSource = _DonNhanHangTraList;
                if (_DonNhanHangTraList.Count == 0)
                {
                    MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region ultragrdDSDonHang_InitializeLayout
        private void ultragrdDSDonHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
           
            foreach (UltraGridColumn col in this.ultragrdDSDonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/MM/yyyy";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/mm/yyyy";

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 5;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;
            
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.VisiblePosition = 1;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;
            
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 6;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Đối Tác";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 8;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Đối Tác";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 9;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Số CMND";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 10;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;

            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TinhTrangString"].Header.Caption = "Tình Trạng";
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TinhTrangString"].Header.VisiblePosition = 11;
            ultragrdDSDonHang.DisplayLayout.Bands[0].Columns["TinhTrangString"].Hidden = false;


         
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmDonNhanHangTra dlg = new frmDonNhanHangTra();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                _DonNhanHangTraList = DonNhanHangTraList.GetDonNhanHangTraList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),_Loai);
                donNhanHangTraListBindingSource.DataSource = _DonNhanHangTraList;
                if (_DonNhanHangTraList.Count == 0)
                {
                    MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.luudulieu, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)==DialogResult.OK)
            {
                if (LuuDuLieu() == true)
                {
                    MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   // MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _DonNhanHangTraList =   DonNhanHangTraList.GetDonNhanHangTraList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),_Loai);
                }
            }
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdDSDonHang.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else ultragrdDSDonHang.DeleteSelectedRows();

        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            _DonNhanHangTraList = DonNhanHangTraList.GetDonNhanHangTraList(Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value),_Loai);
            donNhanHangTraListBindingSource.DataSource = _DonNhanHangTraList;
            if (_DonNhanHangTraList.Count == 0)
            {
                MessageBox.Show(this, util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void frmDanhSachDonNhanHangTra_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

       
    }
}
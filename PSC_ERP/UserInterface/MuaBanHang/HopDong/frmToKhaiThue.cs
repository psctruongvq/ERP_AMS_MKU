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
using Infragistics.Shared;

namespace PSC_ERP
{
    public partial class frmToKhaiThue : Form
    {
        ToKhaiThue _toKhaiThue = ToKhaiThue.NewToKhaiThue();
        HamDungChung hamDungChung = new HamDungChung();

        #region Contructor
        public frmToKhaiThue()
        {
            InitializeComponent();
            KhaiBaoSuKien();
           // KhoiTao();
        }
        public frmToKhaiThue(ToKhaiThue toKhaiThue)
        {
            InitializeComponent();
            KhaiBaoSuKien();
            KhoiTao(toKhaiThue);
        }
        #endregion 

        #region Khai Báo Sự Kiện
        private void KhaiBaoSuKien()
        {
            hamDungChung.EventForm(this);
            hamDungChung.EventGrid(grdu_CTToKhaiThue);
        }

        #endregion 

        #region Khởi Tạo
        private void KhoiTao(ToKhaiThue toKhaiThue)
        {
            _toKhaiThue = toKhaiThue;
            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();
            ToKhaiThuebindingSource.DataSource = _toKhaiThue;
            cTToKhaiThueListBindingSource.DataSource = _toKhaiThue.CT_ToKhaiThueList;
           // cb_LoaiTien.SelectedValue = ((LoaiTien)(loaiTienListBindingSource.Current)).MaLoaiTien;            
        }
        #endregion

        #region Kiểm Tra Dữ Liệu
        private bool KiemTraDuLieu()
        {            
            if (_toKhaiThue.SoToKhai == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Tờ Khai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoToKhaiThue.Focus();
                return false;
            }
            return true;
        }
        #endregion 

        #region grdu_CTToKhaiThue_InitializeLayout
        private void grdu_CTToKhaiThue_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["MaToKhaiThue"].Hidden = true;

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition= 1;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Hàng Hóa";

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["KhoiLuong"].MaskInput = "nnnnnnnnn.nnnn";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["KhoiLuong"].Header.Caption = "Khối Lượng";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["KhoiLuong"].Header.VisiblePosition = 2;

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 3;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";            

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 4;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["DonGia"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["DonGia"].Format = "###,###,###,###,###";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["DonGia"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 5;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThanhTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThanhTien"].Format = "###,###,###,###,###";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThanhTien"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThueNK"].Header.VisiblePosition = 6;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThueNK"].Header.Caption = "Phần Trăm Thuế Nhập Khẩu";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThueNK"].MaskInput = "nn.nn";

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatNK"].Header.Caption =  "Thuế Suất NK";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatNK"].Header.VisiblePosition = 7;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatNK"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatNK"].Format = "###,###,###,###,###";

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThueVAT"].Header.Caption = "Phần Trăm Thuế VAT";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThueVAT"].Header.VisiblePosition = 8;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThueVAT"].MaskInput = "nn.nn";

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatVAT"].Header.Caption = "Thuế Suất VAT";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatVAT"].Header.VisiblePosition = 9;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatVAT"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatVAT"].Format = "###,###,###,###,###";

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThueTTDB"].Header.Caption = "Phần Trăm Thuế TTDB";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThueTTDB"].Header.VisiblePosition = 10;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThueTTDB"].MaskInput = "nn.nn";

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatTTDB"].Header.Caption = "Thuế Suất Tiêu Thụ Đặc Biệt";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatTTDB"].Header.VisiblePosition = 11;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatTTDB"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["ThueSuatTTDB"].Format = "###,###,###,###,###";

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThuKhac"].Header.Caption = "Phần Trăm Thu Khác";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThuKhac"].Header.VisiblePosition = 12;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["PhanTramThuKhac"].MaskInput = "nn.nn";

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["SoTienThuKhac"].Header.Caption = "Số Tiền Thu Khác";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["SoTienThuKhac"].Header.VisiblePosition = 13;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["SoTienThuKhac"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["SoTienThuKhac"].Format = "###,###,###,###,###";

            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["MaHangHoa"].Hidden = true;
            grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;  

            this.grdu_CTToKhaiThue.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_CTToKhaiThue.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_CTToKhaiThue.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
           // hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion 

        #region Lưu Dữ Liệu
        private Boolean LuuDuLieu()
        {            
            try
            {
                _toKhaiThue.ApplyEdit();
                _toKhaiThue.Save();
            }
            catch(ApplicationException ex)
            {
                return false; 
            }
            return true;
        }
        #endregion 

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu() == true)
            {
                if (LuuDuLieu() == true)
                    MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //    MessageBox.Show(this, "Cập Nhật Không Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion 

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region grdu_CTToKhaiThue_Leave
        private void grdu_CTToKhaiThue_Leave(object sender, EventArgs e)
        {
            decimal tongTien = 0;
            foreach (CT_ToKhaiThue ct_ToKhaiThue in _toKhaiThue.CT_ToKhaiThueList)
            {
                tongTien = tongTien + ct_ToKhaiThue.ThueSuatVAT + ct_ToKhaiThue.ThueSuatTTDB + ct_ToKhaiThue.ThueSuatNK;
            }
            _toKhaiThue.SoTien = tongTien; 
        }
        #endregion 

        #region grdu_CTToKhaiThue_KeyDown
        private void grdu_CTToKhaiThue_KeyDown(object sender, KeyEventArgs e)
        {
            decimal tongTien = 0;
            foreach (CT_ToKhaiThue ct_ToKhaiThue in _toKhaiThue.CT_ToKhaiThueList)
            {
                tongTien = tongTien + ct_ToKhaiThue.ThueSuatVAT + ct_ToKhaiThue.ThueSuatTTDB + ct_ToKhaiThue.ThueSuatNK;
            }
            _toKhaiThue.SoTien = tongTien;
        }
        #endregion 

        #region cb_LoaiTien_SelectedValueChanged
        private void cb_LoaiTien_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_LoaiTien != null)
            {
                LoaiTien loaiTien = (LoaiTien)(cb_LoaiTien.SelectedItem);
               //
                _toKhaiThue.MaLoaiTien = loaiTien.MaLoaiTien; 
                numu_TyGia.Value = loaiTien.TiGiaQuyDoi;
                _toKhaiThue.TyGia = loaiTien.TiGiaQuyDoi;
            }

        }
        #endregion 
    }
}
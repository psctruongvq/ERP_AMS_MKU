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
using System.Threading;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace PSC_ERP
{
    //fix
    public partial class frmCongTy : Form
    {
        #region Properties
    
        NganHangList _NganHangList;
        CongTy _CongTy;
        Util util = new Util();
        HamDungChung hdc = new HamDungChung();
        static byte[] value;
        string _Path;
        OpenFileDialog _OpenFileDialog;
        LoaiTienList _LoaiTienList;
        HeThongTaiKhoan1List _heThongTaiKhoan;
        #endregion

        #region Contructor
        public frmCongTy()
        {
            InitializeComponent();
            Them();
            KhoiTaoBanDau();
            //KhoiTao();
        }

        public frmCongTy(CongTy congTy)
        {
            InitializeComponent();
            _CongTy = congTy;
            KhoiTao();
        }
        #endregion

        #region KhoiTaoBanDau
        public void KhoiTaoBanDau()
        {
            _NganHangList = NganHangList.GetNganHangList();
            nganHangListBindingSource.DataSource = _NganHangList;
        }
        #endregion

        #region KhoiTao
        public void KhoiTao(CongTy CongTy)
        {
            pcBoxLogo.Image = null;
            congTyBindingSource.DataSource = _CongTy;

            diaChiCongTyListBindingSource.DataSource = _CongTy.DiaChi_CongTyList;
            congTyWebsiteEmailListBindingSource.DataSource = _CongTy.CongTy_Website_EmailList;
            congTyDienThoaiFaxListBindingSource.DataSource = _CongTy.CongTy_DienThoai_FaxList;
            congTyNganHangListBindingSource.DataSource = _CongTy.CongTy_NganHangList;

            _NganHangList = NganHangList.GetNganHangList();
            nganHangListBindingSource.DataSource = _NganHangList;
            TinhThanhList tinhList = TinhThanhList.GetTinhThanhList();
            this.TinhThanhDiaChi_BindingSource.DataSource = tinhList;

            _LoaiTienList = LoaiTienList.GetLoaiTienList();
            LoaiTien loaitien = LoaiTien.NewLoaiTien(0, "Chưa chọn");
            _LoaiTienList.Insert(0, loaitien);
            LoaiTien_BindingSource.DataSource = _LoaiTienList;

            _heThongTaiKhoan = HeThongTaiKhoan1List.GetHeThongTaiKhoanBySoHieu("112");
            HeThongTaiKhoan1 ht = HeThongTaiKhoan1.NewHeThongTaiKhoan1("Chưa chọn");
            _heThongTaiKhoan.Insert(0, ht);
            TKKeToan_bindingSource.DataSource = _heThongTaiKhoan;
        }

        public void KhoiTao()
        {
            pcBoxLogo.Image = null;
            congTyBindingSource.DataSource = _CongTy;
            diaChiCongTyListBindingSource.DataSource = _CongTy.DiaChi_CongTyList;
            congTyWebsiteEmailListBindingSource.DataSource = _CongTy.CongTy_Website_EmailList;
            congTyDienThoaiFaxListBindingSource.DataSource = _CongTy.CongTy_DienThoai_FaxList;
            congTyNganHangListBindingSource.DataSource = _CongTy.CongTy_NganHangList;

            _NganHangList = NganHangList.GetNganHangList();
            nganHangListBindingSource.DataSource = _NganHangList;
            TinhThanhList tinhList = TinhThanhList.GetTinhThanhList();
            this.TinhThanhDiaChi_BindingSource.DataSource = tinhList;

            _LoaiTienList = LoaiTienList.GetLoaiTienList();
            LoaiTien loaitien = LoaiTien.NewLoaiTien(0, "Chưa chọn");
            _LoaiTienList.Insert(0, loaitien);
            LoaiTien_BindingSource.DataSource = _LoaiTienList;

            _heThongTaiKhoan = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            HeThongTaiKhoan1 ht = HeThongTaiKhoan1.NewHeThongTaiKhoan1("Chưa chọn");
            _heThongTaiKhoan.Insert(0, ht);
            TKKeToan_bindingSource.DataSource = _heThongTaiKhoan;
        }
        #endregion
         
        #region Them
        public void Them()
        {
            _CongTy = CongTy.NewCongTy();
            congTyBindingSource.DataSource = _CongTy;

            diaChiCongTyListBindingSource.DataSource = _CongTy.DiaChi_CongTyList;
            congTyWebsiteEmailListBindingSource.DataSource = _CongTy.CongTy_Website_EmailList;
            congTyDienThoaiFaxListBindingSource.DataSource = _CongTy.CongTy_DienThoai_FaxList;
            congTyNganHangListBindingSource.DataSource = _CongTy.CongTy_NganHangList;
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            congTyBindingSource.EndEdit();
            diaChiCongTyListBindingSource.EndEdit();            
            congTyNganHangListBindingSource.EndEdit();
            congTyWebsiteEmailListBindingSource.EndEdit();
            congTyDienThoaiFaxListBindingSource.EndEdit();
            grdu_DiaChi.UpdateData();
            grdu_DienThoaiFax.UpdateData();
            grdu_WebEmail.UpdateData();
            grdu_TKNganHang.UpdateData();
            int dcActive = 0;
            int webActive = 0;
            int dtActive = 0;
            int stkActive = 0;
            try
            {
                foreach (DiaChi_CongTy dc in _CongTy.DiaChi_CongTyList)
                {
                    if (dc.Active == true)
                    {
                        dcActive++;
                    }
                }
                if (dcActive != 1 && _CongTy.DiaChi_CongTyList.Count>0)
                {
                    MessageBox.Show(this, "Chọn 1 địa chỉ làm địa chỉ chính của Công Ty", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (CongTy_DienThoai_Fax dt in _CongTy.CongTy_DienThoai_FaxList)
                {
                    if (dt.Active == true)
                    {
                        dtActive++;
                    }
                }
                if (dtActive != 1 && _CongTy.CongTy_DienThoai_FaxList.Count>0)
                {
                    MessageBox.Show(this, "Chọn 1 điện thoại làm điện thoại chính của Công Ty", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (CongTy_Website_Email web in _CongTy.CongTy_Website_EmailList)
                {
                    if (web.Active == true )
                    {
                        webActive++;
                    }
                }
                if (webActive != 1&& _CongTy.CongTy_Website_EmailList.Count>0)
                {
                    MessageBox.Show(this, "Chọn 1 website làm website chính của Công Ty", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (CongTy_NganHang nh in _CongTy.CongTy_NganHangList)
                {
                    if (nh.Active == true)
                    {
                        stkActive++;
                    }
                }
                if (stkActive != 1&&_CongTy.CongTy_NganHangList.Count>0)
                {
                    MessageBox.Show(this, "Chọn 1 Tài khoản làm Tài khoản chính của Công Ty", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _CongTy.ApplyEdit();
                _CongTy.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                throw ex;
            }
                
        }
            
   
        #endregion

        #region grdu_DiaChi_InitializeLayout
        private void grdu_DiaChi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
          
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DiaChi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            //màu nền
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Active"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.Caption = "Tỉnh Thành";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Active"].Header.Caption = "Địa Chỉ Chính";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 0;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.VisiblePosition = 1;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Active"].Header.VisiblePosition = 2;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaTinhThanh"].EditorComponent=cmbu_DiaChiTinhThanh;

            hdc.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region grdu_DienThoaiFax_InitializeLayout
        private void grdu_DienThoaiFax_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
           
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_DienThoaiFax.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            grdu_DienThoaiFax.DisplayLayout.Bands[0].Columns["DienThoai"].Hidden = false;
            grdu_DienThoaiFax.DisplayLayout.Bands[0].Columns["Active"].Hidden = false;
            grdu_DienThoaiFax.DisplayLayout.Bands[0].Columns["Fax"].Hidden = false;
            grdu_DienThoaiFax.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            grdu_DienThoaiFax.DisplayLayout.Bands[0].Columns["Fax"].Header.Caption = "Fax";
            grdu_DienThoaiFax.DisplayLayout.Bands[0].Columns["Active"].Header.Caption = "Sử Dụng Chính";
            grdu_DienThoaiFax.DisplayLayout.Bands[0].Columns["DienThoai"].Header.VisiblePosition = 0;
            grdu_DienThoaiFax.DisplayLayout.Bands[0].Columns["Fax"].Header.VisiblePosition = 1;
            grdu_DienThoaiFax.DisplayLayout.Bands[0].Columns["Active"].Header.VisiblePosition = 2;
            
            hdc.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region grdu_TKNganHang_InitializeLayout
        private void grdu_TKNganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_TKNganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Hidden = false;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["Active"].Hidden = false;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["SoUNCBatDau"].Hidden = false;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["LoaiTien"].Hidden = false;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaTKKeToan"].Hidden = false;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaUNCNganHang"].Hidden = false;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.Caption = "Ngân hàng";
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số tài khoản";
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["LoaiTien"].Header.Caption = "Loại tiền";
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["SoUNCBatDau"].Header.Caption = "Số bắt đầu";
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["Active"].Header.Caption = "Sử dụng chính";
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaTKKeToan"].Header.Caption = "TK kế toán";
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaUNCNganHang"].Header.Caption = "Mã UNC";

            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.VisiblePosition = 0;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 1;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["LoaiTien"].Header.VisiblePosition = 2;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["SoUNCBatDau"].Header.VisiblePosition = 3;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["Active"].Header.VisiblePosition = 5;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaTKKeToan"].Header.VisiblePosition = 6;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaUNCNganHang"].Header.VisiblePosition = 4;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaTKKeToan"].EditorComponent = cmb_TKKeToan;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].EditorComponent = cmbu_NganHang;
            grdu_TKNganHang.DisplayLayout.Bands[0].Columns["LoaiTien"].EditorComponent = cmb_LoaiTien;

            hdc.ultragrdEmail_InitializeLayout(sender, e);

            FilterCombo filter = new FilterCombo(grdu_TKNganHang, "MaNganHang", "TenNganHang");
        }
        #endregion

        #region cmbu_NganHang_InitializeLayout
        private void cmbu_NganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_NganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Hidden = true;
            cmbu_NganHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            cmbu_NganHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Ngân Hàng";
            cmbu_NganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";

            cmbu_NganHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            cmbu_NganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 1;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_NganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
          
        }
        #endregion

        #region grdu_WebEmail_InitializeLayout_1
        private void grdu_WebEmail_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
          
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_WebEmail.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdu_WebEmail.DisplayLayout.Bands[0].Columns["Website"].Hidden = false;
            grdu_WebEmail.DisplayLayout.Bands[0].Columns["Active"].Hidden = false;
            grdu_WebEmail.DisplayLayout.Bands[0].Columns["Email"].Hidden = false;
            grdu_WebEmail.DisplayLayout.Bands[0].Columns["Website"].Header.Caption = "Website";
            grdu_WebEmail.DisplayLayout.Bands[0].Columns["Email"].Header.Caption = "Số Tài Khoản";
            grdu_WebEmail.DisplayLayout.Bands[0].Columns["Active"].Header.Caption = "Sử Dụng Chính";
            grdu_WebEmail.DisplayLayout.Bands[0].Columns["Website"].Header.VisiblePosition = 0;
            grdu_WebEmail.DisplayLayout.Bands[0].Columns["Email"].Header.VisiblePosition = 1;
            grdu_WebEmail.DisplayLayout.Bands[0].Columns["Active"].Header.VisiblePosition = 2;
            
            hdc.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region btn_ChonLoGo_Click
        private void btn_ChonLoGo_Click(object sender, EventArgs e)
        {
            _Path = Application.StartupPath;
            _OpenFileDialog = new OpenFileDialog();
            _OpenFileDialog.Title = "Chọn file cần đính kèm";
            _OpenFileDialog.InitialDirectory = _Path;
            if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                value = ConvertFileToBinary(_OpenFileDialog);
                _CongTy.Logo = value;
            }
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            Them();
        }
        #endregion

        #region grdu_WebEmail_TextChanged
        private void grdu_WebEmail_TextChanged(object sender, EventArgs e)
        {
            if (Util.KiemTraDiaChiEmail(grdu_WebEmail.ActiveRow.Cells["DiaChi"].Value.ToString()) == false)
            {
                MessageBox.Show(this, util.emailkhonghople, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmDanhSachCongTy f = new frmDanhSachCongTy();
            f.Show();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_CongTysAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptTinhThanh(), new frmHienThiReport(), false);            

        }

        private void ultraTextEditor_MNS_ValueChanged(object sender, EventArgs e)
        {

        }
        private byte[] ConvertFileToBinary(OpenFileDialog openFileDialog)
        {
            value = new byte[0];
            MemoryStream ms = new MemoryStream();
            if (openFileDialog.FileName.Trim() != string.Empty)
            {

                Bitmap image1 = new Bitmap(openFileDialog.FileName, true);
                Bitmap image2 = new Bitmap(image1, new Size(100, 120));
                image2.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                value = ms.GetBuffer();
                pcBoxLogo.Image = image2;
                ultraTextEditor_MNS.Value = image2;
                ms.Close();
                ms.Dispose();


            }
            return value;

        }

        private void ultraTextEditor_MNS_Click(object sender, EventArgs e)
        {
            OpenFileDialog _OpenFileDialog;

            string _Path = Application.StartupPath;
            _OpenFileDialog = new OpenFileDialog();
            _OpenFileDialog.Title = "Chọn file cần đính kèm";
            _OpenFileDialog.InitialDirectory = _Path;
            if (_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                value = ConvertFileToBinary(_OpenFileDialog);
            }
        }

        private void ultraTextEditor1_Click(object sender, EventArgs e)
        {
            pcBoxLogo.Image = null;
        }

        private void cmbu_DiaChiTinhThanh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {  //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_DiaChiTinhThanh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmbu_DiaChiTinhThanh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên tỉnh thành";
            cmbu_DiaChiTinhThanh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Hidden = false;
        }

        private void cmb_LoaiTien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_LoaiTien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmb_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.Caption = "Loại tiền";
            cmb_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Header.VisiblePosition = 0;
            cmb_LoaiTien.DisplayLayout.Bands[0].Columns["MaLoaiQuanLy"].Hidden = false;

            cmb_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.Caption = "Tên loại tiền";
            cmb_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Header.VisiblePosition = 1;
            cmb_LoaiTien.DisplayLayout.Bands[0].Columns["TenLoaiTien"].Hidden = false;

        }

        private void cmb_TKKeToan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_TKKeToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmb_TKKeToan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số hiệu tài khoản";
            cmb_TKKeToan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            cmb_TKKeToan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cmb_TKKeToan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 150;

            cmb_TKKeToan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên tài khoản";
            cmb_TKKeToan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
            cmb_TKKeToan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cmb_TKKeToan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 300;
        }
    }
}

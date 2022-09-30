using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class frmDanhSachCongTy : Form
    {
        //ok
        static byte[] value;
        CongTyList _CongTyList = CongTyList.NewCongTyList();
        CongTy _CongTy;
        Util util = new Util();
        NganHangList _nganHangList ;
        CongTy_NganHangList _congTy_NganHangList;
        int maCongTy = 0;
        public frmDanhSachCongTy()
        {
            InitializeComponent();
            this.KeyPreview = true;
            LayDuLieu();

            tlslblTim.Visible = false;
            toolStripSeparator4.Visible = false;

            tlslblXoa.Visible = false;
            toolStripSeparator3.Visible = false;
        }

        private void LayDuLieu()
        {
            _nganHangList = NganHangList.GetNganHangList();
            this.nganHangListBindingSource.DataSource = _nganHangList;
            _CongTyList = CongTyList.GetCongTyList();
            string diaChi= "";
            string dienThoai= "";
            string fax = "";
            string web = "";
            string email = "";
            string tenNganHang = "";
            string soTK = "";

            for (int i = 0; i < _CongTyList.Count; i++)
            {
                for (int j = 0; j < _CongTyList[i].DiaChi_CongTyList.Count; j++)
                {
                    if (_CongTyList[i].DiaChi_CongTyList[j].Active == true)
                    {
                        diaChi = _CongTyList[i].DiaChi_CongTyList[j].DiaChi;
                        _CongTyList[i].DiaChi = diaChi;
                        
                        break;
                    }
                }
                for (int k = 0; k < _CongTyList[i].CongTy_DienThoai_FaxList.Count; k++)
                {
                    if (_CongTyList[i].CongTy_DienThoai_FaxList[k].Active == true)
                    {
                        dienThoai = _CongTyList[i].CongTy_DienThoai_FaxList[k].DienThoai;
                        fax = _CongTyList[i].CongTy_DienThoai_FaxList[k].Fax;
                        _CongTyList[i].DienThoai = dienThoai;
                        _CongTyList[i].Fax = fax;
                        break;
                    }
                }
                for (int l = 0; l < _CongTyList[i].CongTy_Website_EmailList.Count; l++)
                {
                    if (_CongTyList[i].CongTy_Website_EmailList[l].Active == true)
                    {
                        web = _CongTyList[i].CongTy_Website_EmailList[l].Website;
                        email = _CongTyList[i].CongTy_Website_EmailList[l].Email;
                        _CongTyList[i].Website = web;
                        _CongTyList[i].Email = email;
                        break;
                    }
                }
                for (int m = 0; m < _CongTyList[i].CongTy_NganHangList.Count; m++)
                {
                    if (_CongTyList[i].CongTy_NganHangList[m].Active == true)
                    {
                        soTK = _CongTyList[i].CongTy_NganHangList[m].SoTaiKhoan;                        
                        tenNganHang = _CongTyList[i].CongTy_NganHangList[m].TenNganHang;
                        int maNganHang = _CongTyList[i].CongTy_NganHangList[m].MaNganHang;
                        _CongTyList[i].MaNganHang = maNganHang;
                        _CongTyList[i].SoTaiKhoan = soTK;
                        _CongTyList[i].TenNganHang = tenNganHang;    
                        break;
                    }
                }
            }
                CongTyList_BindingSource.DataSource = _CongTyList;
            _congTy_NganHangList = CongTy_NganHangList.GetCongTy_NganHangList(maCongTy);
            this.bindingSource1_CongTyNganHangList.DataSource = _congTy_NganHangList;
        }

        private void grdu_DiaChi_DoubleClick(object sender, EventArgs e)
        {
            _CongTy = CongTy.GetCongTy((int)grdu_DiaChi.ActiveRow.Cells["MaCongTy"].Value);
            frmCongTy _frmCongTy = new frmCongTy(_CongTy);
            if (_frmCongTy.ShowDialog() != DialogResult.OK)
            {
                if (_CongTy != null)
                {
                    LayDuLieu();
                }
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblLamTuoi_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

       

        private void grdu_DiaChi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);


            e.Layout.Bands[4].Override.AllowAddNew = AllowAddNew.FixedAddRowOnTop;
           // e.Layout.Bands[4].
            foreach (UltraGridColumn col in this.grdu_DiaChi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaCongTyQuanLy"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaCongTyQuanLy"].Header.Caption = "Mã Công Ty";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaCongTyQuanLy"].Header.VisiblePosition = 0;
           
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["TenCongTy"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["TenCongTy"].Header.Caption = "Tên Công Ty";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["TenCongTy"].Width = 200;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["TenCongTy"].Header.VisiblePosition = 1;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["TenTiengAnh"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["TenTiengAnh"].Header.Caption = "Tên Tiếng Anh";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["TenTiengAnh"].Header.VisiblePosition = 2;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 3;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 4;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaNganHang"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaNganHang"].EditorComponent = cbNganHang;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.Caption = "Ngân Hàng";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaNganHang"].Width = cbNganHang.Width;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.VisiblePosition = 5;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số Tài Khoản";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Width = 100;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 6;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["DienThoai"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Số Điện Thoại";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["DienThoai"].Header.VisiblePosition = 7;

            //grdu_DiaChi.DisplayLayout.Bands[0].Columns["DienThoai1"].Hidden = false;
            //grdu_DiaChi.DisplayLayout.Bands[0].Columns["DienThoai1"].Header.Caption = "Số Điện Thoại 1";
            //grdu_DiaChi.DisplayLayout.Bands[0].Columns["DienThoai1"].Header.VisiblePosition = 8;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Fax"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Fax"].Header.Caption = "Fax";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Fax"].Header.VisiblePosition = 9;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Website"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Website"].Header.Caption = "Website";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Website"].Header.VisiblePosition = 10;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Email"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Email"].Header.Caption = "Email";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Email"].Header.VisiblePosition = 11;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 12;

            //grdu_DiaChi.DisplayLayout.Bands[0].Columns["DiaChi1"].Hidden = false;
            //grdu_DiaChi.DisplayLayout.Bands[0].Columns["DiaChi1"].Header.Caption = "Địa chỉ 1";
            //grdu_DiaChi.DisplayLayout.Bands[0].Columns["DiaChi1"].Header.VisiblePosition = 13;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Logo"].Hidden = false;
            
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Logo"].Header.Caption = "Logo";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["Logo"].Header.VisiblePosition = 14;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 15;
            e.Layout.Bands[0].Columns["Logo"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.ImageWithShadow;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["SoDVSDNS"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["SoDVSDNS"].Header.Caption = "Số ĐVSDNS";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["SoDVSDNS"].Header.VisiblePosition = 16;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["NgayChanSoLieu"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["NgayChanSoLieu"].Header.Caption = "Ngày chặn số liệu";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["NgayChanSoLieu"].Header.VisiblePosition = 17;

            grdu_DiaChi.DisplayLayout.Bands[0].Columns["CongThue"].Hidden = false;
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["CongThue"].Header.Caption = "Cộng Thuế";
            grdu_DiaChi.DisplayLayout.Bands[0].Columns["CongThue"].Header.VisiblePosition = 18;
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
              //  pcBoxLogo.Image = image2;
              //  ultraTextEditor_MNS.Value = image2;
                ms.Close();
                ms.Dispose();

           
            }
            return value;

        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                this.CongTyList_BindingSource.EndEdit();
                grdu_DiaChi.UpdateData();
                _CongTyList.ApplyEdit();
                using (DialogUtil.Wait(this))
                {
                    _CongTyList.Save();
                    LayDuLieu();
                }
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.strStatus = "KHOA";
                this.ReadOnlyConTrolByStatus(this.strStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

     
        private void grdu_DiaChi_BeforeRowInsert(object sender, BeforeRowInsertEventArgs e)
        {
           // pcBoxLogo.Image = null;
        }

        private void CongTyList_BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //CongTy ct= CongTy.GetCongTy(((CongTy)this.CongTyList_BindingSource.Current).MaCongTy);
            //if(ct.Logo!=null)
            //{

            //    MemoryStream stream = new MemoryStream(((CongTy)this.CongTyList_BindingSource.Current).Logo);
            //    Image image = Image.FromStream(stream);
            //    pcBoxLogo.Image = image;
            //}
            //else
            //    pcBoxLogo.Image = null;
        }

        private void ultraTextEditor_MNS_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmDanhSachCongTy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                tlslblLuu.PerformClick();
            }
        }
        // phân wuyen 
        private void ReadOnlyConTrolByStatus(string _strStatus)
        {
            if (_strStatus == "" || _strStatus == "THEM" || _strStatus == "SUA")
            {
                btnSua.Visible = false;
                btnThem.Visible = false;
                tlslblLuu.Visible = true;
                btnTroLai.Visible = true;
            }
            else if (_strStatus == "KHOA")
            {
                btnSua.Visible = true;
                tlslblLuu.Visible = false;
                btnThem.Visible = true;
                btnTroLai.Visible = false;
               // CongTyList_BindingSource.AllowNew = false;// chặn add dòng mới 
                //grdu_DiaChi.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
                
                ReadOnly(true);
            }
            PhanQuyenThemSuaXoa();
        }
        public string strStatus = "KHOA";
        PhanQuyenSuDungForm _phanQuyen = null;
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(ERP_Library.Security.CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btnThem.Enabled = _phanQuyen.Them;
            btnSua.Enabled = _phanQuyen.Sua;
            //tlslblXoa.Enabled = _phanQuyen.Xoa;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            CongTyList_BindingSource.AddNew();
            ReadOnly(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            ReadOnly(false);
        }

        private void frmDanhSachCongTy_Load(object sender, EventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            grdu_DiaChi.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            using (DialogUtil.Wait(this))
                LayDuLieu();
        }
        private void ReadOnly(bool Bat=false) // bằng true là tắt chỉnh sửa
        {
            for (int i = 0; i < grdu_DiaChi.DisplayLayout.Bands.Count; i++)
            {
                foreach (UltraGridColumn col in this.grdu_DiaChi.DisplayLayout.Bands[i].Columns)
                {
                    if(Bat)
                        col.CellActivation = Activation.ActivateOnly;
                    else
                        col.CellActivation = Activation.AllowEdit;
                }
            }
        }
    }
}
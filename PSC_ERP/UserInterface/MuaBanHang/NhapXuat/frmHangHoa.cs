using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Shared;
using System.IO;
using System.Windows.Forms;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmHangHoa : Form
    {
        #region Properties & Nap Du Lieu - Khoi Tao Form
        private Util util = new Util();
        HamDungChung _hamDC = new HamDungChung();
        private NhomHangHoa_C1List _NhomHangHoa_C1List=NhomHangHoa_C1List.NewNhomHangHoa_C1List();
        private LoaiHangHoaList _loaiHHList = LoaiHangHoaList.NewLoaiHangHoaList();
        private DonViTinhList _dvtList = DonViTinhList.NewDonViTinhList();                
        private QuocGiaList _quocGiaList = QuocGiaList.NewQuocGiaList();
        private HangHoaList _hangHoaList = HangHoaList.NewHangHoaList();        
        private HangHoa _hangHoa;// = HangHoa.NewHangHoa();
        public delegate void GetData(HangHoaList value);
        public GetData getData;
        private LoaiVangList _loaiVangList = LoaiVangList.NewLoaiVangList();
        public static int MaMauMa;
        public static bool _laLenhNhapNau = false;
        int _flag = 0;

        private void NapDuLieu()
        {
            //_NhomHangHoa_C1List = NhomHangHoa_C1List.
           
            //_nhomHHList = NhomHangHoaList.GetNhomHangHoaList(0);
            _loaiHHList = LoaiHangHoaList.GetLoaiHangHoaList_MuaBan();
            _dvtList = DonViTinhList.GetDonViTinhList();                     
            _quocGiaList = QuocGiaList.GetQuocGiaList();           
            
           
            //_phuKienHHList = PhuKienHHList.GetPhuKienHHList(0);
        }

        private void GanDuLieu()
        {
            //hangHoaBindingSource.DataSource = _hangHoa;
           
            loaiHangHoaListBindingSource.DataSource = _loaiHHList;
            DonViTinh _dvt = DonViTinh.NewDonViTinh(0, "Thêm mới...");
            _dvtList.Insert(0, _dvt);
            donViTinhListBindingSource.DataSource = _dvtList;           
            
            QuocGia _quocGia = QuocGia.NewQuocGia( 0,"Thêm mới...");
            _quocGiaList = QuocGiaList.GetQuocGiaList();
            _quocGiaList.Insert(0, _quocGia);
            quocGiaListBindingSource.DataSource = _quocGiaList;  
          
            LoaiVang _LoaiVang = LoaiVang.NewLoaiVang(0, "Thêm mới...");
            _loaiVangList = LoaiVangList.GetLoaiVangList();
            _loaiVangList.Insert(0, _LoaiVang);
            
        }
       
        #endregion

        #region Constructor

        public frmHangHoa()
        {
            InitializeComponent();
            _hamDC.EventForm(this);           
            ThemDL();
           // this.NapDuLieu();
            //this.GanDuLieu();
            //for (float i = (float)(42.00); i < (float)(100.00); i += (float)(0.01))
            //    cmb_TuoiVang.Add(i.ToString("#,###.00"));
        }
       

        public frmHangHoa(HangHoa hanghoa)
        {
            InitializeComponent();
            _hamDC.EventForm(this);          
            _hangHoa = hanghoa;
            hangHoaBindingSource.DataSource = _hangHoa;
        }
      

        #endregion
        
        #region Events

        #region ThemDL()
        public void ThemDL()
        {
            try
            {
                _hangHoa = HangHoa.NewHangHoa();                
                this.NapDuLieu();
                this.GanDuLieu();
                hangHoaBindingSource.DataSource = _hangHoa;
               
                //cmb_VatTu1.Text = "";               
                cmbu_LoaiHH.Text = "";
                cmbu_XuatXu.Text = "";
                cmbu_DVT.Text = "";               
                ShowDataComBo();
            }
            catch (ApplicationException ex)
            {
                //throw ex;
                return;
            }
        }
        #endregion

        #region Kiểm Tra dữ liệu nhập
        public bool KiemTra()
        {
            bool kq = true;
            if (_hangHoa.MaQuanLy == string.Empty)
            {
                MessageBox.Show(this, "Vui lòng nhập mã hàng hóa.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaQuanLy.Focus();
                kq = false;
                return kq;
            }
            if (txt_TenHH.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui lòng nhập tên hàng hóa.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenHH.Focus();
                kq = false;
                return kq;
            }
            //if (_hangHoa.MaLoaiHangHoa==null)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn loại hàng hóa.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbu_LoaiHH.Focus();
            //    kq = false;
            //    return kq;
            //}
             if (cmbu_LoaiHH.SelectedRow == null)
            {
                MessageBox.Show(this, "Vui lòng chọn loại hàng hóa.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_LoaiHH.Focus();
                cmbu_LoaiHH.Select();
                kq = false;
                return kq;
            }
        
                            
            //if(pib_MauMa.Image == null)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn hình cho hàng hóa", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    pib_MauMa.Focus();
            //    kq = false;
            //    return kq;
            //}
            return kq;
        }
        #endregion

        #region Kiểm tra Mã HH trước khi lưu
        /// <summary>
        /// Kiểm tra Mã HH trước khi lưu. Return True if ko trùng, và ngược lại.
        /// </summary>
        /// <returns></returns>
        public Boolean KTraMaHangHoaLuu()
        {
            Boolean kq = true;
            if (HangHoa.KiemTraMaHangHoa(txt_MaQuanLy.Text) == 0)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "Mã hàng hóa này bị trùng lặp. Vui lòng nhập mã hàng hóa khác.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaQuanLy.Text = "";
                txt_MaQuanLy.Focus();
                txt_MaQuanLy.SelectAll();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion

        #region Thao Tác Trên Form

        #region Các Thao Tác Chức Năng Thêm-Xóa,...

        private void tlsThem_Click(object sender, EventArgs e)
        {
            ThemDL();
        }

        public void ShowDataComBo()
        {
           
            if (cmbu_XuatXu.Rows.Count > 0)
                //cmbu_XuatXu.Value = _quocGiaList[0].MaQuocGia;
                _hangHoa.MaQuocGia = _quocGiaList[1].MaQuocGia;
            if (cmbu_DVT.Rows.Count > 0)
                //cmbu_DVT.Value = _dvtList[0].MaDonViTinh;
                _hangHoa.MaDonViTinh = _dvtList[1].MaDonViTinh;            
        }
        
      
        private void tlsTroVe_Click(object sender, EventArgs e)
        {
            try
            {                
                this.NapDuLieu();
                this.GanDuLieu();
            }
            catch (ApplicationException ex)
            {
                //throw ex;
                return;
            }
        }

        private void tlsTim_Click(object sender, EventArgs e)
        {
            int _maNhomHH, _maNhomHH_C1,_maLoaiHH;
            //frmTimHangHoa frm = new frmTimHangHoa();
            frmHangHoa_Tim frm = new frmHangHoa_Tim();
            //frm.MdiParent = this;
            if (frm.ShowDialog() != DialogResult.OK)
            {
                if (frm._hangHoa != null)
                {
                    _hangHoa = frm._hangHoa;
                    hangHoaBindingSource.DataSource = _hangHoa;                                     
                    _maLoaiHH = _hangHoa.MaLoaiHangHoa;
                    _loaiHHList = LoaiHangHoaList.GetLoaiHangHoaList_MuaBan();
                    loaiHangHoaListBindingSource.DataSource = _loaiHHList;                    
                    cmbu_LoaiHH.Value = _hangHoa.MaLoaiHangHoa;
                }
            }
        }

        private void tlsIn_Click(object sender, EventArgs e)
        {

        }

        private void tlsTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Hang Hoa", "Help_SanXuat.chm");
        }

        private void tlsThoat_Click(object sender, EventArgs e)
        {
           
                this.Close();
        }
        #endregion

        

        #endregion


        #region cmbu_LoaiHH_InitializeLayout
        private void cmbu_LoaiHH_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_LoaiHH.DisplayLayout.Bands[0],
            new string[3] { "MaQuanLy", "TenLoaiHangHoa", "DienGiai" },
            new string[3] { "Mã Loại HH", "Tên Loại HH", "Diễn Giải" },
            new int[3] { 100, 150, 120 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_LoaiHH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmbu_LoaiHH.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_LoaiHH.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion     

     
        #region cmbu_DVT_InitializeLayout
        private void cmbu_DVT_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_DVT.DisplayLayout.Bands[0],
            new string[3] { "MaQuanLy", "TenDonViTinh", "DienGiai" },
            new string[3] { "Mã ĐVT", "Tên ĐVT", "Diễn Giải" },
            new int[3] { 100, 150, 120 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_DVT.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmbu_DVT.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_DVT.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region cmbu_XuatXu_InitializeLayout
        private void cmbu_XuatXu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_XuatXu.DisplayLayout.Bands[0],
            new string[3] { "MaQuocGiaQuanLy", "TenQuocGia", "DienGiai" },
            new string[3] { "Mã Quốc Gia", "Tên Quốc Gia", "Diễn Giải" },
            new int[3] { 100, 150, 120 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { true, true, true });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_XuatXu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmbu_XuatXu.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_XuatXu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion
        
        #region cmb_NhomHHC1_Leave
        private void cmb_NhomHHC1_Leave(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region cmb_NhomHH_Leave
        private void cmb_NhomHH_Leave(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region cmb_VatTu1_Leave
        private void cmb_VatTu1_Leave(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region cmb_TuoiVang_Leave
        //private void cmb_TuoiVang_Leave(object sender, EventArgs e)
        //{
        //    if (_hangHoa != null)
        //    {
        //        _hangHoa.TuoiVang = decimal.Parse(cmb_TuoiVang.Text);
        //    }
        //}
        #endregion

        #region cmbu_LoaiHH_Leave
        private void cmbu_LoaiHH_Leave(object sender, EventArgs e)
        {
            //if (_loaiHHList.Count == 0)
            //{
            //    _loaiHHList.Add(new LoaiHangHoa());// = LoaiHangHoaList.NewLoaiHangHoaList();
            //    loaiHangHoaListBindingSource.DataSource = _loaiHHList;
            //}
            if (_hangHoa != null)
            {
                if (cmbu_LoaiHH.Value != null)
                {
                    _hangHoa.MaLoaiHangHoa = (int)(cmbu_LoaiHH.Value);
                }
            }
            return;
        }
        #endregion

     
        
        private void tlsLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_hangHoa.IsNew == true)
                {
                    if (KiemTra() == true)
                    {
                        if (KTraMaHangHoaLuu() == true)
                        {
                            try
                            {                              
                                _hangHoaList.Add(_hangHoa);
                                _hangHoaList.ApplyEdit();
                                hangHoaBindingSource.EndEdit();                              
                                _hangHoaList.Save();
                                MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (getData != null)
                                    getData(_hangHoaList);
                            }
                            catch (ApplicationException ex)
                            {
                                //MessageBox.Show(this, util.luuthatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //string tem = ex.Message;
                                return;
                            }
                        }
                    }
                    else
                        return;
                }
                else
                {
                    try
                    {
                      
                        _hangHoaList.Add(_hangHoa);
                        _hangHoaList.ApplyEdit();
                        hangHoaBindingSource.EndEdit();                        
                        _hangHoaList.Save();
                        MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (getData != null)
                            getData(_hangHoaList);
                    }
                    catch (ApplicationException ex)
                    {
                        //MessageBox.Show(this, util.luuthatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //string tem = ex.Message;
                        return;
                    }
                }
            }
            catch (ApplicationException ex)
            {
                //throw ex;
                return;
            }
        }

       

       

        private void cmbu_LoaiHH_ValueChanged(object sender, EventArgs e)
        {
            //if (_loaiHHList.Count == 0)
            //{
            //    _loaiHHList.Add(new LoaiHangHoa());// = LoaiHangHoaList.NewLoaiHangHoaList();
            //    loaiHangHoaListBindingSource.DataSource = _loaiHHList;
            //}
            if (_hangHoa != null)
            {
                if (cmbu_LoaiHH.Value != null)
                {
                    _hangHoa.MaLoaiHangHoa = (int)(cmbu_LoaiHH.Value);
                }
            }
            return;
        }

      
        public void GetList(object value)
        {         
         
          
            if (value.ToString().Contains("ERP_Library.LoaiHangHoaList"))
            {
                LoaiHangHoa _LoaiHH = LoaiHangHoa.NewLoaiHangHoa("Thêm mới...",0);
               
                _loaiHHList.Insert(0, _LoaiHH);
                loaiHangHoaListBindingSource.DataSource = _loaiHHList;
            }
            if (value.ToString().Contains("ERP_Library.QuocGiaList"))
            {
                QuocGia _quocGia = QuocGia.NewQuocGia( 0,"Thêm mới...");
                _quocGiaList = QuocGiaList.GetQuocGiaList();
                _quocGiaList.Insert(0, _quocGia);
                quocGiaListBindingSource.DataSource = _quocGiaList;
            }
            if (value.ToString().Contains("ERP_Library.DonViTinhList"))
            {
                DonViTinh _dvt = DonViTinh.NewDonViTinh(0, "Thêm mới...");
                _dvtList = DonViTinhList.GetDonViTinhList();
                _dvtList.Insert(0, _dvt);
                donViTinhListBindingSource.DataSource = _dvtList;
            }
            
        }

       

        private void cmbu_LoaiHH_AfterCloseUp(object sender, EventArgs e)
        {
            cmbu_LoaiHH_ValueChanged(null, null);
            if (cmbu_LoaiHH.ActiveRow != null)
            {
                if (cmbu_LoaiHH.ActiveRow.Index == 0)
                {
                    frmLoaiHangHoa frm = new frmLoaiHangHoa();
                    frm.getData = new frmLoaiHangHoa.GetData(GetList);
                    frm.Show();
                }
            }
            return;
        }

        private void cmbu_XuatXu_AfterCloseUp(object sender, EventArgs e)
        {            
            if (cmbu_XuatXu.ActiveRow != null)
            {
                if (cmbu_XuatXu.ActiveRow.Index == 0)
                {
                    frmQuocGia frm = new frmQuocGia();
                    frm.getData = new frmQuocGia.PassData(GetList);
                    frm.Show();
                }
            }
            return;
        }

      
        private void cmbu_DVT_AfterCloseUp(object sender, EventArgs e)
        {
            if (cmbu_DVT.ActiveRow != null)
            {
                if (cmbu_DVT.ActiveRow.Index == 0)
                {
                    frmDonViTinh frm = new frmDonViTinh();
                    frm.getData = new frmDonViTinh.GetData(GetList);
                    frm.Show();
                }
            }
            return;
        }     

        #endregion

     
        private void cmb_NhomHHC1_BeforeDropDown(object sender, CancelEventArgs e)
        {
            _flag = 0;
        }

        private void cmb_NhomHHC1_Click(object sender, EventArgs e)
        {
            _flag = 0;
        }

        private void cmb_NhomHH_Click(object sender, EventArgs e)
        {
            _flag = 0;
        }

        private void cmb_NhomHH_BeforeDropDown(object sender, CancelEventArgs e)
        {
            _flag = 0;
        }


        private void frmHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Hang Hoa", "Help_SanXuat.chm");
            }
        }
    }
}

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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;


namespace PSC_ERP
{
    public partial class frmDSPhieuNhapXuat : Form
    {
        #region properties & Constructors
        HamDungChung _hamDC = new HamDungChung();
        PhieuNhapXuatList _PhieuNhapXuatList;
        Util util = new Util();
        public PhieuNhapXuat phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
        public PhieuNhapXuatList _dsPhieuNhapXuat = PhieuNhapXuatList.NewPhieuNhapXuatList();
        public PhieuNhapXuat _PhieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();

        /// <summary>
        /// Loại: 5: chuyển kho; 6: Nấu
        /// </summary>
        public byte _LoaiLenhNhap;
        public short Loai;
        private bool LaNhap;
        public bool _lapLenhNhap;
        public decimal _tuoiVang;
        public int _maKhoNhanCongNau;
        //public LenhNhapXuat _lenhNhapXuat;// = LenhNhapXuat.NewLenhNhapXuat(6);
        public bool _lapLenhNhapBPKhac = false;
        private byte QuyTrinh = 2;
        private int _maKho;
        private int _maKy;

        public frmDSPhieuNhapXuat()
        {
            InitializeComponent();
        }

        public frmDSPhieuNhapXuat(short loai, bool laNhap, byte quyTrinh)
        {
            InitializeComponent();
            _hamDC.EventForm(this);
            _hamDC.EventGrid(grdu_DanhSachPhieuNhapXuat);
            LaNhap = laNhap;
            Loai = loai;
            QuyTrinh = quyTrinh;
            KhoiTao(loai, laNhap);
            Invisible1();
            //if (loai == 2)
            //{
            //    grdu_DanhSachPhieuNhapXuat.DoubleClick -= new EventHandler(grdu_DanhSachPhieuNhapXuat_DoubleClick);
            //    grdu_DanhSachPhieuNhapXuat.CellChange+=new CellEventHandler(grdu_DanhSachPhieuNhapXuat_CellChange);
            //}
        }

        /// <summary>
        /// Loại: 1: NX nau; 2: NX SX khac; 5: Nhập Kho Thành Phẩm;
        ///       18: NX nấu Làm Lại; 16: NX SX khac Làm Lại;  17: Phiếu Nhập Kho Thành Phẩm Làm Lại
        /// </summary>
        /// <param name="loai"></param>
        /// <param name="laNhap"></param>
        public frmDSPhieuNhapXuat(short loai, bool laNhap)
        {
            InitializeComponent();
            _hamDC.EventForm(this);
            _hamDC.EventGrid(grdu_DanhSachPhieuNhapXuat);
            LaNhap = laNhap;
            Loai = loai;
          
            KhoiTao(loai, laNhap);
            Invisible();
            //if (loai == 2)
            //{
            //    grdu_DanhSachPhieuNhapXuat.DoubleClick -= new EventHandler(grdu_DanhSachPhieuNhapXuat_DoubleClick);
            //    grdu_DanhSachPhieuNhapXuat.CellChange+=new CellEventHandler(grdu_DanhSachPhieuNhapXuat_CellChange);
            //}
        }

        /// <summary>
        /// Danh sách phiếu nhập xuất điều chỉnh tồn kho
        /// </summary>
        /// <param name="loai">Kho cần điều chỉnh</param>
        /// <param name="laNhap">Nhập/xuất</param>
        public frmDSPhieuNhapXuat(short loai,bool laNhap, int maKho,int maKy)
        {
            InitializeComponent();
            _hamDC.EventForm(this);
            _hamDC.EventGrid(grdu_DanhSachPhieuNhapXuat);
            LaNhap = laNhap;
            KhoiTao(loai, laNhap);
            this.Text = "Danh Sách Phiếu Nhập Xuất Điều Chỉnh Tồn Kho";
            Loai = loai;
            _maKho = maKho;
            _maKy = maKy;
            Invisible();
            Ky _ky = Ky.GetKy(maKy);
            //BindingSource kyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //kyBindingSource.DataSource = typeof(ERP_Library.Ky);
            //ultradteTuNgay.DataBindings.Add(new System.Windows.Forms.Binding("Value", kyBindingSource, "NgayBatDau", true));
            //ultradteDenNgay.DataBindings.Add(new System.Windows.Forms.Binding("Value", kyBindingSource, "NgayKetThuc", true));
            //kyBindingSource.DataSource = _ky;
            ultradteTuNgay.Value = _ky.NgayBatDau;
            ultradteDenNgay.Value = _ky.NgayKetThuc;
            _PhieuNhapXuatList = PhieuNhapXuatList.GetDSPhieuNhapXuat_DCTK(Loai, LaNhap, _maKho, _maKy);
            PhieuNhapXuat_bindingSource.DataSource = _PhieuNhapXuatList;
        }

        public frmDSPhieuNhapXuat(short loai, bool laNhap,bool lapLenhNhapBPKhac)
        {
            InitializeComponent();
            _hamDC.EventForm(this);
            _hamDC.EventGrid(grdu_DanhSachPhieuNhapXuat);
            LaNhap = laNhap;
            Loai = loai;
            _lapLenhNhapBPKhac = lapLenhNhapBPKhac;
            KhoiTao(loai, laNhap);
            Invisible();
            tlslblLuu.Visible = true;
            toolStripSeparator2.Visible = true;
            if (loai == 1 || loai == 2 || loai == 16 ||loai == 17 || loai == 18)
            {
                grdu_DanhSachPhieuNhapXuat.DoubleClick -= new EventHandler(grdu_DanhSachPhieuNhapXuat_DoubleClick);
                grdu_DanhSachPhieuNhapXuat.CellChange += new CellEventHandler(grdu_DanhSachPhieuNhapXuat_CellChange);
            }
        }

        private void Invisible()
        {
            tlslblXoa.Available = false;
            tlslblUndo.Available = false;
            tlslblLuu.Visible = false;
            toolStripSeparator2.Visible = false;
            //tlslblTroGiup.Available = false;
        }

        private void Invisible1()
        {
            tlslblXoa.Available = false;
            tlslblUndo.Available = false;            
            toolStripSeparator2.Visible = false;
            //tlslblTroGiup.Available = false;
        }

        #endregion 

        #region Khởi Tạo

        private void KhoiTao(short loai, bool laNhap)
        {
            //if (_lapLenhNhapBPKhac)
            //    _PhieuNhapXuatList = PhieuNhapXuatList.GetDSPhieuNhapXuat(Loai, LaNhap, DateTime.Today, DateTime.Today, 0, _tuoiVang, _maKhoNhanCongNau);
            //else
            //    _PhieuNhapXuatList = PhieuNhapXuatList.GetDSPhieuNhapXuat(loai, laNhap, DateTime.Today, DateTime.Today, 0, QuyTrinh);
            //PhieuNhapXuat_bindingSource.DataSource = _PhieuNhapXuatList;
            HamDungChung.EditAllGrid(grdu_DanhSachPhieuNhapXuat);
            if (Loai == 0)
            {
                if (laNhap)
                {
                    HamDungChung.EditNhieuCot(grdu_DanhSachPhieuNhapXuat, 0,
                              new string[5] { "SoPhieu", "TenNhanCong", "NgayNX", "TenDoiTac", "DienGiai" },
                              new string[5] { "Số Phiếu", "Người Nhập", "Ngày Nhập", "Tên Đối Tác", "Ghi Chú" },
                              new int[5] { 150, 250, 80, 250, 250 },
                              new Control[5] { null, null, null, null, null },
                              new KieuDuLieu[5] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Null },
                              new bool[5] { false, false, false, false, false }
                              );
                }
                else
                {
                    HamDungChung.EditNhieuCot(grdu_DanhSachPhieuNhapXuat, 0,
                              new string[5] { "SoPhieu", "TenNhanCong", "NgayNX", "TenDoiTac", "DienGiai" },
                              new string[5] { "Số Phiếu", "Người Xuất", "Ngày Xuất", "Tên Đối Tác", "Ghi Chú" },
                              new int[5] { 150, 250, 80, 250, 250 },
                              new Control[5] { null, null, null, null, null },
                              new KieuDuLieu[5] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Null },
                              new bool[5] { false, false, false, false, false }
                              );
                }
            }
            else
            {
                if (laNhap)
                {
                    HamDungChung.EditNhieuCot(grdu_DanhSachPhieuNhapXuat, 0,
                              new string[5] { "SoPhieu", "TenNhanCong", "NgayNX", "TenKho", "DienGiai" },
                              new string[5] { "Số Phiếu", "Người Nhập", "Ngày Nhập", "Tên Kho", "Ghi Chú" },
                              new int[5] { 150, 250, 80, 250, 250 },
                              new Control[5] { null, null, null, null, null },
                              new KieuDuLieu[5] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Null },
                              new bool[5] { false, false, false, false, false }
                              );
                }
                else
                {
                    //if ((loai == 2 || loai == 17 || loai == 16) && _lapLenhNhapBPKhac || loai==1 ||loai == 18)
                    if ((loai == 1 || loai == 2 || loai == 16 || loai == 17 || loai == 18) && _lapLenhNhapBPKhac)
                        HamDungChung.EditNhieuCot(grdu_DanhSachPhieuNhapXuat, 0,
                              new string[6] { "ThucHien", "SoPhieu", "TenNhanCong", "NgayNX", "TenKho", "DienGiai" },
                              new string[6] { "Lập Lệnh", "Số Phiếu", "Người Xuất", "Ngày Xuất", "Tên Kho", "Ghi Chú" },
                              new int[6] { 90, 150, 250, 80, 250, 250 },
                              new Control[6] { null, null, null, null, null, null },
                              new KieuDuLieu[6] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Null },
                              new bool[6] { true, false, false, false, false, false }
                              );
                    else//if (loai == 1 || loai == 2 || loai == 16 ||loai == 17 || loai == 18) && _lapLenhNhapBPKhac=false
                        HamDungChung.EditNhieuCot(grdu_DanhSachPhieuNhapXuat, 0,
                                  new string[5] { "SoPhieu", "TenNhanCong", "NgayNX", "TenKho", "DienGiai" },
                                  new string[5] { "Số Phiếu", "Người Xuất", "Ngày Xuất", "Tên Kho", "Ghi Chú" },
                                  new int[5] { 150, 250, 80, 250, 250 },
                                  new Control[5] { null, null, null, null, null },
                                  new KieuDuLieu[5] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Null },
                                  new bool[5] { false, false, false, false, false }
                                  );
                }
            }
            foreach (UltraGridColumn col in grdu_DanhSachPhieuNhapXuat.DisplayLayout.Bands[0].Columns)
            {
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
            grdu_DanhSachPhieuNhapXuat.DisplayLayout.Bands[0].Columns["NgayNX"].CellAppearance.TextHAlign = HAlign.Center;
            
        }

        private void grdu_DanhSachDonHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            //Loại: 4: NhapKhoThanhPham; 5:Chuyển Kho (BP khác) ; 6: BP Nấu
            //Loại: 19: Nấu Làm Lại; 17: NhapKhoThanhPham Làm Lại; 18:Chuyển Kho Làm Lại(BP khác)
            if (QuyTrinh != 2)
            {
                try
                {
                    _PhieuNhapXuatList.ApplyEdit();
                    _PhieuNhapXuatList.Save();
                    MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex )
                { 
                    
                }
            }
            else
            {
                //if (_LoaiLenhNhap == 5 || _LoaiLenhNhap == 6 || _LoaiLenhNhap == 17 || _LoaiLenhNhap == 18 || _LoaiLenhNhap == 19)//_LoaiLenhNhap = Loại
                //{
                //    if (_dsPhieuNhapXuat.Count > 0)
                //    {
                //        foreach (PhieuNhapXuat child in _dsPhieuNhapXuat)
                //        {
                //            if (child.ThucHien == true)
                //            {
                //                // Hiện tại 1 phiếu -> 1 lệnh
                //                _PhieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(child.MaPhieuNhapXuat);
                //                phieuNhapXuat = _PhieuNhapXuat;
                //                _lenhNhapXuat = LenhNhapXuat.NewLenhNhapXuat(_LoaiLenhNhap, _PhieuNhapXuat);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show(this, "Bạn chưa chọn phiếu xuất.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
                //this.Close();
            }
           
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            _dsPhieuNhapXuat.Clear();
            if (_lapLenhNhap)
                _PhieuNhapXuatList = PhieuNhapXuatList.GetDSPhieuNhapXuat(Loai, LaNhap, (DateTime)ultradteTuNgay.Value, (DateTime)ultradteDenNgay.Value, 0, _tuoiVang, _maKhoNhanCongNau);
            else
            {               
                _PhieuNhapXuatList = PhieuNhapXuatList.GetDSPhieuNhapXuat(Loai, LaNhap, Convert.ToDateTime(ultradteTuNgay.Value), Convert.ToDateTime(ultradteDenNgay.Value), 0, QuyTrinh, txt_ThongTin.Text, txt_ThongTinHHDV.Text);
            }
            PhieuNhapXuat_bindingSource.DataSource = _PhieuNhapXuatList;
            if (_PhieuNhapXuatList.Count == 0)
            {
                MessageBox.Show("Không có phiếu nào trong khoảng thời gian này !");
            }
        }
        #endregion 

        #region grdu_DanhSachPhieuNhapXuat_DoubleClick
        private void grdu_DanhSachPhieuNhapXuat_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmNhapMuaBan();           
            DoiTuongNhapXuatList dtlist;
            //_lenhNhapXuat = LenhNhapXuat.NewLenhNhapXuat(_LoaiLenhNhap);

            if (_lapLenhNhap == true && QuyTrinh == 2)
            {
                _PhieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat((long)grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["MaPhieuNhapXuat"].Value);
                phieuNhapXuat = _PhieuNhapXuat;
                //if (_LoaiLenhNhap == 5)
                //{
                //    _lenhNhapXuat = LenhNhapXuat.NewLenhNhapXuat(_LoaiLenhNhap, _PhieuNhapXuat);
                //    this.Close();
                //}
                //else
                //{
                //    _lenhNhapXuat = LenhNhapXuat.NewLenhNhapXuat(_LoaiLenhNhap);
                //    if (LenhNhapXuat.KiemTra_MaPhieuXuatNau(phieuNhapXuat.MaPhieuNhapXuat).MaPhieuXuatNau != 0)
                //    {
                //        MessageBox.Show(this, "Đã tồn tại Lệnh Nhập Nấu cho Phiếu này rồi.Vui lòng chọn Phiếu khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //    else
                //    {
                //        dtlist = DoiTuongNhapXuatList.GetDoiTuongNhapXuatList(phieuNhapXuat.MaPhieuNhapXuat);
                //        if (dtlist.Count > 0)
                //            _lenhNhapXuat = LenhNhapXuat.GetLenhNhapXuat(dtlist[0].MaLenhNhapXuat);
                //        //for (int i = 0; i < dtlist.Count; i++)
                //        //{
                //        //    _lenhNhapXuat = LenhNhapXuat.GetLenhNhapXuat(dtlist[i].MaLenhNhapXuat);
                //        //}
                //        this.Close();
                //    }
                //}
            }
            else
            {
                if (grdu_DanhSachPhieuNhapXuat.ActiveRow != null)
                {
                    _PhieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat((long)grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["MaPhieuNhapXuat"].Value);

                    if (QuyTrinh != 2)
                    {
                        if (LaNhap == true)
                        {                            
                                frm = new frmNhapMuaBan(_PhieuNhapXuat);
                        }
                        else
                        {
                            frm = new frmXuatMuaBan(_PhieuNhapXuat);
                        }
                    }
                    // 0: NX mua ban; 6: NX Dieu Chinh Ton Kho ;   7 NX huy động; 8 NX đóng lãi huy động; 9 NX tam XNK; 10: NX XNK; 
                    // 11 : NX Tam Dai Ly; 12: NX NoiBo; 13 NX Le; 14: NX Hang Tra; 15: NX Tạm DL Cty; 

                    // 1 : NX nau;    2: NX SX khac; 5: Nhập Kho Thành Phẩm;
                    // 18 : NX nấu Làm Lại; 16 : NX SX khac Làm Lại;  17: Nhập Kho Thành Phẩm Làm Lại;
                  
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        if (Loai == 22) // Danh sách phiếu nhập xuất điều chỉnh tồn kho
                            _PhieuNhapXuatList = PhieuNhapXuatList.GetDSPhieuNhapXuat_DCTK(Loai, LaNhap, _maKho, _maKy);
                        else
                            _PhieuNhapXuatList = PhieuNhapXuatList.GetDSPhieuNhapXuat(Loai, LaNhap, (DateTime)ultradteTuNgay.Value, (DateTime)ultradteDenNgay.Value, 0, QuyTrinh);
                        PhieuNhapXuat_bindingSource.DataSource = _PhieuNhapXuatList;
                    }
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

        private void grdu_DanhSachPhieuNhapXuat_AfterCellUpdate(object sender, CellEventArgs e)
        {
            //// chỉ lấy 1 thôi, nếu lấy nhiều thì xóa khối này
            //if (grdu_DanhSachPhieuNhapXuat.ActiveCell == grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["ThucHien"])
            //{
            //    foreach (PhieuNhapXuat child in _PhieuNhapXuatList)
            //    {
            //        if (child.MaPhieuNhapXuat == (long)grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["MaPhieuNhapXuat"].Value)
            //        {
            //            if (grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["ThucHien"].Selected == false)
            //            {
            //                grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["ThucHien"].Selected = true;
            //                if (child.ThucHien == true)
            //                {
            //                    if (_dsPhieuNhapXuat.Count == 0)
            //                    {
            //                        _dsPhieuNhapXuat.Add(child);
            //                    }
            //                    else// if (_dsPhieuNhapXuat.Count == 1)
            //                    {
            //                        MessageBox.Show(this, "Vui lòng chỉ chọn 1 lệnh nhập nấu.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                        grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["ThucHien"].Value = false;
            //                        _dsPhieuNhapXuat.Remove(child);
            //                    }
            //                }
            //                else
            //                {
            //                    _dsPhieuNhapXuat.Remove(child);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        #region grdu_DanhSachPhieuNhapXuat_CellChange
        private void grdu_DanhSachPhieuNhapXuat_CellChange(object sender, CellEventArgs e)
        {
            // chỉ lấy 1 thôi, nếu lấy nhiều thì xóa khối này
            if (grdu_DanhSachPhieuNhapXuat.ActiveCell == grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["ThucHien"])
            {
                foreach (PhieuNhapXuat child in _PhieuNhapXuatList)
                {
                    if (child.MaPhieuNhapXuat == (long)grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["MaPhieuNhapXuat"].Value)
                    {
                        if (grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["ThucHien"].Selected == false)
                        {
                            grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["ThucHien"].Selected = true;
                            if (child.ThucHien == true)
                            {
                                if (_dsPhieuNhapXuat.Count == 0)
                                {
                                    _dsPhieuNhapXuat.Add(child);
                                }
                                else
                                {
                                    MessageBox.Show(this, "Vui lòng chỉ chọn 1 Phiếu Xuất.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["ThucHien"].Value = false;
                                    _dsPhieuNhapXuat.Remove(child);
                                }
                            }
                            else
                            {
                                _dsPhieuNhapXuat.Remove(child);
                            }
                        }
                    }
                }
            }
        }
        #endregion 

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (grdu_DanhSachPhieuNhapXuat.ActiveRow != null)
            {
                _PhieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat((long)grdu_DanhSachPhieuNhapXuat.ActiveRow.Cells["MaPhieuNhapXuat"].Value);
                if (QuyTrinh != 2)
                {
                    if (_PhieuNhapXuat.LaNhap == true)
                    {
                        DataSet _ds = new DataSet();

                        ReportDocument Report = new Report.Report_MuaBan.PhieuNhapKho();

                        SqlCommand cm1 = new SqlCommand();
                        cm1.CommandType = CommandType.StoredProcedure;
                        cm1.CommandText = "spd_LayCoTaiKhoan_PhieuNhapXuat";
                        cm1.Parameters.AddWithValue("@MaPhieuNhapXuat", _PhieuNhapXuat.MaPhieuNhapXuat);
                        cm1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                        SqlDataAdapter _adapter = new SqlDataAdapter(cm1);
                        DataTable _table1 = new DataTable();
                        _adapter.Fill(_table1);
                        _table1.TableName = "spd_LayCoTaiKhoan_PhieuNhapXuat;1";

                        SqlCommand cm3 = new SqlCommand();
                        cm3.CommandType = CommandType.StoredProcedure;
                        cm3.CommandText = "spd_LayNoTaiKhoan_PhieuNhapXuat";
                        cm3.Parameters.AddWithValue("@MaPhieuNhapXuat", _PhieuNhapXuat.MaPhieuNhapXuat);
                        cm3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                        _adapter = new SqlDataAdapter(cm3);
                        DataTable _table3 = new DataTable();
                        _adapter.Fill(_table3);
                        _table3.TableName = "spd_LayNoTaiKhoan_PhieuNhapXuat;1";

                        SqlCommand cm2 = new SqlCommand();
                        cm2.CommandType = CommandType.StoredProcedure;
                        cm2.CommandText = "spd_REPORT_PhieuNhapXuatKho";
                        cm2.Parameters.AddWithValue("@MaPhieuNhapXuat", _PhieuNhapXuat.MaPhieuNhapXuat);
                        cm2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                        _adapter = new SqlDataAdapter(cm2);
                        DataTable _table2 = new DataTable();
                        _adapter.Fill(_table2);
                        _table2.TableName = "spd_REPORT_PhieuNhapXuatKho;1";

                        SqlCommand cm4 = new SqlCommand();
                        cm4.CommandType = CommandType.StoredProcedure;
                        cm4.CommandText = "spd_REPORT_ReportHeader";
                        cm4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                        _adapter = new SqlDataAdapter(cm4);
                        DataTable _table4 = new DataTable();
                        _adapter.Fill(_table4);
                        _table4.TableName = "spd_REPORT_ReportHeader;1";

                        _ds.Tables.Add(_table1);
                        _ds.Tables.Add(_table2);
                        _ds.Tables.Add(_table3);
                        _ds.Tables.Add(_table4);

                        Report.SetDataSource(_ds);

                        Report.SetParameterValue("@MaPhieuNhapXuat", _PhieuNhapXuat.MaPhieuNhapXuat);
                        frmHienThiReport frm = new frmHienThiReport();
                        frm.crytalView_HienThiReport.ReportSource = Report;
                        frm.Show();
                    }
                    else
                    {
                        DataSet _ds = new DataSet();

                        ReportDocument Report = new Report.Report_MuaBan.PhieuXuatKho();

                        SqlCommand cm1 = new SqlCommand();
                        cm1.CommandType = CommandType.StoredProcedure;
                        cm1.CommandText = "spd_LayCoTaiKhoan_PhieuNhapXuat";
                        cm1.Parameters.AddWithValue("@MaPhieuNhapXuat", _PhieuNhapXuat.MaPhieuNhapXuat);
                        cm1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                        SqlDataAdapter _adapter = new SqlDataAdapter(cm1);
                        DataTable _table1 = new DataTable();
                        _adapter.Fill(_table1);
                        _table1.TableName = "spd_LayCoTaiKhoan_PhieuNhapXuat;1";

                        SqlCommand cm3 = new SqlCommand();
                        cm3.CommandType = CommandType.StoredProcedure;
                        cm3.CommandText = "spd_LayNoTaiKhoan_PhieuNhapXuat";
                        cm3.Parameters.AddWithValue("@MaPhieuNhapXuat", _PhieuNhapXuat.MaPhieuNhapXuat);
                        cm3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                        _adapter = new SqlDataAdapter(cm3);
                        DataTable _table3 = new DataTable();
                        _adapter.Fill(_table3);
                        _table3.TableName = "spd_LayNoTaiKhoan_PhieuNhapXuat;1";

                        SqlCommand cm2 = new SqlCommand();
                        cm2.CommandType = CommandType.StoredProcedure;
                        cm2.CommandText = "spd_REPORT_PhieuNhapXuatKho";
                        cm2.Parameters.AddWithValue("@MaPhieuNhapXuat", _PhieuNhapXuat.MaPhieuNhapXuat);
                        cm2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                        _adapter = new SqlDataAdapter(cm2);
                        DataTable _table2 = new DataTable();
                        _adapter.Fill(_table2);
                        _table2.TableName = "spd_REPORT_PhieuNhapXuatKho;1";

                        SqlCommand cm4 = new SqlCommand();
                        cm4.CommandType = CommandType.StoredProcedure;
                        cm4.CommandText = "spd_REPORT_ReportHeader";
                        cm4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                        _adapter = new SqlDataAdapter(cm4);
                        DataTable _table4 = new DataTable();
                        _adapter.Fill(_table4);
                        _table4.TableName = "spd_REPORT_ReportHeader;1";

                        _ds.Tables.Add(_table1);
                        _ds.Tables.Add(_table2);
                        _ds.Tables.Add(_table3);
                        _ds.Tables.Add(_table4);

                        Report.SetDataSource(_ds);

                        Report.SetParameterValue("@MaPhieuNhapXuat", _PhieuNhapXuat.MaPhieuNhapXuat);
                        frmHienThiReport frm = new frmHienThiReport();
                        frm.crytalView_HienThiReport.ReportSource = Report;
                        frm.Show();
                    }
                }
            }
        }
        #endregion 

        private void tlslblThem_Click(object sender, EventArgs e)
        {

        }

        private void frmDSPhieuNhapXuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Danh Sach Phieu Xuat Nau", "Help_SanXuat.chm");
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Danh Sach Phieu Xuat Nau", "Help_SanXuat.chm");
        }
    }
}

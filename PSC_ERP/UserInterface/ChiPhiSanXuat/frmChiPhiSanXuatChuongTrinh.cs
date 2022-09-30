using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmChiPhiSanXuatChuongTrinh : Form
    {
        ChuongTrinhList _chuongTrinhList = ChuongTrinhList.NewChuongTrinhList();
        public ChungTu_ChiPhiSanXuatList _ChungTu_ChiPhiSXList;
        public static ChungTu_ChiPhiSanXuatList _chungTu_ChiPhiSanXuatList = null;
        long maChungTu = 0;
        int maButToan = 0;
        string soChungTu = string.Empty;
        public bool IsSave = false;
        decimal soTien = 0;
        long maDoiTuong = 0;
        DateTime ngayLap = DateTime.Today.Date;
        string dienGiai = string.Empty;
        public decimal SoTienDaNhap = 0;
        public ChungTu _chungTu;
        HeThongTaiKhoan1List tklist;
        HeThongTaiKhoan1List tklistAll;
        public static decimal _soTienThuLao = 0;
        public static decimal _soTienChiPhi = 0;
        public static decimal _soTienTong = 0;
        public static ChungTu_ChiPhiSanXuat ct_ChiPhi;
        //public static List<object> chiThuLaoList_Tam = new List<object>();
        public frmChiPhiSanXuatChuongTrinh()
        {
            InitializeComponent();
            bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            bd_ChungTuChiPhiSanXuat.DataSource = typeof(ChungTu_ChiPhiSanXuatList);
        }
        public frmChiPhiSanXuatChuongTrinh(ChungTu ct, ChungTu_ChiPhiSanXuatList list, decimal soTien, long maChungTu, string soChungTu, long maDoiTuong, DateTime ngayLap, string dienGiai, int maButToan)
        {
            InitializeComponent();
            _chungTu = ct;
            _ChungTu_ChiPhiSXList = list;
            this.bd_ChungTuChiPhiSanXuat.DataSource = _ChungTu_ChiPhiSXList;
            this.maChungTu = maChungTu;
            this.soChungTu = soChungTu;
            this.soTien = soTien;
            this.maDoiTuong = maDoiTuong;
            this.ngayLap = ngayLap;
            this.dienGiai = dienGiai;
            this.maButToan = maButToan;

            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;
            if (ERP_Library.Security.CurrentUser.Info.UserID == 39)
            {
                ChungTu_ChiPhiSanXuatList liscp = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatUpdateDataTemp();
                liscp.ApplyEdit();
                liscp.Save();
            }
            _soTienThuLao = 0;
            _soTienChiPhi = 0;
            _soTienTong = 0;
            ct_ChiPhi = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();
            //ct_ChiPhi.SoTien=0;
            //foreach (ChungTu_ChiPhiSanXuat ct_cpsx in _ChungTu_ChiPhiSXList)
            //{

            //    foreach (ChiThuLao ctl in ct_cpsx.ChiThuLaoList)
            //    {
            //        _soTienThuLao += ctl.SoTien;
            //    }
            //    foreach (ChiPhiThucHien cp in ct_cpsx.ChiPhiThucHienList)
            //    {
            //        _soTienChiPhi += cp.SoTien;
            //    }
            //    ct_cpsx.SoTien = _soTienChiPhi + _soTienThuLao;
            // }          
        }
        private void frmChiPhiSanXuatChuongTrinh_Load(object sender, EventArgs e)
        {
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            tklist = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            bindingSource_TaiKhoanlist.DataSource = tklist;

            //tklistAll = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //bindingSource_TaiKhoanAll.DataSource = tklist;

        }

        private void grdu_DSChiThuLao_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            //FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
            foreach (UltraGridBand ban in grdData.DisplayLayout.Bands)
            {
                ban.Hidden = true;
            } this.grdData.DisplayLayout.Bands[0].Hidden = false;
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.Format = "###,###,###,###,###,###";
                }
                col.Hidden = true;
            }

            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].EditorComponent = cmbu_ChuongTrinh;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.Caption = "Chương Trình";
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.VisiblePosition = 0;

            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;


            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].EditorComponent = ultraCombo_TaiKhoan;
            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.Caption = "Kết Chuyển Nguồn";
            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Width = 100;
            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.VisiblePosition = 2;

            grdData.DisplayLayout.Bands[0].Columns["ChiThuLao"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["ChiThuLao"].EditorComponent = tEChiThuLao;
            grdData.DisplayLayout.Bands[0].Columns["ChiThuLao"].Header.Caption = "Chi Thù Lao";
            grdData.DisplayLayout.Bands[0].Columns["ChiThuLao"].Width = 150;
            grdData.DisplayLayout.Bands[0].Columns["ChiThuLao"].Header.VisiblePosition = 3;

            grdData.DisplayLayout.Bands[0].Columns["ChiPhiThucHien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["ChiPhiThucHien"].EditorComponent = tEChiPhi;
            grdData.DisplayLayout.Bands[0].Columns["ChiPhiThucHien"].Header.Caption = "Chi Phí Thực Hiện";
            grdData.DisplayLayout.Bands[0].Columns["ChiPhiThucHien"].Width = 100;
            grdData.DisplayLayout.Bands[0].Columns["ChiPhiThucHien"].Header.VisiblePosition = 4;


        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(grdData, "MaChuongTrinh", "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;

        }



        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            decimal _soTien = 0;
            _soTienThuLao = 0;
            _soTienChiPhi = 0;
            this.bd_ChungTuChiPhiSanXuat.EndEdit();
            grdData.UpdateData();
            _ChungTu_ChiPhiSXList = bd_ChungTuChiPhiSanXuat.DataSource as ChungTu_ChiPhiSanXuatList;
            foreach (ChungTu_ChiPhiSanXuat ct_cpsx in _ChungTu_ChiPhiSXList)
            {
                if (ct_cpsx.MaChuongTrinh == 0)
                {
                    MessageBox.Show("Vui lòng chọn chương trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ct_cpsx.MaChungTu = maChungTu;
                ct_cpsx.MaButToan = maButToan;
                ct_cpsx.SoChungTu = soChungTu;
                _soTien += ct_cpsx.SoTien;
                //foreach (ChiThuLao ctl in ct_cpsx.ChiThuLaoList)
                //{
                //    _soTien += ctl.SoTien;

                //    ctl.MaChuongTrinh = ct_cpsx.MaChuongTrinh;
                //}
                //foreach (ChiPhiThucHien cp in ct_cpsx.ChiPhiThucHienList)
                //{
                //    _soTien += cp.SoTien;

                //    cp.MaChuongTrinh = ct_cpsx.MaChuongTrinh;
                //}
            }
            if (_soTien > this.soTien)
            {
                if (MessageBox.Show("Số tiền đã nhập lớn hơn số tiền Bút Toán. Bạn có muốn tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    IsSave = false;
                    this.Close();
                }
            }
            _ChungTu_ChiPhiSXList.ApplyEdit();
            IsSave = true;
            SoTienDaNhap = _soTien;
            this.Close();

        }

        private void tEChiPhi_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            _soTienChiPhi = 0;
            _soTienThuLao = 0;
            int maChuongTrinh = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChuongTrinh;
            string tenChuongTrinh = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).TenChuongTrinh;
            long maChungTu = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChungTu;
            string soChungTu = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).SoChungTu;

            ct_ChiPhi = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current);
            ct_ChiPhi.ChiPhiThucHienList.BeginEdit();
            frmChiPhiThucHien f = new frmChiPhiThucHien(ct_ChiPhi.ChiPhiThucHienList, maChungTu, soChungTu, maChuongTrinh, tenChuongTrinh, maDoiTuong, soTien, ngayLap, dienGiai);

            if (f.ShowDialog() != DialogResult.OK)
            {
                //lay so tien chi thu lao
                if (ct_ChiPhi.ChiThuLaoList != null)
                {
                    foreach (ChiThuLao _chiThuLao in ct_ChiPhi.ChiThuLaoList)
                    {
                        _soTienThuLao += _chiThuLao.SoTien;
                    }
                }
                //lay so tien chi phi thuc hien
                foreach (ChiPhiThucHien _chiPhiThucHien in ct_ChiPhi.ChiPhiThucHienList)
                {
                    _soTienChiPhi += _chiPhiThucHien.SoTien;
                }

                ct_ChiPhi.SoTien = _soTienChiPhi + _soTienThuLao;

                _soTienChiPhi = 0;
                _soTienThuLao = 0;
            }

        }

        private void tEChiThuLao_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            _soTienThuLao = 0;
            _soTienChiPhi = 0;
            int maChuongTrinh = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChuongTrinh;
            string tenChuongTrinh = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).TenChuongTrinh;
            long maChungTu = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChungTu;
            string soChungTu = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).SoChungTu;

            ct_ChiPhi = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current);
            ct_ChiPhi.ChiThuLaoList.BeginEdit();
            frmChiThuLao f = new frmChiThuLao(_chungTu, ct_ChiPhi.ChiThuLaoList, maChuongTrinh, soTien);
            if (f.ShowDialog() != DialogResult.OK)
            {
                //lay so tien chi thu lao
                foreach (ChiThuLao _chiThuLao in ct_ChiPhi.ChiThuLaoList)
                {
                    _soTienThuLao += _chiThuLao.SoTien;
                }

                //lay so tien chi phi thuc hien
                if (ct_ChiPhi.ChiPhiThucHienList != null)
                {
                    foreach (ChiPhiThucHien _chiPhiThucHien in ct_ChiPhi.ChiPhiThucHienList)
                    {
                        _soTienChiPhi += _chiPhiThucHien.SoTien;
                    }
                }
                ct_ChiPhi.SoTien = _soTienChiPhi + _soTienThuLao;

                _soTienChiPhi = 0;
                _soTienThuLao = 0;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdData_AfterRowInsert(object sender, RowEventArgs e)
        {
            if (ERP_Library.Security.CurrentUser.Info.MaCongTy == 3 && frmTamUng.MaChuongTrinh == 0)
            {
                ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChuongTrinh = 3741;
            }
            else
            {
                ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChuongTrinh = frmTamUng.MaChuongTrinh;
            }
        }

        private void ultraCombo_TaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            FilterCombo f = new FilterCombo(ultraCombo_TaiKhoan, "SoHieuTK");
        }

        private void ultraCombo_TaiKhoanAll_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            FilterCombo f = new FilterCombo(ultraCombo_TaiKhoanAll, "SoHieuTK");
        }

        private void ultraCombo_TaiKhoanAll_ValueChanged(object sender, EventArgs e)
        {
            //if(ultraCombo_TaiKhoanAll.Value!= null)
            //{
            //    foreach (ChungTu_ChiPhiSanXuat ctcp in _ChungTu_ChiPhiSXList)
            //    {
            //        ctcp.MaTaiKhoan = Convert.ToInt32(ultraCombo_TaiKhoanAll.Value);
            //    }   
            //}
        }

        private void tlslblDanhSach_Click(object sender, EventArgs e)
        {
            int _bienTam = 0;
            int bienTam = 0;
            bd_ChungTuChiPhiSanXuat.EndEdit();
            ChungTu_ChiPhiSanXuatList _chungTuChiPhiSanXuatCTList = bd_ChungTuChiPhiSanXuat.DataSource as ChungTu_ChiPhiSanXuatList;
            frmTapHopChiPhiTheoThuLao frm = new frmTapHopChiPhiTheoThuLao(_chungTuChiPhiSanXuatCTList);
            frm.ShowDialog();

            if (_chungTu_ChiPhiSanXuatList != null)
            {
                bd_ChungTuChiPhiSanXuat.EndEdit();
                _chungTuChiPhiSanXuatCTList = bd_ChungTuChiPhiSanXuat.DataSource as ChungTu_ChiPhiSanXuatList;
                int soDong = _chungTuChiPhiSanXuatCTList.Count;

                if (_chungTuChiPhiSanXuatCTList.Count != 0)
                {
                    foreach (ChungTu_ChiPhiSanXuat _itemChungTu in _chungTu_ChiPhiSanXuatList)
                    {
                        for (int i = 0; i < soDong; i++)
                        {
                            if (_chungTuChiPhiSanXuatCTList[i].MaChuongTrinh == _itemChungTu.MaChuongTrinh)
                            {
                                _bienTam = 1;

                                foreach (ChiThuLao item in _itemChungTu.ChiThuLaoList)
                                {   
                                    int _soDong = _chungTuChiPhiSanXuatCTList[i].ChiThuLaoList.Count;

                                    for(int j = 0; j < _soDong ;j++)
                                    {
                                        if (_chungTuChiPhiSanXuatCTList[i].ChiThuLaoList[j].MaBoPhanNhan == item.MaBoPhanNhan)
                                        {
                                            bienTam = 1;
                                        }
                                    }

                                    if (bienTam == 0)
                                    {
                                        _chungTuChiPhiSanXuatCTList[i].ChiThuLaoList.Add(item);
                                    }

                                    bienTam = 0;
                                }

                                _chungTuChiPhiSanXuatCTList[i].SoTien = 0;
                                foreach (ChiThuLao item in _chungTuChiPhiSanXuatCTList[i].ChiThuLaoList)
                                {
                                  
                                    _chungTuChiPhiSanXuatCTList[i].SoTien += item.SoTien;
                                }
                            }
                        }
                        if (_bienTam == 0)
                        {
                            bd_ChungTuChiPhiSanXuat.Add(_itemChungTu);
                        }
                        _bienTam = 0;

                    }
                }
                else
                {
                    bd_ChungTuChiPhiSanXuat.DataSource = _chungTu_ChiPhiSanXuatList;
                }
            }


        }
    }
}

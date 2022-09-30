using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;
using System.Data.OleDb;

namespace PSC_ERP
{
    public partial class FrmHoTroCacChucNangCanThiet : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        ChungTuImportFromExcelList _ChungTuImportFromExcelList = ChungTuImportFromExcelList.NewChungTuImportFromExcelList();
        CTNhapXuatImportFromExcelList _ctNhapXuatImportFromExcelList = CTNhapXuatImportFromExcelList.NewCTNhapXuatImportFromExcelList();
        ChungTuCustomizeList _chungtuCustomizeList = ChungTuCustomizeList.NewChungTuCustomizeList();
        int _MaLoaiCT = 0;
        DateTime _tuNgay;
        DateTime _denNgay;
        string _FileNameImport = "";

        private LoaiChungTuDevList _LoaiChungTuList = LoaiChungTuDevList.NewLoaiChungTuDevList();
        private HeThongTaiKhoan1List _hethongtaikhoanList = HeThongTaiKhoan1List.NewHeThongTaiKhoan1List();
        private DoiTuongAllList _DoiTuongList = DoiTuongAllList.NewDoiTuongAllList();
        ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList _TKNganHangCtyList;

        DataSet _dataSet = new DataSet();
        #endregion Properties

        #region Initialize
        public FrmHoTroCacChucNangCanThiet()
        {
            InitializeComponent();
            KhoiTao();
            DesignGridControls();
            LoadData();
        }
        #endregion Initialize


        #region Function


        private void KhoiTao()
        {
            ChungTuCustomizelistbindingSource.DataSource = typeof(ChungTuCustomizeList);
            ChungTuCustomizelistbindingSource.DataSource = _chungtuCustomizeList;
            gridControl1.DataSource = ChungTuCustomizelistbindingSource;
            //gridControl1.ContextMenuStrip = contextMenuStrip1;
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;

            _LoaiChungTuList = LoaiChungTuDevList.GetLoaiChungTuDevListCustomize();
            LoaiChungTuDev lctEmpt = LoaiChungTuDev.NewLoaiChungTuDev();
            lctEmpt.TenLoaiCT = "<<Tất cả>>";
            _LoaiChungTuList.Insert(0, lctEmpt);
            LoaiChungTuList_bindingSource1.DataSource = _LoaiChungTuList;
            _hethongtaikhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            _DoiTuongList = DoiTuongAllList.GetDoiTuongAllList_Tim("", 0);
            _TKNganHangCtyList = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            LoaiChungTu_gridLookUpEdit.EditValue = 0;
           
        }
        private void LoadData()
        {
            GetInformationSearch();
            _chungtuCustomizeList = ChungTuCustomizeList.GetChungTuCustomizeListForTheoDoi(_MaLoaiCT, _tuNgay, _denNgay);
            BindingData();
        }

        private void BindingData()
        {
            ChungTuCustomizelistbindingSource.DataSource = _chungtuCustomizeList;
        }

        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView1, new string[] { "LoaiChungTu", "SoChungTu", "NgayChungTu", "MaDoiTuongChung", "TenDTChung", "TenDoiTuongNgoai", "TKNo", "TKCo", "SoTienButToan", "TenDTNo", "TenDTCo", "DienGiaiChung", "DienGiaiChiTiet", "SoTaiKhoanDi", "NganHangDi", "SoTaiKhoanDen", "NganHangDen","DonVi","KhoanMuc","SoHopDong" },
                                new string[] { "Loại chứng từ", "Số chứng từ", "Ngày chứng từ", "Mã đối tượng trong", "Đối tượng trong", "Đối tượng ngoài", "TK Nợ ", "TK Có", "Số tiền bút toán", "Đối tượng nợ", "Đối tượng có", " Diễn giải chung", "Diễn giải chi tiết", "Tài khoản Cty", "Ngân hàng Cty", "Tài khoản giao dịch ", "Ngân hàng giao dịch","Đơn vị", "Khoản mục", "Số hợp đồng" },
                                             new int[] { 150, 90, 80, 100, 120, 120, 80, 80, 100, 120, 120, 120, 120, 100, 100, 100, 100, 100, 100, 100 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "LoaiChungTu", "SoChungTu", "NgayChungTu", "MaDoiTuongChung", "TenDTChung", "TenDoiTuongNgoai", "TKNo", "TKCo", "SoTienButToan", "TenDTNo", "TenDTCo", "DienGiaiChung", "DienGiaiChiTiet", "SoTaiKhoanDi", "NganHangDi", "SoTaiKhoanDen", "NganHangDen", "DonVi", "KhoanMuc", "SoHopDong" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTienButToan" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTienButToan" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);


            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
        }

        private void DesignLoaiChungTu_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(LoaiChungTu_gridLookUpEdit, LoaiChungTuList_bindingSource1, "TenLoaiCT", "MaLoaiCT", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(LoaiChungTu_gridLookUpEdit, new string[] { "TenLoaiCT", "TienTo" }, new string[] { "Loại chứng từ", "Tiền tố chứng từ" }, new int[] { 200, 100 }, false);
        }


        private void DesignGridControls()
        {
            DesignLoaiChungTu_gridLookUpEdit1();
            DesignGridView();
        }


        private void GetInformationSearch()
        {
            _MaLoaiCT = 0;
            if (LoaiChungTu_gridLookUpEdit.EditValue != null)
            {
                int maloaictOut = 0;
                if (int.TryParse(LoaiChungTu_gridLookUpEdit.EditValue.ToString(), out maloaictOut))
                {
                    _MaLoaiCT = maloaictOut;
                }
            }
            _tuNgay = Convert.ToDateTime(dtEdit_TuNgay.EditValue);
            _denNgay = Convert.ToDateTime(dtEdit_DenNgay.EditValue);
        }


       

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private bool KiemTraTonTaiLoaiChungTu(string LoaiChungTu)
        {
            foreach (LoaiChungTuDev item in _LoaiChungTuList)
            {
                if (item.TenLoaiCT.ToLower() == LoaiChungTu.ToLower())
                    return true;
            }
            return false;
        }

        private bool KiemTraTonTaiTKNo(string TKno)
        {
            foreach (HeThongTaiKhoan1 item in _hethongtaikhoanList)
            {
                if (item.SoHieuTK == TKno.Replace(" ",""))
                    return true;
            }
            return false;
        }
        private bool KiemTraTonTaiTKCo(string TKco)
        {
            foreach (HeThongTaiKhoan1 item in _hethongtaikhoanList)
            {
                if (item.SoHieuTK == TKco.Replace(" ",""))
                    return true;
            }
            return false;
        }
        private bool KiemTraTonTaiMaDoiTuongNo(string madtNo)
        {
            foreach (DoiTuongAll item in _DoiTuongList)
            {
                if (item.MaQLDoiTuong.ToUpper() == madtNo.ToUpper())
                    return true;
            }
            return false;
        }
        private bool KiemTraTonTaiMaDoiTuongCo(string madtCo)
        {
            foreach (DoiTuongAll item in _DoiTuongList)
            {
                if (item.MaQLDoiTuong.ToUpper() == madtCo.ToUpper())
                    return true;
            }
            return false;
        }

        private bool KiemTraTonTaiTkNganHangCongtyDi(string sotkDi)
        {
            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in _TKNganHangCtyList)
            {
                if (item.SoTaiKhoan.ToUpper() == sotkDi.ToUpper())
                    return true;
            }
            return false;
        }

        private bool KiemTraTonTaiTkNganHangCongtyDen(string sotkDen)
        {
            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in _TKNganHangCtyList)
            {
                if (item.SoTaiKhoan.ToUpper() == sotkDen.ToUpper())
                    return true;
            }
            return false;
        }

        #endregion

        #region Event
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }



        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
            if (_chungtuCustomizeList.Count == 0)
            {
                MessageBox.Show("Danh Sách Tìm Kiếm Rỗng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

        #region eventHandles

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                ChungTuCustomize chungtuCus = gridView1.GetFocusedRow() as ChungTuCustomize;
                if (chungtuCus.MaLoaiChungTuQL == "PT111")//--ThuTienMat
                {
                    FrmChungTuThuTienMat f = new FrmChungTuThuTienMat(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "PC111")//--ChiTienMat
                {
                    FrmChungTuChiTienMat f = new FrmChungTuChiTienMat(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "PT112")//--ThuTienGui
                {
                    FrmChungTuThuTienGui f = new FrmChungTuThuTienGui(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "PC112")//--ChiTienGui
                {
                    FrmChungTuChiTienGui f = new FrmChungTuChiTienGui(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "CTNB")//--ChuyenTienNoiBo
                {
                    FrmChungTuChuyenTienNoiBo f = new FrmChungTuChuyenTienNoiBo(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "GNN")//--GiayNhanNo
                {
                    FrmChungTuGiayNhanNo f = new FrmChungTuGiayNhanNo(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "MuaChuaThanhToan")//--ChungTu Mua Chua Thanh Toan
                {
                    FrmChungTuMuaChuaThanhToan f = new FrmChungTuMuaChuaThanhToan(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "PhiNH")//--Phí ngân hàng
                {
                    FrmChungTuPhiNganHang f = new FrmChungTuPhiNganHang(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "GBNT")//--Giấy bán ngoại tệ
                {
                    FrmChungTuMuaNgoaiTe f = new FrmChungTuMuaNgoaiTe(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "LCTNN")//--Lệnh chuyển tiền ra nước ngoài
                {
                    FrmChungTuLenhChuyenTienNuocNgoai f = new FrmChungTuLenhChuyenTienNuocNgoai(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "GRT")//--Giấy rút tiền
                {
                    FrmChungTuGiayRutTienMat f = new FrmChungTuGiayRutTienMat(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (chungtuCus.MaLoaiChungTuQL == "PKT")//--ChungTu KeToan
                {
                    FrmChungTuKeToanCustomize f = new FrmChungTuKeToanCustomize(chungtuCus);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                
            }
        }
        #endregion eventHandles

        
        
       
    }
}
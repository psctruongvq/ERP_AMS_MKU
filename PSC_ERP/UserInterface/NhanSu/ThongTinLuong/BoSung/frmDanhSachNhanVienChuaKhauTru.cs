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

namespace PSC_ERP
{
    public partial class frmDanhSachNhanVienChuaKhauTru : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();

        //Thong Tin Search
        private int _maKyTinhLuong = 0;
        private int _maKyPC = 0;
        private int _maBoPhan = 0;
        private int _maLoaiPC = 0;
        private int _maLoaiChi = 6;//5: Truy Linh; 6: Truy Thu
        private byte _loai = 1;//@Loai: 1: Truy thu BH; 2: Tru NgayLuong; 3: Truy Linh
        private KyTinhLuong _kyTinhLuong;
        private KyTinhLuong _kyPC;
        //int _maPhuCap = 0;

        #endregion//Properties

        #region Constructors

        public frmDanhSachNhanVienChuaKhauTru(List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> list,int maKyTinhLuong, int maKyPC, int maLoaiPC,int maloaichi,byte loai)
        {
            InitializeComponent();
            InitializeForm();
            _maKyTinhLuong = maKyTinhLuong;
            _maKyPC = maKyPC;
            _kyPC = KyTinhLuong.GetKyTinhLuong(_maKyPC);
            _maLoaiPC = maLoaiPC;
            _maLoaiChi = maloaichi;
            _loai = loai;
            KhoiTao();
            _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = list;
            LoadData();
            SetValueForControl();

        }

        #endregion//Constructors


        #region Function

        private void KhoiTao()
        {

            KyTinhLuongList kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            this.bindingSource_KyTinhLuong.DataSource = kyTinhLuongList;

            KyTinhLuongList kyPhuCapList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource_KyPhuCap.DataSource = kyPhuCapList;

            bindingSource_LoaiPC.DataSource = LoaiPhuCapList.GetLoaiPhuCapListByMaLoaiChi(_maLoaiChi);

            _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;

            gridControl1.DataSource = bindingSource_ThongTinLuongNV;
            DesignGridView();
        }

        private void InitializeForm()
        {
            this.bindingSource_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource_KyPhuCap.DataSource = typeof(KyTinhLuongList);
            this.bindingSource_LoaiPC.DataSource = typeof(LoaiPhuCapList);
            this.bindingSource_ThongTinLuongNV.DataSource = typeof(List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>);
        }

        private void FormatThongTinTimKiem(bool isUnLock)
        {
            groupControl1.Enabled = isUnLock;
        }

        private void GetThongTinSearch()
        {
            

        }

        private bool GetThongTinCapNhat()
        {
            
            return true;
        }

        private void LoadData()
        {
            GetThongTinSearch();
            if (_thongTinLuongNVKhiCapNhatCacKhoanKhauTruList.Count == 0)
            {
                _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.NhanVienChuaTruyThuList(_maKyTinhLuong, _maKyPC, _maLoaiPC, _loai);

            }
            bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;
        }


        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            if (_loai == 1)//Truy Thu
            {
                HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaBoPhanQL", "MaQLNhanVien", "TenNhanVien", "ThuTienBHXHTruyLuongTruocHan", "TruyThuBHXH", "TruyThuBHYT", "TruyThuBHTN" },
                                    new string[] { "Mã bộ phận", "Mã Nhân viên", "Họ và tên", "Phải thu kỳ phụ cấp " + _kyPC.TenKy, "Truy thu BHXH", "Truy thu BHYT", "Truy thu BHTN", },
                                                 new int[] { 70, 80, 100, 150,90,90,90 });
                HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaBoPhanQL", "MaQLNhanVien", "TenNhanVien", "ThuTienBHXHTruyLuongTruocHan", "TruyThuBHXH", "TruyThuBHYT", "TruyThuBHTN" }, DevExpress.Utils.HorzAlignment.Center);
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "ThuTienBHXHTruyLuongTruocHan", "TruyThuBHXH", "TruyThuBHYT", "TruyThuBHTN" }, "#,###");
                HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "ThuTienBHXHTruyLuongTruocHan", "TruyThuBHXH", "TruyThuBHYT", "TruyThuBHTN" }, "{0:#,###}");

                HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "MaBoPhanQL", "MaQLNhanVien", "TenNhanVien", "ThuTienBHXHTruyLuongTruocHan", "TruyThuBHXH", "TruyThuBHYT", "TruyThuBHTN" });
            }
            else if (_loai == 2)//Tru Luong
            {
                HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaBoPhanQL", "MaQLNhanVien", "TenNhanVien", "Tru1NgayLuong" },
                                                   new string[] { "Mã bộ phận", "Mã Nhân viên", "Họ và tên", "Số tiền trừ lương" },
                                                                new int[] { 70, 80, 100, 120 });
                HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaBoPhanQL", "MaQLNhanVien", "TenNhanVien", "Tru1NgayLuong" }, DevExpress.Utils.HorzAlignment.Center);
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "Tru1NgayLuong" }, "#,###");
                HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "Tru1NgayLuong" }, "{0:#,###}");

                HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "MaBoPhanQL", "MaQLNhanVien", "TenNhanVien", "Tru1NgayLuong" });
            }
            else if (_loai == 3)//Truy Linh
            {
                HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaBoPhanQL", "MaQLNhanVien", "TenNhanVien", "TongTienLuongTuNguonPCCaiCachTienLuong" },
                                                   new string[] { "Mã bộ phận", "Mã Nhân viên", "Họ và tên", "Số tiền truy lĩnh kỳ PC "+ _kyPC.TenKy },
                                                                new int[] { 70, 80, 100, 200 });
                HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaBoPhanQL", "MaQLNhanVien", "TenNhanVien", "TongTienLuongTuNguonPCCaiCachTienLuong" }, DevExpress.Utils.HorzAlignment.Center);
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTienLuongTuNguonPCCaiCachTienLuong" }, "#,###");
                HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTienLuongTuNguonPCCaiCachTienLuong" }, "{0:#,###}");

                HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "MaBoPhanQL", "MaQLNhanVien", "TenNhanVien", "TongTienLuongTuNguonPCCaiCachTienLuong" });
            }
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
        }



        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void SetValueForControl()
        {
            grdLU_KyTinhLuong.EditValue = _maKyTinhLuong;
            grdLU_KyPC.EditValue = _maKyPC;
            grdLU_LoaiPC.EditValue = _maLoaiPC;
            if (_loai == 1)
            {
                this.Text = "Danh Sách Nhân Viên Chưa Truy Thu";
            }
            else if (_loai == 2)
            {
                this.Text = "Danh Sách Nhân Viên Chưa Trừ Lương";
            }
            else if (_loai == 3)
            {
                this.Text = "Danh Sách Nhân Viên Chưa Truy Lĩnh";
            }
        }

        #endregion

        #region Event
        private void frmCapNhatCacKhoanTruLuongNhanVien_Load(object sender, EventArgs e)
        {

        }


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


        #endregion

        #region Event Handle
        //private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass currentTtl = (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass)bindingSource_ThongTinLuongNV.Current;
        //    if (gridView1.FocusedColumn.Name == "Tru1NgayLuong")
        //    {
        //        if (_capNhatGridview == false) return;
        //        if (currentTtl.ThucLanhSauThue - currentTtl.Tru1NgayLuong >= 0)
        //        {
        //            currentTtl.SoTienConLai = currentTtl.ThucLanhSauThue - currentTtl.Tru1NgayLuong;

        //        }
        //        else
        //        {
        //            currentTtl.Tru1NgayLuong = 0;
        //            currentTtl.SoTienConLai = currentTtl.ThucLanhSauThue;
        //        }
                
        //    }
        //}
        #endregion Event Handle



    }
}
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
    public partial class frmTruyThuTruyLinhNhanVien : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
        private List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> _TruyThuList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
        private List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> _TruyLinhList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();

        //Thong Tin Search
        private int _maKyTinhLuong = 0;
        private int _maBoPhan = 0;
        private int _maLoaiPC = 0;
        private KyTinhLuong _kyTinhLuong;
        private bool _capNhatGridview = true;

        private int _maLoaiChi = 0;
        private int _maKyPhuCap = 0;
        private string _tieude = string.Empty;
        private List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> _nhanVienChuaTruyThuList=new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
        PhuCapNhanVienList _phuCapNhanVienList;

        private bool _khoaSo = false;
        private bool _tinhTruy = false;
        #endregion//Properties

        #region Constructors


        public frmTruyThuTruyLinhNhanVien()
        {
            InitializeComponent();
            InitializeForm();
            this.lbSoLuong.Text = "";

        }


        public void ShowTruyLinh()
        {
            _maLoaiChi = 5;//Truy Linh
            this.Text = "Tính Truy Lĩnh Nhân Viên";
            _tieude = "Truy lĩnh";
            Show_HideButtonByMaloaiChi();
            KhoiTao();
            this.Show();
        }

        public void ShowTruyThu()
        {
            _maLoaiChi = 6;//Truy Thu
            this.Text = "Tính Truy Thu Nhân Viên";
            _tieude = "Truy thu";
            Show_HideButtonByMaloaiChi();
            KhoiTao();
            this.Show();
        }


        #endregion//Constructors


        #region Function

        private void KhoiTao()
        {
            BoPhanList boPhanList = BoPhanList.GetBoPhanListByAll();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "<<Tất cả>>");
            boPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = boPhanList;

            KyTinhLuongList kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            this.bindingSource_KyTinhLuong.DataSource = kyTinhLuongList;

            KyTinhLuongList kyPhuCapList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource_KyPC.DataSource = kyPhuCapList;

            LoadDataSourceLoaiPC();

            _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;

            _nhanVienChuaTruyThuList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();

            dtmp_Ngay.EditValue = DateTime.Now.Date;
            gridControl1.DataSource = bindingSource_ThongTinLuongNV;
            DesignGridView();
        }

        private void InitializeForm()
        {
            btnTiepTucKT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            this.boPhanListBindingSource.DataSource = typeof(BoPhanList);
            this.bindingSource_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource_KyPC.DataSource = typeof(KyTinhLuongList);
            this.bindingSource_LoaiPC.DataSource = typeof(LoaiPhuCapList);
            this.bindingSource_ThongTinLuongNV.DataSource = typeof(List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>);
        }

        private void Show_HideButtonByMaloaiChi()
        {
            if (_maLoaiChi == 5)
            {
                btnTinhTruyThu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnNVChuaTruyThu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnTinhTruyLinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnNVChuaTruyLinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else if (_maLoaiChi == 6)
            {
                btnTinhTruyThu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnNVChuaTruyThu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnTinhTruyLinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnNVChuaTruyLinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void FormatThongTinTimKiem(bool isUnLock)
        {
            groupControl1.Enabled = isUnLock;
        }

        private void GetThongTinSearch()
        {
            if (grdLU_KyTinhLuong.EditValue != null)
            {
                int makytinhluongOut = 0;
                if (int.TryParse(grdLU_KyTinhLuong.EditValue.ToString(), out makytinhluongOut))
                {
                    _maKyTinhLuong = makytinhluongOut;
                    _kyTinhLuong = KyTinhLuong.GetKyTinhLuong(_maKyTinhLuong);
                }
            }
            else
            {
                _maKyTinhLuong = 0;
            }
            if (grdLU_KyPhuCap.EditValue != null)
            {
                int maKyPhuCapOut = 0;
                if (int.TryParse(grdLU_KyPhuCap.EditValue.ToString(), out maKyPhuCapOut))
                {
                    _maKyPhuCap = maKyPhuCapOut;
                }
            }
            else
            {
                _maKyPhuCap = 0;
            }
            if (grdLU_LoaiPC.EditValue != null)
            {
                int maLoaiPCpOut = 0;
                if (int.TryParse(grdLU_LoaiPC.EditValue.ToString(), out maLoaiPCpOut))
                {
                    _maLoaiPC = maLoaiPCpOut;
                }
            }
            else
            {
                _maLoaiPC = 0;
            }
            if (grdLU_PhongBan.EditValue != null)
            {
                int maBoPhanOut = 0;
                if (int.TryParse(grdLU_PhongBan.EditValue.ToString(), out maBoPhanOut))
                {
                    _maBoPhan = maBoPhanOut;
                }
            }
            else
            {
                _maBoPhan = 0;
            }
        }

        private bool GetThongTinCapNhat()
        {
            if (grdLU_KyTinhLuong.EditValue != null)
            {
                _maKyTinhLuong = (int)grdLU_KyTinhLuong.EditValue;
                _kyTinhLuong = KyTinhLuong.GetKyTinhLuong(_maKyTinhLuong);
                _khoaSo = KyTinhLuong.GetKyTinhLuong(_maKyTinhLuong).KhoaSoKy2;
                if (_khoaSo == true && _tinhTruy)
                {
                    MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin Kỳ tính lương!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _maKyTinhLuong = 0;
                return false;
            }
            if (grdLU_KyPhuCap.EditValue != null)
            {
                _maKyPhuCap = (int)grdLU_KyPhuCap.EditValue;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin Kỳ phụ cấp!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _maKyPhuCap = 0;
                return false;
            }
            if (grdLU_LoaiPC.EditValue != null)
            {
                _maLoaiPC = (int)grdLU_LoaiPC.EditValue;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin Loại phụ cấp!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _maLoaiPC = 0;
                return false;
            }
            if (grdLU_PhongBan.EditValue != null)
            {
                _maBoPhan = Convert.ToInt32(grdLU_PhongBan.EditValue);//(int) lookUpEdit_PhongBan.EditValue;
            }
            else
            {
                _maBoPhan = 0;
            }
            

            return true;
        }

        private void LoadData()
        {
            GetThongTinSearch();
            if (_maKyTinhLuong != 0 && _maKyPhuCap != 0 && _maLoaiPC != 0)
            {
                if (_maLoaiChi == 5)
                    _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.GetTruyLinh(_maKyPhuCap, _maBoPhan, _maKyTinhLuong, _maLoaiPC);
                else if (_maLoaiChi == 6)
                    _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.GetTruyThu(_maKyPhuCap, _maBoPhan, _maKyTinhLuong, _maLoaiPC);
                bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;
                this.lbSoLuong.Text = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList.Count.ToString();
            }
            _nhanVienChuaTruyThuList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
        }

        private void LoadDataSourceLoaiPC()
        {
            LoaiPhuCapList loaiPhuCapList = LoaiPhuCapList.GetLoaiPhuCapListByMaLoaiChi(_maLoaiChi);
            bindingSource_LoaiPC.DataSource = loaiPhuCapList;
        }


        private void DesignGridView()
        {
            if (_maLoaiChi == 5)//Truy Lĩnh
            {
                HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

                HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaQLNhanVien", "TenNhanVien", "LuongCoBanNN", "LuongCoBanMoi", "HeSoLuong", "TongTienLuongTuNguonPCCaiCachTienLuong", "MaBoPhanQL" },
                                    new string[] { "Mã nhân viên", "Họ và tên", "Lương CB trong kỳ", "Lương CB mới", "Hệ số lương", "Số tiền truy lĩnh", "Mã BP" },
                                                 new int[] { 80, 120, 100, 100, 100, 100, 100 });
                HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaQLNhanVien", "TenNhanVien", "LuongCoBanNN", "LuongCoBanMoi", "HeSoLuong", "TongTienLuongTuNguonPCCaiCachTienLuong", "MaBoPhanQL" }, DevExpress.Utils.HorzAlignment.Center);
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "LuongCoBanNN", "LuongCoBanMoi", "TongTienLuongTuNguonPCCaiCachTienLuong" }, "#,###");
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "HeSoLuong"}, "#,##0.#0");
                HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTienLuongTuNguonPCCaiCachTienLuong" }, "{0:#,###}");

                HamDungChung.ReadOnlyColumnGridViewDev(gridView1);
                Utils.GridUtils.SetSTTForGridView(gridView1, 50);
            }
            else if (_maLoaiChi==6)//Truy Thu
            {
                HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

                HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaQLNhanVien", "TenNhanVien", "LuongCoBanNN", "LuongCoBanMoi", "HeSoLuong", "HeSoBaoHiem", "HeSoPhuCap", "HeSoVuotKhungBH", "ThuTienBHXHTruyLuongTruocHan","TruyThuBHXH","TruyThuBHYT","TruyThuBHTN", "MaBoPhanQL" },
                                    new string[] { "Mã nhân viên", "Họ và tên","Lương CB trong kỳ","Lương CB mới", "Hệ số lương", "Hệ số bảo hiểm","Hệ số phụ cấp", "Hệ số vượt khung BH", "Thu tiền Bảo hiểm","Truy thu BHXH","Truy thu BHYT","Truy thu BHTN", "Mã BP" },
                                                 new int[] { 80, 120, 100, 100, 100, 100, 100, 100, 100,90,90,90, 80 });
                HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaQLNhanVien", "TenNhanVien", "LuongCoBanNN", "LuongCoBanMoi", "HeSoLuong", "HeSoBaoHiem", "HeSoPhuCap", "HeSoVuotKhungBH", "ThuTienBHXHTruyLuongTruocHan", "TruyThuBHXH", "TruyThuBHYT", "TruyThuBHTN", "MaBoPhanQL" }, DevExpress.Utils.HorzAlignment.Center);
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "LuongCoBanNN", "LuongCoBanMoi", "ThuTienBHXHTruyLuongTruocHan", "TruyThuBHXH", "TruyThuBHYT", "TruyThuBHTN" }, "#,###");
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "HeSoLuong", "HeSoBaoHiem", "HeSoPhuCap", "HeSoVuotKhungBH" }, "#,##0.#0");
                HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "ThuTienBHXHTruyLuongTruocHan", "TruyThuBHXH", "TruyThuBHYT", "TruyThuBHTN" }, "{0:#,###}");

                HamDungChung.ReadOnlyColumnGridViewDev(gridView1);
                //HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoTT", "MaBoPhanQL", "TenNhanVien", "MaNgachLuong", "HeSoLuong", "HeSoPhuCap", "HeSoVuotKhung", "CongHeSo", "PhanTramNhan", "TienLuong", "ThucLanhSauThue" });
                //this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);

                Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
                //
            }
        }



        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private byte KiemTraPhuCap()//1: Trừ Ngày Lương; 2: Thu tiền BHXH truy lương trước hạn; 3: Tổng tiền lương từ nguồn cải cách tiền lương 
        {
            #region Note
            //if (grdLU_PhuCap.EditValue != null)
            //{
            //    _maPhuCap = (int)grdLU_PhuCap.EditValue;
            //    PhuCapList phucaplist = PhuCapList.GetPhuCapListByMaPhuCap(_maPhuCap);
            //    if (phucaplist[0].MaQLPhuCap == "TruNgayLuong")
            //    {
            //        return 1;
            //    }
            //    else if (phucaplist[0].MaQLPhuCap == "ThuTienBXXH")
            //    {
            //        return 2;
            //    }
            //    else if (phucaplist[0].MaQLPhuCap == "LuongTuNguonCaiCach")
            //    {
            //        return 3;
            //    }
            //}
            #endregion//Note
            #region XuLy
            if (grdLU_LoaiPC.EditValue != null)
            {
                _maLoaiPC = (int)grdLU_LoaiPC.EditValue;
                LoaiPhuCapList loaiphucaplist = LoaiPhuCapList.GetLoaiPhuCapByMaLoai(_maLoaiPC);
                if (loaiphucaplist[0].MaQLLoaiPhuCap == "TruNgayLuong")
                {
                    return 1;
                }
                else if (loaiphucaplist[0].MaQLLoaiPhuCap == "ThuTienBXXH")
                {
                    return 2;
                }
                else if (loaiphucaplist[0].MaQLLoaiPhuCap == "LuongTuNguonCaiCach")
                {
                    return 3;
                }
            }
            #endregion//XuLy

            return 0;
        }


        private void RefetchData()
        {
            

        }

        private void LockAfterUpdate()
        {
            grdLU_KyTinhLuong.Enabled = false;
            grdLU_KyPhuCap.Enabled = false;
            grdLU_PhongBan.Enabled = false;
            grdLU_LoaiPC.Enabled = false;
            btnTiepTucKT.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btnCapNhat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void InitializeUpdate()
        {
            _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;

            grdLU_KyTinhLuong.Enabled = true;
            grdLU_KyTinhLuong.EditValue = null;
            grdLU_KyPhuCap.Enabled = true;
            grdLU_KyPhuCap.EditValue = null;
            grdLU_PhongBan.Enabled = true;
            grdLU_PhongBan.EditValue = null;
            grdLU_LoaiPC.Enabled = true;
            grdLU_LoaiPC.EditValue = null;

            btnTiepTucKT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCapNhat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private bool KiemTraTruocCapNhat()
        {
            
            return true;
        }

        private bool isTruyThuBaoHiem()
        {
            return ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.CheckIsTruyThuDoNangLuongCB(_maLoaiPC);
        }


        private bool isTruyLinhDoNangLuongCB()
        {
            return ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.CheckIsTruyLinhDoNangLuongCB(_maLoaiPC);
        }


        #endregion

        #region Event
        private void frmTruyThuTruyLinhNhanVien_Load(object sender, EventArgs e)
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

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textFocus.Focus();
            if (GetThongTinCapNhat())
            {
                if (KiemTraTruocCapNhat() == false)
                {
                    return;
                }
                if (_phuCapNhanVienList == null || _phuCapNhanVienList.Count == 0) return;

                if (MessageBox.Show(string.Format("Bạn muốn lưu danh sách tính {0}?",_tieude), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    byte loai = KiemTraPhuCap();
                    try
                    {
                        _phuCapNhanVienList.ApplyEdit();
                        bindingSource_ThongTinLuongNV.EndEdit();
                        _phuCapNhanVienList.Save();
                        _nhanVienChuaTruyThuList = new List<ERP_Library.ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
                        MessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LockAfterUpdate();
                    }
                    catch
                    {
                        MessageBox.Show("Cập nhật thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTiepTucKT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitializeUpdate();
        }


        private void btnTinhTruyThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _tinhTruy = true;
            textFocus.Focus();
            GetThongTinCapNhat();
            if (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.KiemTraDaTruyThu_TruyLinh(_maKyPhuCap, _maKyTinhLuong, _maLoaiPC))
            {
                MessageBox.Show("Kỳ phụ cấp này đã truy thu, không thể thực hiện!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (isTruyThuBaoHiem() == false)
            {
                MessageBox.Show("Vui lòng chọn loại phụ cấp Truy thu Bảo hiểm!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (_thongTinLuongNVKhiCapNhatCacKhoanKhauTruList.Count > 0)
            //{
            //    if (MessageBox.Show("Bạn muốn tính lại truy thu?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            //    {
            //        return;
            //    }
            //}
            _phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
            _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            _TruyThuList = ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.TinhTruyThuDaoHiem(_maKyPhuCap, _maBoPhan, _maKyTinhLuong);
            _nhanVienChuaTruyThuList = new List<ERP_Library.ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            #region Update tach rieng cac truy thu
            for (int i = 1; i <= 3; i++)
            {
                foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in _TruyThuList)
                {
                    PhuCapNhanVien phuCapNhanVien = PhuCapNhanVien.NewPhuCapNhanVien();
                    phuCapNhanVien.MaKyTinhLuong = _maKyTinhLuong;
                    //if (cbLoaiPhuCap.ActiveRow != null)
                    phuCapNhanVien.MaLoaiPhuCap = _maLoaiPC;//(int)cbLoaiPhuCap.ActiveRow.Cells["MaLoaiPhuCap"].Value;
                    phuCapNhanVien.TenPhuCap = grdLU_LoaiPC.Text;
                    phuCapNhanVien.DienGiai = grdLU_LoaiPC.Text +(i == 1 ? " - BHXH" : (i == 2 ? " - BHYT" : " - BHTN"));
                    
                    phuCapNhanVien.MaNhanVien = ttl.MaNhanVien;
                    phuCapNhanVien.NgayLap = Convert.ToDateTime(dtmp_Ngay.EditValue);
                    phuCapNhanVien.TinhThueTNCN = true;
                    phuCapNhanVien.TenNhanVien = ttl.TenNhanVien;
                    phuCapNhanVien.MaPhieuChi = "";
                    phuCapNhanVien.ThanhToan = true;
                    phuCapNhanVien.MaBoPhan = ttl.MaBoPhan;
                    phuCapNhanVien.MaKyPhuCap = _maKyPhuCap;
                    phuCapNhanVien.PhuCap = (i == 1 ? ttl.TruyThuBHXH : (i == 2 ? ttl.TruyThuBHYT : ttl.TruyThuBHTN));
                    phuCapNhanVien.PhanLoai = i;
                    if (ttl.ThucLanhSauThue < ttl.ThuTienBHXHTruyLuongTruocHan || ttl.BHXH_Luong != 0 || ttl.TinhTrangNV != 0)
                    {
                        if (_nhanVienChuaTruyThuList.Contains(ttl) == false)
                            _nhanVienChuaTruyThuList.Add(ttl);
                    }
                    else
                    {
                        _phuCapNhanVienList.Add(phuCapNhanVien);
                        if (_thongTinLuongNVKhiCapNhatCacKhoanKhauTruList.Contains(ttl) == false)
                        {
                            _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList.Add(ttl);
                        }
                    }
                }
            }
            #endregion//Update tach rieng cac truy thu
            #region Old
            //foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in _TruyThuList)
            //{
            //    PhuCapNhanVien phuCapNhanVien = PhuCapNhanVien.NewPhuCapNhanVien();
            //    phuCapNhanVien.MaKyTinhLuong = _maKyTinhLuong;
            //    phuCapNhanVien.MaLoaiPhuCap = _maLoaiPC;
            //    phuCapNhanVien.TenPhuCap = grdLU_LoaiPC.Text;
            //    phuCapNhanVien.DienGiai = textEdit_DienGiai.Text;
            //    phuCapNhanVien.MaNhanVien = ttl.MaNhanVien;
            //    phuCapNhanVien.NgayLap = Convert.ToDateTime(dtmp_Ngay.EditValue);
            //    phuCapNhanVien.TinhThueTNCN = true;
            //    phuCapNhanVien.TenNhanVien = ttl.TenNhanVien;
            //    phuCapNhanVien.MaPhieuChi = "";
            //    phuCapNhanVien.ThanhToan = true;
            //    phuCapNhanVien.MaBoPhan = ttl.MaBoPhan;
            //    phuCapNhanVien.MaKyPhuCap = _maKyPhuCap;
            //    phuCapNhanVien.PhuCap = ttl.ThuTienBHXHTruyLuongTruocHan;
            //    if (ttl.ThucLanhSauThue < ttl.ThuTienBHXHTruyLuongTruocHan || ttl.BHXH_Luong != 0)
            //    {
            //        _nhanVienChuaTruyThuList.Add(ttl);
            //    }
            //    else
            //    {
            //        _phuCapNhanVienList.Add(phuCapNhanVien);
            //        _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList.Add(ttl);
            //    }
            //}
            #endregion//Old

            this.bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;
            this.lbSoLuong.Text = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList.Count.ToString();
            LockAfterUpdate();
        }

        private void btnTinhTruyLinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _tinhTruy = true;
            textFocus.Focus();
            GetThongTinCapNhat();
            if (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.KiemTraDaTruyThu_TruyLinh(_maKyPhuCap, _maKyTinhLuong, _maLoaiPC))
            {
                MessageBox.Show("Kỳ phụ cấp này đã truy lĩnh, không thể thực hiện!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (isTruyLinhDoNangLuongCB() == false)
            {
                MessageBox.Show("Vui lòng chọn loại phụ cấp Truy lĩnh do nâng lương cơ bản!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (_thongTinLuongNVKhiCapNhatCacKhoanKhauTruList.Count > 0)
            //{
            //    if (MessageBox.Show("Bạn muốn tính lại truy lĩnh?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            //    {
            //        return;
            //    }
            //}
            _phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
            _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            _TruyLinhList = ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.TinhTruyLinhNangLuongCoBan(_maKyPhuCap, _maBoPhan);
            _nhanVienChuaTruyThuList = new List<ERP_Library.ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in _TruyLinhList)
            {
                PhuCapNhanVien phuCapNhanVien = PhuCapNhanVien.NewPhuCapNhanVien();
                phuCapNhanVien.MaKyTinhLuong = _maKyTinhLuong;
                phuCapNhanVien.MaLoaiPhuCap = _maLoaiPC;
                phuCapNhanVien.TenPhuCap = grdLU_LoaiPC.Text;
                phuCapNhanVien.DienGiai = textEdit_DienGiai.Text;
                phuCapNhanVien.MaNhanVien = ttl.MaNhanVien;
                phuCapNhanVien.NgayLap = Convert.ToDateTime(dtmp_Ngay.EditValue);
                phuCapNhanVien.TinhThueTNCN = true;
                phuCapNhanVien.TenNhanVien = ttl.TenNhanVien;
                phuCapNhanVien.MaPhieuChi = "";
                phuCapNhanVien.ThanhToan = true;
                phuCapNhanVien.MaBoPhan = ttl.MaBoPhan;
                phuCapNhanVien.MaKyPhuCap = _maKyPhuCap;
                phuCapNhanVien.PhuCap = ttl.TongTienLuongTuNguonPCCaiCachTienLuong;
                if (ttl.TinhTrangNV == 0 && ttl.BHXH_Luong == 0)
                {
                    _phuCapNhanVienList.Add(phuCapNhanVien);
                    _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList.Add(ttl);
                }
                else
                {
                    _nhanVienChuaTruyThuList.Add(ttl);
                }
            }

            this.bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;
            this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();
            LockAfterUpdate();
        }

        private void btnNVChuaTruyThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _tinhTruy = false;
            textFocus.Focus();
            GetThongTinCapNhat();
            if (_maLoaiChi == 6)//TruyThu
            {
                if (isTruyThuBaoHiem())
                {
                    frmDanhSachNhanVienChuaKhauTru frm = new frmDanhSachNhanVienChuaKhauTru(_nhanVienChuaTruyThuList, _maKyTinhLuong, _maKyPhuCap, _maLoaiPC, _maLoaiChi, 1);
                    frm.Show();

                }
            }
        }

        private void btnNVChuaTruyLinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _tinhTruy = false;
            textFocus.Focus();
            GetThongTinCapNhat();
            if (_maLoaiChi == 5)//TruyTLinh
            {
                if (isTruyLinhDoNangLuongCB())
                {
                    frmDanhSachNhanVienChuaKhauTru frm = new frmDanhSachNhanVienChuaKhauTru(_nhanVienChuaTruyThuList, _maKyTinhLuong, _maKyPhuCap, _maLoaiPC, _maLoaiChi, 3);
                    frm.Show();

                }
            }
        }

        private void grdLU_KyTinhLuong_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdLU_LoaiPC_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdLU_KyPhuCap_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdLU_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region Event Handle
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass currentTtl = (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass)bindingSource_ThongTinLuongNV.Current;
            if (gridView1.FocusedColumn.Name == "Tru1NgayLuong")
            {
                if (_capNhatGridview == false) return;
                if (currentTtl.ThucLanhSauThue - currentTtl.Tru1NgayLuong >= 0)
                {
                    currentTtl.SoTienConLai = currentTtl.ThucLanhSauThue - currentTtl.Tru1NgayLuong;

                }
                else
                {
                    currentTtl.Tru1NgayLuong = 0;
                    currentTtl.SoTienConLai = currentTtl.ThucLanhSauThue;
                }
                
            }
        }
        #endregion Event Handle




    }
}
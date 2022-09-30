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
    public partial class frmCapNhatCacKhoanTruLuongNhanVien : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();

        //Thong Tin Search
        private int _maKyTinhLuong = 0;
        private int _maBoPhan = 0;
        private int _maNhomPC = 0;
        private int _maLoaiPC = 0;
        private KyTinhLuong _kyTinhLuong;
        private bool _capNhatGridview = true;
        //int _maPhuCap = 0;

        #endregion//Properties

        #region Constructors

        public frmCapNhatCacKhoanTruLuongNhanVien()
        {
            InitializeComponent();
            InitializeForm();
            KhoiTao();

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

            NhomPhuCapList nhomPClist = NhomPhuCapList.GetNhomPhuCapList();
            bindingSource_NhomPC.DataSource = nhomPClist;

            _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;

            dtmp_Ngay.EditValue = DateTime.Now.Date;
            gridControl1.DataSource = bindingSource_ThongTinLuongNV;
            DesignGridView();
            GrdLU_NhomPC.EditValue = NhomPhuCap.GetNhomPhuCapByMaQL("KTL").MaNhom;
            GrdLU_NhomPC.Enabled = false;
            textEdit_SoNgayTruLuong.EditValue = 0;
        }

        private void InitializeForm()
        {
            btnTiepTucKT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            this.boPhanListBindingSource.DataSource = typeof(BoPhanList);
            this.bindingSource_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource_NhomPC.DataSource = typeof(NhomPhuCapList);
            this.bindingSource_LoaiPC.DataSource = typeof(LoaiPhuCapList);
            this.bindingSource_PhuCap.DataSource = typeof(PhuCapList);
            this.bindingSource_ThongTinLuongNV.DataSource = typeof(List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>);
        }

        private void FormatThongTinTimKiem(bool isUnLock)
        {
            groupControl1.Enabled = isUnLock;
        }

        private void GetThongTinSearch()
        {
            if (grdLU_KyTinhLuong.EditValue != null)
            {
                _maKyTinhLuong = (int)grdLU_KyTinhLuong.EditValue;
                _kyTinhLuong = KyTinhLuong.GetKyTinhLuong(_maKyTinhLuong);
            }
            else
            {
                _maKyTinhLuong = 0;
            }
            if (grdLU_PhongBan.EditValue != null)
            {
                _maBoPhan = Convert.ToInt32(grdLU_PhongBan.EditValue);//(int) lookUpEdit_PhongBan.EditValue;
            }
            else
            {
                _maBoPhan = 0;
            }

        }

        private bool GetThongTinCapNhat()
        {
            if (GrdLU_NhomPC.EditValue != null)
            {
                _maNhomPC = (int)GrdLU_NhomPC.EditValue;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin Nhóm phụ cấp!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (grdLU_LoaiPC.EditValue != null)
            {
                _maLoaiPC = Convert.ToInt32(grdLU_LoaiPC.EditValue);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin Loại phụ cấp!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //if (grdLU_PhuCap.EditValue != null)
            //{
            //    _maPhuCap = (int)grdLU_PhuCap.EditValue;
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng nhập thông tin Phụ cấp!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            return true;
        }

        private void LoadData()
        {
            GetThongTinSearch();
            if (_maKyTinhLuong != 0)
            {
                _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.CreatThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass(_maKyTinhLuong, _maBoPhan);
                bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;
            }
        }


        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, true, true);

            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "SoTT", "MaBoPhanQL", "TenNhanVien", "MaNgachLuong", "HeSoLuong", "HeSoPhuCap", "HeSoVuotKhung", "CongHeSo", "PhanTramNhan", "TienLuong", "ThucLanhSauThue", "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong", "SoTienConLai" },
                                new string[] { "STT", "Mã BP", "Họ và tên", "Mã ngạch lương", "Hệ số lương", "Hệ số phụ cấp", "Hệ số vượt khung", "Cộng hệ số", "% nhận", "Tiền lương", "Thực lãnh sau thuế", "Số tiền khấu trừ", "Thu tiền BHXH truy lương trước hạn", "Tổng tiền lương từ nguồn phụ cấp cải cách tiền lương", "Số tiền còn lại" },
                                             new int[] { 50, 60, 120, 80, 80, 80, 80, 80, 70, 100, 100, 100, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoTT", "MaBoPhanQL", "TenNhanVien", "MaNgachLuong", "HeSoLuong", "HeSoPhuCap", "HeSoVuotKhung", "CongHeSo", "PhanTramNhan", "TienLuong", "ThucLanhSauThue", "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong", "SoTienConLai" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "PhanTramNhan", "TienLuong", "ThucLanhSauThue", "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong", "SoTienConLai" }, "#,###");
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "HeSoLuong", "HeSoPhuCap", "HeSoVuotKhung", "CongHeSo" }, "#,##0.#0");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TienLuong", "ThucLanhSauThue", "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong", "SoTienConLai" }, "{0:#,###}");

            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoTT", "MaBoPhanQL", "TenNhanVien", "MaNgachLuong", "HeSoLuong", "HeSoPhuCap", "HeSoVuotKhung", "CongHeSo", "PhanTramNhan", "TienLuong", "ThucLanhSauThue" });
            HamDungChung.HideOrShowColumnofGridViewDev(gridView1, new string[] { "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong" }, new bool[] { false, false, false });
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders=false;
            //Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
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
                NhomPhuCap npc = NhomPhuCap.GetNhomPhuCap(loaiphucaplist[0].MaNhom);
                if (npc.Ma == "KTL")
                {
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
                    else return 4;//Khau tru khac
                }
            }
            #endregion//XuLy

            return 0;
        }

        private decimal TinhNgayLuong(int tongSoNgay, decimal tienluong, int songay)
        {
            return Math.Round((tienluong * (decimal)songay) / (decimal)tongSoNgay, MidpointRounding.AwayFromZero);
        }

        private void CapNhatTruLuongTheoSoNgay(int songay)
        {
            _capNhatGridview = false;
            if (KiemTraPhuCap() == 1)
            {
                decimal sotienTruNgayLuong;
                foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList)
                {
                    sotienTruNgayLuong = 0;
                    //sotienTruNgayLuong = TinhNgayLuong(_kyTinhLuong.SoNgay, (decimal)(ttl.TienLuong), songay);
                    sotienTruNgayLuong = TinhNgayLuong(_kyTinhLuong.SoNgay, (decimal)(ttl.ThucLanhSauThue), songay);
                    if ((ttl.ThucLanhSauThue - sotienTruNgayLuong) >= 0)
                    {
                        ttl.Tru1NgayLuong = sotienTruNgayLuong;
                        ttl.SoTienConLai = ttl.ThucLanhSauThue - ttl.Tru1NgayLuong;
                    }
                    else
                    {
                        ttl.Tru1NgayLuong = 0;
                        ttl.SoTienConLai = ttl.ThucLanhSauThue;

                    }
                }
            }
            bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;
            gridControl1.RefreshDataSource();
            _capNhatGridview = true;
        }

        private void CapNhatSoTienKhauTru(decimal sotienKT)
        {
            _capNhatGridview = false;
            if (KiemTraPhuCap() == 4)
            {
                foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList)
                {
                    if ((ttl.ThucLanhSauThue - sotienKT) >= 0)
                    {
                        ttl.Tru1NgayLuong = sotienKT;
                        ttl.SoTienConLai = ttl.ThucLanhSauThue - ttl.Tru1NgayLuong;
                    }
                    else
                    {
                        ttl.Tru1NgayLuong = 0;
                        ttl.SoTienConLai = ttl.ThucLanhSauThue;

                    }
                }
            }
            bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;
            gridControl1.RefreshDataSource();
            _capNhatGridview = true;
        }

        private void RefetchData()
        {
            foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList)
            {
                ttl.Tru1NgayLuong = 0;
                ttl.ThuTienBHXHTruyLuongTruocHan = 0;
                ttl.TongTienLuongTuNguonPCCaiCachTienLuong = 0;
                ttl.SoTienConLai = ttl.TienLuong;
            }

        }

        private void LockAfterUpdate()
        {
            grdLU_KyTinhLuong.Enabled = false;
            grdLU_PhongBan.Enabled = false;
            //GrdLU_NhomPC.Enabled = false;
            grdLU_LoaiPC.Enabled = false;
            textEdit_SoNgayTruLuong.Enabled = false;
            btnTiepTucKT.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnCapNhat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void InitializeUpdate()
        {
            _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList = new List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            bindingSource_ThongTinLuongNV.DataSource = _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList;

            grdLU_KyTinhLuong.Enabled = true;
            grdLU_KyTinhLuong.EditValue = null;
            grdLU_PhongBan.Enabled = true;
            grdLU_PhongBan.EditValue = null;
            //GrdLU_NhomPC.Enabled = true;
            //GrdLU_NhomPC.EditValue = null;
            grdLU_LoaiPC.Enabled = true;
            grdLU_LoaiPC.EditValue = null;

            btnTiepTucKT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCapNhat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private bool KiemTraTruocCapNhat()
        {
            //byte loai=KiemTraPhuCap();
            //foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList)
            //{
            //    if (loai == 1 && ttl.Tru1NgayLuong<=0)
            //    {
            //        MessageBox.Show(string.Format("Nhân viên {0} số tiền [Trừ Ngày Lương] không hợp lệ!", ttl.TenNhanVien), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //    else if (loai == 2 && ttl.ThuTienBHXHTruyLuongTruocHan <= 0)
            //    {
            //        MessageBox.Show(string.Format("Nhân viên {0} số tiền [Thu tiền BHXH truy lương trước hạn] không hợp lệ!", ttl.TenNhanVien), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //    else if (loai == 3 && ttl.TongTienLuongTuNguonPCCaiCachTienLuong <= 0)
            //    {
            //        MessageBox.Show(string.Format("Nhân viên {0} số tiền [Tổng tiền lương từ nguồn cải cách tiền lương] không hợp lệ!", ttl.TenNhanVien), "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}
            return true;
        }

        private void CapNhatLoaiPCKhauTruLuong()
        {
            if (GetThongTinCapNhat())
            {
                int songayKT = 0;
                decimal sotienKT = 0;
                byte kiemtraphucap = KiemTraPhuCap();
                if (kiemtraphucap == 1)
                {
                    int songayOut;
                    if (int.TryParse(textEdit_SoNgayTruLuong.EditValue.ToString(), out songayOut))
                    {
                        songayKT = songayOut;
                        sotienKT = 0;
                    }
                }
                else if (kiemtraphucap == 4)
                {
                    decimal sotienOut;
                    if (decimal.TryParse(textEdit_SoNgayTruLuong.EditValue.ToString(), out sotienOut))
                    {
                        sotienKT = sotienOut;
                        songayKT = 0;
                    }
                    
                }
                if (songayKT > 0)
                {
                    CapNhatTruLuongTheoSoNgay(songayKT);
                }
                else if (sotienKT > 0)
                {
                    CapNhatSoTienKhauTru(sotienKT);
                }
            }
        }

        #endregion

        #region Event
        private void frmCapNhatCacKhoanTruLuongNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void GrdLU_NhomPC_EditValueChanged(object sender, EventArgs e)
        {
            if (GrdLU_NhomPC.EditValue != null)
            {
                _maNhomPC = (int)GrdLU_NhomPC.EditValue;
                LoaiPhuCapList loaipcList = LoaiPhuCapList.GetLoaiPhuCapByMaNhom(_maNhomPC);
                bindingSource_LoaiPC.DataSource = loaipcList;
                grdLU_LoaiPC.EditValue = loaipcList[0].MaLoaiPhuCap;
            }
        }

        private void grdLU_KyTinhLuong_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdLU_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
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

        private void grdLU_LoaiPC_EditValueChanged(object sender, EventArgs e)
        {
            //if (grdLU_LoaiPC.EditValue != null)
            //{
            //    _maLoaiPC = Convert.ToInt32(grdLU_LoaiPC.EditValue);
            //    bindingSource_PhuCap.DataSource = PhuCapList.GetPhuCapListByLoaiPhuCap(_maLoaiPC);
            //    grdLU_PhuCap.EditValue = null;
            //}
            byte kiemtraphucap = KiemTraPhuCap();
            if (kiemtraphucap == 1 || kiemtraphucap == 4)
            {
                if (kiemtraphucap == 1) lbTruNgayLuong.Text = "Số ngày trừ lương";
                else lbTruNgayLuong.Text = "Số tiền khấu trừ";

                textEdit_SoNgayTruLuong.Enabled = true;
                HamDungChung.HideOrShowColumnofGridViewDev(gridView1, new string[] { "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong" }, new bool[] { true, false, false });
                RefetchData();
            }
            else if (kiemtraphucap == 2)
            {
                textEdit_SoNgayTruLuong.EditValue = 0;
                textEdit_SoNgayTruLuong.Enabled = false;
                HamDungChung.HideOrShowColumnofGridViewDev(gridView1, new string[] { "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong" }, new bool[] { false, true, false });
                RefetchData();
            }
            else if (kiemtraphucap == 3)
            {
                textEdit_SoNgayTruLuong.EditValue = 0;
                textEdit_SoNgayTruLuong.Enabled = false;
                HamDungChung.HideOrShowColumnofGridViewDev(gridView1, new string[] { "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong" }, new bool[] { false, false, true });
                RefetchData();

            }
        }

        private void textEdit_SoNgayTruLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GetThongTinCapNhat())
                {
                    CapNhatLoaiPCKhauTruLuong();
                    //int songay = (int)textEdit_SoNgayTruLuong.EditValue;
                    //if (songay > 0)
                    //{
                    //    CapNhatTruLuongTheoSoNgay(songay);
                    //}
                }
                else
                {
                    textEdit_SoNgayTruLuong.EditValue = textEdit_SoNgayTruLuong.OldEditValue;
                    e.Handled = true;
                }
            }
        }


        private void grdLU_PhuCap_EditValueChanged(object sender, EventArgs e)
        {
            if (KiemTraPhuCap() == 1)
            {
                textEdit_SoNgayTruLuong.Enabled = true;
                HamDungChung.HideOrShowColumnofGridViewDev(gridView1, new string[] { "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong" }, new bool[] { true, false, false });
                RefetchData();
            }
            else if (KiemTraPhuCap() == 2)
            {
                textEdit_SoNgayTruLuong.EditValue = 0;
                textEdit_SoNgayTruLuong.Enabled = false;
                HamDungChung.HideOrShowColumnofGridViewDev(gridView1, new string[] { "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong" }, new bool[] { false, true, false });
                RefetchData();
            }
            else if (KiemTraPhuCap() == 3)
            {
                textEdit_SoNgayTruLuong.EditValue = 0;
                textEdit_SoNgayTruLuong.Enabled = false;
                HamDungChung.HideOrShowColumnofGridViewDev(gridView1, new string[] { "Tru1NgayLuong", "ThuTienBHXHTruyLuongTruocHan", "TongTienLuongTuNguonPCCaiCachTienLuong" }, new bool[] { false, false, true });
                RefetchData();

            }

        }

        private void textEdit_SoNgayTruLuong_Leave(object sender, EventArgs e)
        {
            CapNhatLoaiPCKhauTruLuong();
        }

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textFocus.Focus();
            DateTime ngaylap = Convert.ToDateTime(dtmp_Ngay.EditValue);
            if (GetThongTinCapNhat())
            {
                if (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.KiemTraDaLapDeNghiChuyenKhoanLuongKy1(_maKyTinhLuong, 0, 2))
                {
                    MessageBox.Show("Kỳ tính lương này đã lập đề nghị chuyển khoản, không thể cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int songay = 0; 
                if (KiemTraPhuCap() == 1 && songay <= 0)
                {
                    songay = (int)textEdit_SoNgayTruLuong.EditValue;
                    //MessageBox.Show("Số ngày trừ lương không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                if (KiemTraTruocCapNhat() == false)
                {
                    return;
                }
                if (MessageBox.Show("Bạn muốn cập nhật các khoản trừ lương của nhân viên?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    byte loai = KiemTraPhuCap();
                    try
                    {
                        ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.InsertKTLintoBangLuongPhuCap(_maKyTinhLuong, _thongTinLuongNVKhiCapNhatCacKhoanKhauTruList, _maLoaiPC, loai, ngaylap, songay);
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

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.RowCount > 0)
                {
                    if (gridView1.GetSelectedRows().Length > 0)
                    {
                        if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView1.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            gridView1.DeleteSelectedRows();
                        }
                    }
                }
            }

        }
        #endregion Event Handle



    }
}
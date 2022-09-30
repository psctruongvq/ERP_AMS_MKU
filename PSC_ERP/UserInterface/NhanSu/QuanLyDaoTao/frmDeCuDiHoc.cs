using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP.UserInterface.NhanSu.QuanLyDaoTao.Controllers;
using ERP_Library;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERP.UserInterface.NhanSu.QuanLyDaoTao
{
    public partial class frmDeCuDiHoc : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        private int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        private ThongTinNhanVienTongHopList _ThongTinNhanVienTongHopList;
        private DeCu _deCu;
        private UCLopHoc _control;


        #endregion

        #region Functions

        public void LoadData(DeCu deCu)
        {
            Load();
            KhoiTaoDeCu(deCu);
            _control.Refresh();
        }

        private void KhoiTaoDeCu(DeCu decu)
        {
            if (decu == null)
            {
                _deCu = DeCu.NewDeCu();
                _deCu.MaNguoiLap = _userID;
            }
            else
                _deCu = decu;
            BindingData();
        }

        private bool CoChonNhanVien()
        {
            foreach (ThongTinNhanVienTongHop thongtinnhanvien in _ThongTinNhanVienTongHopList)
            {
                if (thongtinnhanvien.Chon)
                {
                    return true;
                }

            }
            return false;
        }

        private bool KiemTraNhanViendaDeCuvaoLoaiLop(long maNhanVien)
        {
            if (_control.MaLoaiLop != 0)
            {
                if (ChiTietDeCuNhanVien.KiemTraNhanViendaDeCuvaoLoaiLop(_deCu.MaDeCu, maNhanVien, _control.MaLoaiLop))
                {
                    return true;
                }
            }
            return false;
        }

        private bool KiemTraNhanVienTrungThoiGianLopHoc(long maNhanVien)
        {
            if (_control.NgayBatDau != null || _control.NgayKetThuc != null)
            {
                if (ChiTietDeCuNhanVien.KiemTraNhanVienTrungThoiGianLopHoc(_deCu.MaDeCu, maNhanVien, _control.NgayBatDau.Value, _control.NgayKetThuc.Value))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ChoPhepNhanVienTrungLichHoc(long maNhanVien, String tenNhanVien)
        {
            bool choPhep = true;
            foreach (LichHocDaoTao lichhoc in _deCu.LichHocDaoTaoList)
            {
                //thu 2
                if (lichhoc.Thu2.Length != 0)
                {
                    if (ChiTietDeCuNhanVien.KiemTraNhanVienTrungLichHoc(maNhanVien, "Thu2", lichhoc.Thu2, lichhoc.Time2, lichhoc.NgayApDung.Value,lichhoc.NgayKetThuc.Value, _deCu.MaDeCu))
                    {
                        if (MessageBox.Show(string.Format("{0} trùng lịch học thứ 2, bạn có muốn tiếp tục đề cử?", tenNhanVien), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            choPhep = true;
                        }
                        else return false;
                    }
                }
                if (choPhep)
                {
                    if (lichhoc.Thu3.Length != 0)
                    {
                        if (ChiTietDeCuNhanVien.KiemTraNhanVienTrungLichHoc(maNhanVien, "Thu3", lichhoc.Thu3, lichhoc.Time3, lichhoc.NgayApDung.Value,lichhoc.NgayKetThuc.Value, _deCu.MaDeCu))
                        {
                            if (MessageBox.Show(string.Format("{0} trùng lịch học thứ 3, bạn có muốn tiếp tục đề cử?", tenNhanVien), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                choPhep = true;
                            }
                            else return false;
                        }
                    }
                }
                if (choPhep)
                {
                    if (lichhoc.Thu4.Length != 0)
                    {
                        if (ChiTietDeCuNhanVien.KiemTraNhanVienTrungLichHoc(maNhanVien, "Thu4", lichhoc.Thu4, lichhoc.Time4, lichhoc.NgayApDung.Value,lichhoc.NgayKetThuc.Value, _deCu.MaDeCu))
                        {
                            if (MessageBox.Show(string.Format("{0} trùng lịch học thứ 4, bạn có muốn tiếp tục đề cử?", tenNhanVien), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                choPhep = true;
                            }
                            else return false;
                        }
                    }
                }
                if (choPhep)
                {
                    if (lichhoc.Thu5.Length != 0)
                    {
                        if (ChiTietDeCuNhanVien.KiemTraNhanVienTrungLichHoc(maNhanVien, "Thu5", lichhoc.Thu5, lichhoc.Time5, lichhoc.NgayApDung.Value,lichhoc.NgayKetThuc.Value, _deCu.MaDeCu))
                        {
                            if (MessageBox.Show(string.Format("{0} trùng lịch học thứ 5, bạn có muốn tiếp tục đề cử?", tenNhanVien), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                choPhep = true;
                            }
                            else return false;
                        }
                    }
                }
                if (choPhep)
                {
                    if (lichhoc.Thu6.Length != 0)
                    {
                        if (ChiTietDeCuNhanVien.KiemTraNhanVienTrungLichHoc(maNhanVien, "Thu6", lichhoc.Thu6, lichhoc.Time6, lichhoc.NgayApDung.Value, lichhoc.NgayKetThuc.Value, _deCu.MaDeCu))
                        {
                            if (MessageBox.Show(string.Format("{0} trùng lịch học thứ 6, bạn có muốn tiếp tục đề cử?", tenNhanVien), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                choPhep = true;
                            }
                            else return false;
                        }
                    }
                }
                if (choPhep)
                {
                    if (lichhoc.Thu7.Length != 0)
                    {
                        if (ChiTietDeCuNhanVien.KiemTraNhanVienTrungLichHoc(maNhanVien, "Thu7", lichhoc.Thu7, lichhoc.Time7, lichhoc.NgayApDung.Value, lichhoc.NgayKetThuc.Value, _deCu.MaDeCu))
                        {
                            if (MessageBox.Show(string.Format("{0} trùng lịch học thứ 7, bạn có muốn tiếp tục đề cử?", tenNhanVien), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                choPhep = true;
                            }
                            else return false;
                        }
                    }
                }
                if (choPhep)
                {
                    if (lichhoc.ChuNhat.Length != 0)
                    {
                        if (ChiTietDeCuNhanVien.KiemTraNhanVienTrungLichHoc(maNhanVien, "ChuNhat", lichhoc.ChuNhat, lichhoc.TimeCN, lichhoc.NgayApDung.Value, lichhoc.NgayKetThuc.Value, _deCu.MaDeCu))
                        {
                            if (MessageBox.Show(string.Format("{0} trùng lịch học Chủ nhật, bạn có muốn tiếp tục đề cử?", tenNhanVien), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                choPhep = true;
                            }
                            else return false;
                        }
                    }
                }

            }

            return true;
        }

        private void DesignNhanVienGrid()
        {
            NhanVienGridC.DataSource = bsNhanVienList;
            HamDungChung.InitGridViewDev(NhanVienGridV, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(NhanVienGridV, new string[] { "Chon", "MaQLNhanVien", "TenNhanVien", "TenChucVu", "TenBoPhan" },
                                new string[] { "Chọn", "Mã QL", "Tên nhân viên", "Chức vụ", "Bộ phận" },
                                             new int[] { 35, 75, 120, 70, 90 });
            HamDungChung.AlignHeaderColumnGridViewDev(NhanVienGridV, new string[] { "Chon", "MaQLNhanVien", "TenNhanVien", "TenChucVu", "TenBoPhan" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(NhanVienGridV, new string[] { "MaQLNhanVien", "TenNhanVien", "TenChucVu", "TenBoPhan" });

            Utils.GridUtils.SetSTTForGridView(NhanVienGridV, 35);//M

        }

        private void DesignChiTietNhanVienGrid()
        {
            CTDeCuNhanVienGridC.DataSource = bsChiTietDeCuNhanVien;
            HamDungChung.InitGridViewDev(CTDeCuNhanVienGridV, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(CTDeCuNhanVienGridV, new string[] { "MaQLNhanVien", "TenNhanVien", "BoPhanNhanVien", "GhiChu" },
                                new string[] { "Mã QL", "Tên nhân viên", "Bộ phận", "Ghi chú" },
                                             new int[] { 75, 120, 70, 90 });
            HamDungChung.AlignHeaderColumnGridViewDev(CTDeCuNhanVienGridV, new string[] { "MaQLNhanVien", "TenNhanVien", "BoPhanNhanVien", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(CTDeCuNhanVienGridV, new string[] { "MaQLNhanVien", "TenNhanVien", "BoPhanNhanVien" });

            Utils.GridUtils.SetSTTForGridView(CTDeCuNhanVienGridV, 30);//M 
            CTDeCuNhanVienGridV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CTDeCuNhanVienGridVg_KeyDown);
        }

        private void Load()
        {
            bsNhanVienList.DataSource = typeof(ThongTinNhanVienTongHopList);
            bsDeCu.DataSource = typeof(DeCu);
            bsChiTietDeCuNhanVien.DataSource = typeof(ChiTietDeCuNhanVienList);
            bsLichHocDaoTaoList.DataSource = typeof(LichHocDaoTaoList);

            DesignChiTietNhanVienGrid();
            DesignNhanVienGrid();
            //
            _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(0, false);
            bsNhanVienList.DataSource = _ThongTinNhanVienTongHopList;
        }

        private void RefeshNhanDataNhanVienGrid()
        {
            foreach (ThongTinNhanVienTongHop nv in _ThongTinNhanVienTongHopList)
            {
                if (nv.Chon)
                    nv.Chon = false;
            }
            bsNhanVienList.DataSource = _ThongTinNhanVienTongHopList;
            NhanVienGridV.RefreshData();

        }

        private void BindingData()
        {
            bsDeCu.DataSource = _deCu;
            bsChiTietDeCuNhanVien.DataSource = _deCu.chiTietDeCuNhanVienList;
            bsLichHocDaoTaoList.DataSource = _deCu.LichHocDaoTaoList;
            LoadConTrol();
        }

        private void LoadConTrol()
        {
            LopHoc lopHoc;
            if (_deCu.MaHopHoc != 0)
            {
                lopHoc = LopHoc.GetLopHoc(_deCu.MaHopHoc);
            }
            else
            {
                lopHoc = LopHoc.NewLopHoc();
            }
            _control.LoadData(lopHoc, _deCu.MaDeCu);
        }

        private void CreateLayoutItem(UserControl control)
        {
            LayoutControlItem item = new LayoutControlItem();

            ((ISupportInitialize)(item)).BeginInit();
            item.Control = control;
            item.CustomizationFormText = "";
            item.Location = new Point(0, 0);
            item.Name = "item";
            //item.Size = new Size(402, 260);
            item.Text = "";
            item.TextSize = new Size(0, 0);
            item.TextToControlDistance = 0;
            item.TextVisible = false;
            ((ISupportInitialize)(item)).EndInit();
            //int width = GroupLopHoc.Size.Width;
            //int height=_control.Size.Height+35;
            //GroupLopHoc.Size=new Size(width,height);
            GroupLopHoc.Items.AddRange(new BaseLayoutItem[] { item });
        }

        private bool KiemTraNhanVienThoaDieuKienTruocKhiLuu()
        {
            foreach (ChiTietDeCuNhanVien ct in _deCu.chiTietDeCuNhanVienList)
            {
                if (KiemTraNhanViendaDeCuvaoLoaiLop(ct.MaNhanVien))
                {
                    //ThongTinNhanVienTongHop thongtinnhanvien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(ct.MaNhanVien);
                    if (MessageBox.Show(string.Format("{0} đã đề cử học Loại lớp này, bạn có muốn tiếp tục đề cử?", ct.TenNhanVien), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        MessageBox.Show(string.Format("Vui Lòng xóa {0} ra khỏi Danh sách đề cử trước khi lưu! ", ct.TenNhanVien));
                        return false;
                    }
                }
                if (_control.NgayBatDau == null || _control.NgayKetThuc == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và kết thúc lớp chính thức!", "Thông Báo");
                    return false;
                }
                if (_deCu.LichHocDaoTaoList.Count == 0
                    ||
                    (_deCu.LichHocDaoTaoList[0].Thu2.Length==0
                    && _deCu.LichHocDaoTaoList[0].Thu3.Length == 0
                    && _deCu.LichHocDaoTaoList[0].Thu4.Length == 0
                    && _deCu.LichHocDaoTaoList[0].Thu5.Length == 0
                    && _deCu.LichHocDaoTaoList[0].Thu6.Length == 0
                    && _deCu.LichHocDaoTaoList[0].Thu7.Length == 0
                    && _deCu.LichHocDaoTaoList[0].ChuNhat.Length == 0)
                    )
                {
                    if (KiemTraNhanVienTrungThoiGianLopHoc(ct.MaNhanVien))
                    {
                        if (MessageBox.Show(string.Format("{0} trùng thời gian học, bạn có muốn tiếp tục đề cử?", ct.TenNhanVien), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            MessageBox.Show(string.Format("Vui Lòng xóa {0} ra khỏi Danh sách đề cử trước khi lưu! ", ct.TenNhanVien));
                            return false;
                        }
                    }
                }
                else
                {
                    if (!ChoPhepNhanVienTrungLichHoc(ct.MaNhanVien, ct.TenNhanVien))
                    {
                        MessageBox.Show(string.Format("Vui Lòng xóa {0} ra khỏi Danh sách đề cử trước khi lưu! ", ct.TenNhanVien));
                        return false;
                    }
                }
                //if(KiemTraNhanVienTrungThoiGianLopHoc(ct.MaNhanVien))
                //{
                //    if(MessageBox.Show(string.Format("{0} trùng thời gian học, bạn có muốn tiếp tục đề cử?",ct.TenNhanVien),"Hỏi",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
                //    {
                //        MessageBox.Show(string.Format("Vui Lòng xóa {0} ra khỏi Danh sách đề cử trước khi lưu! ", ct.TenNhanVien));
                //        return false;  
                //    }
                //}
                //if (!ChoPhepNhanVienTrungLichHoc(ct.MaNhanVien, ct.TenNhanVien))
                //{
                //    MessageBox.Show(string.Format("Vui Lòng xóa {0} ra khỏi Danh sách đề cử trước khi lưu! ", ct.TenNhanVien));
                //    return false;
                //}
            }
            return true;
        }

        private bool KiemTraTruocKhiLuu()
        {
            if (!_control.LuuLopHocControl())
                return false;
            if (_control.MaLopHoc < 1)
                return false;
            if (!KiemTraHopLeLichHoc())
                return false;
            if (CTDeCuNhanVienGridV.RowCount < 1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên đề cử!");
                return false;
            }
            if (!KiemTraNhanVienThoaDieuKienTruocKhiLuu())
                return false;
            return true;
        }

        private bool ExistsNhanVienInCtDeCuNhanVien(long maNhanVien)
        {
            foreach (ChiTietDeCuNhanVien item in _deCu.chiTietDeCuNhanVienList)
            {
                if (item.MaNhanVien == maNhanVien)
                    return true;
            }
            return false;
        }

        private void ChuyenNhanVienSangDeCu()
        {
            if (_ThongTinNhanVienTongHopList != null)
            {
                bsNhanVienList.EndEdit();
                if (CoChonNhanVien())
                {
                    foreach (ThongTinNhanVienTongHop thongtinnhanvien in _ThongTinNhanVienTongHopList)
                    {
                        if (thongtinnhanvien.Chon)
                        {
                            if (!ExistsNhanVienInCtDeCuNhanVien(thongtinnhanvien.MaNhanVien))
                            {
                                //bool chapNhanThem = true;
                                //if (KiemTraNhanViendaDeCuvaoLop(thongtinnhanvien.MaNhanVien))
                                //{
                                //    if (MessageBox.Show(string.Format("{0} đã đề cử học lớp này, bạn có muốn tiếp tục đề cử?", thongtinnhanvien.TenNhanVien), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                //    {
                                //        chapNhanThem = true;
                                //    }
                                //    else chapNhanThem = false;
                                //}
                                //if (chapNhanThem)
                                //{
                                //    if (_control.NgayBatDau == null || _control.NgayKetThuc == null)
                                //    {
                                //        MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và kết thúc lớp chính thức!", "Thông Báo");
                                //        return;
                                //    }
                                //    if (ChoPhepNhanVienTrungLichHoc(thongtinnhanvien.MaNhanVien, thongtinnhanvien.TenNhanVien))
                                //    {
                                //        chapNhanThem = true;
                                //    }
                                //    else
                                //    {
                                //        chapNhanThem = false;
                                //    }
                                //}
                                //-->
                                //if (chapNhanThem)
                                //{
                                ChiTietDeCuNhanVien ct = ChiTietDeCuNhanVien.NewChiTietDeCuNhanVien(thongtinnhanvien.MaNhanVien);
                                bsChiTietDeCuNhanVien.Add(ct as object);
                                //}

                            }
                        }

                    }
                    RefeshNhanDataNhanVienGrid();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên đề cử", "Yêu Cầu");
                }

            }
        }

        private bool KiemTraCTDeCudaDiHoc(ChiTietDeCuNhanVien ctdc)
        {
            if (ChiTietDeCuNhanVien.KiemTraCTDeCudaDiHoc(ctdc.MaChiTiet))
                return true;
            return false;
        }

        private bool KiemTraXoaCTDeCu()
        {
            int[] deleteRows = CTDeCuNhanVienGridV.GetSelectedRows();
            foreach (int deleteRow in deleteRows)
            {
                ChiTietDeCuNhanVien ct = CTDeCuNhanVienGridV.GetRow(deleteRow) as ChiTietDeCuNhanVien;
                if (KiemTraCTDeCudaDiHoc(ct))
                {
                    MessageBox.Show("Đã có đề cử đi hoc, không thể thực hiên!", "Thông Báo");
                    return false;
                }

            }
            return true;
        }

        private bool KiemTraTruocKhiXoaDeCu()
        {
            if(DeCu.KiemTraDeCuDaCoNguoiDiHoc(_deCu.MaDeCu))
                {
                	 MessageBox.Show("Đề cử đã có người đi học, không thể thực hiện!", "Thông Báo");
                    return false;
                }
            return true;
        }

        private bool KiemTraHopLeLichHoc()
        {
            foreach (LichHocDaoTao lichhoc in _deCu.LichHocDaoTaoList)
            {
                if (lichhoc.NgayApDung < _control.NgayBatDau || lichhoc.NgayApDung > _control.NgayKetThuc)
                {
                    MessageBox.Show("Ngày áp dụng lịch học không được nhỏ hơn Ngày bắt đầu Lớp hay lớn hơn ngày kết thúc Lớp", "Yêu Cầu");
                    return false;
                }
                if (lichhoc.NgayApDung == null)
                {
                    MessageBox.Show("Nhập vào ngày áp dụng cho lịch học", "Yêu Cầu");
                    return false;
                }


            }
            return true;
        }
        #endregion

        #region Event
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraTruocKhiLuu())
            {
                try
                {
                    _deCu.MaHopHoc = _control.MaLopHoc;
                    //dataLayoutControl2.Refresh();
                    _deCu.ApplyEdit();
                    _deCu.Save();

                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnChuyentoDeCu_Click(object sender, EventArgs e)
        {
            ChuyenNhanVienSangDeCu();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoDeCu(null);
        }

        private void frmDeCuDiHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_deCu.IsDirty)
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (kq == DialogResult.Yes)
                {
                    btnLuu.PerformClick();
                }
                else
                    if (kq == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
            }
        }

        private void btnXoaDeCu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraTruocKhiXoaDeCu())
            {
                if (MessageBox.Show("Bạn muốn xóa Danh sách đề cử này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        MessageBox.Show("Xóa Thành công, Chuyển sang Thêm mới!", "Thông Báo");
                        DeCu.DeleteDeCu(_deCu);
                        btnThemMoi.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể Xóa!", "Thông Báo");
                    }
                }
            }
        }

        private void CTDeCuNhanVienGridVg_KeyDown(object sender, KeyEventArgs e)
        {
            if (KiemTraXoaCTDeCu())
                HamDungChung.DeleteSelectedRowsGridViewDev(CTDeCuNhanVienGridV, e);
        }

        private void LichHocDaoTaogridView_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.DeleteSelectedRowsGridViewDev(LichHocDaoTaogridView, e);
        }

        private void LichHocDaoTaogridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            LichHocDaoTao lichhoc = LichHocDaoTaogridView.GetFocusedRow() as LichHocDaoTao;
            if (_deCu.LichHocDaoTaoList.Count > 1)
            {
                int len = _deCu.LichHocDaoTaoList.Count;
                lichhoc.NgayApDung = _deCu.LichHocDaoTaoList[len - 2].NgayKetThuc.Value.AddDays(1);
                lichhoc.NgayKetThuc = _control.NgayKetThuc;
            }
            else
            {
                lichhoc.NgayApDung =_control.NgayBatDau;
                lichhoc.NgayKetThuc = _control.NgayKetThuc;
            }
        }

        #endregion

        public frmDeCuDiHoc()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _control = new UCLopHoc();
            CreateLayoutItem(_control);
        }

       


















    }
}
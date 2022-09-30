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
using DevExpress.XtraEditors.Repository;

namespace PSC_ERP.UserInterface.NhanSu.QuanLyDaoTao
{
    public partial class frmQuyHoach : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        private int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        private ThongTinNhanVienTongHopList _ThongTinNhanVienTongHopList;
        private ChucVuList _chucVuList;
        private QuyHoach _quyHoach;

        #endregion

        #region Functions
        public void LoadData(QuyHoach quyHoach)
        {
            Load();
            KhoiTaoQuyHoach(quyHoach);
        }

        private void KhoiTaoQuyHoach(QuyHoach quyHoach)
        {
            if (quyHoach == null)
            {
                _quyHoach = QuyHoach.NewQuyHoach();
                _quyHoach.MaNguoiLap = _userID;
            }
            else
                _quyHoach = quyHoach;
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


        private void DesignNhanVienGrid()
        {
            NhanVienGridC.DataSource = bsNhanVienList;
            HamDungChung.InitGridViewDev(NhanVienGridV, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            //HamDungChung.ShowFieldGridViewDev(NhanVienGridV, new string[] { "Chon", "MaQLNhanVien", "TenNhanVien", "TenChucVu", "TenBoPhan" },
            //                    new string[] { "Chọn", "Mã QL", "Tên nhân viên", "Chức vụ", "Bộ phận" },
            //                                 new int[] { 35, 90, 120, 70, 90 });
            //HamDungChung.AlignHeaderColumnGridViewDev(NhanVienGridV, new string[] { "Chon", "MaQLNhanVien", "TenNhanVien", "TenChucVu", "TenBoPhan" }, DevExpress.Utils.HorzAlignment.Center);
            //HamDungChung.ReadOnlyColumnChoseGridViewDev(NhanVienGridV, new string[] { "MaQLNhanVien", "TenNhanVien", "TenChucVu", "TenBoPhan" });
            HamDungChung.ShowFieldGridViewDev(NhanVienGridV, new string[] { "Chon", "MaQLNhanVien", "TenNhanVien", "TenBoPhan" },
                                new string[] { "Chọn", "Mã QL", "Tên nhân viên", "Bộ phận" },
                                             new int[] { 35, 90, 120, 90 });
            HamDungChung.AlignHeaderColumnGridViewDev(NhanVienGridV, new string[] { "Chon", "MaQLNhanVien", "TenNhanVien", "TenBoPhan" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(NhanVienGridV, new string[] { "MaQLNhanVien", "TenNhanVien", "TenBoPhan" });

            Utils.GridUtils.SetSTTForGridView(NhanVienGridV, 35);//M

        }

        private void DesignChiTietQuyHoachGrid()
        {
            NhanVienQuyHoachGridC.DataSource = bsCTQuyHoach;
            HamDungChung.InitGridViewDev(NhanVienQuyHoachGridV, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(NhanVienQuyHoachGridV, new string[] { "MaQLNhanVien", "TenNhanVien", "MaChucVuQuyHoach", "GhiChu" },
                                new string[] { "Mã nhân viên", "Tên nhân viên", "Chức vụ quy hoạch", "Ghi chú" },
                                             new int[] { 90, 120, 120, 120 });
            HamDungChung.AlignHeaderColumnGridViewDev(NhanVienQuyHoachGridV, new string[] { "MaQLNhanVien", "TenNhanVien", "MaChucVuQuyHoach", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.ReadOnlyColumnChoseGridViewDev(NhanVienQuyHoachGridV, new string[] { "MaQLNhanVien", "TenNhanVien" });

            RepositoryItemGridLookUpEdit chucVu_GrdLU = new RepositoryItemGridLookUpEdit();
            chucVu_GrdLU.DataSource = bsChucVuList;
            chucVu_GrdLU.DisplayMember = "TenChucVu";
            chucVu_GrdLU.ValueMember = "MaChucVu";
            HamDungChung.InitRepositoryItemGridLookUpDev(chucVu_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(chucVu_GrdLU, new string[] { "MaQLChucVu", "TenChucVu" }, new string[] { "Mã", "Chức vụ" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(chucVu_GrdLU);
            HamDungChung.RegisterControlFieldGridViewDev(NhanVienQuyHoachGridV, "MaChucVuQuyHoach", chucVu_GrdLU);

            Utils.GridUtils.SetSTTForGridView(NhanVienQuyHoachGridV, 30);//M 
            NhanVienQuyHoachGridV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NhanVienQuyHoachGridV_KeyDown);
        }

        private void Load()
        {
            bsNhanVienList.DataSource = typeof(ThongTinNhanVienTongHopList);
            bsQuyHoach.DataSource = typeof(QuyHoach);
            bsCTQuyHoach.DataSource = typeof(ChiTietQuyHoachList);
            bsChucVuList.DataSource = typeof(ChucVuList);

            DesignChiTietQuyHoachGrid();
            DesignNhanVienGrid();
            //
            _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(0, false);
            bsNhanVienList.DataSource = _ThongTinNhanVienTongHopList;

            ChucVu cv = ChucVu.NewChucVu(0, "<Không chọn>");
            _chucVuList = ChucVuList.NewChucVuList();
            _chucVuList = ChucVuList.GetChucVuListForQuyHoach();
            _chucVuList.Insert(0, cv);
            bsChucVuList.DataSource = _chucVuList;
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
            bsQuyHoach.DataSource = _quyHoach;
            bsCTQuyHoach.DataSource = _quyHoach.chitietQuyHoachList;
            bsChucVuList.DataSource = _chucVuList;
        }
        private bool KiemTraNhanVienThoaDieuKienTruocKhiLuu()
        {
            foreach (ChiTietQuyHoach chitietquyhoach in _quyHoach.chitietQuyHoachList)
            {
                int nam;
                if (_quyHoach.NgayQuyHoach == null)
                {
                    nam = DateTime.Today.Year;
                }
                else
                {
                    nam = _quyHoach.NgayQuyHoach.Value.Year;
                }
                if (KiemTraNhanVienTrungQuyHoachTrongNam(chitietquyhoach.MaNhanVien, _quyHoach.MaQuyHoach, nam))
                {
                    if (MessageBox.Show(string.Format("{0} đã được Quy hoạch trong năm {1}, bạn có muốn tiếp tục Quy hoạch?", chitietquyhoach.TenNhanVien, nam), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        MessageBox.Show(string.Format("Vui Lòng xóa {0} ra khỏi Danh sách quy hoạch trước khi lưu! ", chitietquyhoach.TenNhanVien));
                        return false;
                    }
                }
            }
           
            return true;
        }

        private bool KiemTraTruocKhiLuu()
        {
            if (NhanVienQuyHoachGridV.RowCount < 1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên đề cử!");
                return false;
            }
            if (KiemTraNhanVienThoaDieuKienTruocKhiLuu() == false)
                return false;
            return true;
        }

        private void NhanVienQuyHoachGridV_KeyDown(object sender, KeyEventArgs e)
        {
            //if (KiemTraXoaCTQuyHoach())
            HamDungChung.DeleteSelectedRowsGridViewDev(NhanVienQuyHoachGridV, e);
        }

        private bool KiemTraNhanVienTrungQuyHoachTrongNam(long maNhanVien, int maQuyHoach, int nam)
        {
            if (QuyHoach.KiemTraTrungQuyHoachTrongNam(maNhanVien,maQuyHoach,nam))
            {
                return true;
            }
            return false;
        }

        private bool ExistsNhanVienInCtQuyHoachNhanVien(long maNhanVien)
        {
            foreach (ChiTietQuyHoach item in _quyHoach.chitietQuyHoachList)
            {
                if (item.MaNhanVien == maNhanVien)
                    return true;
            }
            return false;
        }

        private void ChuyenNhanVienSangQuyHoach()
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
                            if (!ExistsNhanVienInCtQuyHoachNhanVien(thongtinnhanvien.MaNhanVien))
                            {
                                bool chapNhanThem = true;
                                #region Phan kiem tra Nhan vien thoa dieu kien trươc khi chuyen
                                //int nam;
                                //if(_quyHoach.NgayQuyHoach==null)
                                //    {
                                //        nam=DateTime.Today.Year;
                                //    }
                                //else
                                //    {
                                //        nam=_quyHoach.NgayQuyHoach.Value.Year;
                                //    }
                                //if(KiemTraNhanVienTrungQuyHoachTrongNam(thongtinnhanvien.MaNhanVien,_quyHoach.MaQuyHoach,nam))
                                //{
                                //    if (MessageBox.Show(string.Format("{0} đã được Quy hoạch trong năm {1}, bạn có muốn tiếp tục Quy hoạch?", thongtinnhanvien.TenNhanVien,nam), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                //    {
                                //        chapNhanThem = true;
                                //    }
                                //    else chapNhanThem = false;
                                //}
                                #endregion
                                if(chapNhanThem)
                                {
                                    ChiTietQuyHoach ct = ChiTietQuyHoach.NewChiTietQuyHoach(thongtinnhanvien.MaNhanVien);
                                    ct.GhiChu = _quyHoach.DienGiai;
                                    bsCTQuyHoach.Add(ct as object); 
                                }
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

        private bool KiemTraTruocKhiXoaQuyHoach()
        {
            return true;
        }
        #endregion

        #region Event
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangeFocusTxt.Focus();

            if (KiemTraTruocKhiLuu())
            {
                bsQuyHoach.EndEdit();
                bsCTQuyHoach.EndEdit();
                try
                {
                    _quyHoach.ApplyEdit();
                    _quyHoach.Save();

                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnChuyentoQuyHoach_Click(object sender, EventArgs e)
        {
            ChuyenNhanVienSangQuyHoach();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoQuyHoach(null);
        }

        private void frmQuyHoach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_quyHoach.IsDirty)
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

        private void btnXoaQuyHoach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa Danh sách Quy hoạch này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (KiemTraTruocKhiXoaQuyHoach())
                {
                    try
                    {
                        QuyHoach.DeleteQuyHoach(_quyHoach);
                        MessageBox.Show("Xóa Thành công, Chuyển sang Thêm mới!", "Thông Báo");
                        btnThemMoi.PerformClick(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể Xóa!", "Thông Báo");   
                    }
                }
            }
        }

        private void btnSaoChep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_quyHoach.IsNew)
            {
                frmQuyHoachList frm = new frmQuyHoachList();
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    if (frm.MaQuyHoach != 0)
                    {
                        QuyHoach qhCopy = QuyHoach.GetQuyHoach(frm.MaQuyHoach);
                        if (qhCopy != null)
                        {
                            _quyHoach = QuyHoach.NewQuyHoach(qhCopy);
                            BindingData();
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Quy Hoạch đã lập, không thể copy!", "Thông Báo");
            }

        }
        #endregion

        public frmQuyHoach()
        {
            InitializeComponent();
        }




    }
}
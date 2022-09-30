using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;

namespace PSC_ERP.UserInterface.NhanSu.QuanLyDaoTao
{
    public partial class frmLopHoc : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        LopHoc _lopHoc;
        LopHoc _lopHocOld;
        bool loadfinish = false;
        #endregion

        #region Functions
        private void KhoiTao()
        {
            bsLopHoc.DataSource = typeof(LopHoc);
            bsLoaiLopDaoTaoList.DataSource = typeof(LoaiLopDaoTaoList);
            bsTruongDaoTao.DataSource = typeof(TruongDaoTaoList);
            bsTrinhDoHocVan.DataSource = typeof(TrinhDoHocVanClassList);
            bsQuocGia.DataSource = typeof(QuocGiaList);
            bsChuyenNganhDaoTao.DataSource = typeof(ChuyenNganhDaoTaoClassList);
            bsDonViDaoTaoList.DataSource = typeof(DonViDaoTaoList);
        }


        private void LoadDataBindingLoaiLopDaoTao()
        {
            bsLoaiLopDaoTaoList.DataSource = LoaiLopDaoTaoList.GetLoaiLopDaoTaoList(0, 0, 0, 0);
        }

        private void LoadDataBindingSource()
        {
            LoadDataBindingLoaiLopDaoTao();

            TruongDaoTao truongdaotao = TruongDaoTao.NewTruongDaoTao("<Không chọn>");
            TruongDaoTaoList truongdaotaolist;
            truongdaotaolist = TruongDaoTaoList.GetTruongDaoTaoList();
            truongdaotaolist.Insert(0, truongdaotao);
            bsTruongDaoTao.DataSource = truongdaotaolist;

            TrinhDoHocVanClass trinhdo = TrinhDoHocVanClass.NewTrinhDoHocVanClass(0, "<Không chọn>");
            TrinhDoHocVanClassList trinhdoList = TrinhDoHocVanClassList.GetTrinhDoHocVanClassList();
            trinhdoList.Insert(0, trinhdo);
            bsTrinhDoHocVan.DataSource = trinhdoList;

            QuocGia qg = QuocGia.NewQuocGia(0, "<Không chọn>");
            QuocGiaList quocgiaList = QuocGiaList.GetQuocGiaList();
            quocgiaList.Insert(0, qg);
            bsQuocGia.DataSource = quocgiaList;

            ChuyenNganhDaoTaoClass chuyennganh = ChuyenNganhDaoTaoClass.NewChuyenNganhDaoTaoClass(0, "<Không chọn>");
            ChuyenNganhDaoTaoClassList chuyennganhList = ChuyenNganhDaoTaoClassList.GetChuyenNganhDaoTaoClassList();
            chuyennganhList.Insert(0, chuyennganh);
            bsChuyenNganhDaoTao.DataSource = chuyennganhList;

            LoadDataBindingDonViDaoTao();
        }


        private void KhoiTaoLopHoc(LopHoc lophoc)
        {
            if (lophoc == null)
            {
                _lopHoc = LopHoc.NewLopHoc();
                _lopHoc.VanbangChungChi = 1;
                _lopHoc.TrongnuocNgoainuoc = 1;
                TenvanbangChungchiTextEdit.Focus();
            }
            else
            {
                _lopHoc = lophoc;
                _lopHocOld = LopHoc.GetLopHoc(_lopHoc.MaLopHoc);
                #region BS
                if (_lopHoc.SoNguoiHoc != LopHoc.GetSoNguoiDiHocOfLopHoc(_lopHoc.MaLopHoc))
                {
                    _lopHoc.SoNguoiHoc = LopHoc.GetSoNguoiDiHocOfLopHoc(_lopHoc.MaLopHoc);
                }
                #endregion//BS
            }

            BingdingData();
        }

        private void BingdingData()
        {
            bsLopHoc.DataSource = _lopHoc;
            //bsKhoaBieuHoc.DataSource = _lopHoc.KhoaBieuHoc;
        }

        private void ResetLopHoc()
        {
            _lopHoc.MaLoaiLop = _lopHocOld.MaLoaiLop;
            _lopHoc.TenvanbangChungchi = _lopHocOld.TenvanbangChungchi;
            _lopHoc.VanbangChungChi = _lopHocOld.VanbangChungChi;
            _lopHoc.MaQuocGiaCap = _lopHocOld.MaQuocGiaCap;
            _lopHoc.MaTruongDaoTao = _lopHocOld.MaTruongDaoTao;
            _lopHoc.MaChuyenNganhDaoTao = _lopHocOld.MaChuyenNganhDaoTao;
            _lopHoc.TrongnuocNgoainuoc = _lopHocOld.TrongnuocNgoainuoc;
            _lopHoc.MaDonViDaoTao = _lopHocOld.MaDonViDaoTao;
        }

        private bool ChoPhepCapNhatLopHocDaCoNguoiDiHoc()
        {
            bool chophep = true;
            if (_lopHoc.IsNew == false)
            {
                if (LopHoc.KiemTraLopHocDaCoNguoiDiHocKhongChoCapNhat(_lopHoc.MaLopHoc))
                {
                    if (_lopHoc.MaLoaiLop != _lopHocOld.MaLoaiLop
                    || _lopHoc.TenvanbangChungchi != _lopHocOld.TenvanbangChungchi
                    || _lopHoc.VanbangChungChi != _lopHocOld.VanbangChungChi
                    || _lopHoc.MaQuocGiaCap != _lopHocOld.MaQuocGiaCap
                    || _lopHoc.MaTruongDaoTao != _lopHocOld.MaTruongDaoTao
                    || _lopHoc.MaChuyenNganhDaoTao != _lopHocOld.MaChuyenNganhDaoTao
                    || _lopHoc.TrongnuocNgoainuoc != _lopHocOld.TrongnuocNgoainuoc
                    || _lopHoc.MaDonViDaoTao != _lopHocOld.MaDonViDaoTao
                    )
                    {
                        if (MessageBox.Show("Lớp học đang có người học, sự thay đổi của bạn là không hợp lý. \n Bạn có muốn tiếp tục thay đổi?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            ResetLopHoc();
                            chophep = false;
                        }
                        else
                        {
                            chophep = true;
                        }
                    }
                }
            }
            return chophep;
        }

        private bool KiemTraTruocKhiXoa()
        {
            if (LopHoc.KiemTraLopHocdaDeCu(_lopHoc.MaLopHoc))
                return false;
            return true;
        }

        private bool KiemTraTruocKhiLuu()
        {
            if (LopHoc.KiemTraLopHocDaNopBangKhongChoCapNhat(_lopHoc.MaLopHoc))
            {
                MessageBox.Show("Lớp học này đã có người nộp bằng, Không thể cập nhật", "Thông Báo");
                return false;
            }

            if (ChoPhepCapNhatLopHocDaCoNguoiDiHoc() == false)
            {
                return false;
            }

            if (_lopHoc.MaLoaiLop == 0)
            {
                MessageBox.Show("Vui lòng chọn Loại Lớp thuộc vào!", "Thông Báo");
                LoaiLopHocGLU.Focus();
                return false;
            }
            if (_lopHoc.NgayBatDau == null || _lopHoc.NgayKetThuc == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và kết thúc dự kiến lớp học!", "Thông Báo");
                NgayBatDauDateEdit.Focus();
                return false;
            }
            //if (LopHoc.KiemTraLopHocMoTrungThoiGian_MaLoaiLop(_lopHoc.MaLoaiLop, _lopHoc.MaLopHoc, _lopHoc.NgayBatDau.Value, _lopHoc.NgayKetThuc.Value))
            //{
            //    MessageBox.Show("Lớp học chính thức mở trùng ngày với lớp học chính thức trước, trong khi cùng 1 lớp học!\n Không thể thực hiện", "Thông Báo");
            //    return false;
            //}
            return true;
        }

        private bool LuuDuLieu()
        {
            if (KiemTraTruocKhiLuu())
            {
                try
                {

                    if (_lopHoc.NgayBatDauChinhThuc == null)
                        _lopHoc.NgayBatDauChinhThuc = _lopHoc.NgayBatDau;
                    if (_lopHoc.NgayKetThucChinhThuc == null)
                        _lopHoc.NgayKetThucChinhThuc = _lopHoc.NgayKetThuc;

                    _lopHoc.ApplyEdit();
                    bsLopHoc.EndEdit();
                    _lopHoc.Save();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else return false;
            return true;
        }

        public void BingdingDataformLoaiLopDaoTaotoLopHoc(LoaiLopDaoTao loaiLopdaotao)
        {
            _lopHoc.MaLoaiLop = loaiLopdaotao.MaLoaiLop;
            _lopHoc.TenvanbangChungchi = loaiLopdaotao.TenLoaiLop;
            _lopHoc.LoaiVanBang = loaiLopdaotao.LoaiVanBang;
            _lopHoc.MaChuyenNganhDaoTao = loaiLopdaotao.MaChuyenNganhDaoTao;
            _lopHoc.MaQuocGiaCap = loaiLopdaotao.MaQuocGiaCap;
            _lopHoc.MaTruongDaoTao = loaiLopdaotao.MaTruongDaoTao;
            _lopHoc.VanbangChungChi = loaiLopdaotao.VanbangChungChi;
            _lopHoc.TrongnuocNgoainuoc = loaiLopdaotao.TrongnuocNgoainuoc;
            _lopHoc.MaDonViDaoTao = loaiLopdaotao.MaDonViDaoTao;
        }

        private void LoadDataBindingDonViDaoTao()
        {
            DonViDaoTao dvdt = DonViDaoTao.NewDonViDaoTao("<Không chọn>");
            DonViDaoTaoList donvidaotaoList = DonViDaoTaoList.GetDonViDaoTaoList();
            donvidaotaoList.Insert(0, dvdt);
            bsDonViDaoTaoList.DataSource = donvidaotaoList;
        }

        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoLopHoc(null);
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LuuDuLieu())
            {
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraTruocKhiXoa())
            {
                if (MessageBox.Show("Bạn muốn xóa Lớp học này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        LopHoc.DeleteLopHoc(_lopHoc);
                        MessageBox.Show("Xóa thành công! Chuyển sang Thêm mới");
                        btnThemMoi.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
            else
                MessageBox.Show("Lớp học đã được đề cử, Không thể xóa");
        }

        private void frmLopHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_lopHoc.IsDirty)
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

        private void LoaiLopHocGLU_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frmLoaiLopHocDaoTaoList frm = new frmLoaiLopHocDaoTaoList(true);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    if (frm.MaLoaiLopDaoTao != 0)
                    {
                        LoaiLopDaoTao loaiLopdaotao = LoaiLopDaoTao.GetLoaiLopDaoTao(frm.MaLoaiLopDaoTao);
                        if (loaiLopdaotao != null)
                        {
                            BingdingDataformLoaiLopDaoTaotoLopHoc(loaiLopdaotao);
                            BingdingData();
                        }
                    }
                    LoadDataBindingLoaiLopDaoTao();
                }
            }
        }

        private void DonViDaoTaoGrLU_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frmDonViDaoTaoList frm = new frmDonViDaoTaoList(true);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    LoadDataBindingDonViDaoTao();
                    if (frm.MaDonViDaoTao != 0)
                    {
                        DonViDaoTaoGrLU.EditValue = frm.MaDonViDaoTao as object;
                    }
                }
            }
        }
        #endregion


        public frmLopHoc()
        {
            InitializeComponent();

        }

        public void LoadData(LopHoc lopHoc)
        {
            KhoiTao();
            LoadDataBindingSource();
            KhoiTaoLopHoc(lopHoc);
        }

        private void LoaiLopHocGLU_EditValueChanged(object sender, EventArgs e)
        {
            if (LoaiLopHocGLU.EditValue != null &&
                loadfinish)
            {
                int maLoaiLop;
                if (int.TryParse(LoaiLopHocGLU.EditValue.ToString(), out maLoaiLop))
                {
                    LoaiLopDaoTao loaiLopdaotao = LoaiLopDaoTao.GetLoaiLopDaoTao(maLoaiLop);
                    if (loaiLopdaotao != null)
                    {
                        BingdingDataformLoaiLopDaoTaotoLopHoc(loaiLopdaotao);
                        BingdingData();

                    }
                }

            }
        }

        private void NgayBatDauDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (NgayBatDauChinhThucdateEdit.EditValue == null && loadfinish)
            {
                NgayBatDauChinhThucdateEdit.EditValue = NgayBatDauDateEdit.EditValue;
            }
        }

        private void NgayKetThucDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (NgayKetThucChinhThucdateEdit.EditValue == null && loadfinish)
            {
                NgayKetThucChinhThucdateEdit.EditValue = NgayKetThucDateEdit.EditValue;
            }
        }

        private void frmLopHoc_Load(object sender, EventArgs e)
        {
            loadfinish = true;

        }

        






    }
}
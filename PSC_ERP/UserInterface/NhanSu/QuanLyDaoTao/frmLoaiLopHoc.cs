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
    public partial class frmLoaiLopHoc : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        LoaiLopDaoTao _loaiLopHoc;

        public bool TuLopHoc;
        #endregion

        #region Functions
        private void KhoiTao()
        {
            bsLoaiLopHoc.DataSource = typeof(LoaiLopDaoTao);

            bsTruongDaoTao.DataSource = typeof(TruongDaoTaoList);
            bsTrinhDoHocVan.DataSource = typeof(TrinhDoHocVanClassList);
            bsQuocGia.DataSource = typeof(QuocGiaList);
            bsChuyenNganhDaoTao.DataSource = typeof(ChuyenNganhDaoTaoClassList);
            bsDonViDaoTaoList.DataSource = typeof(DonViDaoTaoList);
        }

        private void LoadDataBindingSource()
        {
            this.Text = "Loại Lớp Học";
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


        private void KhoiTaoLoaiLopHoc(LoaiLopDaoTao loaiLophoc)
        {
            if (loaiLophoc == null)
            {
                _loaiLopHoc = LoaiLopDaoTao.NewLoaiLopDaoTao();
                _loaiLopHoc.VanbangChungChi = 1;
                _loaiLopHoc.TrongnuocNgoainuoc = 1;
                txt_MaQL.Focus();
            }
            else
                _loaiLopHoc = loaiLophoc;
            BingdingData();
        }

        private void BingdingData()
        {
            bsLoaiLopHoc.DataSource = _loaiLopHoc;
        }

        private bool KiemTraTruocKhiXoa()
        {
            if (LoaiLopDaoTao.KiemTraLoaiLopHocdaDung(_loaiLopHoc.MaLoaiLop))
            {
                MessageBox.Show("Loại Lớp này đã được sử dùng, không thể xóa!");
                return false;
            }
            
            return true;
        }

        private bool KiemTraTruocKhiLuu()
        {
            if (_loaiLopHoc.MaQL.Trim().Length < 1)
            {
                MessageBox.Show("Vui lòng nhập vào Mã quản lý của Loại Lớp học!");
                txt_MaQL.Focus();
                return false;
            }
            if (LoaiLopDaoTao.KiemTraTrungMaQlLoaiLopDaoTao(_loaiLopHoc.MaLoaiLop, _loaiLopHoc.MaQL))
            {
                MessageBox.Show("Trùng Mã Quản lý, vui lòng chỉnh lại!");
                txt_MaQL.SelectAll();
                return false;
            }
            return true;
        }

        private bool LuuDuLieu()
        {
            if (KiemTraTruocKhiLuu())
            {
                try
                {
                    _loaiLopHoc.ApplyEdit();
                    bsLoaiLopHoc.EndEdit();
                    _loaiLopHoc.Save();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else return false;
            return true;
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
            KhoiTaoLoaiLopHoc(null);
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LuuDuLieu())
            {
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (TuLopHoc)
                    this.Close();
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
                if (MessageBox.Show("Bạn muốn xóa Loại Lớp học này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        LoaiLopDaoTao.DeleteLoaiLopDaoTao(_loaiLopHoc);
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
                MessageBox.Show("Loại Lớp học đã được đề cử, Không thể xóa");
        }

        private void frmLoaiLopHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_loaiLopHoc.IsDirty)
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


        public frmLoaiLopHoc()
        {
            InitializeComponent();

        }

        public void LoadData(LoaiLopDaoTao loaiLopHoc)
        {
            KhoiTao();
            LoadDataBindingSource();
            KhoiTaoLoaiLopHoc(loaiLopHoc);
        }






    }
}
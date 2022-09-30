using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.IO;
//using Demo.Report.Parameters;
using System.Reflection;
using System.Data.OleDb;
using DevExpress.Xpo;

using System.Data.SqlClient;
using ERP_Library;
using DevExpress;
using DevExpress.XtraLayout;
//11/04/2014////
namespace PSC_ERP.UserInterface.NhanSu.QuanLyDaoTao
{
    public partial class frmLoaiLopHoc2 : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        LoaiLopDaoTao _loaiLopHoc;

        public bool TuLopHoc;

        private int _loai = 0;//3: Tin học | 4: Ngoại ngữ
        private bool _loadformFinish = false;
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

            NgoaiNgu_BindingSource.DataSource = typeof(NgoaiNguList);
            TrinhDoNgoaiNgu_BindingSource.DataSource = typeof(TrinhDoNgoaiNguClassList);
            trinhDoTinHocClassListBindingSource.DataSource = typeof(TrinhDoTinHocClassList);
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
            //
            NgoaiNguList ngoaiNguList = NgoaiNguList.GetNgoaiNguList();
            this.NgoaiNgu_BindingSource.DataSource = ngoaiNguList;
            TrinhDoNgoaiNguClassList _trinhDoList = TrinhDoNgoaiNguClassList.GetTrinhDoNgoaiNguClassList();
            this.TrinhDoNgoaiNgu_BindingSource.DataSource = _trinhDoList;

            TrinhDoTinHocClassList TrinhDoTinHocClassList = TrinhDoTinHocClassList.GetTrinhDoTinHocClassList();
            TrinhDoTinHocClass trinhdoTH = TrinhDoTinHocClass.NewTrinhDoTinHocClass(0, "<không chọn>");
            TrinhDoTinHocClassList.Insert(0, trinhdoTH);
            trinhDoTinHocClassListBindingSource.DataSource = TrinhDoTinHocClassList;
            //
            LoadDataBindingDonViDaoTao();

            //
            List<PhanLoaiLopDaoTao> loaiList = PhanLoaiLopDaoTao.CreatePhanLoaiLopDaoTaoList();
            gridLookUpEditLoai.Properties.DataSource = loaiList;
            gridLookUpEditLoai.Properties.DisplayMember = "TenLoai";
            gridLookUpEditLoai.Properties.ValueMember = "ID";
            //
            LyLuanChinhTriList LyLuanChinhTriList = LyLuanChinhTriList.GetLyLuanChinhTriList();
            LyLuanChinhTri lyluanCT = LyLuanChinhTri.NewLyLuanChinhTri(0, "<Trống>");
            LyLuanChinhTriList.Insert(0, lyluanCT);
            lyLuanChinhTriListBindingSource.DataSource = LyLuanChinhTriList;
            //
            QuanLyNhaNuoc item = QuanLyNhaNuoc.NewQuanLyNhaNuoc(0, "Trống");
            QuanLyNhaNuocList quanLyNNList = QuanLyNhaNuocList.GetQuanLyNhaNuocList();
            quanLyNNList.Insert(0, item);
            this.QuanLyNhaNuoc_BindingSource.DataSource = quanLyNNList;

        }


        private void KhoiTaoLoaiLopHoc(LoaiLopDaoTao loaiLophoc)
        {
            if (loaiLophoc == null)
            {
                _loaiLopHoc = LoaiLopDaoTao.NewLoaiLopDaoTao();
                _loaiLopHoc.VanbangChungChi = 1;
                _loaiLopHoc.TrongnuocNgoainuoc = 1;
                gridLookUpEditLoai.Focus();

            }
            else
                _loaiLopHoc = loaiLophoc;
            BingdingData();
            LoadlayoutControlItembyLoai(_loaiLopHoc.Loai);//--
            _loadformFinish = true;//--
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
            //if (_loaiLopHoc.Loai == 0)
            //{
            //    MessageBox.Show("Vui lòng nhập vào Loại của Loại Lớp học!");
            //    gridLookUpEditLoai.Focus();
            //    return false;
            //}
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

        private void LoadlayoutControlItembyLoai(int loai)
        {
            if (loai != 1 && loai != 2 && loai != 3 && loai != 4)//!Tin Hoc; !NgoaiNgu
            {
                HideControlItem(layoutControlItemLyLuanCT);
                HideControlItem(layoutControlItemQuanLyNhaNuoc);
                HideControlItem(layoutControlItemNgoaiNgu);
                HideControlItem(layoutControlItemTrinhDoNN);
                HideControlItem(layoutControlItemTrinhDoTH);

            }
            else if (loai == 1)
            {
                ShowControlItem(layoutControlItemLyLuanCT);
                HideControlItem(layoutControlItemQuanLyNhaNuoc);
                HideControlItem(layoutControlItemNgoaiNgu);
                HideControlItem(layoutControlItemTrinhDoNN);
                HideControlItem(layoutControlItemTrinhDoTH);
            }
            else if (loai == 2)
            {
                ShowControlItem(layoutControlItemQuanLyNhaNuoc);
                HideControlItem(layoutControlItemLyLuanCT);
                HideControlItem(layoutControlItemNgoaiNgu);
                HideControlItem(layoutControlItemTrinhDoNN);
                HideControlItem(layoutControlItemTrinhDoTH);
            }
            else if (loai == 3)//Tin Hoc
            {
                ShowControlItem(layoutControlItemTrinhDoTH);
                HideControlItem(layoutControlItemLyLuanCT);
                HideControlItem(layoutControlItemQuanLyNhaNuoc);
                HideControlItem(layoutControlItemNgoaiNgu);
                HideControlItem(layoutControlItemTrinhDoNN);
            }
            else if (loai == 4)//NgoaiNgu
            {
                ShowControlItem(layoutControlItemNgoaiNgu);
                ShowControlItem(layoutControlItemTrinhDoNN);
                HideControlItem(layoutControlItemLyLuanCT);
                HideControlItem(layoutControlItemQuanLyNhaNuoc);
                HideControlItem(layoutControlItemTrinhDoTH);
            }

        }

        #endregion//Functions

        private void AnTatCaControlItem()
        {
            foreach (LayoutControlItem item in this.layoutControlGroup1.Items)
            {
                item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void ShowControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }

        private void HideControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        public frmLoaiLopHoc2()
        {
            InitializeComponent();
        }
        public void LoadData(LoaiLopDaoTao loaiLopHoc)
        {
            KhoiTao();
            LoadDataBindingSource();
            KhoiTaoLoaiLopHoc(loaiLopHoc);
        }
        private bool KiemTra(string name)
        {
            bool bFound = false;
            ReportTemplate obj = ReportTemplate.GetReportTemplate(name);
            if (obj.Data != null)
                bFound = true;
            return bFound;
        }
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

        private void barbtXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void frmLoaiLopHoc2_FormClosing(object sender, FormClosingEventArgs e)
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


        private void gridLookUpEditLoai_EditValueChanged(object sender, EventArgs e)
        {
            if (_loadformFinish)
            {
                if (gridLookUpEditLoai.EditValue != null)
                {
                    int loai;
                    if (int.TryParse(gridLookUpEditLoai.EditValue.ToString(), out loai))
                    {
                        LoadlayoutControlItembyLoai(loai);
                        if (_loaiLopHoc != null)
                        {
                            if (loai != 1 && loai != 2 && loai != 3 && loai != 4)//!LyLuanCT, !Tin Hoc; !NgoaiNgu
                            {
                                _loaiLopHoc.MaLyLuanCT = 0;
                                _loaiLopHoc.MaQuanLyNhaNuoc = 0;
                                _loaiLopHoc.MaTrinhDoTH = 0;
                                _loaiLopHoc.MaNgoaiNgu = 0;
                                _loaiLopHoc.MaTrinhDoNN = 0;

                            }
                            else if (loai == 1)
                            {
                                _loaiLopHoc.MaQuanLyNhaNuoc = 0;
                                _loaiLopHoc.MaTrinhDoTH = 0;
                                _loaiLopHoc.MaNgoaiNgu = 0;
                                _loaiLopHoc.MaTrinhDoNN = 0;
                            }
                            else if (loai == 2)
                            {
                                _loaiLopHoc.MaLyLuanCT = 0;
                                _loaiLopHoc.MaTrinhDoTH = 0;
                                _loaiLopHoc.MaNgoaiNgu = 0;
                                _loaiLopHoc.MaTrinhDoNN = 0;
                            }
                            else if (loai == 3)//Tin Hoc
                            {
                                _loaiLopHoc.MaLyLuanCT = 0;
                                _loaiLopHoc.MaQuanLyNhaNuoc = 0;
                                _loaiLopHoc.MaNgoaiNgu = 0;
                                _loaiLopHoc.MaTrinhDoNN = 0;

                            }
                            else if (loai == 4)//NgoaiNgu
                            {
                                _loaiLopHoc.MaLyLuanCT = 0;
                                _loaiLopHoc.MaQuanLyNhaNuoc = 0;
                                _loaiLopHoc.MaTrinhDoTH = 0;

                            }
                        }

                    }
                }
            }
        }

    }
}
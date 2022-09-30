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
    public partial class frmLoaiLopHocDaoTaoList : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private LoaiLopDaoTaoList _loaiLopDaoTaoList;

        private int _maTruongDaoTao = 0;
        private int _loaiVanBang = 0;
        private int _maQuocGiaCap = 0;
        private int _maChuyenNganhDaoTao = 0;
        private LoaiLopDaoTao _loaiLopDaoTao;
        private int _maLoaiLopDaoTao = 0;
        bool _tulopHoc;

        public int MaLoaiLopDaoTao
        {
            get
            {
                return _maLoaiLopDaoTao;
            }
        }
#endregion

        #region Functions

        private void LoadData()
        {
            GetDieuKienTim();
            _loaiLopDaoTaoList = LoaiLopDaoTaoList.GetLoaiLopDaoTaoList(_loaiVanBang, _maQuocGiaCap, _maTruongDaoTao, _maChuyenNganhDaoTao);
            bsLoaiLopDaoTaoList.DataSource = _loaiLopDaoTaoList;
            
        }

        private void FormatForm()
        {
            //if(_tulopHoc)
            //{
            //    btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
        }

        private void LoadDataBindingSource()
        {
            FormatForm();
            DesignGrid();

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
        }

        private void GetDieuKienTim()
        {
            if(MaTruongDaoTaoGLU.EditValue!=null)
            {
                _maTruongDaoTao = (int)MaTruongDaoTaoGLU.EditValue;
            }
            else
            {
                _maTruongDaoTao = 0;
            }
            if (LoaiVanBangGLU.EditValue != null)
            {
                _loaiVanBang = (int)LoaiVanBangGLU.EditValue;
            }
            else
            {
                _loaiVanBang = 0;
            }
            if (MaQuocGiaCapGLU.EditValue != null)
            {
                _maQuocGiaCap = (int)MaQuocGiaCapGLU.EditValue;
            }
            else
            {
                _maQuocGiaCap = 0;
            }
            if (MaChuyenNganhDaoTaoGLU.EditValue != null)
            {
                _maChuyenNganhDaoTao  = (int)MaChuyenNganhDaoTaoGLU.EditValue;
            }
            else
            {
                _maChuyenNganhDaoTao = 0;
            }

        }

        private void DesignGrid()
        {

            gridControl1.DataSource = bsLoaiLopDaoTaoList;
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaQL", "TenLoaiLop", "LoaiVanBangString", "VanbangChungChiString", "QuocGiaCap", "TenTruongDaoTao", "TenChuyenNganhDaoTao", "TrongnuocNgoainuocString" },
                                new string[] { "Mã QL","Tên loại Lớp học", "Loại Văn bằng/Chứng chỉ", "Văn bằng/ Chứng chỉ", "Quốc gia cấp", "Trường đào tạo", "Chuyên ngành đào tạo", "Đào tạo"},
                                             new int[] { 80, 150, 80, 85, 85, 120, 120, 80 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaQL", "TenLoaiLop", "LoaiVanBangString", "VanbangChungChiString", "QuocGiaCap", "TenTruongDaoTao", "TenChuyenNganhDaoTao", "TrongnuocNgoainuocString" }, DevExpress.Utils.HorzAlignment.Center);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
            gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdView1_KeyDown);
            
        }

        private bool KiemTraTruocKhiXoa()
        {
            int[] deleteRows = gridView1.GetSelectedRows();
            foreach (int deleteRow in deleteRows)
            {
                LoaiLopDaoTao _loaiLopHoc = gridView1.GetRow(deleteRow) as LoaiLopDaoTao;
                if (LoaiLopDaoTao.KiemTraLoaiLopHocdaDung(_loaiLopHoc.MaLoaiLop))
                {
                    MessageBox.Show("Có Lớp đã được sử dùng, không thể xóa!");
                    return false;
                }

            }
            return true;
        }
        #endregion

        #region Event
        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                LoaiLopDaoTao loaiLophoc = gridView1.GetFocusedRow() as LoaiLopDaoTao;
                if(loaiLophoc!=null)
                {
                    _loaiLopDaoTao = LoaiLopDaoTao.GetLoaiLopDaoTao(loaiLophoc.MaLoaiLop);
                    if (_tulopHoc)
                    {
                        _maLoaiLopDaoTao = _loaiLopDaoTao.MaLoaiLop;
                        this.Close();
                    }
                    else
                    {
                        //frmLoaiLopHoc frm = new frmLoaiLopHoc();
                        frmLoaiLopHoc2 frm = new frmLoaiLopHoc2();
                        frm.LoadData(_loaiLopDaoTao);
                        if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        {
                            LoadData();

                        }//New

                    }   
                }
                

            }
        }

        private void GrdView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (KiemTraTruocKhiXoa())
                HamDungChung.DeleteSelectedRowsGridViewDev(gridView1, e);
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
            if (_loaiLopDaoTaoList.Count == 0)
                MessageBox.Show("Danh sách rỗng");
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmLoaiLopHoc frm = new frmLoaiLopHoc();
            frmLoaiLopHoc2 frm = new frmLoaiLopHoc2();
            frm.LoadData(null);
            frm.TuLopHoc = _tulopHoc;
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                LoadData();

            }//New
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bsLoaiLopDaoTaoList.EndEdit();
                _loaiLopDaoTaoList.ApplyEdit();
                _loaiLopDaoTaoList.Save();
                MessageBox.Show("Cập nhật thành công!", "Thông Báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện!", "Thông Báo");
            }
        }

        private void frmLoaiLopHocDaoTaoList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_tulopHoc)
            {
                if (_maLoaiLopDaoTao == 0)
                {
                    MessageBox.Show("Hãy chọn 1 lớp học cho lớp chính thức", "Thông Báo");
                    e.Cancel = true;
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraTruocKhiXoa())
            {
                if (gridView1.RowCount > 0)
                {
                    if (gridView1.GetSelectedRows().Length > 0)
                    {
                        if (XtraMessageBox.Show(String.Format("Bạn có chắc muốn xóa {0} dòng đang chọn ?", gridView1.GetSelectedRows().Length), "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            gridView1.DeleteSelectedRows();
                        }
                    }
                } 
            }
        }
        #endregion
        public frmLoaiLopHocDaoTaoList()
        {
            InitializeComponent();
            LoadDataBindingSource();
            LoadData();

        }
        public frmLoaiLopHocDaoTaoList(bool tuLopHoc)
        {
            InitializeComponent();
            _tulopHoc = tuLopHoc;
            LoadDataBindingSource();
            LoadData();

        }

        

        

        

        

    }
}
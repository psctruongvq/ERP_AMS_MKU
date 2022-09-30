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
    public partial class frmLopHocList : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private LopHocList _lopHocList;

        private int _nam=0;
        private int _maDonViDaoTao = 0;
        private int _maTruongDaoTao = 0;
        private int _loaiVanBang = 0;
        private int _maQuocGiaCap = 0;
        private int _maChuyenNganhDaoTao = 0;
        private int _maLoaiLop = 0;
        private bool _tuUsercontrol = false;
        private LopHoc _lopHoc;

        public LopHoc LopHoc
        {
            get
            {
                return _lopHoc;
            }
        }
#endregion

        #region Functions

        private void LoadData()
        {
            GetDieuKienTim();
            _lopHocList = LopHocList.GetLopHocList(_loaiVanBang, _maQuocGiaCap, _maTruongDaoTao, _maChuyenNganhDaoTao,_nam,_maDonViDaoTao,_maLoaiLop);
            bsLopHocList.DataSource = _lopHocList;
        }

        private void FormatForm()
        {
            if(_tuUsercontrol)
            {
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
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

            DonViDaoTao dvdt = DonViDaoTao.NewDonViDaoTao("<Không chọn>");
            DonViDaoTaoList donvidaotaoList = DonViDaoTaoList.GetDonViDaoTaoList();
            donvidaotaoList.Insert(0, dvdt);
            bsDonViDaoTaoList.DataSource = donvidaotaoList;

            LoaiLopDaoTao ll = LoaiLopDaoTao.NewLoaiLopDaoTao("<Không chọn>");
            LoaiLopDaoTaoList loaiLopList = LoaiLopDaoTaoList.GetLoaiLopDaoTaoList(0, 0, 0, 0);
            loaiLopList.Insert(0, ll);
            bsLoaiLopDaoTaoList.DataSource = loaiLopList;
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

            int tryint;
            if (int.TryParse(txt_nam.Text, out tryint))
            {
                _nam = tryint;
            }
            else
            {
                _nam = 0;
            }

            int tryintMaDV;
            if (int.TryParse(DonViDaoTaoGrLU.EditValue.ToString(),out tryintMaDV))
            {
                _maDonViDaoTao = tryintMaDV;
            }
            else _maDonViDaoTao = 0;

            //int tryintMaLoaiLop;
            //if (int.TryParse(LoaiLopHocGrLu.EditValue.ToString(), out tryintMaLoaiLop))
            //{
            //    _maLoaiLop = tryintMaLoaiLop;
            //}
            //else _maLoaiLop = 0;
            if (LoaiLopHocGrLu.EditValue != null)
            {
                _maLoaiLop = (int)LoaiLopHocGrLu.EditValue;
            }
            else
            {
                _maLoaiLop = 0;
            }

        }

        private void DesignGrid()
        {

            gridControl1.DataSource = bsLopHocList;
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "TenvanbangChungchi","LoaiVanBangString","VanbangChungChiString","NgayBatDau", "NgayKetThuc","QuocGiaCap","TenDonViDaoTao","TenTruongDaoTao","TenChuyenNganhDaoTao","TrongnuocNgoainuocString","GhiChu" },
                                new string[] { "Tên lớp học", "Loại Văn bằng/Chứng chỉ", "Văn bằng/ Chứng chỉ", "Ngày bắt đầu", "Ngày kết thúc", "Quốc gia cấp","Tên đơn vị đào tào", "Trường đào tạo", "Chuyên ngành đào tạo", "Đào tạo", "Ghi chú" },
                                             new int[] { 150, 75, 75, 75, 75, 75,100, 100, 100, 100, 150 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "TenvanbangChungchi", "LoaiVanBangString", "VanbangChungChiString", "NgayBatDau", "NgayKetThuc", "QuocGiaCap", "TenDonViDaoTao", "TenTruongDaoTao", "TenChuyenNganhDaoTao", "TrongnuocNgoainuocString", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);

            //gridView1.MouseEnter += new System.EventHandler(this.gridView1_MouseEnter);
            
        }
        #endregion

        #region Event
        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                LopHoc lophoc = gridView1.GetFocusedRow() as LopHoc;
                if(lophoc!=null)
                {
                    _lopHoc = LopHoc.GetLopHoc(lophoc.MaLopHoc);
                    if (_tuUsercontrol)
                    {
                        this.Close();
                    }
                    else
                    {
                        frmLopHoc frm = new frmLopHoc();
                        frm.LoadData(_lopHoc);
                        if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        {
                            LoadData();

                        }//New

                    }   
                }
                

            }
        }

        private void gridView1_MouseEnter(object sender, EventArgs e)
        {
            LopHoc lophoc = gridView1.GetFocusedRow() as LopHoc;
            if (lophoc != null)
            {
                if (LopHoc.GetMonth_RemainTime(lophoc.MaLopHoc) <= 3)
                {
                    gridView1.OptionsView.ShowViewCaption = true;
                    gridView1.ViewCaption = string.Format("Lớp {0} còn {1} tháng nữa là hết hạn", lophoc.TenvanbangChungchi, LopHoc.GetMonth_RemainTime(lophoc.MaLopHoc));
                }
                else
                    gridView1.ViewCaption = "";
            }
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLopHoc frm = new frmLopHoc();
            frm.LoadData(null);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                LoadData();

            }//New
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion
        public frmLopHocList()
        {
            InitializeComponent();
            LoadDataBindingSource();
            LoadData();

        }
        public frmLopHocList(bool tuUsercontrol)
        {
            InitializeComponent();
            _tuUsercontrol = tuUsercontrol;
            LoadDataBindingSource();
            LoadData();

        }

        private void DonViDaoTaoGrLU_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        

        

        

    }
}
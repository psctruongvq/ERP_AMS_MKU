using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using DevExpress.XtraEditors;
//23/10/2014    
namespace PSC_ERP.UserInterface.NhanSu.QuanLyDaoTao.Controllers
{
    public partial class UCLopHoc : UserControl
    {
        #region Properties

        private DateTime? _NgayKetThuc;
        private DateTime? _NgayBatDau;
        private int _MaLoaiLop;
        private int _MaLopHoc;
        private bool _loadfinish = false;
        private int _maDeCu = 0;
        private LopHoc _lopHoc;
        private LopHoc _lopHocOld;


        public int MaLopHoc
        {
            get { return _MaLopHoc; }
            set
            {
                _MaLopHoc = value;
            }
        }


        public int MaLoaiLop
        {
            get { return _MaLoaiLop; }
            set
            {
                _MaLoaiLop = value;
            }
        }


        public DateTime? NgayBatDau
        {
            get { return _NgayBatDau; }
            set
            {
                _NgayBatDau = value;
            }
        }


        public DateTime? NgayKetThuc
        {
            get { return _NgayKetThuc; }
            set
            {
                _NgayKetThuc = value;
            }
        }



        #endregion

        #region Functions

        private void KiemTraLopHocSapHetHan()
        {
            if (_MaLopHoc != 0)
                if (LopHoc.KiemTraLopHocdaDeCu(_lopHoc.MaLopHoc) == false)
                    if (LopHoc.GetMonth_RemainTime(_MaLopHoc) <= 3)
                    {
                        MessageBox.Show(string.Format("Lớp còn {0} tháng nữa là hết hạn", LopHoc.GetMonth_RemainTime(_MaLopHoc)));
                    }
        }

        private void KhoiTao()
        {
            btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
        private void LoadDataBindingDonViDaoTao()
        {
            DonViDaoTao dvdt = DonViDaoTao.NewDonViDaoTao("<Không chọn>");
            DonViDaoTaoList donvidaotaoList = DonViDaoTaoList.GetDonViDaoTaoList();
            donvidaotaoList.Insert(0, dvdt);
            bsDonViDaoTaoList.DataSource = donvidaotaoList;
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


        private void KhoiTaoLopHoc(LopHoc lopHoc)
        {
            if (lopHoc == null)
            {
                _lopHoc = LopHoc.NewLopHoc();
                _lopHoc.VanbangChungChi = 1;
                _lopHoc.TrongnuocNgoainuoc = 1;
                TenvanbangChungchiTextEdit.Focus();
            }
            else
            {
                _lopHoc = lopHoc;
                if (_lopHoc.MaLopHoc != 0)
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
            _MaLopHoc = _lopHoc.MaLopHoc;
            _MaLoaiLop = _lopHoc.MaLoaiLop;

            if (_lopHoc.NgayBatDauChinhThuc != null)
                _NgayBatDau = _lopHoc.NgayBatDauChinhThuc;
            else
                _NgayBatDau = _lopHoc.NgayBatDau;
            if (_lopHoc.NgayKetThucChinhThuc != null)
                _NgayKetThuc = _lopHoc.NgayKetThucChinhThuc;
            else
                _NgayKetThuc = _lopHoc.NgayKetThuc;
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
                MessageBox.Show("Vui lòng chọn Loại lớp thuộc vào!", "Thông Báo");
                LoaiLopHocGLU.Focus();
                return false;
            }
            if (_lopHoc.NgayBatDau == null || _lopHoc.NgayKetThuc == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ ngày bắt đầu và kết thúc dự kiến cho lớp để thuận lợi cho việc theo dõi!", "Thông Báo");
                NgayBatDauDateEdit.Focus();
                return false;
            }
            //if(LopHoc.KiemTraLopHocMoTrungThoiGian_MaLoaiLop(_lopHoc.MaLoaiLop,_lopHoc.MaLopHoc,_lopHoc.NgayBatDau.Value,_lopHoc.NgayKetThuc.Value))
            //{
            //    MessageBox.Show("Lớp học chính thức mở trùng ngày với lớp học chính thức trước, trong khi cùng 1 lớp học!", "Thông Báo");
            //    return false;
            //}
            return true;
        }

        public bool LuuLopHocControl()
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
                    _MaLopHoc = _lopHoc.MaLopHoc;
                    _MaLoaiLop = _lopHoc.MaLoaiLop;
                    _NgayBatDau = _lopHoc.NgayBatDauChinhThuc;
                    _NgayKetThuc = _lopHoc.NgayKetThucChinhThuc;
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

        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoLopHoc(null);
        }
        private void btnLoadtuDSLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DeCu.KiemTraDeCuDaCoNguoiDiHoc(_maDeCu) == false)
            {
                frmLopHocList frm = new frmLopHocList(true);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    if (frm.LopHoc != null)
                    {
                        _loadfinish = false;
                        _lopHoc = frm.LopHoc;
                        _lopHocOld = LopHoc.GetLopHoc(_lopHoc.MaLopHoc);
                        BingdingData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Đề cử đã có người đi học, không thể thay đổi lớp!", "Thông Báo");
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
                //GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                //gridLUE.EditValue = null;
            }
        }

        private void LoaiLopHocGLU_EditValueChanged(object sender, EventArgs e)
        {
            if (LoaiLopHocGLU.EditValue != null && _loadfinish)
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
            _loadfinish = true;
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

        private void NgayBatDauDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            //_NgayBatDau = NgayBatDauDateEdit.EditValue as DateTime?;
            //if(NgayBatDauChinhThucdateEdit.EditValue==null)
            //{
            //    NgayBatDauChinhThucdateEdit.EditValue = NgayBatDauDateEdit.EditValue;
            //}
        }

        private void NgayKetThucDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            //_NgayKetThuc = NgayKetThucDateEdit.EditValue as DateTime?;
            //if (NgayKetThucChinhThucdateEdit.EditValue == null)
            //{
            //    NgayKetThucChinhThucdateEdit.EditValue = NgayKetThucDateEdit.EditValue;
            //}
        }

        private void NgayBatDauChinhThucdateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (_loadfinish)
                _NgayBatDau = NgayBatDauChinhThucdateEdit.EditValue as DateTime?;
        }

        private void NgayKetThucChinhThucdateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (_loadfinish)
                _NgayKetThuc = NgayKetThucChinhThucdateEdit.EditValue as DateTime?;
        }
        #endregion

        public UCLopHoc()
        {
            InitializeComponent();
        }


        public void LoadData(LopHoc lopHoc, int maDeCu)
        {
            _maDeCu = maDeCu;
            KhoiTao();
            LoadDataBindingSource();
            KhoiTaoLopHoc(lopHoc);
            KiemTraLopHocSapHetHan();
        }








    }
}

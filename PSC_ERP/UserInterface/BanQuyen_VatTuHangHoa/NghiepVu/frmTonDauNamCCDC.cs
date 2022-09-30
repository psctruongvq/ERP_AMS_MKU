using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
namespace PSC_ERP
{
    public partial class frmTonDauNamCCDC : DevExpress.XtraEditors.XtraForm
    {
        KyKetChuyenCongCuDungCu _kyKetChuyen = KyKetChuyenCongCuDungCu.NewKyKetChuyenCongCuDungCu();
        public frmTonDauNamCCDC()
        {
            InitializeComponent();
            LoadForm();
        }
        private void LoadForm()
        {
            numNam.Value = DateTime.Today.Year;
            Utils.GridUtils.SetSTTForGridView(gridView_ChiTiet, 35);
            gridView_ChiTiet.OptionsBehavior.Editable = false;

            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();//.GetBoPhanListBy_All();            
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaCongCuDungCuList();
            //kyListBindingSource.DataSource = KyList.GetKyList();
            kyKetChuyenCongCuDungCuBindingSource.DataSource = _kyKetChuyen;
            cTKetChuyenCongCuDungCuListBindingSource.DataSource = _kyKetChuyen.CT_KetChuyenCongCuDungCuList;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private bool KTDuLieuNhap()
        {
            bool _Check = true;
            if (_kyKetChuyen.MaKy == 0)
            {
                MessageBox.Show("Hãy chọn năm");
                _Check = false;
                numNam.Focus();//gridLookUpEdit_Ky.Focus();
            }
            else if (_kyKetChuyen.MaBoPhan == 0)
            {
                MessageBox.Show("Hãy nhập vào giá trị Bộ Phận");
                _Check = false;
                gridLookUpEdit_BoPhan.Focus();
            }
            return _Check;
        }

        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_KetChuyenCongCuDungCu ctkc in _kyKetChuyen.CT_KetChuyenCongCuDungCuList)
            {
                if (ctkc.MaHangHoa == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập Hàng hóa cha cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                if (ctkc.SoLuong <= 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập Số lượng cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                if (ctkc.ThanhTien == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập Thành tiền cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            return kq;
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            kyKetChuyenCongCuDungCuBindingSource.EndEdit();
            _kyKetChuyen = KyKetChuyenCongCuDungCu.GetKyKetChuyenCongCuDungCu(_kyKetChuyen.MaKy, _kyKetChuyen.MaBoPhan);
            if (_kyKetChuyen.MaKetChuyen == 0)
            {
                MessageBox.Show(this, "Kỳ chưa có số dư đầu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _kyKetChuyen.CT_KetChuyenCongCuDungCuList = CT_KetChuyenCongCuDungCuList.NewCT_KetChuyenCongCuDungCuList();
                cTKetChuyenCongCuDungCuListBindingSource.DataSource = _kyKetChuyen.CT_KetChuyenCongCuDungCuList;
            }
            else
            {
                cTKetChuyenCongCuDungCuListBindingSource.DataSource = _kyKetChuyen.CT_KetChuyenCongCuDungCuList;
                kyKetChuyenCongCuDungCuBindingSource.DataSource = _kyKetChuyen;
            }
        }



        private void gridLookUpEdit_BoPhan_EditValueChanged(object sender, EventArgs e)
        {
            _kyKetChuyen.MaBoPhan = (int)gridLookUpEdit_BoPhan.EditValue;
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _kyKetChuyen = KyKetChuyenCongCuDungCu.NewKyKetChuyenCongCuDungCu();
            kyKetChuyenCongCuDungCuBindingSource.DataSource = _kyKetChuyen;
            cTKetChuyenCongCuDungCuListBindingSource.DataSource = _kyKetChuyen.CT_KetChuyenCongCuDungCuList;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KTDuLieuNhap())
            {
                if (KiemTraChiTiet())
                {
                    try
                    {
                        _kyKetChuyen.ApplyEdit();
                        _kyKetChuyen.Save();
                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btn_Sua_Khoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btn_Sua_Khoa.Caption == "Sửa")
            {
                btn_Sua_Khoa.Caption = "Khóa";
                gridView_ChiTiet.OptionsBehavior.Editable = true;

            }
            else if (btn_Sua_Khoa.Caption == "Khóa")
            {
                btn_Sua_Khoa.Caption = "Sửa";
                gridView_ChiTiet.OptionsBehavior.Editable = false;
            }
        }

        private void gridView_ChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (cTKetChuyenCongCuDungCuListBindingSource.Current != null)
            {
                CT_KetChuyenCongCuDungCu _ctkc = (CT_KetChuyenCongCuDungCu)cTKetChuyenCongCuDungCuListBindingSource.Current;
                if (gridView_ChiTiet.FocusedColumn.Name == "colMaHangHoa")
                {
                    //_ctkc.MaHangHoa = 0;                    
                }
            }
        }
        //private void gridLookUpEdit_Ky_EditValueChanged(object sender, EventArgs e)
        //{
        //    _kyKetChuyen.MaKy = (int)gridLookUpEdit_Ky.EditValue;
        //}
        private void numNam_EditValueChanged(object sender, EventArgs e)
        {

            int nam = (int)numNam.Value;
            int maKy = 0;
            if (nam.ToString().Length >= 4)
            {
                maKy = Ky.GetMaKyDauCuaNam(nam);


                if (maKy == 0)
                    MessageBox.Show("Kỳ đầu của năm " + nam.ToString() + " chưa được khai báo trong danh sách kỳ");
            }
            _kyKetChuyen.MaKy = maKy;
        }


    }
}
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
    public partial class frmDonViDaoTao : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        DonViDaoTao _donViDaoTao;
        #endregion

        #region Functions
        private void KhoiTao()
        {
            bsDonViDaoTao.DataSource = typeof(DonViDaoTao);
            btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }



        private void LoadDataBindingSource()
        {
        }


        private void KhoiTaoDonViDaoTao(DonViDaoTao donvi)
        {
            if (donvi == null)
            {
                _donViDaoTao = DonViDaoTao.NewDonViDaoTao();
                txtMaQL.Focus();
            }
            else
                _donViDaoTao = donvi;
            BingdingData();
        }

        private void BingdingData()
        {
            bsDonViDaoTao.DataSource = _donViDaoTao;
        }

        private bool KiemTraTruocKhiXoa()
        {
            if (DonViDaoTao.KiemTraDonViDaoTaoDaSuDung(_donViDaoTao.MaDonViDaoTao))
            {
                MessageBox.Show("Đơn vị đã sử dụng, không thể xóa!");
                return false;
            }
            return true;
        }

        private bool KiemTraTruocKhiLuu()
        {//d
            if (_donViDaoTao.TenDonViDaoTao.Length==0)
            {
                MessageBox.Show("Tên Đơn vị đào tạo không thể để trống", "Thông Báo");
                txtTenDonViDaoTao.Focus();
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
                    _donViDaoTao.ApplyEdit();
                    bsDonViDaoTao.EndEdit();
                    _donViDaoTao.Save();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else return false;
            return true;
        }


        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoDonViDaoTao(null);
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
                if (MessageBox.Show("Bạn muốn xóa Đơn vị này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        DonViDaoTao.DeleteDonViDaoTao(_donViDaoTao);
                        MessageBox.Show("Xóa thành công! Chuyển sang Thêm mới");
                        btnThemMoi.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
        }

        private void frmDonViDaoTao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_donViDaoTao.IsDirty)
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

        #endregion


        public frmDonViDaoTao()
        {
            InitializeComponent();

        }

        public void LoadData(DonViDaoTao donvi)
        {
            KhoiTao();
            LoadDataBindingSource();
            KhoiTaoDonViDaoTao(donvi);
        }

    }
}
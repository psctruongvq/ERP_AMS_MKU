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
    public partial class frmQuanLyDiHoc : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        QuaTrinhDaoTaoNhanLuc _quaTrinhDaoTao;
        private bool _dongSaukhixoa = false;
        #endregion

        #region Functions
        private void KhoiTao()
        {
            bsQuaTrinhDaoTao.DataSource = typeof(QuaTrinhDaoTaoNhanLuc);
        }

        private void LoadDataBindingSource()
        {

        }

        private void KhoiTaoQuaTrinhDaoTao(QuaTrinhDaoTaoNhanLuc quaTrinhDaoTao)
        {
            _quaTrinhDaoTao = quaTrinhDaoTao;
            BingdingData();
        }

        private void BingdingData()
        {
            bsQuaTrinhDaoTao.DataSource = _quaTrinhDaoTao;
        }

        private bool KiemTraTruocKhiLuu()
        {
            return true;
        }

        private bool KiemTraTruocKhiXoa()
        {
            if(_quaTrinhDaoTao.DaNopBang)
            {
                MessageBox.Show("Quá trình đào tạo đã hoàn thành, không thể xóa!", "Thông Báo");
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
                    _quaTrinhDaoTao.ApplyEdit();
                    bsQuaTrinhDaoTao.EndEdit();
                    _quaTrinhDaoTao.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else return false;
            return true;
        }

        private void FormatConTrolForm()
        {
            //TenNhanVienTextEdit.Enabled = false;
            //MaQLNhanVienTextEdit.Enabled = false;
            //BoPhanNhanVienTextEdit.Enabled = false;
            //TenvanbangChungchiTextEdit.Enabled = false;
            //LoaiVanBangStringTextEdit.Enabled = false;
            //QuocGiaCapStringTextEdit.Enabled = false;
            //TruongDaoTaostringTextEdit.Enabled = false;
            //VanbangChungchiStringTextEdit.Enabled = false;
            //TrongnuocNgoainuocStringTextEdit.Enabled = false;
            //ChuyenNganhDaoTaoStringTextEdit.Enabled = false;
            //txtSoNgayHoc.Enabled = false;

            TenNhanVienTextEdit.Properties.ReadOnly = true;
            MaQLNhanVienTextEdit.Properties.ReadOnly = true;
            BoPhanNhanVienTextEdit.Properties.ReadOnly = true;
            TenvanbangChungchiTextEdit.Properties.ReadOnly = true;
            LoaiVanBangStringTextEdit.Properties.ReadOnly = true;
            QuocGiaCapStringTextEdit.Properties.ReadOnly = true;
            TruongDaoTaostringTextEdit.Properties.ReadOnly = true;
            VanbangChungchiStringTextEdit.Properties.ReadOnly = true;
            TrongnuocNgoainuocStringTextEdit.Properties.ReadOnly = true;
            ChuyenNganhDaoTaoStringTextEdit.Properties.ReadOnly = true;
            txtSoNgayHoc.Properties.ReadOnly = true;

            KiemTraDaNopBang();
        }

        private void DaNopBang()
        {
            SovanbangChungchiTextEdit.Enabled = true;
            NgayCapDateEdit.Enabled = true;
            NamTotNghiepSpinEdit.Enabled = true;
            XepLoaiTextEdit.Enabled = true;
            NguoiKyTextEdit.Enabled = true;
            //GhiChuTextEdit.Enabled = true;
        }
        private void ChuaNopBang()
        {
            SovanbangChungchiTextEdit.Enabled = false;
            NgayCapDateEdit.Enabled = false;
            NamTotNghiepSpinEdit.Enabled = false;
            XepLoaiTextEdit.Enabled = false;
            NguoiKyTextEdit.Enabled = false;
            //GhiChuTextEdit.Enabled = false;
        }

        private void ResetDuLieuKhiChuaNopBang()
        {
            _quaTrinhDaoTao.SovanbangChungchi = string.Empty;
            _quaTrinhDaoTao.NgayCap = DateTime.MinValue;
            _quaTrinhDaoTao.NamTotNghiep = 0;
            _quaTrinhDaoTao.XepLoai = string.Empty;
            _quaTrinhDaoTao.NguoiKy = string.Empty;
            _quaTrinhDaoTao.GhiChu = string.Empty;
            bsQuaTrinhDaoTao.DataSource = _quaTrinhDaoTao;
        }

        private void KiemTraDaNopBang()
        {
            if (_quaTrinhDaoTao.DaNopBang)
                DaNopBang();
            else
            {
                ResetDuLieuKhiChuaNopBang();
                ChuaNopBang(); 
            }
                
        }

        #endregion

        #region Event

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

        private void frmQuanLyDiHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_dongSaukhixoa == false)
            {
                if (_quaTrinhDaoTao.IsDirty)
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

        }

        private void btnXoaQuaTrinhDaoTao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraTruocKhiXoa())
            {
                if (MessageBox.Show("Bạn muốn xóa quản lý đi học này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        QuaTrinhDaoTaoNhanLuc.DeleteQuaTrinhDaoTaoNhanLuc(_quaTrinhDaoTao);
                        _dongSaukhixoa = true;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể thực hiện");
                    }
                }
            }
        }

        private void DaNopBangcheck_EditValueChanged(object sender, EventArgs e)
        {
            _quaTrinhDaoTao.DaNopBang = DaNopBangcheck.Checked;
            KiemTraDaNopBang();
        }
        #endregion
        public frmQuanLyDiHoc(QuaTrinhDaoTaoNhanLuc quaTrinhDaoTao)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            KhoiTao();
            LoadDataBindingSource();
            KhoiTaoQuaTrinhDaoTao(quaTrinhDaoTao);
            FormatConTrolForm();
        }

        

        
    }
}
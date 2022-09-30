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
    public partial class XtraFrm_LoaiKho : DevExpress.XtraEditors.XtraForm
    {
        #region Properties and Methods
        LoaiKhoBQ_VT k;
        LoaiKhoBQ_VTList _loaiKhoBQ_VTList;
        #endregion //Properties and Methods
        private void loadForm()
        {
            _loaiKhoBQ_VTList = LoaiKhoBQ_VTList.GetLoaiKhoBQ_VTList();
            bs_LoaiKho.DataSource = _loaiKhoBQ_VTList;
            grd_DSLoaiKho.DataSource = bs_LoaiKho;
            //
            if (bs_LoaiKho.Count == 0)
                btnThemMoi.PerformClick();
            else
                k = (LoaiKhoBQ_VT)bs_LoaiKho.Current;
        }
        public XtraFrm_LoaiKho()
        {
            InitializeComponent();
            bs_LoaiKho.DataSource = typeof(LoaiKhoBQ_VTList);
        }

        private void XtraFrm_LoaiKho_Load(object sender, EventArgs e)
        {
            loadForm();
            Utils.GridUtils.SetSTTForGridView(gridView_DMLoaiKho, 35);

        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                k = LoaiKhoBQ_VT.NewLoaiKhoBQ_VT();
                _loaiKhoBQ_VTList.Insert(0, k);
                txt_MaQuanLy.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView_DMLoaiKho.DeleteSelectedRows();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadForm();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                _loaiKhoBQ_VTList.ApplyEdit();
                bs_LoaiKho.EndEdit();
                _loaiKhoBQ_VTList.Save();

                MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể lưu");
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                this.Close();

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void txt_TenLoaiKho_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void XtraFrm_LoaiKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (k.IsDirty)
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
}
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


    public partial class XtraFrm_DonViTinh : DevExpress.XtraEditors.XtraForm
    {
        #region Properties and Methods
        DonViTinhList _donViTinhList;
        DonViTinh dvt;
        #endregion //Properties and Methods
        private void ThemMoi()
        {
            try
            {
                 dvt = DonViTinh.NewDonViTinh();
                _donViTinhList.Insert(0, dvt);
                txtMaQuanLy.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadForm()
        {
            _donViTinhList = DonViTinhList.GetDonViTinhList();
            bs_DonViTinhList.DataSource = _donViTinhList;
            grd_DVT.DataSource = bs_DonViTinhList;
           //
            if (bs_DonViTinhList.Count == 0)
                btnThemMoi.PerformClick();
            else
                dvt = (DonViTinh)bs_DonViTinhList.Current;

        }
        public XtraFrm_DonViTinh()
        {
            InitializeComponent();
            bs_DonViTinhList.DataSource = typeof(DonViTinhList);
        }

        private void XtraFrm_DonViTinh_Load(object sender, EventArgs e)
        {

            LoadForm();
            Utils.GridUtils.SetSTTForGridView(gridView_DMDonViTinh, 35);
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThemMoi();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridView_DMDonViTinh.DeleteSelectedRows();
            }
            catch
            {
                MessageBox.Show("Nhấn nút Refesh trước khi thực hiện thao tác Xóa");
            }
            

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _donViTinhList = DonViTinhList.GetDonViTinhList();
            bs_DonViTinhList.DataSource = _donViTinhList;
            grd_DVT.DataSource = bs_DonViTinhList;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                _donViTinhList.ApplyEdit();
                bs_DonViTinhList.EndEdit();
                _donViTinhList.Save();

                MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể lưu! "+ex.Message);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                this.Close();

        }

        private void XtraFrm_DonViTinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dvt.IsDirty)
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
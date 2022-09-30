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
    public partial class frmBoPhanMoRongList : DevExpress.XtraEditors.XtraForm
    {
        public frmBoPhanMoRongList()
        {
            InitializeComponent();
            LoadForm();

        }

        BoPhanMoRongList _boPhanMoRongList;

        public void LoadForm()
        {
            _boPhanMoRongList = BoPhanMoRongList.GetBoPhanMoRongList();
            boPhanMoRongListBindingSource.DataSource = _boPhanMoRongList;
        }

 
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView_BoPhanMoRongList.DeleteSelectedRows();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();//
            try
            {

                _boPhanMoRongList.ApplyEdit();
                _boPhanMoRongList.Save();

                MessageBox.Show(this, "Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(this, "Không thể lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void grid_BoPhanList_DoubleClick(object sender, EventArgs e)
        {
            //BoPhanMoRong _bp = (BoPhanMoRong)grid_BoPhanList.GetFocusedRow();
            //if (_bp != null)
            //{
            //    BoPhanMoRong _boPhan = BoPhanMoRong.GetBoPhanMoRong(_bp.MaBoPhanMoRong);
            //    frmBoPhanMoRong frm = new frmBoPhanMoRong(_boPhan);
            //    frm.ShowDialog();
            //}
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmBoPhanMoRongList_Load(object sender, EventArgs e)
        {

            Utils.GridUtils.SetSTTForGridView(gridView_BoPhanMoRongList, 35);
            Utils.GridUtils.InitCopyCellForGridView(gridView_BoPhanMoRongList);
            Utils.GridUtils.InitMultiCellSelectForGridView(gridView_BoPhanMoRongList);
        }
    }
}
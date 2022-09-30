using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class XtraFrm_LoaiVatTuHH : XtraForm
    {
        LoaiVatTuHHBQ_VT vt;
        LoaiVatTuHHBQ_VTList _loaiVatTuHHBQ_VTList;
        private void loadform()
        {
            _loaiVatTuHHBQ_VTList = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHBQ_VTList();
            bs_LoaiVatTuHH.DataSource = _loaiVatTuHHBQ_VTList;
            grd_DSLoaiVatTuHH.DataSource = bs_LoaiVatTuHH;
            if (bs_LoaiVatTuHH.Count == 0)
                btnThemMoi.PerformClick();
            else
                vt = (LoaiVatTuHHBQ_VT)bs_LoaiVatTuHH.Current;
        }
        public XtraFrm_LoaiVatTuHH()
        {
            InitializeComponent();
            bs_LoaiVatTuHH.DataSource = typeof(LoaiVatTuHHBQ_VTList);
        }

        private void XtraForm2_Load(object sender, EventArgs e)
        {
            loadform();
            Utils.GridUtils.SetSTTForGridView(gridView_DSLoaiVatTuHH, 35);
        }    


        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView_DSLoaiVatTuHH.DeleteSelectedRows();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _loaiVatTuHHBQ_VTList = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHBQ_VTList();
            bs_LoaiVatTuHH.DataSource = _loaiVatTuHHBQ_VTList;
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                vt = LoaiVatTuHHBQ_VT.NewLoaiVatTuHHBQ_VT();
                _loaiVatTuHHBQ_VTList.Insert(0, vt);
                txt_MaQuanLy.Focus();
            }
            catch (Exception ex)
            {
                DialogUtil.ShowWarning(ex.Message);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _loaiVatTuHHBQ_VTList.ApplyEdit();
                bs_LoaiVatTuHH.EndEdit();
                _loaiVatTuHHBQ_VTList.Save();
                MessageBox.Show(this, "Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DialogUtil.ShowWarning("Không thể lưu!\n"+ ex.Message);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void XtraFrm_LoaiVatTuHH_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vt.IsDirty)
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

        private void btn_ExportDataExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.gridView_DSLoaiVatTuHH, showOpenFilePrompt: true);
        }
    }
}
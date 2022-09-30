using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class Frm_Xe : XtraForm
    {
        #region Properties and Methods
        Xe xe;
        XeList _xeList;
        bool themMoi = false;
        int _maXeChon = 0;
        public  int MaXeChon
        {
            get { return _maXeChon; }
        }
        int _maBoPhanDefault = BoPhan.GetBoPhan("DV23").MaBoPhan;
        #endregion //Properties and Methods
        private void loadForm()
        {
            _xeList = XeList.GetXeList();
            XeListBindingSource.DataSource = _xeList;
            BoPhanListbindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            grd_DSXe.DataSource = XeListBindingSource;

            if (XeListBindingSource.Count == 0)
                btnThemMoi.PerformClick();
            else
                xe = (Xe)XeListBindingSource.Current;
        }
        public Frm_Xe()
        {
            InitializeComponent();
            XeListBindingSource.DataSource = typeof(XeList);
            BoPhanListbindingSource.DataSource = typeof(BoPhanList);

        }
        public Frm_Xe(int maBoPhan)
        {
            InitializeComponent();
            XeListBindingSource.DataSource = typeof(XeList);
            BoPhanListbindingSource.DataSource = typeof(BoPhanList);
            _xeList = XeList.GetXeList(maBoPhan);
            XeListBindingSource.DataSource = _xeList;
            _maBoPhanDefault = maBoPhan;
            themMoi = true;
            btnThemMoi.PerformClick();
        }

        private void Frm_Xe_Load(object sender, EventArgs e)
        {
            loadForm();
            Utils.GridUtils.SetSTTForGridView(gridView_DMKho, 35);
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                xe = Xe.NewXe();
                xe.MaBoPhan = _maBoPhanDefault;
                _xeList.Insert(0, xe);
                txt_MaQuanLyXe.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridView_DMKho.DeleteSelectedRows();
            }
            catch
            {
                MessageBox.Show("Nhấn nút Refesh trước khi thực hiện thao tác Xóa");
            }        
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _xeList = XeList.GetXeList();
            XeListBindingSource.DataSource = _xeList;
            grd_DSXe.DataSource = XeListBindingSource;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _xeList.ApplyEdit();
                XeListBindingSource.EndEdit();
                _xeList.Save();

                MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(themMoi)
                {
                    if(_xeList.Count!=0)
                    {
                        xe = XeListBindingSource.Current as Xe;
                        _maXeChon = xe.Id;
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Không thể lưu!\n" + ex.Message);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Frm_Xe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xe.IsDirty)
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
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
    public partial class XtraFrm_KHCapPhatVatTu : DevExpress.XtraEditors.XtraForm
    {
        public XtraFrm_KHCapPhatVatTu()
        {
            InitializeComponent();
            
            LoadForm();
        }

        int _checkDay = 0;
        DateTime _tuNgay;
        DateTime _denNgay;
        int _boPhan = 0;
        string _soKeHoach = "";
        
        KHCapPhatVatTuList _kHCapPhatVatTuList = KHCapPhatVatTuList.NewKHCapPhatVatTuList();
        public void LoadForm()
        {            
            deTuNgay.Enabled = false;
            deDenNgay.Enabled = false;
            deTuNgay.EditValue = DateTime.Today;
            deDenNgay.EditValue = DateTime.Today;
            lueBoPhan.EditValue = null;
            
            _tuNgay = (DateTime)deTuNgay.EditValue;
            _denNgay = (DateTime)deDenNgay.EditValue;

            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();

            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Duyet", typeof(string));
            _dataTable.Rows.Add(1, "Không duyệt");
            _dataTable.Rows.Add(2, "Duyệt");

            lueTinhTrangList.DataSource = _dataTable;
            lueTinhTrangList.ValueMember = "Ma";
            lueTinhTrangList.DisplayMember = "Duyet";
            
        }           
    
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btLuu();
        }

        private void btLuu()
        {
            try
            {
                
                _kHCapPhatVatTuList.ApplyEdit();
                _kHCapPhatVatTuList.Save();

                MessageBox.Show(this, "Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(this, "Không thể lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void barBt_LapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            LoadForm();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result= MessageBox.Show(this, "Bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes: btLuu(); this.Close(); break;
                case DialogResult.No: this.Close(); break;
                case DialogResult.Cancel: break;
            }
            
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
            
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //KHCapPhatVatTu _kH = _kHCapPhatVatTuList.AddNew();
            KHCapPhatVatTu _kH = KHCapPhatVatTu.NewKHCapPhatVatTu();
            _kH.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;            
            XtraFrm_CTKHCapPhatVatTu frm = new XtraFrm_CTKHCapPhatVatTu(_kH);
            frm.ShowDialog();
            if (_kH.MakeHoachCapPhat == 0)
                _kHCapPhatVatTuList = KHCapPhatVatTuList.GetKHCapPhatVatTuList(ERP_Library.Security.CurrentUser.Info.UserID);
           
        }

        private void XtraFrm_KHCapPhatVatTu_Load(object sender, EventArgs e)
        {
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grd_KeHoach, 35);
        }

        
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grd_KeHoach.DeleteSelectedRows();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            KHCapPhatVatTu _kH = (KHCapPhatVatTu)grd_KeHoach.GetFocusedRow();            
            if (_kH != null)
            {
                KHCapPhatVatTu _keHoach = KHCapPhatVatTu.GetKHCapPhatVatTu(_kH.MakeHoachCapPhat);
                XtraFrm_CTKHCapPhatVatTu frm = new XtraFrm_CTKHCapPhatVatTu(_keHoach);
                frm.ShowDialog();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
          
        }

        private void lueBoPhan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lueBoPhan.EditValue =null;
            }
        }

        private void ceNgayLap_CheckedChanged(object sender, EventArgs e)
        {
            deTuNgay.Enabled = (bool)ceNgayLap.EditValue;
            deDenNgay.Enabled = (bool)ceNgayLap.EditValue;
            _checkDay = (bool)ceNgayLap.EditValue ? 1 : 0;
        }

        private void barbt_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            _tuNgay = (DateTime)deTuNgay.EditValue;
            _denNgay = (DateTime)deDenNgay.EditValue;
            if (lueBoPhan.GetSelectedDataRow() == null)
                _boPhan = 0;
            else
                _boPhan = (int)lueBoPhan.EditValue;
            if (txtSoKeHoach.EditValue.ToString().Trim().Length == 0)
                _soKeHoach = "";
            else
                _soKeHoach = txtSoKeHoach.EditValue.ToString().Trim();
            _kHCapPhatVatTuList = KHCapPhatVatTuList.GetKHCapPhatVatTuList(_checkDay, ERP_Library.Security.CurrentUser.Info.UserID, _soKeHoach, _boPhan, _tuNgay, _denNgay);
            if (_kHCapPhatVatTuList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
            kHCapPhatVatTuListBindingSource.DataSource = _kHCapPhatVatTuList;
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
                grd_KeHoach.DeleteSelectedRows();
        }
        
    }
    
}
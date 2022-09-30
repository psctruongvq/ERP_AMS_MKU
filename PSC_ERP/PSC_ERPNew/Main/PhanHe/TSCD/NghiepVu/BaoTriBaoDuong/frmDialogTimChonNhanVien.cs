using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERP_Core;
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERP.Main
{
    public partial class frmDialogTimChonNhanVien : DevExpress.XtraEditors.XtraForm
    {
        //Private Static Field
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        //Private Member fieldxxxxxxxxxxxxxx
        #region Private Member field
        IQueryable<tblnsNhanVien> _nhanVienList = null;
        List<tblnsNhanVien> _nhanVienDuocChonList = null;
        Project _project = null;
        #endregion

        //Public Member field
        #region Public Member field

        #endregion

        //Public Member Property
        #region Public Member Property
        public List<tblnsNhanVien> NhanVienDuocChonList
        {
            get { return _nhanVienDuocChonList; }
        }
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDialogTimChonNhanVien(Project project)
        {
            InitializeComponent();

            //Lấy project hiện tại
            _project = project;
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            _nhanVienList = NhanVien_Factory.New().GetAll();
        
            //Gán bindingSource
            this.GanBindingSource();
        }
        private void GanBindingSource()
        {
            nhanVienBindingSource.DataSource = _nhanVienList;
            //
            gioiTinhBindingSource.DataSource = GioiTinh.GioiTinhList;
        }

        #endregion

        //Event Method
        #region Event Method
        private void frmDialogProjectEmployeeResource_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //Load dữ liệu
                LoadData();

                // Đưa checkbox lên lưới
                PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewNhanVien, colChon);
                
                //Cấu hình lưới
                GridUtil.ConfigGridView1(true, false, false, true, false, grdViewNhanVien);
            };
        }    
        private void btnDuaDuLieuVeTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            txtBlackHole.Focus();
            //lấy những dòng được chọn
            _nhanVienDuocChonList = (from o in _nhanVienList.ToList()
                                   where o.Chon == true
                                   select o).ToList();
   

            //
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }  
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
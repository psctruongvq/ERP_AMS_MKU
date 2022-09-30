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
    public partial class frmDialogChonNhanVien : DevExpress.XtraEditors.XtraForm
    {
        //Private Static Field
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        //Private Member fieldxxxxxxxxxxxxxx
        #region Private Member field
        List<tblnsNhanVien> _nhanVienList = new List<tblnsNhanVien>();
        tblnsNhanVien _nhanVienDaChon = null;
        Project _project = null;
        Boolean _daLoadXong = false;
        #endregion

        //Public Member field
        #region Public Member field

        #endregion

        //Public Member Property
        #region Public Member Property
        public tblnsNhanVien NhanVienDaChon
        {
            get { return _nhanVienDaChon; }
        }
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDialogChonNhanVien(Project project)
        {
            InitializeComponent();

            //Lấy project
            _project = project;
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            {//Lấy danh sách nhân viên như vậy nhằm tái sử dụng về sau
                foreach (ProjectEmployeeResource item in _project.ProjectEmployeeResources)
                {
                    tblnsNhanVien nhanVien = NhanVien_Factory.New().Get_NhanVienTheoMaNhanVien(item.EmployeeID.Value);
                    //
                    _nhanVienList.Add(nhanVien);
                }
            }
            //Gán bindingSource
            this.GanBindingSource();
        }

        private void GanBindingSource()
        {
            nhanVienBindingSource.DataSource = _nhanVienList;
            //
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmDialogChonNhanVien_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //Load dữ liệu
                LoadData();
                //
                _daLoadXong = true;
                //Lấy giá trị mặc định cho combobox
                cbNhanVien.EditValue = _nhanVienList[0].MaNhanVien;         
            };
        }
        private void btnOke_Click(object sender, EventArgs e)
        {
            txtBlackHole.Focus();
            if (_nhanVienDaChon != null)
            {
                //
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }  
        private void btnThoat_Click(object sender, EventArgs e)
        {
            _daLoadXong = false;
            this.Close();
        }   
        private void cbNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                //Lấy nhân viên được chọn
                _nhanVienDaChon = cbNhanVien.GetSelectedDataRow() as tblnsNhanVien;
            }
        }
        #endregion
    }
}
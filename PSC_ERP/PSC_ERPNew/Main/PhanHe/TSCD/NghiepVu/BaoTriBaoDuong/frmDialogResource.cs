using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;

namespace PSC_ERP.Main
{
    public partial class frmDialogResource : XtraForm
    {
        //Private Static Field
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        //Private Member fieldxxxxxxxxxxxxxx
        #region Private Member field
        List<Resource> _resourceList = new List<Resource>();
        #endregion

        //Public Member Property
        #region Public Member Property
        public List<Resource> ResourceList
        {
            get { return _resourceList; }
        }
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDialogResource()
        {
            InitializeComponent();
        }
        public frmDialogResource(List<Resource> resourceList)
        {
            InitializeComponent();
            //
            _resourceList = resourceList;
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void AddRootNode()
        {
            //
            Resource resourceNew = Resource_Factory.New().CreateAloneObject();
            resourceNew.ID = Guid.Empty;
            resourceNew.Description = "*";         
            //
            _resourceList.Add(resourceNew);         
        }
        private void GanBindingSource()
        {
            
            //
            resourceBindingSource.DataSource = _resourceList;
            //
        }
        private Boolean KiemTraHopLe()
        {
            bool duocPhepLuu = true;
            //
            foreach (Resource item in _resourceList)
            {
                if (string.IsNullOrEmpty(item.Description))
                {
                    DialogUtil.ShowWarning("Nhập tên!");
                    return duocPhepLuu = false;
                }
            }
            return duocPhepLuu;
        }
        private void Them()
        {
            //Lấy resource hiện tại
            Resource currentResource = resourceBindingSource.Current as Resource;

            Resource resourceNew = Resource_Factory.New().CreateAloneObject();
            resourceNew.ID = Guid.NewGuid();
            resourceNew.ParentID = currentResource.ID;
            //
            _resourceList.Add(resourceNew);

            //Set cây
            SetTreeList();
        }
        private void DeleteChildResourceAll(Guid id)
        {
            List<Resource> deleteList = (from o in _resourceList where o.ParentID == id select o).ToList();

            foreach (Resource item in deleteList)
            {
                //Gọi đệ qui
                DeleteChildResourceAll(item.ID);
                //
                _resourceList.Remove(item);
                //
                SetTreeList();
            }
        }
        private void SetTreeList()
        {
            TreeList_Resource.RefreshDataSource();
            TreeList_Resource.ExpandAll();
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmDialogResource_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //Load node root
                AddRootNode();

                //Nếu resource là có parentid là null thì set lại bằng Gui.Empty để tất cả đều là con của root
                foreach (Resource item in _resourceList)
                {
                    if (item.ParentID == null)
                        item.ParentID = Guid.Empty;
                }

                //Gán bindingSource
                this.GanBindingSource();

                //Set cây
                TreeList_Resource.ExpandAll();
            };
        }
        private void btnDuaDuLieuVe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //
            txtBlackHole.Focus();
            //
            if (KiemTraHopLe())
            {
                //
                this.DialogResult = DialogResult.Yes;
                //
                this.Close();
            }
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Lấy resource hiện tại
            Resource currentResource = resourceBindingSource.Current as Resource;
            if (currentResource.ID == Guid.Empty)
                return;
            if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn có chắc muốn xóa resource [" + currentResource.Description + "] và các resource con?"))
            {
                using (DialogUtil.WaitForDelete())
                {
                    //Xóa các 
                    DeleteChildResourceAll(currentResource.ID);
                    //Xóa resource hiện tại
                    _resourceList.Remove(currentResource);
                    //
                    SetTreeList();
                }
            }
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Thêm resource mới
            Them();
        }
        #endregion

    }
}
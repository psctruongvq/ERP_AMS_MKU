using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP_Digitizing.Client.UI
{
    public partial class frmDigitizingBag : DevExpress.XtraEditors.XtraForm
    {
        //Boolean _taoMoiBag = true;
        Boolean _daLoadFormXong = false;
        Guid? _bagIdForReload;
        private DigitizingBag _bag = null;
        private DigitizingBag_Factory _factory = null;
        public frmDigitizingBag()
        {
            InitializeComponent();
            _bagIdForReload = null;
            //_taoMoiBag = true;
        }
        public frmDigitizingBag(DigitizingBag obj)
        {
            InitializeComponent();
            //_taoMoiBag = false;
        }
        private void frmDigitizingBag_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            this.Shown += (object senderz, EventArgs ez) =>
            {
                using (DialogUtil.Wait(this))
                {
                    //thiet lap
                    
                        this.XuLyBag(_bagIdForReload);

                }
            };
        }

        private void XuLyBag(Guid? bagIdForReload)
        {
            _daLoadFormXong = false;
            #region Body

            _factory = DigitizingBag_Factory.New();
            if (bagIdForReload == null)
                _bag = _factory.CreateManagedObject();
            else
                _bag = _factory.GetById(bagIdForReload.Value);

            digitizingBagBindingSource.DataSource = new List<DigitizingBag> { _bag };
            //digitizingBagBindingSource.MoveFirst();
            digitizingFileBindingSource.DataSource = _bag.DigitizingFiles;
            #endregion
            _daLoadFormXong = true;
        }

        private Boolean Save()
        {
            this.txtBlackHole.Focus();
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

    }
}

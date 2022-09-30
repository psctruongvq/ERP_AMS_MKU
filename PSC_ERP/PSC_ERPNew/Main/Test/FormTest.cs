using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC_ERP_Business;
using PSC_ERP_Util;
using mdl = PSC_ERP_Business.Main.Model;
using fac = PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
namespace PSC_ERPNew
{
    public partial class FormTest : Form
    {
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        fac.Function_Factory _factory = new fac.Function_Factory();
        public FormTest()
        {
            //TracingLog.Debug("FormTest");
            PSC_ERP_Global.Main.UserID = 1;//gan user id
            //Log.Info("dfhgjhgjhg", 1);
            InitializeComponent();

            //testAFactory.DeleteAll();
            //fac.FunctionFactory factory = new fac.FunctionFactory();
            //factory.Test();

            //Function fn1 = factory.GetFunctionById(1);

            //fn.FunctionName = "new function1";
            //factory.Add(fn);

            functionBindingSource.DataSource = _factory.GetAll();
            //Function fn = new Function();

            //fn.FunctionName = "new function";

            //PSC_ERP.Entity.Model.Menu menu = new Entity.Model.Menu() { Title = "hi hi he he" };

            //fn.Menus.Add(menu);
            //factory.AddObject(fn);
            //factory.SaveChanges();

            //PSC_ERP.Entity.Model.Menu mn = new PSC_ERP.Entity.Model.Menu();
            //mn.Title = "test1";

            //fn.Menus.Add(mn);

            //functionBindingSource.Add(fn);
            //if(fn.CheckChildListDirty())
            //    MessageBox.Show("ChildListDirty");
            //factory.Save();
            //functionBindingSource.DataSource = factory.GetDanhSachFunction();

            GridUtil.InitDetailForGridView<mdl.AppFunction>(this.gridView1, AppFunction.AppMenus_EntityCollectionPropertyName, 0, 1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _factory.SaveChangesWithoutTrackingLog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.gridView1.DeleteSelectedRows();
        }


    }
}

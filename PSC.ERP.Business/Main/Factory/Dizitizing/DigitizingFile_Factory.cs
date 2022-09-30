using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Core;
using System.Reflection;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Objects;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main;
using PSC_ERP_Util.DateTimeExtension;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class DigitizingFile_Factory : BaseFactory<Entities, DigitizingFile>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return DigitizingFile_Factory.New().CreateAloneObject();
        }
        public static DigitizingFile_Factory New()
        {
            return new DigitizingFile_Factory();
        }
        public DigitizingFile_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public DigitizingFile GetById(Guid id)
        {
            DigitizingFile obj = this.ObjectSet.SingleOrDefault(o => o.FileId == id);
            return obj;
        }
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //duyệt qua danh sách
            foreach (DigitizingFile item in deleteList)
            {
                //xóa
                context.DigitizingFiles.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}

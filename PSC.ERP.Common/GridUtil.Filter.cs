using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
namespace PSC_ERP_Common
{
    public partial class GridUtil
    {

        public static List<T> GetFilteredData<T>(ColumnView view)//(GridView view)
        {
            List<T> resp = new List<T>();
            int currentRowHandle = view.GetVisibleRowHandle(0);
            while (currentRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                resp.Add((T)view.GetRow(currentRowHandle));
                currentRowHandle = view.GetNextVisibleRow(currentRowHandle);
            }
            return resp;
        }
        
    }
}

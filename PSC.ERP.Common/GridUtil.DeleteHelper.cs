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

namespace PSC_ERP_Common
{
    public partial class GridUtil
    {
        public class DeleteHelper
        {
            Boolean _manual = false; 
            //public delegate void DeleteListDelegate(GridView gridView, params Object[] deleteList);
            public delegate void DeleteListDelegate(GridView gridView, List<Object> deleteList);
           
            private event DeleteListDelegate Deleting = null;

            public static DeleteHelper Setup_ManualType(GridView gridView, DeleteListDelegate performEvent = null)
            {
                DeleteHelper obj = new DeleteHelper(gridView: gridView, manual: true);

                obj.Deleting = performEvent;
                return obj;
            }
            public static DeleteHelper Setup_AutoType(GridView gridView)
            {
                DeleteHelper obj = new DeleteHelper(gridView: gridView, manual: false);
                return obj;
            }

            public DeleteHelper(GridView gridView, Boolean manual)
            {
                _manual = manual;
                gridView.KeyDown -= GridView_KeyDown;
                gridView.KeyDown += GridView_KeyDown;
            }
            //void GridView_KeyDown(object sender, KeyEventArgs e)
            //{

            //    GridView gridView = sender as GridView;
            //    if (e.KeyCode == Keys.Delete)
            //    {

            //        if (gridView.SelectedRowsCount > 0)
            //        {
            //            if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn có muốn xóa trên lưới những dòng đang chọn?"))
            //            {
            //                if (_manual)//xóa thủ công
            //                {
            //                    Int32[] rowHandleList = gridView.GetSelectedRows();
            //                    if (rowHandleList.Count() > 0)
            //                    {
            //                        //List<Object> deleteList = new List<Object>();
            //                        Object[] deleteList = new Object[rowHandleList.Count()];
            //                        Int32 i = 0;
            //                        foreach (var index in rowHandleList)
            //                        {
            //                            //deleteList.Add(gridView.GetRow(index));
            //                            deleteList[i++] = gridView.GetRow(index);
            //                        }
            //                        if (Deleting != null)
            //                        {
            //                            Deleting(gridView, deleteList);
            //                        }
            //                    }
            //                }
            //                else//xóa bằng control
            //                    gridView.DeleteSelectedRows();
            //            }
            //        }
            //        else
            //        {
            //            DialogUtil.ShowInfo("Vui lòng chọn dòng cần xóa");
            //        }
            //    }
            //}//end F
            void GridView_KeyDown(object sender, KeyEventArgs e)
            {

                GridView gridView = sender as GridView;
                if (e.KeyCode == Keys.Delete)
                {

                    if (gridView.SelectedRowsCount > 0)
                    {
                        if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn có muốn xóa trên lưới những dòng đang chọn?"))
                        {
                            if (_manual)//xóa thủ công
                            {
                                Int32[] rowHandleList = gridView.GetSelectedRows();
                                if (rowHandleList.Count() > 0)
                                {
                                    List<Object> deleteList = new List<Object>();
                                    foreach (var index in rowHandleList)
                                    {
                                        deleteList.Add(gridView.GetRow(index));
                                    }
                                    if (Deleting != null)
                                    {
                                        Deleting(gridView, deleteList);
                                    }
                                }
                            }
                            else//xóa bằng control
                                gridView.DeleteSelectedRows();
                        }
                    }
                    else
                    {
                        DialogUtil.ShowInfo("Vui lòng chọn dòng cần xóa");
                    }
                }
            }






        }
    }
}

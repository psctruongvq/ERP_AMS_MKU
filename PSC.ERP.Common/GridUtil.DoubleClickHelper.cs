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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace PSC_ERP_Common
{
    public partial class GridUtil
    {
        public class DoubleClickHelper
        {

            GridView _gridView = null;
            BaseEdit _inplaceEditor;
            public event EventHandler DoubleClick = null;

            public static DoubleClickHelper Setup(GridView gridView, EventHandler performEvent = null)
            {
                DoubleClickHelper obj = new DoubleClickHelper(gridView);
                obj.DoubleClick = performEvent;

                return obj;
            }
            public DoubleClickHelper(GridView gridView)
            {
                _gridView = gridView;
                _gridView.DoubleClick -= _gridView_DoubleClick;
                _gridView.DoubleClick += _gridView_DoubleClick;
                //
                _gridView.ShownEditor -= _gridView_ShownEditor;
                _gridView.ShownEditor += _gridView_ShownEditor;
                //
                _gridView.HiddenEditor -= _gridView_HiddenEditor;
                _gridView.HiddenEditor += _gridView_HiddenEditor;
            }



            void _gridView_DoubleClick(object sender, EventArgs e)
            {
                GridView view = sender as GridView;
                if ((sender as BaseEdit) != null)//trường hợp inplaceEditor double click
                {
                    BaseEdit editor = (BaseEdit)sender;

                    GridControl grid = (GridControl)editor.Parent;

                    Point pt = grid.PointToClient(Control.MousePosition);

                    view = (GridView)grid.FocusedView;
                }
                PerformEvent(view, e);
            }

            private void PerformEvent(object sender, EventArgs e)
            {
                if (DoubleClick != null)
                {
                    GridView view = sender as GridView;
                    Point pt = view.GridControl.PointToClient(Control.MousePosition);
                    GridHitInfo info = view.CalcHitInfo(pt);

                    if (info.InRow || info.InRowCell)
                    {

                        DoubleClick(sender, e);

                    }


                }
            }
            void _gridView_HiddenEditor(object sender, EventArgs e)
            {
                if (_inplaceEditor != null)
                {
                    _inplaceEditor.DoubleClick -= _gridView_DoubleClick;
                    //_inplaceEditor.DoubleClick -= inplaceEditor_DoubleClick;

                    _inplaceEditor = null;

                }
            }
            void _gridView_ShownEditor(object sender, EventArgs e)
            {
                _inplaceEditor = ((GridView)sender).ActiveEditor;
                _inplaceEditor.DoubleClick += _gridView_DoubleClick;
                //_inplaceEditor.DoubleClick += inplaceEditor_DoubleClick;
            }

            //void inplaceEditor_DoubleClick(object sender, EventArgs e)
            //{

            //    BaseEdit editor = (BaseEdit)sender;

            //    GridControl grid = (GridControl)editor.Parent;

            //    Point pt = grid.PointToClient(Control.MousePosition);

            //    GridView view = (GridView)grid.FocusedView;

            //    PerformEvent(view, e);

            //}
        }
    }
}

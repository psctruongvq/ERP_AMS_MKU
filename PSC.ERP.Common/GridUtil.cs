using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
//using PSC_ERP.DataAccess.Model;
using System.Windows.Forms;
using System.Reflection;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.Metadata.Edm;

namespace PSC_ERP_Common
{
    public partial class GridUtil
    {

        private delegate void VoidDelegate(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e);



        
        public static void ConfigGridView1(bool setSTT, bool initCopyCell, bool multiSelectCell, bool multiSelectRow, bool initNewRowOnTop, params GridView[] gridViews)
        {//Cuong

            //
            if (setSTT) SetSTTForGridView(gridViews);
            //
            if (initCopyCell) InitCopyCellForGridView(gridViews);
            //
            if (multiSelectCell)
            {
                InitMultiCellSelectForGridView(gridViews);
            }
            else if (multiSelectRow)
            {
                InitMultiRowSelectForGridView(gridViews);
            }
            //
            if (initNewRowOnTop) InitNewRowOnTopOfGridView1(gridViews);
            //
        }

       
        public static void InitNewRowOnTopOfGridView1(params GridView[] gridViews)
        {//Cuong
            foreach (var gridView in gridViews)
            {
                gridView.NewItemRowText = @"<<Thêm dòng mới>>";
                gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                //gridView.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(InitNewRowOnTopOfGridView_Helper);
                //gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(InitNewRowOnTopOfGridView_Helper);
            }


        }

        private static bool NeedCopyHeaders(GridView gridView)
        {//cuong
            return gridView.SelectedRowsCount > 1;
        }

        public static void ConfigGridView(GridView gridView, bool setSTT, bool initCopyCell, bool multiSelectCell, bool multiSelectRow, bool initNewRowOnTop)
        {//Cuong
            //
            if (setSTT) SetSTTForGridView(gridView);
            //
            if (initCopyCell) InitCopyCellForGridView(gridView);
            //
            if (multiSelectCell)
            {
                InitMultiCellSelectForGridView(gridView);
            }
            else if (multiSelectRow)
            {
                InitMultiRowSelectForGridView(gridView);
            }
            //
            if (initNewRowOnTop) InitNewRowOnTopOfGridView(gridView);
            //
        }

        public static void InitNewRowOnTopOfGridView(GridView gridView)
        {//Cuong
            gridView.NewItemRowText = @"<<Thêm dòng mới>>";
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            //gridView.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(InitNewRowOnTopOfGridView_Helper);
            //gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(InitNewRowOnTopOfGridView_Helper);

        }

        public static void InitNewRowOnBottomOfGridView(GridView gridView)
        {//Cuong
            gridView.NewItemRowText = @"<<Thêm dòng mới>>";
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            //gridView.CellValueChanged -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(InitNewRowOnTopOfGridView_Helper);
            //gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(InitNewRowOnTopOfGridView_Helper);

        }

        static void InitNewRowOnTopOfGridView_Helper(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {//Cuong

            System.Threading.Thread thr = new System.Threading.Thread(() =>
            {
                DevExpress.XtraGrid.GridControl ct = (sender as GridView).GridControl;

                if (ct.InvokeRequired)
                {
                    VoidDelegate dele = new VoidDelegate(InitNewRowOnTopOfGridView_Helper1);
                    ct.Invoke(dele, sender, e);

                }
                else
                {
                    InitNewRowOnTopOfGridView_Helper1(sender, e);
                }
            }
            );

            thr.Start();
        }

        private static void InitNewRowOnTopOfGridView_Helper1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {//Cuong
            if (e.RowHandle < 0)
            {
                try
                {
                    GridView gridView = sender as GridView;
                    DevExpress.XtraGrid.GridControl gridControl = gridView.GridControl;
                    Object newItem;

                    gridView.RefreshData();//cap nhat lai du lieu rat quan trong
                    gridView.MoveLast();
                    newItem = ((BindingSource)gridControl.DataSource).Current;
                    if (((BindingSource)gridControl.DataSource).Count > 1)
                    {
                        gridView.DeleteRow(gridView.RowCount - 1);
                        dynamic objectList = gridControl.DataSource;
                        objectList.Insert(0, newItem);
                        //gridView.RefreshData();
                        gridView.MoveFirst();
                    }
                }
                catch (System.Exception ex)
                {

                }

            }
        }


        /// ////////////////////////////////////////////////////////////////////////////

        /// /////////////////////////////////////////////////

        public static void HideGroupPanel(GridView gridView)
        {
            gridView.OptionsView.ShowGroupPanel = false;
        }
        public static void ShowGroupPanel(GridView gridView)
        {
            gridView.OptionsView.ShowGroupPanel = true;
        }
        ////////////////

        /// //////////////////////////////////////////////////////////

        public static void InitDetailForGridView<ParentType, ChildType>(GridView gridView, ObjectContext context, Int32 childIndex, Int32 totalRelationCount = 1)
            where ParentType : EntityObject
            where ChildType : EntityObject
        {
            String entitySetName = GetEntitySetName_Helper<ChildType>(context);
            InitDetailForGridView<ParentType>(gridView, entitySetName, childIndex, totalRelationCount);

        }
        //
        //
        private static string GetEntitySetName_Helper<TEntity>(ObjectContext context) where TEntity : EntityObject
        {
            Type entityType = typeof(TEntity);
            string entityTypeName = entityType.Name;
            var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
            string entitySetName = (from meta in container.BaseEntitySets
                                    where meta.ElementType.Name == entityTypeName
                                    select meta.Name).First();

            return entitySetName;
        }
        //
        public static void InitDetailForGridView<ParentType>(GridView gridView, String relationNameOrChildCollectionName, Int32 childIndex, Int32 totalRelationCount = 1) where ParentType : EntityObject
        {

            gridView.MasterRowEmpty += (object sender, MasterRowEmptyEventArgs e) =>
            {
                ParentType o = (ParentType)gridView.GetRow(e.RowHandle);

                Type type = typeof(ParentType);
                PropertyInfo childInfo = type.GetProperty(relationNameOrChildCollectionName, BindingFlags.Public | BindingFlags.Instance);

                dynamic childCollection = childInfo.GetValue(o, null);

                e.IsEmpty = childCollection.Count == 0;
            };
            gridView.MasterRowGetRelationCount += (object sender, MasterRowGetRelationCountEventArgs e) =>
            {
                e.RelationCount = totalRelationCount;//totalRelationCount;//1;
            };
            gridView.MasterRowGetRelationName += (object sender, MasterRowGetRelationNameEventArgs e) =>
            {
                if (e.RelationIndex == childIndex)
                {
                    e.RelationName = relationNameOrChildCollectionName;
                }

            };
            gridView.MasterRowGetChildList += (object sender, MasterRowGetChildListEventArgs e) =>
            {
                if (e.RelationIndex == childIndex)
                {
                    ParentType master = (ParentType)gridView.GetRow(e.RowHandle);
                    e.ChildList = new BindingSource(master, relationNameOrChildCollectionName);
                }
            };
        }

        //






    }
}

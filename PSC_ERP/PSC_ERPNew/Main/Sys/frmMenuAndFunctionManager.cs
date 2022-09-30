/*Công dụng:
*
*
*
*Người tạo: 
*Ngày tạo:
*Ngày cập nhât:
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
//using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
//using DevExpress.XtraBars;
using System.Linq;
using DevExpress.XtraEditors;
using mdl = PSC_ERP_Business.Main.Model;
using System.Reflection;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
namespace PSC_ERPNew.Main.Sys
{
    public partial class frmMenuAndFunctionManager : XtraForm
    {
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        GridHitInfo _downHitInfo = null;
        List<mdl.AppMenu> _menuThemMoiList = new List<mdl.AppMenu>();
        Boolean _loadXong = false;
        Menu_Factory _factory = Menu_Factory.New();//Database.NewEntities();
        //Singleton
        #region Singleton
        private static frmMenuAndFunctionManager singleton_ = null;
        public static frmMenuAndFunctionManager Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmMenuAndFunctionManager();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        #endregion

        //Member Constructor
        #region Member Constructor
        //IDbTransaction _tran = null;
        public frmMenuAndFunctionManager()
        {
            InitializeComponent();
        }

        private static void FillType(DataTable tbl, Type[] typeList2)
        {
            foreach (System.Type t in typeList2)
            {

                if (t.BaseType == typeof(DevExpress.XtraEditors.XtraForm) || t.BaseType == typeof(Form)
                    || t.BaseType.BaseType == typeof(Form)
                    //|| t.BaseType.BaseType.BaseType == typeof(Form)
                    //|| t.BaseType.BaseType.BaseType.BaseType == typeof(Form)
                    //|| t.BaseType.BaseType.BaseType.BaseType.BaseType == typeof(Form)
                    ) //trường hợp nếu kế thừa từ 1 form cấu trúc cũng hợp lệ
                {
                    tbl.Rows.Add(t.Name, t.FullName, t.BaseType.ToString(), t.Module.ToString());
                }
            }
        }

        #endregion

        //Private Member Function
        #region Private Member Function

        //private void menuPicture_DoubleClick(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFile = new OpenFileDialog();
        //    openFile.Filter = "All image|*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|All file|*.*";
        //    Model.Menu menu = (Model.Menu)menuBindingSource.Current;
        //    if (menu != null && openFile.ShowDialog(this) == DialogResult.OK)
        //    {
        //        Image img = Image.FromFile(openFile.FileName);
        //        this.menuPicture.Image = img;
        //        System.IO.MemoryStream m = new System.IO.MemoryStream();
        //        img.Save(m, img.RawFormat);
        //        menu.Image = m.GetBuffer();
        //        m.Close();
        //    }
        //}

        #region Event
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            try
            {
                //if (_tran != null)
                {
                    _factory.SaveChangesWithoutTrackingLog();
                    //_factory.SaveChanges(BusinessCodeEnum.TSCD_MenuAndFunctionManager.ToString());
                    //_tran.Commit();
                    //_tran.Dispose();
                    //_tran = null;

                    //BeginTransaction();
                }
                DialogUtil.ShowSaveSuccessful();
            }
            catch (System.Exception ex)
            {
                DialogUtil.ShowNotSaveSuccessful();
            }
        }

        private void functionPicture_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All image|*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|All file|*.*";
            mdl.AppFunction fn = (mdl.AppFunction)AppFunctionBindingSource.Current;
            if (fn != null && openFile.ShowDialog(this) == DialogResult.OK)
            {
                Image img = Image.FromFile(openFile.FileName);
                this.functionPicture.Image = img;
                System.IO.MemoryStream m = new System.IO.MemoryStream();
                img.Save(m, img.RawFormat);
                fn.Image = m.GetBuffer();
                m.Close();
            }
        }
        private void treeMenu_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            try
            {
                if (_loadXong)
                {
                    e.Node.Expanded = true;//bung node ra
                    //mdl.AppMenu menu = (mdl.AppMenu)AppMenuBindingSource.Current;
                    //for (int i = 0; i < gridViewFunction.RowCount; i++)
                    //{
                    //    mdl.AppFunction function = (mdl.AppFunction)gridViewFunction.GetRow(i);
                    //    if (menu.FunctionID == function.FunctionID)
                    //    {
                    //        if (i != 0)
                    //            gridViewFunction.MoveBy(i);
                    //        else
                    //            gridViewFunction.MoveFirst();

                    //        break;
                    //    }
                    //}
                }
            }
            catch (System.Exception ex)
            {

            }

        }
        private void btnXoaMenu_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn xóa menu", "Hỏi ý kiến", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                mdl.AppMenu menu = treeMenu.GetDataRecordByNode(treeMenu.FocusedNode) as mdl.AppMenu;
                Menu_Factory.FullDelete(_factory.Context, new List<object> { menu });
                treeMenu.DeleteSelectedNodes();
            }
        }
        private void btnThemBarButtonGroup_Click(object sender, EventArgs e)
        {
            Them("BarButtonGroup", (mdl.AppMenu)AppMenuBindingSource.Current);
        }
        private void btnThemBarSubItem_Click(object sender, EventArgs e)
        {
            Them("BarSubItem", (mdl.AppMenu)AppMenuBindingSource.Current);
        }
        private void btnThemRibbonPageGroup_Click(object sender, EventArgs e)
        {
            Them("RibbonPageGroup", (mdl.AppMenu)AppMenuBindingSource.Current);
        }
        private void btnThemRibbonPageCategory_Click(object sender, EventArgs e)
        {
            Them("RibbonPageCategory", (mdl.AppMenu)AppMenuBindingSource.Current);
        }
        private void btnThemRibbonPage_Click(object sender, EventArgs e)
        {
            Them("RibbonPage", (mdl.AppMenu)AppMenuBindingSource.Current);
        }
        private void btnThemRibbon_Click(object sender, EventArgs e)
        {
            Them("Ribbon", (mdl.AppMenu)AppMenuBindingSource.Current);
        }
        private void btnThemPhanHe_Click(object sender, EventArgs e)
        {
            Them("PhanHe", parentMenu: (mdl.AppMenu)AppMenuBindingSource.Current);
        }
        private void cmsMenu_Opening(object sender, CancelEventArgs e)
        {
            //an tat ca cac btnThem...
            foreach (ToolStripItem item in this.btnThemMenu.DropDownItems)
            {
                item.Visible = false;
            }

            mdl.AppMenu parentMenu = (mdl.AppMenu)AppMenuBindingSource.Current;
            switch (parentMenu.Type)
            {

                case "Root":
                    btnThemPhanHe.Visible = true;
                    break;
                case "PhanHe":
                    btnThemRibbon.Visible = true;
                    break;
                case "Ribbon":
                    {
                        btnThemRibbonPageCategory.Visible = true;
                        btnThemRibbonPage.Visible = true;
                    }
                    break;
                case "RibbonPageCategory":
                    btnThemRibbonPage.Visible = true;
                    break;
                case "RibbonPage":
                    btnThemRibbonPageGroup.Visible = true;
                    break;
                case "RibbonPageGroup":
                    {
                        btnThemBarSubItem.Visible = true;
                        btnThemBarButtonGroup.Visible = true;
                    }
                    break;
                case "BarButtonGroup":
                case "BarSubItem":
                    {
                        btnThemBarSubItem.Visible = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void gridCtrlFunction_Enter(object sender, EventArgs e)
        {
            //ribbonControl1.SelectedPage = ribbonPage_Function;
        }
        private void gridViewFunction_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            _downHitInfo = null;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
                _downHitInfo = hitInfo;
        }

        private void gridViewFunction_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && _downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect =
                          new Rectangle(new Point(_downHitInfo.HitPoint.X -
                                                  dragSize.Width / 2,
            _downHitInfo.HitPoint.Y -
            dragSize.Height / 2),
            dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    mdl.AppFunction fn = (mdl.AppFunction)AppFunctionBindingSource.Current;
                    view.GridControl.DoDragDrop(fn, DragDropEffects.Move);
                    _downHitInfo = null;

                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }
        private void treeMenu_DragOver(object sender, DragEventArgs e)
        {
            TreeList tree = sender as TreeList;
            Point p = tree.PointToClient(new Point(e.X, e.Y));
            TreeListHitInfo hitInfo = tree.CalcHitInfo(p);
            tree.FocusedNode = hitInfo.Node;

            if (e.Data.GetDataPresent(typeof(mdl.AppFunction)))
                e.Effect = DragDropEffects.Move;
            else if (e.Data.GetDataPresent(typeof(TreeListNode)))
            {

                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void treeMenu_Enter(object sender, EventArgs e)
        {
            //ribbonControl1.SelectedPage = ribbonPage1;
        }
        private void treeMenu_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{

            //}
        }
        private void treeMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void treeMenu_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            //if (Convert.ToBoolean(e.Node["Check"]))
            //    e.NodeImageIndex = 0;
            //else
            //    e.NodeImageIndex = 1;

            String type = Convert.ToString(e.Node["Type"]);
            switch (type)
            {
                case "Root":
                    e.NodeImageIndex = 1;
                    break;
                case "PhanHe":
                    e.NodeImageIndex = 2;
                    break;
                case "Ribbon":
                    e.NodeImageIndex = 3;
                    break;
                case "RibbonPageCategory":
                    e.NodeImageIndex = 4;
                    break;
                case "RibbonPage":
                    e.NodeImageIndex = 5;
                    break;
                case "RibbonPageGroup":
                    e.NodeImageIndex = 6;
                    break;
                case "BarButtonGroup":
                    e.NodeImageIndex = 7;
                    break;
                case "BarSubItem":
                    e.NodeImageIndex = 8;
                    break;
                case "BarButtonItem":
                    e.NodeImageIndex = 9;
                    break;

                default:
                    e.NodeImageIndex = 0;
                    break;
            }

        }

        private void treeMenu_DragDrop(object sender, DragEventArgs e)
        {
            TreeList tree = sender as TreeList;
            ////
            Point p = tree.PointToClient(new Point(e.X, e.Y));
            TreeListHitInfo hitInfo = tree.CalcHitInfo(p);
            //
            if (e.Data.GetDataPresent(typeof(mdl.AppFunction)))//drag tu function
            {
                if (hitInfo.HitInfoType == HitInfoType.StateImage
                    || hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    mdl.AppFunction fn = e.Data.GetData(typeof(mdl.AppFunction)) as mdl.AppFunction;
                    mdl.AppMenu parentMenu = tree.GetDataRecordByNode(hitInfo.Node) as mdl.AppMenu;
                    if (parentMenu != null && (parentMenu.Type == "RibbonPageGroup"
                        || parentMenu.Type == "BarButtonGroup"
                        || parentMenu.Type == "BarSubItem"))
                    {
                        Them("BarButtonItem", parentMenu, fn);
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm BarButtonItem vào " + parentMenu.Type);
                    }

                }
            }
            else if (e.Data.GetDataPresent(typeof(TreeListNode)))//drag menu
            {
                TreeListNode node = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;

                mdl.AppMenu dragMenu = tree.GetDataRecordByNode(node) as mdl.AppMenu;
                mdl.AppMenu destinationMenu = tree.GetDataRecordByNode(hitInfo.Node) as mdl.AppMenu;
                if (destinationMenu != null)
                    ////if (dragMenu.Type == destinationMenu.Type
                    ////    && dragMenu.ParentID == destinationMenu.ParentID)
                    ////{
                    ////    //sort
                    ////    MessageBox.Show("Test");
                    ////}
                    ////else
                    CheckMenu(dragMenu, destinationMenu, e);
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void treeMenu_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("treeMenu_MouseUp");
        }

        private void treeMenu_MouseDown(object sender, MouseEventArgs e)
        {
            //TreeList tree = sender as TreeList;
            //Point p = tree.PointToClient(new Point(e.X, e.Y));
            //TreeListHitInfo hi = tree.CalcHitInfo(p);
            //DevExpress.XtraTreeList.Nodes.TreeListNode node = hi.Node;
            //if (node != null)
            //{

            //    if (Control.ModifierKeys == Keys.Control && tree.Selection.Count > 0 && tree.Selection.Contains(node))
            //        return;
            //}
        }

        private void txtFilterTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                TextEdit txt = sender as TextEdit;
                if (String.IsNullOrWhiteSpace(txt.Text))
                {
                    this.treeMenu.DataSource = null;
                    this.treeMenu.DataSource = this.AppMenuBindingSource;
                }
                else
                    PSC_ERP_Common.TreeUtils.FilterTreeNode(treeMenu, txt.Text);
            }
        }

        private void btnMoveUpMenu_Click(object sender, EventArgs e)
        {
            ChangeNodeIndex(-1);
        }

        private void btnMoveDownMenu_Click(object sender, EventArgs e)
        {
            ChangeNodeIndex(1);
        }

        #endregion

        private void Them(String insertType, mdl.AppMenu parentMenu, mdl.AppFunction fn = null)
        {
            mdl.AppMenu newMenu = null;
            switch (insertType)
            {
                case "PhanHe":
                    {
                        String tenPhanHe = "";
                        while (String.IsNullOrWhiteSpace(tenPhanHe))
                            tenPhanHe = Microsoft.VisualBasic.Interaction.InputBox("Hãy nhập tên phân hệ. Ví dụ: Tài sản cố định", "Tên phân hệ", "", Screen.PrimaryScreen.WorkingArea.Width / 2 - 150, Screen.PrimaryScreen.WorkingArea.Height / 2 - 150);

                        String maPhanHe = "";
                        while (String.IsNullOrWhiteSpace(maPhanHe))
                            maPhanHe = Microsoft.VisualBasic.Interaction.InputBox("Hãy nhập mã phân hệ. Ví dụ: TSCD", "Mã phân hệ", "", Screen.PrimaryScreen.WorkingArea.Width / 2 - 150, Screen.PrimaryScreen.WorkingArea.Height / 2 - 150);
                        newMenu = new mdl.AppMenu() { Title = tenPhanHe, Type = "PhanHe", MaPhanHeQL = maPhanHe };
                    }
                    break;
                case "Ribbon":
                    newMenu = new mdl.AppMenu() { Title = "New Ribbon", Type = "Ribbon", MaPhanHeQL = parentMenu.MaPhanHeQL };
                    break;
                case "RibbonPageCategory":
                    newMenu = new mdl.AppMenu() { Title = "New RibbonPageCategory", Type = "RibbonPageCategory", MaPhanHeQL = parentMenu.MaPhanHeQL };
                    break;
                case "RibbonPage":
                    newMenu = new mdl.AppMenu() { Title = "New RibbonPage", Type = "RibbonPage", MaPhanHeQL = parentMenu.MaPhanHeQL };
                    break;
                case "RibbonPageGroup":
                    newMenu = new mdl.AppMenu() { Title = "New RibbonPageGroup", Type = "RibbonPageGroup", MaPhanHeQL = parentMenu.MaPhanHeQL };
                    break;
                case "BarButtonGroup":
                    newMenu = new mdl.AppMenu() { Title = "New BarButtonGroup", Type = "BarButtonGroup", MaPhanHeQL = parentMenu.MaPhanHeQL };
                    break;
                case "BarButtonItem":
                    if (fn != null)
                        newMenu = new mdl.AppMenu() { FunctionID = fn.FunctionID, Title = fn.FunctionName, Type = "BarButtonItem", MaPhanHeQL = parentMenu.MaPhanHeQL };
                    break;
                case "BarSubItem":
                    newMenu = new mdl.AppMenu() { Title = "New BarSubItem", Type = "BarSubItem", MaPhanHeQL = parentMenu.MaPhanHeQL };
                    break;
                default:
                    break;
            }
            if (newMenu != null)
            {
                //xu ly phat sinh ma moi
                {
                    mdl.AppMenu menuLonNhat = _factory.Get_AppMenu_CoIDLonNhat();

                    if (menuLonNhat == null)
                        newMenu.ID = 1;
                    else if (_menuThemMoiList.Count() != 0 || menuLonNhat != null)
                    {

                        foreach (var ky in _menuThemMoiList)
                        {
                            if (ky.ID > menuLonNhat.ID)
                                menuLonNhat = ky;
                        }
                        newMenu.ID = menuLonNhat.ID + 1;
                    }
                    _menuThemMoiList.Add(newMenu);
                }
                //
                newMenu.ParentID = parentMenu.ID;
                AppMenuBindingSource.Add(newMenu);//khong add truc tiep vao list, ma phai add thong qua binding
                this.treeMenu.FocusedNode = this.treeMenu.FocusedNode.LastNode;//focus den noi cuoi cung
                //dua node len tren cung
                while (ChangeNodeIndex(-1) != 0)
                {
                }
                //_factory.SaveChanges();
                //ChangeMenuIdx_helper();
            }
        }
        private void CheckMenu(mdl.AppMenu dragMenu, mdl.AppMenu destinationMenu, DragEventArgs e)
        {
            switch (dragMenu.Type)
            {
                case "Root"://khong dc di chuyen Root
                    e.Effect = DragDropEffects.None;

                    break;
                case "PhanHe"://tam khoi khong dc di chuyen phan he
                    e.Effect = DragDropEffects.None;

                    //e.Effect = DragDropEffects.Move;
                    break;
                case "Ribbon":
                    if (destinationMenu.Type != "PhanHe")//Ribbon chi dc di chuyen den phan he
                    {
                        e.Effect = DragDropEffects.None;

                    }
                    else
                        e.Effect = DragDropEffects.Move;
                    break;
                case "RibbonPage"://RibbonPage chi duoc di chuyen den Ribbon hoặc RibbonPageCategory
                    if (destinationMenu.Type != "Ribbon"
                        && destinationMenu.Type != "RibbonPageCategory")
                    {
                        e.Effect = DragDropEffects.None;

                    }
                    else
                        e.Effect = DragDropEffects.Move;
                    break;
                case "RibbonPageCategory":
                    if (destinationMenu.Type != "Ribbon")//RibbonPageCategory chi dc di chuyen den ribbon
                    {
                        e.Effect = DragDropEffects.None;

                    }
                    else
                        e.Effect = DragDropEffects.Move;
                    break;
                case "RibbonPageGroup":
                    if (destinationMenu.Type != "RibbonPage")//RibbonPageGroup chi dc di chuyen den RibbonPage
                    {
                        e.Effect = DragDropEffects.None;

                    }
                    else
                        e.Effect = DragDropEffects.Move;
                    break;
                case "BarButtonGroup":
                    if (destinationMenu.Type != "RibbonPageGroup")//BarButtonGroup chi dc di chuyen den RibbonPageGroup
                    {
                        e.Effect = DragDropEffects.None;
                    }
                    else
                        e.Effect = DragDropEffects.Move;
                    break;
                case "BarSubItem":
                case "BarButtonItem":
                    if (destinationMenu.Type != "RibbonPageGroup"
                        && destinationMenu.Type != "BarButtonGroup"
                        && destinationMenu.Type != "BarSubItem"
                        )//BarSubItem va BarButtonItem chi dc di chuyen den RibbonPageGroup,BarButtonGroup,BarSubItem
                        e.Effect = DragDropEffects.None;
                    else
                        e.Effect = DragDropEffects.Move;
                    break;
                default:
                    e.Effect = DragDropEffects.Move;
                    break;
            }
            if (e.Effect == DragDropEffects.Move)
            {
                if (dragMenu.MaPhanHeQL != destinationMenu.MaPhanHeQL)
                {
                    //khi thay đổi vị trí của menu đến phân hệ khác
                    //phải thay đổi mã phân hệ của nó, cũng cần thay đổi các thành phần con bên trong nó
                    dragMenu.MaPhanHeQL = destinationMenu.MaPhanHeQL;
                    ChuyenMaPhanHeChoCacMenuCon(parentMenu: dragMenu);

                    //_db.SaveChanges();
                }
            }
        }

        private void ChuyenMaPhanHeChoCacMenuCon(mdl.AppMenu parentMenu)
        {
            int id = parentMenu.ID;

            List<mdl.AppMenu> menuList = (from m in _factory.Context.AppMenus where m.ParentID == id select m).ToList();
            if (menuList.Count != 0)
            {
                foreach (mdl.AppMenu item in menuList)
                {
                    item.MaPhanHeQL = parentMenu.MaPhanHeQL;
                    ChuyenMaPhanHeChoCacMenuCon(item);
                }
            }
        }

        private int ChangeNodeIndex(int step)
        {
            int firstIndex = this.treeMenu.GetNodeIndex(this.treeMenu.FocusedNode);
            this.treeMenu.SetNodeIndex(this.treeMenu.FocusedNode, firstIndex + step);
            int lastIndex = this.treeMenu.GetNodeIndex(this.treeMenu.FocusedNode);
            if (firstIndex != lastIndex)
            {
                //NPCSimpleDynamicMenu.Model.Menu menu = this.menuBindingSource.Current as NPCSimpleDynamicMenu.Model.Menu;
                //menu.LocalIdx = lastIndex;
                ChangeMenuIdx_helper();
            }

            return lastIndex;
        }
        //private int ChangeFunctionIndex(int step)
        //{
        //    //int firstIndex = this.treeMenu.GetNodeIndex(this.treeMenu.FocusedNode);
        //    //this.treeMenu.SetNodeIndex(this.treeMenu.FocusedNode, firstIndex + step);
        //    //int lastIndex = this.treeMenu.GetNodeIndex(this.treeMenu.FocusedNode);
        //    //if (firstIndex != lastIndex)
        //    //{
        //    //    //NPCSimpleDynamicMenu.Model.Menu menu = this.menuBindingSource.Current as NPCSimpleDynamicMenu.Model.Menu;
        //    //    //menu.LocalIdx = lastIndex;

        //    //    ChangeMenuIdx_helper();
        //    //}

        //    //return lastIndex;

        //}

        private void ChangeMenuIdx_helper()
        {
            TreeListNode nodeHandle = this.treeMenu.FocusedNode;
            if (this.treeMenu.FocusedNode.ParentNode != null)
            {
                TreeListNode parentNode = this.treeMenu.FocusedNode.ParentNode;
                ChangeMenuIdx(parentNode.Nodes);
            }
            else
            {
                ChangeMenuIdx(this.treeMenu.Nodes);
            }
            this.treeMenu.FocusedNode = nodeHandle;
        }

        private void ChangeMenuIdx(TreeListNodes nodes)
        {
            foreach (TreeListNode item in nodes)
            {
                this.treeMenu.FocusedNode = item;
                mdl.AppMenu menu = this.AppMenuBindingSource.Current as mdl.AppMenu;
                int currentIndex = this.treeMenu.GetNodeIndex(item);
                if (menu.LocalIdx != currentIndex) menu.LocalIdx = currentIndex;
            }
        }
        #endregion

        private void cmdDeleteFunction_Click(object sender, EventArgs e)
        {
            //if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn xóa function đang chọn", "Hỏi ý kiến", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            //    this.gridViewFunction.DeleteSelectedRows();
        }

        private void btnThemMenu_Click(object sender, EventArgs e)
        {
        }

        private void frmMenuAndFunctionManager_Load(object sender, EventArgs e)
        {
            //BeginTransaction();
            GridUtil.DeleteHelper.Setup_ManualType(gridViewFunction, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa
                Function_Factory.FullDelete(context: _factory.Context, deleteList: deleteList);
            });
            AppFunctionBindingSource.DataSource = _factory.Context.AppFunctions;
            AppMenuBindingSource.DataSource = (from m in _factory.Context.AppMenus select m).OrderBy(x => x.LocalIdx);
            //
            {
                DataTable tbl = new DataTable("Forms");
                tbl.Columns.Add("Name", typeof(string));
                tbl.Columns.Add("FullName", typeof(string));
                tbl.Columns.Add("BaseType", typeof(string));
                tbl.Columns.Add("Module", typeof(string));

                Type[] typeList1 = System.Reflection.Assembly.GetEntryAssembly().GetTypes();
                FillType(tbl, typeList1);

                Assembly asm = Assembly.GetAssembly(typeof(frmMenuAndFunctionManager));
                Type[] typeList2 = asm.GetTypes();
                FillType(tbl, typeList2);

                formTypeBindingSource.DataSource = tbl;
            }
            _loadXong = true;
        }

        private void btnMoveUpFunction_Click(object sender, EventArgs e)
        {
        }

        private void btnMoveDownFunction_Click(object sender, EventArgs e)
        {
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }//end class
}
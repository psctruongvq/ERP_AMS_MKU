/* Tên chức năng: LoadMenu
 * Người viết: Nguyễn Phú Cường
 * Ngày tạo: 12/4/2013
 * Ngày cập nhật sau cùng:
 * Công dụng: Lấy danh sách menu của một phân hệ từ database để gắn vào ribbon và một số control khác
 * Cách sử dung: gọi phương thức static LoadMenuChoPhanHe(maPhanHeQL: "TSCD", owner: this, ribbon: this.ribbonControl1);
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using mdl = PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;

//using mdl.Context;
//using mdl.Context;

namespace PSC_ERP_Digitizing.Client.Util
{
    public class LoadMenu
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);
        private const uint SW_RESTORE = 0x09;

        #region Static Method
        private static Image BytesToImage(byte[] bytes)
        {
            try
            {
                MemoryStream stream = new MemoryStream(bytes);
                return Image.FromStream(stream);
            }
            catch (Exception) { }
            return null;
        }
        public static Byte[] ImageToBytes(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            return ms.ToArray();
        }
        private static Icon CreateIconFromImage(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            bitmap.SetResolution(image.Width, image.Height);
            Icon icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
            return icon;
        }

        public static Image ResizeImage(Image img, int width, int height, bool keepAspectRatio)
        {
            Bitmap square = new Bitmap(width, height); // create new bitmap
            Graphics g = Graphics.FromImage(square); // allow drawing to it

            int x, y, w, h; // dimensions for new image

            if (!keepAspectRatio || img.Height == img.Width)
            {
                // just fill the square
                x = y = 0; // set x and y to 0
                // set width and height
                w = width;
                h = height;
            }
            else
            {
                // work out the aspect ratio
                float r = (float)img.Width / (float)img.Height;

                // set dimensions accordingly to fit inside size^2 square
                if (r > 1)
                { // w is bigger, so divide h by r
                    w = width;
                    h = (int)((float)height / r);
                    x = 0; y = (width - h) / 2; // center the image
                }
                else
                { // h is bigger, so multiply w by r
                    w = (int)((float)width * r);
                    h = height;
                    y = 0; x = (height - w) / 2; // center the image
                }
            }

            // make the image shrink nicely by using HighQualityBicubic mode
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, x, y, w, h); // draw image with specified dimensions
            g.Flush(); // make sure all drawing operations complete before we get the icon

            // following line would work directly on any image, but then
            // it wouldn't look as nice.

            return square;

        }
        private static FormStartPosition GetFormStartPositionByName(String startPositionName)
        {
            switch (startPositionName)
            {
                case "Manual":
                    return FormStartPosition.Manual;
                case "CenterScreen":
                    return FormStartPosition.CenterScreen;
                case "WindowsDefaultLocation":
                    return FormStartPosition.WindowsDefaultLocation;
                case "WindowsDefaultBounds":
                    return FormStartPosition.WindowsDefaultBounds;
                case "CenterParent":
                    return FormStartPosition.CenterParent;
                default:
                    return FormStartPosition.WindowsDefaultLocation;
            }

        }

        private static FormWindowState GetFormWindowStateByName(String formWindowStateName)
        {
            switch (formWindowStateName)
            {
                case "Normal":
                    return FormWindowState.Normal;
                case "Minimized":
                    return FormWindowState.Minimized;
                case "Maximized":
                    return FormWindowState.Maximized;
                default:
                    return FormWindowState.Normal;
            }
        }
        public static PropertyInfo GetStaticPropertyInfo(String fullClassTypeName, String propertyName)
        {
            Type type = Type.GetType(fullClassTypeName);
            PropertyInfo info = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static);
            return info;
        }
        public static void LoadMenuChoPhanHe(String maPhanHeQL, IWin32Window owner, RibbonControl ribbon)
        {

            if (ribbon != null)
            {
                while (ribbon.Pages.Count > 1)
                {
                    ribbon.Pages.RemoveAt(1);
                }
                while (ribbon.PageCategories.Count > 1)
                {
                    ribbon.PageCategories.RemoveAt(1);
                }
            }
            LoadMenu loadMenuObj = new LoadMenu(ribbon, owner, maPhanHeQL);
            loadMenuObj.Load();


        }
        #endregion

        #region Private member method
        private Entities _db = Database.NewEntities();//new mdl.Context.Entities();
        private RibbonControl _ribbon;
        private IWin32Window _owner;
        private String _maPhanHeQL;
        #endregion
        #region Constructor
        public LoadMenu(RibbonControl ribbon, IWin32Window owner, String maPhanHeQL)
        {
            this._ribbon = ribbon;
            this._owner = owner;
            this._maPhanHeQL = maPhanHeQL;


        }
        #endregion
        #region Public Member Method
        public void Load()
        {
            if (_ribbon != null)
                InsertMenuInto(_ribbon);//Gan menu vao ribbon
        }
        #endregion

        #region Private Member Method
        private void InsertMenuInto(Object parent)
        {
            bool isAdmin = false;
            int userID = PSC_ERP_Global.Main.UserID;
            //Kiểm tra Admin
            isAdmin = app_users_Factory.New().CheckAdminByUserID_ContainsAdminKeyword(userID);

            if (parent is RibbonControl)
            {
                RibbonControl ribbon = (RibbonControl)parent;
                ////danh sach menu co kieu RibbonPage
                //List<mdl.AppMenu> menuList = (from m in _db.AppMenus
                //                              where m.MaPhanHeQL == _maPhanHeQL && m.Type == "RibbonPage" && (m.ParentAppMenu.Type == "Ribbon" || m.ParentAppMenu.Type == "RibbonPageCategory")
                //                              orderby m.LocalIdx ascending
                //                              select m).ToList();

                List<AppMenu> menuList = Menu_Factory.New().Get_DanhSachAppMenuByUserID_KieuRibbonPage(_maPhanHeQL, userID, isAdmin).ToList();

                //PSC_ERP_Business.MenuFactory menuFactory = new Business.MenuFactory();

                //List<mdl.Menu> menuList = menuFactory.g
                //duyet qua cac ribbon page
                foreach (AppMenu menu in menuList)
                {
                    RibbonPage page = new RibbonPage() { Tag = menu /*luu vet*/ };


                    if (menu.Image != null)
                    {
                        Image img = BytesToImage(menu.Image);




                        Image imgx = ResizeImage(img, 16, 16, true);//ResizeFixed(img, 16, 16);
                        //Image imgx = ResizeImage(img, 16, true);//ResizeFixed(img, 16, 16);

                        page.Image = imgx;
                    }
                    page.Text = menu.Title;//dinh caption cua ribbon page
                    ribbon.Pages.Add(page);//them ribbon page vao ribbon
                    //
                    if (menu.Focused == true)
                        ribbon.SelectedPage = page;
                    //
                    InsertMenuInto(page);//goi de quy ->them group vao page

                }//end foreach
                GroupRibbonPageInto_RibbonPageCategoryOn(ribbon, _maPhanHeQL);//group cac ribbon page vao cac ribbon page category
            }
            else if (parent is RibbonPage)
            {
                RibbonPage page = (RibbonPage)parent;
                int ParentID = ((mdl.AppMenu)page.Tag).ID;

                ////danh sach menu co kieu RibbonPageGroup
                //List<mdl.AppMenu> menuList = (from m in _db.AppMenus
                //                              where m.MaPhanHeQL == _maPhanHeQL && m.ParentID == ParentID &&
                //                              m.Type == "RibbonPageGroup"
                //                              orderby m.LocalIdx ascending
                //                              select m).ToList();

                List<AppMenu> menuList = Menu_Factory.New().Get_DanhSachAppMenuByUserID_RibbonPageGroup(_maPhanHeQL, userID, isAdmin, ParentID).ToList();

                //duyet qua cac RibbonPageGroup
                foreach (mdl.AppMenu menu in menuList)
                {
                    RibbonPageGroup pageGroup = new RibbonPageGroup() { Tag = menu /*luu vet*/ };

                    if (menu.Image != null)
                    {
                        pageGroup.Glyph = BytesToImage(menu.Image);//khong thay hien len
                    }
                    pageGroup.Text = menu.Title;
                    page.Groups.Add(pageGroup);
                    InsertMenuInto(pageGroup);//goi de quy -> them barButtonItem vao group
                }
            }
            else if (parent is RibbonPageGroup)
            {
                RibbonPageGroup pageGroup = (RibbonPageGroup)parent;
                int ParentID = ((mdl.AppMenu)pageGroup.Tag).ID;
                ////danh sach menu
                //List<mdl.AppMenu> menuList = (from m in _db.AppMenus
                //                              where m.ParentID == ParentID
                //                              orderby m.LocalIdx ascending
                //                              select m).ToList();

                List<AppMenu> menuList = Menu_Factory.New().Get_DanhSachAppMenuByUserID_BarButtonItem(userID, isAdmin, ParentID).ToList();

                //duyet qua cac BarButtonItem
                foreach (mdl.AppMenu menu in menuList)
                {
                    BarItem barItem = null;
                    if (menu.Type == "BarButtonItem")
                        barItem = new BarButtonItem();
                    else if (menu.Type == "BarSubItem")//
                        barItem = new BarSubItem();
                    else if (menu.Type == "BarLinkContainerItem")//
                        barItem = new BarLinkContainerItem();
                    else if (menu.Type == "BarButtonGroup")
                        barItem = new BarButtonGroup();

                    //
                    CauHinhMenu(menu, barItem);
                    //
                    pageGroup.ItemLinks.Add(barItem, menu.IsBeginGroup ?? false);
                    //
                    GoiDeQuyThemMenuVaoContainer(menu, barItem);
                }
            }
            else if (parent is BarButtonGroup || parent is BarSubItem || parent is BarLinkContainerItem)
            {
                //dang xem cho nay

                BarLinkContainerItem parentMenu = null;
                if (parent is BarButtonGroup)
                    parentMenu = (BarButtonGroup)parent;
                else if (parent is BarSubItem)
                    parentMenu = (BarSubItem)parent;
                int ParentID = ((mdl.AppMenu)parentMenu.Tag).ID;
                ////danh sach menu
                //List<mdl.AppMenu> menuList = (from m in _db.AppMenus
                //                              where m.ParentID == ParentID
                //                              orderby m.LocalIdx ascending
                //                              select m).ToList<mdl.AppMenu>();

                List<AppMenu> menuList = Menu_Factory.New().Get_DanhSachAppMenuByUserID_BarButtonItem_BarSubItem_BarLinkContainerItem(userID, isAdmin, ParentID).ToList();

                foreach (mdl.AppMenu menu in menuList)
                {
                    BarItem barItem = null;
                    if (menu.Type == "BarButtonItem")
                        barItem = new BarButtonItem();
                    else if (menu.Type == "BarSubItem")
                        barItem = new BarSubItem();
                    else if (menu.Type == "BarLinkContainerItem")
                        barItem = new BarLinkContainerItem();

                    //
                    CauHinhMenu(menu, barItem);
                    //
                    parentMenu.AddItem(barItem);
                    //
                    GoiDeQuyThemMenuVaoContainer(menu, barItem);
                }

            }
        }

        private void CauHinhMenu(mdl.AppMenu menu, BarItem barItem)
        {
            if (barItem != null)
            {
                barItem.Id = menu.ID;
                barItem.Tag = menu;//luu vet
                barItem.RibbonStyle = RibbonItemStyles.Large | RibbonItemStyles.SmallWithText;
                bool suDungTilteCuaFunction = false;
                if (String.IsNullOrWhiteSpace(menu.Title))//nếu title của menu là rỗng
                    suDungTilteCuaFunction = true;//cần sử dụng title của function
                else
                    barItem.Caption = menu.Title;//sử dụng title của menu

                bool suDungImageCuaFunction = false;
                if (menu.Image == null)
                    suDungImageCuaFunction = true;
                else
                {
                    barItem.Glyph = BytesToImage(menu.Image);
                    barItem.LargeGlyph = BytesToImage(menu.Image);
                }
                int? test = menu.FunctionID;
                if (menu != null && menu.AppFunction != null)
                {
                    if (suDungTilteCuaFunction)//kiểm tra có cần gán lại title
                        barItem.Caption = menu.Title;//sử dụng title của function
                    //image
                    if (suDungImageCuaFunction && menu.AppFunction.Image != null)
                    {
                        barItem.Glyph = BytesToImage(menu.AppFunction.Image);
                        barItem.LargeGlyph = BytesToImage(menu.AppFunction.Image);
                    }

                    barItem.ItemClick += (object senderz, ItemClickEventArgs ez) =>
                    {
                        mdl.AppMenu m = (mdl.AppMenu)(ez.Item.Tag);//buoc phai lay menu tu duong nay
                        System.Type objType = System.Type.GetType(m.AppFunction.NamespaceAndClassName);
                        object obj = Activator.CreateInstance(objType);
                        //Form
                        if (obj is Form)
                        {

                            Form frm = (Form)obj;
                            if (barItem.Glyph != null)
                            {

                                frm.Icon = CreateIconFromImage(barItem.Glyph);

                                //byte[] imageBytes = ImageToBytes(barItem.Glyph, barItem.Glyph.RawFormat);

                                //IntPtr iconHandle = GetHandleFromBytes(imageBytes);
                                //frm.Icon = Icon.FromHandle(iconHandle);

                            }
                            //
                            frm.StartPosition = GetFormStartPositionByName(m.AppFunction.StartPosition);
                            //
                            frm.WindowState = GetFormWindowStateByName(m.AppFunction.WindowsState);
                            //
                            if (m.AppFunction.IsMdiContainer != null)
                                frm.IsMdiContainer = m.AppFunction.IsMdiContainer.Value;


                            //Init
                            if (!String.IsNullOrWhiteSpace(m.AppFunction.PublicInitInstanceMethod))
                            {

                                frm.GetType().GetMethod(m.AppFunction.PublicInitInstanceMethod).Invoke(frm, null);//goi phuong thuc trong form truoc khi show+
                            }
                            //Public static
                            else if (!String.IsNullOrWhiteSpace(m.AppFunction.PublicStaticMethod))
                            {
                                Type type = Type.GetType(m.AppFunction.NamespaceAndClassName);
                                type.InvokeMember(m.AppFunction.PublicStaticMethod, BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Static, null, null, new object[] { _owner });
                                return;
                                //

                            }
                            //Singleton
                            else if (!String.IsNullOrWhiteSpace(m.AppFunction.PublicStaticSingletonProperty))
                            {
                                PropertyInfo info = GetStaticPropertyInfo(m.AppFunction.NamespaceAndClassName, m.AppFunction.PublicStaticSingletonProperty);
                                frm = (Form)(info.GetValue(null, null));
                                //

                            }
                            //
                            if (m.AppFunction.IsMdiChild != null && true == m.AppFunction.IsMdiChild.Value)
                            {
                                frm.MdiParent = (Form)_owner;

                            }
                            if (frm != null)
                            {
                                if (frm.Visible)
                                {
                                    if (frm.WindowState == FormWindowState.Minimized)
                                        ShowWindow(frm.Handle, SW_RESTORE);
                                    else
                                        frm.BringToFront();
                                }
                                else
                                {
                                    if (m.AppFunction.ShowDialog != null && m.AppFunction.ShowDialog.Value == true)
                                        frm.ShowDialog(_owner);
                                    else if (m.AppFunction.IsMdiChild != null && m.AppFunction.IsMdiChild.Value)
                                        frm.Show();
                                    else
                                        frm.Show(_owner);
                                }
                            }

                        }
                        //Other object
                        else
                        {


                            obj.GetType().GetMethod(m.AppFunction.PublicInitInstanceMethod).Invoke(obj, null);
                        }
                    };//end event
                }//end if
            }//end if
        }




        private void GoiDeQuyThemMenuVaoContainer(mdl.AppMenu menu, BarItem barItem)
        {
            if (menu.Type == "BarSubItem"
                //|| menu.Type == "BarListItem"
                || menu.Type == "BarLinkContainerItem"
                   || menu.Type == "BarButtonGroup")
                InsertMenuInto(barItem);//goi de quy
        }

        private void GroupRibbonPageInto_RibbonPageCategoryOn(RibbonControl ribbon, String maPhanHeQL)
        {//page category nam o tren thanh titlebar, cong dung group cac ribbon page vao 1 nhom

            //danh sach menu co kieu RibbonPageCategory
            List<mdl.AppMenu> menuList = (from m in _db.AppMenus
                                          where m.MaPhanHeQL == maPhanHeQL && m.Type == "RibbonPageCategory" && m.ParentAppMenu.Type == "Ribbon"
                                          orderby m.LocalIdx ascending
                                          select m).ToList<mdl.AppMenu>();
            //duyet qua tung RibbonPageCategory va insert vao ribbon
            foreach (mdl.AppMenu categoryMenu in menuList)
            {

                RibbonPageCategory pageCategory = new RibbonPageCategory() { Tag = categoryMenu /*luu vet*/ };

                pageCategory.Text = categoryMenu.Title;//caption cua page category
                ribbon.PageCategories.Add(pageCategory);//them page category vao ribbon
                Queue<RibbonPage> pages = new Queue<RibbonPage>();//danh sach ribbon page thuoc category dang xet
                //duyet qua cac Ribbon page dang hien huu tren ribbon
                for (int i = 0; i < ribbon.Pages.Count; i++)
                {

                    try
                    {
                        if (((mdl.AppMenu)ribbon.Pages[i].Tag).ParentID == categoryMenu.ID)//neu ribbon page co tag luu vet la con truc tiep cua page category dang xet                            pages.Enqueue(ribbon.Pages[i]);//them vao danh sach ribbon page thuoc category dang xet
                            pages.Enqueue(ribbon.Pages[i]);//them vao danh sach ribbon page thuoc category dang xet
                    }
                    catch (Exception ex)
                    {/*ko can nem ngoai le*/
                        //MessageBox.Show(ex.ToString());
                    }

                }//end for
                foreach (RibbonPage page in pages)
                {
                    ribbon.Pages.Remove(page);//go bo ribbon page thuoc page category dang xet ra khoi ribbon

                }
                pageCategory.Pages.AddRange(pages.ToArray());//gan cac ribbon page vao page category, thi cung dong thoi duoc gan tro lai ribbon


            }//end foreach

        }
        #endregion
    }
}

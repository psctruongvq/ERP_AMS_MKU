using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERPNew.Main.PhanHe.DIGITIZING.Predefined;
using PSC_ERPNew.Main.PhanHe.DIGITIZING.Model;
using System.Threading.Tasks;
using DevExpress.XtraTreeList.Nodes;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using System.Threading;
using PSC_ERP_Common.Extension;
using PSC_ERP_Digitizing.Client.WebReference1;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Text;
using DevExpress.Utils;
using System.Transactions;

namespace PSC_ERPNew.Main.PhanHe.DIGITIZING
{
    public partial class frmDigitizing_UpLoadFile : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDigitizing_UpLoadFile singleton_ = null;
        public static frmDigitizing_UpLoadFile Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDigitizing_UpLoadFile();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion



        Int32? _maBoPhan_ForQuickLoad = null;
        Int64? _maChungTu_ForQuickLoad = null;
        Int32? _maLoaiChungTu_ForQuickLoad = null;

        String _publicKey = "gi cung duoc";
        String _token = null;
        Boolean _daLoadFormXong = false;
        DigitizingBag_Factory _treeBagFactory = DigitizingBag_Factory.New();
        IQueryable<DigitizingBag> treeBag;
        TreeListNode focusedNode;
        DigitizingBag currentObjectAtNode_Folder;
        DigitizingBag _currentBagForPreview_File = null;

        public frmDigitizing_UpLoadFile()
        {
            InitializeComponent();
        }


        private void DocDuLieuVaDuaLenCay()
        {
            //tạo mới factory
            //_treeBagFactory = DigitizingBag_Factory.New();
            treeBag = _treeBagFactory.GetAll();
            int namHienTai = app_users_Factory.New().SystemDate.Year;//(DateTime.Today.Year);
            //lọc bớt chỉ lấy dữ liệu là folder đến năm hiện tại
            treeBag = treeBag.Where(x => ((x.FolderYear ?? namHienTai) <= namHienTai && (x.IsFile ?? false) == false));

            //gắn binding source
            digitizingBagBindingSource_ForTree.DataSource = treeBag;
            //treeListBag.DataSource = digitizingBagBindingSource_ForTree;
        }

        private DigitizingBag GetObject_AtNode(TreeListNode node)
        {
            return treeListBag.GetDataRecordByNode(node) as DigitizingBag;
        }

        private Boolean SaveTree()
        {
            this.txtBlackHole.Focus();
            try
            {
                _treeBagFactory.SaveChangesWithoutTrackingLog();
                //ẩn nút save              
                return true;
            }
            catch (Exception ex)
            {
                DialogUtil.ShowNotSaveSuccessful("Không lưu được");
                return false;
            }
        }

        private void frmDigitizing_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            this.Shown += (object senderz, EventArgs ez) =>
            {
                TaoCauTrucCay();
                TaskUtil.InvokeCrossThread(this, () =>
                {
                    using (DialogUtil.Wait(this))
                    {
                        _daLoadFormXong = false;

                        _token = PSC_ERPNew.Main.PhanHe.DIGITIZING.Helper.MakeToken(publicKey: _publicKey, secretKey: "pscvietnam@hoasua");

                        //TaskUtil.InvokeCrossThread(this, () => { this.XuLyChungTu(); });
                        //du du lieu len cay
                        DocDuLieuVaDuaLenCay();
                        //TaskUtil.InvokeCrossThread(this, () => { DocDuLieuVaDuaLenCay(); });                                   
                        _daLoadFormXong = true;
                    }
                });

            };
        }

        private void digitizingBagBindingSource_ForGrid_CurrentChanged(object sender, EventArgs e)
        {
            //The CurrentChanged event is raised whenever the Current property changes for any of the following reasons:
            //The current position of the List changes.
            //The DataSource or DataMember properties change.
            //The membership of the underlying List changes, which causes Position to refer to a different item. Examples include adding or deleting an item before the current item, deleting or moving the current item itself, or moving an item to the current position.
            //The underlying list is refreshed by a new sorting or filtering operation.
            //When this event is triggered, the Current property will already contain its new value.
            //CurrentChanged is the default event for the BindingSource class.

        }

        private void digitizingBagBindingSource_ForGrid_CurrentItemChanged(object sender, EventArgs e)
        {
            //The CurrentItemChanged event is raised in response to all of the circumstances that raise the CurrentChanged event. Additionally, CurrentItemChanged is also fired whenever the value of one of the properties of Current is changed.
        }

        private void treeListBag_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            currentObjectAtNode_Folder = treeListBag.GetDataRecordByNode(e.Node) as DigitizingBag;

            Int32? _CapDoCay = currentObjectAtNode_Folder.CapDoCay;
            //nếu ko phải là nút gốc
            if (currentObjectAtNode_Folder.CapDoCay > 0)
            {
                TaskUtil.InvokeCrossThread(this, () =>
                {
                    using (DialogUtil.Wait(this))
                    {
                        //fill danh sach file trong node lên lưới

                        //switch (_CapDoCay)
                        //{
                        //    //lấy toàn bộ file theo bộ phận
                        //    case 1:
                        //        dsFile = _treeBagFactory.Context.spd_TimFile(0, obj.MaBoPhan, 0, 0) as List<DigitizingBag>;                         
                        //        break;
                        //    //lấy toàn bộ file theo loại chứng từ và bộ phận
                        //    case 2:
                        //        break;
                        //        dsFile = _treeBagFactory.Context.spd_TimFile(0, obj.MaBoPhan, obj.MaLoaiChungTu, 0) as List<DigitizingBag>;                          
                        //    //lấy toàn bộ file theo năm - loại chứng từ - bộ phận
                        //    case 3:
                        //        dsFile = _treeBagFactory.Context.spd_TimFile(obj.FolderYear, obj.MaBoPhan, obj.MaLoaiChungTu, 0) as List<DigitizingBag>;
                        //        break;
                        //    default:
                        //        break;
                        //}

                        DigitizingBag_Factory factory = DigitizingBag_Factory.New();
                        IQueryable<DigitizingBag> dsFile=null;
                        switch (_CapDoCay)
                        {
                            case 1: dsFile = factory.TimFile(currentObjectAtNode_Folder.MaBoPhan.Value, 0, 0);//phòng ban
                                break;
                            case 2: dsFile = factory.TimFile(currentObjectAtNode_Folder.MaBoPhan.Value, currentObjectAtNode_Folder.MaLoaiChungTu.Value, 0);//loại chứng từ
                                break;
                            case 3: dsFile = factory.TimFile(currentObjectAtNode_Folder.MaBoPhan.Value, currentObjectAtNode_Folder.MaLoaiChungTu.Value, currentObjectAtNode_Folder.FolderYear.Value);//năm
                                break;
                        }
                        //List<Guid> idFileList = _treeBagFactory.Context.sp_DIGITIZING_DigitizingBag_GetAllFileListByBagId(currentObjectAtNode_Folder.BagId).Select(x => x ?? Guid.Empty).ToList();
                        ////

                        //IQueryable<DigitizingBag> dsBag = _treeBagFactory.GetAll();                     
                        //IQueryable<DigitizingBag> dsFile = DigitizingBag_Factory.GetListByIdList(dsBag, idFileList);
                        digitizingBagBindingSource_ForGrid.DataSource = dsFile;
                    }
                });//end task
            }

        }

        private void treeListBag_DoubleClick(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node != null)
            {
                var obj = treeListBag.GetDataRecordByNode(hi.Node) as DigitizingBag;
                if ((obj.FileUploadCompleted ?? false) == true)
                {
                    //_currentBagForPreview = obj;

                }
            }

        }

        private void frmDigitizing_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_treeBagFactory.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    if (false == this.SaveTree())
                    {
                        DialogUtil.ShowNotSaveSuccessful();
                        e.Cancel = true;
                    }
                }
                else if (DialogResult.No == dlgResult)
                {
                    //không làm gì cả
                }
                else if (DialogResult.Cancel == dlgResult)
                {
                    e.Cancel = true;
                }
            }
        }

        private void treeListBag_DragOver(object sender, DragEventArgs e)
        {
            TreeList tree = sender as TreeList;
            Point p = tree.PointToClient(new Point(e.X, e.Y));
            TreeListHitInfo hitInfo = tree.CalcHitInfo(p);
            tree.FocusedNode = hitInfo.Node;
            DigitizingBag dragBag = tree.GetDataRecordByNode(hitInfo.Node) as DigitizingBag;

            if (e.Data.GetDataPresent(typeof(TreeListNode)) && dragBag != null && ((_maChungTu_ForQuickLoad ?? 0) == 0 || dragBag.IsFile == true))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }
        private void treeListBag_DragDrop(object sender, DragEventArgs e)
        {
            TreeList tree = sender as TreeList;
            ////
            Point p = tree.PointToClient(new Point(e.X, e.Y));
            TreeListHitInfo hitInfo = tree.CalcHitInfo(p);
            //
            if (e.Data.GetDataPresent(typeof(TreeListNode)))//drag menu
            {
                TreeListNode node = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;

                DigitizingBag dragBag = tree.GetDataRecordByNode(node) as DigitizingBag;
                DigitizingBag destinationBag = tree.GetDataRecordByNode(hitInfo.Node) as DigitizingBag;
                if (destinationBag != null)
                {

                    if (!(destinationBag.IsFile ?? false))//dest thu muc
                        e.Effect = DragDropEffects.Move;
                    else e.Effect = DragDropEffects.None;

                    if (e.Effect == DragDropEffects.Move)
                    {
                        //nen su dung task cho nay.
                        TaskUtil.InvokeCrossThread(this, () =>
                        {
                            Thread.Sleep(100);
                            _treeBagFactory.SaveChangesWithoutTrackingLog();
                        });

                    }
                }
                else
                    e.Effect = DragDropEffects.None;
            }



        }

        private void treeListBag_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            DigitizingBag bag = this.treeListBag.GetDataRecordByNode(e.Node) as DigitizingBag;
            if (bag != null)
            {
                if (!(bag.IsFile ?? false))//thu muc
                {
                    e.NodeImageIndex = 0;
                }
                else//file
                {
                    e.NodeImageIndex = 1;
                }
            }
        }

        private void gridViewDanhSachFile_RowStyle(object sender, RowStyleEventArgs e)
        {
            //////////////HighLight Row GridView
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0 && txtNoiDungCanTim.Text != "")
            //{
            //    string name = View.GetRowCellDisplayText(e.RowHandle, View.Columns[0]).ToLower();
            //    // string name = View.GetRowCellValue(e.RowHandle, View.Columns["col_TenTaiLieu"]);
            //    if (name.Contains(txtNoiDungCanTim.Text.Trim().ToLower()))
            //    {
            //        e.Appearance.BackColor = Color.SkyBlue;
            //        //e.Appearance.BackColor2 = Color.SaShell;
            //    }
            //}
        }

        #region Tạo cấu trúc cây - đổ dữ liệu lên cây
        public void TaoCauTrucCay()//chỉ chạy lần đầu tiên để đổ liệu vào bảng DigitizingBag tạo cấu trúc cây
        {
            var factory = DigitizingBag_Factory.New();
            //
            if (factory.ObjectSet.Count() == 0)
            {
                using (DialogUtil.Wait(this, "vui lòng đợi...", "Đang tạo cấu trúc cây"))
                {
                    //đổ bộ phận
                    List<tblnsBoPhan> boPhanList = BoPhan_Factory.New().GetAll().ToList();
                    var root = boPhanList.SingleOrDefault(x => x.MaBoPhan == 33);

                    DigitizingBag digiRoot = factory.CreateManagedObject();
                    digiRoot.BagId = Guid.Empty;
                    digiRoot.MaBoPhan = root.MaBoPhan;
                    digiRoot.Name = root.TenBoPhan;
                    digiRoot.IsFile = false;
                    digiRoot.CapDoCay = 0;
                    foreach (tblnsBoPhan bophan in boPhanList)
                    {

                        if (bophan.MaBoPhan != root.MaBoPhan && bophan.MaLoaiBoPhan == 2)
                        {
                            DigitizingBag obj_BoPhan = factory.CreateManagedObject();
                            obj_BoPhan.BagId = Guid.NewGuid();
                            obj_BoPhan.MaBoPhan = bophan.MaBoPhan;
                            obj_BoPhan.Name = bophan.MaBoPhanQL + ": " + bophan.TenBoPhan;
                            obj_BoPhan.IsFile = false;
                            obj_BoPhan.ParentBagId = digiRoot.BagId;
                            obj_BoPhan.CapDoCay = 1;
                            //đổ loại chứng từ
                            foreach (var docType in DocumentType.DocumentTypeList)
                            {
                                if (docType.Id != 0)
                                {
                                    DigitizingBag obj_Loai = factory.CreateManagedObject();
                                    obj_Loai.BagId = Guid.NewGuid();
                                    obj_Loai.Name = docType.Name;
                                    obj_Loai.MaLoaiChungTu = docType.Id;
                                    obj_Loai.CapDoCay = 2;
                                    obj_Loai.IsFile = false;

                                    obj_Loai.MaBoPhan = bophan.MaBoPhan;
                                    //trường hợp file không có trong databse
                                    if (docType.Id == 1003 || docType.Id == 1004 //hợp đồng
                                        || docType.Id == 2005 || docType.Id == 2006 || docType.Id == 2007)//văn bản
                                    {
                                        obj_Loai.IsDatabase = false;
                                    }
                                    //trường hợp file có trong database
                                    else//chứng từ
                                    {
                                        obj_Loai.IsDatabase = true;
                                    }


                                    obj_Loai.DigitizingBag2 = obj_BoPhan;
                                    //đổ năm
                                    for (int i = 1998; i <= (DateTime.Now.Year + 5); i++)
                                    {

                                        DigitizingBag obj_Nam = factory.CreateManagedObject();
                                        obj_Nam.BagId = Guid.NewGuid();
                                        obj_Nam.Name = "Năm " + i;

                                        obj_Nam.MaBoPhan = bophan.MaBoPhan;
                                        obj_Nam.MaLoaiChungTu = docType.Id;
                                        obj_Nam.CapDoCay = 3;
                                        obj_Nam.IsDatabase = obj_Loai.IsDatabase;
                                        obj_Nam.IsFile = false;

                                        obj_Nam.FolderYear = i;
                                        obj_Nam.DigitizingBag2 = obj_Loai;
                                    }
                                }
                            }

                            //quyết định
                            DigitizingBag obj_QuyetDinh = factory.CreateManagedObject();
                            obj_QuyetDinh.BagId = Guid.NewGuid();
                            obj_QuyetDinh.Name = "Quyết Định";

                            obj_QuyetDinh.CapDoCay = 2;
                            obj_QuyetDinh.MaBoPhan = obj_BoPhan.MaBoPhan;
                            obj_QuyetDinh.MaLoaiChungTu = 2005;
                            obj_QuyetDinh.IsDatabase = false;
                            obj_QuyetDinh.IsFile = false;
                            //obj_BoPhan.DigitizingBag1.Add(obj_Loai);
                            obj_QuyetDinh.DigitizingBag2 = obj_BoPhan;
                            //đổ năm
                            for (int i = 1998; i <= (DateTime.Now.Year + 5); i++)
                            {

                                DigitizingBag obj_Nam = factory.CreateManagedObject();
                                obj_Nam.BagId = Guid.NewGuid();
                                obj_Nam.Name = "Năm " + i;
                                obj_Nam.FolderYear = i;
                                obj_Nam.IsDatabase = obj_QuyetDinh.IsDatabase;
                                obj_Nam.CapDoCay = 3;
                                obj_Nam.IsFile = false;
                                obj_Nam.MaBoPhan = obj_BoPhan.MaBoPhan;
                                obj_Nam.MaLoaiChungTu = obj_QuyetDinh.MaLoaiChungTu;
                                obj_Nam.DigitizingBag2 = obj_QuyetDinh;
                            }

                            //    //thông báo
                            DigitizingBag obj_ThongBao = factory.CreateManagedObject();
                            obj_ThongBao.BagId = Guid.NewGuid();
                            obj_ThongBao.Name = "Thông Báo";

                            obj_ThongBao.MaBoPhan = obj_BoPhan.MaBoPhan;
                            obj_ThongBao.CapDoCay = 2;
                            obj_ThongBao.MaLoaiChungTu = 2006;
                            obj_ThongBao.IsDatabase = false;
                            obj_ThongBao.IsFile = false;

                            //obj_BoPhan.DigitizingBag1.Add(obj_Loai);
                            obj_ThongBao.DigitizingBag2 = obj_BoPhan;
                            //đổ năm
                            for (int i = 1998; i <= (DateTime.Now.Year + 5); i++)
                            {

                                DigitizingBag obj_Nam = factory.CreateManagedObject();
                                obj_Nam.BagId = Guid.NewGuid();
                                obj_Nam.Name = "Năm " + i;
                                obj_Nam.CapDoCay = 3;
                                obj_Nam.IsFile = false;
                                obj_Nam.IsDatabase = obj_ThongBao.IsDatabase;
                                obj_Nam.MaLoaiChungTu = obj_ThongBao.MaLoaiChungTu;
                                obj_Nam.MaBoPhan = obj_BoPhan.MaBoPhan;
                                obj_Nam.FolderYear = i;
                                obj_Nam.DigitizingBag2 = obj_ThongBao;
                            }

                            //    //chuyên mục khác
                            DigitizingBag obj_ChuyenMucKhac = factory.CreateManagedObject();
                            obj_ChuyenMucKhac.BagId = Guid.NewGuid();
                            obj_ChuyenMucKhac.Name = "Chuyên Mục Khác";

                            obj_ChuyenMucKhac.MaLoaiChungTu = 2007;
                            obj_ChuyenMucKhac.MaBoPhan = obj_BoPhan.MaBoPhan;
                            obj_ChuyenMucKhac.CapDoCay = 2;
                            obj_ChuyenMucKhac.IsDatabase = false;
                            obj_ChuyenMucKhac.IsFile = false;
                            //obj_BoPhan.DigitizingBag1.Add(obj_Loai);
                            obj_ChuyenMucKhac.DigitizingBag2 = obj_BoPhan;
                            //đổ năm
                            for (int i = 1998; i <= (DateTime.Now.Year + 5); i++)
                            {

                                DigitizingBag obj_Nam = factory.CreateManagedObject();
                                obj_Nam.BagId = Guid.NewGuid();
                                obj_Nam.Name = "Năm " + i;
                                obj_Nam.FolderYear = i;
                                obj_Nam.IsFile = false;
                                obj_Nam.MaBoPhan = obj_BoPhan.MaBoPhan;
                                obj_Nam.IsDatabase = obj_ChuyenMucKhac.IsDatabase;
                                obj_Nam.MaLoaiChungTu = obj_ChuyenMucKhac.MaLoaiChungTu;
                                obj_Nam.CapDoCay = 3;

                                obj_Nam.DigitizingBag2 = obj_ChuyenMucKhac;
                            }
                        }

                    }
                    factory.SaveChangesWithoutTrackingLog();

                }
            }

        }
        #endregion

        private void treeListBag_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            //var obj = treeListBag.GetDataRecordByNode(e.Node) as DigitizingBag;
            //chỉnh lại màu của node được selecte
            if (e.Node.Selected)
            {
                e.Appearance.BackColor = Color.LightBlue;//Color.LightPink;
                e.Appearance.ForeColor = Color.DarkViolet;//Color.DarkGreen;
            }
        }

        private void btnMenuTreeView_Them_Click(object sender, EventArgs e)
        {
            focusedNode = treeListBag.FocusedNode;//C
            currentObjectAtNode_Folder = GetObject_AtNode(focusedNode);//C       
            //lấy mã bộ phận của nhánh cây
            _maBoPhan_ForQuickLoad = currentObjectAtNode_Folder.MaBoPhan; //TimMaBoPhan(currentObjectAtNode_Folder) ?? 0;
            //lấy loại chứng từ
            DocumentTypeEnum documentType_ForQuickLoad = (DocumentTypeEnum)currentObjectAtNode_Folder.MaLoaiChungTu;//(TimMaLoaiChungTu(currentObjectAtNode_Folder) ?? 0);
            _maLoaiChungTu_ForQuickLoad = Convert.ToInt32(documentType_ForQuickLoad);
            //lấy FolderYear chứng từ
            Int32? folderYearAtCurrentBranch = currentObjectAtNode_Folder.FolderYear; //TimNam(currentObjectAtNode_Folder) ?? 0;

            //lấy danh sách chứng từ đã có trước đó
            IQueryable<DigitizingBag> dsBag = _treeBagFactory.GetAll();//(digitizingBagBindingSource_ForTree.DataSource as IQueryable<DigitizingBag>);

            //trường hợp có trong Database các chứng từ: bảng kê, phiếu thu, phiếu chi, phiếu nhập, phiếu xuất
            if ((currentObjectAtNode_Folder.IsDatabase ?? false) == true)
            {
                using (frmDigitizing_ChonChungTuUpLoad frm = new frmDigitizing_ChonChungTuUpLoad(_treeBagFactory, dsBag, _maBoPhan_ForQuickLoad, documentType_ForQuickLoad,
                                                                                        folderYearAtCurrentBranch, currentObjectAtNode_Folder, _maChungTu_ForQuickLoad, true))
                {
                    DialogResult result = frm.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        digitizingBagBindingSource_ForTree.ResetBindings(true);
                    }
                }
            }

            //trường hợp file không có trong database: văn bản (quyết định, thông báo, chuyên mục khác) và hợp đồng
            else if ((currentObjectAtNode_Folder.IsDatabase ?? false) == false)
            {
                //spd_TimChungTuSoHoa_Result _currentChungTu = null;                
                using (var frm = new frmDigitizing_ChonFilesUpLoad(_treeBagFactory, dsBag, null, currentObjectAtNode_Folder, _maBoPhan_ForQuickLoad, documentType_ForQuickLoad, folderYearAtCurrentBranch, false))
                {
                    DialogResult result = frm.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        digitizingBagBindingSource_ForTree.ResetBindings(true);
                    }
                }
            }
        }


        private void gridViewDanhSachFile_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);

        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if ((info.InRow || info.InRowCell) && info.RowHandle >= 0)
            {
                _currentBagForPreview_File = this.gridViewDanhSachFile.GetRow(info.RowHandle) as DigitizingBag;
                //mở from xem lại chứng từ
                using (frmDigitizing_Find_and_PreViewFile frm = new frmDigitizing_Find_and_PreViewFile(_currentBagForPreview_File))
                {
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Text = "Bạn Đang Xem File " + _currentBagForPreview_File.Name;

                    frm.splitContainerControl1.Panel1.Hide();
                    frm.splitContainerControl1.SplitterPosition = 0;
                    frm.splitContainerControl1.IsSplitterFixed = true;

                    frm.ShowDialog();
                }
                //frmDigitizing_PreViewFile.ShowFile(_currentBagForPreview_File, this);//không phải ShowDialog dùng hàm nay khi chạy from độc lập ở project khác
            }
        }


        private void contextMenuStrip_ForGridView_Opening(object sender, CancelEventArgs e)
        {
            //đóng tất cả nút của menustrip lại

            int[] selRows = ((GridView)gridControlDanhSachFile.MainView).GetSelectedRows();
            btnMenuGridView_Them.Visible = false;

            //đang chọn 1 dòng trên Girdview
            if (selRows.Count() > 0)
            {
                if (currentObjectAtNode_Folder.CapDoCay == 3)
                    btnMenuGridView_Them.Visible = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        //ContextMenuStrip_ForTree   
        private void contextMenuStrip_ForTree_Opening(object sender, CancelEventArgs e)
        {
            var obj = treeListBag.GetDataRecordByNode(this.treeListBag.FocusedNode) as DigitizingBag;

            this.btnMenuTreeView_Them.Visible = false;

            if (obj != null)
            {
                //nếu là Folder Year thì cho phép thêm
                if (obj != null && !(obj.IsFile ?? false) && obj.CapDoCay == 3)
                {
                    this.btnMenuTreeView_Them.Visible = true;
                }
                else if (obj.IsFile == true)
                {
                    //đang active vào node file
                }
            }
        }

        //xóa
        private void btnMenuGridView_Xoa_Click(object sender, EventArgs e)
        {
            this.txtBlackHole.Focus();
            ////yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn xóa những dòng đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {

                    using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required,
                                     TimeSpan.FromSeconds(180)))
                    {

                        Int32[] rowHandleList = this.gridViewDanhSachFile.GetSelectedRows();
                        if (rowHandleList.Count() > 0)
                        {
                            List<Object> deleteList = new List<Object>();
                            foreach (var index in rowHandleList)
                            {
                                deleteList.Add(this.gridViewDanhSachFile.GetRow(index));
                            }
                            //
                            DigitizingBag_Factory.FullDelete(_treeBagFactory.Context, deleteList);

                            //xóa file trên server
                            PSC_ERP_Digitizing.Client.WebReference1.DigitizingService service = new PSC_ERP_Digitizing.Client.WebReference1.DigitizingService();
                            foreach (DigitizingBag item in deleteList)
                            {
                                service.QuickHelper_DeleteDocument_ByDocFileNameWithoutExtension(_publicKey, _token, item.BagId.ToString());
                            }
                        }
                        //hoàn tất
                        transaction.Complete();
                    }
                    //lưu lại vào database
                    if (_treeBagFactory.IsDirty)
                        _treeBagFactory.SaveChangesWithoutTrackingLog();

                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể xóa những dòng đang chọn!");
                }
            }

        }

        private void btnMenuGridView_Them_Click(object sender, EventArgs e)
        {
            btnMenuTreeView_Them.PerformClick();
        }
        //xem danh sách file từ menu strip
        private void btnMenuGridView_XemFile_Click(object sender, EventArgs e)
        {
            Int32[] rowHandleList = this.gridViewDanhSachFile.GetSelectedRows();
            //_currentBagForPreview_File = this.gridViewDanhSachFile.GetRow(info.RowHandle) as DigitizingBag;

            if (rowHandleList.Count() > 0)
            {
                List<DigitizingBag> dsFilePreView = new List<DigitizingBag>();
                foreach (Int32 index in rowHandleList)
                {
                    dsFilePreView.Add(this.gridViewDanhSachFile.GetRow(index) as DigitizingBag);
                }

                //frmDigitizing_PreViewFile.ShowDanhSachFile(dsFilePreView, this);
                using (frmDigitizing_Find_and_PreViewFile frm = new frmDigitizing_Find_and_PreViewFile(dsFilePreView))
                {
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Text = "Bạn Đang Xem File " + dsFilePreView[0].Name;
                    if (dsFilePreView.Count == 1)
                    {
                        frm.splitContainerControl1.Panel1.Hide();
                        frm.splitContainerControl1.SplitterPosition = 0;
                        frm.splitContainerControl1.IsSplitterFixed = true;
                    }
                    else
                    {
                        frm.groupControl_TimKiem.Visible = false;
                        frm.groupControl_TimKiem.Size = new System.Drawing.Size(0, 0);

                        frm.splitContainerControl2.Panel1.Hide();
                        frm.splitContainerControl2.SplitterPosition = 0;
                        frm.splitContainerControl2.IsSplitterFixed = true;
                    }
                    frm.ShowDialog();
                }
            }
        }

        private void btnMenuGridView_Refresh_Click(object sender, EventArgs e)
        {
            digitizingBagBindingSource_ForTree.ResetBindings(true);
        }

        private void gridViewDanhSachFile_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinDock;
using Filmstrip;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Printing;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win;
//22/01/2016
namespace PSC_ERP
{
    public partial class frmThongTinVanBan : Form
    {
        #region Properties
        Util util = new Util();
        BoPhanList _boPhanList;
        NhomVanBanList _nhomVanBanList;

        ThongTinVanBanList _thongTinVanBanList = ThongTinVanBanList.NewThongTinVanBanList();
        long _maNhomVanBan = 0;
        NhanVien _nhanvien = NhanVien.NewNhanVien();
        ThongTinNhanVienTongHop _nhanVienTongHop;
        List<FilmstripImage> images = new List<FilmstripImage>();

        bool bFind = false;
        TreeNode _nodeFind = null;

        bool bIsNode = false;
        bool bIsSeach = false;
        string strSoHoSo = string.Empty;
        private PrintDocument printDocument = new PrintDocument();
        PrintPreviewDialog prevDialog = new PrintPreviewDialog();

        int iAo = 0;

        #endregion

        #region Load
        public frmThongTinVanBan()
        {
            InitializeComponent();
        }

        #region Load danh sách có hiển thị form chờ
        private void DanhSachNhanVien_Load(object sender, DoWorkEventArgs e)
        {
            //tree_DanhSachNV.Nodes.Clear();
            //tree_DanhSachNV.Nodes.Add("root", "Danh sách nhân viên theo bộ phận");
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                TreeNode root = e.Argument as TreeNode;
                root = tree_DanhSachNV.Nodes[0];
                _boPhanList = BoPhanList.GetBoPhanListBy_All();

                foreach (BoPhan _bophan in _boPhanList)
                {
                    NhanVienList _nhanVienList = NhanVienList.GetNhanVienListBoPhan(_bophan.MaBoPhan);
                    TreeNode Node = new TreeNode(_bophan.TenBoPhan + " - " + _nhanVienList.Count + " nhân viên");
                    Node.Tag = _bophan.MaBoPhan;
                    if (tree_DanhSachNV.InvokeRequired)
                    {
                        tree_DanhSachNV.Invoke((MethodInvoker)delegate()
                        {
                            root.Nodes.Add(Node);
                            ThemNodeNhanVien(Node, _nhanVienList);
                        });
                    }
                }
            }
        }
        #endregion

        private void frmThongTinVanBan_Load(object sender, EventArgs e)
        {
            //frmWaitProcess.Wait(DanhSachNhanVien_Load);
            this.Cursor = Cursors.WaitCursor;

            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            //DanhSachNhanVien_Load(tree_DanhSachNV);
            CreateDockPanel_NhanVien();

            //sử dụng lưới ultra
            DanhSachNhanVien_Load(utree_DanhSachNV);

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region Process
        /// <summary>
        /// Load cây khi bắt đầu form
        /// </summary>
        /// <param name="TreeDanhSach"></param>
        /// <param name="SoHoSo"></param>
        private void DanhSachNhanVien_Load(TreeView TreeDanhSach)
        {
            TreeDanhSach.Nodes.Clear();
            TreeDanhSach.Nodes.Add("root", "Danh sách nhân viên theo bộ phận");
            TreeNode root = TreeDanhSach.Nodes[0];
            root.Tag = null;

            foreach (BoPhan _bophan in _boPhanList)
            {
                //NhanVienList _nhanVienList = NhanVienList.GetNhanVienListBoPhan(_bophan.MaBoPhan);
                TreeNode Node = new TreeNode(_bophan.TenBoPhan);// + " - " + _nhanVienList.Count + " nhân viên");
                Node.Tag = _bophan.MaBoPhan;
                root.Nodes.Add(Node);
                NhanVien _nhanvien = new NhanVien();
                Them1NodeNhanVien(Node, _nhanvien);
            }

            tree_DanhSachNV.Refresh();
            tree_DanhSachNV.Nodes[0].Expand();
        }

        /// <summary>
        /// Load cây khi bắt đầu form (Sử dụng Lưới Ultra)
        /// </summary>
        /// <param name="TreeDanhSach"></param>
        /// <param name="SoHoSo"></param>
        private void DanhSachNhanVien_Load(UltraTree TreeDanhSach)
        {
            TreeDanhSach.Nodes.Clear();
            TreeDanhSach.Nodes.Add("root", "Danh sách nhân viên theo bộ phận");
            UltraTreeNode root = TreeDanhSach.Nodes[0];
            root.Tag = null;

            foreach (BoPhan _bophan in _boPhanList)
            {
                //NhanVienList _nhanVienList = NhanVienList.GetNhanVienListBoPhan(_bophan.MaBoPhan);
                UltraTreeNode Node = new UltraTreeNode(_bophan.TenBoPhan);// + " - " + _nhanVienList.Count + " nhân viên");
                Node.Tag = _bophan.MaBoPhan;
                root.Nodes.Add(Node);
                ThongTinNhanVienTongHop _nhanvien = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0);
                Them1NodeNhanVien(Node, _nhanvien);
            }

            TreeDanhSach.Refresh();
            TreeDanhSach.ExpandAll();
        }

        /// <summary>
        /// Load cây khi tìm chỉ với 1 nhân viên
        /// </summary>
        /// <param name="TreeDanhSach"></param>
        /// <param name="SoHoSo"></param>
        private void DanhSachNhanVien_Load(TreeView TreeDanhSach, NhanVien _nhanVien)
        {
            TreeDanhSach.Nodes.Clear();
            TreeDanhSach.Nodes.Add("root", "Danh sách nhân viên theo bộ phận");
            TreeNode root = TreeDanhSach.Nodes[0];
            root.Tag = null;

            foreach (BoPhan _bophan in _boPhanList)
            {
                //NhanVienList _nhanVienList = NhanVienList.GetNhanVienListBoPhan(_bophan.MaBoPhan);
                TreeNode Node = new TreeNode(_bophan.TenBoPhan);// + " - " + _nhanVienList.Count + " nhân viên");
                Node.Tag = _bophan.MaBoPhan;
                root.Nodes.Add(Node);
                Them1NodeNhanVien(Node, _nhanVien);
            }

            tree_DanhSachNV.Refresh();
            tree_DanhSachNV.ExpandAll();   
        }

        /// <summary>
        /// Load cây khi tìm chỉ với 1 nhân viên (Ultra)
        /// </summary>
        /// <param name="TreeDanhSach"></param>
        /// <param name="SoHoSo"></param>
        private void DanhSachNhanVien_Load(UltraTree TreeDanhSach, ThongTinNhanVienTongHop _nhanVien)
        {
            TreeDanhSach.Nodes.Clear();
            TreeDanhSach.Nodes.Add("root", "Danh sách nhân viên theo bộ phận");
            UltraTreeNode root = TreeDanhSach.Nodes[0];
            root.Tag = null;

            foreach (BoPhan _bophan in _boPhanList)
            {
                //NhanVienList _nhanVienList = NhanVienList.GetNhanVienListBoPhan(_bophan.MaBoPhan);
                UltraTreeNode Node = new UltraTreeNode(_bophan.TenBoPhan);// + " - " + _nhanVienList.Count + " nhân viên");
                Node.Tag = _bophan.MaBoPhan;
                root.Nodes.Add(Node);
                Them1NodeNhanVien(Node, _nhanVien);
            }

            TreeDanhSach.Refresh();
            TreeDanhSach.ExpandAll();
        }

        /// <summary>
        /// Load cây theo số hồ sơ được chọn
        /// </summary>
        /// <param name="TreeDanhSach"></param>
        /// <param name="SoHoSo"></param>
        private void DanhSachNhanVien_Load(TreeView TreeDanhSach, string SoHoSo)
        {
            TreeDanhSach.Nodes.Clear();
            TreeDanhSach.Nodes.Add("root", "Danh sách nhân viên theo bộ phận");
            TreeNode root = TreeDanhSach.Nodes[0];
            root.Tag = null;

            foreach (BoPhan _bophan in _boPhanList)
            {
                //NhanVienList _nhanVienList = NhanVienList.GetNhanVienListBoPhan(_bophan.MaBoPhan);
                TreeNode Node = new TreeNode(_bophan.TenBoPhan);// + " - " + _nhanVienList.Count + " nhân viên");
                Node.Tag = _bophan.MaBoPhan;
                root.Nodes.Add(Node);
                NhanVienList nhanVienList = GetNhanvienList_Cu(_bophan.MaBoPhan, SoHoSo);
                ThemNodeNhanVien(Node, nhanVienList);
            }

            tree_DanhSachNV.Refresh();
            tree_DanhSachNV.ExpandAll();
        }

        /// <summary>
        /// Load cây theo số hồ sơ được chọn (Dùng ultra Trê)
        /// </summary>
        /// <param name="TreeDanhSach"></param>
        /// <param name="SoHoSo"></param>
        private void DanhSachNhanVien_Load(UltraTree TreeDanhSach, string SoHoSo)
        {
            TreeDanhSach.Nodes.Clear();
            TreeDanhSach.Nodes.Add("root", "Danh sách nhân viên theo bộ phận");
            UltraTreeNode root = TreeDanhSach.Nodes[0];
            root.Tag = null;

            foreach (BoPhan _bophan in _boPhanList)
            {
                //NhanVienList _nhanVienList = NhanVienList.GetNhanVienListBoPhan(_bophan.MaBoPhan);
                UltraTreeNode Node = new UltraTreeNode(_bophan.TenBoPhan);// + " - " + _nhanVienList.Count + " nhân viên");
                Node.Tag = _bophan.MaBoPhan;
                root.Nodes.Add(Node);
                ThongTinNhanVienTongHopList nhanVienList = GetNhanvienList(_bophan.MaBoPhan, SoHoSo);
                ThemNodeNhanVien(Node, nhanVienList);
            }

            TreeDanhSach.Refresh();
            TreeDanhSach.ExpandAll();
        }


        private void Them1NodeNhanVien(TreeNode ParentNode, NhanVien _nhanvien)
        {
            TreeNode Node = new TreeNode(_nhanvien.TenNhanVien + " - Mã nhân viên: " + _nhanvien.MaQLNhanVien);
            Node.Tag = _nhanvien.MaNhanVien;
            ParentNode.Nodes.Add(Node);
        }

        private void CayThongTin_Load(TreeView TreeThongTin, NhanVien _nhanVien)
        {
            TreeThongTin.Nodes.Clear();
            TreeThongTin.Nodes.Add("root", _nhanVien.TenNhanVien + " - Mã nhân viên: " + _nhanVien.MaQLNhanVien);
            TreeNode root = TreeThongTin.Nodes[0];
            root.Tag = _nhanVien.MaNhanVien;
            _nhomVanBanList = NhomVanBanList.GetNhomVanBanList(0);

            foreach (NhomVanBan _nhomVanBan in _nhomVanBanList)
            {
                TreeNode Node = new TreeNode(_nhomVanBan.TenNhomvanBan);
                Node.Tag = _nhomVanBan.MaNhomVanBan;
                root.Nodes.Add(Node);
                ThemNodeNhomVanBan(Node);
            }

            TreeThongTin.Refresh();
            TreeThongTin.Nodes[0].Expand();
        }

        private void CayThongTin_LoadSreach(TreeView TreeThongTin, NhanVien _nhanVien)
        {
            TreeThongTin.Nodes.Clear();
            TreeThongTin.Nodes.Add("root", _nhanVien.TenNhanVien + " - Mã nhân viên: " + _nhanVien.MaQLNhanVien);
            TreeNode root = TreeThongTin.Nodes[0];
            root.Tag = _nhanVien.MaNhanVien;
            _nhomVanBanList = GetNhomVanBanList(_nhanvien.MaNhanVien, strSoHoSo);

            foreach (NhomVanBan _nhomVanBan in _nhomVanBanList)
            {
                TreeNode Node = new TreeNode(_nhomVanBan.TenNhomvanBan);
                Node.Tag = _nhomVanBan.MaNhomVanBan;
                if (_nhomVanBan.MaNhomCha == 0)
                {
                    root.Nodes.Add(Node);
                }
                else
                {
                    CreateTreeView(TreeThongTin, Node);
                }

                //root.Nodes.Add(Node);
                //ThemNodeNhomVanBan(Node);
            }

            TreeThongTin.Refresh();
            TreeThongTin.ExpandAll();
        }

        private void ThemNodeNhanVien(TreeNode ParentNode, NhanVienList _nhanVienList)
        {
            foreach (NhanVien _nhanVien in _nhanVienList)
            {
                Them1NodeNhanVien(ParentNode, _nhanVien);
            }
        }

        private void ThemNodeNhomVanBan(TreeNode ParentNode)
        {
            NhomVanBanList _nhomVanBanListCon = NhomVanBanList.GetNhomVanBanList((long)ParentNode.Tag);
            foreach (NhomVanBan _nhomVanBan in _nhomVanBanListCon)
            {
                TreeNode Node = new TreeNode(_nhomVanBan.TenNhomvanBan);
                Node.Tag = _nhomVanBan.MaNhomVanBan;
                ParentNode.Nodes.Add(Node);
            }
        }

        private void CreateDockPanel_NhanVien()
        {
            DockableControlPane DSNhanVien = new DockableControlPane("DanhSach", "Danh sách nhân viên", utree_DanhSachNV);
            DSNhanVien.ToolTipCaption = "Danh sách nhân viên";
            DSNhanVien.ToolTipTab = "Danh sách nhân viên";

            DockableControlPane TTVanBan = new DockableControlPane("ThongTin", "Danh mục văn bản", utree_ThongTin);
            TTVanBan.ToolTipCaption = "Danh mục văn bản";
            TTVanBan.ToolTipTab = "Danh mục văn bản";

            DockAreaPane dockAreaPane = new DockAreaPane(DockedLocation.DockedLeft);
            dockAreaPane.Panes.AddRange(new DockablePaneBase[] { DSNhanVien, TTVanBan });
            dockAreaPane.ChildPaneStyle = ChildPaneStyle.HorizontalSplit;
            dockAreaPane.Size = new Size(300, -1);

            this.dkmu_NhanVien.DockAreas.Add(dockAreaPane);
            //iWidth = this.Width;
        }

        private void Load_ThongTinNhanVien(TreeNode Node)
        {
            if (Node != null && Node.LastNode == null && Node.Parent.Name != "root")
            {
                _nhanvien = NhanVien.GetNhanVien((long)Node.Tag);
                CayThongTin_Load(tree_ThongTin, _nhanvien);
            }
        }

        private void Load_ThongTinNhanVienSearch(TreeNode Node)
        {
            if (Node != null && Node.LastNode == null && Node.Parent.Name != "root")
            {
                _nhanvien = NhanVien.GetNhanVien((long)Node.Tag);
                CayThongTin_LoadSreach(tree_ThongTin, _nhanvien);
            }
        }

        //Hàm thêm hình ảnh vào Khung xem ảnh FilmStrip
        private void AddImage()
        {
            UltraTreeNode Node = utree_ThongTin.SelectedNodes[0];
            if (KiemTraNodeAddImage(Node))
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Chọn văn bản";
                string path = string.Empty;
                openFileDialog.Filter = "Tập tin ảnh (*.jpeg, *.jpg, *.bmp, *.png)|*.jpeg; *.jpg; *.bmp; *.png";
                openFileDialog.FileName = "";
                if (DialogResult.OK == openFileDialog.ShowDialog())
                {
                    images = new List<FilmstripImage>();
                    foreach (String file in openFileDialog.FileNames)
                    {
                        Image thisImage = Image.FromFile(file);
                        FilmstripImage newImageObject = new FilmstripImage(thisImage, file, 0);
                        images.Add(newImageObject);

                        ThongTinVanBan vanban = ThongTinVanBan.NewThongTinVanBan();
                        //vanban.HinhAnh = ImageToByte(thisImage);
                        vanban.MaThongTinNhanVien = _nhanVienTongHop.MaNhanVien;
                        vanban.MaBoPhan = _nhanVienTongHop.MaBoPhan;
                        vanban.MaNhomVanBan = _maNhomVanBan;
                        _thongTinVanBanList.Add(vanban);
                    }

                    _thongTinVanBanList.ApplyEdit();
                    _thongTinVanBanList.Save();

                    //Load_Thumbs();
                }

            }
            else
            {
                MessageBox.Show(this, "Không thể thực hiện thao tác. Dữ liệu số hóa chỉ có thể thêm vào loại văn bản quyết định.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //Kiểm tra node add Image
        private bool KiemTraNodeAddImage(UltraTreeNode Node)
        {
            if (Node == null)
                return false;
            //Nếu node không là node lá hoặc cha nó là root hoặc là root thì return false
            else if (Node.Nodes.Count != 0 || Node.Parent == null)
                return false;
            return true;
        }

        public void SetButtonStates()
        {
            tlslblXoa1File.Enabled = (filmstripControl.ImagesCollection.Length > 0) ? true : false;
            tlslblXoaTatCa.Enabled = (filmstripControl.ImagesCollection.Length > 0) ? true : false;
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void Load_Thumbs()
        {
            try
            {
                int iChon = 0;
                if (filmstripControl.SelectedImageID <= _thongTinVanBanList.Count)
                    iChon = filmstripControl.SelectedImageID;
                else if (filmstripControl.SelectedImageID != -1)
                    iChon = images.Count;
                else
                    iChon = -1;
                filmstripControl.SetImageIdBegin();
                filmstripControl.ClearAllImages(false);
                images.Clear();
                if (_thongTinVanBanList.Count > 0)
                {
                    foreach (ThongTinVanBan vb in _thongTinVanBanList)
                    {
                        ////Image thisImage = byteArrayToImage(vb.HinhAnh);
                        //Image thisImage = byteArrayToImage(vb.TenFile);
                        //FilmstripImage newImageObject = new FilmstripImage(thisImage, "", vb.MaThongTinVanBan, vb.SoHoSo, vb.NgayLap, vb.DienGiai);
                        //images.Add(newImageObject);
                    }
                    filmstripControl.AddImageRange(images.ToArray());
                    filmstripControl.ThongTinVanBanList = _thongTinVanBanList;
                    if (iChon > -1 & images.Count > iChon)
                        filmstripControl.SelectedImageID = images[iChon].Id;
                    else
                        filmstripControl.SelectedImageID = -1;
                }

                SetButtonStates();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool CanhBaoTruocKhiLuu(object sender, EventArgs e)
        {
            bool IsDirty = false;

            if (images.Count == _thongTinVanBanList.Count)
            {
                foreach (FilmstripImage img in images)
                {
                    foreach (ThongTinVanBan vanban in _thongTinVanBanList)
                    {
                        if (img.MaHinhAnh == vanban.MaThongTinVanBan)
                        {
                            if (vanban.SoHoSo != img.SoHoSo | vanban.NgayLap != img.NgayLap | vanban.DienGiai != img.DienGiai)
                            {
                                IsDirty = true;
                                break;
                            }
                        }
                    }
                    if (IsDirty)
                        break;
                }
            }

            DialogResult result = new DialogResult();
            //Nếu có thay đổi
            if(IsDirty)
                result = MessageBox.Show(this, "Dữ liệu đã được thay đổi, bạn có muốn lưu trước khi thực hiện thao tác tiếp theo ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            //Nếu lưu
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                tlslblLuu_Click(sender, e);
            }
            // Nếu dừng
            else if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return true;
            }
            return false;
        }

        private BoPhanList GetBoPhanList(string strSoHoSo)
        {
            BoPhanList _BoPhanList = BoPhanList.NewBoPhanList();
            DataTable _tblBoPhan = new DataTable();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection_Digital))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblThongTinVanBansAllBoPhan";
                    cm.Parameters.AddWithValue("@SoHoSo", strSoHoSo);

                    SqlDataAdapter adapt = new SqlDataAdapter(cm);
                    adapt.Fill(_tblBoPhan);
                }
            }

            if (_tblBoPhan.Rows.Count > 0)
            {
                foreach (DataRow row in _tblBoPhan.Rows)
                {
                    BoPhan bp = BoPhan.GetBoPhan(Convert.ToInt32(row["MaBoPhan"].ToString()));
                    _BoPhanList.Add(bp);
                }
            }
            return _BoPhanList;
        }

        private NhanVienList GetNhanvienList_Cu(int iMaBoPhan, string strSoHoSo)
        {
            NhanVienList _nhanVienList = NhanVienList.NewNhanVienList();
            DataTable _tblNhanVien = new DataTable();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection_Digital))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblThongTinVanBansAllBoPhanAndNhanVien";
                    cm.Parameters.AddWithValue("@SoHoSo", strSoHoSo);
                    cm.Parameters.AddWithValue("@MaBoPhan", iMaBoPhan);

                    SqlDataAdapter adapt = new SqlDataAdapter(cm);
                    adapt.Fill(_tblNhanVien);
                }
            }

            if (_tblNhanVien.Rows.Count > 0)
            {
                foreach (DataRow row in _tblNhanVien.Rows)
                {
                    NhanVien nv = NhanVien.GetNhanVien(Convert.ToInt32(row["MaThongTinNhanVien"].ToString()));
                    _nhanVienList.Add(nv);
                }
            }
            return _nhanVienList;
        }

        private ThongTinNhanVienTongHopList GetNhanvienList(int iMaBoPhan, string strSoHoSo)
        {
            ThongTinNhanVienTongHopList _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            DataTable _tblNhanVien = new DataTable();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection_Digital))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblThongTinVanBansAllBoPhanAndNhanVien";
                    cm.Parameters.AddWithValue("@SoHoSo", strSoHoSo);
                    cm.Parameters.AddWithValue("@MaBoPhan", iMaBoPhan);

                    SqlDataAdapter adapt = new SqlDataAdapter(cm);
                    adapt.Fill(_tblNhanVien);
                }
            }

            if (_tblNhanVien.Rows.Count > 0)
            {
                foreach (DataRow row in _tblNhanVien.Rows)
                {
                    ThongTinNhanVienTongHop nv = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(Convert.ToInt32(row["MaThongTinNhanVien"].ToString()));
                    _nhanVienList.Add(nv);
                }
            }
            return _nhanVienList;
        }

        private void Load_DanhSachAnh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                filmstripControl.ClearControl();
                TreeNode Node = tree_ThongTin.SelectedNode;
                if (Node != null)
                {
                    if (Node.Tag != null)
                    {
                        _maNhomVanBan = Convert.ToInt64(Node.Tag);
                        if (!bIsSeach)
                            _thongTinVanBanList = ThongTinVanBanList.GetThongTinVanBanList(_maNhomVanBan, _nhanvien.MaNhanVien, 0);
                        else
                            _thongTinVanBanList = ThongTinVanBanList.GetThongTinVanBanList(_maNhomVanBan, _nhanvien.MaNhanVien, strSoHoSo, 0);


                        filmstripControl.SetImageIdBegin();
                        //Loads Thumbs
                        //Load_Thumbs();
                    }
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Load_DanhSachAnhUltra()
        {
            try
            {
                if (utree_ThongTin.SelectedNodes.Count != 0)
                {
                    this.Cursor = Cursors.WaitCursor;

                    filmstripControl.ClearControl();
                    UltraTreeNode Node = utree_ThongTin.SelectedNodes[0];
                    if (Node != null)
                    {
                        if (Node.Tag != null)
                        {
                            _maNhomVanBan = Convert.ToInt64(Node.Tag);
                            if (!bIsSeach)
                                _thongTinVanBanList = ThongTinVanBanList.GetThongTinVanBanList(_maNhomVanBan, _nhanVienTongHop.MaNhanVien, 0);
                            else
                                _thongTinVanBanList = ThongTinVanBanList.GetThongTinVanBanList(_maNhomVanBan, _nhanVienTongHop.MaNhanVien, strSoHoSo, 0);


                            filmstripControl.SetImageIdBegin();
                            //Loads Thumbs
                            //Load_Thumbs();
                        }
                    }

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private NhomVanBanList GetNhomVanBanList(long iMaNhanVien, string strSoHoSo)
        {
            NhomVanBanList _NhoMVanBanList = NhomVanBanList.NewNhomVanBanList();
            DataTable _tblNhomVanBan = new DataTable();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection_Digital))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblThongTinVanBansAllNhomVanBan";
                    cm.Parameters.AddWithValue("@SoHoSo", strSoHoSo);
                    cm.Parameters.AddWithValue("@MaNhanVien", iMaNhanVien);

                    SqlDataAdapter adapt = new SqlDataAdapter(cm);
                    adapt.Fill(_tblNhomVanBan);
                }
            }

            if (_tblNhomVanBan.Rows.Count > 0)
            {
                foreach (DataRow row in _tblNhomVanBan.Rows)
                {
                    NhomVanBan vb = NhomVanBan.GetNhomVanBan(Convert.ToInt32(row["MaNhomVanBan"].ToString()));
                    _NhoMVanBanList.Add(vb);
                }
            }
            return _NhoMVanBanList;
        }

        private void CreateTreeView(TreeView tree, TreeNode Node)
        {

            TreeNode NodeCha;
            if (KiemTraNodeChaTonTai(tree, Node) != null)
            {
                KiemTraNodeTonTai(tree.Nodes[0], Node);
                if (!bFind)
                {
                    NodeCha = KiemTraNodeChaTonTai(tree, Node);
                    NodeCha.Nodes.Add(Node);
                }
            }
            else
            {

                NhomVanBan _nhomVanBan = NhomVanBan.GetNhomVanBan((long)Node.Tag);
                NhomVanBan _nhomVanBanCha = NhomVanBan.GetNhomVanBan(_nhomVanBan.MaNhomCha);
                if (TimNode(tree.Nodes[0], _nhomVanBan.MaNhomCha) != null)
                {
                    NodeCha = TimNode(tree.Nodes[0], _nhomVanBan.MaNhomCha);
                }
                else
                {
                    NodeCha = new TreeNode(_nhomVanBanCha.TenNhomvanBan);
                    NodeCha.Tag = _nhomVanBanCha.MaNhomVanBan;
                }

                KiemTraNodeTonTai(tree.Nodes[0], NodeCha);
                if (bFind)
                {
                    NodeCha.Nodes.Add(Node);
                }
                else
                {
                    NodeCha.Nodes.Add(Node);
                }
                CreateTreeView(tree, NodeCha);
            }
        }

        private TreeNode KiemTraNodeChaTonTai(TreeView tree, TreeNode Node)
        {
            NhomVanBan _nhomVanBan = NhomVanBan.GetNhomVanBan((long)Node.Tag);
            if (_nhomVanBan.MaNhomCha == 0)
                return tree.Nodes[0];
            NhomVanBan _nhomVanBanCha = NhomVanBan.GetNhomVanBan(_nhomVanBan.MaNhomCha);

            foreach (TreeNode node in tree.Nodes)
            {
                if ((long)node.Tag == _nhomVanBanCha.MaNhomVanBan)
                {
                    return node;
                }
            }
            return null;
        }

        private void KiemTraNodeTonTai(TreeNode node, TreeNode NodeFind)
        {
            foreach (TreeNode n in node.Nodes)
            {
                if ((long)n.Tag == (long)NodeFind.Tag)
                {
                    bFind = true;
                    _nodeFind = n;
                    return;
                }
                else
                {
                    bFind = false;
                    KiemTraNodeTonTai(n, NodeFind);
                }
            }
            if (node.Nodes.Count == 0)
            {
                bFind = false;
            }
        }

        private TreeNode TimNode(TreeNode node, long NodeFind)
        {
            foreach (TreeNode n in node.Nodes)
            {
                if ((long)n.Tag == NodeFind)
                {
                    return n;
                }
                else
                {
                    TimNode(n, NodeFind);
                }
            }
            return null;
        }

        private TreeNode GetNodeCha(TreeView tree, TreeNode Node)
        {
            if (Node == null)
                return Node;
            NhomVanBan _nhomVanBanCha = NhomVanBan.GetNhomVanBan((long)Node.Tag);
            foreach (TreeNode node in tree.Nodes)
            {
                if ((long)node.Tag == _nhomVanBanCha.MaNhomCha)
                {
                    return node;
                }
            }
            if (_nhomVanBanCha.MaNhomCha == 0)
                return tree.Nodes[0];
            return null;
        }

        #endregion

        #region Events
        private void tree_DanhSachNV_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (!bIsSeach)
                Load_ThongTinNhanVien(tree_DanhSachNV.SelectedNode);
            else
                Load_ThongTinNhanVienSearch(tree_DanhSachNV.SelectedNode);
            filmstripControl.ClearAllImages(false);

            this.Cursor = Cursors.Default;
        }

        private void tree_DanhSachNV_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (tree_DanhSachNV.SelectedNode != null && tree_DanhSachNV.SelectedNode.LastNode != null)
            {
                this.Cursor = Cursors.WaitCursor;

                TreeNode Node = e.Node;
                if (Node.Tag == null)
                    return;
                else
                {
                    if ((long)Node.LastNode.Tag == 0)
                    {
                        Node.LastNode.Remove();
                        int iMaBoPhan = (int)Node.Tag;
                        NhanVienList _nhanVienList = NhanVienList.GetNhanVienListBoPhan(iMaBoPhan);
                        if (_nhanVienList.Count > 0)
                            ThemNodeNhanVien(Node, _nhanVienList);
                    }
                    else
                    { }

                }

                this.Cursor = Cursors.Default;
            }
        }

        private void tree_ThongTin_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode Node = this.tree_ThongTin.GetNodeAt(e.Location);
                tree_ThongTin.SelectedNode = Node;
                if (Node != null)
                {
                    if (Node.Tag == null)
                    { return; }
                    //else if (Node.Name == "root")
                    //{
                    //    this.contextMenuStrip.Items["mnu_ThemNhomVB"].Enabled = true;
                    //    this.contextMenuStrip.Items["mnu_ThemLoaiVB"].Enabled = false;
                    //    this.contextMenuStrip.Items["mnu_ThemDL"].Enabled = false;
                    //}
                    //else if (Node.Parent.Name == "root")
                    //{
                    //    this.contextMenuStrip.Items["mnu_ThemNhomVB"].Enabled = false;
                    //    this.contextMenuStrip.Items["mnu_ThemLoaiVB"].Enabled = true;
                    //    this.contextMenuStrip.Items["mnu_ThemDL"].Enabled = false;
                    //}
                    //else if (Node.Parent.Name != "root")
                    //{
                    //    this.contextMenuStrip.Items["mnu_ThemNhomVB"].Enabled = false;
                    //    this.contextMenuStrip.Items["mnu_ThemLoaiVB"].Enabled = false;
                    //    this.contextMenuStrip.Items["mnu_ThemDL"].Enabled = true;
                    //}
                    this.contextMenuStrip.Show(this.tree_ThongTin, e.Location);
                    bIsNode = true;
                }
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (!bIsNode)
                e.Cancel = true;
            else
                bIsNode = false;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnu_ThemNhomVB_Click(object sender, EventArgs e)
        {
            TreeNode Node = tree_DanhSachNV.SelectedNode;

            frmNhomVanBan frm = new frmNhomVanBan();
            frm.ShowDialog();

            Load_ThongTinNhanVien(Node);
        }

        private void mnu_ThemLoaiVB_Click(object sender, EventArgs e)
        {
        }

        private void mnu_ThemDL_Click(object sender, EventArgs e)
        {
            AddImage();
        }

        private void tlslblThemDuLieu_Click(object sender, EventArgs e)
        {
            AddImage();
        }

        private void tlslblXoa1File_Click(object sender, EventArgs e)
        {
            if (images.Count <= 0 || filmstripControl.SelectedImageID <= 0)
            {
                MessageBox.Show(this, "Không có ảnh nào đang được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Xóa hình đang chọn
            filmstripControl.RemoveImage(filmstripControl.SelectedImageID);
            if (filmstripControl.ImagesCollectionCount != 0)
                filmstripControl.SelectedImageID = filmstripControl.ImagesCollection[0].Id;
            else
                filmstripControl.SelectedImageID = -1;
            SetButtonStates();
        }

        private void tlslblXoaTatCa_Click(object sender, EventArgs e)
        {
            filmstripControl.ClearAllImages(true);
            SetButtonStates();
        }

        private void mnu_ThongTinVanBan_Click(object sender, EventArgs e)
        {
            dkmu_NhanVien.ShowAll();
        }

        private void filmstripControl_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void frmThongTinVanBan_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void filmstripControl_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode Node = tree_ThongTin.SelectedNode;
                if (Node != null)
                {
                    if (Node.Tag == null)
                    { return; }
                    else if (Node.LastNode == null && Node.Parent.Name != "root")
                    {
                        this.contextMenuStrip.Items["mnu_ThemNhomVB"].Enabled = false;
                        this.contextMenuStrip.Items["mnu_ThemLoaiVB"].Enabled = false;
                        this.contextMenuStrip.Items["mnu_ThemDL"].Enabled = true;
                    }
                    else
                    {
                        this.contextMenuStrip.Items["mnu_ThemNhomVB"].Enabled = false;
                        this.contextMenuStrip.Items["mnu_ThemLoaiVB"].Enabled = true;
                        this.contextMenuStrip.Items["mnu_ThemDL"].Enabled = false;
                    }
                    this.contextMenuStrip.Show(this.tree_ThongTin, e.Location);
                    bIsNode = true;
                }
            }
        }

        private void tree_ThongTin_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (CanhBaoTruocKhiLuu(sender, e))
                    return;
                Load_DanhSachAnh();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            int SoLuongAnh = images.Count;
            if (keyData == Keys.Left)
            {
                //Preview image
                if (filmstripControl.SelectedImageID <= 1)
                {
                    return true;
                }
                else
                {
                    filmstripControl.SelectedImageID -= 1;
                }
                return true;
            }
            else if (keyData == Keys.Right)
            {
                //Next image
                //Preview image
                if (filmstripControl.SelectedImageID >= SoLuongAnh)
                {
                    return true;
                }
                else
                {
                    filmstripControl.SelectedImageID += 1;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            if (CanhBaoTruocKhiLuu(sender, e))
                return;
            Load_DanhSachAnh();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (images.Count == _thongTinVanBanList.Count)
                {
                    foreach (FilmstripImage img in images)
                    {
                        foreach (ThongTinVanBan vanban in _thongTinVanBanList)
                        {
                            if (img.MaHinhAnh == vanban.MaThongTinVanBan)
                            {
                                vanban.SoHoSo = img.SoHoSo;
                                vanban.NgayLap = img.NgayLap;
                                vanban.DienGiai = img.DienGiai;
                                vanban.MaThongTinNhanVien = _nhanVienTongHop.MaNhanVien;
                                vanban.MaBoPhan = _nhanVienTongHop.MaBoPhan;
                                vanban.MaNhomVanBan = _maNhomVanBan;
                            }
                        }
                    }
                }
                else
                {
                    //Từ từ tính
                }
                _thongTinVanBanList.ApplyEdit();
                _thongTinVanBanList.Save();

                MessageBox.Show(this, "Đã lưu dữ liệu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void tlslblFind_Click(object sender, EventArgs e)
        {
            frmDigitalFind frm = new frmDigitalFind();
            bIsSeach = false;
            if (frm.ShowDialog(this) != DialogResult.OK)
            {
                if (frm.bNhanVien)
                {
                    if (frm.maBophan != 0 && frm.maNhanVien != 0)
                    {
                        _boPhanList = BoPhanList.GetBoPhan(frm.maBophan);
                        _nhanvien = NhanVien.GetNhanVien(frm.maNhanVien);

                        DanhSachNhanVien_Load(tree_DanhSachNV, _nhanvien);
                        CayThongTin_Load(tree_ThongTin, _nhanvien);

                        //Ultra
                        _nhanVienTongHop = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(frm.maNhanVien);
                        DanhSachNhanVien_Load(utree_DanhSachNV, _nhanVienTongHop);
                        CayThongTin_Load(utree_ThongTin, _nhanVienTongHop);
                    }
                }
                else
                {
                    if (frm.soHoSo != string.Empty)
                    {
                        _boPhanList = GetBoPhanList(frm.soHoSo);
                        if (_boPhanList.Count <= 0)
                        {
                            frm.soHoSo = string.Empty;
                            MessageBox.Show(this, "Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            bIsSeach = true;
                            tree_ThongTin.Nodes.Clear();
                            filmstripControl.ClearAllImages(false);
                            DanhSachNhanVien_Load(tree_DanhSachNV, frm.soHoSo);

                            //Ultra
                            utree_ThongTin.Nodes.Clear();
                            DanhSachNhanVien_Load(utree_DanhSachNV, frm.soHoSo);
                        }
                    }
                }

                if ((frm.maBophan == 0 && frm.maNhanVien == 0 && frm.bNhanVien) | (frm.soHoSo == string.Empty & !frm.bNhanVien))
                {
                    tree_ThongTin.Nodes.Clear();
                    filmstripControl.ClearAllImages(false);
                    _boPhanList = BoPhanList.GetBoPhanListBy_All();
                    DanhSachNhanVien_Load(tree_DanhSachNV);
                    tree_DanhSachNV.SelectedNode = tree_DanhSachNV.Nodes[0];

                    utree_ThongTin.Nodes.Clear();
                    DanhSachNhanVien_Load(utree_DanhSachNV);
                    //utree_DanhSachNV.SelectedNodes. = utree_DanhSachNV.Nodes[0];
                }
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {

            //printDocument.BeginPrint += new PrintEventHandler(OnBeginPrint);
            //printDocument.PrintPage += new PrintPageEventHandler(OnPrintPage);

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printDocument.DocumentName = "In hồ sơ nhân viên";
            prevDialog.Document = printDocument;
            prevDialog.ShowDialog();

        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = 0;
            float y = 0;
            if (filmstripControl.SelectedImageMaHinhAnh > 1 & filmstripControl.SelectedImageMaHinhAnh != null)
            {
                ThongTinVanBan vanban = ThongTinVanBan.GetThongTinVanBan(filmstripControl.SelectedImageMaHinhAnh);
                //e.Graphics.DrawImage(byteArrayToImage(vanban.HinhAnh), x, y);
            }
        }
        #endregion

        #region Sử dụng UltraTree
        private void Them1NodeNhanVien(UltraTreeNode ParentNode, ThongTinNhanVienTongHop _nhanvien)
        {
            UltraTreeNode Node = new UltraTreeNode(_nhanvien.TenNhanVien + " - Mã nhân viên: " + _nhanvien.MaQLNhanVien);
            if (_nhanvien.MaNhanVien != 0)
                Node.Tag = _nhanvien.MaNhanVien;
            else
            {
                iAo++;
                Node.Key += iAo.ToString();
            }
            ParentNode.Nodes.Add(Node);
        }

        private void ThemNodeNhanVien(UltraTreeNode ParentNode, ThongTinNhanVienTongHopList _nhanVienList)
        {
            foreach (ThongTinNhanVienTongHop _nhanVien in _nhanVienList)
            {
                Them1NodeNhanVien(ParentNode, _nhanVien);
            }
        }

        private void tree_DanhSachNV_BeforeExpand(object sender, Infragistics.Win.UltraWinTree.CancelableNodeEventArgs e)
        {
            UltraTreeNode Node = e.TreeNode;
            if (Node.Tag != null)
            {
                this.Cursor = Cursors.WaitCursor;

                if (Node.Tag == null)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
                else
                {
                    if (Node.Nodes.Count <= 0)
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    if (Node.Nodes[0].Tag == null)
                    {
                        Node.Nodes[0].Remove();
                        int iMaBoPhan = (int)Node.Tag;
                        ThongTinNhanVienTongHopList _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ByBophan(iMaBoPhan);
                        if (_nhanVienList.Count > 0)
                            ThemNodeNhanVien(Node, _nhanVienList);
                    }
                    else
                    { }

                }

                this.Cursor = Cursors.Default;
            }
        }

        private void utree_DanhSachNV_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (!bIsSeach)
                Load_ThongTinNhanVien(utree_DanhSachNV.SelectedNodes[0]);
            else
                Load_ThongTinNhanVienSearch(utree_DanhSachNV.SelectedNodes[0]);
            filmstripControl.ClearAllImages(false);

            this.Cursor = Cursors.Default;
        }

        private void Load_ThongTinNhanVien(UltraTreeNode Node)
        {
            if (Node != null && Node.Nodes.Count == 0)
            {
                _nhanVienTongHop = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop((long)Node.Tag);
                CayThongTin_Load(utree_ThongTin, _nhanVienTongHop);
            }
        }

        private void Load_ThongTinNhanVienSearch(UltraTreeNode Node)
        {
            if (Node != null && Node.Nodes.Count == 0)
            {
                _nhanVienTongHop = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop((long)Node.Tag);
                CayThongTin_LoadSreach(utree_ThongTin, _nhanVienTongHop);
            }
        }

        private void CayThongTin_Load(UltraTree TreeThongTin, ThongTinNhanVienTongHop _nhanVien)
        {
            TreeThongTin.Nodes.Clear();
            TreeThongTin.Nodes.Add("root", _nhanVien.TenNhanVien + " - Mã nhân viên: " + _nhanVien.MaQLNhanVien);
            UltraTreeNode root = TreeThongTin.Nodes[0];
            root.Tag = _nhanVien.MaNhanVien;
            _nhomVanBanList = NhomVanBanList.GetNhomVanBanList(0);

            foreach (NhomVanBan _nhomVanBan in _nhomVanBanList)
            {
                UltraTreeNode Node = new UltraTreeNode(_nhomVanBan.TenNhomvanBan);
                Node.Tag = _nhomVanBan.MaNhomVanBan;
                root.Nodes.Add(Node);
                ThemNodeNhomVanBan(Node);
            }

            TreeThongTin.Refresh();
            TreeThongTin.Nodes[0].ExpandAll();
        }

        private void CayThongTin_LoadSreach(UltraTree TreeThongTin, ThongTinNhanVienTongHop _nhanVien)
        {
            TreeThongTin.Nodes.Clear();
            TreeThongTin.Nodes.Add("root", _nhanVien.TenNhanVien + " - Mã nhân viên: " + _nhanVien.MaQLNhanVien);
            UltraTreeNode root = TreeThongTin.Nodes[0];
            root.Tag = _nhanVien.MaNhanVien;
            _nhomVanBanList = GetNhomVanBanList(_nhanvien.MaNhanVien, strSoHoSo);

            foreach (NhomVanBan _nhomVanBan in _nhomVanBanList)
            {
                UltraTreeNode Node = new UltraTreeNode(_nhomVanBan.TenNhomvanBan);
                Node.Tag = _nhomVanBan.MaNhomVanBan;
                if (_nhomVanBan.MaNhomCha == 0)
                {
                    root.Nodes.Add(Node);
                }
                else
                {
                    CreateTreeView(TreeThongTin, Node);
                }

                //root.Nodes.Add(Node);
                //ThemNodeNhomVanBan(Node);
            }

            TreeThongTin.Refresh();
            TreeThongTin.ExpandAll();
        }

        private void ThemNodeNhomVanBan(UltraTreeNode ParentNode)
        {
            NhomVanBanList _nhomVanBanListCon = NhomVanBanList.GetNhomVanBanList((long)ParentNode.Tag);
            foreach (NhomVanBan _nhomVanBan in _nhomVanBanListCon)
            {
                UltraTreeNode Node = new UltraTreeNode(_nhomVanBan.TenNhomvanBan);
                Node.Tag = _nhomVanBan.MaNhomVanBan;
                ParentNode.Nodes.Add(Node);
            }
        }

        private void CreateTreeView(UltraTree tree, UltraTreeNode Node)
        {

            UltraTreeNode NodeCha;
            if (KiemTraNodeChaTonTai(tree, Node) != null)
            {
                KiemTraNodeTonTai(tree.Nodes[0], Node);
                if (!bFind)
                {
                    NodeCha = KiemTraNodeChaTonTai(tree, Node);
                    NodeCha.Nodes.Add(Node);
                }
            }
            else
            {

                NhomVanBan _nhomVanBan = NhomVanBan.GetNhomVanBan((long)Node.Tag);
                NhomVanBan _nhomVanBanCha = NhomVanBan.GetNhomVanBan(_nhomVanBan.MaNhomCha);
                if (TimNode(tree.Nodes[0], _nhomVanBan.MaNhomCha) != null)
                {
                    NodeCha = TimNode(tree.Nodes[0], _nhomVanBan.MaNhomCha);
                }
                else
                {
                    NodeCha = new UltraTreeNode(_nhomVanBanCha.TenNhomvanBan);
                    NodeCha.Tag = _nhomVanBanCha.MaNhomVanBan;
                }

                KiemTraNodeTonTai(tree.Nodes[0], NodeCha);
                if (bFind)
                {
                    NodeCha.Nodes.Add(Node);
                }
                else
                {
                    NodeCha.Nodes.Add(Node);
                }
                CreateTreeView(tree, NodeCha);
            }
        }

        private UltraTreeNode KiemTraNodeChaTonTai(UltraTree tree, UltraTreeNode Node)
        {
            NhomVanBan _nhomVanBan = NhomVanBan.GetNhomVanBan((long)Node.Tag);
            if (_nhomVanBan.MaNhomCha == 0)
                return tree.Nodes[0];
            NhomVanBan _nhomVanBanCha = NhomVanBan.GetNhomVanBan(_nhomVanBan.MaNhomCha);

            foreach (UltraTreeNode node in tree.Nodes)
            {
                if ((long)node.Tag == _nhomVanBanCha.MaNhomVanBan)
                {
                    return node;
                }
            }
            return null;
        }


        UltraTreeNode _NodeFind;
        private void KiemTraNodeTonTai(UltraTreeNode node, UltraTreeNode NodeFind)
        {
            foreach (UltraTreeNode n in node.Nodes)
            {
                if ((long)n.Tag == (long)NodeFind.Tag)
                {
                    bFind = true;
                    _NodeFind = n;
                    return;
                }
                else
                {
                    bFind = false;
                    KiemTraNodeTonTai(n, NodeFind);
                }
            }
            if (node.Nodes.Count == 0)
            {
                bFind = false;
            }
        }

        private UltraTreeNode TimNode(UltraTreeNode node, long NodeFind)
        {
            foreach (UltraTreeNode n in node.Nodes)
            {
                if ((long)n.Tag == NodeFind)
                {
                    return n;
                }
                else
                {
                    TimNode(n, NodeFind);
                }
            }
            return null;
        }

        private UltraTreeNode GetNodeCha(UltraTreeNode tree, UltraTreeNode Node)
        {
            if (Node == null)
                return Node;
            NhomVanBan _nhomVanBanCha = NhomVanBan.GetNhomVanBan((long)Node.Tag);
            foreach (UltraTreeNode node in tree.Nodes)
            {
                if ((long)node.Tag == _nhomVanBanCha.MaNhomCha)
                {
                    return node;
                }
            }
            if (_nhomVanBanCha.MaNhomCha == 0)
                return tree.Nodes[0];
            return null;
        }

        private void tree_ThongTin_AfterSelect(object sender, SelectEventArgs e)
        {
            try
            {
                if (CanhBaoTruocKhiLuu(sender, e))
                    return;
                Load_DanhSachAnhUltra();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void utree_ThongTin_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                UltraTree tree = sender as UltraTree;
                UltraTreeNode node = tree.GetNodeFromPoint(e.Location);

                if ( node != null )
                {
                    this.contextMenuStrip.Show(this.utree_ThongTin, e.Location);
                    node.Selected = true;
                    bIsNode = true;
                }
                
            }
        }
    }
}

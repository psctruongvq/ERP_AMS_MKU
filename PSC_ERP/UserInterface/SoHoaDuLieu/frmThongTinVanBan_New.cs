using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinDock;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Printing;
using Infragistics.Win.UltraWinTree;
using PSC_ERP_Common;
using PSC_ERP_Digitizing.Client.WebReference1;
using PSC_ERP.UserInterface.SoHoaDuLieu;

namespace PSC_ERP
{
    public partial class frmThongTinVanBan_New : Form
    {
        #region Properties
        Util util = new Util();
        BoPhanList _boPhanList;
        NhomVanBanList _nhomVanBanList;

        String _publicKey = "gi cung duoc";
        String _token = null;

        ThongTinVanBanList _thongTinVanBanList = ThongTinVanBanList.NewThongTinVanBanList();
        long _maNhomVanBan = 0;
        NhanVien _nhanvien = NhanVien.NewNhanVien();
        ThongTinNhanVienTongHop _nhanVienTongHop;
        ThongTinVanBan _ThongTinVanBanCurrent;

        bool bFind = false;
        TreeNode _nodeFind = null;

        bool bIsNode = false;
        bool bIsSeach = false;
        bool loadFile = false;
        string strSoHoSo = string.Empty;
        private PrintDocument printDocument = new PrintDocument();
        PrintPreviewDialog prevDialog = new PrintPreviewDialog();

        UltraTreeNode _NodeCurrent = null;

        UltraTreeNode _NodeFind;

        string strTenEdit = string.Empty;
        int iAo = 0;

        AxAcroPDFLib.AxAcroPDF pdf = new AxAcroPDFLib.AxAcroPDF();

        #endregion

        #region Load
        public frmThongTinVanBan_New()
        {
            InitializeComponent();
            _token = PSC_ERPNew.Main.PhanHe.DIGITIZING.Helper.MakeToken(publicKey: _publicKey, secretKey: "pscvietnam@hoasua");
        }

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
                Node.Override.NodeAppearance.Image = imageList_PDF.Images["group"];

                ThongTinNhanVienTongHop _nhanvien = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0);
                Them1NodeNhanVien(Node, _nhanvien);
            }

            TreeDanhSach.Refresh();
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
                //Node.Tag = _nhanvien.MaNhanVien;
                Node.Override.NodeAppearance.Image = imageList_PDF.Images["group"];

                root.Nodes.Add(Node);
                Them1NodeNhanVien(Node, _nhanVien);
            }

            TreeDanhSach.Refresh();
            TreeDanhSach.ExpandAll();
        }

        /// <summary>
        /// Load cây theo số hồ sơ được chọn (Dùng ultra Tree)
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
                Node.Override.NodeAppearance.Image = imageList_PDF.Images["group"];

                ThongTinNhanVienTongHopList nhanVienList = GetNhanvienList(_bophan.MaBoPhan, SoHoSo);
                ThemNodeNhanVien(Node, nhanVienList);
            }

            TreeDanhSach.Refresh();
            TreeDanhSach.ExpandAll();
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

        //Kiểm tra node xem có phải là node NHÓM VĂN BẢN và đồng thời là nút lá hay không
        private bool KiemTraNodeAddImage(UltraTreeNode Node)
        {
            NhomVanBan _nhomVB = NhomVanBan.GetNhomVanBan((long)Node.Tag);
            NhomVanBanList _nhomVBCon = NhomVanBanList.GetNhomVanBanList(_nhomVB.MaNhomVanBan);
            //if (_nhomVB.MaNhomVanBan == 0 | _nhomVBCon.Count > 0 | _nhomVB.TenNhomvanBan != Node.Key)
            if (_nhomVB.MaNhomVanBan == 0 | _nhomVB.TenNhomvanBan != Node.Key)
                return false;
            return true;
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

        private void ThemNodeNhomVanBan(UltraTreeNode ParentNode)
        {
            try
            {
                NhomVanBanList _nhomVanBanListCon = NhomVanBanList.GetNhomVanBanList((long)ParentNode.Tag);
                //if (_nhomVanBanListCon.Count >0) //sửa ngày 14/03/2016 cho load toàn bộ file không nhất thiết phải là nút lá
                //{
                foreach (NhomVanBan _nhomVanBan in _nhomVanBanListCon)
                {
                    UltraTreeNode Node = new UltraTreeNode(_nhomVanBan.TenNhomvanBan) { Tag = _nhomVanBan.MaNhomVanBan };
                    Node.Override.NodeAppearance.Image = imageList_PDF.Images["folder"];
                    ParentNode.Nodes.Add(Node);
                    ThemNodeNhomVanBan(Node);
                }
                //} //sửa ngày 14/03/2016
                //else
                //{
                _maNhomVanBan = Convert.ToInt64(ParentNode.Tag);
                if (!bIsSeach)
                {
                    _thongTinVanBanList = ThongTinVanBanList.GetThongTinVanBanList(_maNhomVanBan, _nhanVienTongHop.MaNhanVien, 0);
                }
                else
                {
                    _thongTinVanBanList = ThongTinVanBanList.GetThongTinVanBanList(_maNhomVanBan, _nhanVienTongHop.MaNhanVien, strSoHoSo, 0);
                }
                //_thongTinVanBanList = ThongTinVanBanList.GetThongTinVanBanList(_maNhomVanBan, _nhanVienTongHop.MaNhanVien, 0);

                foreach (ThongTinVanBan vb in _thongTinVanBanList)
                {
                    UltraTreeNode Node = new UltraTreeNode(vb.SoHoSo) { Tag = vb.MaThongTinVanBan };
                    Node.Override.NodeAppearance.Image = imageList_PDF.Images["pdf1"];
                    Node.LeftImages.Tag = 1;
                    ParentNode.Nodes.Add(Node);
                }
                //}
            }
            catch
            {
                throw;
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

        /// <summary>
        /// Đọc một file lên
        /// </summary>
        private void ReadFile()
        {
            //Mở file để đọc 
            FileStream fs = new FileStream("test.txt", FileMode.Open);
            StreamReader r = new StreamReader(fs, Encoding.UTF8);
            // Đọc nội dung file và in ra màn hình 
            Console.WriteLine(Decimal.Parse(r.ReadLine()));
            Console.WriteLine(r.ReadLine());
            Console.WriteLine(Char.Parse(r.ReadLine()));

            r.Close();
            fs.Close();
        }

        /// <summary>
        /// Lưu lại file
        /// </summary>
        private void SaveFile()
        {
            FileStream fs = new FileStream("test.txt", FileMode.Create);
            // Khai báo biến w để ghi với định dạng Unicode UTF8 
            StreamWriter w = new StreamWriter(fs, Encoding.UTF8);
            // Ghi nội dung vào file 
            w.WriteLine("soctrangit.net");
            w.WriteLine("Diễn đàn công nghệ thông tin Sóc Trăng");
            w.WriteLine("Chia sẽ kiến thức - Mở cửa tương lai");
            w.Flush();
            w.Close();
            fs.Close();
        }

        /// <summary>
        /// Function to get byte array from a file
        /// </summary>
        /// <param name="_FileName">File name to get byte array</param>
        /// <returns>Byte Array</returns>
        public byte[] FileToByteArray(string _FileName)
        {
            byte[] _Buffer = null;

            try
            {
                // Open file for reading
                FileStream _FileStream = new FileStream(_FileName, FileMode.Open, FileAccess.Read);

                // attach filestream to binary reader
                BinaryReader _BinaryReader = new BinaryReader(_FileStream);

                // get total byte length of the file
                long _TotalBytes = new FileInfo(_FileName).Length;

                // read entire file into buffer
                _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);

                // close file reader
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            return _Buffer;
        }

        //private void SaveFilePDF()
        //{
        //    using (StreamWriter sWriter = new StreamWriter("file.pdf"))
        //    {
        //        BinaryWriter writer = new BinaryWriter(sWriter.BaseStream);
        //        writer.Write(myArray);
        //        writer.Close();

        //    }
        //}

        //Hàm thêm hình ảnh vào Khung xem ảnh FilmStrip
        private void AddFile()
        {
            if (KiemTraNodeAddImage(_NodeCurrent))
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Chọn văn bản";
                string strChuoi = string.Empty;
                openFileDialog.Filter = "Tập tin PDF (*.pdf)|*.pdf";
                openFileDialog.FileName = "";
                if (DialogResult.OK == openFileDialog.ShowDialog())
                {
                    double viTriMax = ThongTinVanBan.GetMaxMViTri_By_NhanVienAndLoaiVanBan(_nhanVienTongHop.MaNhanVien, _maNhomVanBan);
                    foreach (String file in openFileDialog.FileNames)
                    {
                        string namefile = Path.GetFileNameWithoutExtension(file);
                        //Kiểm tra xem các file đưa vào có bị trùng với dữ liệu hiện có hay không.
                        bool bExist = KiemTraSoHoSo(namefile);
                        //bExist = KiemTraSoHoSo(_nhanVienTongHop.MaNhanVien.ToString() + "_" + namefile);
                        if (bExist && !KiemTraSoHoSoVaTenNhomVanBan(namefile))
                        {
                            ThongTinVanBan vanban = ThongTinVanBan.NewThongTinVanBan();
                            //vanban.TenFile = namefile;                          
                            vanban.TenFile = string.Format("{0}_{1}NS", _nhanVienTongHop.MaNhanVien, namefile);
                            vanban.MaThongTinNhanVien = _nhanVienTongHop.MaNhanVien;
                            vanban.MaBoPhan = _nhanVienTongHop.MaBoPhan;
                            vanban.MaNhomVanBan = _maNhomVanBan;

                            vanban.ViTri = ++viTriMax;
                            //vanban.SoHoSo = vanban.TenFile;
                            vanban.SoHoSo = namefile;
                            //vanban.ViTri = vt + 1;
                            //double _viTriMax = ThongTinVanBanList.get
                            //upload từng file
                            //var task = TaskUtil.InvokeCrossThread(this, () =>
                            //{
                            using (DialogUtil.Wait(this, "Đang upload...", "Vui lòng chờ!"))
                            {
                                //up load
                                String extension = Path.GetExtension(file);
                                if (UploadFile(_publicKey, _token, file, vanban.TenFile + extension))
                                {
                                    _thongTinVanBanList.Add(vanban);
                                    //Lưu lại nhưng tập tin không bị trùng
                                    //_thongTinVanBanList.ApplyEdit();
                                    //_thongTinVanBanList.Save();
                                }
                            }
                            //});
                        }
                        else
                        {
                            //Nếu bị trùng thi lưu vào chuỗi để xuất ra cảnh bảo
                            if (strChuoi != string.Empty)
                                strChuoi += "\n ";
                            strChuoi += namefile;
                        }
                    }

                    //Nếu có file bị trùng thì xuất ra thông báo
                    if (strChuoi != string.Empty)
                    {
                        //ialogResult result = MessageBox.Show(this, "Các tập tin sau đã tồn tại trong thông tin: " + strChuoi + ".", "Lưu ý",);
                        MessageBox.Show(this, string.Format("Các tập tin sau đã tồn tại\nHay tên không hợp lệ trùng tên với tên nhóm hồ sơ: \n{0}\nVui lòng đổi tên file!", strChuoi), "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    //Lưu lại nhưng tập tin không bị trùng
                    _thongTinVanBanList.ApplyEdit();
                    _thongTinVanBanList.Save();

                    //Load lại cây thông tin. Nếu đang tìm kiếm thì load lại toàn bộ cây hiển thị như lúc vừa chọn nhân viên
                    if (bIsSeach)
                    {
                        bIsSeach = false;
                        CayThongTin_Load(utree_ThongTin, _nhanVienTongHop);
                    }
                    else
                    {
                        //Nếu không thì chỉ cần load lại nút hiện tại đang chọn
                        _NodeCurrent.Nodes.Clear();
                        ThemNodeNhomVanBan(_NodeCurrent);
                        _NodeCurrent.ExpandAll();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Không thể thực hiện thao tác. Dữ liệu số hóa chỉ có thể thêm vào nhóm văn bản.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //đổi nhóm văn bản 14/03/2016
        public void DiChuyenFileToiNhomVanBanMoi()
        {
            NhomVanBan nhomVBMoi;
            if (!KiemTraNodeAddImage(_NodeCurrent))
            {
                frmChonNhomVanBan frm = new frmChonNhomVanBan();
                DialogResult dlr = frm.ShowDialog();
                if (dlr == DialogResult.OK)
                {
                    nhomVBMoi = frm.cmb_NhomVanBan.GetSelectedDataRow() as NhomVanBan;

                    //if (_thongTinVanBanList.Count == 0)
                    _thongTinVanBanList = ThongTinVanBanList.GetThongTinVanBanList((long)_NodeCurrent.Parent.Tag, _nhanVienTongHop.MaNhanVien, 0);

                    _ThongTinVanBanCurrent = KiemTraTonTaiList(_thongTinVanBanList, (long)_NodeCurrent.Tag);
                    if (_ThongTinVanBanCurrent == null)
                    {
                        _ThongTinVanBanCurrent = ThongTinVanBan.GetThongTinVanBan((long)_NodeCurrent.Tag);
                    }
                    else
                    {
                        _ThongTinVanBanCurrent = ThongTinVanBan.GetThongTinVanBan(_ThongTinVanBanCurrent.MaThongTinVanBan);
                    }
                    //DialogUtil.ShowInfo("kiểm tra node hiện tại " + _ThongTinVanBanCurrent.SoHoSo + " nhóm văn bản " + nhomVBMoi.MaNhomVanBan + " _ " + nhomVBMoi.TenNhomvanBan);


                    if (_ThongTinVanBanCurrent != null)
                    {
                        _ThongTinVanBanCurrent.MaNhomVanBan = nhomVBMoi.MaNhomVanBan;
                        CapNhatDuLieuNode(_thongTinVanBanList, _ThongTinVanBanCurrent);
                    }

                    //Lưu lại nhưng tập tin không bị trùng
                    _thongTinVanBanList.ApplyEdit();
                    _thongTinVanBanList.Save();
                    Refesh_DuLieu();
                }
            }
            else
            {
                MessageBox.Show(this, "Không thể thực hiện thao tác. \nChỉ có thể di chuyển file vào nhóm văn bản.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //

        private void CayThongTin_Load(UltraTree TreeThongTin, ThongTinNhanVienTongHop _nhanVien)
        {
            this.pdfViewer1.CloseDocument();
            TreeThongTin.Nodes.Clear();
            TreeThongTin.Nodes.Add("root", string.Format("{0} - Mã nhân viên: {1}", _nhanVien.TenNhanVien, _nhanVien.MaQLNhanVien));
            UltraTreeNode root = TreeThongTin.Nodes[0];
            root.Tag = _nhanVien.MaNhanVien;
            root.Override.NodeAppearance.Image = imageList_PDF.Images["user1"];
            _nhomVanBanList = NhomVanBanList.GetNhomVanBanList(0);

            foreach (NhomVanBan _nhomVanBan in _nhomVanBanList)
            {
                UltraTreeNode Node = new UltraTreeNode(_nhomVanBan.TenNhomvanBan);
                Node.Tag = _nhomVanBan.MaNhomVanBan;
                Node.Override.NodeAppearance.Image = imageList_PDF.Images["folder"];
                root.Nodes.Add(Node);
                ThemNodeNhomVanBan(Node);
            }

            TreeThongTin.Refresh();
            //TreeThongTin.Nodes[0].ExpandAll();//29/07/2016
            //TreeThongTin.Nodes[0].ExpandAll(ExpandAllType.OnlyNodesWithChildren);
        }

        private void CayThongTin_LoadSreach(UltraTree TreeThongTin, ThongTinNhanVienTongHop _nhanVien)
        {
            this.pdfViewer1.CloseDocument();
            TreeThongTin.Nodes.Clear();
            TreeThongTin.Nodes.Add("root", string.Format("{0} - Mã nhân viên: {1}", _nhanVien.TenNhanVien, _nhanVien.MaQLNhanVien));
            UltraTreeNode root = TreeThongTin.Nodes[0];
            root.Tag = _nhanVien.MaNhanVien;
            root.Override.NodeAppearance.Image = imageList_PDF.Images["user1"];
            _nhomVanBanList = GetNhomVanBanList(_nhanVien.MaNhanVien, strSoHoSo);

            foreach (NhomVanBan _nhomVanBan in _nhomVanBanList)
            {
                UltraTreeNode Node = new UltraTreeNode(_nhomVanBan.TenNhomvanBan) { Tag = _nhomVanBan.MaNhomVanBan };
                Node.Override.NodeAppearance.Image = imageList_PDF.Images["folder"];
                if (_nhomVanBan.MaNhomCha == 0)
                {
                    root.Nodes.Add(Node);
                }
                else
                {
                    CreateTreeView(TreeThongTin, Node);
                }

                ThemNodeNhomVanBan(Node);
                //root.Nodes.Add(Node);
                //ThemNodeNhomVanBan(Node);//29/07/2016
            }

            TreeThongTin.Refresh();
            //TreeThongTin.ExpandAll();
        }

        private void Them1NodeNhanVien(UltraTreeNode ParentNode, ThongTinNhanVienTongHop _nhanvien)
        {
            UltraTreeNode Node = new UltraTreeNode(string.Format("{0} - Mã nhân viên: {1}", _nhanvien.TenNhanVien, _nhanvien.MaQLNhanVien));
            if (_nhanvien.MaNhanVien != 0)
            {
                Node.Tag = _nhanvien.MaNhanVien;
                //Node.Override.NodeAppearance.Image = ((System.Drawing.Image)(this.resources.GetObject("user1")));
            }
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

        private void DisplayFilePDF(ThongTinVanBan vb)
        {
            //pdf.Dispose();
            //pdf = new AxAcroPDFLib.AxAcroPDF();

            //pdf.Dock = System.Windows.Forms.DockStyle.Fill;
            //pdf.Enabled = true;
            //pdf.Location = axAcroPDF1.Location;
            //pdf.Size = axAcroPDF1.Size;
            //axAcroPDF1.Visible = false;
            //pdf.Name = "pdfReader";
            ////pdf.OcxState = ((System.Windows.Forms.AxHost.State)(new System.ComponentModel.ComponentResourceManager(typeof(frmThongTinVanBan_New)).GetObject("pdfReader.OcxState")));
            //pdf.TabIndex = 1;

            //// Add pdf viewer to current form        
            //this.Controls.Add(pdf);

            ////byte[] File = vb.HinhAnh;

            //string strTenFile = "TempFile.pdf";
            //SaveFilePDF(File, strTenFile);
            Boolean taiXong = true;
            GC.Collect();
            byte[] data = null;
            long offset = 0;
            //lay stream file nguon dua len pdf viewer
            DigitizingService service = new DigitizingService();
            Int32 soFile = 0;
            try
            {
                soFile = service.SplitFile(_publicKey, _token, vb.TenFile.ToString() + ".pdf", "NS");
            }
            catch (Exception ex)
            {
                taiXong = false;
                DialogUtil.ShowError("Không tìm thấy file \n" + ex.Message);
            }
            if (soFile == 1)
            {
                using (DialogUtil.Wait(this, "vui lòng đợi...", "Đang tải dữ liệu!"))
                {
                    try
                    {
                        data = service.QuickHelper_DownloadSourceFile_ByFileName(_publicKey, _token, vb.TenFile.ToString() + ".pdf", "NS");
                        SaveFilePDF(data, "TempFile.pdf");
                        this.pdfViewer1.LoadDocument("TempFile.pdf");
                        this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.ActualSize;
                    }
                    catch (Exception ex)
                    {
                        //this.pdfViewer1.CloseDocument();
                        DialogUtil.ShowError("Không tìm thấy file \n" + ex.Message);
                        this.pdfViewer1.CloseDocument();
                    }
                }
            }
            else
            {
                using (DialogUtil.Wait(this, "vui lòng đợi...", "Đang tải dữ liệu!\nFile này có dung lượng lớn\nQuá trình tải có thể hơi lâu"))
                {                   
                    try
                    {
                        for (int i = 0; i < soFile; i++)
                        {
                            data = null;
                            data = service.QuickHelper_DownloadSourceFileLarge_ByFileName(_publicKey, _token, vb.TenFile.ToString() + ".pdf", "NS", offset);
                            SaveFileLargeSize("TempFile.pdf", data, offset);
                            offset += data.Length;
                        }
                    }
                    catch (Exception exp)
                    {
                        DialogUtil.ShowError("Xảy ra lỗi trong quá trình tải file\nTải file không thành công\n" + exp.Message);
                        taiXong = false;
                    }
                    if (taiXong)
                    {
                        this.pdfViewer1.LoadDocument("TempFile.pdf");
                        this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.ActualSize;
                    }
                    else
                    {
                        //DialogUtil.ShowError("Tải File không thành công \n");
                        this.pdfViewer1.CloseDocument();
                    }
                }

            }
        }

        private void SaveFileLargeSize(string destFilePath, byte[] buffer, long offset)
        {

            try
            {
                if (offset == 0) // new file, create an empty file
                    File.Create(destFilePath).Close();
                // open a file stream and write the buffer. 
                // Don't open with FileMode.Append because the transfer may wish to 
                // start a different point
                using (FileStream fs = new FileStream(destFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    fs.Seek(offset, SeekOrigin.Begin);
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveFilePDF(byte[] File, string strTenFile)
        {
            try
            {
                FileStream fs = new FileStream(strTenFile, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter w = new BinaryWriter(fs);
                w.Flush();
                w.Write(File);
                w.Close();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Events
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

        private void mnu_ThemDL_Click(object sender, EventArgs e)
        {
            AddFile();
            //Refesh_DuLieu();
        }

        private void tlslblThemDuLieu_Click(object sender, EventArgs e)
        {
            AddFile();
            Refesh_DuLieu();
        }

        private void mnu_ThongTinVanBan_Click(object sender, EventArgs e)
        {
            dkmu_NhanVien.ShowAll();
        }

        private void filmstripControl_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _thongTinVanBanList.ApplyEdit();
                _thongTinVanBanList.Save();
                MessageBox.Show(this, "Đã lưu dữ liệu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Refesh_DuLieu();
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

                        //Ultra
                        _nhanVienTongHop = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(frm.maNhanVien);
                        DanhSachNhanVien_Load(utree_DanhSachNV, _nhanVienTongHop);
                        CayThongTin_Load(utree_ThongTin, _nhanVienTongHop);
                    }
                }
                else
                {
                    strSoHoSo = frm.soHoSo;
                    if (strSoHoSo != string.Empty)
                    {
                        _boPhanList = GetBoPhanList(strSoHoSo);
                        if (_boPhanList.Count <= 0)
                        {
                            strSoHoSo = string.Empty;
                            MessageBox.Show(this, "Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            bIsSeach = true;

                            //Ultra
                            utree_ThongTin.Nodes.Clear();
                            DanhSachNhanVien_Load(utree_DanhSachNV, strSoHoSo);
                        }
                    }
                }

                if ((frm.maBophan == 0 && frm.maNhanVien == 0 && frm.bNhanVien) | (strSoHoSo == string.Empty & !frm.bNhanVien))
                {
                    utree_ThongTin.Nodes.Clear();
                    DanhSachNhanVien_Load(utree_DanhSachNV);
                }
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printDocument.DocumentName = "In hồ sơ nhân viên";
            prevDialog.Document = printDocument;
            prevDialog.ShowDialog();

        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = 0;
            float y = 0;
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
            if (utree_DanhSachNV.SelectedNodes.Count == 0)
                return;

            this.Cursor = Cursors.WaitCursor;

            if (!bIsSeach)
                Load_ThongTinNhanVien(utree_DanhSachNV.SelectedNodes[0]);
            else
                Load_ThongTinNhanVienSearch(utree_DanhSachNV.SelectedNodes[0]);

            this.Cursor = Cursors.Default;
            //utree_DanhSachNV.ExpandAll(ExpandAllType.OnlyNodesWithChildren);
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

        //Khi chọn một node trên cây thông tin
        private void utree_ThongTin_AfterSelect(object sender, SelectEventArgs e)
        {
            if (utree_ThongTin.SelectedNodes.Count > 0)
            {
                _NodeCurrent = utree_ThongTin.SelectedNodes[0];
                _maNhomVanBan = (long)_NodeCurrent.Tag;
            }
        }

        private void utree_ThongTin_MouseClick(object sender, MouseEventArgs e)
        {
            UltraTree tree = sender as UltraTree;
            UltraTreeNode node = tree.GetNodeFromPoint(e.Location);

            if (e.Button == MouseButtons.Right)
            {
                if (node != null)
                {
                    node.Selected = true;
                    bIsNode = true;
                    this.contextMenuStrip.Show(this.utree_ThongTin, e.Location);
                }
            }
        }

        private void utree_ThongTin_DoubleClick(object sender, EventArgs e)
        {
            if (_NodeCurrent.LeftImages.Tag != null)
            {
                //if (_ThongTinVanBanCurrent != null)
                //    iff_ThongTinVanBanCurrent.MaThongTinVanBan == (long)_NodeCurrent.Tag) return;

                _ThongTinVanBanCurrent = KiemTraTonTaiList(_thongTinVanBanList, (long)_NodeCurrent.Tag);
                if (_ThongTinVanBanCurrent == null)
                {
                    _ThongTinVanBanCurrent = ThongTinVanBan.GetThongTinVanBan((long)_NodeCurrent.Tag);
                }
                else
                {
                    _ThongTinVanBanCurrent = ThongTinVanBan.GetThongTinVanBan(_ThongTinVanBanCurrent.MaThongTinVanBan);
                }

                if (_ThongTinVanBanCurrent != null)
                {
                    //Hiển thị file PDF
                    DisplayFilePDF(_ThongTinVanBanCurrent);

                    loadFile = true;
                    //Hiển thị thông tin vào dữ liệu
                    HienThiThongTin(_ThongTinVanBanCurrent);
                }
            }
        }
        #endregion

        private void HienThiThongTin(ThongTinVanBan vanBan)
        {
            groupBox_ThongTin.Enabled = true;
            txtu_SoHoSo.Text = vanBan.SoHoSo;
            txt_DienGiai.Text = vanBan.DienGiai;
            dtpu_NgayLap.Value = vanBan.NgayLap;
            txt_ViTri.EditValue = vanBan.ViTri;
            loadFile = false;
            //DialogUtil.ShowInfo("vị trí hiện tại của nhóm văn bản " + vanBan.MaNhomVanBan + " vị trí " + vanBan.ViTri);
        }

        private ThongTinVanBan KiemTraTonTaiList(ThongTinVanBanList vbList, long MaThongTin)
        {
            foreach (ThongTinVanBan vb in vbList)
            {
                if (vb.MaThongTinVanBan == MaThongTin)
                    return vb;
            }
            return null;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.utree_ThongTin.ActiveNode != null)
            {
                if (keyData == Keys.F2 & this.utree_ThongTin.ActiveNode.LeftImages.Tag != null)
                {
                    UltraTreeNode node = this.utree_ThongTin.ActiveNode;

                    if (node == null)
                        return false;

                    // Make sure the node is in view
                    node.BringIntoView();

                    node.AllowCellEdit = AllowCellEdit.Full;

                    // Start editing the active node
                    node.BeginEdit();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void utree_ThongTin_AfterLabelEdit(object sender, NodeEventArgs e)
        {
            bool bExist = KiemTraSoHoSo(_NodeCurrent.Text);
            if (!bExist)
            {
                _NodeCurrent.Text = strTenEdit;
                MessageBox.Show(this, "Tên tập tin đã tồn tại xin vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra dữ liệu node hiện tại có trong danh sách hay không nếu chưa thì lấy node lên
            ThongTinVanBan vbEdit = KiemTraTonTaiList(_thongTinVanBanList, (long)_NodeCurrent.Tag);
            if (vbEdit == null)
            {
                vbEdit = ThongTinVanBan.GetThongTinVanBan((long)_NodeCurrent.Tag);
            }

            vbEdit.SoHoSo = _NodeCurrent.Text;
            //03/03/2016
            if (KiemTraSoHoSoVaTenNhomVanBan(vbEdit.SoHoSo))
            {
                DialogUtil.ShowError("Số hồ sơ không được trùng với tên nhóm văn bản");
            }
            else
            {
                CapNhatDuLieuNode(_thongTinVanBanList, vbEdit);

                if (_ThongTinVanBanCurrent != null)
                {
                    //Kiểm tra xem node đang chọn và Dữ liệu hiện tại có giống nhau hay không. Nếu giống nhau thì cập nhật dữ liệu
                    if (vbEdit.MaThongTinVanBan == _ThongTinVanBanCurrent.MaThongTinVanBan)
                    {
                        HienThiThongTin(vbEdit);
                    }
                }
            }
        }

        //kiểm tra số hồ sơ nếu trùng với tên nhóm văn nếu trùng sẽ không thể hiện lên cây
        bool KiemTraSoHoSoVaTenNhomVanBan(string soHoSo)
        {
            NhomVanBanList nhomVanBanFull = NhomVanBanList.GetNhomVanBanList();
            foreach (NhomVanBan nhomVanBan in nhomVanBanFull)
            {
                if (nhomVanBan.TenNhomvanBan.ToUpper().Equals(soHoSo.ToUpper()))
                {
                    return true;
                }
            }
            return false;
        }
        //
        private void txtu_SoHoSo_ValueChanged(object sender, EventArgs e)
        {
            if (_ThongTinVanBanCurrent != null && !loadFile)
            {
                loadFile = false;
                if (KiemTraSoHoSoVaTenNhomVanBan(txtu_SoHoSo.Text) || !KiemTraSoHoSoUpdate(txtu_SoHoSo.Text, _ThongTinVanBanCurrent))
                {
                    DialogUtil.ShowError("Số hồ sơ không được trùng với tên nhóm văn bản\nHay số hồ sơ trong cùng 1 nhân viên không được giống nhau!\nVui lòng nhập số hồ sơ khác!");
                    txtu_SoHoSo.SelectAll();
                }
                else
                {
                    _ThongTinVanBanCurrent.SoHoSo = txtu_SoHoSo.Text;
                    CapNhatDuLieuNode(_thongTinVanBanList, _ThongTinVanBanCurrent);
                    CapNhatThongTinNode(utree_ThongTin.ActiveNode.RootNode, _ThongTinVanBanCurrent);
                }
            }
        }

        private void dtpu_NgayLap_ValueChanged(object sender, EventArgs e)
        {
            if (_ThongTinVanBanCurrent != null)
            {
                _ThongTinVanBanCurrent.NgayLap = (DateTime)dtpu_NgayLap.Value;
                CapNhatDuLieuNode(_thongTinVanBanList, _ThongTinVanBanCurrent);
            }
        }

        private void txt_DienGiai_ValueChanged(object sender, EventArgs e)
        {
            if (_ThongTinVanBanCurrent != null)
            {
                _ThongTinVanBanCurrent.DienGiai = txt_DienGiai.Text;
                CapNhatDuLieuNode(_thongTinVanBanList, _ThongTinVanBanCurrent);
            }
        }

        private void CapNhatDuLieuNode(ThongTinVanBanList VanBanList, ThongTinVanBan VanBan)
        {
            foreach (ThongTinVanBan vb in VanBanList)
            {
                if (vb.MaThongTinVanBan == VanBan.MaThongTinVanBan)
                {
                    vb.SoHoSo = VanBan.SoHoSo;
                    vb.NgayLap = VanBan.NgayLap;
                    vb.DienGiai = VanBan.DienGiai;
                    vb.ViTri = VanBan.ViTri;
                    vb.MaNhomVanBan = VanBan.MaNhomVanBan;
                    return;
                }
            }

            //Nếu không tồn tại dữ liệu trong list trước thì add thêm nó vào
            VanBanList.Add(VanBan);
        }

        private void tlslblXoa1File_Click(object sender, EventArgs e)
        {
            XoaDuLieu();
        }

        private void XoaDuLieu()
        {
            if (_thongTinVanBanList.Count > 0)
            {
                ThongTinVanBan vbEdit = KiemTraTonTaiList(_thongTinVanBanList, (long)_NodeCurrent.Tag);
                if (vbEdit == null)
                {
                    vbEdit = ThongTinVanBan.GetThongTinVanBan((long)_NodeCurrent.Tag);
                }

                if (vbEdit != null)
                {
                    //if (vbEdit.MaThongTinVanBan == _ThongTinVanBanCurrent.MaThongTinVanBan)
                    //{
                    //    HienThiThongTin(ThongTinVanBan.NewThongTinVanBan());
                    //    pdf.Dispose();
                    //}

                    ////xóa file trên server
                    //DigitizingService service = new DigitizingService();
                    //service.QuickHelper_DeleteDocument_ByDocFileNameWithoutExtension(_publicKey, _token, vbEdit.TenFile.ToString());
                    string tenFile_Xoa = vbEdit.TenFile.ToString();

                    //_thongTinVanBanList.Add(vbEdit);
                    if (_thongTinVanBanList.Remove(vbEdit))
                    {
                        _thongTinVanBanList.ApplyEdit();
                        _thongTinVanBanList.Save();

                        //xóa file trên server
                        DigitizingService service = new DigitizingService();
                        service.QuickHelper_DeleteDocument_ByDocFileNameWithoutExtension(_publicKey, _token, tenFile_Xoa);
                    }
                }

                utree_ThongTin.ActiveNode.Remove();
                this.pdfViewer1.CloseDocument();
            }
            else
            {
                DialogUtil.ShowWarning("Chưa chọn file để xóa \nVui lòng chọn file");
            }
        }

        private void utree_ThongTin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                XoaDuLieu();
        }

        private void CapNhatThongTinNode(UltraTreeNode NodeParent, ThongTinVanBan vanban)
        {
            foreach (UltraTreeNode node in NodeParent.Nodes)
            {
                if ((long)node.Tag == vanban.MaThongTinVanBan)
                    node.Text = vanban.SoHoSo;
                CapNhatThongTinNode(node, vanban);
            }

        }

        private void utree_ThongTin_BeforeLabelEdit(object sender, CancelableNodeEventArgs e)
        {
            if (_NodeCurrent != null)
            {
                strTenEdit = _NodeCurrent.Text;
            }
        }

        private bool KiemTraSoHoSo(string SoHoSo)
        {
            foreach (ThongTinVanBan vb in _thongTinVanBanList)
            {
                if (vb.SoHoSo.ToUpper() == SoHoSo.ToUpper())
                {
                    return false;
                }
            }

            //Kiểm tra xem các file đưa vào có bị trùng với dữ liệu hiện có hay không.
            ThongTinVanBanList vbList = ThongTinVanBanList.GetThongTinVanBanList_KiemTra(_nhanVienTongHop.MaNhanVien, SoHoSo, 0);
            if (vbList.Count > 0)
                return false;
            return true;
        }

        //15/07/2016
        private bool KiemTraSoHoSoUpdate(string SoHoSo, ThongTinVanBan vanBan)
        {
            foreach (ThongTinVanBan vb in _thongTinVanBanList)
            {
                if (vb.SoHoSo.ToUpper() == SoHoSo.ToUpper())
                {
                    return false;
                }
            }
            ThongTinVanBanList vbList = ThongTinVanBanList.GetThongTinVanBanList_KiemTra(vanBan.MaThongTinVanBan, _nhanVienTongHop.MaNhanVien, SoHoSo, 0);
            if (vbList.Count > 0)
                return false;
            return true;
        }

        //Resfesh dữ liệu - hải còi 
        //19/01/2016
        public void Refesh_DuLieu()
        {
            using (DialogUtil.Wait(this, "vui lòng đợi...", "Đang tải dữ liệu!"))
            {
                if (!bIsSeach)
                    CayThongTin_Load(utree_ThongTin, _nhanVienTongHop);
                else
                    CayThongTin_LoadSreach(utree_ThongTin, _nhanVienTongHop);
            }
        }
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;

            //if (!bIsSeach)
            //    CayThongTin_Load(utree_ThongTin, _nhanVienTongHop);
            //else
            //    CayThongTin_LoadSreach(utree_ThongTin, _nhanVienTongHop);

            //this.Cursor = Cursors.Default;
            Refesh_DuLieu();
        }

        private void mnu_ThemNhomVB_Click(object sender, EventArgs e)
        {
            frmNhomVanBan frm = new frmNhomVanBan();
            frm.ShowDialog();
        }
        //up file lên Server
        /// <summary>
        /// 18/02/2016
        /// hải còi
        /// <returns></returns>
        public static Boolean UploadFile(String publicKey, String token, String filePath, String destFileNameWithExtension)
        {
            bool uploadSuccedd = true;
            try
            {
                long offset = 0;
                const int intendedChunkSize = 65536; //65536;
                GC.Collect();
                byte[] buffer = new byte[intendedChunkSize];
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                DigitizingService service = new DigitizingService();
                //DigitizingServiceSoap service = new DigitizingServiceSoapClient();     

                try
                {
                    Int64 fileSize = new FileInfo(filePath).Length;//Tổng dung lượng file
                    //this.progressBarControl1.Properties.Step = intendedChunkSize;
                    //this.progressBarControl1.Properties.Maximum = (Int32)(fileSize / intendedChunkSize);
                    //this.progressBarControl1.Properties.Minimum = 0;
                    fs.Position = offset;
                    int bytesRead = 0;
                    while (offset != fileSize)
                    {
                        ////////_num3 = Offset; //Dung lượng đã upload
                        //progressBarControl1.PerformStep();
                        //progressBarControl1.Update();

                        bytesRead = fs.Read(buffer, 0, intendedChunkSize);
                        if (bytesRead != intendedChunkSize)
                        {
                            byte[] trimmedBuffer = new byte[bytesRead];
                            Array.Copy(buffer, trimmedBuffer, bytesRead);
                            buffer = trimmedBuffer;
                        }

                        try
                        {
                            service.QuickHelper_UploadFileLargeSize(publicKey, token, destFileNameWithExtension, buffer, offset, fileSize, "NS");
                            //QuickHelper_UploadFileLargeSizeResponse response = service.QuickHelper_UploadFileLargeSize(new QuickHelper_UploadFileLargeSizeRequest(new QuickHelper_UploadFileLargeSizeRequestBody(PublicKey, Token, targetFilePath, buffer, offset, fileSize)));
                        }
                        catch (Exception ex)
                        {
                            uploadSuccedd = false;
                            break;
                        }

                        offset += bytesRead;
                    }
                }
                catch { }
                finally
                {
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                //PscMessage.ShowError(ex.Message);
            }
            return uploadSuccedd;
        }

        //cập nhật lại dữ liệu đã up trước đó theo dạng binary lưu trong database 27 người
        //chú ý chỉ chạy ở  PSC qua HTV compare databse bảng [tblThongTinVanBan]
        //chép thư mục file vào  ..\\SOHOA\DATA\NhanSu
        // và rải đểu các file vào thư mục ..\SOHOA\Watching để convert
        public void saveHoSoNhanVien()
        {
            //string tenNhanVien = nhanvien.TenNhanVien;
            List<string> danhSachFile = new List<string>();
            string dir = @"D:\NhanSuHTV2016\";
            int count = 0;
            foreach (string tenNhanVien in Directory.GetDirectories(dir))
            {
                foreach (string filePath in Directory.GetFiles(tenNhanVien, "*.pdf"))
                {
                    //lưu lại dữ liệu ở đây
                    string tenFile = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
                    ThongTinVanBan vanban = ThongTinVanBan.NewThongTinVanBan();
                    int startIndex = tenFile.IndexOf(@"_") + 1;


                    string maNhomVB = tenFile.Substring(startIndex);

                    //int endIndex = tenFile.LastIndexOf(@"_");
                    string maNhom = maNhomVB.Substring(0, maNhomVB.IndexOf(@"_"));

                    long maNhanVien = long.Parse(tenFile.Substring(0, startIndex - 1));
                    long maNhomVanBan = long.Parse(maNhom);
                    ThongTinNhanVienTongHop nhanvien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(maNhanVien);
                    //
                    double viTriMax = ThongTinVanBan.GetMaxMViTri_By_NhanVienAndLoaiVanBan(maNhanVien, maNhomVanBan);
                    //vanban.TenFile = namefile;
                    vanban.TenFile = tenFile.Substring(0, tenFile.Length - 4);
                    vanban.MaThongTinNhanVien = nhanvien.MaNhanVien;
                    vanban.MaBoPhan = nhanvien.MaBoPhan;
                    vanban.MaNhomVanBan = maNhomVanBan;
                    //vanban.SoHoSo = namefile;
                    vanban.ViTri = ++viTriMax;
                    vanban.SoHoSo = maNhomVB.Substring(maNhomVB.IndexOf(@"_") + 1, maNhomVB.Substring(maNhomVB.IndexOf(@"_") + 1).Length - 6);
                    _thongTinVanBanList.Add(vanban);
                }
                try
                {
                    _thongTinVanBanList.ApplyEdit();
                    _thongTinVanBanList.Save();
                    //DialogUtil.ShowInfo("Đã lưu xong cho nhân viên " + tenNhanVien);
                    count++;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            DialogUtil.ShowInfo("Save thành công số nhân viên " + count);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saveHoSoNhanVien();
        }

        private void txt_ViTri_EditValueChanged(object sender, EventArgs e)
        {

            if (_ThongTinVanBanCurrent != null)
            {
                _ThongTinVanBanCurrent.ViTri = float.Parse(txt_ViTri.Text);
                CapNhatDuLieuNode(_thongTinVanBanList, _ThongTinVanBanCurrent);
                CapNhatThongTinNode(utree_ThongTin.ActiveNode.RootNode, _ThongTinVanBanCurrent);
            }
        }

        private void mnu_DoiNhomVanBan_Click(object sender, EventArgs e)
        {
            DiChuyenFileToiNhomVanBanMoi();
        }
        //
    }
}

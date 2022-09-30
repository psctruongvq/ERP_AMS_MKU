using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using System.Diagnostics;
using System.Collections;

namespace PSC_ERP
{
    public partial class frmSoDuDauKy_ForTree : Form
    {
        SoDuDauKyHList _soDuDauKyList;
        HeThongTaiKhoan1List _taiKhoanList;
        KyList _kyList;

        private int _maKy = 0;
        private bool indicatorIcon = true;
        int locationGrid = 0;
        private byte CheckSuaDL = 0;

        public frmSoDuDauKy_ForTree()
        {
            InitializeComponent();
        }

        private void KhoiTao()
        {
            SoDuDauKyListBindingSource.DataSource = typeof(SoDuDauKyList);
            kyListBindingSource.DataSource = typeof(KyList);
            LoadDataForm();

        }

        private void LoadDataForm()
        {
            //Load Ky
            _kyList = KyList.GetKyList();
            kyListBindingSource.DataSource = _kyList;

        }

        private void GetInformations()
        {
            _maKy = 0;
            if (lueky.EditValue != null)
            {
                int kyKTOut = 0;
                if (int.TryParse(lueky.EditValue.ToString(), out kyKTOut))
                {
                    _maKy = kyKTOut;
                }
            }
            //
        }

        private void LoadDataObjectForm()
        {
            GetInformations();
            _soDuDauKyList = SoDuDauKyHList.GetSoDuDauKyHList(_maKy, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            SoDuDauKyListBindingSource.DataSource = _soDuDauKyList;

            foreach (TreeListNode node in tree.Nodes)
            {
                if (node.HasChildren == true)
                {
                    node["SoDuDauKyNo"] = SumParentNode_DuNo(node);
                    node["SoDuDauKyCo"] = SumParentNode_DuCo(node);
                }
            }

            //tree.Columns["SoDuDauKyNo"].AllNodesSummary = true;
            //tree.Columns["SoDuDauKyCo"].AllNodesSummary = true;
        }

        private void frmSoDuDauKy_ForTree_Load(object sender, System.EventArgs e)
        {
            KhoiTao();
        }

        private void btnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lueky.EditValue != null && lueky.EditValue != "")
            {
                LoadDataObjectForm();
                if (SoDuDauKyListBindingSource.Count == 0)
                    MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tree.ExpandAll();
               
            }
        }

        private void tree_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node;
            node = e.Node;
            
            int maTaiKhoanCha = (int)node.GetValue("MaTaiKhoanCha");
            if (maTaiKhoanCha == 0)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        //sum len node cha
        private void Calculate()
        {
            //foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in this.tree.Nodes)
            //{
             //  TreeListOperationCalcSummarySum operation = new TreeListOperationCalcSummarySum(tree.Columns["SoDuDauKyNo"], SummaryItemType.Sum, true);
            //    node.TreeList.NodesIterator.DoLocalOperation(operation, node.Nodes);
            //    node.SetValue(tree.Columns["SoDuDauKyNo"], operation.Result);

            //    TreeListOperationCalcSummarySum operationCo = new TreeListOperationCalcSummarySum(tree.Columns["SoDuDauKyCo"], SummaryItemType.Sum, true);
            //    node.TreeList.NodesIterator.DoLocalOperation(operationCo, node.Nodes);
            //    node.SetValue(tree.Columns["SoDuDauKyCo"], operationCo.Result);
            //}
        }

        private void tree_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //if (e.Node.ParentNode != null)
            //{
            //    Calculate();
            //}
        }

        private void tree_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            //int maTaiKhoanCha = (int)e.Node.GetValue("MaTaiKhoanCha");
            //bool coTheoDoiDoiTuong = (bool)e.Node.GetValue("CoTheoDoiDoiTuong");
            //int maTK_KeToan_NganHang = (int)e.Node.GetValue("MaTK_KeToan_NganHang");
            //string soHieuTK = (string)e.Node.GetValue("SoHieuTK");
            //if (coTheoDoiDoiTuong == true || maTK_KeToan_NganHang != 0 || e.Node.HasChildren == true)
            //{
            //    e.RepositoryItem.ReadOnly = true;
            //}
            //else
            //{
            //    e.RepositoryItem.ReadOnly = false;
            //}
        }

        private void tree_DoubleClick(object sender, System.EventArgs e)
        {           
            //TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            //if (hi.Node != null)
            //{
            //    int maTaiKhoanCha = (int)hi.Node.GetValue("MaTaiKhoanCha");
            //    bool coTheoDoiDoiTuong = (bool)hi.Node.GetValue("CoTheoDoiDoiTuong");
            //    int maTK_KeToan_NganHang = (int)hi.Node.GetValue("MaTK_KeToan_NganHang");
            //    string soHieuTK = (string)hi.Node.GetValue("SoHieuTK");
                
            //    //tk ngan hang, nhap chi tiet ben tk ngan hang
            //    if (maTK_KeToan_NganHang != 0)
            //    {
            //        frmSoDuDauKy_NganHang frm = new frmSoDuDauKy_NganHang();
            //        frm.ShowDialog();
            //    }
            //    else if (coTheoDoiDoiTuong == true)
            //    {
            //        frmSoDuDauKyTheoDoiTuong_Dev frm = new frmSoDuDauKyTheoDoiTuong_Dev();
            //        frm.ShowDialog();
            //    }
            //    else
            //    {
            //        frmSoDuDauKyH frm = new frmSoDuDauKyH();
            //        frm.ShowDialog();
            //    }
            //}
        }

        private void tree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListNode Node = tree.CalcHitInfo(new Point(e.X, e.Y)).Node;

            if (Node != null)
            {
                int maTaiKhoanCha = (int)Node.GetValue("MaTaiKhoanCha");
                bool coTheoDoiDoiTuong = (bool)Node.GetValue("CoTheoDoiDoiTuong");
                int maTK_KeToan_NganHang = (int)Node.GetValue("MaTK_KeToan_NganHang");
                string soHieuTK = (string)Node.GetValue("SoHieuTK");
                int maTaiKhoan = (int)Node.GetValue("MaTaiKhoan");

                //tk ngan hang, nhap chi tiet ben tk ngan hang
                if (Node.HasChildren == true)
                {
                    MessageBox.Show("Vui lòng chọn tài khoản con để nhập số dư!");
                }
                else if (maTK_KeToan_NganHang != 0)
                {
                    frmSoDuDauKy_NganHang frm = new frmSoDuDauKy_NganHang();
                    frm._maKy = _maKy;
                    frm._isShowFromParent = true;
                    frm.ShowDialog();
                    if (frm._isSave == true)
                    {
                        LoadDataObjectForm();
                    }
                }
                else if (coTheoDoiDoiTuong == true)
                {
                    frmSoDuDauKyTheoDoiTuong_Dev frm = new frmSoDuDauKyTheoDoiTuong_Dev();
                    frm._isShowFromParent = true;
                    frm._KyKeToan = this._maKy;
                    frm._maTaiKhoan_focus = maTaiKhoan;
                    frm.ShowDialog();
                    if (frm._isSave == true)
                    {
                        LoadDataObjectForm();
                    }
                }
                else
                {
                    frmSoDuDauKyH frm = new frmSoDuDauKyH();
                    frm._maKy = _maKy;
                    frm._isShowFromParent = true;
                    frm._maTaiKhoan_focus = maTaiKhoan;
                    frm.ShowDialog();
                    if (frm._isSave == true)
                    {
                        LoadDataObjectForm();
                    }
                }
            }

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();            
        }

        private void tree_GetCustomSummaryValue(object sender, GetCustomSummaryValueEventArgs e)
        {
            //if (e.Column.FieldName == "SoDuDauKyNo")
            //{
            //    IEnumerator en = e.Nodes.GetEnumerator();
            //    int exceedingLimitNodes = 0;
            //    while (en.MoveNext())
            //    {
            //        TreeListNode node = (TreeListNode)en.Current;
            //        decimal budget = (decimal)node.GetValue(e.Column);                  
            //            exceedingLimitNodes++;
                      
            //    }
            //    e.CustomValue = exceedingLimitNodes;
            //}
        }

        private decimal SumParentNode_DuNo(TreeListNode node)
        {
            decimal result = 0;
            if (node.HasChildren)
            {
                foreach (TreeListNode nodeC in node.Nodes)
                {
                    decimal kqNodeC = 0;
                    if (nodeC.HasChildren)
                    {
                        kqNodeC += SumParentNode_DuNo(nodeC); //de qui
                        nodeC["SoDuDauKyNo"] = kqNodeC;
                        result += kqNodeC;
                    }
                    else
                    {
                        result += (decimal)nodeC["SoDuDauKyNo"];
                    }
                }
            }
           
            return result;
        }

        private decimal SumParentNode_DuCo(TreeListNode node)
        {
            decimal result = 0;
            if (node.HasChildren)
            {
                foreach (TreeListNode nodeC in node.Nodes)
                {
                    decimal kqNodeC = 0;
                    if (nodeC.HasChildren)
                    {
                        kqNodeC += SumParentNode_DuCo(nodeC); //de qui
                        nodeC["SoDuDauKyCo"] = kqNodeC;
                        result += kqNodeC;
                    }
                    else
                    {
                        result += (decimal)nodeC["SoDuDauKyCo"];
                    }
                }
                //node["SoDuDauKyCo"] = result;
            }

            return result;
        }

    }
}

using DevExpress.XtraTreeList.Nodes;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace PSC_ERP_Digitizing.Client.UI
{
    public partial class frmDigitizing
    {
        private void btnReloadTree_Click(object sender, EventArgs e)
        {
            TaskUtil.InvokeCrossThread(this, () =>
            {
                using (DialogUtil.Wait(this))
                {
                    DocDuLieuVaDuaLenCay();
                }
            });
        }
        private void btnThemThuMuc_Click(object sender, EventArgs e)
        {
            //goi ham them len cay
            this.ThemLenCay(themThuMuc: true, themFile: false);
        }

        private void btnThemTapTin_Click(object sender, EventArgs e)
        {
            //goi ham them len cay
            this.ThemLenCay(themThuMuc: false, themFile: true);
        }

        private void contextMenuStrip_ForTree_Opening(object sender, CancelEventArgs e)
        {
            //kiem tra co bi dirty ko
            if (_treeBagFactory.IsDirty)
            {
                this.btnSaveTree.Visible = true;
            }
            //an hien nut them
            /////////
            ////
            var obj = treeListBag.GetDataRecordByNode(this.treeListBag.FocusedNode) as DigitizingBag;


            this.btnThem.Visible = false;
            this.btnThemThuMuc.Visible = false;
            this.btnThemTapTin.Visible = false;
            this.btnDeleteTreeNode.Visible = false;

            if (obj == null || !(obj.IsFile ?? false))
            {
                //hiện nút thêm
                this.btnThem.Visible = true;
                //hiện nút thêm thư mục
                this.btnThemThuMuc.Visible = true;
            }
            if (obj != null)
            {
                //hiện nút xóa
                this.btnDeleteTreeNode.Visible = true;
                //
                if (obj != null && !(obj.IsFile ?? false))
                {
                    //hiện nút thêm tập tin
                    btnThemTapTin.Visible = true;
                }
                else if (obj.IsFile == true)
                {
                    //đang active vào node file
                }
            }

        }

        private void btnSaveTree_Click(object sender, EventArgs e)
        {
            if (this.SaveTree())
                DialogUtil.ShowSaveSuccessful();
        }
        private void btnDeleteTreeNode_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn thực sự muốn xóa những dòng đang chọn trên cây"))
            {//xóa node

                try
                {
                    using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required,
                                     TimeSpan.FromSeconds(180)))
                    {
                        //lay danh sach
                        List<DigitizingBag> dsBag = new List<DigitizingBag>();
                        foreach (TreeListNode item in this.treeListBag.Selection)
                        {
                            DigitizingBag bag = GetObject_AtNode(item);
                            dsBag.Add(bag);
                        }
                        DigitizingBag_Factory.FullDelete(_treeBagFactory.Context, dsBag.ToList<object>());
                        _treeBagFactory.SaveChangesWithoutTrackingLog();
                        //xóa file trên server
                        WebReference1.DigitizingService service = new WebReference1.DigitizingService();
                        foreach (var item in dsBag)
                        {
                            service.QuickHelper_DeleteDocument_ByDocFileNameWithoutExtension(_publicKey, _token, item.BagId.ToString());
                        }


                        //hoàn tất
                        transaction.Complete();
                    }

                }
                catch (Exception ex)
                {

                }
            }

        }
    }
}

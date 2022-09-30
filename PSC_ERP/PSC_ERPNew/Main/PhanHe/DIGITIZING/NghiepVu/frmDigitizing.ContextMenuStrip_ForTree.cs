using DevExpress.XtraTreeList.Nodes;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using PSC_ERPNew.Main.PhanHe.DIGITIZING.Predefined;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace PSC_ERPNew.Main.PhanHe.DIGITIZING
{
    public partial class frmDigitizing
    {

        private void ThemLenCay(Boolean themThuMuc = false, Boolean themTapTin = false, Boolean themNhieuTapTin = false)
        {
            focusedNode = treeListBag.FocusedNode;//C
            currentObjectAtNode = GetObject_AtNode(focusedNode);//C

            MessageBox.Show("dang test trước thêm " + focusedNode.Id + " mã row hiện tại " + currentObjectAtNode.BagId + "\n vị trí hiện tại " + digitizingBagBindingSource_ForTree.IndexOf(currentObjectAtNode) + "ma bo phan " + currentObjectAtNode.MaBoPhan);
            //lấy mã bộ phân của nhánh cây
            Int32 maBoPhanAtCurrentBranch = TimMaBoPhan(currentObjectAtNode) ?? 0;
            //lựa chọn loại chứng từ
            DocumentTypeEnum documentType_ForQuickLoad = (DocumentTypeEnum)(TimMaLoaiChungTu(currentObjectAtNode) ?? 0);
            //if ((_maChungTu_ForQuickLoad ?? 0) == 0)
            //    documentType_ForQuickLoad = (DocumentTypeEnum)(TimMaLoaiChungTu(currentObjectAtNode) ?? 0);
            //else documentType_ForQuickLoad = _docTypeEnum_ForQuickLoad;
            Int32 folderYearAtCurrentBranch = TimNam(currentObjectAtNode) ?? 0;
            IQueryable<DigitizingBag> dsBag = (digitizingBagBindingSource_ForTree.DataSource as IQueryable<DigitizingBag>);
            if (themNhieuTapTin)
            {
                //trường hợp có trong Database
                if ((currentObjectAtNode.IsDatabase??false)==true)
                {
                  //dsBag  = (digitizingBagBindingSource_ForTree.DataSource as IQueryable<DigitizingBag>);

                    using (frmDigitizing_ChonChungTuUpLoad frm = new frmDigitizing_ChonChungTuUpLoad(_treeBagFactory, dsBag, maBoPhanAtCurrentBranch
                            , documentType_ForQuickLoad
                            , folderYearAtCurrentBranch
                            , currentObjectAtNode
                            , _maChungTu_ForQuickLoad
                            , (currentObjectAtNode.IsDatabase??false)
                            ))
                    {
                        DialogResult result = frm.ShowDialog();
                        if (result == DialogResult.Yes)
                        {
                            digitizingBagBindingSource_ForTree.ResetBindings(true);                           
                            //treeListBag.RefreshDataSource();
                            //làm tươi cây
                            //bool _isLoad = false;
                            //đang load lại dữ liệu
                            //using (DialogUtil.Wait(this))
                            //{
                            //    this.btnReloadTree.PerformClick();
                            //    _isLoad = true;
                            //};
                            //đợi load xong thì mới active lại node trước đó đã chọn                            

                            //if (_isLoad)
                            //{
                            //    MessageBox.Show("dang test sau thêm " + focusedNode.Id + " mã row hiện tại " + currentObjectAtNode.BagId + "\n vị trí hiện tại " + digitizingBagBindingSource_ForTree.IndexOf(currentObjectAtNode));
                            //    //treeListBag.FocusedNode = focusedNode;
                            //    //treeListBag.Nodes[digitizingBagBindingSource_ForTree.IndexOf(currentObjectAtNode)].Selected = true;
                            //    //digitizingBagBindingSource_ForTree.Position = digitizingBagBindingSource_ForTree.IndexOf(currentObjectAtNode);

                            //    // focusedNode.Nodes[0].Selected = true;
                            //}
                        }
                    }
                }

                else if ((currentObjectAtNode.IsDatabase ?? false) == false)  //trường hợp file không có trong database
                {
                    IQueryable<DigitizingBag> dsFile = null;// = DigitizingBag_Factory.New().Context.spd_TimFile(currentObjectAtNode.FolderYear, currentObjectAtNode.MaBoPhan, currentObjectAtNode.MaLoaiChungTu, 0, currentObjectAtNode.IsDatabase) as IQueryable<DigitizingBag>;
                    using (DialogUtil.Wait(this))
                    {
                        dsFile = dsBag.Where(x => x.MaBoPhan == maBoPhanAtCurrentBranch && x.MaLoaiChungTu == currentObjectAtNode.MaLoaiChungTu && x.IsFile == true && x.FolderYear == folderYearAtCurrentBranch);
                        //dsFile = DigitizingBag_Factory.New().Context.spd_TimFile(folderYearAtCurrentBranch, maBoPhanAtCurrentBranch, Convert.ToInt32(documentType_ForQuickLoad), 0, false) as IQueryable<DigitizingBag>;
                    }
                    //spd_TimChungTuSoHoa_Result _currentChungTu = null;
                    using (var frm = new frmDigitizing_ChonFilesUpLoad(_treeBagFactory, dsBag, null, currentObjectAtNode, maBoPhanAtCurrentBranch, documentType_ForQuickLoad, folderYearAtCurrentBranch, false))
                    {
                        DialogResult result = frm.ShowDialog();
                        if (result == DialogResult.Yes)
                        {
                            this.btnReloadTree.PerformClick();
                        }
                    }
                }
            }
            else
            {
                DigitizingBag newObj = _treeBagFactory.CreateAloneObject();

                newObj.CreatedUser = BasicInfo.User.UserID;//PSC_ERP_Global.Main.UserID;
                newObj.MaBoPhan = BasicInfo.User.MaBoPhan;//PSC_ERP_Global.Main.MaBoPhanCuaUser;

                if (currentObjectAtNode != null)
                {
                    newObj.ParentBagId = currentObjectAtNode.BagId;
                    newObj.BagId = Guid.NewGuid();
                }
                else
                {
                    newObj.BagId = Guid.Empty;
                }

                Boolean chapNhanThem = false;
                if (themThuMuc)
                {
                    newObj.Name = Microsoft.VisualBasic.Interaction.InputBox("Hãy nhập tên thư mục.", "Tên thư mục", "");
                    if (String.IsNullOrWhiteSpace(newObj.Name))
                        newObj.Name = "<<Quên đặt tên>>";
                    chapNhanThem = true;

                }
                else if (themTapTin)
                {


                    using (frmDigitizing_AddNewFileOrPreview frm = new frmDigitizing_AddNewFileOrPreview(maBoPhanAtCurrentBranch
                        , documentType_ForQuickLoad
                        , folderYearAtCurrentBranch
                        , _maChungTu_ForQuickLoad
                        , false
                        , newObj))
                    {
                        DialogResult result = frm.ShowDialog();
                        if (result == DialogResult.OK && (newObj.FileUploadCompleted ?? false))
                        {
                            chapNhanThem = true;
                        }
                    }

                }
                if (chapNhanThem)
                {
                    //đưa vào context
                    //_treeBagFactory.Attach(newObj);
                    //thêm vào binding source
                    digitizingBagBindingSource_ForTree.Add(newObj);

                    //focus tới vị trí vừa thêm vào 
                    digitizingBagBindingSource_ForTree.Position = digitizingBagBindingSource_ForTree.IndexOf(newObj);

                    //save tree
                    SaveTree();

                }
            }

        }

        private static int? TimMaBoPhan(DigitizingBag currentObjectAtNode)
        {
            Int32? tmpMaBoPhan = (currentObjectAtNode.MaBoPhan ?? 0);
            if (tmpMaBoPhan == 0)
            {
                if (currentObjectAtNode.DigitizingBag2 != null)
                    return TimMaBoPhan(currentObjectAtNode.DigitizingBag2);
            }
            return tmpMaBoPhan;
        }

        private static int? TimMaLoaiChungTu(DigitizingBag currentObjectAtNode)
        {
            Int32? tmpMaLoaiChungTu = (currentObjectAtNode.MaLoaiChungTu ?? 0);
            if (tmpMaLoaiChungTu == 0)
            {
                if (currentObjectAtNode.DigitizingBag2 != null)
                    return TimMaLoaiChungTu(currentObjectAtNode.DigitizingBag2);
            }
            return tmpMaLoaiChungTu;
        }
        private static int? TimNam(DigitizingBag currentObjectAtNode)
        {
            Int32? tmpFolderYear = (currentObjectAtNode.FolderYear ?? 0);
            if (tmpFolderYear == 0)
            {
                if (currentObjectAtNode.DigitizingBag2 != null)
                    return TimNam(currentObjectAtNode.DigitizingBag2);
            }
            return tmpFolderYear;
        }
        //reload lại treeview
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
            this.ThemLenCay(themThuMuc: true, themTapTin: false);
        }


        private void btnThemTapTin_Click(object sender, EventArgs e)
        {
            //goi ham them len cay
            this.ThemLenCay(themThuMuc: false, themTapTin: true);
        }

        private void btnThemNhieuTapTin_Click(object sender, EventArgs e)
        {
            //goi ham them len cay
            this.ThemLenCay(themThuMuc: false, themTapTin: false, themNhieuTapTin: true);

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
            this.btnThemNhieuTapTin.Visible = false;
            this.btnThemTapTin.Visible = false;
            this.btnDeleteTreeNode.Visible = false;
            this.btnEditDigitizingBag.Visible = false;

            //if ((obj == null || !(obj.IsFile ?? false)))
            //{
            //    //hiện nút thêm
            //    this.btnThem.Visible = true;
            //    if (((_maChungTu_ForQuickLoad ?? 0) == 0))
            //    {
            //        //hiện nút thêm thư mục
            //        //this.btnThemThuMuc.Visible = true;
            //    }
            //}
            if (obj != null)
            {
                //chung tu
                //if ((_maChungTu_ForQuickLoad ?? 0) != 0)
                //{
                //    //chi duoc xoa sua file
                //    if (obj.IsFile == true)
                //    {
                //        this.btnDeleteTreeNode.Visible = true;
                //        this.btnEditDigitizingBag.Visible = true;
                //    }
                //}
                ////toan quyen
                //else
                //{
                //    //hiện nút xóa
                //    this.btnDeleteTreeNode.Visible = true;
                //    //hien nut edit
                //    this.btnEditDigitizingBag.Visible = true;

                //}
                //nếu là file thì cho thêm, xóa sửa
                if (obj.IsFile == true)
                {
                    this.btnDeleteTreeNode.Visible = true;
                    this.btnEditDigitizingBag.Visible = true;
                }

                //nếu là Folder Year thì cho phép thêm
                if (obj != null && !(obj.IsFile ?? false) && obj.CapDoCay==3)
                {
                    //thu thập thông tin của nhánh cây
                    //Int32 maBoPhanAtCurrentBranch = TimMaBoPhan(obj) ?? 0;
                    //Int32 maLoaiChungTuAtCurrentBranch = TimMaLoaiChungTu(obj) ?? 0;
                    //Int32 folderYearAtCurrentBranch = TimNam(obj) ?? 0;
                    //if (maBoPhanAtCurrentBranch != 0 && maLoaiChungTuAtCurrentBranch != 0 && folderYearAtCurrentBranch != 0)
                    //{
                        //hiện nút thêm tập tin khi thu thập đủ các thông tin cần thiết                  
                        this.btnThem.Visible = true;
                        btnThemNhieuTapTin.Visible = true;
                        btnThemTapTin.Visible = true;
                   // }
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
                        PSC_ERP_Digitizing.Client.WebReference1.DigitizingService service = new PSC_ERP_Digitizing.Client.WebReference1.DigitizingService();
                        foreach (var item in dsBag)
                        {
                            if (item.IsFile == true)
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
        private void btnEditDigitizingBag_Click(object sender, EventArgs e)
        {
            var obj = treeListBag.GetDataRecordByNode(this.treeListBag.FocusedNode) as DigitizingBag;
            if (obj != null)
            {
                if ((obj.IsFile ?? false) == false)
                {
                    //sua thu muc
                    //do
                    //{
                    //    obj.Name = Microsoft.VisualBasic.Interaction.InputBox("Hãy nhập tên thư mục.", "Tên thư mục", obj.Name);
                    //} while (String.IsNullOrWhiteSpace(obj.Name));
                }
                else
                {
                    //thu thập thông tin của nhánh cây
                    Int32 maBoPhanAtCurrentBranch = TimMaBoPhan(obj) ?? 0;
                    DocumentTypeEnum documentType_ForQuickLoad = (DocumentTypeEnum)(TimMaLoaiChungTu(obj) ?? 0);
                    Int32 folderYearAtCurrentBranch = TimNam(obj) ?? 0;
                    //sua tap tin
                    using (frmDigitizing_AddNewFileOrPreview frm = new frmDigitizing_AddNewFileOrPreview(maBoPhanAtCurrentBranch, documentType_ForQuickLoad, folderYearAtCurrentBranch, _maChungTu_ForQuickLoad, true, obj, _laChungTuImport_ForQuickLoad))
                    {
                        DialogResult result = frm.ShowDialog();
                    }
                }
                _treeBagFactory.SaveChangesWithoutTrackingLog();
            }

        }
    }
}

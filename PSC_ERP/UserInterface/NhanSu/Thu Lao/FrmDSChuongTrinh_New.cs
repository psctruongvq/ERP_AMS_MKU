using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraTreeList.Nodes;
using System.IO;
using System.Diagnostics;

namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class FrmDSChuongTrinh_New : DevExpress.XtraEditors.XtraForm//
    {
        int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        int _hoanTat = 0;
        int _maCongTyCurrent = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private int _maCongTy = 0;
        string _tenChuongTrinhSearch = "";
        string _maChuongTrinhSearch = "";
        Util util = new Util();
        int childCount;
        bool _isSearch = false;

        bool _ktCTCha = true;

        ChuongTrinh_New _chuongTrinh = ChuongTrinh_New.NewChuongTrinh_New();
        NguonList _nguonList;
        BoPhanList _boPhanList;
        ChuongTrinh_NewList _chuongTrinh_NewListCha = ChuongTrinh_NewList.NewChuongTrinh_NewList();
        ChuongTrinh_NewList _chuongTrinh_NewAll = ChuongTrinh_NewList.NewChuongTrinh_NewList();
        ChuongTrinh_NewList _chuongTrinhList_Con = ChuongTrinh_NewList.NewChuongTrinh_NewList();

        //
        ChuongTrinh_NewList _chuongTrinh_NewList = ChuongTrinh_NewList.NewChuongTrinh_NewList();
        Boolean _capNhatNguon = false;

        private void BindingDaTaChuongTrinh(ChuongTrinh_New ct)
        {
            if (ct != null)
            {
                //if (ct.MaChuongTrinhCha != 0)
                //{
                //    AddChuongTrinhtoDSChuongTrinhCha(ct.MaChuongTrinhCha);
                //}
                if (ct.MaChuongTrinh != 0)
                {
                    _chuongTrinh = ChuongTrinh_New.GetChuongTrinh_New(ct.MaChuongTrinh);
                    chuongTrinh_NewBindingSource.DataSource = _chuongTrinh;
                }
            }
            else
            {
                RefreshChuongTrinh();
            }
        }


        private ChuongTrinh_New FindParentOfChuongTrinh(ChuongTrinh_New ct)
        {
            if (ct.MaChuongTrinhCha != 0)
            {
                if (ChuongTrinh_New.ExistsChuongTrinh(ct.MaChuongTrinhCha))
                    return ChuongTrinh_New.GetChuongTrinh_New(ct.MaChuongTrinhCha);
            }
            return null;
        }

        private bool ExistsParentChuongTrinh(ChuongTrinh_New ct)
        {
            if (ct != null)
                if (ct.MaChuongTrinhCha != 0)
                    return true;
            return false;
        }

        private void LoadDanhSachChuongTrinhCha()
        {
            _chuongTrinh_NewListCha = ChuongTrinh_NewList.GetChuongTrinh_NewListAll(_hoanTat, _maCongTyCurrent);
            ChuongTrinh_New ct0 = ChuongTrinh_New.NewChuongTrinh_New("Không Chọn");
            _chuongTrinh_NewListCha.Insert(0, ct0);
            chuongTrinh_NewListBindingSource.DataSource = _chuongTrinh_NewListCha;
        }
        public FrmDSChuongTrinh_New()
        {
            InitializeComponent();
            LoadForm();
        }

        void RefreshChuongTrinh()
        {
            _chuongTrinh = ChuongTrinh_New.NewChuongTrinh_New();
            chuongTrinh_NewBindingSource.DataSource = _chuongTrinh;
        }

        void RefreshTree()
        {
            treeList1.Nodes.Clear();
            if (_isSearch)
            {
                CreateDaTaSearch();
                PSC_ERP.Utils.TreeUtils.FilterTreeNode(treeList1, _tenChuongTrinhSearch);
            }
            else
                CreateDaTa();
        }

        private bool KiemTraControl()
        {
            if (txt_MaChuongTrinh.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Mã Chương Trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txt_TenChuongTrinh.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Tên Chương Trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        string SetMaQL()
        {
            string chuoiKQ = "";
            int max = ChuongTrinh_NewList.GetmaxMaChuongTrinh(_hoanTat);
            if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 22 || ERP_Library.Security.CurrentUser.Info.MaBoPhan == 26)
            {
                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 22)
                {
                    chuoiKQ = "TFS_" + DateTime.Today.Date.ToShortDateString() + "_" + max.ToString();
                }
                else if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 26)
                {
                    chuoiKQ = "HTVC_" + DateTime.Today.Date.ToShortDateString() + "_" + max.ToString();
                }
            }
            return chuoiKQ;


        }

        private void SetIsSearch()
        {
            if (_tenChuongTrinhSearch.Length > 0)
            {
                _isSearch = true;
            }
            else
            {
                _isSearch = false;
            }
        }

        private void DeleteNode(int maChuongTrinh)
        {
            _chuongTrinhList_Con = ChuongTrinh_NewList.GetChuongTrinh_NewbyChaList(maChuongTrinh, _hoanTat, _maCongTyCurrent);
            if (_chuongTrinhList_Con.Count == 0)
                return;
            foreach (ChuongTrinh_New ctCon in _chuongTrinhList_Con)
            {
                childCount += 1;
                DeleteNode(ctCon.MaChuongTrinh);
                ChuongTrinh_New.DeleteChuongTrinh_New(ctCon.MaChuongTrinh);
            }
        }

        void LoadForm()
        {
            _nguonList = NguonList.GetNguonList();
            Nguon _nguon = Nguon.NewNguon("<Không Chọn>");
            _nguonList.Insert(0, _nguon);
            NguonList_bindingSource.DataSource = _nguonList;
            //
            LoadDanhSachChuongTrinhCha();

            _boPhanList = BoPhanList.GetBoPhanList();
            BoPhan bp = BoPhan.NewBoPhan(0, "<Không chọn>");
            _boPhanList.Insert(0, bp);
            boPhanListBindingSource.DataSource = _boPhanList;

            QuocGiaBQ_VTList quocGiaList = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList();
            QuocGiaBQ_VT qg = QuocGiaBQ_VT.NewQuocGiaBQ_VT("<Không chọn>");
            quocGiaList.Insert(0, qg);
            bs_QuocGiaList.DataSource = quocGiaList;

            DonViTinhList donViTinhBQ_VTList = DonViTinhList.GetDonViTinhList();
            DonViTinh dvt = DonViTinh.NewDonViTinh(0, "<Không chọn>");
            donViTinhBQ_VTList.Insert(0, dvt);
            bs_DonViTinhList.DataSource = donViTinhBQ_VTList;
        }

        void AddChuongTrinhtoDSChuongTrinhCha(int maChuongTrinh)
        {
            //if (ChuongTrinh_New.ExistsChuongTrinh(maChuongTrinh))
            //{
            //    ChuongTrinh_New ct = ChuongTrinh_New.GetChuongTrinh_New(maChuongTrinh);
            //    if (!_chuongTrinh_NewListCha.Contains(ct))
            //    {
            //        _chuongTrinh_NewListCha.Insert(_chuongTrinh_NewListCha.Count, ct);
            //        chuongTrinh_NewListBindingSource.DataSource = _chuongTrinh_NewListCha;
            //    }
            //}


        }

        void KhoiTaoChuongTrinh()
        {
            _chuongTrinh = ChuongTrinh_New.NewChuongTrinh_New();
            _chuongTrinh.MaQL = SetMaQL();
            _chuongTrinh.MaNguoiLap = _userID;
            //Lay lai du lieu cua CT Cha
            ChuongTrinh_New ct = chuongTrinh_NewListAllBindingSource.Current as ChuongTrinh_New;
            if (ct != null)
            {
                //AddChuongTrinhtoDSChuongTrinhCha(ct.MaChuongTrinh);
                _chuongTrinh.MaNguon = ct.MaNguon;
                _chuongTrinh.MaBoPhan = ct.MaBoPhan;
                _chuongTrinh.MaChuongTrinhCha = ct.MaChuongTrinh;//
                _chuongTrinh.MaQuocGia = ct.MaQuocGia;
                _chuongTrinh.MaDonViTinh = ct.MaDonViTinh;
                _chuongTrinh.ThoiLuong = ct.ThoiLuong;
                if (ct.MaPhanCap < 5)
                    _chuongTrinh.MaPhanCap = ct.MaPhanCap + 1;
                else
                    _chuongTrinh.MaPhanCap = ct.MaPhanCap;
            }

            chuongTrinh_NewBindingSource.DataSource = _chuongTrinh;



            txt_TenChuongTrinh.Focus();
        }


        #region New

        private void CreateDaTa()
        {
            _chuongTrinh_NewList = ChuongTrinh_NewList.GetChuongTrinh_NewListAll(_hoanTat, _maCongTyCurrent);

            //{//Thêm node root vào
            //    ChuongTrinh_New chuongTrinh_New = ChuongTrinh_New.NewChuongTrinh_New();
            //    chuongTrinh_New.MaQL = "Root";
            //    _chuongTrinh_NewList.Insert(0, chuongTrinh_New);
            //}
            //
            chuongTrinh_NewListAllBindingSource.DataSource = _chuongTrinh_NewList;
            treeList1.DataSource = chuongTrinh_NewListAllBindingSource;
            //

        }

        private void CreateDaTaSearch()
        {
            ChuongTrinh_NewList tempList1 = ChuongTrinh_NewList.GetChuongTrinh_NewListAllParentSearch(_hoanTat, _maCongTyCurrent, _tenChuongTrinhSearch);
            ChuongTrinh_NewList tempList2 = ChuongTrinh_NewList.GetChuongTrinh_NewListAllChildSearch(_hoanTat, _maCongTyCurrent, _tenChuongTrinhSearch);
            ChuongTrinh_NewList kqList = ChuongTrinh_NewList.NewChuongTrinh_NewList();
            foreach (ChuongTrinh_New ct in tempList1)
                if (!kqList.Contains(ct))
                {
                    kqList.Add(ct);
                }
            foreach (ChuongTrinh_New ct in tempList2)
                if (!kqList.Contains(ct))
                {
                    kqList.Add(ct);
                }
            chuongTrinh_NewListAllBindingSource.DataSource = kqList;
            treeList1.DataSource = chuongTrinh_NewListAllBindingSource;

            {//
                _chuongTrinh_NewList = kqList;

                ////Thêm node root vào
                //ChuongTrinh_New chuongTrinh_New = ChuongTrinh_New.NewChuongTrinh_New();
                //chuongTrinh_New.MaQL = "Root";
                //_chuongTrinh_NewList.Insert(0, chuongTrinh_New);
                ////
            }
            //
            foreach (TreeListNode node in treeList1.Nodes)
            {
                node.ExpandAll();
            }
            //
        }
        #endregion//New

        private void treeList1_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {

        }

        private void FrmDSChuongTrinh_New_Load(object sender, EventArgs e)
        {
            //chuongTrinh_NewListAllBindingSource.DataSource = ChuongTrinh_NewList.GetChuongTrinh_NewListAll(_hoanTat, _maCongTyCurrent);
            //CreateTree(null);
            CreateDaTa();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //if (treeList1.Nodes.Count != 0)
            //{
            //    ChuongTrinh_New ct = e.Node.Tag as ChuongTrinh_New;
            //    BindingDaTaChuongTrinh(ct);
            //}
            //else
            //{
            //    RefreshChuongTrinh();
            //}

            if (treeList1.Nodes.Count != 0)
            {
                ChuongTrinh_New ct = chuongTrinh_NewListAllBindingSource.Current as ChuongTrinh_New;
                BindingDaTaChuongTrinh(ct);
            }
            else
            {
                RefreshChuongTrinh();
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ktCTCha = false;
            KhoiTaoChuongTrinh();
            _ktCTCha = true;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //textEdit_Focus.Focus();
            if (KiemTraControl() == false)
            {
                return;
            }
            try
            {
                chuongTrinh_NewBindingSource.EndEdit();
                _chuongTrinh.ApplyEdit();
                _chuongTrinh.Save();

                //Cập nhật lại mã nguồn
                if (_capNhatNguon)
                {
                    _chuongTrinh_NewList.ApplyEdit();
                    _chuongTrinh_NewList.Save();
                }
                //
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshTree();
                treeList1.Refresh();

                LoadDanhSachChuongTrinhCha();

                //Không cho cập nhật mã nguồn nữa
                _capNhatNguon = false;
            }
            catch
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ChuongTrinh_New ct = treeList1.FocusedNode.Tag as ChuongTrinh_New;
            ChuongTrinh_New ct = chuongTrinh_NewListAllBindingSource.Current as ChuongTrinh_New;
            if (ct != null)
            {
                try
                {
                    DialogResult result = MessageBox.Show("Bạn thật sự muốn xóa " + ct.TenChuongTrinh + "- " + ct.MaQL + " và các chương trình con?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if ((result) == DialogResult.Yes)
                    {
                        childCount = 0;
                        DeleteNode(ct.MaChuongTrinh);
                        ChuongTrinh_New.DeleteChuongTrinh_New(ct.MaChuongTrinh);
                        MessageBox.Show("Xóa Thành Công " + ct.TenChuongTrinh + "- " + ct.MaQL + " và " + childCount + " chương trình con", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshChuongTrinh();
                        RefreshTree();
                        LoadDanhSachChuongTrinhCha();

                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show(ex.Message, "Không Thể Xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                treeList1.Refresh();
            }

        }

        private void rbChuaHoanTat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbChuaHoanTat.Checked == true)
            {
                _hoanTat = 0;
                SetIsSearch();
            }
            RefreshTree();
        }

        private void rbHoanTat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHoanTat.Checked == true)
            {
                _hoanTat = 1;
                SetIsSearch();
            }
            RefreshTree();
        }

        private void rbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTatCa.Checked == true)
            {
                _hoanTat = -1;
                SetIsSearch();
            }
            RefreshTree();
        }

        private void txt_TenChuongTrinhSearch_TextChanged(object sender, EventArgs e)
        {
            _tenChuongTrinhSearch = txt_TenChuongTrinhSearch.Text.Trim();

        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetIsSearch();
            RefreshTree();
        }

        private void cbMaPhanCap_ValueChanged(object sender, EventArgs e)
        {
            int maPhanCapTemp;
            if (int.TryParse(cbMaPhanCap.Value.ToString(), out maPhanCapTemp))
            {
                if (_chuongTrinh.IsNew)
                    _chuongTrinh.MaPhanCap = maPhanCapTemp;
                else
                    if (_chuongTrinh.MaPhanCap != maPhanCapTemp)
                        _chuongTrinh.MaPhanCap = maPhanCapTemp;
            }
        }

        private void txt_TenChuongTrinhSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetIsSearch();
                RefreshTree();

            }
        }


        private void gridLookUpEdit_ChuongTrinhList_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                ChuongTrinh_New ct = chuongTrinh_NewListAllBindingSource.Current as ChuongTrinh_New;
                if (ct != null)
                {
                    AddChuongTrinhtoDSChuongTrinhCha(ct.MaChuongTrinh);
                }
                else
                    MessageBox.Show("Hãy chọn chương trình cần thêm vào danh sách chương trình cha!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btn_ExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList1.ExpandAll();
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                treeList1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
            btnTim.PerformClick();
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void gridLookUpEdit_ChuongTrinhList_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit_ChuongTrinhList.EditValue != null)
            {
                ChuongTrinh_New ct = chuongTrinh_NewListAllBindingSource.Current as ChuongTrinh_New;
                if (ct != null)
                {
                    int maCTChaOld = ct.MaChuongTrinhCha;
                    if ((!ct.IsNew) && ct.IsDirty && _ktCTCha)
                    {
                        int mactChaGrd;
                        if (int.TryParse(gridLookUpEdit_ChuongTrinhList.EditValue.ToString(),out mactChaGrd))
                        {
                            if (mactChaGrd!=0 && ct.MaChuongTrinh == mactChaGrd)
                            {
                                MessageBox.Show("Chương trình Cha không thể là chính nó!");
                                ct.MaChuongTrinhCha = maCTChaOld;
                                gridLookUpEdit_ChuongTrinhList.EditValue = (object)maCTChaOld;
                                return;
                            }
                        }
                    }
                }
                //
            }
        }
        private void CheckParent(int parentID)
        {
            foreach (ChuongTrinh_New item in _chuongTrinh_NewList)
            {
                if (item.MaChuongTrinh == parentID)
                {
                    item.Chon = true;
                    if (item.MaChuongTrinhCha != null)
                        CheckParent(item.MaChuongTrinhCha);
                }
            }

        }
        private void CheckChild(int ID)
        {
            foreach (ChuongTrinh_New item in _chuongTrinh_NewList)
            {
                if (item.MaChuongTrinhCha == ID)
                {
                    item.Chon = true;
                    if (item.MaChuongTrinh != 0)
                        CheckChild(item.MaChuongTrinh);
                }
            }
        }
        private void RemoveCheckChild(int ID)
        {
            foreach (ChuongTrinh_New item in _chuongTrinh_NewList)
            {
                if (item.MaChuongTrinhCha == ID)
                {
                    item.Chon = false;
                    if (item.MaChuongTrinh != 0)
                        RemoveCheckChild(item.MaChuongTrinh);
                }
            }
        }

        private void treeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            //Lấy menu hiện tại
            ChuongTrinh_New currentChuongTrinh_New = chuongTrinh_NewListAllBindingSource.Current as ChuongTrinh_New;
            if (currentChuongTrinh_New == null)
                return;

            foreach (ChuongTrinh_New item in _chuongTrinh_NewList)
            {
                //----------------------------Bỏ check-------------------------------//
                if (item.MaChuongTrinh == currentChuongTrinh_New.MaChuongTrinh && currentChuongTrinh_New.Chon == true)
                {
                    item.Chon = false; //Bỏ check node hiện tại

                    //Bỏ check tất cả nút con
                    RemoveCheckChild(item.MaChuongTrinh);

                    //Gán bindingSource
                    chuongTrinh_NewListAllBindingSource.DataSource = _chuongTrinh_NewList;
                    treeList1.Refresh();
                    return;
                }

                //-----------------------------Check---------------------------------//
                if (item.MaChuongTrinh == currentChuongTrinh_New.MaChuongTrinh && currentChuongTrinh_New.Chon == false)
                {
                    item.Chon = true; //Check node hiện tại

                    //Check tất cả nút con
                    CheckChild(item.MaChuongTrinh);

                    //Gán bindingSource
                    chuongTrinh_NewListAllBindingSource.DataSource = _chuongTrinh_NewList;
                    treeList1.Refresh();
                    return;
                }
            }
        }

        private void gridLookUpEdit_Nguon_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit_Nguon.EditValue == null || gridLookUpEdit_Nguon.EditValue.ToString() =="")
                return;

            //Lấy giá trị vừa chọn
            int maNguon = (Int32)gridLookUpEdit_Nguon.EditValue;

            //Duyệt qua danh sách chương trình
            foreach (ChuongTrinh_New item in _chuongTrinh_NewList)
            {
                if (item.Chon)
                {
                    item.MaNguon = maNguon;
                    //
                    _capNhatNguon = true;
                }
            }
        }   
    }
}
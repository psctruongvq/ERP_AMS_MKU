using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using PSC_ERP_Common;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils;
using System.Text;
using System.IO;
using ERP_Library;
using ERP_Library.Security;
using DevExpress.XtraTreeList;
using System.Data;
using System.Data.OleDb;

using PSC_ERP;
using System.Data.SqlClient;

namespace PSC_ERPNew.Main
{
    public partial class frmBoPhanNew : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmBoPhanNew singleton_ = null;
        public static frmBoPhanNew Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmBoPhanNew();
                return singleton_;
            }
        }

        public static void ShowSingleton(object owner)
        {
            FormUtil.ShowForm_Helper(Singleton, owner);
        }
        #endregion

        //Private Member field
        #region Private Member field

        PhanQuyenSuDungForm _phanQuyen = null;
        BoPhanERPNewList _boPhanERPNewList = null;
        BoPhanERPNewList _boPhanList = null;
        TinhChatPhongList _tinhChatPhongList = null;
        public string strStatus = "KHOA";
        DataSet _dataSet;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmBoPhanNew()
        {
            InitializeComponent();
            _boPhanList = BoPhanERPNewList.NewBoPhanERPNewList();
            _boPhanERPNewList = BoPhanERPNewList.NewBoPhanERPNewList();
        }
        private void frmBoPhan_Load(object sender, EventArgs e)
        {
            // treeList_BoPhan.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            LoadData();
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            _boPhanERPNewList = BoPhanERPNewList.GetBoPhanERPNewList();
            tblnsBoPhanERP_BindingSource.DataSource = _boPhanERPNewList;

            _tinhChatPhongList = TinhChatPhongList.GetTinhChatPhongList();

            _boPhanList = BoPhanERPNewList.GetBoPhanERPNewList();
            BoPhanERPNew bpEmpt = BoPhanERPNew.NewBoPhanERPNew("<< Cấp I >>");
            _boPhanList.Insert(0, bpEmpt);

            tblnsBoPhanERPCha_BindingSource.DataSource = _boPhanList;
            tblTinhChatPhong_bindingSource.DataSource = _tinhChatPhongList;
            TreeUtils.SetSTTForTreeListView(treeList_BoPhan); //STT
            treeList_BoPhan.ForceInitialize();
            //You must call the ForceInitialize method before changing a TreeList's options
            treeList_BoPhan.BestFitColumns();
        }
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = ERP_Library.PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btn_ThemMoi.Enabled = _phanQuyen.Them;
            btnSua.Enabled = _phanQuyen.Sua;
            btnXoa.Enabled = _phanQuyen.Xoa;
            btn_Import.Enabled = _phanQuyen.Them;
        }
        private void ReadOnlyConTrolByStatus(string strStatus)
        {
            if (strStatus == "" || strStatus == "THEM" || strStatus == "SUA")
            {
                #region old
                //foreach (var c in splitContainerControl1.Panel1.Controls)//
                //{
                //    if (c is TreeListLookUpEdit)
                //    {
                //        ((TreeListLookUpEdit)c).Properties.ReadOnly = false;
                //    }
                //    else if (c is TextEdit)
                //    {
                //        ((TextEdit)c).Properties.ReadOnly = false;
                //    }
                //    else if (c is RichTextBox)
                //    {
                //        ((RichTextBox)c).ReadOnly = false;
                //        ((RichTextBox)c).BackColor = System.Drawing.Color.White;
                //    }
                //    else if (c is SpinEdit)
                //    {
                //        ((SpinEdit)c).Properties.ReadOnly = false;
                //    }
                //}
                #endregion

                txtMaQuanLy.Properties.ReadOnly = false;
                txtTen.Properties.ReadOnly = false;
                txtDienGiai.Properties.ReadOnly = false;
                textEdit2.Properties.ReadOnly = false; //txt tên tiếng anh
                cbPhongBan.Properties.ReadOnly = false;
                txtViTri.Properties.ReadOnly = false;
                txtDonViSuDung.Properties.ReadOnly = false;
                txtQuyPhongXepTKB.Properties.ReadOnly = false;
                txtMaKhoiNhaCu.Properties.ReadOnly = false;
                txtMaKhoiNhaMoi.Properties.ReadOnly = false;
                txtSoPhong.Properties.ReadOnly = false;
                cbTinhChatPhong.Properties.ReadOnly = false;
                txtMaHoaPhongNhomHoaThat.Properties.ReadOnly = false;
                txtMaPhongHKEdusoft.Properties.ReadOnly = false;
                rtxtGhiChu.ReadOnly = false;
                rtxtGhiChu.BackColor = System.Drawing.Color.White;
                numChoNgoiThucTe.Properties.ReadOnly = false;
                numChoNgoiThietKe.Properties.ReadOnly = false;
                numDienTich.Properties.ReadOnly = false;
                check_IsNgungSuDung.ReadOnly = false;
                date_NgayNgungSuDung.ReadOnly = false;
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btn_ThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                treeList_BoPhan.Enabled = false;

            }
            else if (strStatus == "KHOA")
            {
                txtMaQuanLy.Properties.ReadOnly = true;
                txtTen.Properties.ReadOnly = true;
                txtDienGiai.Properties.ReadOnly = true;
                textEdit2.Properties.ReadOnly = true; //txt tên tiếng anh
                cbPhongBan.Properties.ReadOnly = true;
                txtViTri.Properties.ReadOnly = true;
                txtDonViSuDung.Properties.ReadOnly = true;
                txtQuyPhongXepTKB.Properties.ReadOnly = true;
                txtMaKhoiNhaCu.Properties.ReadOnly = true;
                txtMaKhoiNhaMoi.Properties.ReadOnly = true;
                txtSoPhong.Properties.ReadOnly = true;
                cbTinhChatPhong.Properties.ReadOnly = true;
                txtMaHoaPhongNhomHoaThat.Properties.ReadOnly = true;
                txtMaPhongHKEdusoft.Properties.ReadOnly = true;
                rtxtGhiChu.ReadOnly = true;
                rtxtGhiChu.BackColor = System.Drawing.Color.FromArgb(239, 239, 241);
                numChoNgoiThucTe.Properties.ReadOnly = true;
                numChoNgoiThietKe.Properties.ReadOnly = true;
                numDienTich.Properties.ReadOnly = true;
                check_IsNgungSuDung.ReadOnly = true;
                date_NgayNgungSuDung.ReadOnly = true;
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btn_ThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                treeList_BoPhan.Enabled = true;
            }
            PhanQuyenThemSuaXoa();
        }



        private Boolean Save()
        {
            txtBlack.Focus();
            //kiểm tra dữ liệu trước khi lưu
            bool kq;

            var o = (BoPhanERPNew)tblnsBoPhanERP_BindingSource.Current;
            int soTSDangChua = dt_TSCDCB_TaiViTri(o.MaBoPhan).Rows.Count;
            if (dt_TSCDCB_TaiViTri(o.MaBoPhan).Rows.Count > 0 && check_IsNgungSuDung.Checked == true)
            {
                XtraMessageBox.Show($"Tại vị trí <b>{o.MaBoPhanQL} - {o.DienGiai} </b>còn <color=red>{soTSDangChua} Tài sản </color> .\n\n Vui lòng xử lý trước khi ngừng sử dụng vị trí!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, DefaultBoolean.True);
                check_IsNgungSuDung.CausesValidation = false;
                check_IsNgungSuDung.Checked = false;
                return false;
            }

            try
            {
                using (DialogUtil.WaitForSave())
                {
                    _boPhanERPNewList.BeginEdit();
                    treeList_BoPhan.BeginUpdate();
                    treeList_BoPhan.EndUpdate();
                    _boPhanERPNewList.ApplyEdit();
                    _boPhanERPNewList.Save();
                    DialogUtil.ShowSaveSuccessful();
                    kq = true;
                    return kq;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lý Do: <color=red> {ex.ToString()}</color>  \n\n Nên Không Thể Lưu Dữ Liệu "
                       , "Cảnh Báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
                //thông báo không xóa được
                XtraMessageBox.Show($"Lý Do: <color=red> {treeList_BoPhan.GetColumnError(treeList_BoPhan.Columns.ColumnByFieldName("MaBoPhanQL")).ToString()}</color>  \n\n Nên Không Thể Lưu Dữ Liệu "
                        , "Cảnh Báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);

                _boPhanERPNewList.CancelEdit();
                _boPhanERPNewList = BoPhanERPNewList.GetBoPhanERPNewList();
                tblnsBoPhanERP_BindingSource.DataSource = _boPhanERPNewList;
                kq = false;
            }

            return kq;
        }

        #endregion

        //Event Method
        #region Event Method
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.strStatus == "THEM")
            {
                if (_boPhanERPNewList.Select(x => x.MaBoPhanQL.ToLower().Equals(txtMaQuanLy.Text.ToLower())).Count() > 1)
                {
                    if (MessageBox.Show("Lưu ý! Mã hóa phòng này đã tồn tại, bạn chắc chắn tạo vị trí mới với mã " + txtMaQuanLy.Text + "?", "Cảnh báo trùng mã", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    else
                        rtxtGhiChu.Text = rtxtGhiChu.Text + "Tạo mới trùng mã";
                }
            }           


            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);

            this.Save();
            btnRefresh.PerformClick();
        }
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            this.LoadData();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private bool KiemTraTSTruocKhiXoa(BoPhanERPNew obj)
        {
            if (obj.KhauHaoHaoMon == true)
            {
                DialogUtil.ShowError("Vui lòng xóa các Bộ phận con của bộ phận này " + obj.TenBoPhan + " trước!");
                return false;
            }
            return true;
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var tenBoPhan = _boPhanERPNewList.ElementAt(tblnsBoPhanERP_BindingSource.Position).TenBoPhan;
            DialogResult dlgResult =
            XtraMessageBox.Show($"Bạn Có Chắc Muốn Xóa Bộ Phận: <color=red > {_boPhanERPNewList.ElementAt(tblnsBoPhanERP_BindingSource.Position).TenBoPhan}</color>"
                        , "Cảnh Báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
            if (KiemTraTSTruocKhiXoa(GetObject_AtNode(treeList_BoPhan.FocusedNode)))
            {
                if (dlgResult == DialogResult.Yes)
                {
                    try
                    {
                        using (DialogUtil.WaitForDelete(this))
                        {
                            _boPhanERPNewList.BeginEdit();
                            treeList_BoPhan.BeginDelete();
                            treeList_BoPhan.DeleteSelectedNodes();
                            treeList_BoPhan.EndDelete();

                            _boPhanERPNewList.ApplyEdit();
                            _boPhanERPNewList.Save();
                        }
                        //thông báo đã xóa thành công
                        DialogUtil.ShowDeleteSuccessful();
                    }
                    catch (Exception ex)
                    {
                        //thông báo không xóa được
                        XtraMessageBox.Show($"Bộ Phận: <color=red > {tenBoPhan.ToString()}</color> Đã Phát Sinh Dữ Liệu Liên Kết! \n Nên Không Thể Xóa "
                              , "Cảnh Báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
                        DialogUtil.ShowError("Xóa không thành công!\n" + ex.Message + "\n" + ex.InnerException);
                        _boPhanERPNewList.CancelEdit();
                        _boPhanERPNewList = BoPhanERPNewList.GetBoPhanERPNewList();
                        tblnsBoPhanERP_BindingSource.DataSource = _boPhanERPNewList;
                    }
                }
            }
        }
        #endregion

        private void frmBoPhanNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlack.Focus();
            if (_boPhanERPNewList.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    if (false == this.Save())
                        e.Cancel = true;
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

        private void btn_xuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //xuất excel danh sách phòng ban
            treeList_BoPhan.ExpandAll();
            //xuất excel cây danh mục
            TreeUtils.ExportToExcel(treeList: treeList_BoPhan, showOpenFilePrompt: true);
        }
        private BoPhanERPNew GetObject_AtNode(TreeListNode node)
        {
            return treeList_BoPhan.GetDataRecordByNode(node) as BoPhanERPNew;
        }

        private void btn_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);

            //BoPhanERPNew currentObject = GetObject_AtNode(treeList_BoPhan.FocusedNode);
            Boolean duocPhepThemMoi = true;
            if (_boPhanERPNewList.IsDirty)
            {
                if (this.Save())
                    duocPhepThemMoi = true;
                else
                    duocPhepThemMoi = false;
            }

            //được phép thêm mới
            if (duocPhepThemMoi)
            {

                BoPhanERPNew newObj = BoPhanERPNew.NewBoPhanERPNewChild();
                //if (currentObject != null)
                //    newObj.MaBoPhanCha = currentObject.MaBoPhan;

                _boPhanERPNewList.Add(newObj);

                tblnsBoPhanERP_BindingSource.DataSource = _boPhanERPNewList;

                txtMaQuanLy.Focus();
            }
        }

        private void btn_Import_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                OpenFileDialog oFD = new OpenFileDialog() { Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx" };
                oFD.ShowDialog();
                DataSet dsRerult = ImportExcelXLSToDataset(oFD.FileName, true);
                ImportToChungTuFromDataSet(dsRerult);
            }
            catch
            {
                MessageBox.Show("Không thể đọc file!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private DataSet ImportExcelXLSToDataset(string FileName, bool hasHeaders)
        {

            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xls")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

            _dataSet = new DataSet();
            DataTable outputTable = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (sheet == "tblBoPhanERPNewImport$")
                    {
                        try
                        {
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A1:T]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            outputTable.TableName = "tblBoPhanERPNew";
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                            _dataSet.Tables.Add(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }

                }
            }

            return _dataSet;

        }

        private void ImportToChungTuFromDataSet(DataSet dsresult)
        {
            BoPhanERPNew _boPhanERPNew;
            #region old
            MessageBox.Show("Chọn nơi lưu file chứa các đối tượng lỗi không thêm được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Text File|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //tạo file template
                FileStream fsa = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fsa.Close();
            }
            string filepath = dlg.FileName;
            FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt)//fs là 1 FileStream 
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
            sWriter.WriteLine("Danh Sách Các Dòng Bị Lỗi Lúc Import");
            //Ghi và đóng file
            sWriter.Flush();

            fs.Close();
            #endregion
            if (dsresult.Tables.Count == 0) return;
            DataTable tblBoPhanERPNew = new DataTable();
            tblBoPhanERPNew = dsresult.Tables["tblBoPhanERPNew"];
            if (tblBoPhanERPNew.Rows.Count > 0)
            {
                foreach (DataRow rowhd in tblBoPhanERPNew.Rows)
                {
                    if (rowhd[6].ToString().Trim().Length > 0)
                    {
                        if (BoPhanERPNewList.KiemTraBoPhanERPNewTonTai(_boPhanERPNewList, rowhd[6].ToString().Trim()))//Update
                        {
                            _boPhanERPNew = _boPhanERPNewList.Single(o => o.MaBoPhanQL == (rowhd[6].ToString().Trim()));
                            try
                            {
                                //rowhd[0] Cơ Sở k có cột trong CSDL 
                                if (rowhd[1].ToString().Trim().Length > 0)
                                    _boPhanERPNew.MaBoPhanCha = BoPhanERPNewList.GetMaBoPhanByMaBoPhanQL(_boPhanERPNewList, rowhd[1].ToString().Trim());
                                _boPhanERPNew.ViTri = rowhd[2].ToString().Trim();
                                _boPhanERPNew.MaKhoiNhaCu = rowhd[3].ToString().Trim();
                                _boPhanERPNew.MaKhoiNhaMoi = rowhd[4].ToString().Trim();
                                //rowhd[5] Số Phòng k có cột trong CSDL 
                                //_boPhanERPNew.MaBoPhanQL = rowhd[6].ToString().Trim(); //k xai
                                _boPhanERPNew.MaHoaPhongNhomHoaThat = rowhd[7].ToString().Trim();
                                _boPhanERPNew.MaPhongHKEdusoft = rowhd[8].ToString().Trim();
                                _boPhanERPNew.TenBoPhan = rowhd[9].ToString().Trim();
                                _boPhanERPNew.DienGiai = rowhd[10].ToString().Trim();
                                _boPhanERPNew.TenTiengAnh = rowhd[11].ToString().Trim();
                                if (rowhd[12].ToString().Trim().Length > 0)
                                    _boPhanERPNew.MaTinhChatPhong = TinhChatPhongList.GetMaBoPhanByMaBoPhanQL(_tinhChatPhongList, rowhd[12].ToString().Trim());
                                //rowhd[13] Tên Tính Chất k có cột trong CSDL 
                                if (rowhd[14].ToString().Trim().Length > 0)
                                    _boPhanERPNew.SoChoNgoiTheoThucTe = Convert.ToInt32(rowhd[14].ToString().Trim());
                                if (rowhd[15].ToString().Trim().Length > 0)
                                    _boPhanERPNew.SoChoNgoiTheoThietKe = Convert.ToInt32(rowhd[15].ToString().Trim());
                                if (rowhd[16].ToString().Trim().Length > 0)
                                    _boPhanERPNew.DienTich = Convert.ToDecimal(rowhd[16].ToString().Trim());
                                _boPhanERPNew.DonViSuDung = rowhd[17].ToString().Trim();
                                _boPhanERPNew.GhiChu = rowhd[18].ToString().Trim();
                                _boPhanERPNew.QuyPhongXepTKB = rowhd[19].ToString().Trim();



                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(ex.ToString(), "Error", buttons: MessageBoxButtons.OK);
                                LogImportError(filepath, _boPhanERPNew, ex.ToString());
                            }

                        }
                        else if (!BoPhanERPNewList.KiemTraBoPhanERPNewTonTai(_boPhanERPNewList, rowhd[6].ToString().Trim())) //insert
                        {
                            _boPhanERPNew = BoPhanERPNew.NewBoPhanERPNew();
                            try
                            {

                                //rowhd[0] Cơ Sở k có cột trong CSDL 
                                if (rowhd[1].ToString().Trim().Length > 0)
                                    _boPhanERPNew.MaBoPhanCha = BoPhanERPNewList.GetMaBoPhanByMaBoPhanQL(_boPhanERPNewList, rowhd[1].ToString().Trim());
                                _boPhanERPNew.ViTri = rowhd[2].ToString().Trim();
                                _boPhanERPNew.MaKhoiNhaCu = rowhd[3].ToString().Trim();
                                _boPhanERPNew.MaKhoiNhaMoi = rowhd[4].ToString().Trim();
                                // rowhd[5] Số Phòng k có cột trong CSDL
                                _boPhanERPNew.MaBoPhanQL = rowhd[6].ToString().Trim();
                                _boPhanERPNew.MaHoaPhongNhomHoaThat = rowhd[7].ToString().Trim();
                                _boPhanERPNew.MaPhongHKEdusoft = rowhd[8].ToString().Trim();
                                _boPhanERPNew.TenBoPhan = rowhd[9].ToString().Trim();
                                _boPhanERPNew.DienGiai = rowhd[10].ToString().Trim();
                                _boPhanERPNew.TenTiengAnh = rowhd[11].ToString().Trim();
                                if (rowhd[12].ToString().Trim().Length > 0)
                                    _boPhanERPNew.MaTinhChatPhong = TinhChatPhongList.GetMaBoPhanByMaBoPhanQL(_tinhChatPhongList, rowhd[12].ToString().Trim());
                                //  rowhd[13] Tên Tính Chất k có cột trong CSDL
                                if (rowhd[14].ToString().Trim().Length > 0)
                                    _boPhanERPNew.SoChoNgoiTheoThucTe = Convert.ToInt32(rowhd[14].ToString().Trim());
                                if (rowhd[15].ToString().Trim().Length > 0)
                                    _boPhanERPNew.SoChoNgoiTheoThietKe = Convert.ToInt32(rowhd[15].ToString().Trim());
                                if (rowhd[16].ToString().Trim().Length > 0)
                                    _boPhanERPNew.DienTich = Convert.ToDecimal(rowhd[16].ToString().Trim());
                                _boPhanERPNew.DonViSuDung = rowhd[17].ToString().Trim();
                                _boPhanERPNew.GhiChu = rowhd[18].ToString().Trim();
                                _boPhanERPNew.QuyPhongXepTKB = rowhd[19].ToString().Trim();

                                _boPhanERPNewList.Add(_boPhanERPNew);
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(ex.ToString(), "Error", buttons: MessageBoxButtons.OK);
                                LogImportError(filepath, _boPhanERPNew, ex.ToString());
                            }

                        }
                    }
                }

            }

            DialogResult NCC = MessageBox.Show("Bạn có muốn lưu đối tượng mới import", "Thông báo!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (NCC == DialogResult.OK)
            {
                btnLuu.PerformClick();
                _boPhanERPNewList = BoPhanERPNewList.GetBoPhanERPNewList();
                tblnsBoPhanERP_BindingSource.DataSource = _boPhanERPNewList;
            }

        }
        private void LogImportError(string filepath, BoPhanERPNew BoPhanERPNewImport, string error)
        {
            System.IO.StreamWriter str = System.IO.File.AppendText(filepath);
            str.WriteLine($" {BoPhanERPNewImport.MaBoPhanQL} : {error}");
            str.Close();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);

        }

        private void treeList_BoPhan_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            BoPhanERPNew currentObject = GetObject_AtNode(e.Node);
            if (!_phanQuyen.Sua)// không có quyển sửa thì hiện cảnh báo 
            {
                if (!currentObject.IsNew) //thì là dữ liệu cũ 
                {
                    XtraMessageBox.Show("Bạn chưa được cấp quyền <color=red>Sửa</color> dữ liệu cũ.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, DefaultBoolean.True);
                }
            }
        }

        private void treeList_BoPhan_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "MaBoPhanQL" && IsDuplicatedMaBoPhanQL(e.Value))
            {
                DuplicatedValueWarning(sender, e);
            }
            if (!IsDuplicatedMaBoPhanQL(e.Value))
            {
                ((DevExpress.XtraTreeList.TreeList)sender).ClearColumnErrors();
            }
        }
        private void DuplicatedValueWarning(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            var treeList = sender as DevExpress.XtraTreeList.TreeList;
            XtraMessageBox.Show(String.Format($"Dữ Liệu <color=red>\"{e.Value.ToString()}\"</color> đã tồn tại !"), "Thông Báo ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);

            try
            {
                // treeList.CancelCurrentEdit();
                treeList.SetColumnError(e.Column, "Dữ liệu trùng lặp !");
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
        private Boolean IsDuplicatedMaBoPhanQL(object someValue)
        {
            var linq = (_boPhanERPNewList.Where(o => o.MaBoPhanQL == someValue.ToString())).Count();
            return linq > 1;
        }

        private void txtMaQuanLy_Validated(object sender, EventArgs e)
        {
            //if (IsDuplicatedMaBoPhanQL(txtMaQuanLy.EditValue))
            //{
            //    try
            //    {
            //        txtMaQuanLy.ErrorText = "Dữ liệu trùng lặp !";
            //        txtMaQuanLy.Focus();
            //    }
            //    catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            //}
            if (string.IsNullOrEmpty(txtMaQuanLy.EditValue.ToString()))
            {
                try
                {
                    ((TextEdit)sender).ErrorText = "Mã Không Được Trống!";
                    ((TextEdit)sender).Focus();
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }
        }

        private void txtTen_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.EditValue.ToString()))
            {
                try
                {
                    txtTen.ErrorText = "Tên Không Được Trống!";
                    txtTen.Focus();
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
            }
        }
        private void frmBoPhanNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (_phanQuyen.Xoa && e.KeyCode == Keys.Delete)
            {
                btnXoa.PerformClick();
            }
        }

        private void treeList_BoPhan_GetNodeDisplayValue(object sender, GetNodeDisplayValueEventArgs e)
        {
            //if (e.Column.Name.Equals("colQuyPhongXepTKB"))
            //{
            //    var info = (BoPhanERPNew)treeList_BoPhan.GetDataRecordByNode(e.Node);
            //    if(info != null && info.MaTinhChatPhong > 0)
            //        e.Value = _tinhChatPhongList.Single(o => o.MaTinhChatPhong == info.MaTinhChatPhong).DienGiaiText;
            //}
        }

        private void MaHoaPhongAutoGen(BoPhanERPNew o)
        {
            if (o.MaBoPhanCha == null) return;
            if (o.MaBoPhanCha == 0 || strStatus == "KHOA") return;

            if ((o.SoPhong != "") && (o.MaKhoiNhaMoi != ""))
                o.MaBoPhanQL = $"{_boPhanERPNewList.Where(list => list.MaBoPhan == o.MaBoPhanCha).Select(list => list.MaBoPhanQL).First()}.{o.MaKhoiNhaMoi}.{o.SoPhong}";
            else if (o.SoPhong == "" && o.MaKhoiNhaMoi != "")
                o.MaBoPhanQL = $"{_boPhanERPNewList.Where(list => list.MaBoPhan == o.MaBoPhanCha).Select(list => list.MaBoPhanQL).First()}.{o.MaKhoiNhaMoi}";
            else if (o.SoPhong == "" && o.MaKhoiNhaMoi == "")
                o.MaBoPhanQL = $"{_boPhanERPNewList.Where(list => list.MaBoPhan == o.MaBoPhanCha).Select(list => list.MaBoPhanQL).First()}";
        }

        private void txtMaKhoiNhaMoi_EditValueChanged(object sender, EventArgs e)
        {
            var o = (BoPhanERPNew)tblnsBoPhanERP_BindingSource.Current;
            if ((sender as TextEdit).EditValue != DBNull.Value)
                o.MaKhoiNhaMoi = (sender as TextEdit).EditValue.ToString();
            MaHoaPhongAutoGen(o);
        }

        private void txtSoPhong_EditValueChanged(object sender, EventArgs e)
        {
            var o = (BoPhanERPNew)tblnsBoPhanERP_BindingSource.Current;
            if ((sender as TextEdit).EditValue != DBNull.Value)
                o.SoPhong = (sender as TextEdit).EditValue.ToString();
            MaHoaPhongAutoGen(o);
        }

        private void cbPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            var o = (BoPhanERPNew)tblnsBoPhanERP_BindingSource.Current;
            if ((sender as TextEdit).EditValue != DBNull.Value)
                o.MaBoPhanCha = (int)(sender as TextEdit).EditValue;
            MaHoaPhongAutoGen(o);
        }

        private void treeList_BoPhan_DoubleClick(object sender, EventArgs e)
        {
            var o = (BoPhanERPNew)tblnsBoPhanERP_BindingSource.Current;
            frmDanhSachTaiSanTaiViTri frm = new frmDanhSachTaiSanTaiViTri(o.MaBoPhan);
            frm.ShowDialog();

        }

        private void check_IsNgungSuDung_Validated(object sender, EventArgs e)
        {
            var o = (BoPhanERPNew)tblnsBoPhanERP_BindingSource.Current;
            int soTSDangChua = dt_TSCDCB_TaiViTri(o.MaBoPhan).Rows.Count;
            if (dt_TSCDCB_TaiViTri(o.MaBoPhan).Rows.Count > 0)
            {
                XtraMessageBox.Show($"Tại vị trí <b>{o.MaBoPhanQL} - {o.DienGiai} </b>còn <color=red>{soTSDangChua} Tài sản </color> .\n\n Vui lòng xử lý trước khi ngừng sử dụng vị trí!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, DefaultBoolean.True);
                ((CheckEdit)sender).CausesValidation = false;
                ((CheckEdit)sender).Checked = false;
            }
        }

        public static DataTable dt_TSCDCB_TaiViTri(int maViTri)
        {
            DataTable kq = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandTimeout = 1800;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DanhSachTSTaiViTri";
                        cm.Parameters.AddWithValue("@MaViTri", maViTri);
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        da.Fill(kq);
                    }
                }
                return kq;
            }
            catch (Exception ThongBaoLoi) { XtraMessageBox.Show("<color=red>-Lỗi: </color>" + ThongBaoLoi.ToString(), "ĐÃ XẢY RA LỖI", DevExpress.Utils.DefaultBoolean.True); return kq; }
        }
    }
}
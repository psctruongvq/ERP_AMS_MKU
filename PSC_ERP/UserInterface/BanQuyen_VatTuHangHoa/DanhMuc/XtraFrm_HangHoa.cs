using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.Data;
using System.IO;
using System.Data.OleDb;
using PSC_ERP_Common;
//08_04_13
namespace PSC_ERP
{
    public partial class XtraFrm_HangHoa : XtraForm
    {
        //event update lookupedit
        public event EventHandler OnHangHoaUpdated;

        #region Properties and Methods
        private int mahh = 0;
        HangHoaBQ_VT hh;
        HangHoaBQ_VTList _hhSSList;
        HangHoaBQ_VTList _hangHoaBQ_VTList;
        DonViTinhList _donViTinhBQ_VTList;
        NhomHangHoaBQ_VTList _nhomHangHoaBQ_VTList;
        private DataTable tblHangHoa;
        private bool _checkThemMoi = false;
        DataSet _dataSet = new DataSet();
        string _FileNameImport = ""; 
        int _loai = 0;
        int _maHangHoaChon = 0;
        int _maChuongTrinhConChon = 0;
        bool themMoi = false;
        public int MaHangHoaChon
        {
            get { return _maHangHoaChon; }

        }
        public int MaChuongTrinhConChon
        {
            get { return _maChuongTrinhConChon; }

        }
        #endregion //Properties and Methods
        private void DinhDangLable()
        {
            this.lb_MaHangHoa.Text = "Mã chương trình:";
            this.lb_TenHangHoa.Text = "Tên chương trình:";
            this.lb_TenNhomHangHoa.Text = "Tên nhóm chương trình:";
            //Grid
            //this.colMaQuanLy.Caption = "Mã Chương Trình";
            this.colTenHangHoa.Caption = "Tên Chương Trình";
            // this.colMaNhomHangHoa.Caption = "Nhóm Chương Trình";
        }
        private void LoadForm(int loai)
        {
            _loai = loai;
            bs_DSHangHoaListAll.DataSource = typeof(HangHoaBQ_VTList);
            bs_DonViTinhList.DataSource = typeof(DonViTinhList);
            bs_NhomHangHoaList.DataSource = typeof(NhomHangHoaBQ_VTList);
            bs_HangCungCapList.DataSource = typeof(HangCungCapBQ_VTList);

            if (_loai == 1)//HangHoaBanQuyen
            {
                _hangHoaBQ_VTList = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
                DinhDangLable();
                contextMenuStrip_ChuongTrinhCon.Enabled = true;
                lb_NuocSanXuat.Visible = false;
                lookUpEdit_Nuocsanxuat.Visible = false;
                this.colMaQuocGia.Visible = false;
            }
            else if (_loai == 0)//ShowHangHoaVatTu
            {
                //_hangHoaBQ_VTList = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
                _hangHoaBQ_VTList = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList_2018(DateTime.Now.AddHours(23).AddMinutes(59).AddSeconds(59));
                contextMenuStrip_ChuongTrinhCon.Enabled = false;
            }
            else if (_loai == 3)//CCDC
            {
                _hangHoaBQ_VTList = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
                contextMenuStrip_ChuongTrinhCon.Enabled = false;
            }

            bs_DSHangHoaListAll.DataSource = _hangHoaBQ_VTList;
            grd_DSHangHoa.DataSource = bs_DSHangHoaListAll;

            _donViTinhBQ_VTList = DonViTinhList.GetDonViTinhList();
            bs_DonViTinhList.DataSource = _donViTinhBQ_VTList;
            QuocGiaBQ_VTList _quocGiaList = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList();
            QuocGiaBQ_VT qg = QuocGiaBQ_VT.NewQuocGiaBQ_VT("<<Không chọn>>");
            _quocGiaList.Insert(0, qg);
            bs_QuocGiaList.DataSource = _quocGiaList;
            bs_QuocGiaList1.DataSource = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList();
            //
            if (_loai == 1)
                _nhomHangHoaBQ_VTList = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListTheoLoaiVatTu(1);
            else if (_loai == 3)
            {
                _nhomHangHoaBQ_VTList = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListTheoLoaiVatTu(3);
            }
            else _nhomHangHoaBQ_VTList = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListVatTuHangHoa();
            bs_NhomHangHoaList.DataSource = _nhomHangHoaBQ_VTList;
            //
            HeThongTaiKhoan1List danhSachTaiKhoan = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            HeThongTaiKhoan1 taiKhoan_KhongChon = HeThongTaiKhoan1.NewHeThongTaiKhoan1("<<Không chọn>>");
            danhSachTaiKhoan.Insert(0, taiKhoan_KhongChon);
            heThongTaiKhoan1ListKho_BindingSource.DataSource = danhSachTaiKhoan;
            heThongTaiKhoan1ListPhanBo_BindingSource.DataSource = danhSachTaiKhoan;
            heThongTaiKhoan1ListChoPhanBo_BindingSource.DataSource = danhSachTaiKhoan;
        }

        public void ShowHangHoaBanQuyen()
        {
            LoadForm(1);
            this.Show();
        }

        public void ShowHangHoaVatTu()
        {
            LoadForm(0);
            this.Show();
        }

        public XtraFrm_HangHoa()
        {
            InitializeComponent();
        }
        public XtraFrm_HangHoa(byte loai)
        {
            InitializeComponent();
            LoadForm(loai);
            themMoi = true;
            _checkThemMoi = true;
            if (loai != 1)
            {
                hh = HangHoaBQ_VT.NewHangHoaBQ_VT();
                _hangHoaBQ_VTList.Insert(0, hh);
            }
        }
        public XtraFrm_HangHoa(HangHoaBQ_VT newHangHoa)
        {
            InitializeComponent();

            this.colMaQuanLy.SortOrder = ColumnSortOrder.None;//khong cho sort
            LoadForm(3);
            hh = newHangHoa;
            _hangHoaBQ_VTList.Insert(0, newHangHoa);
            gridView_DSHangHoa.MoveFirst();
            //if (newHangHoa.MaHangHoa != 0)
            //{
            //    newHangHoa.MaQuanLy = LayMaQuanLyMoi(newHangHoa.MaNhomHangHoa);
            //}
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                hh = HangHoaBQ_VT.NewHangHoaBQ_VT();
                _hangHoaBQ_VTList.Insert(0, hh);
                //grd_DSHangHoa.
                lookUpEdit_NhomHangHoa.Focus();
                _checkThemMoi = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (txtDev_Mahanghoa.EditValue != null)//IF 1
            {
                string _maQuanLy = txtDev_Mahanghoa.EditValue.ToString().Trim();
                int _lengthMaQL = _maQuanLy.Length;
                int _stt;
                //// MessageBox.Show(_maQuanLy.Substring(_lengthMaQL - 4, 4));
                //if (_lengthMaQL >= 4 && int.TryParse(_maQuanLy.Substring(_lengthMaQL - 4, 4), out _stt))//IF 2
                //{
                    bool ktphieutrung = true;
                    if (hh.IsNew)
                    {
                        ktphieutrung = HangHoaBQ_VT.CheckMaQuanLyHangHoaKhongTrung(hh.MaHangHoa, hh.MaQuanLy, true);
                    }
                    else//k phai IS NEW
                    {
                        ktphieutrung = HangHoaBQ_VT.CheckMaQuanLyHangHoaKhongTrung(hh.MaHangHoa, hh.MaQuanLy, false);
                    }

                    if (ktphieutrung)//IF 5
                    {
                        try
                        {
                            _hangHoaBQ_VTList.ApplyEdit();
                            bs_DSHangHoaListAll.EndEdit();
                            _hangHoaBQ_VTList.Save();

                            if (DialogResult.OK == MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information))
                            {
                                if (themMoi)
                                {
                                    if (bs_DSHangHoaListAll.Current != null)
                                    {
                                        HangHoaBQ_VT hhChon;
                                        hhChon = (HangHoaBQ_VT)bs_DSHangHoaListAll.Current;
                                        _maHangHoaChon = hhChon.MaHangHoa;

                                        _checkThemMoi = false;
                                    }
                                    this.Close();
                                }
                                else

                                    this.DialogResult = DialogResult.OK;

                                //if (OnHangHoaUpdated != null)
                                //    OnHangHoaUpdated(this, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            DialogUtil.ShowWarning("Không thể lưu!\n"+ ex.Message);
                        }
                        //E
                    }//END IF 5
                    else
                    {
                        MessageBox.Show("Trùng Mã Hàng hóa ! Không Thể Lưu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDev_Mahanghoa.Focus();
                    }
                //}//END IF 2
                //else
                //{
                //    MessageBox.Show("Mã Hàng hóa Không Hợp Lệ! 4 ký tự cuối phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtDev_Mahanghoa.Focus();
                //}
            }//END IF 4
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridView_DSHangHoa.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhấn nút Refesh trước khi thực hiện thao tác Xóa!\n" + ex.Message);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_loai == 1)
                _hangHoaBQ_VTList = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            else _hangHoaBQ_VTList = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
            bs_DSHangHoaListAll.DataSource = _hangHoaBQ_VTList;
            grd_DSHangHoa.DataSource = bs_DSHangHoaListAll;
            _checkThemMoi = false;
        }

        private string LayMaQuanLyMoi(int maNhomHH)
        {
            //NhomHangHoaBQ_VT nhom = NhomHangHoaBQ_VT.GetNhomHangHoaBQ_VT(maNhomHH);
            //{
            //    int sizeOfNumber = 4;
            //    string maQuanLyMoi = nhom.MaQuanLy + new String('0', sizeOfNumber - 1) + "1";
            //    string maxMaQuanLy = HangHoaBQ_VT.Get_MaxMaQuanLy(maNhomHH, sizeOfNumber);
            //    if (maxMaQuanLy != "Null")
            //    {

            //        int max = int.Parse(maxMaQuanLy.Substring(maxMaQuanLy.Length - sizeOfNumber, sizeOfNumber));
            //        int soMoi = max + 1;
            //        string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

            //        maQuanLyMoi = nhom.MaQuanLy + stringSoMoi;
            //    }
            //    return maQuanLyMoi;
            //}
            return "";
        }

        private void XtraFrm_HangHoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region old
            //this.txtBlackHole.Focus();
            //if (hh.IsDirty)
            //{
            //    DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //    if (kq == DialogResult.Yes && !themMoi)
            //    {
            //        btnLuu.PerformClick();
            //    }
            //    else
            //        if (kq == DialogResult.Cancel)
            //        {
            //            e.Cancel = true;
            //        }
            //}
            #endregion 
        }

        private void XtraFrm_HangHoa_Load(object sender, EventArgs e)
        {
            if (bs_DSHangHoaListAll.Current != null)
            {
                hh = bs_DSHangHoaListAll.Current as HangHoaBQ_VT;
            }
            else
            {
                hh = HangHoaBQ_VT.NewHangHoaBQ_VT();
            }
            gridView_DSHangHoa.OptionsNavigation.AutoFocusNewRow = true;
            Utils.GridUtils.SetSTTForGridView(gridView_DSHangHoa, 35);
            HamDungChung.AllowEditColumnGridViewDev(gridView_DSHangHoa);
        }

        private void lookUpEdit_NhomHangHoa_EditValueChanged(object sender, EventArgs e)
        {
            #region // old
            // ??
            //if (lookUpEdit_NhomHangHoa.EditValue != null)
            //{
            //    HangHoaBQ_VT hanghoa = gridView_DSHangHoa.GetFocusedRow() as HangHoaBQ_VT;
            //    if (hanghoa != null)
            //    {
            //        if (hanghoa.MaHangHoa == 0)
            //        {
            //            string maxMaQL = HangHoaBQ_VT.spd_MaxMaHangHoaByMaNhom(Convert.ToInt32(lookUpEdit_NhomHangHoa.EditValue.ToString()));
            //            int indexBD = 0;
            //            int indexKT = maxMaQL.Length;
            //            if (_checkThemMoi)
            //            {
            //                if (!string.IsNullOrEmpty(maxMaQL))
            //                {
            //                    if (maxMaQL != "Null")
            //                    {
            //                        for (int i = maxMaQL.Length - 1; i >= 0; i--)
            //                        {
            //                            if ((maxMaQL[i] >= 'a' && maxMaQL[i] <= 'z') || (maxMaQL[i] >= 'A' && maxMaQL[i] <= 'Z'))
            //                            {
            //                                indexBD = i;
            //                                break;
            //                            }
            //                            else if (maxMaQL[i] >= '0' && maxMaQL[i] <= '9')
            //                            {
            //                            }
            //                            else
            //                            {
            //                                indexBD = i;
            //                                break;
            //                            }
            //                        }
            //                        int lengthForMat = maxMaQL.Substring(indexBD + 1, indexKT - (indexBD + 1)).ToString().Length;
            //                        //string format = "{0:D" + lengthForMat + "}";
            //                        string MaxMaQLNew = maxMaQL.Substring(0, indexBD + 1) + (Convert.ToInt32(maxMaQL.Substring(indexBD + 1, indexKT - (indexBD + 1))) + 1).ToString("D" + lengthForMat + "");
            //                        //txtDev_Mahanghoa.EditValue = MaxMaQLNew;
            //                        hh.MaNhomHangHoa = Convert.ToInt32(lookUpEdit_NhomHangHoa.EditValue);
            //                        hh.MaQuanLy = MaxMaQLNew;
            //                    }
            //                    else
            //                    {
            //                        hh.MaNhomHangHoa = Convert.ToInt32(lookUpEdit_NhomHangHoa.EditValue);
            //                        hh.MaQuanLy = "";
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            # endregion 
        }

        private void gridView_DSHangHoa_Click(object sender, EventArgs e)
        {
            if (bs_DSHangHoaListAll.Current != null)
            {
                hh = bs_DSHangHoaListAll.Current as HangHoaBQ_VT;
            }
        }

        private void ChuongTrinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bs_DSHangHoaListAll.Current != null)
            {
                hh = bs_DSHangHoaListAll.Current as HangHoaBQ_VT;
                frm_ChuongTrinhConBanQuyen frm;
                if (themMoi)
                {
                    frm = new frm_ChuongTrinhConBanQuyen(hh.MaHangHoa, hh.MaQuanLy, true);
                }
                else
                {
                    frm = new frm_ChuongTrinhConBanQuyen(hh.MaHangHoa, hh.MaQuanLy, false);
                }
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    _maChuongTrinhConChon = frm.MaChuongTrinhCon;
                }
            }
        }

        private void gridView_DSHangHoa_GotFocus(object sender, EventArgs e)
        {
            if (bs_DSHangHoaListAll.Current != null)
            {
                hh = bs_DSHangHoaListAll.Current as HangHoaBQ_VT;
            }
        }

        private void repositoryItemGridLookUpEdit_MaQuocGia_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void NhomHangHoaList_repositoryItemGridLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void btnExportMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel|*.xlsx|All file|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //tạo file template
                FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Write(Properties.Resources.Template_Import_HangHoa, 0, Properties.Resources.Template_Import_HangHoa.Length);
                fs.Close();
                DialogUtil.ShowWarning("Đã xuất dữ liệu thành công!");
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        private void btnImportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _FileNameImport = "";
                //isimportfromExcel = true;
                #region Old
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                oFD.ShowDialog();
                string path = oFD.FileName;
                string p = System.IO.Path.GetFileName(path);
                _FileNameImport = p;
                //DataTable tblResult = ImportExcelXLS(path, true);
                //ImportToTable(tblResult);
                DataSet dsRerult = ImportExcelXLSToDataset(path, true);
                ImportToHangHoaFromDataSet(dsRerult);
                //ImportToChiTietNhapXuatFromDataSet(dsRerult);
                //BindingData();
                //if (_ChungTuImportFromExcelList.Count > 0)
                //{
                //    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //}
                //if (_ChungTuImportFromExcelList.Count > 0)
                //{
                //    btnLuuCTNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //}
                #endregion//Old
                //isimportfromExcel = false;
            }
            catch (Exception ex)
            {
                DialogUtil.ShowWarning("Không thể đọc file!\n" + ex.Message);
            }
        }//end function

        private DataSet ImportExcelXLSToDataset(string FileName, bool hasHeaders)
        {
            #region Old
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
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
                    if (sheet == "Sheet1$" && !sheet.EndsWith("_"))
                    {
                        try
                        {
                            outputTable = new DataTable();
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A5:G]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            outputTable.TableName = "HangHoa";
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                            _dataSet.Tables.Add(outputTable);
                        }
                        catch (Exception ex)
                        {
                            DialogUtil.ShowWarning("Lỗi hệ thống!\n" + ex.Message);
                           // throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                }
            }
            return _dataSet;
            #endregion//Old
        }

        private bool KiemTraTonTaiHangHoa(string MaQLHangHoa, string filepath, string STT)
        {
            foreach (HangHoaBQ_VT item in _hhSSList)
            {
                if (item.MaQuanLy == MaQLHangHoa)
                {
                    StreamWriter str = File.AppendText(filepath);
                    str.WriteLine(STT + "  " + item.MaQuanLy);
                    str.Close();
                    //FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt)//fs là 1 FileStream 
                    //StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
                    //sWriter.WriteLine(item.MaQLDoiTac);
                    // Ghi và đóng file
                    //sWriter.Flush();
                    //fs.Close();
                    return false;
                }
            }
            return true;
        }

        private void ImportToHangHoaFromDataSet(DataSet dsresult)
        {
            #region HH
            _hhSSList = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
            _hhSSList = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
            _hangHoaBQ_VTList = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
            hh = HangHoaBQ_VT.NewHangHoaBQ_VT();

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
            //String filepath = "E:\\test.txt";// đường dẫn của file muốn tạo
            FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt)//fs là 1 FileStream 

            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
            sWriter.WriteLine("Danh Sách Hàng Hóa Bị Trùng Mã");
            //Ghi và đóng file
            sWriter.Flush();
            fs.Close();

            if (dsresult.Tables.Count == 0) return;
            tblHangHoa = new DataTable();
            tblHangHoa = dsresult.Tables["HangHoa"];
            if (tblHangHoa.Rows.Count > 0)
            {
                foreach (DataRow rowhd in tblHangHoa.Rows)
                {
                    if (rowhd[1].ToString().Trim().Length == 0 && rowhd[2].ToString().Trim().Length == 0)//MaDoiuong va TenDoiTuong = rong
                    {
                        break;
                    }
                    //STT
                    double sTT = 0;
                    double sTTOut;
                    if (double.TryParse(rowhd[0].ToString(), out sTTOut))
                    {
                        sTT = sTTOut;
                    }

                    //LoaiChungTu
                    if (rowhd[1].ToString().Trim() != "")
                    {
                        if (KiemTraTonTaiHangHoa(rowhd[1].ToString().Trim(), filepath, rowhd[0].ToString()) != false)
                        {
                            hh = HangHoaBQ_VT.NewHangHoaBQ_VT();

                            DonViTinh dvt = DonViTinh.NewDonViTinh();
                            NhomHangHoaBQ_VT NHH = NhomHangHoaBQ_VT.NewNhomHangHoaBQ_VT();

                            hh.MaQuanLy = rowhd[1].ToString();
                            hh.TenHangHoa = rowhd[2].ToString();
                            if (rowhd[3].ToString().Trim() != "" && rowhd[3].ToString().Trim() != "NULL")
                            {
                                hh.MaDonViTinh = DonViTinh.GetMaDonViTinhByTen(rowhd[3].ToString().Trim());
                            }
                            if (rowhd[4].ToString().Trim() != "" && rowhd[4].ToString().Trim() != "NULL")
                            {
                                hh.MaNhomHangHoa = NhomHangHoaBQ_VT.GetNhomHangHoaBQ_VT(rowhd[4].ToString().Trim()).MaNhomHangHoa;
                            }
                            hh.TinhTrang = Convert.ToBoolean(rowhd[5].ToString());
                            hh.DienGiai = rowhd[6].ToString();
                            _hangHoaBQ_VTList.Add(hh);
                        }
                    }
                }
            }

            DialogResult NCC = MessageBox.Show("Bạn có muốn lưu hàng hóa mới import", "Thông báo!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (NCC == DialogResult.OK)
            {
                btnLuu.PerformClick();
                LoadForm(0);
            }
            #endregion//NCC
        }

        private void btn_ExportDataExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.gridView_DSHangHoa, showOpenFilePrompt: true);
        }
    }
}
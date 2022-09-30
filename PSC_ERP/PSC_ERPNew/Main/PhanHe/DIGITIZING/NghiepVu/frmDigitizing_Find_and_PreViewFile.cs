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

namespace PSC_ERPNew.Main.PhanHe.DIGITIZING
{
    public partial class frmDigitizing_Find_and_PreViewFile : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDigitizing_Find_and_PreViewFile singleton_ = null;
        public static frmDigitizing_Find_and_PreViewFile Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDigitizing_Find_and_PreViewFile();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }


        public static void ShowFile(DigitizingBag FileShow, Form owner)
        {
            var frm = new frmDigitizing_Find_and_PreViewFile(FileShow) { WindowState = FormWindowState.Maximized, Text = "Bạn đang xem Chứng từ " + FileShow.Name };
            FormUtil.ShowForm_Helper(frm, owner);
        }

        public static void ShowDanhSachFile(List<DigitizingBag> dsFileShow, Form owner)
        {
            var frm = new frmDigitizing_Find_and_PreViewFile(dsFileShow) { WindowState = FormWindowState.Maximized };
            FormUtil.ShowForm_Helper(frm, owner);
        }
        #endregion


        const String _publicKey = "gi cung duoc";
        String _token = null;
        Boolean _daLoadFormXong = false;
        //List<ChungTu> _chungTuList = null;
        DigitizingBag_Factory _digitizingBagFull = DigitizingBag_Factory.New();

        DigitizingBag _currentBagForPreview = null;
        List<DigitizingBag> dsFilePreView = new List<DigitizingBag>();
        bool TimTatCa = false;
        public frmDigitizing_Find_and_PreViewFile()
        {
            InitializeComponent();
        }

        public frmDigitizing_Find_and_PreViewFile(DigitizingBag FileShow)
        {
            InitializeComponent();
            _currentBagForPreview = FileShow;
            if (_currentBagForPreview != null)
                dsFilePreView.Add(_currentBagForPreview);
        }
        public frmDigitizing_Find_and_PreViewFile(List<DigitizingBag> dsFileShow)
        {
            InitializeComponent();
            dsFilePreView = dsFileShow;
            if (dsFileShow.Count > 0)
                _currentBagForPreview = dsFileShow[0];
        }


        #region tìm file
        #region Tim lucene
        public IEnumerable<DigitizingBag> TimKiemFile_Lucene()
        {
            //IQueryable<DigitizingBag> dsFileFull = _digitizingBagFull.GetAll();            
            String _NoiDungCanTim = txtNoiDungCanTim.Text.Trim();
            //IQueryable<DigitizingBag> kqTimLucene = new List<DigitizingBag>();
            IEnumerable<DigitizingBag> kqTimLucene = null;
            if (!String.IsNullOrWhiteSpace(_NoiDungCanTim))
            {
                try
                {
                    DigitizingService service = new DigitizingService();
                    List<IndexPackage> kqTim = service.QuickHelper_SearchContent_String(publicKey: _publicKey, token: _token, content: _NoiDungCanTim, maPhanHe: "SH", fileContentInResult: false).ToList<IndexPackage>();
                    //trich lay thong tin DocId;
                    //List<Guid> docIdList = (from o in kqTim select new Guid(o.DocId)).ToList();
                    List<String> docIdList = (from o in kqTim select (o.DocId)).ToList();
                    //
                    IQueryable<DigitizingBag> fullList = _digitizingBagFull.GetAll().Where(x => x.IsFile == true);
                    //kqTimLucene = DigitizingBag_Factory.GetListByIdList(fullList, docIdList);
                    kqTimLucene = (from o in fullList
                                   where docIdList.Contains(o.OriginalFileName)
                                   select o).ToList();
                }
                catch (Exception)
                {
                    DialogUtil.ShowError("Xảy ra lỗi với từ khóa tìm kiếm \n Vui lòng nhập lại từ khóa khác!");
                    return kqTimLucene;
                }
            }
            return kqTimLucene;

        }
        #endregion

        #region tìm theo Name và Description
        public IEnumerable<DigitizingBag> TimFile_Name_Description()
        {
            IQueryable<DigitizingBag> dsFileFull = _digitizingBagFull.GetAll();
            IEnumerable<DigitizingBag> kqTimName_Description = new List<DigitizingBag>();
            String titleContain = this.txtNoiDungCanTim.Text.Trim().Replace("*", "").Replace("\"", "");
            if (!String.IsNullOrWhiteSpace(titleContain))
            {
                String lowerTitleContain = titleContain.Trim().ToLower();
                kqTimName_Description = dsFileFull.Where(o => o.IsFile == true && o.Name.ToLower().Contains(lowerTitleContain) || o.Description.ToLower().Contains(lowerTitleContain));

            }
            return kqTimName_Description;
        }
        #endregion

        #region tìm File
        public List<spd_TimFile_Result> TimFile()
        {
            List<spd_TimFile_Result> kqTimDB = new List<spd_TimFile_Result>();
            Int32? maBoPhan = Convert.ToInt32(cbBoPhan.EditValue);
            Int32? nam = Convert.ToInt32(cbNam.EditValue);
            Int32? maLoaiChungTu = Convert.ToInt32(cbLoaiChungTu.EditValue);
            spd_TimChungTuSoHoa_Result currentChungTu = (spd_TimChungTuSoHoa_Result)cbChungTu.GetSelectedDataRow();

            if (currentChungTu != null)//trường hợp là chứng từ: bảng kê, phiếu thu, phiếu chi, phiếu nhập, phiếu xuất
                kqTimDB = _digitizingBagFull.Context.spd_TimFile(nam ?? 0, maBoPhan ?? 0, maLoaiChungTu ?? 0, currentChungTu.MaChungTu).ToList();
            else // trường hợp không phải chứng từ: hợp đồng (trong và ngoài đài, hợp đồng mua bán) văn bản(quyết định, thông báo, chuyên mục khác)
                kqTimDB = _digitizingBagFull.Context.spd_TimFile(nam ?? 0, maBoPhan ?? 0, maLoaiChungTu ?? 0, 0).ToList();
            return kqTimDB;
        }
        #endregion
        #endregion


        #region HighLight Text
        //HighLight RichEditTextbox
        private void ToMauChu()
        {
            string _NoiDungCanTim = txtNoiDungCanTim.Text;
            List<string> str_NoiDungTim = new List<string>();
            //tìm tuyệt đối không cần cắt chuỗi ra heghlight
            if (_NoiDungCanTim.Substring(0, 1) == "\"" && ((_NoiDungCanTim.Substring((_NoiDungCanTim.Length - 1), 1) == "\"") || _NoiDungCanTim.Trim().Substring((_NoiDungCanTim.Trim().Length - 1), 1) == "\""))
            {
                str_NoiDungTim.Add(_NoiDungCanTim.Trim().Replace("*", "").Replace("\"", ""));
            }
            //tìm tương đối cắt chuỗi ra hightlight
            else
            {
                _NoiDungCanTim.Trim().Replace("*", "").Replace("\"", "");
                str_NoiDungTim = _NoiDungCanTim.Split(' ').ToList<string>();
            }
            foreach (string str in str_NoiDungTim)
            {
                DevExpress.XtraRichEdit.API.Native.DocumentRange[] finds = richEditControl_ForTxt.Document.FindAll(str, DevExpress.XtraRichEdit.API.Native.SearchOptions.WholeWord);
                foreach (var find in finds)
                {
                    var doc = find.BeginUpdateDocument();
                    var charprop = doc.BeginUpdateCharacters(find);
                    charprop.BackColor = Color.Yellow;
                    doc.EndUpdateCharacters(charprop);
                    find.EndUpdateDocument(doc);
                }
            }

        }




        void DrawMultiColorString(GraphicsCache cache, Rectangle bounds, string text, string matchedText, AppearanceObject appearance, Color highlightText, Color highlight, bool invert)
        {
            if (cache == null || text == null || text.Length == 0) return;
            TextHighLight par = new TextHighLight(text.IndexOf(matchedText), matchedText.Length, highlight, highlightText);
            TextUtils.DrawString(cache.Graphics, text, appearance.Font, appearance.ForeColor, bounds, appearance.GetStringFormat(),
                par);
        }



        #endregion

        private void XuLyChungTu()
        {
            Int32? nam = Convert.ToInt32(cbNam.EditValue);
            Int32? maPhongBan = Convert.ToInt32(cbBoPhan.EditValue);
            Int32? maLoaiChungTu = Convert.ToInt32(cbLoaiChungTu.EditValue);
            //Document currentChungTu = (Document)cbChungTu.GetSelectedDataRow();

            btnFind.Enabled = true;
            txtNoiDungCanTim.Enabled = true;
            if (maLoaiChungTu == 1003 || maLoaiChungTu == 1004 //hợp đồng
                 || maLoaiChungTu == 2005 || maLoaiChungTu == 2006 || maLoaiChungTu == 2007 // văn bản
                 || ((nam ?? 0) == 0 && (maPhongBan ?? 0) == 0 && (maLoaiChungTu ?? 0) == 0))//cả 3 combox là trường hợp tất cả
            {
                cbChungTu.Enabled = false;
                TimChungTuSoHoabindingSource.DataSource = null;
            }
            else
            {
                if (_daLoadFormXong)
                {
                    TaskUtil.InvokeCrossThread(this, () =>
                    {
                        using (DialogUtil.Wait(this, "Vui lòng đợi....", "Đang lấy danh \n sách chứng từ"))
                        {
                            //lấy chứng từ
                            List<spd_TimChungTuSoHoa_Result> dsChungTu = new List<spd_TimChungTuSoHoa_Result>();
                            dsChungTu = ChungTu_Factory.New().Context.spd_TimChungTuSoHoa(nam ?? 0, maPhongBan ?? 0, maLoaiChungTu ?? 0, 0, false).ToList();// as List<Document>;//truyền false hay null đều dc

                            if (dsChungTu.Count > 0)
                            {
                                dsChungTu.Insert(0, new spd_TimChungTuSoHoa_Result() { MaChungTu = 0, SoChungTu = "<<Tất cả>>" });
                                TimChungTuSoHoabindingSource.DataSource = dsChungTu;

                                cbChungTu.Enabled = true;
                                //chung tu thanh 0
                                cbChungTu.EditValue = 0;
                            }
                            else
                            {
                                DialogUtil.ShowInfo("Không Có Chứng từ!", "Cảnh Báo");
                                cbChungTu.Enabled = btnFind.Enabled = txtNoiDungCanTim.Enabled = false;
                                TimChungTuSoHoabindingSource.DataSource = null;
                            }

                        }
                    });
                }

            }
        }
        private void DownLoadAndPreview(DigitizingBag currentBag)
        {
            using (DialogUtil.Wait(this, "vui lòng đợi ...", "Đang tải dữ liệu từ Server"))
            {
                CloseDocument();
                if (Object.ReferenceEquals(this.XtraTabControl1.SelectedTabPage, this.tabPdfNguon))
                {
                    this.DownLoadPdfAndPreview(currentBag);
                }
                else if (Object.ReferenceEquals(this.XtraTabControl1.SelectedTabPage, this.tabTxt))
                {
                    this.DownLoadTextAndPreview(currentBag);
                }
                else if (Object.ReferenceEquals(this.XtraTabControl1.SelectedTabPage, this.tabWord))
                {
                    this.DownLoadWordAndPreview(currentBag);
                }
                else if (Object.ReferenceEquals(this.XtraTabControl1.SelectedTabPage, this.tabExcel))
                {
                    this.DownLoadExcelAndPreview(currentBag);
                }
                else if (Object.ReferenceEquals(this.XtraTabControl1.SelectedTabPage, this.tabPdfConvert))
                {
                    this.DownLoadPdfAndPreview_Convert(currentBag);
                }
                this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.PageLevel;
            }
        }
        private void DownLoadPdfAndPreview(DigitizingBag currentBag)
        {
            //Task<object> pdfTask = TaskUtil.InvokeCrossThread(this, () =>
            //{
            GC.Collect();
            byte[] data = null;
            //try
            //{
            //    //lay stream file nguon dua len pdf viewer
            //    DigitizingService service = new DigitizingService();
            //    String extension = Path.GetExtension(currentBag.UploadFromFilePath);
            //    //data = service.QuickHelper_DownloadSourceFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension,"SH");
            //    String file = currentBag.OriginalFileName + extension;
            //    data = service.QuickHelper_DownloadSourceFile_ByFileName(_publicKey, _token, file, "SH");
            //    this.pdfViewer1.LoadDocument(new MemoryStream(data));
            //}
            //catch (Exception ex)
            //{
            //    DialogUtil.ShowError("Không tải được file \n" + ex.Message);
            //    //this.pdfViewer1.CloseDocument();
            //}
            Int32 soFile = 0;
            DigitizingService service = new DigitizingService();
            String extension = Path.GetExtension(currentBag.UploadFromFilePath);
            String file = currentBag.OriginalFileName + extension;
            long offset = 0;
            Boolean coFile = true;
            try
            {
                soFile = service.SplitFile(_publicKey, _token, file, "SH");
            }
            catch
            {
                coFile = false;
                DialogUtil.ShowWarning("Không tìm thấy file!");
            }
            if (coFile)
            {
                //trường hợp file nhỏ hơn 1024 * 1024 *10 tải trực tiếp về bộ nhớ full File
                if (soFile == 1)
                {
                    using (DialogUtil.Wait(this, "vui lòng đợi...", "Đang tải dữ liệu!"))
                    {
                        try
                        {
                            data = service.QuickHelper_DownloadSourceFile_ByFileName(_publicKey, _token, file, "SH");
                            SaveFilePDF(data, "TempFileVB.pdf");
                            this.pdfViewer1.LoadDocument("TempFileVB.pdf");
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
                //trường hợp file lớn hơn 1024 * 1024 *10 chia file ra tải về mỗi lần lấy 1024*1024
                else
                {
                    using (DialogUtil.Wait(this, "vui lòng đợi...", "Đang tải dữ liệu!\nFile này có dung lượng lớn\nQuá trình tải có thể hơi lâu"))
                    {
                        Boolean taiXong = true;
                        try
                        {
                            for (int i = 0; i < soFile; i++)
                            {
                                data = null;
                                data = service.QuickHelper_DownloadSourceFileLarge_ByFileName(_publicKey, _token, file, "SH", offset);
                                SaveFileLargeSize("TempFileVB.pdf", data, offset);
                                offset += data.Length;
                            }
                        }
                        catch (Exception exp)
                        {
                            taiXong = false;
                        }
                        if (taiXong)
                        {
                            this.pdfViewer1.LoadDocument("TempFileVB.pdf");
                            this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.ActualSize;
                        }
                        else
                        {
                            DialogUtil.ShowError("Tải File không thành công \n");
                            this.pdfViewer1.CloseDocument();
                        }
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
        private void DownLoadWordAndPreview(DigitizingBag currentBag)
        {
            //Task<object> pdfTask = TaskUtil.InvokeCrossThread(this, () =>
            //{
            byte[] data = null;
            try
            {
                //lay stream file docx dua len doc viewer
                DigitizingService service = new DigitizingService();
                const String extension = ".doc";
                //data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension);
                data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.OriginalFileName + extension);
                //string tenfile = currentBag.BagId.ToString() + extension;
                //FileStream fs = new FileStream(tenfile, FileMode.Create, FileAccess.ReadWrite);
                //Byte[] b = new Byte[1024];
                //data.Initialize();
                //int r;
                //string vanban = "";
                //while ((r = fs.Read(data, 0, 1024)) != 0)
                //{
                //    string s = "";
                //    s = Encoding.ASCII.GetString(data, 0, 1024);
                //    vanban += s;
                //    data.Initialize();
                //}
                //this.richEditControl1.LoadDocument(new MemoryStream(data), DevExpress.XtraRichEdit.DocumentFormat.Doc);
                //richEditControl1.WordMLText = vanban;
                const string strTenFile = "TempFile_DocPreView.rtf";
                SaveFilePDF(data, strTenFile);
                this.richEditControl1.LoadDocument(strTenFile);
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Không tải được file \n" + ex.Message);
            }
            //return data;
            //});
        }

        private void DownLoadTextAndPreview(DigitizingBag currentBag)
        {
            //Task<object> pdfTask = TaskUtil.InvokeCrossThread(this, () =>
            //{
            byte[] data = null;
            try
            {
                //lay stream file docx dua len doc viewer
                DigitizingService service = new DigitizingService();
                const String extension = ".txt";
                //data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension);
                data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.OriginalFileName + extension);
                this.richEditControl_ForTxt.LoadDocument(new MemoryStream(data), DevExpress.XtraRichEdit.DocumentFormat.PlainText);
                ToMauChu();
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Không tải được file \n" + ex.Message);
            }
            //return data;
            //});
        }



        //

        #region luu file pdf
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

        private void DownLoadPdfAndPreview_Convert(DigitizingBag currentBag)
        {
            //Task<object> pdfTask = TaskUtil.InvokeCrossThread(this, () =>
            //{
            byte[] data = null;
            try
            {
                //lay stream file nguon dua len pdf viewer
                DigitizingService service = new DigitizingService();
                String extension = null;


                extension = ".pdf";
                //data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension);
                data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.OriginalFileName + extension);

                const string strTenFile = "TempFile_PdfPreView.pdf";
                SaveFilePDF(data, strTenFile);
                this.pdfViewer2.LoadDocument(strTenFile);

            }


            catch (Exception ex)
            {
                DialogUtil.ShowError("Không tải được file \n" + ex.Message);
                //this.pdfViewer1.CloseDocument();
            }
            //return data;
            //});
        }
        //

        private void DownLoadExcelAndPreview(DigitizingBag currentBag)
        {
            //Task<object> pdfTask = TaskUtil.InvokeCrossThread(this, () =>
            //{
            byte[] data = null;
            try
            {
                //lay stream file docx dua len doc viewer
                DigitizingService service = new DigitizingService();
                const String extension = ".xls";
                //data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension);
                data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.OriginalFileName.ToString() + extension);
                this.spreadsheetControl1.LoadDocument(new MemoryStream(data), DevExpress.Spreadsheet.DocumentFormat.Xls);
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Không tải được file \n" + ex.Message);
            }
            //return data;
            //});
        }

        private void CloseDocument()
        {
            //gỡ bỏ hiển thị pdf pdfviewer
            pdfViewer1.CloseDocument();
            //
            this.richEditControl1.CreateNewDocument();
            //xoa noi dung excel
            this.spreadsheetControl1.CreateNewDocument();
        }

        private void frmDigitizing_Find_and_PreViewFile_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            this.Shown += (senderz, ez) =>
                          {
                              TaskUtil.InvokeCrossThread(this, () =>
                                  {
                                      using (DialogUtil.Wait(this))
                                      {
                                          _daLoadFormXong = false;
                                          _token = PSC_ERPNew.Main.PhanHe.DIGITIZING.Helper.MakeToken(publicKey: _publicKey, secretKey: "pscvietnam@hoasua");
                                          {
                                              List<Year> namList = new List<Year>();
                                              namList.Add(new Year(0, "<<Tất cả>>"));
                                              int namDauTien = 1998;
                                              int namHienTai = app_users_Factory.New().SystemDate.Year;
                                              for (int i = namDauTien++; i <= namHienTai; i++)
                                                  namList.Add(new Year(i));
                                              yearBindingSource.DataSource = namList;
                                              cbNam.EditValue = 0;
                                          }
                                          List<tblnsBoPhan> boPhanList = BoPhan_Factory.New().GetAll().ToList();
                                          boPhanList.Insert(0, new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" });
                                          tblnsBoPhanBindingSource.DataSource = boPhanList;
                                          documentTypeBindingSource.DataSource = DocumentType.DocumentTypeList;
                                          cbChungTu.Enabled = false;
                                          if (dsFilePreView.Count > 0)
                                              digitizingBagBindingSource_ForGrid.DataSource = dsFilePreView;
                                          _daLoadFormXong = true;
                                          if (_daLoadFormXong)
                                          {
                                              if (_currentBagForPreview != null)
                                              {
                                                  DownLoadAndPreview(_currentBagForPreview);
                                              }
                                          }
                                      }
                                  });
                          };
        }


        private void cbNam_EditValueChanged(object sender, EventArgs e)
        {
            XuLyChungTu();

        }
        private void cbBoPhan_EditValueChanged(object sender, EventArgs e)
        {
            XuLyChungTu();
        }
        private void cbLoaiChungTu_EditValueChanged(object sender, EventArgs e)
        {
            XuLyChungTu();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            using (DialogUtil.Wait(this, "vui lòng đợi...", "Đang tìm kiếm"))
            {
                //khởi tạo lại danh sách
                dsFilePreView = new List<DigitizingBag>();

                List<DigitizingBag> kqTimLucene = TimKiemFile_Lucene().ToList();
                IEnumerable<DigitizingBag> kqTimFile_Name_Description = TimFile_Name_Description();
                List<spd_TimFile_Result> kqTimFile = TimFile().ToList();

                #region tìm tất cả
                if (TimTatCa)
                {
                    //gán toàn bộ kết quả lucene
                    if (kqTimLucene.Count() > 0)
                    {
                        dsFilePreView = kqTimLucene;
                        //dsFilePreView = kqTimLucene.ToList<DigitizingBag>();
                        //dsFilePreView = (List<DigitizingBag>) TimKiemFile_Lucene();
                    }


                    //gan them ket qua tim tieu de và diễn giải
                    if (kqTimFile_Name_Description.Count() > 0)
                    {
                        foreach (var item in kqTimFile_Name_Description)
                        {
                            if (!dsFilePreView.Exists(o => o.BagId == item.BagId))
                            {
                                dsFilePreView.Add(item);
                            }
                        }
                    }
                }
                #endregion
                //tìm có điều kiện
                #region tìm có điều kiện lọc
                else
                {
                    //lọc lại kết quả lucene với điều kiện lọc
                    if (kqTimFile.Count() > 0 && kqTimFile != null)
                    {
                        foreach (var item in kqTimLucene)
                        {
                            if (TimFile().Any(o => o.BagId == item.BagId))
                            {
                                dsFilePreView.Add(item);
                            }
                        }
                    }

                    //lọc thêm với tìm kiếm Name hay Description
                    if (kqTimFile_Name_Description.Count() > 0)
                    {
                        foreach (var item in kqTimFile_Name_Description)
                        {
                            if (!dsFilePreView.Exists(o => o.BagId == item.BagId) && (kqTimFile.Exists(f => f.BagId == item.BagId)))
                            {
                                dsFilePreView.Add(item);
                            }
                        }
                    }
                }
                #endregion
            }
            //kiểm tra kết quả có hay không?
            if (dsFilePreView.Count() == 0 || dsFilePreView == null)
            {
                DialogUtil.ShowInfo("Không tìm thấy", "Tìm Kiếm");
            }
            else
            {
                DialogUtil.ShowInfo(string.Format("Đã tìm thấy {0} File!", dsFilePreView.Count), "Tìm Kiếm");
                digitizingBagBindingSource_ForGrid.DataSource = dsFilePreView;
            }


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

        private void frmDigitizing_Find_and_PreViewFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_digitizingBagFull.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    DialogUtil.ShowNotSaveSuccessful();
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

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (_daLoadFormXong && _currentBagForPreview != null)
            {
                this.DownLoadAndPreview(_currentBagForPreview);
            }
        }


        private void btnDownloadSource_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            const String extension = ".pdf";
            DownloadAndSaveToFile(extension, "Pdf file|*.pdf", (service, filePath) =>
                                                               {
                                                                   //tải về
                                                                   byte[] data = null;
                                                                   if (service.QuickHelper_CheckExistSourceFile_ByFileName(_publicKey, _token, _currentBagForPreview.BagId.ToString() + extension))
                                                                   {
                                                                       data = service.QuickHelper_DownloadSourceFile_ByFileName(_publicKey, _token, _currentBagForPreview.BagId.ToString() + extension, "SH");
                                                                   }
                                                                   return data;
                                                               });
        }
        private void btnDownloadWordFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            const String extension = ".doc";
            DownloadAndSaveToFile(extension, "Word 2003 file|*.doc", (service, filePath) =>
                                                                     {
                                                                         //tải về
                                                                         byte[] data = null;
                                                                         if (service.QuickHelper_CheckExistConvertedFile_ByFileName(_publicKey, _token, _currentBagForPreview.BagId + extension))
                                                                         {
                                                                             data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, _currentBagForPreview.BagId + extension);
                                                                         }
                                                                         return data;
                                                                     });
        }
        private void btnDownLoadExcelFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            const String extension = ".xls";
            DownloadAndSaveToFile(extension, "Excel 2003 file|*.xls", (service, filePath) =>
                                                                      {
                                                                          //tải về
                                                                          byte[] data = null;
                                                                          if (service.QuickHelper_CheckExistConvertedFile_ByFileName(_publicKey, _token, _currentBagForPreview.BagId.ToString() + extension))
                                                                          {
                                                                              data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, _currentBagForPreview.BagId.ToString() + extension);
                                                                          }
                                                                          return data;
                                                                      });
        }


        private void DownloadAndSaveToFile(String defaultExtension, String filter, Func<DigitizingService, String, byte[]> fn)
        {
            if (fn != null)
            {
                if (_currentBagForPreview != null)
                {
                    SaveFileDialog dlg = new SaveFileDialog() { DefaultExt = defaultExtension, Filter = filter, FilterIndex = 0 };
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {

                        try
                        {
                            using (DialogUtil.Wait(this))
                            {
                                DigitizingService service = new DigitizingService();
                                byte[] data = fn(service, dlg.FileName);
                                if (data == null)
                                {
                                    DialogUtil.ShowWarning("Server chưa chuyển xong định dạng! Vui lòng thử lại sau 5 phút");
                                }
                                else
                                {
                                    if (File.Exists(dlg.FileName))
                                        File.Delete(dlg.FileName);
                                    //ghi file
                                    FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                                    fs.Write(data, 0, data.Length);
                                    fs.Close();
                                    DialogUtil.ShowInfo("Đã tải xong!");
                                }
                            }


                        }
                        catch (Exception ex)
                        {
                            DialogUtil.ShowError("Lỗi tải file");
                        }
                    }
                }
                else
                {
                    DialogUtil.ShowWarning("Chưa chọn tài liệu khả dụng");
                }
            }
        }

        private void gridViewDanhSachFile_RowStyle(object sender, RowStyleEventArgs e)
        {
            //////////////HighLight Row GridView
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0 && txt_NoiDungCanTim.Text != "")
            //{
            //    string name = View.GetRowCellDisplayText(e.RowHandle, View.Columns[0]).ToLower();
            //    // string name = View.GetRowCellValue(e.RowHandle, View.Columns["col_TenTaiLieu"]);
            //    if (name.Contains(txt_NoiDungCanTim.Text.Trim().ToLower()))
            //    {
            //        e.Appearance.BackColor = Color.SkyBlue;
            //        //e.Appearance.BackColor2 = Color.SaShell;
            //    }
            //}
        }

        private void gridViewDanhSachFile_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            //HighLight Text GridView
            GridView view = sender as GridView;
            if (e.RowHandle >= 0 && txtNoiDungCanTim.Text != "")
            {
                GridCellInfo cellInfo = e.Cell as GridCellInfo;
                TextEditViewInfo vi = cellInfo.ViewInfo as TextEditViewInfo;
                string matchedText = txtNoiDungCanTim.Text.Trim().ToLower();////vi.MatchedString.ToLower();
                string text = e.DisplayText.ToLower();
                //string _NoiDungCanTim_Lower = txt_NoiDungCanTim.Text.Trim().ToLower();
                e.Appearance.FillRectangle(e.Cache, e.Bounds);
                Color myBackColor = Color.Yellow;//màu nền
                Color myForeColor = Color.Black;//màu chữ 
                if (text.Contains(matchedText))
                {
                    DrawMultiColorString(e.Cache, e.Bounds, text, matchedText, e.Appearance, myForeColor, myBackColor, vi.IsInvertIncrementalSearchString);
                    e.Handled = true;
                }
            }
        }

        private void gridViewDanhSachFile_DoubleClick(object sender, EventArgs e)
        {
            Point pt = gridViewDanhSachFile.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(gridViewDanhSachFile, pt);

        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {

            GridHitInfo info = view.CalcHitInfo(pt);
            if ((info.InRow || info.InRowCell) && info.RowHandle >= 0)
            {
                _currentBagForPreview = this.gridViewDanhSachFile.GetRow(info.RowHandle) as DigitizingBag;
                //mở from xem lại chứng từ
                if (_daLoadFormXong && _currentBagForPreview != null)
                {
                    this.DownLoadAndPreview(_currentBagForPreview);
                }
            }
        }

        private void checkEdit_TimTatCa_CheckedChanged(object sender, EventArgs e)
        {
            TimTatCa = checkEdit_TimTatCa.Checked;
            cbBoPhan.Enabled = cbNam.Enabled = cbLoaiChungTu.Enabled = !checkEdit_TimTatCa.Checked;
            if (checkEdit_TimTatCa.Checked)
                cbChungTu.Enabled = false;
            else
                XuLyChungTu();
        }

        private void gridViewDanhSachFile_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using System.Threading.Tasks;
using System.IO;
using PSC_ERP_Digitizing.Client.WebReference1;
using PSC_ERPNew.Main.PhanHe.DIGITIZING.Model;
using PSC_ERPNew.Main.PhanHe.DIGITIZING.Predefined;
using System.Transactions;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;

namespace PSC_ERPNew.Main.PhanHe.DIGITIZING
{
    public partial class frmDigitizing_ChonFilesUpLoad : XtraForm
    {
        String _publicKey = "gi cung duoc";
        String _token = null;
        DigitizingBag_Factory _factory = null;
        IQueryable<DigitizingBag> _fileList = null;
        spd_TimChungTuSoHoa_Result _currentChungTu = null;
        DigitizingBag _parentFolder = null;

        IQueryable<DigitizingBag> dsFile;
        Int32? _maBoPhan_ForQuickLoad;
        DocumentTypeEnum _docTypeEnum_ForQuickLoad;
        Int32? _maLoaiChungTu_ForQuickLoad;
        Int32? _folderYear;
        Boolean _IsDatabase = true;

        public frmDigitizing_ChonFilesUpLoad(DigitizingBag_Factory factory, IQueryable<DigitizingBag> fileList,
                                                 spd_TimChungTuSoHoa_Result currentChungTu, DigitizingBag parentFolder
                                                , Int32? maBoPhan_ForQuickLoad
                                                , DocumentTypeEnum docTypeEnum_ForQuickLoad
                                                , Int32? folderYear
                                                , Boolean IsDatabase)
        {
            InitializeComponent();

            _token = PSC_ERPNew.Main.PhanHe.DIGITIZING.Helper.MakeToken(publicKey: _publicKey, secretKey: "pscvietnam@hoasua");

            _factory = factory;
            _fileList = fileList;
            _currentChungTu = currentChungTu;
            _parentFolder = parentFolder;
            //mới thêm
            _maBoPhan_ForQuickLoad = maBoPhan_ForQuickLoad;
            _docTypeEnum_ForQuickLoad = docTypeEnum_ForQuickLoad;
            _maLoaiChungTu_ForQuickLoad = Convert.ToInt32(docTypeEnum_ForQuickLoad);
            _folderYear = folderYear;
            _IsDatabase = IsDatabase;
        }

        private void frmDigitizing_ChonFilesUpLoad_Load(object sender, EventArgs e)
        {
            IQueryable<DigitizingBag> dsFileFull = _factory.GetAll();
            using (DialogUtil.Wait(this))
            {

                if (_IsDatabase)
                {
                    dsFile = dsFileFull.Where(x => x.FolderYear == _folderYear && x.MaBoPhan == _maBoPhan_ForQuickLoad && x.MaLoaiChungTu == _maLoaiChungTu_ForQuickLoad && x.MaChungTu == _currentChungTu.MaChungTu && x.IsFile == true);
                }
                else
                {
                    dsFile = dsFileFull.Where(x => x.FolderYear == _folderYear && x.MaBoPhan == _maBoPhan_ForQuickLoad && x.MaLoaiChungTu == _maLoaiChungTu_ForQuickLoad && x.IsDatabase == false && x.IsFile == true);
                }

            }
            using (DialogUtil.Wait(this))
            {
                digitizingBagBindingSource.DataSource = dsFile;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        public int GetNoOfPagesPDF(string FileName)
        {
            int result = 0;
            //FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            //StreamReader r = new StreamReader(fs);
            //string pdfText = r.ReadToEnd();

            //System.Text.RegularExpressions.Regex regx = new Regex(@"/Type\s*/Page[^s]");
            //System.Text.RegularExpressions.MatchCollection matches = regx.Matches(pdfText);
            //result = matches.Count;
           
            PdfReader pdfReader = new PdfReader(FileName);
            result = pdfReader.NumberOfPages;        

            return result;
        }

        private void btnAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //mở open file diaglog cho phép chọn nhieu file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Pdf files|*.pdf";
            openFileDialog1.Multiselect = true;
            int soFileUpLoad = 0;
            int soFileLoi = 0;
            List<string> dsFileLoi = new List<string>();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.         
            if (result == DialogResult.OK) // Test result. 
            {
                //List<Task> taskList = new List<Task>();
                if (openFileDialog1.FileNames.Count() > 0)
                {
                    foreach (var filePath in openFileDialog1.FileNames)
                    {
                        var kiemTraFileDaUp = _factory.Context.spd_TimFileDaDuocGanChungTu(_folderYear, _currentChungTu.MaBoPhan, _currentChungTu.MaLoaiChungTu, _currentChungTu.SoChungTu, 0, Path.GetFileName(filePath)).ToList();
                        if (kiemTraFileDaUp.Count == 0)//bỏ qua getHashCode
                        {
                            var objFile = _factory.CreateAloneObject();
                            //cấp id
                            objFile.BagId = Guid.NewGuid();
                            //gắn parent
                            objFile.ParentBagId = _parentFolder.BagId;
                            objFile.CreatedUser = BasicInfo.User.UserID;//PSC_ERP_Global.Main.UserID;

                            //objFile.MaBoPhan = BasicInfo.User.MaBoPhan;//PSC_ERP_Global.Main.MaBoPhanCuaUser;

                            //lấy số trang
                            int soTrang = GetNoOfPagesPDF(filePath);
                            objFile.SoTrang = soTrang;
                            //lấy hashcode -- dùng để kiểm tra xem file đó đã up lên hay chưa nếu cùng tên file mà khác hashcode thì file đó đã được chỉnh sửa
                            objFile.HashCode = filePath.GetHashCode();

                            //sửa thêm DocumentTypeEnumId
                            //objFile.MaBoPhan = _maBoPhan_ForQuickLoad;
                            if (_IsDatabase)
                            {
                                objFile.MaBoPhan = _currentChungTu.MaBoPhan;
                                objFile.SoChungTu = _currentChungTu.SoChungTu;
                                objFile.MaLoaiChungTu = _currentChungTu.MaLoaiChungTu;
                                //objFile.Description =  _currentChungTu.DienGiai;
                            }
                            else
                            {
                                objFile.MaBoPhan = _maBoPhan_ForQuickLoad;
                                objFile.MaLoaiChungTu = _maLoaiChungTu_ForQuickLoad;
                            }
                            objFile.IsDatabase = _IsDatabase;
                            objFile.FolderYear = _folderYear;
                            objFile.CapDoCay = 4;
                            objFile.CreatedDateTime = app_users_Factory.New().SystemDate;
                            //bat co file
                            objFile.IsFile = true;

                            //upload từng file
                            var task = TaskUtil.InvokeCrossThread(this, () =>
                             {
                                 using (DialogUtil.Wait(this, "Đang upload...", "Vui lòng chờ!"))
                                 {
                                     //up load
                                     String extension = Path.GetExtension(filePath);
                                     if (UploadFile(_publicKey, _token, filePath, objFile.BagId.ToString() + "SH" + extension))
                                     {
                                         ////////////////////////////////
                                         //DocumentTypeEnum loaiChungTu = (DocumentTypeEnum)_currentChungTu.MaLoaiChungTu;
                                         if (_IsDatabase)
                                         {
                                             objFile.MaChungTu = _currentChungTu.MaChungTu;
                                             objFile.Description = Path.GetFileName(filePath) + " " + _currentChungTu.DienGiai;
                                         }
                                         //ten file ban dau
                                         objFile.Name = Path.GetFileName(filePath);
                                         //ten file đã sửa
                                         objFile.OriginalFileName = objFile.BagId.ToString() + "SH";
                                         //lưu thông tin file
                                         digitizingBagBindingSource.Add(objFile);
                                         //lưu vết đường dẫn file
                                         objFile.UploadFromFilePath = filePath;
                                         //lưu vết máy tính va user up
                                         objFile.UploadFromComputerUser = Environment.MachineName + "\\" + Environment.UserName;
                                         //ip
                                         try
                                         {
                                             objFile.UploadFromIPAddress = PSC_ERP_Util.NetUtil.FindLanAddress().ToString();
                                         }
                                         catch (Exception exp)
                                         {
                                         }
                                         //ghi nhận đã upload xong
                                         objFile.FileUploadCompleted = true;
                                     }
                                 }

                             });
                            soFileUpLoad++;
                        }
                        else
                        {
                            soFileLoi++;
                            dsFileLoi.Add(Path.GetFileName(filePath));
                            //DialogUtil.ShowError("File bạn chọn đã có chứng từ \nVui lòng kiểm tra lại");
                        }
                    }//end foreach
                    if (soFileLoi == 0)
                    {
                        DialogUtil.ShowInfo("UpLoad Thành Công " + soFileUpLoad + " File!", "UpLoad File Xong");
                    }
                    else
                    {
                        string dsFileUpLoi = "";
                        foreach (string s in dsFileLoi)
                        {
                            dsFileUpLoi += s + "\n";
                        }
                        DialogUtil.ShowInfo("UpLoad Thành Công " + soFileUpLoad + " File!\nSố File lỗi là  " + soFileLoi + "\nGồm những file sau: \n" + dsFileUpLoi, "UpLoad File Xong");
                    }
                    //save lại vào database
                    _factory.SaveChangesWithoutTrackingLog();
                }
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                            DigitizingBag_Factory.FullDelete(_factory.Context, deleteList);

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

                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể xóa những dòng đang chọn!");
                }
            }
        }

        //up file lên Server
        public static Boolean UploadFile(String publicKey, String token, String filePath, String destFileNameWithExtension)
        {
            bool uploadSuccedd = true;
            try
            {
                long offset = 0;
                int intendedChunkSize = 65536; //65536;
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
                            service.QuickHelper_UploadFileLargeSize(publicKey, token, destFileNameWithExtension, buffer, offset, fileSize, "SH");
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

        private void frmDigitizing_ChonFilesUpLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtBlackHole.Focus();
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            //xử lý khi form đang đóng nếu có thay đổi thì save lại vào database
            if (_factory.IsDirty)
                _factory.SaveChangesWithoutTrackingLog();
        }

        private void gridViewDanhSachFile_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
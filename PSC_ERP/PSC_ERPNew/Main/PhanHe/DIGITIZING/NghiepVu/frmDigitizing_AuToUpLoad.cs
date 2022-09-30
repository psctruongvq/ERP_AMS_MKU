using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using System.IO;
using PSC_ERP_Digitizing.Client.WebReference1;
using PSC_ERPNew.Main.PhanHe.DIGITIZING.Predefined;
using System.Text.RegularExpressions;
using System.Threading;
using iTextSharp.text.pdf;


namespace PSC_ERPNew.Main.PhanHe.DIGITIZING
{
    public partial class frmDigitizing_AuToUpLoad : XtraForm
    {


        const String _publicKey = "gi cung duoc";
        String _token = null;
        DigitizingBag_Factory _factory = null;
        IQueryable<DigitizingBag> _fileList = null;
        spd_TimChungTuSoHoa_Result _currentChungTu = null;
        DigitizingBag _parentFolder = null;

        //IQueryable<DigitizingBag> dsFile;
        Int32? _maBoPhan_ForQuickLoad;
        DocumentTypeEnum _docTypeEnum_ForQuickLoad;
        Int32? _maLoaiChungTu_ForQuickLoad;
        Int32? _folderYear;

        Boolean _IsDatabase = true;
        string _thuMucGoc;
        Boolean _autoUpLoad = true;
        Boolean _UpLoadXong = false;
        Thread autoUpLoad_Thread;
        //Singleton
        #region Singleton
        private static frmDigitizing_AuToUpLoad singleton_ = null;
        public static frmDigitizing_AuToUpLoad Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDigitizing_AuToUpLoad();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion


        #region contructor
        public frmDigitizing_AuToUpLoad()
        {
            InitializeComponent();

            _token = PSC_ERPNew.Main.PhanHe.DIGITIZING.Helper.MakeToken(publicKey: _publicKey, secretKey: "pscvietnam@hoasua");
        }

        public frmDigitizing_AuToUpLoad(DigitizingBag_Factory factory, IQueryable<DigitizingBag> fileList,
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
        #endregion

        private void frmDigitizing_ChonFilesUpLoad_Load(object sender, EventArgs e)
        {
            //khởi tạo factory
            _factory = DigitizingBag_Factory.New();
            _UpLoadXong = true;
            btn_BatDau.Enabled = false;
            btn_Dung.Enabled = false;
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

        #region AuTo Update
        public void AuToUpLoad()
        {
            _UpLoadXong = false;
            var task = TaskUtil.InvokeCrossThread(this, () =>
             {
                 _factory = DigitizingBag_Factory.New();
                 string dir = _thuMucGoc;//@"D:\HTV";
                 Boolean _laChungTu = false;
                 Boolean _laPhieuNhapXuat = false;
                 int _nam;
                 //tblBoPhanERPNew _boPhan = new tblBoPhanERPNew();
                 tblnsBoPhan _boPhan = new tblnsBoPhan();
                 int _maLoaiChungTu = 0;
                 //DigitizingBag _folderParent = null;
                 app_users _app_User = null;
                 //List<string> danhSachNam = new List<string>();
                 //List<string> danhSachPhongBan = new List<string>();
                 //List<string> danhSachLoaiChungTu = new List<string>();
                 //List<string> danhSachChungTu = new List<string>();
                 List<string> danhSachFile = new List<string>();

                 //while (_autoUpLoad)
                 //{
                 try
                 {
                     foreach (string nam in Directory.GetDirectories(dir))//danh sách năm chỉ chạy cho năm từ 2010 trở đi. trước đó update tay
                     {
                         if (!_autoUpLoad)
                         {
                             _UpLoadXong = true;
                             break;//nhận được lệnh dừng thoát khỏi vòng lặp ngay
                         }
                         if (Int32.Parse(nam.Substring(nam.Length - 4, 4)) >= 2010)
                         {
                             _nam = Int32.Parse(nam.Substring(nam.Length - 4, 4));
                             foreach (string phongBan in Directory.GetDirectories(nam))//danh sách phòng ban
                             {
                                 if (!_autoUpLoad)
                                 {
                                     _UpLoadXong = true;
                                     break;//nhận được lệnh dừng thoát khỏi vòng lặp ngay
                                 }
                                 string maQuanLyBoPhan = phongBan.Substring(phongBan.LastIndexOf(@"\") + 1);
                                 //_boPhan = _factory.Context.spd_DIG_LayBoPhanTheoMaQuanLy(maQuanLyBoPhan).SingleOrDefault<tblBoPhanERPNew>();
                                 _boPhan = BoPhan_Factory.New().LayBoPhan_TheoMaQuanLy(maQuanLyBoPhan);
                                 foreach (string user in Directory.GetDirectories(phongBan))//danh sách user
                                 {
                                     if (!_autoUpLoad)
                                     {
                                         _UpLoadXong = true;
                                         break;//nhận được lệnh dừng thoát khỏi vòng lặp ngay
                                     }
                                     string _user = user.Substring(user.LastIndexOf(@"\") + 1);
                                     _app_User = app_users_Factory.New().LayUser_TheoPhongBan_MaQuanLy(_user, _boPhan.MaBoPhan);
                                     foreach (string loaiChungTu in Directory.GetDirectories(user))//danh sách loại chứng từ
                                     {
                                         if (!_autoUpLoad)
                                         {
                                             _UpLoadXong = true;
                                             break;//nhận được lệnh dừng thoát khỏi vòng lặp ngay
                                         }
                                         string loaiChungTuText = loaiChungTu.ToUpper().Substring(loaiChungTu.ToUpper().LastIndexOf(@"\") + 1);
                                         switch (loaiChungTuText.ToUpper())
                                         {
                                             case "T": _maLoaiChungTu = 2;//phiếu thu
                                                 break;
                                             case "C": _maLoaiChungTu = 3;//phiếu chi
                                                 break;
                                             case "N": _maLoaiChungTu = 4; //phiếu nhập có thể là PN
                                                 break;
                                             case "X": _maLoaiChungTu = 5; //phiếu xuất có thể là PX
                                                 break;
                                             case "D": _maLoaiChungTu = 15;//Phiếu Điều Chỉnh Kế Toán
                                                 break;
                                             case "K": _maLoaiChungTu = 16; // bảng kê
                                                 break;
                                             //default: _maLoaiChungTu = 16;//bảng kê
                                             //    break;
                                         }

                                         if (Directory.GetFiles(loaiChungTu, "*.pdf").Count() > 0)
                                         {
                                             danhSachFile = new List<string>();//khởi tạo danh sách file mới
                                             foreach (string chungTu in Directory.GetFiles(loaiChungTu, "*.pdf"))//danh sách chứng từ
                                             {
                                                 if (!_autoUpLoad)
                                                 {
                                                     _UpLoadXong = true;
                                                     break;//nhận được lệnh dừng thoát khỏi vòng lặp ngay
                                                 }
                                                 FileInfo file = new FileInfo(chungTu);
                                                 //lấy thông tin của chứng từ từ đây                                    
                                                 string _stt = chungTu.ToUpper().Substring(chungTu.ToUpper().LastIndexOf(@"\") + 1);
                                                 string _stt_ThongMinh = "";
                                                 int length_HauTo = 0;
                                                 if (_stt.ToUpper().IndexOf(loaiChungTuText.ToUpper()) >= 0)
                                                 {
                                                     length_HauTo = _stt.ToUpper().Substring(_stt.IndexOf(loaiChungTuText.ToUpper())).Length;
                                                 }
                                                     //trường hợp lưu tên file không có loại chứng từ thì lấy dấu chấm VD 100.pdf thiếu mã loại nhóm chứng từ
                                                 else
                                                 {
                                                     length_HauTo = _stt.ToUpper().Substring(_stt.IndexOf(".")).Length;
                                                 }
                                                 _stt_ThongMinh = _stt.Substring(0, (_stt.Length - length_HauTo));
                                                 if (_stt_ThongMinh.Length < 4)
                                                 {
                                                     switch (_stt_ThongMinh.Length)
                                                     {
                                                         case 1:
                                                             _stt = "000" + _stt_ThongMinh;
                                                             break;
                                                         case 2:
                                                             _stt = "00" + _stt_ThongMinh;
                                                             break;
                                                         case 3:
                                                             _stt = "0" + _stt_ThongMinh;
                                                             break;
                                                         default:
                                                             _stt = "0000";
                                                             break;
                                                     }
                                                 }
                                                 else
                                                 {
                                                     _stt = file.Name.Substring(0, 4); //chungTu.Substring(chungTu.LastIndexOf(@"\") + 1);
                                                 }
                                                 string _soChungTu = (string.Format("{0}{1}/{2}/{3}/{4}", _stt, loaiChungTuText.ToUpper(), _user, maQuanLyBoPhan, _nam));
                                                 //string _soChungTu = (_stt + "/" + _user + "/" + maQuanLyBoPhan + "/" + _nam);
                                                 //lấy thông tin cấp thư mục cha
                                                 _parentFolder = _factory.LayCapChaCuaFile(_boPhan.MaBoPhan, _maLoaiChungTu, _nam);
                                                 var kiemTraFileDaUp = _factory.Context.spd_TimFileDaDuocGanChungTu(_nam, _boPhan.MaBoPhan, _maLoaiChungTu, _soChungTu, 0, file.Name).ToList();//bỏ qua getHashCode = 0
                                                 //lấy thông tin xem là ở bảng chừng từ hay bảng phiếu nhập xuất
                                                 tblChungTu _chungTu = null;
                                                 tblPhieuNhapXuat _phieuNhapXuat = null;
                                                 if (_maLoaiChungTu == 2 || _maLoaiChungTu == 3 || _maLoaiChungTu == 15 || _maLoaiChungTu == 16)
                                                 {
                                                     _chungTu = ChungTu_Factory.New().GetChungTu_TheoSoChungTu(_soChungTu);
                                                     _laChungTu = true;
                                                     _laPhieuNhapXuat = false;
                                                 }
                                                 else if (_maLoaiChungTu == 4 || _maLoaiChungTu == 5)
                                                 {
                                                     _phieuNhapXuat = PhieuNhapXuat_Factory.New().LayPhieuNhapXuat_TheoSoPhieuNhapXuat(_soChungTu);
                                                     _laChungTu = false;
                                                     _laPhieuNhapXuat = true;
                                                 }
                                                 if ((_chungTu != null || _phieuNhapXuat != null) && kiemTraFileDaUp.Count == 0)
                                                 {
                                                     //danhSachFile = new List<string>();//khởi tạo danh sách file mới
                                                     //_currentChungTu =??;
                                                     //nếu đang ở chứng từ thì phải đợi update xong mới được thoát khỏi vòng lặp

                                                     //if (Directory.GetFiles(chungTu, "*.pdf").Count() > 0)
                                                     //{
                                                     //    foreach (string file in Directory.GetFiles(chungTu, "*.pdf"))//danh sách file thực hiện auto upload file tại thư mục này (thư mục chứng từ)
                                                     //    {
                                                     danhSachFile.Add(chungTu);
                                                     //var objFile = _factory.CreateAloneObject();
                                                     //DigitizingBag objFile = new DigitizingBag();
                                                     DigitizingBag objFile = _factory.CreateManagedObject();
                                                     //cấp id
                                                     objFile.BagId = Guid.NewGuid();
                                                     //gắn parent
                                                     objFile.ParentBagId = _parentFolder.BagId;
                                                     objFile.CreatedUser = BasicInfo.User.UserID;//PSC_ERP_Global.Main.UserID;

                                                     //objFile.MaBoPhan = BasicInfo.User.MaBoPhan;//PSC_ERP_Global.Main.MaBoPhanCuaUser;
                                                     //lấy số trang
                                                     int soTrang = GetNoOfPagesPDF(chungTu);
                                                     objFile.SoTrang = soTrang;
                                                     //lấy hashcode -- dùng để kiểm tra xem file đó đã up lên hay chưa nếu cùng tên file mà khác hashcode thì file đó đã được chỉnh sửa
                                                     objFile.HashCode = chungTu.GetHashCode();
                                                     //sửa thêm DocumentTypeEnumId
                                                     //objFile.MaBoPhan = _maBoPhan_ForQuickLoad;
                                                     if (_IsDatabase)
                                                     {
                                                         objFile.MaBoPhan = _boPhan.MaBoPhan;//_currentChungTu.MaBoPhan;
                                                         objFile.SoChungTu = _soChungTu;//_currentChungTu.SoChungTu;
                                                         objFile.MaLoaiChungTu = _maLoaiChungTu;//_currentChungTu.MaLoaiChungTu;
                                                         //objFile.Description =  _currentChungTu.DienGiai;
                                                     }
                                                     else
                                                     {
                                                         objFile.MaBoPhan = _maBoPhan_ForQuickLoad;
                                                         objFile.MaLoaiChungTu = _maLoaiChungTu_ForQuickLoad;
                                                     }
                                                     objFile.IsDatabase = _IsDatabase;
                                                     objFile.FolderYear = _nam;//_folderYear;
                                                     objFile.CapDoCay = 4;
                                                     objFile.CreatedDateTime = app_users_Factory.New().SystemDate;

                                                     //bat co file
                                                     objFile.IsFile = true;

                                                     #region Thực hiện quá trình upload file
                                                     //upload từng file
                                                     lock (objFile)
                                                     {
                                                         //var task = TaskUtil.InvokeCrossThread(this, () =>
                                                         // {
                                                         using (DialogUtil.Wait(this, "Đang upload...", "Vui lòng chờ!"))
                                                         {
                                                             //up load
                                                             String extension = Path.GetExtension(chungTu);
                                                             if (UploadFile(_publicKey, _token, chungTu, string.Format("{0}SH{1}", objFile.BagId, extension)))
                                                             {
                                                                 ////////////////////////////////
                                                                 //DocumentTypeEnum loaiChungTu = (DocumentTypeEnum)_currentChungTu.MaLoaiChungTu;
                                                                 if (_IsDatabase)
                                                                 {
                                                                     if (_laChungTu)
                                                                     {
                                                                         objFile.MaChungTu = _chungTu.MaChungTu;//
                                                                         objFile.Description = string.Format("{0} - {1}", chungTu.Substring(chungTu.LastIndexOf(@"\") + 1), _chungTu.DienGiai);
                                                                     }
                                                                     else if (_laPhieuNhapXuat)
                                                                     {
                                                                         objFile.MaChungTu = _phieuNhapXuat.MaPhieuNhapXuat;
                                                                         objFile.Description = string.Format("{0} - {1}", chungTu.Substring(chungTu.LastIndexOf(@"\") + 1), _phieuNhapXuat.DienGiai);
                                                                     }

                                                                 }
                                                                 //ten file ban dau
                                                                 objFile.Name = chungTu.Substring(chungTu.LastIndexOf(@"\") + 1);//Path.GetFileName(file);
                                                                 //ten file đã đổi
                                                                 objFile.OriginalFileName = objFile.BagId + "SH";
                                                                 //lưu thông tin file
                                                                 digitizingBagBindingSource.Add(objFile);
                                                                 //lưu vết đường dẫn file
                                                                 objFile.UploadFromFilePath = chungTu;
                                                                 //lưu vết máy tính va user up
                                                                 objFile.UploadFromComputerUser = string.Format("{0}\\{1}", Environment.MachineName, Environment.UserName);
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
                                                                 //save lại vào database
                                                                 //_factory.SaveChangesWithoutTrackingLog();
                                                             }
                                                         }//end hộp thoại waiting
                                                         //save lại vào database
                                                         _factory.SaveChangesWithoutTrackingLog();
                                                         //});//end của task
                                                     }//end lock
                                                 }
                                                 //});
                                                     #endregion
                                             }//end foreach chứng từ lất file    new  end foreach loại chứng từ lấy chứng từ
                                             //save lại vào database
                                             //_factory.SaveChangesWithoutTrackingLog();
                                         }//end if kiểm tra xem có thư mục có file pdf không?
                                         //}//end foreach loại chứng từ lấy chứng từ
                                     }//end foreach user lấy loại chứng từ
                                 }//end foreach  phòng ban lấy user
                             }//end foreach năm lấy phòng ban
                         }//end if năm
                     }//end foreach thu mục gốc HTV lấy năm
                 }//end try
                 catch (System.Exception ex)
                 {
                     //Console.WriteLine(ex.Message);
                 }
             });//end task
            _UpLoadXong = true;//chỉ duyệt 1 lần qua cây
            if (_UpLoadXong)
            {
                btn_BatDau.Enabled = true;
                btn_Dung.Enabled = false;
            }
        }
        #endregion

        //up file lên Server
        public static Boolean UploadFile(String publicKey, String token, String filePath, String destFileNameWithExtension)
        {
            bool uploadSuccedd = true;
            try
            {
                GC.Collect();
                long offset = 0;
                const int intendedChunkSize = 65536; //65536;
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
            if (!_UpLoadXong)
            {
                DialogUtil.ShowInfo("Quá trình Auto UpLoad chưa được tắt\nVui lòng dừng quá trình Auto UpLoad để thoát chương trình!", "Cảnh Báo Lỗi");
                e.Cancel = true;
            }

        }

        private void gridViewDanhSachFile_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btn_BatDau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btn_BatDau.Enabled = false;
            //
            autoUpLoad_Thread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                AuToUpLoad();
            });
            //autoUpLoad_Thread = new Thread(AuToUpLoad);
            //autoUpLoad_Thread.IsBackground = true;
            autoUpLoad_Thread.Start();

            btn_Dung.Enabled = true;
        }

        private void btn_Dung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _autoUpLoad = false;
            using (DialogUtil.Wait(this, "Đang xử lý UpLoad", "Vui lòng chờ UpLoad hoàn thành cho chứng từ hiện tại!"))
            {
                if (_UpLoadXong)
                {
                    DialogUtil.ShowInfo("Quá trình Auto Upload đã được dừng thành công! \nBạn có thể cập nhật thêm dữ liệu cho và bắt đầu lại quá trình auto UpLoad!", "Ngừng Auto UpLoad File");
                    btn_BatDau.Enabled = true;
                }
            }
        }

        private void btn_ChonFolder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean kiemTra = true;
            FolderBrowserDialog folderOpen = new FolderBrowserDialog() { ShowNewFolderButton = false };
            while (kiemTra)
            {
                if (DialogResult.OK == folderOpen.ShowDialog())
                {
                    _thuMucGoc = folderOpen.SelectedPath;
                    if (_thuMucGoc.Substring(_thuMucGoc.LastIndexOf(@"\") + 1).ToUpper() == "HTV")
                    {
                        txt_ThuMucGoc.Caption = folderOpen.SelectedPath;
                        btn_BatDau.Enabled = true;
                        kiemTra = false;
                    }
                    else
                    {
                        DialogUtil.ShowError("Thư mục bạn  chọn không hợp lệ! \n\nVui lòng chọn đúng thư mục HTV có lưu cấu trúc cây chứng từ");
                    }
                }
                else//trường hợp người ta muốn thoát khỏi hộp thoại showDialog
                {
                    kiemTra = false;
                }
            }
        }
    }
}
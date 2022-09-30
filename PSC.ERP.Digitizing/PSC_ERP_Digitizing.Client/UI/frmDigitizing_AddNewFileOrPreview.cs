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
using System.IO;
using PSC_ERP_Digitizing.Client.WebReference1;
using PSC_ERP_Digitizing.Client.Predefined;
using PSC_ERP_Digitizing.Client.Model;

namespace PSC_ERP_Digitizing.Client.UI
{
    public partial class frmDigitizing_AddNewFileOrPreview : DevExpress.XtraEditors.XtraForm
    {
        Boolean _daLoadFormXong = false;
        //DigitizingBag_Factory _factory = null;
        String _publicKey = "gi cung duoc";
        String _token = null;
        DigitizingBag _objFile = null;
        public frmDigitizing_AddNewFileOrPreview(DigitizingBag objFile)
        {
            InitializeComponent();

            _token = PSC_ERP_Digitizing.Client.Helper.MakeToken(publicKey: _publicKey, secretKey: "pscvietnam@hoasua");
            _objFile = objFile;


        }

        private void XuLyChungTu()
        {
            int maPhongBan = Convert.ToInt32(cbBoPhan.EditValue);
            int maLoaiChungTu = Convert.ToInt32(cbLoaiChungTu.EditValue);
            ChungTu currentChungTu = (ChungTu)cbChungTu.GetSelectedDataRow();
            //chung tu thanh 0
            cbChungTu.EditValue = null;
            cbChungTu.EditValue = Guid.Empty;

            //lay chung tu theo bo phan
            List<ChungTu> dsChungTu = new List<ChungTu>();
            //ghep danh sach

            dsChungTu = frmDigitizing.TimChungTuTheoBoPhanVaLoaiChungTu(maPhongBan, (DocumentTypeEnum)maLoaiChungTu);
            dsChungTu.Single(x => x.Id == Guid.Empty).SoChungTu = "<<Không chọn>>";
            chungTuBindingSource.DataSource = dsChungTu;
        }
        private Boolean UploadFile(String filePath, String destFileNameWithExtension)
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
                    this.progressBarControl1.Properties.Step = intendedChunkSize;
                    this.progressBarControl1.Properties.Maximum = (Int32)(fileSize / intendedChunkSize);
                    this.progressBarControl1.Properties.Minimum = 0;
                    fs.Position = offset;
                    int bytesRead = 0;
                    while (offset != fileSize)
                    {
                        //_num3 = Offset; //Dung lượng đã upload
                        progressBarControl1.PerformStep();
                        progressBarControl1.Update();

                        bytesRead = fs.Read(buffer, 0, intendedChunkSize);
                        if (bytesRead != intendedChunkSize)
                        {

                            byte[] trimmedBuffer = new byte[bytesRead];
                            Array.Copy(buffer, trimmedBuffer, bytesRead);
                            buffer = trimmedBuffer;
                        }

                        try
                        {
                            service.QuickHelper_UploadFileLargeSize(_publicKey, _token, destFileNameWithExtension, buffer, offset, fileSize);
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
        private void frmDigitizing_AddNewFileOrPreview_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            this.Shown += (object senderz, EventArgs ez) =>
            {
                TaskUtil.InvokeCrossThread(this, () =>
                {
                    using (DialogUtil.Wait(this))
                    {
                        _daLoadFormXong = false;
                        #region Body
                        //thiet lap
                        digitizingBagBindingSource.DataSource = new List<DigitizingBag> { _objFile };
                        //lay danh sach bo phan
                        List<tblnsBoPhan> boPhanList = BoPhan_Factory.New().GetAll().ToList();
                        boPhanList.Insert(0, new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" });
                        tblnsBoPhanBindingSource.DataSource = boPhanList;
                        //lay danh sach loai chung tu
                        documentTypeBindingSource.DataSource = DocumentType.DocumentTypeList;
                        TaskUtil.InvokeCrossThread(this, () =>
                        {
                            this.XuLyChungTu();

                            //
                            List<ChungTu> dsChungTu = (chungTuBindingSource.DataSource as List<ChungTu>);
                            ChungTu chungTuFind = null;

                            if (_objFile.tblChungTu != null)
                            {
                                chungTuFind = dsChungTu.SingleOrDefault(x => !x.LaChungTuImport && x.MaLoaiChungTu == _objFile.tblChungTu.MaLoaiChungTu && x.DbId == _objFile.File_tblChungTu_MaChungTu);

                            }
                            else if (_objFile.tblChungTuImport != null)
                            {
                                chungTuFind = dsChungTu.SingleOrDefault(x => x.LaChungTuImport && x.MaLoaiChungTu == _objFile.tblChungTu.MaLoaiChungTu && x.DbId == _objFile.File_tblChungTu_MaChungTu);

                            }
                            else if (_objFile.tblPhieuNhapXuat != null)
                            {
                                Int32 maLoaiChungTu;
                                if (_objFile.tblPhieuNhapXuat.LaNhap == true)
                                    maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.ChungTuKeToan_PhieuNhap);
                                else
                                    maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.ChungTuKeToan_PhieuXuat);

                                chungTuFind = dsChungTu.SingleOrDefault(x => x.MaLoaiChungTu == maLoaiChungTu && x.DbId == _objFile.File_tblPhieuNhapXuat_MaPhieuNhapXuat);
                            }
                            else if (_objFile.tblHopDong != null)
                            {
                                Int32 maLoaiChungTu;
                                if (_objFile.tblHopDong.tblHopDongMuaBan.HDTrongNgoaiDai == false)
                                    maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.HopDong_NoiBo);
                                else
                                    maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.HopDong_BenNgoai);

                                chungTuFind = dsChungTu.SingleOrDefault(x => x.MaLoaiChungTu == maLoaiChungTu && x.DbId == _objFile.File_tblHopDong_MaHopDong);
                            }
                            else
                            {//lấy chứng từ không chọn
                                chungTuFind = dsChungTu.SingleOrDefault(x => x.Id == Guid.Empty);
                            }
                            if (chungTuFind != null)
                                //active den chung tu thuoc fileBag
                                cbChungTu.EditValue = chungTuFind.Id;


                        });
                        #endregion
                        _daLoadFormXong = true;
                    }
                });

            };
        }
        private void frmDigitizing_AddNewFileOrPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtBlackHole.Focus();
            //lưu lại liên kết với chứng từ các loại
            //b1 lấy thông tin chứng từ đang chọn
            ChungTu currentChungTu = (ChungTu)cbChungTu.GetSelectedDataRow();
            _objFile.File_tblChungTu_MaChungTu = null;
            _objFile.File_tblChungTuImport_MaChungTu = null;
            _objFile.File_tblPhieuNhapXuat_MaPhieuNhapXuat = null;
            _objFile.File_tblHopDong_MaHopDong = null;

            DocumentTypeEnum loaiChungTu = (DocumentTypeEnum)currentChungTu.MaLoaiChungTu;

            switch (loaiChungTu)
            {
                //case DocumentTypeEnum.TatCa:
                //    break;
                case DocumentTypeEnum.ChungTuKeToan_PhieuThu:
                case DocumentTypeEnum.ChungTuKeToan_PhieuChi:
                case DocumentTypeEnum.ChungTuKeToan_BangKe:
                    {
                        if (currentChungTu.LaChungTuImport)
                        {
                            _objFile.File_tblChungTuImport_MaChungTu = currentChungTu.DbId;
                        }
                        else
                        {
                            _objFile.File_tblChungTu_MaChungTu = currentChungTu.DbId;
                        }
                    }
                    break;
                case DocumentTypeEnum.ChungTuKeToan_PhieuNhap:
                case DocumentTypeEnum.ChungTuKeToan_PhieuXuat:
                    _objFile.File_tblPhieuNhapXuat_MaPhieuNhapXuat = currentChungTu.DbId;
                    break;
                case DocumentTypeEnum.HopDong_NoiBo:
                case DocumentTypeEnum.HopDong_BenNgoai:
                    _objFile.File_tblHopDong_MaHopDong = currentChungTu.DbId;
                    break;
                default:
                    break;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            txtBlackHole.Focus();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Pdf files|*.pdf";
            openFileDialog1.Multiselect = false;

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {

                string filePath = openFileDialog1.FileName;
                if (String.IsNullOrWhiteSpace(filePath) == false)
                {
                    while (String.IsNullOrWhiteSpace(_objFile.Name))
                    {
                        _objFile.Name = Microsoft.VisualBasic.Interaction.InputBox("Hãy nhập tên tài liệu.", "Tên tài liệu", "");
                    }
                    lblFilePath.Text = filePath;

                    String extension = Path.GetExtension(filePath);
                    if (UploadFile(filePath, _objFile.BagId.ToString() + extension))
                    {
                        //bat co file
                        _objFile.IsFile = true;
                        //ten file ban dau
                        _objFile.OriginalFileName = Path.GetFileName(filePath);
                        //lưu vết đường dẫn file
                        _objFile.UploadFromFilePath = filePath;
                        //lưu vết máy tính va user up
                        _objFile.UploadFromComputerUser = Environment.MachineName + "\\" + Environment.UserName;
                        //ip
                        _objFile.UploadFromIPAddress = PSC_ERP_Util.NetUtil.FindLanAddress().ToString();
                        //ghi nhận đã upload xong
                        _objFile.FileUploadCompleted = true;
                        //dinh kieu diglog
                        this.DialogResult = DialogResult.OK;
                        //chi close khi up load xong va ko bi loi
                        this.Close();
                    }



                }


            }
        }




    }
}
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
//using PSC_ERPNew.Main.PhanHe.DIGITIZING.WebReference1;
using PSC_ERPNew.Main.PhanHe.DIGITIZING.Predefined;
using PSC_ERPNew.Main.PhanHe.DIGITIZING.Model;
using PSC_ERP_Digitizing.Client.WebReference1;

namespace PSC_ERPNew.Main.PhanHe.DIGITIZING
{
    public partial class frmDigitizing_AddNewFileOrPreview : DevExpress.XtraEditors.XtraForm
    {
        Boolean _daLoadFormXong = false;
        //DigitizingBag_Factory _factory = null;
        String _publicKey = "gi cung duoc";
        String _token = null;
        DigitizingBag _objFile = null;
        Boolean _preview = false;

        Int64? _maBoPhan_ForQuickLoad = null;
        DocumentTypeEnum _docTypeEnum_ForQuickLoad;
        Boolean _laChungTuImport_ForQuickLoad = false;
        Int64? _maChungTu_ForQuickLoad = null;
        Int32? _folderYear = null;
        public frmDigitizing_AddNewFileOrPreview(Int32? maBoPhan_ForQuickLoad, DocumentTypeEnum docTypeEnum_ForQuickLoad, Int32? folderYear, Int64? maChungTu_ForQuickLoad,                                                  Boolean preview, DigitizingBag objFile, Boolean laChungTuImport_ForQuickLoad = false)
        {
            InitializeComponent();

            _token = PSC_ERPNew.Main.PhanHe.DIGITIZING.Helper.MakeToken(publicKey: _publicKey, secretKey: "pscvietnam@hoasua");
            _objFile = objFile;
            _preview = preview;

            ///
            _maBoPhan_ForQuickLoad = maBoPhan_ForQuickLoad;
            _docTypeEnum_ForQuickLoad = docTypeEnum_ForQuickLoad;
            _folderYear = folderYear;
            _maChungTu_ForQuickLoad = maChungTu_ForQuickLoad;
            _laChungTuImport_ForQuickLoad = laChungTuImport_ForQuickLoad;

        }

        private void XuLyChungTu(Int64? maChungTu)
        {
            int nam = Convert.ToInt32(cbNam.EditValue);
            int maPhongBan = Convert.ToInt32(cbBoPhan.EditValue);
            int maLoaiChungTu = Convert.ToInt32(cbLoaiChungTu.EditValue);
            Document currentChungTu = (Document)cbChungTu.GetSelectedDataRow();

            //lay chung tu theo bo phan
            List<Document> dsChungTu = new List<Document>();
            //ghep danh sach

            dsChungTu = frmDigitizing.TimChungTu(nam, maPhongBan, (DocumentTypeEnum)maLoaiChungTu, _maChungTu_ForQuickLoad);
            dsChungTu.Single(x => x.Id == Guid.Empty).SoChungTu = "<<Không chọn>>";
            chungTuBindingSource.DataSource = dsChungTu;
            //can lay lai chung tu da chon
            this.ActiveChungTuDaChon();
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
                        //năm
                        {
                            List<Year> namList = new List<Year>();
                            namList.Add(new Year(0, "<<Tất cả>>"));
                            int namDauTien = 1998;
                            int namHienTai = app_users_Factory.New().SystemDate.Year;
                            for (int i = namDauTien++; i <= namHienTai + 5; i++)
                                namList.Add(new Year(i));
                            yearBindingSource.DataSource = namList;
                            //set mặc định năm
                            cbNam.EditValue = _folderYear;
                        }
                        //lay danh sach bo phan
                        List<tblnsBoPhan> boPhanList = BoPhan_Factory.New().GetAll().ToList();
                        boPhanList.Insert(0, new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" });
                        tblnsBoPhanBindingSource.DataSource = boPhanList;
                        cbBoPhan.EditValue = _maBoPhan_ForQuickLoad;

                        //lay danh sach loai chung tu
                        documentTypeBindingSource.DataSource = DocumentType.DocumentTypeList;
                        cbLoaiChungTu.EditValue = Convert.ToInt32(_docTypeEnum_ForQuickLoad);
                        //
                        digitizingBagBindingSource.DataSource = new List<DigitizingBag> { _objFile };


                        this.XuLyChungTu(_maChungTu_ForQuickLoad);

                        #region Active chung tu
                        frmDigitizing.ActiveChungTuCanThiet((chungTuBindingSource.DataSource as List<Document>), _docTypeEnum_ForQuickLoad, _laChungTuImport_ForQuickLoad, _maChungTu_ForQuickLoad, cbChungTu);
                        ActiveChungTuDaChon();
                        #endregion
                        //});
                        #endregion
                        _daLoadFormXong = true;
                    }
                });

            };
        }
        private void ActiveChungTuDaChon()
        {
            //List<Document> dsChungTu = (chungTuBindingSource.DataSource as List<Document>);

            //if (dsChungTu != null && dsChungTu.Count > 1)
            //{
            //    Document chungTuFind = null;

            //    //hiển thị lại chứng từ đã chọn
            //    if (_objFile.tblChungTu != null)
            //    {
            //        chungTuFind = dsChungTu.SingleOrDefault(x => !x.LaChungTuImport && x.MaLoaiChungTu == _objFile.tblChungTu.MaLoaiChungTu && x.DbId == _objFile.File_tblChungTu_MaChungTu);

            //    }
            //    else if (_objFile.tblChungTuImport != null)
            //    {
            //        chungTuFind = dsChungTu.SingleOrDefault(x => x.LaChungTuImport && x.MaLoaiChungTu == _objFile.tblChungTu.MaLoaiChungTu && x.DbId == _objFile.File_tblChungTu_MaChungTu);

            //    }
            //    else if (_objFile.tblPhieuNhapXuat != null)
            //    {
            //        Int32 maLoaiChungTu;
            //        if (_objFile.tblPhieuNhapXuat.LaNhap == true)
            //            maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.ChungTuKeToan_PhieuNhap);
            //        else
            //            maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.ChungTuKeToan_PhieuXuat);

            //        chungTuFind = dsChungTu.SingleOrDefault(x => x.MaLoaiChungTu == maLoaiChungTu && x.DbId == _objFile.File_tblPhieuNhapXuat_MaPhieuNhapXuat);
            //    }
            //    else if (_objFile.tblHopDong != null)
            //    {
            //        Int32 maLoaiChungTu;
            //        if (_objFile.tblHopDong.tblHopDongMuaBan.HDTrongNgoaiDai == false)
            //            maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.HopDong_NoiBo);
            //        else
            //            maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.HopDong_BenNgoai);

            //        chungTuFind = dsChungTu.SingleOrDefault(x => x.MaLoaiChungTu == maLoaiChungTu && x.DbId == _objFile.File_tblHopDong_MaHopDong);
            //    }
            //    else
            //    {//lấy chứng từ không chọn
            //        chungTuFind = dsChungTu.SingleOrDefault(x => x.Id == Guid.Empty);
            //    }
            //    //
            //    if (chungTuFind != null)
            //        //active den chung tu thuoc fileBag
            //        cbChungTu.EditValue = chungTuFind.Id;
            //    else
            //    {
            //        cbChungTu.EditValue = Guid.Empty;
            //    }
            //}
        }


        private void frmDigitizing_AddNewFileOrPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (this.DialogResult == DialogResult.OK || (this.DialogResult == DialogResult.Yes && _preview))
            {
                //lưu lại liên kết với chứng từ các loại
                //b1 lấy thông tin chứng từ đang chọn
                Document currentChungTu = (Document)cbChungTu.GetSelectedDataRow();
                //clear
                _objFile.MaLoaiChungTu = null;
                _objFile.MaChungTu = null;
                //_objFile.File_tblChungTu_MaChungTu = null;
                //_objFile.File_tblChungTuImport_MaChungTu = null;
                //_objFile.File_tblPhieuNhapXuat_MaPhieuNhapXuat = null;
                //_objFile.File_tblHopDong_MaHopDong = null;

                DocumentTypeEnum loaiChungTu = (DocumentTypeEnum)currentChungTu.MaLoaiChungTu;
                _objFile.MaLoaiChungTu = currentChungTu.MaLoaiChungTu;
                _objFile.MaLoaiChungTu = currentChungTu.MaLoaiChungTu;
                //switch (loaiChungTu)
                //{
                //    //case DocumentTypeEnum.TatCa:
                //    //    break;
                //    case DocumentTypeEnum.ChungTuKeToan_PhieuThu:
                //    case DocumentTypeEnum.ChungTuKeToan_PhieuChi:
                //    case DocumentTypeEnum.ChungTuKeToan_BangKe:
                //        {
                //            if (currentChungTu.LaChungTuImport)
                //            {
                //                _objFile.File_tblChungTuImport_MaChungTu = currentChungTu.DbId;
                //            }
                //            else
                //            {
                //                _objFile.File_tblChungTu_MaChungTu = currentChungTu.DbId;
                //            }
                //        }
                //        break;
                //    case DocumentTypeEnum.ChungTuKeToan_PhieuNhap:
                //    case DocumentTypeEnum.ChungTuKeToan_PhieuXuat:
                //        _objFile.File_tblPhieuNhapXuat_MaPhieuNhapXuat = currentChungTu.DbId;
                //        break;
                //    case DocumentTypeEnum.HopDong_NoiBo:
                //    case DocumentTypeEnum.HopDong_BenNgoai:
                //        _objFile.File_tblHopDong_MaHopDong = currentChungTu.DbId;
                //        break;
                //    default:
                //        //lưu vết mã loại chứng từ
                //        _objFile.DocumentTypeEnumId = currentChungTu.MaLoaiChungTu;
                //        break;
                //}
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            txtBlackHole.Focus();

            //if (String.IsNullOrWhiteSpace(_objFile.Name))
            //{
            //    DialogUtil.ShowWarning("Chưa nhập tên tài liệu!");
            //    txtDocumentName.Focus();
            //}
            //else
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Pdf files|*.pdf";
                openFileDialog1.Multiselect = false;

                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {

                    string filePath = openFileDialog1.FileName;
                    if (String.IsNullOrWhiteSpace(filePath) == false)
                    {

                        lblFilePath.Text = filePath;

                        String extension = Path.GetExtension(filePath);
                        if (frmDigitizing.UploadFile(_publicKey, _token, filePath, _objFile.BagId.ToString() + extension))
                        {
                            if (String.IsNullOrWhiteSpace(_objFile.Name))
                                _objFile.Name = Path.GetFileName(filePath);
                            //bat co file
                            _objFile.IsFile = true;
                            //ten file ban dau
                            _objFile.OriginalFileName = Path.GetFileName(filePath);
                            //lưu vết đường dẫn file
                            _objFile.UploadFromFilePath = filePath;
                            //lưu vết máy tính va user up
                            _objFile.UploadFromComputerUser = Environment.MachineName + "\\" + Environment.UserName;
                            //ip
                            try
                            {
                                _objFile.UploadFromIPAddress = PSC_ERP_Util.NetUtil.FindLanAddress().ToString();
                            }
                            catch (Exception exp)
                            { }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_preview)
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            else
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void cbChungTu_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách
            {
                using (DialogUtil.Wait(this))
                {
                    this.XuLyChungTu(_maChungTu_ForQuickLoad);
                }
            }
        }

        private void cbNam_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadFormXong)
            {
                TaskUtil.InvokeCrossThread(this, () =>
                {
                    using (DialogUtil.Wait(this))
                    {
                        XuLyChungTu(null);
                    }
                });
            }
        }
        private void cbBoPhan_EditValueChanged(object sender, EventArgs e)
        {
            //Bo phan thay doi se lay lai danh sach chung tu theo bo phan va loai chung tu
            if (_daLoadFormXong)
            {
                TaskUtil.InvokeCrossThread(this, () =>
                {
                    using (DialogUtil.Wait(this))
                    {
                        XuLyChungTu(null);
                    }
                });
            }
        }

        private void cbLoaiChungTu_EditValueChanged(object sender, EventArgs e)
        {
            //loai chung tu thay doi se lay lai danh sach chung tu theo bo phan va loai chung tu
            if (_daLoadFormXong)
            {
                TaskUtil.InvokeCrossThread(this, () =>
                {
                    using (DialogUtil.Wait(this))
                    {
                        XuLyChungTu(null);
                    }
                });
            }
        }






    }
}
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
    public partial class frmDigitizing : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDigitizing singleton_ = null;
        public static frmDigitizing Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDigitizing();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion

        #region Show File theo chung tu
        //phiếu thu - tblChungTu
        public static void ShowFile_PhieuThu(Int64 maChungTu, Boolean laChungTuImport, Form owner)
        {
            var frm = new frmDigitizing(DocumentTypeEnum.ChungTuKeToan_PhieuThu, maChungTu, laChungTuImport);
            PSC_ERP_Common.FormUtil.ShowForm_Helper(frm, owner);
        }
        //phiếu chi - tblChungTu
        public static void ShowFile_PhieuChi(Int64 maChungTu, Boolean laChungTuImport, Form owner)
        {
            var frm = new frmDigitizing(DocumentTypeEnum.ChungTuKeToan_PhieuChi, maChungTu, laChungTuImport);
            PSC_ERP_Common.FormUtil.ShowForm_Helper(frm, owner);
        }
        //bảng kê - tblChungTu
        public static void ShowFile_BangKe(Int64 maChungTu, Boolean laChungTuImport, Form owner)
        {
            var frm = new frmDigitizing(DocumentTypeEnum.ChungTuKeToan_BangKe, maChungTu, laChungTuImport);
            PSC_ERP_Common.FormUtil.ShowForm_Helper(frm, owner);
        }

        //phiếu nhập xuất  - tblPhieuNhapXuat
        public static void ShowFile_PhieuNhapXuat(Int64 maPhieuNhapXuat, Boolean laPhieuNhap, Form owner)
        {
            frmDigitizing frm;
            if (laPhieuNhap)
                frm = new frmDigitizing(DocumentTypeEnum.ChungTuKeToan_PhieuNhap, maPhieuNhapXuat);
            else
                frm = new frmDigitizing(DocumentTypeEnum.ChungTuKeToan_PhieuXuat, maPhieuNhapXuat);
            PSC_ERP_Common.FormUtil.ShowForm_Helper(frm, owner);
        }

        //hợp đồng - hợp dồng nội bộ và hợp đồng mua bán
        public static void ShowFile_HopDong(Int64 maHopDong, Boolean laHopDongNoiBo, Form owner)
        {
            frmDigitizing frm;
            //hợp đồng nội bộ - tblHopDong 
            if (laHopDongNoiBo)
                frm = new frmDigitizing(DocumentTypeEnum.HopDong_NoiBo, maHopDong);
            //hợp đồng mua bán - tblHopDongMuaBan
            else
                frm = new frmDigitizing(DocumentTypeEnum.HopDong_BenNgoai, maHopDong);
            PSC_ERP_Common.FormUtil.ShowForm_Helper(frm, owner);
        }
        #endregion


        Int32? _maBoPhan_ForQuickLoad = null;
        DocumentTypeEnum _docTypeEnum_ForQuickLoad;
        Boolean _laChungTuImport_ForQuickLoad = false;
        Int64? _maChungTu_ForQuickLoad = null;


        String _publicKey = "gi cung duoc";
        String _token = null;
        Boolean _daLoadFormXong = false;
        //List<ChungTu> _chungTuList = null;
        DigitizingBag_Factory _treeBagFactory = DigitizingBag_Factory.New();
        public IQueryable<DigitizingBag> treeBag;

        TreeListNode focusedNode;
        DigitizingBag currentObjectAtNode;
        DigitizingBag _currentBagForPreview = null;


        public static Boolean UploadFile(String publicKey, String token, String filePath, String destFileNameWithExtension)
        {
            bool uploadSuccedd = true;
            //try
            //{
            //    long offset = 0;
            //    int intendedChunkSize = 65536; //65536;
            //    byte[] buffer = new byte[intendedChunkSize];
            //    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //    DigitizingService service = new DigitizingService();
            //    //DigitizingServiceSoap service = new DigitizingServiceSoapClient();
            //    try
            //    {
            //        Int64 fileSize = new FileInfo(filePath).Length;//Tổng dung lượng file
            //        //this.progressBarControl1.Properties.Step = intendedChunkSize;
            //        //this.progressBarControl1.Properties.Maximum = (Int32)(fileSize / intendedChunkSize);
            //        //this.progressBarControl1.Properties.Minimum = 0;
            //        fs.Position = offset;
            //        int bytesRead = 0;
            //        while (offset != fileSize)
            //        {
            //            ////////_num3 = Offset; //Dung lượng đã upload
            //            //progressBarControl1.PerformStep();
            //            //progressBarControl1.Update();

            //            bytesRead = fs.Read(buffer, 0, intendedChunkSize);
            //            if (bytesRead != intendedChunkSize)
            //            {

            //                byte[] trimmedBuffer = new byte[bytesRead];
            //                Array.Copy(buffer, trimmedBuffer, bytesRead);
            //                buffer = trimmedBuffer;
            //            }

            //            try
            //            {
            //                service.QuickHelper_UploadFileLargeSize(publicKey, token, destFileNameWithExtension, buffer, offset, fileSize);
            //                //QuickHelper_UploadFileLargeSizeResponse response = service.QuickHelper_UploadFileLargeSize(new QuickHelper_UploadFileLargeSizeRequest(new QuickHelper_UploadFileLargeSizeRequestBody(PublicKey, Token, targetFilePath, buffer, offset, fileSize)));
            //            }
            //            catch (Exception ex)
            //            {
            //                uploadSuccedd = false;
            //                break;
            //            }

            //            offset += bytesRead;
            //        }
            //    }
            //    catch { }
            //    finally
            //    {
            //        fs.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //PscMessage.ShowError(ex.Message);
            //}
            return uploadSuccedd;
        }

        public frmDigitizing()
        {
            InitializeComponent();
        }

        public frmDigitizing(DocumentTypeEnum docTypeEnum, Int64 maChungTu, Boolean laChungTuImport = false)
        {
            InitializeComponent();
            _docTypeEnum_ForQuickLoad = docTypeEnum;
            _maChungTu_ForQuickLoad = maChungTu;
            _laChungTuImport_ForQuickLoad = laChungTuImport;
            //tìm mã bộ phận theo user chứng từ
            switch (docTypeEnum)
            {
                case DocumentTypeEnum.TatCa:
                    _maBoPhan_ForQuickLoad = null;
                    break;
                case DocumentTypeEnum.ChungTuKeToan_PhieuThu:
                case DocumentTypeEnum.ChungTuKeToan_PhieuChi:
                case DocumentTypeEnum.ChungTuKeToan_BangKe:
                    {
                        var obj = ChungTu_Factory.New().Get_ChungTu_ByMaChungTu(_maChungTu_ForQuickLoad.Value);
                        _maBoPhan_ForQuickLoad = obj.app_users.MaBoPhan;
                    }
                    break;
                case DocumentTypeEnum.ChungTuKeToan_PhieuNhap:
                case DocumentTypeEnum.ChungTuKeToan_PhieuXuat:
                    {
                        var obj = PhieuNhapXuat_Factory.New().GetBy_MaPhieuNhapXuat(_maChungTu_ForQuickLoad.Value);
                        _maBoPhan_ForQuickLoad = obj.app_users.MaBoPhan;
                    }
                    break;
                case DocumentTypeEnum.HopDong_NoiBo:
                case DocumentTypeEnum.HopDong_BenNgoai:
                    {
                        var obj = HopDong_Factory.New().Get_HopDong_ByMaHopDong(_maChungTu_ForQuickLoad.Value);
                        _maBoPhan_ForQuickLoad = obj.app_users.MaBoPhan;
                    }
                    break;
                default:
                    break;
            }
        }


        private void DocDuLieuVaDuaLenCay()
        {
            //tạo mới factory
            //_treeBagFactory = DigitizingBag_Factory.New();
           treeBag = _treeBagFactory.GetAll();
            int namHienTai = app_users_Factory.New().SystemDate.Year;//(DateTime.Today.Year);
            //lọc bớt chỉ lấy dữ liệu đến năm hiện tại
            treeBag = treeBag.Where(x => ((x.FolderYear ?? namHienTai) <= namHienTai && (x.IsFile ?? false) == false)
                                                || (x.IsFile ?? false) == true);
            #region lọc lại danh sách file theo chứng từ
            if (_maChungTu_ForQuickLoad != null)
            {
                int maLoaiChungTu = Convert.ToInt32(_docTypeEnum_ForQuickLoad);
                //treeBag = treeBag.Where(
                //    x => (x.IsFile ?? false) == true
                //           ||
                //           (
                //                (x.IsFile ?? false) == false
                //                &&
                //                (
                //                    x.MaBoPhan == _maBoPhan_ForQuickLoad
                //                    ||
                //                    x.DocumentTypeEnumId == maLoaiChungTu
                //                    ||
                //                    (
                //                        (x.FolderYear ?? 0) != 0
                //                        &&
                //                        (
                //                                    x.DigitizingBag2.MaBoPhan == _maBoPhan_ForQuickLoad
                //                                    ||
                //                                    x.DigitizingBag2.DocumentTypeEnumId == maLoaiChungTu
                //                        )
                //                    )
                //                 )
                //           )
                //          );//end where


                treeBag = treeBag.Where(
                   x => ((x.IsFile ?? false) == true  //trường hợp lấy node (file)
                            && x.MaBoPhan == _maBoPhan_ForQuickLoad 
                            && x.MaLoaiChungTu == maLoaiChungTu)//lấy tất cả các file thuộc phòng ban và loại chứng từ
                         // || //trường hợp lấy nhánh cây Folder
                         // ((x.IsFile ?? false) == false
                         //   &&  (x.MaBoPhan == _maBoPhan_ForQuickLoad && x.DocumentTypeEnumId == _maBoPhan_ForQuickLoad)                          
                         // )
                         );//end where



                //hiển thị lại chứng từ đã chọn
                //if (_docTypeEnum_ForQuickLoad == DocumentTypeEnum.ChungTuKeToan_PhieuThu
                //    || _docTypeEnum_ForQuickLoad == DocumentTypeEnum.ChungTuKeToan_PhieuChi
                //    || _docTypeEnum_ForQuickLoad == DocumentTypeEnum.ChungTuKeToan_BangKe)
                //{
                //    if (_laChungTuImport_ForQuickLoad)
                //    {
                //        treeBag = treeBag.Where(x => (x.File_tblChungTuImport_MaChungTu == _maChungTu_ForQuickLoad) || !(x.IsFile ?? false));
                //    }
                //    else
                //    {
                //        treeBag = treeBag.Where(x => x.File_tblChungTu_MaChungTu == _maChungTu_ForQuickLoad || !(x.IsFile ?? false));
                //    }
                //}
                //else if (_docTypeEnum_ForQuickLoad == DocumentTypeEnum.ChungTuKeToan_PhieuNhap
                //    || _docTypeEnum_ForQuickLoad == DocumentTypeEnum.ChungTuKeToan_PhieuXuat)
                //{
                //    treeBag = treeBag.Where(x => x.File_tblPhieuNhapXuat_MaPhieuNhapXuat == _maChungTu_ForQuickLoad || !(x.IsFile ?? false));
                //}
                //else if (_docTypeEnum_ForQuickLoad == DocumentTypeEnum.HopDong_NoiBo
                //    || _docTypeEnum_ForQuickLoad == DocumentTypeEnum.HopDong_BenNgoai)
                //{
                //    treeBag = treeBag.Where(x => x.File_tblHopDong_MaHopDong == _maChungTu_ForQuickLoad || (x.IsFile ?? false) == false);
                //}
               // treeBag = DigitizingBag_Factory.New().Context.spd_TimFile(nam, maBoPhan, currentChungTu.MaLoaiChungTu, _maChungTu_ForQuickLoad, true) as List<DigitizingBag>;
            }
            #endregion

            //gắn binding source
            digitizingBagBindingSource_ForTree.DataSource = treeBag;
            //treeListBag.DataSource = digitizingBagBindingSource_ForTree;
        }


        public static List<Document> TimChungTu(int? nam, int? maBoPhan, DocumentTypeEnum documentType, Int64? maChungTu)
        {
            Int32 maLoaiChungTuForFind = Convert.ToInt32(documentType);
            IEnumerable<Document> listBangKe_PhieuThu_PhieuChi = new List<Document>();
            IEnumerable<Document> listChungTu_PhieuNhap = new List<Document>();
            IEnumerable<Document> listChungTu_PhieuXuat = new List<Document>();
            IEnumerable<Document> listHopDong_NoiBo = new List<Document>();
            IEnumerable<Document> listHopDong_BenNgoai = new List<Document>();

            IEnumerable<Document> listChungTuFull = new List<Document>();
            //

            #region tblChungTu & tblChungtuImport
            if (documentType == DocumentTypeEnum.TatCa
                || documentType == DocumentTypeEnum.ChungTuKeToan_BangKe
                || documentType == DocumentTypeEnum.ChungTuKeToan_PhieuThu
                || documentType == DocumentTypeEnum.ChungTuKeToan_PhieuChi
               )
            {
                //tblChungTu
                ChungTu_Factory chungTuFactory = ChungTu_Factory.New();
                IQueryable<tblChungTu> tmp1 = chungTuFactory.GetListBy_MaLoaiChungTu_MaBoPhan_Nam(maLoaiChungTuForFind, maBoPhan, nam);
                if ((maChungTu ?? 0) != 0)
                {
                    //lọc chỉ lấy 1
                    tmp1 = tmp1.Where(x => x.MaChungTu == maChungTu);
                }
                if (tmp1.Any() != false)
                {
                    IEnumerable<Document> tmp1_1 = tmp1.Select(x => new Document()
                      {
                          Id = Guid.NewGuid(),
                          DbId = x.MaChungTu,
                          SoChungTu = x.SoChungTu,
                          NgayChungTu = x.NgayLap,
                          MaLoaiChungTu = x.MaLoaiChungTu
                      }).AsEnumerable();
                    //ghép
                    listBangKe_PhieuThu_PhieuChi = listBangKe_PhieuThu_PhieuChi.Concat(tmp1_1);
                }

                //tblChungTuImport
                ChungTuImport_Factory chungTuImportFactory = ChungTuImport_Factory.New();
                IQueryable<tblChungTuImport> tmp2 = chungTuImportFactory.GetListBy_MaLoaiChungTu_MaBoPhan_Nam(maLoaiChungTuForFind, maBoPhan, nam);
                if ((maChungTu ?? 0) != 0)
                {
                    //lọc chỉ lấy 1
                    tmp2 = tmp2.Where(x => x.MaChungTu == maChungTu);
                }
                if (tmp1.Any() != false)
                {
                    IEnumerable<Document> tmp2_1 = tmp2.Select(x => new Document()
                    {
                        Id = Guid.NewGuid(),
                        DbId = x.MaChungTu,
                        SoChungTu = x.SoChungTu,
                        NgayChungTu = x.NgayLap,
                        MaLoaiChungTu = x.MaLoaiChungTu ?? 0,
                        LaChungTuImport = true
                    }).AsEnumerable();
                    //ghép
                    listBangKe_PhieuThu_PhieuChi = listBangKe_PhieuThu_PhieuChi.Concat(tmp2_1);
                }
                //
                if (documentType != DocumentTypeEnum.TatCa)
                    listChungTuFull = listBangKe_PhieuThu_PhieuChi;
                else
                    listChungTuFull = listChungTuFull.Concat(listBangKe_PhieuThu_PhieuChi);
            }
            #endregion
            //phieu nhap xuat

            #region tblPhieuNhapXuat
            if (documentType == DocumentTypeEnum.TatCa
                || documentType == DocumentTypeEnum.ChungTuKeToan_PhieuNhap
                || documentType == DocumentTypeEnum.ChungTuKeToan_PhieuXuat)
            {
                PhieuNhapXuat_Factory phieuNhapXuatFactory = PhieuNhapXuat_Factory.New();
                if (documentType == DocumentTypeEnum.TatCa || documentType == DocumentTypeEnum.ChungTuKeToan_PhieuNhap)
                {
                    IQueryable<tblPhieuNhapXuat> tmpPhieuNhap = phieuNhapXuatFactory.GetListPhieuNhapBy_MaBoPhan_Nam(maBoPhan, nam);
                    if ((maChungTu ?? 0) != 0)
                    {
                        //lọc chỉ lấy 1
                        tmpPhieuNhap = tmpPhieuNhap.Where(x => x.MaPhieuNhapXuat == maChungTu);
                    }
                    if (tmpPhieuNhap.Any() != false)
                    {
                        int maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.ChungTuKeToan_PhieuNhap);
                        listChungTu_PhieuNhap = tmpPhieuNhap.Select(x => new Document()
                        {
                            Id = Guid.NewGuid(),
                            DbId = x.MaPhieuNhapXuat,
                            SoChungTu = x.SoPhieu,
                            NgayChungTu = x.NgayNX,
                            MaLoaiChungTu = maLoaiChungTu
                        }).ToList();

                        if (documentType != DocumentTypeEnum.TatCa)
                            listChungTuFull = listChungTu_PhieuNhap;
                        else
                            listChungTuFull = listChungTuFull.Concat(listChungTu_PhieuNhap);
                    }
                }
                if (documentType == DocumentTypeEnum.TatCa || documentType == DocumentTypeEnum.ChungTuKeToan_PhieuXuat)
                {
                    IQueryable<tblPhieuNhapXuat> tmpPhieuXuat = phieuNhapXuatFactory.GetListPhieuXuatBy_MaBoPhan_Nam(maBoPhan, nam);
                    if ((maChungTu ?? 0) != 0)
                    {
                        //lọc chỉ lấy 1
                        tmpPhieuXuat = tmpPhieuXuat.Where(x => x.MaPhieuNhapXuat == maChungTu);
                    }
                    if (tmpPhieuXuat.Any() != false)
                    {
                        int maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.ChungTuKeToan_PhieuXuat);
                        listChungTu_PhieuXuat = tmpPhieuXuat.Select(x => new Document()
                        {
                            Id = Guid.NewGuid(),
                            DbId = x.MaPhieuNhapXuat,
                            SoChungTu = x.SoPhieu,
                            NgayChungTu = x.NgayNX,
                            MaLoaiChungTu = maLoaiChungTu
                        }).AsEnumerable();
                        if (documentType != DocumentTypeEnum.TatCa)
                            listChungTuFull = listChungTu_PhieuXuat;
                        else
                            listChungTuFull = listChungTuFull.Concat(listChungTu_PhieuXuat);
                    }
                }
            }
            #endregion

            //hop dong
            #region tblHopDongMuaBan
            if (documentType == DocumentTypeEnum.TatCa
                || documentType == DocumentTypeEnum.HopDong_NoiBo
                || documentType == DocumentTypeEnum.HopDong_BenNgoai)
            {
                HopDongMuaBan_Factory hopDongMuaBanFactory = HopDongMuaBan_Factory.New();
                if (documentType == DocumentTypeEnum.TatCa || documentType == DocumentTypeEnum.HopDong_NoiBo)
                {
                    IQueryable<tblHopDongMuaBan> tmpHopDongNoiBo = hopDongMuaBanFactory.GetListHDNoiBoBy_MaBoPhan_Nam(maBoPhan, nam);
                    if ((maChungTu ?? 0) != 0)
                    {
                        //lọc chỉ lấy 1
                        tmpHopDongNoiBo = tmpHopDongNoiBo.Where(x => x.MaHopDong == maChungTu);
                    }
                    if (tmpHopDongNoiBo.Any() != false)
                    {
                        int maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.HopDong_NoiBo);
                        listHopDong_NoiBo = tmpHopDongNoiBo.Select(x => new Document()
                        {
                            Id = Guid.NewGuid(),
                            DbId = x.MaHopDong,
                            SoChungTu = x.SoHopDong,
                            NgayChungTu = x.tblHopDong.NgayKy,
                            MaLoaiChungTu = maLoaiChungTu
                        }).ToList();

                        if (documentType != DocumentTypeEnum.TatCa)
                            listChungTuFull = listHopDong_NoiBo;
                        else
                            listChungTuFull = listChungTuFull.Concat(listHopDong_NoiBo);
                    }
                }
                if (documentType == DocumentTypeEnum.TatCa || documentType == DocumentTypeEnum.HopDong_BenNgoai)
                {
                    IQueryable<tblHopDongMuaBan> tmpHopDongBenNgoai = hopDongMuaBanFactory.GetListHDBenNgoaiBy_MaBoPhan(maBoPhan, nam);
                    if ((maChungTu ?? 0) != 0)
                    {
                        //lọc chỉ lấy 1
                        tmpHopDongBenNgoai = tmpHopDongBenNgoai.Where(x => x.MaHopDong == maChungTu);
                    }
                    if (tmpHopDongBenNgoai.Any() != false)
                    {
                        int maLoaiChungTu = Convert.ToInt32(DocumentTypeEnum.HopDong_BenNgoai);
                        listHopDong_BenNgoai = tmpHopDongBenNgoai.Select(x => new Document()
                        {
                            Id = Guid.NewGuid(),
                            DbId = x.MaHopDong,
                            SoChungTu = x.SoHopDong,
                            NgayChungTu = x.tblHopDong.NgayKy,
                            MaLoaiChungTu = maLoaiChungTu
                        }).AsEnumerable();
                        if (documentType != DocumentTypeEnum.TatCa)
                            listChungTuFull = listHopDong_BenNgoai;
                        else
                            listChungTuFull = listChungTuFull.Concat(listHopDong_BenNgoai);
                    }
                }
            }
            #endregion

            List<Document> result = listChungTuFull.ToList();
            result.Insert(0, new Document { Id = Guid.Empty, DbId = 0, SoChungTu = "<<Tất cả>>", MaLoaiChungTu = Convert.ToInt32(documentType) });
            return result;
        }
        //private void 


        #region tìm file
        private List<DigitizingBag> TimFileBag(Boolean timNoiDungFile, Boolean timKetHop)
        {
            //int maLoaiChungTuFromDB_BangKe =16
            //lay danh sach file thuoc chung tu
            //Guid id = (Guid)cbChungTu.EditValue;
            Document currentChungTu = (Document)cbChungTu.GetSelectedDataRow();
            if (currentChungTu != null)
                currentChungTu.DbId = 0;
            List<DigitizingBag> kqTimFull = new List<DigitizingBag>();
            IEnumerable<DigitizingBag> kqTimDB_DigitizingBagName = new List<DigitizingBag>();
            IEnumerable<DigitizingBag> kqTimDB1 = new List<DigitizingBag>();

            IQueryable<DigitizingBag> dsBag = (digitizingBagBindingSource_ForTree.DataSource as IQueryable<DigitizingBag>);

            //luôn luôn tìm nội dung file với lucene
            #region Tim lucene
            String noiDungCanTim = txtNoiDungCanTim.Text.Trim();
            IEnumerable<DigitizingBag> kqTimLucene = new List<DigitizingBag>();
            if (!String.IsNullOrWhiteSpace(noiDungCanTim))
            {
                PSC_ERP_Digitizing.Client.WebReference1.DigitizingService service = new PSC_ERP_Digitizing.Client.WebReference1.DigitizingService();
                List<IndexPackage> kqTim = service.QuickHelper_SearchContent_String(publicKey: _publicKey, token: _token, content: txtNoiDungCanTim.Text.Trim(),maPhanHe:"SH", fileContentInResult: false).ToList<IndexPackage>();
                //trich lay thong tin DocId;
                List<Guid> docIdList = (from o in kqTim select new Guid(o.DocId)).ToList();
                //
                //DigitizingBag_Factory digitizingBagFactory = DigitizingBag_Factory.New();
                kqTimLucene = DigitizingBag_Factory.GetListByIdList(dsBag, docIdList).AsEnumerable();
            }
            int count = kqTimLucene.Count();
            #endregion
            int? maBoPhan = Convert.ToInt32(cbBoPhan.EditValue);
            int? nam = Convert.ToInt32(cbNam.EditValue);
            DocumentTypeEnum documentType = (DocumentTypeEnum)currentChungTu.MaLoaiChungTu;
            Int32? maLoaiChungTu = Convert.ToInt32(cbChungTu.EditValue);
            #region Tim trong DB
            #region tìm theo tiêu đề
            //tim tieu de
            {
                String titleContain = this.txtNoiDungCanTim.Text.Trim();
                if (!String.IsNullOrWhiteSpace(titleContain))
                {
                    String lowerTitleContain = titleContain.Trim().ToLower();

                    kqTimDB_DigitizingBagName = dsBag.Where(o => o.IsFile == true && o.Name.ToLower().Contains(lowerTitleContain));

                }
            }
            #endregion
            //         
            if (timKetHop)
            {
                kqTimDB1 = DigitizingBag_Factory.New().Context.spd_TimFile(nam, maBoPhan, maLoaiChungTu, currentChungTu.DbId) as List<DigitizingBag>;
                //#region tìm kiếm file trong DB
                //if (currentChungTu != null)
                //{

                //    //DigitizingBag_Factory bagFactory = DigitizingBag_Factory.New();
                //    //DocumentTypeEnum documentType = (DocumentTypeEnum)currentChungTu.MaLoaiChungTu;
                //    //Tim trong db

                //    switch (documentType)
                //    {
                //        case DocumentTypeEnum.TatCa:
                //            kqTimDB1 = DigitizingBag_Factory.GetAllFileList_ByYear_MaBoPhan(fullList: dsBag, nam: nam, maBoPhan: maBoPhan);
                //            break;
                //        case DocumentTypeEnum.ChungTuKeToan_PhieuThu:
                //        case DocumentTypeEnum.ChungTuKeToan_PhieuChi:
                //        case DocumentTypeEnum.ChungTuKeToan_BangKe:
                //            {
                //                //lay danh sach file thuoc chungTu
                //                if (currentChungTu.LaChungTuImport)
                //                    //kqTimDB1 = DigitizingBag_Factory.GetListBy_tblChungTuImport_MaChungTu(fullList: dsBag, nam: nam, maBoPhan: maBoPhan, maLoaiChungTu: currentChungTu.MaLoaiChungTu, maChungTu: currentChungTu.DbId);
                //                    kqTimDB1 = DigitizingBag_Factory.New().Context.spd_TimFile(nam, maBoPhan, currentChungTu.MaLoaiChungTu, currentChungTu.DbId, true) as List<DigitizingBag>;
                //                else
                //                    kqTimDB1 = DigitizingBag_Factory.GetListBy_tblChungTu_MaChungTu(fullList: dsBag, nam: nam, maBoPhan: maBoPhan, maLoaiChungTu: currentChungTu.MaLoaiChungTu, maChungTu: currentChungTu.DbId);
                //            }
                //            break;
                //        case DocumentTypeEnum.ChungTuKeToan_PhieuNhap:
                //            kqTimDB1 = DigitizingBag_Factory.GetListBy_tblPhieuNhapXuat_MaPhieuNhapXuat(fullList: dsBag, nam: nam, maBoPhan: maBoPhan, laNhap: true, maPhieuNhapXuat: currentChungTu.DbId);
                //            break;
                //        case DocumentTypeEnum.ChungTuKeToan_PhieuXuat:
                //            kqTimDB1 = DigitizingBag_Factory.GetListBy_tblPhieuNhapXuat_MaPhieuNhapXuat(fullList: dsBag, nam: nam, maBoPhan: maBoPhan, laNhap: false, maPhieuNhapXuat: currentChungTu.DbId);
                //            break;
                //        case DocumentTypeEnum.HopDong_NoiBo:
                //            kqTimDB1 = DigitizingBag_Factory.GetListBy_tblHopDong_MaHopDong(fullList: dsBag, nam: nam, maBoPhan: maBoPhan, hdBenNgoai: false, maHopDong: currentChungTu.DbId);
                //            break;
                //        case DocumentTypeEnum.HopDong_BenNgoai:
                //            kqTimDB1 = DigitizingBag_Factory.GetListBy_tblHopDong_MaHopDong(fullList: dsBag, nam: nam, maBoPhan: maBoPhan, hdBenNgoai: true, maHopDong: currentChungTu.DbId);
                //            break;
                //        default:
                //            break;
                //    }
                //    //
                //}

                //#endregion

                //kqTimFull = kqTimDB1.ToList();

                #region lọc lại kết quả
                foreach (var item in kqTimLucene)
                {
                    if (kqTimDB1.Any(o => o.BagId == item.BagId))
                    {
                        kqTimFull.Add(item);
                    }
                }

                //gan them ket qua tim tieu de
                foreach (var item in kqTimDB_DigitizingBagName)
                {
                    if (!kqTimFull.Exists(o => o.BagId == item.BagId) && kqTimDB1.Any(o => o.BagId == item.BagId))
                    {
                        kqTimFull.Add(item);
                    }
                }
            }
            //end if
            else
            {
                kqTimFull = kqTimLucene.ToList();
                //gan them ket qua tim tieu de
                foreach (var item in kqTimDB_DigitizingBagName)
                {
                    if (!kqTimFull.Exists(o => o.BagId == item.BagId))
                    {
                        kqTimFull.Add(item);
                    }
                }
            }
                #endregion
            #endregion

            ////////////////////////
            digitizingBagBindingSource_ForGrid.DataSource = kqTimFull;

            return kqTimFull;
        } 
        #endregion


        #region HighLight Text
        //HighLight RichEditTextbox
        private void ToMauChu()
        {

            string noidungcantim = txtNoiDungCanTim.Text.Trim().Replace("*", "").Replace("\"", "");
            DevExpress.XtraRichEdit.API.Native.DocumentRange[] finds = richEditControl_ForTxt.Document.FindAll(noidungcantim, DevExpress.XtraRichEdit.API.Native.SearchOptions.WholeWord);

            foreach (var find in finds)
            {
                var doc = find.BeginUpdateDocument();
                var charprop = doc.BeginUpdateCharacters(find);
                charprop.BackColor = System.Drawing.Color.Yellow;
                doc.EndUpdateCharacters(charprop);
                find.EndUpdateDocument(doc);
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

        private DigitizingBag GetObject_AtNode(TreeListNode node)
        {
            return treeListBag.GetDataRecordByNode(node) as DigitizingBag;            
        }


        private Boolean SaveTree()
        {
            this.txtBlackHole.Focus();
            try
            {
                _treeBagFactory.SaveChangesWithoutTrackingLog();
                //ẩn nút save
                this.btnSaveTree.Visible = false;
                return true;
            }
            catch (Exception ex)
            {
                DialogUtil.ShowNotSaveSuccessful("Không lưu được");
                return false;
            }
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
            dsChungTu = TimChungTu(nam, maPhongBan, (DocumentTypeEnum)maLoaiChungTu, maChungTu);
            chungTuBindingSource.DataSource = dsChungTu;
            //chung tu thanh 0
            cbChungTu.EditValue = Guid.Empty;
        }
        private void DownLoadAndPreview(DigitizingBag currentBag)
        {
            using (DialogUtil.Wait(this))
            {
                CloseDocument();
                if (Object.ReferenceEquals(this.xtraTabControl1.SelectedTabPage, this.tabPdfNguon))
                {
                    this.DownLoadPdfAndPreview(currentBag);
                }
                else if (Object.ReferenceEquals(this.xtraTabControl1.SelectedTabPage, this.tabTxt))
                {
                    this.DownLoadTextAndPreview(currentBag);
                }
                else if (Object.ReferenceEquals(this.xtraTabControl1.SelectedTabPage, this.tabWord))
                {
                    this.DownLoadWordAndPreview(currentBag);
                }
                else if (Object.ReferenceEquals(this.xtraTabControl1.SelectedTabPage, this.tabExcel))
                {
                    this.DownLoadExcelAndPreview(currentBag);
                }
            }
        }
        private void DownLoadPdfAndPreview(DigitizingBag currentBag)
        {
            //Task<object> pdfTask = TaskUtil.InvokeCrossThread(this, () =>
            //{
            byte[] data = null;
            try
            {
                //lay stream file nguon dua len pdf viewer
                PSC_ERP_Digitizing.Client.WebReference1.DigitizingService service = new PSC_ERP_Digitizing.Client.WebReference1.DigitizingService();
                String extension = Path.GetExtension(currentBag.UploadFromFilePath);
                data = service.QuickHelper_DownloadSourceFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension,"SH");
                this.pdfViewer1.LoadDocument(new MemoryStream(data));
            }
            catch (Exception ex)
            {
                //this.pdfViewer1.CloseDocument();
            }
            //return data;
            //});
        }

        private void DownLoadWordAndPreview(DigitizingBag currentBag)
        {
            //Task<object> pdfTask = TaskUtil.InvokeCrossThread(this, () =>
            //{
            byte[] data = null;
            try
            {
                //lay stream file docx dua len doc viewer
                PSC_ERP_Digitizing.Client.WebReference1.DigitizingService service = new PSC_ERP_Digitizing.Client.WebReference1.DigitizingService();
                String extension = ".doc";
                data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension);
                //string tenfile = currentBag.BagId.ToString() + extension;
                //FileStream fs = new FileStream();
                // Byte[] b = new Byte[1024];
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
                this.richEditControl1.LoadDocument(new MemoryStream(data), DevExpress.XtraRichEdit.DocumentFormat.Doc);
                //richEditControl1.WordMLText = vanban;
            }
            catch (Exception ex)
            {

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
                PSC_ERP_Digitizing.Client.WebReference1.DigitizingService service = new PSC_ERP_Digitizing.Client.WebReference1.DigitizingService();
                String extension = ".txt";
                data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension);
                this.richEditControl_ForTxt.LoadDocument(new MemoryStream(data), DevExpress.XtraRichEdit.DocumentFormat.PlainText);
                ToMauChu();
            }
            catch (Exception ex)
            {

            }
            //return data;
            //});
        }

        private void DownLoadExcelAndPreview(DigitizingBag currentBag)
        {
            //Task<object> pdfTask = TaskUtil.InvokeCrossThread(this, () =>
            //{
            byte[] data = null;
            try
            {
                //lay stream file docx dua len doc viewer
                PSC_ERP_Digitizing.Client.WebReference1.DigitizingService service = new PSC_ERP_Digitizing.Client.WebReference1.DigitizingService();
                String extension = ".xls";
                data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension);
                this.spreadsheetControl1.LoadDocument(new MemoryStream(data), DevExpress.Spreadsheet.DocumentFormat.Xls);
            }
            catch (Exception ex)
            {
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

        public static void ActiveChungTuCanThiet(List<Document> dsChungTu, DocumentTypeEnum docTypeEnum_ForQuickLoad, Boolean laChungTuImport_ForQuickLoad, Int64? maChungTu_ForQuickLoad, GridLookUpEdit cbChungTu)
        {
            //List<Document> dsChungTu = (chungTuBindingSource.DataSource as List<Document>);

            if (dsChungTu != null && dsChungTu.Count > 1)
            {
                Document chungTuFind = null;
                int maLoaiChungTu = Convert.ToInt32(docTypeEnum_ForQuickLoad);
                //hiển thị lại chứng từ đã chọn
                if (docTypeEnum_ForQuickLoad == DocumentTypeEnum.ChungTuKeToan_PhieuThu
                    || docTypeEnum_ForQuickLoad == DocumentTypeEnum.ChungTuKeToan_PhieuChi
                    || docTypeEnum_ForQuickLoad == DocumentTypeEnum.ChungTuKeToan_BangKe)
                {
                    if (laChungTuImport_ForQuickLoad)
                    {
                        chungTuFind = dsChungTu.SingleOrDefault(x => x.LaChungTuImport && x.MaLoaiChungTu == maLoaiChungTu && x.DbId == maChungTu_ForQuickLoad);
                    }
                    else
                    {
                        chungTuFind = dsChungTu.SingleOrDefault(x => !x.LaChungTuImport && x.MaLoaiChungTu == maLoaiChungTu && x.DbId == maChungTu_ForQuickLoad);
                    }

                }
                else if (docTypeEnum_ForQuickLoad == DocumentTypeEnum.ChungTuKeToan_PhieuNhap
                    || docTypeEnum_ForQuickLoad == DocumentTypeEnum.ChungTuKeToan_PhieuXuat)
                {
                    chungTuFind = dsChungTu.SingleOrDefault(x => x.MaLoaiChungTu == maLoaiChungTu && x.DbId == maChungTu_ForQuickLoad);
                }
                else if (docTypeEnum_ForQuickLoad == DocumentTypeEnum.HopDong_NoiBo
                    || docTypeEnum_ForQuickLoad == DocumentTypeEnum.HopDong_BenNgoai)
                {
                    chungTuFind = dsChungTu.SingleOrDefault(x => x.MaLoaiChungTu == maLoaiChungTu && x.DbId == maChungTu_ForQuickLoad);
                }
                else
                {//lấy chứng từ không chọn
                    chungTuFind = dsChungTu.SingleOrDefault(x => x.Id == Guid.Empty);
                }
                if (chungTuFind != null)
                    //active den chung tu thuoc fileBag
                    cbChungTu.EditValue = chungTuFind.Id;
                else
                    cbChungTu.EditValue = Guid.Empty;

            }
        }

        private void frmDigitizing_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            this.Shown += (object senderz, EventArgs ez) =>
            {
                TaskUtil.InvokeCrossThread(this, () =>
                {
                    using (DialogUtil.Wait(this))
                    {
                        _daLoadFormXong = false;


                        //thiet lap
                        //cài đặt double click event cho grid view 
                        GridUtil.DoubleClickHelper.Setup(this.gridViewDanhSachFile, (object senderz1, EventArgs ez1) =>
                        {
                            //xem lại chứng từ
                            if (_daLoadFormXong)
                            {
                                GridView view = senderz1 as GridView;
                                DigitizingBag currentBag = view.GetFocusedRow() as DigitizingBag;
                                if (currentBag != null)
                                {
                                    _currentBagForPreview = currentBag;
                                    TreeListNode node = treeListBag.FindNodeByKeyID(currentBag.BagId);
                                    //node.ParentNode.ExpandAll();
                                    treeListBag.FocusedNode = node;
                                    DownLoadAndPreview(currentBag);
                                }
                            }

                        });
                        _token = PSC_ERPNew.Main.PhanHe.DIGITIZING.Helper.MakeToken(publicKey: _publicKey, secretKey: "pscvietnam@hoasua");
                        //năm
                        {
                            List<Year> namList = new List<Year>();
                            namList.Add(new Year(0, "<<Tất cả>>"));
                            int namDauTien = 1998;
                            int namHienTai = app_users_Factory.New().SystemDate.Year;
                            for (int i = namDauTien++; i <= namHienTai; i++)
                                namList.Add(new Year(i));
                            yearBindingSource.DataSource = namList;
                            //set mặc định năm
                            cbNam.EditValue = 0;
                        }
                        //lay danh sach bo phan
                        List<tblnsBoPhan> boPhanList = BoPhan_Factory.New().GetAll().ToList();
                        boPhanList.Insert(0, new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" });
                        tblnsBoPhanBindingSource.DataSource = boPhanList;
                        //lay danh sach loai chung tu
                        documentTypeBindingSource.DataSource = DocumentType.DocumentTypeList;
                        this.XuLyChungTu(_maChungTu_ForQuickLoad);
                        //TaskUtil.InvokeCrossThread(this, () => { this.XuLyChungTu(); });
                        //du du lieu len cay
                        DocDuLieuVaDuaLenCay();
                        //TaskUtil.InvokeCrossThread(this, () => { DocDuLieuVaDuaLenCay(); });


                        if (_maChungTu_ForQuickLoad != null)
                        {
                            cbNam.Enabled = false;
                            cbBoPhan.Enabled = false;
                            cbLoaiChungTu.Enabled = false;
                            //
                            //cbChungTu.EditValue = _maChungTuForPreviewFile;
                            cbChungTu.Enabled = false;

                            //
                            btnFind.Visible = false;
                            btnTimKetHop.Text = "Tìm";


                            #region Active chung tu
                            ActiveChungTuCanThiet((chungTuBindingSource.DataSource as List<Document>), _docTypeEnum_ForQuickLoad, _laChungTuImport_ForQuickLoad, _maChungTu_ForQuickLoad, cbChungTu);
                            #endregion

                        }

                        _daLoadFormXong = true;
                    }
                });

            };
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
        {//Bo phan thay doi se lay lai danh sach chung tu theo bo phan va loai chung tu
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
        {//loai chung tu thay doi se lay lai danh sach chung tu theo bo phan va loai chung tu
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



        private void cbChungTu_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadFormXong)
            {
                TimFileBag(timNoiDungFile: false, timKetHop: true);
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            TaoCauTrucCay();
            if (TimFileBag(timNoiDungFile: true, timKetHop: false).Count() == 0)
            {
                DialogUtil.ShowInfo("Không tìm thấy");
            }

        }

        private void btnTimKetHop_Click(object sender, EventArgs e)
        {
            if (TimFileBag(timNoiDungFile: false, timKetHop: true).Count() == 0)
            {
                DialogUtil.ShowInfo("Không tìm thấy");
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

        private void treeListBag_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            var obj = treeListBag.GetDataRecordByNode(e.Node) as DigitizingBag;
            
            //nếu ko phải file
            if (!(obj.IsFile ?? false))
            {
                //e.Node.ExpandAll();
                //clear current for Preview
                _currentBagForPreview = null;
                CloseDocument();
                //spreadsheetControl1.CloseCellEditor(DevExpress.XtraSpreadsheet.CellEditorEnterValueMode.Default);
                //spreadsheetControl1.ActiveWorksheet.Clear(spreadsheetControl1.ActiveWorksheet.GetDataRange());

                TaskUtil.InvokeCrossThread(this, () =>
                {
                    using (DialogUtil.Wait(this))
                    {
                        //fill danh sach file trong node lên lưới

                        //DigitizingBag_Factory factory = DigitizingBag_Factory.New();
                        List<Guid> idFileList = _treeBagFactory.Context.sp_DIGITIZING_DigitizingBag_GetAllFileListByBagId(obj.BagId).Select(x => x ?? Guid.Empty).ToList();
                        //
                        IQueryable<DigitizingBag> dsBag = _treeBagFactory.GetAll(); //(digitizingBagBindingSource_ForTree.DataSource as IQueryable<DigitizingBag>);

                        //List<DigitizingBag> dsBag = (digitizingBagBindingSource_ForTree.DataSource as List<DigitizingBag>);

                        //
                        IQueryable<DigitizingBag> dsFile = DigitizingBag_Factory.GetListByIdList(dsBag, idFileList);
                        digitizingBagBindingSource_ForGrid.DataSource = dsFile;

                    }
                });
            }

        }


        private void treeListBag_DoubleClick(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node != null)
            {
                var obj = treeListBag.GetDataRecordByNode(hi.Node) as DigitizingBag;
                if ((obj.FileUploadCompleted ?? false) == true)
                {
                    _currentBagForPreview = obj;
                    this.DownLoadAndPreview(obj);
                }
            }

        }


        private void frmDigitizing_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_treeBagFactory.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    if (false == this.SaveTree())
                    {
                        DialogUtil.ShowNotSaveSuccessful();
                        e.Cancel = true;
                    }
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

            String extension = ".pdf";
            DownloadAndSaveToFile(extension, "Pdf file|*.pdf", (DigitizingService service, String filePath) =>
            {
                //tải về
                byte[] data = null;
                if (service.QuickHelper_CheckExistSourceFile_ByFileName(_publicKey, _token, _currentBagForPreview.BagId.ToString() + extension))
                {
                    data = service.QuickHelper_DownloadSourceFile_ByFileName(_publicKey, _token, _currentBagForPreview.BagId.ToString() + extension,"SH");
                }
                return data;
            });
        }
        private void btnDownloadWordFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String extension = ".doc";
            DownloadAndSaveToFile(extension, "Word 2003 file|*.doc", (DigitizingService service, String filePath) =>
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
        private void btnDownLoadExcelFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String extension = ".xls";
            DownloadAndSaveToFile(extension, "Excel 2003 file|*.xls", (DigitizingService service, String filePath) =>
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
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.DefaultExt = defaultExtension;
                    dlg.Filter = filter;
                    dlg.FilterIndex = 0;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {

                        try
                        {
                            using (DialogUtil.Wait(this))
                            {
                                PSC_ERP_Digitizing.Client.WebReference1.DigitizingService service = new PSC_ERP_Digitizing.Client.WebReference1.DigitizingService();
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
                                    System.IO.FileStream fs = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
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



        private void treeListBag_DragOver(object sender, DragEventArgs e)
        {
            TreeList tree = sender as TreeList;
            Point p = tree.PointToClient(new Point(e.X, e.Y));
            TreeListHitInfo hitInfo = tree.CalcHitInfo(p);
            tree.FocusedNode = hitInfo.Node;
            DigitizingBag dragBag = tree.GetDataRecordByNode(hitInfo.Node) as DigitizingBag;

            if (e.Data.GetDataPresent(typeof(TreeListNode)) && dragBag != null && ((_maChungTu_ForQuickLoad ?? 0) == 0 || dragBag.IsFile == true))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }
        private void treeListBag_DragDrop(object sender, DragEventArgs e)
        {
            TreeList tree = sender as TreeList;
            ////
            Point p = tree.PointToClient(new Point(e.X, e.Y));
            TreeListHitInfo hitInfo = tree.CalcHitInfo(p);
            //
            if (e.Data.GetDataPresent(typeof(TreeListNode)))//drag menu
            {
                TreeListNode node = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;

                DigitizingBag dragBag = tree.GetDataRecordByNode(node) as DigitizingBag;
                DigitizingBag destinationBag = tree.GetDataRecordByNode(hitInfo.Node) as DigitizingBag;
                if (destinationBag != null)
                {

                    if (!(destinationBag.IsFile ?? false))//dest thu muc
                        e.Effect = DragDropEffects.Move;
                    else e.Effect = DragDropEffects.None;

                    if (e.Effect == DragDropEffects.Move)
                    {
                        //nen su dung task cho nay.
                        TaskUtil.InvokeCrossThread(this, () =>
                        {
                            Thread.Sleep(100);
                            _treeBagFactory.SaveChangesWithoutTrackingLog();
                        });

                    }
                }
                else
                    e.Effect = DragDropEffects.None;
            }



        }

        private void treeListBag_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            DigitizingBag bag = this.treeListBag.GetDataRecordByNode(e.Node) as DigitizingBag;
            if (bag != null)
            {
                if (!(bag.IsFile ?? false))//thu muc
                {
                    e.NodeImageIndex = 0;
                }
                else//file
                {
                    e.NodeImageIndex = 1;
                }
            }
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

        private void gridViewDanhSachFile_RowStyle(object sender, RowStyleEventArgs e)
        {
            //////////////HighLight Row GridView
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0 && txtNoiDungCanTim.Text != "")
            //{
            //    string name = View.GetRowCellDisplayText(e.RowHandle, View.Columns[0]).ToLower();
            //    // string name = View.GetRowCellValue(e.RowHandle, View.Columns["col_TenTaiLieu"]);
            //    if (name.Contains(txtNoiDungCanTim.Text.Trim().ToLower()))
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
                //string noiDungCanTim_Lower = txtNoiDungCanTim.Text.Trim().ToLower();
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


        #region Tạo cấu trúc cây - đổ dữ liệu lên cây
        public void TaoCauTrucCay()//chỉ chạy lần đầu tiên để đổ liệu vào bảng DigitizingBag tạo cấu trúc cây
        {
            var factory = DigitizingBag_Factory.New();
            //
            if (factory.ObjectSet.Count() == 0)
            {
                using (DialogUtil.Wait(this, "vui lòng đợi...", "Đang tạo cấu trúc cây"))
                {
                    //đổ bộ phận
                    List<tblnsBoPhan> boPhanList = BoPhan_Factory.New().GetAll().ToList();
                    var root = boPhanList.SingleOrDefault(x => x.MaBoPhan == 33);

                    DigitizingBag digiRoot = factory.CreateManagedObject();
                    digiRoot.BagId = Guid.Empty;
                    digiRoot.MaBoPhan = root.MaBoPhan;
                    digiRoot.Name = root.TenBoPhan;
                    digiRoot.IsFile = false;
                    digiRoot.CapDoCay = 0;
                    foreach (tblnsBoPhan bophan in boPhanList)
                    {

                        if (bophan.MaBoPhan != root.MaBoPhan && bophan.MaLoaiBoPhan == 2)
                        {
                            DigitizingBag obj_BoPhan = factory.CreateManagedObject();
                            obj_BoPhan.BagId = Guid.NewGuid();
                            obj_BoPhan.MaBoPhan = bophan.MaBoPhan;
                            obj_BoPhan.Name = bophan.TenBoPhan;
                            obj_BoPhan.IsFile = false;
                            obj_BoPhan.ParentBagId = digiRoot.BagId;
                            obj_BoPhan.CapDoCay = 1;
                            //đổ loại chứng từ
                            foreach (var docType in DocumentType.DocumentTypeList)
                            {
                                if (docType.Id != 0)
                                {
                                    DigitizingBag obj_Loai = factory.CreateManagedObject();
                                    obj_Loai.BagId = Guid.NewGuid();
                                    obj_Loai.Name = docType.Name;
                                    obj_Loai.MaLoaiChungTu = docType.Id;
                                    obj_Loai.CapDoCay = 2;
                                    obj_Loai.IsFile = false;

                                    obj_Loai.MaBoPhan = bophan.MaBoPhan;
                                    //trường hợp file không có trong databse
                                    if( docType.Id == 1003 || docType.Id ==1004 //hợp đồng
                                        || docType.Id == 2005 || docType.Id== 2006|| docType.Id==2007)//văn bản
                                    {
                                        obj_Loai.IsDatabase = false;
                                    }
                                     //trường hợp file có trong database
                                    else//chứng từ
                                    {
                                        obj_Loai.IsDatabase = true;
                                    }
                                       

                                    obj_Loai.DigitizingBag2 = obj_BoPhan;
                                    //đổ năm
                                    for (int i = 1998; i <= (DateTime.Now.Year + 5); i++)
                                    {

                                        DigitizingBag obj_Nam = factory.CreateManagedObject();
                                        obj_Nam.BagId = Guid.NewGuid();
                                        obj_Nam.Name = "Năm " + i;

                                        obj_Nam.MaBoPhan = bophan.MaBoPhan;
                                        obj_Nam.MaLoaiChungTu = docType.Id;
                                        obj_Nam.CapDoCay = 3;
                                        obj_Nam.IsDatabase = obj_Loai.IsDatabase;
                                        obj_Nam.IsFile = false;

                                        obj_Nam.FolderYear = i;
                                        obj_Nam.DigitizingBag2 = obj_Loai;
                                    }
                                }
                            }

                            //quyết định
                        //    DigitizingBag obj_QuyetDinh = factory.CreateManagedObject();
                        //    obj_QuyetDinh.BagId = Guid.NewGuid();
                        //    obj_QuyetDinh.Name = "Quyết Định";

                        //    obj_QuyetDinh.CapDoCay = 2;
                        //    obj_QuyetDinh.MaBoPhan = obj_BoPhan.MaBoPhan;
                        //    obj_QuyetDinh.MaLoaiChungTu = 2005;
                        //    obj_QuyetDinh.IsDatabase = false;
                        //    obj_QuyetDinh.IsFile = false;
                        //    //obj_BoPhan.DigitizingBag1.Add(obj_Loai);
                        //    obj_QuyetDinh.DigitizingBag2 = obj_BoPhan;
                        //    //đổ năm
                        //    for (int i = 1998; i <= (DateTime.Now.Year + 5); i++)
                        //    {

                        //        DigitizingBag obj_Nam = factory.CreateManagedObject();
                        //        obj_Nam.BagId = Guid.NewGuid();
                        //        obj_Nam.Name = "Năm " + i;
                        //        obj_Nam.FolderYear = i;
                        //        obj_Nam.IsDatabase = obj_QuyetDinh.IsDatabase;
                        //        obj_Nam.CapDoCay = 3;
                        //        obj_Nam.IsFile = false;
                        //        obj_Nam.MaBoPhan = obj_BoPhan.MaBoPhan;
                        //        obj_Nam.MaLoaiChungTu = obj_QuyetDinh.MaLoaiChungTu;
                        //        obj_Nam.DigitizingBag2 = obj_QuyetDinh;
                        //    }

                        //    //thông báo
                        //    DigitizingBag obj_ThongBao = factory.CreateManagedObject();
                        //    obj_ThongBao.BagId = Guid.NewGuid();
                        //    obj_ThongBao.Name = "Thông Báo";

                        //    obj_ThongBao.MaBoPhan = obj_BoPhan.MaBoPhan;
                        //    obj_ThongBao.CapDoCay = 2;
                        //    obj_ThongBao.MaLoaiChungTu = 2006;
                        //    obj_ThongBao.IsDatabase = false;
                        //    obj_ThongBao.IsFile = false;
                           
                        //    //obj_BoPhan.DigitizingBag1.Add(obj_Loai);
                        //    obj_ThongBao.DigitizingBag2 = obj_BoPhan;
                        //    //đổ năm
                        //    for (int i = 1998; i <= (DateTime.Now.Year + 5); i++)
                        //    {

                        //        DigitizingBag obj_Nam = factory.CreateManagedObject();
                        //        obj_Nam.BagId = Guid.NewGuid();
                        //        obj_Nam.Name = "Năm " + i;
                        //        obj_Nam.CapDoCay = 3;
                        //        obj_Nam.IsFile = false;
                        //        obj_Nam.IsDatabase = obj_ThongBao.IsDatabase;
                        //        obj_Nam.MaLoaiChungTu = obj_ThongBao.MaLoaiChungTu;                                
                        //        obj_Nam.MaBoPhan = obj_BoPhan.MaBoPhan;
                        //        obj_Nam.FolderYear = i;
                        //        obj_Nam.DigitizingBag2 = obj_ThongBao;
                        //    }

                        //    //chuyên mục khác
                        //    DigitizingBag obj_ChuyenMucKhac = factory.CreateManagedObject();
                        //    obj_ChuyenMucKhac.BagId = Guid.NewGuid();
                        //    obj_ChuyenMucKhac.Name = "Chuyên Mục Khác";
                            
                        //    obj_ChuyenMucKhac.MaLoaiChungTu = 2007;
                        //    obj_ChuyenMucKhac.MaBoPhan = obj_BoPhan.MaBoPhan;
                        //    obj_ChuyenMucKhac.CapDoCay = 2;
                        //    obj_ChuyenMucKhac.IsDatabase = false;
                        //    obj_ChuyenMucKhac.IsFile = false;
                        //    //obj_BoPhan.DigitizingBag1.Add(obj_Loai);
                        //    obj_ChuyenMucKhac.DigitizingBag2 = obj_BoPhan;
                        //    //đổ năm
                        //    for (int i = 1998; i <= (DateTime.Now.Year + 5); i++)
                        //    {

                        //        DigitizingBag obj_Nam = factory.CreateManagedObject();
                        //        obj_Nam.BagId = Guid.NewGuid();
                        //        obj_Nam.Name = "Năm " + i;
                        //        obj_Nam.FolderYear = i;
                        //        obj_Nam.IsFile = false;
                        //        obj_Nam.MaBoPhan = obj_BoPhan.MaBoPhan;
                        //        obj_Nam.IsDatabase = obj_ChuyenMucKhac.IsDatabase;
                        //        obj_Nam.MaLoaiChungTu = obj_ChuyenMucKhac.MaLoaiChungTu;
                        //        obj_Nam.CapDoCay = 3;
                             
                        //        obj_Nam.DigitizingBag2 = obj_ChuyenMucKhac;
                        //    }
                        }

                    }
                    factory.SaveChangesWithoutTrackingLog();
                    btnReloadTree.PerformClick();
                }
            }

        } 
        #endregion

        private void treeListBag_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            //var obj = treeListBag.GetDataRecordByNode(e.Node) as DigitizingBag;
            //chỉnh lại màu của node được selecte
            if (e.Node.Selected)
            {
                e.Appearance.BackColor = Color.LightBlue;//Color.LightPink;
                e.Appearance.ForeColor = Color.DarkViolet;//Color.DarkGreen;
            }
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }


    }
}
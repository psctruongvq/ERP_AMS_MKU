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
using PSC_ERP_Digitizing.Client.Predefined;
using PSC_ERP_Digitizing.Client.Model;
using PSC_ERP_Digitizing.Client.WebReference1;
using System.Threading.Tasks;
using DevExpress.XtraTreeList.Nodes;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using System.Threading;
using PSC_ERP_Common.Extension;

namespace PSC_ERP_Digitizing.Client.UI
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
        String _publicKey = "gi cung duoc";
        String _token = null;
        Boolean _daLoadFormXong = false;
        //List<ChungTu> _chungTuList = null;
        DigitizingBag_Factory _treeBagFactory = DigitizingBag_Factory.New();

        DigitizingBag _currentBagForPreview = null;
        public frmDigitizing()
        {
            InitializeComponent();
        }



        private void DocDuLieuVaDuaLenCay()
        {
            //tạo mới factory
            _treeBagFactory = DigitizingBag_Factory.New();
            IQueryable<DigitizingBag> treeBag = _treeBagFactory.GetAll();
            //gắn binding source
            digitizingBagBindingSource_ForTree.DataSource = treeBag;
            //treeListBag.DataSource = digitizingBagBindingSource_ForTree;
        }


        public static List<ChungTu> TimChungTuTheoBoPhanVaLoaiChungTu(int maBoPhan, DocumentTypeEnum documentType)
        {
            Int32 maLoaiChungTu = Convert.ToInt32(documentType);
            IEnumerable<ChungTu> listBangKe_PhieuThu_PhieuChi = new List<ChungTu>();
            IEnumerable<ChungTu> listChungTu_PhieuNhap = new List<ChungTu>();
            IEnumerable<ChungTu> listChungTu_PhieuXuat = new List<ChungTu>();
            IEnumerable<ChungTu> listHopDong_NoiBo = new List<ChungTu>();
            IEnumerable<ChungTu> listHopDong_BenNgoai = new List<ChungTu>();

            IEnumerable<ChungTu> listChungTuFull = new List<ChungTu>();
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
                IQueryable<tblChungTu> tmp1 = chungTuFactory.GetListBy_MaLoaiChungTu_MaBoPhan(maLoaiChungTu, maBoPhan);
                if (tmp1.Any() != false)
                {
                    IEnumerable<ChungTu> tmp1_1 = tmp1.Select(x => new ChungTu()
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
                IQueryable<tblChungTuImport> tmp2 = chungTuImportFactory.GetListBy_MaLoaiChungTu_MaBoPhan(maLoaiChungTu, maBoPhan);
                if (tmp1.Any() != false)
                {
                    IEnumerable<ChungTu> tmp2_1 = tmp2.Select(x => new ChungTu()
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
                if (documentType == DocumentTypeEnum.ChungTuKeToan_PhieuNhap)
                {
                    IQueryable<tblPhieuNhapXuat> tmpPhieuNhap = phieuNhapXuatFactory.GetListPhieuNhapBy_MaBoPhan(maBoPhan);
                    if (tmpPhieuNhap.Any() != false)
                    {
                        listChungTu_PhieuNhap = tmpPhieuNhap.Select(x => new ChungTu()
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
                if (documentType == DocumentTypeEnum.ChungTuKeToan_PhieuXuat)
                {
                    IQueryable<tblPhieuNhapXuat> tmpPhieuXuat = phieuNhapXuatFactory.GetListPhieuXuatBy_MaBoPhan(maBoPhan);
                    if (tmpPhieuXuat.Any() != false)
                    {
                        listChungTu_PhieuXuat = tmpPhieuXuat.Select(x => new ChungTu()
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
                if (documentType == DocumentTypeEnum.HopDong_NoiBo)
                {
                    IQueryable<tblHopDongMuaBan> tmpHopDongNoiBo = hopDongMuaBanFactory.GetListHDNoiBoBy_MaBoPhan(maBoPhan);
                    if (tmpHopDongNoiBo.Any() != false)
                    {
                        listHopDong_NoiBo = tmpHopDongNoiBo.Select(x => new ChungTu()
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
                if (documentType == DocumentTypeEnum.HopDong_BenNgoai)
                {
                    IQueryable<tblHopDongMuaBan> tmpHopDongBenNgoai = hopDongMuaBanFactory.GetListHDBenNgoaiBy_MaBoPhan(maBoPhan);
                    if (tmpHopDongBenNgoai.Any() != false)
                    {
                        listHopDong_BenNgoai = tmpHopDongBenNgoai.Select(x => new ChungTu()
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

            List<ChungTu> result = listChungTuFull.ToList();
            result.Insert(0, new ChungTu { Id = Guid.Empty, SoChungTu = "<<Tất cả>>", MaLoaiChungTu = -1 });
            return result;
        }
        //private void 

        private void TimFileBag(Boolean timNoiDungFile, Boolean timKetHop, Boolean timThemTieuDe)
        {
            //int maLoaiChungTuFromDB_BangKe =16
            //lay danh sach file thuoc chung tu
            //Guid id = (Guid)cbChungTu.EditValue;
            ChungTu currentChungTu = (ChungTu)cbChungTu.GetSelectedDataRow();
            List<DigitizingBag> kqTimFull = new List<DigitizingBag>();
            IEnumerable<DigitizingBag> kqTimDB_DigitizingBagName = new List<DigitizingBag>();
            IEnumerable<DigitizingBag> kqTimDB1 = new List<DigitizingBag>();

            //luôn luôn tìm nội dung file với lucene
            #region Tim lucene
            String noiDungCanTim = txtNoiDungCanTim.Text.Trim();
            IEnumerable<DigitizingBag> kqTimLucene = new List<DigitizingBag>();
            if (!String.IsNullOrWhiteSpace(noiDungCanTim))
            {
                WebReference1.DigitizingService service = new WebReference1.DigitizingService();
                List<IndexPackage> kqTim = service.QuickHelper_SearchContent_String(publicKey: _publicKey, token: _token, content: txtNoiDungCanTim.Text.Trim(), fileContentInResult: false).ToList<IndexPackage>();
                //trich lay thong tin DocId;
                List<Guid> docIdList = (from o in kqTim select new Guid(o.DocId)).ToList();
                //
                DigitizingBag_Factory digitizingBagFactory = DigitizingBag_Factory.New();
                kqTimLucene = digitizingBagFactory.GetListByIdList(docIdList).AsEnumerable();
            }
            #endregion
            #region Tim trong DB
            //
            if (timThemTieuDe)
            {
                DigitizingBag_Factory bagFactory = DigitizingBag_Factory.New();
                String contain = this.txtNoiDungCanTim.Text.Trim();
                kqTimDB_DigitizingBagName = bagFactory.FindFileBag_ByTitleContain(contain);

            }
            if (timKetHop)
            {
                if (currentChungTu != null)
                {
                    DigitizingBag_Factory bagFactory = DigitizingBag_Factory.New();
                    DocumentTypeEnum documentType = (DocumentTypeEnum)currentChungTu.MaLoaiChungTu;
                    //Tim trong db

                    switch (documentType)
                    {
                        case DocumentTypeEnum.TatCa:
                            kqTimDB1 = bagFactory.GetAllFileList();
                            break;
                        case DocumentTypeEnum.ChungTuKeToan_PhieuThu:
                        case DocumentTypeEnum.ChungTuKeToan_PhieuChi:
                        case DocumentTypeEnum.ChungTuKeToan_BangKe:
                            {
                                //lay danh sach file thuoc chungTu
                                if (currentChungTu.LaChungTuImport)
                                    kqTimDB1 = bagFactory.GetListBy_tblChungTuImport_MaChungTu(currentChungTu.MaLoaiChungTu, currentChungTu.DbId);
                                else
                                    kqTimDB1 = bagFactory.GetListBy_tblChungTu_MaChungTu(currentChungTu.MaLoaiChungTu, currentChungTu.DbId);
                            }
                            break;
                        case DocumentTypeEnum.ChungTuKeToan_PhieuNhap:
                            kqTimDB1 = bagFactory.GetListBy_tblPhieuNhapXuat_MaPhieuNhapXuat(laNhap: true, maPhieuNhapXuat: currentChungTu.DbId);
                            break;
                        case DocumentTypeEnum.ChungTuKeToan_PhieuXuat:
                            kqTimDB1 = bagFactory.GetListBy_tblPhieuNhapXuat_MaPhieuNhapXuat(laNhap: false, maPhieuNhapXuat: currentChungTu.DbId);
                            break;
                        case DocumentTypeEnum.HopDong_NoiBo:
                            kqTimDB1 = bagFactory.GetListBy_tblHopDong_MaHopDong(hdNoiBo: true, maHopDong: currentChungTu.DbId);
                            break;
                        case DocumentTypeEnum.HopDong_BenNgoai:
                            kqTimDB1 = bagFactory.GetListBy_tblHopDong_MaHopDong(hdNoiBo: false, maHopDong: currentChungTu.DbId);
                            break;
                        default:
                            break;
                    }
                    //
                }

            }
            #endregion


            //lua chon ket quả tìm

            if (timKetHop)
            {//tìm kết hợp
                if (kqTimLucene.Count() > 0)
                    foreach (var item in kqTimLucene)
                    {
                        if (kqTimDB1.Any(x => (x.BagId == item.BagId)))
                        {
                            kqTimFull.Add(item);
                        }
                    }
                else
                {
                    if (timThemTieuDe)
                        kqTimFull = kqTimDB1.Concat(kqTimDB_DigitizingBagName).ToList();
                    else
                        kqTimFull = kqTimDB1.ToList();
                }
            }
            else
            {//lay ket qua tim lucene
                if (timThemTieuDe)
                    kqTimFull = kqTimLucene.Concat(kqTimDB_DigitizingBagName).ToList();
                else
                    kqTimFull = kqTimLucene.ToList();
            }

            ////////////////////////
            digitizingBagBindingSource_ForGrid.DataSource = kqTimFull;
        }

        private DigitizingBag GetObject_AtNode(TreeListNode node)
        {
            return treeListBag.GetDataRecordByNode(node) as DigitizingBag;
        }
        private void ThemLenCay(Boolean themThuMuc = false, Boolean themFile = false)
        {
            TreeListNode focusedNode = treeListBag.FocusedNode;//C

            DigitizingBag currentObject = GetObject_AtNode(focusedNode);//C


            DigitizingBag newObj = _treeBagFactory.CreateAloneObject();

            newObj.CreatedUser = BasicInfo.User.UserID;//PSC_ERP_Global.Main.UserID;
            newObj.MaBoPhan = BasicInfo.User.MaBoPhan;//PSC_ERP_Global.Main.MaBoPhanCuaUser;

            if (currentObject != null)
            {
                newObj.ParentBagId = currentObject.BagId;
                newObj.BagId = Guid.NewGuid();
            }
            else
            {
                newObj.BagId = Guid.Empty;
            }

            Boolean chapNhanThem = false;
            if (themThuMuc)
            {
                while (String.IsNullOrWhiteSpace(newObj.Name))
                {
                    newObj.Name = Microsoft.VisualBasic.Interaction.InputBox("Hãy nhập tên thư mục.", "Tên thư mục", "");
                }
                chapNhanThem = true;

            }
            else if (themFile)
            {
                using (frmDigitizing_AddNewFileOrPreview frm = new frmDigitizing_AddNewFileOrPreview(newObj))
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

            dsChungTu = TimChungTuTheoBoPhanVaLoaiChungTu(maPhongBan, (DocumentTypeEnum)maLoaiChungTu);
            chungTuBindingSource.DataSource = dsChungTu;
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
                WebReference1.DigitizingService service = new WebReference1.DigitizingService();
                String extension = Path.GetExtension(currentBag.UploadFromFilePath);
                data = service.QuickHelper_DownloadSourceFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension);
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
                WebReference1.DigitizingService service = new WebReference1.DigitizingService();
                String extension = ".doc";
                data = service.QuickHelper_DownloadConvertedFile_ByFileName(_publicKey, _token, currentBag.BagId.ToString() + extension);
                this.richEditControl1.LoadDocument(new MemoryStream(data), DevExpress.XtraRichEdit.DocumentFormat.Doc);
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
                WebReference1.DigitizingService service = new WebReference1.DigitizingService();
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
                        _token = PSC_ERP_Digitizing.Client.Helper.MakeToken(publicKey: _publicKey, secretKey: "pscvietnam@hoasua");
                        //lay danh sach bo phan
                        List<tblnsBoPhan> boPhanList = BoPhan_Factory.New().GetAll().ToList();
                        boPhanList.Insert(0, new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" });
                        tblnsBoPhanBindingSource.DataSource = boPhanList;
                        //lay danh sach loai chung tu
                        documentTypeBindingSource.DataSource = DocumentType.DocumentTypeList;

                        TaskUtil.InvokeCrossThread(this, () => { this.XuLyChungTu(); });
                        //du du lieu len cay
                        TaskUtil.InvokeCrossThread(this, () => { DocDuLieuVaDuaLenCay(); });
                        _daLoadFormXong = true;
                    }
                });

            };
        }


        private void cbBoPhan_EditValueChanged(object sender, EventArgs e)
        {//Bo phan thay doi se lay lai danh sach chung tu theo bo phan va loai chung tu
            if (_daLoadFormXong)
            {
                TaskUtil.InvokeCrossThread(this, () =>
                {
                    using (DialogUtil.Wait(this))
                    {
                        XuLyChungTu();
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
                        XuLyChungTu();
                    }
                });
            }
        }



        private void cbChungTu_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadFormXong)
            {
                TimFileBag(timNoiDungFile: false, timKetHop: true, timThemTieuDe: true);

            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            TimFileBag(timNoiDungFile: true, timKetHop: false, timThemTieuDe: true);
        }

        private void btnTimKetHop_Click(object sender, EventArgs e)
        {
            TimFileBag(timNoiDungFile: false, timKetHop: true, timThemTieuDe: true);
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
                        IQueryable<DigitizingBag> dsFile = _treeBagFactory.GetListByIdList(idFileList);
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
            if (_currentBagForPreview != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "pdf";
                dlg.Filter = "Pdf file|*.pdf";
                dlg.FilterIndex = 0;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Boolean trungFile = false;
                    if (File.Exists(dlg.FileName))
                    {
                        trungFile = true;
                        DialogResult result = DialogUtil.ShowYesNoCancel("File trùng! Bạn muốn ghi đè?");
                    }

                    try
                    {
                        using (DialogUtil.Wait(this))
                        {
                            //tải về
                            WebReference1.DigitizingService service = new WebReference1.DigitizingService();
                            String extension = Path.GetExtension(_currentBagForPreview.UploadFromFilePath);
                            byte[] data = service.QuickHelper_DownloadSourceFile_ByFileName(_publicKey, _token, _currentBagForPreview.BagId.ToString() + extension);

                            //ghi file
                            System.IO.FileStream fs = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                            fs.Write(data, 0, data.Length);
                            fs.Close();

                        }
                        DialogUtil.ShowInfo("Đã tải xong!");
                    }
                    catch (Exception ex)
                    {
                        DialogUtil.ShowError("Lỗi tải file");
                    }


                }
            }
        }









    }
}
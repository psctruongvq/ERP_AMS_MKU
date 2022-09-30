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
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;

namespace PSC_ERPNew.Main.PhanHe.DIGITIZING
{
    public partial class frmDigitizing_ChonChungTuUpLoad : DevExpress.XtraEditors.XtraForm
    {
        Boolean _daLoadFormXong = false;
        //DigitizingBag_Factory _factory = null;
        String _publicKey = "gi cung duoc";
        String _token = null;

        DigitizingBag_Factory _factory = null;
        IQueryable<DigitizingBag> _digitizingFullList = null;

        Int32? _maBoPhan_ForQuickLoad = null;
        DocumentTypeEnum _docTypeEnum_ForQuickLoad;
        Int32? _maLoaiChungTu_ForQuickLoad = null;
        Int64? _maChungTu_ForQuickLoad = null;
        Int32? _folderYear = null;
        DigitizingBag _parentFolder = null;

        Boolean _IsDatabase = false;

        public frmDigitizing_ChonChungTuUpLoad(DigitizingBag_Factory factory, IQueryable<DigitizingBag> digitizingFullList, Int32? maBoPhan_ForQuickLoad
                            , DocumentTypeEnum docTypeEnum_ForQuickLoad, Int32? folderYear, DigitizingBag parentFolder, Int64? maChungTu_ForQuickLoad, Boolean IsDatabase)
        {
            InitializeComponent();

            _token = PSC_ERPNew.Main.PhanHe.DIGITIZING.Helper.MakeToken(publicKey: _publicKey, secretKey: "pscvietnam@hoasua");
            _parentFolder = parentFolder;

            ///
            _factory = factory;
            _digitizingFullList = digitizingFullList;
            _maBoPhan_ForQuickLoad = maBoPhan_ForQuickLoad;
            _docTypeEnum_ForQuickLoad = docTypeEnum_ForQuickLoad;
            _maLoaiChungTu_ForQuickLoad = Convert.ToInt32(docTypeEnum_ForQuickLoad);
            _folderYear = folderYear;
            _maChungTu_ForQuickLoad = maChungTu_ForQuickLoad;
            _IsDatabase = IsDatabase;

        }

        private void XuLyChungTu()
        {
            int nam = Convert.ToInt32(cbNam.EditValue);
            int maPhongBan = Convert.ToInt32(cbBoPhan.EditValue);
            int maLoaiChungTu = Convert.ToInt32(cbLoaiChungTu.EditValue);

            //lay chung tu theo bo phan
            //List<Document> dsChungTu = new List<Document>();
            //ghep danh sach

            //dsChungTu = frmDigitizing.TimChungTu(nam, maPhongBan, (DocumentTypeEnum)maLoaiChungTu, _maChungTu_ForQuickLoad);
            //var chungTuKhongChon = dsChungTu.Single(x => x.Id == Guid.Empty);
            //if (chungTuKhongChon != null)
            //    dsChungTu.Remove(chungTuKhongChon);            
            List<spd_TimChungTuSoHoa_Result> dsChungTu = null;
            using (DialogUtil.Wait(this, "Đang xử lý", "Vui lòng đợi!"))
            {
            if (rad_TatCaChungTu.Checked)
            {
                dsChungTu = ChungTu_Factory.New().Context.spd_TimChungTuSoHoa(nam, maPhongBan, maLoaiChungTu, 0, null).ToList();//loại bỏ chứng từ đã gán file có thể truyền null hay false
            }
            if (rad_LoaiBoChungTuDaGanFile.Checked)
            {
                dsChungTu = ChungTu_Factory.New().Context.spd_TimChungTuSoHoa(nam, maPhongBan, maLoaiChungTu, 0, true).ToList();
            }
            if (rad_ChungTuDaGanFile.Checked)
            {
                dsChungTu = ChungTu_Factory.New().Context.spd_TimChungTuSoHoa(nam, maPhongBan, maLoaiChungTu, 0, false).ToList();
            }
            }//end using hộp thoại dialog waiting
            chungTuBindingSource.DataSource = null;
            chungTuBindingSource.DataSource = dsChungTu;

        }
        private void frmDigitizing_ChonChungTuUpLoad_Load(object sender, EventArgs e)
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
                        cbLoaiChungTu.EditValue = _maLoaiChungTu_ForQuickLoad;


                        this.XuLyChungTu();


                        //});
                        #endregion
                        _daLoadFormXong = true;
                    }
                });

            };
        }

        private void frmDigitizing_ChonChungTuUpLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtBlackHole.Focus();
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void cbChungTu_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách
            {
                using (DialogUtil.Wait(this))
                {
                    this.XuLyChungTu();
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
                        XuLyChungTu();
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
                        XuLyChungTu();
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
                        XuLyChungTu();
                    }
                });
                //XuLyChungTu();
            }
        }

        private void btnShowFilesListOfThisDocument_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var currentChungTu = gridViewDanhSachChungTu.GetFocusedRow() as spd_TimChungTuSoHoa_Result;

            //mở form danh sach file thuoc chung tu
            using (var frm = new frmDigitizing_ChonFilesUpLoad(_factory, _digitizingFullList, currentChungTu, _parentFolder, _maBoPhan_ForQuickLoad, _docTypeEnum_ForQuickLoad, _folderYear, true))
            {
                //set lại tiêu đề
                frm.Text = "Chọn File UpLoad Cho Chứng Từ " + currentChungTu.SoChungTu + " - " + currentChungTu.DienGiai;
                DialogResult result = frm.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    return;
                }

            }

        }

        private void gridViewDanhSachChungTu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void rad_TatCaChungTu_CheckedChanged(object sender, EventArgs e)
        {
            XuLyChungTu();
        }

        private void rad_LoaiBoChungTuDaGanFile_CheckedChanged(object sender, EventArgs e)
        {
            XuLyChungTu();
        }

        private void rad_ChungTuDaGanFile_CheckedChanged(object sender, EventArgs e)
        {
            XuLyChungTu();
        }

        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.gridViewDanhSachChungTu, showOpenFilePrompt: true);
        }

    }
}
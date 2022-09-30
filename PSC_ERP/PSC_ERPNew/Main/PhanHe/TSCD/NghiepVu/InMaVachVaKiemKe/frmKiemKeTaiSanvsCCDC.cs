namespace PSC_ERPNew.Main
{
    using DevExpress.Data;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using PSC_ERP_Business.Main;
    using PSC_ERP_Business.Main.Factory;
    using PSC_ERP_Business.Main.Model;
    using PSC_ERP_Common;
    using PSC_ERP_Common.Ado.Net;
    using PSC_ERPNew.Main.Reports;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Objects;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="frmKiemKeTaiSanvsCCDC" />.
    /// </summary>
    public partial class frmKiemKeTaiSanvsCCDC : XtraForm
    {
        //Private Member field
        /// <summary>
        /// Defines the _viTriList.
        /// </summary>
        internal List<tblBoPhanERPNew> _viTriList = new List<tblBoPhanERPNew>();

        /// <summary>
        /// Defines the _kiemKeTaiSan_Factory.
        /// </summary>
        internal KiemKeTaiSan_Factory _kiemKeTaiSan_Factory = KiemKeTaiSan_Factory.New();
        internal List<tblKiemKeTaiSan> _kiemKeTaiSanList = new List<tblKiemKeTaiSan>();
        /// <summary>
        /// Defines the _userID.
        /// </summary>
        internal Int32 _userID = PSC_ERP_Global.Main.UserID;

        /// <summary>
        /// Defines the _maPhongBanKiemKe.
        /// </summary>
        internal Int32 _maPhongBanKiemKe = 0;

        /// <summary>
        /// Defines the _ngayKiemKe.
        /// </summary>
        internal DateTime _ngayKiemKe = app_users_Factory.New().SystemDate;

        /// <summary>
        /// Defines the _maVach.
        /// </summary>
        internal String _maVach = "";
        //  internal String MaVach = "";
        /// <summary>
        /// Defines the MaCongTy.
        /// </summary>
        internal int MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        /// <summary>
        /// số tài sản đã được kiểm kê tại vị trí 
        /// </summary>
        internal int soTaiSanDaQuet = 0;
        /// <summary>
        /// tổng số lượng tài sản tại vị trí 
        /// </summary>
        internal int tongTaiSan = 0;
        //Member Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="frmKiemKeTaiSanvsCCDC"/> class.
        /// </summary>
        public frmKiemKeTaiSanvsCCDC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The LayThongTinMaVachQuet.
        /// </summary>
        /// <param name="soHieu">The soHieu<see cref="String"/>.</param>
        /// <returns>The <see cref="Int32"/>.</returns>
        public Int32 LayThongTinMaVachQuet(String soHieu)
        {
            foreach (tblKiemKeTaiSan kkts in _kiemKeTaiSanList)
            {
                if (kkts.SoHieuTSCDCaBiet == soHieu)
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// The DuocPhepLuu.
        /// </summary>
        /// <returns>The <see cref="Boolean"/>.</returns>
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            if (grdViewKiemKeTaiSan.RowCount == 0)
            {
                DialogUtil.ShowWarning("Chưa có dữ liệu!");
                duocPhepLuu = false;
            }
            return duocPhepLuu;
        }

        /// <summary>
        /// The ChangeFocus.
        /// </summary>
        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }

        /// <summary>
        /// The Save.
        /// </summary>
        /// <returns>The <see cref="Boolean"/>.</returns>
        private Boolean Save()
        {
            this.ChangeFocus();

            //kiểm tra dữ liệu trước khi lưu
            if (DuocPhepLuu())
            {
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        //lưu kiểm kê tài sản
                        foreach (tblKiemKeTaiSan obj in _kiemKeTaiSanList)
                        {
                            obj.NgayKiemKe = dteNgayKiemKe.DateTime;
                            obj.GhiChuChung = RtxtGhiChuChung.Text;
                            //  obj.EntityKey = new EntityKey("PSC_ERPModel.tblKiemKeTaiSans", "ID", obj.ID);
                            //_kiemKeTaiSan_Factory.AddObject(obj);

                        }
                        _kiemKeTaiSan_Factory.SaveChangesWithoutTrackingLog();
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful(ex.Message);
                }
            }
            return false;
        }

        /// <summary>
        /// The frmKiemKeTaiSanvsCCDC_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="System.EventArgs"/>.</param>
        private void frmKiemKeTaiSanvsCCDC_Load(object sender, System.EventArgs e)
        {
            tblTaiSanCoDinhCaBiet_BindingSource.DataSource = TaiSanCoDinhCaBiet_Factory.New().GetAll().Where(o => o.MaCongTy == MaCongTy).ToList();
            _viTriList = BoPhanERPNew_Factory.New().GetAll().ToList();
            tblBoPhanERPNewBindingSource.DataSource = _viTriList;
            cbBoPhan.EditValue = _maPhongBanKiemKe;
            dteNgayKiemKe.EditValue = _ngayKiemKe;
            if (ERP_Library.Security.CurrentUser.Info.MaCongTyQuanLy == "VL08")
            {
                grdViewKiemKeTaiSan.Columns["SoHieuTSCDCaBiet"].Visible = false;
            }
            else
            {
                grdViewKiemKeTaiSan.Columns["SoHieuCu"].Visible = false;
            }
            //cài đặt delete helper kiểm kê TSCD
            GridUtil.DeleteHelper.Setup_ManualType(grdViewKiemKeTaiSan, (gridView, deleteList) =>
            {
                // xóa kiểm kê tài sản trên lưới
                foreach (tblKiemKeTaiSan item in deleteList)
                {
                    _kiemKeTaiSanList.Remove(item);
                    tblKiemKeTaiSanBindingSource.DataSource = _kiemKeTaiSanList;
                    // Refesh lại lưới
                    grdViewKiemKeTaiSan.RefreshData();
                }
                //xóa kiểm kê tài sản
                KiemKeTaiSan_Factory.FullDeleteKiemKeTaiSan(context: _kiemKeTaiSan_Factory.Context, deleteList: deleteList);
            });
            // SET STT IN GridView
            GridUtil.SetSTTForGridView(this.grdViewKiemKeTaiSan, 50);
            // Đưa checkbox lên lưới
            // GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewKiemKeTaiSan, colDaQuetTSCD);
            #region k xài 
            //GridUtil.DoubleClickHelper.Setup(this.grdViewKiemKeTaiSan, (object senderz1, EventArgs ez1) =>
            //{
            //    GridView view = senderz1 as GridView;
            //    var obj = view.GetFocusedRow() as tblKiemKeTaiSan;
            //    if (obj != null)
            //    {
            //        tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet = TaiSanCoDinhCaBiet_Factory.New().Get_TaiSanCoDinhCaBiet_ByMaTSCDCaBiet(obj.MaTSCDCaBiet.Value);
            //        if (taiSanCoDinhCaBiet != null)
            //        {
            //            if ((taiSanCoDinhCaBiet.LaTaiSanCu ?? false) == true)
            //            {
            //                Boolean _laDat = true;
            //                if (taiSanCoDinhCaBiet.tblDanhMucTSCD.ParentID == 168)
            //                    //trường hợp tài sản là đất chỉ nhập vào để theo dõi không tính khấu hao hay hao mòn
            //                    _laDat = true;
            //                else
            //                    _laDat = false;
            //                frmNhapTaiSanCoDinhCaBietCu frm = new frmNhapTaiSanCoDinhCaBietCu(taiSanCoDinhCaBiet, _laDat);
            //                if (frm.ShowDialog() == DialogResult.Yes)
            //                {
            //                    _kiemKeTaiSan_Factory.RefreshAll(System.Data.Objects.RefreshMode.ClientWins);
            //                }
            //            }
            //            else
            //            {
            //                frmDialogThongTinTSCDCaBiet frm = new frmDialogThongTinTSCDCaBiet(taiSanCoDinhCaBiet, true);
            //                if (frm.ShowDialog() == DialogResult.Yes)
            //                {
            //                    _kiemKeTaiSan_Factory.RefreshAll(System.Data.Objects.RefreshMode.ClientWins);
            //                }
            //            }
            //        }
            //    }
            //});
            #endregion
        }

        /// <summary>
        /// The btn_LayDanhSachTaiSanvaChiTiet_ItemClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DevExpress.XtraBars.ItemClickEventArgs"/>.</param>
        private void btn_LayDanhSachTaiSanvaChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdViewKiemKeTaiSan.RefreshData();
            using (DialogUtil.Wait(this))
            {
                var _dsTaiSanVaCCDCTheoViTri = _kiemKeTaiSan_Factory.Context
                                           .ExecuteFunction<spd_TSCD_LayTaiSanCoDinhvaChiTietTaiSanTheoPhongBanDenNgay_KiemKe_New_Result>
                                           ("spd_TSCD_LayTaiSanCoDinhvaChiTietTaiSanTheoPhongBanDenNgay_KiemKe_New", MergeOption.NoTracking
                                             , new ObjectParameter[] { new ObjectParameter("DenNgay", _ngayKiemKe)
                                                                     ,new ObjectParameter("MaViTri", _maPhongBanKiemKe)
                                                                     ,new ObjectParameter("MaCongTy", MaCongTy)
                                                                    }
                                           ).ToList();

                _kiemKeTaiSanList = _kiemKeTaiSan_Factory
                    .Get_TaiSanCoDinhCaBiet_MaPhongBan_NgayKiemKe_MaCongTy(_maPhongBanKiemKe, _ngayKiemKe, MaCongTy)
                    .ToList();
                if (_dsTaiSanVaCCDCTheoViTri.Any() && _kiemKeTaiSanList.Count == 0)
                {
                    _kiemKeTaiSanList = convertListToTblKiemKeTaiSanEntities(_dsTaiSanVaCCDCTheoViTri);
                }

                else if (_dsTaiSanVaCCDCTheoViTri.Count == 0 && _kiemKeTaiSanList.Count == 0)
                {
                    XtraMessageBox.Show(this, "<b>Không có dữ liệu</b>"
                                        , "THÔNG BÁO", MessageBoxButtons.OK
                                        , MessageBoxIcon.Information
                                        , DevExpress.Utils.DefaultBoolean.True);
                }
                tblKiemKeTaiSanBindingSource.DataSource = _kiemKeTaiSanList;
                if (_kiemKeTaiSanList.Count > 0)
                {
                    RtxtGhiChuChung.Text = _kiemKeTaiSanList[0].GhiChuChung;
                }

            }
        }

        /// <summary>
        /// The frmKiemKeTaiSanvsCCDC_FormClosing.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="FormClosingEventArgs"/>.</param>
        private void frmKiemKeTaiSanvsCCDC_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        /// <summary>
        /// The btnThoat_ItemClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DevExpress.XtraBars.ItemClickEventArgs"/>.</param>
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// The txt_MaVach_KeyDown.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="KeyEventArgs"/>.</param>
        private void txt_MaVach_KeyDown(object sender, KeyEventArgs e)
        {
            #region đợi thống nhất ý kiến chổ block control
            //if ((char)e.KeyCode != '\u0010' && (char)e.KeyCode != '\r')
            //{
            //    if ((char)e.KeyCode == '½')
            //        MaVach += '-';
            //    else
            //        MaVach += (char)e.KeyCode;
            //}
            #endregion

            txt_MaVach.ReadOnly = false;
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_MaVach.Text.Trim() == "") { ClearDataAndFocustxtMaVach(); return; }


                string MaVach = txt_MaVach.Text;
                ClearDataAndFocustxtMaVach();//ok đoạn trên thì chỉnh lại method này
                if (MaVach.IndexOf("-") < 0)
                {

                    tblTaiSanCoDinhCaBiet taiSanSoHieuCu = TaiSanCoDinhCaBiet_Factory.New().Get_TaiSanCoDinhCaBiet_BySoHieuCu(MaVach);

                    if (taiSanSoHieuCu == null)//số hiệu không tồn tại trong phần mềm
                    {
                        XtraMessageBox.Show(this
                            , $"Mã: <color=red>{MaVach}</color>. \n<b>Không thuộc công ty này hoặc không tồn tại trong hệ thống!</b>"
                            , "THÔNG BÁO"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information
                            , DevExpress.Utils.DefaultBoolean.True);

                    }
                    else
                    {
                        tblKiemKeTaiSan tsSoHieuCaBietCu = new tblKiemKeTaiSan();
                        spd_TSCD_LayTaiSanCoDinh_KiemKe_BySoHieuCaBiet_Result tsDangQuet =
                            _kiemKeTaiSan_Factory.Context.spd_TSCD_LayTaiSanCoDinh_KiemKe_BySoHieuCaBiet(
                                                                                                        soHieu: taiSanSoHieuCu.SoHieu
                                                                                                        , denNgay: dteNgayKiemKe.DateTime
                                                                                                        , maCongTy: MaCongTy
                                                                                                        ).SingleOrDefault();
                        convertItemToTblKiemKeTaiSanEntities(tsSoHieuCaBietCu, tsDangQuet);
                        if (LayThongTinMaVachQuet(tsSoHieuCaBietCu.SoHieuTSCDCaBiet) == 1)//có trong phần mềm và đúng vị trí
                        {
                            var tsDangQuetSoHieuCu = (from o in _kiemKeTaiSanList
                                                      where o.SoHieuCu == tsSoHieuCaBietCu.SoHieuCu && o.DaQuet.Value == false
                                                      select o).First();
                            _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(tsDangQuetSoHieuCu)).DaQuet = true;
                            _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(tsDangQuetSoHieuCu)).NgayQuet = dteNgayKiemKe.DateTime;
                            grdViewKiemKeTaiSan.FocusedRowHandle = tblKiemKeTaiSanBindingSource.IndexOf(tsDangQuetSoHieuCu);
                        }

                        else
                        {
                            _kiemKeTaiSanList.Insert(0, tsSoHieuCaBietCu);
                            _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(tsSoHieuCaBietCu)).DaQuet = true;
                            _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(tsSoHieuCaBietCu)).NgayQuet = dteNgayKiemKe.DateTime;
                            _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(tsSoHieuCaBietCu)).TaiSanThua = true;
                            _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(tsSoHieuCaBietCu)).GhiChu =
                           $"Đang thuộc Bộ phận {tsSoHieuCaBietCu.MaPhongBanQL} - {tsSoHieuCaBietCu.TenBoPhan} - \nVị trí: {tsSoHieuCaBietCu.MaViTriQL} - {tsSoHieuCaBietCu.TenViTri} ";
                            grdViewKiemKeTaiSan.FocusedRowHandle = tblKiemKeTaiSanBindingSource.IndexOf(tsSoHieuCaBietCu);
                            XtraMessageBox.Show(this,
                                               $"<Color=red>Tài sản: </color> {tsSoHieuCaBietCu.SoHieuCu}" +
                                               $"\n<Color=red>Tên: </color> {tsSoHieuCaBietCu.Ten}" +
                                               $"\n<Color=red> Bộ phận quản lý: </color>{tsSoHieuCaBietCu.MaPhongBanQL} - {tsSoHieuCaBietCu.TenBoPhan}" +
                                               $"\n<Color=red> Hiện tại thuộc vị trí: </color>{tsSoHieuCaBietCu.MaViTriQL} - {tsSoHieuCaBietCu.TenViTri}"
                                               , "THÔNG BÁO",
                                               MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True
                                       );
                            _kiemKeTaiSan_Factory.AddObject(tsSoHieuCaBietCu);
                        }
                        tblKiemKeTaiSanBindingSource.ResetBindings(true);
                    }
                }
                else
                {
                    _maVach = XuLyMaVach(MaVach, 0, MaVach.IndexOf("-"));
                    string maCongTyQuanLy = MaVach.Replace(_maVach + "-", "");
                    ERP_Library.CongTy CongTy_TrenMaVach = ERP_Library.CongTy.GetCongTy_ByMaCongTyQuanLy(maCongTyQuanLy);
                    // Mã công ty user so sánh với mã công ty trên mã vạch sau khi quét
                    //TH: Mã công ty user <> mã công ty trên mã vạch
                    if (MaCongTy != CongTy_TrenMaVach.MaCongTy)
                    {

                        XtraMessageBox.Show($"Mã: <color=red>{_maVach}</color> này!."
                                             + $"\nThuộc về công ty: <color=red>{CongTy_TrenMaVach.TenVietTat}</color> - "
                                             + $"<color=red>{CongTy_TrenMaVach.TenCongTy}</color>"
                                             , "THÔNG BÁO", MessageBoxButtons.OK
                                             , MessageBoxIcon.Information
                                             , DevExpress.Utils.DefaultBoolean.True
                                            );
                    }
                    else
                    {
                        tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet = TaiSanCoDinhCaBiet_Factory.New().Get_TaiSanCoDinhCaBiet_BySoHieu(_maVach);

                        if (taiSanCoDinhCaBiet == null)//số hiệu không tồn tại trong phần mềm
                        {
                            XtraMessageBox.Show(this
                                , $"Mã: <color=red>{_maVach}</color>. \n<b>Không thuộc công ty này hoặc không tồn tại trong hệ thống!</b>"
                                , "THÔNG BÁO"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Information
                                , DevExpress.Utils.DefaultBoolean.True);

                        }
                        else // là tài sản hay chi tiết tài sản
                        {
                            if (LayThongTinMaVachQuet(_maVach) == 1)//có trong phần mềm và đúng vị trí
                            {

                                tblKiemKeTaiSan thongTinQuet = (from o in _kiemKeTaiSanList
                                                                where o.SoHieuTSCDCaBiet == _maVach
                                                                select o).FirstOrDefault();

                                _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(thongTinQuet)).DaQuet = true;
                                _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(thongTinQuet)).NgayQuet = dteNgayKiemKe.DateTime;
                                grdViewKiemKeTaiSan.FocusedRowHandle = tblKiemKeTaiSanBindingSource.IndexOf(thongTinQuet);
                            }
                            else // có trong phần mềm nhưng không đúng vị trí
                            {
                                if (taiSanCoDinhCaBiet != null)//là tài sản cố định
                                {

                                    tblKiemKeTaiSan tsThua = new tblKiemKeTaiSan();
                                    spd_TSCD_LayTaiSanCoDinh_KiemKe_BySoHieuCaBiet_Result tsDangQuet =
                                        _kiemKeTaiSan_Factory.Context.spd_TSCD_LayTaiSanCoDinh_KiemKe_BySoHieuCaBiet(
                                                                                                                    soHieu: _maVach
                                                                                                                    , denNgay: dteNgayKiemKe.DateTime
                                                                                                                    , maCongTy: MaCongTy
                                                                                                                    ).SingleOrDefault();
                                    convertItemToTblKiemKeTaiSanEntities(tsThua, tsDangQuet);
                                    _kiemKeTaiSanList.Insert(0, tsThua);
                                    _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(tsThua)).TaiSanThua = true;
                                    _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(tsThua)).DaQuet = true;
                                    _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(tsThua)).NgayQuet = dteNgayKiemKe.DateTime;
                                    _kiemKeTaiSanList.ElementAt(tblKiemKeTaiSanBindingSource.IndexOf(tsThua)).GhiChu =
                                        $"Đang thuộc Bộ phận {tsThua.MaPhongBanQL} - {tsThua.TenBoPhan} - \nVị trí: {tsThua.MaViTriQL} - {tsThua.TenViTri} ";
                                    grdViewKiemKeTaiSan.FocusedRowHandle = tblKiemKeTaiSanBindingSource.IndexOf(tsThua);
                                    XtraMessageBox.Show(this,
                                                $"<Color=red>Tài sản: </color> {tsThua.SoHieuTSCDCaBiet}" +
                                                $"\n<Color=red>Tên: </color> {tsThua.Ten}" +
                                                $"\n<Color=red> Bộ phận quản lý: </color>{tsThua.MaPhongBanQL} - {tsThua.TenBoPhan}" +
                                                $"\n<Color=red> Hiện tại thuộc vị trí: </color>{tsThua.MaViTriQL} - {tsThua.TenViTri}"
                                                , "THÔNG BÁO",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True
                                        );
                                    _kiemKeTaiSan_Factory.AddObject(tsThua);
                                }
                            }
                            tblKiemKeTaiSanBindingSource.ResetBindings(true);
                        }
                    }

                }

                #region đợi thống nhất ý kiến chổ block control
                // MaVach = "";
                #endregion
            }


        }
        /// <summary>
        ///  Clear text And Focus txtMaVach
        /// </summary>
        private void ClearDataAndFocustxtMaVach()
        {
            txt_MaVach.ReadOnly = true;
            txt_MaVach.ResetText();
            txt_MaVach.Refresh();
            txt_MaVach.Focus();
        }


        private List<tblKiemKeTaiSan> convertListToTblKiemKeTaiSanEntities(List<spd_TSCD_LayTaiSanCoDinhvaChiTietTaiSanTheoPhongBanDenNgay_KiemKe_New_Result> convertList)
        {
            var entityCollection = new List<tblKiemKeTaiSan>();
            foreach (var m in convertList)
            {
                var entityObject = _kiemKeTaiSan_Factory.CreateAloneObject();
                #region chuyển đổi các prop từ store sang objectEntity
                entityObject.ID = m.ID.Value;
                entityObject.MaPhongBan = m.MaBoPhan.Value;
                entityObject.SoHieuTSCDCaBiet = m.SoHieu;
                entityObject.MaPhongBanQL = m.MaBoPhanQL;
                entityObject.NgayKiemKe = null;
                entityObject.FilePath = null;
                entityObject.UserID = ERP_Library.Security.CurrentUser.Info.UserID;
                entityObject.MaTSCDCaBiet = (int)m.MaTSCDCaBiet.Value;
                entityObject.MaChiTietTSCDCaBiet = null;
                entityObject.NgayQuet = null;
                entityObject.DaQuet = false;
                entityObject.Ten = m.Ten;
                entityObject.LaTaiSan = m.LaTaiSan.Value;
                entityObject.NguyenGiaBanDau = m.NguyenGiaMua;
                entityObject.GiaTriMoiNhat = m.GiaTriHienTai;
                entityObject.GiaTriConLai = m.GiaTriConLai;
                entityObject.NgaySuDung = m.NgaySuDung;
                entityObject.SoSerial = null;
                entityObject.TaiSanThua = null;
                entityObject.MaViTri = m.MaViTri.Value;
                entityObject.TenViTri = m.TenViTri;
                entityObject.MaViTriQL = m.MaViTriQL;
                entityObject.MaCongTy = m.MaCongTy;
                entityObject.TinhTrang = m.TinhTrang;
                entityObject.MaViTriKiemKe = (int)cbBoPhan.EditValue;
                entityObject.SoHieuCu = m.SoHieuCu;
                #endregion

                entityCollection.Add(entityObject);
            }
            return entityCollection;
        }

        /// <summary>
        ///  Chuyển đổi Object từ Store (dựa trên mã số hiệu cá biệt cửa tài sản) sang TblKiemKeTaiSanEntities.
        ///  Dành cho tài sản không thuộc về vị trí đang kiểm kê
        /// </summary>
        /// <param name="entityObject">The entityObject<see cref="tblKiemKeTaiSan"/>.</param>
        /// <param name="m">The m<see cref="spd_TSCD_LayTaiSanCoDinh_KiemKe_BySoHieuCaBiet_Result"/>.</param>
        private void convertItemToTblKiemKeTaiSanEntities(tblKiemKeTaiSan entityObject, spd_TSCD_LayTaiSanCoDinh_KiemKe_BySoHieuCaBiet_Result m)
        {
            entityObject.ID = m.ID.Value;
            entityObject.MaPhongBan = m.MaBoPhan;
            entityObject.SoHieuTSCDCaBiet = m.SoHieu;
            entityObject.MaPhongBanQL = m.MaBoPhanQL;
            entityObject.NgayKiemKe = null;
            entityObject.FilePath = null;
            entityObject.UserID = ERP_Library.Security.CurrentUser.Info.UserID;
            entityObject.MaTSCDCaBiet = (int)m.MaTSCDCaBiet.Value;
            entityObject.MaChiTietTSCDCaBiet = null;
            entityObject.NgayQuet = null;
            entityObject.DaQuet = false;
            entityObject.Ten = m.Ten;
            entityObject.LaTaiSan = m.LaTaiSan;
            entityObject.NguyenGiaBanDau = m.NguyenGiaMua;
            entityObject.GiaTriMoiNhat = m.GiaTriHienTai;
            entityObject.GiaTriConLai = m.GiaTriConLai;
            entityObject.NgaySuDung = m.NgaySuDung;
            entityObject.SoSerial = null;
            entityObject.TaiSanThua = null;
            entityObject.MaViTri = m.MaViTri;
            entityObject.TenViTri = m.TenViTri;
            entityObject.MaViTriQL = m.MaViTriQL;
            entityObject.MaCongTy = m.MaCongTy;
            entityObject.TinhTrang = m.TinhTrang;
            entityObject.TenBoPhan = m.TenBoPhan;
            entityObject.MaViTriKiemKe = (int)cbBoPhan.EditValue;
            entityObject.SoHieuCu = m.SoHieuCu;
        }

        /// <summary>
        /// The btnLuu_ItemClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DevExpress.XtraBars.ItemClickEventArgs"/>.</param>
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                DialogResult dlgResult = DialogUtil.ShowYesNo("Kết thúc kiểm kê!\nBạn có muốn in báo cáo đối chiếu kiểm kê!");
                if (dlgResult == DialogResult.Yes)
                {
                    btn_InBaoCao.PerformClick();
                }
                btn_LayDanhSachTaiSanvaChiTiet.Enabled = groupThongTinKiemKe.Enabled = true;
            }
            else
            {
                XtraMessageBox.Show(this, "<b> Kết thúc không thành công!</b>"
                                        , "THÔNG BÁO", MessageBoxButtons.OK
                                        , MessageBoxIcon.Information
                                        , DevExpress.Utils.DefaultBoolean.True);
            }
            cbBoPhan.Enabled = true;
            dteNgayKiemKe.Enabled = true;
            RtxtGhiChuChung.Enabled = false;
            btnLuu.Enabled = false;
            btn_BatDau.Enabled = true;
        }

        /// <summary>
        /// The cbBoPhan_EditValueChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void cbBoPhan_EditValueChanged(object sender, EventArgs e)
        {
            _maPhongBanKiemKe = (Int32)cbBoPhan.EditValue;
            _kiemKeTaiSanList.Clear();
            tblKiemKeTaiSanBindingSource.ResetBindings(true);
        }

        /// <summary>
        /// The dteNgayKiemKe_EditValueChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void dteNgayKiemKe_EditValueChanged(object sender, EventArgs e)
        {
            _ngayKiemKe = (DateTime)dteNgayKiemKe.EditValue;
            _kiemKeTaiSanList.Clear();
            tblKiemKeTaiSanBindingSource.ResetBindings(true);
        }

        /// <summary>
        /// The XuLyMaVach.
        /// </summary>
        /// <param name="maVach">The maVach<see cref="string"/>.</param>
        /// <param name="TuViTri">The TuViTri<see cref="int"/>.</param>
        /// <param name="DenViTri">The DenViTri<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string XuLyMaVach(string maVach, int TuViTri, int DenViTri)
        {
            string kq = string.Empty;
            if (maVach.Trim() != "")
            {
                kq = maVach.Substring(TuViTri, DenViTri);
            }
            return kq;
        }

        /// <summary>
        /// The btn_InBaoCao_ItemClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DevExpress.XtraBars.ItemClickEventArgs"/>.</param>
        private void btn_InBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string MaBoPhanQL = BoPhanERPNew_Factory.New().Get_BoPhanTheoMaBoPhan((Int32)cbBoPhan.EditValue).MaBoPhanQL;
            ReportHelper.ShowReportCustomNameFile($"BaoCaoKiemKe_{MaBoPhanQL}", "DanhSachTaiSanvaChiTietCoDenNgay_DungKiemKeDoiChieu", () =>
             {
                 DataSet dataSet = new DataSet();
                 SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                 dataAccess.FillDataSet(ref dataSet
                                             , "MainData"
                                             , "spRpt_TSCD_DanhSachTaiSanvaChiTietTaiSanCoDenNgay_KiemKeDoiChieu"
                                             , "@DenNgay,@MaPhongBan,@CoChiTiet,@MaCongTy"
                                             , _ngayKiemKe
                                             , _maPhongBanKiemKe
                                             , true
                                             , MaCongTy
                                         );
                 //Tao Bang Ngay Lap
                 DataTable dtngay = new DataTable();
                 dtngay.Columns.Add("DenNgay", typeof(DateTime));
                 //Add dòng 1
                 DataRow dr = dtngay.NewRow();
                 dr["DenNgay"] = _ngayKiemKe;
                 dtngay.Rows.Add(dr);
                 dtngay.TableName = "SubInfo";
                 dataSet.Tables.Add(dtngay);
                 return dataSet;
             }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        /// <summary>
        /// The btn_BatDau_ItemClick.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="DevExpress.XtraBars.ItemClickEventArgs"/>.</param>
        private void btn_BatDau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean _checkViTriKiemKeTheoNgay = _kiemKeTaiSan_Factory.Check_ViTriChuaKiemKe_TheoNgay(
                                                                                                      maViTriKiemKe: (int)cbBoPhan.EditValue,
                                                                                                      ngayKiemKe: dteNgayKiemKe.DateTime
                                                                                                     );
            #region Kiểm tra đã chọn vị trí cần kiểm kê chưa
            if ((int)cbBoPhan.EditValue > 0)
            {
                if (_checkViTriKiemKeTheoNgay == false)
                {
                    //khóa/mở các control
                    cbBoPhan.Enabled = false;
                    dteNgayKiemKe.Enabled = false;
                    btn_BatDau.Enabled = false;
                    btnLuu.Enabled = true;
                    RtxtGhiChuChung.Enabled = true;
                    txt_MaVach.Focus();
                    foreach (var o in _kiemKeTaiSanList)
                        _kiemKeTaiSan_Factory.AddObject(o);
                }
                else if (_checkViTriKiemKeTheoNgay == true)
                {
                    XtraMessageBox.Show(this
                                        , $"Đã thực hiện kiểm kê vị trí {cbBoPhan.Text} cùng ngày {dteNgayKiemKe.DateTime.ToString("dd/MM/yyyy")} \n " +
                                        "(Chỉ kiểm kê một vị trí <color=red>một lần trong ngày</color>)"
                                        , "THÔNG BÁO"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True
                                        );
                }
                //else   //_kiemKeTaiSanList.Count < 0 
                //    XtraMessageBox.Show(this
                //                        , $"<b>Vui lòng lấy dữ liệu trước khi bắt đầu!<b>"
                //                        , "THÔNG BÁO"
                //                        , MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True
                //                        );
            }
            else
            {
                XtraMessageBox.Show(this
                                        , $"<b>Vui lòng chọn phòng ban để kiểm kê!<b>"
                                        , "THÔNG BÁO"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True
                                        );
            }
            #endregion
        }

        /// <summary>
        /// The grdViewKiemKeTaiSan_DataSourceChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void grdViewKiemKeTaiSan_DataSourceChanged(object sender, EventArgs e)
        {
            grdViewKiemKeTaiSan.RowStyle += GrdViewKiemKeTaiSan_RowStyle;
            grdViewKiemKeTaiSan.RowCellStyle += GrdViewKiemKeTaiSan_RowCellStyle;
        }

        /// <summary>
        /// The GrdViewKiemKeTaiSan_RowStyle.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RowStyleEventArgs"/>.</param>
        private void GrdViewKiemKeTaiSan_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (_kiemKeTaiSanList != null && _kiemKeTaiSanList.Any())
            {
                GridView View = sender as GridView;
                string TaiSanThua = View.GetRowCellDisplayText(e.RowHandle, "TaiSanThua");
                if (TaiSanThua == "Checked")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.LightCoral);
                }
            }
        }

        /// <summary>
        /// The GrdViewKiemKeTaiSan_RowCellStyle.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RowCellStyleEventArgs"/>.</param>
        private void GrdViewKiemKeTaiSan_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            string TaiSanThua = View.GetRowCellDisplayText(e.RowHandle, "TaiSanThua");
            if (TaiSanThua == "Checked")
            {
                e.Appearance.BackColor = Color.FromArgb(150, Color.LightCoral);
            }
        }

        private void grdViewKiemKeTaiSan_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            string _daQuet = $"{this.soTaiSanDaQuet}/{this.tongTaiSan}";
            GridView view = sender as GridView;
            // Get the summary ID. 
            string summaryID = Convert.ToString((e.Item as GridSummaryItem).Tag);
            // Initialization. 
            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                this.soTaiSanDaQuet = 0;
                this.tongTaiSan = _kiemKeTaiSanList.Count();
            }
            // Calculation.
            if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {
                switch (summaryID)
                {
                    case "daquet":
                        if (Convert.ToString(view.GetRowCellDisplayText(e.RowHandle, "DaQuet")) == "Checked")
                            this.soTaiSanDaQuet += 1;
                        break;
                }
            }
            // Finalization. 
            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                switch (summaryID)
                {
                    case "daquet":
                        e.TotalValue = _daQuet;
                        break;
                }
            }

        }//end method


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;
using System.IO;

using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERP_Common.Ado.Net;
using PSC_ERPNew.Main.Reports;
using System.Data.Objects;
using System.Linq;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERPNew.Main;
//26_04_2014
namespace PSC_ERP.ThuChiEntity
{
    public partial class frmChiPhiSanXuatChuongTrinhE : DevExpress.XtraEditors.XtraForm
    {

        #region properties

        Entities _context = null;
        public tblChungTu _chungTu = null;
        tblButToan _butToan = null;

        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        int _nguoilap= ERP_Library.Security.CurrentUser.Info.UserID;
        List<tblnsChuongTrinh> _chuongTrinhList = null;

        public List<tblCT_ChiPhiSanXuat> _ChungTu_ChiPhiSXList;
        public static tblCT_ChiPhiSanXuat _chungTuChiPhiSanXuat = null;
        List<tblCT_ChiPhiSanXuat> _chungTu_ChiPhiSanXuatList_Deleted = null;
        public bool IsSave = false;
        public decimal SoTienDaNhap = 0;
        public static decimal _soTienThuLao = 0;
        public static decimal _soTienChiPhi = 0;
        public static decimal _soTienTong = 0;
        public static ChungTu_ChiPhiSanXuat ct_ChiPhi;
        private static List<tblCT_ChiPhiSanXuat> _ct_ChiPhiSanXuatListFirst = null;//Us
        private static List<spd_DanhSachChiPhiSanXuatTheoThang_Result> _chiThuLaoListFirst = null;//Us
        private decimal _tongSotienCPSX;
        private Boolean _daTapHopChiPhiSanXuat = false;//Us
        public bool DaTapHopChiPhiSanXuat
        {
            get
            {
                return _daTapHopChiPhiSanXuat;
            }
            set
            {
                if (!_daTapHopChiPhiSanXuat.Equals(value))
                {
                    _daTapHopChiPhiSanXuat = value;
                }
            }

        }

        public List<tblCT_ChiPhiSanXuat> ChungTu_ChiPhiSanXuatList_Delete
        {
            get { return _chungTu_ChiPhiSanXuatList_Deleted; }
        }

        private bool clickgriview = false;
        #endregion

        #region Function

        private void KhoiTao()
        {
            tblButToanBindingSource_Single.DataSource = typeof(PSC_ERP_Business.Main.Model.tblButToan);
            //lấy danh sách chương trình chưa hoàn tất theo mã công ty
            tblnsChuongTrinhBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblnsChuongTrinh);
            tblnsBoPhanDenbindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblnsBoPhan);
            //lấy danh sách chi phi san xuat theo but toan
            tblCTChiPhiSanXuatBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblCT_ChiPhiSanXuat);

            tblTaiKhoanBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblTaiKhoan);
            gridControl1.DataSource = tblCTChiPhiSanXuatBindingSource;
            DesignGrid();
        }

        private void LoadDaTa()
        {
            tblButToanBindingSource_Single.DataSource = _butToan;
            //lấy danh sách chi phi san xuat theo but toan
            tblCTChiPhiSanXuatBindingSource.DataSource = _butToan.tblCT_ChiPhiSanXuat;
            //Lay DS TK No Co
            tblTaiKhoanBindingSource_No.DataSource = TaiKhoan_Factory.New().GetAll();
            tblTaiKhoanBindingSource_Co.DataSource = TaiKhoan_Factory.New().GetAll();
            //lấy danh sách tài khoản
            List<tblTaiKhoan> taiKhoanList = TaiKhoan_Factory.New().GetAll().ToList<tblTaiKhoan>();
            tblTaiKhoan tk_rong = new tblTaiKhoan() { MaTaiKhoan = 0, SoHieuTK = "<<Khôgn chọn>>" };
            taiKhoanList.Insert(0, tk_rong);
            tblTaiKhoanBindingSource.DataSource = taiKhoanList;

            //lấy danh sách chương trình chưa hoàn tất theo mã công ty
            _chuongTrinhList = NsChuongTrinh_Factory.New().Get_DanhSachChuaHoanTatByMaCongTy(BasicInfo.User.MaCongTy ?? 0).ToList<tblnsChuongTrinh>();
            tblnsChuongTrinh chuongtrinh_khongChon = new tblnsChuongTrinh() { MaChuongTrinh = 0, TenChuongTrinh = "<<Không chọn>>" };
            _chuongTrinhList.Insert(0, chuongtrinh_khongChon);
            tblnsChuongTrinhBindingSource.DataSource = _chuongTrinhList;

            List<tblnsBoPhan> bophanlist = BoPhan_Factory.New().GetBoPhanbyMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).ToList();
            tblnsBoPhan bpempty = new tblnsBoPhan() { MaBoPhan = 0, TenBoPhan = "<<Không chọn>>" };
            bophanlist.Insert(0, bpempty);
            tblnsBoPhanDenbindingSource.DataSource = bophanlist;

        }

        private void DesignGrid()
        {
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaChuongTrinh", "SoTien", "MaTaiKhoan", "MaLoaiChi", "MaBoPhan" },
                                new string[] { "Công việc/Chương Trình", "Số Tiền", "Tài khoản KC","Loại Chi","Bộ Phận Đến" },
                                             new int[] { 300, 100, 100,100,100 });

            //Cot Muc Ngan Sach
            RepositoryItemButtonEdit ButtonEdit_MucNganSach = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(ButtonEdit_MucNganSach)).BeginInit();
            ButtonEdit_MucNganSach.AutoHeight = false;
            ButtonEdit_MucNganSach.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Mục ngân sách", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), new DevExpress.Utils.SerializableAppearanceObject(), "", null, null, true)});
            ButtonEdit_MucNganSach.Name = "repositoryItemButtonEdit2";
            ButtonEdit_MucNganSach.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            GridColumn colMucNganSach = new GridColumn();
            colMucNganSach.Caption = "Mục ngân sách";
            colMucNganSach.ColumnEdit = ButtonEdit_MucNganSach;
            colMucNganSach.Name = "colMucNganSach";
            colMucNganSach.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colMucNganSach.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            colMucNganSach.Visible = true;
            colMucNganSach.VisibleIndex = 2;

            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ButtonEdit_MucNganSach });
            gridView1.Columns.Add(colMucNganSach);
            //Cot Muc Ngan Sach

            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaChuongTrinh", "SoTien", "MaTaiKhoan", "MaLoaiChi", "MaBoPhan" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(gridView1,NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(gridView1, 40);//M

            //Cong Viec/Chuong Trinh
            RepositoryItemGridLookUpEdit ChuongTrinh_grdLU = new RepositoryItemGridLookUpEdit();
            ChuongTrinh_grdLU.DataSource = tblnsChuongTrinhBindingSource;
            ChuongTrinh_grdLU.DisplayMember = "TenChuongTrinh";
            ChuongTrinh_grdLU.ValueMember = "MaChuongTrinh";
            HamDungChung.InitRepositoryItemGridLookUpDev(ChuongTrinh_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(ChuongTrinh_grdLU, new string[] { "MaQL", "TenChuongTrinh", "TenNguon" }, new string[] { "Mã chương trình", "Tên chương trình", "Tên nguồn" }, new int[] { 120, 250, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaChuongTrinh", ChuongTrinh_grdLU);
            //

            //TaiKhoan Ket Chuyen
            RepositoryItemGridLookUpEdit TaiKhoan_GrdLU = new RepositoryItemGridLookUpEdit();
            TaiKhoan_GrdLU.DataSource = tblTaiKhoanBindingSource;
            TaiKhoan_GrdLU.DisplayMember = "SoHieuTK";
            TaiKhoan_GrdLU.ValueMember = "MaTaiKhoan";
            HamDungChung.InitRepositoryItemGridLookUpDev(TaiKhoan_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoan_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên Tài Khoản" }, new int[] { 100, 250 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaTaiKhoan", TaiKhoan_GrdLU);
            //

            //Loai Chi
            RepositoryItemGridLookUpEdit loaichi_GrdLU = new RepositoryItemGridLookUpEdit();
            loaichi_GrdLU.DataSource = MaLoaiChiClass.CreatMaLoaiChiClassList();
            loaichi_GrdLU.DisplayMember = "LoaiChi";
            loaichi_GrdLU.ValueMember = "MaLoaiChi";
            HamDungChung.InitRepositoryItemGridLookUpDev(loaichi_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(loaichi_GrdLU, new string[] { "LoaiChi" }, new string[] { "Loại Chi" }, new int[] {250 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiChi", loaichi_GrdLU);
            //
            //BoPhanDen
            RepositoryItemGridLookUpEdit bophanDen_GrdLU = new RepositoryItemGridLookUpEdit();
            bophanDen_GrdLU.DataSource = tblnsBoPhanDenbindingSource;
            bophanDen_GrdLU.DisplayMember = "TenBoPhan";
            bophanDen_GrdLU.ValueMember = "MaBoPhan";
            HamDungChung.InitRepositoryItemGridLookUpDev(bophanDen_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(bophanDen_GrdLU, new string[] { "MaBoPhanQL", "TenBoPhan" }, new string[] { "Mã bộ phận", "Tên bộ phận" }, new int[] { 100, 250 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaBoPhan", bophanDen_GrdLU);
            //
            //
            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["SoTien"].ColumnEdit = repositoryItemCalcEditSoTien;

            //


            HamDungChung.FormatNumberTypeofColumnGridViewDev(gridView1, new string[] { "SoTien" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "#,###.#");

            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            //this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            //this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);

            this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);

            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
        }

        private void setvaluesDefault(tblCT_ChiPhiSanXuat chiPhiSX)
        {
            Decimal tongTienCacChiPhiSanXuatKhac = 0;
            foreach (var item in _butToan.tblCT_ChiPhiSanXuat)
            {
                if (!Object.ReferenceEquals(item, chiPhiSX))
                    tongTienCacChiPhiSanXuatKhac += item.SoTien ?? 0;
            }
            chiPhiSX.SoChungTu = _chungTu.SoChungTu;
            chiPhiSX.SoTien = _butToan.SoTien - tongTienCacChiPhiSanXuatKhac;
        }

        private bool KiemTraTruocKhiThoat()
        {
                string noTK = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(_butToan.NoTaiKhoan.Value).SoHieuTK;
                string coTK = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(_butToan.CoTaiKhoan.Value).SoHieuTK;
                if (noTK.Contains("1551") || noTK.Contains("1552") || coTK.Contains("1551") || coTK.Contains("1552") || noTK.Contains("631") || noTK.Contains("4314"))
                {
                    if (_butToan.tblCT_ChiPhiSanXuat.Count == 0)
                    {
                        MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        foreach (tblCT_ChiPhiSanXuat cp in _butToan.tblCT_ChiPhiSanXuat)
                        {
                            if (cp.tblButToan_MucNganSach.Count == 0 && (noTK.Contains("631") || noTK.Contains("4314")))
                            {
                                MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
            return true;
        }

        private Boolean HopLe()
        {
            if (KiemTraTruocKhiThoat() == false)
            {
                return false;
            }

            Decimal tongTien = 0;
            foreach (var chiPhi in _butToan.tblCT_ChiPhiSanXuat)
            {
                if ((chiPhi.MaChuongTrinh ?? 0) == 0)
                {
                    DialogUtil.ShowError("Có dòng chưa chọn công việc/CT!");
                    return false;
                }
                else if (chiPhi.SoTien == 0)
                {
                    DialogUtil.ShowError("Có dòng có Số tiền =0!");
                    return false;
                }
                else if ((chiPhi.MaLoaiChi == 1 || chiPhi.MaLoaiChi == 2) && chiPhi.MaBoPhan == 0)
                {
                    MessageBox.Show("Vui lòng chọn bộ phận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                #region Kiem tra Tongtien ButToan_MNS với TongIienChiPhi
                if (chiPhi.tblButToan_MucNganSach.Count > 0)
                {
                    decimal tongtienCP = 0;
                    foreach (var bt_mns in chiPhi.tblButToan_MucNganSach)
                    {
                        tongtienCP += bt_mns.SoTien;
                    }
                    if (tongtienCP != chiPhi.SoTien)
                    {
                        DialogUtil.ShowError("Tổng tiền bút toán - Mục ngân sách không bằng số tiền chi phí");
                        return false;
                    }
                }
                #endregion//Kiem tra Tongtien ButToan_MNS với TongIienChiPhi
                tongTien += chiPhi.SoTien ?? 0;
            }
            //
            if (_butToan.tblCT_ChiPhiSanXuat.Count>0 && tongTien != _butToan.SoTien && _daTapHopChiPhiSanXuat == false)//.Count > 0)
            {
                DialogUtil.ShowError("Tổng tiền chi phí không bằng số tiền bút toán");
                return false;
            }
            _tongSotienCPSX = tongTien;
            return true;
        }

        private void XoaCPSXdaChon()
        {
            if (KiemTraTruocKhiXoa() == false) return;
            if (gridView1.RowCount > 0)
            {
                if (gridView1.GetSelectedRows().Length > 0)
                {
                    if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView1.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (int cpDeleteindex in gridView1.GetSelectedRows())
                        {
                            tblCT_ChiPhiSanXuat itemChungTu = _butToan.tblCT_ChiPhiSanXuat.ElementAtOrDefault(cpDeleteindex);
                            _chungTu_ChiPhiSanXuatList_Deleted.Add(itemChungTu);
                            for (int i = 0; i < frmBangKeE._chiThuLaoList_DaChon.Count; i++)
                            {
                                spd_DanhSachChiPhiSanXuatTheoThang_Result item = frmBangKeE._chiThuLaoList_DaChon.ElementAt<spd_DanhSachChiPhiSanXuatTheoThang_Result>(i);
                                if (item.MaChuongTrinh == itemChungTu.MaChuongTrinh)
                                {
                                    frmBangKeE._chiThuLaoList_DaChon.Remove(item);
                                    i -= 1;
                                }
                            }

                            #region Xoa ButToan MucNganSach ra  ButToan
                            foreach (tblButToan_MucNganSach bt_mns in itemChungTu.tblButToan_MucNganSach)
                            {
                                _butToan.tblButToan_MucNganSach.Remove(bt_mns);
                            }
                            #endregion//Xoa ButToan MucNganSach ra  ButToan
                        }
                        gridView1.DeleteSelectedRows();
                    }
                }
            }
        }

        #region BoSungMaLoaiChi

        private void LockGrig()
        {
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoTien", "MaLoaiChi" });
            //gridView1.Columns["SoTien"].AllowSummaryMenu = Activation.NoEdit;
            //gridView1.Columns["MaLoaiChi"].CellActivation = Activation.NoEdit;
        }

        private void UnLockGrig()
        {
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "SoTien", "MaLoaiChi" });
            //grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellActivation = Activation.AllowEdit;
            //grdData.DisplayLayout.Bands[0].Columns["MaLoaiChi"].CellActivation = Activation.AllowEdit;
        }

        private bool CheckChiThuLaoChuaSuDung()
        {
            if (gridView1.GetFocusedRow() != null)
            {
                tblCT_ChiPhiSanXuat chungTuChiPhiSanXuatCurrent = gridView1.GetFocusedRow() as tblCT_ChiPhiSanXuat;
                if (chungTuChiPhiSanXuatCurrent.tblcnChiThuLaos.Count != 0)
                {
                    ChiThuLao chiThuLao = ChiThuLao.GetChiThuLao(chungTuChiPhiSanXuatCurrent.tblcnChiThuLaos.First().MaChiThuLao);
                    if (ChiThuLao.CheckChiThuLaoDaSuDung(chiThuLao.MaChiThuLao))
                        return false;

                }
            }
            return true;
        }

        private bool KiemTraTruocKhiXoa()
        {
             int[] deleteRows = gridView1.GetSelectedRows();
            foreach (int deleteRow in deleteRows)
            {
                tblCT_ChiPhiSanXuat ct_chiphi=gridView1.GetRow(deleteRow) as tblCT_ChiPhiSanXuat;
                if (ct_chiphi.tblcnChiThuLaos.Count != 0)
                {
                    ChiThuLao chiThuLao = ChiThuLao.GetChiThuLao(ct_chiphi.tblcnChiThuLaos.First().MaChiThuLao);
                    if (ChiThuLao.CheckChiThuLaoDaSuDung(chiThuLao.MaChiThuLao))
                    {
                        MessageBox.Show("Chi phí đã Chi, không thể xóa. Vui lòng kiểm tra lại!", "Thông báo");
                        return false;
                    }

                }

            }
            return true;
        }



        #endregion//BoSungMaLoaiChi

        #endregion

        #region EventHandle

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //lấy chi phi san xuat vừa tạo mới trên lưới
            tblCT_ChiPhiSanXuat chiPhiSX = this.gridView1.GetRow(e.RowHandle) as tblCT_ChiPhiSanXuat;
            if (chiPhiSX != null)
            {
                _chungTu.tblCT_ChiPhiSanXuat.Add(chiPhiSX);
                setvaluesDefault(chiPhiSX);
            }
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            clickgriview = true;

            if (gridView1.FocusedColumn.Name == "colMucNganSach")
            {
                //lay dong chi phi san xuat hien tai
                tblCT_ChiPhiSanXuat currentChiPhi = this.gridView1.GetFocusedRow() as tblCT_ChiPhiSanXuat;
                //kiem tra da chon chuong trinh
                if ((currentChiPhi.MaChuongTrinh ?? 0) == 0)
                {
                    DialogUtil.ShowWarning("Cần chọn công việc/CT");
                }
                else
                {
                    using (frmGhiMucNganSachcuaChiPhiSanXuatE frm = new frmGhiMucNganSachcuaChiPhiSanXuatE(context: _context, chungTu: _chungTu, butToan: _butToan, chiPhiSanXuat: currentChiPhi))
                    {
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                XoaCPSXdaChon();
            }

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            tblCT_ChiPhiSanXuat currentchiphi = this.gridView1.GetFocusedRow() as tblCT_ChiPhiSanXuat;
            if (gridView1.FocusedColumn.FieldName == "MaChuongTrinh")
            {
                if (e.Value != null && (int)e.Value != 0)
                {
                    tblnsChuongTrinh chuongtrinh = NsChuongTrinh_Factory.New().GetChuongTrinhByMaChuongTrinh((int)e.Value);
                    if (chuongtrinh != null)
                    {
                        currentchiphi.TenChuongTrinh = chuongtrinh.TenChuongTrinh;
                        if (currentchiphi.tblcnChiThuLaos != null && currentchiphi.tblcnChiThuLaos.Count > 0)
                        {
                            currentchiphi.tblcnChiThuLaos.First().TenChuongTrinh = chuongtrinh.TenChuongTrinh;
                        }
                    }
                }
            }
            //if (gridView1.FocusedColumn.FieldName == "MaLoaiChi" || gridView1.FocusedColumn.FieldName == "MaBoPhan")
            //{
                if (currentchiphi.MaLoaiChi == 0)
                {

                    if (currentchiphi.tblChiPhiThucHiens.Count != 0)
                    {
                        ChiPhiThucHien_Factory.FullDelete(_context, currentchiphi.tblChiPhiThucHiens.ToList());
                        //currentchiphi.tblChiPhiThucHiens.Clear();
                    }

                    if (currentchiphi.tblcnChiThuLaos.Count != 0)
                    {
                        ChiThuLao_Factory.FullDelete(_context, currentchiphi.tblcnChiThuLaos.ToList());
                        //currentchiphi.tblcnChiThuLaos.Clear();
                    }

                    //Set mã bộ phận 
                    currentchiphi.MaBoPhan = 0;
                }
                else if (currentchiphi.MaLoaiChi == 3 && _chungTu.MaDoiTuong == 0)
                {
                    MessageBox.Show("Chưa chọn Tên Khách Hàng.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    currentchiphi.MaLoaiChi = 0;
                    return;
                }
                else if (currentchiphi.MaLoaiChi == 3 && _chungTu.MaDoiTuong != 0)
                {
                    if (currentchiphi.tblcnChiThuLaos.Count != 0)
                    {
                        ChiThuLao_Factory.FullDelete(_context, currentchiphi.tblcnChiThuLaos.ToList());
                        //currentchiphi.tblcnChiThuLaos.Clear();
                        //Set mã bộ phận 
                        currentchiphi.MaBoPhan = 0;
                    }

                    if (currentchiphi.tblChiPhiThucHiens.Count == 0)
                    {

                        tblChiPhiThucHien chiPhiThucHien =ChiPhiThucHien_Factory.New().CreateAloneObject();
                        chiPhiThucHien.MaChuongTrinh = currentchiphi.MaChuongTrinh;
                        chiPhiThucHien.MaDoiTuong = _chungTu.MaDoiTuong;
                        chiPhiThucHien.SoTien = currentchiphi.SoTien;
                        chiPhiThucHien.NgayLap = DateTime.Now.Date;
                        chiPhiThucHien.MaLoaiChiPhiSanXuat = 1;
                        chiPhiThucHien.NguoiLap = _nguoilap;
                        //Lấy dữ liệu cho chi phí thực hiện chương trình
                        currentchiphi.tblChiPhiThucHiens.Add(chiPhiThucHien);

                        //Set mã bộ phận 
                        currentchiphi.MaBoPhan = 0;
                    }
                    else
                    {
                        foreach (tblChiPhiThucHien cpth in currentchiphi.tblChiPhiThucHiens)
                        {
                            cpth.MaChuongTrinh = currentchiphi.MaChuongTrinh;
                            cpth.MaDoiTuong = _chungTu.MaDoiTuong;
                            cpth.SoTien = currentchiphi.SoTien;
                        }
                        //Set mã bộ phận 
                        currentchiphi.MaBoPhan = 0;
                    }
                }
                else if ((currentchiphi.MaBoPhan ?? 0) != 0)
                {
                    if (currentchiphi.tblChiPhiThucHiens.Count != 0)
                    {
                        ChiPhiThucHien_Factory.FullDelete(_context, currentchiphi.tblChiPhiThucHiens.ToList());
                        //currentchiphi.tblChiPhiThucHiens.Clear();
                    }
                    if (currentchiphi.tblcnChiThuLaos.Count == 0)
                    {
                        tblcnChiThuLao chiThuLao =ChiThuLao_Factory.New().CreateAloneObject();
                        chiThuLao.HoanTat = false;
                        chiThuLao.MaBoPhanNhan = currentchiphi.MaBoPhan.Value;
                        chiThuLao.SoTien = currentchiphi.SoTien.Value;
                        chiThuLao.NgayThucHienChi = DateTime.Now.Date;
                        chiThuLao.MaLoaiKinhPhi = currentchiphi.MaLoaiChi;

                        //BS

                        chiThuLao.TenBoPhanNhan = BoPhan_Factory.New().Get_ByID(currentchiphi.MaBoPhan.Value).TenBoPhan;//
                        chiThuLao.MaChuongTrinh = currentchiphi.MaChuongTrinh;
                        chiThuLao.TenChuongTrinh = currentchiphi.tblnsChuongTrinh.TenChuongTrinh;
                        chiThuLao.MaBoPhanGui = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
                        chiThuLao.TenBoPhanGui = BoPhan_Factory.New().Get_ByID(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan;
                        chiThuLao.NgayLap = DateTime.Now.Date;
                        chiThuLao.NguoiLap = _nguoilap;
                        chiThuLao.SoTienDaNhap = 0;
                        chiThuLao.SoTienDaNhapNgoaiDai = 0;
                        chiThuLao.SoTienSeNhap = 0;
                        chiThuLao.SoTienSeNhapNgoaiDai = 0;
                        chiThuLao.SoTienConLai = chiThuLao.SoTien;

                        chiThuLao.SoChungTu = _chungTu.SoChungTu;
                        chiThuLao.MaChungTu = _chungTu.MaChungTu;
                        //Lấy dữ liệu cho chi phí thù lao chương trình
                        currentchiphi.tblcnChiThuLaos.Add(chiThuLao);
                    }
                    else
                    {
                        foreach (tblcnChiThuLao ctl in currentchiphi.tblcnChiThuLaos)
                        {

                            ctl.MaBoPhanNhan = currentchiphi.MaBoPhan.Value;
                            ctl.SoTien = currentchiphi.SoTien.Value;
                            ctl.MaLoaiKinhPhi = currentchiphi.MaLoaiChi;

                            //BS

                            ctl.TenBoPhanNhan = BoPhan_Factory.New().Get_ByID(currentchiphi.MaBoPhan.Value).TenBoPhan;//
                            ctl.MaChuongTrinh = currentchiphi.MaChuongTrinh;
                            ctl.MaBoPhanGui = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
                            ctl.TenBoPhanGui = BoPhan_Factory.New().Get_ByID(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan;

                        }
                    }
                }
            //}
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (clickgriview)
            {
                #region MyRegion
                if (e.FocusedColumn.FieldName == "MaChuongTrinh"
                            || e.FocusedColumn.FieldName == "MaTaiKhoan"
                            || (e.FocusedColumn.FieldName == "MaLoaiChi" 
                                    && gridView1.Columns["MaLoaiChi"].OptionsColumn.AllowEdit==true)
                            || e.FocusedColumn.FieldName == "MaBoPhan"
                            )
                {
                    gridView1.ShowEditor();
                    ((GridLookUpEdit)gridView1.ActiveEditor).ShowPopup();
                }
                #endregion

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (CheckChiThuLaoChuaSuDung() == false)
            {
                LockGrig();
            }
            else
            {
                UnLockGrig();
            }
        }

        #endregion

        #region Events

        private void frmChiPhiSanXuatChuongTrinhE_Load(object sender, EventArgs e)
        {
            LoadDaTa();
        }

        private void frmChiPhiSanXuatChuongTrinhE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsSave == false)
            {
                if (_daTapHopChiPhiSanXuat)
                {
                    MessageBox.Show("Hãy lưu trước khi thoát!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            tblCT_ChiPhiSanXuat chiPhiSX = CT_ChiPhiSanXuat_Factory.New().CreateAloneObject();
            _chungTu.tblCT_ChiPhiSanXuat.Add(chiPhiSX);
            _butToan.tblCT_ChiPhiSanXuat.Add(chiPhiSX);
            tblCTChiPhiSanXuatBindingSource.Add(chiPhiSX);
            tblCTChiPhiSanXuatBindingSource.MoveLast();
            setvaluesDefault(chiPhiSX);
            //
            tblCTChiPhiSanXuatBindingSource.DataSource = _butToan.tblCT_ChiPhiSanXuat;
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _chungTu.tblCT_ChiPhiSanXuat.Clear();
            _butToan.tblCT_ChiPhiSanXuat.Clear();
            foreach (tblCT_ChiPhiSanXuat cp in _ct_ChiPhiSanXuatListFirst)
            {
                _chungTu.tblCT_ChiPhiSanXuat.Add(cp);
                _butToan.tblCT_ChiPhiSanXuat.Add(cp);
            }
            frmBangKeE._chiThuLaoList_DaChon.Clear();
            foreach (spd_DanhSachChiPhiSanXuatTheoThang_Result tl in _chiThuLaoListFirst)
            {
                frmBangKeE._chiThuLaoList_DaChon.Add(tl);
            }
            tblCTChiPhiSanXuatBindingSource.DataSource = _butToan.tblCT_ChiPhiSanXuat;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtFocus.Focus();
            if (HopLe())
            {
                _ct_ChiPhiSanXuatListFirst = _butToan.tblCT_ChiPhiSanXuat.ToList<tblCT_ChiPhiSanXuat>();
                _chiThuLaoListFirst = frmBangKeE._chiThuLaoList_DaChon;
                IsSave = true;
                SoTienDaNhap = _tongSotienCPSX;
                this.Close();
            }
        }

        private void btnDSThuLao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmTapHopChiPhiTheoThuLaoE frm = new frmTapHopChiPhiTheoThuLaoE(context: _context, chungTu: _chungTu, butToan: _butToan))
            {
                frm.ShowDialog();
            }
            tblCTChiPhiSanXuatBindingSource.DataSource = _butToan.tblCT_ChiPhiSanXuat;
            foreach (tblCT_ChiPhiSanXuat cp in _butToan.tblCT_ChiPhiSanXuat)
            {
                if (cp.TaoTuTapHopCPSX)
                {
                    _daTapHopChiPhiSanXuat = true;
                    break;
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XoaCPSXdaChon();
        }




        #endregion//Event

        #region Constructors
        public frmChiPhiSanXuatChuongTrinhE()
        {
            InitializeComponent();
        }

        public frmChiPhiSanXuatChuongTrinhE(Entities context, tblChungTu chungTu, tblButToan butToan)
        {
            InitializeComponent();
            KhoiTao();
            _context = context;
            _chungTu = chungTu;
            _butToan = butToan;
            _chungTu_ChiPhiSanXuatList_Deleted = new List<tblCT_ChiPhiSanXuat>();
            _ct_ChiPhiSanXuatListFirst = _butToan.tblCT_ChiPhiSanXuat.ToList<tblCT_ChiPhiSanXuat>();
            _chiThuLaoListFirst = frmBangKeE._chiThuLaoList_DaChon;

            foreach (tblCT_ChiPhiSanXuat ct_cpsx in _butToan.tblCT_ChiPhiSanXuat)
            {
                if (ct_cpsx.tblChiPhiThucHiens.Count != 0)
                {
                    ct_cpsx.MaLoaiChi = 3;
                }
                else if (ct_cpsx.tblcnChiThuLaos.Count != 0)
                {
                    ct_cpsx.MaLoaiChi = ct_cpsx.tblcnChiThuLaos.FirstOrDefault().MaLoaiKinhPhi;
                    ct_cpsx.MaBoPhan = ct_cpsx.tblcnChiThuLaos.FirstOrDefault().MaBoPhanNhan;
                }
                else
                {
                    ct_cpsx.MaLoaiChi = 0;
                    ct_cpsx.MaBoPhan = 0;
                }
            }
        }

        #endregion//Constructors







    }
}
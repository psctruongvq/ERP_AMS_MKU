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
//26_04_2014
namespace PSC_ERP.ThuChiEntity
{
    public partial class frmChonDeNghiChuyenKhoan : DevExpress.XtraEditors.XtraForm
    {

        #region properties

        Entities _context = null;
        tblChungTu _chungTu = null;
        List<spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result> _deNghiList = null;
        List<spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result> _deNghiListbinding = null;
        int _userId = 0;
        bool _save;
        public bool Save
        {
            get
            {
                return _save;
            }
        }

        #endregion
        #region Function
        private void KhoiTao()
        {

            AllDoiTuong_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.sp_AllDoiTuong_Result);
            AllDoiTuong_bindingSource.DataSource = _context.sp_AllDoiTuong(0).Where(x => x.Loai == 2 || x.Loai==3).ToList();
            BoPhanbindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblnsBoPhan);
            BoPhanbindingSource.DataSource = _context.tblnsBoPhans.ToList();

            DeNghiList_bindingSource.DataSource = typeof(spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result);
            _deNghiList = _context.spd_Select_DeNghiChuyenKhoan_ChuaLapCT((int?)_userId).ToList();
            _deNghiListbinding = new List<spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result>();
            foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in _deNghiList)
            {
                if (_chungTu.tblChungTu_DeNghiChuyenKhoan.Where(x => x.MaDeNghiChuyenKhoan == dn.MaPhieu).Count() == 0
                    && _chungTu.tblChungTu_GiayBaoCo.Where(x => x.MaGiayBaoCo == dn.MaPhieu).Count() == 0
                    && _chungTu.tblChungTu_GiayBanNT.Where(x => x.MaPhieu == dn.MaPhieu).Count() == 0
                    && _chungTu.tblChungTu_LenhChuyenTien.Where(x => x.MaLenhCT == dn.MaPhieu).Count() == 0
                    && _chungTu.tblChungTu_UyNhiemChi.Where(x => x.MaUNC == dn.MaPhieu).Count() == 0
                    && _chungTu.tblChungTu_GiayRutTien.Where(x => x.MaGiayRutTien == dn.MaPhieu).Count() == 0
                    )
                {
                    _deNghiListbinding.Add(dn);
                }
            }
            DeNghiList_bindingSource.DataSource = _deNghiListbinding;

            DesignGrid();
            #region Set Màu chữ để phân biệt các loại
            //if (gridView1.RowCount > 0)
            //{
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //    {
            //        spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn=gridView1.GetRow(i) as spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result;

            //        if (dn.LoaiCT == 2)
            //        {
            //          (()gridView1.GetRow(i)).a
            //            grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.Green;
            //            //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Green;
            //        }
            //        else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 3)
            //        {
            //            grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.Blue;
            //            //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
            //        }
            //        else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 4)
            //        {
            //            grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.Orange;
            //            //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
            //        }
            //        else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 5)
            //        {
            //            grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.DarkGoldenrod;
            //            //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
            //        }
            //        else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 6)
            //        {
            //            grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.LightSeaGreen;
            //            //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
            //        }
            //        else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 7)
            //        {
            //            grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.DarkRed;
            //            //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
            //        }
            //        else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 8)
            //        {
            //            grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.Brown;
            //            //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
            //        }
            //    }
            //}
            #endregion//

        }

        private bool KiemTraDongNhat(List<spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result> deNghiChuyenKhoanList, ref int iLoaiChungTu)
        {
            foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in deNghiChuyenKhoanList)
            {
                if (dn.Chon)
                {
                    if (iLoaiChungTu == 0)
                    {
                        iLoaiChungTu = dn.LoaiCT;
                    }
                    else
                    {
                        if (iLoaiChungTu != dn.LoaiCT)
                            return false;
                    }
                }
            }
            return true;
        }

        private bool KiemTraDongNhat_Ngay(List<spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result> deNghiChuyenKhoanList, ref DateTime _ngay)
        {
            DateTime? Ngay = null;
            foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in deNghiChuyenKhoanList)
            {
                if (dn.Chon)
                {
                    if (Ngay == null)
                    {
                        if (dn.NgayXacNhan != null)
                            Ngay = dn.NgayXacNhan;
                    }
                    else
                    {
                        if (Ngay != dn.NgayXacNhan && dn.NgayXacNhan != null)
                        {
                            _ngay = (DateTime)dn.NgayXacNhan;
                            return false;
                        }
                    }
                }
            }
            if (Ngay == null)
            {
                _ngay = DateTime.Today;
            }
            else
            {
                _ngay = (DateTime)Ngay;
            }
            return true;
        }

        private void GetDienGiai(spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn, ref string strDienGiai)
        {
            //Lưu diễn giải
            if (strDienGiai != string.Empty)
            {
                strDienGiai += ", " + dn.LyDo;
            }
            else
            {
                strDienGiai += dn.LyDo;
            }
        }

        private void DesignGrid()
        {
            //gridView2.Columns.Clear();
            gridControl2.DataSource = DeNghiList_bindingSource;

            HamDungChung.InitGridViewDev(gridView2, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView2, new string[] { "Chon", "LoaiChungTuString", "NgayXacNhan", "So", "Ngay", "SoTien", "TyGia", "SoTienConLai", "LyDo", "MaBoPhan", "MaNhanVien", "NganHangChuyen", "TenNguoiNhan" },
                                new string[] { "Chọn","Loại chứng từ","Ngày xác nhận","Số","Ngày","Số tiền","Tỷ giá","Thành tiền","Lý do","Bộ phận","Nhân viên","Ngân hàng chuyển","Tên đơn vị nhận tiền" },
                                             new int[] { 60, 150, 85, 120, 75, 100, 60, 100, 200, 150, 150, 150, 150 },false);


            HamDungChung.AlignHeaderColumnGridViewDev(gridView2, new string[] { "Chon", "LoaiChungTuString", "NgayXacNhan", "So", "Ngay", "SoTien", "TyGia", "SoTienConLai", "LyDo", "MaBoPhan", "MaNhanVien", "NganHangChuyen", "TenNguoiNhan" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView2, new string[] { "SoTien", "SoTienConLai" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView2, new string[] { "SoTien", "SoTienConLai" }, "{0:#,###.#}");
            //HamDungChung.NewRowGridViewDev(gridView2, NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(gridView2, 50);//M

            //
            RepositoryItemGridLookUpEdit BoPhan_grdLU = new RepositoryItemGridLookUpEdit();
            BoPhan_grdLU.DataSource = AllDoiTuong_bindingSource;
            BoPhan_grdLU.DisplayMember = "TenBoPhan";
            BoPhan_grdLU.ValueMember = "MaBoPhan";
            HamDungChung.InitRepositoryItemGridLookUpDev(BoPhan_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(BoPhan_grdLU, new string[] {"TenBoPhan" }, new string[] { "" }, new int[] {200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView2, "MaBoPhan", BoPhan_grdLU);
            //
            RepositoryItemGridLookUpEdit DoiTuong_grdLU = new RepositoryItemGridLookUpEdit();
            DoiTuong_grdLU.DataSource = AllDoiTuong_bindingSource;
            DoiTuong_grdLU.DisplayMember = "TenDoiTuong";
            DoiTuong_grdLU.ValueMember = "MaDoiTuong";
            HamDungChung.InitRepositoryItemGridLookUpDev(DoiTuong_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuong_grdLU, new string[] { "TenDoiTuong" }, new string[] { "" }, new int[] { 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView2, "MaNhanVien", DoiTuong_grdLU);

            //this.gridView2.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            //this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            //this.gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            //this.gridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView2);
            ////this.gridView2.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);

            ////this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
        }

        #endregion

        #region EventHandle


        #endregion
        public frmChonDeNghiChuyenKhoan()
        {
            InitializeComponent();
        }

        public frmChonDeNghiChuyenKhoan(Entities context, tblChungTu chungtu, int userId)
        {
            InitializeComponent();
            _context = context;
            _chungTu = chungtu;
            _userId = userId;
            KhoiTao();
        }

        private void frmTamUng_Load(object sender, EventArgs e)
        {

        }



        private void frmTamUng_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!_save)
            {
                DialogResult kq = MessageBox.Show("Bạn thật sự muốn đóng không chọn?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (kq == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (kq == DialogResult.OK)
                {
                    _save = false;
                }
            }
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            bool next = false;
            this.Focus1.Focus();

            if (_deNghiListbinding.Count == 0)
            {
                return;
            }
            else
            {
                foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in _deNghiListbinding)
                {
                    if (dn.Chon)
                    {
                        next = true;
                        break;
                    }
                }
            }
            if (next)
            {
                #region xuly
                int iLoaiChungTu = 0;
                string strDienGiai = string.Empty;
                long lMaDoiTac = 0;
                _chungTu.tblTienTe.SoTien = 0;
                try
                {
                    //Nếu Chứng Từ Đã Được set loại chứng từ
                    if (_chungTu.LoaiChungTu.Value != 0)
                    {
                        iLoaiChungTu = _chungTu.LoaiChungTu.Value;
                    }
                    //Kiểm tra tính thống nhất của dữ liệu đang được chọn
                    if (!KiemTraDongNhat(_deNghiListbinding, ref iLoaiChungTu))
                    {
                        MessageBox.Show(this, "Chỉ chọn các chứng từ kèm theo của cùng một loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //Kiểm tra tính thống nhất của ngày
                    DateTime ngayLap = _chungTu.NgayLap.Value;
                    if (!KiemTraDongNhat_Ngay(_deNghiListbinding, ref ngayLap))
                    {
                        MessageBox.Show(this, "Ngày xác nhận của các chứng từ không giống nhau.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    _chungTu.NgayLap = ngayLap;
                    _chungTu.LoaiChungTu = iLoaiChungTu;

                    switch (iLoaiChungTu)
                    {
                        case 1: //Đề nghị chuyển khoản
                            foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in _deNghiListbinding)
                            {
                                if (dn.Chon)
                                {
                                    //Khúc này để tính tổng số tiền đưa qua bảng kê, còn xài đừng có xóa
                                    //ChiTietChungTuNganHangList chitiet = ChiTietChungTuNganHangList.GetChiTietChungTuNganHangList_ByDeNghiChuyenKhoan(dn.MaPhieu);
                                    //foreach (ChiTietChungTuNganHang ct in chitiet)
                                    //{
                                    //    _chungTu.SoTien += (ct.SoTien * ct.TyGia);
                                    //}
                                    tblChungTu_DeNghiChuyenKhoan chungTuDeNghi = new tblChungTu_DeNghiChuyenKhoan { MaDeNghiChuyenKhoan = dn.MaPhieu, SoTien = dn.ThanhTien.Value, Loai = dn.LoaiCT, SoChungTu = dn.So, LyDo = dn.LyDo };
                                    _chungTu.tblChungTu_DeNghiChuyenKhoan.Add(chungTuDeNghi);
                                    _chungTu.tblTienTe.SoTien += dn.ThanhTien.Value;

                                    //Lưu diễn giải
                                    GetDienGiai(dn, ref strDienGiai);


                                    ////Lấy Mã Đối Tác
                                    if (tblDeNghiChuyenKhoan_Factory.New().Get_DeNghiChuyenKhoan_ByMaPhieu(dn.MaPhieu).tblDeNghiChuyenKhoan_DichVu.Count > 0 && lMaDoiTac == 0)
                                    {
                                        lMaDoiTac = tblDeNghiChuyenKhoan_Factory.New().Get_DeNghiChuyenKhoan_ByMaPhieu(dn.MaPhieu).tblDeNghiChuyenKhoan_DichVu.First().MaDoiTac.Value;
                                    }
                                }
                            }
                            break;

                        case 2: //Giấy báo co
                            foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in _deNghiListbinding)
                            {
                                if (dn.Chon)
                                {
                                    tblChungTu_GiayBaoCo chungTu_GBC = new tblChungTu_GiayBaoCo { MaGiayBaoCo = Convert.ToInt32(dn.MaPhieu), SoTien = dn.ThanhTien, SoChungTu = dn.So, LyDo = dn.LyDo };
                                    _chungTu.tblChungTu_GiayBaoCo.Add(chungTu_GBC);
                                    _chungTu.tblTienTe.SoTien += dn.ThanhTien.Value;

                                    //Lấy Mã Đối Tác
                                    lMaDoiTac = tblGiayBaoCo_Factory.New().Get_GiayBaoCo_ByMaGBC((int)dn.MaPhieu).madoitac.Value;

                                    //Lưu diễn giải
                                    GetDienGiai(dn, ref strDienGiai);
                                }
                            }
                            break;

                        case 3: //Giấy bán ngoại tệ
                            foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in _deNghiListbinding)
                            {
                                if (dn.Chon)
                                {
                                    tblChungTu_GiayBanNT chungTu_GBNT = new tblChungTu_GiayBanNT { MaPhieu = dn.MaPhieu, SoTien = dn.ThanhTien, SoChungTu = dn.So, LyDo = dn.LyDo };
                                    _chungTu.tblChungTu_GiayBanNT.Add(chungTu_GBNT);
                                    _chungTu.tblTienTe.SoTien += dn.ThanhTien.Value;

                                    //Lưu diễn giải
                                    GetDienGiai(dn, ref strDienGiai);
                                }
                            }
                            break;

                        case 4: //Lệnh chuyển tiền
                            foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in _deNghiListbinding)
                            {
                                if (dn.Chon)
                                {
                                    tblChungTu_LenhChuyenTien chungTu_LenhCT = new tblChungTu_LenhChuyenTien { MaLenhCT = dn.MaPhieu, SoTien = dn.ThanhTien, SoChungTu = dn.So, LyDo = dn.LyDo };
                                    _chungTu.tblChungTu_LenhChuyenTien.Add(chungTu_LenhCT);
                                    _chungTu.tblTienTe.SoTien += dn.ThanhTien.Value;

                                    lMaDoiTac = tblLenhChuyenTienNuocNgoai_Factor.New().Get_LenhChuyenTienNuocNgoai_ByMaLenhCT(dn.MaPhieu).MaDoiTac.Value;
                                    //Lưu diễn giải
                                    GetDienGiai(dn, ref strDienGiai);
                                }
                            }
                            break;

                        case 5:
                        case 8: //Uy Nhiệm Chi
                            foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in _deNghiListbinding)
                            {
                                if (dn.Chon)
                                {
                                    tblChungTu_UyNhiemChi chungtu_UyNhiemChi = new tblChungTu_UyNhiemChi { MaUNC = Convert.ToInt32(dn.MaPhieu), SoTien = dn.ThanhTien, SoChungTu = dn.So, LyDo = dn.LyDo };
                                    _chungTu.tblChungTu_UyNhiemChi.Add(chungtu_UyNhiemChi);
                                    _chungTu.tblTienTe.SoTien += dn.ThanhTien.Value;

                                    GetDienGiai(dn, ref strDienGiai);
                                }
                            }
                            break;

                        case 6: //Phí ngân hàng
                            foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in _deNghiListbinding)
                            {
                                if (dn.Chon)
                                {
                                    tblChungTu_GiayBaoCo chungTu_GBC = new tblChungTu_GiayBaoCo { MaGiayBaoCo = Convert.ToInt32(dn.MaPhieu), SoTien = dn.ThanhTien, SoChungTu = dn.So, LyDo = dn.LyDo };
                                    _chungTu.tblChungTu_GiayBaoCo.Add(chungTu_GBC);
                                    _chungTu.tblTienTe.SoTien += dn.ThanhTien.Value;

                                    ////Lấy Mã Đối Tác
                                    lMaDoiTac = tblGiayBaoCo_Factory.New().Get_GiayBaoCo_ByMaGBC((int)dn.MaPhieu).madoitac.Value;
                                    //Lưu diễn giải
                                    GetDienGiai(dn, ref strDienGiai);
                                }
                            }
                            break;

                        case 7: //Giấy rút tiền
                            foreach (spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result dn in _deNghiListbinding)
                            {
                                if (dn.Chon)
                                {
                                    tblChungTu_GiayRutTien Chungtu_GRT = new tblChungTu_GiayRutTien { MaGiayRutTien = Convert.ToInt32(dn.MaPhieu), SoTien = dn.ThanhTien, SoChungTu = dn.So, LyDo = dn.LyDo };
                                    _chungTu.tblChungTu_GiayRutTien.Add(Chungtu_GRT);
                                    _chungTu.tblTienTe.SoTien += dn.ThanhTien.Value;//Lấy Mã Đối Tác

                                    //Lưu diễn giải
                                    GetDienGiai(dn, ref strDienGiai);
                                }
                            }
                            break;

                        default: break;
                    }

                    _chungTu.DienGiai = strDienGiai;
                    if (lMaDoiTac != 0)
                        _chungTu.MaDoiTuong = lMaDoiTac;
                    _save = true;
                    this.Close();
                }
                catch (Exception)
                {

                    throw;

                }
                #endregion  //Xuly

            }
            else
            {
                MessageBox.Show("Hãy chọn đề nghị!", "Thông Báo");
            }
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }








    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using System.Collections;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using System.IO;
using System.Data.OleDb;
namespace PSC_ERP
{
    public partial class frmKhenThuongNhanVien_ChuyenKhoan : Form
    {
        BoPhanList _boPhanList;
        LoaiPhuCapList _loaiPhuCapList;
        KyTinhLuongList _kyTinhLuongList;
        ThongTinNhanVienTongHopList _nhanVienList;
        PhuCapNhanVienList _phuCapNhanVienList;
        static int maBoPhan = 0;
        static int maKyTinhluong = 0;
        private bool khoaSo = false;
        private int maLoaiPhuCap = 0;

        private bool isimportfromExcel = false;

        #region Bo Sung MaLoai Chi

        private string _thongbaoNhapLoaiPhuCap = string.Empty;
        private int _maLoaiChi = 0;

        private int _maKyPhuCap = 0;

        private List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> _nhanVienChuaTruyThuList;

        private void SetTieuDe_ThongBaoNhapLoaiPhuCap()
        {
            if (_maLoaiChi == 2)
            {
                this.Text = "Khen Thưởng Nhân Viên - Chuyển Khoản";
                lbLoaiPhuCap.Text = "Loại khen thưởng ";
                _thongbaoNhapLoaiPhuCap = "Vui Lòng nhập Loại Khen Thưởng";
            }
            else if (_maLoaiChi == 4)
            {
                this.Text = "Phụ Cấp Nhân Viên - Chuyển Khoản";
                lbLoaiPhuCap.Text = "Loại phụ cấp ";
                _thongbaoNhapLoaiPhuCap = "Vui Lòng nhập Loại Phụ Cấp";
            }
            else if (_maLoaiChi == 5)
            {
                this.Text = "Truy Lĩnh Nhân Viên - Chuyển Khoản";
                lbLoaiPhuCap.Text = "Loại truy lĩnh ";
                _thongbaoNhapLoaiPhuCap = "Vui Lòng nhập Loại Truy Lĩnh";

            }
            else if (_maLoaiChi == 6)
            {
                this.Text = "Truy Thu Nhân Viên - Chuyển Khoản";
                lbLoaiPhuCap.Text = "Loại truy thu ";
                _thongbaoNhapLoaiPhuCap = "Vui Lòng nhập Loại Truy Thu";

            }
        }



        #region Constructors

        public void ShowKhenThuong()
        {
            _maLoaiChi = 2;//Chi Khen Thuong
            KhoiTao();
            this.Show();
        }

        public void ShowPhuCap()
        {
            _maLoaiChi = 4;//Chi Thu Lao
            KhoiTao();
            this.Show();
        }

        public void ShowTruyLinh()
        {
            _maLoaiChi = 5;//Truy Linh
            tlSbtnExportMau.Visible = true;
            tlSbtnImportTruyThu.Visible = true;
            KhoiTao();
            this.Show();
        }

        public void ShowTruyThu()
        {
            _maLoaiChi = 6;//Truy Thu
            tlSbtnExportMau.Visible = true;
            tlSbtnImportTruyThu.Visible = true;
            KhoiTao();
            this.Show();
        }

        #endregion

        #region Functions

        private bool KiemTraSoTienPhuCapHopLe(long manhavien, string tennhanvien, decimal SoTienPC)
        {
            if (_maLoaiChi == 6)//truy thu
            {
                decimal sotienThucLanh = ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.GetThucLanhSauThueOFNhanVien(maKyTinhluong, manhavien);
                if (sotienThucLanh - SoTienPC < 0)
                {
                    //MessageBox.Show(string.Format("Nhân viên {0} số tiền thực lãnh nhỏ hơn số tiền khấu trừ, không hợp lệ", tennhanvien), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }


        private DataTable ImportExcelXLS(string FileName, bool hasHeaders)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";


            DataTable outputTable = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (!sheet.EndsWith("_"))
                    {
                        try
                        {
                            //OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A6:D]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                }
            }
            return outputTable;
        }

        private void ImportTabletoDSHoaDon(DataTable tblresult)
        {

            #region New
            if (tblresult.Rows.Count > 0)
            {
                foreach (DataRow rowpc in tblresult.Rows)
                {
                    if (rowpc[2].ToString().Trim().Length == 0)//Mã Nhân viên và Số tiền
                    {
                        return;
                    }
                    //Mã Ql Nhân viên
                    string maQLNhanVien; List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> nhanvien;
                    maQLNhanVien = rowpc[2].ToString().Trim();
                    nhanvien = ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.KiemTraMaQLNhanVienTonTai(maQLNhanVien);
                    if (nhanvien.Count <= 0)
                    {
                        MessageBox.Show(string.Format("Mã nhân viên của nhân viên {0}, số TT {1} không tồn tại!", rowpc[1].ToString(), rowpc[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //SoTienPC
                    decimal sotienTT; decimal sotienTTOut;
                    if (decimal.TryParse(rowpc[3].ToString(), out sotienTTOut))
                    {
                        sotienTT = sotienTTOut;
                        if (sotienTT >= 1000000)
                        {
                            if (MessageBox.Show(string.Format("Số tiền truy thu của nhân viên {0}, số TT {1} >= 1000.000, Bạn có muốn import nhân viên này?!", rowpc[1].ToString(), rowpc[0].ToString()), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Số tiền truy thu của nhân viên {0}, số TT {1} không hợp lệ!", rowpc[1].ToString(), rowpc[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    //
                    PhuCapNhanVien phuCapNhanVien = PhuCapNhanVien.NewPhuCapNhanVien();
                    phuCapNhanVien.MaKyTinhLuong = maKyTinhluong;
                    if (cbLoaiPhuCap.ActiveRow != null)
                        phuCapNhanVien.MaLoaiPhuCap = (int)cbLoaiPhuCap.ActiveRow.Cells["MaLoaiPhuCap"].Value;
                    phuCapNhanVien.TenPhuCap = cbLoaiPhuCap.Text;
                    phuCapNhanVien.DienGiai = cbLoaiPhuCap.Text;
                    phuCapNhanVien.SoQuyetDinh = txt_SoQuyetDinh.Text;
                    phuCapNhanVien.MaNhanVien = nhanvien[0].MaNhanVien;
                    phuCapNhanVien.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                    phuCapNhanVien.TinhThueTNCN = true;
                    phuCapNhanVien.TenNhanVien = nhanvien[0].TenNhanVien;
                    phuCapNhanVien.MaPhieuChi = "";
                    phuCapNhanVien.ThanhToan = true;
                    phuCapNhanVien.MaBoPhan = NhanVien.GetNhanVien(phuCapNhanVien.MaNhanVien).MaBoPhan;
                    phuCapNhanVien.PhuCap = sotienTT;
                    _phuCapNhanVienList.Add(phuCapNhanVien);

                }
                this.BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
                this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();
            }
            #endregion//New

        }

        #endregion Functions
        private void Show_HideControlForTruyThu(bool isShow)
        {
            lbKyPC.Visible = isShow;
            cbKyPhuCap.Visible = isShow;
            lbKyPC.Enabled = isShow;
            cbKyPhuCap.Enabled = isShow;
            tlSTinhTruyThu.Visible = isShow;
            tlSbtnDSNVChuaTruyThu.Visible = isShow;
        }

        private void Show_HideControlForTruyLinh(bool isShow)
        {
            lbKyPC.Visible = isShow;
            cbKyPhuCap.Visible = isShow;
            lbKyPC.Enabled = isShow;
            cbKyPhuCap.Enabled = isShow;
            tlSTinhTruyLinh.Visible = isShow;
            tlSbtnNVChuaTruyLinh.Visible = isShow;
        }

        private void CustomizeShow_HideControlForTruyLinh()
        {
            if (_maLoaiChi == 5)//TruyLinh
            {
                if (isTruyLinhDoNangLuongCB())
                {
                    Show_HideControlForTruyLinh(true);
                }
                else
                {
                    Show_HideControlForTruyLinh(false);
                }
            }
            else if (_maLoaiChi == 6)//TruyThu
            {
                if (isTruyThuBaoHiem())
                {
                    Show_HideControlForTruyThu(true);
                }
                else
                {
                    Show_HideControlForTruyThu(false);
                }
            }
        }

        private void Unlock_LockControlAfterTinhTruyThuTruyLinh(bool isunLock)
        {
            if ((_maLoaiChi == 5 && isTruyLinhDoNangLuongCB()) || (_maLoaiChi == 6 && isTruyThuBaoHiem()))//TruyLinh or Truy Thu
            {
                lbKyPC.Enabled = isunLock;
                cbKyPhuCap.Enabled = isunLock;
                ultraGrid1.Enabled = isunLock;
                cbLoaiPhuCap.Enabled = isunLock;
            }
            else
            {
                ultraGrid1.Enabled = true;
                cbLoaiPhuCap.Enabled = true;
            }
        }


        private bool isTruyThuBaoHiem()
        {
            if (maLoaiPhuCap == 414)
            {
                return true;
            }
            return false;
        }

        private bool isTruyLinhDoNangLuongCB()
        {
            return ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.CheckIsTruyLinhDoNangLuongCB(maLoaiPhuCap);
        }

        #endregion

        public frmKhenThuongNhanVien_ChuyenKhoan()
        {
            InitializeComponent();

            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);
            LoạiKhenThuongList_BindingSouce.DataSource = typeof(LoaiPhuCapList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.KyPhuCap_bindingSource.DataSource = typeof(KyTinhLuongList);
            BangLuong_PhuCapList_BindingSouce.DataSource = typeof(PhuCapNhanVienList);
            bindingSource1_NhanVien.DataSource = typeof(ThongTinNhanVienTongHopList);

            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            //grdu_QuocGia.BeforeRowsDeleted += new BeforeRowsDeletedEventHandler(grdu_QuocGia_BeforeRowsDeleted);
            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);

            //KhoiTao();
        }


        public frmKhenThuongNhanVien_ChuyenKhoan(int _maKyTinhLuong, int _maLoaiPhuCap, string _soQuyetDinh, string _maPhieuChi)
        {
            InitializeComponent();

            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            // grdu_QuocGia.BeforeRowsDeleted += new BeforeRowsDeletedEventHandler(grdu_QuocGia_BeforeRowsDeleted);
            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            KhoiTao();
            cbKyTinhLuong.Value = _maKyTinhLuong;
            cbLoaiPhuCap.Value = _maLoaiPhuCap;
            txt_SoQuyetDinh.Text = _soQuyetDinh;
            _phuCapNhanVienList.Clear();
            _phuCapNhanVienList = PhuCapNhanVienList.GetNhapPhuCapListByNgay(_maKyTinhLuong, _maLoaiPhuCap, _soQuyetDinh, _maPhieuChi, true);
            BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
            maKyTinhluong = _maKyTinhLuong;
            maLoaiPhuCap = _maLoaiPhuCap;
            khoaSo = KyTinhLuong.GetKyTinhLuong(maKyTinhluong).KhoaSoKy2;
            this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();

        }

        public frmKhenThuongNhanVien_ChuyenKhoan(int _maKyTinhLuong, int _maLoaiPhuCap, string _soQuyetDinh, string _maPhieuChi, int maLoaiChi,DateTime ngayLap)
        {
            InitializeComponent();
            _maLoaiChi = maLoaiChi;//
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            // grdu_QuocGia.BeforeRowsDeleted += new BeforeRowsDeletedEventHandler(grdu_QuocGia_BeforeRowsDeleted);
            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            KhoiTao();
            cbKyTinhLuong.Value = _maKyTinhLuong;
            cbLoaiPhuCap.Value = _maLoaiPhuCap;
            txt_SoQuyetDinh.Text = _soQuyetDinh;
            _phuCapNhanVienList.Clear();
            //_phuCapNhanVienList = PhuCapNhanVienList.GetNhapPhuCapListByNgay(_maKyTinhLuong, _maLoaiPhuCap, _soQuyetDinh, _maPhieuChi, true,ngayLap);
            _phuCapNhanVienList = PhuCapNhanVienList.GetNhapPhuCapListByNgayChuyenKhoan_MaLoaiChi(_maKyTinhLuong, _maLoaiPhuCap, _soQuyetDinh, _maPhieuChi, true, ngayLap);
            BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
            maKyTinhluong = _maKyTinhLuong;
            maLoaiPhuCap = _maLoaiPhuCap;
            dateTimePicker_NgayLap.Value = ngayLap;
            khoaSo = KyTinhLuong.GetKyTinhLuong(maKyTinhluong).KhoaSoKy2;
            this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();
            //cbKyPhuCap.Value = _phuCapNhanVienList[0].MaKyPhuCap;
            Unlock_LockControlAfterTinhTruyThuTruyLinh(false);

        }
        public void KhoiTao()
        {
            SetTieuDe_ThongBaoNhapLoaiPhuCap();//
            _boPhanList = BoPhanList.GetBoPhanListByAll();
            BoPhan _boPhanAdd = BoPhan.NewBoPhan(0, "Tất Cả");
            _boPhanList.Insert(0, _boPhanAdd);
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            _loaiPhuCapList = LoaiPhuCapList.GetLoaiPhuCapListByMaLoaiChi(_maLoaiChi);
            //_loaiPhuCapList = LoaiPhuCapList.GetLoaiPhuCapListByThuong();
            LoạiKhenThuongList_BindingSouce.DataSource = _loaiPhuCapList;
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
            if (_maLoaiChi == 5 || _maLoaiChi == 6)
            {
                this.KyPhuCap_bindingSource.DataSource = KyTinhLuongList.GetKyTinhLuongList();

            }
            _phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
            BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
            maBoPhan = 0;
            maLoaiPhuCap = 0;
            maKyTinhluong = 0;
            dateTimePicker_NgayLap.Value = DateTime.Today.Date;
            _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            bindingSource1_NhanVien.DataSource = _nhanVienList;

            _nhanVienChuaTruyThuList = new List<ERP_Library.ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbu_Bophan.ActiveRow != null)
                {
                    maBoPhan = (int)cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value;
                }
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, false);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void chkAlldanhsach_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlldanhsach.Checked == true)
            {
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    if (!ultraGrid1.Rows[i].Hidden == true)
                    {
                        ultraGrid1.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    ultraGrid1.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (maLoaiPhuCap != 0 && maKyTinhluong != 0
                //&& txt_SoQuyetDinh.Text != ""
                )
            {
                DialogResult _DialogResult = MessageBox.Show("Bạn Có Đồng Ý Đứa Nhân Viên Qua", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_DialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid1.Rows[i].Cells["Check"].Value == true)
                        {

                            PhuCapNhanVien phuCapNhanVien = PhuCapNhanVien.NewPhuCapNhanVien();
                            phuCapNhanVien.MaKyTinhLuong = maKyTinhluong;
                            if (cbLoaiPhuCap.ActiveRow != null)
                                phuCapNhanVien.MaLoaiPhuCap = (int)cbLoaiPhuCap.ActiveRow.Cells["MaLoaiPhuCap"].Value;
                            phuCapNhanVien.TenPhuCap = cbLoaiPhuCap.Text;
                            phuCapNhanVien.DienGiai = cbLoaiPhuCap.Text;
                            phuCapNhanVien.SoQuyetDinh = txt_SoQuyetDinh.Text;
                            phuCapNhanVien.MaNhanVien = (long)ultraGrid1.Rows[i].Cells["MaNhanVien"].Value;
                            phuCapNhanVien.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                            phuCapNhanVien.TinhThueTNCN = true;
                            phuCapNhanVien.TenNhanVien = (string)ultraGrid1.Rows[i].Cells["TenNhanVien"].Value;
                            phuCapNhanVien.MaPhieuChi = "";
                            phuCapNhanVien.ThanhToan = true;
                            phuCapNhanVien.MaBoPhan = NhanVien.GetNhanVien(phuCapNhanVien.MaNhanVien).MaBoPhan;
                            _phuCapNhanVienList.Add(phuCapNhanVien);

                        }
                    }
                    this.BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
                    this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();

                    for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid1.Rows[i].Cells["Check"].Value == true)
                        {
                            ultraGrid1.Rows[i].Cells["Check"].Value = false;
                            ultraGrid1.Rows[i].Hidden = true;
                        }
                    }
                    this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (txt_SoQuyetDinh.Text == "")
                {
                    MessageBox.Show("Vui Lòng Nhập Số Quyết Định", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_SoQuyetDinh.Focus();
                    return;
                }
                else if (maLoaiPhuCap == 0)
                {
                    MessageBox.Show("Vui Lòng Loại Khen Thưởng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaiPhuCap.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Vui Lòng Chọn Kỳ Tính Lương ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbKyTinhLuong.Focus();
                    return;
                }
            }
        }


        private void ComBoChangedValue()
        {

        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            try
            {
                if (khoaSo == true)
                {
                    MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (maKyTinhluong == 0)
                    {
                        MessageBox.Show("Vui Lòng Chọn Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbKyTinhLuong.Focus();
                        return;
                    }

                    else if (maLoaiPhuCap == 0)
                    {
                        MessageBox.Show("Vui Lòng Chọn Loại Khen Thưởng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbKyTinhLuong.Focus();
                        return;
                    }
                    else if (_maLoaiChi == 6 && ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.KiemTraDaLapDeNghiChuyenKhoanLuongKy1(maKyTinhluong, 0,1))
                    {
                        MessageBox.Show("Kỳ tính lương này đã lập đề nghị chuyển khoản, không thể cập nhật!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }//Ap dung cho Truy Thu


                    //else if (txt_SoQuyetDinh.Text == "")
                    //{
                    //    MessageBox.Show("Vui Lòng Nhập Quyết Định", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    txt_SoQuyetDinh.Focus();
                    //    return;
                    //}


                    foreach (PhuCapNhanVien pc in _phuCapNhanVienList)
                    {
                        //if (KiemTraSoTienPhuCapHopLe(pc.MaNhanVien, pc.TenNhanVien, pc.PhuCap) == false) return;

                        pc.MaKyTinhLuong = maKyTinhluong;
                        pc.MaLoaiPhuCap = maLoaiPhuCap;
                        pc.MaPhieuChi = "";
                        pc.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                        pc.SoQuyetDinh = txt_SoQuyetDinh.Text;
                        pc.ThanhToan = true;
                        pc.TinhThueTNCN = true;
                        pc.TenPhuCap = cbLoaiPhuCap.Text;
                    }
                    _phuCapNhanVienList.ApplyEdit();
                    BangLuong_PhuCapList_BindingSouce.EndEdit();
                    _phuCapNhanVienList.Save();
                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _nhanVienChuaTruyThuList = new List<ERP_Library.ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }



        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComBoChangedValue();
        }


        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblNew_Click(object sender, EventArgs e)
        {
            //KhoiTao(); 
            #region Replace KhoiTao
            _phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
            BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
            dateTimePicker_NgayLap.Value = DateTime.Today.Date;
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhluong = (int)cbKyTinhLuong.Value;
                khoaSo = KyTinhLuong.GetKyTinhLuong(maKyTinhluong).KhoaSoKy2;
            }
            else
            {
                maKyTinhluong = 0;
            }

            if (cbLoaiPhuCap.Value != null)
            {
                maLoaiPhuCap = (int)cbLoaiPhuCap.Value;
            }
            else
            {
                maLoaiPhuCap = 0;

            }

            if (cmbu_Bophan.ActiveRow != null)
            {
                maBoPhan = (int)cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value;
            }
            else
            {
                maBoPhan = 0;
            }
            //_nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, false);
            //this.bindingSource1_NhanVien.DataSource = _nhanVienList;      

            CustomizeShow_HideControlForTruyLinh();
            Unlock_LockControlAfterTinhTruyThuTruyLinh(true);
            _nhanVienChuaTruyThuList = new List<ERP_Library.ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
            #endregion//Replace KhoiTao
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (khoaSo == true)
            {
                MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if ((bool)grdu_QuocGia.Rows[i].Cells["Check"].Value == true)
                    {
                        grdu_QuocGia.Rows[i].Selected = true;

                        #region Ap dung cho Truy Thu
                        int machitiet = (int)grdu_QuocGia.Rows[i].Cells["MaChiTiet"].Value;
                        if (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.KiemTraDaLapDeNghiChuyenKhoanLuongKy1(maKyTinhluong, machitiet,1))
                        {
                            MessageBox.Show("Kỳ tính lương này đã lập đề nghị chuyển khoản, không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        #endregion Ap dung cho Truy Thu
                    }

                }
                grdu_QuocGia.DeleteSelectedRows();
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, false);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void grdu_QuocGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                button2_Click_1(null, null);
                // this.ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                this.grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                this.grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Paste);

            }
        }

        private void grdu_QuocGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            // Turn on all of the Cut, Copy, and Paste functionality. 
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
            // In order to cut or copy, the user needs to select cells or rows. 
            // So set CellClickAction so that clicking on a cell selects that cell
            // instead of going into edit mode.
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;

        }

        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {

                if (e.KeyCode == Keys.Space)
                {
                    if (ultraGrid1.ActiveRow.Cells["Check"].Value.ToString() != "")
                    {
                        if ((bool)ultraGrid1.ActiveRow.Cells["Check"].Value == true)
                            ultraGrid1.ActiveRow.Cells["Check"].Value = false;
                        else
                            ultraGrid1.ActiveRow.Cells["Check"].Value = true;
                    }
                }
            }
        }


        private void ultraGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnthem_Click(null, null);
            }
        }



        private void cmbu_ChucVu_Leave(object sender, EventArgs e)
        {
            if (cbLoaiPhuCap.Value != null)
            {
                maLoaiPhuCap = (int)cbLoaiPhuCap.Value;
                foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
                {
                    tl.MaLoaiPhuCap = maLoaiPhuCap;
                }
            }
        }

        private void cbKyTinhLuong_Leave(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhluong = (int)cbKyTinhLuong.Value;
                khoaSo = KyTinhLuong.GetKyTinhLuong(maKyTinhluong).KhoaSoKy2;
                foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
                {
                    tl.MaKyTinhLuong = maKyTinhluong;
                }
            }
        }
        private void dateTimePicker_NgayLap_Leave(object sender, EventArgs e)
        {

            foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
            {
                tl.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
            }
        }

        private void txt_SoQuyetDinh_TextChanged(object sender, EventArgs e)
        {
            foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
            {
                tl.SoQuyetDinh = txt_SoQuyetDinh.Text;
            }
        }



        private void grdu_QuocGia_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (isimportfromExcel) return;
            //cập nhật lại số tiền
            if (e.Cell.Column.Key == "PhuCap")
            {
                e.Cell.Row.Cells["SoTien"].Value = e.Cell.Value;
                if (((decimal)e.Cell.Value) >= 1000000)
                    MessageBox.Show("Số tiền vượt 1000.000 đồng!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void grdu_QuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_QuocGia.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (grdu_QuocGia.ActiveRow.Cells["Check"].Value.ToString() != "")
                    {
                        if ((bool)grdu_QuocGia.ActiveRow.Cells["Check"].Value == true)
                            grdu_QuocGia.ActiveRow.Cells["Check"].Value = false;
                        else
                            grdu_QuocGia.ActiveRow.Cells["Check"].Value = true;
                    }
                }
            }

            if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9) && grdu_QuocGia.ActiveCell != null && grdu_QuocGia.ActiveCell.Column.DataType == typeof(decimal))
            {
                grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
        }



        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_QuocGia.ActiveCell != null && !grdu_QuocGia.ActiveCell.IsInEditMode && grdu_QuocGia.ActiveCell.Column.Key != "TenNhanVien")
            {
                if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    grdu_QuocGia.ActiveCell.SelectAll();
                    iskeyok = true;
                }
                if (e.KeyCode == Keys.Space && grdu_QuocGia.ActiveCell.Column.DataType == typeof(bool))
                {
                    grdu_QuocGia.ActiveCell.Value = !Convert.ToBoolean(grdu_QuocGia.ActiveCell.Value);
                }
            }
        }

        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iskeyok && grdu_QuocGia.ActiveCell.Row.IsDataRow)
            {
                if (grdu_QuocGia.ActiveCell.Column.DataType == typeof(decimal))
                    try
                    {
                        grdu_QuocGia.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                    }
                    catch
                    { }
                else
                    grdu_QuocGia.ActiveCell.Value = e.KeyChar.ToString();
                grdu_QuocGia.ActiveCell.SelStart = grdu_QuocGia.ActiveCell.Text.Length;
                e.Handled = true;
                iskeyok = false;
            }
        }
        //xử lý copy 1 cell cho nhiều cell
        private bool iscopyok = false;
        private object copyvalue;
        private void grdData_BeforeMultiCellOperation(object sender, Infragistics.Win.UltraWinGrid.BeforeMultiCellOperationEventArgs e)
        {
            if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Copy)
            {
                if (e.Cells.RowCount == 1 && e.Cells.ColumnCount == 1)
                {
                    iscopyok = true;
                    copyvalue = e.Cells[0, 0].Value;
                }
            }
            else
                if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Paste)
                {
                    if (iscopyok && grdu_QuocGia.Selected != null && grdu_QuocGia.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_QuocGia.Selected.Cells)
                        {
                            try
                            {
                                item.Value = copyvalue;
                                item.Row.Update();
                            }
                            catch { }
                        }
                    }
                    iscopyok = false;
                }
        }

        private void cmbu_ChucVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbLoaiPhuCap, "TenLoaiPhuCap");
        }

        private void cbKyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //HamDungChung h = new HamDungChung();
            //h.ultragrdEmail_InitializeLayout(sender, e);
            //e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenChucvu"].Hidden = false;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Quản Lý";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Chứng Minh";
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.Caption = "Chức Vụ";
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 2;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 3;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 4;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.VisiblePosition = 5;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 6;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Width = 40;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 100;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenChucvu"].Width = 100;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 100;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaSoThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        }

        private void cmbu_ChucVu_ValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiPhuCap.ActiveRow != null)
            {
                maLoaiPhuCap = Convert.ToInt32(cbLoaiPhuCap.ActiveRow.Cells["MaLoaiPhuCap"].Value);
                #region BS
                CustomizeShow_HideControlForTruyLinh();
                #endregion//BS
            }
        }

        private void tlSbtnExportMau_Click(object sender, EventArgs e)
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel|*.xls|All file|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Tạo file template
                FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Write(Properties.Resources.MauTruyThuBHXHForImport, 0, Properties.Resources.MauTruyThuBHXHForImport.Length);
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        private void tlSbtnImportTruyThu_Click(object sender, EventArgs e)
        {
            if (maLoaiPhuCap != 0 && maKyTinhluong != 0)
            {
                isimportfromExcel = true;
                #region Old
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                oFD.ShowDialog();
                string path = oFD.FileName;
                string p = System.IO.Path.GetFileName(path);
                DataTable tblResult = ImportExcelXLS(path, true);
                ImportTabletoDSHoaDon(tblResult);
                #endregion//Old

                isimportfromExcel = false;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Mã kỳ lương và Loại Phụ cấp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbKyPhuCap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKyPhuCap, "TenKy");
        }

        private void cbKyPhuCap_Leave(object sender, EventArgs e)
        {
            _maKyPhuCap = 0;
            if (cbKyPhuCap.Value != null)
            {
                int makypcOut = 0;
                if (int.TryParse(cbKyPhuCap.Value.ToString(), out  makypcOut))
                {
                    _maKyPhuCap = makypcOut;
                }
            }
        }

        private void tlSTinhTruyThu_Click(object sender, EventArgs e)
        {
            textBoxFocus.Focus();
            if (_maKyPhuCap != 0)
            {
                if (maLoaiPhuCap == 0 || maKyTinhluong == 0)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ Loại phụ cấp, Kỳ tính lương!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (isTruyThuBaoHiem() == false)
                {
                    return;
                }
                else if (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.KiemTraDaTruyThu_TruyLinh(_maKyPhuCap, maKyTinhluong, maLoaiPhuCap))
                {
                    MessageBox.Show("Kỳ phụ cấp này đã truy thu, không thể thực hiện!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int maloaiPCIP = maLoaiPhuCap;
                if (_phuCapNhanVienList.Count > 0)
                {
                    if (MessageBox.Show("Bạn muốn tính lại truy thu?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                    else
                        _phuCapNhanVienList.Clear();
                }

                //_phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
                //BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
                List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> listThongTinluong = new List<ERP_Library.ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
                listThongTinluong = ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.TinhTruyThuDaoHiem(_maKyPhuCap, maBoPhan, maKyTinhluong);
                _nhanVienChuaTruyThuList = new List<ERP_Library.ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
                #region Update tach rieng cac truy thu
                for (int i = 1; i <= 3; i++)
                {
                    foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in listThongTinluong)
                    {
                        PhuCapNhanVien phuCapNhanVien = PhuCapNhanVien.NewPhuCapNhanVien();
                        phuCapNhanVien.MaKyTinhLuong = maKyTinhluong;
                        //if (cbLoaiPhuCap.ActiveRow != null)
                        phuCapNhanVien.MaLoaiPhuCap = maloaiPCIP;//(int)cbLoaiPhuCap.ActiveRow.Cells["MaLoaiPhuCap"].Value;
                        phuCapNhanVien.TenPhuCap = cbLoaiPhuCap.Text;
                        phuCapNhanVien.DienGiai = cbLoaiPhuCap.Text + (i == 1 ? " - BHXH" : (i == 2 ? " - BHYT" : " - BHTN"));
                        phuCapNhanVien.SoQuyetDinh = txt_SoQuyetDinh.Text;
                        phuCapNhanVien.MaNhanVien = ttl.MaNhanVien;
                        phuCapNhanVien.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                        phuCapNhanVien.TinhThueTNCN = true;
                        phuCapNhanVien.TenNhanVien = ttl.TenNhanVien;
                        phuCapNhanVien.MaPhieuChi = "";
                        phuCapNhanVien.ThanhToan = true;
                        phuCapNhanVien.MaBoPhan = ttl.MaBoPhan;
                        phuCapNhanVien.MaKyPhuCap = _maKyPhuCap;
                        phuCapNhanVien.PhuCap = (i == 1 ? ttl.TruyThuBHXH : (i == 2 ? ttl.TruyThuBHYT : ttl.TruyThuBHTN));
                        phuCapNhanVien.PhanLoai = i;
                        if (ttl.ThucLanhSauThue < ttl.ThuTienBHXHTruyLuongTruocHan || ttl.BHXH_Luong != 0 || ttl.TinhTrangNV != 0)
                        {
                            if (_nhanVienChuaTruyThuList.Contains(ttl) == false)
                                _nhanVienChuaTruyThuList.Add(ttl);
                        }
                        else
                            _phuCapNhanVienList.Add(phuCapNhanVien);
                    }
                }
                #endregion//Update tach rieng cac truy thu
                #region Old
                //foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in listThongTinluong)
                //{
                //    PhuCapNhanVien phuCapNhanVien = PhuCapNhanVien.NewPhuCapNhanVien();
                //    phuCapNhanVien.MaKyTinhLuong = maKyTinhluong;
                //    //if (cbLoaiPhuCap.ActiveRow != null)
                //    phuCapNhanVien.MaLoaiPhuCap = maloaiPCIP;//(int)cbLoaiPhuCap.ActiveRow.Cells["MaLoaiPhuCap"].Value;
                //    phuCapNhanVien.TenPhuCap = cbLoaiPhuCap.Text;
                //    phuCapNhanVien.DienGiai = cbLoaiPhuCap.Text;
                //    phuCapNhanVien.SoQuyetDinh = txt_SoQuyetDinh.Text;
                //    phuCapNhanVien.MaNhanVien = ttl.MaNhanVien;
                //    phuCapNhanVien.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                //    phuCapNhanVien.TinhThueTNCN = true;
                //    phuCapNhanVien.TenNhanVien = ttl.TenNhanVien;
                //    phuCapNhanVien.MaPhieuChi = "";
                //    phuCapNhanVien.ThanhToan = true;
                //    phuCapNhanVien.MaBoPhan = ttl.MaBoPhan;
                //    phuCapNhanVien.MaKyPhuCap = _maKyPhuCap;
                //    phuCapNhanVien.PhuCap = ttl.ThuTienBHXHTruyLuongTruocHan;
                //    if (ttl.ThucLanhSauThue < ttl.ThuTienBHXHTruyLuongTruocHan || ttl.BHXH_Luong != 0)
                //        _nhanVienChuaTruyThuList.Add(ttl);
                //    else
                //        _phuCapNhanVienList.Add(phuCapNhanVien);
                //}
                #endregion//Old

                this.BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
                this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();
                Unlock_LockControlAfterTinhTruyThuTruyLinh(false);



            }
            else
            {
                MessageBox.Show("Vui lòng chọn Kỳ Phụ cấp để tính truy thu!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKyPhuCap.Focus();
            }

        }

        private void tlSTinhTruyLinh_Click(object sender, EventArgs e)
        {
            textBoxFocus.Focus();
            if (_maKyPhuCap != 0)
            {
                if (maLoaiPhuCap == 0 || maKyTinhluong == 0)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ Loại phụ cấp, Kỳ tính lương!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (isTruyLinhDoNangLuongCB() == false)
                {
                    return;
                }
                else if (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.KiemTraDaTruyThu_TruyLinh(_maKyPhuCap, maKyTinhluong, maLoaiPhuCap))
                {
                    MessageBox.Show("Kỳ phụ cấp này đã truy lĩnh, không thể thực hiện!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int maloaiPCIP = maLoaiPhuCap;

                if (_phuCapNhanVienList.Count > 0)
                {
                    if (MessageBox.Show("Bạn muốn tính lại truy lĩnh?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                    else
                        _phuCapNhanVienList.Clear();
                }
                //_phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
                //BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
                List<ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass> listThongTinluong = new List<ERP_Library.ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass>();
                listThongTinluong = ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass.TinhTruyLinhNangLuongCoBan(_maKyPhuCap, maBoPhan);
                foreach (ThongTinLuongNVKhiCapNhatCacKhoanKhauTruClass ttl in listThongTinluong)
                {
                    PhuCapNhanVien phuCapNhanVien = PhuCapNhanVien.NewPhuCapNhanVien();
                    phuCapNhanVien.MaKyTinhLuong = maKyTinhluong;
                    //if (cbLoaiPhuCap.ActiveRow != null)
                    phuCapNhanVien.MaLoaiPhuCap = maloaiPCIP;//(int)cbLoaiPhuCap.ActiveRow.Cells["MaLoaiPhuCap"].Value;
                    phuCapNhanVien.TenPhuCap = cbLoaiPhuCap.Text;
                    phuCapNhanVien.DienGiai = cbLoaiPhuCap.Text;
                    phuCapNhanVien.SoQuyetDinh = txt_SoQuyetDinh.Text;
                    phuCapNhanVien.MaNhanVien = ttl.MaNhanVien;
                    phuCapNhanVien.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                    phuCapNhanVien.TinhThueTNCN = true;
                    phuCapNhanVien.TenNhanVien = ttl.TenNhanVien;
                    phuCapNhanVien.MaPhieuChi = "";
                    phuCapNhanVien.ThanhToan = true;
                    phuCapNhanVien.MaBoPhan = ttl.MaBoPhan;
                    phuCapNhanVien.MaKyPhuCap = _maKyPhuCap;
                    phuCapNhanVien.PhuCap = ttl.TongTienLuongTuNguonPCCaiCachTienLuong;
                    if (ttl.TinhTrangNV == 0 && ttl.BHXH_Luong == 0)
                    {
                        _phuCapNhanVienList.Add(phuCapNhanVien);
                    }
                    else
                    {
                        _nhanVienChuaTruyThuList.Add(ttl);
                    }
                }

                this.BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
                this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();
                Unlock_LockControlAfterTinhTruyThuTruyLinh(false);


            }
            else
            {
                MessageBox.Show("Vui lòng chọn Kỳ Phụ cấp để tính truy lĩnh!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKyPhuCap.Focus();
            }
        }

        private void tlSbtnDSNVChuaTruyThu_Click(object sender, EventArgs e)
        {
            textBoxFocus.Focus();
            if (_maLoaiChi == 6)//TruyThu
            {
                if (isTruyThuBaoHiem())
                {
                    if (maKyTinhluong == 0 || _maKyPhuCap == 0 || maLoaiPhuCap == 0)
                    {
                        MessageBox.Show("Vui lòng chọn đầy đủ thông tin Kỳ tính lương, Kỳ phụ cấp, Loại phụ cấp!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    frmDanhSachNhanVienChuaKhauTru frm = new frmDanhSachNhanVienChuaKhauTru(_nhanVienChuaTruyThuList, maKyTinhluong, _maKyPhuCap, maLoaiPhuCap, _maLoaiChi, 1);
                    frm.Show();
                }
            }
        }

        private void tlSbtnNVChuaTruyLinh_Click(object sender, EventArgs e)
        {
            textBoxFocus.Focus();
            if (_maLoaiChi == 5)//TruyTLinh
            {
                if (isTruyLinhDoNangLuongCB())
                {
                    if (maKyTinhluong == 0 || _maKyPhuCap == 0 || maLoaiPhuCap == 0)
                    {
                        MessageBox.Show("Vui lòng chọn đầy đủ thông tin Kỳ tính lương, Kỳ phụ cấp, Loại phụ cấp!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    frmDanhSachNhanVienChuaKhauTru frm = new frmDanhSachNhanVienChuaKhauTru(_nhanVienChuaTruyThuList, maKyTinhluong, _maKyPhuCap, maLoaiPhuCap, _maLoaiChi, 3);
                    frm.Show();
                }
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            frmBaoCaoPhuCapBS frm = new frmBaoCaoPhuCapBS(1);
            frm.Show();
        }


    }
}

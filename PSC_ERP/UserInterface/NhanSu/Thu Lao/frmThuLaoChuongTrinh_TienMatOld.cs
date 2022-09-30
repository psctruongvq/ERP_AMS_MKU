using System;
using System.Data;
using System.Windows.Forms;

using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;
using ERP_Library.Security;

namespace PSC_ERP
{//1/
    public partial class frmThuLaoChuongTrinh_TienMatOld : Form
    {
        BoPhanList _boPhanList;
        ChuongTrinhList _chuongTrinhList;
        KyTinhLuongList _kyTinhLuongList;
        ThongTinNhanVienTongHopList _nhanVienList;
        ThuLaoChuongTrinhList _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
        ThuLaoChuongTrinhList _thuLaoChuongTrinhListAll = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
        //ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        //GiayXacNhanChuongTrinhList _giayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();
        //ChiTietGiayXacNhan chiTietGXN = ChiTietGiayXacNhan.NewChiTietGiayXacNhan();
        ChiTietGiayXacNhanTongHopList _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.NewChiTietGiayXacNhanTongHopList();
        ChiTietGiayXacNhanTongHop chiTietGXN = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop();
        int userID = CurrentUser.Info.UserID;
        decimal _tienChiTietGiayXacNhan = 0;
        long maChiThuLao = 0;
        string soChungTu = string.Empty;             
         DateTime _ngayLap;
        static int maBoPhan = 0;
        static int maKyTinhluong = 0;
        static int maChuongTrinh = 0;
        bool nhapHo = false;
        string tenGiayXacNhan = string.Empty;
        string tenChuongTrinh = string.Empty;
        int maBoPhanDen = 0;
        Boolean _suaDuLieu = false;
        // long them vao
        decimal _tongTienChoPhepCapNhat = 0;
        int maChiTietGiayXacNhan = 0;
        int maGiayXacNhan = 0;
        bool _hoanTat = false;
        string tenNguon = string.Empty;
        int maNguon = 0;
        decimal _soTienConLaiTrongGiayXacNhan = 0;
        int _maChiTietGiayXacNhan_Update = 0;
        private void LoadControls()
        {
            _boPhanList = BoPhanList.GetBoPhanListByAll();
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, itemBoPhan);
            this.bindingSource1_BoPhan.DataSource = _boPhanList;

            ///------Chay cham--------////
            //_chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
            //_chiTietGiayXacNhanList.Insert(0, itemAdd);
            //this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

            ///------Chay nhanh--------////
            _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserIDAndMaChiTietGiayXacNhan(ERP_Library.Security.CurrentUser.Info.UserID, _maChiTietGiayXacNhan_Update);
            ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
            _chiTietGiayXacNhanList.Insert(0, itemAdd);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

            //chuong trinh
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;


            _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            bindingSource1_NhanVien.DataSource = _nhanVienList;
            _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
            dateTimePicker_NgayLap.Value = DateTime.Today;
        }
        public frmThuLaoChuongTrinh_TienMatOld()
        {
            InitializeComponent();

            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = typeof(ThuLaoChuongTrinhList);
         
            bindingSource1_NhanVien.DataSource = typeof(ThongTinNhanVienTongHopList);
            LoadControls();         
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            
            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            dateTimePicker_NgayLap.Value = DateTime.Today;

        }

        public frmThuLaoChuongTrinh_TienMatOld(int _maKyTinhLuong, int _maChuongTrinh, int maChiTietGiayXacNhan, string maPhieuChi, DateTime ngayLap, bool tinhDangPhi)
        {
            InitializeComponent();
            KhoiTao(_maKyTinhLuong, _maChuongTrinh, maPhieuChi, ngayLap, tinhDangPhi, maChiTietGiayXacNhan);
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));            
            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            dateTimePicker_NgayLap.Value = DateTime.Today;
            _suaDuLieu = true;
        }
        private void frmThuLaoChuongTrinh_Load(object sender, EventArgs e)
        {
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, Infragistics.Win.UltraWinGrid.UltraGridState.AddRow, 0, 0, 0));
            //LoadControls();
        }

        public void KhoiTao(int _maKyTinhLuong, int _maChuongTrinh, string maPhieuChi, DateTime ngayLap, bool tinhDangPhi, int _maChiTietGiayXacNhan)
        {
            _maChiTietGiayXacNhan_Update = _maChiTietGiayXacNhan;
            LoadControls();           
            cbKyTinhLuong.Value = _maKyTinhLuong;
            cmbu_ChuongTrinh.EditValue = _maChuongTrinh;
            cbChiTietGiayXacNhan.Value = _maChiTietGiayXacNhan; 
            maChuongTrinh = _maChuongTrinh;
            _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(0, maChuongTrinh, maKyTinhluong, maPhieuChi,tinhDangPhi,0,0,ngayLap);
           
            _thuLaoChuongTrinhListAll = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(0, maChuongTrinh, maKyTinhluong, maPhieuChi, tinhDangPhi, 0, 0,ngayLap);

            maKyTinhluong = _maKyTinhLuong;
            if (_thuLaoChuongTrinhList.Count != 0)
            {
                
                dateTimePicker_NgayLap.Value = _thuLaoChuongTrinhList[0].NgayLap;
                chbTinhDangPhi.Checked = _thuLaoChuongTrinhList[0].TinhDangPhi;
            }

            bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
            this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();

            _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbu_Bophan.Value != null)
                {
                    maBoPhan = (int)cmbu_Bophan.Value;
                }
                //_nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, checkBox_NghiHuu.Checked);
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByDatabase(maBoPhan, checkBox_NghiHuu.Checked);
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
                    if (!ultraGrid1.Rows[i].Hidden == true && ultraGrid1.Rows[i].IsFilteredOut == false)
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
            if (tbMaPhieuChi.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Phiếu Chi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaPhieuChi.Focus();
                return;
            }

             if (cmbu_ChuongTrinh.EditValue == null || (cmbu_ChuongTrinh.EditValue != null && Convert.ToInt32(cmbu_ChuongTrinh.EditValue) == 0))
            {
                MessageBox.Show("Vui Lòng Chọn Chương Trình ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_ChuongTrinh.Focus();
                return;
            }
            if (cbKyTinhLuong.Value == null || (cbKyTinhLuong.Value != null && Convert.ToInt32(cbKyTinhLuong.Value) == 0))
            {
                MessageBox.Show("Vui Lòng Chọn Kỳ Tính Lương ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKyTinhLuong.Focus();
                return;
            }

            {
                KyTinhLuong ktl = KyTinhLuong.GetKyTinhLuong(maKyTinhluong);
                if ((DateTime)dateTimePicker_NgayLap.Value >= ktl.NgayKhoaThuLao)
                {
                    MessageBox.Show("Ngày Lập lớn hơn Ngày Khóa Thù Lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                    return;
                }
                if (ktl.KhoaSoKy2 == true || ktl.KhoaSo == true)
                {
                    MessageBox.Show("Tháng lương Đã Khóa Sổ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult _DialogResult = MessageBox.Show("Bạn Có Đồng Ý Đứa Nhân Viên Qua", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_DialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid1.Rows[i].Cells["Check"].Value == true )
                        {
                           
                            ThuLaoChuongTrinh thuLao = ThuLaoChuongTrinh.NewThuLaoChuongTrinh();
                            thuLao.ThanhToan = false;
                            thuLao.MaChuongTrinh = maChuongTrinh;
                            thuLao.MaKyTinhLuong = maKyTinhluong;
                            thuLao.MaNhanVien = (long)ultraGrid1.Rows[i].Cells["MaNhanVien"].Value;
                            thuLao.TenNhanVien = (string)ultraGrid1.Rows[i].Cells["TenNhanVien"].Value;
                            thuLao.TinhDangPhi = chbTinhDangPhi.Checked;
                            thuLao.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                            thuLao.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                            thuLao.MaPhieuChi = tbMaPhieuChi.Text;  
                            thuLao.SoTien = Convert.ToDecimal(ultraGrid1.Rows[i].Cells["SoTien"].Value);
                            thuLao.MaQLNhanVien = (string)ultraGrid1.Rows[i].Cells["MaQLNhanVien"].Value;
                            thuLao.MaQLBoPhan = (string)ultraGrid1.Rows[i].Cells["MaQLBoPhan"].Value;
                            thuLao.MaBoPhan = (int)ultraGrid1.Rows[i].Cells["MaBoPhan"].Value;
                            thuLao.MaChucVu = (int)ultraGrid1.Rows[i].Cells["MaChucVu"].Value;
                            thuLao.TenBoPhan = (string)ultraGrid1.Rows[i].Cells["TenBoPhan"].Value;
                            thuLao.TenChucVu = (string)ultraGrid1.Rows[i].Cells["TenChucVu"].Value;

                            thuLao.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                            thuLao.MaNguonChuongTrinh = maNguon;
                            thuLao.TenNguonChuongTrinh = tenNguon;
                            thuLao.TenGiayXacNhan = tenGiayXacNhan;
                            
                            thuLao.TenChuongTrinh = cmbu_ChuongTrinh.Text;
                            thuLao.DuocNhapHo = nhapHo;
                            thuLao.ThucNhan = cbDinhMuc.Checked;
                            _thuLaoChuongTrinhList.Add(thuLao);


                        }
                    }
                    this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
                    this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();

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
        }

       
        private void ComBoChangedValue()
        {
            //decimal _soTienTemp = 0;
            //if (txt_MaPhieuChi.Text != "")
            //{
            //    _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(maBoPhan, maChuongTrinh, maKyTinhluong, txt_MaPhieuChi.Text);
            //    this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
            //}
            lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
            //for (int i = 0; i < _thuLaoChuongTrinhList.Count; i++)
            //{
            //    _soTienTemp += _thuLaoChuongTrinhList[i].SoTien;
            //}
            //SoTien = _soTienTemp;
            //if (_soTienTemp != 0)
            //{
            //    tbSoTien.Text = SoTien.ToString();
            //}
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            
           try
           {
               //if (cbChiTietGiayXacNhan.Value == null || (cbChiTietGiayXacNhan.Value != null && Convert.ToInt32(cbChiTietGiayXacNhan.Value) == 0))
               //{
               //    MessageBox.Show("Vui lòng chọn giấy xác nhận.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               //    return;
               //}

               KyTinhLuong ktl= KyTinhLuong.GetKyTinhLuong(maKyTinhluong);
               if (tbMaPhieuChi.Text == "" && _thuLaoChuongTrinhList.Count>0)
               {
                   MessageBox.Show("Vui Lòng Nhập Phiếu Chi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   tbMaPhieuChi.Focus();
                   return;
               }
               if (ktl.KhoaSoKy2 == true || ktl.KhoaSo == true)
               {
                   MessageBox.Show("Tháng lương Đã Khóa Sổ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return;
               }
               if (dateTimePicker_NgayLap.Value != null && (DateTime)dateTimePicker_NgayLap.Value >= ktl.NgayKhoaThuLao)
               {
                   MessageBox.Show("Ngày Lập lớn hơn Ngày Khóa Thù Lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return;
               }
             
               else
               {
                   decimal soTienDaNhap = 0;
                   foreach (ThuLaoChuongTrinh tl in _thuLaoChuongTrinhList)
                   {
                       KyTinhLuong ktlTrack = KyTinhLuong.GetKyTinhLuong(tl.MaKyTinhLuong);
                       if (ktlTrack.KhoaSoKy2 == true)
                       {
                           MessageBox.Show("Kỳ Trước Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           return;
                       }
                       if ((DateTime)dateTimePicker_NgayLap.Value >= ktlTrack.NgayKhoaThuLao)
                       {
                           MessageBox.Show("Ngày Lập lớn hơn Ngày Khóa Thù Lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           return;
                       }

                       tl.MaPhieuChi = tbMaPhieuChi.Text;                      
                       
                       //tl.NgayLap = dateTimePicker_NgayLap.Value.Date;
                       //tl.TenChuongTrinh = cmbu_ChuongTrinh.Text;
                       //tl.MaChuongTrinh = maChuongTrinh;
                       //tl.MaKyTinhLuong = maKyTinhluong;                      
                       
                       //soTienDaNhap += tl.SoTien;

                       tl.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                       tl.TenChuongTrinh = cmbu_ChuongTrinh.Text;
                       tl.MaChuongTrinh = maChuongTrinh;
                       tl.MaKyTinhLuong = maKyTinhluong;
                       tl.TenGiayXacNhan = tenGiayXacNhan;
                       tl.MaChiThuLao = maChiThuLao;
                       tl.SoChungTu = soChungTu;
                      

                       tl.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                     
                       tl.MaNguonChuongTrinh = maNguon;
                       tl.TenNguonChuongTrinh = tenNguon;
                       soTienDaNhap += tl.SoTien;
                       tl.DuocNhapHo = nhapHo;

                       if (tl.NgayLap < ktl.NgayBatDau || tl.NgayLap > ktl.NgayKetThuc)
                       {
                           MessageBox.Show("Ngày Lập phải năm trong tháng của kỳ lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           return;
                       }
                   }

                   if (cbChiTietGiayXacNhan.Value != null && (int)cbChiTietGiayXacNhan.Value != 0)
                   {
                       if (!_suaDuLieu)
                       {
                           if (_soTienConLaiTrongGiayXacNhan < soTienDaNhap)
                           {
                               MessageBox.Show("Không đủ tiền nhập thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                               return;
                           }
                       }
                       else
                       {
                           if (soTienDaNhap > _tongTienChoPhepCapNhat || _soTienConLaiTrongGiayXacNhan < soTienDaNhap - TinhSoTienDaNhapThuLao((int)cbChiTietGiayXacNhan.Value))
                           {
                               MessageBox.Show("Không đủ tiền nhập thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                               return;
                           }
                       }
                   }
                   _thuLaoChuongTrinhList.ApplyEdit();
                   bindingSource1_ThuLaoChuongTrinh.EndEdit();
                   _thuLaoChuongTrinhList.Save();
                   if (maChiTietGiayXacNhan != 0)
                   {
                       //ChiTietGiayXacNhan.UpdateSoTienTienMatChiTietGiayXacNhan(maChiTietGiayXacNhan, databaseNumberGXN, Database.DatabaseNumber, soTienDaNhap);
                   }
                   MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   _soTienConLaiTrongGiayXacNhan = ChiTietGiayXacNhanTongHop.GetChiTietGiayXacNhanTongHop(maChiTietGiayXacNhan).SoTienConLai;

                   _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
                   _suaDuLieu = true;
               }
           }
           catch (Exception ex)
           {
               throw ex;
               
           }
        }

        private decimal TinhSoTienDaNhapThuLao(int maChiTietGiayXacNhan)
        {
            decimal soTienConLai = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienDaNhapThuLao";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@SoTien", soTienConLai);
                    cm.Parameters["@SoTien"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    soTienConLai = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }//using
            return soTienConLai;
        }      

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComBoChangedValue();
        }

       
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
           // KhoiTao(maKyTinhluong,maChuongTrinh,maGiayXacNhan);           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(KyTinhLuong.GetKyTinhLuong(maKyTinhluong).KhoaSoKy2!=true)
            {
            for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
            {
                if ((bool)grdu_QuocGia.Rows[i].Cells["Check"].Value == true)
                {
                    grdu_QuocGia.Rows[i].Selected = true;
                }
            }
            grdu_QuocGia.DeleteSelectedRows();
           //_thuLaoChuongTrinhList.ApplyEdit();
           // _thuLaoChuongTrinhList.Save();
            _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByDatabase(maBoPhan, checkBox_NghiHuu.Checked);
            this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
            }
            else
            {
                MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   return;
            }
            //ComBoChangedValue();
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
            //else if (e.KeyCode == (Keys.C && Keys.Control))
            //{
            //    this.grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            //}
            //if (e.KeyCode == (Keys.V && Keys.Control))
            //{
            //    this.grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Paste);
            //}
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
            foreach (UltraGridColumn col in this.grdu_QuocGia.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

            }
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Width = 60;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 4;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 120;

            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 5;
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Header.Caption = "Ngoài Định Mức";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Header.VisiblePosition = 6;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Width = 80;
        }

        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {
                
                if (e.KeyCode == Keys.Space)
                {
                    if (ultraGrid1.ActiveRow.Cells["Check"].Value.ToString() !="")
                    {
                        if ((bool)ultraGrid1.ActiveRow.Cells["Check"].Value == true)
                            ultraGrid1.ActiveRow.Cells["Check"].Value = false;
                        else
                            ultraGrid1.ActiveRow.Cells["Check"].Value = true;
                    }
                }
            }
        }

        private void grdu_QuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            //if (grdu_QuocGia.ActiveRow != null)
            //{
            //    if (e.KeyCode == Keys.Space)
            //    {
            //        if (grdu_QuocGia.ActiveRow.Cells["Check"].Value.ToString() != "")
            //        {
            //            if ((bool)grdu_QuocGia.ActiveRow.Cells["Check"].Value == true)
            //                grdu_QuocGia.ActiveRow.Cells["Check"].Value = false;
            //            else
            //                grdu_QuocGia.ActiveRow.Cells["Check"].Value = true;
            //        }
            //    }
            //}
        }

        private void ultraGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnthem_Click(null, null);
            }
        }
       
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            frmBaoCaoThuLaoChiTiet f = new frmBaoCaoThuLaoChiTiet();
            f.Show();
        }

        private void dateTimePicker_NgayLap_Leave(object sender, EventArgs e)
        {
           
            foreach (ThuLaoChuongTrinh tl in _thuLaoChuongTrinhList)
            {
                tl.NgayLap =Convert.ToDateTime(dateTimePicker_NgayLap.Value);
            }
        }

        private void grdu_QuocGia_AfterCellUpdate(object sender, CellEventArgs e)
        {

            //if (e.Cell.Row.IsDataRow)
            //{
            //    string t = e.Cell.Column.Key;
            //    if (t == "PhanTramThue" || t == "SoTien")
            //    {
            //        decimal sotien = Convert.ToDecimal(e.Cell.Row.Cells["SoTien"].Value);
            //        decimal ts = Convert.ToDecimal(e.Cell.Row.Cells["PhanTramThue"].Value);
            //        e.Cell.Row.Cells["TienThue"].Value = Math.Round(sotien * ts / 100, 0);
            //        e.Cell.Row.Cells["SoTienConLai"].Value = sotien - Math.Round(sotien * ts / 100, 0);
            //    }
            //}
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

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhluong = (int)cbKyTinhLuong.Value;

            }   
        }

        private void cbKyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
            foreach (UltraGridColumn col in this.cbKyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = cbKyTinhLuong.Width;
        }

        private void chbTinhDangPhi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTinhDangPhi.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["TinhDangPhi"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["TinhDangPhi"].Value = (object)false;
                }
            }
        }

  
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _suaDuLieu = false;
            cbChiTietGiayXacNhan.Value = 0;
            _soTienConLaiTrongGiayXacNhan = 0;
            _maChiTietGiayXacNhan_Update = 0;
            cmbu_ChuongTrinh.EditValue = null;
            _suaDuLieu = false;
            _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;

            _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserIDAndMaChiTietGiayXacNhan(ERP_Library.Security.CurrentUser.Info.UserID, _maChiTietGiayXacNhan_Update);
            ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
            _chiTietGiayXacNhanList.Insert(0, itemAdd);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;
        }

        private void cbDinhMuc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDinhMuc.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["ThucNhan"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["ThucNhan"].Value = (object)false;
                }
            }
        }
        private decimal TongSoTienToiDaChoPhepCapNhat()
        {
            decimal soTienDaNhapThuLao = 0;
            decimal soTienChoPhepCapNhat = 0;
            foreach (ThuLaoChuongTrinh item in _thuLaoChuongTrinhList)
            {
                soTienDaNhapThuLao += item.SoTien;
            }
            soTienChoPhepCapNhat += soTienDaNhapThuLao + _soTienConLaiTrongGiayXacNhan;

            return soTienChoPhepCapNhat;
        }
        private void cbChiTietGiayXacNhan_ValueChanged(object sender, EventArgs e)
        {
            maChiTietGiayXacNhan = 0;
            if (maChiTietGiayXacNhan == 0)
            {
                maChiTietGiayXacNhan = Convert.ToInt32(cbChiTietGiayXacNhan.Value);
            }
            //if (cbChiTietGiayXacNhan.Value != null &&maChiTietGiayXacNhan != 0)
            if (maChiTietGiayXacNhan != 0)
            {
                _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
                _boPhanList = BoPhanList.GetBoPhanListAll(userID);
                this.bindingSource1_BoPhan.DataSource = _boPhanList;
                _tienChiTietGiayXacNhan = 0;
                if (cbChiTietGiayXacNhan.ActiveRow != null)
                {
                    maGiayXacNhan = (int)cbChiTietGiayXacNhan.ActiveRow.Cells["MaGiayXacNhan"].Value;
                    maChiTietGiayXacNhan = Convert.ToInt32(cbChiTietGiayXacNhan.Value);
                    
                    maBoPhanDen = (int)cbChiTietGiayXacNhan.ActiveRow.Cells["MaBoPhanDen"].Value;
                    tenGiayXacNhan = (string)cbChiTietGiayXacNhan.ActiveRow.Cells["TenGiayXacNhan"].Value;
                    _hoanTat = (bool)cbChiTietGiayXacNhan.ActiveRow.Cells["HoanTat"].Value;
                    _tienChiTietGiayXacNhan = (decimal)cbChiTietGiayXacNhan.ActiveRow.Cells["SoTien"].Value;
                    nhapHo = (bool)cbChiTietGiayXacNhan.ActiveRow.Cells["DuocNhapHo"].Value;
                }
                cmbu_ChuongTrinh.Enabled = false;
                //GiayXacNhanChuongTrinh gxn = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(maGiayXacNhan);
                GiayXacNhanTongHop gxn = GiayXacNhanTongHop.GetGiayXacNhanChuongTrinh(maGiayXacNhan);

                maChuongTrinh = gxn.MaChuongTrinh;
                tenChuongTrinh = gxn.TenChuongTrinh;
                ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
                maNguon = ct.MaNguon;
                tenNguon = ct.TenNguon;

                TbTongTien.Value = _tienChiTietGiayXacNhan;
                cmbu_ChuongTrinh.EditValue = maChuongTrinh;

                // chiTietGXN = ChiTietGiayXacNhan.GetChiTietGiayXacNhan(maChiTietGiayXacNhan);
                chiTietGXN = ChiTietGiayXacNhanTongHop.GetChiTietGiayXacNhanTongHop(maChiTietGiayXacNhan);

                _soTienConLaiTrongGiayXacNhan = chiTietGXN.SoTienConLai;
            }
            else
            {
                _tienChiTietGiayXacNhan = 0;
                TbTongTien.Value = 0;
                tenGiayXacNhan = string.Empty;
                maGiayXacNhan = 0;
                maChiTietGiayXacNhan = 0;
                nhapHo = false;
                cmbu_ChuongTrinh.EditValue = 0;
                _soTienConLaiTrongGiayXacNhan = 0;
                maChuongTrinh = 0;
            }

            _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();

        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Quản Lý";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Chứng Minh";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.Caption = "Chức Vụ";
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 2;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 3;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 4;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.VisiblePosition = 5;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 6;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Width = 40;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 100;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucVu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

        }

        private void cbChiTietGiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChiTietGiayXacNhan, "TenGiayXacNhan");
            foreach (UltraGridColumn col in this.cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 0;

            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
           // cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "###,###,###,###,###";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 2;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Header.Caption = "Đơn Vị Gửi";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Header.VisiblePosition = 3;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Header.Caption = "Đơn Vị Nhận";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Header.VisiblePosition = 4;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 5;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.Caption = "Nhập Hộ";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.VisiblePosition = 6;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 7;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 8;
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

        private void cmbu_ChuongTrinh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.EditValue != null)
            {
                maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.EditValue);
                ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
                maNguon = ct.MaNguon;
                tenNguon = ct.TenNguon;
            }
        }  

    }
}

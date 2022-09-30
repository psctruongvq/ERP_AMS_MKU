using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
//

namespace PSC_ERP
{
    public partial class frmGiayXacNhanChuongTrinhNew : Form
    {
        TTNhanVienRutGonList _nhanVienList = TTNhanVienRutGonList.NewTTNhanVienRutGonList();
        ChuongTrinhList _ChuongTrinhList = ChuongTrinhList.NewChuongTrinhList();
        GiayXacNhanChuongTrinh _GiayXacNhanChuongTrinh=GiayXacNhanChuongTrinh.NewGiayXacNhanChuongTrinh();
        GiayXacNhanChuongTrinhList _GiayXacNhanChuongTrinhList=GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();
        ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        ChiTietGiayXacNhan_NhanVienList _chiTietGiayXacNhan_NhanVienList;
        BoPhanList _BoPhanDenList;
        BoPhanList _BoPhanDiList;
        static bool isDeletedNotValid = false;
        int maChuongTrinh = 0; int maBoPhanDi = 0; int maBoPhanDen = 0;
        Boolean _loaiGiayXacNhan = false;
        public frmGiayXacNhanChuongTrinhNew()
        {
            InitializeComponent();             
        }

        public void ShowGiayXacNhanChuongTrinh()
        {
            ChuongTrinh_bindingSourceList.DataSource = typeof(ChuongTrinhList);
            BoPhanGoc_bindingSourceList.DataSource = typeof(BoPhanList);
            BoPhanChuyen_bindingSourceList.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChiTietXacNhan_NhanVien.DataSource = typeof(ChiTietGiayXacNhan_NhanVienList);
            this.GiayXacNhanChuongTrinh_bindingSource.DataSource = typeof(GiayXacNhanChuongTrinhList);
            this.bindingSource1_NhanVien.DataSource = typeof(TTNhanVienRutGonList);
            KhoiTao(ERP_Library.Security.CurrentUser.Info.UserID);
            this.Show();
        }

        public void ShowGiayXacNhanTrucTiep()
        {
            _loaiGiayXacNhan = true;// Giấy xác nhận trực tiếp
            ChuongTrinh_bindingSourceList.DataSource = typeof(ChuongTrinhList);
            BoPhanGoc_bindingSourceList.DataSource = typeof(BoPhanList);
            BoPhanChuyen_bindingSourceList.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChiTietXacNhan_NhanVien.DataSource = typeof(ChiTietGiayXacNhan_NhanVienList);
            this.GiayXacNhanChuongTrinh_bindingSource.DataSource = typeof(GiayXacNhanChuongTrinhList);
            this.bindingSource1_NhanVien.DataSource = typeof(TTNhanVienRutGonList);
            KhoiTao(ERP_Library.Security.CurrentUser.Info.UserID);

            this.Text = "Giấy xác nhận trực tiếp";
            this.Show();
        }

        public frmGiayXacNhanChuongTrinhNew(int maGiayXacNhan, bool loaiGiayXacNhan)
        {
            InitializeComponent();
            _loaiGiayXacNhan = loaiGiayXacNhan;
            _ChuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh_bindingSourceList.DataSource = _ChuongTrinhList;
            _BoPhanDiList = BoPhanList.GetBoPhanList();
            _BoPhanDenList = BoPhanList.GetBoPhanListByAll();
            BoPhanGoc_bindingSourceList.DataSource = _BoPhanDiList;
            BoPhanChuyen_bindingSourceList.DataSource = _BoPhanDenList;
            _GiayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.GetGiayXacNhanChuongTrinhListByMaGiayXacNhan(maGiayXacNhan);

            _chiTietGiayXacNhanList = _GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList;            
            ChiTietGiayXacNhan_bindingSource.DataSource = _chiTietGiayXacNhanList;
            this.bindingSource1_ChiTietXacNhan_NhanVien.DataSource = _chiTietGiayXacNhan_NhanVienList;

            this.GiayXacNhanChuongTrinh_bindingSource.DataSource = _GiayXacNhanChuongTrinhList;
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListBoPhan(maBoPhanDen);
            this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            ChiTietGiayXacNhan chiTiet = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0);
            bindingSource1_ChiTietXacNhan_NhanVien.DataSource = chiTiet.ChiTietGiayXacNhan_NhanVienList;

            //Phân quyền chi tiết giấy xác nhận 
            for (int i = 0; i < grdu_ChiTietGiayXacNhan.Rows.Count; i++)
            {
                int maChiTietGiayXacNhan = Convert.ToInt32(grdu_ChiTietGiayXacNhan.Rows[i].Cells["MaChiTietGiayXacNhan"].Value);

                if (KiemTraNhapThuLaoChuongTrinh(maChiTietGiayXacNhan))
                {
                    //Không cho sữa những cột sau
                    grdu_ChiTietGiayXacNhan.Rows[i].Cells["MaBoPhanDen"].Activation = Activation.ActivateOnly;
                    grdu_ChiTietGiayXacNhan.Rows[i].Cells["GhiChu"].Activation = Activation.ActivateOnly;
                    grdu_ChiTietGiayXacNhan.Rows[i].Cells["NgayLap"].Activation = Activation.ActivateOnly;
                }
                else
                {
                    grdu_ChiTietGiayXacNhan.Rows[i].Activation = Activation.AllowEdit;
                }
            }
        }
        public void KhoiTao(int userID)
        {
            isDeletedNotValid = false;
            
            _ChuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            ChuongTrinh_bindingSourceList.DataSource = _ChuongTrinhList;
            _BoPhanDiList = BoPhanList.GetBoPhanList();
             _BoPhanDenList=BoPhanList.GetBoPhanListByAll();
            BoPhanGoc_bindingSourceList.DataSource = _BoPhanDiList ;
            BoPhanChuyen_bindingSourceList.DataSource = _BoPhanDenList;
            //_GiayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.GetGiayXacNhanChuongTrinhList(userID);
           // this.GiayXacNhanChuongTrinh_bindingSource.DataSource = _GiayXacNhanChuongTrinhList;
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListBoPhan(maBoPhanDen);
            this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            ChiTietGiayXacNhan chiTiet = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0);
            bindingSource1_ChiTietXacNhan_NhanVien.DataSource= chiTiet.ChiTietGiayXacNhan_NhanVienList;
            ThemMoi();
        }
        string SoCTMoiPS = "";

        private void SetSoChungTuMoiPS()
        {

            string soCTCu = GiayXacNhanChuongTrinh.KiemTraSoChungTuMoiNhat(Convert.ToDateTime(dateTimePicker_NgayLap.Value).Year);
            if (soCTCu != null)
            {

                if (_GiayXacNhanChuongTrinh.TenGiayXacNhan == "")
                {

                    SoCTMoiPS = GiayXacNhanChuongTrinh.LaySoChungTuMax(Convert.ToDateTime(dateTimePicker_NgayLap.Value).Year);
                    txt_SoGiay.Text = SoCTMoiPS;
                    _GiayXacNhanChuongTrinh.TenGiayXacNhan = SoCTMoiPS;
                }
                else
                {
                    SoCTMoiPS = _GiayXacNhanChuongTrinh.TenGiayXacNhan;
                    txt_SoGiay.Text = SoCTMoiPS;

                }
            }
            else
            {
                SoCTMoiPS = "";
                txt_SoGiay.Text = "";
                _GiayXacNhanChuongTrinh.TenGiayXacNhan = "";

            }
            GiayXacNhanChuongTrinh_bindingSource.DataSource = _GiayXacNhanChuongTrinh;
        }
        private void tlslblLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cbSoTien.Value.ToString() == "")
                {
                    MessageBox.Show("Vui Lòng Nhập Số Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbSoTien.Focus();
                    return;
                }

                if (Convert.ToInt32(ultraCombo_BoPhanGoc.Value) == 0)
                {
                    MessageBox.Show("Vui Lòng Nhập Bộ Phận Chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraCombo_BoPhanGoc.Focus();
                    return;
                }
                if (Convert.ToInt32(cmbu_ChuongTrinh.EditValue) == 0)
                {
                    MessageBox.Show("Vui Lòng chọn Chương Trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbu_ChuongTrinh.Focus();
                    return;
                }

                if (_GiayXacNhanChuongTrinhList.Count > 0)
                {
                    _GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList = _chiTietGiayXacNhanList;
                    _GiayXacNhanChuongTrinhList[0].TenDonViXacNhanDi = ultraCombo_BoPhanGoc.Text;
                    _GiayXacNhanChuongTrinhList[0].TenChuongTrinh = cmbu_ChuongTrinh.Text;
                    if (_loaiGiayXacNhan == true) // Giấy xác nhận trực tiếp
                    {
                        _GiayXacNhanChuongTrinhList[0].TrangThai = true;
                    }
                    else if (_GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList.Count == 0)
                    {
                        MessageBox.Show("Vui nhập chi tiết giấy xác nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                        return;
                    }
                    decimal soTienTong = 0;
                    soTienTong = (decimal)_GiayXacNhanChuongTrinhList[0].SoTien;
                    decimal soTienChiTiet = 0;
                    decimal soTienChiTiet1 = 0;
                    for (int i = 0; i < _GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList.Count; i++)
                    {
                        if (_GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList[i].MaBoPhanDen == 0)
                        {
                            MessageBox.Show("Chọn Bộ Phận đến", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (_GiayXacNhanChuongTrinhList[0].TenGiayXacNhan == "")
                        {
                            MessageBox.Show("Nhập tên giấy xác nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (_GiayXacNhanChuongTrinhList[0].MaDonViXacNhanDi == 0)
                        {
                            MessageBox.Show("Chọn Bộ Phận lập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (_GiayXacNhanChuongTrinhList[0].MaChuongTrinh == 0)
                        {
                            MessageBox.Show("Chọn Chương Trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        soTienChiTiet += _GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList[i].SoTien;
                        soTienChiTiet1 = _GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList[i].SoTien;
                        decimal soTienChiTietNhanVien = 0;
                        for (int j = 0; j < _GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList[i].ChiTietGiayXacNhan_NhanVienList.Count; j++)
                        {
                            soTienChiTietNhanVien += _GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList[i].ChiTietGiayXacNhan_NhanVienList[j].SoTien;


                        }
                        if (soTienChiTietNhanVien > soTienChiTiet1)
                        {
                            MessageBox.Show("Tổng Tiền Chi Tiết Cho Các Nhân Viên Lớn Hơn Số Tiền Được Phân Bổ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //if (_GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList[i].HoanTat == true && _GiayXacNhanChuongTrinhList[0].IsDirty == true)
                        //{
                        //    MessageBox.Show("Chi Tiết Xác Nhận Đã Hoàn Tất Sẽ Không Được Lưu Thay Đổi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                    }
                    if (soTienChiTiet > soTienTong)
                    {
                        MessageBox.Show("Tổng Tiền Chi Tiết Cho Các Đơn Vị Lớn Hơn Số Tiền Được Phân Bổ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                isDeletedNotValid = false;
                grdu_ChiTietGiayXacNhan.UpdateData();
                _GiayXacNhanChuongTrinhList.ApplyEdit();
                //if (_GiayXacNhanChuongTrinhList[0].IsNew==false)
                //{
                //    for (int i = 0; i < _chiTietGiayXacNhanList.Count; i++)
                //    {
                //        decimal sotiendanhap = 0;
                //        sotiendanhap = ChiTietGiayXacNhan.KiemTraSoTienHopLe(_chiTietGiayXacNhanList[i].MaChiTietGiayXacNhan);
                //        if (_GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList[i].SoTien < sotiendanhap)
                //        {
                //            MessageBox.Show("Số tiền giấy xác nhận của bộ phận: " + _GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList[i].TenBoPhanDen.ToString() + " phải >= Số tiền đã nhập thù lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            //_GiayXacNhanChuongTrinhList[0].ChiTietGiayXacNhanList[i].SoTien = sotiendanhap;
                //            continue;
                //        }
                //    }
                //}

                _GiayXacNhanChuongTrinhList.Save();
                isDeletedNotValid = false;
                this.GiayXacNhanChuongTrinh_bindingSource.DataSource = _GiayXacNhanChuongTrinhList;
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
        

        
        
        private void ThemMoi()
        {
            GiayXacNhanChuongTrinh item;
            for (int i = 0; i < _GiayXacNhanChuongTrinhList.Count; i++)
            {
                item = _GiayXacNhanChuongTrinhList[i];
                if (item.TenGiayXacNhan == "")
                {
                    return;
                }

            }
            item = GiayXacNhanChuongTrinh.NewGiayXacNhanChuongTrinh();
            
            _GiayXacNhanChuongTrinhList.Add(item);
            //ChiTietGiayXacNhan _chiTiet = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0);
            //_chiTietGiayXacNhanList.Add(_chiTiet);
            //_chiTietGiayXacNhan_NhanVienList = _chiTiet.ChiTietGiayXacNhan_NhanVienList;
            //item.ChiTietGiayXacNhanList = _chiTietGiayXacNhanList;
            //this.bindingSource1_ChiTietXacNhan_NhanVien.DataSource = _chiTietGiayXacNhan_NhanVienList;
            //this.ChiTietGiayXacNhan_bindingSource.DataSource = _chiTietGiayXacNhanList;
            this.GiayXacNhanChuongTrinh_bindingSource.DataSource = _GiayXacNhanChuongTrinhList;
            //ultraGrid1.ActiveRow = ultraGrid1.Rows[_GiayXacNhanChuongTrinhList.Count - 1];     
        }
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            
            _GiayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();

            _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
            ChiTietGiayXacNhan_bindingSource.DataSource = _chiTietGiayXacNhanList;
            this.bindingSource1_ChiTietXacNhan_NhanVien.DataSource = _chiTietGiayXacNhan_NhanVienList;

            this.GiayXacNhanChuongTrinh_bindingSource.DataSource = _GiayXacNhanChuongTrinhList;
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListBoPhan(maBoPhanDen);
            this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            ChiTietGiayXacNhan chiTiet = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0);
            bindingSource1_ChiTietXacNhan_NhanVien.DataSource = chiTiet.ChiTietGiayXacNhan_NhanVienList;
            //SetSoChungTuMoiPS();
            ThemMoi();
        }

        private void ultraCombo_BoPhanGoc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(ultraCombo_BoPhanGoc, "TenBoPhan");
            foreach (UltraGridColumn col in this.ultraCombo_BoPhanGoc.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultraCombo_BoPhanGoc.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraCombo_BoPhanGoc.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";            
            ultraCombo_BoPhanGoc.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 250;
            
            ultraCombo_BoPhanGoc.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            ultraCombo_BoPhanGoc.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            ultraCombo_BoPhanGoc.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Width = 100;
         

        }

        private void ultraCombo_BoPhanChuyen_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(ultraCombo_BoPhanChuyen, "TenBoPhan");
            foreach (UltraGridColumn col in this.ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";            
            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 250;

            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            ultraCombo_BoPhanChuyen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Width = 100;
         

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _chiTietGiayXacNhanList.Count; i++)
            {
                if (ChiTietGiayXacNhan.KiemTraGiayXacNhanTonTai(_chiTietGiayXacNhanList[i].MaBoPhanDen, _chiTietGiayXacNhanList[i].MaChiTietGiayXacNhan))
                {
                    MessageBox.Show("Đã nhập thù lao cho giấy xác nhận này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            _chiTietGiayXacNhanList.Clear();
            _GiayXacNhanChuongTrinhList.Clear();

        }
        
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            KhoiTao(ERP_Library.Security.CurrentUser.Info.UserID);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (!_loaiGiayXacNhan)
            {
                InGiayXacNhanChuongTrinh(((GiayXacNhanChuongTrinh)GiayXacNhanChuongTrinh_bindingSource.Current).MaGiayXacNhan, _loaiGiayXacNhan);
            }
            else
            {
                InGiayXacNhanTrucTiep(((GiayXacNhanChuongTrinh)GiayXacNhanChuongTrinh_bindingSource.Current).MaGiayXacNhan, _loaiGiayXacNhan);
            }
        }
        public static void InGiayXacNhanChuongTrinh(int maGiayXacNhan, bool loaiGiayXacNhan)
        {
            
            ReportDocument Report = new Report.rptGiayXacNhanChuongTrinh();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_ReportSelecttblnsGiayXacNhanChuongTrinh";
            
            command.Parameters.AddWithValue("@MaGiayXacNhan", maGiayXacNhan);
            command.Parameters.AddWithValue("@LoaiGiayXacNhan", loaiGiayXacNhan);
            //command.Parameters.AddWithValue("_SoTienBangChu", HamDungChung.DocTien();
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_ReportSelecttblnsGiayXacNhanChuongTrinh;1";
           
            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);
           // Report.SetParameterValue("SoTienChu", soTien);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show(); 
        }

        public static void InGiayXacNhanTrucTiep(int maGiayXacNhan, bool loaiGiayXacNhan)
        {

            ReportDocument Report = new Report.rptGiayXacNhanTrucTiep();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_ReportSelecttblnsGiayXacNhanChuongTrinh";

            command.Parameters.AddWithValue("@MaGiayXacNhan", maGiayXacNhan);
            command.Parameters.AddWithValue("@LoaiGiayXacNhan", loaiGiayXacNhan);
            //command.Parameters.AddWithValue("_SoTienBangChu", HamDungChung.DocTien();
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_ReportSelecttblnsGiayXacNhanChuongTrinh;1";

            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);
            // Report.SetParameterValue("SoTienChu", soTien);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        private void ultraTextEditor_MNS_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ultraCombo_BoPhanChuyen_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCombo_BoPhanChuyen.Value != null)
            {
                maBoPhanDen = Convert.ToInt32(ultraCombo_BoPhanChuyen.Value);
            }
           
        }

        private void ultraTextEditor_MNS_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (grdu_ChiTietGiayXacNhan.ActiveRow!=null)
            {
                maBoPhanDen = (int)grdu_ChiTietGiayXacNhan.ActiveRow.Cells["MaBoPhanDen"].Value;
            }
            if (_chiTietGiayXacNhanList.Count != 0)
            {
                frmChiTietGiayXacNhan_NhanVien _frmChietNhanVien = new frmChiTietGiayXacNhan_NhanVien((ChiTietGiayXacNhan)ChiTietGiayXacNhan_bindingSource.Current, maBoPhanDen);
                _frmChietNhanVien.Show();
            }
            else
            {
                frmChiTietGiayXacNhan_NhanVien _frmChietNhanVien = new frmChiTietGiayXacNhan_NhanVien((ChiTietGiayXacNhan)ChiTietGiayXacNhan_bindingSource.Current,maBoPhanDen);
                _frmChietNhanVien.Show();
            }
        }

        private void frmGiayXacNhanChuongTrinhNew_Load(object sender, EventArgs e)
        {
            
            ChiTietGiayXacNhan_bindingSource.DataSource = _chiTietGiayXacNhanList;
            this.bindingSource1_ChiTietXacNhan_NhanVien.DataSource = _chiTietGiayXacNhan_NhanVienList;
           // SetSoChungTuMoiPS();
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            frmDanhSachGiayXacNhan f = new frmDanhSachGiayXacNhan(_loaiGiayXacNhan);
            f.Show();
        }

        private void grdu_ChiTietGiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            //e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.grdu_ChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                //col.Hidden = true;
            }
            grdu_ChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["MaBoPhanDen"].EditorComponent = ultraCombo_BoPhanChuyen;
            grdu_ChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["MaBoPhanDen"].Header.Caption = "Bộ Phận Đến";
            grdu_ChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["MaBoPhanDen"].Header.VisiblePosition = 0;

            grdu_ChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = true;
            grdu_ChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = true;
            //ultraGrid1.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.Caption = "Bộ Phận Đến";
            //ultraGrid1.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.VisiblePosition = 0;
        }

        private bool KiemTraNhapThuLaoChuongTrinh(int maChiTietGiayXacNhan)
        {
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraNhapThuLaoChuongTrinhByMaChiTietGiayXacNhan";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@GiaTri", kq);
                    cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    kq = Convert.ToBoolean(cm.Parameters["@GiaTri"].Value);
                }
            }//using
            return kq;
        }

        private decimal LaySoTienNhapThuLaoChuongTrinh(int maChiTietGiayXacNhan)
        {
            decimal soTien = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienNhapThuLaoChuongTrinhByMaChiTietGiayXacNhan";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@SoTien", soTien);
                    cm.Parameters["@SoTien"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    soTien = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }//using
            return soTien;
        }

        private void grdu_ChiTietGiayXacNhan_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (Convert.ToString(e.Cell.Column).CompareTo("SoTien") == 0)
            { 
               //Lấy chi tiết giấy xác nhận hiện tại
                ChiTietGiayXacNhan chiTietGiayXacNhanCurrent = ChiTietGiayXacNhan_bindingSource.Current as ChiTietGiayXacNhan;

                if (chiTietGiayXacNhanCurrent != null)
                {
                    if (KiemTraNhapThuLaoChuongTrinh(chiTietGiayXacNhanCurrent.MaChiTietGiayXacNhan))//Nếu đã nhập phân bổ thù lao
                    {
                        //Lấy số tiền đã cập nhật trên lưới
                        decimal soTien_Updated = Convert.ToDecimal(e.Cell.Text);
                        //Lấy số tiền đã nhập thù lao
                        decimal soTienDaNhapThuLao = LaySoTienNhapThuLaoChuongTrinh(chiTietGiayXacNhanCurrent.MaChiTietGiayXacNhan);

                        if (soTienDaNhapThuLao > soTien_Updated)
                        {
                            MessageBox.Show("Số tiền vừa cập nhật không hợp lệ.","Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            chiTietGiayXacNhanCurrent.SoTien = soTienDaNhapThuLao;
                            return;
                        }
                    }
                }
            }
            
        }
    }
}
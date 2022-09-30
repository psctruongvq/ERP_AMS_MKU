using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library;
using System.Data.OleDb;
using Infragistics.Win.UltraWinGrid;
using System.Threading;
using System.IO;
namespace PSC_ERP
{
    public partial class frmThuLaoNgoaiDaiTam : Form
    {

        System.Net.WebClient webClient;
        Thread workedTheard;
        
        NhanVienNgoaiDaiList ngoaiDaiList;
        string path = string.Empty;
        ChiThuLao _chiThuLao_NhanVienList = ChiThuLao.NewChiThuLao();
        //ChiThuLaoList _chiThuLaoList;
        ChiThuLaoTongHopList _chiThuLaoList;
        
        ChuongTrinhList _chuongTrinhList;
        KyTinhLuongList _kyTinhLuongList;
        
        ThuLaoNhanVienNgoaiDaiList _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
        //GiayXacNhanChuongTrinhList _giayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();
        //ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        //ChiTietGiayXacNhan chiTietGXN = ChiTietGiayXacNhan.NewChiTietGiayXacNhan();
        ChiTietGiayXacNhanTongHopList _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.NewChiTietGiayXacNhanTongHopList();
        ChiTietGiayXacNhanTongHop chiTietGXN = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop();

        decimal _tienChiTietGiayXacNhan = 0;
        decimal _tienTuPhieuChi = 0;
        string tenNguon = string.Empty;
        int maNguon = 0;
        int maBoPhanDen = 0;
        DateTime _ngayLap;
        static int maBoPhan = 0;
        static int maKyTinhluong = 0;
        int maChuongTrinh = 0;
        string tenGiayXacNhan = string.Empty;
        string tenChuongTrinh = string.Empty;
        long maChiThuLao = 0;
        string soChungTu = string.Empty;
        long maChungTu = 0;
        string ghiChuPhieuChi = string.Empty;
        int maChiTietGiayXacNhan = 0;
        int maGiayXacNhan = 0;
        bool _hoanTat = false;
        bool nhapHo = false;
        DateTime _NgayChungTu;
        long _maChiThuLao_Update = 0;

        public frmThuLaoNgoaiDaiTam()
        {
            InitializeComponent();
            
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = typeof(ThuLaoNhanVienNgoaiDaiList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChiThuLaoList);
            bindingSource1_NhanVien.DataSource = typeof(NhanVienNgoaiDaiList);
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdData.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            
            grdData.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdData.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdData.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            dateTimePicker_NgayLap.Value = DateTime.Today;
        }
        private void frmThuLaoNgoaiDaiTam_Load(object sender, EventArgs e)
        {

    
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;

            ///------Chay cham--------////
            //_chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
            //_chiTietGiayXacNhanList.Insert(0, itemAdd);
            //this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;]

            ///------Chay nhanh--------////
            //_chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
            //_chiTietGiayXacNhanList.Insert(0, itemAdd);
            //this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

            _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;

            //_chiThuLaoList = ChiThuLaoList.GetChiThuLaoListByUser(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiThuLao itemChiTL = ChiThuLao.NewChiThuLao("Không Có Chứng Từ");
            //_chiThuLaoList.Insert(0, itemChiTL);
            //this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;

            _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update);
            ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
            _chiThuLaoList.Insert(0, itemChiTL);
            this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string cnnExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0;HDR=NO'";
                OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [Sheet1$A7:S] ", cnnExcel);
                DataTable tblExcel = new DataTable("Import");
                daExcel.Fill(tblExcel);
                //daExcel.UpdateCommand = new OleDbCommand("Update [Sheet1$A7:S] Set F11=? Where F1=?", daExcel.SelectCommand.Connection);
                //daExcel.UpdateCommand.Parameters.Add("p1", OleDbType.WChar, 8, "F11");
                //daExcel.UpdateCommand.Parameters.Add("p2", OleDbType.WChar, 8, "F1");

                //thêm dữ liệu vào object và save lại
                ERP_Library.ThuLaoNhanVienNgoaiDaiList _lstNew = ERP_Library.ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
                ERP_Library.ThuLaoNhanVienNgoaiDai objNew;
                bool ok;
                foreach (DataRow row in tblExcel.Rows)
                {
                   
                    ok = true;
                    if (row.IsNull("F2")) continue;
                    //if (row["F1"].ToString() == "") continue;

                    //ok = false;
                   
                    if (ok)
                    {
                        objNew = ERP_Library.ThuLaoNhanVienNgoaiDai.NewThuLaoNhanVienNgoaiDai();
                         
                        if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 22)
                        {
                            objNew.SoChungTu = Convert.ToString(row["F11"]);                            
                            ChungTu_ChiPhiSanXuat cpxs = ChungTu_ChiPhiSanXuat.GetChungTu_ChiPhiSanXuatBySoChungTu(objNew.SoChungTu);
                            objNew.TenChuongTrinh = cpxs.TenChuongTrinh;
                            objNew.MaChuongTrinh = cpxs.MaChuongTrinh;
                            objNew.MaPhieuChi = objNew.SoChungTu;
                            objNew.SoChungTu = objNew.SoChungTu;
                            objNew.MaChungTu = cpxs.MaChungTu;
                        }
                        else
                        {
                            objNew.TenChuongTrinh = tenChuongTrinh;
                            objNew.MaChuongTrinh = maChuongTrinh;                     
                            objNew.SoChungTu = soChungTu;
                            objNew.MaPhieuChi = soChungTu;
                            objNew.MaChungTu = maChungTu;

                        }                      
                        objNew.MaKyTinhLuong = maKyTinhluong;
                        objNew.NgayLap = dateTimePicker_NgayLap.Value.Date;
                        objNew.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                        objNew.MaBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
                        objNew.TenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
                        objNew.MaGiayXacNhan = maGiayXacNhan;
                        objNew.ThanhToan = false;
                        objNew.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                        objNew.DuocNhapHo = nhapHo;
                        objNew.TenGiayXacNhan = tenGiayXacNhan;
                        //objNew.TenChuongTrinh = cmbu_ChuongTrinhGXN.Text;                 
                        objNew.MaChiThuLao = maChiThuLao;
                        objNew.TenNhanVien = Convert.ToString(row["F1"]);
                        objNew.SoTien = Convert.ToDecimal(row["F2"]);
                        if (row["F3"].ToString() == "")
                        {
                            objNew.PhanTramThue = 0;
                        }
                        else
                        {
                            objNew.PhanTramThue = Convert.ToByte(row["F3"]);
                        }
                        if (row["F4"].ToString() == "")
                        {
                            objNew.TienThue = 0;
                        }
                        else
                        {
                            objNew.TienThue = Convert.ToDecimal(row["F4"]);
                        }
                        objNew.SoTienConLai = Convert.ToDecimal(row["F5"]);
                        objNew.Loai = Convert.ToInt32(cmbLoai.Value);
                        objNew.Cmnd = Convert.ToString(row["F6"]);
                        objNew.MaSoThue = Convert.ToString(row["F7"]);
                        objNew.DienThoai = Convert.ToString(row["F8"]);
                        objNew.DienGiai = Convert.ToString(row["F9"]);
                        objNew.DiaChi = Convert.ToString(row["F10"]);
                     
                        _lstNew.Add(objNew);
                        row["F12"] = "OK";
                    }
                    else
                    {
                        row["F12"] = "Lỗi";
                    }
                }
               // daExcel.Update(tblExcel);
                try
                {
                    _lstNew.Save();
                    MessageBox.Show("Đã import dữ liệu thành công!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    throw ex;
                    MessageBox.Show("Import dữ liệu Thất Bại!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                this.bindingSource1_ThuLaoChuongTrinh.DataSource = _lstNew;
            }
            
            
            //_thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
            //ThuLaoNhanVienNgoaiDai thuLao;
            //OpenFileDialog oFD = new OpenFileDialog();
            //oFD.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            //oFD.ShowDialog();
            //path = oFD.FileName;
            //string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0;";
            //OleDbConnection conn=null;
            //OleDbCommand cmd;
            //OleDbDataReader reader=null;
            //   if (path.Length > 0)
            //{
            //    try
            //    {
                    
            //        conn = new OleDbConnection(strCon);
            //        cmd = new OleDbCommand("Select * from [Sheet1$]", conn);
            //        conn.Open();
            //        reader = cmd.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            thuLao = ThuLaoNhanVienNgoaiDai.NewThuLaoNhanVienNgoaiDai();
            //            if (!reader.IsDBNull(1))
            //            {

            //                thuLao.MaChuongTrinh = maChuongTrinh;
            //                thuLao.MaKyTinhLuong = maKyTinhluong;
            //                thuLao.NgayLap = dateTimePicker_NgayLap.Value.Date;
            //                thuLao.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            //                thuLao.MaBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            //                thuLao.MaGiayXacNhan = maGiayXacNhan;
            //                thuLao.ThanhToan = false;
            //                thuLao.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
            //                thuLao.DuocNhapHo = nhapHo;
            //                thuLao.TenGiayXacNhan = tenGiayXacNhan;
            //                thuLao.TenChuongTrinh = cmbu_ChuongTrinhGXN.Text;
            //                //thuLao.SoChungTu = soChungTu;
            //                thuLao.MaChiThuLao = maChiThuLao;
            //                thuLao.TenNhanVien = Convert.ToString(reader.GetString(0));
            //                thuLao.SoTien = Convert.ToDecimal(reader.GetValue(1));
            //                if (!reader.IsDBNull(5))
            //                {
            //                    thuLao.DienGiai = Convert.ToString(reader.GetValue(5));
            //                }
            //                if (!reader.IsDBNull(3))
            //                {
            //                    thuLao.Cmnd = Convert.ToString(reader.GetValue(3));
            //                }
            //                if (!reader.IsDBNull(2))
            //                {
            //                    thuLao.PhanTramThue = Convert.ToByte(reader.GetValue(2));
            //                }
            //                if (!reader.IsDBNull(4))
            //                {
            //                    thuLao.MaSoThue = Convert.ToString(reader.GetValue(4));
            //                }
            //                if (!reader.IsDBNull(6))
            //                {
            //                    thuLao.DienThoai = Convert.ToString(reader.GetValue(6));
            //                }
            //                if (!reader.IsDBNull(7))
            //                {
            //                    thuLao.DiaChi = Convert.ToString(reader.GetValue(7));
            //                }
            //                if (!reader.IsDBNull(8))
            //                {
            //                    thuLao.SoChungTu = Convert.ToString(reader.GetValue(8));
            //                    soChungTu =thuLao.SoChungTu  ;
            //                }

            //                _thuLaoChuongTrinhList.Add(thuLao);
            //            }
            //        }
            //        this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;

            //        MessageBox.Show("Import danh sách Thù Lao Cộng Tác Viên thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Dữ liệu định dạng chưa hợp lệ, vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        throw ex;
            //    }
            //    finally
            //    {
            //        reader.Close();
            //        conn.Close();
            //    }
            //}
            
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
           // DownloadFile();
            
           


        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (_hoanTat == true && maChiThuLao != 0)
                {
                    MessageBox.Show("Phiếu Chi đã  hoàn tất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    if (maChiTietGiayXacNhan != 0 && maChiThuLao != 0)
                    {
                        if (GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(maGiayXacNhan).MaChuongTrinh != ChiThuLao.GetChiThuLao(maChiThuLao).MaChuongTrinh)
                        {
                            MessageBox.Show("Chương trình từ Giấy Xác Nhận và Phiếu Chi không giống nhau", "ThôngBáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    decimal soTienDaNhap = 0;
                    foreach (ThuLaoNhanVienNgoaiDai tl in _thuLaoChuongTrinhList)
                    {
                        KyTinhLuong ktlTrack = KyTinhLuong.GetKyTinhLuong(tl.MaKyTinhLuong);
                        tl.NgayLap = dateTimePicker_NgayLap.Value.Date;
                        tl.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                        tl.MaBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
                        tl.TenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
                        tl.NgayChungTu = _NgayChungTu;
                        if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 22)
                        {
                            ChiPhiThucHienList _cpthuchien = ChiPhiThucHienList.GetChiPhiThucHienListBySoChungTu(tl.SoChungTu);

                            tl.TenChuongTrinh = _cpthuchien[0].TenChuongTrinh;
                            tl.MaChuongTrinh = _cpthuchien[0].MaChuongTrinh;
                            tl.MaPhieuChi = tl.SoChungTu;
                            tl.MaChungTu = _cpthuchien[0].MaChungTu;
                            
                        }
                        else
                        {
                            tl.TenChuongTrinh = tenChuongTrinh;
                            tl.MaChuongTrinh = maChuongTrinh;
                             tl.SoChungTu = soChungTu;
                             tl.MaPhieuChi = soChungTu;
                             tl.MaChungTu = maChungTu;
                        }
                        tl.MaKyTinhLuong = maKyTinhluong;
                        //tl.MaPhieuChi = soChungTu;
                        tl.MaGiayXacNhan = maGiayXacNhan;
                        tl.TenGiayXacNhan = tenGiayXacNhan;
                        tl.MaChiThuLao = maChiThuLao;
                       
                        tl.ThanhToan = false;
                        tl.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                        tl.DuocNhapHo = nhapHo;
                        soTienDaNhap += tl.SoTien;
                        tl.Loai = Convert.ToInt32(cmbLoai.Value);
                    }

                    _thuLaoChuongTrinhList.ApplyEdit();
                    bindingSource1_ThuLaoChuongTrinh.EndEdit();
                    _thuLaoChuongTrinhList.Save();
                    if (maChiTietGiayXacNhan != 0)
                    {
                        //  ChiTietGiayXacNhan.UpdateSoTienNhanVienNgoaiDaiGXN(maChiTietGiayXacNhan, databaseNumberGXN, Database.DatabaseNumber, soTienDaNhap);
                    }
                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao(ERP_Library.Security.CurrentUser.Info.UserID, maChiThuLao);
                    ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
                    _chiThuLaoList.Insert(0, itemChiTL);
                    this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;

                    tbSoTienConLaiPC.Value = ChiThuLao.SoTienConLaiPhieuChi(maChiThuLao);
                    tbSoTienConLaiGXN.Value = ChiTietGiayXacNhanTongHop.GetChiTietGiayXacNhanTongHop(maChiTietGiayXacNhan).SoTienConLai;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            
           
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {            
            ngoaiDaiList = NhanVienNgoaiDaiList.NewNhanVienNgoaiDaiList();
            NhanVienNgoaiDaiTam nvTam;
            NhanVienNgoaiDai nv;
            try
            {
                for (int i = 0; i < grdData.Rows.Count; i++)
                {
                    //Lưu NV Ngoài Đài
                    nv = NhanVienNgoaiDai.NewNhanVienNgoaiDai();
                    nv.Cmnd = (string)grdData.Rows[i].Cells["CMND"].Value;
                    nv.DiaChi = (string)grdData.Rows[i].Cells["Địa Chỉ"].Value;
                    nv.DienThoai = (string)grdData.Rows[i].Cells["Điện Thoại"].Value;
                    nv.GhiChu = (string)grdData.Rows[i].Cells["Diễn Giải"].Value;
                    nv.LoaiNhanVien = 2;
                    nv.Mst = (string)grdData.Rows[i].Cells["Mã Số Thuế"].Value;
                    nv.NgayLap = DateTime.Today.Date;
                    nv.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                    nv.SuDung = true;
                    nv.SoTien = Convert.ToDecimal(grdData.Rows[i].Cells["Số Tiền"].Value);
                    nv.TenNhanVien = (string)grdData.Rows[i].Cells["Họ Tên"].Value;
                    ngoaiDaiList.Add(nv);
                }
                ngoaiDaiList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bindingSource1_NhanVien.DataSource = ngoaiDaiList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Dữ Liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
    

        }

 
        private void cbChungTu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChungTu, "SoChungTu");
            foreach (UltraGridColumn col in this.cbChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Phiếu Chi";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 120;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.Caption = "Tên Bộ Phận Nhận";
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Width = 150;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.VisiblePosition = 1;

            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.Caption = "Tên Bộ Phận Gửi";
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Width = 150;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.VisiblePosition = 2;

            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 200;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 3;

            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 4;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;



            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Width = 60;
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 5;
        }

        private void cbChiTietGiayXacNhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
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

        private void cbKyTinhLuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
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

        private void cbChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (cbChungTu.ActiveRow!= null)
            {
                maChiThuLao = Convert.ToInt64(cbChungTu.ActiveRow.Cells["MaChiThuLao"].Value);
            }

            if (maChiThuLao != 0)
            {


                maChuongTrinh = (int)cbChungTu.ActiveRow.Cells["MaChuongTrinh"].Value;
                tenChuongTrinh = (string)cbChungTu.ActiveRow.Cells["TenChuongTrinh"].Value;
                _tienTuPhieuChi = (decimal)cbChungTu.ActiveRow.Cells["SoTien"].Value;
                _NgayChungTu = (DateTime)cbChungTu.ActiveRow.Cells["NgayLap"].Value;
                _hoanTat = (bool)cbChungTu.ActiveRow.Cells["HoanTat"].Value;
                soChungTu = (string)cbChungTu.ActiveRow.Cells["SoChungTu"].Value;
                ghiChuPhieuChi = (string)cbChungTu.ActiveRow.Cells["GhiChu"].Value;
                ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
                maNguon = ct.MaNguon;
                tenNguon = ct.TenNguon;
                tbSoTienPhieuChi.Value = _tienTuPhieuChi;
                tbSoTienConLaiPC.Value = ChiThuLao.SoTienConLaiPhieuChi(maChiThuLao);
                cmbu_ChuongTrinh.EditValue = maChuongTrinh;
                cmbu_ChuongTrinh.Enabled = false;

            }


            else
            {
                soChungTu = string.Empty;
                tbSoTienPhieuChi.Value = 0;
                tbSoTienConLaiPC.Value = 0;
            }
        }

        private void cbChiTietGiayXacNhan_ValueChanged(object sender, EventArgs e)
        {
            maChiTietGiayXacNhan = 0;
            if (cbChiTietGiayXacNhan.ActiveRow != null)
            {
                maChiTietGiayXacNhan = Convert.ToInt32(cbChiTietGiayXacNhan.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value);
            }
            //if (cbChiTietGiayXacNhan.Value != null &&maChiTietGiayXacNhan != 0)
            if (maChiTietGiayXacNhan != 0)
            {
              
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

                GiayXacNhanTongHop gxn = GiayXacNhanTongHop.GetGiayXacNhanChuongTrinh(maGiayXacNhan);

                maChuongTrinh = gxn.MaChuongTrinh;
                tenChuongTrinh = gxn.TenChuongTrinh;

                TbTongTienGXN.Value = _tienChiTietGiayXacNhan;
               
                cmbu_ChuongTrinh.EditValue = maChuongTrinh;

                chiTietGXN = ChiTietGiayXacNhanTongHop.GetChiTietGiayXacNhanTongHop(maChiTietGiayXacNhan);
                tbSoTienConLaiGXN.Value = chiTietGXN.SoTienConLai;
            }
            else
            {
                cmbu_ChuongTrinh.EditValue = maChuongTrinh;
                //maChuongTrinh = 0;
                _tienChiTietGiayXacNhan = 0;
                TbTongTienGXN.Value = 0;
                tenGiayXacNhan = string.Empty;
                maGiayXacNhan = 0;
                maChiTietGiayXacNhan = 0;
                nhapHo = false;
                cmbu_ChuongTrinh.EditValue = maChuongTrinh;
                TbTongTienGXN.Value = 0;
                tbSoTienConLaiGXN.Value = 0;
            }
        }

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhluong = (int)cbKyTinhLuong.Value;

            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (KyTinhLuong.GetKyTinhLuong(maKyTinhluong).KhoaSoKy2 != true)
            {
                for (int i = 0; i < grdData.Rows.Count; i++)
                {
                    if ((bool)grdData.Rows[i].Cells["Check"].Value == true)
                    {
                        grdData.Rows[i].Selected = true;
                    }
                }
                grdData.DeleteSelectedRows();  
            }
            else
            {
                MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

     
        private void grdu_QuocGia_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
           // e.Layout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
           // e.Layout.Override.CellClickAction = CellClickAction.CellSelect;
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                col.CellActivation = Activation.AllowEdit;
            }
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Họ Tên";
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;
             
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdData.DisplayLayout.Bands[0].Columns["PhanTramThue"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["PhanTramThue"].Header.Caption = "%Thuế";
            grdData.DisplayLayout.Bands[0].Columns["PhanTramThue"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["PhanTramThue"].Width = 60;
            grdData.DisplayLayout.Bands[0].Columns["PhanTramThue"].Format = "###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["PhanTramThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdData.DisplayLayout.Bands[0].Columns["TienThue"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TienThue"].Header.Caption = "Tiền Thuế";
            grdData.DisplayLayout.Bands[0].Columns["TienThue"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["TienThue"].Width = 80;
            grdData.DisplayLayout.Bands[0].Columns["TienThue"].Format = "###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["TienThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Tiền Sau Thuế";
            grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 4;
            grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 80;
            grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;


            grdData.DisplayLayout.Bands[0].Columns["Cmnd"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["Cmnd"].Header.Caption = "CMND";
            grdData.DisplayLayout.Bands[0].Columns["Cmnd"].Header.VisiblePosition = 5;
            grdData.DisplayLayout.Bands[0].Columns["Cmnd"].Width = 80;

            grdData.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";
            grdData.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 6;
            grdData.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 80;          
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 7;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 200;

            grdData.DisplayLayout.Bands[0].Columns["DienThoai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            grdData.DisplayLayout.Bands[0].Columns["DienThoai"].Header.VisiblePosition=8 ;
            grdData.DisplayLayout.Bands[0].Columns["DienThoai"].Width = 80;

            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 200;
            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 9;

            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chưng Từ";
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 150;
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 10;
        }
        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdData.ActiveCell != null && !grdData.ActiveCell.IsInEditMode && grdData.ActiveCell.Column.Key != "TenNhanVien")
            {
                if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    grdData.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    grdData.ActiveCell.SelectAll();
                    iskeyok = true;
                }
                if (e.KeyCode == Keys.Space && grdData.ActiveCell.Column.DataType == typeof(bool))
                {
                    grdData.ActiveCell.Value = !Convert.ToBoolean(grdData.ActiveCell.Value);
                }
            }
        }

        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iskeyok && grdData.ActiveCell.Row.IsDataRow)
            {
                if (grdData.ActiveCell.Column.DataType == typeof(decimal))
                    try
                    {
                        grdData.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                    }
                    catch
                    { }
                else
                    grdData.ActiveCell.Value = e.KeyChar.ToString();
                grdData.ActiveCell.SelStart = grdData.ActiveCell.Text.Length;
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
                    if (iscopyok && grdData.Selected != null && grdData.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdData.Selected.Cells)
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

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel|*.xls|All file|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //tạo file template
                FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Write(Properties.Resources.CongTacVienExport, 0, Properties.Resources.CongTacVienExport.Length);
                fs.Close();
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        private void grdData_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Row.IsDataRow)
            {
                string t = e.Cell.Column.Key;
                if (t == "PhanTramThue" || t == "SoTien")
                {
                    decimal sotien = Convert.ToDecimal(e.Cell.Row.Cells["SoTien"].Value);
                    decimal ts = Convert.ToDecimal(e.Cell.Row.Cells["PhanTramThue"].Value);
                    e.Cell.Row.Cells["TienThue"].Value = Math.Round(sotien * ts / 100, 0);
                    e.Cell.Row.Cells["SoTienConLai"].Value = sotien - Math.Round(sotien * ts / 100, 0);
                }
                //else if (t == "TienThue")
                //{
                //    decimal sotien = Convert.ToDecimal(e.Cell.Row.Cells["SoTienConLai"].Value);
                //    decimal thue = Convert.ToDecimal(e.Cell.Value);
                //    e.Cell.Row.Cells["SoTien"].Value = sotien + thue;
                //}
            }
        }

        private void cmbu_ChuongTrinh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.EditValue != null)
            {
                if ((int)cmbu_ChuongTrinh.EditValue != 0 || cmbu_ChuongTrinh.EditValue != null)
                {
                    maChuongTrinh = (int)cmbu_ChuongTrinh.EditValue;
                    ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
                    if(ct!=null)
                    tenChuongTrinh = ct.TenChuongTrinh;
                }
            }
        }

    }
}
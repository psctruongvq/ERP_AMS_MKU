using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Data.OleDb;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.IO;
namespace PSC_ERP.UserInterface.ThuChi.Import
{

    public partial class Import : Form
    {
        BoPhanList _boPhanList;
        int maBoPhan = 0;
        ImportChungTuHVT import;
        ImportChungTuHVTList importList = ImportChungTuHVTList.NewImportChungTuHVTList();
        ImportChungTuHVTList importListDelete = ImportChungTuHVTList.NewImportChungTuHVTList();
        ImportChungTuHVTList importListBySoChungTuList = ImportChungTuHVTList.NewImportChungTuHVTList();
        ImportChungTuHVTList importListByButToanList = ImportChungTuHVTList.NewImportChungTuHVTList();
        ImportChungTuHVTList importListByMucNganSachList = ImportChungTuHVTList.NewImportChungTuHVTList();

        ChungTuImport chungTuImport = ChungTuImport.NewChungTuImport();
        ChungTuImportList chungTuImportList = ChungTuImportList.NewChungTuImportList();
        ButToanImport butToanImport = ButToanImport.NewButToanImport();
        ButToanImportList butToanImportList = ButToanImportList.NewButToanImportList();
        ButToan_MucNganSachImport mucNganSachImport = ButToan_MucNganSachImport.NewButToan_MucNganSachImport();
        ButToan_MucNganSachImportList mucNganSachImportList = ButToan_MucNganSachImportList.NewButToan_MucNganSachImportList();

        ImportChungTuHVTList list;
        int maBuToan = 0;
        int _maButToanMucNganSach = 0;
        public Import()
        {
            InitializeComponent();
            list = ImportChungTuHVTList.GetImportChungTuHVT_ByDanhSach();
            bindingSource2.DataSource = list;
        }

        private void Import_Load(object sender, EventArgs e)
        {
            _boPhanList = BoPhanList.GetBoPhanListBy_All();        
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
        }
        #region Data Access - Insert

        long _maChungTu = 0;
        private void ExecuteInsertChungTu(SqlTransaction tr, ImportChungTuHVT chungTu)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblChungTuImport";
                AddInsertChungTuParameters(cm, chungTu);
                cm.ExecuteNonQuery();
                _maChungTu = (long)cm.Parameters["@MaChungTu"].Value;
                //foreach (ImportChungTuHVT import in importListByButToanList)
                //{//loi can xem lai--
                //    if (import.SoChungTu == chungTu.SoChungTu &&import.IsSave==true)// && chungTu.SoTien == import.SoTienButToan && chungTu.DienGiaiCT == import.DienGiaiBT)
                //    {

                ExecuteInsertBuToan(tr, chungTu, _maChungTu);
                import.IsSave = false;
              
                //    }

                //}

            }
        }

        private void AddInsertChungTuParameters(SqlCommand cm, ImportChungTuHVT chungTu)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@SoChungTu", chungTu.SoChungTu);
            cm.Parameters.AddWithValue("@NgayLap", chungTu.NgayLap);
            cm.Parameters.AddWithValue("@MucNganSach", DBNull.Value);

            cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (chungTu.LoaiChungTu != 0)
                cm.Parameters.AddWithValue("@MaLoaiChungTu", chungTu.LoaiChungTu);
            else
                cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
            if (chungTu.DienGiaiCT.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", chungTu.DienGiaiCT);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);

            cm.Parameters.AddWithValue("@MaDoiTuongThuChi", DBNull.Value);
            if (chungTu.MaBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", chungTu.MaBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (chungTu.SoTien != 0)
                cm.Parameters.AddWithValue("@SoTien", chungTu.SoTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (chungTu.TiGia != 0)
                cm.Parameters.AddWithValue("@TyGia", chungTu.TiGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            if (chungTu.ThanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", chungTu.ThanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);

                     
            cm.Parameters.AddWithValue("@KhachHangTrongDai", chungTu.KhachHangTrongDai);
            cm.Parameters.AddWithValue("@DiaChi", chungTu.DiaChi);
            cm.Parameters.AddWithValue("@KhachHangNgoaiDai", chungTu.KhachHangNgoaiDai);
            cm.Parameters.AddWithValue("@DiaChi1", chungTu.DiaChi1);

            cm.Parameters.AddWithValue("@GhiSoCai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            cm.Parameters["@MaChungTu"].Direction = ParameterDirection.Output;
        }

        private void ExecuteInsertBuToan(SqlTransaction tr, ImportChungTuHVT butToan, long maChungTu)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblButToanImport";
                AddInsertButToanParameters(cm, butToan, maChungTu, butToan.DienGiaiBT);
                cm.ExecuteNonQuery();
                maBuToan = (int)cm.Parameters["@MaButToan"].Value;
                if (butToan.SoTienTieuMuc != 0)
                {
                    ExecuteInsertMucNganSach(tr, butToan, maBuToan, import.DienGiaiMuc);
                }
            }
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblButToanImport_ChiPhiHD";
                AddInsertButToanImport_ChiPhiHDParameters(cm, butToan);
                cm.ExecuteNonQuery();
            }
        }
        private void AddInsertButToanImport_ChiPhiHDParameters(SqlCommand cm, ImportChungTuHVT butToan)
        {

            int _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            string _tenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
            cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            cm.Parameters.AddWithValue("@MaChiPhiHD", DBNull.Value);
            cm.Parameters.AddWithValue("@TenChiPhiHD", DBNull.Value);
            if (maBuToan != 0)
                cm.Parameters.AddWithValue("@MaButToan", maBuToan);
            else
                cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
            if (butToan.SoTien != 0)
                cm.Parameters.AddWithValue("@SoTien", butToan.SoTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", DateTime.Today.Date);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@ThuChi", 0);
            cm.Parameters.AddWithValue("@MaButToanCPHD", 0);
            cm.Parameters["@MaButToanCPHD"].Direction = ParameterDirection.Output;
        }

        private void AddInsertButToanParameters(SqlCommand cm, ImportChungTuHVT butToan, long maChungTu, string dienGiai)
        {
         
            //TODO: if parent use identity key, fix fk member with value from parent
            if (butToan.TKNo.Length > 0)
                cm.Parameters.AddWithValue("@NoTaiKhoan", butToan.TKNo);
            else
                cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
            if (butToan.TKCo.Length > 0)
                cm.Parameters.AddWithValue("@CoTaiKhoan", butToan.TKCo);
            else
                cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTien", butToan.SoTienButToan);
            if (butToan.DienGiaiBT.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", butToan.DienGiaiBT);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
            cm.Parameters.AddWithValue("@MaButToan", maBuToan);
            cm.Parameters["@MaButToan"].Direction = ParameterDirection.Output;
        }
        private void ExecuteInsertMucNganSach(SqlTransaction tr, ImportChungTuHVT mucNganSach, int maBuToan, string dienGiai)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblButToan_MucNganSachImport";

                AddInsertMucNganSachParameters(cm, mucNganSach, maBuToan, dienGiai);

                cm.ExecuteNonQuery();

                _maButToanMucNganSach = (int)cm.Parameters["@MaButToanMucNganSach"].Value;
            }//using
        }

        private void AddInsertMucNganSachParameters(SqlCommand cm, ImportChungTuHVT mucNganSach, int maBuToan, string dienGiai)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaButToan", maBuToan);
            cm.Parameters.AddWithValue("@MaTieuMuc", mucNganSach.MucNganSach);
            cm.Parameters.AddWithValue("@SoTien", mucNganSach.SoTienTieuMuc);

            if (mucNganSach.DienGiaiMuc.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", mucNganSach.DienGiaiMuc);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToanMucNganSach", 0);
            cm.Parameters["@MaButToanMucNganSach"].Direction = ParameterDirection.Output;
            if (mucNganSach.SoTienTieuMuc < 0)
            {
                if (mucNganSach.SoTienTieuMuc < 0)
                {

                }   
            }
        }
        #endregion //Data Access - Insert

        private void button1_Click(object sender, EventArgs e)
        {           

        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (maBoPhan == 0)
            {
                MessageBox.Show("Chọn đơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            oFD.ShowDialog();
            string path = oFD.FileName;
            string p = System.IO.Path.GetFileName(path);
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0;";
            OleDbConnection conn = null;
            OleDbCommand cmd;
            OleDbDataReader reader = null;
            ImportChungTuHVTList importListHTV = ImportChungTuHVTList.GetImportChungTuHVTList();
            importList = ImportChungTuHVTList.NewImportChungTuHVTList();
            for (int i = 0; i < importListHTV.Count; i++)
            {
                if (importListHTV[i].FileName == p)
                {
                    MessageBox.Show("File " + p + " đã được Import. Bạn phải xóa dữ liệu của File này nếu muốn tiếp tục import", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //importList.Clear();
            //importList.ApplyEdit();
            //importList.Save();
            if (path.Length > 0)
            {
                try
                {
                    conn = new OleDbConnection(strCon);
                    cmd = new OleDbCommand("Select SoChungTu, NgayLap, SoTien, TyGia, ThanhTien, DienGiaiBT, KhachHangTrong, DiaChiTrong,KhachHangNgoai, DiaChiNgoai,TKNo, TKCo, SoTienButToan, LoaiChungTu, DienGiaiCT  from [Sheet1$] where SoChungTu is not null", conn);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        import = ImportChungTuHVT.NewImportChungTuHVT();
                        if (!reader.IsDBNull(0))
                            import.SoChungTu = Convert.ToString(reader.GetValue(0));
                        if (!reader.IsDBNull(1))
                            import.NgayLap = Convert.ToDateTime(reader.GetValue(1));
                        if (!reader.IsDBNull(2))
                            import.SoTien = Convert.ToDecimal(reader.GetValue(2));
                        if (!reader.IsDBNull(3))
                            import.TiGia = Convert.ToInt32(reader.GetValue(3));
                        if (!reader.IsDBNull(4))
                            import.ThanhTien = Convert.ToDecimal(reader.GetValue(4));
                        if (!reader.IsDBNull(5))
                            import.DienGiaiBT = Convert.ToString(reader.GetValue(5));                                        
                            import.MaBoPhan = maBoPhan;                     
                        if (!reader.IsDBNull(6))
                            import.KhachHangTrongDai = Convert.ToString(reader.GetValue(6));
                        if (!reader.IsDBNull(7))
                            import.DiaChi = Convert.ToString(reader.GetValue(7));
                        if (!reader.IsDBNull(8))
                            import.KhachHangNgoaiDai = Convert.ToString(reader.GetValue(8));
                        if (!reader.IsDBNull(9))
                            import.DiaChi1 = Convert.ToString(reader.GetValue(9));
                        if (!reader.IsDBNull(10))
                            import.TKNo = Convert.ToString(reader.GetValue(10));
                        if (!reader.IsDBNull(11))
                            import.TKCo = Convert.ToString(reader.GetValue(11));
                        if (!reader.IsDBNull(12))//
                            import.SoTienButToan = Convert.ToDecimal(reader.GetValue(12));//, SoTienTieuMuc, MaTieuMuc
                        //if (!reader.IsDBNull(13))
                        //    import.SoTienTieuMuc = Convert.ToDecimal(reader.GetValue(13));
                        //if (!reader.IsDBNull(14))
                        //    import.MucNganSach = Convert.ToString(reader.GetValue(14));
                        if (!reader.IsDBNull(13))
                        {
                            string loaichungtuStr = Convert.ToString(reader.GetValue(13));
                            if (loaichungtuStr == "Phiếu Thu")
                            {
                                import.LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PT111").MaLoaiCT; //Convert.ToInt32(reader.GetValue(15));
                            }
                            else if (loaichungtuStr == "Phiếu Chi")
                            {
                                import.LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PC111").MaLoaiCT; //Convert.ToInt32(reader.GetValue(15));
                            }
                            else if (loaichungtuStr == "Chứng Từ Kế Toán")
                            {
                                import.LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PKT").MaLoaiCT; //Convert.ToInt32(reader.GetValue(15));
                            }
                        }
                        if (!reader.IsDBNull(14))
                            import.DienGiaiCT = Convert.ToString(reader.GetValue(14));//,DienGiaiMuc
                        //if (!reader.IsDBNull(17))
                        //    import.DienGiaiMuc = Convert.ToString(reader.GetValue(17));
                        import.FileName = p;
                        importList.Add(import);
                    }
                    importList.ApplyEdit();
                    importList.Save();
                    this.bindingSource1.DataSource = importList;
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    reader.Close();
                    conn.Close();
                    importListBySoChungTuList = ImportChungTuHVTList.GetImportChungTuHVT_DistinctBySoChungTu();
     
                }
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            importList.ApplyEdit();
            importList.Save();
        
            SqlTransaction tr;
            foreach (ImportChungTuHVT import in importListBySoChungTuList)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    try
                    {

                        if (import.IsSaved == false)
                        {
                            ExecuteInsertChungTu(tr, import);
                            tr.Commit();
                            import.IsSaved = true;
                        }   
                      
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        throw;
                    }
                }
            }
           
            MessageBox.Show("Lưu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                col.CellActivation = Activation.ActivateOnly;
               
            }
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;

            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";

            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Format="###,###,###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdData.DisplayLayout.Bands[0].Columns["TiGia"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TiGia"].Header.Caption = "Tỉ Giá";
            grdData.DisplayLayout.Bands[0].Columns["TiGia"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["TiGia"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdData.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdData.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 4;
            grdData.DisplayLayout.Bands[0].Columns["ThanhTien"].Format = "###,###,###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["ThanhTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            grdData.DisplayLayout.Bands[0].Columns["DienGiaiCT"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienGiaiCT"].Header.Caption = "Diễn Giải";
            grdData.DisplayLayout.Bands[0].Columns["DienGiaiCT"].Header.VisiblePosition = 5;

            grdData.DisplayLayout.Bands[0].Columns["KhachHangNgoaiDai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["KhachHangNgoaiDai"].Header.Caption = "Khách Hàng Ngoài";
            grdData.DisplayLayout.Bands[0].Columns["KhachHangNgoaiDai"].Header.VisiblePosition = 6;

            grdData.DisplayLayout.Bands[0].Columns["DiaChi1"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DiaChi1"].Header.Caption = "Địa Chỉ Ngoài";
            grdData.DisplayLayout.Bands[0].Columns["DiaChi1"].Header.VisiblePosition = 7;

            grdData.DisplayLayout.Bands[0].Columns["KhachHangTrongDai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["KhachHangTrongDai"].Header.Caption = "Khách Hàng Trong";
            grdData.DisplayLayout.Bands[0].Columns["KhachHangTrongDai"].Header.VisiblePosition = 8;

            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            grdData.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 9;

            grdData.DisplayLayout.Bands[0].Columns["TKNo"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TKNo"].Header.Caption = "TK Nợ";
            grdData.DisplayLayout.Bands[0].Columns["TKNo"].Header.VisiblePosition = 10;

            grdData.DisplayLayout.Bands[0].Columns["TKCo"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TKCo"].Header.Caption = "TK Có";
            grdData.DisplayLayout.Bands[0].Columns["TKCo"].Header.VisiblePosition = 11;

            grdData.DisplayLayout.Bands[0].Columns["SoTienButToan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTienButToan"].Header.Caption = "Số Tiền Bút Toán";
            grdData.DisplayLayout.Bands[0].Columns["SoTienButToan"].Header.VisiblePosition = 12;
            grdData.DisplayLayout.Bands[0].Columns["SoTienButToan"].Format = "###,###,###,###,###,###";
            grdData.DisplayLayout.Bands[0].Columns["SoTienButToan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            //grdData.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Hidden = false;
            //grdData.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.Caption = "Số Tiền Tiểu Mục";
            //grdData.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.VisiblePosition = 13;
            //grdData.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Format = "###,###,###,###,###,###";
            //grdData.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            //grdData.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Hidden = false;
            //grdData.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Header.Caption = "Diễn Giải Mục";
            //grdData.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Header.VisiblePosition = 14;

            grdData.DisplayLayout.Bands[0].Columns["LoaiChungTu"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["LoaiChungTu"].Header.Caption = "Loại Chứng Từ";
            grdData.DisplayLayout.Bands[0].Columns["LoaiChungTu"].Header.VisiblePosition = 15;



            UltraGridColumn columnToSummarize1 = e.Layout.Bands[0].Columns["SoTien"];
            SummarySettings summary1 = grdData.DisplayLayout.Bands[0].Summaries.Add("SoTien", SummaryType.Sum, columnToSummarize1);
            summary1.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary1.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary1.Appearance.TextHAlign = HAlign.Right;
            summary1.SummaryType = SummaryType.Sum;
            summary1.SummaryPositionColumn = columnToSummarize1;

            UltraGridColumn columnToSummarize4 = e.Layout.Bands[0].Columns["ThanhTien"];
            SummarySettings summary4 = grdData.DisplayLayout.Bands[0].Summaries.Add("ThanhTien", SummaryType.Sum, columnToSummarize4);
            summary4.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary4.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary4.Appearance.TextHAlign = HAlign.Right;
            summary4.SummaryType = SummaryType.Sum;
            summary4.SummaryPositionColumn = columnToSummarize4;

            UltraGridColumn columnToSummarize2 = e.Layout.Bands[0].Columns["SoTienButToan"];
            SummarySettings summary2 = grdData.DisplayLayout.Bands[0].Summaries.Add("SoTienButToan", SummaryType.Sum, columnToSummarize2);
            summary2.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary2.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary2.Appearance.TextHAlign = HAlign.Right;
            summary2.SummaryType = SummaryType.Sum;
            summary2.SummaryPositionColumn = columnToSummarize2;


            UltraGridColumn columnToSummarize3 = e.Layout.Bands[0].Columns["SoTienTieuMuc"];
            SummarySettings summary3 = grdData.DisplayLayout.Bands[0].Summaries.Add("SoTienTieuMuc", SummaryType.Sum, columnToSummarize3);
            summary3.SummaryPosition = SummaryPosition.UseSummaryPositionColumn;
            summary3.DisplayFormat = "Tổng={0:###,###,###,###,###,###}";
            summary3.Appearance.TextHAlign = HAlign.Right;
            summary3.SummaryType = SummaryType.Sum;
            summary3.SummaryPositionColumn = columnToSummarize3;

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;

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

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                maBoPhan = Convert.ToInt32(cmbu_Bophan.Value);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultraTabControl1.SelectedTab.Index == 1)
            {
                if (ultraGrid2.Selected.Rows.Count != 1)
                {
                    MessageBox.Show("Chọn một dòng để xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn xóa hết dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string ds = (string)ultraGrid2.ActiveRow.Cells["FileName"].Value;
                        using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                        {
                            cn.Open();
                            SqlCommand cm = cn.CreateCommand();
                            cm.CommandType = System.Data.CommandType.StoredProcedure;
                            cm.CommandText = "DeleteChungTuImport";
                            cm.Parameters.AddWithValue("@TenDanhSach", ds);
                            cm.ExecuteNonQuery();
                            cn.Close();
                            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }        
                }
            }
            ImportChungTuHVTList list = ImportChungTuHVTList.GetImportChungTuHVT_ByDanhSach();
            bindingSource2.DataSource = list;
         
        }

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (ultraTabControl1.SelectedTab.Index == 1)
            {
                ImportChungTuHVTList list = ImportChungTuHVTList.GetImportChungTuHVT_ByDanhSach();
                bindingSource2.DataSource = list;
               // ultraGrid2.InitializeLayout += new InitializeLayoutEventHandler(ultraGrid2_InitializeLayout);
            }
        }

        private void ultraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.ultraGrid2.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                col.CellActivation = Activation.ActivateOnly;

            }
            ultraGrid2.DisplayLayout.Bands[0].Columns["FileName"].Hidden = false;
            ultraGrid2.DisplayLayout.Bands[0].Columns["FileName"].Header.Caption = "Tên Danh Sách Chứng Từ Import";
            ultraGrid2.DisplayLayout.Bands[0].Columns["FileName"].Header.VisiblePosition = 0;
            ultraGrid2.DisplayLayout.Bands[0].Columns["FileName"].Width = 600;

        }

        private void tlsBtn_ExportMauNhapLieu_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel|*.xls|All file|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //tạo file template
                FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Write(Properties.Resources.TemplateImportChungTu, 0, Properties.Resources.TemplateImportChungTu.Length);
                fs.Close();




                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }
    }
}


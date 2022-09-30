
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Infragistics.Win;
using Infragistics.Win.UltraWinTree;
using PSC_ERP_Common;
using System.IO;
using System.Net;
using System.Configuration;

namespace PSC_ERP
{
    public partial class frmSoHoaChungTu : Form
    {
        #region
        LoaiVanBanList _loaiVanBanList;
        VanBan _vanBan = null;
        int _soVB = 100;
        bool _isChungTuMoi = false;
        ChungTuCu _chungTuCurrent;
        #endregion

        public frmSoHoaChungTu()
        {
            InitializeComponent();
        }
        public void ShowSoHoaChungTuCu()
        {
            //
            _loaiVanBanList = LoaiVanBanList.GetLoaiVanBanList();
            LoaiVanBan_BindingSource.DataSource = _loaiVanBanList;

            this.Show();
        }
        public void ShowSoHoaChungTuMoi()
        {
            //
            _loaiVanBanList = LoaiVanBanList.GetLoaiVanBanList();
            LoaiVanBan_BindingSource.DataSource = _loaiVanBanList;

            _isChungTuMoi = true;

            this.Show();
        }

        private void TreeThongTinVanBan_DoubleClick(object sender, EventArgs e)
        {

            if (TreeDanhSachVanBan.SelectedNodes.Count > 0)
            {
                //Lấy văn bản hiện tại đã chọn
                UltraTreeNode nodeCurrent = TreeDanhSachVanBan.SelectedNodes[0];

                if (nodeCurrent.Tag != null)
                {
                    _vanBan = VanBan.GetVanBan((long)nodeCurrent.Tag);
                }
            }
            frmChiTietVanBan frm = new frmChiTietVanBan(_vanBan);
            frm.ShowDialog(this);
        }

        private void cmbuLoaiVanBan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbuLoaiVanBan, "MaQuanLy");
            foreach (UltraGridColumn col in this.cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns["TenLoaiVanBan"].Hidden = false;
            cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            // cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns["MaLoaiCha"].Hidden = false;

            cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns["TenLoaiVanBan"].Width = cmbuLoaiVanBan.Width;

            cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns["TenLoaiVanBan"].Header.Caption = "Tên Loại Văn Bản";
            cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            // cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns["MaLoaiCha"].Header.Caption = "Mã Loại Văn Bản Cha";

            cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns["TenLoaiVanBan"].Header.VisiblePosition = 1;
            cmbuLoaiVanBan.DisplayLayout.Bands[0].Columns["MaLoaiCha"].Header.VisiblePosition = 2;

        }

        private void TreeDanhSachVanBan_AfterSelect(object sender, SelectEventArgs e)
        {
            Boolean daChonDuLieu = false;

            if (TreeDanhSachVanBan.SelectedNodes.Count > 0)
            {
                //Lấy văn bản hiện tại
                UltraTreeNode nodeCurrent = TreeDanhSachVanBan.SelectedNodes[0];
                if (nodeCurrent.Tag != null && (long)nodeCurrent.Tag != 0)
                {
                    _vanBan = VanBan.GetVanBan((long)nodeCurrent.Tag);
                    VanBan_BindingSource.DataSource = _vanBan;
                    daChonDuLieu = true;
                }
            }
            if (daChonDuLieu == false)
            {
                VanBan_BindingSource.Clear();
                cmbuLoaiVanBan.Value = null;
                dteNgayLap.Value = DateTime.Now.Date;
                txtTenVanBan.Value = string.Empty;
                txtNoiDungTimKiem.Value = string.Empty;
                _vanBan = null;
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cmbuLoaiVanBan == null || (cmbuLoaiVanBan != null && Convert.ToInt32(cmbuLoaiVanBan.Value) == 0))
            {
                DialogUtil.ShowWarning("Vui lòng chọn loại văn bản.");
                cmbuLoaiVanBan.Focus();
                return;
            }

            if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn có thật sự muốn thêm văn bản mới không?"))
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Chọn Văn Bản";
                    dlg.Filter = "File PDF (*.pdf)|*.pdf";
                    dlg.AddExtension = true;

                    string namefile = string.Empty;
                    string urlOnServer = string.Empty;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            //Upload file lên server
                            if (UploadFileToFTP(dlg.FileName, ref urlOnServer, ref namefile))
                            {
                                //Khởi tạo văn bản mới
                                _vanBan = VanBan.NewVanBan();

                                if (string.IsNullOrEmpty(Convert.ToString(txtTenVanBan.Value)))
                                {
                                    _vanBan.TenVanBan = System.IO.Path.GetFileName(dlg.FileName);// Lấy tên của file
                                }
                                else
                                {
                                    _vanBan.TenVanBan = Convert.ToString(txtTenVanBan.Value);//Lấy tên người dùng nhập
                                }
                                _vanBan.MaLoaiVanBan = Convert.ToInt32(cmbuLoaiVanBan.Value);
                                _vanBan.NgayLap = Convert.ToDateTime(dteNgayLap.Value);
                                _vanBan.UserId = ERP_Library.Security.CurrentUser.Info.UserID;
                                _vanBan.DienGiai = Convert.ToString(txtNoiDungTimKiem.Value);
                                _vanBan.Idx = LayIndexMaxCuaVanBan();
                                _vanBan.TenVanBanCT = namefile;

                                if (_chungTuCurrent != null && _isChungTuMoi == false)
                                {
                                    _vanBan.MaChungTuCu = _chungTuCurrent.MaChungTuCu;
                                }
                                if (_chungTuCurrent != null && _isChungTuMoi)
                                {
                                    _vanBan.MaChungTu = Convert.ToInt32(_chungTuCurrent.MaChungTuCu);
                                }

                                //Lấy đường dẫn trên server
                                _vanBan.DuongDan = urlOnServer;

                                _vanBan.ApplyEdit();
                                _vanBan.Save();

                                DialogUtil.ShowSaveSuccessful("Đã thêm văn bản thành công.");
                            }
                        }
                        catch (Exception ex)
                        {
                            DialogUtil.ShowError("Không thể thêm tập tin [" + namefile + "].");
                        }

                        //Load lại danh sách văn bản
                        if (_chungTuCurrent != null)
                        {
                            //Danh sách văn bản
                            DanhSachVanBanByMaChungTu(_chungTuCurrent);
                        }
                    }
                }
            }
        }

        private string SetTenVanBanTuDong()
        {
            // Lấy giá trị Idx lớn nhất cuả văn bản
            string tenVanBan = "VB" + LayIndexMaxCuaVanBan();

            return tenVanBan;
        }

        private void LayThongTinKetNoi(ref String ftpurl, ref String ftpusername, ref String ftppassword)
        {
            //
            ftpurl = ConfigurationManager.AppSettings["ftpUrl_Digital"];
            ftpusername = ConfigurationManager.AppSettings["ftpUser_Digital"];
            ftppassword = ConfigurationManager.AppSettings["ftpPass_Digital"];

        }
        private bool UploadFileToFTP(string source, ref string urlOnServer, ref string filename)
        {
            //Khai báo các biến
            String ftpurl = string.Empty; // e.g. ftp://serverip/foldername/foldername
            String ftpusername = string.Empty; // e.g. username
            String ftppassword = string.Empty; // e.g. password
            string ftpfullpath = string.Empty;
            string namefileTuPhatSinh = string.Empty;
            //Lấy thông tin từ file config
            LayThongTinKetNoi(ref ftpurl, ref ftpusername, ref ftppassword);

            try
            {
                //Lấy tên file
                filename = Path.GetFileName(source);

                //Phát sinh tên văn bản khi upload server tự động
                namefileTuPhatSinh = SetTenVanBanTuDong();

                // Set 
                ftpurl = ftpurl + "/ChungTu/";

                {   //Kiểm tra có thư mục chứng từ chưa nếu chưa thì thêm mới thư mục chứng từ
                    DirectoryExists(ftpurl, ftpusername, ftppassword);
                }
                ftpfullpath = ftpurl + namefileTuPhatSinh + ".pdf";

                if (!CheckExistNameFile(namefileTuPhatSinh))
                {
                    FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                    ftp.Method = WebRequestMethods.Ftp.UploadFile;
                    ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);
                    ftp.KeepAlive = false;
                    ftp.UseBinary = true;
                    ftp.Timeout = -1;
                    ftp.UsePassive = true;

                    using (FileStream fs = File.OpenRead(source))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        fs.Close();
                        Stream requestStream = ftp.GetRequestStream();
                        requestStream.Write(buffer, 0, buffer.Length);
                        requestStream.Close();
                        requestStream.Flush();
                        //Lấy đường dẫn trên server
                        urlOnServer = ftpfullpath;
                    }

                    return true;
                }
                else
                {
                    if (DialogUtil.ShowYesNo("Tập tin [" + namefileTuPhatSinh + "] đã tồn tại trên máy chủ. Bạn có muốn tiếp tục hay không?") == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Không thể [Upload] tập tin [" + filename + "] lên máy chủ." + ex.Message);
                return false;
            }
        }

        private void DirectoryExists(string directory, string userName, string pass)
        {
            bool directoryExists;

            var request = (FtpWebRequest)WebRequest.Create(directory);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(userName, pass);

            try
            {
                using (request.GetResponse())
                {
                    directoryExists = true;
                }
            }
            catch (WebException)
            {
                directoryExists = false;
            }

            try
            {
                if (!directoryExists)
                {
                    WebRequest req = WebRequest.Create(directory);
                    req.Method = WebRequestMethods.Ftp.MakeDirectory;
                    req.Credentials = new NetworkCredential(userName, pass);
                    using (var resp = (FtpWebResponse)req.GetResponse())
                    {
                        Console.WriteLine(resp.StatusCode);
                    }
                }
            }
            catch (Exception ex) { throw; }
        }

        private bool CheckExistNameFile(string nameFile)
        {
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CheckExistNameFileInVanBan";
                    cm.Parameters.AddWithValue("@TenVanBan", nameFile);
                    cm.Parameters.AddWithValue("@KetQua", kq);
                    cm.Parameters["@KetQua"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    kq = Convert.ToBoolean(cm.Parameters["@KetQua"].Value);
                }
            }//using
            return kq;
        }

        private int LayIndexMaxCuaVanBan()
        {
            int kq = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayIndexCuaVanBan";
                    cm.Parameters.AddWithValue("@KetQua", kq);
                    cm.Parameters["@KetQua"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    kq = Convert.ToInt32(cm.Parameters["@KetQua"].Value);

                    kq += 1;
                }
            }//using
            return kq;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(txtTenVanBan.Value)))
            {
                DialogUtil.ShowWarning("Vui lòng chọn văn bản cần xóa.");
                return;
            }

            if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn có thật sự muốn xóa văn bản [" + txtTenVanBan.Value + "] không?"))
            {
                try
                {
                    //Xóa file trên server trước khi xóa trong database
                    DeleteFileOnServer(_vanBan.DuongDan);

                    _vanBan.Delete();
                    _vanBan.ApplyEdit();
                    _vanBan.Save();
                    DialogUtil.ShowSaveSuccessful("Đã xóa thành công.");

                    //
                    if (_chungTuCurrent != null)
                    {
                        //Danh sách văn bản
                        DanhSachVanBanByMaChungTu(_chungTuCurrent);
                    }
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowError("Xóa không thành công.");
                }
            }
        }

        private void DeleteFileOnServer(string url)
        {
            //Khai báo các biến
            String ftpurl = string.Empty; // e.g. ftp://serverip/foldername/foldername
            String ftpusername = string.Empty; // e.g. username
            String ftppassword = string.Empty; // e.g. password

            try
            {
                //Lấy thông tin từ file config
                LayThongTinKetNoi(ref ftpurl, ref ftpusername, ref ftppassword);

                FtpWebRequest requestFileDelete = (FtpWebRequest)WebRequest.Create(url);
                requestFileDelete.Credentials = new NetworkCredential(ftpusername, ftppassword);
                requestFileDelete.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse responseFileDelete = (FtpWebResponse)requestFileDelete.GetResponse();
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Không thể [Delete] tập tin trong máy chủ." + ex.Message);
                throw ex;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Focus();
                if (_vanBan == null)
                {
                    MessageBox.Show("Vui lòng chọn văn bản.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Tiến hành lưu dữ liệu
                _vanBan.ApplyEdit();
                _vanBan.Save();

                MessageBox.Show("Cập nhật [" + _vanBan.TenVanBan + "] thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Danh sách văn bản
                if (_chungTuCurrent != null)
                DanhSachVanBanByMaChungTu(_chungTuCurrent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSoHoaChungTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnLuu_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                btnXoa_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                btnThem_Click(sender, e);
            }
            else if (e.Alt && e.KeyCode == Keys.X)
            {
                btnThoat_Click(sender, e);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            VanBan_BindingSource.Clear();
            cmbuLoaiVanBan.Value = null;
            dteNgayLap.Value = DateTime.Now.Date;
            txtTenVanBan.Value = string.Empty;
            txtNoiDungTimKiem.Value = string.Empty;
            _vanBan = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dte_TuNgay.Value == null || dte_DenNgay.Value == null)
            {
                DialogUtil.ShowWarning("Vui lòng chọn thời gian.");
                return;
            }

            DateTime tuNgay = Convert.ToDateTime(dte_TuNgay.Value);
            DateTime denNgay = Convert.ToDateTime(dte_DenNgay.Value);
            ChungTuCuList _chungTuCuList;

            if (!_isChungTuMoi)
            {
                //Mượn tạm chứng từ cũ để đọc chứng từ mới
                _chungTuCuList = ChungTuCuList.GetChungTuCuListByNgayLap(tuNgay, denNgay);
            }
            else
            {
                _chungTuCuList = ChungTuCuList.GetChungTuMoiListByNgayLap(tuNgay, denNgay);
            }

            if (_chungTuCuList.Count == 0)
            {
                DialogUtil.ShowInfo("Không có chứng từ trong thời gian này.");
            }
            ChungTuCu_BindingSource.DataSource = _chungTuCuList;
        }

        private void grdu_DanhSachChungTuCu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["NgayChungTu"].Hidden = false;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["TenKH"].Hidden = false;
          //  grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["NoTK"].Hidden = false;
         //   grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["CoTK"].Hidden = false;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
          //  grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["Muc"].Hidden = false;

            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["NgayChungTu"].Header.VisiblePosition = 1;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["TenKH"].Header.VisiblePosition = 3;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["NoTK"].Header.VisiblePosition = 4;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["CoTK"].Header.VisiblePosition = 5;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 6;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["Muc"].Header.VisiblePosition = 7;

            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["NgayChungTu"].Header.Caption = "Ngày Lập";
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["TenKH"].Header.Caption = "Tên Khách Hàng";
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["NoTK"].Header.Caption = "Nợ TK";
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["CoTK"].Header.Caption = "Có TK";
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["Muc"].Header.Caption = "Mục";

            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 120;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["NgayChungTu"].Width = 100;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 180;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["TenKH"].Width = 150;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["NoTK"].Width = 80;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["CoTK"].Width = 80;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["Muc"].Width = 100;

            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["Muc"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["NoTK"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["CoTK"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachChungTuCu.DisplayLayout.Bands[0].Columns["NgayChungTu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

        }

        private void ChungTuCu_BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //Lấy chứng từ hiện tại
            _chungTuCurrent = ChungTuCu_BindingSource.Current as ChungTuCu;

            if (_chungTuCurrent != null)
            {
                this.grpDanhSachVanBan.Text = "Văn Bản Theo Chứng Từ Số [" + _chungTuCurrent.SoChungTu.Trim().ToUpper() +"]".Trim();
                //Danh sách văn bản
                DanhSachVanBanByMaChungTu(_chungTuCurrent);
            }
        }

        private void DanhSachVanBanByMaChungTu(ChungTuCu _chungTuCu)
        {
            VanBanList vanBanList;
            if (!_isChungTuMoi)
            {
                //Lấy danh sách văn bản theo chứng từ cũ
                vanBanList = VanBanList.GetVanBanListByMaChungTuCu(_chungTuCu.MaChungTuCu);
            }
            else
            {
                //Lấy danh sách văn bản theo chứng từ mới
                vanBanList = VanBanList.GetVanBanListByMaChungTu(Convert.ToInt64(_chungTuCu.MaChungTuCu));
            }

            LayDuLieuChoCayVanBan(vanBanList);
        }

        private void LayDuLieuChoCayVanBan(VanBanList vanBanList)
        {
            TreeDanhSachVanBan.Nodes.Clear();

            //Thêm một node trống
            UltraTreeNode nodeEmpty = new UltraTreeNode("*");
            nodeEmpty.Override.NodeAppearance.Image = imageList.Images["nodeEmpty"];

            foreach (VanBan vanBan in vanBanList)
            {
                if (vanBan.MaVanBan != 0)
                {
                    UltraTreeNode Node = new UltraTreeNode(vanBan.TenVanBan);
                    Node.Tag = vanBan.MaVanBan;
                   // Node.Override.NodeAppearance.ForeColor = Color.Green;
                   // Node.Override.NodeAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    Node.Override.NodeAppearance.Image = imageList.Images["pdf.png"];
                    nodeEmpty.Nodes.Add(Node);
                }
            }

            TreeDanhSachVanBan.Nodes.Add(nodeEmpty);
            TreeDanhSachVanBan.Refresh();
            TreeDanhSachVanBan.ExpandAll();
        }

        private void frmSoHoaChungTu_Load(object sender, EventArgs e)
        {
            ///
            dte_TuNgay.Value = DateTime.Now.Date;
            dte_DenNgay.Value = DateTime.Now.Date;
            dteNgayLap.Value = DateTime.Now.Date;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class frmLoaiVanBan : Form
    {
        #region properties
        LoaiVanBanList _loaiVanBanList;

        #endregion

        public frmLoaiVanBan()
        {
            InitializeComponent();
        }

        public void LoadDuLieu()
        {
            //Đưa dữ liệu vào lưới
            _loaiVanBanList = LoaiVanBanList.GetLoaiVanBanList();
            LoaiVanBan_BingSource.DataSource = _loaiVanBanList;

            //Đưa dữ liệu vào combobox
            LoaiVanBanList loaiVanBanChaList = LoaiVanBanList.GetLoaiVanBanList();
            LoaiVanBan loaiVanBan_Insert = LoaiVanBan.NewLoaiVanBan(0, "Không Chọn", "Không Chọn");
            loaiVanBanChaList.Insert(0, loaiVanBan_Insert);
            LoaiVanBanCha_BindingSource.DataSource = loaiVanBanChaList;

            LoaiVanBan_TreeList.ExpandAll();

            //
            dteNgayLap.EditValue = DateTime.Now.Date;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool KiemTra()
        {
            Boolean kq = true;
            if (_loaiVanBanList == null)
            {
                return kq = false;
            }
            foreach (LoaiVanBan item in _loaiVanBanList)
            {
                if (string.IsNullOrEmpty(item.MaQuanLy))
                {
                    MessageBox.Show(this, "Vui lòng nhập mã quản lý loại văn bản.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    kq = false;
                    return kq;
                }
                if (string.IsNullOrEmpty(item.TenLoaivanBan))
                {
                    MessageBox.Show(this, "Vui lòng nhập tên loại văn bản.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    kq = false;
                    return kq;
                }
                if (KiemTraMaQuanLy(item.MaLoaiVanBan, item.MaQuanLy))
                {
                    MessageBox.Show(this, "Mã quản lý văn bản ["+ item.TenLoaivanBan +"] bị trùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    kq = false;
                    return kq;
                }
            }
            return kq;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            labelControl1.Focus();
            try
            {
                if (KiemTra())
                {
                    _loaiVanBanList.ApplyEdit();
                    _loaiVanBanList.Save();

                    MessageBox.Show("Cập nhật thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Refesh lại dữ liệu
                    _loaiVanBanList = LoaiVanBanList.GetLoaiVanBanList();
                    LoaiVanBan_BingSource.DataSource = _loaiVanBanList;
                    LoaiVanBan_TreeList.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật không thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Lấy loại văn bản hiện tại
            LoaiVanBan loaiVanBan = LoaiVanBan_BingSource.Current as LoaiVanBan;

            if (loaiVanBan == null)
            {
                MessageBox.Show("Chọn dòng cần xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DialogUtil.ShowYesNo("Bạn chắc xóa [" + loaiVanBan.TenLoaivanBan + "] này và các con của nó không?") == DialogResult.Yes)
            {
                //Xóa các con của nó
                DeleteLoaiVanBanCon(loaiVanBan);

                //Xóa loại văn bản đã chọn
                _loaiVanBanList.Remove(loaiVanBan);
                LoaiVanBan_BingSource.DataSource = _loaiVanBanList; 
            }
        }

        private void DeleteLoaiVanBanCon(LoaiVanBan loaiVanBan)
        {
            for (int i = 0; i < _loaiVanBanList.Count; i++)
            {
                if (_loaiVanBanList[i].MaLoaiCha == loaiVanBan.MaLoaiVanBan)
                {
                    //Tiếp tục gọi đệ qui
                    DeleteLoaiVanBanCon(_loaiVanBanList[i]);

                    //Tiến hành xóa
                    _loaiVanBanList.RemoveAt(i);
                    i--;
                }
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
        }


        private void frmLoaiVanBan_KeyDown(object sender, KeyEventArgs e)
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Lấy loại văn bản hiện tại
            LoaiVanBan loaiVanBanCurrent = LoaiVanBan_BingSource.Current as LoaiVanBan;

            //Lấy tất cả dữ liệu trên cây 
            LoaiVanBanList loaiVanBanList = LoaiVanBan_BingSource.DataSource as LoaiVanBanList;

            foreach (LoaiVanBan item in loaiVanBanList)
            {
                if (item.MaQuanLy != "*" && item.MaLoaiVanBan == 0)// Phải lưu dữ liệu rồi mới tiếp tục thêm
                {
                    MessageBox.Show("Có một dòng dữ liệu trống. Vui lòng lưu dữ liệu trước khi thêm.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //Khởi tạo loại văn bản mới
            LoaiVanBan loaiVanBan = LoaiVanBan.NewLoaiVanBan();

            if (loaiVanBanCurrent != null)
            {
                //Lấy loại văn bản cha
                loaiVanBan.MaLoaiCha = loaiVanBanCurrent.MaLoaiVanBan;
            }
            loaiVanBan.NgayLap = DateTime.Now.Date;
            loaiVanBan.UserId = ERP_Library.Security.CurrentUser.Info.UserID;

            //Đưa vào cây danh sách loại văn bản
            LoaiVanBan_BingSource.Add(loaiVanBan);

            //Focus vào dòng vừa thêm mới
            //LoaiVanBan_BingSource.Position = LoaiVanBan_BingSource.IndexOf(_loaiVanBan);

        }

        private bool KiemTraMaQuanLy(long maLoaiVanBan, string maQuanLy)
        {
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraMaQuanLy_LoaiVanBan";
                    cm.Parameters.AddWithValue("@MaLoaiVanBan", maLoaiVanBan);
                    cm.Parameters.AddWithValue("@MaQuanLy", maQuanLy);
                    cm.Parameters.AddWithValue("@KetQua", kq);
                    cm.Parameters["@KetQua"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    kq = Convert.ToBoolean(cm.Parameters["@KetQua"].Value);
                }
            }//using
            return kq;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(txtThongTin.EditValue)))
            {
                btnLoad_Click(sender,e);
            }
            else
            {
                //Lấy thông tin tìm kiếm đã nhập
                string duLieuTim = Convert.ToString(txtThongTin.EditValue).Trim();

                _loaiVanBanList = LoaiVanBanList.GetLoaiVanBanList(duLieuTim);
                LoaiVanBan_BingSource.DataSource = _loaiVanBanList;

                LoaiVanBan_TreeList.ExpandAll();
            }
        }

        private void txtThongTin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (string.IsNullOrEmpty(Convert.ToString(txtThongTin.EditValue)))
                {
                    btnLoad_Click(sender, e);
                }
                else
                {
                    //Lấy thông tin tìm kiếm đã nhập
                    string duLieuTim = Convert.ToString(txtThongTin.EditValue).Trim(); ;

                    _loaiVanBanList = LoaiVanBanList.GetLoaiVanBanList(duLieuTim);
                    LoaiVanBan_BingSource.DataSource = _loaiVanBanList;

                    LoaiVanBan_TreeList.ExpandAll();
                }
            }
        }

        private void frmLoaiVanBan_Load(object sender, EventArgs e)
        {
            ///Load dữ liệu cho loại văn bản
            LoadDuLieu();
        }
    }
}
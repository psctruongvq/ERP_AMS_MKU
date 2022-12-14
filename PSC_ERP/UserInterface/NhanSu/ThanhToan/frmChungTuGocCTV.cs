using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.ThanhToan
{
    public partial class frmChungTuGocCTV : Form
    {
        private bool OK = false;
        protected ERP_Library.ThanhToan.LoaiChungTuGoc _loaichungtu;
        protected DataSet _dataset = new DataSet("ChungTuGoc");
        protected object _chungtu;
        internal ERP_Library.ThanhToan.DeNghiChuyenKhoan _denghi;
        public event CancelEventHandler SaveXMLData;
        public event EventHandler CreateXMLData;

        protected bool IsLoaded = false;
        protected bool IsNew = false;

        public frmChungTuGocCTV()
        {
            InitializeComponent();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (txtDienGiai.Text == "")
            {
                MessageBox.Show("Diễn giải không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Convert.ToDecimal(txtSoTien.Value) == 0)
            {
                MessageBox.Show("Số tiền đề nghị không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (SaveXMLData != null)
            {
                CancelEventArgs tmp = new CancelEventArgs();
                SaveXMLData(this, tmp);
                if (tmp.Cancel)
                    return;
            }
            if (_chungtu is ERP_Library.ThanhToan.DeNghiThanhToan_ChungTu)
            {
                ((ERP_Library.ThanhToan.DeNghiThanhToan_ChungTu)_chungtu).DuLieuChungTu = _dataset.GetXml();
                ((ERP_Library.ThanhToan.DeNghiThanhToan_ChungTu)_chungtu).DienGiai = txtDienGiai.Text;
                ((ERP_Library.ThanhToan.DeNghiThanhToan_ChungTu)_chungtu).SoTien = Convert.ToDecimal(txtSoTien.Value);
            }
            else
            {
                ((ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu)_chungtu).DuLieuChungTu = _dataset.GetXml();
                ((ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu)_chungtu).DienGiai = txtDienGiai.Text;
                ((ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu)_chungtu).SoTien = Convert.ToDecimal(txtSoTien.Value);
            }
            OK = true;
            this.Close();
        }

        public bool MoChungTu(ERP_Library.ThanhToan.LoaiChungTuGoc LoaiChungTu, ERP_Library.ThanhToan.DeNghiThanhToan_ChungTu ChungTu, bool isNew)
        {
            IsNew = isNew;
            _loaichungtu = LoaiChungTu;
            _chungtu = ChungTu;
            if (IsNew) ChungTu.MaLoaiChungTu = _loaichungtu.MaLoaiChungTu;
            if (!IsNew && ChungTu.DuLieuChungTu != "")
            {
                try
                {
                    System.IO.StringReader sr = new System.IO.StringReader(ChungTu.DuLieuChungTu);
                    _dataset.ReadXml(sr);
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xử lý dữ liệu chứng từ gốc \r\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (IsNew && CreateXMLData != null)
            {
                CreateXMLData(this, null);
            }
            txtDienGiai.Text = ChungTu.DienGiai;
            txtSoTien.Value = ChungTu.SoTien;
            this.ShowDialog();
            return OK;
        }

        public bool MoChungTu(ERP_Library.ThanhToan.LoaiChungTuGoc LoaiChungTu, ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu ChungTu, bool isNew)
        {
            IsNew = isNew;
            _loaichungtu = LoaiChungTu;
            _chungtu = ChungTu;
            if (IsNew) ChungTu.MaLoaiChungTu = _loaichungtu.MaLoaiChungTu;
            if (!IsNew && ChungTu.DuLieuChungTu != "")
            {
                try
                {
                    System.IO.StringReader sr = new System.IO.StringReader(ChungTu.DuLieuChungTu);
                    _dataset.ReadXml(sr);
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xử lý dữ liệu chứng từ gốc \r\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (IsNew && CreateXMLData != null)
            {
                CreateXMLData(this, null);
            }
            txtDienGiai.Text = ChungTu.DienGiai;
            txtSoTien.Value = ChungTu.SoTien;
            CanSave(isNew || LoaiChungTu.TenLoai == "Khác");
            this.ShowDialog();
            return OK;
        }

        protected void SetChungTuGoc(string DienGiai, decimal SoTien)
        {
            if (IsLoaded)
            {
                txtDienGiai.Text = DienGiai;
                txtSoTien.Value = SoTien;
            }
        }

        private void CanSave(bool b)
        {
            lblErr.Visible = !b;
            btnDongY.Enabled = b;
        }
    }
}
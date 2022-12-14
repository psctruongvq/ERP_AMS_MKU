using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmNhanVienTangCaEdit : Form
    {
        private ERP_Library.NhanVienTangCa _Data;
        private bool _OK = false;
        private bool _isNew = false;
        private int _idEdit = 0;
        public bool NewTangCa()
        {
            _isNew = true;
            this.ShowDialog();
            return _OK;
        }

        public bool EditTangCa(int ID)
        {
            _isNew = false;
            _idEdit = ID;
            this.ShowDialog();
            return _OK;
        }

        public frmNhanVienTangCaEdit()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVienTangCaEdit_Load(object sender, EventArgs e)
        {
            if (_isNew)
            {
                _Data = ERP_Library.NhanVienTangCa.NewNhanVienTangCa();
                tlslblXoa.Enabled = false;
                tlslblUndo.Enabled = false;
            }
            else
                _Data = ERP_Library.NhanVienTangCa.GetNhanVienTangCa(_idEdit);

            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            cmbHinhThuc.DataSource = ERP_Library.HinhThucTangCaList.GetHinhThucTangCaList();
            bdData.DataSource = _Data;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bdData.EndEdit();
                _Data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _OK = true;
                this.Close();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _Data = ERP_Library.NhanVienTangCa.GetNhanVienTangCa(_idEdit);
            bdData.DataSource = _Data;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tăng ca của nhân viên này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _Data.Delete();
                    bdData.EndEdit();
                    _Data.Save();
                    MessageBox.Show("Dữ liệu đã được xóa", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _OK = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
                }
            }
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value == null)
                cmbNhanVien.LoadDataByBoPhan(0);
            else
                cmbNhanVien.LoadDataByBoPhan((int)cmbBoPhan.Value);
            cmbNhanVien.Value = null;
        }
    }
}
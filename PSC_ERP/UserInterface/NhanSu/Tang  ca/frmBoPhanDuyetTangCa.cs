using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmBoPhanDuyetTangCa : Form
    {
        private ERP_Library.BoPhanDuyetTangCaList _data;

        public frmBoPhanDuyetTangCa()
        {
            InitializeComponent();
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBoPhanDuyetTangCa_Load(object sender, EventArgs e)
        {
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            LoadData();
        }

        private void LoadData()
        {
            if (cmbBoPhan.Value != null)
            {
                _data = ERP_Library.BoPhanDuyetTangCaList.GetBoPhanDuyetTangCaList((int)cmbBoPhan.Value);
                bdData.DataSource = _data;
            }
        }

        private void SaveData()
        {
            try
            {
                grdData.UpdateData();
                _data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (_data != null && _data.IsDirty)
            {
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
            }
            LoadData();
        }

        private void frmBoPhanDuyetTangCa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_data != null && _data.IsDirty)
            {
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
            }
        }

        private void toolUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}

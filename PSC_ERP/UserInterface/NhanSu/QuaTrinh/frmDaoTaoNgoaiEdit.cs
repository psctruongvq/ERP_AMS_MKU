
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmDaoTaoNgoaiEdit : Form
    {
        private bool OK = false;
        private bool IsNew;
        private int _IDEdit;
        private ERP_Library.DaoTaoNgoai _Data;
        public frmDaoTaoNgoaiEdit()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool NewDaoTao()
        {
            IsNew = true;
            this.ShowDialog();
            return OK;
        }
        public bool EditDaoTao(int MaDTNgoai)
        {
            IsNew = false;
            _IDEdit = MaDTNgoai;
            this.ShowDialog();
            return OK;            
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            bool _ok = true;
            grdChiTiet.UpdateData();
            bdData.EndEdit();
            try
            {
                _Data.Save();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
                _ok = false;
            }
            if (_ok)
            {
                OK = true;
                this.Close();
                
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _Data = ERP_Library.DaoTaoNgoai.GetDaoTaoNgoai(_IDEdit);
            bdData.DataSource = _Data;
        }


        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chương trình này không?", "Xóa", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Data.Delete();
                tlslblLuu.PerformClick();
            }
        }

        private void frmDaoTaoNgoaiEdit_Load(object sender, EventArgs e)
        {
            tlslblXoa.Enabled = !IsNew;
            tlslblUndo.Enabled = !IsNew;
            ERP_Library.TinhThanhList tinh = ERP_Library.TinhThanhList.GetTinhThanhList();
            foreach (ERP_Library.TinhThanh t in tinh)
            {
                grdChiTiet.DisplayLayout.ValueLists["QueQuan"].ValueListItems.Add(t.MaTinhThanh, t.TenTinhThanh);
            }
            if (IsNew)
            {
                _Data = ERP_Library.DaoTaoNgoai.NewDaoTaoNgoai();
                bdData.DataSource = _Data;
            }
            else
            {
                _Data = ERP_Library.DaoTaoNgoai.GetDaoTaoNgoai(_IDEdit);
                bdData.DataSource = _Data;
            }
        }

        private void grdChiTiet_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa học viên này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }
    }
}
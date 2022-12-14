using ERP_Library;
using ERP_Library.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.Security
{
    public partial class frmGroups : Form
    {
        private ERP_Library.Security.GroupList _data;

        public frmGroups()
        {
            InitializeComponent();
        }
        public string strStatus = "KHOA";
        PhanQuyenSuDungForm _phanQuyen = null;
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            itNew.Enabled = _phanQuyen.Them;
            itEdit.Enabled = _phanQuyen.Sua;
            itDelete.Enabled = _phanQuyen.Xoa;
            
        }

        private void ReadOnlyConTrolByStatus(string _strStatus)
        {
            if (_strStatus == "" || _strStatus == "THEM" || _strStatus == "SUA")
            {

                itEdit.Visible = false;
                itSave.Visible = true;
                itNew.Visible = false;
            }
            else if (_strStatus == "KHOA")
            {

                itEdit.Visible = true;
                itSave.Visible = false;
                itNew.Visible = true;

            }
            PhanQuyenThemSuaXoa();
        }
        private void itDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            _data = ERP_Library.Security.GroupList.GetGroupList();
            bdData.DataSource = _data;
        }

        private void frmGroups_Load(object sender, EventArgs e)
        {
            this.ReadOnlyConTrolByStatus(this.strStatus);
            LoadData(); 
        }

        private void SaveData()
        {
            grdData.UpdateData();
            try
            {
                _data.Save();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
            MessageBox.Show("Dữ liệu đã lưu thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void itSave_Click(object sender, EventArgs e)
        {
            SaveData();
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        private void itUndo_Click(object sender, EventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            LoadData();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            if (e.Rows[0].Cells["TenChucNang"].Value.ToString() == "Admin")
            {
                MessageBox.Show("Bạn không được xóa nhóm quyền Admin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.DisplayPromptMsg = false;
                e.Cancel = true;
            }
            else
            {
                e.DisplayPromptMsg = false;
                e.Cancel = MessageBox.Show("Bạn có muốn xóa nhóm người sử dụng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
               
            }
        }

        private void frmGroups_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_data!=null && _data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveData();
                }
        }

        private void itEdit_Click(object sender, EventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            grdData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
        }

        private void itNew_Click(object sender, EventArgs e)
        {
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            grdData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            grdData.DisplayLayout.Bands[0].AddNew();
        }

        private void itDelete_Click(object sender, EventArgs e)
        {
            grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
           
            grdData.DeleteSelectedRows();
            grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;

        }

        private void grdData_AfterRowsDeleted(object sender, EventArgs e)
        {
                grdData.UpdateData();
                try
                {
                    _data.Save();
                }
                catch (Exception ex)
                {
                    frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
                }
        }
    }
}
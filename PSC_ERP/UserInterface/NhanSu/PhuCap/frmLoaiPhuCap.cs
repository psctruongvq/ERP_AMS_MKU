using ERP_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmLoaiPhuCap : Form
    {
        private ERP_Library.LoaiPhuCapList _Data;
        private ERP_Library.NhomPhuCapList _DataNhom;

        private bool KiemTraTruocKhiLuu()
        {
            foreach (LoaiPhuCapChild loaiPhuCapChild in _Data)
            {
               if(loaiPhuCapChild.MaNhom !=0)
               {
                   NhomPhuCap nhomPC=NhomPhuCap.GetNhomPhuCap(loaiPhuCapChild.MaNhom);
                   if(nhomPC.Ma.ToString().Substring(0,2)=="TR" || nhomPC.Ma.ToString().Substring(0,2)=="TT" )
                       {
                       	if(loaiPhuCapChild.PhanLoai==0)
                        {
                            MessageBox.Show("Vui lòng nhập Phân loại cho Loại Phụ cấp khi nhóm là Truy lĩnh, hay Truy thu", "Thông Báo");
                            return false;
                        }
                       }
               }
            }
            return true;
        }

        public frmLoaiPhuCap()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmLoaiPhuCap_FormClosing);
        }

        void frmLoaiPhuCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Data != null && _Data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveData();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmLoaiPhuCap_Load(object sender, EventArgs e)
        {
           
            // nhom phu cap
            _DataNhom = ERP_Library.NhomPhuCapList.GetNhomPhuCapList();
            bdNhomPC.DataSource = _DataNhom;
            bdNhomPCan.DataSource = _DataNhom;
            ucboNhomPC.DataSource = bdNhomPC;
            // loai phu cap
            _Data = ERP_Library.LoaiPhuCapList.GetLoaiPhuCapList();
            bdData.DataSource = _Data;
           
      
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _Data = ERP_Library.LoaiPhuCapList.GetLoaiPhuCapList();
            bdData.DataSource = _Data;
        }

        private void SaveData()
        {
            try
            {
                grdData.UpdateData();
                if(KiemTraTruocKhiLuu())
                {
                    _Data.Save();
                    MessageBox.Show("Dữ liệu lưu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                }
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _Data);
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa loại phụ cấp này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {

        }


        private void grdData_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            if (ucboNhomPC.Value != null)
            {
                e.Row.Cells["MaNhom"].Value = ucboNhomPC.Value;
            }
           

            
        }

        private void ucboNhomPC_ValueChanged(object sender, EventArgs e)
        {
            LoadDL();
        }

        private void LoadDL()
        {
            if (ucboNhomPC.SelectedRow != null)
            {
                int manhom = int.Parse(ucboNhomPC.SelectedRow.Cells["MaNhom"].Value.ToString());

                _Data = ERP_Library.LoaiPhuCapList.GetLoaiPhuCapByMaNhom(manhom);

                bdData.DataSource = _Data;
                lbDSLoai.Text = ucboNhomPC.Text;
            }
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //HamDungChung t = new HamDungChung();
            //t.ultragrdEmail_InitializeLayout(sender, e);
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        } 
    }
}
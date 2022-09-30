using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Csla;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmQuanHe : Form
    {
        
        Util util=new Util();
        QuanHeClassList list;

        public frmQuanHe()
        {
            InitializeComponent();
        }

        private void ultragrdQuanHe_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdQuanHe.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdQuanHe.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdQuanHe.DisplayLayout.Bands[0].Columns["MaQuanHe"].Hidden = true;
            ultragrdQuanHe.DisplayLayout.Bands[0].Columns["QuanHe"].Header.Caption = "Tên quan hệ";
            ultragrdQuanHe.DisplayLayout.Bands[0].Columns["QuanHe"].Header.VisiblePosition = 1;
            ultragrdQuanHe.DisplayLayout.Bands[0].Columns["QuanHe"].Width = 300;

            ultragrdQuanHe.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdQuanHe.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultragrdQuanHe.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 140;
            foreach (UltraGridColumn col in ultragrdQuanHe.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void Load_Luoi()
        {
            try
            {
                list = QuanHeClassList.GetQuanHeClassList();
                QuanHe_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void frmQuanHe_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 0; i < ultragrdQuanHe.Rows.Count; i++)
            {
                //_UuTienBanThan = list[i];
                if (ultragrdQuanHe.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdQuanHe.ActiveRow = ultragrdQuanHe.Rows[i];
                    return kq;
                }
                if (ultragrdQuanHe.Rows[i].Cells["QuanHe"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Quan Hệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdQuanHe.ActiveRow = ultragrdQuanHe.Rows[i];
                    return kq;
                }
            }
            return kq;
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i != j)
                    {
                        if (list[i].MaQuanLy.Trim() == list[j].MaQuanLy.Trim())
                        {
                            QuanHeClass cd = QuanHeClass.GetQuanHeClass(list[i].MaQuanHe);
                            MessageBox.Show(this, "Quan hệ " + cd.QuanHe.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdQuanHe.ActiveRow = ultragrdQuanHe.Rows[i];
                            ultragrdQuanHe.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            try
            {
                if (KiemTra_Luoi() == true)
                {
                    if (KiemTraMaQuanLy() == true)
                    {
                        list.ApplyEdit();
                        list.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Load_Luoi();
                    }
                }

            }
            catch (ApplicationException)
            {

            }
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdQuanHe.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdQuanHe.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdQuanHe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ultragrdQuanHe.UpdateData();
            }
        }

        private void ultragrdQuanHe_Leave(object sender, EventArgs e)
        {
            ultragrdQuanHe.UpdateData()          ;
        }

        private void frmQuanHe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F1)
            {
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                this.Load_Luoi();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdQuanHe);
        }
    }
}
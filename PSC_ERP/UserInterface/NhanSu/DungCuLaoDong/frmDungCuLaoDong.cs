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
    public partial class frmDungCuLaoDong : Form
    {
        Util util=new Util();
        DungCuLaoDongList list;

        public frmDungCuLaoDong()
        {
            InitializeComponent();
        }

        #region Load
        private void Load_Luoi()
        {
            try
            {
                list = DungCuLaoDongList.GetDungCuLaoDongList();
                DungCuLaoDong_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }

        }

        private void frmChuyenMonNghiepVu_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void ultragrdChuyenMonNghiepVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);


            foreach (UltraGridColumn col in gridData.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
           
                try
                {
                    gridData.UpdateData();
                    DungCuLaoDong_bindingSource.EndEdit();
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Luoi();
                }
                catch (ApplicationException)
                {

                }
            
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            
            gridData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridData);
        }
        #endregion

        #region Process
       
        #endregion  

        private void ultragrdChuyenMonNghiepVu_KeyDown(object sender, KeyEventArgs e)
        {
           // gridData.UpdateData();
        }

        private void ultragrdChuyenMonNghiepVu_Leave(object sender, EventArgs e)
        {
           // gridData.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridData);
        }

        



    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmCapQuyetDinh : Form
    {
        #region Properties
        Util util=new Util();
        CapQuyetDinhList list;
      
        public delegate void PassData(CapQuyetDinhList value);
        public PassData passData;
        #endregion

        #region Events
        private void ultragrdChucVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
           
        }
        public frmCapQuyetDinh()
        {
            InitializeComponent();
        }
        private void Load_Luoi()
        {
            try
            {


                list = CapQuyetDinhList.GetCapQuyetDinhList();
                CapQuyetDinh_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
           
        }

     

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();

            tlslblIn.Visible = true;
            toolStripLabel1.Visible = false;
           

        }

      
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            try
            {
              

               
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Luoi();
                    if (passData != null)
                        passData(this.list);
               
            }
            catch (ApplicationException)
            {

            }
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdChucVu.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa,util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdChucVu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void Undo()
        {
            this.Load_Luoi();
          
        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void frmChucVu_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            if (e.Control && e.KeyCode == Keys.U)
            {
                Undo();
            }
            if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

     

        private void grdu_QuocGia_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);

        }

        private void grdu_QuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              //  ultragrdChucVu.UpdateData();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdChucVu);
        }

    }
}

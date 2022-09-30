using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
//04/04/2013
namespace PSC_ERP
{
    public partial class frmLichSuDieuChuyenCCDC : DevExpress.XtraEditors.XtraForm
    {
        DataTable tblResult;
        int _maCCDC = 0;

        #region Function
        private void InitializeForm()
        {
            gridView2.Columns.Clear();
            tblResult = new DataTable();
            GetDataForBindingSource();
            gridControl1.DataSource = tblResult;
            InitializeGrdLichSuDieuChuyenCDC();
            if(tblResult.Rows.Count==0)
            {
                MessageBox.Show("Chưa có Điều chuyển");
            }
        }

        private void InitializeGrdLichSuDieuChuyenCDC()
        {
            gridView2.OptionsView.ShowGroupPanel = true;
            gridView2.GroupPanelText = "Lịch Sử Điều Chuyển Công Cụ Dụng Cụ";
            gridView2.OptionsView.ShowAutoFilterRow = true;
            gridView2.OptionsView.ColumnAutoWidth = true;//--
            for (int i = 0; i < gridView2.Columns.Count; i++)
            {
                gridView2.Columns[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gridView2.Columns[i].OptionsColumn.AllowEdit = false;
                //gridView2.Columns[i].OptionsColumn.FixedWidth = false;
                //gridView2.Columns[i].BestFit();
                gridView2.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView2.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            }
        }

        private void GetDataForBindingSource()
        {
            tblResult = Table_LichSuDieuChuyenCCDC(_maCCDC);
        }

        private void bindingData()
        {
            
        }

        private DataTable Table_LichSuDieuChuyenCCDC(int maCCDC)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetLichSuDieuChuyenCCDC";
                    cm.Parameters.AddWithValue("@MaCCDC", maCCDC);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                            kqTbl = ds.Tables[0];
                    }
                }
            }//us
            return kqTbl;
        }

        #endregion//Function
        
        #region Events
        
        #endregion//Events


        public frmLichSuDieuChuyenCCDC()
        {
            InitializeComponent();
        }//

        public frmLichSuDieuChuyenCCDC(int maCCDC)
        {
            InitializeComponent();
            _maCCDC = maCCDC;
            InitializeForm();
            bindingData();
            GetDataForBindingSource();

        }//



        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
                this.Close();
        }//

        private void btn_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }//

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }


    }
}
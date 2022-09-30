using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;//dung cho class [ParameterInfo]
using DevExpress.XtraEditors;//Dung cho class [LookUpEdit]
using DevExpress.XtraEditors.Controls;//Dung cho [LookUpColumnInfo]
using ERP_Library;

namespace PSC_ERP
{
    public partial class Rpt_ThongKeVatTuXNT_TheoNguonKinhPhi : DevExpress.XtraReports.UI.XtraReport
    {

        #region Tao DataSet cho Phieu In
        private DataSet DataSet_PhieuXuatBanQuyen()
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_PhieuXuatBQVT 
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ThongKeVatTuXNT_TheoNguonKinhPhi";
                    cm.Parameters.AddWithValue("@MaKho", parameter_MaKho);
                    cm.Parameters.AddWithValue("@TuNgay", parameter_TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", parameter_DenNgay);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_ThongKeVatTuXNT_TheoNguonKinhPhi;1";
                    ds.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_REPORT_ReportHeader";
                    cm.Parameters.AddWithValue("@MaCongTy", 1);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_REPORT_ReportHeader;1";
                    ds.Tables.Add(dt);
                }
                
            }//us
            return ds;
        }
        #endregion//END Tao DataSet cho Phieu In

        public Rpt_ThongKeVatTuXNT_TheoNguonKinhPhi()
        {
            InitializeComponent();
        }

        private void Rpt_ThongKeVatTuXNT_TheoNguonKinhPhi_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            //Begin 
                        // duyệt tất cả các Parameters của Report
                  foreach (ParameterInfo info in e.ParametersInformation)
                  {
                      //Cai dat cho [parameter_MaKho]
                    if (info.Parameter.Name == "parameter_MaKho")
                    {
                      //lấy dữ liệu cho cái này, ở đây mình tạo 1 datatable để demo
                     DSKhoList_bindingSource.DataSource=KhoBQ_VTList.GetKhoBQ_VTList(1);
                      //tao LookUpEdit và gán dữ liệu cho nó
                      LookUpEdit lookUpEdit = new LookUpEdit();
                      lookUpEdit.Properties.DataSource = DSKhoList_bindingSource;
                      //lookUpEdit.Properties.Columns.Add(new LookUpColumnInfo("TenKho", 0, "Nhập vào Tên Kho"));
                      // Dinh dang lookUpEdit
                      lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaQuanLy", "Mã Kho", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center),
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenKho", "Tên Kho", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
                      lookUpEdit.Properties.DisplayMember = "TenKho";
                      lookUpEdit.Properties.ValueMember = "MaKho";
                      lookUpEdit.Size = new System.Drawing.Size(100, 20);
                      lookUpEdit.TabIndex = 0;
                      // END Dinh dang lookUpEdit
                      info.Editor = lookUpEdit;//gán cái lookUpEdit này vào cái Parameters
                    }
                      //END cai dat cho [parameter_MaKho]

                      //Cai dat cho [parameter_TuNgay]
                    if (info.Parameter.Name == "parameter_TuNgay")
                    {
                        //tao DateEdit và gán dữ liệu cho nó
                        DateEdit dateEdit_Tungay = new DateEdit();
                        //gán cái lookUpEdit này vào cái Parameters
                        info.Editor = dateEdit_Tungay;
                    }
                      //END Cai dat cho [parameter_TuNgay]
                    //Cai dat cho [parameter_DenNgay]
                    if (info.Parameter.Name == "parameter_DenNgay")
                    {
                        //tao DateEdit và gán dữ liệu cho nó
                        DateEdit dateEdit_DenNgay = new DateEdit();
                        //gán cái lookUpEdit này vào cái Parameters
                        info.Editor = dateEdit_DenNgay;
                    }
                      //END Cai dat cho [parameter_TuNgay]

                  }

            //End
        }

    }
}

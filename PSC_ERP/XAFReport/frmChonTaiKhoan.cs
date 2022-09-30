using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;

//2018.08.03
namespace PSC_ERP
{
    public partial class frmChonTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        string strTenPhuongThuc;
        DataSet dsReport;
        HeThongTaiKhoan1List lstTaiKhoan;
        public string strMaTaiKhoan = "";

        #endregion Events

        public frmChonTaiKhoan()
        {
            InitializeComponent();
        }

        #region event FormLoad
        private void frmShowReportForGrid_Load(object sender, EventArgs e)
        {
            lstTaiKhoan = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            HeThongTaiKhoan1 objHeThongTaiKhoan1 = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            //objHeThongTaiKhoan1.MaQL = "<<Tất cả>>";
            //lstTaiKhoan.Insert(0, objHeThongTaiKhoan1);
            bdTaiKhoan.DataSource = lstTaiKhoan;

            treeTaiKhoan.ExpandAll();
        }
        #endregion
        

        #region event btn
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnExportDataExcell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(dlg.FileName);
            }
        }
        #endregion

        private void treeTaiKhoan_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node;
            node = e.Node;

            string maTaiKhoanCha = node.GetValue("MaTaiKhoanCha")+"";
            if (maTaiKhoanCha == "0")
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }


        private void CheckParent(int parentID)
        {
            foreach (HeThongTaiKhoan1 item in lstTaiKhoan)
            {
                if (item.MaTaiKhoan == parentID)
                {
                    item.Chon = true;
                    if (item.MaTaiKhoanCha + "0" != "0")
                        CheckParent(item.MaTaiKhoanCha);
                }
            }

        }
        private void CheckChild(int ID)
        {
            foreach (HeThongTaiKhoan1 item in lstTaiKhoan)
            {
                if (item.MaTaiKhoanCha == ID)
                {
                    item.Chon = true;
                    if (item.MaTaiKhoan != null)
                        CheckChild(item.MaTaiKhoan);
                }
            }

        }
        private void RemoveCheckChild(int ID)
        {
            foreach (HeThongTaiKhoan1 item in lstTaiKhoan)
            {
                if (item.MaTaiKhoanCha == ID)
                {
                    item.Chon = false;
                    if (item.MaTaiKhoan != null)
                        RemoveCheckChild(item.MaTaiKhoan);
                }
            }
        }

        HeThongTaiKhoan1 _HeThongTaiKhoan1Curent;
        private void treeTaiKhoan_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            _HeThongTaiKhoan1Curent = null;

            DevExpress.XtraTreeList.Nodes.TreeListNode node = e.Node;

            if (node.GetType().Name == "TreeListAutoFilterNode")
                return;

            //Lấy menu hiện tại
            _HeThongTaiKhoan1Curent = bdTaiKhoan.Current as HeThongTaiKhoan1;
            if (_HeThongTaiKhoan1Curent == null)
                return;

            foreach (HeThongTaiKhoan1 appMenu in lstTaiKhoan)
            {
                //----------------------------Bỏ check-------------------------------//
                if (appMenu.MaTaiKhoan == _HeThongTaiKhoan1Curent.MaTaiKhoan && _HeThongTaiKhoan1Curent.Chon == true)
                {
                    appMenu.Chon = false; //Bỏ check node hiện tại

                    //Bỏ check tất cả nút con
                    if (appMenu.MaTaiKhoan != 0)
                        RemoveCheckChild(appMenu.MaTaiKhoan);

                    //Gán bindingSource
                   
                    treeTaiKhoan.Refresh();
                    return;
                }

                //-----------------------------Check---------------------------------//
                if (appMenu.MaTaiKhoan == _HeThongTaiKhoan1Curent.MaTaiKhoan && _HeThongTaiKhoan1Curent.Chon == false)
                {
                    appMenu.Chon = true; //Check node hiện tại

                    //Check tất cả nút cha
                    if (appMenu.MaTaiKhoanCha != null)
                        CheckParent(appMenu.MaTaiKhoanCha);

                    //Check tất cả nút con
                    if (appMenu.MaTaiKhoan != 0)
                        CheckChild(appMenu.MaTaiKhoan);

                    //Gán bindingSource
                   
                    treeTaiKhoan.Refresh();
                    return;
                }
            }
        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            strMaTaiKhoan = "";
            foreach (HeThongTaiKhoan1 obj in lstTaiKhoan)
            {
                if (obj.Chon == true)
                    strMaTaiKhoan = strMaTaiKhoan + obj.MaTaiKhoan + ",";
            }
            if (strMaTaiKhoan.Length > 0)
            {
                strMaTaiKhoan = strMaTaiKhoan.Substring(0, strMaTaiKhoan.Length - 1);
            }
            this.Close();
        }






    }
}
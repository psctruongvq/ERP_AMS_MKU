using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
namespace PSC_ERP
{
    public partial class frmKho : Form
    {
        KhoList khoList = KhoList.NewKhoList();
           
        Util util = new Util();      
      
        Kho kho;// = Kho.NewKho(); 
        DoiTacList _doiTacList = DoiTacList.NewDoiTacList();         
        public delegate void GetData(KhoList value);
        public GetData getData;
        HamDungChung _hamDC = new HamDungChung();
        int maLoaiKho = 0;          
        int makho=0;

        #region Contructor
        public frmKho()
        {
            InitializeComponent();
            _hamDC.EventForm(this);
            _hamDC.EventGrid(ultraGridKho);           
            tlslblIn.Visible = false;
            tlslblTim.Visible = false;
            khoList = KhoList.GetKhoList_All();
            Kho_bindingSource.DataSource = khoList;

        }
        #endregion 

        #region Events
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
            this.Close();
        }
      
        private void ttbThem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < khoList.Count; i++)
                {
                    kho = khoList[i];
                    if (kho.MaQuanLy == "" || kho.TenKho == "")
                    {
                        return;
                    }
                }
                //khoList.AddNew();
                kho = Kho.NewKho();              
              
                khoList.Add(kho);
                Kho_bindingSource.DataSource = khoList;
                ultraGridKho.ActiveRow = ultraGridKho.Rows[khoList.Count - 1];
            }
            catch (ApplicationException ex)
            {

            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ultraGridKho.UpdateData();

                ultraGridKho.ActiveRow.Cells["MaQuanLy"].Value = tbMaKho.Text;
                ultraGridKho.ActiveRow.Cells["TenKho"].Value = tbTenKho.Text;
             int count = 0;

             #region Kiemtra Luới
                for (int i = 0; i < ultraGridKho.Rows.Count; i++)
                {
                    if (ultraGridKho.Rows[i].Cells["MaQuanLy"].Text == "")
                    {
                        MessageBox.Show(this, "Nhập Mã Quản Lý", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultraGridKho.ActiveRow = ultraGridKho.Rows[i];
                        return;
                    }
                    if (ultraGridKho.Rows[i].Cells["TenKho"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên  Kho", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultraGridKho.ActiveRow = ultraGridKho.Rows[i];
                        return;
                    }
                    if (ultraGridKho.Rows[i].Cells["MaTinhTrang"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Tình Trạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultraGridKho.ActiveRow = ultraGridKho.Rows[i];
                        return;
                    }                   
                   
                    if (ultraGridKho.Rows[i].Cells["MaQuanLy"].Value.ToString().ToUpper() == tbMaKho.Text.ToUpper())
                    {
                        count++;
                    }
                    if (count > 1)
                    {
                        MessageBox.Show("Mã Kho bị trùng !", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
             #endregion
                              
              khoList.ApplyEdit();
              khoList.Save();
              MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
              if (getData != null)
                  getData(this.khoList);
            }
            catch (ApplicationException ex) 
            {
                //MessageBox.Show(util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            //GridLoad();
            khoList = KhoList.GetKhoList_LoaiKho(maLoaiKho);
            Kho_bindingSource.DataSource = khoList;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultraGridKho.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultraGridKho.DeleteSelectedRows();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {            
            khoList = KhoList.GetKhoList_LoaiKho(maLoaiKho);
            Kho_bindingSource.DataSource = khoList;
        }

        #endregion

        #region ultraGridKho_InitializeLayout
        private void ultraGridKho_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //HamDungChung hdc = new HamDungChung();
          //  hdc.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.ultraGridKho.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;  //= System.Drawing.w;//RoyalBlue
                col.Hidden = true;
            }
            //màu nền
            this.ultraGridKho.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.ultraGridKho.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            

            ultraGridKho.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultraGridKho.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultraGridKho.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;
            ultraGridKho.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;

            ultraGridKho.DisplayLayout.Bands[0].Columns["TenKho"].Header.Caption = "Tên Kho";
            ultraGridKho.DisplayLayout.Bands[0].Columns["TenKho"].Header.VisiblePosition = 2;
            ultraGridKho.DisplayLayout.Bands[0].Columns["TenKho"].Width = 260;
            ultraGridKho.DisplayLayout.Bands[0].Columns["TenKho"].Hidden = false;


            ultraGridKho.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi Chú";
            ultraGridKho.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 4;
            ultraGridKho.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 300;
            ultraGridKho.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;

            //màu và font chữ

        }
        #endregion 

    }
}

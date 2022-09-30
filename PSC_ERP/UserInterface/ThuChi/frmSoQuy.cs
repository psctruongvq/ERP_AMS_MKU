using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmSoQuy : Form
    {
        Util util=new Util();
        
        SoQuyList list;
   
     

        public frmSoQuy()
        {
            InitializeComponent();
        }

    
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {

            bdSoQuy.EndEdit();
            ultragrdNgoaiNgu.UpdateData();
            list.ApplyEdit();
            list.Save();
            MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
  
        private void frmSoQuy_Load(object sender, EventArgs e)
        {

            list = SoQuyList.GetSoQuyList();
            bdSoQuy.DataSource = list;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            
            ultragrdNgoaiNgu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            list = SoQuyList.GetSoQuyList();
            bdSoQuy.DataSource = list;
        }

        private void ultragrdNgoaiNgu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
          
          
            foreach (UltraGridColumn col in this.ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition =0;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width=200;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["TenSoQuy"].Hidden = false;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["TenSoQuy"].Header.Caption = "Tên Sổ Quỹ";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["TenSoQuy"].Header.VisiblePosition = 1;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["TenSoQuy"].Width = 200;

            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["SoDuDauKyNo"].Hidden = false;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["SoDuDauKyNo"].Header.Caption = "Số Dư Đầu Nợ";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["SoDuDauKyNo"].Header.VisiblePosition = 2;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["SoDuDauKyNo"].Format = "###,###,###,###,###";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["SoDuDauKyNo"].CellAppearance.TextHAlign = HAlign.Right;

            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["SoDuDauKyCo"].Hidden = false;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["SoDuDauKyCo"].Header.Caption = "Số Dư Đầu Có";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["SoDuDauKyCo"].Header.VisiblePosition = 3;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["SoDuDauKyCo"].Format = "###,###,###,###,###";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["SoDuDauKyCo"].CellAppearance.TextHAlign = HAlign.Right;

            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["LuyKeDauKyNo"].Hidden = false;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["LuyKeDauKyNo"].Header.Caption = "Lũy Kế Nợ";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["LuyKeDauKyNo"].Header.VisiblePosition = 4;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["LuyKeDauKyNo"].Format = "###,###,###,###,###";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["LuyKeDauKyNo"].CellAppearance.TextHAlign = HAlign.Right;


            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["LuyKeDauKyCo"].Hidden = false;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["LuyKeDauKyCo"].Header.Caption = "Lũy Kế Có";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["LuyKeDauKyCo"].Header.VisiblePosition = 5;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["LuyKeDauKyCo"].Format = "###,###,###,###,###";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["LuyKeDauKyCo"].CellAppearance.TextHAlign = HAlign.Right;


            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["NgaySoDu"].Hidden = false;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["NgaySoDu"].Header.Caption = "Ngày Số Dư";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["NgaySoDu"].Header.VisiblePosition = 6;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["NgaySoDu"].Format = "dd/MM/yyyy";
            

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
    

      

        private void frmSoQuy_Load_2(object sender, EventArgs e)
        {
            list = SoQuyList.GetSoQuyList();
            this.bdSoQuy.DataSource = list;
        }
    }
}

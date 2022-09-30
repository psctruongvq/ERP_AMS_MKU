using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{


    public partial class frmPhieuChiTracking : Form
    {
        //GiayXacNhan_TrackingList _giayXacNhan_TrackingList=GiayXacNhan_TrackingList.NewGiayXacNhan_TrackingList();
        int maBoPhan = 0;
        ChiThuLaoList _list = null;
        public frmPhieuChiTracking()
        {
            InitializeComponent();
            this.PhieuChiTracking_bindingSourceList.DataSource = typeof(ChiThuLaoList);
            maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            _list = ChiThuLaoList.GetChiThuLaoListByUser(ERP_Library.Security.CurrentUser.Info.UserID,Convert.ToDateTime(dateTimePicker_TuNgay.Value),Convert.ToDateTime( dateTimePicker_DenNgay.Value));
           
            for (int i = 0; i < _list.Count; i++)
            {
                ChiThuLao.UpdateSoTienDaNhapPhieuChi(_list[i].MaChiThuLao);
            }
            _list = ChiThuLaoList.GetChiThuLaoListByUser(ERP_Library.Security.CurrentUser.Info.UserID, Convert.ToDateTime(dateTimePicker_TuNgay.Value), Convert.ToDateTime(dateTimePicker_DenNgay.Value));
            this.PhieuChiTracking_bindingSourceList.DataSource = _list;
        }

        private void ultraGrid1_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (ultraGrid1.ActiveCell == ultraGrid1.ActiveRow.Cells["HoanTat"])
            {
                if (ultraGrid1.ActiveRow.IsFilterRow!=true)
                {
                    long _maChiThuLao = (long)ultraGrid1.ActiveRow.Cells["MaChiThuLao"].Value;

                    bool _tinhTrang = (bool)ultraGrid1.ActiveRow.Cells["HoanTat"].Value;
                    decimal _soTienConLai = (decimal)ultraGrid1.ActiveRow.Cells["SoTienConLai"].Value;
                    if (_soTienConLai != 0 && _tinhTrang == false)
                    {
                        DialogResult result = MessageBox.Show("Số tiền còn lại chưa hết. Bạn có muốn hoàn tất giấy xác nhận?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            if (_tinhTrang == true)
                            {
                                ultraGrid1.ActiveRow.Cells["HoanTat"].Value = false;
                            }

                            return;
                        }
                    }
                    bool TinhTrang = false;
                    if (_tinhTrang == true)
                        TinhTrang = false;
                    else
                        TinhTrang = true;
                    ChiThuLao.UpdateTrangThaiChiThuLao(_maChiThuLao, TinhTrang);
                }
            }
          
        }

        private void ultraGrid1_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (ultraGrid1.ActiveCell == ultraGrid1.ActiveRow.Cells["SoTienSeNhap"] || ultraGrid1.ActiveCell == ultraGrid1.ActiveRow.Cells["SoTienSeNhapNgoaiDai"])
            {
                long _maChiThuLao = (long)ultraGrid1.ActiveRow.Cells["MaChiThuLao"].Value;
                bool _hoanTat = (bool)ultraGrid1.ActiveRow.Cells["HoanTat"].Value;
                decimal _soTienSeNhap = (decimal)ultraGrid1.ActiveRow.Cells["SoTienSeNhap"].Value;
                decimal _soTienSeNhapNgoaiDai = (decimal)ultraGrid1.ActiveRow.Cells["SoTienSeNhapNgoaiDai"].Value;
                int _maDBGui = (int)ultraGrid1.ActiveRow.Cells["MaDBGui"].Value;
                if (_hoanTat == true)
                    return;
                ChiThuLao.UpdateSoTienSeNhapPhieuChi(_maChiThuLao, _soTienSeNhap, _soTienSeNhapNgoaiDai, _maDBGui);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraGrid1);
            
           
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
        }
    }
}

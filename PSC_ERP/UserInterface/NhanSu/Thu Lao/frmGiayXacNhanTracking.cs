using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Diagnostics;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    //
    public partial class frmGiayXacNhanTracking : Form
    {
        GiayXacNhan_TrackingList _giayXacNhan_TrackingList=GiayXacNhan_TrackingList.NewGiayXacNhan_TrackingList();
        public frmGiayXacNhanTracking()
        {
            InitializeComponent();
            this.GiayXacNhanTracking_bindingSourceList.DataSource = typeof(GiayXacNhan_TrackingList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            _giayXacNhan_TrackingList = GiayXacNhan_TrackingList.GetGiayXacNhan_TrackingListByUser(ERP_Library.Security.CurrentUser.Info.UserID,Convert.ToDateTime(dateTimePicker_TuNgay.Value), Convert.ToDateTime(dateTimePicker_DenNgay.Value));
            for (int i = 0; i < _giayXacNhan_TrackingList.Count; i++)
            {
                GiayXacNhan_Tracking.UpdateSoTienDaNhapChiTietGiayXacNhan(_giayXacNhan_TrackingList[i].TrackingID, _giayXacNhan_TrackingList[i].MaChiTietGiayXacNhan, _giayXacNhan_TrackingList[i].MaBoPhanNhan);
            }
            _giayXacNhan_TrackingList = GiayXacNhan_TrackingList.GetGiayXacNhan_TrackingListByUser(ERP_Library.Security.CurrentUser.Info.UserID, Convert.ToDateTime(dateTimePicker_TuNgay.Value), Convert.ToDateTime(dateTimePicker_DenNgay.Value));
            this.GiayXacNhanTracking_bindingSourceList.DataSource = _giayXacNhan_TrackingList;
        }

        private void ultraGrid1_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (ultraGrid1.ActiveCell == ultraGrid1.ActiveRow.Cells["TinhTrang"])
            {
                int _maGiayXacNhan = (int)ultraGrid1.ActiveRow.Cells["MaGiayXacNhan"].Value;
                int _maChiTietGiayXacNhan = (int)ultraGrid1.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value;
                //int _DBNumberGXN = (int)ultraGrid1.ActiveRow.Cells["DatabasenumberGxn"].Value;
                bool _tinhTrang = (bool)ultraGrid1.ActiveRow.Cells["TinhTrang"].Value;
                decimal _soTienConLai = (decimal)ultraGrid1.ActiveRow.Cells["SoTienConLai"].Value;
                if (_soTienConLai != 0 && _tinhTrang == false)
                {                    
                  DialogResult result=  MessageBox.Show("Số tiền còn lại chưa hết. Bạn có muốn hoàn tất giấy xác nhận?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                  if (result == DialogResult.No)
                  {
                      if (_tinhTrang == true)
                      {
                          ultraGrid1.ActiveRow.Cells["TinhTrang"].Value = false;
                      }
                      
                      return;
                  }
                }
                bool TinhTrang = false;
                if (_tinhTrang == true)
                    TinhTrang = false;
                else
                    TinhTrang = true;
                ChiTietGiayXacNhan.UpdateTrangThaiChiTietGXN(_maChiTietGiayXacNhan, TinhTrang);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string filePath = fbd.SelectedPath + "DanhSachGXNHTV_" + DateTime.Today.Day.ToString() + "_" + DateTime.Today.Month.ToString() + "_" + DateTime.Today.Year.ToString() + ".xls"; ;

            ultraGridExcelExporter1.Export(ultraGrid1, filePath);
            MessageBox.Show("Import thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(filePath);

        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.CellActivation = Activation.NoEdit;
                if (col.DataType == typeof(DateTime))
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType ==typeof(decimal))
                {
                    col.Format = "###,###,###,###,###";
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 0;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.Caption = "Bộ Phận Gửi";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.VisiblePosition = 1;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.Caption = "Bộ Phận Nhận";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.VisiblePosition = 2;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 3;
            ultraGrid1.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.Caption = "Nhập Hộ";
            ultraGrid1.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.VisiblePosition = 4;

            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 5;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapNV"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapNV"].Header.Caption = "Tiền CK Nhân Viên";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapNV"].Header.VisiblePosition = 6;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapNVNgoaiDai"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapNVNgoaiDai"].Header.Caption = "Tiền CK NV Ngoài Đài";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapNVNgoaiDai"].Header.VisiblePosition = 7;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapNVTienMat"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapNVTienMat"].Header.Caption = "Tiền Mặt";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapNVTienMat"].Header.VisiblePosition =8;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapTrongDinhMuc"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapTrongDinhMuc"].Header.Caption = "Tiền Trong ĐM";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaNhapTrongDinhMuc"].Header.VisiblePosition = 9;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaDeNghiCK"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaDeNghiCK"].Header.Caption = "Tiền Đã Đề Nghị CK";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienDaDeNghiCK"].Header.VisiblePosition = 10;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienChuaDeNghiCK"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienChuaDeNghiCK"].Header.Caption = "Tiền Chưa Đề Nghị CK";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienChuaDeNghiCK"].Header.VisiblePosition = 11;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 12;

            ultraGrid1.DisplayLayout.Bands[0].Columns["NgayLapGXN"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["NgayLapGXN"].Header.Caption = "Ngày Lập GXN";
            ultraGrid1.DisplayLayout.Bands[0].Columns["NgayLapGXN"].Header.VisiblePosition = 13;
          
            ultraGrid1.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TinhTrang"].CellActivation=Activation.AllowEdit;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TinhTrang"].Header.Caption = "Hoàn Tất";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TinhTrang"].Header.VisiblePosition = 14;

            ultraGrid1.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            ultraGrid1.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 15;

        }
    }
}
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
using System.IO;
using System.Diagnostics;

namespace PSC_ERP
{
    public partial class FrmTheoDoiHopDongThuChi : DevExpress.XtraEditors.XtraForm
    {
        int _maLoaiHopDong;
        int _maPhanLoaiHD = 0;
        long _maDoiTac = 0;
        bool _timTheoNgay;
        DataTable _tableSource;
        public FrmTheoDoiHopDongThuChi()
        {
            InitializeComponent();
            KhoiTao();

        }

        private void KhoiTao()
        {
            LoaiHopDongList loaiHDList=LoaiHopDongList.GetLoaiHopDongList();
            LoaiHopDong loaiHD = LoaiHopDong.NewLoaiHopDong(0, "Không chọn");
            loaiHDList.Insert(0,loaiHD);
            loaiHopDongListBindingSource.DataSource = loaiHDList; 


            DoiTacList _doiTacList = DoiTacList.GetDoiTacList("", 0);
            DoiTac _doiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _doiTacList.Insert(0, _doiTac);
            doiTacListBindingSource.DataSource = _doiTacList;

            PhanLoaiHopDongList _phanLoaiHopDongList = PhanLoaiHopDongList.GetPhanLoaiHopDongList();
            PhanLoaiHopDong _pLHD = PhanLoaiHopDong.NewPhanLoaiHopDong(0, "Không chọn");
            _phanLoaiHopDongList.Insert(0, _pLHD);
            PhanLoaiHopDongList_bindingSource.DataSource = _phanLoaiHopDongList;

            _tableSource = new DataTable();
        }
        #region Function
        private void GetThongTinSearch()
        {
            if (gridLookUpEdit_LoaiHD.EditValue != null)
            {
                _maLoaiHopDong = (int)gridLookUpEdit_LoaiHD.EditValue;
            }
            else
            {
                _maPhanLoaiHD = 0;
            }

            if (grdLU_MaPhanLoaiHD.EditValue != null)
            {
                _maPhanLoaiHD = (int)grdLU_MaPhanLoaiHD.EditValue;
            }
            else
            {
                _maPhanLoaiHD = 0;
            }

            

            if (grdLU_MaDoiTac.EditValue != null)
            {
                _maDoiTac = Convert.ToInt64(grdLU_MaDoiTac.EditValue);// (long)grdLU_MaDoiTac.EditValue;
            }
            else
            {
                _maDoiTac = 0;
            }
            if (checkEdit_Ngay.EditValue != null)
            {
                _timTheoNgay =checkEdit_Ngay.Checked;

            }
            else
            {
                _timTheoNgay = false;
            }

        }

        private void LoadData()
        {
            GetThongTinSearch();
            _tableSource = HopDongThuChiList.Table_TheoDoiHopDong(_timTheoNgay, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _maLoaiHopDong, _maPhanLoaiHD, _maDoiTac);
            
        }


        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView1, new string[] { "TenDoiTac", "SoHopDong", "NgayHD", "NgayTH", "SoThamDinh", "NgayThamDinh", "NoiDungHD", "GiaTriHD", "QuyCMTL", "NgayCMTL", "ThanhLy", "chuaThanhToan", "TongThanhToan", "TongThuLao", "TToan1", "NgayTToan1", "ThuLao1", "NgayTLao1", "TToan2", "NgayTToan2", "ThuLao2", "NgayTLao2", "TToan3", "NgayTToan3", "ThuLao3", "NgayTLao3" },
                                new string[] { "Đối tác", "Số HĐ", "Ngày HĐ", "Ngày TH","Số thẩm định","Ngày thẩm định", "Nội dung", "Tổng cộng", "Quỹ CMTL", "Ngày", "Thanh Lý", "chưa Thanh Toán", "Tổng TToán", "Tổng TLao", "T.Toán 1", "Ngày TT1", "Thù lao Đ1", "Ngày TL1", "T.Toán 2", "Ngày TT2", "Thù lao Đ2", "Ngày TL2", "T.Toán 3", "Ngày TT3", "Thù lao Đ3", "Ngày TL3" },
                                             new int[] { 100, 100, 85, 85, 100, 85, 100, 100, 100, 85, 100, 100, 100, 100, 100, 85, 100, 85, 100, 85, 100, 85, 100, 85, 100, 85 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "TenDoiTac", "SoHopDong", "NgayHD", "NgayTH", "SoThamDinh", "NgayThamDinh", "NoiDungHD", "GiaTriHD", "QuyCMTL", "NgayCMTL", "ThanhLy", "chuaThanhToan", "TongThanhToan", "TongThuLao", "TToan1", "NgayTToan1", "ThuLao1", "NgayTLao1", "TToan2", "NgayTToan2", "ThuLao2", "NgayTLao2", "TToan3", "NgayTToan3", "ThuLao3", "NgayTLao3" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "GiaTriHD","QuyCMTL","ThanhLy", "chuaThanhToan", "TongThanhToan", "TongThuLao", "TToan1", "TToan2", "TToan3","ThuLao1", "ThuLao2", "ThuLao3" }, "#,###");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "GiaTriHD", "QuyCMTL", "ThanhLy", "chuaThanhToan", "TongThanhToan" }, "{0:n1}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "GiaTriHD", "QuyCMTL", "ThanhLy", "chuaThanhToan", "TongThanhToan", "TongThuLao", "TToan1", "TToan2", "TToan3", "ThuLao1", "ThuLao2", "ThuLao3" }, "#,###");
            Utils.GridUtils.SetSTTForGridView(gridView1, 40);//M
        }

        #endregion

        #region Event

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.Columns.Clear();
            _tableSource = new DataTable();
            LoadData();
            gridControl1.DataSource = _tableSource;
            DesignGridView();
            if (_tableSource.Rows.Count == 0)//M
                MessageBox.Show("Danh Sách Hợp đồng rỗng!");
        }

       
        #endregion

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }



     

        private void FrmDanhSachHopDongThuChi_Load(object sender, EventArgs e)
        {
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }
    }
}
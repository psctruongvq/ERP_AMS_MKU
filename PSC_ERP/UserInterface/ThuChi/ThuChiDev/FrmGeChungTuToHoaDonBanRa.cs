using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
//13/04/2013
namespace PSC_ERP
{
    public partial class FrmGeChungTuToHoaDonBanRa : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        List<ChungTuForHoaDonBanRa> _chungtuList = new List<ChungTuForHoaDonBanRa>();
        List<ChungTuForHoaDonBanRa> _chungtuListSelected = new List<ChungTuForHoaDonBanRa>();
        BindingSource DSChungTu_BindingSource = new BindingSource();

        public List<ChungTuForHoaDonBanRa> ChungTuListSelected
        {
            get { return _chungtuListSelected; }

        }
        #endregion//Properties

        private void DesignGridView()
        {
            #region Design Gridview
            gridControl1.DataSource = DSChungTu_BindingSource;

            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);


            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "SoChungTu", "NgayChungTu", "TenDoiTuong", "DienGiaiButToan", "SoTienButToan", "PhuongThucThanhToanString" },
                                new string[] { "Chọn", "Số chứng từ", "Ngày chứng từ","Đối tượng", "Nội dung", "Số tiền","PT Thanh toán" },
                                             new int[] { 80, 100, 90,120, 150, 100,90 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "SoChungTu", "NgayChungTu", "TenDoiTuong", "DienGiaiButToan", "SoTienButToan", "PhuongThucThanhToanString" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTienButToan" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTienButToan" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoChungTu", "NgayChungTu", "TenDoiTuong", "DienGiaiButToan", "SoTienButToan", "PhuongThucThanhToanString" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }

        private void loadForm()//HinhThucThanhToan: 1-> Tiền mặt; 2 -> Chuyển Khoản
        {
            DSChungTu_BindingSource.DataSource = typeof(ChungTuForHoaDonBanRa);
            // chi lay nhung hoa don cua nguoi lap chung tu
            _chungtuList = ChungTuForHoaDonBanRa.LoadChungTuForHoaDonBanRaList();
            DSChungTu_BindingSource.DataSource = _chungtuList;
            DesignGridView();
        }
        public FrmGeChungTuToHoaDonBanRa()
        {//--kieulap=1: LâpChứng Từ; kieulap=2: Lập Hóa Đơn
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            loadForm();

        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FocustextBox1.Focus();
            DSChungTu_BindingSource.EndEdit();
            foreach (ChungTuForHoaDonBanRa ctbl in _chungtuList)
            {
                if (ctbl.Check == true)
                {
                    _chungtuListSelected.Add(ctbl);
                }
            }
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //HoaDon hd = (HoaDon)DSButToan_BindingSource.Current;
            //CheckEdit check = (CheckEdit)sender;
            //hd.Check = (bool)check.EditValue;

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            ChungTuForHoaDonBanRa obj = (ChungTuForHoaDonBanRa)DSChungTu_BindingSource.Current;
            long maChungTu = obj.MaChungTu;
            int maLoaiChungTu = obj.MaLoaiChungTu;

            if (maChungTu > 0)
            {
                switch (maLoaiChungTu)
                {
                    case 2:
                        //PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu,isShowFromReport);
                        PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu);
                        //frm.maChungTuOfReport = maChungTu;
                        //frm.isShowFromReport = isShowFromReport;
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();
                        break;

                    case 3:
                        PSC_ERP.FrmChungTuChiTienMat frm3 = new PSC_ERP.FrmChungTuChiTienMat(maChungTu);
                        frm3.WindowState = FormWindowState.Maximized;
                        frm3.ShowDialog();
                        break;

                    case 4:
                        PSC_ERP.frmPhieuNhapVatTuHangHoa_New frm4 = new PSC_ERP.frmPhieuNhapVatTuHangHoa_New(maChungTu);
                        frm4.WindowState = FormWindowState.Maximized;
                        frm4.ShowDialog();
                        break;

                    case 5:
                        PSC_ERP.FrmPhieuXuatVatTuHangHoa_New frm5 = new PSC_ERP.FrmPhieuXuatVatTuHangHoa_New(maChungTu, 1);
                        frm5.WindowState = FormWindowState.Maximized;
                        frm5.ShowDialog();
                        break;

                    case 6:
                        PSC_ERP.FrmChungTuThuTienGui frm6 = new PSC_ERP.FrmChungTuThuTienGui(maChungTu);
                        frm6.WindowState = FormWindowState.Maximized;
                        frm6.ShowDialog();
                        break;

                    case 7:
                        PSC_ERP.FrmChungTuChiTienGui frm7 = new PSC_ERP.FrmChungTuChiTienGui(maChungTu);
                        frm7.WindowState = FormWindowState.Maximized;
                        frm7.ShowDialog();
                        break;

                    case 8:
                        PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD frm8 = new PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD(maChungTu);
                        frm8.WindowState = FormWindowState.Maximized;
                        frm8.ShowDialog();
                        break;

                    case 9:
                        PSC_ERP.FrmChungTuMuaChuaThanhToan frm9 = new PSC_ERP.FrmChungTuMuaChuaThanhToan(maChungTu);
                        frm9.WindowState = FormWindowState.Maximized;
                        frm9.ShowDialog();
                        break;

                    case 10:
                        PSC_ERP.FrmChungTuGiayNhanNo frm10 = new PSC_ERP.FrmChungTuGiayNhanNo(maChungTu);
                        frm10.WindowState = FormWindowState.Maximized;
                        frm10.ShowDialog();
                        break;

                    case 14:
                        PSC_ERP.FrmChungTuChuyenTienNoiBo frm14 = new PSC_ERP.FrmChungTuChuyenTienNoiBo(maChungTu);
                        frm14.WindowState = FormWindowState.Maximized;
                        frm14.ShowDialog();
                        break;

                    case 16:
                        PSC_ERP.FrmChungTuKeToanCustomize frm16 = new PSC_ERP.FrmChungTuKeToanCustomize(maChungTu);
                        frm16.WindowState = FormWindowState.Maximized;
                        frm16.ShowDialog();
                        break;

                    case 22:
                        PSC_ERP.FrmChungTuPhiNganHang frm22 = new PSC_ERP.FrmChungTuPhiNganHang(maChungTu);
                        frm22.WindowState = FormWindowState.Maximized;
                        frm22.ShowDialog();
                        break;

                    case 23:
                        PSC_ERP.FrmChungTuMuaNgoaiTe frm23 = new PSC_ERP.FrmChungTuMuaNgoaiTe(maChungTu);
                        frm23.WindowState = FormWindowState.Maximized;
                        frm23.ShowDialog();
                        break;

                    case 24:
                        PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai frm24 = new PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai(maChungTu);
                        frm24.WindowState = FormWindowState.Maximized;
                        frm24.ShowDialog();
                        break;

                    case 25:
                        PSC_ERP.FrmChungTuGiayRutTienMat frm25 = new PSC_ERP.FrmChungTuGiayRutTienMat(maChungTu);
                        frm25.WindowState = FormWindowState.Maximized;
                        frm25.ShowDialog();
                        break;


                    default:
                        MessageBox.Show("Không tìm thấy form chứng từ");
                        break;
                }

                RefreshData();
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }


        private void RefreshData()
        {
            _chungtuList = ChungTuForHoaDonBanRa.LoadChungTuForHoaDonBanRaList();
            DSChungTu_BindingSource.DataSource = _chungtuList;
        }


    }
}
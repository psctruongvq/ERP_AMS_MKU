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
    public partial class FrmGetButToanThuePhaiNopToHoaDonBanRa : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        List<ButToanThuePhaiNopForHoaDonBanRa> _butToanList = new List<ButToanThuePhaiNopForHoaDonBanRa>();
        List<ButToanThuePhaiNopForHoaDonBanRa> _butToanListSelected = new List<ButToanThuePhaiNopForHoaDonBanRa>();
        BindingSource DSButToan_BindingSource = new BindingSource();

        public List<ButToanThuePhaiNopForHoaDonBanRa> ButToanThuePhaiNopListSelected
        {
            get { return _butToanListSelected; }

        }
        #endregion//Properties

        private void DesignGridView()
        {
            #region Design Gridview
            gridControl1.DataSource = DSButToan_BindingSource;

            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);


            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "SoChungTu", "NgayChungTu", "TenDoiTuong", "DienGiai", "TienThue", "TienSauThue","PhuongThucThanhToanString" },
                                new string[] { "Chọn", "Số chứng từ", "Ngày chứng từ","Đối tượng", "Nội dung", "Tiền thuế", "Tiền sau thuế","PT Thanh toán" },
                                             new int[] { 80, 100, 90,120, 150, 100, 100,90 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "SoChungTu", "NgayChungTu", "TenDoiTuong", "DienGiai", "TienThue", "TienSauThue","PhuongThucThanhToanString" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TienThue", "TienSauThue" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TienThue", "TienSauThue" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] {"SoChungTu", "NgayChungTu", "TenDoiTuong", "DienGiai", "TienThue", "TienSauThue","PhuongThucThanhToanString" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }

        private void loadForm()//HinhThucThanhToan: 1-> Tiền mặt; 2 -> Chuyển Khoản
        {
            DSButToan_BindingSource.DataSource = typeof(ButToanThuePhaiNopForHoaDonBanRa);
            // chi lay nhung hoa don cua nguoi lap chung tu
            _butToanList = ButToanThuePhaiNopForHoaDonBanRa.LoadBienLaiFromOtherDBList();
            DSButToan_BindingSource.DataSource = _butToanList;
            DesignGridView();
        }
        public FrmGetButToanThuePhaiNopToHoaDonBanRa()
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
            DSButToan_BindingSource.EndEdit();
            foreach (ButToanThuePhaiNopForHoaDonBanRa ctbl in _butToanList)
            {
                if (ctbl.Check == true)
                {
                    _butToanListSelected.Add(ctbl);
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





    }
}
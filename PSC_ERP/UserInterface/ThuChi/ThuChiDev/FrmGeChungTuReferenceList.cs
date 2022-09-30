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
    public partial class FrmGeChungTuReferenceList : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        List<ChungTuReference> _chungtuRefList = new List<ChungTuReference>();
        List<ChungTuReference> _chungtuRefListSelected = new List<ChungTuReference>();
        BindingSource DSChungTuRef_BindingSource = new BindingSource();
        private byte _RefType = 0;//1: Hoàn ứng

        public List<ChungTuReference> ChungTuRefListSelected
        {
            get { return _chungtuRefListSelected; }

        }
        #endregion//Properties

        private void DesignGridView()
        {
            #region Design Gridview
            gridControl1.DataSource = DSChungTuRef_BindingSource;

            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);


            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "SoChungTu", "NgayChungTu", "TenDoiTuong", "NoiDung", "TenLoaiTien", "SoTien", "ThanhTien" },
                                new string[] { "Chọn", "Số chứng từ", "Ngày ghi sổ", "Đối tượng", "Nội dung", "Loại tiền", "Số tiền ngoại tệ", "Số tiền" },
                                             new int[] { 80, 100, 90, 150, 200, 90, 100, 100 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "SoChungTu", "NgayChungTu", "TenDoiTuong", "NoiDung", "TenLoaiTien", "SoTien", "ThanhTien" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien" }, "{0:#,###.#}");
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "ThanhTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "ThanhTien" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoChungTu", "NgayChungTu", "TenDoiTuong", "NoiDung", "TenLoaiTien", "SoTien", "ThanhTien" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }

        private void loadForm(int maloaiCT, long madoituong, byte refType)
        {
            DSChungTuRef_BindingSource.DataSource = typeof(ChungTuReference);
            // chi lay nhung hoa don cua nguoi lap chung tu
            _chungtuRefList = ChungTuReference.LoadChungTuReferenceList(maloaiCT, madoituong, refType);
            DSChungTuRef_BindingSource.DataSource = _chungtuRefList;
            DesignGridView();
        }
        public FrmGeChungTuReferenceList(int maloaiCT, long madoituong, byte refType)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _RefType = refType;
            loadForm(maloaiCT, madoituong, refType);

        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FocustextBox1.Focus();
            DSChungTuRef_BindingSource.EndEdit();
            foreach (ChungTuReference ctR in _chungtuRefList)
            {
                if (ctR.Check == true)
                {
                    _chungtuRefListSelected.Add(ctR);
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
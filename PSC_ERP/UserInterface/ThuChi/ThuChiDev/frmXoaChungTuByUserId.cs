using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmXoaChungTuByUserId : DevExpress.XtraEditors.XtraForm
    {
        private ChungTu _chungTu;
        private ChungTuList _chungTuList = ChungTuList.NewChungTuList();
        private ChungTuRutGonList _ChungTuRutGonList;
        private BindingSource ChungTuBindingS = new BindingSource();

        public frmXoaChungTuByUserId()
        {
            InitializeComponent();
            this.Load += frmXoaChungTuByUserId_Load;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.checkAll.EditValueChanged += checkAll_EditValueChanged;
        }

        void checkAll_EditValueChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked == true)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["Check"], true);
                }
                gridControl1.Select();
            }
            else
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["Check"], false);
                }
                gridControl1.Select();
            }
        }

        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        List<ChungTuRutGonList> _HDTTList = new List<ChungTuRutGonList>();
        public List<ChungTuRutGonList> hdttListSelected
        {
            get { return _HDTTList; }

        }

        void frmXoaChungTuByUserId_Load(object sender, EventArgs e)
        {
            //_chungTu = ChungTu.NewChungTu();
            //_ChungTuList = ChungTuList.NewChungTuList();
            //_ChungTuList = ChungTuList.GetChungTuListByUserId(39);
            _ChungTuRutGonList = ChungTuRutGonList.NewChungTuRutGonList();
            dtm_DenNgay.DateTime = DateTime.Now;
            dtmp_TuNgay.DateTime = DateTime.Now;

        }

        private void DesignGridView()
        {
            gridControl1.DataSource = ChungTuBindingS;

            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);


            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "SoChungTu", "NgayLap", "SoTien", "TenDoiTuong", "DienGiai", "TenDangNhap" },
                                new string[] { "Chọn", "Số Chứng Từ", "Ngày Lập", "Số Tiền", "Tên Đối Tượng", "Diễn Giải", "Tên Người Dùng" },
                                             new int[] { 50, 70, 70, 70, 130, 130, 70 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "SoChungTu", "NgayLap", "SoTien", "TenDoiTuong", "DienGiai", "TenDangNhap" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTien"}, "#,###.#");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoChungTu", "NgayLap", "SoTien", "TenDoiTuong", "DienGiai", "TenDangNhap" });
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTien"}, "{0:#,###.#}");
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M

        }


        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FocustextBox1.Focus();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa những chứng từ này !!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (ChungTuRutGon a in ChungTuBindingS)
                    {
                        if (a.Check == true)
                        {
                            _chungTu = ChungTu.NewChungTu();
                            ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(a.MaChungTu);
                            if (ct.Count > 0)
                            {
                                _chungTu = ct[0];
                            }
                            ChungTu.DeleteChungTu(_chungTu);
                        }
                    }
                }
                MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch
            {
                MessageBox.Show("Lỗi !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _ChungTuRutGonList = ChungTuRutGonList.GetChungTuListAllByUserId(dtmp_TuNgay.DateTime,dtm_DenNgay.DateTime);

            ChungTuBindingS.DataSource = _ChungTuRutGonList;
            gridControl1.DataSource = ChungTuBindingS;
                
            
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ChungTuRutGonList = ChungTuRutGonList.GetChungTuListAllByUserId(dtmp_TuNgay.DateTime, dtm_DenNgay.DateTime);

            ChungTuBindingS.DataSource = _ChungTuRutGonList;
            gridControl1.DataSource = ChungTuBindingS;
            DesignGridView();
        }
    }
}
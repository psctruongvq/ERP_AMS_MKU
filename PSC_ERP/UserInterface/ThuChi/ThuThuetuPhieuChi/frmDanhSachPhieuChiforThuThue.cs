using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
//04/04/2013
namespace PSC_ERP
{
    public partial class frmDanhSachPhieuChiforThuThue : DevExpress.XtraEditors.XtraForm
    {
        long _maDoiTac;
        List<ChungTuPhieuChiforLapPhieuThu> _ChungTuPhieuChiforLapPhieuThuList = new List<ChungTuPhieuChiforLapPhieuThu>();
        PhieuThutuPhieuChiEditableChildList _phieuThutuPhieuChiList = PhieuThutuPhieuChiEditableChildList.NewPhieuThutuPhieuChiEditableChildList();
        private long _maChungTu;
        private string _soChungtuPhieuChiString = string.Empty;
        bool _lockPhieuChi = false;
        public bool _trangThai = false;
        public decimal _tongTien = 0;
        private void LockPhieuChi()
        {
            grdv_ThongTinPhieuChi.Columns["Check"].OptionsColumn.AllowEdit = false;

        }
        void UnLockHopDong()
        {
            grdv_ThongTinPhieuChi.Columns["Check"].OptionsColumn.AllowEdit = true;
        }

        public PhieuThutuPhieuChiEditableChildList PhieuThutuPhieuChiList
        {
            get { return _phieuThutuPhieuChiList; }
        }//

        public string SoChungtuPhieuChiString
        {
            get { return _soChungtuPhieuChiString; }
        }//

        public bool TrangThai { get { return _trangThai; } }

        public decimal TongTienChon { get { return _tongTien; } }

        private void DesignGrid()
        {
            _ChungTuPhieuChiforLapPhieuThuList = ChungTuPhieuChiforLapPhieuThu.CreatChungTuPhieuChiforLapPhieuThuList(_maChungTu);
            grd_PhieuChi.DataSource = _ChungTuPhieuChiforLapPhieuThuList;
            HamDungChung.InitGridViewDev(grdv_ThongTinPhieuChi, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(grdv_ThongTinPhieuChi, new string[] { "Check", "SoChungTu", "NgayLap", "TienThue" },
                                new string[] { "Chọn", "Số chứng từ", "Ngày lập", "Tiền thuế" },
                                             new int[] { 35, 100, 70, 90 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdv_ThongTinPhieuChi, new string[] { "Check", "SoChungTu", "NgayLap", "TienThue" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdv_ThongTinPhieuChi, new string[] { "TienThue" }, "{0:#,###.###}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(grdv_ThongTinPhieuChi, new string[] { "SoChungTu", "NgayLap" });

            Utils.GridUtils.SetSTTForGridView(grdv_ThongTinPhieuChi, 35);//M
            this.grdv_ThongTinPhieuChi.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdVChiTietThanhToan_CellValueChanged);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdv_ThongTinPhieuChi, new string[] { "TienThue" }, "{0:#,###.###}");

        }

        private void CustomizeCheckProperties(PhieuThutuPhieuChiEditableChildList selectedList)
        {
            foreach (PhieuThutuPhieuChiEditableChild selectedItem in selectedList)
            {
                int j = -1;
                for (int i = j + 1; i < _ChungTuPhieuChiforLapPhieuThuList.Count; i++)
                {
                    ChungTuPhieuChiforLapPhieuThu ct = _ChungTuPhieuChiforLapPhieuThuList[i];
                    if (ct.MaChungTu == selectedItem.MaPhieuChi)
                    {
                        ct.Check = true;
                        ct.TienThue = selectedItem.SoTien;
                        j = i;
                    }
                }
            }
            grdv_ThongTinPhieuChi.RefreshData();

        }

        private void grdVChiTietThanhToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdv_ThongTinPhieuChi.FocusedColumn.FieldName == "TienThue")
            {
                ChungTuPhieuChiforLapPhieuThu ct = grdv_ThongTinPhieuChi.GetFocusedRow() as ChungTuPhieuChiforLapPhieuThu;
                if (ct.TienThue > ChungTuPhieuChiforLapPhieuThu.GetTienThueConLai(ct.MaChungTu, _maChungTu))
                {
                    MessageBox.Show("Tiền thuế vượt quá tiền thuế còn lại của phiếu chi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    ct.TienThue = ChungTuPhieuChiforLapPhieuThu.GetTienThueConLai(ct.MaChungTu, _maChungTu);
                }
            }
        }
        public frmDanhSachPhieuChiforThuThue()
        {
            InitializeComponent();
        }//

        public frmDanhSachPhieuChiforThuThue(long maChungTu, PhieuThutuPhieuChiEditableChildList selectedList, bool Lockphieuchi)
        {
            InitializeComponent();
            _maChungTu = maChungTu;
            _lockPhieuChi = Lockphieuchi;
            DesignGrid();
            CustomizeCheckProperties(selectedList);
        }//


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _trangThai = false;
            this.Close();
        }//

        private void btn_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }//

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit_Focus.Focus();

            _trangThai = true;
            _tongTien = 0;
            for (int i = 0; i < _ChungTuPhieuChiforLapPhieuThuList.Count; i++)
            {
                ChungTuPhieuChiforLapPhieuThu ct = _ChungTuPhieuChiforLapPhieuThuList[i];
                if (ct.Check)
                {
                    _phieuThutuPhieuChiList.Add(PhieuThutuPhieuChiEditableChild.NewPhieuThutuPhieuChiEditableChild(ct.MaChungTu, ct.SoChungTu, ct.TienThue));
                    _tongTien += ct.TienThue;
                }
            }
            _soChungtuPhieuChiString = PhieuThutuPhieuChiEditableChildList.GetSoChungTuString(_phieuThutuPhieuChiList);

            this.Close();
        }

        private void CheckEdit_Chon_EditValueChanged(object sender, EventArgs e)
        {
            //HopDongMuaBan _hdmb = (HopDongMuaBan)HopDongMuaBanList_BindingSource.Current;
            //CheckEdit ch = (CheckEdit)sender;
            //_hdmb.Check = (bool)ch.EditValue;
        }

        private void frmChonHopDongLapPhieu_Load(object sender, EventArgs e)
        {
            if (_lockPhieuChi)
            {
                LockPhieuChi();
            }
            else
            {
                UnLockHopDong();
            }
        }//
    }
}
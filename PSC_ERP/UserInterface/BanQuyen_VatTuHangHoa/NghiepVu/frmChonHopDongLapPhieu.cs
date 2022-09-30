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
    public partial class frmChonHopDongLapPhieu : DevExpress.XtraEditors.XtraForm
    {
        long _maDoiTac;
        HopDongMuaBanList _HopDongMuaBanList = HopDongMuaBanList.NewHopDongMuaBanList();
        NhapXuat_HopDongList _nhapXuat_HopDongList = NhapXuat_HopDongList.NewNhapXuat_HopDongList();
        PhieuNhapXuat _phieuNhapXuat;
        bool _trangThai = false;
        string _soHopDong = "";
        bool _lockHopDong = false;
        private void LockHopDong()
        {
            grdv_ThongTinHopDong.Columns["Check"].OptionsColumn.AllowEdit = false;

        }
        void UnLockHopDong()
        {
            grdv_ThongTinHopDong.Columns["Check"].OptionsColumn.AllowEdit = true;
        }

        public NhapXuat_HopDongList NhapXuat_HopDongList
        {
            get { return _nhapXuat_HopDongList; }
        }//

        public bool TrangThai
        {
            get { return _trangThai; }
        }//
        public long MaDoiTac
        {
            get { return _maDoiTac; }
        }//
        public string SoHopDong
        {
            get { return _soHopDong; }
        }//
        public frmChonHopDongLapPhieu()
        {
            InitializeComponent();
        }//

        public frmChonHopDongLapPhieu(long MaDoiTac,bool LockHopDong)
        {
            InitializeComponent();
            _maDoiTac = MaDoiTac;
            _lockHopDong = LockHopDong;
            _HopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(1, _maDoiTac, 0);
            HopDongMuaBanList_BindingSource.DataSource = _HopDongMuaBanList;
        }//

        public frmChonHopDongLapPhieu(PhieuNhapXuat phieuNhapXuat,bool LockHopDong)
        {
            InitializeComponent();
            _phieuNhapXuat = phieuNhapXuat;
            _nhapXuat_HopDongList = phieuNhapXuat.NhapXuat_HopDongList;
            _lockHopDong = LockHopDong;
            _HopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(_phieuNhapXuat.MaPhieuNhapXuat);
            foreach (HopDongMuaBan hopDongMuaBan in _HopDongMuaBanList)
            {
                hopDongMuaBan.Check = true;
            }

            HopDongMuaBanList_BindingSource.DataSource = _HopDongMuaBanList;
        }//

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _trangThai = false;
            this.Close();
        }//

        private void btn_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHopDongDichVu _frmHopDongDichVu = new frmHopDongDichVu(_maDoiTac, DateTime.Today, 1);
            _frmHopDongDichVu.ShowDialog();

            _HopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(1, _maDoiTac, 0);
            HopDongMuaBanList_BindingSource.DataSource = _HopDongMuaBanList;
        }//

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit_Focus.Focus();
            int sodongchon = 0;
            foreach (HopDongMuaBan hopDongMuaBan in _HopDongMuaBanList)
            {
                if (hopDongMuaBan.Check == true)
                {
                    sodongchon += 1;
                }
            }
            if (sodongchon > 1)
            {
                MessageBox.Show(this, "Mỗi phiếu chỉ chọn 1 hợp đồng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _trangThai = true;
                if (_phieuNhapXuat == null)
                {
                    foreach (HopDongMuaBan hopDongMuaBan in _HopDongMuaBanList)
                    {
                        if (hopDongMuaBan.Check == true)
                        {
                            _nhapXuat_HopDongList.Add(NhapXuat_HopDong.NewNhapXuat_HopDong(hopDongMuaBan.MaHopDong));
                            _maDoiTac = hopDongMuaBan.MaDoiTac;
                            if (_soHopDong.Length == 0)

                                _soHopDong = hopDongMuaBan.SoHopDong;
                            else
                                _soHopDong += ", " + hopDongMuaBan.SoHopDong;
                        }
                    }
                }
                else
                {
                    foreach (HopDongMuaBan hopDongMuaBan in _HopDongMuaBanList)
                    {
                        if (hopDongMuaBan.Check == false)
                        {
                            foreach (NhapXuat_HopDong nhapXuat_HopDong in _nhapXuat_HopDongList)
                            {
                                if (hopDongMuaBan.MaHopDong == nhapXuat_HopDong.MaHopDong)
                                {
                                    _nhapXuat_HopDongList.Remove(nhapXuat_HopDong);
                                    break;
                                }
                            }
                        }
                    }
                }
                this.Close();
            }
        }

        private void CheckEdit_Chon_EditValueChanged(object sender, EventArgs e)
        {
            //HopDongMuaBan _hdmb = (HopDongMuaBan)HopDongMuaBanList_BindingSource.Current;
            //CheckEdit ch = (CheckEdit)sender;
            //_hdmb.Check = (bool)ch.EditValue;
        }

        private void frmChonHopDongLapPhieu_Load(object sender, EventArgs e)
        {
            if(_lockHopDong)
            {
                LockHopDong();
            }
            else
            {
                UnLockHopDong();
            }
        }//
    }
}
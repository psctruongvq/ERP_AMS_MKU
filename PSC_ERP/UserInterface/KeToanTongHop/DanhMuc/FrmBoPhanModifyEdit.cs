using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using PSC_ERP_Common;
using ERP_Library.Security;
using System.Linq;

namespace PSC_ERP
{
    public partial class FrmBoPhanModifyEdit : XtraForm
    {
        #region Properties
        BoPhan _BoPhan = null;
        BoPhanList bophanlist = null;
        CongTyList _CongTyList = null;
        public string strStatus = "KHOA";
        PhanQuyenSuDungForm _phanQuyen = null;
       // int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        #endregion
        public FrmBoPhanModifyEdit()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoBoPhan();
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + "FrmBoPhanModify"));
            ReadOnlyConTrolByStatus(_phanQuyen.Them);
        }
        public FrmBoPhanModifyEdit(int mabophan)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoBoPhan(mabophan);
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(CurrentUser.Info.UserID, (this.GetType().Namespace + "." + "FrmBoPhanModify"));
            ReadOnlyConTrolByStatus(_phanQuyen.Sua);
        }
       
        #region Function

        private void KhoiTao()
        {               
            BoPhanParent_ListBindingSource.DataSource=typeof(BoPhanList);
            BoPhan_bindingSource.DataSource=typeof(BoPhan);
            _CongTyList = CongTyList.GetCongTyListChooseChild(diaChi_CongTyListChild: false,
               congTy_DienThoai_FaxListChild: false, congTy_Website_EmailListChild: false, congTy_NganHangListChild: false);
            CongTyList_BindingSource.DataSource = _CongTyList;
            bophanlist = BoPhanList.GetBoPhanAll_ByMaCongTy();
            BoPhanParent_ListBindingSource.DataSource = bophanlist;
            HeThongTaiKhoan1List heThongTaiKhoan1List = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            HeThongTaiKhoan1 heThongTaiKhoanEmpt = HeThongTaiKhoan1.NewHeThongTaiKhoan1("<<Không chọn>>");
            heThongTaiKhoanEmpt.TenTaiKhoan = "Không có";
            heThongTaiKhoan1List.Insert(0, heThongTaiKhoanEmpt);
            tblTaiKhoanBindingSource.DataSource = heThongTaiKhoan1List;
            TaiKhoanCCDCBindingSource.DataSource = heThongTaiKhoan1List;
            BoPhan_bindingSource.DataSource = _BoPhan;
        }

        private void KhoiTaoBoPhan()
        {
            _BoPhan = BoPhan.NewBoPhanDocLap();
            bophanlist.Add(_BoPhan);        
            BoPhan_bindingSource.DataSource = _BoPhan;
            MaQL_textEdit.Focus();
        }
        private void KhoiTaoBoPhan(int  mabophan)
        {
            _BoPhan = bophanlist.Where(o => o.MaBoPhan == mabophan).SingleOrDefault();
            BoPhan_bindingSource.DataSource = _BoPhan;
        }
       
        private void ReadOnlyConTrolByStatus(bool _phanQuyen)
        {
            if (!_phanQuyen)
            {
                foreach (Control c in panelControl1.Controls)
                {
                    if (c is TreeListLookUpEdit)
                    {
                        ((TreeListLookUpEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is GridLookUpEdit)
                    {
                        ((GridLookUpEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is TextEdit)
                    {
                        ((TextEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is CheckBox)
                    {
                        ((CheckBox)c).Enabled = true;
                    }
                }
                btnLuuvaThemMoi.Enabled = _phanQuyen;
                btnLuu.Enabled = _phanQuyen;
            }
            else
            {
                foreach (Control c in panelControl1.Controls)
                {
                    if (c is TreeListLookUpEdit)
                    {
                        ((TreeListLookUpEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is GridLookUpEdit)
                    {
                        ((GridLookUpEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is TextEdit)
                    {
                        ((TextEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is CheckBox)
                    {
                        ((CheckBox)c).Enabled = false;
                    }
                }
                btnLuuvaThemMoi.Enabled = _phanQuyen;
                btnLuu.Enabled = _phanQuyen;
            }
            
        }
        
        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                if (bophanlist.IsDirty)
                    bophanlist.Save();
            }
            catch (Exception ex)
            {
                kq = false;
                DialogUtil.ShowError("Lưu không thành công!\n" + ex.Message + "\n" + ex.InnerException);
            }
            return kq;
        }

        #endregion

        #region Event

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LuuDuLieu())
            {
                MessageBox.Show(this, "Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnLuuvaThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LuuDuLieu())
            {
                KhoiTaoBoPhan();
            }
            else
            {
                MessageBox.Show(this, "Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Validate MaBoPhanQL
        private void DuplicatedValueWarning(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var text = sender as TextEdit;
            try
            {
                XtraMessageBox.Show(String.Format($"Dữ Liệu <color=red>\"{text.EditValue.ToString()}\"</color> đã tồn tại !"), "Thông Báo ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
                e.Cancel = true;
                text.ErrorIconAlignment = ErrorIconAlignment.TopLeft;
                text.ErrorText = "Dữ liệu trùng lặp !";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private Boolean IsDuplicatedMaBoPhanQL(object someValue)
        {
            var linq = (bophanlist.Where(o => o.MaBoPhanQL == someValue.ToString())).Count();
            return linq > 1;
        }


        private void MaQL_textEdit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsDuplicatedMaBoPhanQL(MaQL_textEdit.EditValue))
            {
                DuplicatedValueWarning(sender, e);
            }
        }
        #endregion

    }
}
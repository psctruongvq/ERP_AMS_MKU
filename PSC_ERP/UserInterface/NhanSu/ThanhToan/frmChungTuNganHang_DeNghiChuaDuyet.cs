using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.UserInterface.NhanSu.ThanhToan
{
    public partial class frmChungTuNganHang_DeNghiChuaDuyet : Form
    {
        internal ERP_Library.ChungTuNganHang _chungtu;
        private bool _loai;

        public frmChungTuNganHang_DeNghiChuaDuyet()
        {
            InitializeComponent();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            //thêm những row chọn vào data chứng từ
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in grdData.Rows)
                if ((bool)item.Cells["Chon"].Value)
                {
                    ERP_Library.ChungTuNganHang_DeNghi i = (ERP_Library.ChungTuNganHang_DeNghi)item.ListObject;
                    ERP_Library.ChungTuNganHang_DeNghi a = new ERP_Library.ChungTuNganHang_DeNghi(_chungtu.MaChungTu, i.MaDeNghi);
                    a.MaBoPhanQL = i.MaBoPhanQL;
                    a.TenBoPhan = i.TenBoPhan;
                    a.SoTien = i.SoTien;
                    a.TinhTrang = i.TinhTrang;
                    a.LyDo = i.LyDo;
                    _chungtu.DeNghi.Add(a);
                }
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
        }
        public frmChungTuNganHang_DeNghiChuaDuyet(bool Loai)
        {
            InitializeComponent();
            _loai = Loai;
            if (_loai == false)
            {
                this.Text = "Đề nghị chuyển khoản Nhân Viên chưa duyệt";
            }
            else
            {
                this.Text = "Đề nghị chuyển khoản Công Tác Viên chưa duyệt"; 
            }
        }

        private void frmChungTuNganHang_DeNghiChuaDuyet_Load(object sender, EventArgs e)
        {
            bdData.DataSource = ERP_Library.ChungTuNganHang_DeNghiList.GetDeNghiChuaDuyet(ERP_Library.CongTy_NganHang.GetCongTy_NganHang(_chungtu.MaNganHang).MaNganHang,false);
            //filter những record đã add vào nhưng chưa lưu
            grdData.DisplayLayout.Bands[0].ColumnFilters["MaDeNghi"].ClearFilterConditions();
            foreach (ERP_Library.ChungTuNganHang_DeNghi item in _chungtu.DeNghi)
            {
                if (item.IsNew)
                {
                    grdData.DisplayLayout.Bands[0].ColumnFilters["MaDeNghi"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.MaDeNghi);
                }
            }
            foreach (ERP_Library.DatabaseNumberChild item in ERP_Library.DatabaseNumberList.GetDatabaseNumberList())
            {
                grdData.DisplayLayout.ValueLists["DatabaseNumber"].ValueListItems.Add(item.DatabaseNumber, item.Ten);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in grdData.Rows)
            {
                if (!item.IsFilteredOut)
                {
                    item.Cells["Chon"].Value = true;
                    item.Update();
                }
            }
        }

        private void frmChungTuNganHang_DeNghiChuaDuyet_Load_1(object sender, EventArgs e)
        {
            bdData.DataSource = ERP_Library.ChungTuNganHang_DeNghiList.GetDeNghiChuaDuyet(ERP_Library.CongTy_NganHang.GetCongTy_NganHang(_chungtu.MaNganHang).MaNganHang, _loai);
            //filter những record đã add vào nhưng chưa lưu
            grdData.DisplayLayout.Bands[0].ColumnFilters["MaDeNghi"].ClearFilterConditions();
            foreach (ERP_Library.ChungTuNganHang_DeNghi item in _chungtu.DeNghi)
            {
                if (item.IsNew)
                {
                    grdData.DisplayLayout.Bands[0].ColumnFilters["MaDeNghi"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.MaDeNghi);
                }
            }
            foreach (ERP_Library.DatabaseNumberChild item in ERP_Library.DatabaseNumberList.GetDatabaseNumberList())
            {
                grdData.DisplayLayout.ValueLists["DatabaseNumber"].ValueListItems.Add(item.DatabaseNumber, item.Ten);
            }
        }
    }
}
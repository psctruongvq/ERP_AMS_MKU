using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmKetChuyenCCDCTheoNam : DevExpress.XtraEditors.XtraForm
    {
        int _nam = 0;


        BoPhanList _boPhanList = null;
        //Load Form
        private void _loadForm()
        {
            //KyListbindingSource.DataSource = KyList.GetKyList();
            _boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            boPhanListBindingSource.DataSource = _boPhanList;
            Utils.GridUtils.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.gridView_BoPhan, this.colChon);
            Utils.GridUtils.SetSTTForGridView(this.gridView_BoPhan, 35);
        }
        public frmKetChuyenCCDCTheoNam()
        {
            InitializeComponent();
            //KyListbindingSource.DataSource = typeof(KyList);
            numNam.Value = DateTime.Today.Year;
            boPhanListBindingSource.DataSource = typeof(BoPhanList);
        }

        private void FrmKetChuyenKhoTheoKy_Load(object sender, EventArgs e)
        {
            _loadForm();
        }

        private void btn_KetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ////kiem tra ky 1 nam sau co ton tai ko
            if (false == KiemTraTonTaiKy1CuaNam(_nam + 1))
            {

                MessageBox.Show("Kỳ đầu tiên của năm " + (_nam + 1).ToString() + " không tồn tại, vui lòng thêm vào trước khi chạy kết chuyển");
                return;
            }

            /////////////
            this.txtBlackHole.Focus();
            this.txtLog.Text = String.Empty;

            /////

            if (this.numNam.EditValue == null)
            {
                MessageBox.Show("Cần chọn năm kết chuyển!", "Yêu Cầu");
                this.numNam.Focus();

            }
            else
            {
                Boolean coChonBoPhan = false;
                foreach (BoPhan item in _boPhanList)
                {
                    if (item.Chon == true)
                    {
                        coChonBoPhan = true;
                        break;
                    }
                }
                if (coChonBoPhan == false)
                {
                    MessageBox.Show("Chọn phòng ban cần kết chuyển!", "Yêu Cầu");
                    this.gridBoPhan.Focus();//gridLookUpEdit_BoPhanKetChuyen.Focus();
                }
                else
                {

                    foreach (BoPhan pb in _boPhanList)
                    {
                        if (pb.Chon == true)
                        {
                            long maBoPhan = pb.MaBoPhan;//(int)gridLookUpEdit_BoPhanKetChuyen.EditValue;
                            try
                            {
                                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                                {
                                    bool duocPhepKetChuyen = false;//Ky Nay da Ket chuyen
                                    cn.Open();
                                    using (SqlCommand cm = cn.CreateCommand())
                                    {
                                        cm.CommandType = CommandType.StoredProcedure;
                                        cm.CommandText = "Spd_KiemTraKetChuyenCCDCTheoNam";
                                        cm.Parameters.AddWithValue("@Nam", _nam);
                                        cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                                        SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 2);
                                        prmGiaTriTraVe.Direction = ParameterDirection.Output;
                                        cm.Parameters.Add(prmGiaTriTraVe);
                                        cm.ExecuteNonQuery();
                                        duocPhepKetChuyen = (bool)prmGiaTriTraVe.Value;
                                    }
                                    if (duocPhepKetChuyen)//duoc phep ket chuyen
                                    {
                                        using (SqlCommand cm1 = cn.CreateCommand())
                                        {
                                            cm1.CommandType = CommandType.StoredProcedure;
                                            cm1.CommandText = "Spd_KetChuyenCCDCTheoNam";
                                            cm1.Parameters.AddWithValue("@Nam", _nam);
                                            cm1.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                                            cm1.ExecuteNonQuery();
                                        }
                                        this.txtLog.Text += String.Format(Environment.NewLine + "*Kết chuyển [{0}] từ năm [{1}] sang năm tiếp theo thành công", pb.TenBoPhan, _nam.ToString());//MessageBox.Show("Kết Chuyển Thành Công!", "Thông Báo");
                                    }
                                    else
                                    {
                                        this.txtLog.Text += String.Format(Environment.NewLine + "*Không thực hiện kết chuyển [{0}] từ năm [{1}] sang năm tiếp theo do đã tồn tại kết chuyển trước đó, nếu muốn kết chuyển lại phải hủy kết chuyển cũ", pb.TenBoPhan, _nam.ToString());//MessageBox.Show("Kho đã Kết Chuyển trong kỳ này! Nếu muốn Kết Chuyển lại thì hãy hủy Kết Chuyển cũ", "Thông Báo");
                                    }

                                }
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                    }


                }//END Else
            }
        }

        private bool KiemTraTonTaiKy1CuaNam(int nam)
        {
            bool tonTaiKyCua1NamSau = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CheckKy1CuaNam";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    SqlParameter outPara = new SqlParameter("@TonTai", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    tonTaiKyCua1NamSau = (bool)outPara.Value;
                }
            }//end using
            return tonTaiKyCua1NamSau;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_HuyKetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (numNam.EditValue == null)
            {
                MessageBox.Show("Nhập vào năm Cần Hủy Kết Chuyển!", "Yêu Cầu");
                numNam.Focus();

            }
            else
            {
                Boolean coChonBoPhan = false;
                foreach (BoPhan item in _boPhanList)
                {
                    if (item.Chon == true)
                    {
                        coChonBoPhan = true;
                        break;
                    }
                }
                if (coChonBoPhan == false)
                {
                    MessageBox.Show("Chọn Phòng Ban Cần Hủy Kết Chuyển!", "Yêu Cầu");
                    this.gridBoPhan.Focus();
                }
                else
                {
                    DialogResult kq = MessageBox.Show("Bạn chắc hủy kết chuyển cũ?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (kq == DialogResult.Yes)
                    {

                        foreach (BoPhan pb in _boPhanList)
                        {
                            if (pb.Chon == true)
                            {
                                long maBoPhan = pb.MaBoPhan;
                                try
                                {
                                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                                    {
                                        cn.Open();
                                        using (SqlCommand cm = cn.CreateCommand())
                                        {
                                            cm.CommandType = CommandType.StoredProcedure;
                                            cm.CommandText = "Spd_HuyKetChuyenCCDCTheoNam";
                                            cm.Parameters.AddWithValue("@Nam", _nam);
                                            cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                                            cm.ExecuteNonQuery();

                                        }

                                    }//us
                                    this.txtLog.Text += String.Format(Environment.NewLine + "*Đã hủy kết chuyển [{0}] từ năm trước sang năm [{1}] thành công", pb.TenBoPhan, _nam.ToString());//MessageBox.Show("Đã Hủy Kết Chuyển Cũ Thành Công!", "Thông Báo");
                                }
                                catch
                                {
                                    this.txtLog.Text += String.Format(Environment.NewLine + "*Không hủy được kết chuyển [{0}] từ năm trước sang năm [{1}]", pb.TenBoPhan, _nam.ToString());//MessageBox.Show("Hủy Kết Chuyển Cũ Không Thành Công!", "Thông Báo");
                                }
                            }
                        }
                    }

                }
            }
        }



        private void numNam_EditValueChanged(object sender, EventArgs e)
        {
            _nam = (int)numNam.Value;
        }



    }
}
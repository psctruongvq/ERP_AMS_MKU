
using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class DuLieuTho
    {
        #region properties
        private string _duongDan = string.Empty;
        private string _dinhDang = string.Empty;
        private List<LanQuetThe> _lanQuetTheList = new List<LanQuetThe>();
        private bool isDirty = false;

        public string DuongDan
        {
            get
            {
                return _duongDan;
            }
            set
            {
                if (_duongDan != value)
                    _duongDan = value;
            }
        }

        public string DinhDang
        {
            get
            {
                return _dinhDang;
            }
            set
            {
                if (_dinhDang != value)
                    _dinhDang = value;
            }
        }

        //public List<LanQuetThe> LanQuetTheList
        //{
        //    get
        //    {
        //        return _lanQuetTheList;
        //    }
        //}
        #endregion

        #region khoi tao
        public DuLieuTho(string duongDan, string dinhDang)
        {
            _duongDan = duongDan;
            _dinhDang = dinhDang;
            Fetch();
            isDirty = true;
        }
        #endregion

        #region phuong thuc
        public void Fetch()
        {
            _lanQuetTheList.Clear();

            try
            {
                StreamReader srd = new StreamReader(_duongDan);
                string motDong = srd.ReadLine();

                while (motDong != null)
                {
                    _lanQuetTheList.Add(new LanQuetThe(motDong, _dinhDang));
                    motDong = srd.ReadLine();
                }

                srd.Close();
            }
            catch (Exception err)
            {
                
                throw err;
            }
        }

        public void Save()
        {
            if (isDirty)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        foreach (LanQuetThe lanQuetThe in _lanQuetTheList)
                            lanQuetThe.Save(tr);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using SqlConnection

                isDirty = false;
            }
        }
        #endregion
    }

    internal class LanQuetThe
    {
        #region properties
        private bool isDirty = true;
        private string _maNhanVien;
        private SmartDate _ngayQuetThe = new SmartDate(false);
        private string _gioQuetThe = string.Empty;

        public string MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            //set
            //{
            //    if (!_maNhanVien.Equals(value))
            //        _maNhanVien = value;
            //}
        }

        /// <summary>
        /// chi doc
        /// </summary>
        public DateTime NgayQuetThe
        {
            get
            {
                return _ngayQuetThe.Date;
            }
        }

        public string NgayQuetTheString
        {
            get
            {
                //CanReadProperty("NgayGioQuetString", true);
                return _ngayQuetThe.Text;
            }
            //set
            //{
            //    //CanWriteProperty("NgayGioQuetString", true);
            //    if (value == null) value = string.Empty;
            //    if (!_ngayQuetThe.Equals(value))
            //    {
            //        _ngayQuetThe.Text = value;
            //        //PropertyHasChanged("NgayGioQuetString");
            //    }
            //}
        }
        #endregion

        #region khoi tao
        internal LanQuetThe(string motDong, string dinhDang)
        {
            //_ngayQuetThe.FormatString = "dd/MM/yyyy";
            Fetch(motDong, dinhDang);
        }
        #endregion

        #region phuong thuc
        private void Fetch(string motDong, string dinhDang)
        {
            #region dinh dang
            List<int> dsViTriCot = new List<int>();
            dsViTriCot.Add(0);
            for (int k = 0; k < motDong.Length; k++)
                if (motDong[k] == '\t')
                    dsViTriCot.Add(k + 1);

            int vtNgay = 0;
            int vtGio = 0;
            int vtCardId = 0;
            string ddNgay = string.Empty;
            string ddGio = string.Empty;
            string ddCardId = string.Empty;
            int i = 0;
            int j = 0;

            for (int k = 0; k < 6; k++)
            {
                j = dinhDang.IndexOf('@', i);
                switch (k)
                {
                    case 0:
                        vtNgay = int.Parse(dinhDang.Substring(i, j - i)) - 1;
                        break;
                    case 1:
                        vtGio = int.Parse(dinhDang.Substring(i, j - i)) - 1;
                        break;
                    case 2:
                        vtCardId = int.Parse(dinhDang.Substring(i, j - i)) - 1;
                        break;
                    case 3:
                        ddNgay = dinhDang.Substring(i, j - i);
                        break;
                    case 4:
                        ddGio = dinhDang.Substring(i, j - i);
                        break;
                    case 5:
                        ddCardId = dinhDang.Substring(i, j - i);
                        break;
                    default:
                        break;
                }
                i = j + 1;
            }

            //_ngayQuetThe.FormatString = ddNgay + " " + ddGio;
            #endregion
            try
            {
                string ngayGio = string.Empty;
                string maNhanVien = string.Empty;

                ngayGio = motDong.Substring(dsViTriCot[vtNgay], dsViTriCot[vtNgay + 1] - dsViTriCot[vtNgay] - 1);
                ngayGio += " ";
                ngayGio += motDong.Substring(dsViTriCot[vtGio], dsViTriCot[vtGio + 1] - dsViTriCot[vtGio] - 1);
                _gioQuetThe = motDong.Substring(dsViTriCot[vtGio], dsViTriCot[vtGio + 1] - dsViTriCot[vtGio] - 1);
                maNhanVien = motDong.Substring(dsViTriCot[vtCardId], dsViTriCot[vtCardId + 1] - dsViTriCot[vtCardId] - 1).Remove(0, ddCardId.Length);

                _maNhanVien = maNhanVien;
                //Them Gio vao lam gi
                DateTime date = new DateTime();
                date = DateTime.ParseExact(ngayGio, ddNgay + " " + ddGio, null);
                _ngayQuetThe.Text = date.ToString();

                //_ngayQuetThe.Text = (Convert.ToDateTime(ngayGio)).ToShortDateString();//trang them vao

                isDirty = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        internal void Save(SqlTransaction tr)
        {
            if (isDirty)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblDuLieuTho";

                    cm.Parameters.AddWithValue("@MaQLNhanVien", _maNhanVien);
                    cm.Parameters.AddWithValue("@NgayGioQuet", Convert.ToDateTime(_ngayQuetThe.DBValue).ToShortDateString());
                    cm.Parameters.AddWithValue("@GioQuetThe", _gioQuetThe);

                    cm.ExecuteNonQuery();
                }//using

                isDirty = false;
            }
        }
        #endregion
    }
}


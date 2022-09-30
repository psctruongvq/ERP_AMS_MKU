using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ERP_Library;

namespace ERP_Library
{
    public class DangNhap
    {
        public static int _Permit;
        public static long _MaNguoiSuDung;

        public static ArrayList arrRoleID;
        public static int _maBoPhan;
        public static string _TenBoPhan;
        
        public byte checkLogin(string UserName, string Password)
        {



            /*
            SqlConnection con = new SqlConnection(Database.ERP_Connection);
            SqlCommand cmd = new SqlCommand("spd_Login", con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100);
            sqlParam.Value = UserName;

            sqlParam = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 200);
            sqlParam.Value = Password;

            SqlParameter RolesID = new SqlParameter("@RolesID", SqlDbType.Int);
            RolesID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(RolesID);

            SqlParameter pCheckLogin = new SqlParameter("@CheckLogin", SqlDbType.Int);
            pCheckLogin.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pCheckLogin);


            SqlParameter pmaNguoiSuDung = new SqlParameter("@MaNguoiSuDung", SqlDbType.BigInt, 8);
            pmaNguoiSuDung.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pmaNguoiSuDung);
             * try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (pmaNguoiSuDung.SqlValue.ToString() != "Null")
                    {
                        //_MaNguoiSuDung = (long)cm.Parameters["@MaNguoiSuDung"].Value;
                        _MaNguoiSuDung = Convert.ToInt64(pmaNguoiSuDung.SqlValue.ToString());
                    }                   
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Exception adding login Account. " + ex.Message);
                //				return 2;// không thể kết nối
            }
            finally
            {
                con.Close();
            }
            int checkLogin = int.Parse(pCheckLogin.Value.ToString());
            if (checkLogin == 3)// có user này và đúng password
            {
                _Permit = int.Parse(RolesID.Value.ToString());
                //  Resource.isLoggedIn = true;
            }
            // Không có user này checkLogin = 0   ,// Không có pass này checkLogin = 1         
            return (byte)checkLogin;

*/
            SqlConnection con = new SqlConnection(Database.ERP_Connection);
            SqlCommand cmd = new SqlCommand("HL_Login", con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
            sqlParam.Value = UserName;

            sqlParam = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
            sqlParam.Value = Password;

            // SqlParameter RolesID = new SqlParameter("@RolesID", SqlDbType.Int);
            //RolesID.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(RolesID);

            SqlParameter pCheckLogin = new SqlParameter("@CheckLogin", SqlDbType.Int);
            pCheckLogin.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pCheckLogin);


            SqlParameter pAccountID = new SqlParameter("@AccountID", SqlDbType.Int);
            pAccountID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pAccountID);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (pAccountID.SqlValue.ToString() != "Null")
                    {
                        //_MaNguoiSuDung = (long)cm.Parameters["@MaNguoiSuDung"].Value;
                        _MaNguoiSuDung = Convert.ToInt32(pAccountID.SqlValue.ToString());
                        ERP_Library.BoPhan bp = BoPhan.GetBoPhan_NhanVien(_MaNguoiSuDung);
                        _maBoPhan = bp.MaBoPhan;
                        _TenBoPhan = bp.TenBoPhan;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Exception adding login Account. " + ex.Message);
                //				return 2;// không thể kết nối
            }
            finally
            {
                con.Close();
            }
            int checkLogin = int.Parse(pCheckLogin.Value.ToString());
            if (checkLogin == 3)// có user này và đúng password
            {
                // _Permit = int.Parse(RolesID.Value.ToString());
                //  Resource.isLoggedIn = true;
                GetRoleID(UserName);
            }
            // Không có user này checkLogin = 0   ,// Không có pass này checkLogin = 1         
            return (byte)checkLogin;

        }
        public ArrayList GetRoleID(string Username)
        {
            //int[] aRole;
            arrRoleID = new ArrayList();
            SqlConnection con = new SqlConnection(Database.ERP_Connection);
            SqlCommand cmd = new SqlCommand("HL_GetRoleID", con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
            sqlParam.Value = Username;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    arrRoleID.Add(Convert.ToInt32(reader["RolesID"]));
                }
            }
            return arrRoleID;
        }
        public int GetPhanHe(long _MaNguoiSuDung)
        {
            int phanHe = 0;
            SqlConnection con = new SqlConnection(Database.ERP_Connection);
            SqlCommand cmd = new SqlCommand("spd_TimPhanHe", con);
            cmd.CommandType = CommandType.StoredProcedure;  

            SqlParameter sqlParam = null;

            sqlParam = cmd.Parameters.Add("@MaNhanVien", SqlDbType.Int,4);
            sqlParam.Value = _MaNguoiSuDung;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                phanHe = (int)cmd.ExecuteScalar();
            }

            return phanHe;
        }
    }
}

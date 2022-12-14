using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace ERP_Library.Security
{
    public static class CurrentUser
    {
         public static ArrayList arrRoleID;
        private static bool _isLogIn = false;
        private static UserInfo _user; //các cài đặt dữ liệu khác của user nên đưa vào class UserInfo

        /// <summary>
        /// Kiểm tra user đã được đăng nhập chưa
        /// </summary>
        public static bool IsLogIn
        {
            get
            {
                return _isLogIn;
            }
        }

        /// <summary>
        /// Các thông tin hoặc config khác của user
        /// </summary>
        public static UserInfo Info
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
               
            }
        }

        /// <summary>
        /// Login vào hệ thống, sau khi gọi LogIn cần gọi loadmenu để cập nhật lại menu chức năng phân quyền
        /// </summary>
        /// <param name="username">Tên đăng nhập của user</param>
        /// <param name="pass">Mật khẩu của user</param>
        /// <returns>True nếu login thành công, ngược lại False</returns>
        public static bool LogIn(string username, string pass)
        {
            string pass_mahoa = EncryptUtil.EncryptString(pass, "System.Windows.Forms.MessageBox");
            string pass_Decrypt = EncryptUtil.DecryptString(pass, "System.Windows.Forms.MessageBox");
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "Select IsNull(UserID,0) From app_users Where TenDangNhap=@TenDangNhap AND MatKhau=@MatKhau";
                cm.Parameters.AddWithValue("@TenDangNhap", username);
                cm.Parameters.AddWithValue("@MatKhau", pass_mahoa);
                int userid = Convert.ToInt32(cm.ExecuteScalar());
                cn.Close();
                if (userid == 0)
                    return false;
                else
                {
                    //cài đặt sau khi login thành công
                    _user = UserInfo.GetUserInfo(userid);
                    CurrentUser.Info = UserInfo.GetUserInfo(userid);
                    _isLogIn = true;
                    //Be Load TaiKhoanThue
                    TaiKhoanThue.LoadTaiKhoanThueList(_user.MaCongTy);
                    //End Load TaiKhoanThue
                    // 04/11/2020 ghi nhận datetime đăng nhập gần nhất 
                    int test =LoginDateUsers(userid);
                    return true;
                }
            }
        }
        //04/11/2020 ghi nhận datetime đăng nhập gần nhất 
        public static int LoginDateUsers(int UserID)
        {
            int count = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoginDateUsers";
                    cm.Parameters.AddWithValue("@UserID", UserID);
                    count = Convert.ToInt32(cm.ExecuteNonQuery());
                }
            }
            return count;
        }

        /// <summary>
        /// Tạo menu các chức năng tùy theo phân quyền của user, mỗi menu tạo ra có property Tag là số ID của chức năng
        /// </summary>
        /// <param name="ParentID">ID của menu chính trong trường hợp nhiều phân hệ, hoặc = 0 nếu cần load tất cả menu</param>
        /// <param name="menu">Object menu của form</param>
        public static void LoadMenu(int ParentID, System.Windows.Forms.MenuStrip menu, System.EventHandler MenuClick)
        {
            menu.SuspendLayout();
            menu.Items.Clear();
            MenuList lst = MenuList.GetMenuUser(_user.UserID);
            MenuItem root = null;
            if (ParentID != 0)
                root = MenuItem.GetMenuItemByMaChucNang(ParentID);
            foreach (MenuItem item in lst)
                if (root == null || item.ParentID == root.MenuID)
                {
                    if (item.TenChucNang == "-")
                    {
                        menu.Items.Add(new System.Windows.Forms.ToolStripSeparator());
                    }
                    else
                    {
                        System.Windows.Forms.ToolStripMenuItem mn = new System.Windows.Forms.ToolStripMenuItem(item.TenChucNang);
                        if (item.HinhAnh != null)
                        {
                            System.IO.MemoryStream m = new System.IO.MemoryStream();
                            m.Write(item.HinhAnh, 0, item.HinhAnh.Length);
                            System.Drawing.Image img = System.Drawing.Image.FromStream(m);
                            m.Close();
                            mn.Image = img;
                        }
                        mn.Tag = item;
                        AddChildMenu(lst, item.MenuID, mn, MenuClick);
                        if (item.TenForm != "")
                            mn.Click += MenuClick;
                        menu.Items.Add(mn);
                    }
                }
            menu.ResumeLayout(true);
        }

        private static void AddChildMenu(MenuList lst, int ParentID, System.Windows.Forms.ToolStripMenuItem menu, System.EventHandler MenuClick)
        {
            foreach (MenuItem item in lst)
                if (item.ParentID == ParentID)
                {
                    if (item.TenChucNang == "-")
                    {
                        menu.DropDownItems.Add(new System.Windows.Forms.ToolStripSeparator());
                    }
                    else
                    {
                        System.Windows.Forms.ToolStripMenuItem mn = new System.Windows.Forms.ToolStripMenuItem(item.TenChucNang);
                        if (item.HinhAnh != null)
                        {
                            System.IO.MemoryStream m = new System.IO.MemoryStream();
                            m.Write(item.HinhAnh, 0, item.HinhAnh.Length);
                            System.Drawing.Image img = System.Drawing.Image.FromStream(m);
                            m.Close();
                            mn.Image = img;
                        }
                        mn.Tag = item;
                        AddChildMenu(lst, item.MenuID, mn, MenuClick);
                        if (item.TenForm != "")
                            mn.Click += MenuClick;
                        menu.DropDownItems.Add(mn);
                    }
                }
        }

        /// <summary>
        /// Kiểm tra user hiện tại có được phân quyền mở 1 chức năng không
        /// </summary>
        /// <param name="MaChucNang">ID của menu cần kiểm tra</param>
        /// <returns>True nếu hợp lệ, ngược lại False</returns>
        public static bool CanOpen(int MaChucNang)
        {
            if (!_isLogIn) return false;
            if (IsAdmin) return true;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "Select C.MaChucNang From app_rights A Inner Join app_users B On A.GroupID = B.GroupID Inner Join app_menus C On A.MenuID = C.MenuID Where C.MaChucNang = @MaChucNang AND B.UserID = @UserID";
                cm.Parameters.AddWithValue("@UserID", _user.UserID);
                cm.Parameters.AddWithValue("@MaChucNang", MaChucNang);
                object v = cm.ExecuteScalar();
                cn.Close();
                return v is Int32;
            }
        }

        /// <summary>
        /// Kiểm tra user hiện tại thuộc nhóm quyền Admin
        /// </summary>
        public static bool IsAdmin
        {
            get
            {
                if (_user != null)
                    return _user.TenGroup.ToLower() == "admin";
                else
                    return false;
            }
        }

        /// <summary>
        /// Kiểm tra user hiện tại thuộc nhóm quyền admin của phân hệ nhân sự
        /// </summary>
        public static bool IsAdminNhanSu
        {
            get
            {
                if (_user != null)
                    return _user.TenGroup.ToLower().Contains("admin nhân sự") || IsAdmin;
                else
                    return false;
            }
        }
        /// <summary>
        /// Kiểm tra user hiện tại thuộc nhóm quyền admin Thu Chi
        /// </summary>
        public static bool IsAdminThuChi            
        {
            get
            {
                if (_user != null)
                    return _user.TenGroup.ToLower() == "admin thu chi";
                else
                    return false;
            }
        }

        /// <summary>
        /// Kiểm tra user hiện tại thuộc nhóm quyền admin Thu Chi
        /// </summary>
        public static bool AdminThue
        {
            get
            {
                if (_user != null)
                    return _user.TenGroup.ToLower() == "AdminThue";
                else
                    return false;
            }
        }

        public static ArrayList GetBoPhanPhanQuyenList(int UserID)
        {
            //int[] aRole;
            arrRoleID = new ArrayList();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
             
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "select MaBoPhan from app_userbophan where UserId=@UserID";
                cm.Parameters.AddWithValue("@UserID", UserID);
                SqlDataReader reader = cm.ExecuteReader();
                while (reader.Read())
                {
                    arrRoleID.Add(Convert.ToInt32(reader["MaBoPhan"]));
                }
            }
            return arrRoleID;
        }
  
    }
}

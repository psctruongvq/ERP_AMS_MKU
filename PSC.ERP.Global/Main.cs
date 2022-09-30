using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Global
{
    public class Main
    {
        //public static DateTime NgayLamViec
        //{
        //    get { return DateTime.Today; }
        //}

        //public static DateTime NgayServer
        //{
        //    get { }
        //    set { }
        //}
        public static String NormalConnectionString;
        public static int UserID
        {
            get
            {
                return UserID_;
            }
            set
            {
                UserID_ = value;
                PSC_ERP_Core.BaseObjectContext.UserID = value;
            }

        }
        private static int UserID_ = 0;

        public static int MaBoPhanCuaUser
        {
            get
            {
                return MaBoPhanCuaUser_;
            }
            set
            {
                MaBoPhanCuaUser_ = value;
                //PSC_ERP_Core.BaseObjectContext.MaBoPhanCuaUser = value;
            }

        }
        private static int MaBoPhanCuaUser_ = 0;

        public String LanIP
        {
            get
            {
                return PSC_ERP_Util.NetUtil.FindLanAddress().ToString();
            }
        }


    }
}

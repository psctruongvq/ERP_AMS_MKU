﻿using PSC_ERP_Digitizing.WebService.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Web;

namespace PSC_ERP_Digitizing.WebService
{
    public partial class Helper
    {
        #region Security
        public static bool TrustTest(string publicKey, string token)
        {
            try
            {
                String secretKey = "pscvietnam@hoasua";
                if (token != MakeToken(publicKey, secretKey))
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static string MakeToken(string publicKey, string secretKey)
        {
            return PSC_ERP_Common.EncryptUtil.MD5(publicKey ?? "" + secretKey ?? "");
        }
        #endregion






    }
}
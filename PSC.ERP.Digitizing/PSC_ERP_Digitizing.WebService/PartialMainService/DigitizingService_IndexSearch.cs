using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using PSC_ERP_Digitizing.WebService.Model;
using Similarity.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace PSC_ERP_Digitizing.WebService
{
    public partial class DigitizingService
    {


       

        [WebMethod]
        private List<IndexPackage> SearchContent(String publicKey, String token, byte[] binaryContent, string documentMiningIndexingPath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                return Helper.Digitizing_SearchContent(Helper.Digitizing_Unzip(binaryContent), documentMiningIndexingPath);
            }
            else
            {
                //Xác thực không hợp lệ.
                SoapException se = new SoapException("Xác thực không hợp lệ",
                 SoapException.ClientFaultCode,
                 Context.Request.Url.AbsoluteUri,
                 new Exception("Xác thực không hợp lệ"));
                throw se;
            }
        }

        [WebMethod]
        public List<IndexPackage> SearchContent_String(String publicKey, String token, String content, string documentMiningIndexingPath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                try
                {
                    return Helper.Digitizing_SearchContent(content, documentMiningIndexingPath);
                }
                catch (Exception ex)
                {
                    SoapException se = new SoapException("SearchContent_String error",
                     SoapException.ClientFaultCode,
                     Context.Request.Url.AbsoluteUri,
                    ex);
                    throw se;
                }
            }
            else
            {
                //Xác thực không hợp lệ.
                SoapException se = new SoapException("Xác thực không hợp lệ",
                 SoapException.ClientFaultCode,
                 Context.Request.Url.AbsoluteUri,
                 new Exception("Xác thực không hợp lệ"));
                throw se;
            }
        }

      
    }
}
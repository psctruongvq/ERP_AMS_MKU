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
using PSC_ERP_Digitizing.WebService.Util;
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
        public String Index_GetPdfContent(String publicKey, String token, string filePath, string pdfPass = null)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                string result = Helper.Digitizing_GetPdfContent(filePath, pdfPass);
                return result;
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
        public String Index_GetFileContent(String publicKey, String token, string filePath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                string result = Helper.Digitizing_GetFileContent(filePath);
                return result;
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

        //[WebMethod]
        //public void Index_WriteToIndexing(String publicKey, String token, string docId, String docFileName, byte[] contentBinary, string directoryIndexing)
        //{
        //    if (Helper.TrustTest(publicKey, token))
        //    {
        //        Helper.Digitizing_WriteToIndexing(docId, docFileName, contentBinary, directoryIndexing);
        //    }
        //    else
        //    {
        //        //Xác thực không hợp lệ.
        //        SoapException se = new SoapException("Xác thực không hợp lệ",
        //         SoapException.ClientFaultCode,
        //         Context.Request.Url.AbsoluteUri,
        //         new Exception("Xác thực không hợp lệ"));
        //        throw se;
        //    }
        //}

        [WebMethod]
        public void Index_DeleteDocIndexing_ByDocId(String publicKey, String token, string docId, string directoryIndexing)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                Helper.Digitizing_DeleteDocIndexing_ByDocId(docId, directoryIndexing);
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

        #region Helper

  

  

        //private static byte[] GetFileContent(string fileLocation, string pdfPass)
        //{
        //    return ZipString(System.IO.Path.GetExtension(fileLocation).ToLower() == ".pdf" ? getPdfContent(fileLocation, pdfPass) : getFileContent(fileLocation));
        //}    


        #endregion
















    }
}
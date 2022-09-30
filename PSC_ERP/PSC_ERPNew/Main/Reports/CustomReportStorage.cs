
using System;
using System.IO;
using System.Linq;
using System.Data;
//using WinDemo.ReportData;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Extensions;


namespace PSC_ERPNew.Main.Reports
{
    public class CustomReportStorage : ReportStorageExtension
    {

        Object[] _tag = null;
        public CustomReportStorage()
        {

            ////// load dataset on creation
            ////if (dataSet == null)
            ////{
            ////    dataSet = new DataSet();
            ////    if (File.Exists(StoragePath))
            ////        dataSet.ReadXml(StoragePath, XmlReadMode.ReadSchema);
            ////}
        }

        #region Info for Storing Report Data
        /// <summary>
        /// For storing reports. This can be changed to save each report
        /// to a database or any other storage location.
        /// </summary>
        ////const string fileName = "ReportStorage.xml";
        ////DataSet dataSet;//Storage dataSet;

        /// <summary>
        /// Path for storage xml (could be any data provider)
        /// </summary>
        ////protected string StoragePath
        ////{
        ////    get
        ////    {
        ////        string dirName = Path.GetDirectoryName(Application.ExecutablePath);
        ////        return Path.Combine(dirName, fileName);
        ////    }
        ////}

        ////protected byte[] LayoutArray(XtraReport r)
        ////{
        ////    using (MemoryStream m = new MemoryStream())
        ////    {
        ////        r.SaveLayout(m);
        ////        return m.ToArray();
        ////    }
        ////}
        #endregion

        /// <summary>
        /// Can this particular report be saved?
        /// Good for checking permissions etc.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public override bool CanSetData(string url)
        {
            // We can save everything!
            // In your app, you might
            // check the current user etc.
            return true;
        }


        /// <summary>
        /// Get the actual report based upon a url
        /// (a name for the report)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public override byte[] GetData(string url)
        {


            return null;
        }


        /// <summary>
        /// Open an existing report
        /// </summary>
        /// <returns></returns>
        public override string GetNewUrl()
        {

            return string.Empty;
        }

        /// <summary>
        /// get a list of available datasources for a report
        /// this is especially useful for subreports
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string[] GetStandardUrls(ITypeDescriptorContext context)
        {


            return null;
        }

        /// <summary>
        /// Whether or not we can specify standard urls
        /// for datasources
        /// </summary>
        /// <param name="context">Current context</param>
        /// <returns></returns>
        public override bool GetStandardUrlsSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Valid report name/location?
        /// </summary>
        /// <param name="url">name/url</param>
        /// <returns>True/False</returns>
        public override bool IsValidUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && !string.IsNullOrWhiteSpace(url);
        }

        /// <summary>
        /// Save an existing report
        /// </summary>
        /// <param name="report">report class</param>
        /// <param name="url">url/name of report</param>
        public override void SetData(XtraReport report, string url)
        {
            //////if (_tag == null)
            //////    _tag = (Object[])report.Tag;//giu lai tag o Memory

            //////if (_tag != null)
            //////{
            //////    report.Tag = null;//go bo tag truoc khi luu
            //////    NPCSimpleReportStorage.Model.Report rpt = (NPCSimpleReportStorage.Model.Report)_tag[0];
            //////    NPCSimpleReportStorage.Model.NPCSimpleReportStorageEntities db = (NPCSimpleReportStorage.Model.NPCSimpleReportStorageEntities)_tag[1];

            //////    report.SaveLayout(url);
            //////    using (MemoryStream m = new MemoryStream())
            //////    {
            //////        report.SaveLayout(m);
            //////        rpt.ReportLayoutData = m.ToArray();
            //////    }
            //////    db.SaveChanges();

            
            //////    MessageBox.Show("Đã lưu report");

            //////}

        }

        /// <summary>
        /// Save a new report
        /// </summary>
        /// <param name="xtraReport">report class</param>
        /// <param name="defaultUrl">default url/name of report</param>
        /// <returns>Report Url/Name</returns>
        public override string SetNewData(XtraReport xtraReport, string defaultUrl)
        {
            //String fileName = defaultUrl + ".repx";
            //SetData(xtraReport, fileName);
            //return fileName;//da save
            //return string.Empty;//tra ve chuoi rong thi trang thai cua report la chua save (dau * con hien tren tab)

            return "";
        }
    }
}


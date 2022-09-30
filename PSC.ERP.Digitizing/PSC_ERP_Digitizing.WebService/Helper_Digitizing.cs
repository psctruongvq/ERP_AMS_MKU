using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Digitizing.WebService.Model;
using PSC_ERP_Digitizing.WebService.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;

namespace PSC_ERP_Digitizing.WebService
{
    public partial class Helper
    {
        internal class IntegralCollector : Lucene.Net.Search.Collector
        {
            private int _docBase;

            private List<int> _docs = new List<int>();
            public List<int> Docs
            {
                get { return _docs; }
            }

            public override bool AcceptsDocsOutOfOrder
            {
                get
                {
                    return true;
                }
            }

            public override void Collect(int doc)
            {
                _docs.Add(_docBase + doc);
            }

            public override void SetNextReader(Lucene.Net.Index.IndexReader reader, int docBase)
            {
                _docBase = docBase;
            }

            public override void SetScorer(Lucene.Net.Search.Scorer scorer)
            {
            }
        }
        #region Index
        //public static void Digitizing_WriteToIndexing(string docId, String docFileName, byte[] contentBinary, string directoryIndexing)
        //{
        //    string fileContent = Helper.Digitizing_Unzip(contentBinary);
        //    Digitizing_WriteToIndexing(IndexPackage indexPackage, directoryIndexing);
        //}

        public static void Digitizing_WriteToIndexing(IndexPackage indexPackage, string directoryIndexing)
        {
            //            Enum Constant Summary
            //ANALYZED 
            //          Index the tokens produced by running the field's value through an Analyzer.
            //ANALYZED_NO_NORMS 
            //          Expert: Index the tokens produced by running the field's value through an Analyzer, and also separately disable the storing of norms.
            //NO 
            //          Do not index the field value.
            //NOT_ANALYZED 
            //          Index the field's value without using an Analyzer, so it can be searched.
            //NOT_ANALYZED_NO_NORMS 
            //          Expert: Index the field's value without an Analyzer, and also disable the storing of norms.

            //Delete if Have
            try
            {
                Digitizing_DeleteDocIndexing_ByDocId(indexPackage.DocId, directoryIndexing);
            }
            catch (Exception ex)
            {

            }


            //AddNew
            FSDirectory directory = FSDirectory.Open(directoryIndexing);
            IndexWriter indexWriter = null;
            if (new DirectoryInfo(directoryIndexing).GetFiles().Length > 1)
                indexWriter = new IndexWriter(directory, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30), false, IndexWriter.MaxFieldLength.UNLIMITED);
            else
                indexWriter = new IndexWriter(directory, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30), true, IndexWriter.MaxFieldLength.UNLIMITED);

            Lucene.Net.Documents.Document doc = new Lucene.Net.Documents.Document();
            doc.Add(new Field("DocId", indexPackage.DocId, Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("DocFileName", indexPackage.DocId, Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("Content", indexPackage.Content, Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("UpdateDate", Helper.Digitizing_GetDateStringFull(DateTime.Now), Field.Store.YES, Field.Index.NO));
            indexWriter.AddDocument(doc);
            indexWriter.Dispose();//.Close();

        }

        public static void Digitizing_DeleteDocIndexing_ByDocId(string docId, string directoryIndexing)
        {
            FSDirectory directory = FSDirectory.Open(directoryIndexing);
            Lucene.Net.Index.IndexReader reader = Lucene.Net.Index.IndexReader.Open(directory, false);
            int i = reader.DeleteDocuments(new Lucene.Net.Index.Term("DocId", docId));
            reader.Dispose();//.Close();
        }

        public static void Digitizing_DeleteDocIndexing_ByDocFileName(string docFileName, string directoryIndexing)
        {
            FSDirectory directory = FSDirectory.Open(directoryIndexing);
            Lucene.Net.Index.IndexReader reader = Lucene.Net.Index.IndexReader.Open(directory, false);
            int i = reader.DeleteDocuments(new Lucene.Net.Index.Term("DocFileName", docFileName));
            reader.Dispose();//.Close();
        }


        public static List<IndexPackage> Digitizing_SearchContent(String content, string documentMiningIndexingPath, Boolean fileContentInResult = false)
        {

            string directoryIndexing = documentMiningIndexingPath;
            string searchValue = content;

            List<IndexPackage> resultList = new List<IndexPackage>();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("DocId", typeof(string));
            //dt.Columns.Add("DocFileName", typeof(string));
            //dt.Columns.Add("Content", typeof(string));
            //dt.Columns.Add("UpdateDate", typeof(string));

            FSDirectory directory = FSDirectory.Open(directoryIndexing);
            Lucene.Net.Index.IndexReader reader = Lucene.Net.Index.IndexReader.Open(directory, true);
            Lucene.Net.Search.IndexSearcher searcher = new Lucene.Net.Search.IndexSearcher(reader);
            /*
             Lucene.Net.QueryParsers.QueryParser parser = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Content", new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));
             Lucene.Net.Search.Query query = parser.Parse(searchValue);
             var collector = new IntegralCollector();
             searcher.Search(query, collector);
             */
            var booleanQuery = new Lucene.Net.Search.BooleanQuery();
            if (searchValue != string.Empty)
            {
                var parserContent = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Content", new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));
                Lucene.Net.Search.Query queryContent = parserContent.Parse(searchValue);
                booleanQuery.Add(queryContent, Occur.MUST);
            }


            var collector = new IntegralCollector();
            searcher.Search(booleanQuery, collector);

            //var result = new Document[collector.Docs.Count];
            for (int i = 0; i < collector.Docs.Count; i++)
            {
                Document doc = searcher.Doc(collector.Docs[i]);
                //result[i] = doc;



                string id = doc.GetField("DocId").StringValue;
                if (resultList.Any(x => x.DocId == id)) continue;

                String fileContent = null;
                if (fileContentInResult) fileContent = doc.GetField("Content").StringValue;

                resultList.Add(new IndexPackage { DocId = id, DocFileName = doc.GetField("DocFileName").StringValue, Content = fileContent, UpdateDate = doc.GetField("UpdateDate").StringValue });

                //if (dt.Select("DocId='" + id + "'").Length > 0) continue;
                //dt.Rows.Add(new object[] { id, doc.GetField("DocFileName").StringValue, doc.GetField("Content").StringValue, doc.GetField("UpdateDate").StringValue });

            }
            searcher.Dispose();//.Close(); // this is probably not needed
            reader.Dispose();//.Close();

            /*
            Lucene.Net.Search.Hits hits = searcher.Search(query);
            int totalDocuments = hits.Length();
            for (int i = 0; i < hits.Length(); i++)
            {
                string id = hits.Doc(i).GetField("DocId").StringValue();
                if (dt.Select("DocId='" + id + "'").Length > 0) continue;
                dt.Rows.Add(new object[] { id
                    , hits.Doc(i).GetField("DocFileName").StringValue()
                    , hits.Doc(i).GetField("Content").StringValue()
                    , hits.Doc(i).GetField("UpdateDate").StringValue() });
            }
            reader.Close();
            */
            return resultList;
            //return dt;
        }



        #endregion



        public static bool Digitizing_AllowDistributeFile(string file)
        {
            string prefix = System.IO.Path.GetExtension(file).ToLower();
            if (prefix != ".txt" && prefix != ".doc" && prefix != ".chm" && prefix != ".pdf" && prefix != ".rtf" && prefix != ".html" && prefix != ".htm")
                return false;
            return true;
        }
        public static byte[] Digitizing_ZipString(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                    Digitizing_CopyTo(msi, gs);
                return mso.ToArray();
            }
        }
        public static string Digitizing_Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                    Digitizing_CopyTo(gs, mso);
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
        public static void Digitizing_CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];
            int cnt;
            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
        public static string Digitizing_GetDateStringFull(DateTime date)
        {
            return date.Day.ToString().PadLeft(2, '0') + "/" + date.Month.ToString().PadLeft(2, '0') + "/" + date.Year.ToString()
                + " " + date.Hour.ToString().PadLeft(2, '0') + ":" + date.Minute.ToString().PadLeft(2, '0') + ":" + date.Second.ToString().PadLeft(2, '0');
        }

        public static string Digitizing_GetPdfContent(string filePath, string pdfPass = null)
        {
            try
            {
                PdfReader pReader = (!String.IsNullOrEmpty(pdfPass) ? new PdfReader(filePath, new System.Text.ASCIIEncoding().GetBytes(pdfPass))
                        : new PdfReader(filePath));

                int pageFrom = 1;
                int pageTo = pReader.NumberOfPages;

                string pdfContent = string.Empty;

                for (int i = pageFrom; i <= pageTo; i++)
                {
                    string content = PdfTextExtractor.GetTextFromPage(pReader, i);
                    content = Helper.RemoveContentRedundantString(content);
                    pdfContent += (pdfContent == "" ? "" : " ") + content;
                }
                pReader.Close();
                return pdfContent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static string Digitizing_GetFileContent(string filePath)
        {
            if (!Helper.Digitizing_AllowDistributeFile(filePath))
                return string.Empty;

            string content = TextMiningTool.FileMaster.Process(filePath);
            content = Helper.RemoveContentRedundantString(content);
            return content.Trim();
        }
        private static string RemoveContentRedundantString(string content)
        {
            content = content.Replace("\r", " ").Replace("\n", " ");
            while (content.IndexOf("  ") > -1)
                content = content.Replace("  ", " ");
            while (content.IndexOf("..") > -1)
                content = content.Replace("..", ".");
            return content;
        }
        public static string Digitizing_GetFileContent_SmartChoice(string fileLocation, string pdfPass = null)
        {

            string fileContent = System.IO.Path.GetExtension(fileLocation).ToLower() == ".pdf" ? Helper.Digitizing_GetPdfContent(fileLocation, pdfPass) : Helper.Digitizing_GetFileContent(fileLocation);

            return fileContent;
        }
        public static void Digitizing_UploadFileLargeSize(string destFilePath, byte[] buffer, long offset)
        {

            try
            {
                if (offset == 0) // new file, create an empty file
                    File.Create(destFilePath).Close();
                // open a file stream and write the buffer. 
                // Don't open with FileMode.Append because the transfer may wish to 
                // start a different point
                using (FileStream fs = new FileStream(destFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    fs.Seek(offset, SeekOrigin.Begin);
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Digitizing_UpdateDigitizingBag_Indexed(Guid digitizingBagId, Boolean indexed)
        {
            DigitizingBag_Factory factory = DigitizingBag_Factory.New();
            var obj = factory.GetById(digitizingBagId);
            if (obj != null)
            {
                obj.FileIndexed = indexed;
                try
                {
                    factory.SaveChangesWithoutTrackingLog();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new Exception("Not found " + digitizingBagId.ToString());

        }
        /*
        public static Query ParseQuery(string searchQuery, QueryParser parser)
        {
            Query query;
            try
            {
                query = parser.Parse(searchQuery.Trim());
            }
            catch (Lucene.Net.QueryParsers.ParseException)
            {
                query = parser.Parse(QueryParser.Escape(searchQuery.Trim()));
            }
            return query;
        }
         * */



    }
}
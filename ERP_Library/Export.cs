namespace ERP_Library
{
    using System;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Xsl;

    public class Export
    {
        private string appType;
        private HttpResponse response;

        public Export()
        {
            this.appType = "Web";
            this.response = HttpContext.Current.Response;
        }

        public Export(string ApplicationType)
        {
            this.appType = ApplicationType;
            if ((this.appType != "Web") && (this.appType != "Win"))
            {
                throw new Exception("Provide valid application format (Web/Win)");
            }
            if (this.appType == "Web")
            {
                this.response = HttpContext.Current.Response;
            }
        }

        private void CreateStylesheet(XmlTextWriter writer, string[] sHeaders, string[] sFileds, ExportFormat FormatType)
        {
            try
            {
                int num;
                string ns = "http://www.w3.org/1999/XSL/Transform";
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("xsl", "stylesheet", ns);
                writer.WriteAttributeString("version", "1.0");
                writer.WriteStartElement("xsl:output");
                writer.WriteAttributeString("method", "text");
                writer.WriteAttributeString("version", "4.0");
                writer.WriteEndElement();
                writer.WriteStartElement("xsl:template");
                writer.WriteAttributeString("match", "/");
                for (num = 0; num < sHeaders.Length; num++)
                {
                    writer.WriteString("\"");
                    writer.WriteStartElement("xsl:value-of");
                    writer.WriteAttributeString("select", "'" + sHeaders[num] + "'");
                    writer.WriteEndElement();
                    writer.WriteString("\"");
                    if (num != (sFileds.Length - 1))
                    {
                        writer.WriteString((FormatType == ExportFormat.CSV) ? "," : "\t");
                    }
                }
                writer.WriteStartElement("xsl:for-each");
                writer.WriteAttributeString("select", "Export/Values");
                writer.WriteString("\r\n");
                for (num = 0; num < sFileds.Length; num++)
                {
                    writer.WriteString("\"");
                    writer.WriteStartElement("xsl:value-of");
                    writer.WriteAttributeString("select", sFileds[num]);
                    writer.WriteEndElement();
                    writer.WriteString("\"");
                    if (num != (sFileds.Length - 1))
                    {
                        writer.WriteString((FormatType == ExportFormat.CSV) ? "," : "\t");
                    }
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void Export_with_XSLT_Web(DataSet dsExport, string[] sHeaders, string[] sFileds, ExportFormat FormatType, string FileName)
        {
            try
            {
                this.response.Clear();
                this.response.Buffer = true;
                if (FormatType == ExportFormat.CSV)
                {
                    this.response.ContentType = "text/csv";
                    this.response.AppendHeader("content-disposition", "attachment; filename=" + FileName);
                }
                else
                {
                    this.response.ContentType = "application/vnd.ms-excel";
                    this.response.AppendHeader("content-disposition", "attachment; filename=" + FileName);
                }
                MemoryStream w = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
                this.CreateStylesheet(writer, sHeaders, sFileds, FormatType);
                writer.Flush();
                w.Seek(0L, SeekOrigin.Begin);
                XmlDataDocument document = new XmlDataDocument(dsExport);
                XslTransform transform = new XslTransform();
                transform.Load(new XmlTextReader(w), null, null);
                StringWriter writer2 = new StringWriter();
                transform.Transform((IXPathNavigable) document, null, (TextWriter) writer2, null);
                this.response.Write(writer2.ToString());
                writer2.Close();
                writer.Close();
                w.Close();
                this.response.End();
            }
            catch (ThreadAbortException exception)
            {
                string message = exception.Message;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
        }

        private void Export_with_XSLT_Windows(DataSet dsExport, string[] sHeaders, string[] sFileds, ExportFormat FormatType, string FileName)
        {
            try
            {
                MemoryStream w = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(w, Encoding.UTF8);
                this.CreateStylesheet(writer, sHeaders, sFileds, FormatType);
                writer.Flush();
                w.Seek(0L, SeekOrigin.Begin);
                XmlDataDocument document = new XmlDataDocument(dsExport);
                XslTransform transform = new XslTransform();
                transform.Load(new XmlTextReader(w), null, null);
                StringWriter writer2 = new StringWriter();
                transform.Transform((IXPathNavigable) document, null, (TextWriter) writer2, null);
                StreamWriter writer3 = new StreamWriter(FileName);
                writer3.WriteLine(writer2.ToString());
                writer3.Close();
                writer2.Close();
                writer.Close();
                w.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void ExportDetails(DataTable DetailsTable, ExportFormat FormatType, string FileName)
        {
            try
            {
                if (DetailsTable.Rows.Count == 0)
                {
                    throw new Exception("There are no details to export.");
                }
                DataSet dsExport = new DataSet("Export");
                DataTable table = DetailsTable.Copy();
                table.TableName = "Values";
                dsExport.Tables.Add(table);
                string[] sHeaders = new string[table.Columns.Count];
                string[] sFileds = new string[table.Columns.Count];
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    sHeaders[i] = table.Columns[i].ColumnName;
                    sFileds[i] = this.ReplaceSpclChars(table.Columns[i].ColumnName);
                }
                if (this.appType == "Web")
                {
                    this.Export_with_XSLT_Web(dsExport, sHeaders, sFileds, FormatType, FileName);
                }
                else if (this.appType == "Win")
                {
                    this.Export_with_XSLT_Windows(dsExport, sHeaders, sFileds, FormatType, FileName);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void ExportDetails(DataTable DetailsTable, int[] ColumnList, ExportFormat FormatType, string FileName)
        {
            try
            {
                if (DetailsTable.Rows.Count == 0)
                {
                    throw new Exception("There are no details to export");
                }
                DataSet dsExport = new DataSet("Export");
                DataTable table = DetailsTable.Copy();
                table.TableName = "Values";
                dsExport.Tables.Add(table);
                if (ColumnList.Length > table.Columns.Count)
                {
                    throw new Exception("ExportColumn List should not exceed Total Columns");
                }
                string[] sHeaders = new string[ColumnList.Length];
                string[] sFileds = new string[ColumnList.Length];
                for (int i = 0; i < ColumnList.Length; i++)
                {
                    if ((ColumnList[i] < 0) || (ColumnList[i] >= table.Columns.Count))
                    {
                        throw new Exception("ExportColumn Number should not exceed Total Columns Range");
                    }
                    sHeaders[i] = table.Columns[ColumnList[i]].ColumnName;
                    sFileds[i] = this.ReplaceSpclChars(table.Columns[ColumnList[i]].ColumnName);
                }
                if (this.appType == "Web")
                {
                    this.Export_with_XSLT_Web(dsExport, sHeaders, sFileds, FormatType, FileName);
                }
                else if (this.appType == "Win")
                {
                    this.Export_with_XSLT_Windows(dsExport, sHeaders, sFileds, FormatType, FileName);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void ExportDetails(DataTable DetailsTable, int[] ColumnList, string[] Headers, ExportFormat FormatType, string FileName)
        {
            try
            {
                if (DetailsTable.Rows.Count == 0)
                {
                    throw new Exception("There are no details to export");
                }
                DataSet dsExport = new DataSet("Export");
                DataTable table = DetailsTable.Copy();
                table.TableName = "Values";
                dsExport.Tables.Add(table);
                if (ColumnList.Length != Headers.Length)
                {
                    throw new Exception("ExportColumn List and Headers List should be of same length");
                }
                if ((ColumnList.Length > table.Columns.Count) || (Headers.Length > table.Columns.Count))
                {
                    throw new Exception("ExportColumn List should not exceed Total Columns");
                }
                string[] sFileds = new string[ColumnList.Length];
                for (int i = 0; i < ColumnList.Length; i++)
                {
                    if ((ColumnList[i] < 0) || (ColumnList[i] >= table.Columns.Count))
                    {
                        throw new Exception("ExportColumn Number should not exceed Total Columns Range");
                    }
                    sFileds[i] = this.ReplaceSpclChars(table.Columns[ColumnList[i]].ColumnName);
                }
                if (this.appType == "Web")
                {
                    this.Export_with_XSLT_Web(dsExport, Headers, sFileds, FormatType, FileName);
                }
                else if (this.appType == "Win")
                {
                    this.Export_with_XSLT_Windows(dsExport, Headers, sFileds, FormatType, FileName);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private string ReplaceSpclChars(string fieldName)
        {
            fieldName = fieldName.Replace(" ", "_x0020_");
            fieldName = fieldName.Replace("%", "_x0025_");
            fieldName = fieldName.Replace("#", "_x0023_");
            fieldName = fieldName.Replace("&", "_x0026_");
            fieldName = fieldName.Replace("/", "_x002F_");
            return fieldName;
        }

        public enum ExportFormat
        {
            CSV = 1,
            Excel = 2
        }
    }
}


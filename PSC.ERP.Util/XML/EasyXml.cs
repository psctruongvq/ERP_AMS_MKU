using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace PSC_ERP_Util.XML
{
    /// Element, Attribute la Node
    /// Element chua cac Attribute, Element
    /// 
    public class EasyXml
    {
        #region Field
        XmlDocument _doc = new XmlDocument();
        #endregion

        #region Property
        public XmlDocument Doc
        {
            get { return _doc; }
            private set { _doc = value; }
        }
        #endregion
        #region Constructor
        public EasyXml()
        {

        }
        public EasyXml(String xml)
        {
            this.LoadXmlString(xml);
        }
        #endregion
        #region Instance Method

        public void LoadFile(String filePath)
        {
            if (File.Exists(filePath))
            {
                this.Doc.Load(filePath);
            }

        }
        public void LoadXmlString(string xml)
        {
            this.Doc.LoadXml(xml);
        }
        public void SaveToFile(String filePath)
        {
            this.Doc.Save(filePath);
        }
        public XmlNode SelectSingleNode(string xpath)
        {
            return this.Doc.SelectSingleNode(xpath);

        }
        public XmlNodeList SelectNodes(string xpath)
        {
            return this.Doc.SelectNodes(xpath);

        }

   

        public XmlNode AppendElementIntoRoot(string newElementName)
        {
            return AppendElement(this.Doc, newElementName, null);
        }
        public XmlNode AppendElementIntoRoot(string newElementName, String innerValue)
        {
            return AppendElement(this.Doc, newElementName, innerValue);
        }

        public override String ToString()
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            this.Doc.WriteTo(tx);

            return sw.ToString();
        }
        #endregion

        #region Static Method


        public static XmlNode AppendElement(XmlNode node, string newElementName)
        {
            return AppendElement(node, newElementName, null);
        }

        public static XmlNode AppendElement(XmlNode node, string newElementName, string innerValue)
        {
            XmlNode oNode;

            if (node is XmlDocument)
                oNode = node.AppendChild(((XmlDocument)node).CreateElement(newElementName));
            else
                oNode = node.AppendChild(node.OwnerDocument.CreateElement(newElementName));

            if (innerValue != null)
                oNode.AppendChild(node.OwnerDocument.CreateTextNode(innerValue));

            return oNode;
        }

        public static XmlAttribute CreateAttribute(XmlDocument xmlDocument, string name, string value)
        {
            XmlAttribute oAtt = xmlDocument.CreateAttribute(name);
            oAtt.Value = value;
            return oAtt;
        }

        public static void SetAttribute(XmlNode node, string attributeName, string attributeValue)
        {
            if (node.Attributes[attributeName] != null)
                node.Attributes[attributeName].Value = attributeValue;
            else
                node.Attributes.Append(CreateAttribute(node.OwnerDocument, attributeName, attributeValue));
        }

        #endregion
    }
}

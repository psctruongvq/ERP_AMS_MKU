using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace PSC_ERP
{
    public partial class FrmHienThiReportBQVT : DevExpress.XtraEditors.XtraForm
    {
        public object PrintingSystem
        {
            get { return printControl1.PrintingSystem; }
            set { printControl1.PrintingSystem = (PrintingSystem)value; }
        }

        public FrmHienThiReportBQVT()
        {
            InitializeComponent();
        }

        public FrmHienThiReportBQVT(XtraReport rpt)
        {
            InitializeComponent();
            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument();
        }
    }
}
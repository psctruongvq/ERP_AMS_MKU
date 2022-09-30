using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmHienThiReport : Form
    {
        public frmHienThiReport()
        {
            InitializeComponent();
          //  crystalReportViewerHienThi.ShowGroupTreeButton = false;

        }

        /// <summary>
        /// Report Viewer
        /// (get-set)
        /// </summary>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crytalView_HienThiReport
        {
            get
            {
                return crystalReportViewerHienThi;
            }
            set
            {
                crystalReportViewerHienThi = value;
            }
        }
    }
}

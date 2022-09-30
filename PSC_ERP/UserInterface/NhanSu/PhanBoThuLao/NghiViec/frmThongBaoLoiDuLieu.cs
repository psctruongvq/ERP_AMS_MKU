using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmThongBaoLoiDuLieu : Form
    {
        public frmThongBaoLoiDuLieu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void ThongBaoLoi(Exception ex, object Data)
        {
            frmThongBaoLoiDuLieu f = new frmThongBaoLoiDuLieu();
            string s = "";
            Csla.Core.BusinessBase d;
            if (Data is Csla.Core.BusinessBase)
            {
                d = (Csla.Core.BusinessBase)Data;
                if (d.BrokenRulesCollection.Count > 0)
                {
                    foreach (Csla.Validation.BrokenRule r in d.BrokenRulesCollection)
                    {
                        s += r.Description + "\r\n";
                    }
                }
            }
            else if (Data is Csla.Core.IExtendedBindingList)
            {
                Csla.Core.IExtendedBindingList l = (Csla.Core.IExtendedBindingList)Data;
                foreach (object o in l)
                {
                    d = (Csla.Core.BusinessBase)o;
                    if (d.BrokenRulesCollection.Count > 0)
                    {
                        foreach (Csla.Validation.BrokenRule r in d.BrokenRulesCollection)
                        {
                            if (!s.Contains(r.Description))
                                s += r.Description + "\r\n";
                        }
                    }   
                }
            }
            else
            {
                s = ex.Message;
            }
            if (s == "")
                s = ex.Message;
            f.txtErr.Text = s;
            f.ShowDialog();
        }
    }
}
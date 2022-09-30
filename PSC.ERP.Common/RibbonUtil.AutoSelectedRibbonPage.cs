using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;


namespace PSC_ERP_Common
{
    public partial class RibbonUtil
    {
        public class AutoSelectedRibbonPage
        {
            RibbonControl _ribbon;
            public static void SetUp(RibbonControl ribbon)
            {
                AutoSelectedRibbonPage obj = new AutoSelectedRibbonPage(ribbon);
            }
            public AutoSelectedRibbonPage(RibbonControl ribbon)
            {
                _ribbon = ribbon;
                ribbon.MouseMove -= ribbon_MouseMove;
                ribbon.MouseMove += ribbon_MouseMove;
            }


            void ribbon_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                RibbonHitInfo hitInfo = _ribbon.CalcHitInfo(new Point(e.X, e.Y));
                if (hitInfo.HitTest == RibbonHitTest.PageHeader)
                    if (Object.ReferenceEquals(_ribbon.SelectedPage, hitInfo.Page) == false)
                        _ribbon.SelectedPage = hitInfo.Page;
            }

        }

    }
}

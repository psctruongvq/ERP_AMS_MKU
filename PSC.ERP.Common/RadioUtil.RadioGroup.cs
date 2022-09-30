using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PSC_ERP_Common
{
    public partial class RadioUtil
    {
        public class RadioGroup
        {
            Object[] _all;
            Boolean _pause = false;
            Boolean _check = true;
            public static void Setup(Boolean check, params Object[] all)
            {
                RadioGroup obj = new RadioGroup(check, all);
            }
            public RadioGroup(Boolean check, params Object[] all)
            {
                _check = check;
                _all = all;

                if (_all.GetType() == typeof(CheckEdit[]))
                    foreach (CheckEdit item in _all)
                    {
                        item.CheckedChanged -= item_CheckedChanged;
                        item.CheckedChanged += item_CheckedChanged;
                    }
                else if (_all.GetType() == typeof(RadioButton[]))
                    foreach (RadioButton item in _all)
                    {
                        item.CheckedChanged -= item_CheckedChanged;
                        item.CheckedChanged += item_CheckedChanged;

                    }

            }


            void item_CheckedChanged(object sender, EventArgs e)
            {
                if (_pause == false)
                {
                    _pause = true;
                    if (_all.GetType() == typeof(CheckEdit[]))
                    {
                        foreach (CheckEdit item in _all)
                            if (!Object.ReferenceEquals(item, sender))
                                item.Checked = _check;
                    }
                    else if (_all.GetType() == typeof(RadioButton[]))
                    {
                        foreach (RadioButton item in _all)
                            if (!Object.ReferenceEquals(item, sender))
                                item.Checked = _check;
                    }
                    _pause = false;
                }
            }
        }
    }
}

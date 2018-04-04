using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Techl.Wpf
{
    public class SystemParametersHelper
    {
        public static bool MenuDropAlignment
        {
            get
            {
                return SystemParameters.MenuDropAlignment;
            }
            set
            {
                var _menuDropAlignmentField = typeof(SystemParameters).GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
                _menuDropAlignmentField?.SetValue(null, value);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Techl.Winforms
{
    public static class TextBoxHelper
    {
        public static void SetNumberInput(this TextBox textBox)
        {
            //Prevent multiple calling
            textBox.KeyPress -= TextBox_KeyPress;
            textBox.KeyPress += TextBox_KeyPress;

            textBox.TextAlign = HorizontalAlignment.Right;
        }

        private static void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && !char.IsControl(e.KeyChar) 
                && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '-')
                e.Handled = true;

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
                e.Handled = true;
        }
    }
}

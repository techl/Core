using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Techl.Winforms;

namespace Techl.TestForm
{
    public partial class TextBoxHelperTestForm : Form
    {
        public decimal Price { get; set; }
        public decimal? NullablePrice { get; set; }

        public TextBoxHelperTestForm()
        {
            InitializeComponent();
            //textBox1.SetNumberInput();
            textBox1.AddTextDataBinding(this, nameof(Price)).AddCurrencyFormatting("N0");

            NullableCurrencyTextBox.AddTextDataBinding(this, nameof(NullablePrice)).AddCurrencyFormatting("N0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Price.ToString());
        }

        private void NullableCurrencyShowButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NullablePrice?.ToString());
        }
    }
}

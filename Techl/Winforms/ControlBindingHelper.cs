using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Techl.Reflection;

namespace Techl.Winforms
{
    public static class ControlBindingHelper
    {
        public static Binding AddDataBinding(this Control control, string propertyName, object dataSource, string dataMember, ErrorProvider errorProvider = null)
        {
            object nullValue = null;
            if (control.GetType().GetProperty(propertyName).PropertyType == typeof(string))
                nullValue = String.Empty;
            else
                nullValue = control.GetType().GetProperty(propertyName).PropertyType.GetDefaultValue();

            var binding = control.DataBindings.Add(propertyName, dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged, nullValue);
            binding.BindingComplete += (sender, e) =>
            {
                if (e.BindingCompleteState != BindingCompleteState.Success)
                {
                    if (errorProvider == null)
                        MessageBox.Show(e.ErrorText);

                    Rollback((sender as Binding).Control, propertyName);
                }

                errorProvider?.SetError(control, e.ErrorText);
            };

            control.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Rollback(sender as Control, propertyName);
                }
            };

            return binding;
        }

        public static Binding AddTextDataBinding(this Control control, object dataSource, string dataMember, ErrorProvider errorProvider = null)
        {
            return AddDataBinding(control, nameof(Control.Text), dataSource, dataMember, errorProvider);
        }

        private static void Rollback(Control control, string propertyName)
        {
            var binding = control.DataBindings[propertyName];
            binding.ReadValue();

            if (control is TextBox && propertyName == nameof(TextBox.Text))
            {
                var textBox = control as TextBox;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        public static Binding AddDataBinding(this ComboBox comboBox, object[] list, object dataSource, string dataSourceMember, ErrorProvider errorProvider = null)
        {
            return AddDataBinding(comboBox, list, null, dataSource, dataSourceMember, errorProvider);
        }

        public static Binding AddDataBinding(this ComboBox comboBox, object[] list, string displayMember, object dataSource, string dataSourceMember, ErrorProvider errorProvider = null)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox.Items.AddRange(list);

            if (!displayMember.IsNullOrEmpty())
                comboBox.DisplayMember = displayMember;

            var binding = comboBox.AddDataBinding(nameof(ComboBox.SelectedItem), dataSource, dataSourceMember, errorProvider);
            comboBox.SelectionChangeCommitted += (s, eventArgs) =>
            {
                (s as ComboBox).DataBindings[nameof(ComboBox.SelectedItem)].WriteValue();
            };

            return binding;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="comboBoxDataSource"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataSourceMember"></param>
        /// <param name="errorProvider"></param>
        /// <returns></returns>
        public static Binding AddDataBinding(this ComboBox comboBox, object comboBoxDataSource, string displayMember, string valueMember, object dataSource, string dataSourceMember, ErrorProvider errorProvider = null)
        {
            // object[]를 쓰면 ComboBox bug 발생함.
            // https://stackoverflow.com/questions/25761803/cannot-bind-to-the-new-display-member-in-combobox-c-sharp
            if (comboBoxDataSource is object[])
                throw new NotSupportedException("object[] is not supported.");

            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox.DataSource = comboBoxDataSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            return comboBox.AddDataBinding(nameof(ComboBox.SelectedValue), dataSource, dataSourceMember, errorProvider);
        }

        public static Binding AddDataBinding<TEnum>(this ComboBox comboBox, object dataSource, string dataSourceMember, ErrorProvider errorProvider = null) where TEnum : struct, IConvertible
        {
            var list = EnumHelper.GetValues<TEnum>().ToDictionary(v => (v as Enum).GetDescription()).ToArray();

            return AddDataBinding(comboBox, list, "Key", "Value", dataSource, dataSourceMember, errorProvider);
        }

        public static Binding AddCurrencyFormatting(this Binding binding, string format = "C")
        {
            if (binding.Control is TextBox textBox)
                textBox.SetNumberInput();

            binding.Parse += (sender, e) =>
            {
                if (e.DesiredType == typeof(decimal))
                {
                    if (decimal.TryParse(e.Value.ToString(), NumberStyles.Currency, null, out decimal value))
                        e.Value = value;
                    else
                        e.Value = default(decimal);
                }
            };

            binding.Format += (sender, e) =>
            {
                if (e.DesiredType == typeof(string))
                {
                    e.Value = ((decimal)e.Value).ToString(format);
                }
            };

            return binding;
        }
    }
}

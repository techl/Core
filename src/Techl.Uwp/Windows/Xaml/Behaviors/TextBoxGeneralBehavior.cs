// Copyright (c) techl.com All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Techl.Windows.Xaml.Behaviors
{
    public class TextBoxGeneralBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }

        private TextBox TextBox { get { return AssociatedObject as TextBox; } }

        public ICommand EnterCommand
        {
            get { return (ICommand)GetValue(EnterCommandProperty); }
            set { SetValue(EnterCommandProperty, value); }
        }

        public static readonly DependencyProperty EnterCommandProperty =
            DependencyProperty.Register("EnterCommand", typeof(ICommand), typeof(TextBoxGeneralBehavior), new PropertyMetadata(null));

        public void Attach(DependencyObject associatedObject)
        {
            if (!(associatedObject is TextBox))
                return;

            AssociatedObject = associatedObject;

            TextBox.KeyDown += TextBox_KeyDown;
            TextBox.GotFocus += TextBox_GotFocus;
            TextBox.TextChanged += TextBox_TextChanged;
        }

        public void Detach()
        {
            if (TextBox == null)
                return;

            TextBox.KeyDown -= TextBox_KeyDown;
            TextBox.GotFocus -= TextBox_GotFocus;
            TextBox.TextChanged -= TextBox_TextChanged;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox.SelectAll();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var binding = TextBox.GetBindingExpression(TextBox.TextProperty);
            binding?.UpdateSource();
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == global::Windows.System.VirtualKey.Enter && EnterCommand != null)
            {
                e.Handled = true;
                EnterCommand?.Execute(null);
            }
        }
    }
}

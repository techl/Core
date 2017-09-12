// Copyright (c) techl.com All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Techl.Reflection;

namespace Techl.ComponentModel
{
    public static class INotifyPropertyChangedHelper
    {
        public static void RaisePropertyChanged(this INotifyPropertyChanged obj, [CallerMemberName] string propertyName = "")
        {
            ReflectionHelper.RaiseEvent(obj, "PropertyChanged", new object[] { obj, new PropertyChangedEventArgs(propertyName) });
        }

        public static bool SetField<T>(this INotifyPropertyChanged obj, ref T field, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
                return false;

            field = newValue;
            obj.RaisePropertyChanged(propertyName);

            return true;
        }
    }
}

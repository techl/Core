// Copyright (c) techl.com All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Techl.Reflection
{
    public static class ReflectionHelper
    {
        private static readonly BindingFlags AllBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public static TValue GetPropertyValue<TValue>(this object owner, string propertyName)
        {
            var property = owner.GetType().GetProperty(propertyName, AllBindingFlags);
            if (property == null)
                throw new ArgumentException(String.Format("Can't find '{0}' property", propertyName));

            return (TValue)property.GetValue(owner);
        }

        public static void SetPropertyValue<TValue>(this object owner, string propertyName, TValue value)
        {
            var property = owner.GetType().GetProperty(propertyName, AllBindingFlags);
            if (property == null)
                throw new ArgumentException(String.Format("Can't find '{0}' property", propertyName));

            property.SetValue(owner, value);
        }

        public static object Invoke(object obj, string methodName, params object[] parameters)
        {
            var method = obj.GetType().GetMethod(methodName, AllBindingFlags);
            if (method == null)
                throw new ArgumentException(String.Format("'{0}' method doesn't exist.", methodName));

            return method.Invoke(obj, parameters);
        }

        public static T Invoke<T>(Type type, string methodName, params object[] parameters)
        {
            var method = type.GetMethod(methodName, AllBindingFlags);

            return (T)method.Invoke(null, parameters);
        }

        public static T InvokeGenericMethod<T>(Type type, string methodName, object[] parameters, params Type[] genericTypeArguments)
        {
            var method = type.GetMethod(methodName, AllBindingFlags);
            if (genericTypeArguments != null)
                method = method.MakeGenericMethod(genericTypeArguments);

            return (T)method.Invoke(null, parameters);
        }

        /// <summary>
        /// NOTICE : Does not support custom implemented event.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="eventName"></param>
        /// <param name="args"></param>
        public static void RaiseEvent(object obj, string eventName, params object[] args)
        {
            var eventDelegate = (MulticastDelegate)obj.GetType().GetField(eventName, AllBindingFlags).GetValue(obj);
            if (eventDelegate == null)
                return;

            foreach (var handler in eventDelegate.GetInvocationList())
            {
                handler.DynamicInvoke(args);
            }
        }

        private static IEnumerable<FieldInfo> GetAllFields(Type t)
        {
            if (t == null)
                return Enumerable.Empty<FieldInfo>();

            return t.GetFields(AllBindingFlags).Concat(GetAllFields(t.GetTypeInfo().BaseType));
        }

        private static FieldInfo GetField(Type t, string fieldName)
        {
            return GetAllFields(t).Where(f => f.Name == fieldName).FirstOrDefault();
        }

        public static T GetFieldValue<T>(object owner, string fieldName)
        {
            var field = GetField(owner.GetType(), fieldName);
            return (T)field.GetValue(owner);
        }

        public static void SetFieldValue(object owner, string fieldName, object value)
        {
            var field = GetField(owner.GetType(), fieldName);
            field.SetValue(owner, value);
        }
    }
}

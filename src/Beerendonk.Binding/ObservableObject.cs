// Copyright (c) Rick Beerendonk. All rights reserved.
//
// The use and distribution terms for this software are covered by the
// Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
// which can be found in the file LICENSE at the root of this distribution.
// By using this software in any fashion, you are agreeing to be bound by
// the terms of this license.
//
// You must not remove this notice, or any other, from this software.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Beerendonk.Binding
{
    /// <summary>
    /// Base class for observable classes.
    /// </summary>
    /// <typeparam name="T">Type of the derived class.</typeparam>
    public class ObservableObject<T> : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// If the property value changes, the oldValue will be replaced by the newValue
        /// and the INotifyPropertyChanged.PropertyChanged event will be raised.
        /// </summary>
        /// <typeparam name="TProperty">Type of the property.</typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="oldValue">Old value of the property.</param>
        /// <param name="newValue">New value of the property.</param>
        /// <returns><c>true</c> if the property value changed, otherwise <c>false</c>.</returns>
        protected bool ChangeProperty<TProperty>(string propertyName, ref TProperty oldValue, TProperty newValue)
        {
            // Can the property be found?
            Debug.Assert(
                HasProperty(propertyName),
                string.Format(
                    "{0} is not a public property of {1}",
                    propertyName,
                    GetType().FullName)
                );

            if ((oldValue == null && newValue != null) || ((oldValue != null) && !oldValue.Equals(newValue)))
            {
                oldValue = newValue;
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

                return true;
            }

            return false;
        }

        /// <summary>
        /// If the property value changes, the oldValue will be replaced by the newValue
        /// and the INotifyPropertyChanged.PropertyChanged event will be raised.
        /// </summary>
        /// <typeparam name="TProperty">Type of the property.</typeparam>
        /// <param name="propertyExpression">Expression identifying the property: "o => o.PropertyName".</param>
        /// <param name="oldValue">Old value of the property.</param>
        /// <param name="newValue">New value of the property.</param>
        /// <returns><c>true</c> if the property value changed, otherwise <c>false</c>.</returns>
        protected bool ChangeProperty<TProperty>(Expression<Func<T, TProperty>> propertyExpression, ref TProperty oldValue, TProperty newValue)
        {
            return ChangeProperty(((MemberExpression)propertyExpression.Body).Member.Name, ref oldValue, newValue);
        }

        // Event Design Guidelines:
        // http://msdn.microsoft.com/en-us/library/ms229011.aspx
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, e);
            }
        }

        private bool HasProperty(string propertyName)
        {
            Type type = GetType();
            while (type != null)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                if (typeInfo.DeclaredProperties.Any(p => p.Name == propertyName))
                {
                    return true;
                }

                type = typeInfo.BaseType;
            }

            return false;
        }
    }
}

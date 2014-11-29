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
using System.Linq.Expressions;

namespace Beerendonk.Binding
{
    /// <summary>
    /// Extension methods for the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    public static class NotifyPropertyChangedExtensions
    {
        /// <summary>
        /// No need to have PropertyNames as string in your code when using this method with param "o => o.PropertyName"
        /// </summary>
        /// <typeparam name="T">Type of the class.</typeparam>
        /// <typeparam name="TProperty">Type of the property.</typeparam>
        /// <param name="obj"></param>
        /// <param name="expr"></param>
        /// <returns>Property</returns>
        public static string GetPropertyName<T, TProperty>(this T obj, Expression<Func<T, TProperty>> expr) where T : INotifyPropertyChanged
        {
            return ((MemberExpression)expr.Body).Member.Name;
        }
    }
}

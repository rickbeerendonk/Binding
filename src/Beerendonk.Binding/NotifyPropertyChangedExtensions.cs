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
    public static class NotifyPropertyChangedExtensions
    {
        /// <summary>
        /// No need to have PropertyNames as string in your code when using this method with param "o => o.PropertyName"
        /// Source: http://themechanicalbride.blogspot.com/2007/03/symbols-on-steroids-in-c.html
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="obj"></param>
        /// <param name="expr"></param>
        /// <returns>Property</returns>
        public static string GetPropertyName<T, R>(this T obj, Expression<Func<T, R>> expr) where T : INotifyPropertyChanged
        {
            return ((MemberExpression)expr.Body).Member.Name;
        }
    }
}

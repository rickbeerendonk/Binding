// Copyright (c) Rick Beerendonk. All rights reserved.
//
// The use and distribution terms for this software are covered by the
// Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
// which can be found in the file LICENSE at the root of this distribution.
// By using this software in any fashion, you are agreeing to be bound by
// the terms of this license.
//
// You must not remove this notice, or any other, from this software.

using Beerendonk.Binding;

namespace Beerendonk.Binding.Demo
{
    // Demo class should inherit ObservableObject<T> where T should become the Demo class itself.
    public class Demo : ObservableObject<Demo>
    {
        // Example: Property Name snippet.
        private string _FirstProperty;
        public string FirstProperty
        {
            get
            {
                return _FirstProperty;
            }
            set
            {
                ChangeProperty("FirstProperty", ref _FirstProperty, value);
            }
        }

        // Example: Property Expression snippet.
        private int _SecondProperty;
        public int SecondProperty
        {
            get
            {
                return _SecondProperty;
            }
            set
            {
                ChangeProperty(o => o.SecondProperty, ref _SecondProperty, value);
            }
        }
    }
}

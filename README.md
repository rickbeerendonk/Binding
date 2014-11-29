Binding
=======

[![NuGet version](http://img.shields.io/nuget/v/Beerendonk.Binding.svg)](https://www.nuget.org/packages/Beerendonk.Binding)
[![NuGet downloads](http://img.shields.io/nuget/dt/Beerendonk.Binding.svg)](https://www.nuget.org/packages/Beerendonk.Binding)

Simplifies creating databindable objects in .NET

## Releases and Dependency Information

* Latest release: 1.0

This is a Portable Class Library with the following targets:

* .NET Framework 4.5
* Windows 8
* Windows Phone 8.1

## Usage

```C#
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
```

## Copyright and License
Copyright © 2014 Rick Beerendonk. All rights reserved.

The use and distribution terms for this software are covered by the Eclipse Public License 1.0 ([http://opensource.org/licenses/eclipse-1.0.php](http://opensource.org/licenses/eclipse-1.0.php)) which can be found in the file epl-v10.html at the root of this distribution. By using this software in any fashion, you are agreeing to be bound by the terms of this license.

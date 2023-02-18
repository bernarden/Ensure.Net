# Ensure.Net

[![Build status](https://github.com/bernarden/Ensure.Net/actions/workflows/build.yml/badge.svg?branch=master)](https://github.com/bernarden/Ensure.Net/actions/workflows/build.yml)
[![NuGet](https://img.shields.io/nuget/v/Ensure.Net.svg)](https://www.nuget.org/packages/Ensure.Net/)

Ensure.Net is a simple yet functional argument validation library.

## Project goals

1. Simple to use.
1. Support most needed functionality.
1. Be available for most .NET frameworks.
1. Take a fresh perspective.

## Examples

### Constructor

```csharp
public class YourClass
{
    private IYourDependency _dependency;
    private int _intValue;
    private Guid _recordId;

    public YourClass(IYourDependency dependency, int? intValue, Guid recordId)
    {
        _dependency = Ensure.NotNull(dependency).Value;
        _intValue = Ensure.NotNull(intValue).Value;
        _recordId = Ensure.NotDefault(recordId).Value;
    }
    ...
}
```

### Method

```csharp
    ...
    public void YourMethod(IYourDependency dependency)
    {
        Ensure.NotNull(dependency);
        ...
    }
    ...
```

## ReSharper
Update ReSharper's settings to auto generate null checks using this library.
Refer to this [.DotSettings](./Resources/ReSharper.DotSettings) file for an example.

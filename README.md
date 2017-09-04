# Ensure.Net

[![Build status](https://ci.appveyor.com/api/projects/status/9rx1gvvt6bxv6jw7/branch/master?svg=true)](https://ci.appveyor.com/project/bernarden/ensure-net/branch/master)
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

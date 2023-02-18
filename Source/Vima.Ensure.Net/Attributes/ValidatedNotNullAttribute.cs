using System;

namespace Vima.Ensure.Net.Attributes;

[AttributeUsage(AttributeTargets.Parameter)]
internal sealed class ValidatedNotNullAttribute : Attribute
{
}
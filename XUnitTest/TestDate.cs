using System;
using System.Globalization;

namespace XUnitTest;

internal static class TestDate
{
    public static DateTime Parse(String value) => DateTime.Parse(value, CultureInfo.InvariantCulture);
}

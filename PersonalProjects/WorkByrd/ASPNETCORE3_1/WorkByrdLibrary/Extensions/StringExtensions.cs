using System;

namespace WorkByrdLibrary.Extensions
{
    public static class StringExtensions
    {
        public static E ToEnum<E>(this string value)
        {
            return (E) Enum.Parse(typeof(E), value);
        }
    }
}

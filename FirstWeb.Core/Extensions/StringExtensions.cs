using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text) => string.IsNullOrEmpty(text);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blogger.SharedUI.Extensions
{
    public static class StringExtension
    {
            public static string Slugify(this string name) =>
            Regex.Replace(name.ToLower(), @"[^a-zA-Z0-9\-_]", "-", RegexOptions.Compiled, TimeSpan.FromSeconds(1))
                .Replace("--", "-")
                .Trim('-');
    }
}

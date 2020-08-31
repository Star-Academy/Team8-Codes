// Standard Library
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Internal
using BagherEngine.Models;

namespace BagherEngine.QuerySystem
{
    public class OrTerms : Terms
    {
        private static readonly Regex Pattern = new Regex(@"\+(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public OrTerms(String expression) : base()
        {
            Collect(expression, Pattern, 1);
        }
    }
}

// Standard Library
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Internal
using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Structures;


namespace GoogleSharp.Src.Core.Query
{
    public class OrTerms : Terms
    {
        private static readonly Regex Pattern = new Regex(@"\+(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public OrTerms(String expression) : base()
        {
            this.Collect(expression, Pattern, 1);
        }

        public override HashSet<Document> GetResults(IInvertedIndex index)
        {
            return new HashSet<Document>(this.Tokens.SelectMany(token => index.GetDocumentsOfToken(token)));
        }
    }
}
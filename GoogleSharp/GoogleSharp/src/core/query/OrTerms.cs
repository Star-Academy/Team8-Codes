using System;
using System.Linq;
using GoogleSharp.Src.Core.Structures;
using GoogleSharp.Src.Core.Engine;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
            return this.Tokens.SelectMany(token => index.GetDocumentsOfToken(token)) as HashSet<Document>;
        }
    }
}
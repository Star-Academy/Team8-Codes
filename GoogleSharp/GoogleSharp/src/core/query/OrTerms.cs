using System;
using GoogleSharp.Src.Core.Structures;
using GoogleSharp.Src.Core.Engine;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace GoogleSharp.Src.Core.Query
{
    public class OrTerms : Terms
    {
        private readonly Regex PATTERN = new Regex(@"\+(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public OrTerms(String expression) : base()
        {
            this.Collect(expression, PATTERN, 1);
        }

        public override HashSet<Document> GetResults(IInvertedIndex index)
        {
            var results = new HashSet<Document>();
            this.Tokens.ForEach(token => results.UnionWith(index.GetDocumentsOfToken(token)));
            return results;
        }
    }
}
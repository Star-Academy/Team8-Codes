using System.Collections.Generic;
using System.Text.RegularExpressions;
using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Structures;

namespace GoogleSharp.Src.Core.Query
{
    public class ExcTerms : Terms
    {
        private readonly Regex PATTERN = new Regex(@"\-(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public ExcTerms(string expression) : base()
        {
            this.Collect(expression, PATTERN, 1);
        }

        public override HashSet<Document> GetResults(IInvertedIndex index)
        {
            HashSet<Document> results = new HashSet<Document>();
            this.Tokens.ForEach(t => results.UnionWith(index.GetDocumentsOfToken(t)));
            return results;
        }
    }
}
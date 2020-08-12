// Standard Library
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Internal
using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Structures;


namespace GoogleSharp.Src.Core.Query
{
    public class AndTerms : Terms
    {
        private static readonly Regex Pattern = new Regex(@"( *[^\+\-\w]|^)(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public AndTerms(string expression) : base()
        {
            this.Collect(expression, Pattern, 2);
        }

        public override HashSet<Document> GetResults(IInvertedIndex index)
        {
            var results = new HashSet<Document>();
            if (this.Tokens.Any())
            {
                results.UnionWith(index.GetDocumentsOfToken(this.Tokens[0]));
                this.Tokens.ForEach(t => results.IntersectWith(index.GetDocumentsOfToken(t)));
            }
            return results;
        }
    }
}
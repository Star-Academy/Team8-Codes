using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GoogleSharp.Src.Core.Engine;
using GoogleSharp.Src.Core.Structures;

namespace GoogleSharp.Src.Core.Query
{
    public class AndTerms : Terms
    {
        private readonly Regex PATTERN = new Regex(@"( *[^\+\-\w]|^)(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public AndTerms(string expression) : base()
        {
            this.Collect(expression, PATTERN, 2);
        }

        public override HashSet<Document> GetResults(IInvertedIndex index)
        {
            HashSet<Document> results = new HashSet<Document>();
            if (this.Tokens.Any())
            {
                results.UnionWith(index.GetDocumentsOfToken(this.Tokens[0]));
                this.Tokens.ForEach(t => results.IntersectWith(index.GetDocumentsOfToken(t)));
            }
            return results;
        }
    }
}
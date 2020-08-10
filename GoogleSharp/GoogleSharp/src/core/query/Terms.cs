using GoogleSharp.Src.Core.Structures;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using GoogleSharp.Src.Core.Engine;

namespace GoogleSharp.Src.Core.Query
{
    public abstract class Terms
    {
        public List<Token> Tokens { get; set; }

        public Terms()
        {
            this.Tokens = new List<Token>();
        }

        protected void Collect(string expression, Regex pattern, int regexGroupIndex)
        {
            pattern.Matches(expression).OfType<Match>().ToList().ForEach(
                match =>
                {
                    this.Tokens.Add(new Token(match.Groups[regexGroupIndex].Value));
                }
            );
        }

        public bool IsEmpty()
        {
            return !this.Tokens.Any();
        }

        public abstract HashSet<Document> GetResults(IInvertedIndex index);
    }
}

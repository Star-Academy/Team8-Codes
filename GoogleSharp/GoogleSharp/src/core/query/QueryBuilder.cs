using System;

namespace GoogleSharp.Src.Core.Query
{
    public class QueryBuilder
    {
        public AndTerms Ands { get; set; }
        public OrTerms Ors { get; set; }
        public ExcTerms Excs { get; set; }

        public QueryBuilder(string queryString)
        {
            this.CollectTerms(queryString);
        }

        private void CollectTerms(string expression)
        {
            this.Ands = new AndTerms(expression);
            this.Ors = new OrTerms(expression);
            this.Excs = new ExcTerms(expression);
        }

        public override string ToString()
        {
            return "Query\n" +
                    $"Ands : {this.Ands.ToString()}\n" +
                    $"Ors  : {this.Ors.ToString()}\n" +
                    $"Excs : {this.Excs.ToString()}";
        }
    }
}
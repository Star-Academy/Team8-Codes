namespace GoogleSharp.Src.Core.Query {
    public class QueryBuilder {
        public AndTerms Ands { get; set; }
        public OrTerms Ors { get; set; }
        public ExcTerms Excs { get; set; }

        public QueryBuilder (string queryString) {
            CollectTerms (queryString);
        }

        private void CollectTerms (string expression) {
            Ands = new AndTerms (expression);
            Ors = new OrTerms (expression);
            Excs = new ExcTerms (expression);
        }

        public override string ToString () {
            return "Query\n" +
                $"Ands : {Ands.ToString()}\n" +
                $"Ors  : {Ors.ToString()}\n" +
                $"Excs : {Excs.ToString()}";
        }
    }
}

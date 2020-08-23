namespace BagherEngine.QuerySystem
{
    public class Query
    {
        public AndTerms Ands { get; set; }
        public OrTerms Ors { get; set; }
        public ExcTerms Excs { get; set; }

        public Query(string queryString)
        {
            CollectTerms(queryString);
        }

        private void CollectTerms(string expression)
        {
            Ands = new AndTerms(expression);
            Ors = new OrTerms(expression);
            Excs = new ExcTerms(expression);
        }
    }
}

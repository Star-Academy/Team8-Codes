namespace BagherMusic.QuerySystem
{
	public class Query
	{
		public Terms Ands { get; set; }
		public Terms Ors { get; set; }
		public Terms Excs { get; set; }

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

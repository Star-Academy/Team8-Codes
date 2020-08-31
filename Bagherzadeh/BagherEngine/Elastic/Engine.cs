using System.Collections.Generic;
using System.Linq;

using BagherEngine.Models;
using BagherEngine.QuerySystem;

using Nest;

namespace BagherEngine.Elastic
{
	public class Engine
	{
		private static IElasticClient client = ElasticClientFactory.CreateElasticClient();
		private const string ContentField = "content";

		private static Engine engineInstance = CreateInitialEngine();

		private Engine()
		{

		}

		private static Engine CreateInitialEngine()
		{
			return new Engine();
		}

		public static Engine GetInstance()
		{
			return engineInstance;
		}

		public HashSet<Document> GetQueryResults(Query query)
		{
			var queryContainer = BuildQueryContainer(query);
			var response = SearchDocuments(queryContainer);
			Validator.Validate(response);

			return ExtractDocumentsFromResponse(response);
		}

		private QueryContainer BuildQueryContainer(Query query)
		{
			return new BoolQuery
			{
				Must = query.Ands.Tokens.Select(token => (QueryContainer) new MatchQuery { Field = ContentField, Query = token.Key }),
					Should = query.Ors.Tokens.Select(token => (QueryContainer) new MatchQuery { Field = ContentField, Query = token.Key }),
					MustNot = query.Excs.Tokens.Select(token => (QueryContainer) new MatchQuery { Field = ContentField, Query = token.Key })
			};
		}

		private ISearchResponse<Document> SearchDocuments(QueryContainer queryContainer)
		{
			return client.Search<Document>(s => s
				.Index("bagher-documents")
				.Query(q => queryContainer)
				.Size(100)
			);
		}

		private HashSet<Document> ExtractDocumentsFromResponse(ISearchResponse<Document> response)
		{
			var documents = response.Documents.ToList<Document>();
			var hits = response.Hits.ToArray();
			for (var index = 0; index < hits.Length; index++)
				documents[index].Id = hits[index].Id;
			return documents.ToHashSet();
		}
	}
}

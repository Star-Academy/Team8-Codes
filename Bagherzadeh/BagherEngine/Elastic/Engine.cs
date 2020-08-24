using System.Collections.Generic;
using System.Linq;

using BagherEngine.Models;
using BagherEngine.QuerySystem;

using Nest;

namespace BagherEngine.Elastic
{
    public static class Engine
    {
        private static IElasticClient client = ElasticClientFactory.CreateElasticClient();

        public static HashSet<Document> GetQueryResults(Query query)
        {
            var queryContainer = BuildQueryContainer(query);
            var response = SearchDocuments(queryContainer);
            Validator.Validate(response);

            return ExtractDocumentsFromResponse(response);
        }

        private static QueryContainer BuildQueryContainer(Query query)
        {
            return new BoolQuery
            {
                Must = query.Ands.Tokens.Select(token => (QueryContainer) new MatchQuery { Field = "content", Query = token.Key }).ToList(),
                    Should = query.Ors.Tokens.Select(token => (QueryContainer) new MatchQuery { Field = "content", Query = token.Key }).ToList(),
                    MustNot = query.Excs.Tokens.Select(token => (QueryContainer) new MatchQuery { Field = "content", Query = token.Key }).ToList()
            };
        }

        private static ISearchResponse<Document> SearchDocuments(QueryContainer queryContainer)
        {
            return client.Search<Document>(s => s
                .Index("bagher-documents")
                .Query(q => queryContainer)
                .Size(100)
            );
        }

        private static HashSet<Document> ExtractDocumentsFromResponse(ISearchResponse<Document> response)
        {
            var documents = response.Documents.ToList<Document>();
            var hits = response.Hits.ToArray();
            Enumerable.Range(0, hits.Length).ToList().ForEach(index => documents[index].Id = hits[index].Id);
            return documents.ToHashSet();
        }
    }
}

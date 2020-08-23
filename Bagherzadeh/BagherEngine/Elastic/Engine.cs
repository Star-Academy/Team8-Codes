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

        public static QueryContainer BuildQueryContainer(Query query)
        {
            return new BoolQuery
            {
                Must = query.Ands.Tokens.Select(token => (QueryContainer) new MatchQuery { Field = "content", Query = token.Key }).ToList(),
                    Should = query.Ors.Tokens.Select(token => (QueryContainer) new MatchQuery { Field = "content", Query = token.Key }).ToList(),
                    MustNot = query.Excs.Tokens.Select(token => (QueryContainer) new MatchQuery { Field = "content", Query = token.Key }).ToList()
            };
        }

        public static HashSet<Document> GetQueryResults(Query query)
        {
            var queryContainer = BuildQueryContainer(query);

            var response = client.Search<Document>(s => s
                .Index("bagher-documents")
                .Query(q => queryContainer)
                .Size(100)
            );

            var documents = response.Documents.ToList<Document>();
            var ids = response.Hits.ToArray();
            int idx = 0;
            documents.ForEach(doc => doc.Id = ids[idx++].Id);
            return documents.ToHashSet();
        }
    }
}

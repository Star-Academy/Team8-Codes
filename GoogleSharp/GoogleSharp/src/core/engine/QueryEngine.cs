using System.Collections.Generic;
using GoogleSharp.Src.Core.Structures;
using GoogleSharp.Src.Core.Query;
using System;

namespace GoogleSharp.Src.Core.Engine
{
    public class QueryEngine
    {
        private static HashSet<Document> GetSubQueriesResults(QueryBuilder query, IInvertedIndex index)
        {
            HashSet<Document> results = new HashSet<Document>();
            results.UnionWith(query.Ands.GetResults(index));   // + AND results
            results.UnionWith(query.Ors.GetResults(index));    // + OR  results
            results.ExceptWith(query.Excs.GetResults(index));  // - EXC results
            return results;
        }

        public static HashSet<Document> GetQueryResults(QueryBuilder query, IInvertedIndex index)
        {
            if (query.Ands.IsEmpty() && query.Ors.IsEmpty())
                throw new ArgumentException("Cannot search the whole internet!");
            return GetSubQueriesResults(query, index);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

using BagherMusic.Models;
using BagherMusic.QuerySystem;

using Nest;

namespace BagherMusic.Elastic
{
	public class SearchEngine
	{
		private static IElasticClient client = ElasticClientFactory.CreateElasticClient();

		private const string ContentField = "content";
		private const int ResultCountPerPage = 10;
		private const int AcceptableFuzziness = 3;

		private readonly string[] MusicSearchFields = new string[] { "lyrics", "artistNames" };

		private readonly Dictionary<Type, string> IndexNames = new Dictionary<Type, string>
		{
			{
				typeof(Music),
				"bagher-musics"
			},
			{
				typeof(Artist),
				"bagher-artists"
			}
		};
		private readonly Dictionary<Type, string[]> SearchFields = new Dictionary<Type, string[]>
		{
			{
				typeof(Music),
				new string[]
				{
					"lyrics",
					"primaryArtistName",
					"title"
				}
			},
			{
				typeof(Artist),
				new string[]
				{
					"name"
				}
			}
		};


		private static SearchEngine engineInstance = CreateInitialEngine();

		private SearchEngine()
		{

		}

		private static SearchEngine CreateInitialEngine()
		{
			return new SearchEngine();
		}

		public static SearchEngine GetInstance()
		{
			return engineInstance;
		}

		public HashSet<T> GetSearchResults<T>(Query query, int pageIndex) where T : class
		{
			var queryContainer = BuildSearchQueryContainer(query, SearchFields[typeof(T)]);
			var response = Search<T>(queryContainer, pageIndex);
			Validator.Validate(response);
			return response.Documents.ToList<T>().ToHashSet();
		}

		private QueryContainer BuildSearchQueryContainer(Query query, string[] fields)
		{
			return new BoolQuery
			{
				Must = query.Ands.Tokens.Select(
						token => (QueryContainer) new MultiMatchQuery
						{
							Fields = fields,
								Query = token.Id,
								Fuzziness = Fuzziness.EditDistance(AcceptableFuzziness)
						}
					),
					Should = query.Ors.Tokens.Select(
						token => (QueryContainer) new MultiMatchQuery
						{
							Fields = fields,
								Query = token.Id,
								Fuzziness = Fuzziness.EditDistance(AcceptableFuzziness)
						}
					),
					MustNot = query.Excs.Tokens.Select(
						token => (QueryContainer) new MultiMatchQuery
						{
							Fields = fields,
								Query = token.Id,
								Fuzziness = Fuzziness.EditDistance(AcceptableFuzziness)
						}
					)
			};
		}

		private ISearchResponse<T> Search<T>(QueryContainer queryContainer, int pageIndex) where T : class
		{
			return client.Search<T>(s => s
				.Index(IndexNames[typeof(T)])
				.Query(q => queryContainer)
				.Size(ResultCountPerPage)
				.From(pageIndex * ResultCountPerPage)
			);
		}
	}
}

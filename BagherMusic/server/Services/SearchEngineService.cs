// Standard
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

// Internal
using BagherMusic.Core.Elastic;
using BagherMusic.Core.QuerySystem;
using BagherMusic.Models;

// Microsoft
using Microsoft.Extensions.Configuration;

// Elastic
using Nest;

namespace BagherMusic.Services
{
	public class SearchEngineService : ISearchEngineService
	{
		private IElasticClient client;

		private bool running = false;
		private IConfiguration _config;

		private int ResultCountPerPage;
		private int AcceptableFuzziness;

		private Dictionary<Type, string> IndexNames = new Dictionary<Type, string>();
		private Dictionary<Type, string[]> SearchFields = new Dictionary<Type, string[]>();

		public SearchEngineService(IConfiguration config)
		{
			_config = config;
		}

		private void RunService()
		{
			Console.WriteLine("Attempting to run search service...");
			ElasticClientFactory.CreateInitialClient(_config["SearchService:ElasticServerUri"]);
			client = ElasticClientFactory.GetInstance();
			ResultCountPerPage = Int32.Parse(_config["SearchService:SearchOptions:ResultCountPerPage"]);
			AcceptableFuzziness = Int32.Parse(_config["SearchService:SearchOptions:AcceptableFuzziness"]);
			IndexNames[typeof(Music)] = _config["SearchService:SearchOptions:IndexNames:Music"];
			IndexNames[typeof(Artist)] = _config["SearchService:SearchOptions:IndexNames:Artist"];
			SearchFields[typeof(Music)] = JsonSerializer.Deserialize<string[]>(_config["SearchService:SearchOptions:SearchFields:Music"]);
			SearchFields[typeof(Artist)] = JsonSerializer.Deserialize<string[]>(_config["SearchService:SearchOptions:SearchFields:Artist"]);
			Console.WriteLine("[SUCCESS] Run search service");
			running = true;
		}

		public G GetEntity<T, G>(T id)
		where T : IComparable
		where G : IEntity<T>
		{
			if (!running)
				RunService();

			var queryContainer = new MatchQuery
			{
				Field = "_id",
					Query = id.ToString()
			};
			var response = client.Search<G>(s => s
				.Index(IndexNames[typeof(G)])
				.Query(q => queryContainer)
				.Size(1)
			);
			Validator.Validate(response);
			return response.Documents.ToList<G>() [0];
		}

		public HashSet<T> GetSearchResults<T>(Query query, int pageIndex) where T : class
		{
			if (!running)
				RunService();
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

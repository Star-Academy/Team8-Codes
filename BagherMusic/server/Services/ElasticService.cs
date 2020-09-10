// Standard
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

// Internal
using BagherMusic.Core.Elastic;
using BagherMusic.Core.QuerySystem;
using BagherMusic.Models;
using BagherMusic.Utils;

// Microsoft
using Microsoft.Extensions.Configuration;

// Elastic
using Nest;

namespace BagherMusic.Services
{
	public abstract class ElasticService<T, G> : IElasticService<T, G> where G : IEntity<T>
	{
		protected IElasticClient client;

		protected int resultCountPerPage;
		protected int acceptableFuzziness;

		protected string indexName;
		protected string[] searchFields;

		public ElasticService(IConfiguration config, IElasticClientService clientService)
		{
			client = clientService.GetInstance();
			resultCountPerPage = Int32.Parse(config["ElasticService:Options:ResultCountPerPage"]);
			acceptableFuzziness = Int32.Parse(config["ElasticService:Options:AcceptableFuzziness"]);
		}

		private void CreateInitialClient(string elasticUri)
		{
			var uri = new Uri(elasticUri);
			var connectionSettings = new ConnectionSettings(uri);
			client = new ElasticClient(connectionSettings);
		}

		public G GetEntity(T id)
		{
			var queryContainer = new MatchQuery
			{
				Field = "_id",
					Query = id.ToString()
			};
			var response = client.Search<G>(s => s
				.Index(indexName)
				.Query(q => queryContainer)
				.Size(1)
			);
			Validator.Validate(response);
			return response.Documents.ToList<G>() [0];
		}

		public HashSet<G> GetSearchResults(Query query, int pageIndex)
		{
			var queryContainer = BuildSearchQueryContainer(query, searchFields);
			var response = Search(queryContainer, pageIndex);
			Validator.Validate(response);
			return response.Documents.ToList<G>().ToHashSet();
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
								Fuzziness = Fuzziness.EditDistance(acceptableFuzziness)
						}
					),
					Should = query.Ors.Tokens.Select(
						token => (QueryContainer) new MultiMatchQuery
						{
							Fields = fields,
								Query = token.Id,
								Fuzziness = Fuzziness.EditDistance(acceptableFuzziness)
						}
					),
					MustNot = query.Excs.Tokens.Select(
						token => (QueryContainer) new MultiMatchQuery
						{
							Fields = fields,
								Query = token.Id,
								Fuzziness = Fuzziness.EditDistance(acceptableFuzziness)
						}
					)
			};
		}

		private ISearchResponse<G> Search(QueryContainer queryContainer, int pageIndex)
		{
			return client.Search<G>(s => s
				.Index(indexName)
				.Query(q => queryContainer)
				.Size(resultCountPerPage)
				.From(pageIndex * resultCountPerPage)
			);
		}

		public int Import(string resourcesPath)
		{
			var bulk = CreateBulk(FileHandler.GetEntitiesFromFolder<T, G>(resourcesPath));
			var response = client.Bulk(bulk);
			Validator.Validate(response);
			return response.Items.Count;
		}

		private BulkDescriptor CreateBulk(IEnumerable<G> entities)
		{
			var bulkDescriptor = new BulkDescriptor();
			bulkDescriptor.IndexMany<G>(entities, (descriptor, s) => descriptor.Index(indexName).Id(s.Id.ToString()));
			return bulkDescriptor;
		}
	}
}

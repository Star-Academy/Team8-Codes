// Standard
using System;

using Microsoft.Extensions.Configuration;

// Elastic
using Nest;

namespace BagherMusic.Services
{
	internal class ElasticClientService : IElasticClientService
	{
		private static IElasticClient client;

		public ElasticClientService(IConfiguration config)
		{
			CreateInitialClient(config["ElasticClientService:ServerUri"]);
		}

		public IElasticClient GetInstance()
		{
			return client;
		}

		private static void CreateInitialClient(string elasticUri)
		{
			var uri = new Uri(elasticUri);
			var connectionSettings = new ConnectionSettings(uri);
			client = new ElasticClient(connectionSettings);
		}
	}
}

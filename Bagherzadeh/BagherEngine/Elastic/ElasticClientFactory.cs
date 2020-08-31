using System;

using Nest;

namespace BagherEngine.Elastic
{
	internal class ElasticClientFactory
	{
		private const string ElasticUri = "http://localhost:9200";

		private static IElasticClient client = CreateInitialClient();

		private static IElasticClient CreateInitialClient()
		{
			var uri = new Uri(ElasticUri);
			var connectionSettings = new ConnectionSettings(uri);
			return new ElasticClient(connectionSettings);
		}

		public static IElasticClient CreateElasticClient()
		{
			return client;
		}
	}
}

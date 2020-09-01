// Standard
using System;

// Elastic
using Nest;

namespace BagherMusic.Core.Elastic
{
	internal class ElasticClientFactory
	{
		private static string Uri;

		private static IElasticClient client;

		public static void CreateInitialClient(string elasticUri)
		{
			Uri = elasticUri;
			var uri = new Uri(Uri);
			var connectionSettings = new ConnectionSettings(uri);
			client = new ElasticClient(connectionSettings);
		}

		public static IElasticClient GetInstance()
		{
			return client;
		}
	}
}

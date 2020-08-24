using System;

using Nest;

namespace BagherEngine.Elastic
{
    internal static class ElasticClientFactory
    {
        private static IElasticClient client = CreateInitialClient();

        private static IElasticClient CreateInitialClient()
        {
            var uri = new Uri("http://localhost:9200");
            var connectionSettings = new ConnectionSettings(uri);
            return new ElasticClient(connectionSettings);
        }

        public static IElasticClient CreateElasticClient()
        {
            return client;
        }
    }
}

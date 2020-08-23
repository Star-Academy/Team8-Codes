using System;

using BagherEngine.Models;

using Nest;

namespace BagherEngine.Elastic
{
    internal class IndexDefiner
    {
        private readonly IElasticClient client;

        public IndexDefiner()
        {
            client = ElasticClientFactory.CreateElasticClient();
        }

        public void CreateIndex(string index)
        {
            var response = client.Indices.Create(index, s => s
                .Map<Document>(CreateMapping));
        }

        private ITypeMapping CreateMapping(TypeMappingDescriptor<Document> mappingDescriptor)
        {
            return mappingDescriptor
                .Properties(pr => pr.AddContentFieldMapping());
        }
    }
}

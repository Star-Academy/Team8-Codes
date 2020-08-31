using BagherEngine.Models;

using Nest;

namespace BagherEngine.Elastic
{
    internal static class FieldsDefiner
    {
        public static PropertiesDescriptor<Document> AddContentFieldMapping(this PropertiesDescriptor<Document> propertiesDescriptor)
        {
            return propertiesDescriptor
                .Text(t => t
                    .Name(n => n.Content)
                );
        }
    }
}

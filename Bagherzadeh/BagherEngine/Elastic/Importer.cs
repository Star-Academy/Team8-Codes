using System.Collections.Generic;

using Nest;

namespace BagherEngine.Elastic
{
	internal class Importer<T> where T : class
	{
		private readonly IElasticClient client = ElasticClientFactory.CreateElasticClient();

		public void Import(IEnumerable<T> documents, string index)
		{
			var bulk = CreateBulk(documents, index);
			client.Bulk(bulk);
		}

		public void Import(IEnumerable<T> documents, string index, List<string> ids)
		{
			var bulk = CreateBulk(documents, index, ids);
			client.Bulk(bulk);
		}

		private BulkDescriptor CreateBulk(IEnumerable<T> documents, string index)
		{
			var bulkDescriptor = new BulkDescriptor();
			foreach (var document in documents)
			{
				bulkDescriptor.Index<T>(x => x
					.Index(index)
					.Document(document)
				);
			}
			return bulkDescriptor;
		}

		private BulkDescriptor CreateBulk(IEnumerable<T> documents, string index, List<string> ids)
		{
			var bulkDescriptor = new BulkDescriptor();
			int idx = 0;
			bulkDescriptor.IndexMany(documents, (descriptor, s) => descriptor.Index(index).Id(ids[idx++]));
			return bulkDescriptor;
		}
	}
}

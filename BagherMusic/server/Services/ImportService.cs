// Standard
using System;
using System.Collections.Generic;

using BagherEngine.Utils;

// Internal
using BagherMusic.Core.Elastic;
using BagherMusic.Models;

// Microsoft
using Microsoft.Extensions.Configuration;

// Elastic
using Nest;

namespace BagherMusic.Services
{
	internal class ImportService : IImportService
	{
		private IElasticClient client;

		private bool running = false;
		private IConfiguration _config;

		private Dictionary<Type, string> IndexNames = new Dictionary<Type, string>();

		public ImportService(IConfiguration config)
		{
			_config = config;
		}

		private void RunService()
		{
			Console.WriteLine("Attempting to run import service...");
			ElasticClientFactory.CreateInitialClient(_config["SearchService:ElasticServerUri"]);
			client = ElasticClientFactory.GetInstance();
			IndexNames[typeof(Music)] = _config["SearchService:SearchOptions:IndexNames:Music"];
			IndexNames[typeof(Artist)] = _config["SearchService:SearchOptions:IndexNames:Artist"];
			Console.WriteLine("[SUCCESS] Run import service");
			running = true;
		}

		public int Import<T, G>(string resourcesPath)
		where T : IComparable
		where G : IEntity<T>
		{
			if (!running)
				RunService();

			var bulk = CreateBulk<T, G>(FileHandler.GetEntitiesFromFolder<T, G>(resourcesPath));
			var response = client.Bulk(bulk);

			Validator.Validate(response);

			return response.Items.Count;
		}

		private BulkDescriptor CreateBulk<T, G>(IEnumerable<G> entities)
		where T : IComparable
		where G : IEntity<T>
		{
			var bulkDescriptor = new BulkDescriptor();
			bulkDescriptor.IndexMany<G>(entities, (descriptor, s) => descriptor.Index(IndexNames[typeof(G)]).Id(s.Id.ToString()));
			return bulkDescriptor;
		}
	}
}

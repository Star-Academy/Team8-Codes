using System;
using System.Text.Json;

using BagherMusic.Models;

using Microsoft.Extensions.Configuration;

using Nest;

namespace BagherMusic.Services
{
	public class ElasticArtistService : ElasticService<int, Artist>
	{
		public ElasticArtistService(IConfiguration config, IElasticClientService clientService) : base(config, clientService)
		{
			Console.WriteLine("Attempting to run artist service...");

			indexName = config["ElasticService:Options:IndexNames:Artist"];
			searchFields = JsonSerializer.Deserialize<string[]>(config["ElasticService:Options:SearchFields:Artist"]);

			Console.WriteLine("[SUCCESS] Run artist service");
		}
	}
}

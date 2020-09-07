// Standard
using System;
using System.Text.Json;

// Internal
using BagherMusic.Models;

// Microsoft
using Microsoft.Extensions.Configuration;

namespace BagherMusic.Services
{
	public class ElasticMusicService : ElasticService<int, Music>
	{
		public ElasticMusicService(IConfiguration config, IElasticClientService clientService) : base(config, clientService)
		{
			Console.WriteLine("Attempting to run music service...");

			indexName = config["ElasticService:Options:IndexNames:Music"];
			searchFields = JsonSerializer.Deserialize<string[]>(config["ElasticService:Options:SearchFields:Music"]);
			foreignFields = JsonSerializer.Deserialize<string[]>(config["ElasticService:Options:ForeignFields:Music"]);

			Console.WriteLine("[SUCCESS] Run music service");
		}
	}
}

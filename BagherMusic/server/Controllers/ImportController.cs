// Standard
using System;

// Microsoft
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// Internal
using BagherMusic.Models;
using BagherMusic.Services;

namespace BagherMusic.Controllers
{
	[EnableCors("ImportOrigins")]
	[ApiController]
	[Route("api/[controller]")]
	public class ImportController : ControllerBase
	{
		private readonly IElasticService<int, Artist> artistService;
		private readonly IElasticService<int, Music> musicService;

		public ImportController(IElasticService<int, Artist> artistService, IElasticService<int, Music> musicService)
		{
			this.artistService = artistService;
			this.musicService = musicService;
		}

		[HttpPost("music")]
		public IActionResult PostMusics([FromBody] string resourcesPath)
		{
			return PostEntities<int, Music>(resourcesPath, musicService);
		}

		[HttpPost("artist")]
		public IActionResult PostArtists([FromBody] string resourcesPath)
		{
			return PostEntities<int, Artist>(resourcesPath, artistService);
		}

		private IActionResult PostEntities<T, G>(string resourcesPath, IElasticService<T, G> service)
		where G : IEntity<T>
		{
			try
			{
				var count = service.Import(resourcesPath);
				return Ok($"Imported {count} entities");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}

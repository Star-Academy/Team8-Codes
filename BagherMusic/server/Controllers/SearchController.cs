// Standard
using System;
using System.Diagnostics;

// Microsoft
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// Internal
using BagherMusic.Core.QuerySystem;
using BagherMusic.Core.Structures;
using BagherMusic.Models;
using BagherMusic.Services;

namespace BagherMusic.Controllers
{
	[EnableCors("SearchOrigins")]
	[Route("api/[controller]")]
	[ApiController]
	public class SearchController : ControllerBase
	{
		private readonly IElasticService<int, Artist> artistService;
		private readonly IElasticService<int, Music> musicService;

		public SearchController(IElasticService<int, Artist> artistService, IElasticService<int, Music> musicService)
		{
			this.artistService = artistService;
			this.musicService = musicService;
		}

		[HttpGet("music")]
		public IActionResult GetMusicSearchResults(string query, int pageIndex = 0)
		{
			return GetSearchResults<int, Music>(query, pageIndex, musicService);
		}

		[HttpGet("artist")]
		public IActionResult GetArtistSearchResults(string query, int pageIndex = 0)
		{
			return GetSearchResults<int, Artist>(query, pageIndex, artistService);
		}

		private IActionResult GetSearchResults<T, G>(
			string query,
			int pageIndex,
			IElasticService<T, G> service)
		where G : IEntity<T>
		{
			try
			{
				var watch = Stopwatch.StartNew();
				var set = service.GetSearchResults(new Query(query), pageIndex);
				watch.Stop();
				return Ok(new ResultSet<G>(watch.ElapsedMilliseconds, set.Count, set));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}

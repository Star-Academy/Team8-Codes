using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

using BagherMusic.Elastic;
using BagherMusic.Models;
using BagherMusic.QuerySystem;
using BagherMusic.Structures;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace BagherMusic.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SearchController : ControllerBase
	{
		private static SearchEngine engine = SearchEngine.GetInstance();
		private readonly ILogger<SearchController> _logger;

		public SearchController(ILogger<SearchController> logger)
		{
			_logger = logger;
		}

		/*
			api/search/music?query={query}&pageIndex={pageIndex}
		*/
		[HttpGet("music")]
		public IActionResult GetMusicSearchResults(string query, int pageIndex)
		{
			try
			{
				var watch = Stopwatch.StartNew();
				var set = engine.GetSearchResults<Music>(new Query(query), pageIndex);
				watch.Stop();
				return Ok(new ResultSet<Music>(watch.ElapsedMilliseconds, set.Count, set));
			}
			catch (Exception e)
			{
				return new ObjectResult(
					new { message = e.Message, StatusCode = 400, currentDate = DateTime.Now }
				);
			}
		}

		/*
			api/search/artist?query={query}
		*/
		[HttpGet("artist")]
		public IActionResult GetArtistSearchResults(string query, int pageIndex)
		{
			try
			{
				var watch = Stopwatch.StartNew();
				var set = engine.GetSearchResults<Artist>(new Query(query), pageIndex);
				watch.Stop();
				return Ok(new ResultSet<Artist>(watch.ElapsedMilliseconds, set.Count, set));
			}
			catch (Exception e)
			{
				return new ObjectResult(
					new { message = e.Message, StatusCode = 400, currentDate = DateTime.Now }
				);
			}
		}
	}
}

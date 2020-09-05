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

using Microsoft.AspNetCore.Cors;

namespace BagherMusic.Controllers
{
	// [EnableCors("BagherMusicSearch")]
	[EnableCors("SearchOrigins")]
	[Route("api/[controller]")]
	[ApiController]
	public class SearchController : ControllerBase
	{
		private readonly ISearchEngineService searchService;

		public SearchController(ISearchEngineService searchService)
		{
			this.searchService = searchService;
		}

		/*
			api/search/music?query={query}&pageIndex={pageIndex}
		*/
		[HttpGet("music")]
		public IActionResult GetMusicSearchResults(string query, int pageIndex = 0)
		{
			try
			{
				var watch = Stopwatch.StartNew();
				var set = searchService.GetSearchResults<Music>(new Query(query), pageIndex);
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
		public IActionResult GetArtistSearchResults(string query, int pageIndex = 0)
		{
			try
			{
				var watch = Stopwatch.StartNew();
				var set = searchService.GetSearchResults<Artist>(new Query(query), pageIndex);
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

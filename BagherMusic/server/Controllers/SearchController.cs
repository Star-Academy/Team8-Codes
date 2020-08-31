using System;
using System.Collections.Generic;
using System.Text.Json;

using BagherMusic.Models;
using BagherMusic.Structures;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BagherMusic.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SearchController : ControllerBase
	{
		private readonly ILogger<SearchController> _logger;

		public SearchController(ILogger<SearchController> logger)
		{
			_logger = logger;
		}

		/*
			api/search/music?query={query}
		*/
		[HttpGet("music")]
		public IActionResult GetMusicSearchResults(string query)
		{
			return Ok(new ResultSet<Music>(0.01, 1, new HashSet<Music> { new Music(0, query) }));
		}

		/*
			api/search/artist?query={query}
		*/
		[HttpGet("artist")]
		public IActionResult GetArtistSearchResults(string query)
		{
			return Ok(new ResultSet<Artist>(0.01, 1, new HashSet<Artist> { new Artist(0, query) }));
		}
	}
}

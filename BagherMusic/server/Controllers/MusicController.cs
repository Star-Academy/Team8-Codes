using System;
using System.Collections.Generic;
using System.Text.Json;

using BagherMusic.Elastic;
using BagherMusic.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BagherMusic.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MusicController : ControllerBase
	{
		private static SearchEngine engine = SearchEngine.GetInstance();
		private readonly ILogger<SearchController> _logger;

		public MusicController(ILogger<SearchController> logger)
		{
			_logger = logger;
		}

		/*
			api/music/{id}
		*/
		[HttpGet("{id}")]
		public IActionResult GetMusic(int id)
		{
			try
			{
				return Ok(engine.GetEntity<int, Music>(id));
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

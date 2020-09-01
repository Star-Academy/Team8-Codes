using System;
using System.Collections.Generic;
using System.Text.Json;

using BagherMusic.Elastic;
using BagherMusic.Models;
using BagherMusic.Structures;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BagherMusic.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ArtistController : ControllerBase
	{
		private static SearchEngine engine = SearchEngine.GetInstance();
		private readonly ILogger<ArtistController> _logger;

		public ArtistController(ILogger<ArtistController> logger)
		{
			_logger = logger;
		}

		/*
			api/artist/{id}
		*/
		[HttpGet("{id}")]
		public IActionResult GetArtist(int id)
		{
			try
			{
				return Ok(engine.GetEntity<int, Artist>(id));
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

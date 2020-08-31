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
	public class MusicController : ControllerBase
	{
		private readonly ILogger<SearchController> _logger;

		public MusicController(ILogger<SearchController> logger)
		{
			_logger = logger;
		}

		/*
			api/music/{id}
		*/
		[HttpGet("{id}")]
		public IActionResult GetSearchMusic(int id)
		{
			return Ok(new Music(id, $"music_{id}"));
		}
	}
}

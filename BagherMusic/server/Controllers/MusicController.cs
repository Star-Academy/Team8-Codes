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
	[EnableCors("EntitiesOrigins")]
	[ApiController]
	[Route("api/[controller]")]
	public class MusicController : ControllerBase
	{
		private readonly ISearchEngineService searchService;

		public MusicController(ISearchEngineService searchService)
		{
			this.searchService = searchService;
		}

		/*
			api/music/{id}
		*/
		[HttpGet("{id}")]
		public IActionResult GetMusic(int id)
		{
			try
			{
				return Ok(searchService.GetEntity<int, Music>(id));
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

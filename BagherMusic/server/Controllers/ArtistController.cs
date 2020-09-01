// Standard
using System;

// Microsoft
using Microsoft.AspNetCore.Mvc;

// Internal
using BagherMusic.Models;
using BagherMusic.Services;

namespace BagherMusic.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ArtistController : ControllerBase
	{
		private readonly ISearchEngineService searchService;

		public ArtistController(ISearchEngineService searchService)
		{
			this.searchService = searchService;
		}

		/*
			api/artist/{id}
		*/
		[HttpGet("{id}")]
		public IActionResult GetArtist(int id)
		{
			try
			{
				return Ok(searchService.GetEntity<int, Artist>(id));
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

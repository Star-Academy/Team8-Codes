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
	public class ArtistController : ControllerBase
	{
		private readonly IElasticService<int, Artist> artistService;

		public ArtistController(IElasticService<int, Artist> artistService)
		{
			this.artistService = artistService;
		}

		[HttpGet("{id}")]
		public IActionResult GetArtist(int id)
		{
			try
			{
				return Ok(artistService.GetEntity(id));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}

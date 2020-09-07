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
		private readonly IElasticService<int, Music> musicService;

		public MusicController(IElasticService<int, Music> musicService)
		{
			this.musicService = musicService;
		}

		[HttpGet("{id}")]
		public IActionResult GetMusic(int id)
		{
			try
			{
				return Ok(musicService.GetEntity(id));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("by-artist/{id}")]
		public IActionResult GetMusicsByArtist(int id)
		{
			try
			{
				return Ok(musicService.GetEntities(id));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}

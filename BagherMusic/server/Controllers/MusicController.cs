// Standard
using System;

// Microsoft
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// Internal
using System.Collections.Generic;

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
			return GetResult<Music>((args) => musicService.GetEntity((int) args[0]), id);
		}

		[HttpGet("by-artist/{id}")]
		public IActionResult GetMusicsByArtist(int id)
		{
			return GetResult<HashSet<Music>>((args) => musicService.GetEntities(args[0]), id);
		}

		[HttpGet("lucky")]
		public IActionResult GetRandomMusic()
		{
			return GetResult<Music>((args) => musicService.GetRandomEntity(), null);
		}

		private IActionResult GetResult<T>(Func<object[], T> callback, params object[] args)
		{
			try
			{
				return Ok(callback(args));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}

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
	public class ImportController : ControllerBase
	{
		private readonly IImportService importService;

		public ImportController(IImportService importService)
		{
			this.importService = importService;
		}

		/*
			api/import/music
		*/
		[HttpPost("music")]
		public IActionResult PostMusics([FromBody] string resourcesPath)
		{
			try
			{
				var count = importService.Import<int, Music>(resourcesPath);
				return Ok($"Successfully imported {count} music into the database.");
			}
			catch (Exception e)
			{
				return new ObjectResult(
					new { message = e.Message, StatusCode = 400, currentDate = DateTime.Now }
				);
			}
		}

		/*
			api/import/artist
		*/
		[HttpPost("artist")]
		public IActionResult PostArtists([FromBody] string resourcesPath)
		{
			try
			{
				var count = importService.Import<int, Artist>(resourcesPath);
				return Ok($"Successfully imported {count} artist into the database.");
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

// Standard
using System;
using System.Collections.Generic;

// Internal
using BagherMusic.Core.QuerySystem;
using BagherMusic.Models;

namespace BagherMusic.Services
{
	public interface IImportService
	{
		int Import<T, G>(string resourcesPath)
		where T : IComparable
		where G : IEntity<T>;
	}
}

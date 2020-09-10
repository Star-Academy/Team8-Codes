// Standard
using System;
using System.Collections.Generic;

// Internal
using BagherMusic.Core.QuerySystem;
using BagherMusic.Models;

namespace BagherMusic.Services
{
	public interface IElasticService<T, G> where G : IEntity<T>
	{
		G GetEntity(T id);

		HashSet<G> GetSearchResults(Query query, int pageIndex);

		int Import(string resourcesPath);
	}
}

// Standard
using System;
using System.Collections.Generic;

// Internal
using BagherMusic.Core.QuerySystem;
using BagherMusic.Models;

namespace BagherMusic.Services
{
	public interface ISearchEngineService
	{
		G GetEntity<T, G>(T id)
		where T : IComparable
		where G : IEntity<T>;

		HashSet<T> GetSearchResults<T>(Query query, int pageIndex)
		where T : class;
	}
}

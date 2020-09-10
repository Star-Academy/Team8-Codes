// Standard
using System.Collections;
using System.Collections.Generic;

namespace BagherMusic.Core.Structures
{
	public class ResultSet<T>
	{
		public ResultSet(double delay, int count, HashSet<T> hits)
		{
			Delay = delay;
			Count = count;
			Hits = hits;
		}

		public double Delay { get; }
		public int Count { get; }
		public HashSet<T> Hits { get; }

		public override string ToString()
		{
			return $"ResultSet(Delay: {Delay}, Count: {Count}, HitsCount: {Hits.Count})";
		}
	}
}

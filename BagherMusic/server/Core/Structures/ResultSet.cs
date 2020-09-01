// Standard
using System.Collections;
using System.Collections.Generic;

namespace BagherMusic.Core.Structures
{
	public class ResultSet<T> : IEnumerable<T>
	{
		public ResultSet(double delay, int count, HashSet<T> hits)
		{
			Delay = delay;
			Count = count;
			Hits = hits;
		}

		public double Delay { get; set; }
		public int Count { get; set; }
		public HashSet<T> Hits { get; set; }

		public IEnumerator<T> GetEnumerator()
		{
			return Hits.GetEnumerator();
		}

		public override string ToString()
		{
			return $"Delay: {Delay}; Count: {Count}; HitsCount: {Hits.Count}";
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Hits.GetEnumerator();
		}
	}
}

using System;

namespace BagherMusic.Models
{
	public abstract class IEntity<T> : IComparable where T : IComparable
	{
		T Id { get; set; }

		public override bool Equals(object obj)
		{
			return obj is IEntity<T> other && Id.Equals(other.Id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		int IComparable.CompareTo(object obj)
		{
			if (obj is IEntity<T> that)
				return Id.CompareTo(that.Id);
			throw new ArgumentException($"Object must be an Entity!");
		}
	}
}

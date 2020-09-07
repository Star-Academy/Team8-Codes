// Standard
using System.Text.Json.Serialization;

namespace BagherMusic.Models
{
	public abstract class IEntity<T>
	{
		[JsonPropertyName("id")]
		public T Id { get; set; }

		public override bool Equals(object obj)
		{
			return obj is IEntity<T> other && Id.Equals(other.Id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}

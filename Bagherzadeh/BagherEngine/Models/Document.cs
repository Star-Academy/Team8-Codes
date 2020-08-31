using Nest;

namespace BagherEngine.Models
{
	public class Document
	{
		[Ignore]
		public string Id { get; set; }

		public string Content { get; set; }

		public Document(string id, string content)
		{
			Id = id;
			Content = content;
		}

		public override bool Equals(object obj)
		{
			return obj is Document other && Id == other.Id;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override string ToString()
		{
			return $"Document({Id})";
		}
	}
}

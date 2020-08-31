namespace BagherMusic.Models
{
	public class Artist : IEntity<int>
	{
		public Artist(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
}

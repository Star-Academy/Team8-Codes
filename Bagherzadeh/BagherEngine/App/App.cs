namespace BagherEngine.App
{
	public class App
	{
		private const string ResourcesDirectory = "Resources/Documents";

		public static void Main(string[] args)
		{
			var app = new SearchEngineApp(ResourcesDirectory);
			app.Run();
		}
	}
}

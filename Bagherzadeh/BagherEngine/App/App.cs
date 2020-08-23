namespace BagherEngine.App
{
    public class App
    {
        public static void Main(string[] args)
        {
            var app = new SearchEngineApp("Resources/Documents");
            app.Run();
        }
    }
}

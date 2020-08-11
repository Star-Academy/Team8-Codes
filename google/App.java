import main.src.core.apps.SearchEngineApp;

public class App {

    final static String INPUT_FILES_DIRECTORY = "main/resources/input";

    public static void main(String[] args) {
        SearchEngineApp app = new SearchEngineApp(INPUT_FILES_DIRECTORY);
        app.run();
    }
}
import main.src.core.engine.SearchEngineApp;

public class App {

    final static String INPUT_FILES_DIRECTORY = "google/main/resources/input";

    public static void main(String[] args) {
        SearchEngineApp engine = new SearchEngineApp(INPUT_FILES_DIRECTORY);
        engine.handleCommands();
    }
}
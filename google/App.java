import main.src.core.engine.SearchEngineApp;

public class App {
    public static void main(String[] args) {
        SearchEngineApp engine = new SearchEngineApp("google/main/resources/input");
        engine.handleCommands();
    }
}
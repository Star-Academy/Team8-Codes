import java.util.*;
import java.io.IOException;
import java.lang.IllegalArgumentException;

public class SearchEngineApp {

    public static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        InvertedIndex index = new InvertedIndex("../resources/input");

        handleCommands();
    }

    private static void handleCommands() {
        String input, command, arguments;
        int firstSpaceIndex;

        while (true) {
            input = scanner.nextLine();
            firstSpaceIndex = input.indexOf(' ');
            command = input.substring(0, firstSpaceIndex);
            arguments = input.substring(firstSpaceIndex + 1);

            if (command.equals("search"))
                search(arguments);
            else if (command.equals("view"))
                view(arguments);
            else if (command.equals("help"))
                help();
            else if (command.equals("exit"))
                break;
            else
                System.out.println(String.format("\'%s\' is not recognized as an internal or external command."));
        }
    }

    private static void search(String arguments) {
        try {
            HashSet<Document> results = Engine.runQuery(new Query(arguments), index);
            System.out.println(results);
        } catch (IllegalArgumentException e) {
            System.out.println(e.getMessage());
        }
    }

    private static void view(String arguments) {
        try {
            System.out.println(FileHandler.loadFile("../resources/input/" + arguments));
        } catch (IOException e) {
            System.out.println(e.getMessage());
        }
    }

    private static void help() {
        System.out.println("search <terms>\nterm  : AND feature\n+term : OR  feature\n-term : EXC feature");
        System.out.println("help\ndisplay commands");
        System.out.println("view <docId>");
    }
}
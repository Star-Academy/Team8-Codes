import java.util.*;
import java.lang.IllegalArgumentException;

public class App {

    public static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        String command;
        InvertedIndex index = new InvertedIndex("../resources/input");
        do {
            command = scanner.nextLine();
            if (command.equals("search")) {
                System.out.print("Enter search query:");
                command = scanner.nextLine();
                try {
                    HashSet<Document> results = Engine.runQuery(new Query(command), index);
                    System.out.println(results);
                } catch (IllegalArgumentException e) {
                    System.out.println(e.getMessage());
                }
                command = "";
            }
        } while (!command.equals("exit"));
    }
}
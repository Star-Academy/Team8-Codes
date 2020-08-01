import java.util.*;

public class App {

    public static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        String command, query;
        InvertedIndex indexer = new InvertedIndex("../resources/input");
        do {
            command = scanner.nextLine();
            if (command.equals("search")) {
                System.out.println("Enter search query:");
                query = scanner.nextLine();
                ArrayList<Document> results = indexer.getIndex().get(new Token(query));
                System.out.println(results);
            }
        } while (!command.equals("exit"));
    }
}
import java.util.*;

public class Tester {
    public static void main(String[] args) {
        // String content = FileHandler.loadFile("./resources/input/test.txt");
        // System.out.println(content);

        // ArrayList<String> files =
        // FileHandler.loadFileNamesFromFolder("../resources/input");
        // System.out.println(files);

        // ArrayList<Document> files = FileHandler.loadFolder("../resources/input");
        // System.out.println(files);

        InvertedIndex indexer = new InvertedIndex("../resources/input");
        for (Token key : indexer.getIndex().keySet()) {
            System.out.println(key);
            System.out.println(indexer.getIndex().get(key) + "\n");
        }

    }
}
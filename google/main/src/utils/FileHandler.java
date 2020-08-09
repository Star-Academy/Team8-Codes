package main.src.utils;

import main.src.core.structures.Document;
import main.src.core.structures.Token;

import java.util.*;
import java.io.*;
import java.util.regex.*;


public class FileHandler {

    private static Pattern tokenPattern = Pattern.compile("[a-zA-Z0-9]+");

    public static HashSet<Token> getDocumentTokens(Document doc){
        HashSet<Token> tokens = new HashSet<>();
        File file = new File(doc.getPath());
        try(Scanner scanner = new Scanner(file)){
            while (scanner.hasNext()){
                String next = scanner.next();
                if(tokenPattern.matcher(next).matches())
                    tokens.add(new Token(next));
            }
            scanner.close();
            return tokens;
        } catch(IOException error){
            error.printStackTrace();
            tokens.add(new Token(error.toString()));
            return tokens;
        }
    }

    public static ArrayList<Document> getFolderDocuments(String folderDirectory){
        final File folder = new File(folderDirectory);
        ArrayList<Document> documents = new ArrayList<>();
        for (File fileEntry : folder.listFiles())
            if (!fileEntry.isDirectory())
                documents.add(new Document(fileEntry.getName(), folderDirectory + '/' + fileEntry.getName()));
        return documents;
    }

    public static String getFileContent(String fileName) {
        try (BufferedReader reader = new BufferedReader(new FileReader(new File(fileName)))) {
            StringBuilder contentBuilder = new StringBuilder();
            String line;
            while ((line = reader.readLine()) != null)
                contentBuilder.append(line + "\n");
            reader.close();
            return contentBuilder.toString().substring(0, contentBuilder.length() - 1);
        } catch (IOException e) {
            System.out.println(e.getMessage());
            return null;
        }
    }
}
package main.src.utils;

import main.src.core.structures.Document;
import main.src.core.structures.Token;

import java.util.*;
import java.io.*;
import java.util.regex.*;


public class FileHandler implements FileHandlerInterface{

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

    public static String getDocumentContent(Document doc) {
        return FileHandlerInterface.getFileContent(doc.getPath());
    }

    public static String getFileContent(String filePath) {
        return FileHandlerInterface.getFileContent(filePath);
    }
}
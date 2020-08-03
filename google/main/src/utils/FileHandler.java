package main.src.utils;

import main.src.core.structures.Document;

import java.util.ArrayList;
import java.io.*;

public class FileHandler {

    public static String loadFile(String fileName) {
        try (BufferedReader reader = new BufferedReader(new FileReader(new File(fileName)))) {
            StringBuilder contentBuilder = new StringBuilder();
            String line;
            while ((line = reader.readLine()) != null)
                contentBuilder.append(line + "\n");
            reader.close();
            return contentBuilder.toString();
        } catch (IOException e) {
            System.out.println(e.getMessage());
            return null;
        }
    }

    private static ArrayList<String> getFileNamesFromFolder(String folderName) {
        final File folder = new File(folderName);
        ArrayList<String> output = new ArrayList<>();
        for (File fileEntry : folder.listFiles()) {
            if (!fileEntry.isDirectory())
                output.add(fileEntry.getName());
        }
        return output;
    }

    public static ArrayList<Document> loadFolder(String folderName) {
        ArrayList<String> fileNames = getFileNamesFromFolder(folderName);
        ArrayList<Document> documents = new ArrayList<>();
        for (String fileName : fileNames) {
            String path = folderName + '/' + fileName;
            documents.add(new Document(fileName, path));
        }
        return documents;
    }

}
package main.src.utils;

import java.io.*;


public interface FileHandlerInterface {

    public static String getFileContent(String fileName){
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
    };

}
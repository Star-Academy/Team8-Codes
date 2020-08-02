package main.src.core.engine;

import main.src.core.structures.Document;
import main.src.core.structures.Token;
import main.src.utils.FileHandler;
import main.src.utils.Prettifier;

import java.util.*;
import java.io.IOException;
import java.lang.IllegalArgumentException;


public class SearchEngineApp {

    private Scanner scanner = new Scanner(System.in);
    private String resourcesDirectory;
    private InvertedIndex index;

    public SearchEngineApp(String resourcesDirectory){
        this.resourcesDirectory = resourcesDirectory;
        this.index = new InvertedIndex(this.resourcesDirectory);
    }

    public void handleCommands() {
        String input, command, arguments;
        int firstSpaceIndex;

        while (true) {
            System.out.print("google> ");
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

    private void search(String arguments) {
        try {
            HashSet<Document> results = Engine.runQuery(new Query(arguments), index);
            System.out.println(Prettifier.prettify(results));
        } catch (IllegalArgumentException e) {
            System.out.println(e.getMessage());
        }
    }

    private void view(String arguments) {
        System.out.println(FileHandler.loadFile(this.resourcesDirectory + "/" + arguments));
    }

    private void help() {
        System.out.println("search <terms>\nterm  : AND feature\n+term : OR  feature\n-term : EXC feature");
        System.out.println("help\ndisplay commands");
        System.out.println("view <docId>");
    }
}
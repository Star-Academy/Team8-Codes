package main.src.core.engine;

import main.src.core.structures.Document;
import main.src.utils.FileHandler;
import main.src.utils.Prettifier;
import main.src.core.query.Query;

import java.util.*;
import java.lang.IllegalArgumentException;


public class SearchEngineApp {

    private Scanner scanner = new Scanner(System.in);
    private String resourcesDirectory;
    private InvertedIndex index;

    public SearchEngineApp(String resourcesDirectory){
        this.resourcesDirectory = resourcesDirectory;
        System.out.print("Indexing...");
        this.index = new InvertedIndex(this.resourcesDirectory);
        System.out.println("DONE!\n");
        System.out.println("Welcome to google! Copyright(c) 2020 v1.0.1");
        help();
    }

    private boolean handleCommand(String command, String arguments){
        if (command.equals("search"))    search(arguments);
        else if (command.equals("view")) view(arguments);
        else if (command.equals("help")) help();
        else if (command.equals("exit")) return false;
        else System.out.println(String.format("\'%s\' is not recognized as an internal or external command."));
        return true;
    }

    public void handleCommands() {
        String input, command, arguments;
        int firstSpaceIndex;
        do {
            System.out.print("google> ");
            input = scanner.nextLine();
            firstSpaceIndex = input.indexOf(' ');
            command = input.substring(0, firstSpaceIndex);
            arguments = input.substring(firstSpaceIndex + 1);
        } while(handleCommand(command, arguments));
    }

    private void search(String arguments) {
        try {
            HashSet<Document> results = Engine.getQueryResults(new Query(arguments), index);
            System.out.println(Prettifier.prettify(results));
        } catch (IllegalArgumentException e) {
            System.out.println(e.getMessage());
        }
    }

    private void view(String arguments) {
        System.out.println(FileHandler.loadFile(this.resourcesDirectory + "/" + arguments));
    }

    private void help() {
        System.out.println("\nsearch <terms>\n- search for terms\n term : AND feature\n+term : OR  feature\n-term : EXC feature");
        System.out.println("\nhelp\n- display commands\n");
        System.out.println("view <docId>\n- view the documents\n");
    }
}
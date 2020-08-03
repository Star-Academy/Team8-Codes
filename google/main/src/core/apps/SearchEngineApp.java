package main.src.core.apps;

import main.src.core.structures.Document;
import main.src.utils.FileHandler;
import main.src.utils.Prettifier;
import main.src.core.query.Query;
import main.src.utils.ConsoleApp;
import main.src.core.engine.InvertedIndex;
import main.src.core.engine.Engine;

import java.util.*;
import java.lang.IllegalArgumentException;


public class SearchEngineApp extends ConsoleApp{

    private static final String APP_NAME = "google";
    private final String YEAR = "2020";
    private final String VERSION = "v0.0.0";
    
    private String resourcesDirectory;
    private InvertedIndex index;

    public void intro(){
        this.sout("Welcome to " + APP_NAME + "! Copyright(c) " + YEAR + " " + VERSION);
    }

    public SearchEngineApp(String resourcesDirectory){
        super();
        this.resourcesDirectory = resourcesDirectory;
        this.index = new InvertedIndex(this.resourcesDirectory);
        this.prompt = APP_NAME + "> ";
    }

    public boolean handleCommand(String command, String arguments){
        if (command.equals("search"))    this.search(arguments);
        else if (command.equals("view")) this.view(arguments);
        else if (command.equals("help")) this.help();
        else if (command.equals("exit")) return false;
        else this.sout(String.format("\'%s\' is not recognized as an internal or external command.", command));
        return true;
    }

    private String getSearchResults(String arguments){
        HashSet<Document> results = Engine.getQueryResults(new Query(arguments), this.index);
        if(results.isEmpty())
            return "No results found!";
        return Prettifier.prettify(results);
    }

    public void search(String arguments) {
        if(arguments == ""){
            this.sout("No keywords passed!");
            return;
        }
        try {
            this.sout(this.getSearchResults(arguments));
        } catch (IllegalArgumentException e) {
            this.sout(e.getMessage());
        }
    }

    public void view(String arguments) {
        if(arguments == ""){
            this.sout("No documentId passed!");
            return;
        }
        this.sout(FileHandler.loadFile(this.resourcesDirectory + "/" + arguments));
    }

    public void help() {
        this.sout("search <terms> -- view <documentId> -- help");
    }

    private void sout(String output){
        System.out.println("\n" + output + "\n");
    }

}
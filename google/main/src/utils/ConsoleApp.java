package main.src.utils;

import java.util.*;


public abstract class ConsoleApp {

    protected String prompt;
    protected Scanner scanner;

    private String command;
    private String arguments;
    private int firstSpaceIndex;
    

    public abstract void intro();

    public abstract void help();

    protected abstract boolean handleCommand(String command, String arguments);

    public ConsoleApp(){
        this.intro();
        this.help();
        this.scanner = new Scanner(System.in);
        this.prompt = "";
    }

    private void decomposeInput(String input){
        this.firstSpaceIndex = input.indexOf(' ');
        if(firstSpaceIndex < 0){
            this.firstSpaceIndex = input.length();
            this.command = input;
            this.arguments = "";
        }
        else{
            this.command = input.substring(0, this.firstSpaceIndex).trim();
            this.arguments = input.substring(this.firstSpaceIndex + 1).trim();
        }
    }

    public void run() {
        String input;
        do {
            System.out.print(this.prompt);
            input = scanner.nextLine().trim();
            this.decomposeInput(input);
        } while(handleCommand(this.command, this.arguments));
    }
}
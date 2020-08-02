package main.src.core.engine;

import main.src.core.structures.Document;
import main.src.core.structures.Token;

import java.util.*;
import java.lang.IllegalArgumentException;


public class Engine {

    public static HashSet<Document> runAndQuery(ArrayList<Token> andTerms, InvertedIndex index){
        HashSet<Document> results = new HashSet<>();
        if(!andTerms.isEmpty()){
            results.addAll(index.getDocumentsOfToken(andTerms.get(0)));
            for(int idx = 1; idx < andTerms.size(); idx++){
                results.retainAll(index.getDocumentsOfToken(andTerms.get(idx)));
            }
        }
        return results;
    }

    public static HashSet<Document> runOrQuery(ArrayList<Token> orTerms, InvertedIndex index){
        HashSet<Document> results = new HashSet<>();
        for(Token token : orTerms)
            results.addAll(index.getDocumentsOfToken(token));
        return results;
    }
    
    public static HashSet<Document> runExcQuery(ArrayList<Token> excTerms, InvertedIndex index){
        HashSet<Document> results = new HashSet<>();
        for(Token token : excTerms)
            results.addAll(index.getDocumentsOfToken(token));
        return results;
    }

    public static HashSet<Document> runQuery(Query query, InvertedIndex index) throws IllegalArgumentException{
        HashSet<Document> andResults = runAndQuery(query.andTerms, index);
        HashSet<Document> orResults = runOrQuery(query.orTerms, index);
        HashSet<Document> excResults = runExcQuery(query.excTerms, index);

        HashSet <Document> results = new HashSet<>();

        if(query.andTerms.isEmpty() && query.orTerms.isEmpty()){
            throw new IllegalArgumentException("Cannot search the whole internet!");
        }

        results.addAll(andResults);
        results.addAll(orResults);
        results.removeAll(excResults);

        return results;
    }

}
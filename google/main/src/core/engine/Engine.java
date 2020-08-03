package main.src.core.engine;

import main.src.core.structures.Document;
import main.src.core.structures.Token;

import java.util.*;
import java.lang.IllegalArgumentException;


public class Engine {

    private static HashSet<Document> getAndQueryResults(ArrayList<Token> andTerms, InvertedIndex index){
        HashSet<Document> results = new HashSet<>();
        if(!andTerms.isEmpty()){
            results.addAll(index.getDocumentsOfToken(andTerms.get(0)));
            for(int idx = 1; idx < andTerms.size(); idx++){
                results.retainAll(index.getDocumentsOfToken(andTerms.get(idx)));
            }
        }
        return results;
    }

    private static HashSet<Document> getOrQueryResults(ArrayList<Token> orTerms, InvertedIndex index){
        HashSet<Document> results = new HashSet<>();
        for(Token token : orTerms)
            results.addAll(index.getDocumentsOfToken(token));
        return results;
    }
    
    private static HashSet<Document> getExcQueryResults(ArrayList<Token> excTerms, InvertedIndex index){
        HashSet<Document> results = new HashSet<>();
        for(Token token : excTerms)
            results.addAll(index.getDocumentsOfToken(token));
        return results;
    }

    private static HashSet<Document> getSubQueriesResults(Query query, InvertedIndex index){
        HashSet <Document> results = new HashSet<>();
        results.addAll(getAndQueryResults(query.andTerms, index));    // + AND results
        results.addAll(getOrQueryResults(query.orTerms, index));      // + OR  results
        results.removeAll(getExcQueryResults(query.excTerms, index)); // - EXC results
        return results;
    }

    public static HashSet<Document> getQueryResults(Query query, InvertedIndex index) throws IllegalArgumentException{
        if(query.andTerms.isEmpty() && query.orTerms.isEmpty()){
            throw new IllegalArgumentException("Cannot search the whole internet!");
        }
        return getSubQueriesResults(query, index);
    }

}
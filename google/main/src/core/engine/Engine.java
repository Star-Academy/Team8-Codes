package main.src.core.engine;

import main.src.core.structures.Document;
import main.src.core.query.Query;

import java.util.*;
import java.lang.IllegalArgumentException;


public class Engine {

    private static HashSet<Document> getSubQueriesResults(Query query, InvertedIndex index){
        HashSet <Document> results = new HashSet<>();
        results.addAll(query.andTerms.getResults(index));     // + AND results
        results.addAll(query.orTerms.getResults(index));      // + OR  results
        results.removeAll(query.excTerms.getResults(index));  // - EXC results
        return results;
    }

    public static HashSet<Document> getQueryResults(Query query, InvertedIndex index) throws IllegalArgumentException{
        if(query.andTerms.isEmpty() && query.orTerms.isEmpty())
            throw new IllegalArgumentException("Cannot search the whole internet!");
        return getSubQueriesResults(query, index);
    }
}
package main.src.core.query;

import java.util.regex.Pattern;
import java.util.*;

import main.src.core.engine.InvertedIndex;
import main.src.core.structures.Document;


public class AndTerms extends Terms{

    private static Pattern pattern = Pattern.compile("( *[^\\+\\-\\w]|^)(\\w+)");
    private static int regexGroupIndex = 2;

    public AndTerms(String expression){
        this.keys = new ArrayList<>();
        this.collect(expression, pattern, regexGroupIndex);
    }

    public HashSet<Document> getResults(InvertedIndex index){
        HashSet<Document> results = new HashSet<>();
        if(!this.keys.isEmpty()){
            results.addAll(index.getDocumentsOfToken(this.keys.get(0)));
            for(int idx = 1; idx < this.keys.size(); idx++)
                results.retainAll(index.getDocumentsOfToken(this.keys.get(idx)));
        }
        return results;
    };

}

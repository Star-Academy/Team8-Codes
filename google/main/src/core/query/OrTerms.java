package main.src.core.query;

import java.util.regex.Pattern;
import java.util.*;

import main.src.core.engine.InvertedIndex;
import main.src.core.structures.Token;
import main.src.core.structures.Document;


public class OrTerms extends Terms{

    private static Pattern pattern = Pattern.compile("\\+(\\w+)");

    public OrTerms(String expression){
        super();
        this.collect(expression, pattern, 1);
    }

    public HashSet<Document> getResults(InvertedIndex index){
        HashSet<Document> results = new HashSet<>();
        for(Token token : this.keys)
            results.addAll(index.getDocumentsOfToken(token));
        return results;
    }
}

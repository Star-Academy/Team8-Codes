package main.src.core.query;

import java.util.regex.Pattern;
import java.util.*;

import main.src.core.engine.IndexInterface;
import main.src.core.structures.Token;
import main.src.core.structures.Document;


public class ExcTerms extends Terms{

    private static Pattern pattern = Pattern.compile("\\-(\\w+)");

    public ExcTerms(String expression){
        super();
        this.collect(expression, pattern, 1);
    }

    public HashSet<Document> getResults(IndexInterface index){
        HashSet<Document> results = new HashSet<>();
        for(Token token : this.keys)
            results.addAll(index.getDocumentsOfToken(token));
        return results;
    }
}

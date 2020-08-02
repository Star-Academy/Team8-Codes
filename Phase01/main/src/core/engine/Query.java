package main.src.core.engine;

import main.src.core.structures.Document;
import main.src.core.structures.Token;

import java.util.*;
import java.util.regex.*;


public class Query {

    ArrayList<Token> andTerms;
    ArrayList<Token> orTerms;
    ArrayList<Token> excTerms;
    String expression;

    public Query(String queryString) {
        this.expression = queryString;
        this.andTerms = new ArrayList<>();
        this.orTerms = new ArrayList<>();
        this.excTerms = new ArrayList<>();
        this.collectTerms();
    }

    private void collectTerms() {
        collectTerms(andTerms, "( *[^\\+\\-\\w]|^)(\\w+)", 2);
        collectTerms(orTerms, "\\+(\\w+)", 1);
        collectTerms(excTerms, "\\-(\\w+)", 1);
    }

    private void collectTerms(ArrayList<Token> termsList, String patternString, int groupIndex) {
        Pattern andPattern = Pattern.compile(patternString);
        Matcher matcher = andPattern.matcher(this.expression);
        while (matcher.find())
            termsList.add(new Token(matcher.group(groupIndex)));
    }

    @Override
    public String toString() {
        return  "Query\n" + 
                "ANDs : " + this.andTerms.toString() + "\n" + 
                "ORs  : " + this.orTerms.toString() + "\n" + 
                "EXCs : " + this.excTerms.toString();
    }

}
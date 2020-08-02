import java.util.*;
import java.util.regex.*;

public class Query {

    ArrayList<Token> andTerms;
    ArrayList<Token> orTerms;
    ArrayList<Token> excludeTerms;

    String expression;

    public Query(String queryString) {
        this.expression = queryString;
        this.andTerms = new ArrayList<>();
        this.orTerms = new ArrayList<>();
        this.excludeTerms = new ArrayList<>();
        this.collectTerms();
    }

    private void collectTerms() {
        collectTerms(andTerms, "[^\\+\\-](\\w+)", 1);
        collectTerms(orTerms, "\\+(\\w+)", 1);
        collectTerms(excludeTerms, "\\-(\\w+)", 1);
    }

    private void collectTerms(ArrayList<Token> termsList, String patternString, int groupIndex) {
        Pattern andPattern = Pattern.compile(patternString);
        Matcher matcher = andPattern.matcher(this.expression);
        while (matcher.find())
            termsList.add(new Token(matcher.group()));
    }

    @Override
    public String toString() {
        return  "Query\n" + 
                "ANDs: " + this.andTerms.toString() + "\n" + 
                "ORs: " + this.orTerms.toString() + "\n" + 
                "EXCs: " + this.excludeTerms.toString();
    }

}
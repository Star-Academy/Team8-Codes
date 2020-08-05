package main.src.core.query;

import java.util.regex.Pattern;
import java.util.regex.Matcher;
import java.util.*;

import main.src.core.engine.InvertedIndex;
import main.src.core.structures.Token;
import main.src.core.structures.Document;

public abstract class Terms {

    protected ArrayList<Token> keys;

    public Terms() {
        this.keys = new ArrayList<>();
    }

    public ArrayList<Token> getKeys() {
        return keys;
    }

    protected void collect(String expression, Pattern pattern, int regexGroupIndex) {
        Matcher matcher = pattern.matcher(expression);
        while (matcher.find())
            this.keys.add(new Token(matcher.group(regexGroupIndex)));
    }

    public boolean isEmpty() {
        return this.keys.isEmpty();
    }

    public abstract HashSet<Document> getResults(InvertedIndex index);
}

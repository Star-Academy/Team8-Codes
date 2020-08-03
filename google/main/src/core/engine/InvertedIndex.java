package main.src.core.engine;

import main.src.core.structures.Document;
import main.src.core.structures.Token;
import main.src.utils.FileHandler;
import main.src.utils.Prettifier;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class InvertedIndex {

    private HashMap<Token, HashSet<Document>> index;

    public InvertedIndex(String folderName) {
        this.index = new HashMap<>();
        this.invert(folderName);
    }

    private HashSet<Token> getTokens(Document doc) {
        HashSet<Token> tokens = new HashSet<>();
        Matcher matcher = Pattern.compile("[a-zA-Z]+").matcher(doc.getContent());
        while (matcher.find())
            tokens.add(new Token(matcher.group()));
        return tokens;
    }

    private void indexDocument(Document doc){
        for (Token token : this.getTokens(doc))
            if (this.index.containsKey(token))
                this.index.get(token).add(doc);
            else
                this.index.put(token, new HashSet<Document>(){{add(doc);}});
    }

    private void indexDocuments(ArrayList<Document> documents){
        for (Document doc: documents)
            indexDocument(doc);
    }

    private void invert(String folderName) {
        ArrayList<Document> documents = FileHandler.loadFolder(folderName);
        indexDocuments(documents);
    }

    public HashSet<Document> getDocumentsOfToken(Token token) {
        HashSet<Document> result = this.index.get(token);
        return result == null ? new HashSet<Document>() : result;
    }

    @Override
    public String toString(){
        return "InvertedIndex\n" + Prettifier.prettify(this.index);
    }

}
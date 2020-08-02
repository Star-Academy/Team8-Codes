package main.src.core.engine;

import main.src.core.structures.Document;
import main.src.core.structures.Token;
import main.src.utils.FileHandler;

import java.util.*;


public class InvertedIndex {

    private HashMap<Token, HashSet<Document>> index;

    public InvertedIndex(String folderName) {
        this.index = new HashMap<>();
        this.invert(folderName);
    }

    private HashSet<Token> tokenized(Document doc) {
        String[] words = doc.getContent().split("\\s+", 0);
        HashSet<Token> output = new HashSet<>();
        for (int i = 0; i < words.length; i++)
            output.add(new Token(words[i]));
        return output;
    }

    private void invert(String folderName) {
        ArrayList<Document> documents = FileHandler.loadFolder(folderName);
        for (Document doc : documents)
            for (Token token : this.tokenized(doc))
                if (this.index.containsKey(token))
                    this.index.get(token).add(doc);
                else
                    this.index.put(token, new HashSet<Document>() {
                        {
                            add(doc);
                        }
                    });
    }

    public HashSet<Document> getDocumentsOfToken(Token token) {
        HashSet<Document> result = this.index.get(token);
        return result == null ? new HashSet<Document>() : result;
    }

}
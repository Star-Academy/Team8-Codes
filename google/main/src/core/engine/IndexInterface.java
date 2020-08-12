package main.src.core.engine;

import main.src.core.structures.Token;
import main.src.core.structures.Document;
import java.util.*;


public interface IndexInterface {

    public HashSet<Document> getDocumentsOfToken(Token token);

}
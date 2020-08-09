package test.src.utils;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.*;
import java.util.HashSet;

import org.junit.Test;

import main.src.core.structures.Document;
import main.src.core.structures.Token;
import main.src.utils.FileHandler;


public class TestFileHandler {

    final public static String RESOURCES_ABSOLUTE_PATH = "D:/projects/internship/codestar/Team8-Codes/google/test/resources/input";

    @Test
    public void testGetDocumentTokens() {
        Document doc = new Document("doc1.txt", RESOURCES_ABSOLUTE_PATH + '/' + "doc1.txt");
        HashSet<Token> expected = new HashSet<>();
        expected.add(new Token("first"));
        expected.add(new Token("second"));
        expected.add(new Token("thidr"));
        HashSet<Token> actual = FileHandler.getDocumentTokens(doc);
        assertEquals(expected, actual);
    }

    @Test
    public void testGetFolderDocuments(){
        ArrayList<Document> expected = new ArrayList<>();
        expected.add(new Document());
        String actual = Prettifier.prettify(input);
        String expected = "1\n\t1) a\n\t2) b\n\t3) c\n";

        assertEquals(expected, actual);
    }

}
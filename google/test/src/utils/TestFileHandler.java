package test.src.utils;

import static org.junit.jupiter.api.Assertions.*;

import java.util.*;
import java.util.HashSet;

import org.junit.jupiter.api.Test;

import main.src.core.structures.Document;
import main.src.core.structures.Token;
import main.src.utils.FileHandler;


public class TestFileHandler {

    final public static String RESOURCES_ABSOLUTE_PATH = "D:/projects/internship/codestar/Team8-Codes/google/test/resources/input";

    @Test
    public void testGetDocumentTokens() {
        Document doc = new Document("doc1.txt", RESOURCES_ABSOLUTE_PATH + '/' + "doc1.txt");
        HashSet<Token> expected = new HashSet<>();
        expected.add(new Token("hello"));
        expected.add(new Token("world"));
        HashSet<Token> actual = FileHandler.getDocumentTokens(doc);

        assertEquals(expected, actual);
    }

    @Test
    public void testGetFolderDocuments(){
        ArrayList<Document> expected = new ArrayList<>();
        expected.add(new Document("doc1.txt", "simple/Path"));
        expected.add(new Document("doc2.txt", "simple/Path"));
        expected.add(new Document("doc3.txt", "simple/Path"));
        ArrayList<Document> actual = FileHandler.getFolderDocuments(RESOURCES_ABSOLUTE_PATH);

        assertEquals(expected, actual);
    }

    @Test
    public void testGetFileContent(){
        String expected = "hello world";
        String actual = FileHandler.getFileContent(RESOURCES_ABSOLUTE_PATH + "/doc1.txt");
        assertEquals(expected, actual);
    }
}
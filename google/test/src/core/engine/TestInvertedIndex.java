package test.src.core.engine;

import java.io.File;
import java.util.*;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

import main.src.core.structures.*;
import main.src.core.engine.*;
import main.src.utils.*;


public class TestInvertedIndex {

    public static InvertedIndex sampleInvertedIndex;
    public final static String RESOURCE_RELATIVE_PATH = "bin/test/resources/input";

    @Before
    public void makeSampleInvertedIndex() {
        sampleInvertedIndex = new InvertedIndex(
            FileHandler.getFolderDocuments(new File(RESOURCE_RELATIVE_PATH).getAbsolutePath())
        );
    }

    @After
    public void resetSampleInvertedIndex() {
        sampleInvertedIndex = null;
    }

    @Test
    public void testConstructorSeed()
    {
        var expected = new HashMap<Token, HashSet<Document>>();
        expected.put(new Token("first"), new HashSet <Document> (
            Arrays.asList(
                new Document("doc2.txt", "simple/path"),
                new Document("doc3.txt", "simple/path")
            )
        ));
        expected.put(new Token("second"), new HashSet <Document> (
            Arrays.asList(
                new Document("doc2.txt", "simple/path"),
                new Document("doc3.txt", "simple/path")
            )
        ));
        expected.put(new Token("third"), new HashSet <Document> (
            Arrays.asList(
                new Document("doc2.txt", "simple/path"),
                new Document("doc3.txt", "simple/path")
            )
        ));
        expected.put(new Token("hello"), new HashSet <Document> (
            Arrays.asList(
                new Document("doc1.txt", "simple/path")
            )
        ));
        expected.put(new Token("world"), new HashSet <Document> (
            Arrays.asList(
                new Document("doc1.txt", "simple/path")
            )
        ));
        expected.put(new Token("fourth"), new HashSet <Document> (
            Arrays.asList(
                new Document("doc3.txt", "simple/path")
            )
        ));

        var actual = sampleInvertedIndex.getIndex();

        assertEquals(expected, actual);
    }

    @Test
    public void testGetDocumentsOfTokenSeed() {
        var expected = new HashSet<Document>();
        expected.add(new Document("doc3.txt", "simple/path"));
        var actual = sampleInvertedIndex.getDocumentsOfToken(new Token("fourth"));
        assertEquals(expected, actual);
    }
}

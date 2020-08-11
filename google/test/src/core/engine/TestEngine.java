package test.src.core.engine;

import java.io.File;
import java.util.*;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

import main.src.core.engine.*;
import main.src.utils.*;
import main.src.core.query.*;
import main.src.core.structures.*;


public class TestEngine {
    
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
    public void testGetQueryResultsOnlyAndTerms()
    {
        var query = new Query("first third");
        var actual = Engine.getQueryResults(query, sampleInvertedIndex);

        var expected = new HashSet<Document>();
        expected.add(new Document("doc2.txt", "simple/path"));
        expected.add(new Document("doc3.txt", "simple/path"));

        assertEquals(expected, actual);
    }

    @Test
    public void testGetQueryResultsOnlyOrTerms()
    {
        var query = new Query("+first +third");
        var actual = Engine.getQueryResults(query, sampleInvertedIndex);

        var expected = new HashSet<Document>();
        expected.add ( new Document("doc2.txt", "simple/path") );
        expected.add ( new Document("doc3.txt", "simple/path") );
    
        assertEquals(expected, actual);
    }

    @Test
    public void testGetQueryResultsOnlyExcTerms()
    {
        var query = new Query("-first -third");
        
        assertThrows(IllegalArgumentException.class, () -> Engine.getQueryResults(query, sampleInvertedIndex));
    }

    @Test
    public void testGetQueryResultsAndOrTerms()
    {
        var query = new Query("first +hello second");
        var actual = Engine.getQueryResults(query, sampleInvertedIndex);

        var expected = new HashSet<Document>();    
        expected.add ( new Document("doc1.txt", "simple/path") );
        expected.add ( new Document("doc2.txt", "simple/path") );
        expected.add ( new Document("doc3.txt", "simple/path") );
            
        assertEquals(expected, actual);
    }

    @Test
    public void testGetQueryResultsAndExcTerms()
    {
        var query = new Query("first -second");
        var actual = Engine.getQueryResults(query, sampleInvertedIndex);

        var expected = new HashSet<Document>();
            
        assertEquals(expected, actual);
    }

    @Test
    public void testGetQueryResultsOrExcTerms()
    {
        var query = new Query("+first +hello -second");
        var actual = Engine.getQueryResults(query, sampleInvertedIndex);

        var expected = new HashSet<Document>();
        expected.add(new Document("doc1.txt", "simple/path"));

        assertEquals(expected, actual);
    }

    @Test
    public void testGetQueryResultsAllTerms()
    {
        var query = new Query("first +hello -second");
        var actual = Engine.getQueryResults(query, sampleInvertedIndex);

        var expected = new HashSet<Document>();
        expected.add(new Document("doc1.txt", "simple/path"));

        assertEquals(expected, actual);
    }
}

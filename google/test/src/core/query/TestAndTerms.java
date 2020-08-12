package test.src.core.query;

import org.junit.Test;

import static org.junit.Assert.assertEquals;
import java.util.*;

import main.src.core.query.AndTerms;
import main.src.core.structures.*;


public class TestAndTerms extends TestTermsAbstract{    

    @Test
    public void testConstructorOnlyAnds(){
        var expected = new ArrayList<>(Arrays.asList(
            new Token("first"),
            new Token("second2"),
            new Token("3rd")
        ));
        var actual = new AndTerms("first second2 3rd").getKeys();

        assertEquals(expected, actual);
    }

    @Test
    public void testConstructorNoAnds(){
        var expected = new ArrayList<Token>();
        var actual = new AndTerms("-first +second2 -3rd").getKeys();

        assertEquals(expected, actual);
    }

    @Test
    public void testConstructorSomeAnds(){
        ArrayList<Token> expected = new ArrayList<>( Arrays.asList(
            new Token("first"),
            new Token("4th"),
            new Token("5th")
        ));
        var actual = new AndTerms("first +second2 -3rd 4th 5th").getKeys();

        assertEquals(expected, actual);
    }
    
    @Test
    public void testGetResultsSingleTokenIndex(){
        HashSet<Document> expected = new HashSet<>(
            Arrays.asList(
                new Document("doc1.txt", "simple/path"),
                new Document("doc2.txt", "simple/path"),
                new Document("doc3.txt", "simple/path")
            )
        );
        var objectUnderTest = new AndTerms("first");
        var actual = objectUnderTest.getResults(this.mockedInvertedIndex);

        assertEquals(expected, actual);
    }

    @Test
    public void testGetResultsMultiTokenIndex(){   
        HashSet<Document> expected = new HashSet<Document>(
            Arrays.asList(
                new Document("doc1.txt", "simple/path"),
                new Document("doc2.txt", "simple/path")
            )
        );
        var objectUnderTest = new AndTerms("first second -third +fourth");
        var actual = objectUnderTest.getResults(this.mockedInvertedIndex);

        assertEquals(expected, actual);
    }
}
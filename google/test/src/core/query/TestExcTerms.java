package test.src.core.query;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.junit.MockitoJUnitRunner;

import static org.junit.Assert.*;
import java.util.*;

import main.src.core.query.ExcTerms;
import main.src.core.structures.*;


@RunWith(MockitoJUnitRunner.class)
public class TestExcTerms extends TestTermsAbstract{

    @Test
    public void testConstructorOnlyExcs(){
        ArrayList<Token> expected = new ArrayList<>(Arrays.asList(
            new Token("first"),
            new Token("second2"),
            new Token("3rd")
        ));
        var actual = new ExcTerms("-first -second2 -3rd").getKeys();

        assertEquals(expected, actual);
    }

    @Test
    public void testConstructorNoExcs(){
        var expected = new ArrayList<Token>();
        var actual = new ExcTerms("+first second2 +3rd").getKeys();

        assertEquals(expected, actual);
    }

    @Test
    public void testConstructorSomeExcs(){
        ArrayList<Token> expected = new ArrayList<>( Arrays.asList(
            new Token("first"),
            new Token("4th"),
            new Token("5th")
        ));
        var actual = new ExcTerms("-first second2 +3rd -4th -5th").getKeys();

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
        var objectUnderTest = new ExcTerms("-first");
        var actual = objectUnderTest.getResults(this.mockedInvertedIndex);

        assertEquals(expected, actual);
    }

    @Test
    public void testGetResultsMultiTokenIndex(){   
        HashSet<Document> expected = new HashSet<Document>(
            Arrays.asList(
                new Document("doc1.txt", "simple/path"),
                new Document("doc2.txt", "simple/path"),
                new Document("doc3.txt", "simple/path")
            )
        );
        var objectUnderTest = new ExcTerms("-first -second +third fourth");
        var actual = objectUnderTest.getResults(this.mockedInvertedIndex);

        assertEquals(expected, actual);
    }
}

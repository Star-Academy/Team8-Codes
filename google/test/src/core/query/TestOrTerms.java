package test.src.core.query;

import org.junit.jupiter.api.Test;
import org.junit.runner.RunWith;
import org.mockito.junit.MockitoJUnitRunner;

import static org.junit.jupiter.api.Assertions.assertEquals;
import java.util.*;

import main.src.core.query.OrTerms;
import main.src.core.structures.*;


@RunWith(MockitoJUnitRunner.class)
public class TestOrTerms extends TestTermsAbstract{

    @Test
    public void testConstructorOnlyOrs(){
        ArrayList<Token> expected = new ArrayList<>(Arrays.asList(
            new Token("first"),
            new Token("second2"),
            new Token("3rd")
        ));
        ArrayList<Token> actual = new OrTerms("+first +second2 +3rd").getKeys();

        assertEquals(expected, actual);
    }

    @Test
    public void testConstructorNoOrs(){
        ArrayList<Token> expected = new ArrayList<Token>();
        ArrayList<Token> actual = new OrTerms("-first second2 -3rd").getKeys();

        assertEquals(expected, actual);
    }

    @Test
    public void testConstructorSomeOrs(){
        ArrayList<Token> expected = new ArrayList<>( Arrays.asList(
            new Token("first"),
            new Token("4th"),
            new Token("5th")
        ));
        ArrayList<Token> actual = new OrTerms("+first second2 -3rd +4th +5th").getKeys();

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
        var objectUnderTest = new OrTerms("+first");
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
        var objectUnderTest = new OrTerms("+first +second -third fourth");
        var actual = objectUnderTest.getResults(this.mockedInvertedIndex);

        assertEquals(expected, actual);
    }
}

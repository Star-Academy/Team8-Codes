package test.src.core.query;

import static org.junit.Assert.*;
import org.junit.jupiter.api.Test;
import java.util.*;


import main.src.core.query.Query;
import main.src.core.structures.Token;


public class TestQuery
{
    @Test
    public void testConstructorOnlyOrTerms()
    {
        var query = new Query("+first +second +third");
        var expected = new ArrayList<Token>(
            Arrays.asList(
                new Token("first"),
                new Token("second"),
                new Token("third")
            )
        );
        var actual = query.orTerms.getKeys();

        assertEquals(expected, actual);

    }

    @Test
    public void testConstructorOnlyAndTerms()
    {
        var query = new Query("first second third");
        var expected = new ArrayList<Token>(
            Arrays.asList(
                new Token("first"),
                new Token("second"),
                new Token("third")
            )
        );
        var actual = query.andTerms.getKeys();

        assertEquals(expected, actual);
    }

    @Test
    public void testConstructorOnlyExcTerms()
    {
        var query = new Query("-first -second -third");
        var expected = new ArrayList<Token>(
            Arrays.asList(
                new Token("first"),
                new Token("second"),
                new Token("third")
            )
        );
        var actual = query.excTerms.getKeys();

        assertEquals(expected, actual);
    }

    @Test
    public void testConstructorAndOr()
    {
        Query queryBuilder = new Query("first +second third");

        var expectedAndTerms = new ArrayList<Token>(
            Arrays.asList(
                new Token("first"),
                new Token("third")
            )
        );
        var expectedOrTerms = new ArrayList<Token>(
            Arrays.asList(
                new Token("second")
            )
        );

        var actualAndTerms = queryBuilder.andTerms.getKeys();
        var actualOrTerms = queryBuilder.orTerms.getKeys();

        assertEquals(expectedAndTerms, actualAndTerms);
        assertEquals(expectedOrTerms, actualOrTerms);
    }

    @Test
    public void testConstructorAndExc()
    {
        Query query = new Query("first -second third");

        var expectedAndTerms = new ArrayList<Token>(
            Arrays.asList(
                new Token("first"),
                new Token("third")
            )
        );
        var expectedExcTerms = new ArrayList<Token>(
            Arrays.asList(
                new Token("second")
            )
        );

        var actualAndTerms = query.andTerms.getKeys();
        var actualExcTerms = query.excTerms.getKeys();

        assertEquals(expectedAndTerms, actualAndTerms);
        assertEquals(expectedExcTerms, actualExcTerms);
    }

    @Test
    public void testConstructorOrExc()
    {
        Query query = new Query("+first -second +third");

        var expectedOrTerms = new ArrayList<Token>(
            Arrays.asList(
                new Token("first"),
                new Token("third")
            )
        );
        var expectedExcTerms = new ArrayList<Token>(
            Arrays.asList(
                new Token("second")
            )
        );

        var actualOrTerms = query.orTerms.getKeys();
        var actualExcTerms = query.excTerms.getKeys();

        assertEquals(expectedOrTerms, actualOrTerms);
        assertEquals(expectedExcTerms, actualExcTerms);
    }

    @Test
    public void testConstructorAll()
    {
        Query query = new Query("first +second -third");

        var expectedAndTerms = new ArrayList<Token>();
        expectedAndTerms.add(new Token("first"));
        var expectedOrTerms = new ArrayList<Token>();
        expectedOrTerms.add(new Token("second"));
        var expectedExcTerms = new ArrayList<Token>();
        expectedExcTerms.add(new Token("third"));

        var actualAndTerms = query.andTerms.getKeys();
        var actualOrTerms = query.orTerms.getKeys();
        var actualExcTerms = query.excTerms.getKeys();

        assertEquals(expectedAndTerms, actualAndTerms);
        assertEquals(expectedOrTerms, actualOrTerms);
        assertEquals(expectedExcTerms, actualExcTerms);
    }
}

package test.src.core.structures;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

import org.junit.Before;
import org.junit.jupiter.api.Test;

import main.src.core.structures.Token;


public class TestToken {
    
    public static Token sampleToken;

    @Before
    public void makeToken(){
        sampleToken = new Token("HelLoo WorlD");
    }

    @Test
    public void testTokenBasicMethods(){
        assertEquals("helloo world", sampleToken.getKey());
        sampleToken.setKey("key");
        String expected = "key";
        String actual = sampleToken.getKey();
        assertEquals(expected, actual);

    }

    @Test
    public void testTokenComparability(){
        assertEquals("Token(helloo world)", sampleToken.toString());
        assertTrue(sampleToken.equals(new Token("helloo WORLD")));
        assertEquals("helloo world".hashCode(), sampleToken.hashCode());
        assertEquals(18, new Token("ZZZ").compareTo(sampleToken));
    }
}
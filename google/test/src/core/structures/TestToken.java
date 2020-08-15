package test.src.core.structures;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import main.src.core.structures.Token;


public class TestToken {
    
    private static Token sampleToken;
    private static final String sampleTokenId = "hello world";

    @Before
    public void makeToken(){
        sampleToken = new Token(sampleTokenId.toUpperCase());
    }

    @After
    public void disposeToken(){
        sampleToken = null;
    }

    @Test
    public void testSetter(){
        assertEquals(sampleTokenId, sampleToken.getId());
        sampleToken.setId("SampleIDForToken");
        String expected = "sampleidfortoken";
        String actual = sampleToken.getId();
        assertEquals(expected, actual);
        sampleToken.setId(sampleTokenId);
    }

    @Test
    public void testTokenToString(){
        var expected = "Token(" + sampleTokenId + ")";
        var actual = sampleToken.toString();
        assertEquals(expected, actual);
    }

}
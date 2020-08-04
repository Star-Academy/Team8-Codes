package test.src.utils;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

import org.junit.Test;

import main.src.utils.Prettifier;


public class TestPrettifier {

    @Test
    public void testPrettifyHashSet() {
        HashSet<Integer> input = new HashSet<>();
        input.add(1);
        input.add(2);
        input.add(3);
        
        String actual = Prettifier.prettify(input);
        String expected = "\t1) 1\n\t2) 2\n\t3) 3\n";

        assertEquals(expected, actual);
    }

    @Test
    public void testPrettifyHashMap(){
        HashMap<Integer, HashSet<String>> input = new HashMap<>();
        input.put(1, new HashSet<String>(Arrays.asList("a", "b", "c")));

        String actual = Prettifier.prettify(input);
        String expected = "1\n\t1) a\n\t2) b\n\t3) c\n";

        assertEquals(expected, actual);
    }

}
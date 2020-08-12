package test.src.core.structures;

import static org.junit.Assert.assertTrue;
import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import main.src.core.structures.Entity;


public class TestEntity {

    private static Entity sampleEntity;
    private final static String sampleEntityId = "sampleId";

    @Test
    public void testGetterSetters(){
        sampleEntity = new Entity(sampleEntityId);
        sampleEntity.setId("anotherId");
        var expected = "anotherId";
        var actual = sampleEntity.getId();
        assertEquals(expected, actual);
    }

    @Before
    public void makeEntity(){
        sampleEntity = new Entity(sampleEntityId);
    }

    @After
    public void disposeEntity(){
        sampleEntity = null;
    }

    @Test
    public void testEntityComparability(){
        // .equals
        assertTrue(sampleEntity.equals(new Entity(sampleEntityId)));
        // .hashCode
        assertEquals(sampleEntity.getId().hashCode(), sampleEntity.hashCode());
        // .compareTo
        assertEquals(-25, new Entity("ZZZ").compareTo(sampleEntity));
    }

    @Test
    public void testTokenToString(){
        var expected = "Entity(" + sampleEntityId + ")";
        var actual = sampleEntity.toString();
        assertEquals(expected, actual);
    }

}
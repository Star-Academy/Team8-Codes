package test.src.core.structures;

import static org.junit.Assert.assertEquals;

import org.junit.jupiter.api.Test;

import main.src.core.structures.Document;


public class TestDocument {

    @Test
    public void testGetterSetters(){
        Document doc = new Document("hey", "hey/path1/path2");
        doc.setId("doc");
        assertEquals("doc", doc.getId());
        doc.setPath("root/path");
        assertEquals("root/path", doc.getPath());
    }

}
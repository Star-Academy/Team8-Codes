package test.src.core.structures;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

import main.src.core.structures.Document;


public class TestDocument {

    @Test
    public void testDocument(){
        Document doc = new Document("hey", "hey/path1/path2");
        doc.setId("doc");
        assertEquals("doc", doc.getId());
        doc.setPath("root/path");
        assertEquals("root/path", doc.getPath());
    }

    @Test
    public void testDocumentGetDocument(){
        Document doc = new Document("hey", "hey/path1/path2");
        String actual = doc.getContent();
        String expected = null;
        assertEquals(expected, actual);
    }
}
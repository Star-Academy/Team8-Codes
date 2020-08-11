package test.src.core.query;

import org.junit.*;
import org.junit.runner.RunWith;
import org.mockito.junit.MockitoJUnitRunner;


import static org.mockito.Mockito.*;
import java.util.*;

import main.src.core.structures.*;
import main.src.core.engine.*;


@RunWith(MockitoJUnitRunner.class)
public class TestTermsAbstract {

    protected IndexInterface mockedInvertedIndex;

    @Before
    public void initMockedInvertedIndex(){
        mockedInvertedIndex = mock(IndexInterface.class);

        when(mockedInvertedIndex.getDocumentsOfToken(new Token("first")))
        .thenReturn(
            new HashSet<Document>(
                Arrays.asList(
                    new Document("doc1.txt", "simple/path"),
                    new Document("doc2.txt", "simple/path"),
                    new Document("doc3.txt", "simple/path")
                )
            )
        );

        when(mockedInvertedIndex.getDocumentsOfToken(new Token("second")))
        .thenReturn(
            new HashSet<Document>(
                Arrays.asList(
                    new Document("doc1.txt", "simple/path"),
                    new Document("doc2.txt", "simple/path")
                )
            )
        );
    }

    @After
    public void disposeMockedInvertedIndex(){
        reset(mockedInvertedIndex);
    }
}

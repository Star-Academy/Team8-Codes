package test.src.core.query;

import static org.junit.Assert.*;

import java.util.*;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

import main.src.core.query.Query;
import main.src.core.structures.Token;

@RunWith(Parameterized.class)
public class TestQuery {
    final String QUERY_STRING;
    final Token[] EXPECTED_AND_TERMS;
    final Token[] EXPECTED_OR_TERMS;
    final Token[] EXPECTED_EXC_TERMS;

    public TestQuery(final String QUERY_STRING, final Token[] EXPECTED_AND_TERMS, final Token[] EXPECTED_OR_TERMS,
            final Token[] EXPECTED_EXC_TERMS) {
        this.QUERY_STRING = QUERY_STRING;
        this.EXPECTED_AND_TERMS = EXPECTED_AND_TERMS;
        this.EXPECTED_OR_TERMS = EXPECTED_OR_TERMS;
        this.EXPECTED_EXC_TERMS = EXPECTED_EXC_TERMS;
    }

    @Test
    public void testCollectTerms() {
        final Query QUERY = new Query(QUERY_STRING);

        assertArrayEquals(EXPECTED_AND_TERMS, QUERY.andTerms.getKeys().toArray());
        assertArrayEquals(EXPECTED_OR_TERMS, QUERY.orTerms.getKeys().toArray());
        assertArrayEquals(EXPECTED_EXC_TERMS, QUERY.excTerms.getKeys().toArray());
    }

    @Parameterized.Parameters
    public static List<Object[]> data() {
        final Token[] TOKENS = new Token[] { new Token(""), new Token("first"), new Token("second"),
                new Token("third") };

        final Token[] TOKENS_0 = new Token[] {};
        final Token[] TOKENS_1 = new Token[] { TOKENS[1] };
        final Token[] TOKENS_2 = new Token[] { TOKENS[2] };
        final Token[] TOKENS_3 = new Token[] { TOKENS[3] };
        final Token[] TOKENS_13 = new Token[] { TOKENS[1], TOKENS[3] };
        final Token[] TOKENS_23 = new Token[] { TOKENS[2], TOKENS[3] };
        final Token[] TOKENS_123 = new Token[] { TOKENS[1], TOKENS[2], TOKENS[3] };

        final List<Object[]> PARAMETERS_LIST = new ArrayList<>();

        // Only AND terms
        PARAMETERS_LIST.add(new Object[] { "first Second tHirD", TOKENS_123, TOKENS_0, TOKENS_0 });

        // Only OR terms
        PARAMETERS_LIST.add(new Object[] { "+first +Second +tHirD", TOKENS_0, TOKENS_123, TOKENS_0 });

        // Only Exc terms
        PARAMETERS_LIST.add(new Object[] { "-first -Second -tHirD", TOKENS_0, TOKENS_0, TOKENS_123 });

        // And & OR terms
        PARAMETERS_LIST.add(new Object[] { "first +Second +tHirD", TOKENS_1, TOKENS_23, TOKENS_0 });
        PARAMETERS_LIST.add(new Object[] { "+first Second tHirD", TOKENS_23, TOKENS_1, TOKENS_0 });
        PARAMETERS_LIST.add(new Object[] { "first +Second tHirD", TOKENS_13, TOKENS_2, TOKENS_0 });

        // And & EXC terms
        PARAMETERS_LIST.add(new Object[] { "first -Second -tHirD", TOKENS_1, TOKENS_0, TOKENS_23 });
        PARAMETERS_LIST.add(new Object[] { "-first Second tHirD", TOKENS_23, TOKENS_0, TOKENS_1 });
        PARAMETERS_LIST.add(new Object[] { "first -Second tHirD", TOKENS_13, TOKENS_0, TOKENS_2 });

        // OR & EXC terms
        PARAMETERS_LIST.add(new Object[] { "+first -Second -tHirD", TOKENS_0, TOKENS_1, TOKENS_23 });
        PARAMETERS_LIST.add(new Object[] { "-first +Second +tHirD", TOKENS_0, TOKENS_23, TOKENS_1 });
        PARAMETERS_LIST.add(new Object[] { "+first -Second +tHirD", TOKENS_0, TOKENS_13, TOKENS_2 });

        // AND, OR & EXC terms
        PARAMETERS_LIST.add(new Object[] { "first +Second -tHirD", TOKENS_1, TOKENS_2, TOKENS_3 });
        PARAMETERS_LIST.add(new Object[] { "first -Second +tHirD", TOKENS_1, TOKENS_3, TOKENS_2 });
        PARAMETERS_LIST.add(new Object[] { "+first Second -tHirD", TOKENS_2, TOKENS_1, TOKENS_3 });
        PARAMETERS_LIST.add(new Object[] { "+first -Second tHirD", TOKENS_3, TOKENS_1, TOKENS_2 });
        PARAMETERS_LIST.add(new Object[] { "-first Second +tHirD", TOKENS_2, TOKENS_3, TOKENS_1 });
        PARAMETERS_LIST.add(new Object[] { "-first +Second tHirD", TOKENS_3, TOKENS_2, TOKENS_1 });

        return PARAMETERS_LIST;
    }
}
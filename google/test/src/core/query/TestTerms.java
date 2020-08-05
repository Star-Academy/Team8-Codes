package test.src.core.query;

import static org.junit.Assert.*;

import java.io.File;
import java.util.*;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

import main.src.core.engine.InvertedIndex;
import main.src.core.query.*;

@RunWith(Parameterized.class)
public class TestTerms {
	final String RESOURCE_RELATIVE_FOLDER_PATH = "bin/test/resources/input";
	final String RESOURCE_ABSOLUTE_FOLDER_PATH;
	final InvertedIndex INDEX;

	final String EXPRESSION;
	final String EXPECTED_AND_RESULTS;
	final String EXPECTED_OR_RESULTS;
	final String EXPECTED_EXC_RESULTS;

	public TestTerms(final String EXPRESSION, final String EXPECTED_AND_RESULTS, final String EXPECTED_OR_RESULTS,
			final String EXPECTED_EXC_RESULTS) {
		this.RESOURCE_ABSOLUTE_FOLDER_PATH = new File(RESOURCE_RELATIVE_FOLDER_PATH).getAbsolutePath();
		this.INDEX = new InvertedIndex(RESOURCE_ABSOLUTE_FOLDER_PATH);

		this.EXPRESSION = EXPRESSION;
		this.EXPECTED_AND_RESULTS = EXPECTED_AND_RESULTS;
		this.EXPECTED_OR_RESULTS = EXPECTED_OR_RESULTS;
		this.EXPECTED_EXC_RESULTS = EXPECTED_EXC_RESULTS;
	}

	@Test
	public void testGetResults() {
		final AndTerms AND_TERMS = new AndTerms(EXPRESSION);
		final OrTerms OR_TERMS = new OrTerms(EXPRESSION);
		final ExcTerms EXC_TERMS = new ExcTerms(EXPRESSION);

		final ArrayList<String> ACTUAL_AND_RESULTS = new ArrayList<>();
		final ArrayList<String> ACTUAL_OR_RESULTS = new ArrayList<>();
		final ArrayList<String> ACTUAL_EXC_RESULTS = new ArrayList<>();

		AND_TERMS.getResults(INDEX).forEach(doc -> ACTUAL_AND_RESULTS.add(doc.toString()));
		OR_TERMS.getResults(INDEX).forEach(doc -> ACTUAL_OR_RESULTS.add(doc.toString()));
		EXC_TERMS.getResults(INDEX).forEach(doc -> ACTUAL_EXC_RESULTS.add(doc.toString()));

		Collections.sort(ACTUAL_AND_RESULTS);
		Collections.sort(ACTUAL_OR_RESULTS);
		Collections.sort(ACTUAL_EXC_RESULTS);

		assertEquals(EXPECTED_AND_RESULTS, ACTUAL_AND_RESULTS.toString());
		assertEquals(EXPECTED_OR_RESULTS, ACTUAL_OR_RESULTS.toString());
		assertEquals(EXPECTED_EXC_RESULTS, ACTUAL_EXC_RESULTS.toString());
	}

	@Parameterized.Parameters
	public static List<Object[]> data() {
		final String[] DOCUMENTS = new String[] { "", "Document(doc1.txt)", "Document(doc2.txt)",
				"Document(doc3.txt)" };

		final String DOCUMENTS_0 = Arrays.asList(new String[] {}).toString();
		final String DOCUMENTS_3 = Arrays.asList(new String[] { DOCUMENTS[3] }).toString();
		final String DOCUMENTS_12 = Arrays.asList(new String[] { DOCUMENTS[1], DOCUMENTS[2] }).toString();
		final String DOCUMENTS_13 = Arrays.asList(new String[] { DOCUMENTS[1], DOCUMENTS[3] }).toString();
		final String DOCUMENTS_123 = Arrays.asList(new String[] { DOCUMENTS[1], DOCUMENTS[2], DOCUMENTS[3] })
				.toString();

		final List<Object[]> PARAMETERS_LIST = new ArrayList<>();

		// Only AND terms
		PARAMETERS_LIST.add(new Object[] { "first second third", DOCUMENTS_0, DOCUMENTS_0, DOCUMENTS_0 });

		// Only OR terms
		PARAMETERS_LIST.add(new Object[] { "+first +second +third", DOCUMENTS_0, DOCUMENTS_123, DOCUMENTS_0 });

		// Only Exc terms
		PARAMETERS_LIST.add(new Object[] { "-first -second -third", DOCUMENTS_0, DOCUMENTS_0, DOCUMENTS_123 });

		// And & OR terms
		PARAMETERS_LIST.add(new Object[] { "first +second +third", DOCUMENTS_13, DOCUMENTS_123, DOCUMENTS_0 });
		PARAMETERS_LIST.add(new Object[] { "+first second third", DOCUMENTS_0, DOCUMENTS_13, DOCUMENTS_0 });
		PARAMETERS_LIST.add(new Object[] { "first +second third", DOCUMENTS_3, DOCUMENTS_12, DOCUMENTS_0 });

		// And & EXC terms
		PARAMETERS_LIST.add(new Object[] { "first -second -third", DOCUMENTS_13, DOCUMENTS_0, DOCUMENTS_123 });
		PARAMETERS_LIST.add(new Object[] { "-first second third", DOCUMENTS_0, DOCUMENTS_0, DOCUMENTS_13 });
		PARAMETERS_LIST.add(new Object[] { "first -second third", DOCUMENTS_3, DOCUMENTS_0, DOCUMENTS_12 });

		// OR & EXC terms
		PARAMETERS_LIST.add(new Object[] { "+first -second -third", DOCUMENTS_0, DOCUMENTS_13, DOCUMENTS_123 });
		PARAMETERS_LIST.add(new Object[] { "-first +second +third", DOCUMENTS_0, DOCUMENTS_123, DOCUMENTS_13 });
		PARAMETERS_LIST.add(new Object[] { "+first -second +third", DOCUMENTS_0, DOCUMENTS_13, DOCUMENTS_12 });

		// AND, OR & EXC terms
		PARAMETERS_LIST.add(new Object[] { "first +second -third", DOCUMENTS_13, DOCUMENTS_12, DOCUMENTS_3 });
		PARAMETERS_LIST.add(new Object[] { "first -second +third", DOCUMENTS_13, DOCUMENTS_3, DOCUMENTS_12 });
		PARAMETERS_LIST.add(new Object[] { "+first second -third", DOCUMENTS_12, DOCUMENTS_13, DOCUMENTS_3 });
		PARAMETERS_LIST.add(new Object[] { "+first -second third", DOCUMENTS_3, DOCUMENTS_13, DOCUMENTS_12 });
		PARAMETERS_LIST.add(new Object[] { "-first second +third", DOCUMENTS_12, DOCUMENTS_3, DOCUMENTS_13 });
		PARAMETERS_LIST.add(new Object[] { "-first +second third", DOCUMENTS_3, DOCUMENTS_12, DOCUMENTS_13 });

		return PARAMETERS_LIST;
	}
}
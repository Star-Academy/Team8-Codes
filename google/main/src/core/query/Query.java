package main.src.core.query;


public class Query {

    public AndTerms andTerms;
    public OrTerms orTerms;
    public ExcTerms excTerms;
    
    public Query(String queryString) {
        this.collectTerms(queryString);
    }

    private void collectTerms(String expression) {
        this.andTerms = new AndTerms(expression);
        this.orTerms = new OrTerms(expression);
        this.excTerms = new ExcTerms(expression);
    }

    @Override
    public String toString() {
        return  "Query\n" + 
                "ANDs : " + this.andTerms.toString() + "\n" + 
                "ORs  : " + this.orTerms.toString() + "\n" + 
                "EXCs : " + this.excTerms.toString();
    }
}
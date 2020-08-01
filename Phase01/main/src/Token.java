public class Token implements Comparable<Token> {

    private String key;

    public Token(String key) {
        this.key = normalize(key);
    }

    public String getKey() {
        return key;
    }

    public void setKey(String newKey) {
        this.key = newKey;
    }

    private String normalize(String key) {
        String normalized = key;
        normalized = key.toLowerCase();
        return normalized;
    }

    @Override
    public String toString() {
        return "Token(" + this.key + ")";
    }

    @Override
    public boolean equals(Object other) {
        if (this == other)
            return true;
        if (!(other instanceof Token))
            return false;
        Token that = (Token) other;
        return this.key.equals(that.key);
    }

    @Override
    public int hashCode() {
        return key.hashCode();
    }

    @Override
    public int compareTo(Token that) {
        // returns -1 if "this" object is less than "that" object
        // returns 0 if they are equal
        // returns 1 if "this" object is greater than "that" object
        return this.key.compareTo(that.key);
    }

}
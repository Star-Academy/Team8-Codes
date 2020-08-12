package main.src.core.structures;

public class Token extends Entity {

    public Token(String id) {
        super(id);
        this.id = normalize(id);
    }

    private static String normalize(String str) {
        String normalized = str;
        normalized = str.toLowerCase();
        return normalized;
    }

    @Override
    public void setId(String newId){
        super.setId(normalize(newId));
    }

    @Override
    public String toString() {
        return "Token(" + this.id + ")";
    }
}
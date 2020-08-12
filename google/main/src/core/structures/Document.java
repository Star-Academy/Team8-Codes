package main.src.core.structures;


public class Document extends Entity{

    private String path;

    public Document(String id, String path) {
        super(id);
        this.path = path;
    }

    public String getPath() {
        return this.path;
    }

    public void setPath(String newPath) {
        this.path = newPath;
    }

    @Override
    public String toString() {
        return "Document(" + this.id + ")";
    }
}
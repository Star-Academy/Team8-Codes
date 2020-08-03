package main.src.core.structures;

import main.src.utils.FileHandler;

public class Document extends Object{

    private String id;
    private String path;

    public Document(String id, String path) {
        this.id = id;
        this.path = path;
    }

    public String getId() {
        return this.id;
    }

    public void setId(String newId) {
        this.id = newId;
    }

    public String getPath() {
        return this.path;
    }

    public void setPath(String newPath) {
        this.path = newPath;
    }

    public String getContent() {
        return FileHandler.loadFile(this.path);
    }

    @Override
    public String toString() {
        return "Document(" + this.id + ")";
    }

}
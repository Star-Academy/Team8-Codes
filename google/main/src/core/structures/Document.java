package main.src.core.structures;

import main.src.utils.FileHandler;

public class Document implements Comparable<Document>{

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
        return FileHandler.getFileContent(this.path);
    }

    @Override
    public boolean equals(Object obj) {
        if(this == obj) 
            return true; 
        if(obj == null || obj.getClass()!= this.getClass()) 
            return false; 
        Document that = (Document) obj; 
        return (that.id.equals(id)); 
    }

    @Override
    public int hashCode() {
        return this.id.hashCode();
    }

    @Override
    public int compareTo(Document that) {
        // returns -1 if "this" object is less than "that" object
        // returns 0 if they are equal
        // returns 1 if "this" object is greater than "that" object
        return this.id.compareTo(that.id);
    }


    @Override
    public String toString() {
        return "Document(" + this.id + ")";
    }

}
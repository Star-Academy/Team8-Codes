
public class Document {

    private String id;
    private String path;
    private String content;

    public Document(String id, String path, String content) {
        this.id = id;
        this.path = path;
        this.content = content;
    }

    public String getId() {
        return id;
    }

    public void setId(String newId) {
        id = newId;
    }

    public String getPath() {
        return path;
    }

    public void setPath(String newPath) {
        path = newPath;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String newContent) {
        content = newContent;
    }

    @Override
    public String toString() {
        return "Document(" + this.id + ")";
    }

}
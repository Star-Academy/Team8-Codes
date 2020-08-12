package main.src.core.structures;

public class Entity implements Comparable<Entity> {

    protected String id;

    public Entity(String id) {
        this.id = id;
    }

    public String getId() {
        return this.id;
    }

    public void setId(String newId) {
        this.id = newId;
    }

    @Override
    public boolean equals(Object other) {
        if (this == other)
            return true;
        if (!(other instanceof Entity))
            return false;
            Entity that = (Entity) other;
        return this.id.equals(that.id);
    }

    @Override
    public int hashCode() {
        return id.hashCode();
    }

    @Override
    public int compareTo(Entity that) {
        // returns -1 if "this" object is less than "that" object
        // returns 0 if they are equal
        // returns 1 if "this" object is greater than "that" object
        return this.id.compareTo(that.id);
    }

    @Override
    public String toString(){
        return "Entity(" + this.id + ")";
    }

}
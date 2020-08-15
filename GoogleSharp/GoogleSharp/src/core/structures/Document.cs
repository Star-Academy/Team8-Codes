namespace GoogleSharp.Src.Core.Structures {
    public class Document {
        public Document (string id, string path) {
            Id = id;
            Path = path;
        }

        public string Id { get; set; }
        public string Path { get; set; }

        public override bool Equals (object obj) {
            if (obj is Document other)
                return Id == other.Id;
            return false;
        }

        public override int GetHashCode () {
            return Id.GetHashCode ();
        }

        public override string ToString () {
            return $"Document({Id})";
        }
    }
}

namespace GoogleSharp.Src.Core.Structures
{
    public class Document
    {
        public Document(string id, string path)
        {
            this.Id = id;
            this.Path = path;
        }

        public string Id { get; set; }
        public string Path { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            var other = (Document)(obj);
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"Document({this.Id})";
        }
    }
}

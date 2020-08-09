using System;

namespace Structures
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
            return this.Path == other.Path;
        }

        public override string ToString()
        {
            return String.Format("Document({0})", this.Id);
        }
    }
}

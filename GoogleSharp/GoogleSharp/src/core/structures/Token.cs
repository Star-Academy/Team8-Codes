using System;

namespace Structures
{
    public class Token : IComparable
    {
        private string key;

        public Token(string key)
        {
            this.Key = key;
        }

        private static String Normalize(string key)
        {
            string normalized = key;
            normalized = normalized.ToLower();
            return normalized;
        }

        public string Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = Normalize(value);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            var other = (Token)(obj);
            return this.Key == other.Key;
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }


        public override string ToString()
        {
            return String.Format("Token({0})", this.Key);
        }

        public int CompareTo(object obj)
        {
            // returns -1 if "this" object is less than "that" object
            // returns 0 if they are equal
            // returns 1 if "this" object is greater than "that" object
            if (obj == null)
                return 1;

            var that = obj as Token;
            if (that != null)
                return this.key.CompareTo(that.key);
            throw new ArgumentException("Object is not a token !");
        }
    }
}

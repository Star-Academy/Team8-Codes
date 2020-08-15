// Standard Library
using System;

namespace GoogleSharp.Src.Core.Structures {
    public class Token : IComparable {
        private string key;

        public Token (string key) {
            Key = key;
        }

        public string Key {
            get {
                return key;
            }
            set {
                key = Normalize (value);
            }
        }

        public override bool Equals (object obj) {
            if (obj is Token other)
                return Key == other.Key;
            return false;
        }

        public override int GetHashCode () {
            return Key.GetHashCode ();
        }

        public override string ToString () {
            return $"Token({key})";
        }

        public int CompareTo (object obj) {
            // returns -1 if "this" object is less than "that" object
            // returns 0 if they are equal
            // returns 1 if "this" object is greater than "that" object
            if (obj is Token that)
                return Key.CompareTo (that.Key);
            throw new ArgumentException ("Object is not a token !");
        }

        private static string Normalize (string key) {
            string normalized = key;
            normalized = normalized.ToLower ();
            return normalized;
        }
    }
}

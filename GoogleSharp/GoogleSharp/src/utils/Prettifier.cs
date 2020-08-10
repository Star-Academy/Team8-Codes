using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace GoogleSharp.Src.Utils
{
    public class Prettifier<T>
    {
        public const int MAX_ITEMS = 8;

        public static String Prettify(HashSet<T> inputSet)
        {
            List<T> itemList = new List<T>(inputSet);
            StringBuilder o = new StringBuilder();

            if (itemList.Count <= MAX_ITEMS)
                CollectItemStrings(itemList, o, 0, itemList.Count);
            else
            {
                CollectItemStrings(itemList, o, 0, MAX_ITEMS / 2);
                o.Append("\t    ...\n");
                CollectItemStrings(itemList, o, itemList.Count - MAX_ITEMS / 2, itemList.Count);
            }

            return o.ToString();
        }

        private static void CollectItemStrings(List<T> itemList, StringBuilder builder, int startIndex, int endIndex)
        {
            int maxSize = ("" + itemList.Count).Length;
            for (int idx = startIndex; idx < endIndex; idx++)
                builder.Append("\t" + LeftPad("" + (idx + 1), maxSize) + ") " + itemList[idx] + "\n");
        }

        private static string LeftPad(string s, int length)
        {
            if (s.Length >= length)
                return s;
            return s + Multiply(" ", length - s.Length);
        }

        private static string Multiply(String s, int multiplier)
        {
            return String.Concat(Enumerable.Repeat(s, multiplier));
        }
    }
}
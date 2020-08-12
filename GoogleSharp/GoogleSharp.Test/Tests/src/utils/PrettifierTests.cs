// Standard Library
using System;
using System.Collections.Generic;
using System.Linq;

// Nuget Packages
using Xunit;

// Internal
using GoogleSharp.Src.Utils;


namespace Tests.Src.Utils
{
    public class PrettifierTests
    {
        [Fact]
        public void Prettify_SmallHashSet_Success()
        {
            Assert.True(Prettifier<string>.MaxItems > 2);

            var inputSet = new HashSet<string>();
            inputSet.Add("hello");
            inputSet.Add("bye");

            string actual = Prettifier<string>.Prettify(inputSet);
            string expected = "\t1) hello\n\t2) bye\n";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Prettify_BigHashSet_Success()
        {
            int MaxItems = Prettifier<string>.MaxItems;
            Assert.True(MaxItems < 15);

            string expected = "\t" + String.Join("\n\t", Enumerable.Range(1, MaxItems / 2).Select(n => n + " ) testString" + n).ToArray());
            expected += "\n\t    ...\n\t";
            expected += String.Join("\n\t", Enumerable.Range(15 - MaxItems / 2 + 1, MaxItems / 2).Select(n => n + ") testString" + n).ToArray()) + "\n";

            var inputSet = new HashSet<string>(Enumerable.Range(1, 15).Select(n => "testString" + n).ToArray());
            string actual = Prettifier<string>.Prettify(inputSet);

            Assert.Equal(expected, actual);
        }
    }
}

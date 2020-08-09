using System;
using Xunit;
using Utils;
using System.Collections.Generic;

namespace GoogleSharp.Test
{
    public class TestPrettifier
    {
        [Fact]
        public void TestPrettifyHashSet()
        {
            var inputSet = new HashSet<string>();
            inputSet.Add("hello");
            inputSet.Add("bye");
            string actual = Prettifier<string>.Prettify(inputSet);
            string expected = "\t1) hello\n\t2) bye\n";
            Assert.Equal(expected, actual);
        }
    }
}

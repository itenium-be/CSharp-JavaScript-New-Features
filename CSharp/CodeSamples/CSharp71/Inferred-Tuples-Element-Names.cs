using System;
using Xunit;

namespace CodeSamples.CSharp71
{
    public class InferredTuplesElementNames
    {
        [Fact]
        public void HappyPath()
        {
            int count = 3;
            string label = "Three";

            // C# 7.0
            var before = (count: count, label: label);
            Assert.Equal(3, before.count);

            // C# 7.1
            var after = (count, label);
            Assert.Equal("Three", after.label);
        }
    }
}

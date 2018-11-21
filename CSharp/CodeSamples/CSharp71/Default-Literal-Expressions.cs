using System;
using Xunit;

namespace CodeSamples.CSharp71
{
    public class DefaultLiteralExpressions
    {
        [Fact]
        public void ClassesDefaultToNull()
        {
            Func<int, bool> fnBefore = default(Func<int, bool>);
            Func<int, bool> fnAfter = default;

            Assert.Null(fnBefore);
            Assert.Null(fnAfter);
        }

        [Fact]
        public void IntsToZero()
        {
            int intBefore = default(int);
            int intAfter = default;

            Assert.Equal(0, intBefore);
            Assert.Equal(0, intAfter);
        }
    }
}

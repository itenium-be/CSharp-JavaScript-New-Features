using Xunit;

namespace CodeSamples.CSharp72
{
    public class NonTrailingNamedArguments
    {
        [Fact]
        public void HappyPath()
        {
            // Call with the 2nd required argument after the 3rd optional argument
            Example(5, optionalInt: 1, requiredStr: "5");
        }

        void Example(int required, string requiredStr, int optionalInt = 10)
        {

        }
    }
}

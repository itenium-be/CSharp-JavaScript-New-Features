using Xunit;

namespace CodeSamples.CSharp72
{
    public class LeadingUnderscoresInNumericLiterals
    {
        [Fact]
        public void HappyPath()
        {
            int intValue = 85;
            int binaryValue = 0b_0101_0101;
            int hexValue = 0x_55;

            Assert.Equal(intValue, binaryValue);
            Assert.Equal(intValue, hexValue);
        }
    }
}

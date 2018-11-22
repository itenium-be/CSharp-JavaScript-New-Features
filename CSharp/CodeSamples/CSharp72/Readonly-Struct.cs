using Xunit;

namespace CodeSamples.CSharp72
{
    public class ReadonlyStruct
    {
        [Fact]
        public void HappyPath()
        {
            var name = new Name("Bob", "Sinclair", 15);
            Assert.Equal("Bob", name.FirstName);

            InParamExample(name);
            InParamExample(in name);
        }

        void InParamExample(in Name name)
        {
            // Compile error:
            // name = default;
        }
    }

    readonly struct Name
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        // Compile error:
        // public string MiddleName { get; set; }

        public Name(string first, string last) => (FirstName, LastName, Age) = (first, last, 10);

        public Name(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }

    /// <summary>
    /// Indicate that a struct accesses managed memory directly
    /// Must always be stack allocated
    /// </summary>
    ref struct Pointy
    {

    }
}

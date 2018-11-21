using System;
using Xunit;

namespace CodeSamples.CSharp72
{
    public class ConditionalRefExpressions
    {
        [Fact]
        public void HappyPath()
        {
            var arr = new[] { 5 };
            var otherArr = new[] { 6 };

            ref int r = ref (arr != null ? ref arr[0] : ref otherArr[0]);

            Assert.Equal(5, r);
        }

        [Fact]
        public void RefReturnsFromCSharp70()
        {
            var p = new Point(5);

            // normal behavior
            int x = p.GetX();
            x = 20;
            Assert.Equal("X is 5", p.Display());

            // ref local
            ref int refX = ref p.GetX();
            refX = 10;
            Assert.Equal("X is 10", p.Display());

            ref readonly int readOnlyRefX = ref p.GetX();
            // readOnlyRefX = 5; // Compile error
            int regularGetY = p.GetY();

            // C# 7.3 - reassign local ref variables
            refX = ref p.GetX();
        }
    }

    public class Point
    {
        private int _x;
        private readonly int _y;

        public Point(int x)
        {
            _x = x;
        }

        public ref int GetX()
        {
            return ref _x;
        }

        public ref readonly int GetY()
        {
            return ref _y;
        }

        public string Display()
        {
            return $"X is {_x}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using CodeSamples.CSharp72;
using Xunit;

namespace CodeSamples.CSharp73
{
    public class EnhancedGenericConstraints
    {
        #region Enums
        [Fact]
        public void SystemEnum()
        {
            Dictionary<int, string> result = EnumNamedValues<Gender>();
            Assert.Equal(2, result.Count);
        }

        enum Gender { Male, Female }

        static Dictionary<int, string> EnumNamedValues<T>() where T : System.Enum
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
                result.Add(item, Enum.GetName(typeof(T), item));

            return result;
        }
        #endregion

        #region Delegates
        [Fact]
        public void SystemDelegate()
        {
            int count = 0;

            Func<int> addOne = () => count += 1;
            Func<int> addTen = () => count += 10;

            var combined = TypeSafeCombine(addOne, addTen);
            Assert.Equal(11, combined());
        }

        public static T TypeSafeCombine<T>(T source, T target) where T : System.Delegate
        {
            return Delegate.Combine(source, target) as T;
        }
        #endregion

        #region Unmanaged
        // unsafe: Need to turn on project Build property: "Allow unsafe code"

        [Fact]
        public void Unmanaged()
        {
            var thing = new Point3D { X = 1, Y = 2, Z = 3 };
            var storage = ToByteArray(thing);

            foreach (var t in storage)
                Debug.Write($"{t:X2}, ");
        }

        public static unsafe byte[] ToByteArray<T>(T argument) where T : unmanaged
        {
            int size = sizeof(T);
            var result = new byte[size];

            var p = (byte*)&argument;
            for (int i = 0; i < size; i++)
                result[i] = *p++;

            return result;
        }

        public struct Point3D
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }
        #endregion
    }
}

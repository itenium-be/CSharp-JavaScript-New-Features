# Enhanced generic constraints

**Enums**  
```c#
static Dictionary<int, string> EnumNamedValues<T>() where T : System.Enum
{
   var result = new Dictionary<int, string>();
   var values = Enum.GetValues(typeof(T));

   foreach (int item in values)
       result.Add(item, Enum.GetName(typeof(T), item));

   return result;
}
```

**Delegates**  
```c#
public static T TypeSafeCombine<T>(T source, T target) where T : System.Delegate
{
   return Delegate.Combine(source, target) as T;
}

// Usage
Action logOne = () => Console.Write("1");
Action logTen = () => Console.Write("10");
var combined = TypeSafeCombine(addOne, addTen);
```

# More uses for `out`

```c#
public class B
{
   public B(int i, out int j)
   {
      j = i;
   }

   bool IsPositive = int.TryParse("5", out int nr) && nr > 0;
   // and also: bool IsPositive { get; } = int.TryParse(...)
}
```

# Attributes Targeting Fields of Auto-Implemented Properties

```c#
[field: NonSerialized]
public double X { get; set; }
```


# Unmanaged

`unsafe`: Need to turn on project Build property: "Allow unsafe code"

## unmanaged generic constraint

```c#
class UnManagedWrapper<T> where T : unmanaged { }
```

## `stackalloc` arrays support initializers

stackalloc: Allocate a block of memory on the stack. (like c++ `_malloca`)

```c#
// Worked already
var arr = new int[3] {1, 2, 3};
var arr2 = new [] {1, 2, 3};

// Now this works also
int* pArr = stackalloc int[3] {1, 2, 3};
int* pArr2 = stackalloc int[] {1, 2, 3};
Span<int> arr = stackalloc[] {1, 2, 3};
```

Example:  
```c#
const int arraySize = 20;
int* fib = stackalloc int[arraySize];
int* p = fib;
// The sequence begins with 1, 1.
*p++ = *p++ = 1;
for (int i = 2; i < arraySize; ++i, ++p)
{
    // Sum the previous two numbers.
    *p = p[-1] + p[-2];
}
for (int i = 0; i < arraySize; ++i)
{
    Console.WriteLine(fib[i]);
}
```

## More uses for `fixed`

The `fixed` statement prevents the garbage collector from relocating a movable variable.

```c#
unsafe struct S
{
    public fixed int myFixedField[10];
}

// Now
class C
{
    static S s = new S();

    unsafe public void M()
    {
        int p = s.myFixedField[5];
    }
}

// Before
class C
{
    static S s = new S();

    unsafe public void M()
    {
        fixed (int* ptr = s.myFixedField)
        {
            int p = ptr[5];
        }
    }
}
```

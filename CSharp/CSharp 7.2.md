# Non-trailing named arguments

```c#
// Definition
void Example(int required, string requiredStr, int optionalInt = 10) {}

// Call with the 2nd required argument after the 3rd optional argument
Example(5, optionalInt: 1, requiredStr: "5");
```

Mostly useful for COM (Component Object Model) to help reduce the many `Type.Missing` argument values.


# Leading underscores in numeric literals

Was part of C# 7.0, but now starting with an `_` is possible. (yaye!)  
Works for binary (`0b`) and hex (`0x`) values.  

```c#
int binaryValue = 0b_0101_0101;
```


# private protected access modifier

Accessible by the containing class and in **derived classes** if they are declared in the **same assembly**.

`protected internal` already existed which means accessible in  
- Containing class
- Derived classes in any assembly
- Other classes in the same assembly


# Write safe and efficient C# code

Changes primarily used by `Span<T>`.

## readonly struct

```c#
readonly struct Name
{
	public string FirstName { get; }
	public string LastName { get; }

	// Compile error:
	// public string MiddleName { get; set; }

	public Name(string firstName, string lastName)
   {
      FirstName = firstName;
      LastName = lastName;
   }
}
```

## in parameters

Save copies by passing `readonly structs` with `in`:  
May have a negative performance impact when used with regular structs.  
```c#
int readonlyArgument = 44;
InParamExample(in readonlyArgument); // "in" is optional

void InParamExample(in int number)
{
   // Compile error:
   // number = 19;
}
```

`in` is optional, except when the method is overload as follows: `fn(int number)` and `fn(in int number)`.


## Conditional `ref` expressions

7.0 added `ref returns`  
```c#
public class XPoint
{
   private int X;

   public XPoint(int x) {
      X = x;
   }

   public ref int GetX() {
      return ref X;
   }
      
   public void Display() {
      Console.WriteLine($"X is {X}");
   }
}

// Which does exactly what you'd think
var xp = new XPoint(5);

// normal behavior
int x = xp.GetX();
x = 20;
xp.Display(); // X is 5

// ref local
ref int refX = ref xp.GetX();
refX = 10;
xp.Display(); // X is 10
```


7.2 adds this capability to the ternary operator.  
```c#
var arr = new[] { 5 };
var otherArr = new[] { 6 };
ref int r = ref (arr != null ? ref arr[0] : ref otherArr[0]);
```

# Async main for console apps

Async/await away in your Mains.

```csharp
public static Task Main() {}
public static Task<int> Main() {}
public static Task Main(string[] args) {}
public static Task<int> Main(string[] args) {}
```

# Default Literal Expressions

One no longer needs to be specify the type if it can be inferred.

```c#
Func<int, bool> fn = default(Func<int, bool>);
Func<int, bool> fn = default;
```


# Inferred Tuples Element Names

Tuples but with user-defined property names instead of `Item1`, `Item2`
etc were introduced in C# 7.0.  


```c#
int count = 3;
string label = "Three";

// C# 7.0
var pair = (count: count, label: label);

// C# 7.1
var pair = (count, label);
```

Starting from C# 7.3 tuples support `==` and `!=`.

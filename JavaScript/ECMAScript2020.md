Some things that will probably get into 2020 (or later) versions.


# Strings

Improved `Function.prototype.toString`

`String.prototype.trimStart` and `End`.


# Array.prototype.flatMap

```js
function flatMap(arr, mapFunc) {
    return arr.reduce(
        (prev, x) => prev.concat(mapFunc(x)),
        []
    );
}
```

# Array.prototype.flat

```js
['a', ['b','c'], ['d']].flat();
```

# BigInt


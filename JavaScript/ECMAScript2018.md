
# ECMAScript2018

## More async stuff

Added `Promise.prototype.finally`. Even with this addition, you may still benefit
from a library like Bluebird if you have needs
[beyond basic use cases](https://stackoverflow.com/questions/34960886/are-there-still-reasons-to-use-promise-libraries-like-q-or-bluebird-now-that-we).


### Asynchronous iteration

Synchronous Symbol.iterator introduced in ECMAScript2015 is used by `for...of`.
(Not supported by IE)
```js
const iterable = ['a', 'b'];
const iterator = iterable[Symbol.iterator]();
iterator.next();
// { value: 'a', done: false }
iterator.next();
// { value: 'b', done: false }
iterator.next();
// { value: undefined, done: true }
```

Now we get the same
```js
for (const line of readLines()) {
    console.log(line);
}


async function* prefixLines(asyncIterable) {
    for await (const line of asyncIterable) {
        yield '> ' + line;
    }
}

async function* readLines() {
    yield 'line 1';
    yield 'line 2';
    yield 'line 3';
}
```


## Rest/Spread Properties

Existing uses:
- Rest: Array destructuring: `[a, b, ...rest] = [1, 2, 3, 4]`
- Rest: Parameter definitions: `function fn(a, b, ...rest)`
- Spread: Arrays: `[1, 2, ...[3, 4]]`
- Spread: Function calls: `fn(1, 2, ...[3, 4])`

The same is now added for objects  
```js
let {a, b, ...rest} = {a: 10, b: 20, c: 30, d: 40}

// TODO: add example of deep nesting
let rgba = {r: 0, g: 0, b: 0, a: 0.5}
```

## Template Literals

Was part of ECMAScript 2015
```js
`String interpolation ${nr}`
```

Got tripped over the notation with the C# one being 
```c#
$"String interpolation {nr}"
```

Template Tags
ES2018 revision of illegal escape sequences
--> So small, better to put in ## Other?

```
function latex(str) { 
 return { "cooked": str[0], "raw": str.raw[0] }
} 

latex`\unicode`
```


## RegEx


# More async stuff

Added `Promise.prototype.finally`. Even with this addition, you may still benefit
from a library like Bluebird if you have needs
[beyond basic use cases](https://stackoverflow.com/questions/34960886/are-there-still-reasons-to-use-promise-libraries-like-q-or-bluebird-now-that-we).


## Asynchronous iteration

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

Now we get the same `for...of` asynchronously:  
```js
async function* readLines() {
    yield 'line 1';
    yield 'line 2';
    await sleep(2500);
    yield Promise.resolve('line 3');
}

function sleep(time) {
  return new Promise(resolve => setTimeout(resolve, time));
}

(async function() {
	for await (const line of readLines()) {
   	console.log(line);
	}
})();
```


# Rest/Spread Properties

Existing uses:
- Rest: Array destructuring: `[a, b, ...rest] = [1, 2, 3, 4]`
- Rest: Parameter definitions: `function fn(a, b, ...rest)`
- Spread: Arrays: `[1, 2, ...[3, 4]]`
- Spread: Function calls: `fn(1, 2, ...[3, 4])`

The same is now added for objects  
```js
let {a, b, ...rest} = {a: 10, b: 20, c: 30, d: 40}

let box = {pos: {x: 0, y: 5}, size: {width: 100, height: 200}, color: 'red'};
let {pos: {x, ...justY}, ...sizeAndColor} = box;
// justY = {y: 5}
// sizeAndColor = {size: ..., color: 'red'}
```

# Template Literals

Was part of ECMAScript2015
```js
`String interpolation ${nr}`
```

Got tripped over the notation with the C# one being 
```c#
$"String interpolation {nr}"
```

## Template Tags

ES2018 revision of illegal escape sequences

```js
function latex(str) { 
 return { "cooked": str[0], "raw": str.raw[0] }
} 

latex`\unicode`
```


# RegEx

In 2015 there was a Regex session by Juliette Reinders Folmer.

## Named capture groups

```js
let RE_DATE = /(?<year>[0-9]{4})-(?<month>[0-9]{2})-(?<day>[0-9]{2})/;

const matchObj = RE_DATE.exec('1999-12-31');
const year = matchObj.groups.year; // 1999, or: matchObj[1]
const month = matchObj.groups.month; // 12

'1999-12-31'.replace(RE_DATE, '$<day>/$<month>/$<year>')
// 31/12/1999
```

Backreferences still work with indexes (`\1`) and now also with `\k<prevNamedGroup>`
```js
let RE_TWICE = /^(?<word>[a-z]+)!\k<word>!\1$/;
RE_TWICE.test('abc!abc!abc'); // true
RE_TWICE.test('abc!abc!ab'); // false
```

## Lookbehind zero-width assertions

Match only when a number is preceded with a € but do not capture the € itself.  
```js
/(?<=€)\d+/.exec('€15')
```

Negative lookbehind: `(?<!a)b` (a 'b' not preceded by an 'a')

Lookaheads already existed: `(?=positive)` and `(?!negative)`  
```js
const people = `
- Bob (vegetarian)
- Billa (vegan)
- Alice
`;

/-\s(\w+?)\s(?=\(vegan\))/g.exec(people)
```


## Added missing s (dotAll) flag

The dot (.) in regular expressions doesn't match line terminator.

```js
/./.test('\n')
// false

/[\s\S]/.test('\n')
// true
```

The `/s` (singleline) flag changes this behavior
```js
/./s.dotAll
new RegExp('.', 's').dotAll
// true

/./s.test('\n')
// true
```

ECMAScript line terminators:  
- \u000A: Line Feed (LF) (\n)
- \u000D: Carriage Return (CR) (\r)
- \u2028: Line Separator
- \u2029: Paragraph Separator


The `/m` (multiline) flag already existed.  
Changes the behavior of `^$` to match the beginning and end of all lines rather than the entire text.


## Unicode property escapes

```
/\p{White_Space}/u.test('\t \n\r')
// true because of the /u (unicode) flag

/\p{Currency_Symbol}/u.test('£')
```

Others:  
- LATIN CAPITAL LETTER A
- GRINNING FACE (😀)
- Lowercase_Letter
- Script=Latin
- Surrogate (\u{D83D})

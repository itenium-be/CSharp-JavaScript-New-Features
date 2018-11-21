# Exponentiation operator

```js
let squared = 2 ** 3;
let squared = 2 * 2 * 2;
let squared = Math.pow(2, 3);

squared **= 2;
```

# Array.prototype.includes

```js
['a', 'b', 'c'].includes('a')
['a', 'b', 'c'].indexOf('a') !== -1
```

Because `contains` was in use in over a million live websites using Mootools
which was implemented in a non-compatible way, the function needed to be renamed.

https://esdiscuss.org/topic/having-a-non-enumerable-array-prototype-contains-may-not-be-web-compatible
https://gist.github.com/fakedarren/28953b01e455078fb4f8

# Object

`Object.keys` already existed, now we also got `Object.values` and `Object.entries`

```js
const arr = {a: 1, b: true};
for (let [key, value] of Object.entries(arr)) {
	console.log(`${key} is ${value}`);
}
```


# Strings

`"string".padStart(length, 'char(s)')` and `padEnd()`  
Start/End to not make things confusing for right-to-left languages.

**Aligning moneys**  
```js
[200, 1, 50].map(n => '€' + n.toString().padStart(5, ' ')).join('\n')
```


# Functions

Allow a trailing comma after the last parameter/argument when defining/calling a function.  
Big fan here because of the reduced `git diff` footprint when adding parameters to existing functions.


# async/await

Syntactic sugar for unwrapping promises in a more convenient way.
async functions return a Promise.

```js
// Using Promises:
function getAmount(userId) {
    return getUser(userId).then(getBankBalance);
}

// Using async/await:
async function getAmount(userId) {
    const user = await getUser(userId);
    const amount = await getBankBalance(user);
    return amount;
}

function getUser(userId) {
    return Promise.resolve({id: userId, name: 'Bob'});
}

function getBankBalance(user) {
    return new Promise((resolve, reject) => {
        if (user.name === 'Bob') {
            resolve('$42');
        } else {
            reject('User not found');
        }
    });
}
```


# Other

## getOwnPropertyDescriptors

```js
Object.getOwnPropertyDescriptors({property1: 5});
// {property1: {value: 5, writable: true, enumerable: true, configurable: true}}
```


## Shared Memory and Atomics

Browser support rather poor.

```js
// Concurrent agents
var w = new Worker("hard.js");
w.postMessage('ping');
w.onmessage = function (ev) {
  console.log(ev.data);
}

// hard.js Worker (global functions)
onmessage = function(ev) {
  console.log(ev.data);
  postMessage('pong');
}


var sab = new SharedArrayBuffer(Int32Array.BYTES_PER_ELEMENT * 100000); // 100000 primes
var ia = new Int32Array(sab);  // ia.length == 100000
var primes = new PrimeGenerator();
for (let i = 0; i < ia.length; i++)
   ia[i] = primes.next();
w.postMessage(ia);


Atomics.add(ia, 112, 1); // Add 1 to index 112
```

https://github.com/tc39/ecmascript_sharedmem/blob/master/TUTORIAL.md


Operation                                     | Function
----------------------------------------------|----------
load(array, index)                            | return the value of array[index]
store(array, index, value)                    | store value in array[index], return value
compareExchange(array, index, oldval, newval) | if array[index] == oldval then store newval in array[index], return the old value of array[index]
exchange(array, index, value)                 | store value in array[index], return the old value of array[index]
add(array, index, value)                      | add value to array[index], return the old value of array[index]
sub(array, index, value)                      | subtract value from array[index], return the old value of array[index]
and(array, index, value)                      | bitwise-and value into array[index], return the old value of array[index]
or(array, index, value)                       | bitwise-or value into array[index], return the old value of array[index]
xor(array, index, value)                      | bitwise-xor value into array[index], return the old value of array[index]

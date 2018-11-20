# ECMAScript2017

## Object

`Object.keys` already existed, now we also got `Object.values` and `Object.entries`

```js
for (let [key, value] of Object.entries(arr)) {}
```

Object.getOwnPropertyDescriptors

Object.assign does not shallow copies getters and setters.



## Strings

"string".padStart(length, 'char(s)') and padEnd()

- Right aligning strings
- Prepending numbers with zeroes


## Functions

Allow a trailing comma after the last parameter/argument when defining/calling a function.  
Big fan here because of the reduced `git diff` footprint when adding parameters to existing functions.


## async/await

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

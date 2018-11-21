Two stage four proposals

# Optional catch binding

```js
try {
	// 
} catch {
	// 
}
```

Currently:  
```js
try {
	// ...
} catch (someUnusedVariableNameLintersComplainAbout) { // eslint-disable-line
	// ...
}
```


# Json Superset

JSON can contain
- U+2028 Line Separator
- U+2029 Paragraph Separator

But ECMAScript strings could not.

The "Test 262" tests for U+2028 and U+2029 changed from:  
```js
assert.throws(SyntaxError, function() {
  eval("'\u2028str\u2028ing\u2028'");
});
```

to:  
```js
assert.sameValue(eval("'\u2028'"), "\u2028");
```

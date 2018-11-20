
http://es6-features.org/



# ECMAScript2015 (ES6)


# Scoping
let/const



# Functions
default parameter values

rest parameter
function f (x, y, ...a) {
spread operator
f(1, 2, ...[3, 4, 5])

## Arrow-Functions



# Template String


# Properties

property shorthand
obj = { x, y }
obj = { x: x, y: y };

Computed Property Names

Method Properties
obj = { foo() {} }
obj = { foo: foo() {} }


# Destructuring

var [one, , three] = [1, 2, 3]
[ b, a ] = [ a, b ]

const { r, g, [b1, b2, b3] } = (() => ({r: 0, g: 0, b: '255'}))();


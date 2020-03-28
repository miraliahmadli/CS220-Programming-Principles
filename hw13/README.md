# CS220 - HW13

Please read carefully the problems and fill out several fs files that we show
below (*not* fsi files). You can use any language features: your function
doesn't need to be purely functional (although function implementation is
preferred).  The only restriction is that you cannot use external libraries: you
can use any APIs from .NET core, but not from other external packages. The
deadline is 23:59:59, 5/31.

### Introduction

In this assignment, you will write an evaluator for our simple calculator
language. Note that this is the same language that we used in the previous
homework assignment. Your goal here is to simply implement a function called
`Evaluator.eval`. You will learn how easy it is to write an interpreter in F#!

### Simple Calculator Language

To remind you, this is a simple language that is a subset of F#. If you
copy-paste a program written in this language to FSI (REPL), it should work too.
This language allows only straightline programs without nested let-bindings, and
only four primitive operators are used in this language.

The language supports only four primitive operators: addition, subtraction,
multiplication, and division. All these operators run on an integer value (`int`
type), and even a result will be an integer. For example, `4 / 3 = 1`.
Additionally, we can have let-bindings which basically binds a name to a value.

For simplicity, this language does not use lexical scoping: we cannot have
nested let-bindings. You can only have straight-line code in this language. For
example, the following expression is **not** allowed:

```
let x =
  let a = 42 * 42
  a * a
```

### Evaluation

All you need to do is to implement the `Evaluator.eval` function, which takes in
a list of expressions as input, and returns an `int option` as output. Each
expression in the list corresponds to a statement of a program in order. When
evaluating each statement, you should check whether the variable is indeed
accessible. When there are two or more let-bindings for the same symbol, then
you should use the last value. For example, in the following case, `y` is 2 and
`z` is 4.

```
let x = 1
let y = x + x
let x = 2
let z = x * x
```

A let-binding itself does not result in a value. If there is a program where the
last statement is a let-binding, the `eval` function should return `None`.
Otherwise, it should return a "Some" value.

### Error Handling

When there is an undeclared variable, you should raise
`UnknownVariableException`, which is defined in `Evaluator.fs`. For example, we
expect the exception in the following case:

```
let x = 1
x + y
```

If you encounter too large/small value that is not within the range of a valid
`int`,  you should raise `IntOverflowException`, which is defined in
`Evaluator.fs`. At any point during evaluation, you should detect such a case,
and raise an exception. For example, we expect the excpetion in the following
case:

```
let x = 2147483647
x + 1 - 1
```

### Note

This homework is independent from the previous one in a sense that we do not
require you to fully implement the parser to complete this homework.

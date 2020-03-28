# CS220 - HW12

Please read carefully the problems and fill out several fs files that we show
below (*not* fsi files). You can use any language features: your function
doesn't need to be purely functional (although function implementation is
preferred).  The only restriction is that you cannot use external libraries: you
can use any APIs from .NET core, but not from other external packages. The
deadline is 23:59:59, 5/28.

### Introduction

In this assignment, you will write a parser for a simple calculator language
that we show below. We provide almost the whole implementation of the parser,
and you will have to simply fill out some functions to make it work. You can see
the example shown in `Program.fs` to learn how the language looks like.

### Simple Calculator Language

This language does not really have any complex features, but support only four
basic operators: addition, subtraction, multiplication, and division. All these
operators run on an integer value (`int` type), and even a result will be an
integer. For example, `4 / 3 = 1`. This language allows us to create
let-bindings. Names for a let-binding should start with a English letter, and
the rest of the name can contain any alphanumeric characters.

For simplicity, this language does not use lexical scoping: we cannot have
nested let-bindings. You can only have straight-line code in this language. For
example, the following expression is **not** allowed:

```
let x =
  let a = 42 * 42
  a * a
```

Note that this language is indeed a "subset" of F#. If you copy-paste a program
written in this language to FSI (REPL), it should work too.

### Parser Library

The `ParserCombinator.fs` file contains several useful functions for building
monadic parsers, most of which are discussed in the class. Please read them
carefully. However, you'd better not modify them for this homework. We will
overwrite the file for grading.

### Parser Implementation

The `Parser.fs` file is the one that you want to modify for this homework. We
clearly marked functions that you want to implement (with `failwith`). Note, the
grammar for the language is clearly shown in the skeleton code.

There are five parsers that you need to implement:
- `string`: a string parser.
- `num`: a number expression parser (the `Num` expression defined in `AST.fs`).
- `letbinding`: a let-binding expression parser (the `Let` expression in
  `AST.fs`).
- `binop`: a binary operator parser (such as Add, Sub, etc.).
- `stmt`: this represents a statement parser, which is the basic building block
  of this language.

### Dealing with Whitespace Characters

In normal parser implementation, whitespace characters are not a particular
concern because they are handled by a
[lexer](https://en.wikipedia.org/wiki/Lexical_analysis). But in this simple
implementation, we should always consider whitespace characters. For example,
`"1 + 1"` should be equivalent to `"1+1"`, but without considering the space
characters they will result in two different parsing results. Thus, while
implementing your parser, you should always consider whitespace characters.

### Operator Precedence

The current code template does not properly handle operator precedence. For
example, given `5 - 4 + 1`, we may end up parsing it as `5 - (4 + 1)`. This is a
known issue, you don't need to resolve it. For simplicity, we assume that input
source code is always given with explicitly parentheses.

# CS220 - HW6

Please read carefully the problems and fill out the `Library.fs` file. Note that
the unit tests will be replaced to new ones when we grade your homework, and
your grade will be based on the number of passed test cases. We recommend you to
modify only the `Library.fs` file for your homework. Even if you have local
modifications, you should not push your modifications to the other files. You
should not use imperative language features, such as for loop and while loop, to
solve these problems. The deadline is 23:59:59, 4/1.

For this homework, you cannot use built-in F# functions nor modules, such as
`List.length`. We will give zero point for this homework if you have used any of
the built-in functions except consing operator `(::)` and the equality operator
`(=)`.

### Problem 1

Write a function `removeOdd` that takes an integer list (`int list`) and returns
an integer list without odd numbers. The resulting list should preserve the
order of the original list. For example, given `[ 1; 2; 3 ]` the function
returns `[ 2 ]`.

```fsharp
val removeOdd : int list -> int list
```

### Problem 2

Write a function `getSmallest` that takes in an integer list and returns a
smallest number in the list if exists. For example, given `[ 1; 2; 3 ]` the
function returns `Some 1`. If the given list is empty, than the function returns
`None`.

```fsharp
val getSmallest : int list -> int option
```

### Problem 3

Write a function `take` that takes in a list and an unsigned integer `n`
(uint32), and returns the first `n` elements from the list. For example, `take
[ "a"; "b"; "c" ] 1u` returns `[ "a" ]`. If `n` is larger than the length of the
list, then the function returns the list as it is. When `n` is zero, the
function returns an empty list.

```fsharp
val take: 'a list -> uint32 -> 'a list
```

### Problem 4

Write a function `runLength` that takes in a list and returns a list of pairs by
applying run-length encoding. Specifically, the function replace `n` consecutive
elements into a pair of (element, number of appearance). For example, when a
list `[ 1; 2; 2; 2; 3; 3 ]` is given, the function returns `[ (1, 1); (2, 3);
(3, 2) ]`.

```fsharp
val runLength : 'a list -> ('a * int) list
```

### Problem 5

Write a function `isPalindrome` that takes in a list and returns a boolean
indicating whether the list contains a palindrome. A palindrome is a list that
reads the same backward as forward. For example, `[ 1; 2; 1 ]` and `[ ]` are a
palindrome, but `[ 1; 2; 3 ]` is not.

```fsharp
val isPalindrome : 'a list -> bool
```

### Problem 6

Write a function `slice` that takes in a list and two integers (`a` and `b`),
and returns a sublist of the given one. Specifically, the resulting list should
contain elements between the `a`th and `b`th element of the original list. For
example, `slice [ 1; 2; 3; 4; 5 ] 2 4` should return `[ 2; 3; 4 ]`, and `slice [
1; 2; 3 ] 2 4` should return `[ 2; 3 ]`. When all the integer indexes between
`a` and `b` are not in the range of the given list, this function returns an
empty list `[]`.  Both `slice lst 2 4` and `slice lst 4 2` return the same
result.

```fsharp
val slice : 'a list -> int -> int -> 'a list
```


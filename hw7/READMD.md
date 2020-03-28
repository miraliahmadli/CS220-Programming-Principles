# CS220 - HW7

Please read carefully the problems and fill out the `Library.fs` file. Note that
the unit tests will be replaced to new ones when we grade your homework, and
your grade will be based on the number of passed test cases. We recommend you to
modify only the `Library.fs` file for your homework. Even if you have local
modifications, you should not push your modifications to the other files. Please
do not use imperative language features such as for loop and while loop to solve
these problems. You can use built-in functions, such as `List.length` and
`List.fold`, for this homework. The only restriction is to not use
imperative/mutable language features. The deadline is 23:59:59, 4/8.

### Problem 1

Write a function `countLetter` that takes in two strings `s1` and `s2` as input,
and returns a number of `s2`s appeared in `s1`. For example, if `s1` is "my name
is Ann", and `s2` is "n", then the function should return 3UL because there are
three "n"s in the given string `s1`. If either `s1` or `s2` is an empty string
`""`, then this function returns 0UL.

```fsharp
val countLetter : string -> string -> uint64
```

### Problem 2

Write a function `diagonal` that takes in a square matrix (type SqMatrix defined
in `Types.fs`) and returns a list (`'a list`) representing the main diagonal of
the matrix. We assume that SqMatrix can only be created through the
`SqMatrix.init` function defined in `Types.fs`.

```fsharp
val diagonal : 'a SqMatrix -> 'a list
```

### Problem 3

Write a function `transpose` that takes in a square matrix defined in
`Types.fs`, and returns a new matrix, which is the transpose of the given
matrix.

```fsharp
val transpose: 'a SqMatrix -> 'a SqMatrix
```

### Problem 4

Write a function `rotate` that takes in a list (`'a list`) and an integer `N`,
and returns a new list by rotating the given list. When `N` is a positive
number, the function will rotate the list to the right by `N`. When `N` is
negative, the function will rotate the list to the left by `-N`. For example,
`rotate [1; 2; 3; 4] 2` will result in `[3; 4; 1; 2]`. Note that one can rotate
the list for any arbitrary iterations: the absolute value of `N` can be bigger
than the length of the given list.

```fsharp
val rotate : 'a list -> int -> 'a list
```

### Problem 5

Write a function `hanoi` that takes in three integers `a`, `b`, and `n`, and
returns a list of integer pairs, which represents a sequence of actions for the
game [Tower of Hanoi](https://en.wikipedia.org/wiki/Tower_of_Hanoi). The third
argument `n` represents how many disks we have when we start the game, and `a`
and `b` represent the start and the end pole, respectively. There are a total of
three poles, and the goal of the game is to move the `n` disks at `a`th pole to
the `b`th pole while obeying the following rules:

- Only one disk may be moved at a time.
- Each move consists of taking the top (smallest) disk from one of the rods and
  sliding it onto another rod, on top of the other disks that may already be
  present on that rod.
- No disk may be placed on top of a smaller disk.

The `hanoi` function returns an optimal solution, which is a minimal list of
moves to make. Each move is represented as an integer pair indicating from which
pole to which pole we move a disk. For example, a pair `(1, 2)` means we move a
disk from the first pole to the second pole.

**We will assume that the parameter values `a` and `b`  will always 1, 2, or
3.**


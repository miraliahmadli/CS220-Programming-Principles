# CS220 - HW3

Please read carefully the problems and fill out the `Library.fs` file. Note that
the unit tests will be replaced to new ones when we grade your homework, and
your grade will be based on the number of passed test cases. We recommend you to
modify only the `Library.fs` file for your homework. Please do not use
imperative language features such as for loop and while loop to solve these
problems. The deadline is 23:59:59, 3/15.

### Problem 1

Write a function `prob1` that takes in a number `n` (int) and returns the n-th
[harmonic number](https://en.wikipedia.org/wiki/Harmonic_number) (float). For
any error case, this function should return `nan`.

```fsharp
val prob1: int -> float
```

### Problem 2

How many different ways can we make change of a given amount of money in Korean
coins? Suppose we have 5 different kinds of coins: 500-won coins, 100-won coins,
50-won coins, 10-won coins, and 1-won coins. Write a function `prob2` that takes
in an amount of money in won, and returns the number of possible
combinations. This function should return `-1` if an errorneous input is given,
e.g., when negative amount is given.

```fsharp
val prob2: int -> int
```

### Problem 3

Write a function `prob3` that computes GCD (Greatest Common Divisor) of two
given integers. This function should return `-1` for any error cases.

```fsharp
val prob3: int -> int -> int
```

### Problem 4

Write a function `prob4` that takes in an integer `n` and returns an integer
`1 + 2 + ... + (n-1) + n`. If n is a negative integer, this function should
return `-1`. This function should return `-1` for any error cases.

```fsharp
val prob4: int -> int
```

### Problem 5

Write a function `prob5` that takes in two integers `m` and `n`, and returns an
integer `m + (m+1) + (m+2) + ... + (m + (n-1)) + (m + n)`. This function should
return `-1` for any error cases. For instance, if `n` is negative, the function
should return `-1`.

```fsharp
val prob5: int -> int -> int
```

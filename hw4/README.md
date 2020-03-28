# CS220 - HW4

Please read carefully the problems and fill out the `Library.fs` file. Note that
the unit tests will be replaced to new ones when we grade your homework, and
your grade will be based on the number of passed test cases. We recommend you to
modify only the `Library.fs` file for your homework. Even if you have local
modifications for the other files, you should not push the modifications. Please
do not use imperative language features such as for loop and while loop to solve
these problems. The deadline is 23:59:59, 3/19.

**You will get zero point for HW4, if you use imperative language constructs,
such as FOR loop, WHILE loop, `mutable` variables, etc., in any one of the
problems.**

### Problem 1

Write a function `prob1` that takes in two positive integers `a` and `b`, and
returns `N` where `N` is the number of possible `n` such that satisfies the
following three conditions: (1) `a <= n <= b`; (2) `n` is divisible by 7; and
(3) `n` is not a multiple of `5`. Always return `-1` for all error cases, such
as when `a > b` or when `b < 0`.

```fsharp
val prob1 : int -> int -> int
```

### Problem 2

Declare a function `pow` that takes in a string `s` and an integer `n`, and
returns a string that repeats `s` for `n` times. For example, `pow "abc" 3`
should return "abcabcabc". When `n` is zero, the function returns an empty
string, and when `n` is negative, it returns a string that repeats reversed `s`
for `-n` times. For example, `pow "abc" -3` will return "cbacbacba".

```fsharp
val pow: string -> int -> string
```

### Problem 3

Write a function `smallestDivisor` that takes in an unsigned integer `n`, and
returns the smallest integral divisor of `n` that is greater than 1. For
example, given 45, the function will return 3 (`45 % 3 = 0`). This function
returns `0` for all error cases, such as when the given number is 1.

```fsharp
val smallestDivisor : uint32 -> uint32
```

### Problem 4

Write a function `isPrime` that takes in an unsigned integer, and check if it is
a prime number or not. If the number is prime, then the function returns true.
Otherwise, it returns false. Hint: use the `smallestDivisor` function of problem
3.

```fsharp
val isPrime : uint32 -> bool
```

### Problem 5

Write a function `isFeasible` that takes in three unsigned integers `a`, `b`,
and `c`, and returns boolean indicating whether one can obtain `c` by combining
all the unsigned integers from `a` to `b` with either plus or minus operator.
Specifically, for all unsigned integers `a <= n <= b`, we concatenate them in
the order using an operator OP: `(a) OP (a+1) OP (a+2) OP ... OP (b-1) OP (b)`,
where OP can be either `+` or `-`. For example, `isFeasible 1 3 0` returns
`true`, because we can obtain 0 by `1 + 2 - 3 = 0`. However, `isFeasible 1 3 4`
returns `false`, because we cannot obtain 4 with any combination. For all error
cases, this function returns false. For example, when `a > b`, the function
simply returns false.

```fsharp
val isFeasible : uint32 -> uint32 -> uint32 -> bool
```


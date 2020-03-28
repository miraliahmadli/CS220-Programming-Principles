# CS220 - HW5

Please read carefully the problems and fill out the `Library.fs` file. Note that
the unit tests will be replaced to new ones when we grade your homework, and
your grade will be based on the number of passed test cases. We recommend you to
modify only the `Library.fs` file for your homework. Even if you have local
modifications, you should not push your modifications to the other files. Please
do not use imperative language features such as for loop and while loop to solve
these problems. The deadline is 23:59:59, 3/XX.

### Problem 1

Let the Shape type be:
```fsharp
type Shape =
/// A circle of a radius.
| Circle of float
/// A square with a side length.
| Square of float
/// A triangle with side lengths.
| Triangle of float * float * float
```

Write a function `area`, which computes the area of a given shape. You can
assume that the Shape type is well-formed, i.e., we will construct a Shape with
a valid values. We will *not* have a Circle with negative radius for instance.

```fsharp
val area : Shape -> float
```

### Problem 2

We learned in the class how we can declare pairs (tuples) in F#. For example, we
can create a pair of two integers as follows:
```fsharp
(1, 2)
```
In this problem, however, we will define a pair using a function. Specifically,
we define a constructor function for a pair of integers as follows:
```fsharp
let pair (x: int) (y: int) m : int = m x y
```
With the pair function we can create a pair as follows:
```fsharp
let p = pair 1 2
```
Define a funciton `fst` that returns the first element of the pair. For example,
`pair 1 2 |> fst` should return 1.

### Problem 3

Consider a data type `Time` representing a time of day:
```fsharp
type AMPM =
  | AM
  | PM

type Time = {
  Hours: int
  Minutes: int
  AMPM: AMPM
}
```
Note that Hours field should have integer values from 0 to 11, whereas Minutes
should have values from 0 to 59. Moreover, we assume that every input values
with type `Time` always have valid values.

Define a function `isEarly` that takes in two Time values `t1` and `t2` and
returns true if `t1` is earlier than `t2`. For example, when `t1` is `{ Hours =
1; Minutes = 30; AM }` and `t2` is `{ Hours = 1; Minutes = 0; PM }`, then the
function returns `true`. Note that if `t1` and `t2` are same, `isEarly` should
return `false`.

```fsharp
val isEarly : Time -> Time -> bool
```

### Problem 4

Define a function `addMinutes` that takes in a Time value `t` and an integer
value `m`, and returns a new Time value that is `m` minutes after `t`. If `m` is
negative, then the function returns a Time value that is `- m` minutes before
`t`.

```fsharp
val addMinutes : Time -> int -> Time
```

### Problem 5

Let us consider a straight line (y = ax + b) in the plane. We represent a
straight line with:
```fsharp
type StraightLine = a: int * b: int
```
Define a function `mirrorX` that takes in a StraightLine and returns a new
StraightLine mirrored around the x-axis. And, define a function `mirrorY` that
takes in a StraightLine and returns a new StraightLine mirrored around the
y-axis.

```fsharp
val mirrorX : StraightLine -> StraightLine
val mirrorY : StraightLine -> StraightLine
```


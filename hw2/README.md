# CS220 - HW2

Please read carefully the problems and fill out the `Library.fs` file. Note that
the unit tests will be replaced to new ones when we grade your homework, and
your grade will be based on the number of passed test cases. We recommend you to
modify only the `Library.fs` file for your homework. The deadline is before the
next class begins.

### Problem 1

Define a procedure `prob1` that takes three numbers (int) as arguments and
returns the sum of the squares of the two large numbers. If there is any error
in processing the inputs, e.g., integer overflows, then the function should
return `-1`.

### Problem 2

Define a function `prob2` that takes in a string and returns a new string that
ends with a newline character `'\n'`. The function appends a newline character
to the given string to produce a new one, but if the input string already ends
with a newline character, the function does not append an additional newline
character.  Note that a string in F# is indeed, an array of characters, and each
character in a string can be accessed through a dot operator. For example,
`str.[0]` returns the first character of the string `str`. Also, one can get the
length of a string `s` by calling a function `String.length`: `String.length s`
returns the length of the string `s`. Finally, you can append two strings using
the `+` operator.

### Problem 3

Write a function `prob3` that takes in three floating point numbers `a`, `b`,
and `c`, and returns a bigger root of the quadratic formula (in a floating point
number): <a
href="https://www.codecogs.com/eqnedit.php?latex=ax^2&space;&plus;&space;bx&space;&plus;&space;c&space;=&space;0"
target="_blank"><img
src="https://latex.codecogs.com/gif.latex?ax^2&space;&plus;&space;bx&space;&plus;&space;c&space;=&space;0"
title="ax^2 + bx + c = 0" /></a>. If there is only one root, then the function
returns the root. If there is a case where we cannot determine one or two roots
in the range of real numbers, the function should return `nan`, which is a
special floating point number representing "Not a Number".

### Problem 4

Define a function `prob4` that returns the number of days in a month. The
function takes in as input an integer representing a month, and outputs the
number of days. You can assume that February has 28 days. The function returns
`-1` for any error cases. For example, if a number big than 12 is given as
input, then the function should return `-1`.

### Problem 5

Define a function `prob5` that returns the number of days in a specific month of
a specific year (in Gregorian calendar). The function takes as input two
integers `year` and `month`, and returns the number of days of the specific year
and the month. The function returns `-1` for any error cases. As in `prob4`. The
signature of the function should look as `val prob5: int -> int -> int`.

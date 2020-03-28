# CS220 - HW9

Please read carefully the problems and fill out the `TextAnimation.fs` and
`Mandelbrot.fs` file. From now on, you can use any language features: your
function doesn't need to be purely functional (although function implementation
is preferred). The only restriction is that you cannot use external libraries:
you can use any APIs from .NET core, but not from other external packages. The
deadline is 23:59:59, 5/1.

### Problem 1

Implement the `makeAnimateFunction`, which takes in a string `s`, and returns an
imperative function whose signature is: `unit -> string`. The returned function
takes in a unit value as input, and returns a new string that swaps the case of
the first character of the string `s`: if the character is lower-case letter, it
will convert it to an upper case letter, and vice versa. However, this fuction
has a side-effect. It remembers the last index of the string that we swapped.
Therefore, when we run the function for the second time, it will return a new
string where the second character is swapped. When the swapping process reaches
the last character, then we select the first character again in the next run.

Suppose we have created a function `f` by `let f = makeAnimateFunction "aBCd"`.
then `f ()` will return `"ABCd"`, and `"abCd"`, for the first and the second
invocation, respectively. The fifth invocation and the first invocation, in this
example, should return the same result as the length of the given string is 4.
Please take a look at the `Main.fs` file to understand the usage of the
function.

Note that whenever we create a function using `makeAnimateFunction`, the newly
created function should start by swapping the first character.

### Problem 2

In this problem, you should compute the [Mandelbrot
set](https://en.wikipedia.org/wiki/Mandelbrot_set). We recommend you to read the
Wiki page first before you proceed. Your goal is to implement three functions in
total: `computeMandelbrot`, `toString`, and `toJsonString`.

##### `computeMandelbrot`

```fsharp
val computeMandelbrot: int -> int -> int -> float -> float -> float -> float -> int list list
```

This function takes in 7 arguments, and returns `int list list` (a list of
integer list). Arguments are described as follows:

    1. width: This value specifies the number of horizontal pixels to draw.
    2. height: This value specifies the number of vertical pixels to draw. In
       total we will output `width * height` pixels (or points).
    3. maxIter: The maximum number of iterations to run to check whether the
       given point is in the Mandelbrot set or not.
    4. xMin: The minimum x complex coordinate value.
    5. xMax: The maximum x complex coordinate value. The function will focus on
       computing elements within [xMin, xMax] in the x-axis of the complex
       coordinate space.
    6. yMin: The minimum y complex coordinate value.
    7. yMax: The maximum y complex coordinate value. The function will focus on
       computing elements within [yMin, yMax] in the y-axis of the complex
       coordinate space.

This function returns the result for each pixel on a screen. For 2-by-4 screen
(width = 4, height = 2), where there are only 8 pixels, and if x varies from
-2.0 to 1.0 and y varies from -1.0 to 1.0, this function returns a list that
looks like:

```fsharp
val
[ [1; 3; 4; 4]
  [0; 0; 0; 0] ]
```

The number 0 in the list means that the corresponding complex number is in the
Mandelbrot set. The number greater than 0 means the number of steps performed to
confirm that the corresponding complex number does not belong to the Mandelbrot
set by applying the recurrence formula:
![](https://wikimedia.org/api/rest_v1/media/math/render/svg/ea17613cecf92dbe8bb5f464a3862b08678ecd08)

To be clear, the very first "1" in the above list corresponds to the pixel at
the upper left corner of the screen, and the last "0" corresponds to the pixel
at the bottom right corner of the screen. And the upper left corner of the
screen corresponds to the point (xMin, yMax) in the complex plane.

**For this problem, always assume that the `int` parameters are greater than
zero, and do not consider integer overflow conditions. Also, `xMin (or yMin)` is
always smaller than `xMax (or yMax)`.**

##### `toString`

```fsharp
val toString: int list list -> string
```

This function gets the result from the `computeMandelbrot` function, and convert
the result into a multi-line string. Where each line corresponds to a row, and
each character in a line represents a pixel. If the pixel point is in the
Mandelbrot set, then it prints out an empty character `" "`, and otherwise, it
prints out a dot character `"."`. For example, if you run `computeMandelbrot`
with the following arguments, and convert the result with `toString`, you would
expect the following:

```
> dotnet run -- mandelbrot 60 20 100 -2.0 1.0 -1.0 1.0
........................................ ...................
............................................................
....................................    ....................
....................................    ....................
.............................. ..          .................
..............................                 .............
............................                   .............
...........................                     ............
.................       ..                      ............
................         .                      ............
                                              ..............
................         .                      ............
.................       ..                      ............
...........................                     ............
............................                   .............
..............................                 .............
.............................. ..          .................
....................................    ....................
....................................    ....................
............................................................
```

##### `toJsonString`

```fsharp
val toJsonString: int list list -> string
```

This function gets the result from the `computeMandelbrot` function, and convert
the result into a JSON string. [JSON](https://en.wikipedia.org/wiki/JSON) is a
simple text-based data encoding format, and your goal is to make a json file
that looks like:

```json
{
  "width": 60,
  "height": 20,
  "values": [
    [1,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,5,5,6,7,11,9,11,0,5,4,4,4,4,3,3,3,3,2,2,2,2,2,2,2,2,2,2],
    [1,1,1,1,1,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,6,8,9,36,24,11,8,6,5,5,4,4,4,4,3,3,3,3,3,2,2,2,2,2,2,2],
    [1,1,1,1,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,6,6,7,8,14,0,0,0,0,18,8,6,5,5,5,5,4,4,3,3,3,3,3,3,2,2,2,2,2],
    [1,1,1,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,5,5,6,7,8,8,8,8,9,10,14,0,0,0,0,13,10,9,8,6,6,6,18,5,4,4,3,3,3,3,3,2,2,2,2],
    [1,1,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,4,4,4,4,5,5,5,5,6,6,7,12,42,0,16,26,0,0,0,0,0,0,0,0,0,0,20,12,14,15,16,15,5,4,3,3,3,3,3,3,2,2,2],
    [1,1,2,3,3,3,3,3,3,3,3,3,3,3,4,4,5,5,5,5,5,5,5,6,6,6,8,14,12,62,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,20,7,6,5,4,3,3,3,3,3,3,2,2],
    [1,2,3,3,3,3,3,3,3,4,4,4,5,5,7,12,7,7,7,7,7,7,7,7,7,8,11,20,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,9,19,5,4,4,3,3,3,3,3,3,2],
    [1,3,3,3,4,4,4,4,4,4,5,5,5,6,7,10,16,20,12,13,35,13,11,9,9,11,24,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,8,6,4,4,3,3,3,3,3,3,3],
    [1,3,4,4,4,4,4,4,5,5,5,5,6,7,8,11,18,0,0,0,0,0,0,0,15,16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,31,7,5,4,4,4,3,3,3,3,3,3],
    [1,4,4,4,4,4,6,6,6,6,7,8,12,13,14,22,0,0,0,0,0,0,0,0,0,33,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,6,5,4,4,4,3,3,3,3,3,3],
    [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,12,8,7,6,5,4,4,4,3,3,3,3,3,3],
    [1,4,4,4,4,4,6,6,6,6,7,8,12,13,14,22,0,0,0,0,0,0,0,0,0,33,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,6,5,4,4,4,3,3,3,3,3,3],
    [1,3,4,4,4,4,4,4,5,5,5,5,6,7,8,11,18,0,0,0,0,0,0,0,15,16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,31,7,5,4,4,4,3,3,3,3,3,3],
    [1,3,3,3,4,4,4,4,4,4,5,5,5,6,7,10,16,20,12,13,35,13,11,9,9,11,24,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,8,6,4,4,3,3,3,3,3,3,3],
    [1,2,3,3,3,3,3,3,3,4,4,4,5,5,7,12,7,7,7,7,7,7,7,7,7,8,11,20,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,9,19,5,4,4,3,3,3,3,3,3,2],
    [1,1,2,3,3,3,3,3,3,3,3,3,3,3,4,4,5,5,5,5,5,5,5,6,6,6,8,14,12,62,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,20,7,6,5,4,3,3,3,3,3,3,2,2],
    [1,1,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,4,4,4,4,5,5,5,5,6,6,7,12,42,0,16,26,0,0,0,0,0,0,0,0,0,0,20,12,14,15,16,15,5,4,3,3,3,3,3,3,2,2,2],
    [1,1,1,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,5,5,6,7,8,8,8,8,9,10,14,0,0,0,0,13,10,9,8,6,6,6,18,5,4,4,3,3,3,3,3,2,2,2,2],
    [1,1,1,1,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,6,6,7,8,14,0,0,0,0,18,8,6,5,5,5,5,4,4,3,3,3,3,3,3,2,2,2,2,2],
    [1,1,1,1,1,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,5,5,5,6,8,9,36,24,11,8,6,5,5,4,4,4,4,3,3,3,3,3,2,2,2,2,2,2,2]
  ]
}
```

There are total of three fields: "width", "height", and "values". The "values"
field contains a JSON array (of JSON array), representing the result from the
`computeMandelbrot` function. "width" and "height" field represent the number of
horizontal and vertical pixels for the image, respectively.

#### YOU SHOULD NOT ASK QUESTIONS ABOUT ERROR HANDLING. WE WILL DEDUCT YOUR POINTS IF YOU DO SO.


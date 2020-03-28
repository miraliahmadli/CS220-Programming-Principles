# CS220 - HW10

Please read carefully the problems and fill out the `Minimax.fs` and
`BoardHelper.fs` file. You can use any language features: your function doesn't
need to be purely functional (although function implementation is preferred).
The only restriction is that you cannot use external libraries: you can use any
APIs from .NET core, but not from other external packages. The deadline is
23:59:59, 5/8.

In this assignment, your goal is to create a tic-tac-toe game. In case you don't
know what the game is, you should read the
[wiki](https://en.wikipedia.org/wiki/Tic-tac-toe) page. You can only modify two
fs files mentioned above, and your goal is to write the following three
functions.

### `BoardHelper.checkWinner`

```fsharp
val BoardHelper.checkWinner: SlotState [] -> Marker option
```

This function takes in the current state of the game board as an array of
`SlotState`, and returns `Marker option`, which indicates `Some` winner if
exists. If there is no winner yet, the function returns `None`. This function
does not predict the next moves. It simply reads the current states and decides
whether the game has a winner or not. If there is a winner, then it returns the
winner's marker (either 'O' or 'X').

### `BoardHelper.isDraw`

```fsharp
val BoardHelper.isDraw: SlotState [] -> bool
```

This function checks if the game is over in draw. Similar to `checkWinner`
function, this function does *not* predict the next moves. It simply checks the
current board state, and decides whether it is over or not. For example, even if
there is only one empty slot left, and it is clear that the game will end in
draw after that move, this function will not return true.

### `MinimaxStrategy.NextMove`

The `MinimaxStrategy` class implements the `AI` interface, which has one
abstract member, called `NextMove`. This function takes in the current player's
Marker and a `Board` object as input, and returns an integer, representing the
next move. For example, if the function takes in `X` and returns 2, it means
that we want to mark the second slot of the board with `X`. For your reference,
you can see `RandomStrategy` class to understand how the `NextMove` function can
be implemented.

Your goal here is to write an unbeatable tic-tac-toe strategy. In other words,
you should create a function that always return an optimal move. It is well
known that if two players always perform optimal moves, the game will end in
draw (refer to the wiki page). One simple and recursive way of finding the
optimal solution is to use an algorithm called
["Minimax"](https://en.wikipedia.org/wiki/Minimax). The key idea is to always
chose the maximum score for your moves, while always choosing the minimum score
for the opponent's moves. You should write your own algorithm on the given
tic-tac-toe infrastructure we gave. You should not modify files other than the
two files mentioned above.

Note that the code is mixture of functional data structures and OOP-style
objects, which encapsulate various concepts appeared in the tic-tac-toe game. A
part of the homework is to understand the skeleton code that we provide. It
contains all necessary functions and classes for your homework. If you
successfully write the three functions, then you should be able to play a "real"
game on your own machine (against your own AI)!

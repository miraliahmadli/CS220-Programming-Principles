# CS220 - HW11

Please read carefully the problems and fill out several fs files that we show
below (not fsi files). You can use any language features: your function doesn't
need to be purely functional (although function implementation is preferred).
The only restriction is that you cannot use external libraries: you can use any
APIs from .NET core, but not from other external packages. The deadline is
23:59:59, 5/15.

### Introduction

In this assignment, you are going write a simluator for a [whac-a-mole
game](https://en.wikipedia.org/wiki/Whac-A-Mole). You will learn that one can
model the game using streams in an elegant manner. In our model, we split time
into a stream of (a sequence of) epochs, and we obtain two distinct events per
each epoch. You will implement two event streams and a score evaluator taking
the event streams as input.

### Basic Setting

We assuem 3x3 whac-a-mole game, where there are 9 holes as follows:
```
 1 | 2 | 3
---+---+---
 4 | 5 | 6
---+---+---
 7 | 8 | 9
```
There is one mole for each hole.

### Position Stream

Your goal here is to implement the `create` function in `Position.fs`.
`PositionStream` is an **infinite** stream of pseudo-random positions (from 1 to
9).  We use a linear congruential generator where its state is updated with the
following algorithm:
```
nextState := (214013 * currentState + 2531011) % (2^31)
r := nextState % 9
```
This stream always return a new `r` value while updating its state using the
above formula.

### Mole Event Stream

A mole event (MoleEvent) represents an event that may occur for the 9 moles in
the game. We assume only one out of the nine moles can generate an event for one
epoch. There are only two possible events: (1) one of the moles pops up, or (2)
none of them pops up. When a mole is popped up in epoch `t`, it will move back
at `t + 3`.  Therefore, a player can hit the mole during three epochs. When a
pop-up event occurs for the same mole at `t` and `t + 1`, then the mole will
remain active until `t + 3`, and will move back at `t + 4`.

The `MoleEventStream.create` function in `Mole.fs` needs to be implemented. It
creates an infinite stream that internally uses a `PositionStream` to create a
random position for `MoleEvent`. The function takes in two parameters: `freq`
and `seed`. The `freq` parameter decides how often a pop-up event should be
fired. If `freq` is 3, it means that the resulting stream will have a pop-up
event every 3 epochs, i.e., 1st, 4th, 7th, 10th epoch, etc. The `seed` parameter
is passed directly to a `PositionStream` to decide the next pop-up position.

### Mallet Event Stream

A mallet event (MalletEvent) represents an action of a player (with a mallet).
For simplicity, we assume that the player will always hit something for every
epoch (no miss shot!). MalletEventStream represents an infinite stream of mallet
events.

The `MalletEventStream.create` function in `Mallet.fs` should be implemented.
The function takes in a seed as input, and returns an infinite stream of mallet
events. The function internally has a `PositionStream` to randomly generating
hitting positions for MalletEvents. The `seed` parameter of the
`MalletEventStream.create` function is passed directly to the `PositionStream`.

### Score Evaluation

Finally, you need to implement the `Score.compute` function in `Score.fs` file.
We simply assume that we always receive one event from both MoleEventStream and
MalletEventStream. This way, we can simulate the whole movements of both player
and the moles in an elegant way without relying on mutable states.

The function takes in the number of epochs to simulate as input along with the
two event streams (MoleEventStream and MalletEventStream). As a result, it
returns a score (uint32). As discussed above, a mole is activated for three
epcohs. Therefore, if there is a hit on the mole within three epochs, the player
gets +1 score. Let's consider the following scenario with 10 epochs.

```
         -------------------------------->
epochs:   t1 t2 t3 t4 t5 t6 t7 t8 t9 t10
mallet:    1  2  3  4  5  6  7  8  9   3
mole:      9  8  7  6  5  4  3  2  1   9
hit?                   o  o
```

In the first epoch, the 9th mole has popped up, and the player hit the first
hole. In the second epoch, the 8th mole has popped up, and the player hit the
second hole. We can see that the player earned points at `t5` and `t6`. Note
that at `t5` the fifth mole popped up, and the player hit the mole at the same
time. We assume that if both mallet and mole event occurred in the same hole at
the same epoch, the player gets a point.


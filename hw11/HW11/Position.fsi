namespace HW11

/// Position of a mole in the game. We are assuming 3x3 game board with 9 holes.
/// Each hole is numbered as follows.
///
///  1 | 2 | 3
/// ---+---+---
///  4 | 5 | 6
/// ---+---+---
///  7 | 8 | 9
type Position = int

type PositionStream = seq<Position>

module PositionStream =
  /// Create an infinite stream of pseudo-random position (from 1 to 9) for the
  /// game. This function internally implements linear congruential generator
  /// using the following formula: state_1 = (214013 * state_0 + 2531011) %
  /// (2^31). The stream will return (state_n % 9) as a random position value.
  val create: seed: int -> PositionStream

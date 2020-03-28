namespace HW11

/// Mole can either pop up or stay hidden (i.e., nothing happened).
type MoleEvent =
  | Popup of Position
  | NothingHappened

/// Stream of mole events for a whack-a-mole game.
type MoleEventStream = seq<MoleEvent>

module MoleEventStream =
  /// Create an infinite stream of MoleEvents. The freq parameter determines how
  /// often a mole pops up in the stream. For example, when freq = 5, a mole
  /// should pop up every five events: a mole should pop up at the (1+5n)th
  /// event. This stream internally creates the PositionStream with the given
  /// seed to decide the position of the mole when it pops up. Naturally,
  /// PositionStream will be applied in a lazy manner: only when a Popup event
  /// occurs.
  val create: freq: uint32 -> seed: int -> MoleEventStream

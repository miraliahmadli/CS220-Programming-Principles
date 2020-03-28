module HW11.Score

/// Compute the score after the number of epochs. We assume that one MoleEvent
/// and one MalletEvent always occurs per each epoch. A mole, which has popped
/// up, will last for three epochs including the current epoch. If there is a
/// MalletEvent for the mole (in the same position) during the period, then a
/// player earns +1 score, When there are two pop-up events for the same mole
/// within three epochs, then we will simply reset the epoch counter and keep
/// the mole popped up for next two epochs. If both MoleEvent and MalletEvent of
/// the same position occurred at the same epoch, we also give +1 score. In
/// other words, we assume that a player can successfully hit the mole if both
/// the mole event and the mallet event occurred at the same epoch. Let t1, t2,
/// ..., tn be n different epochs, and let numbers between 1 and 9 be a position
/// of a hole.
///
///          -------------------------------->
/// epochs:   t1 t2 t3 t4 t5 t6 t7 t8 t9 t10
/// mallet:    1  2  3  4  5  6  7  8  9   3
/// mole:      9  8  7  6  5  4  3  2  1   9
/// hit?                   o  o
///
/// In the above case, the score will become 2 after 10 epochs, because we have
/// hit two moles at epoch t5 and t6.
val compute: MoleEventStream -> MalletEventStream -> epochs: uint32 -> uint32

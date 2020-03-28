namespace HW8

open HW8.RationalNumber
open HW8.RationalNumberOperation

module MyLibrary =
  let pi = make Positive 355ul 113ul
  let one = make Positive 1ul 1ul
  let two = make Positive 2ul 1ul
  let four = make Positive 4ul 1ul

  /// Approximated arctan. Why? See: http://www-labs.iro.umontreal.ca/~mignotte/IFT2425/Documents/EfficientApproximationArctgFunction.pdf
  let arctan x =
    if le x one && ge x (minus one) then Some (mul (div pi four) x)
    else None

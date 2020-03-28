// XXX: DO NOT MODIFY THIS FILE.
namespace HW8

/// Raised when any error happens during computation. For example, when dividing
/// a number by zero, or when integer overflow happens.
exception ComputationErrorException

/// Rational number can be either positive or negative.
type Sign =
  | Positive
  | Negative

/// Rational number is any number that can be expressed as the quotient of two
/// integers. In this implementation, we use uint32 for both numerator and
/// denominator. Therefore, the maximum rational number that we can represent
/// with this type is (System.UInt32.MaxValue / 1), and the minimum value is
/// (- System.UInt32.MaxValue / 1).
[<CustomComparison;CustomEquality>]
type RationalNumber =
  private {
    Numerator: uint32
    Denominator: uint32
    Sign: Sign }
  override __.GetHashCode () = hash (__.Numerator, __.Denominator, __.Sign)
  override __.Equals (_) =
    failwith "Use eq, neq in RationalNumberOperation module"
  interface System.IComparable with
    member __.CompareTo _ =
      failwith "Use gt, ge, lt, le in RationalNumberOperation module"

module RationalNumber =
  /// Get numerator.
  let numer (n: RationalNumber) = n.Numerator

  /// Get denominator.
  let denom (n: RationalNumber) = n.Denominator

  /// Get sign.
  let sign (n: RationalNumber) = n.Sign

  /// Create a rational number from given a sign, numerator, and denominator.
  let make (sign: Sign) (numer: uint32) (denom: uint32): RationalNumber =
    if denom = 0ul then raise ComputationErrorException
                   else { Numerator = numer; Denominator = denom; Sign = sign }

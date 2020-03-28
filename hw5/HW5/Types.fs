namespace HW5

type Shape =
  | Circle of float
  | Square of float
  | Triangle of float * float * float

type AMPM =
  | AM
  | PM

type Time = {
  Hours: int
  Minutes: int
  AMPM: AMPM
}

type StraightLine = StraightLine of a: int * b: int

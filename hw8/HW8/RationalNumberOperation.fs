module HW8.RationalNumberOperation

open RationalNumber

let rec gcd a b =
    if b=0ul then a
    else gcd b (a%b)

let rec gcd2 a b =
    if b=0UL then a
    else gcd2 b (a%b)

let sameadd (n1: RationalNumber) (n2: RationalNumber): RationalNumber =
    let v1 = gcd (numer n1) (denom n1)
    let v2= gcd (numer n2) (denom n2)
    let ne1 =make (sign n1) ((numer n1)/v1) ((denom n1)/v1)
    let ne2 =make (sign n2) ((numer n2)/v2) ((denom n2)/v2)
    let g = gcd (denom ne1) (denom ne2)
    let lcm = (uint64 (denom ne1))/(uint64 g)*(uint64 (denom ne2))
    let q1 = (denom ne1)/g
    let q2 = (denom ne2)/g
    let num1 = (uint64 (numer ne1))*(uint64 q2)
    let num2 = (uint64 (numer ne2))*(uint64 q1)
    if (g=1ul) || ((num1%(uint64 g)+num2%(uint64 g))%(uint64 g)<>0UL) then 
                    if num1>4294967295UL || num2>4294967295UL then raise ComputationErrorException
                    elif num1> 4294967295UL-num2 then raise ComputationErrorException
                    elif lcm>4294967295UL then raise ComputationErrorException
                    else make (sign n1) (uint32 (num1+num2)) (uint32 lcm)
    else 
                    let nu1 = num1/(uint64 g)
                    let nu2 = num2/(uint64 g)
                    let den = (uint64 q1)*(uint64 q2)
                    if nu1>4294967294UL || nu2>4294967294UL then raise ComputationErrorException
                    elif nu1> 4294967294UL-nu2 then raise ComputationErrorException
                    elif den>4294967295UL then raise ComputationErrorException
                    else make (sign n1) (uint32 (nu1+nu2+1UL)) (uint32 den)
      

let rec samesub (n1: RationalNumber) (n2: RationalNumber): RationalNumber =
    let gt (n1: RationalNumber) (n2: RationalNumber): bool =
          if (numer n1)=0u && (numer n2)=0u then false
          else 
              if (sign n1) = Positive && (sign n2)=Negative then true
              elif (sign n1)=Negative && (sign n2)=Positive then false
              else 
                    if (sign n1)=Positive then (uint64 (numer n1))*(uint64 (denom n2)) > (uint64 (numer n2))*(uint64 (denom n1))
                    else (uint64 (numer n1))*(uint64 (denom n2)) < (uint64 (numer n2))*(uint64 (denom n1))
    let minus (n: RationalNumber): RationalNumber =
        let s = if (sign n)=Negative then Positive else Negative
        make s (numer n) (denom n)
    let abs (n: RationalNumber): RationalNumber =
        make Positive (numer n) (denom n)
    if gt (abs n2) (abs n1) then
        samesub (minus n2) (minus n1)
    else 
        let v1 = gcd (numer n1) (denom n1)
        let v2= gcd (numer n2) (denom n2)
        let ne1 =make (sign n1) ((numer n1)/v1) ((denom n1)/v1)
        let ne2 =make (sign n2) ((numer n2)/v2) ((denom n2)/v2)
        let g = gcd (denom ne1) (denom ne2)
        let lcm = (uint64 (denom ne1))/(uint64 g)*(uint64 (denom ne2))
        let q1 = (denom ne1)/g
        let q2 = (denom ne2)/g
        let num1 = (uint64 (numer ne1))*(uint64 q2)
        let num2 = (uint64 (numer ne2))*(uint64 q1)
        if (g=1ul) || (num1%(uint64 g)<>num2%(uint64 g)) then 
                    if num1-num2 > 4294967295UL then raise ComputationErrorException
                    elif lcm>4294967295UL then raise ComputationErrorException
                    else make (sign n1) (uint32 (num1-num2)) (uint32 lcm)
        else 
                    let nu1 = num1/(uint64 g)
                    let nu2 = num2/(uint64 g)
                    let den = (uint64 q1)*(uint64 q2)
                    if nu1-nu2>4294967295UL then raise ComputationErrorException
                    elif den>4294967295UL then raise ComputationErrorException
                    else make (sign n1) (uint32 (nu1-nu2)) (uint32 den)   
/// n1 + n2
let add (n1: RationalNumber) (n2: RationalNumber): RationalNumber =
  if (sign n1) = (sign n2) then sameadd n1 n2
  else samesub n1 (make (sign n1) (numer n2) (denom n2))

/// n1 - n2
let sub (n1: RationalNumber) (n2: RationalNumber): RationalNumber =
  if (sign n1) = (sign n2) then samesub n1 n2
  else sameadd n1 (make (sign n1) (numer n2) (denom n2))

/// n1 * n2
let mul (n1: RationalNumber) (n2: RationalNumber): RationalNumber =
  let m1 = (uint64 (numer n1))*(uint64 (numer n2))
  let m2 = (uint64 (denom n1))*(uint64 (denom n2))
  let g = gcd2 m1 m2
  let t1 = m1/g
  let t2 = m2/g
  let s = if (sign n1) = (sign n2) then Positive
          else Negative
  if t1>4294967295UL || t2>4294967295UL then raise ComputationErrorException
  else //{Sign=s; Numerator=uint32(t1); Denominator=uint32(t2)}
       make s (uint32 t1) (uint32 t2)
/// n1 / n2
let div (n1: RationalNumber) (n2: RationalNumber): RationalNumber =
  if (numer n2)=0ul then raise ComputationErrorException
  else mul n1 (make (sign n2) (denom n2) (numer n2))

/// n1 = n2
let eq (n1: RationalNumber) (n2: RationalNumber): bool =
    let g1 = gcd (numer n1) (denom n1)
    let g2 = gcd (numer n2) (denom n2)
    let p1 = (numer n1)/g1
    let p2 = (numer n2)/g2
    let q1 = (denom n1)/g1
    let q2 = (denom n2)/g2
    ((numer n1)=0ul && (numer n2)=0ul)||(((sign n1)=(sign n2))&&(p1=p2)&&(q1=q2))
/// n1 <> n2
let neq (n1: RationalNumber) (n2: RationalNumber): bool =
    (eq n1 n2) = false

/// n1 > n2
let gt (n1: RationalNumber) (n2: RationalNumber): bool =
    if (numer n1)=0u && (numer n2)=0u then false
    else 
        if (sign n1) = Positive && (sign n2)=Negative then true
        elif (sign n1)=Negative && (sign n2)=Positive then false
        else 
            if (sign n1)=Positive then (uint64 (numer n1))*(uint64 (denom n2)) > (uint64 (numer n2))*(uint64 (denom n1))
            else (uint64 (numer n1))*(uint64 (denom n2)) < (uint64 (numer n2))*(uint64 (denom n1))

/// n1 >= n2
let ge (n1: RationalNumber) (n2: RationalNumber): bool =
  (gt n1 n2) || (eq n1 n2)

/// n1 < n2
let lt (n1: RationalNumber) (n2: RationalNumber): bool =
  (ge n1 n2) = false

/// n1 <= n2
let le (n1: RationalNumber) (n2: RationalNumber): bool =
    (gt n1 n2) = false

/// - n
let minus (n: RationalNumber): RationalNumber =
    let s = if (sign n)=Negative then Positive else Negative
    make s (numer n) (denom n)

/// | n |
let abs (n: RationalNumber): RationalNumber =
    make Positive (numer n) (denom n)

/// Convert the given rational number n to a rounded int. For example, given
/// 1/2, the function should return 1. Given 1/3, the function should return 0.
let toInt (n: RationalNumber): int =
  let div = (numer n)/(denom n)
  let v = (numer n)%(denom n)
  if v = (denom n)-v &&  (sign n)=Positive then 
                        if div>=2147483647ul then raise ComputationErrorException 
                        else int(div)+1
  elif v > (denom n)-v then
                        if (sign n)=Positive then 
                                      if div>=2147483647ul then raise ComputationErrorException 
                                      else int(div)+1
                        else 
                                      if div>=2147483648ul then raise ComputationErrorException
                                      else -int(div)-1
  else
        if (sign n)=Positive then 
                        if div>2147483647ul then raise ComputationErrorException 
                        else int(div)
        else 
                        if div>2147483648ul then raise ComputationErrorException
                        else -int(div)

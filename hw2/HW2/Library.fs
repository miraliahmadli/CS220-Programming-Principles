module HW2.MySolution
///open System.Windows.Forms

/// FIXME
let prob1 a b c =
    let m1 = if (a>=b && a>=c) then a
             elif (b>=a && b>=c) then b
             else c
    let m2 = if a<>m1 && (a>=b || a>=c) then a
             elif b<>m1 && (b>=a || b>=c) then b
             else c
    if (m1>46340 || m2< -46340) then -1
    else
      let s1 = m1*m1
      let s2 = m2*m2
      if 2147483647-s1<s2 then -1
      else s1+s2

   

/// FIXME
let prob2 str =
    let len = String.length str
    if len=0 then "\n"
    else 
        if str.[len-1]='\n' then str
        else str+"\n"

/// FIXME
let prob3 a b c =
    if a=0.0 then 
            if b=0.0 then nan
            else (float -(double c)/(double b))
    else
        let discr = b*b - 4.0*a*c
        if discr<0.0 then nan
        elif discr=0.0 then 
            (float -(b|>double)/((2 |> double) * (a |> double)))
        else 
            let r1= ((-(double b)+sqrt (double discr))/((double 2)*(double a)))
            let r2= ((-(double b)-sqrt (double discr))/((double 2)*(double a)))
            if r1>r2 then r1 else r2

/// FIXME
let prob4 month =
    match month with 
      | 1 -> 31
      | 2 -> 28
      | 3 -> 31
      | 4 -> 30
      | 5 -> 31
      | 6 -> 30
      | 7 -> 31
      | 8 -> 31
      | 9 -> 30
      | 10 -> 31
      | 11 -> 30
      | 12 -> 31  
      | _ -> -1 

/// FIXME
let prob5 year month =
  if year=1582 && month=10 then 21
  else
    if year<1 then -1
    elif (year%4<>0 || (year%100=0 && year%400<>0)) then prob4 month
    else
        if month=2 then 29
        else prob4 month


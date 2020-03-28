module HW4.MySolution

// Problem 1
let prob1 a b =
  let rec func start finish count = 
    if start > finish then count
    elif start%7=0 && start%5<>0 then func (start+7) finish (count+1)
    else func (start+7) finish count
  if a<1 || a>b ||b<1 then -1
  else 
    let rem = a%7
    if rem=0 then func a b 0
    else func (a+7-rem) b 0


// Problem 2
let pow s n =
  let rec mult (str: string) curr max va= 
    if curr>max then str
    else mult (str+va) (curr+1) max va
  let rec reverse (str: string) curr max (va: string) = 
    if curr>max then str
    else reverse ((string va.[curr-1])+str) (curr+1) max va
  if n=0 then ""
  elif n>0 then mult "" 1 n s
  else 
    let len = String.length s
    if len=0 then ""
    else 
      let re = reverse "" 1 len s
      if n=(-2147483648) then mult re 1 2147483647 re
      else mult "" 1 -n re

// Problem 3
let smallestDivisor (n: uint32) =
  let rec find (curr: uint32) (max: uint32) = 
    if curr>max then max
    elif max%curr=0u then curr
    else find (curr+1u) max
  if (n=1u || n=0u) then 0u
  else find 2u n

// Problem 4
let isPrime n =
  let va = smallestDivisor n
  (n<>0u)&&(n=va)

// Problem 5
let isFeasible (a: uint32) (b: uint32) (c: uint32) =
  let rec calc va curr max =
    if curr>max then va
    else calc (va+curr) (curr+1u) max
  let rec check sum curr mi goal= 
    if curr<mi || curr<goal then false
    elif sum=goal then true
    elif sum<2u*curr then check sum (curr-1u) mi goal
    else (check sum (curr-1u) mi goal)||(check (sum-(2u*curr)) (curr-1u) mi goal)
  if a>b then false
  elif a=b then  a=c
  elif a=b+1u then c=2u*a+1u
  else  
      let ans = calc 0u a b
      if (ans%2u)<>(c%2u) then false
      elif b>=2u*a+2u then c<=ans-2u*a-2u
      else check ans b (a+1u) c

